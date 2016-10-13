#pragma warning disable CS1591 

namespace RC.Framework
{
    using Collections.Generic;
    using System;
    using System.IO;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using System.Linq;
    using System.Text;

    public static class RCL
    {
        public static string Wrap(string text, ConsoleColor color)
            => $"{color.getValue()}{text}{ConsoleColor.White.getValue()}";

        public static string getValue(this ConsoleColor c)
        {
            switch (c)
            {
                case ConsoleColor.Black:
                    return Terminal.Black;
                case ConsoleColor.DarkBlue:
                    return Terminal.DarkBlue;
                case ConsoleColor.DarkGreen:
                    return Terminal.DarkGreen;
                case ConsoleColor.DarkCyan:
                    return Terminal.DarkCyan;
                case ConsoleColor.DarkRed:
                    return Terminal.DarkRed;
                case ConsoleColor.DarkMagenta:
                    return Terminal.DarkMagenta;
                case ConsoleColor.DarkYellow:
                    return Terminal.DarkYellow;
                case ConsoleColor.Gray:
                    return Terminal.Gray;
                case ConsoleColor.DarkGray:
                    return Terminal.DarkGray;
                case ConsoleColor.Blue:
                    return Terminal.Blue;
                case ConsoleColor.Green:
                    return Terminal.Green;
                case ConsoleColor.Cyan:
                    return Terminal.Cyan;
                case ConsoleColor.Red:
                    return Terminal.Red;
                case ConsoleColor.Magenta:
                    return Terminal.Magenta;
                case ConsoleColor.Yellow:
                    return Terminal.Yellow;
                case ConsoleColor.White:
                    return Terminal.White;
                default:
                    throw new ArgumentOutOfRangeException(nameof(c), c, null);
            }
        }
    }

    /// <summary>
    /// Wrap the management console terminal
    /// </summary>
    public static class Terminal
    {
        public const string Key = "§";
        public static string Cost(char c) => $"§{c}";
        public static string Cost(this string c) => $"§{c}";

        private static TextWriter Out => Console.Out;
        private static TextReader In => Console.In;

        static Terminal()
        {
            try
            {
                Console.OutputEncoding = Encoding.UTF8;
                Console.InputEncoding = Encoding.UTF8;
            }
            catch
            {
            }
            listOfRCL = new RList<string>
            {
                "§0", // Black
                "§1", // DarkBlue
                "§2", // DarkGreen
                "§3", // DarkCyan
                "§4", // DarkRed
                "§5", // DarkMagenta
                "§6", // DarkYellow
                "§7", // DarkGray
                "§8", // Gray
                "§9", // Blue
                "§a", // Green
                "§b", // Cyan
                "§c", // Red
                "§d", // Magenta
                "§e", // Yellow
                "§f" // White
            };
        }

        public const string Black = "§0";
        public const string DarkBlue = "§1";
        public const string DarkGreen = "§2";
        public const string DarkCyan = "§3";
        public const string DarkRed = "§4";
        public const string DarkMagenta = "§5";
        public const string DarkYellow = "§6";
        public const string DarkGray = "§7";
        public const string Gray = "§8";
        public const string Blue = "§9";
        public const string Green = "§a";
        public const string Cyan = "§b";
        public const string Red = "§c";
        public const string Magenta = "§d";
        public const string Yellow = "§e";
        public const string White = "§f";

        public static readonly RList<string> listOfRCL;

        private static readonly string defHeader = "§cEngine§c";
        private static string header = "";
        public static bool isUseRCL = true;
        public static bool isUseColor = true;

        /// <summary>
        /// Writes a new line, with the support of rcl, without symbol of the end-line
        /// </summary>
        /// <param name="s">String Rcl</param>
        public static void Write(string s, bool isUseHeader = false)
        {
            if (isUseHeader)
            {
                if (header == "")
                {
                    Out.Write("<");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Out.Write(defHeader.SReplaceRcl());
                    Console.ForegroundColor = ConsoleColor.White;
                    Out.Write(">: ");
                }
                if (header != "" && isUseRCL)
                {
                    Out.Write("<");
                    ParseAndWrite(header);
                    Out.Write(">: ");
                }
            }
            if (isUseRCL)
                ParseAndWrite(s);
            else
                Out.Write(s);
        }

        /// <summary>
        /// Writes a new line, with the support of rcl
        /// </summary>
        /// <param name="s">String Rcl</param>
        public static void WriteLine(string s, bool isUseHeader = false)
        {
            if (isUseHeader)
            {
                if (header == "")
                {
                    Out.Write("<");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Out.Write(defHeader.SReplaceRcl());
                    Console.ForegroundColor = ConsoleColor.White;
                    Out.Write(">: ");
                }
                if (header != "" && isUseRCL)
                {
                    Out.Write($"<");
                    ParseAndWrite(header);
                    Out.Write($">: ");
                }
            }
            if (isUseRCL)
                ParseAndWrite($"{s}{Environment.NewLine}");
            else
                Out.Write($"{s}{Environment.NewLine}");
        }

        /// <summary>
        /// Writes a new line, with the support of rcl
        /// and Trase Line or Member of called
        /// </summary>
        /// <param name="s">string text</param>
        /// <param name="isTrace">is Print member or line to terminal?</param>
        /// <param name="member">autogenerated</param>
        /// <param name="line">autogenerated</param>
        public static void WriteLine(string s, bool isTrace, [CallerMemberName] string member = "?",
            [CallerLineNumber] int line = 0, bool isUseHeader = false)
        {
            if (!isTrace)
            {
                WriteLine(s);
                return;
            }
            if (isUseHeader)
            {
                if (header == "")
                {
                    Out.Write("<");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Out.Write(defHeader.SReplaceRcl());
                    Console.ForegroundColor = ConsoleColor.White;
                    Out.Write($">({member}:{line}): ");
                }
                if (header != "" && isUseRCL)
                {
                    Out.Write($"<");
                    ParseAndWrite(header);
                    Out.Write($">({member}:{line}): ");
                }
                else if (header != "" && !isUseRCL)
                {
                    Out.Write($"<");
                    Out.Write(header);
                    Out.Write($">({member}:{line}): ");
                }
            }
            if (isUseRCL)
                ParseAndWrite($"{s}{Environment.NewLine}");
            else
                Out.Write($"{s}{Environment.NewLine}");
        }

