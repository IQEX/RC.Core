namespace Rc.Framework.Screens
{
    using Colorful;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Text.RegularExpressions;


    public static partial class Screen
    {
        internal struct ConsoleBox
        {
            private readonly Color ForeGroundColor;
            private readonly Color BackGroundColor;

            public ConsoleBox(Color foreground, Color back)
            {
                this.ForeGroundColor = foreground;
                this.BackGroundColor = back;
            }

            public bool IsNamedColor => ForeGroundColor.IsNamedColor && BackGroundColor.IsNamedColor;

            public Color Foreground() => this.ForeGroundColor;
            public Color Background() => this.BackGroundColor;
        }
        internal struct ConsoleText
        {
            private readonly ConsoleBox _box;
            private readonly string _text;

            public ConsoleText(ConsoleBox box, string text)
            {
                _box = box;
                _text = text;
            }

            public bool IsNamedColor => _box.IsNamedColor;

            public string Text() => this._text;
            public ConsoleBox Box() => this._box;
        }

        private static readonly Regex RegexColorGroup  = new Regex(@"&([a-zA-Z]{3,})[;]{1}([a-zA-Z]{3,}|[0]{1,})[;]{1}");
        private static readonly Regex RegexColoredText = new Regex(@"(&([a-zA-Z]{3,}[;]{1}[a-zA-Z|0]{1,})[;]{1})((.*?))(&([a-zA-Z]{1,}[;]{1}[a-zA-Z|0]{1,})[;]{1})", RegexOptions.IgnoreCase);

        internal static ConsoleBox getColor(this Group c)
        {
            var saval = RegexColorGroup.Match(c.Value).Groups;
            try
            {
                string fore = saval[1].Value;
                string back = saval[2].Value;
                return new ConsoleBox(Color.FromName(fore), Color.FromName(back)); ;
            }
            catch(Exception e)
            {
                throw new FailConvertGroupToColorException(c, e);
            }
        }

        private static bool isUseRCL = true;
        public static void SwithRCL() => isUseRCL = !isUseRCL;

        public static void Write(string s)
        {
            if (isUseRCL)
                Screen.Parse(s);
            else
                Screen.Out.Write(s);
        }
        public static void Write(string s, Color foregroundDefault)
        {
            if (isUseRCL)
                Screen.Parse(s);
            else
                Colorful.Console.Write(s, foregroundDefault);
        }
        public static void WriteLine(string s)
        {
            if (isUseRCL)
                Screen.Parse($"{s}{System.Environment.NewLine}");
            else
                Screen.Out.Write($"{s}{System.Environment.NewLine}");
        }
        public static void WriteLine(string s, Color foregroundDefault)
        {
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

            int index = 0;

            foreach (Match grt in coll)
            {
                string fullData = grt.Value;
                ConsoleBox clr = grt.Groups[1].getColor();
                string coloredText = grt.Groups[3].Value;

                if (!clr.IsNamedColor)
                    throw new CustomColorException("Custom color is not allowed");

                dic.Add(index, new ConsoleText(clr, coloredText));
                s = s.Replace(fullData, $"{{{index++}}}");
            }

            List<Formatter> formsForeFormatters = new List<Formatter>();
            List<Formatter> formsBackFormatters = new List<Formatter>();

            foreach (var styleClass in dic) formsForeFormatters.Add(new Formatter(styleClass.Value.Text(), styleClass.Value.Box().Foreground()));
            foreach (var styleClass in dic) formsBackFormatters.Add(new Formatter(styleClass.Value.Text(), styleClass.Value.Box().Background()));

            Colorful.Console.WriteMixFormatted(s, foreground, formsForeFormatters.ToArray(), formsBackFormatters.ToArray());
        }
    }
}
