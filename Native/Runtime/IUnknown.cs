using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Rc.Framework.Native.Runtime
{
    /// <summary>
    /// Base interface for Component Object Model (COM).
    /// </summary>
    [Guid("00000000-0000-0000-C000-000000000046")]
    public interface IUnknown
    {
        /// <summary>
        /// Queries the supported COM interface on this instance.
        /// </summary>
        /// <param name="guid">The guid of the interface.</param>
        /// <param name="comObject">The output COM object reference.</param>
        /// <returns>If successful, <see cref="Result.Ok"/> </returns>
        Result QueryInterface(ref Guid guid, out IntPtr comObject);

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
