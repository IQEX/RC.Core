// =====================================//==============================================================//
// License="root\\LICENSE"              //   Copyright © Of Fire Twins Wesp 2015  <ls-micro@ya.ru>      //
// LicenseType="MIT"                    //                  Alise Wesp & Yuuki Wesp                     //
// =====================================//==============================================================//
namespace Rc.Core.CppModel
{
    /// <summary>
    /// A C++ enum item Name = Value.
    /// </summary>
    public class CppEnumItem : CppElement
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CppEnumItem"/> class.
        /// </summary>
        public CppEnumItem()
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="CppEnumItem"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        public CppEnumItem(string name, string value)
        {
            Name = name;
            Value = value;
        }
        /// <summary>
        /// Gets the path.
        /// </summary>
        /// <value>The path.</value>
        public override string Path
        {
            get
            {
                // Return "" as enum items are global in C++.
                return "";
            }
        }
        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        public string Value { get; set; }
        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return "EnumItem [" + Name + "]";
        }
    }
}