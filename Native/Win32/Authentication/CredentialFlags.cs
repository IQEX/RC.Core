#if WIN32
namespace RC.Framework.Native.Win32.Authentication
{
    using System;
    [Flags]
    public enum CredentialFlags : uint
    {
        CRED_FLAGS_PASSWORD_FOR_CERT = 0x0001,
        /// <summary>
        /// Bit set if the credential does not persist the CredentialBlob and the credential has not been written during this logon session. This bit is ignored on input and is set automatically when queried.
        /// </summary>
        CRED_FLAGS_PROMPT_NOW = 0x0002,
        /// <summary>
        /// Bit is set if this credential has a TargetName member set to the same value as the UserName member. Such a credential is one designed to store the CredentialBlob for a specific user. 
        /// </summary>
        CRED_FLAGS_USERNAME_TARGET = 0x0004,
        CRED_FLAGS_OWF_CRED_BLOB = 0x0008,
        CRED_FLAGS_REQUIRE_CONFIRMATION = 0x0010,

        /// <summary>
        /// Valid only for return and only with CredReadDomainCredentials().
        /// Indicates credential was returned due to wildcard match
        /// of targetname with credential.
        /// </summary>
        CRED_FLAGS_WILDCARD_MATCH = 0x0020,

        /// <summary>
        /// Mask of all valid flags
        /// </summary>
        CRED_FLAGS_VALID_FLAGS = 0xF03F,

        /// <summary>
        /// Bit mask for only those flags which can be passed to the credman APIs.
        /// </summary>
        CRED_FLAGS_VALID_INPUT_FLAGS = 0xF01F,
    }
}
#endif