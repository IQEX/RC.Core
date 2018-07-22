#pragma warning disable 1591
namespace RC.Framework.Net.Arch
{
    using System.IO;
    /// <summary>
    /// Manager class Arch
    /// </summary>
    /// <c>
    /// Of Fire Twins Wesp 2014-2016
    /// Alise Wesp and Yuuki Wesp
    /// </c>
    /// <license type="MIT" path="root\\LICENSE"/>
    /// <version>
    /// 9.0
    /// </version>
    public class ArchManagedByte
    {
        protected MemoryStream nMStream;
        protected int Index = 0;
        protected ArchManagedByte(byte[] bt)
        {
            nMStream = new MemoryStream(bt);
        }
        protected ArchManagedByte()
        {
            nMStream = new MemoryStream();
        }
        /// <summary>
        /// Returns the number of elements between the current position and the limit
        /// </summary>
        /// <returns>
        /// The number of elements remaining in this buffer
        /// </returns>
        public long Remaining() => nMStream.Length - nMStream.Position;
        /// <summary>
        /// Invoke an create instance writer
        /// </summary>
        /// <returns>
        /// writer buffer
        /// </returns>
        public static IArchByteBoxWriter InvokeWriter() => new ArchMBWriter();
        /// <summary>
        /// Invoke an create instance reader
        /// </summary>
        /// <param name="buffer">
        /// Buffer
        /// </param>
        /// <returns>
        /// Reader buffer
        /// </returns>
        public static IArchByteBoxReader InvokeReader(byte[] buffer) => new ArchMBReader(buffer);
    }
}
