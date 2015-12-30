#if WIN32
namespace RC.Framework.Native.Win32.PowerManagement
{
    /// <summary>
    /// wParam values for WM_POWERBROADCAST message.
    /// </summary>
    public enum PowerBroadcastType
    {
        /// <summary>
        /// Power status has changed.
        /// </summary>
        PBT_APMPOWERSTATUSCHANGE = 0xA,
        /// <summary>
        /// Operation is resuming automatically from a low-power state. This message is sent every time the system resumes.
        /// </summary>
        PBT_APMRESUMEAUTOMATIC = 0x12,
        /// <summary>
        /// Operation is resuming from a low-power state. This message is sent after PBT_APMRESUMEAUTOMATIC if the resume is triggered by user input, such as pressing a key.
        /// </summary>
        PBT_APMRESUMESUSPEND = 0x7,
        /// <summary>
        /// System is suspending operation.
        /// </summary>
        PBT_APMSUSPEND = 0x4,
        /// <summary>
        /// A power setting change event has been received.
        /// </summary>
        PBT_POWERSETTINGCHANGE = 0x8013,


        /// <summary>
        /// Battery power is low. In Windows Server 2008 and Windows Vista, use PBT_APMPOWERSTATUSCHANGE instead.
        /// </summary>
        PBT_APMBATTERYLOW = 0x9,
        /// <summary>
        /// OEM-defined event occurred. In Windows Server 2008 and Windows Vista, this event is not available because these operating systems support only ACPI; APM BIOS events are not supported.
        /// </summary>
        PBT_APMOEMEVENT = 0xB,
        /// <summary>
        /// Request for permission to suspend. In Windows Server 2008 and Windows Vista, use the SetThreadExecutionState function instead.
        /// </summary>
        PBT_APMQUERYSUSPEND = 0x0,
        /// <summary>
        /// Suspension request denied. In Windows Server 2008 and Windows Vista, use SetThreadExecutionState instead.
        /// </summary>
        PBT_APMQUERYSUSPENDFAILED = 0x2,
        /// <summary>
        /// Operation resuming after critical suspension. In Windows Server 2008 and Windows Vista, use PBT_APMRESUMEAUTOMATIC instead.
        /// </summary>
        PBT_APMRESUMECRITICAL = 0x6,

    }
}
#endif