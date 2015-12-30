// Copyright (c) 2008-2015 - Yuuki Wesp and Kenneth Bell
// License Type - MIT

namespace RC.Framework.FileSystem.BootConfig
{
    using System;
    using System.Collections.Generic;
    using RC.Framework.FileSystem.Registry;

    /// <summary>
    /// Represents a Boot Configuration Database store (i.e. a BCD file).
    /// </summary>
    public class Store
    {
        private BaseStorage _store;

        /// <summary>
        /// Initializes a new instance of the Store class.
        /// </summary>
        /// <param name="key">The registry key that is the root of the configuration database</param>
        public Store(RegistryKey key)
        {
            _store = new FileSystemRegistryStorage(key);
        }

        /// <summary>
        /// Gets the objects within the store.
        /// </summary>
        public IEnumerable<BcdObject> Objects
        {
            get
            {
                foreach (var obj in _store.EnumerateObjects())
                {
                    yield return new BcdObject(_store, obj);
                }
            }
        }

        /// <summary>
        /// Initializes a new Boot Configuration Database
        /// </summary>
        /// <param name="root">The registry key at the root of the database</param>
        /// <returns>The BCD store</returns>
        public static Store Initialize(RegistryKey root)
        {
            RegistryKey descKey = root.CreateSubKey("Description");
            descKey.SetValue("KeyName", "BCD00000001");
            root.CreateSubKey("Objects");
            return new Store(root);
        }

        /// <summary>
        /// Gets an object from the store.
        /// </summary>
        /// <param name="id">The identity of the object</param>
        /// <returns>The requested object, or <c>null</c></returns>
        public BcdObject GetObject(Guid id)
        {
            if (_store.ObjectExists(id))
            {
                return new BcdObject(_store, id);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Creates a specific object.
        /// </summary>
        /// <param name="id">The identity of the object to create</param>
        /// <param name="type">The object's type</param>
        /// <returns>The object representing the new application</returns>
        public BcdObject CreateObject(Guid id, int type)
        {
            _store.CreateObject(id, type);
            return new BcdObject(_store, id);
        }

        /// <summary>
        /// Creates an application object.
        /// </summary>
        /// <param name="imageType">The image type of the application</param>
        /// <param name="appType">The application's type</param>
        /// <returns>The object representing the new application</returns>
        public BcdObject CreateApplication(ApplicationImageType imageType, ApplicationType appType)
        {
            Guid obj = _store.CreateObject(Guid.NewGuid(), BcdObject.MakeApplicationType(imageType, appType));
            return new BcdObject(_store, obj);
        }

        /// <summary>
        /// Creates an application object.
        /// </summary>
        /// <param name="id">The identity of the object to create</param>
        /// <param name="imageType">The image type of the application</param>
        /// <param name="appType">The application's type</param>
        /// <returns>The object representing the new application</returns>
        public BcdObject CreateApplication(Guid id, ApplicationImageType imageType, ApplicationType appType)
        {
            Guid obj = _store.CreateObject(id, BcdObject.MakeApplicationType(imageType, appType));
            return new BcdObject(_store, obj);
        }

        /// <summary>
        /// Creates an 'inherit' object that contains common settings.
        /// </summary>
        /// <param name="inheritType">The type of object the settings apply to</param>
        /// <returns>The object representing the new settings</returns>
        public BcdObject CreateInherit(InheritType inheritType)
        {
            Guid obj = _store.CreateObject(Guid.NewGuid(), BcdObject.MakeInheritType(inheritType));
            return new BcdObject(_store, obj);
        }

        /// <summary>
        /// Creates an 'inherit' object that contains common settings.
        /// </summary>
        /// <param name="id">The identity of the object to create</param>
        /// <param name="inheritType">The type of object the settings apply to</param>
        /// <returns>The object representing the new settings</returns>
        public BcdObject CreateInherit(Guid id, InheritType inheritType)
        {
            Guid obj = _store.CreateObject(id, BcdObject.MakeInheritType(inheritType));
            return new BcdObject(_store, obj);
        }

        /// <summary>
        /// Creates a new device object, representing a partition.
        /// </summary>
        /// <returns>The object representing the new device.</returns>
        public BcdObject CreateDevice()
        {
            Guid obj = _store.CreateObject(Guid.NewGuid(), 0x30000000);
            return new BcdObject(_store, obj);
        }

        /// <summary>
        /// Removes an object.
        /// </summary>
        /// <param name="id">The identity of the object to remove</param>
        public void RemoveObject(Guid id)
        {
            _store.DeleteObject(id);
        }
    }
}
