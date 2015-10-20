// =====================================//==============================================================//
//                                      //                                                              //
// Source="root\\Conf\\PrivateProfile.cs"/                Copyright © Of Fire Twins Wesp 2015           //
// Author= {"Callada", "Another"}       //                                                              //
// Project="Rc.Framework"               //                  Alise Wesp & Yuuki Wesp                     //
// Version File="1.0"                   //                                                              //
// License="root\\LICENSE"              //                                                              //
// LicenseType="MIT"                    //                                                              //
// =====================================//==============================================================//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rc.Framework.Conf
{
    public class PrivateProfile
    {
        public string path;
        /// <summary>
        /// INIFile Constructor.
        /// </summary>
        /// <PARAM name="INIPath"></PARAM>
        public PrivateProfile(string INIPath)
        {
            this.path = INIPath;
        }
        /// <summary>
        /// Write Data to the INI File
        /// </summary>
        /// <PARAM name="Section"></PARAM>
        /// Section name
        /// <PARAM name="Key"></PARAM>
        /// Key Name
        /// <PARAM name="Value"></PARAM>
        /// Value Name
        public void Write(string Section, string Key, string Value)
        {
            Native.NativeMethods.WritePrivateProfileString(Section, Key, Value, this.path);
        }
        /// <summary>
        /// Read Data Value From the Ini File
        /// </summary>
        /// <PARAM name="Section"></PARAM>
        /// <PARAM name="Key"></PARAM>
        /// <PARAM name="Default"></PARAM>
        /// <returns></returns>
        public string Read(string Section, string Key, string Default)
        {
            StringBuilder temp = new StringBuilder(255);
            int i = Native.NativeMethods.GetPrivateProfileString(Section, Key, Default, temp, 255, this.path);
            return temp.ToString();
        }
    }
}
