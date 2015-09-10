// =====================================//==============================================================//
//                                      //                                                              //         
// Source="root\\Security\\HashCheak.cs"//             Copyright © Of Fire Twins Wesp 2015              //
// Author= {"Callada", "Another"}       //                                                              //
// Project="Rc.Framework"               //                  Alise Wesp & Yuuki Wesp                     //
// Version File="6.3"                   //                                                              //
// License="root\\LICENSE"              //                                                              //
// LicenseType="MIT"                    //                                                              //
// =====================================//==============================================================//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace Rc.Framework.Security
{
    public class HashSum
    {
        public static string Checksum(string path)
        {
            byte[] fileData;
            MD5 md5;
            FileStream fs = System.IO.File.OpenRead(path);
            md5 = new MD5CryptoServiceProvider();
            fileData = new byte[fs.Length];
            fs.Read(fileData, 0, (int)fs.Length);
            fs.Close();
            return BitConverter.ToString(md5.ComputeHash(fileData)).Replace("-", String.Empty);
        }
        public static Dictionary<string, string> SearchDirectory(string[] pathes)
        {
            Dictionary<string, string> temp = new Dictionary<string, string>();
            for (int i = 0; i != pathes.Length; i++)
            {
                temp.Add(pathes[i], HashSum.Checksum(pathes[i]));
            }
            return null;
        }
    }
}
