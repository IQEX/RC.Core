// =====================================//==============================================================//
// License="root\\LICENSE"              //   Copyright © Of Fire Twins Wesp 2015  <ls-micro@ya.ru>      //
// LicenseType="MIT"                    //                  Alise Wesp & Yuuki Wesp                     //
// =====================================//==============================================================//
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Rc.Core.CppModel
{
    /// <summary>
    ///     A C++ method.
    /// </summary>
    public class CppMethod : CppElement
    {
        /// <summary>
        ///     Gets or sets the type of the return.
        /// </summary>
        /// <value>
        ///     The type of the return.
        /// </value>
        public CppType ReturnType { get; set; }
        /// <summary>
        /// Gets or sets the calling convention.
        /// </summary>
        /// <value>The calling convention.</value>
        public CppCallingConvention CallingConvention { get; set; }
        /// <summary>
        /// Gets or sets the offset.
        /// </summary>
        /// <value>The offset.</value>
        public int Offset { get; set; }
        /// <summary>
        /// Gets the parameters.
        /// </summary>
        /// <value>The parameters.</value>
        public IEnumerable<CppParameter> Parameters
        {
            get { return Iterate<CppParameter>(); }
        }
        protected override IEnumerable<CppElement> AllItems
        {
            get
            {
                var allElements = new List<CppElement>(Iterate<CppElement>());
                allElements.Add(ReturnType);
                return allElements;
            }            
        }
        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.Append(ReturnType);
            builder.Append(" ");
            if (Parent is CppInterface)
            {
                builder.Append(Parent.Name);
                builder.Append("::");
            }
            builder.Append(Name);
            builder.Append("(");
            int i = 0, count = Parameters.Count();
            foreach (var cppParameter in Parameters)
            {
                builder.Append(cppParameter);
                if ((i + 1) < count)
                {
                    builder.Append(",");
                }
                i++;
            }
            builder.Append(")");
            return builder.ToString();
        }

        public override string ToShortString()
        {
            var builder = new StringBuilder();
            if (Parent is CppInterface)
            {
                builder.Append(Parent.Name);
                builder.Append("::");
            }
            builder.Append(Name);
            return builder.ToString();
        }
    }
}