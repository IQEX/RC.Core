namespace RC.Framework.Net.Arch
{
    using System;
    using System.Text;
    using RMath;
    /// <summary>
    /// wrap class reader in "box"
    /// </summary>
    /// <c>
    /// Of Fire Twins Wesp 2014-2016
    /// Alise Wesp and Yuuki Wesp
    /// </c>
    /// <license type="MIT" path="root\\LICENSE"/>
    /// <version>
    /// 9.0
    /// </version>
    public class ArchMBReader : ArchManagedByte, IArchByteBoxReader
    {
        internal ArchMBReader(byte[] bt) : base(bt)
        { }

        /// <summary>
        /// Reading <see cref="string"/>
        /// </summary>
        /// <returns><see cref="string"/></returns>
        string IArchByteBoxReader.rString()
        {
            byte[] @Byte = new byte[((IArchByteBoxReader)this).rShort()];
            nMStream.Read(@Byte, 0, @Byte.Length);
            return Encoding.UTF8.GetString(@Byte);
        }
        /// <summary>
        /// Reading <see cref="short"/>
        /// </summary>
        /// <returns><see cref="short"/></returns>
        short IArchByteBoxReader.rShort()
        {
            byte[] @Byte = new byte[sizeof(short)];
            nMStream.Read(@Byte, 0, sizeof(short));
            return BitConverter.ToInt16(@Byte, 0);
        }
        /// <summary>
        /// Reading <see cref="System.Array"/> of <see cref="byte"/>
        /// </summary>
        /// <returns><see cref="System.Array"/> of <see cref="byte"/></returns>
        byte[] IArchByteBoxReader.rByte()
        {
            Byte[] @Byte = new byte[((IArchByteBoxReader)this).rShort()];
            nMStream.Read(@Byte, 0, @Byte.Length);
            return @Byte;
        }

        /// <summary>
        /// Reading <see cref="float"/>
        /// </summary>
        /// <returns><see cref="float"/></returns>
        float IArchByteBoxReader.rFloat()
        {
            byte[] @Byte = new byte[sizeof(float)];
            nMStream.Read(@Byte, 0, sizeof(float));
            return BitConverter.ToSingle(@Byte, 0);
        }

        /// <summary>
        /// Reading <see cref="int"/>
        /// </summary>
        /// <returns><see cref="int"/></returns>
        int IArchByteBoxReader.rInt()
        {
            byte[] @Byte = new byte[sizeof(int)];
            nMStream.Read(@Byte, 0, sizeof(int));
            return BitConverter.ToInt32(@Byte, 0);
        }

        /// <summary>
        /// Reading <see cref="long"/>
        /// </summary>
        /// <returns><see cref="long"/></returns>
        long IArchByteBoxReader.rLong()
        {
            byte[] @Byte = new byte[sizeof(long)];
            nMStream.Read(@Byte, 0, sizeof(long));
            return BitConverter.ToInt64(@Byte, 0);
        }

        /// <summary>
        /// Reading <see cref="System.Guid"/>
        /// </summary>
        /// <returns><see cref="System.Guid"/></returns>
        Guid IArchByteBoxReader.rGUID()
        {
            byte[] @Byte = new byte[Guid.Empty.ToByteArray().Length];
            nMStream.Read(@Byte, 0, Guid.Empty.ToByteArray().Length);
            return new Guid(@Byte);
        }

        /// <summary>
        /// It creates a not complete copy of the current object
        /// </summary>
        /// <returns>
        /// not complete copy of the current object
        /// </returns>
        IArchByteBoxReader IArchByteBoxReader.Clone()
        {
            ArchMBReader reader = (ArchMBReader)InvokeReader(nMStream.ToArray());
            reader.Index = Index;
            reader.nMStream.Position = nMStream.Position;
            return reader;
        }

        /// <summary>
        /// Reading <see cref="System.DateTime.Ticks"/>
        /// </summary>
        /// <returns><see cref="System.DateTime"/></returns>
        DateTime IArchByteBoxReader.rDateTime()
        {
            byte[] @Byte = new byte[sizeof(long)];
            nMStream.Read(@Byte, 0, sizeof(long));
            return new DateTime(BitConverter.ToInt64(@Byte, 0));
        }

        /// <summary>
        /// Reading <see cref="ulong"/>
        /// </summary>
        /// <returns><see cref="ulong"/></returns>
        ulong IArchByteBoxReader.rULong()
        {
            byte[] @Byte = new byte[sizeof(ulong)];
            nMStream.Read(@Byte, 0, sizeof(ulong));
            return BitConverter.ToUInt64(@Byte, 0);
        }

        /// <summary>
        /// Reading <see cref="bool"/>
        /// </summary>
        /// <returns><see cref="bool"/></returns>
        bool IArchByteBoxReader.rBool()
        {
            byte[] @Byte = new byte[sizeof(bool)];
            nMStream.Read(@Byte, 0, sizeof(bool));
            return BitConverter.ToBoolean(@Byte, 0);
        }

        /// <summary>
        /// Reading <see cref="ushort"/>
        /// </summary>
        /// <returns><see cref="ushort"/></returns>
        ushort IArchByteBoxReader.rUShort()
        {
            byte[] @Byte = new byte[sizeof(ushort)];
            nMStream.Read(@Byte, 0, sizeof(ushort));
            return BitConverter.ToUInt16(@Byte, 0);
        }

        /// <summary>
        /// Reading <see cref="uint"/>
        /// </summary>
        /// <returns>
        /// <see cref="uint"/>
        /// </returns>
        uint IArchByteBoxReader.rUInt()
        {
            byte[] @Byte = new byte[sizeof(uint)];
            nMStream.Read(@Byte, 0, sizeof(uint));
            return BitConverter.ToUInt32(@Byte, 0);
        }

        /// <summary>
        /// Reading <see cref="RC.Framework.RMath.IntRange"/>
        /// </summary>
        /// <returns><see cref="RC.Framework.RMath.IntRange"/></returns>
        IntRange IArchByteBoxReader.rIRange()
        {
            IntRange ir = new IntRange();
            byte[] @Byte = new byte[sizeof(int)];
            nMStream.Read(@Byte, 0, sizeof(int));
            ir.Min = BitConverter.ToInt32(@Byte, 0);
            nMStream.Read(@Byte, 0, sizeof(int));
            ir.Max = BitConverter.ToInt32(@Byte, 0);
            return ir;
        }

        /// <summary>
        /// Reading <see cref="RC.Framework.RMath.Range"/>
        /// </summary>
        /// <returns><see cref="RC.Framework.RMath.Range"/></returns>
        Range IArchByteBoxReader.rFRange()
        {
            Range ir = new Range();
            byte[] @Byte = new byte[sizeof(float)];
            nMStream.Read(@Byte, 0, sizeof(float));
            ir.Min = BitConverter.ToSingle(@Byte, 0);
            nMStream.Read(@Byte, 0, sizeof(float));
            ir.Max = BitConverter.ToSingle(@Byte, 0);
            return ir;
        }

        /// <summary>
        /// Reading remaining byte array
        /// </summary>
        /// <returns>
        /// remaining byte array
        /// </returns>
        byte[] IArchByteBoxReader.getRemainingBytes()
        {
            long rem = nMStream.Length - nMStream.Position;
            byte[] @Byte = new byte[rem];
            nMStream.Read(@Byte, 0, @Byte.Length);
            return @Byte;
        }
    }
}