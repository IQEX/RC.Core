// =====================================//==============================================================//
// License="root\\LICENSE"              //   Copyright © Of Fire Twins Wesp 2015  <ls-micro@ya.ru>      //
// LicenseType="MIT"                    //                  Alise Wesp & Yuuki Wesp                     //
// =====================================//==============================================================//
using Rc.Framework.Native.Runtime.CPPCom;
using System;
using System.Runtime.InteropServices;
namespace Rc.Framework.Native.Runtime.Shadow.Unmanaged
{
    /// <summary>
    /// IInspectable used for a C# callback object exposed as WinRT Component.
    /// </summary>
    /// <msdn-id>br205821</msdn-id>
    /// <unamanaged>IInspectable</unamanaged>
    /// <unmanaged-short>IInspectable</unmanaged-short>	
    [Guid("AF86E2E0-B12D-4c6a-9C5A-D7AA65101E90")]
    [ShadowAttribute(typeof(InspectableShadow))]
    public interface IInspectable : ICallbackable
    {
    };
}
