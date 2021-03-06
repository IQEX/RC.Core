﻿namespace RC.Framework.Screens
{
    using System.IO;
    using System;
    using System.Text;
    using System.Drawing;

    public partial class Screen
    {
        public static string Title
        {
            get => Console.Title;
            set => Console.Title = value;
        }

        public static void Clear() => Colorful.Console.Clear();
        public static bool CapsLock => System.Console.CapsLock;


        public static Color BackgroundColor
        {
            get => Colorful.Console.colorManager.GetColor(System.Console.BackgroundColor);
            set => System.Console.BackgroundColor = Colorful.Console.colorManager.GetConsoleColor(value);
        }
        public static Color ForegroundColor
        {
            get => Colorful.Console.colorManager.GetColor(System.Console.ForegroundColor);
            set => System.Console.ForegroundColor = Colorful.Console.colorManager.GetConsoleColor(value);
        }

        public static int BufferHeight
        {
            get { return System.Console.BufferHeight; }
            set { System.Console.BufferHeight = value; }
        }

        public static int BufferWidth
        {
            get { return System.Console.BufferWidth; }
            set { System.Console.BufferWidth = value; }
        }

        public static int CursorLeft
        {
            get { return System.Console.CursorLeft; }
            set { System.Console.CursorLeft = value; }
        }

        public static int CursorSize
        {
            get { return System.Console.CursorSize; }
            set { System.Console.CursorSize = value; }
        }

        public static int CursorTop
        {
            get { return System.Console.CursorTop; }
            set { System.Console.CursorTop = value; }
        }

        public static bool CursorVisible
        {
            get { return System.Console.CursorVisible; }
            set { System.Console.CursorVisible = value; }
        }

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
    }
}