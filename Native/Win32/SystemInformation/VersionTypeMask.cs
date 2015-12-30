#if WIN32
namespace RC.Framework.Native.Win32.SystemInformation
{
    public enum VersionTypeMask : uint
    {
        /// <summary>
        /// dwBuildNumber
        /// </summary>
        VER_BUILDNUMBER = 0x0000004,
        /// <summary>
        /// dwMajorVersion.
        /// If you are testing the major version, you must also test the minor version and the service pack major and minor versions.
        /// </summary>
        VER_MAJORVERSION = 0x0000002,

        /// <summary>
        /// dwMinorVersion
        /// </summary>
        VER_MINORVERSION = 0x0000001,

        /// <summary>
        /// dwPlatformId
        /// </summary>
        VER_PLATFORMID = 0x0000008,
        /// <summary>
        /// wServicePackMajor
        /// </summary>
        VER_SERVICEPACKMAJOR = 0x0000020,
        /// <summary>
        /// wServicePackMinor
        /// </summary>
        VER_SERVICEPACKMINOR = 0x0000010,

        /// <summary>
        /// wSuiteMask
        /// </summary>
        VER_SUITENAME = 0x0000040,

        /// <summary>
        /// wProductType
        /// </summary>
        VER_PRODUCT_TYPE = 0x0000080,

    }
}
#endif