//
// Copyright (c) 2008-2011, Kenneth Bell
//

// copy of this software and associated documentation files (the "Software"),
// to deal in the Software without restriction, including without limitation
// the rights to use, copy, modify, merge, publish, distribute, sublicense,
// and/or sell copies of the Software, and to permit persons to whom the
// Software is furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
// DEALINGS IN THE SOFTWARE.
//

namespace RC.Framework.FileSystem.Vhd
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    internal sealed class DynamicDiskBuilder : StreamBuilder
    {
        private SparseStream _content;
        private Footer _footer;
        private uint _blockSize;

        public DynamicDiskBuilder(SparseStream content, Footer footer, uint blockSize)
        {
            _content = content;
            _footer = footer;
            _blockSize = blockSize;
        }

        internal override List<BuilderExtent> FixExtents(out long totalLength)
        {
            const int FooterSize = 512;
            const int DynHeaderSize = 1024;

            List<BuilderExtent> extents = new List<BuilderExtent>();

            _footer.DataOffset = FooterSize;

            DynamicHeader dynHeader = new DynamicHeader(dataOffset: -1, tableOffset: FooterSize + DynHeaderSize, blockSize: _blockSize, diskSize: _footer.CurrentSize);

            BlockAllocationTableExtent batExtent = new BlockAllocationTableExtent(FooterSize + DynHeaderSize, dynHeader.MaxTableEntries);

            long streamPos = batExtent.Start + batExtent.Length;

            foreach (var blockRange in StreamExtent.Blocks(_content.Extents, _blockSize))
            {
                for (int i = 0; i < blockRange.Count; ++i)
                {
                    long block = blockRange.Offset + i;
                    long blockStart = block * _blockSize;
                    DataBlockExtent dataExtent = new DataBlockExtent(streamPos, new SubStream(_content, blockStart, Math.Min(_blockSize, _content.Length - blockStart)));
                    extents.Add(dataExtent);

                    batExtent.SetEntry((int)block, (uint)(streamPos / Sizes.Sector));

                    streamPos += dataExtent.Length;
                }
            }

            _footer.UpdateChecksum();
            dynHeader.UpdateChecksum();

            byte[] footerBuffer = new byte[FooterSize];
            _footer.ToBytes(footerBuffer, offset: 0);

            byte[] dynHeaderBuffer = new byte[DynHeaderSize];
            dynHeader.ToBytes(dynHeaderBuffer, offset: 0);

            // Add footer (to end)
            extents.Add(new BuilderBufferExtent(streamPos, footerBuffer));
            totalLength = streamPos + FooterSize;

            extents.Insert(index: 0, item: batExtent);
            extents.Insert(index: 0, item: new BuilderBufferExtent(FooterSize, dynHeaderBuffer));
            extents.Insert(index: 0, item: new BuilderBufferExtent(start: 0, buffer: footerBuffer));

            return extents;
        }

        private class BlockAllocationTableExtent : BuilderExtent
        {
            private uint[] _entries;
            private MemoryStream _dataStream;

            public BlockAllocationTableExtent(long start, int maxEntries)
                : base(start, Utilities.RoundUp(maxEntries * 4, unit: 512))
            {
                _entries = new uint[Length / 4];
                for (int i = 0; i < _entries.Length; ++i)
                {
                    _entries[i] = 0xFFFFFFFF;
                }
            }

            public void SetEntry(int index, uint fileSector)
            {
                _entries[index] = fileSector;
            }

            internal override void PrepareForRead()
            {
                byte[] buffer = new byte[Length];

                for (int i = 0; i < _entries.Length; ++i)
                {
                    Utilities.WriteBytesBigEndian(_entries[i], buffer, i * 4);
                }

                _dataStream = new MemoryStream(buffer, writable: false);
            }

            internal override int Read(long diskOffset, byte[] block, int offset, int count)
            {
                _dataStream.Position = diskOffset - Start;
                return _dataStream.Read(block, offset, count);
            }

            internal override void DisposeReadState()
            {
                _dataStream = null;
            }
        }

        private class DataBlockExtent : BuilderExtent
        {
            private SparseStream _content;
            private MemoryStream _bitmapStream;

            public DataBlockExtent(long start, SparseStream content)
                : base(start, Utilities.RoundUp(Utilities.Ceil(content.Length, Sizes.Sector) / 8, Sizes.Sector) + Utilities.RoundUp(content.Length, Sizes.Sector))
            {
                _content = content;
            }

            internal override void PrepareForRead()
            {
                byte[] bitmap = new byte[Utilities.RoundUp(Utilities.Ceil(_content.Length, Sizes.Sector) / 8, Sizes.Sector)];

                foreach (var range in StreamExtent.Blocks(_content.Extents, Sizes.Sector))
                {
                    for (int i = 0; i < range.Count; ++i)
                    {
                        byte mask = (byte)(1 << (7 - ((int)(range.Offset + i) % 8)));
                        bitmap[(range.Offset + i) / 8] |= mask;
                    }
                }

                _bitmapStream = new MemoryStream(bitmap, writable: false);
            }

            internal override int Read(long diskOffset, byte[] block, int offset, int count)
            {
                long position = diskOffset - Start;
                if (position < _bitmapStream.Length)
                {
                    _bitmapStream.Position = position;
                    return _bitmapStream.Read(block, offset, count);
                }
                else
                {
                    _content.Position = position - _bitmapStream.Length;
                    return _content.Read(block, offset, count);
                }
            }

            internal override void DisposeReadState()
            {
                _bitmapStream = null;
            }
        }
    }
}
