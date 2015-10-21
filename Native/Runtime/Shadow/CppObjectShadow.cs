// =====================================//==============================================================//
// License="root\\LICENSE"              //   Copyright © Of Fire Twins Wesp 2015  <ls-micro@ya.ru>      //
// LicenseType="MIT"                    //                  Alise Wesp & Yuuki Wesp                     //
// =====================================//==============================================================//
using Rc.Framework.Native.Runtime.CPPCom;
using Rc.Framework.Native.Runtime.Diagnostic;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
namespace Rc.Framework.Native.Runtime.Shadow
{
    /// <summary>
    /// An Interface shadow callback
    /// </summary>
    public abstract class CppObjectShadow : CppObject
    {
        /// <summary>
        /// Gets the callback.
        /// </summary>
        public ICallbackable Callback { get; private set; }

        /// <summary>
        /// Gets the VTBL associated with this shadow instance.
        /// </summary>
        protected abstract CppObjectVtbl GetVtbl { get; }

        /// <summary>
        /// Initializes the specified shadow instance from a vtbl and a callback.
        /// </summary>
        /// <param name="callbackInstance">The callback.</param>
        public unsafe virtual void Initialize(ICallbackable callbackInstance)
        {
            this.Callback = callbackInstance;

            // Allocate ptr to vtbl + ptr to callback together
            NativePointer = Marshal.AllocHGlobal(IntPtr.Size * 2);

            var handle = GCHandle.Alloc(this);
            Marshal.WriteIntPtr(NativePointer, GetVtbl.Pointer);

            *((IntPtr*)NativePointer + 1) = GCHandle.ToIntPtr(handle);
        }

        protected unsafe override void Dispose(bool disposing)
        {
            if (NativePointer != IntPtr.Zero)
            {
                // Free the GCHandle
                GCHandle.FromIntPtr(*(((IntPtr*)NativePointer) + 1)).Free();

                // Free instance
                Marshal.FreeHGlobal(NativePointer);
                NativePointer = IntPtr.Zero;
            }
            Callback = null;
            base.Dispose(disposing);
        }

        public static T ToShadow<T>(IntPtr thisPtr) where T : CppObjectShadow
        {
            unsafe
            {
                return (T)GCHandle.FromIntPtr(*(((IntPtr*)thisPtr) + 1)).Target;
            }
        }
    }
}
