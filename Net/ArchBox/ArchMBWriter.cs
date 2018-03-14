namespace RC.Framework.Net.Arch
{
    using System;
    using System.Text;
    /// <summary>
    /// wrap calss writing in "box"
    /// </summary>
    /// <c>
    /// Of Fire Twins Wesp 2014-2016
    /// Alise Wesp and Yuuki Wesp
    /// </c>
    /// <license type="MIT" path="root\\LICENSE"/>
    /// <version>
    /// 9.0
    /// </version>
    public class ArchMBWriter : ArchManagedByte, IArchByteBoxWriter
    {
        internal ArchMBWriter()
        { }
        void IArchByteBoxWriter.wSt(string str)
        {
            if (str.Length > short.MaxValue - 1)
                throw new Exception("Length > short.MaxValue");
            byte[] @Byte = Encoding.UTF8.GetBytes(str);
            ((IArchByteBoxWriter)this).wS((short)@Byte.Length);
            nMStream.Write(@Byte, offset: 0, count: @Byte.Length);
        }
        void IArchByteBoxWriter.wS(short sht)
        {
            byte[] @Byte = BitConverter.GetBytes(sht);
            nMStream.Write(@Byte, offset: 0, count: @Byte.Length);
        }
        void IArchByteBoxWriter.wB(byte[] data)
        {
            if (data.Length > short.MaxValue / 2 - 1)
                throw new Exception("Length > short.MaxValue / 2");
            ((IArchByteBoxWriter)this).wS((short)data.Length);
            nMStream.Write(data, offset: 0, count: data.Length);
        }
        void IArchByteBoxWriter.wNB(byte[] data)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));
            if (data.Length == 0) throw new ArgumentException("Argument is empty collection", nameof(data));
            nMStream.Write(data, offset: 0, count: data.Length);
        }
        byte[] IArchByteBoxWriter.toArray()
        {
            return nMStream.ToArray();
        }
        void IArchByteBoxWriter.wF(float flt)
        {
            byte[] @Byte = BitConverter.GetBytes(flt);
            nMStream.Write(@Byte, offset: 0, count: @Byte.Length);
        }
        void IArchByteBoxWriter.wL(long lng)
        {
            byte[] @Byte = BitConverter.GetBytes(lng);
            nMStream.Write(@Byte, offset: 0, count: @Byte.Length);
        }
        void IArchByteBoxWriter.wGUID(Guid g)
        {
            nMStream.Write(g.ToByteArray(), offset: 0, count: g.ToByteArray().Length);
        }
        IArchByteBoxWriter IArchByteBoxWriter.Clone()
        {
            return (IArchByteBoxWriter)this.MemberwiseClone();
        }
        void IArchByteBoxWriter.wDateTime(DateTime DT, bool isBinary)
        {
            byte[] @Byte = null;
            if (isBinary)
                @Byte = BitConverter.GetBytes(DT.ToBinary());
            else
                @Byte = BitConverter.GetBytes(DT.Ticks);
            nMStream.Write(@Byte, offset: 0, count: @Byte.Length);
        }
        void IArchByteBoxWriter.wI(int it)
        {
            byte[] @Byte = BitConverter.GetBytes(it);
            nMStream.Write(@Byte, offset: 0, count: @Byte.Length);
        }
        void IArchByteBoxWriter.wUl(ulong ulng)
        {
            byte[] @Byte = BitConverter.GetBytes(ulng);
            nMStream.Write(@Byte, offset: 0, count: @Byte.Length);
        }
        void IArchByteBoxWriter.wUI(uint uit)
        {
            byte[] @Byte = BitConverter.GetBytes(uit);
            nMStream.Write(@Byte, offset: 0, count: @Byte.Length);
        }
        void IArchByteBoxWriter.wUS(ushort ushrt)
        {
            byte[] @Byte = BitConverter.GetBytes(ushrt);
            nMStream.Write(@Byte, offset: 0, count: @Byte.Length);
        }
        void IArchByteBoxWriter.wB(bool bo)
        {
            byte[] @Byte = BitConverter.GetBytes(bo);
            nMStream.Write(@Byte, offset: 0, count: @Byte.Length);
        }
    }
}