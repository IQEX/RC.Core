// =====================================//==============================================================//
//                                      //                                                              //         
// Source="root\\Yaml\\Yamli.cs"        //             Copyright © Of Fire Twins Wesp 2015              //
// Author= {"Callada", "Another"}       //                                                              //
// Project="Rc.Framework"               //                  Alise Wesp & Yuuki Wesp                     //
// Version File="7.5"                   //                                                              //
// =====================================//==============================================================//
using Rc.Framework.Collections;
using Rc.Framework.Security;
using Rc.Framework;
using System.Text;
using System.IO;
using System;

namespace Rc.Framework.Yaml
{
    [Serializable]
    public class OrchYamlReader
    {
        private readonly string YmlData;
        private readonly string[] YmlCollection;
        public static OrchYamlReader Open(string PathToOYml)
        {
            return new OrchYamlReader(PathToOYml);
        }
        private OrchYamlReader(string ph)
        {
            YmlData = Encoding.UTF8.GetString(new CryptByte().EnCrypt(File.ReadAllText(ph, Encoding.UTF8).Replace("\n", "")));
            YmlCollection = YmlData.Split('\n');
        }
        public string GetFiled(string key, string def)
        {
            try
            {
                foreach (string ks in YmlCollection)
                {
                    if (ks.Substring(0, 1) == "#")
                        continue;
                    if (ks.Split(':')[0] == key)
                        return ks.Split(':')[1].Replace(" ", "").Replace("\'", "");
                }
            }
            catch { }
            return def;
        }
        public int GetFiled(string key, int def)
        {
            try
            {
                foreach (string ks in YmlCollection)
                {
                    if (ks.Substring(0, 1) == "#")
                        continue;
                    if (ks.Split(':')[0] == key)
                        return Convert.ToInt32(ks.Split(':')[1].Replace(" ", "").Replace("\'", ""));
                }
            }
            catch { }
            return def;
        }
    }
    [Serializable]
    public class OrchYamlWriter
    {
        private readonly StringBuilder st;
        private readonly string Head = "# Original Crate Hole Markup Language (OrchML) 1.6\n# Author: Callada\n# Config RC.Framework.\n# Don't touch this file!\n";
        private string Path;
        public static OrchYamlWriter Create(string ph)
        {
            return new OrchYamlWriter(ph, false);
        }
        private OrchYamlWriter(string ph, bool isEx)
        {
            this.Path = ph;
            st = new StringBuilder();
            st.Append(Head);
        }
        public void AddFiled(string key, string value)
        {
            st.Append(string.Format("{0}: \'{1}\'\n", key, value));
        }
        public string ToStr()
        {
            StringBuilder BitBuilder = new StringBuilder();
            CryptByte bcry = new CryptByte();
            string complete = bcry.ToCrypt(Encoding.UTF8.GetBytes(st.ToString()));
            foreach (char chrs in complete)
            {
                BitBuilder.Append(chrs + '\n');
            }
            return BitBuilder.ToString();
        }
        public void AddFiled(string key, int value)
        {
            st.Append(string.Format("{0}: {1}\n", key, value));
        }
        private void AddFiled(string key, int[] value)
        {
            string kzstring = string.Empty;
            kzstring += "[ ";
            foreach (int val in value)
            {
                kzstring += string.Format("{0},", val);
            }
            kzstring = kzstring.Remove(kzstring.Length - 1, 1);
            kzstring += " ]";
            st.Append(string.Format("{0}: {1}\n", key, kzstring));
        }
        public void Save(bool crypt = true)
        {
            StringBuilder BitBuilder = new StringBuilder();
            if (crypt)
            {
                CryptByte bcry = new CryptByte();
                string complete = bcry.ToCrypt(Encoding.UTF8.GetBytes(st.ToString()));
                int i = 0;
                foreach (char chrs in complete)
                {
                    if(i >= 17 * 5)
                    {
                        i = 0;
                        BitBuilder.Append("\n");
                        BitBuilder.Append(chrs);
                    } 
                    else
                        BitBuilder.Append(chrs);
                    i++;
                }
            }
            else
            {
                BitBuilder.Append(st.ToString());
            }
            if (File.Exists(Path))
                File.Delete(Path);
            File.WriteAllText(Path, BitBuilder.ToString(), Encoding.UTF8);
        }
    }
}
