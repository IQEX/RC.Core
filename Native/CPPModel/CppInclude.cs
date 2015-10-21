// =====================================//==============================================================//
// License="root\\LICENSE"              //   Copyright © Of Fire Twins Wesp 2015  <ls-micro@ya.ru>      //
// LicenseType="MIT"                    //                  Alise Wesp & Yuuki Wesp                     //
// =====================================//==============================================================//
using System.Collections.Generic;
namespace Rc.Core.CppModel
{
    /// <summary>
    /// A C++ include contains C++ types declarations for macros, enums, structs, 
    /// interfaces and functions.
    /// </summary>
    public class CppInclude : CppElement
    {
        /// <summary>
        /// Gets the full name.
        /// </summary>
        /// <value>The full name.</value>
        public override string FullName
        {
            get { return ""; }
        }
        /// <summary>
        /// Gets the macros.
        /// </summary>
        /// <value>The macros.</value>
        public IEnumerable<CppDefine> Macros
        {
            get { return Iterate<CppDefine>(); }
        }
        /// <summary>
        /// Gets the interfaces.
        /// </summary>
        /// <value>The interfaces.</value>
        public IEnumerable<CppInterface> Interfaces
        {
            get { return Iterate<CppInterface>(); }
        }
        /// <summary>
        /// Gets the functions.
        /// </summary>
        /// <value>The functions.</value>
        public IEnumerable<CppFunction> Functions
        {
            get { return Iterate<CppFunction>(); }
        }
        /// <summary>
        /// Gets the structs.
        /// </summary>
        /// <value>The structs.</value>
        public IEnumerable<CppStruct> Structs
        {
            get { return Iterate<CppStruct>(); }
        }
        /// <summary>
        /// Gets the enums.
        /// </summary>
        /// <value>The enums.</value>
        public IEnumerable<CppEnum> Enums
        {
            get { return Iterate<CppEnum>(); }
        }
        /// <summary>
        /// Gets the guids.
        /// </summary>
        /// <value>The guids.</value>
        public IEnumerable<CppGuid> Guids
        {
            get { return Iterate<CppGuid>(); }
        }
        /// <summary>
        /// Gets the constants.
        /// </summary>
        /// <value>The constants.</value>
        public IEnumerable<CppConstant> Constants
        {
            get { return Iterate<CppConstant>(); }
        }
    }
}