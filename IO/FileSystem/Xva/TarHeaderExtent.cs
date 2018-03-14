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

namespace RC.Framework.FileSystem.Xva
{
    internal class TarHeaderExtent : BuilderBufferExtent
    {
        private string _fileName;
        private long _fileLength;

        public TarHeaderExtent(long start, string fileName, long fileLength)
            : base(start, length: 512)
        {
            _fileName = fileName;
            _fileLength = fileLength;
        }

        protected override byte[] GetBuffer()
        {
            byte[] buffer = new byte[TarHeader.Length];

            TarHeader header = new TarHeader();
            header.FileName = _fileName;
            header.FileLength = _fileLength;
            header.WriteTo(buffer, offset: 0);

            return buffer;
        }
    }
}
