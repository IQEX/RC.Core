#if WIN32
namespace RC.Framework.Native.Win32.GenericControl
{
	public enum CommonControlMessage
	{
		CCM_FIRST = 0x2000,
		CCM_SETUNICODEFORMAT = CCM_FIRST + 6,
		CCM_GETUNICODEFORMAT = CCM_FIRST + 5,
	}
}
#endif