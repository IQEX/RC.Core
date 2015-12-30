﻿//
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

namespace RC.Framework.FileSystem
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    /// <summary>
    /// Base class for streams that are essentially a mapping onto a parent stream.
    /// </summary>
    /// <remarks>
    /// This class provides access to the mapping underlying the stream, enabling
    /// callers to convert a byte range in this stream into one or more ranges in
    /// the parent stream.
    /// </remarks>
    public abstract class MappedStream : SparseStream
    {
        /// <summary>
        /// Converts any stream into a non-linear stream.
        /// </summary>
        /// <param name="stream">The stream to convert.</param>
        /// <param name="takeOwnership"><c>true</c> to have the new stream dispose the wrapped
        /// stream when it is disposed.</param>
        /// <returns>A sparse stream</returns>
        /// <remarks>The wrapped stream is assumed to be a linear stream (such that any byte range
        /// maps directly onto the parent stream)</remarks>
        public static new MappedStream FromStream(Stream stream, Ownership takeOwnership)
        {
            return new MappedWrapperStream(stream, takeOwnership, null);
        }

        /// <summary>
        /// Converts any stream into a non-linear stream.
        /// </summary>
        /// <param name="stream">The stream to convert.</param>
        /// <param name="takeOwnership"><c>true</c> to have the new stream dispose the wrapped
        /// stream when it is disposed.</param>
        /// <param name="extents">The set of extents actually stored in <c>stream</c></param>
        /// <returns>A sparse stream</returns>
        /// <remarks>The wrapped stream is assumed to be a linear stream (such that any byte range
        /// maps directly onto the parent stream)</remarks>
        public static new MappedStream FromStream(Stream stream, Ownership takeOwnership, IEnumerable<StreamExtent> extents)
        {
            return new MappedWrapperStream(stream, takeOwnership, extents);
        }

        /// <summary>
        /// Maps a logical range down to storage locations.
        /// </summary>
        /// <param name="start">The first logical range to map</param>
        /// <param name="length">The length of the range to map</param>
        /// <returns>One or more stream extents specifying the storage locations that correspond
        /// to the identified logical extent range.</returns>
        /// <remarks>
        /// <para>As far as possible, the stream extents are returned in logical disk order -
        /// however, due to the nature of non-linear streams, not all of the range may actually
        /// be stored, or some or all of the range may be compressed - thus reading the
        /// returned stream extents is not equivalent to reading the logical disk range.</para>
        /// </remarks>
        public abstract IEnumerable<StreamExtent> MapContent(long start, long length);

        private class MappedWrapperStream : MappedStream
        {
            private Stream _wrapped;
            private Ownership _ownsWrapped;
            private List<StreamExtent> _extents;

            public MappedWrapperStream(Stream wrapped, Ownership ownsWrapped, IEnumerable<StreamExtent> extents)
            {
                _wrapped = wrapped;
                _ownsWrapped = ownsWrapped;
                if (extents != null)
                {
                    _extents = new List<StreamExtent>(extents);
                }
            }

            public override bool CanRead
            {
                get { return _wrapped.CanRead; }
            }

            public override bool CanSeek
            {
                get { return _wrapped.CanSeek; }
            }

            public override bool CanWrite
            {
                get { return _wrapped.CanWrite; }
            }

            public override long Length
            {
                get { return _wrapped.Length; }
            }

            public override long Position
            {
                get
                {
                    return _wrapped.Position;
                }

                set
                {
                    _wrapped.Position = value;
                }
            }

            public override IEnumerable<StreamExtent> Extents
            {
                get
                {
                    if (_extents != null)
                    {
                        return _extents;
                    }
                    else
                    {
                        SparseStream wrappedAsSparse = _wrapped as SparseStream;
                        if (wrappedAsSparse != null)
                        {
                            return wrappedAsSparse.Extents;
                        }
                        else
                        {
                            return new StreamExtent[] { new StreamExtent(0, _wrapped.Length) };
                        }
                    }
                }
            }

            public override IEnumerable<StreamExtent> MapContent(long start, long length)
            {
                MappedStream wrappedAsMapped = _wrapped as MappedStream;
                if (wrappedAsMapped != null)
                {
                    return wrappedAsMapped.MapContent(start, length);
                }
                else
                {
                    return new StreamExtent[] { new StreamExtent(start, length) };
                }
            }

            public override void Flush()
            {
                _wrapped.Flush();
            }

            public override int Read(byte[] buffer, int offset, int count)
            {
                return _wrapped.Read(buffer, offset, count);
            }

            public override long Seek(long offset, SeekOrigin origin)
            {
                return _wrapped.Seek(offset, origin);
            }

            public override void SetLength(long value)
            {
                _wrapped.SetLength(value);
            }

            public override void Write(byte[] buffer, int offset, int count)
            {
                if (_extents != null)
                {
                    throw new InvalidOperationException("Attempt to write to stream with explicit extents");
                }

                _wrapped.Write(buffer, offset, count);
            }

            protected override void Dispose(bool disposing)
            {
                try
                {
                    if (disposing && _ownsWrapped == Ownership.Dispose && _wrapped != null)
                    {
                        _wrapped.Dispose();
                        _wrapped = null;
                    }
                }
                finally
                {
                    base.Dispose(disposing);
                }
            }
        }
    }
}
