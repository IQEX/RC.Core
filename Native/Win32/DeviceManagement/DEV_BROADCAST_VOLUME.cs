#if WIN32
namespace RC.Framework.Native.Win32.DeviceManagement
{
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    /// <summary>
    /// Contains information about a logical volume.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DEV_BROADCAST_VOLUME
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
        public uint dbcv_size;
        /// <summary>
        /// Set to DBT_DEVTYP_VOLUME.
        /// </summary>
        public DEV_BROADCAST_HDR.DeviceType dbcv_devicetype;
        /// <summary>
        /// Reserved; do not use.
        /// </summary>
        public uint dbcv_reserved;
        /// <summary>
        /// The logical unit mask identifying one or more logical units. 
        /// Each bit in the mask corresponds to one logical drive. 
        /// Bit 0 represents drive A, bit 1 represents drive B, and so on.
        /// </summary>
        public uint dbcv_unitmask;
        /// <summary>
        /// Flag for the volume.
        /// </summary>
        public Flag dbcv_flags;

        /// <summary>
        /// Indicates the volume flag
        /// </summary>
        public enum Flag : ushort
        {
            /// <summary>
            /// Change affects media in drive. If not set, change affects physical device or drive.
            /// </summary>
            DBTF_MEDIA = 1,
            /// <summary>
            /// Indicated logical volume is a network volume.
            /// </summary>
            DBTF_NET = 2
        }


        /// <summary>
        /// Parses the valid drive letter from the <see cref="dbcv_unitmask"/> field.
        /// </summary>
        /// <returns></returns>
        public IList<char> ParseDriveLetters()
        {
            return ParseDriveLetters(dbcv_unitmask);
        }

        /// <summary>
        /// Parses the valid drive letter from the mask.
        /// </summary>
        /// <param name="mask">The bit mask in the format where bit 0 = A, bit 1 = B, bit 2 = C, and so on..</param>
        /// <returns></returns>
        public static IList<char> ParseDriveLetters(uint mask)
        {
            List<char> list = new List<char>();

            for (int offset = 0; offset < 26; offset++)
            {
                if ((mask & 0x1) > 0)
                {
                    list.Add((char)(offset + 'A'));
                }
                mask >>= 1;
            }
            return list;
        }
    }
}
#endif