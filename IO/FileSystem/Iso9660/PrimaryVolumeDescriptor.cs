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

namespace RC.Framework.FileSystem.Iso9660
{
    using System;
    using System.Text;

    internal class PrimaryVolumeDescriptor : CommonVolumeDescriptor
    {
        public PrimaryVolumeDescriptor(byte[] src, int offset)
            : base(src, offset, Encoding.ASCII)
        {
        }

        public PrimaryVolumeDescriptor(
            uint volumeSpaceSize,
            uint pathTableSize,
            uint typeLPathTableLocation,
            uint typeMPathTableLocation,
            uint rootDirExtentLocation,
            uint rootDirDataLength,
            DateTime buildTime)
            : base(VolumeDescriptorType.Primary, version: 1, volumeSpaceSize: volumeSpaceSize, pathTableSize: pathTableSize, typeLPathTableLocation: typeLPathTableLocation, typeMPathTableLocation: typeMPathTableLocation, rootDirExtentLocation: rootDirExtentLocation, rootDirDataLength: rootDirDataLength, buildTime: buildTime, enc: Encoding.ASCII)
        {
        }

        internal override void WriteTo(byte[] buffer, int offset)
        {
            base.WriteTo(buffer, offset);
            IsoUtilities.WriteAChars(buffer, offset + 8, numBytes: 32, str: SystemIdentifier);
            IsoUtilities.WriteString(buffer, offset + 40, numBytes: 32, pad: true, str: VolumeIdentifier, enc: Encoding.ASCII, canTruncate: true);
            IsoUtilities.ToBothFromUInt32(buffer, offset + 80, VolumeSpaceSize);
            IsoUtilities.ToBothFromUInt16(buffer, offset + 120, VolumeSetSize);
            IsoUtilities.ToBothFromUInt16(buffer, offset + 124, VolumeSequenceNumber);
            IsoUtilities.ToBothFromUInt16(buffer, offset + 128, LogicalBlockSize);
            IsoUtilities.ToBothFromUInt32(buffer, offset + 132, PathTableSize);
            IsoUtilities.ToBytesFromUInt32(buffer, offset + 140, TypeLPathTableLocation);
            IsoUtilities.ToBytesFromUInt32(buffer, offset + 144, OptionalTypeLPathTableLocation);
            IsoUtilities.ToBytesFromUInt32(buffer, offset + 148, Utilities.BitSwap(TypeMPathTableLocation));
            IsoUtilities.ToBytesFromUInt32(buffer, offset + 152, Utilities.BitSwap(OptionalTypeMPathTableLocation));
            RootDirectory.WriteTo(buffer, offset + 156, Encoding.ASCII);
            IsoUtilities.WriteDChars(buffer, offset + 190, numBytes: 129, str: VolumeSetIdentifier);
            IsoUtilities.WriteAChars(buffer, offset + 318, numBytes: 129, str: PublisherIdentifier);
            IsoUtilities.WriteAChars(buffer, offset + 446, numBytes: 129, str: DataPreparerIdentifier);
            IsoUtilities.WriteAChars(buffer, offset + 574, numBytes: 129, str: ApplicationIdentifier);
            IsoUtilities.WriteDChars(buffer, offset + 702, numBytes: 37, str: CopyrightFileIdentifier); // FIXME!!
            IsoUtilities.WriteDChars(buffer, offset + 739, numBytes: 37, str: AbstractFileIdentifier); // FIXME!!
            IsoUtilities.WriteDChars(buffer, offset + 776, numBytes: 37, str: BibliographicFileIdentifier); // FIXME!!
            IsoUtilities.ToVolumeDescriptorTimeFromUTC(buffer, offset + 813, CreationDateAndTime);
            IsoUtilities.ToVolumeDescriptorTimeFromUTC(buffer, offset + 830, ModificationDateAndTime);
            IsoUtilities.ToVolumeDescriptorTimeFromUTC(buffer, offset + 847, ExpirationDateAndTime);
            IsoUtilities.ToVolumeDescriptorTimeFromUTC(buffer, offset + 864, EffectiveDateAndTime);
            buffer[offset + 881] = FileStructureVersion;
        }
    }
}
