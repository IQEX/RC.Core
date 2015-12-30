#if WIN32
namespace RC.Framework.Native.Win32.TreeViewControl
{
    using System;
    /// <summary>
    /// Style for treeview.
    /// </summary>
    [Flags]
	public enum TreeViewStyles : uint
	{
		/// <summary>
		/// Disables horizontal scrolling in the control. The control will not display any horizontal scroll bars.
		/// </summary>
		TVS_NOHSCROLL = 0x8000
	}
}
#endif