// =====================================//==============================================================//
//                                      //                                                              //
// Source="root\\Net\\AtchByte.cs"      //             Copyright © Of Fire Twins Wesp 2015              //
// Author= {"Callada", "Another"}       //                                                              //
// Project="Rc.Framework"               //                  Alise Wesp & Yuuki Wesp                     //
// Version File="4.0"                   //                                                              //
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
            if (data.Length > short.MaxValue - 1)
                throw new Exception("Length > short.MaxValue");
            ((IArchByteBoxWriter)this).wS((short)data.Length);
            nMStream.Write(data, 0, data.Length);
        }
        byte[] IArchByteBoxWriter.GetAll()
        {
            return nMStream.ToArray();
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
            Byte[] trsf = new byte[((IArchByteBoxReader)this).rS()];
            nMStream.Read(trsf, 0, trsf.Length);
            return Encoding.UTF8.GetString(trsf);
        }
        short IArchByteBoxReader.rS()
        {
            byte[] bt = new byte[2];
            nMStream.Read(bt, 0, 2);
            short surs = BitConverter.ToInt16(bt, 0);
            return surs;
        }
        byte[] IArchByteBoxReader.rG()
        {
            Byte[] trsf = new byte[((IArchByteBoxReader)this).rS()];
            nMStream.Read(trsf, 0, trsf.Length);
            return trsf;
        }
        IArchByteBoxReader IArchByteBoxReader.Clone()
        {
            return (IArchByteBoxReader)this.MemberwiseClone();
        }
    }
}
