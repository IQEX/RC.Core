// =====================================//==============================================================//
//                                      //                                                              //         
// Source="root\\Security\\RSA.cs"      //             Copyright © Of Fire Twins Wesp 2015              //
// Author= {"Callada", "Another"}       //                                                              //
// Project="Rc.Framework"               //                  Alise Wesp & Yuuki Wesp                     //
// Version File="7.5"                   //                                                              //
// License="root\\LICENSE"              //                                                              //
// LicenseType="MIT"                    //                                                              //
// =====================================//==============================================================//
using Rc.Framework.Collections;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Rc.Framework.Security
{
    /// <summary>
    /// Class Pair Key
    /// </summary>
    [Serializable]
    public class RSAKeyPair
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="privatekey">Private Key</param>
        /// <param name="publickey">Public Key</param>
        public RSAKeyPair(string privatekey, string publickey)
        {
            this.XML_PrivateKey = privatekey;
            this.XML_PublicKey = publickey;
        }
        /// <summary>
        /// Приватный ключ
        /// </summary>
        public readonly string XML_PrivateKey;
        /// <summary>
        /// Публичный ключ
        /// </summary>
        public readonly string XML_PublicKey;
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
            return new RSAKeyPair(rsa.ToXmlString(true), rsa.ToXmlString(false));
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
            return Convert.ToBase64String(rsa.Encrypt(Encoding.UTF8.GetBytes(Phrase), false));
        }
        public string CryptByte(string xmlPublicKey, byte[] Phrase)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(xmlPublicKey);
            return Convert.ToBase64String(rsa.Encrypt(Phrase, false));
        }
        /// <summary>
        /// Расшифровывает строку используя приватный ключ
        /// </summary>
        /// <param name="xmlPrivateKey">Приватный ключ</param>
        /// <param name="Phrase">Шифрованная фраза</param>
        /// <returns></returns>
        public string Encrypt(string xmlPrivateKey, string Phrase)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(xmlPrivateKey);
            return Encoding.UTF8.GetString(rsa.Decrypt(Convert.FromBase64String(Phrase), false));
        }
        public byte[] EncryptByte(string xmlPrivateKey, string Phrase)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(xmlPrivateKey);
            return rsa.Decrypt(Convert.FromBase64String(Phrase), false);
        }
    }
}
