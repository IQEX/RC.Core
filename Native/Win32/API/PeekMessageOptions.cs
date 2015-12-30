#if WIN32
namespace RC.Framework.Native.Win32.API
{
    using System;
    /// <summary>
    /// Options for PeekMessage function.
    /// </summary>
    [Flags]
	public enum PeekMessageOptions : uint
	{
		/// <summary>
		/// Messages are not removed from the queue after processing by PeekMessage.
		/// </summary>
		PM_NOREMOVE = 0x0000,
		/// <summary>
		/// Messages are removed from the queue after processing by PeekMessage.
		/// </summary>
		PM_REMOVE = 0x0001,
		/// <summary>
		/// Prevents the system from releasing any thread that is waiting for the caller to go idle.
		/// Combine this value with either PM_NOREMOVE or PM_REMOVE.
		/// </summary>
		PM_NOYIELD = 0x0002
	}
}
#endif