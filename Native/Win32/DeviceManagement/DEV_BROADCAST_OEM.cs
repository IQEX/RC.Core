#if WIN32
namespace RC.Framework.Native.Win32.DeviceManagement
{
    using System.Runtime.InteropServices;
    /// <summary>
    /// Contains information about a OEM-defined device type.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DEV_BROADCAST_OEM
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
        public uint dbco_size;
        /// <summary>
        /// Set to DBT_DEVTYP_OEM.
        /// </summary>
        public DEV_BROADCAST_HDR.DeviceType dbco_devicetype;
        /// <summary>
        /// Reserved; do not use.
        /// </summary>
        public uint dbco_reserved;
        /// <summary>
        /// The OEM-specific identifier for the device.
        /// </summary>
        public uint dbco_identifier;
        /// <summary>
        /// The OEM-specific function value. Possible values depend on the device.
        /// </summary>
        public uint dbco_suppfunc;
    }
}
#endif