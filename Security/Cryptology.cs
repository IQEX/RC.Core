using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Rc.Framework.Security.X05h
{
    /// <summary>
    /// Mixed Code
    /// </summary>
    public enum hMxCode
    {
        /// <summary>
        /// X1 Type
        /// </summary>
        X1,
        /// <summary>
        /// X2 Type
        /// </summary>
        X2,
        /// <summary>
        /// X3 Type
        /// </summary>
        X3
    }
    /// <summary>
    /// h Manager Class
    /// </summary>
    public class hMake
    {
        // public const string hPassGameMD5 = "X1-M5479A-S8BFAA";
        //x public const string hPassGameRSA = "X1-R58C32-S8BFAA";
        //x public const string hPassGameSHA = "X1-S5A6DF-S8BFAA";
        /// <summary>
        /// Parse hCode
        /// </summary>
        /// <param name="hCode"></param>
        /// <returns></returns>
        public static hMake Parse(string hCode)
        {
            hMake h = new hMake();
            hMxCode Code = (hMxCode)Enum.Parse(typeof(hMxCode), hCode.Split('-')[0]);
            h.isMD5 = hCode.Split('-')[1][0] == 'M' ? true : false;
            h.CountMD5Hashing = h.isMD5 ? int.Parse(hCode.Split('-')[1][1].ToString()) : 0;
            h.isRSA = hCode.Split('-')[1][0] == 'R' ? true : false;
            h.CountRsaHashing = h.isRSA ? int.Parse(hCode.Split('-')[1][1].ToString()) : 0;
            h.isSHA = hCode.Split('-')[1][0] == 'S' ? true : false;
            h.CountShaHashing = h.isSHA ? int.Parse(hCode.Split('-')[1][1].ToString()) : 0;
            h.isSoul = hCode.Split('-')[2][0] == 'S' ? true : false;
            h.isAssembly = hCode.Split('-')[2][4] == 'A' && hCode.Split('-')[2][5] == 'A' ? true : false;
            h.RawCode = hCode;
            return h;
        }
        /// <summary>
        /// Raw Data Code
        /// </summary>
        public string RawCode;
        /// <summary>
        /// Mixed Type
        /// </summary>
        public hMxCode xCode;
        public int CountMD5Hashing; public bool isMD5;
        public int CountRsaHashing; public bool isRSA;
        public int CountShaHashing; public bool isSHA;
        public bool isSoul; public bool isAssembly;
    }
    /// <summary>
    /// hPass Manager
    /// </summary>
    public class hPassword
    {
        /// <summary>
        /// Assembly Password
        /// </summary>
        /// <param name="str">Password</param>
        /// <param name="hCode">hCode</param>
        /// <param name="data">data output</param>
        /// <returns></returns>
        public static string Assembling(string str, string hCode, out object data)
        {
            string h1 = str;
            data = null;
            if (hMake.Parse(hCode).isMD5)
            {
                for(int i = 0; i != hMake.Parse(hCode).CountMD5Hashing; i++)
                    h1 = BitConverter.ToString(new MD5CryptoServiceProvider().ComputeHash(Encoding.UTF8.GetBytes(h1)));
            }
            else if(hMake.Parse(hCode).isRSA)
            {
                throw new Exception("Not implemented - RSA Crypt");
            }
            else if (hMake.Parse(hCode).isSHA)
            {
                throw new Exception("Not implemented - SHA Crypt");
            }
            if (hMake.Parse(hCode).isAssembly)
            {
                string h2 = default(string);
                h2 += $"{h1.Split('-')[00]}{h1.Split('-')[01]}{h1.Split('-')[02]}{h1.Split('-')[03]}-";
                h2 += $"{h1.Split('-')[04]}{h1.Split('-')[05]}{h1.Split('-')[06]}{h1.Split('-')[07]}-";
                h2 += $"{h1.Split('-')[08]}{h1.Split('-')[09]}{h1.Split('-')[10]}{h1.Split('-')[11]}-";
                h2 += $"{h1.Split('-')[12]}{h1.Split('-')[13]}{h1.Split('-')[14]}{h1.Split('-')[15]}";
                h1 = h2;
            }
            if (hMake.Parse(hCode).isSoul)
            {
                char[] ar = hCode.ToUpper().ToCharArray();
                Array.Reverse(ar);
                h1 += $"-{new string(ar)}";
            }
            if (!hMake.Parse(hCode).isAssembly)
                h1.Replace("-", default(string));
            return h1;
        }
    }
}
