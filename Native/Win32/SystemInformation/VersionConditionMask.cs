#if WIN32
namespace RC.Framework.Native.Win32.SystemInformation
{
    public enum VersionConditionMask : byte
    {
        /// <summary>
        /// The current value must be equal to the specified value.
        /// </summary>
        VER_EQUAL = 1,
        /// <summary>
        /// The current value must be greater than the specified value.
        /// </summary>
        VER_GREATER = 2,
        /// <summary>
        /// The current value must be greater than or equal to the specified value.
        /// </summary>
        VER_GREATER_EQUAL = 3,
        /// <summary>
        /// The current value must be less than the specified value.
        /// </summary>
        VER_LESS = 4,
        /// <summary>
        /// The current value must be less than or equal to the specified value.
        /// </summary>
        VER_LESS_EQUAL = 5,


        //If dwTypeBitMask is VER_SUITENAME, this parameter can be one of the following values.

        /// <summary>
        /// All product suites specified in the wSuiteMask member must be present in the current system.
        /// </summary>
        VER_AND = 6,
        /// <summary>
        /// At least one of the specified product suites must be present in the current system.
        /// </summary>
        VER_OR = 7,
    }
}
#endif