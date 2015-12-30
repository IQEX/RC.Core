#if WIN32
namespace RC.Framework.Native.Win32.Shells
{
    using Rectangles;
    using System;
    using System.Runtime.InteropServices;
    /// <summary>
    /// Contains information about a system appbar message.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct APPBARDATA
    {
        /// <summary>
        /// Gets a value indicating whether this struct is supported on current platform.
        /// </summary>
        /// <value>
        /// <c>true</c> if this struct is supported; otherwise, <c>false</c>.
        /// </value>
        public static bool IsSupported { get { return PlatformInfo.IsWinXPUp; } }

        /// <summary>
        /// The size of the structure, in bytes.
        /// </summary>
        public uint cbSize;
        /// <summary>
        /// The handle to the appbar window.
        /// </summary>
        public IntPtr hWnd;
        /// <summary>
        /// An application-defined message identifier. The application uses the specified identifier for notification messages that it sends to the appbar identified by the hWnd member. This member is used when sending the ABM_NEW message.
        /// </summary>
        public uint uCallbackMessage;
        /// <summary>
        /// A value that specifies an edge of the screen.
        /// </summary>
        public AppBarEdge uEdge;
        /// <summary>
        /// A RECT structure whose use varies depending on the message.
        /// </summary>
        public RECT rc;
        /// <summary>
        /// A message-dependent value.
        /// </summary>
        public IntPtr lParam;
    }

}
#endif