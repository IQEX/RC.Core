// =====================================//==============================================================//
// License="root\\LICENSE"              //   Copyright © Of Fire Twins Wesp 2015  <ls-micro@ya.ru>      //
// LicenseType="MIT"                    //                  Alise Wesp & Yuuki Wesp                     //
// =====================================//==============================================================//
using System.Text;
using System.Xml.Serialization;

namespace Rc.Core.CppModel
{
    /// <summary>
    ///     Type declaration.
    /// </summary>
    public class CppType : CppElement
    {
        /// <summary>
        ///     Gets or sets the name of the type.
        /// </summary>
        /// <value>
        ///     The name of the type.
        /// </value>
        public string TypeName { get; set; }
        /// <summary>
        ///     Gets or sets the pointer.
        /// </summary>
        /// <value>
        ///     The pointer.
        /// </value>
        public string Pointer { get; set; }
        /// <summary>
        ///     Gets or sets a value indicating whether this <see cref="CppType"/> is const.
        /// </summary>
        /// <value>
        ///     <c>true</c> if const;
        ///     otherwise, <c>false</c>.
        /// </value>
        public bool Const { get; set; }
        /// <summary>
        ///     Gets or sets a value indicating whether this instance is array.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is array; 
        ///     otherwise, <c>false</c>.
        /// </value>
        public bool IsArray { get; set; }
        /// <summary>
        ///     Gets or sets the array dimension.
        /// </summary>
        /// <value>
        ///     The array dimension.
        /// </value>
        public string ArrayDimension { get; set; }

        /// <summary>
        ///     Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>
        ///     A <see cref="System.String"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            var builder = new StringBuilder();
            if (Const)
                builder.Append("const ");
            builder.Append(TypeName);
            builder.Append(Pointer);

            if (!string.IsNullOrEmpty(Name))
            {
                builder.Append(" ");
                builder.Append(Name);
            }

            if (IsArray)
            {
                builder.Append("[");
                builder.Append(ArrayDimension);
                builder.Append("]");
            }
            return builder.ToString();
        }

        public override string ToShortString()
        {
            return TypeName;
        }

        public bool Equals(CppType other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.TypeName, TypeName) && Equals(other.Pointer, Pointer);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((TypeName != null ? TypeName.GetHashCode() : 0)*397) ^ (Pointer != null ? Pointer.GetHashCode() : 0);
            }
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (CppType)) return false;
            return Equals((CppType) obj);
        }
    }
}