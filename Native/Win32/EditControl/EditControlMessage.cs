#if WIN32
namespace RC.Framework.Native.Win32.EditControl
{
	/// <summary>
	/// Messages sent to for edit controls.
	/// </summary>
	public enum EditControlMessage
	{
		/// <summary>
		/// Sets the textual cue, or tip, that is displayed by the edit control to prompt the user for information.
		/// </summary>
		EM_SETCUEBANNER = 0x1501,
		/// <summary>
		/// Gets the text that is displayed as the textual cue, or tip, in an edit control.
		/// </summary>
		EM_GETCUEBANNER = 0x1502,

		/// <summary>
		/// Sets or removes the read-only style (ES_READONLY) of an edit control. You can send this message to either an edit control or a rich edit control.
		/// </summary>
        EM_SETREADONLY = 0x00CF
	}
}
#endif