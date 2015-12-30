#if WIN32
namespace RC.Framework.Native.Win32.DeviceManagement
{
    using System.Runtime.InteropServices;
    /// <summary>
    /// Serves as a standard header for information related to a device event reported through the WM_DEVICECHANGE message.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
	public struct DEV_BROADCAST_HDR
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
		public uint dbch_Size;
		/// <summary>
		/// The device type, which determines the event-specific information that follows the first three members.
		/// </summary>
		public DeviceType dbch_DeviceType;
		/// <summary>
		/// Reserved; do not use.
		/// </summary>
		public uint dbch_Reserved;

		/// <summary>
		/// Indicates the device type.
		/// </summary>
		public enum DeviceType : uint
		{
			/// <summary>
			/// Class of devices. This structure is a DEV_BROADCAST_DEVICEINTERFACE structure.
			/// </summary>
			DBT_DEVTYP_DEVICEINTERFACE = 0x00000005,
			/// <summary>
			/// File system handle. This structure is a DEV_BROADCAST_HANDLE structure.
			/// </summary>
			DBT_DEVTYP_HANDLE = 0x00000006,
			/// <summary>
			/// OEM- or IHV-defined device type. This structure is a DEV_BROADCAST_OEM structure.
			/// </summary>
			DBT_DEVTYP_OEM = 0x00000000,
			/// <summary>
			/// Port device (serial or parallel). This structure is a DEV_BROADCAST_PORT structure.
			/// </summary>
			DBT_DEVTYP_PORT = 0x00000003,
			/// <summary>
			/// Logical volume. This structure is a <see cref="DEV_BROADCAST_VOLUME"/> structure.
			/// </summary>
			DBT_DEVTYP_VOLUME = 0x00000002
		}
	}
}
#endif