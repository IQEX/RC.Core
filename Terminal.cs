// =====================================//==============================================================//
// License="root\\LICENSE"              //   Copyright © Of Fire Twins Wesp 2015  <ls-micro@ya.ru>      //
// LicenseType="MIT"                    //                  Alise Wesp & Yuuki Wesp                     //
// =====================================//==============================================================//

using Rc.Framework.Collections.Generic;
using Rc.Framework.Native;
using Rc.Framework.Yaml.Serialization;
using System;
using System.IO;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Runtime.CompilerServices;
using Rc.Framework.Extension;
using System.Text;
using System.Threading;

//! Я уберу старое API в 10 версии фреймворка
namespace Rc.Framework
{
    /// <summary>
    /// Wrap the management console terminal
    /// </summary>
    public static partial class Terminal
    {
        //x string pNone = "(?([0-9]|[a-zA-Z]))[^\\§\\§]+(?=\\§([0-9]|[a-zA-Z]))";
        //x string pNone = "(?=§)";
        public const string pBlack      = "(?<=\\§([0]))[^\\§\\§]+(?=\\§([0-9]|[a-zA-Z]))";
        public const string pDarpBlue   = "(?<=\\§([1]))[^\\§\\§]+(?=\\§([0-9]|[a-zA-Z]))";
        public const string pDarkGreen  = "(?<=\\§([2]))[^\\§\\§]+(?=\\§([0-9]|[a-zA-Z]))";
        public const string pDarkCyan   = "(?<=\\§([3]))[^\\§\\§]+(?=\\§([0-9]|[a-zA-Z]))";
        public const string pDarkRed    = "(?<=\\§([4]))[^\\§\\§]+(?=\\§([0-9]|[a-zA-Z]))";
        public const string pDarkMagenta= "(?<=\\§([5]))[^\\§\\§]+(?=\\§([0-9]|[a-zA-Z]))";
        public const string pDarkYellow = "(?<=\\§([6]))[^\\§\\§]+(?=\\§([0-9]|[a-zA-Z]))";
        public const string pDarkGray   = "(?<=\\§([7]))[^\\§\\§]+(?=\\§([0-9]|[a-zA-Z]))";
        public const string pGray       = "(?<=\\§([8]))[^\\§\\§]+(?=\\§([0-9]|[a-zA-Z]))";
        public const string pBlue       = "(?<=\\§([9]))[^\\§\\§]+(?=\\§([0-9]|[a-zA-Z]))";
        public const string pGreen      = "(?<=\\§([a]))[^\\§\\§]+(?=\\§([0-9]|[a-zA-Z]))";
        public const string pCyan       = "(?<=\\§([b]))[^\\§\\§]+(?=\\§([0-9]|[a-zA-Z]))";
        public const string pRed        = "(?<=\\§([c]))[^\\§\\§]+(?=\\§([0-9]|[a-zA-Z]))";
        public const string pMagenta    = "(?<=\\§([d]))[^\\§\\§]+(?=\\§([0-9]|[a-zA-Z]))";
        public const string pYellow     = "(?<=\\§([e]))[^\\§\\§]+(?=\\§([0-9]|[a-zA-Z]))";
        public const string pWhite      = "(?<=\\§([f]))[^\\§\\§]+(?=\\§([0-9]|[a-zA-Z]))";

        public const string Key = "§";
        public static string Cost(char c) { return $"§{c}"; }
        public static string Cost(this string c) { return $"§{c}"; }

        private static TextWriter _out
        {
            get
            {
                return Console.Out;
            }
        }
        private static TextReader _in
        {
            get
            {
                return Console.In;
            }
        }
        static Terminal()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            ConfigTerminal conf = new ConfigTerminal();
            conf.Load();

            header = conf.Header;
            isUseRCL = conf.isUseRCL;
            isUseColor = conf.isUseColor;
            if (conf.VersionAPI == VTerminalAPI.v4_5)
                isOldKeyParse = true;
            else
                isOldKeyParse = false;

