// =====================================//==============================================================//
// License="root\\LICENSE"              //   Copyright © Of Fire Twins Wesp 2015  <ls-micro@ya.ru>      //
// LicenseType="MIT"                    //                  Alise Wesp & Yuuki Wesp                     //
// =====================================//==============================================================//
namespace Rc.Core.CppModel
{
    /// <summary>
    /// The C++ calling convention.
    /// </summary>
    public enum CppCallingConvention
    {
        /// <summary>
        /// Unknown calling convention.
        /// </summary>
        Unknown = 0,
        /// <summary>
        /// Stdcall calling convention.
        /// </summary>
        StdCall = 1,
        /// <summary>
        /// Fastcall calling convention.
        /// </summary>
        FastCall = 2,
        /// <summary>
        /// Thiscall calling convention.
        /// </summary>        
        ThisCall = 3,
        /// <summary>
        /// Cdecl calling convention.
        /// </summary>    
        CDecl = 4,
    }
}