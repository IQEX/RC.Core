// =====================================//==============================================================//
// License="root\\LICENSE"              //   Copyright © Of Fire Twins Wesp 2015  <ls-micro@ya.ru>      //
// LicenseType="MIT"                    //                  Alise Wesp & Yuuki Wesp                     //
// =====================================//==============================================================//
namespace Rc.Framework.Conf
{
    /// <summary>
    /// INIFile Profile
    /// </summary>
    public interface IPrivateProfile
    {
        /// <summary>
        /// Read Data to the INI File
        /// </summary>
        /// <param name="Section">Section name</param>
        /// <param name="Key">Key Name</param>
        /// <param name="Default">Default value</param>
        /// <returns>string</returns>
        string Read(string Section, string Key, string Default);
        /// <summary>
        /// Write Data to the INI File
        /// </summary>
        /// <param name="Section">Section name</param>
        /// <param name="Key">Key Name</param>
        /// <param name="Value">Value Name</param>
        /// <returns>string</returns>
        void Write(string Section, string Key, string Value);
    }
}