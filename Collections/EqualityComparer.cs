// =====================================//==============================================================//
// License="root\\LICENSE"              //   Copyright © Of Fire Twins Wesp 2015  <ls-micro@ya.ru>      //
// LicenseType="MIT"                    //                  Alise Wesp & Yuuki Wesp                     //
// =====================================//==============================================================//
namespace RC.Framework.Collections
{
    using System;
    using System.Collections.Generic;
    /// <summary>
    /// Provides <see cref="IEqualityComparer{T}"/> for default value types.
    /// </summary>
    public static class EqualityComparer
    {
        /// <summary>
        /// A default <see cref="IEqualityComparer{T}"/> for <see cref="System.IntPtr"/>.
        /// </summary>
        public static readonly IEqualityComparer<IntPtr> DefaultIntPtr = new IntPtrComparer();

        internal class IntPtrComparer : EqualityComparer<IntPtr>
        {
            public override bool Equals(IntPtr x, IntPtr y)
            {
                return x == y;
            }
            public override int GetHashCode(IntPtr obj)
            {
                return obj.GetHashCode();
            }
        }
    }
}
