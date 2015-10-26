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
namespace Rc.Framework
{
    /// <summary>
    /// Wrap the management console terminal
    /// </summary>
    public static partial class Terminal
    {
        public const string Key = "§";
        public static string Cost(char c) { return $"§{c}"; }
        public static string Cost(this string c) { return ""; }

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
            ConfigTerminal conf = new ConfigTerminal();
            conf.Load();

            header          = conf.Header;
            isUseRCL        = conf.isUseRCL;
            isUseHeader     = conf.isUseHeader;
            isUseColor      = conf.isUseColor;
            isOldKeyParse   = conf.isOldKeyParse;

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
        private static string defHeader = "§dEngine§c";
        private static string header = "";
        private static RList<string> listOfRCL;
        private static bool isUseRCL;
        private static bool isUseHeader;
        private static bool isUseColor;
        private static bool isOldKeyParse;


        private static string RexMatherGTColor = "";

        public static ConfigTerminal GetConfig()
        {
            ConfigTerminal conf = new ConfigTerminal();
            conf.Header = header;
            conf.isUseRCL = isUseRCL;
            conf.isUseHeader = isUseHeader;
            conf.isUseColor = isUseColor;
            conf.isOldKeyParse = isOldKeyParse;
            conf.VersionAPI = VTerminalAPI.v8_1;
            return conf;
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
                if (inited)
                    throw new InvalidOperationException("Terminal Windows aleready Inited!");
                updateInf(false);
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
            internal static void updateInf(bool throwOnNoCons)
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
        [YamlSerialize(YamlSerializeMethod.Assign)]
        public class ConfigTerminal
        {
            public string Header;
            public bool isUseRCL;
            public bool isUseHeader;
            public bool isUseColor;
            public bool isOldKeyParse;
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
                    isUseRCL = (bool)reg.GetValue("isUseRCL", true);
                    isUseHeader = (bool)reg.GetValue("isUseHeader", true);
                    isUseColor = (bool)reg.GetValue("isUseColor", true);
                    isOldKeyParse = (bool)reg.GetValue("isOldKeyParse", false);
                    VersionAPI = (VTerminalAPI)reg.GetValue("VersionAPI", VTerminalAPI.v8_1);
                }
                else
                {
                    Header          = ("§dEngine§c");
                    isUseRCL        = (true);
                    isUseHeader     = (true);
                    isUseColor      = (true);
                    isOldKeyParse   = (false);
                    VersionAPI      = (VTerminalAPI.v8_1);
                }
            }
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
