#if WIN32
namespace RC.Framework.Native.Win32.Authentication
{
    public enum CredentialType : uint
    {
        /// <summary>
        /// The credential is a generic credential. The credential will not be used by any particular authentication package. The credential will be stored securely but has no other significant characteristics.
        /// </summary>
        CRED_TYPE_GENERIC = 1,
        /// <summary>
        /// The credential is a password credential and is specific to Microsoft's authentication packages. The NTLM, Kerberos, and Negotiate authentication packages will automatically use this credential when connecting to the named target.
        /// </summary>
        CRED_TYPE_DOMAIN_PASSWORD = 2,
        /// <summary>
        /// The credential is a certificate credential and is specific to Microsoft's authentication packages. The Kerberos, Negotiate, and Schannel authentication packages automatically use this credential when connecting to the named target.
        /// </summary>
        CRED_TYPE_DOMAIN_CERTIFICATE = 3,
        /// <summary>
        /// This value is no longer supported.
        /// </summary>
        CRED_TYPE_DOMAIN_VISIBLE_PASSWORD = 4,
        /// <summary>
        /// The credential is a certificate credential that is a generic authentication package.
        /// </summary>
        CRED_TYPE_GENERIC_CERTIFICATE = 5,
        /// <summary>
        /// The credential is supported by extended Negotiate packages.
        /// </summary>
        CRED_TYPE_DOMAIN_EXTENDED = 6,
        /// <summary>
        /// The maximum number of supported credential types.
        /// </summary>
        CRED_TYPE_MAXIMUM = 7,
        /// <summary>
        /// The extended maximum number of supported credential types that now allow new applications to run on older operating systems.
        /// </summary>
        CRED_TYPE_MAXIMUM_EX = (CRED_TYPE_MAXIMUM + 1000)
    }
}
#endif