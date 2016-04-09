#pragma warning disable 1591
namespace RC.Framework.Net.Arch
{
    using System;
    using System.Text;
    using System.Threading.Tasks;
    public class AsyncArchMBReader : ArchManagedByte, IAsyncArchMBReader
    {
        internal AsyncArchMBReader(byte[] bt) : base(bt)
        { }

        /// <summary>
        /// Async Reading <see cref="string"/>
        /// </summary>
        /// <returns><see cref="string"/></returns>
        async Task<string> IAsyncArchMBReader.rString()
        {
            byte[] @Byte = new byte[await ((IAsyncArchMBReader)this).rShort()];
            int o = await nMStream.ReadAsync(@Byte, 0, @Byte.Length);
            return Encoding.UTF8.GetString(@Byte);
        }
        /// <summary>
        /// Async Reading <see cref="short"/>
        /// </summary>
        /// <returns><see cref="short"/></returns>
        async Task<short> IAsyncArchMBReader.rShort()
        {
            byte[] @Byte = new byte[sizeof(short)];
            int o = await nMStream.ReadAsync(@Byte, 0, sizeof(short));
            return BitConverter.ToInt16(@Byte, 0);
        }
        /// <summary>
        /// Async Reading <see cref="System.Array"/> of <see cref="byte"/>
        /// </summary>
        /// <returns><see cref="System.Array"/> of <see cref="byte"/></returns>
        async Task<byte[]> IAsyncArchMBReader.rByte()
        {
            Byte[] @Byte = new byte[await ((IAsyncArchMBReader)this).rShort()];
            int o = await nMStream.ReadAsync(@Byte, 0, @Byte.Length);
            return @Byte;
        }

        /// <summary>
        /// Async Reading <see cref="float"/>
        /// </summary>
        /// <returns><see cref="float"/></returns>
        async Task<float> IAsyncArchMBReader.rFloat()
        {
            byte[] @Byte = new byte[sizeof(float)];
            int o = await nMStream.ReadAsync(@Byte, 0, sizeof(float));
            return BitConverter.ToSingle(@Byte, 0);
        }

        /// <summary>
        /// Async Reading <see cref="int"/>
        /// </summary>
        /// <returns><see cref="int"/></returns>
        async Task<int> IAsyncArchMBReader.rInt()
        {
            byte[] @Byte = new byte[sizeof(int)];
            int o = await nMStream.ReadAsync(@Byte, 0, sizeof(int));
            return BitConverter.ToInt32(@Byte, 0);
        }

        /// <summary>
        /// Async Reading <see cref="long"/>
        /// </summary>
        /// <returns><see cref="long"/></returns>
        async Task<long> IAsyncArchMBReader.rLong()
        {
            byte[] @Byte = new byte[sizeof(long)];
            int o = await nMStream.ReadAsync(@Byte, 0, sizeof(long));
            return BitConverter.ToInt64(@Byte, 0);
        }

        /// <summary>
        /// Async Reading <see cref="System.Guid"/>
        /// </summary>
        /// <returns><see cref="System.Guid"/></returns>
        async Task<Guid> IAsyncArchMBReader.rGUID()
        {
            byte[] @Byte = new byte[Guid.Empty.ToByteArray().Length];
            int o = await nMStream.ReadAsync(@Byte, 0, Guid.Empty.ToByteArray().Length);
            return new Guid(@Byte);
        }

        /// <summary>
        /// It creates a not complete copy of the current object
        /// </summary>
        /// <returns>
        /// not complete copy of the current object
        /// </returns>
        IAsyncArchMBReader IAsyncArchMBReader.Clone()
        {
            AsyncArchMBReader reader = (AsyncArchMBReader)InvokeReader(nMStream.ToArray());
            reader.Index = Index;
            reader.nMStream.Position = nMStream.Position;
            return reader;
        }

        /// <summary>
        /// Async Reading <see cref="ulong"/>
        /// </summary>
        /// <returns><see cref="ulong"/></returns>
        async Task<ulong> IAsyncArchMBReader.rULong()
        {
            byte[] @Byte = new byte[sizeof(ulong)];
            int o = await nMStream.ReadAsync(@Byte, 0, sizeof(ulong));
            return BitConverter.ToUInt64(@Byte, 0);
        }

        /// <summary>
        /// Async Reading <see cref="bool"/>
        /// </summary>
        /// <returns><see cref="bool"/></returns>
        async Task<bool> IAsyncArchMBReader.rBool()
        {
            byte[] @Byte = new byte[sizeof(bool)];
            int o = await nMStream.ReadAsync(@Byte, 0, sizeof(bool));
            return BitConverter.ToBoolean(@Byte, 0);
        }

        /// <summary>
        /// Async Reading <see cref="ushort"/>
        /// </summary>
        /// <returns><see cref="ushort"/></returns>
        async Task<ushort> IAsyncArchMBReader.rUShort()
        {
            byte[] @Byte = new byte[sizeof(ushort)];
            int o = await nMStream.ReadAsync(@Byte, 0, sizeof(ushort));
            return BitConverter.ToUInt16(@Byte, 0);
        }

        /// <summary>
        /// Async Reading <see cref="uint"/>
        /// </summary>
        /// <returns>
        /// <see cref="uint"/>
        /// </returns>
        async Task<uint> IAsyncArchMBReader.rUInt()
        {
            byte[] @Byte = new byte[sizeof(uint)];
            int o = await nMStream.ReadAsync(@Byte, 0, sizeof(uint));
            return BitConverter.ToUInt32(@Byte, 0);
        }

        /// <summary>
        /// Reading remaining byte array
        /// </summary>
        /// <returns>
        /// remaining byte array
        /// </returns>
        async Task<byte[]> IAsyncArchMBReader.getRemainingBytes()
        {
            long rem = nMStream.Length - nMStream.Position;
            byte[] @Byte = new byte[rem];
            int o = await nMStream.ReadAsync(@Byte, 0, @Byte.Length);
            return @Byte;
        }
    }
}