// =====================================//==============================================================//
// License="root\\LICENSE"              //   Copyright © Of Fire Twins Wesp 2015  <ls-micro@ya.ru>      //
// LicenseType="MIT"                    //                  Alise Wesp & Yuuki Wesp                     //
// =====================================//==============================================================//
namespace RC.Framework.Security
{
    using System;
    using System.Collections.Generic;
    using System.Security.Cryptography;
    using System.IO;
    /// <summary>
    /// Class hash Manager
    /// </summary>
    public class HashSum
    {
        /// <summary>
        /// Check Sum Hash File
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string Checksum(string path)
        {
            FileStream fs = File.OpenRead(path);
            MD5 md5 = new MD5CryptoServiceProvider();
            var fileData = new byte[fs.Length];
            fs.Read(fileData, offset: 0, count: (int)fs.Length);
            fs.Close();
            return BitConverter.ToString(md5.ComputeHash(fileData)).Replace("-", string.Empty);
        }
        /// <summary>
        /// Hash Sum File's in directory
        /// </summary>
        /// <param name="pathes"></param>
        /// <returns></returns>
        public static Dictionary<string, string> SearchDirectory(string[] pathes)
        {
            Dictionary<string, string> temp = new Dictionary<string, string>();
            for (int i = 0; i != pathes.Length; i++)
            {
                temp.Add(pathes[i], Checksum(pathes[i]));
            }
            return null;
        }
    }
}
