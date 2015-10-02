// =====================================//==============================================================//
//                                      //                                                              //
// Source="root\\Security\\Rule.cs"     //             Copyright © Of Fire Twins Wesp 2015              //
// Author= {"Callada", "Another"}       //                                                              //
// Project="Rc.Framework"               //                  Alise Wesp & Yuuki Wesp                     //
// Version File="5.0"                   //                                                              //
// License="root\\LICENSE"              //                                                              //
// LicenseType="MIT"                    //                                                              //
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
