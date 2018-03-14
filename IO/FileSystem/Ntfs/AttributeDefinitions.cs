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

namespace RC.Framework.FileSystem.Ntfs
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    internal sealed class AttributeDefinitions
    {
        private Dictionary<AttributeType, AttributeDefinitionRecord> _attrDefs;

        public AttributeDefinitions()
        {
            _attrDefs = new Dictionary<AttributeType, AttributeDefinitionRecord>();

            Add(AttributeType.StandardInformation, "$STANDARD_INFORMATION", AttributeTypeFlags.MustBeResident, minSize: 0x30, maxSize: 0x48);
            Add(AttributeType.AttributeList, "$ATTRIBUTE_LIST", AttributeTypeFlags.CanBeNonResident, minSize: 0, maxSize: -1);
            Add(AttributeType.FileName, "$FILE_NAME", AttributeTypeFlags.Indexed | AttributeTypeFlags.MustBeResident, minSize: 0x44, maxSize: 0x242);
            Add(AttributeType.ObjectId, "$OBJECT_ID", AttributeTypeFlags.MustBeResident, minSize: 0, maxSize: 0x100);
            Add(AttributeType.SecurityDescriptor, "$SECURITY_DESCRIPTOR", AttributeTypeFlags.CanBeNonResident, minSize: 0x0, maxSize: -1);
            Add(AttributeType.VolumeName, "$VOLUME_NAME", AttributeTypeFlags.MustBeResident, minSize: 0x2, maxSize: 0x100);
            Add(AttributeType.VolumeInformation, "$VOLUME_INFORMATION", AttributeTypeFlags.MustBeResident, minSize: 0xC, maxSize: 0xC);
            Add(AttributeType.Data, "$DATA", AttributeTypeFlags.None, minSize: 0, maxSize: -1);
            Add(AttributeType.IndexRoot, "$INDEX_ROOT", AttributeTypeFlags.MustBeResident, minSize: 0, maxSize: -1);
            Add(AttributeType.IndexAllocation, "$INDEX_ALLOCATION", AttributeTypeFlags.CanBeNonResident, minSize: 0, maxSize: -1);
            Add(AttributeType.Bitmap, "$BITMAP", AttributeTypeFlags.CanBeNonResident, minSize: 0, maxSize: -1);
            Add(AttributeType.ReparsePoint, "$REPARSE_POINT", AttributeTypeFlags.CanBeNonResident, minSize: 0, maxSize: 0x4000);
            Add(AttributeType.ExtendedAttributesInformation, "$EA_INFORMATION", AttributeTypeFlags.MustBeResident, minSize: 0x8, maxSize: 0x8);
            Add(AttributeType.ExtendedAttributes, "$EA", AttributeTypeFlags.None, minSize: 0, maxSize: 0x10000);
            Add(AttributeType.LoggedUtilityStream, "$LOGGED_UTILITY_STREAM", AttributeTypeFlags.CanBeNonResident, minSize: 0, maxSize: 0x10000);
        }

        public AttributeDefinitions(File file)
        {
            _attrDefs = new Dictionary<AttributeType, AttributeDefinitionRecord>();

            byte[] buffer = new byte[AttributeDefinitionRecord.Size];
            using (Stream s = file.OpenStream(AttributeType.Data, name: null, access: FileAccess.Read))
            {
                while (Utilities.ReadFully(s, buffer, offset: 0, length: buffer.Length) == buffer.Length)
                {
                    AttributeDefinitionRecord record = new AttributeDefinitionRecord();
                    record.Read(buffer, offset: 0);

                    // NULL terminator record
                    if (record.Type != AttributeType.None)
                    {
                        _attrDefs.Add(record.Type, record);
                    }
                }
            }
        }

        public void WriteTo(File file)
        {
            List<AttributeType> attribs = new List<AttributeType>(_attrDefs.Keys);
            attribs.Sort();

            using (Stream s = file.OpenStream(AttributeType.Data, name: null, access: FileAccess.ReadWrite))
            {
                byte[] buffer;
                for (int i = 0; i < attribs.Count; ++i)
                {
                    buffer = new byte[AttributeDefinitionRecord.Size];
                    AttributeDefinitionRecord attrDef = _attrDefs[attribs[i]];
                    attrDef.Write(buffer, offset: 0);

                    s.Write(buffer, offset: 0, count: buffer.Length);
                }

                buffer = new byte[AttributeDefinitionRecord.Size];
                s.Write(buffer, offset: 0, count: buffer.Length);
            }
        }

        internal AttributeDefinitionRecord Lookup(string name)
        {
            foreach (var record in _attrDefs.Values)
            {
                if (string.Compare(name, record.Name, StringComparison.OrdinalIgnoreCase) == 0)
                {
                    return record;
                }
            }

            return null;
        }

        internal bool MustBeResident(AttributeType attributeType)
        {
            AttributeDefinitionRecord record;
            if (_attrDefs.TryGetValue(attributeType, out record))
            {
                return (record.Flags & AttributeTypeFlags.MustBeResident) != 0;
            }

            return false;
        }

        internal bool IsIndexed(AttributeType attributeType)
        {
            AttributeDefinitionRecord record;
            if (_attrDefs.TryGetValue(attributeType, out record))
            {
                return (record.Flags & AttributeTypeFlags.Indexed) != 0;
            }

            return false;
        }

        private void Add(AttributeType attributeType, string name, AttributeTypeFlags attributeTypeFlags, int minSize, int maxSize)
        {
            AttributeDefinitionRecord adr = new AttributeDefinitionRecord();
            adr.Type = attributeType;
            adr.Name = name;
            adr.Flags = attributeTypeFlags;
            adr.MinSize = minSize;
            adr.MaxSize = maxSize;
            _attrDefs.Add(attributeType, adr);
        }
    }
}
