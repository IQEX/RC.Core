#if WIN32
namespace RC.Framework.Native.Win32
{
    using API;
    using System;
    /// <summary>   
    /// Provides checks for platform support.
    /// </summary>
    public static class PlatformInfo
    {
        static PlatformInfo()
        {
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                IsWin2kUp = Kernel32.IsWindowsVersionOrGreater(majorVersion: 5, minorVersion: 0, servicePackMajorVersion: 0);
                IsWinXPUp = Kernel32.IsWindowsVersionOrGreater(majorVersion: 5, minorVersion: 1, servicePackMajorVersion: 0);
                IsWinVistaUp = Kernel32.IsWindowsVersionOrGreater(majorVersion: 6, minorVersion: 0, servicePackMajorVersion: 0);
                IsWin7Up = Kernel32.IsWindowsVersionOrGreater(majorVersion: 6, minorVersion: 1, servicePackMajorVersion: 0);
                IsWin8Up = Kernel32.IsWindowsVersionOrGreater(majorVersion: 6, minorVersion: 2, servicePackMajorVersion: 0);
                IsWin81Up = Kernel32.IsWindowsVersionOrGreater(majorVersion: 6, minorVersion: 2, servicePackMajorVersion: 1);
                IsWin10Up = Kernel32.IsWindowsVersionOrGreater(majorVersion: 6, minorVersion: 3, servicePackMajorVersion: 0);
            }

            Is64BitProcess = IntPtr.Size == 8;
        }

        /// <summary>
        /// Gets a value indicating whether the current process is 64-bit.
        /// </summary>
        /// <value>
        ///   <c>true</c> if the current process is 64-bit; otherwise, <c>false</c>.
        /// </value>
        public static bool Is64BitProcess { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the OS is Windows 2000 or higher.
        /// </summary>
        /// <value>
        ///   <c>true</c> if the OS is Windows 2000 higher; otherwise, <c>false</c>.
        /// </value>
        public static bool IsWin2kUp { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the OS is Windows XP or higher.
        /// </summary>
        /// <value>
        ///   <c>true</c> if the OS is Windows XP higher; otherwise, <c>false</c>.
        /// </value>
        public static bool IsWinXPUp { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the OS is Windows vista or higher.
        /// </summary>
        /// <value>
        /// <c>true</c> if the OS is Windows vista or higher; otherwise, <c>false</c>.
        /// </value>
        public static bool IsWinVistaUp { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the OS is Windows 7 or higher.
        /// </summary>
        /// <value>
        /// <c>true</c> if the OS is Windows 7 or higher; otherwise, <c>false</c>.
        /// </value>
        public static bool IsWin7Up { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the OS is Windows 8 or higher.
        /// </summary>
        /// <value>
        /// <c>true</c> if the OS is Windows 8 or higher; otherwise, <c>false</c>.
        /// </value>
        public static bool IsWin8Up { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the OS is Windows 8.1 or higher.
        /// </summary>
        /// <value>
        /// <c>true</c> if the OS is Windows 8.1 or higher; otherwise, <c>false</c>.
        /// </value>
        public static bool IsWin81Up { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the OS is Windows 10 or higher.
        /// </summary>
        /// <value>
        /// <c>true</c> if the OS is Windows 10 or higher; otherwise, <c>false</c>.
        /// </value>
        public static bool IsWin10Up { get; private set; }
    }
}
#endif