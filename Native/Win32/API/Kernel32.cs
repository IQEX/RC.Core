using System.Drawing;
using System.Windows.Forms;
using RC.Framework.Native.Win32.Rectangles;

#if WIN32
namespace RC.Framework.Native.Win32.API
{
    using SystemInformation;
    using System;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Diagnostics;

    /// <summary>
    /// API methods in kernel32.dll.
    /// </summary>
    public static class Kernel32
    {
        class NativeMethods
        {
            [DllImport("kernel32.dll")]
            public static extern IntPtr LoadLibrary(string lpFileName);

            [DllImport("kernel32.dll", SetLastError = true)]
            public static extern bool FreeLibrary(IntPtr hModule);

            [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
            public static extern int GetPrivateProfileString(string lpAppName, string lpKeyName, string defaultValue, StringBuilder lpReturnedString, Int32 bufferSize, string lpFileName);

            [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
            public static extern uint GetPrivateProfileInt(string lpAppName, string lpKeyName, int defaultValue, string lpFileName);

            [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool WritePrivateProfileString(string lpAppName, string lpKeyName, string lpString, string lpFileName);


            [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool VerifyVersionInfo(ref OSVERSIONINFOEX lpVersionInfo, VersionTypeMask dwTypeMask, ulong dwlConditionMask);

            [DllImport("kernel32.dll")]
            public static extern ulong VerSetConditionMask(ulong dwlConditionMask, VersionTypeMask dwTypeBitMask, VersionConditionMask dwConditionMask);

            [DllImport("kernel32.dll", SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool AllocConsole();

            [DllImport("kernel32.dll", SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool FreeConsole();

            [DllImport("kernel32", SetLastError = true)]
            public static extern bool AttachConsole(int dwProcessId);

            [DllImport("user32.dll")]
            public static extern IntPtr GetForegroundWindow();

            [DllImport("user32.dll", SetLastError = true)]
            public static extern uint GetWindowThreadProcessId(IntPtr hWnd, out int lpdwProcessId);

            [DllImport("kernel32.dll", SetLastError = true)]
            public static extern IntPtr GetConsoleWindow();
        }

        public static void CenterConsole()
        {
            IntPtr hWin = NativeMethods.GetConsoleWindow();
            RECT rc;
            User32.GetWindowRect(hWin, out rc);
            Screen scr = Screen.FromPoint(new Point(rc.left, rc.top));
            int x = scr.WorkingArea.Left + (scr.WorkingArea.Width - (rc.right - rc.left)) / 2;
            int y = scr.WorkingArea.Top + (scr.WorkingArea.Height - (rc.bottom - rc.top)) / 2;
            User32.MoveWindow(hWin, x, y, rc.right - rc.left, rc.bottom - rc.top, false);
        }

        public static bool AllocConsole() => NativeMethods.AllocConsole();

        public static bool FreeConsole() => NativeMethods.FreeConsole();

        /// <summary>
        /// Retrieves a string from the specified section in an initialization file.
        /// </summary>
        /// <param name="lpAppName">The name of the section containing the key name. If this parameter is NULL, the GetPrivateProfileString function copies all section names in the file to the supplied buffer.</param>
        /// <param name="lpKeyName">The name of the key whose associated string is to be retrieved. If this parameter is NULL, all key names in the section specified by the lpAppName parameter are copied to the buffer specified by the lpReturnedString parameter.</param>
        /// <param name="defaultValue">A default string. If the lpKeyName key cannot be found in the initialization file, GetPrivateProfileString copies the default string to the lpReturnedString buffer. If this parameter is NULL, the default is an empty string, "".</param>
        /// <param name="lpReturnedString">A pointer to the buffer that receives the retrieved string.</param>
        /// <param name="bufferSize">The size of the buffer pointed to by the lpReturnedString parameter, in characters.</param>
        /// <param name="lpFileName">he name of the initialization file. If this parameter does not contain a full path to the file, the system searches for the file in the Windows directory.</param>
        /// <returns></returns>
        public static int GetPrivateProfileString(string lpAppName, string lpKeyName, string defaultValue, StringBuilder lpReturnedString, Int32 bufferSize, string lpFileName)
        {
            return NativeMethods.GetPrivateProfileString(lpAppName, lpKeyName, defaultValue, lpReturnedString, bufferSize, lpFileName);
        }

        /// <summary>
        /// Retrieves an integer associated with a key in the specified section of an initialization file.
        /// </summary>
        /// <param name="lpAppName">The name of the section in the initialization file.</param>
        /// <param name="lpKeyName">The name of the key whose value is to be retrieved. This value is in the form of a string; the GetPrivateProfileInt function converts the string into an integer and returns the integer.</param>
        /// <param name="defaultValue">The default value to return if the key name cannot be found in the initialization file.</param>
        /// <param name="lpFileName">The name of the initialization file. If this parameter does not contain a full path to the file, the system searches for the file in the Windows directory.</param>
        /// <returns></returns>
        public static uint GetPrivateProfileInt(string lpAppName, string lpKeyName, int defaultValue, string lpFileName)
        {
            return NativeMethods.GetPrivateProfileInt(lpAppName, lpKeyName, defaultValue, lpFileName);
        }

        /// <summary>
        /// Copies a string into the specified section of an initialization file.
        /// </summary>
        /// <param name="lpAppName">The name of the section to which the string will be copied. If the section does not exist, it is created. The name of the section is case-independent; the string can be any combination of uppercase and lowercase letters.</param>
        /// <param name="lpKeyName">The name of the key to be associated with a string. If the key does not exist in the specified section, it is created. If this parameter is NULL, the entire section, including all entries within the section, is deleted.</param>
        /// <param name="lpString">If this parameter is NULL, the key pointed to by the lpKeyName parameter is deleted.</param>
        /// <param name="lpFileName">The name of the initialization file.</param>
        /// <returns></returns>
        public static bool WritePrivateProfileString(string lpAppName, string lpKeyName, string lpString, string lpFileName)
        {
            return NativeMethods.WritePrivateProfileString(lpAppName, lpKeyName, lpString, lpFileName);
        }

        /// <summary>
        /// Indicates if the current OS version matches, or is greater than, the provided version information. 
        /// </summary>
        /// <param name="majorVersion">The major version.</param>
        /// <param name="minorVersion">The minor version.</param>
        /// <param name="servicePackMajorVersion">The service pack major version.</param>
        /// <returns></returns>
        public static bool IsWindowsVersionOrGreater(int majorVersion, int minorVersion, int servicePackMajorVersion)
        {
            var vi = default(OSVERSIONINFOEX);
            vi.dwOSVersionInfoSize = (uint)Marshal.SizeOf(vi);
            vi.dwMajorVersion = (uint)majorVersion;
            vi.dwMinorVersion = (uint)minorVersion;
            vi.wServicePackMajor = (ushort)servicePackMajorVersion;

            ulong mask = NativeMethods.VerSetConditionMask(
                NativeMethods.VerSetConditionMask(
                NativeMethods.VerSetConditionMask(
                    0, VersionTypeMask.VER_MAJORVERSION, VersionConditionMask.VER_GREATER_EQUAL),
                       VersionTypeMask.VER_MINORVERSION, VersionConditionMask.VER_GREATER_EQUAL),
                       VersionTypeMask.VER_SERVICEPACKMAJOR, VersionConditionMask.VER_GREATER_EQUAL);
            return NativeMethods.VerifyVersionInfo(ref vi, VersionTypeMask.VER_MAJORVERSION | VersionTypeMask.VER_MINORVERSION | VersionTypeMask.VER_SERVICEPACKMINOR, mask);
        }
    }
}
#endif