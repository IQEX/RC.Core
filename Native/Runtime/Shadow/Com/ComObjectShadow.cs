// =====================================//==============================================================//
// License="root\\LICENSE"              //   Copyright © Of Fire Twins Wesp 2015  <ls-micro@ya.ru>      //
// LicenseType="MIT"                    //                  Alise Wesp & Yuuki Wesp                     //
// =====================================//==============================================================//
using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace Rc.Framework.Native.Runtime.Shadow.Com
{
    /// <summary>
    /// A COM Interface Callback
    /// </summary>
    internal abstract class ComObjectShadow : CppObjectShadow
    {
        private int count = 1;
        public static Guid IID_IUnknown = new Guid("00000000-0000-0000-C000-000000000046");

        protected int QueryInterfaceImpl(IntPtr thisObject, ref Guid guid, out IntPtr output)
        {
            var shadow = (ComObjectShadow)((ShadowContainer)Callback.Shadow).FindShadow(guid);
            if (shadow != null)
            {
                shadow.AddRefImpl(thisObject);
                output = shadow.NativePointer;
                return Result.Ok.Code;
            }
            output = IntPtr.Zero;
            return Result.NoInterface.Code;
        }

        protected virtual int AddRefImpl(IntPtr thisObject)
        {
            return Interlocked.Increment(ref count);
        }

        protected virtual int ReleaseImpl(IntPtr thisObject)
        {
            return Interlocked.Decrement(ref count);
        }

        internal class ComObjectVtbl : CppObjectVtbl
        {
            public ComObjectVtbl(int numberOfCallbackMethods) : base(numberOfCallbackMethods + 3)
            {
                unsafe
                {
                    AddMethod(new QueryInterfaceDelegate(QueryInterfaceImpl));
                    AddMethod(new AddRefDelegate(AddRefImpl));
                    AddMethod(new ReleaseDelegate(ReleaseImpl));
                }
            }

            [UnmanagedFunctionPointer(CallingConvention.StdCall)]
            public delegate int QueryInterfaceDelegate(IntPtr thisObject, IntPtr guid, out IntPtr output);

            [UnmanagedFunctionPointer(CallingConvention.StdCall)]
            public delegate int AddRefDelegate(IntPtr thisObject);

            [UnmanagedFunctionPointer(CallingConvention.StdCall)]
            public delegate int ReleaseDelegate(IntPtr thisObject);

            protected static int QueryInterfaceImpl(IntPtr thisObject, IntPtr guid, out IntPtr output)
            {
                var shadow = ToShadow<ComObjectShadow>(thisObject);
                if (shadow == null)
                {
                    output = IntPtr.Zero;
                    return Result.NoInterface.Code;
                }
                unsafe
                {
                    return shadow.QueryInterfaceImpl(thisObject, ref *((Guid*)guid), out output);
                }
            }

            protected static int AddRefImpl(IntPtr thisObject)
            {
                var shadow = ToShadow<ComObjectShadow>(thisObject);
                // The shadow could be null if it is released explicitly
                // But we are callbacked by a C++ that want to release it.
                if (shadow == null)
                    return 0;
                return shadow.AddRefImpl(thisObject);
            }

            protected static int ReleaseImpl(IntPtr thisObject)
            {
                var shadow = ToShadow<ComObjectShadow>(thisObject);
                // The shadow could be null if it is released explicitly
                // But we are callbacked by a C++ that want to release it.
                if (shadow == null)
                    return 0;
                return shadow.ReleaseImpl(thisObject);
            }
        }
    }
}
