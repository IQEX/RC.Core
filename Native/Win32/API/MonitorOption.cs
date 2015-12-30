#if WIN32
namespace RC.Framework.Native.Win32.API
{
    /// <summary>
    /// Option used with monitor APIs.
    /// </summary>
    public enum MonitorOption : uint
    {
        /// <summary>
        /// Returns NULL.
        /// </summary>
        MONITOR_DEFAULTTONULL = 0x00000000,
        /// <summary>
        /// Returns a handle to the primary display monitor.
        /// </summary>
        MONITOR_DEFAULTTOPRIMARY = 0x00000001,
        /// <summary>
        /// Returns a handle to the display monitor that is nearest to the window.
        /// </summary>
        MONITOR_DEFAULTTONEAREST = 0x00000002
    }
}
#endif