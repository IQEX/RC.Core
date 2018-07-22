namespace System
{
    using IO;
    using Runtime.InteropServices;
    public class OSDetector
    {
        internal static class NativeMethods
        {
            private const string Kernel32 = "kernel32.dll";

            #region kernel32.dll
            [DllImport(Kernel32, EntryPoint = "GetVersion", SetLastError = true)]
            internal static extern int GetVersion();
            [DllImport(Kernel32, EntryPoint = "SetConsoleMode", SetLastError = true)]
            internal static extern bool SetConsoleMode(IntPtr hConsoleHandle, int mode);
            [DllImport(Kernel32, EntryPoint = "GetConsoleMode", SetLastError = true)]
            internal static extern bool GetConsoleMode(IntPtr handle, out int mode);
            [DllImport(Kernel32, EntryPoint = "GetStdHandle", SetLastError = true)]
            internal static extern IntPtr GetStdHandle(int handle);
            #endregion

            private const string WinrtString = "api-ms-win-core-winrt-string-l1-1-0.dll";

            #region api-ms-win-core-winrt-string-l1-1-0.dll
            [DllImport(WinrtString, EntryPoint = "WindowsCreateString")]
            internal static extern int WindowsCreateString([MarshalAs(UnmanagedType.LPWStr)]string sourceString, int stringLength, out IntPtr hstring);
            [DllImport(WinrtString, EntryPoint = "WindowsDeleteString")]
            internal static extern int WindowsDeleteString(IntPtr hstring);
            #endregion

            [DllImport("api-ms-win-core-winrt-l1-1-0.dll", EntryPoint = "RoGetActivationFactory")]
            internal static extern int RoGetActivationFactory(IntPtr className, ref Guid guid, out IntPtr instance);
        }

        static OSDetector()
        {
            // OS Detection for all CLR implementations (.NET Framework,Mono,.NET Core)
            var windir = Environment.GetEnvironmentVariable("windir");

            if ((!string.IsNullOrWhiteSpace(windir)) && windir.Contains(@"\") && Directory.Exists(windir))
            {
                // windows
                int version = NativeMethods.GetVersion();
                int major = version & 0xFF;
                int minor = (version >> 8) & 0xFF;
                if ((major < 6) || (minor < 2))
                {
                    IsAnniversaryUpdate = false;
                }
                else
                {
                    // Windows 6.2 is Windows 8 or later - first which supports Windows RT
                    IsAnniversaryUpdate = DetectAnniversaryUpdate();
                }

            }
            else if (File.Exists("/proc/sys/kernel/ostype"))
            {
                string osType = File.ReadAllText(@"/proc/sys/kernel/ostype");
                if (osType.StartsWith("Linux", StringComparison.OrdinalIgnoreCase))
                {
                    IsAnniversaryUpdate = false;
                    // linux
                }
            }
            else if (File.Exists(@"/System/Library/CoreServices/SystemVersion.plist"))
            {
                IsAnniversaryUpdate = false;
                // Mac OS
            }

        }

        public static bool IsAnniversaryUpdate { get; }

        /// <summary>
        /// ALL version info functions are DEPRECATED since Windows 10
        /// https://msdn.microsoft.com/en-ca/library/windows/desktop/dn481241(v=vs.85).aspx
        /// this code modified version of code:
        /// http://answers.unity3d.com/questions/1249727/detect-if-windows-10-anniversary-version-number.html
        /// </summary>
        /// <returns></returns>
        private static bool DetectAnniversaryUpdate()
        {
            const string kAppExtensionClassName = "Windows.ApplicationModel.AppExtensions.AppExtensionCatalog";
            var classNameHString = IntPtr.Zero;
            bool ok = false;
            try
            {
                if (NativeMethods.WindowsCreateString(kAppExtensionClassName, kAppExtensionClassName.Length, out classNameHString) == 0)
                {
                    IntPtr appExtensionCatalogStatics;
                    var IID_IAppExtensionCatalogStatics = new Guid(a: 1010198154, b: 24344, c: 20235, d: 156, e: 229, f: 202, g: 182, h: 29, i: 25, j: 111, k: 17);

                    if (NativeMethods.RoGetActivationFactory(classNameHString, ref IID_IAppExtensionCatalogStatics, out appExtensionCatalogStatics) == 0)
                    {
                        if (appExtensionCatalogStatics != IntPtr.Zero)
                        {
                            Marshal.Release(appExtensionCatalogStatics);
                            ok = true;
                        }
                    }
                }
            }
            finally
            {
                if (IntPtr.Zero != classNameHString)
                {
                    NativeMethods.WindowsDeleteString(classNameHString);
                }
            }
            return ok;
        }
    }
}