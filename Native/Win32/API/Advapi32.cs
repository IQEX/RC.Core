#if WIN32
namespace RC.Framework.Native.Win32.API
{
    using Authentication;
    using System;
    using System.Runtime.InteropServices;
    /// <summary>
    /// API methods in Advapi32.dll.
    /// </summary>
    public static class Advapi32
    {
        /// <summary>
        /// Gets whether this api is supported.
        /// </summary>
        public static bool IsPlatformSupported { get { return PlatformInfo.IsWinXPUp; } }

        class NativeMethods
        {
            [DllImport("advapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool CredRead(
                string targetName, CredentialType type, uint flags, ref IntPtr credential);

            [DllImport("advapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool CredWrite([In]ref CREDENTIAL credential, uint flags);

            [DllImport("advapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool CredDelete(string target, CredentialType type, uint flags);

            [DllImport("advapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool CredEnumerate(string filter, uint flag, out uint count, out IntPtr credentials);

            [DllImport("advapi32.dll", SetLastError = true)]
            public static extern void CredFree([In]IntPtr buffer);
        }

        /// <summary>
        /// The CredRead function reads a credential from the user's credential set. The credential set used is the one associated with the logon session of the current token. The token must not have the user's SID disabled.
        /// </summary>
        /// <param name="targetName">Name of the target.</param>
        /// <param name="type">Type of the credential to read. </param>
        /// <param name="flags">Currently reserved and must be zero.</param>
        /// <param name="credential">Pointer to a single allocated block buffer to return the credential. Any pointers contained within the buffer are pointers to locations within this single allocated block. The single returned buffer must be freed by calling CredFree.</param>
        /// <returns></returns>
        public static bool CredRead(
            string targetName, CredentialType type, uint flags, ref IntPtr credential)
        {
            return NativeMethods.CredRead(targetName, type, flags, ref credential);
        }

        /// <summary>
        /// The CredWrite function creates a new credential or modifies an existing credential in the user's credential set. The new credential is associated with the logon session of the current token. The token must not have the user's security identifier (SID) disabled.
        /// </summary>
        /// <param name="credential">The credential.</param>
        /// <param name="flags">Flags that control the function's operation.</param>
        /// <returns></returns>
        public static bool CredWrite(ref CREDENTIAL credential, uint flags)
        {
            return NativeMethods.CredWrite(ref credential, flags);
        }


        /// <summary>
        /// The CredDelete function deletes a credential from the user's credential set. The credential set used is the one associated with the logon session of the current token. The token must not have the user's SID disabled.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="type">Type of the credential to delete. </param>
        /// <param name="flags">Reserved and must be zero.</param>
        /// <returns></returns>
        public static bool CredDelete(string target, CredentialType type, uint flags)
        {
            return NativeMethods.CredDelete(target, type, flags);
        }

        /// <summary>
        /// The CredEnumerate function enumerates the credentials from the user's credential set. The credential set used is the one associated with the logon session of the current token. The token must not have the user's SID disabled.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <param name="flag">The flag.</param>
        /// <param name="count">Count of the credentials returned in the Credentials array.</param>
        /// <param name="credentials">Pointer to an array of pointers to credentials. The returned credential is a single allocated block. 
        /// Any pointers contained within the buffer are pointers to locations within this single allocated block. 
        /// The single returned buffer must be freed by calling CredFree.</param>
        /// <returns></returns>
        public static bool CredEnumerate(string filter, uint flag, out uint count, out IntPtr credentials)
        {
            return NativeMethods.CredEnumerate(filter, flag, out count, out credentials);
        }


        /// <summary>
        /// The CredFree function frees a buffer returned by any of the credentials management functions.
        /// </summary>
        /// <param name="buffer">Pointer to the buffer to be freed.</param>
        public static void CredFree(IntPtr buffer)
        {
            NativeMethods.CredFree(buffer);
        }

        public const uint CRED_PRESERVE_CREDENTIAL_BLOB = 1;
        public const uint CRED_ENUMERATE_ALL_CREDENTIALS = 1;
    }
}
#endif