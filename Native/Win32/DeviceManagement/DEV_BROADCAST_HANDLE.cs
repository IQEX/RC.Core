#if WIN32
namespace RC.Framework.Native.Win32.DeviceManagement
{
    using System;
    using System.Runtime.InteropServices;
    /// <summary>
    /// THIS DEFINITION IS IFFY.
    /// Contains information about a file system handle.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DEV_BROADCAST_HANDLE
    {
        /// <summary>
        /// Gets a value indicating whether this struct is supported on current platform.
        /// </summary>
        /// <value>
        /// <c>true</c> if this struct is supported; otherwise, <c>false</c>.
        /// </value>
        public static bool IsSupported { get { return PlatformInfo.IsWinXPUp; } }

        /// <summary>
        /// The size of this structure, in bytes.
        /// </summary>
        public uint dbch_size;
        /// <summary>
        /// Set to DBT_DEVTYP_HANDLE.
        /// </summary>
        public DEV_BROADCAST_HDR dbch_devicetype;
        /// <summary>
        /// Reserved; do not use.
        /// </summary>
        public uint dbch_reserved;
        /// <summary>
        /// A handle to the device to be checked.
        /// </summary>
        public IntPtr dbch_handle;
        /// <summary>
        /// A handle to the device notification. This handle is returned by RegisterDeviceNotification.
        /// </summary>
        public IntPtr dbch_hdevnotify;
        /// <summary>
        /// The GUID for the custom event. Valid only for DBT_CUSTOMEVENT.
        /// </summary>
        public Guid dbch_eventguid;
        /// <summary>
        /// The offset of an optional string buffer. Valid only for DBT_CUSTOMEVENT.
        /// </summary>
        public int dbch_nameoffset;
        /// <summary>
        /// Optional binary data. This member is valid only for DBT_CUSTOMEVENT.
        /// </summary>
        public IntPtr dbch_data;
    }
}
#endif