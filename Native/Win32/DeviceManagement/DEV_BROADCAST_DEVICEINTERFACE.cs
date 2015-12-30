#if WIN32
namespace RC.Framework.Native.Win32.DeviceManagement
{
    using System;
    using System.Runtime.InteropServices;
    /// <summary>
    /// Contains information about a class of devices.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DEV_BROADCAST_DEVICEINTERFACE
    {
        /// <summary>
        /// Gets a value indicating whether this struct is supported on current platform.
        /// </summary>
        /// <value>
        /// <c>true</c> if this struct is supported; otherwise, <c>false</c>.
        /// </value>
        public static bool IsSupported { get { return PlatformInfo.IsWinXPUp; } }

        /// <summary>
        /// The size of this structure, in bytes. This is the size of the members plus the actual length of the dbcc_name string (the null character is accounted for by the declaration of dbcc_name as a one-character array.).
        /// </summary>
        public uint dbcc_size;
        /// <summary>
        /// Set to DBT_DEVTYP_DEVICEINTERFACE.
        /// </summary>
        public DEV_BROADCAST_HDR.DeviceType dbcc_devicetype;
        /// <summary>
        /// Reserved; do not use.
        /// </summary>
        public uint dbcc_reserved;
        /// <summary>
        /// The GUID for the interface device class.
        /// </summary>
        public Guid dbcc_classguid;
        /// <summary>
        /// A null-terminated string that specifies the name of the device.
        /// </summary>
        [MarshalAs(UnmanagedType.LPTStr)]
        //[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 255)]
        public string dbcc_name;
    }
}
#endif