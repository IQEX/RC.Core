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

namespace RC.Framework.FileSystem.HfsPlus
{
    using System.Globalization;

    internal struct CatalogNodeId
    {
        public static readonly CatalogNodeId RootParentId = new CatalogNodeId(id: 1);
        public static readonly CatalogNodeId RootFolderId = new CatalogNodeId(id: 2);
        public static readonly CatalogNodeId ExtentsFileId = new CatalogNodeId(id: 3);
        public static readonly CatalogNodeId CatalogFileId = new CatalogNodeId(id: 4);
        public static readonly CatalogNodeId BadBlockFileId = new CatalogNodeId(id: 5);
        public static readonly CatalogNodeId AllocationFileId = new CatalogNodeId(id: 6);
        public static readonly CatalogNodeId StartupFileId = new CatalogNodeId(id: 7);
        public static readonly CatalogNodeId AttributesFileId = new CatalogNodeId(id: 8);
        public static readonly CatalogNodeId RepairCatalogFileId = new CatalogNodeId(id: 14);
        public static readonly CatalogNodeId BogusExtentFileId = new CatalogNodeId(id: 15);
        public static readonly CatalogNodeId FirstUserCatalogNodeId = new CatalogNodeId(id: 16);

        private uint _id;

        public CatalogNodeId(uint id)
        {
            _id = id;
        }

        public static implicit operator uint(CatalogNodeId nodeId)
        {
            return nodeId._id;
        }

        public static implicit operator CatalogNodeId(uint id)
        {
            return new CatalogNodeId(id);
        }

        public override string ToString()
        {
            return _id.ToString(CultureInfo.InvariantCulture);
        }
    }
}
