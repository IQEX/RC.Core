// =====================================//==============================================================//
// License="root\\LICENSE"              //   Copyright © Of Fire Twins Wesp 2015  <ls-micro@ya.ru>      //
// LicenseType="MIT"                    //                  Alise Wesp & Yuuki Wesp                     //
// =====================================//==============================================================//
namespace Rc.Core.CppModel
{
    /// <summary>
    /// A C++ constant Name/Value.
    /// </summary>
    public class CppConstant : CppElement
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CppConstant"/> class.
        /// </summary>
        public CppConstant()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CppConstant"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        public CppConstant(string name, string value)
        {
            Name = name;
            Value = value;
        }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        public string Value{ get; set; }
    }
}