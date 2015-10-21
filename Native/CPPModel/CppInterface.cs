// =====================================//==============================================================//
// License="root\\LICENSE"              //   Copyright © Of Fire Twins Wesp 2015  <ls-micro@ya.ru>      //
// LicenseType="MIT"                    //                  Alise Wesp & Yuuki Wesp                     //
// =====================================//==============================================================//
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Rc.Core.CppModel
{
    /// <summary>
    /// A C++ interface.
    /// </summary>
    public class CppInterface : CppElement
    {
        /// <summary>
        /// Gets or sets the GUID.
        /// </summary>
        /// <value>The GUID.</value>
        public string Guid { get; set; }
        /// <summary>
        /// Gets or sets the name of the parent.
        /// </summary>
        /// <value>The name of the parent.</value>
        public string ParentName { get; set; }
        /// <summary>
        /// Gets the methods.
        /// </summary>
        /// <value>The methods.</value>
        public IEnumerable<CppMethod> Methods
        {
            get { return Iterate<CppMethod>(); }
        }
        /// <summary>
        /// Gets or sets the total method count.
        /// </summary>
        /// <value>The total method count.</value>
        internal int TotalMethodCount { get; set; }
    }
}