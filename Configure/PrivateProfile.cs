// =====================================//==============================================================//
// License="root\\LICENSE"              //   Copyright © Of Fire Twins Wesp 2015  <ls-micro@ya.ru>      //
// LicenseType="MIT"                    //                  Alise Wesp & Yuuki Wesp                     //
// =====================================//==============================================================//
using System.Text;
namespace Rc.Framework.Conf
{
    /// <summary>
    /// INIFile Profile
    /// </summary>
    public class PrivateProfile : IPrivateProfile
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
