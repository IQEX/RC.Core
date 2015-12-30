#if WIN32
namespace RC.Framework.Native.Win32.TreeViewControl
{
	/// <summary>
	/// Messages for treeview.
	/// </summary>
	public enum TreeViewMessage
	{
		/// <summary>
		/// For value offset.
		/// </summary>
        TVM_FIRST = 0x1100,
		/// <summary>
		/// Informs the tree-view control to set extended styles. 
		/// </summary>
        TVM_SETEXTENDEDSTYLE = TVM_FIRST + 44,
		/// <summary>
		/// Retrieves the extended style for a tree-view control. 
		/// </summary>
        TVM_GETEXTENDEDSTYLE = TVM_FIRST + 45,
		/// <summary>
		/// Sets information used to determine auto-scroll characteristics.
		/// </summary>
        TVM_SETAUTOSCROLLINFO = TVM_FIRST + 59,
	}
}
#endif