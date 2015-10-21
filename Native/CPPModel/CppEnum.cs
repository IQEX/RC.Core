// =====================================//==============================================================//
// License="root\\LICENSE"              //   Copyright © Of Fire Twins Wesp 2015  <ls-micro@ya.ru>      //
// LicenseType="MIT"                    //                  Alise Wesp & Yuuki Wesp                     //
// =====================================//==============================================================//
using System.Collections.Generic;
namespace Rc.Core.CppModel
{
    /// <summary>
    /// A C++ enum.
    /// </summary>
    public class CppEnum : CppElement
    {
        /// <summary>
        /// Adds an enum item to this enum.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        public void AddEnumItem(string name, string value)
        {
            Add(new CppEnumItem(name, value));
        }
        /// <summary>
        /// Adds the None = 0 enum item.
        /// </summary>
        public void AddNone()
        {
            AddEnumItem("None", "0");
        }
        /// <summary>
        /// Gets the enum items.
        /// </summary>
        /// <value>The enum items.</value>
        public IEnumerable<CppEnumItem> EnumItems
        {
            get { return Iterate<CppEnumItem>(); }
        }
    }
}