#if WIN32
namespace RC.Framework.Native.Win32.Windows
{
    using Rectangles;
    using System;
    using System.Runtime.InteropServices;
    /// <summary>
    /// Contains information that an application can use while processing the WM_NCCALCSIZE 
    /// message to calculate the size, position, and valid contents of the client area of a window.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
	public struct NCCALCSIZE_PARAMS
	{
		/// <summary>
		/// Contains the new coordinates of a window that has been moved or resized, 
		/// that is, it is the proposed new window coordinates.
		/// </summary>
		public RECT rectProposed;
		/// <summary>
		/// Contains the coordinates of the window before it was moved or resized.
		/// </summary>
		public RECT rectBeforeMove;
		/// <summary>
		/// Contains the coordinates of the window's client area before the window 
		/// was moved or resized.
		/// </summary>
		public RECT rectClientBeforeMove;
		/// <summary>
		/// Pointer to a WINDOWPOS structure that contains the size and position 
		/// values specified in the operation that moved or resized the window.
		/// </summary>
		public IntPtr lpPos;
	}
}
#endif