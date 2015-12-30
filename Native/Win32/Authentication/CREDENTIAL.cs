#if WIN32
namespace RC.Framework.Native.Win32.Authentication
{
    using System;
    using System.Runtime.InteropServices;
    using FILETIME = System.Runtime.InteropServices.ComTypes.FILETIME;
    /// <summary>
    /// The CREDENTIAL structure contains an individual credential.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct CREDENTIAL
    {
        /// <summary>
        /// A bit member that identifies characteristics of the credential. Undefined bits should be initialized as zero and not otherwise altered to permit future enhancement.
        /// </summary>
        public CredentialFlags Flags;

        /// <summary>
        /// The type of the credential. This member cannot be changed after the credential is created.
        /// </summary>
        public CredentialType Type;

        /// <summary>
        /// The name of the credential. The TargetName and Type members uniquely identify the credential. This member cannot be changed after the credential is created. Instead, the credential with the old name should be deleted and the credential with the new name created.
        /// This member cannot be longer than CRED_MAX_GENERIC_TARGET_NAME_LENGTH characters.
        /// </summary>
        [MarshalAs(UnmanagedType.LPWStr)]
        public string TargetName;

        /// <summary>
        /// A string comment from the user that describes this credential. This member cannot be longer than CRED_MAX_STRING_LENGTH.
        /// </summary>
        [MarshalAs(UnmanagedType.LPWStr)]
        public string Comment;

        /// <summary>
        /// The time, in Coordinated Universal Time (Greenwich Mean Time), of the last modification of the credential. For write operations, the value of this member is ignored.
        /// </summary>
        public FILETIME LastWritten;

        /// <summary>
        /// The size, in bytes, of the CredentialBlob member. This member cannot be larger than CRED_MAX_CREDENTIAL_BLOB_SIZE bytes.
        /// </summary>
        public uint CredentialBlobSize;

        /// <summary>
        /// Secret data for the credential. The CredentialBlob member can be both read and written.
        /// </summary>
        public IntPtr CredentialBlob;

        /// <summary>
        /// Defines the persistence of this credential. This member can be read and written.
        /// </summary>
        public PersistType Persist;

        /// <summary>
        /// The number of application-defined attributes to be associated with the credential. This member can be read and written. Its value cannot be greater than CRED_MAX_ATTRIBUTES.
        /// </summary>
        public uint AttributeCount;

        /// <summary>
        /// Application-defined attributes that are associated with the credential. This member can be read and written.
        /// </summary>
        public IntPtr Attributes;

        /// <summary>
        /// Alias for the TargetName member. This member can be read and written. It cannot be longer than CRED_MAX_STRING_LENGTH characters.
        /// </summary>
        [MarshalAs(UnmanagedType.LPWStr)]
        public string TargetAlias;

        /// <summary>
        /// The user name of the account used to connect to TargetName.
        /// This member cannot be longer than CRED_MAX_USERNAME_LENGTH characters.
        /// </summary>
        [MarshalAs(UnmanagedType.LPWStr)]
        public string UserName;


        /// <summary>
        /// Maximum size of the CredBlob field (in bytes)
        /// </summary>
        public const uint CRED_MAX_CREDENTIAL_BLOB_SIZE = 5 * 512;

        /// <summary>
        /// Maximum length of the TargetName field for CRED_TYPE_GENERIC (in characters)
        /// </summary>
        public const uint CRED_MAX_GENERIC_TARGET_NAME_LENGTH = 32767;

        /// <summary>
        /// Maximum length of the various credential string fields (in characters)
        /// </summary>
        public const uint CRED_MAX_STRING_LENGTH = 256;

        /// <summary>
        /// Maximum length of the UserName field.  The worst case is User@DnsDomain
        /// </summary>
        public const uint CRED_MAX_USERNAME_LENGTH = (256 + 1 + 256);

        /// <summary>
        /// Maximum length of the TargetName field for CRED_TYPE_DOMAIN_* (in characters).
        /// Largest one is DfsRoot\DfsShare.
        /// </summary>
        public const uint CRED_MAX_DOMAIN_TARGET_NAME_LENGTH = (256 + 1 + 80);

        /// <summary>
        /// Maximum length of a target namespace.
        /// </summary>
        public const uint CRED_MAX_TARGETNAME_NAMESPACE_LENGTH = 256;

        /// <summary>
        /// Maximum length of a target attribute.
        /// </summary>
        public const uint CRED_MAX_TARGETNAME_ATTRIBUTE_LENGTH = 256;

        /// <summary>
        /// Maximum size of the Credential Attribute Value field (in bytes).
        /// </summary>
        public const uint CRED_MAX_VALUE_SIZE = 256;

        /// <summary>
        /// Maximum number of attributes per credential.
        /// </summary>
        public const uint CRED_MAX_ATTRIBUTES = 64;
    }

}
#endif