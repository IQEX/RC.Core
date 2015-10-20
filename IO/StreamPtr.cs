// =====================================//==============================================================//
// License="root\\LICENSE"              //   Copyright © Of Fire Twins Wesp 2015  <ls-micro@ya.ru>      //
// LicenseType="MIT"                    //                  Alise Wesp & Yuuki Wesp                     //
// =====================================//==============================================================//
using System;
using System.IO;

namespace Rc.Framework.IO
{
    /// <summary>
	/// Manipulate a pointer to a stream.
	/// </summary>
	public struct StreamPtr
    {
        Stream stream;
        long offset;

        public StreamPtr(Stream s)
            : this(s, s.Position)
        {
        }
        public StreamPtr(Stream s, long pos)
        {
            if (s == null)
                throw new ArgumentNullException("stream");
            stream = s;
            offset = pos;
        }

        public static StreamPtr operator +(StreamPtr sp, long plus) { return new StreamPtr(sp.stream, sp.offset + plus); }
        public static StreamPtr operator -(StreamPtr sp, long plus) { return new StreamPtr(sp.stream, sp.offset - plus); }

        public static long operator -(StreamPtr sp, StreamPtr sp2)
        {
            if (sp.stream != sp2.stream)
                throw new ArgumentException();
            return sp.offset - sp2.offset;
        }

        public static explicit operator Stream(StreamPtr ptr)
        {
            ptr.stream.Position = ptr.offset;
            return ptr.stream;
        }
    }
}
