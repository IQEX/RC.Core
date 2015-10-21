// =====================================//==============================================================//
// License="root\\LICENSE"              //   Copyright © Of Fire Twins Wesp 2015  <ls-micro@ya.ru>      //
// LicenseType="MIT"                    //                  Alise Wesp & Yuuki Wesp                     //
// =====================================//==============================================================//
using System;
namespace Rc.Framework.Native.Runtime.CPPCom
{
    /// <summary>
    /// Use this interface to tag a class that is called by an unmanaged
    /// object. A <see cref="ICallbackable"/> class must dispose the <see cref="Shadow"/>
    /// on dispose.
    /// </summary>
    public interface ICallbackable : IDisposable
    {
        /// <summary>
        /// Gets or sets the unmanaged shadow callback.
        /// </summary>
        /// <value>The unmanaged shadow callback.</value>
        /// <remarks>
        /// This property is set whenever this instance has an unmanaged shadow callback
        /// registered. This callback must be disposed when disposing this instance. 
        /// </remarks>
        IDisposable Shadow { get; set; }
    }
}
