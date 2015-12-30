// =====================================//==============================================================//
// License="root\\LICENSE"              //   Copyright © Of Fire Twins Wesp 2015  <ls-micro@ya.ru>      //
// LicenseType="MIT"                    //                  Alise Wesp & Yuuki Wesp                     //
// =====================================//==============================================================//
using System;
using System.Runtime.InteropServices;
namespace RC.Framework.Native.Runtime
{
    /// <summary>
    /// Base interface for Component Object Model (COM).
    /// </summary>
    [Guid("00000000-0000-0000-C000-000000000046")]
    public interface IUnknown
    {
        /// <summary>
        /// Increments the reference count for an interface on this instance.
        /// </summary>
        /// <returns>The method returns the new reference count.</returns>
        int AddReference();

        /// <summary>
        /// Decrements the reference count for an interface on this instance.
        /// </summary>
        /// <returns>The method returns the new reference count.</returns>
        int Release();
    }
}
