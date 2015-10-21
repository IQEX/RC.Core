// =====================================//==============================================================//
// License="root\\LICENSE"              //   Copyright © Of Fire Twins Wesp 2015  <ls-micro@ya.ru>      //
// LicenseType="MIT"                    //                  Alise Wesp & Yuuki Wesp                     //
// =====================================//==============================================================//
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Rc.Core.CppModel
{
    /// <summary>
    /// A C++ struct.
    /// </summary>
    public class CppStruct : CppElement
    {
        /// <summary>
        ///     Gets or sets the align.
        /// </summary>
        /// <value>
        ///     The align.
        /// </value>
        public int Align { get; set; }
        /// <summary>
        ///     Gets the fields.
        /// </summary>
        /// <value>
        ///     The fields.
        /// </value>
        public IEnumerable<CppField> Fields
        {
            get { return Iterate<CppField>(); }
        }
    }
}