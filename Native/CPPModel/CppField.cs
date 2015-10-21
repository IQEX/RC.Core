// =====================================//==============================================================//
// License="root\\LICENSE"              //   Copyright © Of Fire Twins Wesp 2015  <ls-micro@ya.ru>      //
// LicenseType="MIT"                    //                  Alise Wesp & Yuuki Wesp                     //
// =====================================//==============================================================//
namespace Rc.Core.CppModel
{
    /// <summary>
    /// A C++ field.
    /// </summary>
    public class CppField : CppType
    {
        /// <summary>
        /// Index of the field mostly used to handle unions.
        /// </summary>
        public int Offset { get; set; }
        /// <summary>
        /// Used only for structure with bits
        /// </summary>
        public bool IsBitField { get; set; }
        /// <summary>
        /// Used only for structure with bits
        /// </summary>
        public int BitOffset { get; set; }
        public override string ToShortString()
        {
            return string.Format("{0} {1}", TypeName, Name);
        }
        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>
        /// true if the current object is equal to the <paramref name="other" /> parameter; otherwise, false.
        /// </returns>
        public bool Equals(CppField other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && other.Offset == Offset && other.IsBitField.Equals(IsBitField) && other.BitOffset == BitOffset;
        }
        /// <summary>
        /// Determines whether the specified <see cref="System.Object"/> is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object"/> to compare with this instance.</param>
        /// <returns>
        /// 	<c>true</c> if the specified <see cref="System.Object"/> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as CppField);
        }
        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            unchecked
            {
                int result = base.GetHashCode();
                result = (result*397) ^ Offset;
                result = (result*397) ^ IsBitField.GetHashCode();
                result = (result*397) ^ BitOffset;
                return result;
            }
        }
    }
}