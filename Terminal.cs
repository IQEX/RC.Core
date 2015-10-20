// =====================================//==============================================================//
// License="root\\LICENSE"              //   Copyright © Of Fire Twins Wesp 2015  <ls-micro@ya.ru>      //
// LicenseType="MIT"                    //                  Alise Wesp & Yuuki Wesp                     //
// =====================================//==============================================================//
using System;
using System.IO;
using Rc.Framework.IO;
using Rc.Framework.RMath;
/// <summary>
/// The root namespace framework
/// </summary>
namespace Rc.Framework
{
    /// <summary>
    /// Wrap the management console terminal
    /// </summary>
    public static class Terminal
    {
        /// <summary>
        /// A reference to the class logging
        /// </summary>
        private static Log logger;
        /// <summary>
        /// The type of structure logging
        /// </summary>
        private static string typeClassLogging;
        /// <summary>
        /// Is logging?
        /// </summary>
        private static bool enabledlog = false;
        /// <summary>
        /// Locker to write
        /// </summary>
        public static object Locker = new object();
        /// <summary>
        /// Colors terminal
        /// </summary>
        public enum eColor
        {
            /// <summary>
            /// Blue Color
            /// </summary>
            Blue,
            /// <summary>
            /// Cyan Color
            /// </summary>
            Cyan,
            /// <summary>
            /// Gray Color
            /// </summary>
            Gray,
            /// <summary>
            /// Green Color
            /// </summary>
            Green,
            /// <summary>
            /// Magenta Color
            /// </summary>
            Magenta,
            /// <summary>
            /// Red Color
            /// </summary>
            Red,
            /// <summary>
            /// Yellow Color
            /// </summary>
            Yellow,
            /// <summary>
            /// DarkRed Color
            /// </summary>
            DarkRed,
            /// <summary>
            /// DarkMagenta Color
            /// </summary>
            DarkMagenta,
            /// <summary>
            /// White Color
            /// </summary>
            White
        }
        /// <summary>
        /// Class finished colors
        /// </summary>
        public class Color
        {
            private readonly static string strBlue               = "+g1 ";
            private readonly static string strCyan               = "+g2 ";
            private readonly static string strGray               = "+g3 ";
            private readonly static string strGreen              = "+g4 ";
            private readonly static string strMagenta            = "+g5 ";
            private readonly static string strRed                = "+g6 ";
            private readonly static string strYellow             = "+g7 ";
            private readonly static string strDarkRed            = "+g8 ";
            private readonly static string strDarkMagenta        = "+g9 ";
            private readonly static string strWhite              = "+g0 ";
            /// <summary>
            /// Blue Singelton
            /// </summary>
            public readonly static Color Blue           = new Color(eColor.Blue)        ;
            /// <summary>
            /// Cyan Singelton
            /// </summary>
            public readonly static Color Cyan           = new Color(eColor.Cyan)        ;
            /// <summary>
            /// Gray Singelton
            /// </summary>
            public readonly static Color Gray           = new Color(eColor.Gray)        ;
            /// <summary>
            /// Green Singelton
            /// </summary>
            public readonly static Color Green          = new Color(eColor.Green)       ;
            /// <summary>
            /// Magenta Singelton
            /// </summary>
            public readonly static Color Magenta        = new Color(eColor.Magenta)     ;
            /// <summary>
            /// Magenta Singelton
            /// </summary>
            public readonly static Color Red            = new Color(eColor.Red)         ;
            /// <summary>
            /// Yellow Singelton
            /// </summary>
            public readonly static Color Yellow         = new Color(eColor.Yellow)      ;
            /// <summary>
            /// DarkRed Singelton
            /// </summary>
            public readonly static Color DarkRed        = new Color(eColor.DarkRed)     ;
            /// <summary>
            /// DarkMagenta Singelton
            /// </summary>
            public readonly static Color DarkMagenta    = new Color(eColor.DarkMagenta) ;
            /// <summary>
            /// White Singelton
            /// </summary>
            public readonly static Color White          = new Color(eColor.White)       ;
            private string rawStringColor;
            /// <summary>
            /// 
            /// </summary>
            /// <param name="e">Type Color</param>
            public Color(eColor e)
            {
                if (e == eColor.Blue)
                    rawStringColor = strBlue;
                else if (e == eColor.Cyan)
                    rawStringColor = strCyan;
                else if (e == eColor.Gray)
                    rawStringColor = strGray;
                else if (e == eColor.Green)
                    rawStringColor = strGreen;
                else if (e == eColor.Magenta)
                    rawStringColor = strMagenta;
                else if (e == eColor.Red)
                    rawStringColor = strRed;
                else if (e == eColor.Yellow)
                    rawStringColor = strYellow;
                else if (e == eColor.DarkRed)
                    rawStringColor = strDarkRed;
                else if (e == eColor.DarkMagenta)
                    rawStringColor = strDarkMagenta;
                else if (e == eColor.White)
                    rawStringColor = strWhite;
            }
            /// <summary>
            /// Regex String to Color
            /// </summary>
            /// <param name="a"></param>
            public static implicit operator Color(String a)
            {
                return impOperation(a);
            }
            /// <summary>
            /// Color to regex string
            /// </summary>
            /// <param name="d"></param>
            public static implicit operator String(Color d)
            {
                return d.rawStringColor;
            }
            private static Color impOperation(String str)
            {
                char[] chars = str.ToCharArray();
                if (chars.Length != 3)
                    throw new Exception("Invalid format rcl color, pleas use \'+g{num color}\'");
                if (chars[0] == '+')
                {
                    if (chars[1] == 'g')
                    {
                        if (chars[2] == '1')
                            return new Color(eColor.Blue);
                        else if (chars[2] == '2')
                            return new Color(eColor.Cyan);
                        else if (chars[2] == '3')
                            return new Color(eColor.Gray);
                        else if (chars[2] == '4')
                            return new Color(eColor.Green);
                        else if (chars[2] == '5')
                            return new Color(eColor.Magenta);
                        else if (chars[2] == '6')
                            return new Color(eColor.Red);
                        else if (chars[2] == '7')
                            return new Color(eColor.Yellow);
                        else if (chars[2] == '8')
                            return new Color(eColor.DarkRed);
                        else if (chars[2] == '9')
                            return new Color(eColor.DarkMagenta);
                        else if (chars[2] == '0')
                            return new Color(eColor.White);
                        else
                            throw new Exception("Invalid num rcl color, pleas use \'+g{1 or 2 or 3.. or 9 or 0}\'");
                    }
                    else
                        throw new Exception("Invalid format rcl color, pleas use \'+g{num color}\'");
                }
                else
                    throw new Exception("Invalid format rcl color, pleas use \'+g{num color}\'");
            }
            public override string ToString()
            {
                return rawStringColor;
            }
        }
        /// <summary>
        /// Standard signature value
        /// </summary>
        public static string Def = "Engine";
        /// <summary>
        /// The value of the signature title window
        /// </summary>
        public static string Title
        {
            get
            {
                return Console.Title;
            }
            set
            {
                Console.Title = value;
            }
        }
        /// <summary>
        /// Write rcl (Raw Color Line)
        /// Without symbol of the end-line
        /// Example:
        ///     "White used standard, red color is used +g6 here+g0 , the green color is used +g4 here+g0 ."
        /// Note:
        ///     After the color numbers you need to retreat a single empty symbol, because it is eaten :D
        /// p.s - "It's not a bug, it's a feature"
        /// </summary>
        /// <param name="rcl">
        /// The usual line of characters 'rcl'
        /// </param>
        private static void rclWrite(string rcl)
        {
            char[] chars = rcl.ToCharArray();
            for(int i = 0; i != chars.Length; i++)
            {
                if (i > chars.Length - 1)
                    break;
                if(chars[i] == '+')
                {
                    if(chars.Length > i + 1)
                    {
                        if(chars[i + 1] == 'g')
                        {
                            if (chars.Length > i + 2)
                            {
                                if (chars[i + 2] == '1')
                                {
                                    Console.ForegroundColor = ConsoleColor.Blue;
                                    i = i + 3;
                                }
                                else if (chars[i + 2] == '2')
                                {
                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                    i = i + 3;
                                }
                                else if (chars[i + 2] == '3')
                                {
                                    Console.ForegroundColor = ConsoleColor.Gray;
                                    i = i + 3;
                                }
                                else if (chars[i + 2] == '4')
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    i = i + 3;
                                }
                                else if (chars[i + 2] == '5')
                                {
                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                    i = i + 3;
                                }
                                else if (chars[i + 2] == '6')
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    i = i + 3;
                                }
                                else if (chars[i + 2] == '7')
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    i = i + 3;
                                }
                                else if (chars[i + 2] == '8')
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    i = i + 3;
                                }
                                else if (chars[i + 2] == '9')
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                                    i = i + 3;
                                }
                                else if (chars[i + 2] == '0')
                                {
                                    Console.ForegroundColor = ConsoleColor.White;
                                    i = i + 3;
                                }
                                else
                                    Console.Write(chars[i]);
                            }
                            else
                                Console.Write(chars[i]);
                        }
                        else
                            Console.Write(chars[i]);
                    }
                    else
                        Console.Write(chars[i]);
                }
                else
                    Console.Write(chars[i]);
            }
        }
        /// <summary>
        /// Writes a clean line in the input stream
        /// </summary>
        /// <param name="s">String</param>
        public static void Print(string s)
        {
            rclWrite(s);
        }
        /// <summary>
        /// Writes a new line, with the support of rcl
        /// </summary>
        /// <param name="s">String Rcl</param>
        public static void WriteLine(string s)
        {
            lock(Locker)
            {
                Console.Write("[");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(Def);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("]: ");
                rclWrite(s);
                Console.Write(System.Environment.NewLine);
                if (enabledlog)
                    logger.Write(typeClassLogging, $"[{Def}]: {Replasercl(s)}");
            }
        }
        /// <summary>
        /// Writes a new line, with the support of rcl, without symbol of the end-line
        /// </summary>
        /// <param name="s">String Rcl</param>
        public static void Write(string s)
        {
            lock (Locker)
            {
                Console.Write("[");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(Def);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("]: ");
                rclWrite(s);
                if (enabledlog)
                    logger.Write(typeClassLogging, $"[{Def}]: {Replasercl(s)}");
            }
           
        }
        /// <summary>
        /// Writes a new line, with the support of rcl
        /// In addition, I write down the title block
        /// </summary>
        public static void WriteLine(string s, string Head)
        {
            lock (Locker)
            {
                Console.Write("[");
                rclWrite(Head);
                Console.Write("]: ");
                rclWrite(s);
                Console.Write(System.Environment.NewLine);
                if (enabledlog)
                    logger.Write(typeClassLogging, $"[{Replasercl(Head)}]: {Replasercl(s)}");
            }
        }
        /// <summary>
        /// Writes a new line, with the support of rcl, without symbol of the end-line
        /// In addition, I write down the title block
        /// </summary>
        /// <param name="s"></param>
        public static void Write(string s, string Head)
        {
            lock (Locker)
            {
                Console.Write("[");
                rclWrite(Head);
                Console.Write("]: ");
                rclWrite(s);
                if (enabledlog)
                    logger.Write(typeClassLogging, $"[{Replasercl(Head)}]: {Replasercl(s)}");
            }
        }
        /// <summary>
        /// Set pause
        /// </summary>
        public static void Pause()
        {
            Console.ReadKey();
        }
        /// <summary>
        /// Mounting logging function
        /// </summary>
        /// <param name="lgs"></param>
        /// <param name="TyperLog"></param>
        public static void OutLog(ref Log lgs, string TyperLog)
        {
            logger = lgs;
            typeClassLogging = TyperLog;
            enabledlog = true;
        }
        /// <summary>
        /// Turn off the set value logging
        /// </summary>
        public static void OffLog()
        {
            logger = null;
            typeClassLogging = null;
            enabledlog = false;
        }
        /// <summary>
        /// It reads the input value
        /// </summary>
        /// <returns></returns>
        public static string OutStreamReadLine()
        {
            string str = Console.ReadLine();
            if (enabledlog)
                logger.Write(typeClassLogging, str);
            return str;
        }
        /// <summary>
        /// Get stream recording
        /// </summary>
        /// <returns></returns>
        public static TextWriter StreamOut()
        {
            return Console.Out;
        }
        /// <summary>
        /// Get Stream reading
        /// </summary>
        /// <returns></returns>
        public static TextReader StreamInput()
        {
            return Console.In;
        }
        /// <summary>
        /// It sends a message to the central terminal
        /// 
        /// Command:
        ///     \clr - Clear a screen
        ///     \a   - Play 'beep' signal
        /// </summary>
        /// <param name="command"></param>
        public static void SendMessage(string command)
        {
            switch(command.ToLower())
            {
                case "\\clr":
                    Console.Clear();
                    break;
                case "\\a":
                    Console.Beep();
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// Set position of the cursor
        /// </summary>
        /// <param name="vec">Vector Point</param>
        public static void SetPoint(Vector2 vec)
        {
            Console.SetCursorPosition((int)vec.X, (int)vec.Y);
        }
        /// <summary>
        /// Set length of the buffer console
        /// </summary>
        /// <param name="vec">Vector Buffer</param>
        public static void SetBuffer(Vector2 vec)
        {
            Console.SetBufferSize((int)vec.X, (int)vec.Y);
        }
        /// <summary>
        /// Set position of the window
        /// </summary>
        /// <param name="vec">Vector Pint</param>
        public static void SetPointWindows(Vector2 vec)
        {
            Console.SetWindowPosition((int)vec.X, (int)vec.Y);
        }
        /// <summary>
        /// Set Conssole Windows sizw
        /// </summary>
        /// <param name="vec">Vector Size</param>
        public static void SetWindowSize(Vector2 vec)
        {
            Console.SetWindowSize((int)vec.X, (int)vec.Y);
        }
        /// <summary>
        /// It reads the position of the cursor
        /// </summary>
        /// <returns>Vecot Point Cursor</returns>
        public static Vector2 ReadVectorPoint()
        {
            return new Vector2(Console.CursorLeft, Console.CursorTop);
        }
        /// <summary>
        /// Remove rcl fragment
        /// </summary>
        /// <param name="rcl"></param>
        /// <returns></returns>
        private static string Replasercl(string rcl)
        {
            return rcl.Replace("+g0", "").Replace("+g1", "").Replace("+g2", "").Replace("+g3", "").Replace("+g4", "").Replace("+g5", "").Replace("+g6", "").Replace("+g7", "").Replace("+g8", "").Replace("+g9", "");
        }
    }
}
