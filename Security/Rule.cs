// =====================================//==============================================================//
// License="root\\LICENSE"              //   Copyright © Of Fire Twins Wesp 2015  <ls-micro@ya.ru>      //
// LicenseType="MIT"                    //                  Alise Wesp & Yuuki Wesp                     //
// =====================================//==============================================================//
using System.Security.Principal;
namespace Rc.Framework.Security
{
    /// <summary>
    /// Class manager rule app
    /// </summary>
    public class Rule
    {
        /// <summary>
        /// is Admin rule?
        /// </summary>
        /// <returns>rule</returns>
        public static bool isProssesAdmin()
        {
            return new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator);
        }
    }
}
