namespace RC.Framework.Screens
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Drawing;
#if !LITE
    using System.Runtime.InteropServices;
    using Microsoft.Win32;
#endif
    public static class RCL
    {
        public delegate void OutputRCL(string str, Exception ex);

        public static event OutputRCL Trace;


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

        /// <summary>
        /// Escape symbol
        /// </summary>
        public const string ESC = "\x1b";
        /// <summary>
        /// CSI Symbols
        /// </summary>
        public const string CSI = "\x1b[";
        public const string EscapeRegex = @"\e\[[0-9;]+m";

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool SetConsoleMode(IntPtr hConsoleHandle, int mode);
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool GetConsoleMode(IntPtr handle, out int mode);
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr GetStdHandle(int handle);

        [Flags]
        internal enum ConsoleModeInputFlags
        {
            ENABLE_PROCESSED_INPUT = 0x0001,
            ENABLE_LINE_INPUT = 0x0002,
            ENABLE_ECHO_INPUT = 0x0004,
            ENABLE_WINDOW_INPUT = 0x0008,
            ENABLE_MOUSE_INPUT = 0x0010,
            ENABLE_INSERT_MODE = 0x0020,
            ENABLE_QUICK_EDIT_MODE = 0x0040,
            ENABLE_EXTENDED_FLAGS = 0x0080,
            ENABLE_AUTO_POSITION = 0x0100,
            ENABLE_VIRTUAL_TERMINAL_PROCESSING = 0x0200
        }
        [Flags]
        internal enum ConsoleModeOutputFlags
        {
            ENABLE_PROCESSED_OUTPUT = 0x0001,
            ENABLE_WRAP_AT_EOL_OUTPUT = 0x0002,
            ENABLE_VIRTUAL_TERMINAL_PROCESSING = 0x0004
        }

        public enum ConsoleHandle : int
        {
            Input = -10,
            Output = -11
        }

        public enum RejectedResponse
        {
            Unknown,
            IsNotAnniversaryUpdate,
            HardDisabledVTP,
            RegistryDisabledVTP,
            WinAPIRejected,
            AlreadyEnabled,
            AlreadyEnabledFromRegistry,
            Success
        }

        public static RejectedResponse EnablingVirtualTerminalProcessing()
        {
            if (!OSDetector.IsAnniversaryUpdate)
            {
                OnOut("OS is not 'Windows 10 AnniversaryUpdate'.");
                OnOut("Failed Enabling VTP technology.");
                return RejectedResponse.IsNotAnniversaryUpdate;
            }
            if (isEnabledVirtualTerminalProc) return RejectedResponse.HardDisabledVTP;

            using (var tree = Registry.CurrentUser.OpenSubKey("Console"))
            {
                var valKey = tree?.GetValue("VirtualTerminalLevel")?.ToString();
                switch (valKey)
                {
                    case null:
                        OnOut("Registry Key 'VirtualTerminalLevel' not found.");
                        break;
                    case "1":
                        OnOut("Registry Key 'VirtualTerminalLevel' is enabled! [0x0000001] DWORD x32");
                        isEnabledVirtualTerminalProc = true;
                        return RejectedResponse.AlreadyEnabledFromRegistry;
                    case "0":
                        OnOut("Registry Key 'VirtualTerminalLevel' is disabled! [0x0000000] DWORD x32");
                        return RejectedResponse.RegistryDisabledVTP;
                    default:
                        OnOut($"Registry Key 'VirtualTerminalLevel' has been unknown value [0x000000{valKey}] DWORD x32");
                        return RejectedResponse.Unknown;
                }
            }


            var handle = GetStdHandle((int)ConsoleHandle.Output);
            OnOut($"Getting handle 'Output' -> [0x{handle}] HANDLE x64");
            GetConsoleMode(handle, out var mode);
            OnOut($"Getting handle mode -> [{(ConsoleModeOutputFlags)mode}] 'Output' 0xB");
            if (!((ConsoleModeOutputFlags) mode).HasFlag(ConsoleModeOutputFlags.ENABLE_VIRTUAL_TERMINAL_PROCESSING))
            {
                SetConsoleMode(handle, mode | (int)ConsoleModeOutputFlags.ENABLE_VIRTUAL_TERMINAL_PROCESSING);
                OnOut($"Set [{(ConsoleModeOutputFlags.ENABLE_VIRTUAL_TERMINAL_PROCESSING)}] from console handle [0xB x64]");
                GetConsoleMode(handle, out mode);
                if (!((ConsoleModeOutputFlags) mode).HasFlag(ConsoleModeOutputFlags.ENABLE_VIRTUAL_TERMINAL_PROCESSING))
                {
                    OnOut($"Rejected [{(ConsoleModeOutputFlags.ENABLE_VIRTUAL_TERMINAL_PROCESSING)}] from console handle [0xB x64] -> [{(ConsoleModeOutputFlags)mode}]");
                    OnOut("Failed Enabling VTP technology.");
                    return RejectedResponse.WinAPIRejected;
                }
                OnOut($"Success set [{(ConsoleModeOutputFlags.ENABLE_VIRTUAL_TERMINAL_PROCESSING)}] from console handle [0xB x64] -> [{(ConsoleModeOutputFlags)mode}]");
                isEnabledVirtualTerminalProc = true;
                return RejectedResponse.Success;
            }
            OnOut($"Already set [{(ConsoleModeOutputFlags.ENABLE_VIRTUAL_TERMINAL_PROCESSING)}] from console handle [0xB x64] -> [{(ConsoleModeOutputFlags)mode}]");
            isEnabledVirtualTerminalProc = true;
            return RejectedResponse.AlreadyEnabled;
        }
#endif
        // for < Windows 10 Anniversary Update
        internal static bool isEnabledVirtualTerminalProc = false;
        private static bool ThrowCustomColor = true;

        public enum Type
        {
            Standard,
            VTP_Technology,
            Unity
        }

        public static void SetThrowCustomColor(bool value) => ThrowCustomColor = value;

        public static Type getType()
        {
#if LITE
            return Type.Unity;
#else
            return isEnabledVirtualTerminalProc ? Type.VTP_Technology : Type.Standard;

#endif
        }

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

        private static void OnOut(string str, Exception ex = null)
        {
            Trace?.Invoke(str, ex);
        }
    }
}