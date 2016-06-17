// =====================================//==============================================================//
// License="root\\LICENSE"              //   Copyright © Of Fire Twins Wesp 17.06.16  <ls-micro@ya.ru>  //
// LicenseType="MIT"                    //                        Yuuki Wesp                            //
// =====================================//==============================================================//

namespace RC.Framework.Extension
{
    using System;

    public static class Ater
    {
        public static bool isInt32(this string s)
        {
            var i = 0;
            return int.TryParse(s, out i);
        }
        public static bool isInt64(this string s)
        {
            var i = 0L;
            return long.TryParse(s, out i);
        }
        public static bool isInt16(this string s)
        {
            var i = (short)0;
            return short.TryParse(s, out i);
        }
        public static bool isByte(this string s)
        {
            var i = (byte)0;
            return byte.TryParse(s, out i);
        }
        public static bool isSingle(this string s)
        {
            var i = (Single)0;
            return Single.TryParse(s, out i);
        }

        public static U At<U>(this string s)
        {
            switch (typeof(U).Name.ToLower())
            {
                case "int32":
                case "int":
                    if (s.isInt32())
                        return (U)(object)int.Parse(s);
                    return default(U);
                case "int64":
                case "long":
                    if (s.isInt64())
                        return (U)(object)long.Parse(s);
                    return default(U);
                case "int16":
                case "short":
                    if (s.isInt16())
                        return (U)(object)short.Parse(s);
                    return default(U);
                case "byte":
                    if (s.isByte())
                        return (U)(object)byte.Parse(s);
                    return default(U);
                case "float":
                case "single":
                    if (s.isSingle())
                        return (U)(object)byte.Parse(s);
                    return default(U);
                default:
                    throw new NotSupportedException();
            }
        }
    }
}