            listOfRCL = new RList<string>();
            //&     Black           DarkBlue            DarkGreen
            listOfRCL.Add("§0"); listOfRCL.Add("§1"); listOfRCL.Add("§2");
            //&     DarkCyan        DarkRed             DarkMagenta
            listOfRCL.Add("§3"); listOfRCL.Add("§4"); listOfRCL.Add("§5");
            //&     DarkYellow      DarkGray            Gray
            listOfRCL.Add("§6"); listOfRCL.Add("§7"); listOfRCL.Add("§8");
            //&     Blue            Green               Cyan
            listOfRCL.Add("§9"); listOfRCL.Add("§a"); listOfRCL.Add("§b");
            //&     Red             Magenta             Yellow
            listOfRCL.Add("§c"); listOfRCL.Add("§d"); listOfRCL.Add("§e");
            //&     White
            listOfRCL.Add("§f");
        }

        public const string Black       = "§0";
        public const string DarkBlue    = "§1";
        public const string DarkGreen   = "§2";
        public const string DarkCyan    = "§3";
        public const string DarkRed     = "§4";
        public const string DarkMagenta = "§5";
        public const string DarkYellow  = "§6";
        public const string DarkGray    = "§7";
        public const string Gray        = "§8";
        public const string Blue        = "§9";
        public const string Green       = "§a";
        public const string Cyan        = "§b";
        public const string Red         = "§c";
        public const string Magenta     = "§d";
        public const string Yellow      = "§e";
        public const string White       = "§f";

