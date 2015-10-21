// =====================================//==============================================================//
// License="root\\LICENSE"              //   Copyright © Of Fire Twins Wesp 2015  <ls-micro@ya.ru>      //
// LicenseType="MIT"                    //                  Alise Wesp & Yuuki Wesp                     //
// =====================================//==============================================================//
namespace Rc.Core.CppModel
{
    /// <summary>
    /// A C++ define macro Name=Value.
    /// </summary>
    public class CppDefine : CppElement
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CppDefine"/> class.
        /// </summary>
        public CppDefine()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CppDefine"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        public CppDefine(string name, string value)
        {
            Name = name;
            Value = value;
        }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        public string Value { get; set; }

        /// <summary>
        /// Gets a stripped string value trimming double-quotes ".
        /// </summary>
        /// <value>The strip string value.</value>
        public string StripStringValue
        {
            get
            {
                return Value.Trim('"');
            }
        }
    }
}