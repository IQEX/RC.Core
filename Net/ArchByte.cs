// =====================================//==============================================================//
//                                      //                                                              //
// Source="root\\Net\\AtchByte.cs"      //             Copyright © Of Fire Twins Wesp 2015              //
// Author= {"Callada", "Another"}       //                                                              //
// Project="Rc.Framework"               //                  Alise Wesp & Yuuki Wesp                     //
// Version File="4.0"                   //                                                              //
// License="root\\LICENSE"              //                                                              //
// LicenseType="MIT"                    //                                                              //
// =====================================//==============================================================//
using System;
using System.IO;
using System.Text;

namespace Rc.Framework.Net
{
    public class ArchByteBox
    {
        protected MemoryStream nMStream;
        protected int Index = 0;
        protected ArchByteBox(Byte[] bt)
        {
            nMStream = new MemoryStream(bt);
        }
        protected ArchByteBox()
        {
            nMStream = new MemoryStream();
        }
        public static IArchByteBoxWriter InvokeWriter()
        {
            return new ArchByteBoxWriter();
        }
        public static IArchByteBoxReader InvokeReader(Byte[] bt)
        {
            return new ArchByteBoxReader(bt);
        }
    }
    public class ArchByteBoxWriter : ArchByteBox, IArchByteBoxWriter
    {
        internal ArchByteBoxWriter() : base()
        { }
        void IArchByteBoxWriter.wQ(string str)
        {
            if (str.Length > short.MaxValue - 1)
                throw new Exception("Length > short.MaxValue");
            Byte[] trsf = Encoding.UTF8.GetBytes(str);
            ((IArchByteBoxWriter)this).wS((short)trsf.Length);
            nMStream.Write(trsf, 0, trsf.Length);
        }
        void IArchByteBoxWriter.wS(short sht)
        {
            Byte[] trsf = BitConverter.GetBytes(sht);
            nMStream.Write(trsf, 0, trsf.Length);
        }
        void IArchByteBoxWriter.wG(byte[] data)
        {
            if (data.Length > short.MaxValue / 2 - 1)
                throw new Exception("Length > short.MaxValue / 2");
            ((IArchByteBoxWriter)this).wS((short)data.Length);
            nMStream.Write(data, 0, data.Length);
        }
        byte[] IArchByteBoxWriter.GetAll()
        {
            return nMStream.ToArray();
        }
        void IArchByteBoxWriter.wF(float flt)
        {
            Byte[] trsf = BitConverter.GetBytes(flt);
            nMStream.Write(trsf, 0, trsf.Length);
        }
        void IArchByteBoxWriter.wL(long lng)
        {
            Byte[] trsf = BitConverter.GetBytes(lng);
            nMStream.Write(trsf, 0, trsf.Length);
        }
        void IArchByteBoxWriter.wGUID(Guid g)
        {
            nMStream.Write(g.ToByteArray(), 0, g.ToByteArray().Length);
        }
        IArchByteBoxWriter IArchByteBoxWriter.Clone()
        {
            return (IArchByteBoxWriter)this.MemberwiseClone();
        }
    }
    public class ArchByteBoxReader : ArchByteBox, IArchByteBoxReader
    {
        internal ArchByteBoxReader(byte[] bt) : base(bt)
        { }
        string IArchByteBoxReader.rQ()
        {
            Byte[] @Byte = new byte[((IArchByteBoxReader)this).rS()];
            nMStream.Read(@Byte, 0, @Byte.Length);
            return Encoding.UTF8.GetString(@Byte);
        }
        short IArchByteBoxReader.rS()
        {
            byte[] @Byte = new byte[sizeof(short)];
            nMStream.Read(@Byte, 0, sizeof(short));
            return BitConverter.ToInt16(@Byte, 0);
        }
        byte[] IArchByteBoxReader.rG()
        {
            Byte[] @Byte = new byte[((IArchByteBoxReader)this).rS()];
            nMStream.Read(@Byte, 0, @Byte.Length);
            return @Byte;
        }
        float IArchByteBoxReader.rF()
        {
            byte[] bt = new byte[sizeof(float)];
            nMStream.Read(bt, 0, sizeof(float));
            return BitConverter.ToSingle(bt, 0);
        }
        int IArchByteBoxReader.rI()
        {
            byte[] bt = new byte[sizeof(int)];
            nMStream.Read(bt, 0, sizeof(int));
            int surs = BitConverter.ToInt32(bt, 0);
            return surs;
        }
        long IArchByteBoxReader.rL()
        {
            byte[] bt = new byte[sizeof(long)];
            nMStream.Read(bt, 0, sizeof(long));
            long surs = BitConverter.ToInt64(bt, 0);
            return surs;
        }
        Guid IArchByteBoxReader.rGUID()
        {
            byte[] @Byte = new byte[Guid.Empty.ToByteArray().Length];
            nMStream.Read(@Byte, 0, Guid.Empty.ToByteArray().Length);
            return new Guid(@Byte);
        }
        IArchByteBoxReader IArchByteBoxReader.Clone()
        {
            return (IArchByteBoxReader)this.MemberwiseClone();
        }
    }
}
