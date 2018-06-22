using System.IO;

namespace RC.Framework.Screens
{
    using Colorful;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Text.RegularExpressions;


    public static partial class Screen
    {
        static Screen()
        {
            #if LINUX
            #endif
        }

        private static readonly Regex RegexColorGroup  = new Regex(@"&([a-zA-Z]{3,})[;]{1}([a-zA-Z]{3,}|[0]{1,})[;]{1}");
        private static readonly Regex RegexColoredText = new Regex(@"(&([a-zA-Z]{3,}[;]{1}[a-zA-Z|0]{1,})[;]{1})((.*?))(&([a-zA-Z]{1,}[;]{1}[a-zA-Z|0]{1,})[;]{1})", RegexOptions.IgnoreCase);

        internal static ConsoleBox getColor(this Group c)
        {
            var saval = RegexColorGroup.Match(c.Value).Groups;
            try
            {
                var fore = saval[groupnum: 1].Value;
                var back = saval[groupnum: 2].Value;
                return new ConsoleBox(Color.FromName(fore), Color.FromName(back));
            }
            catch(Exception e)
            {
                throw new FailConvertGroupToColorException(c, e);
            }
        }

        internal static bool isUseRCL = true;
        internal static bool isTechnicalRedirect = false;
        public static void SwithRCL() => isUseRCL = !isUseRCL;
        public static void SetModeRCL(bool isEnabled) => isUseRCL = isEnabled;

        private static TextWriter wre;
        private static TextReader rew;

        public static void SetOut(TextWriter a) => wre = a;
        public static void SetIn(TextReader a) => rew = a;

        public static void SetModeRedirect(bool isEnabled) => isTechnicalRedirect = isEnabled;

        public static void Write(string s)
        {
            if (isTechnicalRedirect)
            {
                wre.Write(s);
                return;
            }

            if (RCL.isEnabledVirtualTerminalProc)
            {
                System.Console.Write(s);
                return;
            }
            if (isUseRCL)
                Screen.Parse(s);
            else
                System.Console.Write(s);
        }
        public static void Write(string s, Color foregroundDefault)
        {
            if (isTechnicalRedirect)
            {
                wre.Write(s);
                return;
            }
            if (RCL.isEnabledVirtualTerminalProc)
            {
                System.Console.Write(s);
                return;
            }
            if (isUseRCL)
                Screen.Parse(s);
            else
                Colorful.Console.Write(s, foregroundDefault);
        }

        public static void WriteS(string s)
        {
            System.Console.WriteLine(s);
        }
        public static void WriteLine(string s)
        {
            if (isTechnicalRedirect)
            {
                wre.WriteLine(s);
                return;
            }

            if (RCL.isEnabledVirtualTerminalProc)
            {
                System.Console.WriteLine(s);
                return;
            }
            if (isUseRCL)
                Screen.Parse($"{s}{System.Environment.NewLine}");
            else
                System.Console.Write($"{s}{System.Environment.NewLine}");
        }
        public static void WriteLine(string s, Color foregroundDefault)
        {
            if (isTechnicalRedirect)
            {
                wre.WriteLine(s);
                return;
            }
            if (isUseRCL)
                Screen.Parse($"{s}{System.Environment.NewLine}", foregroundDefault);
            else
                Colorful.Console.WriteLine(s, foregroundDefault);
        }

        

        private static void Parse(string s, Color foreground = default(Color))
        {
            if (foreground == default(Color))
                foreground = Color.White;

            var dic = new Dictionary<int, ConsoleText>();

            var coll = RegexColoredText.Matches(s);

            var index = 0;

            foreach (Match grt in coll)
            {
                var fullData = grt.Value;
                var clr = grt.Groups[groupnum: 1].getColor();
                var coloredText = grt.Groups[groupnum: 3].Value;

                if (!clr.IsNamedColor)
                    throw new CustomColorException("Custom color is not allowed");

                dic.Add(index, new ConsoleText(clr, coloredText));
                s = s.Replace(fullData, $"{{{index++}}}");
            }

            var formsForeFormatters = new List<Formatter>();
            var formsBackFormatters = new List<Formatter>();

            foreach (var styleClass in dic) formsForeFormatters.Add(new Formatter(styleClass.Value.Text(), styleClass.Value.Box().Foreground()));
            foreach (var styleClass in dic) formsBackFormatters.Add(new Formatter(styleClass.Value.Text(), styleClass.Value.Box().Background()));
            #if LINUX
            System.Console.Write(s);
            #else
            Colorful.Console.WriteMixFormatted(s, foreground, formsForeFormatters.ToArray(), formsBackFormatters.ToArray());
            #endif
        }
    }
}
