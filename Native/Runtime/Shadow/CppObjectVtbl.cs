// =====================================//==============================================================//
// License="root\\LICENSE"              //   Copyright © Of Fire Twins Wesp 2015  <ls-micro@ya.ru>      //
// LicenseType="MIT"                    //                  Alise Wesp & Yuuki Wesp                     //
// =====================================//==============================================================//
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Rc.Framework.Native.Runtime.Shadow
{
    public class CppObjectVtbl
    {
        private readonly List<Delegate> methods;
        private readonly IntPtr vtbl;

        /// <summary>
        /// Default Constructor.
        /// </summary>
        /// <param name="numberOfCallbackMethods">number of methods to allocate in the VTBL</param>
        public CppObjectVtbl(int numberOfCallbackMethods)
        {
            // Allocate ptr to vtbl
            vtbl = Marshal.AllocHGlobal(IntPtr.Size * numberOfCallbackMethods);
            methods = new List<Delegate>();
        }

        /// <summary>
        /// Gets the pointer to the vtbl.
        /// </summary>
        public IntPtr Pointer
        {
            get { return vtbl; }
        }

        /// <summary>
        /// Add a method supported by this interface. This method is typically called from inherited constructor.
        /// </summary>
        /// <param name="method">the managed delegate method</param>
        public unsafe void AddMethod(Delegate method)
        {
            int index = methods.Count;
            methods.Add(method);
            *((IntPtr*)vtbl + index) = Marshal.GetFunctionPointerForDelegate(method);
        }
    }
}
