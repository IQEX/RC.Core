// Copyright (c) 2008-2015 - Yuuki Wesp and Kenneth Bell
// License Type - MIT

namespace RC.Framework.FileSystem.BootConfig
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using RC.Framework.FileSystem.Registry;

    internal class FileSystemRegistryStorage : BaseStorage
    {
        private const string ElementsPathTemplate = @"Objects\{0}\Elements";
        private const string ElementPathTemplate = @"Objects\{0}\Elements\{1:X8}";
        private const string ObjectTypePathTemplate = @"Objects\{0}\Description";
        private const string ObjectsPath = @"Objects";

        private RegistryKey _rootKey;

        public FileSystemRegistryStorage(RegistryKey key)
        {
            _rootKey = key;
        }

        public override string GetString(Guid obj, int element)
        {
            return GetValue(obj, element) as string;
        }

        public override void SetString(Guid obj, int element, string value)
        {
            SetValue(obj, element, value);
        }

        public override byte[] GetBinary(Guid obj, int element)
        {
            return GetValue(obj, element) as byte[];
        }

        public override void SetBinary(Guid obj, int element, byte[] value)
        {
            SetValue(obj, element, value);
        }

        public override string[] GetMultiString(Guid obj, int element)
        {
            return GetValue(obj, element) as string[];
        }

        public override void SetMultiString(Guid obj, int element, string[] values)
        {
            SetValue(obj, element, values);
        }

        public override IEnumerable<Guid> EnumerateObjects()
        {
            RegistryKey parentKey = _rootKey.OpenSubKey("Objects");
            foreach (var key in parentKey.GetSubKeyNames())
            {
                yield return new Guid(key);
            }
        }

        public override IEnumerable<int> EnumerateElements(Guid obj)
        {
            string path = string.Format(CultureInfo.InvariantCulture, ElementsPathTemplate, obj.ToString("B"));
            RegistryKey parentKey = _rootKey.OpenSubKey(path);
            foreach (var key in parentKey.GetSubKeyNames())
            {
                yield return int.Parse(key, NumberStyles.HexNumber);
            }
        }

        public override int GetObjectType(Guid obj)
        {
            string path = string.Format(CultureInfo.InvariantCulture, ObjectTypePathTemplate, obj.ToString("B"));

            RegistryKey descKey = _rootKey.OpenSubKey(path);

            object val = descKey.GetValue("Type");
            return (int)val;
        }

        public override bool HasValue(Guid obj, int element)
        {
            string path = string.Format(CultureInfo.InvariantCulture, ElementPathTemplate, obj.ToString("B"), element);
            return _rootKey.OpenSubKey(path) != null;
        }

        public override bool ObjectExists(Guid obj)
        {
            string path = string.Format(CultureInfo.InvariantCulture, ObjectTypePathTemplate, obj.ToString("B"));

            return _rootKey.OpenSubKey(path) != null;
        }

        public override Guid CreateObject(Guid obj, int type)
        {
            Guid realObj = (obj == Guid.Empty) ? Guid.NewGuid() : obj;
            string path = string.Format(CultureInfo.InvariantCulture, ObjectTypePathTemplate, realObj.ToString("B"));

            RegistryKey key = _rootKey.CreateSubKey(path);
            key.SetValue("Type", type, RegistryValueType.Dword);

            return realObj;
        }

        public override void CreateElement(Guid obj, int element)
        {
            string path = string.Format(CultureInfo.InvariantCulture, ElementPathTemplate, obj.ToString("B"), element);

            _rootKey.CreateSubKey(path);
        }

        public override void DeleteObject(Guid obj)
        {
            string path = string.Format(CultureInfo.InvariantCulture, ObjectTypePathTemplate, obj.ToString("B"));

            _rootKey.DeleteSubKeyTree(path);
        }

        public override void DeleteElement(Guid obj, int element)
        {
            string path = string.Format(CultureInfo.InvariantCulture, ElementPathTemplate, obj.ToString("B"), element);

            _rootKey.DeleteSubKeyTree(path);
        }

        private object GetValue(Guid obj, int element)
        {
            string path = string.Format(CultureInfo.InvariantCulture, ElementPathTemplate, obj.ToString("B"), element);
            RegistryKey key = _rootKey.OpenSubKey(path);
            return key.GetValue("Element");
        }

        private void SetValue(Guid obj, int element, object value)
        {
            string path = string.Format(CultureInfo.InvariantCulture, ElementPathTemplate, obj.ToString("B"), element);
            RegistryKey key = _rootKey.OpenSubKey(path);
            key.SetValue("Element", value);
        }
    }
}
