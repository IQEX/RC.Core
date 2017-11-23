using System.Collections.Generic;
using System.Linq;
#if !LITE
using System.Runtime.InteropServices;
#endif

namespace RC.Framework.Screens
{
    using System;
    using System.Drawing;

    public static class RCL
    {



        public static string Map(this string e, string t, Color c       ) => e.Replace(t, Wrap(t, c));
        public static string Map(this string e, string t, ConsoleColor c) => e.Map(t, c.getValue());

        public static string Map(this string e, string[]     t, Color        c) => t.Aggregate(e, (current, s) => current.Map(s, c));
        public static string Map(this string e, string[]     t, ConsoleColor c) => e.Map(t, c.getValue());
        public static string Map(this string e, List<string> t, ConsoleColor c) => e.Map(t.ToArray(), c.getValue());
        public static string Map(this string e, List<string> t, Color        c) => e.Map(t.ToArray(), c);


        public static string Map(this string e, List<object> t, Color        c) => e.Map(t.ToArray(), c);
        public static string Map(this string e, List<object> t, ConsoleColor c) => e.Map(t.ToArray(), c);
        public static string Map(this string e, object[]     t, Color        c) => t.Aggregate(e, (current, s) => current.Map(s.ToString(), c));
        public static string Map(this string e, object[]     t, ConsoleColor c) => t.Aggregate(e, (current, s) => current.Map(s.ToString(), c));
        public static string Map(this string e, object       t, Color        c) => e.Replace(t.ToString(), Wrap(t, c));
        public static string Map(this string e, object       t, ConsoleColor c) => e.Map(t, c.getValue());



        public static string Wrap(string text, ConsoleColor color) => $"{color.getValue()}{text}{ConsoleColor.White.getValue()}";
        public static string Wrap(object text, Color foreground) => Wrap(text, foreground, Color.Empty);
        public static string Wrap(object text, Color foreground, Color background) => $"{foreground.getValue(background)}{text}{ConsoleColor.White.getValue().getValue(Color.Empty)}";


#if !LITE

        public const string ESC = "\x1b";
        public const string CSI = "\x1b[";

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool SetConsoleMode(IntPtr hConsoleHandle, int mode);
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool GetConsoleMode(IntPtr handle, out int mode);
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr GetStdHandle(int handle);

        public static void EnablingVirtualTerminalProcessing()
        {
            if(!OSDetector.IsAnniversaryUpdate) return;
            if (isEnabledVirtualTerminalProc) return;

            var handle = GetStdHandle(-11);
            int mode;
            GetConsoleMode(handle, out mode);
            SetConsoleMode(handle, mode | 0x4);

            isEnabledVirtualTerminalProc = true;
        }
#endif
        // for < Windows 10 Anniversary Update
        internal static bool isEnabledVirtualTerminalProc = false;

        internal static bool ThrowCustomColor = true;



        public static void SetThrowCustomColor(bool value) => ThrowCustomColor = value;

        public static string getValue(this Color c, Color back)
        {
            if (!Screen.isUseRCL)
                return "";
#if LITE
            //! HoloVector/DoF.Issues/#5
            //! Add RCL support for Unity RichText
            if (c == Color.White)
                return "</color>";
            return $"<color=#{c.R:X2}{c.G:X2}{c.B:X2}>";
#else
            if (ThrowCustomColor)
            if (!c.IsNamedColor)
                throw new CustomColorException("Custom color is not allowed!");

            if (isEnabledVirtualTerminalProc)
            {
                if (c == Color.White)
                    return "\x1b[39m";
                return $"\x1b[38;2;{c.R};{c.G};{c.B}m";
            }
            return $"&{c.Name};{back.Name};";
#endif
        }

        public static Color getValue(this ConsoleColor c)
        {
            switch (c)
            {
                case ConsoleColor.Black:
                    return Color.Black;
                case ConsoleColor.DarkBlue:
                    return Color.DarkBlue;
                case ConsoleColor.DarkGreen:
                    return Color.DarkGreen;
                case ConsoleColor.DarkCyan:
                    return Color.DarkCyan;
                case ConsoleColor.DarkRed:
                    return Color.DarkRed;
                case ConsoleColor.DarkMagenta:
                    return Color.DarkMagenta;
                case ConsoleColor.DarkYellow:
                    return Color.DarkGoldenrod;
                case ConsoleColor.Gray:
                    return Color.Gray;
                case ConsoleColor.DarkGray:
                    return Color.DarkGray;
                case ConsoleColor.Blue:
                    return Color.Blue;
                case ConsoleColor.Green:
                    return Color.Green;
                case ConsoleColor.Cyan:
                    return Color.Cyan;
                case ConsoleColor.Red:
                    return Color.Red;
                case ConsoleColor.Magenta:
                    return Color.Magenta;
                case ConsoleColor.Yellow:
                    return Color.Yellow;
                case ConsoleColor.White:
                    return Color.White;
                default:
                    throw new ArgumentOutOfRangeException(nameof(c), c, null);
            }
        }
    }
}