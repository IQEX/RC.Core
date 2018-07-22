// =====================================//==============================================================//
// License="root\\LICENSE"              //   Copyright © Of Fire Twins Wesp 2015  <ls-micro@ya.ru>      //
// LicenseType="MIT"                    //                  Alise Wesp & Yuuki Wesp                     //
// =====================================//==============================================================//
#pragma warning disable CS1591
namespace RC.Framework.IO
{
    using System;
    using System.IO;
    /// <summary>
	/// Manipulate a pointer to a stream.
	/// </summary>
	public struct StreamPtr
    {
        private readonly Stream _stream;
        private readonly long _offset;
        public StreamPtr(Stream s) : this(s, s.Position) { }
        public StreamPtr(Stream s, long pos)
        {
            if (s == null) throw new ArgumentNullException(nameof(s));
            _stream = s;
            _offset = pos;
        }

        public static StreamPtr operator +(StreamPtr sp, long plus) { return new StreamPtr(sp._stream, sp._offset + plus); }
        public static StreamPtr operator -(StreamPtr sp, long plus) { return new StreamPtr(sp._stream, sp._offset - plus); }

        public static long operator -(StreamPtr sp, StreamPtr sp2)
        {
            if (sp._stream != sp2._stream)
                throw new ArgumentException();
            return sp._offset - sp2._offset;
        }

        public static explicit operator Stream(StreamPtr ptr)
        {
            ptr._stream.Position = ptr._offset;
            return ptr._stream;
        }
    }
}
