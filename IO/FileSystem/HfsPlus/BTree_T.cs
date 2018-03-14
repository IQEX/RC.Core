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

namespace RC.Framework.FileSystem.HfsPlus
{
    internal sealed class BTree<TKey> : BTree
        where TKey : BTreeKey, new()
    {
        private BTreeHeaderRecord _header;
        private IBuffer _data;
        private BTreeKeyedNode<TKey> _rootNode;

        public BTree(IBuffer data)
        {
            _data = data;

            byte[] headerInfo = Utilities.ReadFully(_data, pos: 0, count: 114);

            _header = new BTreeHeaderRecord();
            _header.ReadFrom(headerInfo, offset: 14);

            byte[] node0data = Utilities.ReadFully(_data, pos: 0, count: _header.NodeSize);

            BTreeHeaderNode node0 = BTreeNode.ReadNode(this, node0data, offset: 0) as BTreeHeaderNode;
            node0.ReadFrom(node0data, offset: 0);

            _rootNode = GetKeyedNode(node0.HeaderRecord.RootNode);
        }

        internal override int NodeSize
        {
            get { return _header.NodeSize; }
        }

        public byte[] Find(TKey key)
        {
            return _rootNode.FindKey(key);
        }

        public void VisitRange(BTreeVisitor<TKey> visitor)
        {
            _rootNode.VisitRange(visitor);
        }

        internal BTreeKeyedNode<TKey> GetKeyedNode(uint nodeId)
        {
            byte[] nodeData = Utilities.ReadFully(_data, (int)nodeId * _header.NodeSize, _header.NodeSize);

            BTreeKeyedNode<TKey> node = BTreeNode.ReadNode<TKey>(this, nodeData, offset: 0) as BTreeKeyedNode<TKey>;
            node.ReadFrom(nodeData, offset: 0);
            return node;
        }
    }
}