        /// <summary>
        /// Writes a new line, exception
        /// </summary>
        /// <param name="ex">Exception app</param>
        public static void WriteLine(Exception ex, bool isUseHeader = false)
        {
            try
            {
                ParseAndWrite($"{Environment.NewLine}");
                ParseAndWrite($"{getHTime()}[§2{ex.GetType().Name}§f] §4Message§f: §7{ex.Message}§f{Environment.NewLine}");
                ParseAndWrite($"{getHTime()}[§2{ex.GetType().Name}§f] §4HResult§f: §7{ex.HResult}§f{Environment.NewLine}");
                if (!string.IsNullOrEmpty(ex.HelpLink))
                    ParseAndWrite($"{getHTime()}[§2{ex.GetType().Name}§f] §4HelpLink§f: §7{ex.HelpLink}§f{Environment.NewLine}");
                foreach (KeyValuePair<object, object> k in ex.Data)
                {
                    ParseAndWrite($"{getHTime()}[§2{ex.GetType().Name}§f] §eIData§f::§{k.Key}§f: §7{k.Value}§f{Environment.NewLine}");
                }
                if (!string.IsNullOrEmpty(ex.StackTrace))
                    ParseAndWrite($"{getHTime()}[§2{ex.GetType().Name}§f] §4StackTrace§f: §7{ex.StackTrace}§f{Environment.NewLine}");
                if (!string.IsNullOrEmpty(ex.Source))
                    ParseAndWrite($"{getHTime()}[§2{ex.GetType().Name}§f] §4Source§f: §7{ex.Source}§f{Environment.NewLine}");
            }
            catch (Exception)
            {
                // Wat?!
            }
        }

        private static string getHTime()
            => $"[{RCL.Wrap(DateTime.Now.ToString("yyyy-MM-dd HH':'mm':'ss"), ConsoleColor.Gray)}]";

        private static void ParseAndWrite(string str)
        {
            lock (Out)
            {
                str = listOfRCL.Aggregate(str, (current, y) => current.Replace(y, $"+{y}\0"));
                char[] chars = str.ToCharArray();
                for (int i = 0; i != chars.Length; i++)
                {
                    if (i > chars.Length - 1)
                        break;
                    if (chars[i] == '+')
                    {
                        if (chars.Length > i + 1)
                        {
                            if (chars[i + 1] == '§')
                            {
                                if (chars.Length > i + 2)
                                {
                                    if (chars[i + 2] == '0')
                                    {
                                        Console.ForegroundColor = ConsoleColor.Black;
                                        i = i + 3;
                                    }
                                    else if (chars[i + 2] == '1')
                                    {
                                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                                        i = i + 3;
                                    }
                                    else if (chars[i + 2] == '2')
                                    {
                                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                                        i = i + 3;
                                    }
                                    else if (chars[i + 2] == '3')
                                    {
                                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                                        i = i + 3;
                                    }
                                    else if (chars[i + 2] == '4')
                                    {
                                        Console.ForegroundColor = ConsoleColor.DarkRed;
                                        i = i + 3;
                                    }
                                    else if (chars[i + 2] == '5')
                                    {
                                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                                        i = i + 3;
                                    }
                                    else if (chars[i + 2] == '6')
                                    {
                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                        i = i + 3;
                                    }
                                    else if (chars[i + 2] == '7')
                                    {
                                        Console.ForegroundColor = ConsoleColor.DarkGray;
                                        i = i + 3;
                                    }
                                    else if (chars[i + 2] == '8')
                                    {
                                        Console.ForegroundColor = ConsoleColor.Gray;
                                        i = i + 3;
                                    }
                                    else if (chars[i + 2] == '9')
                                    {
                                        Console.ForegroundColor = ConsoleColor.Blue;
                                        i = i + 3;
                                    }
                                    else if (chars[i + 2] == 'a')
                                    {
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        i = i + 3;
                                    }
                                    else if (chars[i + 2] == 'b')
                                    {
                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        i = i + 3;
                                    }
                                    else if (chars[i + 2] == 'c')
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        i = i + 3;
                                    }
                                    else if (chars[i + 2] == 'd')
                                    {
                                        Console.ForegroundColor = ConsoleColor.Magenta;
                                        i = i + 3;
                                    }
                                    else if (chars[i + 2] == 'e')
                                    {
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        i = i + 3;
                                    }
                                    else if (chars[i + 2] == 'f')
                                    {
                                        Console.ForegroundColor = ConsoleColor.White;
                                        i = i + 3;
                                    }
                                    else
                                        Out.Write(chars[i]);
                                }
                                else
                                    Out.Write(chars[i]);
                            }
                            else
                                Out.Write(chars[i]);
                        }
                        else
                            Out.Write(chars[i]);
                    }
                    else
                        Out.Write(chars[i]);
                }
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        private static string SReplaceRcl(this string s, string to = "") => listOfRCL.Aggregate(s, (current, y) => current.Replace(y, to));
        private static void VReplaceRcl(this string s, string to = "") => s = listOfRCL.Aggregate(s, (current, y) => current.Replace(y, to));
    }
}
