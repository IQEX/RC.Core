namespace RC.Framework
{
    public static class AutoTools
    {
        public static short ToInt16(this string a) => short.Parse(a);
        public static int ToInt32(this string a) => int.Parse(a);
        public static long ToInt64(this string a) => long.Parse(a);
        public static float ToFloat(this string a) => float.Parse(a);


        public static float ToFloat(this bool a) => a ? 1f : 0f;
        public static int ToInt32(this bool a) => a ? 1 : 0;
    }
}