// =====================================//==============================================================//
// License="root\\LICENSE"              //   Copyright © Of Fire Twins Wesp 2015  <ls-micro@ya.ru>      //
// LicenseType="MIT"                    //                  Alise Wesp & Yuuki Wesp                     //
// =====================================//==============================================================//
namespace RC.Framework.Security
{
    using System;
    using System.Security.Cryptography;
    using System.Text;
    /// <summary>
    /// Class Pair Key
    /// </summary>
    public class RSAKeyPair
    {
        /// <summary>
        /// </summary>
        /// <param name="privatekey">Private Key</param>
        /// <param name="publickey">Public Key</param>
        public RSAKeyPair(string privatekey, string publickey)
        {
            this.XML_PrivateKey = privatekey;
            this.XML_PublicKey = publickey;
        }
        /// <summary>
        /// Private Key
        /// </summary>
        public string XML_PrivateKey;
        /// <summary>
        /// Public Key
        /// </summary>
        public string XML_PublicKey;
    }
    /// <summary>
    /// Engine RSA
    /// </summary>
    public class RSA
    {
        /// <summary>
        /// Создает пару ключ
        /// </summary>
        /// <returns></returns>
        public RSAKeyPair CreateKey()
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            return new RSAKeyPair(rsa.ToXmlString(includePrivateParameters: true), rsa.ToXmlString(includePrivateParameters: false));
        }
        /// <summary>
        /// Шифрует строку используя публичный ключ
        /// </summary>
        /// <param name="xmlPublicKey">публичный ключ в виде xml</param>
        /// <param name="Phrase">Фраза для шифрования</param>
        /// <returns></returns>
        public string Crypt(string xmlPublicKey, string Phrase)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(xmlPublicKey);
            return Convert.ToBase64String(rsa.Encrypt(Encoding.UTF8.GetBytes(Phrase), fOAEP: false));
        }
        /// <summary>
        /// Шифрует массив байтов используя публичный ключ
        /// </summary>
        /// <param name="xmlPublicKey">публичный ключ в виде xml</param>
        /// <param name="Phrase">Фраза для шифрования</param>
        /// <returns>зашифрованная строка</returns>
        public string CryptByte(string xmlPublicKey, byte[] Phrase)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(xmlPublicKey);
            return Convert.ToBase64String(rsa.Encrypt(Phrase, fOAEP: false));
        }
        /// <summary>
        /// Расшифровывает строку используя приватный ключ
        /// </summary>
        /// <param name="xmlPrivateKey">Приватный ключ</param>
        /// <param name="Phrase">Шифрованная фраза</param>
        /// <returns>шифрованная строка</returns>
        public string Encrypt(string xmlPrivateKey, string Phrase)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(xmlPrivateKey);
            return Encoding.UTF8.GetString(rsa.Decrypt(Convert.FromBase64String(Phrase), fOAEP: false));
        }
        /// <summary>
        /// Расшифровывает строку используя приватный ключ
        /// </summary>
        /// <param name="xmlPrivateKey">Приватный ключ</param>
        /// <param name="Phrase">Шифрованная фраза</param>
        /// <returns>массив байтов</returns>
        public byte[] EncryptByte(string xmlPrivateKey, string Phrase)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(xmlPrivateKey);
            return rsa.Decrypt(Convert.FromBase64String(Phrase), fOAEP: false);
        }
    }
}
