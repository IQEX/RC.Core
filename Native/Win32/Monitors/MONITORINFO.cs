#if WIN32
namespace RC.Framework.Native.Win32.Monitors
{
    using Rectangles;
    using System.Runtime.InteropServices;
    /// <summary>
    /// Contains information about a display monitor.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct MONITORINFO
    {
        /// <summary>
        /// The size of the structure, in bytes.
        /// </summary>
        public uint cbSize;
        /// <summary>
        /// A RECT structure that specifies the display monitor rectangle, 
        /// expressed in virtual-screen coordinates. Note that if the monitor is 
        /// not the primary display monitor, some of the rectangle's coordinates 
        /// may be negative values.
        /// </summary>
        public RECT rcMonitor;
        /// <summary>
        /// A RECT structure that specifies the work area rectangle of the display 
        /// monitor, expressed in virtual-screen coordinates. Note that if the monitor
        /// is not the primary display monitor, some of the rectangle's coordinates 
        /// may be negative values.
        /// </summary>
        public RECT rcWork;
        /// <summary>
        /// A set of flags that represent attributes of the display monitor.
        /// </summary>
        public Flag dwFlags;
    }

    /// <summary>
    /// Indicates the monitor flag.
    /// </summary>
    public enum Flag : uint
    {
        /// <summary>
        /// This is the primary display monitor.
        /// </summary>
        MONITORINFOF_PRIMARY = 1
    }
}
#endif