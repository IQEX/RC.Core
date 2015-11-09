// =====================================//==============================================================//
// License="root\\LICENSE"              //   Copyright © Of Fire Twins Wesp 2015  <ls-micro@ya.ru>      //
// LicenseType="MIT"                    //                  Alise Wesp & Yuuki Wesp                     //
// =====================================//==============================================================//
using System;
namespace Rc.Framework.IO.UnSafe.Memory
{
    /// <summary>
    /// Purifier
    /// </summary>
    public static class Disposer
    {
        /// <summary>
        /// Secure purification
        /// </summary>
        /// <typeparam name="T">Class instanse of IDisposable</typeparam>
        /// <param name="obj">Object of purification class</param>
        public static void SafeDispose<T>(ref T obj) where T : class, IDisposable
        {
            if (obj != null)
            {
                obj.Dispose();
                obj = null;
            }
        }
    }
}