        private static string defHeader = "§cEngine§c";
        private static string header = "";
        private static readonly RList<string> listOfRCL;
        private static bool isUseRCL;
        private static bool isUseColor;
        private static bool isOldKeyParse;
        public static void SetConfig(ConfigTerminal conf)
        {
            header = conf.Header;
            isUseRCL = conf.isUseRCL;
            isUseColor = conf.isUseColor;
            if (conf.VersionAPI == VTerminalAPI.v4_5)
                isOldKeyParse = true;
            else
                isOldKeyParse = false;
        }
        public static ConfigTerminal GetConfig()
        {
            ConfigTerminal conf = new ConfigTerminal();
            conf.Header = header;
            conf.isUseRCL = isUseRCL;
            conf.isUseColor = isUseColor;
            conf.VersionAPI = VTerminalAPI.v8_1;
            return conf;
        }
        /// <summary>
        /// Writes a new line, with the support of rcl, without symbol of the end-line
        /// </summary>
        /// <param name="s">String Rcl</param>
        public static void Write(string s, bool isUseHeader = true)
        {
            if (isOldKeyParse)
            {
                old_Write(s);
                return;
            }
            if (isUseHeader)
            {
                if (header == "")
                {
                    _out.Write("<");
                    Console.ForegroundColor = ConsoleColor.Red;
                    _out.Write(defHeader.sReplaceRCL());
                    Console.ForegroundColor = ConsoleColor.White;
                    _out.Write(">: ");
                }
                if (header != "" && isUseRCL)
                {
                    _out.Write($"<");
                    ParseAndWrite(header);
                    _out.Write($">: ");
                }
            }
            if (isUseRCL)
                ParseAndWrite(s);
            else
                _out.Write(s);
        }
        /// <summary>
        /// Writes a new line, with the support of rcl
        /// </summary>
        /// <param name="s">String Rcl</param>
        public static void WriteLine(string s, bool isUseHeader = true)
        {
            if (isOldKeyParse)
            {
                old_WriteLine(s);
                return;
            }
            if (isUseHeader)
            {
                if (header == "")
                {
                    _out.Write("<");
                    Console.ForegroundColor = ConsoleColor.Red;
                    _out.Write(defHeader.sReplaceRCL());
                    Console.ForegroundColor = ConsoleColor.White;
                    _out.Write(">: ");
                }
                if (header != "" && isUseRCL)
                {
                    _out.Write($"<");
                    ParseAndWrite(header);
                    _out.Write($">: ");
                }
            }
            if (isUseRCL)
                ParseAndWrite($"{s}{Environment.NewLine}");
            else
                _out.Write($"{s}{Environment.NewLine}");
        }
        /// <summary>
        /// Writes a new line, with the support of rcl
        /// and Trase Line or Member of called
        /// </summary>
        /// <param name="s">string text</param>
        /// <param name="isTrase">is Print member or line to terminal?</param>
        /// <param name="member">autogenerated</param>
        /// <param name="line">autogenerated</param>
        public static void WriteLine(string s, bool isTrase, [CallerMemberName] string member = "?", [CallerLineNumber] int line = 0, bool isUseHeader = true)
        {
            if (!isTrase)
            {
                WriteLine(s);
                return;
            }
            if (isOldKeyParse)
            {
                old_WriteLine($"[{member}:{line}]{s}");
                return;
            }
            if (isUseHeader)
            {
                if (header == "")
                {
                    _out.Write("<");
                    Console.ForegroundColor = ConsoleColor.Red;
                    _out.Write(defHeader.sReplaceRCL());
                    Console.ForegroundColor = ConsoleColor.White;
                    _out.Write($">({member}:{line}): ");
                }
                if (header != "" && isUseRCL)
                {
                    _out.Write($"<");
                    ParseAndWrite(header);
                    _out.Write($">({member}:{line}): ");
                }
                else if (header != "" && !isUseRCL)
                {
                    _out.Write($"<");
                    _out.Write(header);
                    _out.Write($">({member}:{line}): ");
                }
            }
            if (isUseRCL)
                ParseAndWrite($"{s}{Environment.NewLine}");
            else
                _out.Write($"{s}{Environment.NewLine}");
        }
        /// <summary>
        /// Writes a new line, exception
        /// </summary>
        /// <param name="ex">Exception app</param>
        /// <param name="member">autogenerated</param>
        /// <param name="line">autogenerated</param>
        /// <param name="file">autogenerated</param>
        public static void WriteLine(Exception ex, [CallerMemberName] string member = "?", [CallerLineNumber] int line = 0, [CallerFilePath] string file = "", bool isUseHeader = true)
        {
            if (isOldKeyParse)
            {
                old_WriteLine($"[{member}:{line}]{ex.ToString()}");
                return;
            }
            ParseAndWrite($"[§2{ex.GetType().Name}§f] §4CallerFilePath§f: §7{file}§f{Environment.NewLine}");
            ParseAndWrite($"[§2{ex.GetType().Name}§f] §4CallerMemberName§f: §7{member}§f{Environment.NewLine}");
            ParseAndWrite($"[§2{ex.GetType().Name}§f] §4CallerLineNumber§f: §7{line}§f{Environment.NewLine}");
            ParseAndWrite($"[§2{ex.GetType().Name}§f] §4Message§f: §7{ex.Message}§f{Environment.NewLine}");
            ParseAndWrite($"[§2{ex.GetType().Name}§f] §4HResult§f: §7{ex.HResult}§f{Environment.NewLine}");
            if(ex.HelpLink != null && ex.HelpLink != "")
                ParseAndWrite($"[§2{ex.GetType().Name}§f] §4HelpLink§f: §7{ex.HelpLink}§f{Environment.NewLine}");
            foreach (KeyValuePair<object, object> k in ex.Data)
            {
                ParseAndWrite($"[§2{ex.GetType().Name}§f] §eIData§f::§{k.Key}§f: §7{k.Value}§f{Environment.NewLine}");
            }
            if (ex.StackTrace != null && ex.StackTrace != "")
                ParseAndWrite($"[§2{ex.GetType().Name}§f] §4StackTrace§f: §7{ex.StackTrace}§f{Environment.NewLine}");
            if (ex.Source != null && ex.Source != "")
                ParseAndWrite($"[§2{ex.GetType().Name}§f] §4Source§f: §7{ex.Source}§f{Environment.NewLine}");
        }
        private static void ParseAndWrite(string str)
        {
            Monitor.Wait()
            lock (_out)
            {
                //& Старая реализация
                foreach (string y in listOfRCL)
                {
                    str = str.Replace(y, $"+{y}\0");
                }
                char[] chars = str.ToCharArray();
                //# Такой жесткий костыль, но мля, так охеренно работает
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
                                        _out.Write(chars[i]);
                                }
                                else
                                    _out.Write(chars[i]);
                            }
                            else
                                _out.Write(chars[i]);
                        }
                        else
                            _out.Write(chars[i]);
                    }
                    else
                        _out.Write(chars[i]);
                }
                Console.ForegroundColor = ConsoleColor.White;
            }
            //& новая
            string textToWrite = $"Hello, it's test! Let's go! It's §0black§f, §1DarkBlue§f, §2DarkGreen§f, §3DarkCyan§f, §4DarkRed§f, §5pDarkMagenta§f, §6pDarkYellow§f, §7pDarkGray§f, §8pGray§f, §9pBlue§f, §apGreen§f, §bpCyan§f, §cpRed§f, §dpMagenta§f, §epYellow§f, wot i vse!~";
            List<TextBoxColored> PColor = new List<TextBoxColored>();
            Regex rex = new Regex("");
            //Match s = rex.Match("§1[this][this2]§fasdassdasd asd sd as§0asdasdasdasd§eQWEQWE§c");
            
            while (true)
            {
                //! Необходимо придумать реализацию по извлечению
                //@ Точнее я уже её придумал, но у меня нет инормации по регулярным выражениям
                //@ Мне необходимо достигать первого символа, а не последнего
                //@ Как это делает эта регулярка - (?([0-9]|[a-zA-Z]))[^\\§\\§]+(?=\\§([0-9]|[a-zA-Z]))
                //@ Из строки 'Hello, it's test! Let's go! It's §0black§f' мне необходимо получить текст до символа §0, а не до §f
                break;
                //@ По этому, я пока воспользуюсь старой реализацией записи по символам
                //@ Как соберу информацию, так и перепешу этот отрезок
#pragma warning disable CS0162
                rex = new Regex("pNone"); //(?=§)
                if (rex.IsMatch(textToWrite))
                {
                    if (rex.Match(textToWrite).Index != 0)
                    {
                        TextBoxColored pC = new TextBoxColored();
                        Match m = rex.Match(textToWrite);
                        pC.color = ConsoleColor.White;
                        pC.Text = textToWrite.Substring(0, m.Index);
                        PColor.Add(pC);
                        textToWrite = textToWrite.Remove(0, m.Index);
                    }
                    TR_01:
                    rex = new Regex(pBlack);
                    if (rex.IsMatch(textToWrite))
                    {
                        TextBoxColored pC = new TextBoxColored();
                        Match m = rex.Match(textToWrite);
                        pC.color = ConsoleColor.Black;
                        pC.Text = m.Value;
                        PColor.Add(pC);
                        textToWrite = textToWrite.Remove(m.Index, m.Length);
                        goto TR_01;
                    }
                    rex = new Regex(pBlack);
                    if (rex.IsMatch(textToWrite))
                    {
                        TextBoxColored pC = new TextBoxColored();
                        Match m = rex.Match(textToWrite);
                        pC.color = ConsoleColor.Black;
                        pC.Text = m.Value;
                        PColor.Add(pC);
                        textToWrite = textToWrite.Remove(m.Index, m.Length);
                        goto TR_01;
                    }
                }
                else
                {

                }
#pragma warning restore CS0162
            }
        }
        private static string sReplaceRCL(this string s, string to = "")
        {
            string tr = s;
            foreach (string y in listOfRCL)
            {
                tr = tr.Replace(y, to);
            }
            return tr;
        }
        private static void vReplaceRCL(this string s, string to = "")
        {
            foreach (string y in listOfRCL)
            {
                s = s.Replace(y, to);
            }
        }

    }
    /// <summary>
    /// Wrap the management console terminal
    /// </summary>
    public static partial class Terminal
    {
        public static class Windows
        {
            private static bool inited;

            internal static CONSOLE_SCREEN_BUFFER_INFO __screenInf;
            internal static readonly Transform defTransform;
            internal static readonly Cursor.CursorPoint defPointCursor;
            internal static readonly WinBuffer defBuffer;
            
            public static short WinWidth
            {
                get
                {
                    updateInf(false);
                    return ((Screen)__screenInf).Buff.Width;
                }
            }
            public static short WinHeight
            {
                get
                {
                    updateInf(false);
                    return ((Screen)__screenInf).Buff.Height;
                }
            }
            public static string Title
            {
                set
                {
                    Console.Title = value;
                }
                get
                {
                    return Console.Title;
                }
            }
            static Windows()
            {
                Init();
                defTransform = ((Screen)__screenInf).Traf;
                defPointCursor = ((Screen)__screenInf).CursorPosition;
                defBuffer = ((Screen)__screenInf).Buff;
            }
            public static void Init()
            {
                try
                {
                    if (inited)
                        throw new InvalidOperationException("Terminal Windows aleready Inited!");
                    updateInf(false);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            public unsafe static void SetTransform(Transform traf)
            {
                updateInf(false);
                int newRight = traf.Left + __screenInf.srWindow.Right - Console.WindowLeft + 1;
                if (traf.Left < 0 || newRight > __screenInf.dwSize.X || newRight < 0)
                    throw new ArgumentOutOfRangeException("left", traf.Left, "");
                int newBottom = traf.Top + __screenInf.srWindow.Bottom - __screenInf.srWindow.Top + 1;
                if (traf.Top < 0 || newBottom > __screenInf.dwSize.Y || newBottom < 0)
                    throw new ArgumentOutOfRangeException("top", traf.Top, "");
                SMALL_RECT srWindow = __screenInf.srWindow;
                bool r = NativeMethods.SetConsoleWindowInfo(NativeMethods.GetStdHandle(NativeConstat.STD_OUTPUT_HANDLE), true, &srWindow);
                if (!r)
                    r = NativeMethods.SetConsoleWindowInfo(NativeMethods.GetStdHandle(NativeConstat.STD_INPUT_HANDLE), true, &srWindow);
                if (!r)
                    r = NativeMethods.SetConsoleWindowInfo(NativeMethods.GetStdHandle(NativeConstat.STD_ERROR_HANDLE), true, &srWindow);
                if (!r)
                    throw new ContextMarshalException("declined");
            }
            public static void updateInf(bool throwOnNoCons)
            {
                bool succeeded;
                __screenInf = NativeMethods.GetBufferInfo(throwOnNoCons, out succeeded);
                if(!succeeded)
                    throw new AccessViolationException();
            }
        }
        public static class Cursor
        {
            public static CursorPoint pos
            {
                get
                {
                    Windows.updateInf(false);
                    return ((Screen)Windows.__screenInf).CursorPosition;
                }
                set
                {
                    Windows.updateInf(false);
                    if (value.X < 0 || value.X >= Int16.MaxValue)
                        throw new ArgumentOutOfRangeException("left", value.X, "ConsoleBufferBoundaries");
                    if (value.Y < 0 || value.Y >= Int16.MaxValue)
                        throw new ArgumentOutOfRangeException("top", value.Y, "ConsoleBufferBoundaries");
                    
                    COORD coords = new COORD();
                    coords.X = (short)value.X;
                    coords.Y = (short)value.Y;
                    bool r = NativeMethods.SetConsoleCursorPosition(NativeMethods.GetStdHandle(NativeConstat.STD_OUTPUT_HANDLE), coords);
                    if (!r)
                        r = NativeMethods.SetConsoleCursorPosition(NativeMethods.GetStdHandle(NativeConstat.STD_INPUT_HANDLE), coords);
                    if (!r)
                        r = NativeMethods.SetConsoleCursorPosition(NativeMethods.GetStdHandle(NativeConstat.STD_ERROR_HANDLE), coords);
                    if (!r)
                    {
                        int errorCode = Marshal.GetLastWin32Error();
                        Windows.updateInf(false);
                        CONSOLE_SCREEN_BUFFER_INFO csbi = Windows.__screenInf;
                        if (value.X < 0 || value.X >= csbi.dwSize.X)
                            throw new ArgumentOutOfRangeException("left", value.X, "ConsoleBufferBoundaries");
                        if (value.Y < 0 || value.Y >= csbi.dwSize.Y)
                            throw new ArgumentOutOfRangeException("top", value.Y, "ConsoleBufferBoundaries");
                    }
                }
            }
            public class CursorPoint
            {
                public short X;
                public short Y;
                public static implicit operator CursorPoint(SMALL_POINT po)
                {
                    var t = new CursorPoint();
                    t.X = po.X;
                    t.Y = po.Y;
                    return t;
                }
                public static implicit operator CursorPoint(POINT po)
                {
                    if (po.x > short.MaxValue)
                        throw new ArgumentOutOfRangeException("po.x", short.MaxValue, "po.x > short.MaxValue");
                    if (po.y > short.MaxValue)
                        throw new ArgumentOutOfRangeException("po.y", short.MaxValue, "po.y > short.MaxValue");

                    var t = new CursorPoint();
                    t.X = (short)po.x;
                    t.Y = (short)po.y;
                    return t;
                }
                public static implicit operator CursorPoint(COORD po)
                {
                    var t = new CursorPoint();
                    t.X = po.X;
                    t.Y = po.Y;
                    return t;
                }
            }
        }
        public class WinBuffer
        {
            public short Width;
            public short Height;
            public short Derpth;
        }
        public class Transform
        {
            public short Bottom;
            public short Right;
            public short Left;
            public short Top;
        }
        [Yaml(CompactMethod.Assign)]
        public class ConfigTerminal
        {
            public string Header;
            public bool isUseRCL;
            public bool isUseHeader;
            public bool isUseColor;
            public VTerminalAPI VersionAPI;
            public void AppendGlobal()
            {
                RegistryKey reg = Registry.CurrentUser.OpenSubKey("System\\RC\\Durability\\Terminal");
                if (reg == null)
                    reg = Registry.CurrentUser.CreateSubKey("System\\RC\\Durability\\Terminal");

                reg.SetValue("Header", Header);
                reg.SetValue("isUseRCL", isUseRCL);
                reg.SetValue("isUseHeader", isUseHeader);
                reg.SetValue("isUseColor", isUseColor);
                reg.SetValue("isOldKeyParse", isOldKeyParse);
                reg.SetValue("APIVersion", VersionAPI);
            }
            public void Load()
            {
                RegistryKey reg = Registry.CurrentUser.OpenSubKey("System\\RC\\Durability\\Terminal");
                if (reg != null)
                {
                    Header = (string)reg.GetValue("Header", "§dEngine§c");
                    isUseRCL = bool.Parse((string)reg.GetValue("isUseRCL", true));
                    isUseHeader = bool.Parse((string)reg.GetValue("isUseHeader", true));
                    isUseColor = bool.Parse((string)reg.GetValue("isUseColor", true));
                    VersionAPI = (VTerminalAPI)reg.GetValue("VersionAPI", VTerminalAPI.v8_1);
                }
                else
                {
                    Header          = ("§dEngine§c");
                    isUseRCL        = (true);
                    isUseHeader     = (true);
                    isUseColor      = (true);
                    VersionAPI      = (VTerminalAPI.v8_1);
                }
            }
        }
        internal class TextBoxColored
        {
            public string Text;
            public ConsoleColor color;
        }
        public sealed class Screen
        {
            internal Screen()
            {
                Traf = new Transform();
                Buff = new WinBuffer();
                CursorPosition = new Cursor.CursorPoint();
            }
            public Transform Traf;
            public WinBuffer Buff;

            public Cursor.CursorPoint CursorPosition;

            public short wAttributes;

            public short dwXMaximumWindowSize;
            public short dwYMaximumWindowSize;

            public static implicit operator Screen(CONSOLE_SCREEN_BUFFER_INFO WIN32_NATIVE_BUFFER_INFO)
            {
                Screen traf = new Screen();
                traf.Buff.Width = WIN32_NATIVE_BUFFER_INFO.dwSize.X;
                traf.Buff.Height = WIN32_NATIVE_BUFFER_INFO.dwSize.Y;

                traf.dwXMaximumWindowSize = WIN32_NATIVE_BUFFER_INFO.dwMaximumWindowSize.X;
                traf.dwYMaximumWindowSize = WIN32_NATIVE_BUFFER_INFO.dwMaximumWindowSize.Y;

                traf.wAttributes = WIN32_NATIVE_BUFFER_INFO.wAttributes;

                traf.Traf.Left = WIN32_NATIVE_BUFFER_INFO.srWindow.Left;
                traf.Traf.Right = WIN32_NATIVE_BUFFER_INFO.srWindow.Right;
                traf.Traf.Top = WIN32_NATIVE_BUFFER_INFO.srWindow.Top;
                traf.Traf.Bottom = WIN32_NATIVE_BUFFER_INFO.srWindow.Bottom;

                traf.CursorPosition = WIN32_NATIVE_BUFFER_INFO.dwCursorPosition;
                return traf;
            }
        }
    }
}
