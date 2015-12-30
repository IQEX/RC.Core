#if WIN32
namespace RC.Framework.Native.Win32.ComboBoxControl
{
    using Rectangles;
    using System;
    using System.Runtime.InteropServices;
    /// <summary>
    /// Contains combo box status information.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
	public struct COMBOBOXINFO
	{
		/// <summary>
		/// The size, in bytes, of the structure. The calling application must set this to sizeof(COMBOBOXINFO).
		/// </summary>
		public uint cbSize;
		/// <summary>
		/// A RECT structure that specifies the coordinates of the edit box.
		/// </summary>
		public RECT rcItem;
		/// <summary>
		/// A RECT structure that specifies the coordinates of the button that contains the drop-down arrow.
		/// </summary>
		public RECT rcButton;
		/// <summary>
		/// The combo box button state.
		/// </summary>
		public State stateButton;
		/// <summary>
		/// A handle to the combo box.
		/// </summary>
		public IntPtr hwndCombo;
		/// <summary>
		/// A handle to the edit box.
		/// </summary>
		public IntPtr hwndItem;
		/// <summary>
		/// A handle to the drop-down list.
		/// </summary>
		public IntPtr hwndList;

		/// <summary>
		/// Indicates the combobox button state
		/// </summary>
		public enum State : uint
		{
			/// <summary>
			/// The button exists and is not pressed.
			/// </summary>
			NA = 0,
			/// <summary>
			/// There is no button.
			/// </summary>
			STATE_SYSTEM_INVISIBLE = 0x00008000,
			/// <summary>
			/// The button is pressed.
			/// </summary>
			STATE_SYSTEM_PRESSED = 0x00000008,
		}
	}
}
#endif