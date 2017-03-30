namespace Rc.Framework.Screens
{
    using System;
    using System.Drawing;

    public static class RCL
    {
        public static string Wrap(string text, ConsoleColor color) => $"{color.getValue()}{text}{ConsoleColor.White.getValue()}";


        public static string Wrap(object text, Color foreground) => Wrap(text, foreground, Color.Empty);
        public static string Wrap(object text, Color foreground, Color background) => $"{foreground.getValue(background)}{text}{ConsoleColor.White.getValue().getValue(Color.Empty)}";


        public static string getValue(this Color c, Color back)
        {
            if (!c.IsNamedColor)
                throw new CustomColorException("Custom color is not allowed!");
            return $"&{c.Name};{back.Name};";
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