// =====================================//==============================================================//
// License="root\\LICENSE"              //   Copyright © Of Fire Twins Wesp 2015  <ls-micro@ya.ru>      //
// LicenseType="MIT"                    //                  Alise Wesp & Yuuki Wesp                     //
// =====================================//==============================================================//
using Rc.Framework.Collections;
using Rc.Framework.Native.Runtime;
using Rc.Framework.Native.Runtime.Diagnostic;
using Rc.Framework.Yaml.Serialization;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

//! ВНИМАНИЕ !//
//@ Этот файл опасен для здоровья, так что прочтение данного исходника не рекомендуется разработчиками
//@ Такого "говнокода" даже я нигде не видел, в скором времени я это разберу
//! ВНИМАНИЕ !//
#pragma warning disable CS1591 // Без него, предупреждений более 2500 штук
namespace Rc.Framework.Native
{

    /// <summary>
    /// A Delegate to get a property value from an object.
    /// </summary>
    /// <typeparam name="T">Type of the getter.</typeparam>
    /// <param name="obj">The obj to get the property from.</param>
    /// <param name="value">The value to get.</param>
    public delegate void GetValueFastDelegate<T>(object obj, out T value);

    /// <summary>
    /// A Delegate to set a property value to an object.
    /// </summary>
    /// <typeparam name="T">Type of the setter.</typeparam>
    /// <param name="obj">The obj to set the property from.</param>
    /// <param name="value">The value to set.</param>
    public delegate void SetValueFastDelegate<T>(object obj, ref T value);

    public class KeyEventArgs : EventArgs
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса KeyEventArgs.
        /// </summary>
        /// <param name="keyData"></param>
        public KeyEventArgs(Keys keyData)
        {
            this.KeyData = keyData;
        }
        /// <summary>
        /// Получает значение, показывающее, была ли нажата клавиша ALT.
        /// </summary>
        public bool Alt;
        /// <summary>
        /// Получает значение, показывающее, была ли нажата клавиша CTRL.
        /// </summary>
        public bool Control;
        /// <summary>
        /// Получает или задает значение, определяющее, было ли обработано событие.
        /// </summary>
        public bool Handled;
        /// <summary>
        /// Получает данные, касающиеся клавиш
        /// </summary>
        public Keys KeyData { get; }
        /// <summary>
        /// Получает значение, показывающее, была ли нажата клавиша SHIFT.
        /// </summary>
        public bool Shift;
        /// <summary>
        /// Получает или задает значение, указывающее, следует ли передавать события нажатия
        /// клавиши базовому элементу управления.
        /// </summary>
        public bool SuppressKeyPress { get; set; }
    }
    public delegate IntPtr HookProc(int code, IntPtr wParam, IntPtr lParam);
    public delegate int KeyBoardHookProc(int code, int wParam, ref NativeStruct.KeyBoardHookStruct lParam);
    public delegate void KeyEventHandler(object sender, KeyEventArgs e);
    public enum Keys
    {
        //
        // Сводка:
        //     Битовая маска для извлечения модификаторов из значения клавиши.
        Modifiers = -65536,
        //
        // Сводка:
        //     Нет нажатых клавиш.
        None = 0,
        //
        // Сводка:
        //     Левая кнопка мыши.
        LButton = 1,
        //
        // Сводка:
        //     Правая кнопка мыши.
        RButton = 2,
        //
        // Сводка:
        //     Клавиша отмены.
        Cancel = 3,
        //
        // Сводка:
        //     Средняя кнопка мыши (трехкнопочная мышь).
        MButton = 4,
        //
        // Сводка:
        //     Первая кнопка мыши (пятикнопочная мышь).
        XButton1 = 5,
        //
        // Сводка:
        //     Вторая кнопка мыши (пятикнопочная мышь).
        XButton2 = 6,
        //
        // Сводка:
        //     Клавиша BACKSPACE.
        Back = 8,
        //
        // Сводка:
        //     Клавиша TAB.
        Tab = 9,
        //
        // Сводка:
        //     Клавиша LINEFEED.
        LineFeed = 10,
        //
        // Сводка:
        //     Клавиша CLEAR.
        Clear = 12,
        //
        // Сводка:
        //     Клавиша RETURN.
        Return = 13,
        //
        // Сводка:
        //     Клавиша ВВОД.
        Enter = 13,
        //
        // Сводка:
        //     Клавиша SHIFT.
        ShiftKey = 16,
        //
        // Сводка:
        //     Клавиша CTRL.
        ControlKey = 17,
        //
        // Сводка:
        //     Клавиша ALT.
        Menu = 18,
        //
        // Сводка:
        //     Клавиша PAUSE.
        Pause = 19,
        //
        // Сводка:
        //     Клавиша CAPS LOCK.
        Capital = 20,
        //
        // Сводка:
        //     Клавиша CAPS LOCK.
        CapsLock = 20,
        //
        // Сводка:
        //     Клавиша режима IME Kana.
        KanaMode = 21,
        //
        // Сводка:
        //     Клавиша режима IME Hanguel (поддерживается для обеспечения совместимости; используйте
        //     клавишу HangulMode).
        HanguelMode = 21,
        //
        // Сводка:
        //     Клавиша режима IME Hangul.
        HangulMode = 21,
        //
        // Сводка:
        //     Клавиша режима IME Junja.
        JunjaMode = 23,
        //
        // Сводка:
        //     Клавиша окончательного режима IME.
        FinalMode = 24,
        //
        // Сводка:
        //     Клавиша режима IME Hanja.
        HanjaMode = 25,
        //
        // Сводка:
        //     Клавиша режима IME Kanji.
        KanjiMode = 25,
        //
        // Сводка:
        //     Клавиша ESC.
        Escape = 27,
        //
        // Сводка:
        //     Клавиша преобразования IME.
        IMEConvert = 28,
        //
        // Сводка:
        //     Клавиша без преобразования IME.
        IMENonconvert = 29,
        //
        // Сводка:
        //     Клавиша принятия IME, заменяет клавишу System.Windows.Forms.Keys.IMEAceept.
        IMEAccept = 30,
        //
        // Сводка:
        //     Клавиша принятия IME. Является устаревшей, вместо нее используется клавиша System.Windows.Forms.Keys.IMEAccept.
        IMEAceept = 30,
        //
        // Сводка:
        //     Клавиша изменения режима IME.
        IMEModeChange = 31,
        //
        // Сводка:
        //     Клавиша ПРОБЕЛ.
        Space = 32,
        //
        // Сводка:
        //     Клавиша PAGE UP.
        Prior = 33,
        //
        // Сводка:
        //     Клавиша PAGE UP.
        PageUp = 33,
        //
        // Сводка:
        //     Клавиша PAGE DOWN.
        Next = 34,
        //
        // Сводка:
        //     Клавиша PAGE DOWN.
        PageDown = 34,
        //
        // Сводка:
        //     Клавиша END.
        End = 35,
        //
        // Сводка:
        //     Клавиша HOME.
        Home = 36,
        //
        // Сводка:
        //     Клавиша СТРЕЛКА ВЛЕВО.
        Left = 37,
        //
        // Сводка:
        //     Клавиша СТРЕЛКА ВВЕРХ.
        Up = 38,
        //
        // Сводка:
        //     Клавиша СТРЕЛКА ВПРАВО.
        Right = 39,
        //
        // Сводка:
        //     Клавиша СТРЕЛКА ВНИЗ.
        Down = 40,
        //
        // Сводка:
        //     Клавиша SELECT.
        Select = 41,
        //
        // Сводка:
        //     Клавиша PRINT.
        Print = 42,
        //
        // Сводка:
        //     Клавиша EXECUTE.
        Execute = 43,
        //
        // Сводка:
        //     Клавиша PRINT SCREEN.
        Snapshot = 44,
        //
        // Сводка:
        //     Клавиша PRINT SCREEN.
        PrintScreen = 44,
        //
        // Сводка:
        //     Клавиша INS.
        Insert = 45,
        //
        // Сводка:
        //     Клавиша DEL.
        Delete = 46,
        //
        // Сводка:
        //     Клавиша HELP.
        Help = 47,
        //
        // Сводка:
        //     Клавиша 0.
        D0 = 48,
        //
        // Сводка:
        //     Клавиша 1.
        D1 = 49,
        //
        // Сводка:
        //     Клавиша 2.
        D2 = 50,
        //
        // Сводка:
        //     Клавиша 3.
        D3 = 51,
        //
        // Сводка:
        //     Клавиша 4.
        D4 = 52,
        //
        // Сводка:
        //     Клавиша 5.
        D5 = 53,
        //
        // Сводка:
        //     Клавиша 6.
        D6 = 54,
        //
        // Сводка:
        //     Клавиша 7.
        D7 = 55,
        //
        // Сводка:
        //     Клавиша 8.
        D8 = 56,
        //
        // Сводка:
        //     Клавиша 9.
        D9 = 57,
        //
        // Сводка:
        //     Клавиша A.
        A = 65,
        //
        // Сводка:
        //     Клавиша B.
        B = 66,
        //
        // Сводка:
        //     Клавиша C.
        C = 67,
        //
        // Сводка:
        //     Клавиша D.
        D = 68,
        //
        // Сводка:
        //     Клавиша E.
        E = 69,
        //
        // Сводка:
        //     Клавиша F.
        F = 70,
        //
        // Сводка:
        //     Клавиша G.
        G = 71,
        //
        // Сводка:
        //     Клавиша H.
        H = 72,
        //
        // Сводка:
        //     Клавиша I.
        I = 73,
        //
        // Сводка:
        //     Клавиша J.
        J = 74,
        //
        // Сводка:
        //     Клавиша K.
        K = 75,
        //
        // Сводка:
        //     Клавиша L.
        L = 76,
        //
        // Сводка:
        //     Клавиша M.
        M = 77,
        //
        // Сводка:
        //     Клавиша N.
        N = 78,
        //
        // Сводка:
        //     Клавиша O.
        O = 79,
        //
        // Сводка:
        //     Клавиша P.
        P = 80,
        //
        // Сводка:
        //     Клавиша Q.
        Q = 81,
        //
        // Сводка:
        //     Клавиша R.
        R = 82,
        //
        // Сводка:
        //     Клавиша S.
        S = 83,
        //
        // Сводка:
        //     Клавиша T.
        T = 84,
        //
        // Сводка:
        //     Клавиша U.
        U = 85,
        //
        // Сводка:
        //     Клавиша V.
        V = 86,
        //
        // Сводка:
        //     Клавиша W.
        W = 87,
        //
        // Сводка:
        //     Клавиша X.
        X = 88,
        //
        // Сводка:
        //     Клавиша Y.
        Y = 89,
        //
        // Сводка:
        //     Клавиша Z.
        Z = 90,
        //
        // Сводка:
        //     Левая клавиша с эмблемой Windows (клавиатура Microsoft Natural).
        LWin = 91,
        //
        // Сводка:
        //     Правая клавиша с эмблемой Windows (клавиатура Microsoft Natural).
        RWin = 92,
        //
        // Сводка:
        //     Клавиша контекстного меню (клавиатура Microsoft Natural).
        Apps = 93,
        //
        // Сводка:
        //     Клавиша перевода компьютера в спящий режим.
        Sleep = 95,
        //
        // Сводка:
        //     Клавиша 0 на цифровой клавиатуре.
        NumPad0 = 96,
        //
        // Сводка:
        //     Клавиша 1 на цифровой клавиатуре.
        NumPad1 = 97,
        //
        // Сводка:
        //     Клавиша 2 на цифровой клавиатуре.
        NumPad2 = 98,
        //
        // Сводка:
        //     Клавиша 3 на цифровой клавиатуре.
        NumPad3 = 99,
        //
        // Сводка:
        //     Клавиша 4 на цифровой клавиатуре.
        NumPad4 = 100,
        //
        // Сводка:
        //     Клавиша 5 на цифровой клавиатуре.
        NumPad5 = 101,
        //
        // Сводка:
        //     Клавиша 6 на цифровой клавиатуре.
        NumPad6 = 102,
        //
        // Сводка:
        //     Клавиша 7 на цифровой клавиатуре.
        NumPad7 = 103,
        //
        // Сводка:
        //     Клавиша 8 на цифровой клавиатуре.
        NumPad8 = 104,
        //
        // Сводка:
        //     Клавиша 9 на цифровой клавиатуре.
        NumPad9 = 105,
        //
        // Сводка:
        //     Клавиша умножения.
        Multiply = 106,
        //
        // Сводка:
        //     Клавиша сложения.
        Add = 107,
        //
        // Сводка:
        //     Клавиша разделителя.
        Separator = 108,
        //
        // Сводка:
        //     Клавиша вычитания.
        Subtract = 109,
        //
        // Сводка:
        //     Клавиша десятичного разделителя.
        Decimal = 110,
        //
        // Сводка:
        //     Клавиша деления.
        Divide = 111,
        //
        // Сводка:
        //     Клавиша F1.
        F1 = 112,
        //
        // Сводка:
        //     Клавиша F2.
        F2 = 113,
        //
        // Сводка:
        //     Клавиша F3.
        F3 = 114,
        //
        // Сводка:
        //     Клавиша F4.
        F4 = 115,
        //
        // Сводка:
        //     Клавиша F5.
        F5 = 116,
        //
        // Сводка:
        //     Клавиша F6.
        F6 = 117,
        //
        // Сводка:
        //     Клавиша F7.
        F7 = 118,
        //
        // Сводка:
        //     Клавиша F8.
        F8 = 119,
        //
        // Сводка:
        //     Клавиша F9.
        F9 = 120,
        //
        // Сводка:
        //     Клавиша F10.
        F10 = 121,
        //
        // Сводка:
        //     Клавиша F11.
        F11 = 122,
        //
        // Сводка:
        //     Клавиша F12.
        F12 = 123,
        //
        // Сводка:
        //     Клавиша F13.
        F13 = 124,
        //
        // Сводка:
        //     Клавиша F14.
        F14 = 125,
        //
        // Сводка:
        //     Клавиша F15.
        F15 = 126,
        //
        // Сводка:
        //     Клавиша F16.
        F16 = 127,
        //
        // Сводка:
        //     Клавиша F17.
        F17 = 128,
        //
        // Сводка:
        //     Клавиша F18.
        F18 = 129,
        //
        // Сводка:
        //     Клавиша F19.
        F19 = 130,
        //
        // Сводка:
        //     Клавиша F20.
        F20 = 131,
        //
        // Сводка:
        //     Клавиша F21.
        F21 = 132,
        //
        // Сводка:
        //     Клавиша F22.
        F22 = 133,
        //
        // Сводка:
        //     Клавиша F23.
        F23 = 134,
        //
        // Сводка:
        //     Клавиша F24.
        F24 = 135,
        //
        // Сводка:
        //     Клавиша NUM LOCK.
        NumLock = 144,
        //
        // Сводка:
        //     Клавиша SCROLL LOCK.
        Scroll = 145,
        //
        // Сводка:
        //     Левая клавиша SHIFT.
        LShiftKey = 160,
        //
        // Сводка:
        //     Правая клавиша SHIFT.
        RShiftKey = 161,
        //
        // Сводка:
        //     Левая клавиша CTRL.
        LControlKey = 162,
        //
        // Сводка:
        //     Правая клавиша CTRL.
        RControlKey = 163,
        //
        // Сводка:
        //     Левая клавиша ALT.
        LMenu = 164,
        //
        // Сводка:
        //     Правая клавиша ALT.
        RMenu = 165,
        //
        // Сводка:
        //     Клавиша перехода назад в браузере (Windows 2000 или более поздняя версия).
        BrowserBack = 166,
        //
        // Сводка:
        //     Клавиша перехода вперед в браузере (Windows 2000 или более поздняя версия).
        BrowserForward = 167,
        //
        // Сводка:
        //     Клавиша обновления в браузере (Windows 2000 или более поздняя версия).
        BrowserRefresh = 168,
        //
        // Сводка:
        //     Клавиша остановки в браузере (Windows 2000 или более поздняя версия).
        BrowserStop = 169,
        //
        // Сводка:
        //     Клавиша поиска в браузере (Windows 2000 или более поздняя версия).
        BrowserSearch = 170,
        //
        // Сводка:
        //     Клавиша избранного в браузере (Windows 2000 или более поздняя версия).
        BrowserFavorites = 171,
        //
        // Сводка:
        //     Клавиша домашней страницы в браузере (Windows 2000 или более поздняя версия).
        BrowserHome = 172,
        //
        // Сводка:
        //     Клавиша выключения звука (Windows 2000 или более поздняя версия).
        VolumeMute = 173,
        //
        // Сводка:
        //     Клавиша уменьшения громкости (Windows 2000 или более поздняя версия).
        VolumeDown = 174,
        //
        // Сводка:
        //     Клавиша увеличения громкости (Windows 2000 или более поздняя версия).
        VolumeUp = 175,
        //
        // Сводка:
        //     Клавиша перехода на следующую запись (Windows 2000 или более поздняя версия).
        MediaNextTrack = 176,
        //
        // Сводка:
        //     Клавиша перехода на предыдущую запись (Windows 2000 или более поздняя версия).
        MediaPreviousTrack = 177,
        //
        // Сводка:
        //     Клавиша остановки воспроизведения (Windows 2000 или более поздняя версия).
        MediaStop = 178,
        //
        // Сводка:
        //     Клавиша приостановки воспроизведения (Windows 2000 или более поздняя версия).
        MediaPlayPause = 179,
        //
        // Сводка:
        //     Клавиша запуска почты (Windows 2000 или более поздняя версия).
        LaunchMail = 180,
        //
        // Сводка:
        //     Клавиша выбора записи (Windows 2000 или более поздняя версия).
        SelectMedia = 181,
        //
        // Сводка:
        //     Клавиша запуска приложения один (Windows 2000 или более поздняя версия).
        LaunchApplication1 = 182,
        //
        // Сводка:
        //     Клавиша запуска приложения два (Windows 2000 или более поздняя версия).
        LaunchApplication2 = 183,
        //
        // Сводка:
        //     Клавиша OEM с точкой с запятой на стандартной клавиатуре США (Windows 2000 или
        //     более поздняя версия).
        OemSemicolon = 186,
        //
        // Сводка:
        //     Клавиша 1 изготовителя оборудования.
        Oem1 = 186,
        //
        // Сводка:
        //     Клавиша OEM со знаком плюса на клавиатуре любой страны или региона (Windows 2000
        //     или более поздняя версия).
        Oemplus = 187,
        //
        // Сводка:
        //     Клавиша OEM с запятой на клавиатуре любой страны или региона (Windows 2000 или
        //     более поздняя версия).
        Oemcomma = 188,
        //
        // Сводка:
        //     Клавиша OEM со знаком минуса на клавиатуре любой страны или региона (Windows
        //     2000 или более поздняя версия).
        OemMinus = 189,
        //
        // Сводка:
        //     Клавиша OEM с точкой на клавиатуре любой страны или региона (Windows 2000 или
        //     более поздняя версия).
        OemPeriod = 190,
        //
        // Сводка:
        //     Клавиша OEM с вопросительным знаком на стандартной клавиатуре США (Windows 2000
        //     или более поздняя версия).
        OemQuestion = 191,
        //
        // Сводка:
        //     Клавиша 2 изготовителя оборудования.
        Oem2 = 191,
        //
        // Сводка:
        //     Клавиша OEM со знаком тильды на стандартной клавиатуре США (Windows 2000 или
        //     более поздняя версия).
        Oemtilde = 192,
        //
        // Сводка:
        //     Клавиша 3 изготовителя оборудования.
        Oem3 = 192,
        //
        // Сводка:
        //     Клавиша OEM с открывающей квадратной скобкой на стандартной клавиатуре США (Windows
        //     2000 или более поздняя версия).
        OemOpenBrackets = 219,
        //
        // Сводка:
        //     Клавиша 4 изготовителя оборудования.
        Oem4 = 219,
        //
        // Сводка:
        //     Клавиша OEM с вертикальной чертой на стандартной клавиатуре США (Windows 2000
        //     или более поздняя версия).
        OemPipe = 220,
        //
        // Сводка:
        //     Клавиша 5 изготовителя оборудования.
        Oem5 = 220,
        //
        // Сводка:
        //     Клавиша OEM с закрывающей квадратной скобкой на стандартной клавиатуре США (Windows
        //     2000 или более поздняя версия).
        OemCloseBrackets = 221,
        //
        // Сводка:
        //     Клавиша 6 изготовителя оборудования.
        Oem6 = 221,
        //
        // Сводка:
        //     Клавиша OEM с одинарной/двойной кавычкой на стандартной клавиатуре США (Windows
        //     2000 или более поздняя версия).
        OemQuotes = 222,
        //
        // Сводка:
        //     Клавиша 7 изготовителя оборудования.
        Oem7 = 222,
        //
        // Сводка:
        //     Клавиша 8 изготовителя оборудования.
        Oem8 = 223,
        //
        // Сводка:
        //     Клавиша OEM с угловой скобкой или обратной косой чертой на клавиатуре RT со 102
        //     клавишами (Windows 2000 или более поздняя версия).
        OemBackslash = 226,
        //
        // Сводка:
        //     Клавиша 102 изготовителя оборудования.
        Oem102 = 226,
        //
        // Сводка:
        //     Клавиша PROCESS KEY.
        ProcessKey = 229,
        //
        // Сводка:
        //     Используется для передачи символов в Юникоде в виде нажатия клавиш. Значение
        //     клавиши пакета является младшим словом 32-разрядного виртуального значения клавиши,
        //     используемого для бесклавиатурных методов ввода.
        Packet = 231,
        //
        // Сводка:
        //     Клавиша ATTN.
        Attn = 246,
        //
        // Сводка:
        //     Клавиша CRSEL.
        Crsel = 247,
        //
        // Сводка:
        //     Клавиша EXSEL.
        Exsel = 248,
        //
        // Сводка:
        //     Клавиша ERASE EOF.
        EraseEof = 249,
        //
        // Сводка:
        //     Клавиша PLAY.
        Play = 250,
        //
        // Сводка:
        //     Клавиша ZOOM.
        Zoom = 251,
        //
        // Сводка:
        //     Константа, зарезервированная для использования в будущем.
        NoName = 252,
        //
        // Сводка:
        //     Клавиша PA1.
        Pa1 = 253,
        //
        // Сводка:
        //     Клавиша CLEAR.
        OemClear = 254,
        //
        // Сводка:
        //     Битовая маска для извлечения кода клавиши из значения клавиши.
        KeyCode = 65535,
        //
        // Сводка:
        //     Клавиша SHIFT.
        Shift = 65536,
        //
        // Сводка:
        //     Клавиша CTRL.
        Control = 131072,
        //
        // Сводка:
        //     Клавиша ALT.
        Alt = 262144
    }
    public static class NativeConstat
    {
        public static IntPtr InvalidIntPtr;
        public static IntPtr LPSTR_TEXTCALLBACK;
        public static HandleRef NullHandleRef;
        public const int BITMAPINFO_MAX_COLORSIZE = 256;
        public const int BI_BITFIELDS = 3;
        public const int STATUS_PENDING = 259;
        public const int DESKTOP_SWITCHDESKTOP = 256;
        public const int ERROR_ACCESS_DENIED = 5;
        public const int FW_DONTCARE = 0;
        public const int FW_NORMAL = 400;
        public const int FW_BOLD = 700;
        public const int ANSI_CHARSET = 0;
        public const int DEFAULT_CHARSET = 1;
        public const int OUT_DEFAULT_PRECIS = 0;
        public const int OUT_TT_PRECIS = 4;
        public const int OUT_TT_ONLY_PRECIS = 7;
        public const int ALTERNATE = 1;
        public const int WINDING = 2;
        public const int TA_DEFAULT = 0;
        public const int BS_SOLID = 0;
        public const int HOLLOW_BRUSH = 5;
        public const int R2_BLACK = 1;
        public const int R2_NOTMERGEPEN = 2;
        public const int R2_MASKNOTPEN = 3;
        public const int R2_NOTCOPYPEN = 4;
        public const int R2_MASKPENNOT = 5;
        public const int R2_NOT = 6;
        public const int R2_XORPEN = 7;
        public const int R2_NOTMASKPEN = 8;
        public const int R2_MASKPEN = 9;
        public const int R2_NOTXORPEN = 10;
        public const int R2_NOP = 11;
        public const int R2_MERGENOTPEN = 12;
        public const int R2_COPYPEN = 13;
        public const int R2_MERGEPENNOT = 14;
        public const int R2_MERGEPEN = 15;
        public const int R2_WHITE = 16;
        public const int GM_COMPATIBLE = 1;
        public const int GM_ADVANCED = 2;
        public const int MWT_IDENTITY = 1;
        public const int PAGE_READONLY = 2;
        public const int PAGE_READWRITE = 4;
        public const int PAGE_WRITECOPY = 8;
        public const int FILE_MAP_COPY = 1;
        public const int FILE_MAP_WRITE = 2;
        public const int FILE_MAP_READ = 4;
        public const int SHGFI_ICON = 256;
        public const int SHGFI_DISPLAYNAME = 512;
        public const int SHGFI_TYPENAME = 1024;
        public const int SHGFI_ATTRIBUTES = 2048;
        public const int SHGFI_ICONLOCATION = 4096;
        public const int SHGFI_EXETYPE = 8192;
        public const int SHGFI_SYSICONINDEX = 16384;
        public const int SHGFI_LINKOVERLAY = 32768;
        public const int SHGFI_SELECTED = 65536;
        public const int SHGFI_ATTR_SPECIFIED = 131072;
        public const int SHGFI_LARGEICON = 0;
        public const int SHGFI_SMALLICON = 1;
        public const int SHGFI_OPENICON = 2;
        public const int SHGFI_SHELLICONSIZE = 4;
        public const int SHGFI_PIDL = 8;
        public const int SHGFI_USEFILEATTRIBUTES = 16;
        public const int SHGFI_ADDOVERLAYS = 32;
        public const int SHGFI_OVERLAYINDEX = 64;
        public const int DM_DISPLAYORIENTATION = 128;
        public const int AUTOSUGGEST = 268435456;
        public const int AUTOSUGGEST_OFF = 536870912;
        public const int AUTOAPPEND = 1073741824;
        public const int AUTOAPPEND_OFF = -2147483648;
        public const int ARW_BOTTOMLEFT = 0;
        public const int ARW_BOTTOMRIGHT = 1;
        public const int ARW_TOPLEFT = 2;
        public const int ARW_TOPRIGHT = 3;
        public const int ARW_LEFT = 0;
        public const int ARW_RIGHT = 0;
        public const int ARW_UP = 4;
        public const int ARW_DOWN = 4;
        public const int ARW_HIDE = 8;
        public const int ACM_OPENA = 1124;
        public const int ACM_OPENW = 1127;
        public const int ADVF_NODATA = 1;
        public const int ADVF_ONLYONCE = 4;
        public const int ADVF_PRIMEFIRST = 2;
        public const int BCM_GETIDEALSIZE = 5633;
        public const int BI_RGB = 0;
        public const int BS_PATTERN = 3;
        public const int BITSPIXEL = 12;
        public const int BDR_RAISEDOUTER = 1;
        public const int BDR_SUNKENOUTER = 2;
        public const int BDR_RAISEDINNER = 4;
        public const int BDR_SUNKENINNER = 8;
        public const int BDR_RAISED = 5;
        public const int BDR_SUNKEN = 10;
        public const int BF_LEFT = 1;
        public const int BF_TOP = 2;
        public const int BF_RIGHT = 4;
        public const int BF_BOTTOM = 8;
        public const int BF_ADJUST = 8192;
        public const int BF_FLAT = 16384;
        public const int BF_MIDDLE = 2048;
        public const int BFFM_INITIALIZED = 1;
        public const int BFFM_SELCHANGED = 2;
        public const int BFFM_SETSELECTIONA = 1126;
        public const int BFFM_SETSELECTIONW = 1127;
        public const int BFFM_ENABLEOK = 1125;
        public const int BS_PUSHBUTTON = 0;
        public const int BS_DEFPUSHBUTTON = 1;
        public const int BS_MULTILINE = 8192;
        public const int BS_PUSHLIKE = 4096;
        public const int BS_OWNERDRAW = 11;
        public const int BS_RADIOBUTTON = 4;
        public const int BS_3STATE = 5;
        public const int BS_GROUPBOX = 7;
        public const int BS_LEFT = 256;
        public const int BS_RIGHT = 512;
        public const int BS_CENTER = 768;
        public const int BS_TOP = 1024;
        public const int BS_BOTTOM = 2048;
        public const int BS_VCENTER = 3072;
        public const int BS_RIGHTBUTTON = 32;
        public const int BN_CLICKED = 0;
        public const int BM_SETCHECK = 241;
        public const int BM_SETSTATE = 243;
        public const int BM_CLICK = 245;
        public const int CDERR_DIALOGFAILURE = 65535;
        public const int CDERR_STRUCTSIZE = 1;
        public const int CDERR_INITIALIZATION = 2;
        public const int CDERR_NOTEMPLATE = 3;
        public const int CDERR_NOHINSTANCE = 4;
        public const int CDERR_LOADSTRFAILURE = 5;
        public const int CDERR_FINDRESFAILURE = 6;
        public const int CDERR_LOADRESFAILURE = 7;
        public const int CDERR_LOCKRESFAILURE = 8;
        public const int CDERR_MEMALLOCFAILURE = 9;
        public const int CDERR_MEMLOCKFAILURE = 10;
        public const int CDERR_NOHOOK = 11;
        public const int CDERR_REGISTERMSGFAIL = 12;
        public const int CFERR_NOFONTS = 8193;
        public const int CFERR_MAXLESSTHANMIN = 8194;
        public const int CC_RGBINIT = 1;
        public const int CC_FULLOPEN = 2;
        public const int CC_PREVENTFULLOPEN = 4;
        public const int CC_SHOWHELP = 8;
        public const int CC_ENABLEHOOK = 16;
        public const int CC_SOLIDCOLOR = 128;
        public const int CC_ANYCOLOR = 256;
        public const int CF_SCREENFONTS = 1;
        public const int CF_SHOWHELP = 4;
        public const int CF_ENABLEHOOK = 8;
        public const int CF_INITTOLOGFONTSTRUCT = 64;
        public const int CF_EFFECTS = 256;
        public const int CF_APPLY = 512;
        public const int CF_SCRIPTSONLY = 1024;
        public const int CF_NOVECTORFONTS = 2048;
        public const int CF_NOSIMULATIONS = 4096;
        public const int CF_LIMITSIZE = 8192;
        public const int CF_FIXEDPITCHONLY = 16384;
        public const int CF_FORCEFONTEXIST = 65536;
        public const int CF_TTONLY = 262144;
        public const int CF_SELECTSCRIPT = 4194304;
        public const int CF_NOVERTFONTS = 16777216;
        public const int CP_WINANSI = 1004;
        public const int cmb4 = 1139;
        public const int CS_DBLCLKS = 8;
        public const int CS_DROPSHADOW = 131072;
        public const int CS_SAVEBITS = 2048;
        public const int CF_TEXT = 1;
        public const int CF_BITMAP = 2;
        public const int CF_METAFILEPICT = 3;
        public const int CF_SYLK = 4;
        public const int CF_DIF = 5;
        public const int CF_TIFF = 6;
        public const int CF_OEMTEXT = 7;
        public const int CF_DIB = 8;
        public const int CF_PALETTE = 9;
        public const int CF_PENDATA = 10;
        public const int CF_RIFF = 11;
        public const int CF_WAVE = 12;
        public const int CF_UNICODETEXT = 13;
        public const int CF_ENHMETAFILE = 14;
        public const int CF_HDROP = 15;
        public const int CF_LOCALE = 16;
        public const int CLSCTX_INPROC_SERVER = 1;
        public const int CLSCTX_LOCAL_SERVER = 4;
        public const int CW_USEDEFAULT = -2147483648;
        public const int CWP_SKIPINVISIBLE = 1;
        public const int COLOR_WINDOW = 5;
        public const int CB_ERR = -1;
        public const int CBN_SELCHANGE = 1;
        public const int CBN_DBLCLK = 2;
        public const int CBN_EDITCHANGE = 5;
        public const int CBN_EDITUPDATE = 6;
        public const int CBN_DROPDOWN = 7;
        public const int CBN_CLOSEUP = 8;
        public const int CBN_SELENDOK = 9;
        public const int CBS_SIMPLE = 1;
        public const int CBS_DROPDOWN = 2;
        public const int CBS_DROPDOWNLIST = 3;
        public const int CBS_OWNERDRAWFIXED = 16;
        public const int CBS_OWNERDRAWVARIABLE = 32;
        public const int CBS_AUTOHSCROLL = 64;
        public const int CBS_HASSTRINGS = 512;
        public const int CBS_NOINTEGRALHEIGHT = 1024;
        public const int CB_GETEDITSEL = 320;
        public const int CB_LIMITTEXT = 321;
        public const int CB_SETEDITSEL = 322;
        public const int CB_ADDSTRING = 323;
        public const int CB_DELETESTRING = 324;
        public const int CB_GETCURSEL = 327;
        public const int CB_GETLBTEXT = 328;
        public const int CB_GETLBTEXTLEN = 329;
        public const int CB_INSERTSTRING = 330;
        public const int CB_RESETCONTENT = 331;
        public const int CB_FINDSTRING = 332;
        public const int CB_SETCURSEL = 334;
        public const int CB_SHOWDROPDOWN = 335;
        public const int CB_GETITEMDATA = 336;
        public const int CB_SETITEMHEIGHT = 339;
        public const int CB_GETITEMHEIGHT = 340;
        public const int CB_GETDROPPEDSTATE = 343;
        public const int CB_FINDSTRINGEXACT = 344;
        public const int CB_GETDROPPEDWIDTH = 351;
        public const int CB_SETDROPPEDWIDTH = 352;
        public const int CDRF_DODEFAULT = 0;
        public const int CDRF_NEWFONT = 2;
        public const int CDRF_SKIPDEFAULT = 4;
        public const int CDRF_NOTIFYPOSTPAINT = 16;
        public const int CDRF_NOTIFYITEMDRAW = 32;
        public const int CDRF_NOTIFYSUBITEMDRAW = 32;
        public const int CDDS_PREPAINT = 1;
        public const int CDDS_POSTPAINT = 2;
        public const int CDDS_ITEM = 65536;
        public const int CDDS_SUBITEM = 131072;
        public const int CDDS_ITEMPREPAINT = 65537;
        public const int CDDS_ITEMPOSTPAINT = 65538;
        public const int CDIS_SELECTED = 1;
        public const int CDIS_GRAYED = 2;
        public const int CDIS_DISABLED = 4;
        public const int CDIS_CHECKED = 8;
        public const int CDIS_FOCUS = 16;
        public const int CDIS_DEFAULT = 32;
        public const int CDIS_HOT = 64;
        public const int CDIS_MARKED = 128;
        public const int CDIS_INDETERMINATE = 256;
        public const int CDIS_SHOWKEYBOARDCUES = 512;
        public const int CLR_NONE = -1;
        public const int CLR_DEFAULT = -16777216;
        public const int CCM_SETVERSION = 8199;
        public const int CCM_GETVERSION = 8200;
        public const int CCS_NORESIZE = 4;
        public const int CCS_NOPARENTALIGN = 8;
        public const int CCS_NODIVIDER = 64;
        public const int CBEM_INSERTITEMA = 1025;
        public const int CBEM_GETITEMA = 1028;
        public const int CBEM_SETITEMA = 1029;
        public const int CBEM_INSERTITEMW = 1035;
        public const int CBEM_SETITEMW = 1036;
        public const int CBEM_GETITEMW = 1037;
        public const int CBEN_ENDEDITA = -805;
        public const int CBEN_ENDEDITW = -806;
        public const int CONNECT_E_NOCONNECTION = -2147220992;
        public const int CONNECT_E_CANNOTCONNECT = -2147220990;
        public const int CTRLINFO_EATS_RETURN = 1;
        public const int CTRLINFO_EATS_ESCAPE = 2;
        public const int CSIDL_DESKTOP = 0;
        public const int CSIDL_INTERNET = 1;
        public const int CSIDL_PROGRAMS = 2;
        public const int CSIDL_PERSONAL = 5;
        public const int CSIDL_FAVORITES = 6;
        public const int CSIDL_STARTUP = 7;
        public const int CSIDL_RECENT = 8;
        public const int CSIDL_SENDTO = 9;
        public const int CSIDL_STARTMENU = 11;
        public const int CSIDL_DESKTOPDIRECTORY = 16;
        public const int CSIDL_TEMPLATES = 21;
        public const int CSIDL_APPDATA = 26;
        public const int CSIDL_LOCAL_APPDATA = 28;
        public const int CSIDL_INTERNET_CACHE = 32;
        public const int CSIDL_COOKIES = 33;
        public const int CSIDL_HISTORY = 34;
        public const int CSIDL_COMMON_APPDATA = 35;
        public const int CSIDL_SYSTEM = 37;
        public const int CSIDL_PROGRAM_FILES = 38;
        public const int CSIDL_PROGRAM_FILES_COMMON = 43;
        public const int DUPLICATE = 6;
        public const int DISPID_UNKNOWN = -1;
        public const int DISPID_PROPERTYPUT = -3;
        public const int DISPATCH_METHOD = 1;
        public const int DISPATCH_PROPERTYGET = 2;
        public const int DISPATCH_PROPERTYPUT = 4;
        public const int DV_E_DVASPECT = -2147221397;
        public const int DISP_E_MEMBERNOTFOUND = -2147352573;
        public const int DISP_E_PARAMNOTFOUND = -2147352572;
        public const int DISP_E_EXCEPTION = -2147352567;
        public const int DEFAULT_GUI_FONT = 17;
        public const int DIB_RGB_COLORS = 0;
        public const int DRAGDROP_E_NOTREGISTERED = -2147221248;
        public const int DRAGDROP_E_ALREADYREGISTERED = -2147221247;
        public const int DUPLICATE_SAME_ACCESS = 2;
        public const int DFC_CAPTION = 1;
        public const int DFC_MENU = 2;
        public const int DFC_SCROLL = 3;
        public const int DFC_BUTTON = 4;
        public const int DFCS_CAPTIONCLOSE = 0;
        public const int DFCS_CAPTIONMIN = 1;
        public const int DFCS_CAPTIONMAX = 2;
        public const int DFCS_CAPTIONRESTORE = 3;
        public const int DFCS_CAPTIONHELP = 4;
        public const int DFCS_MENUARROW = 0;
        public const int DFCS_MENUCHECK = 1;
        public const int DFCS_MENUBULLET = 2;
        public const int DFCS_SCROLLUP = 0;
        public const int DFCS_SCROLLDOWN = 1;
        public const int DFCS_SCROLLLEFT = 2;
        public const int DFCS_SCROLLRIGHT = 3;
        public const int DFCS_SCROLLCOMBOBOX = 5;
        public const int DFCS_BUTTONCHECK = 0;
        public const int DFCS_BUTTONRADIO = 4;
        public const int DFCS_BUTTON3STATE = 8;
        public const int DFCS_BUTTONPUSH = 16;
        public const int DFCS_INACTIVE = 256;
        public const int DFCS_PUSHED = 512;
        public const int DFCS_CHECKED = 1024;
        public const int DFCS_FLAT = 16384;
        public const int DCX_WINDOW = 1;
        public const int DCX_CACHE = 2;
        public const int DCX_LOCKWINDOWUPDATE = 1024;
        public const int DCX_INTERSECTRGN = 128;
        public const int DI_NORMAL = 3;
        public const int DLGC_WANTARROWS = 1;
        public const int DLGC_WANTTAB = 2;
        public const int DLGC_WANTALLKEYS = 4;
        public const int DLGC_WANTCHARS = 128;
        public const int DLGC_WANTMESSAGE = 4;
        public const int DLGC_HASSETSEL = 8;
        public const int DTM_GETSYSTEMTIME = 4097;
        public const int DTM_SETSYSTEMTIME = 4098;
        public const int DTM_SETRANGE = 4100;
        public const int DTM_SETFORMATA = 4101;
        public const int DTM_SETFORMATW = 4146;
        public const int DTM_SETMCCOLOR = 4102;
        public const int DTM_GETMONTHCAL = 4104;
        public const int DTM_SETMCFONT = 4105;
        public const int DTS_UPDOWN = 1;
        public const int DTS_SHOWNONE = 2;
        public const int DTS_LONGDATEFORMAT = 4;
        public const int DTS_TIMEFORMAT = 9;
        public const int DTS_RIGHTALIGN = 32;
        public const int DTN_DATETIMECHANGE = -759;
        public const int DTN_USERSTRINGA = -758;
        public const int DTN_USERSTRINGW = -745;
        public const int DTN_WMKEYDOWNA = -757;
        public const int DTN_WMKEYDOWNW = -744;
        public const int DTN_FORMATA = -756;
        public const int DTN_FORMATW = -743;
        public const int DTN_FORMATQUERYA = -755;
        public const int DTN_FORMATQUERYW = -742;
        public const int DTN_DROPDOWN = -754;
        public const int DTN_CLOSEUP = -753;
        public const int DVASPECT_CONTENT = 1;
        public const int DVASPECT_TRANSPARENT = 32;
        public const int DVASPECT_OPAQUE = 16;
        public const int E_NOTIMPL = -2147467263;
        public const int E_OUTOFMEMORY = -2147024882;
        public const int E_INVALIDARG = -2147024809;
        public const int E_NOINTERFACE = -2147467262;
        public const int E_FAIL = -2147467259;
        public const int E_ABORT = -2147467260;
        public const int E_UNEXPECTED = -2147418113;
        public const int INET_E_DEFAULT_ACTION = -2146697199;
        public const int ETO_OPAQUE = 2;
        public const int ETO_CLIPPED = 4;
        public const int EMR_POLYTEXTOUTA = 96;
        public const int EMR_POLYTEXTOUTW = 97;
        public const int EDGE_RAISED = 5;
        public const int EDGE_SUNKEN = 10;
        public const int EDGE_ETCHED = 6;
        public const int EDGE_BUMP = 9;
        public const int ES_LEFT = 0;
        public const int ES_CENTER = 1;
        public const int ES_RIGHT = 2;
        public const int ES_MULTILINE = 4;
        public const int ES_UPPERCASE = 8;
        public const int ES_LOWERCASE = 16;
        public const int ES_AUTOVSCROLL = 64;
        public const int ES_AUTOHSCROLL = 128;
        public const int ES_NOHIDESEL = 256;
        public const int ES_READONLY = 2048;
        public const int ES_PASSWORD = 32;
        public const int EN_CHANGE = 768;
        public const int EN_UPDATE = 1024;
        public const int EN_HSCROLL = 1537;
        public const int EN_VSCROLL = 1538;
        public const int EN_ALIGN_LTR_EC = 1792;
        public const int EN_ALIGN_RTL_EC = 1793;
        public const int EC_LEFTMARGIN = 1;
        public const int EC_RIGHTMARGIN = 2;
        public const int EM_GETSEL = 176;
        public const int EM_SETSEL = 177;
        public const int EM_SCROLL = 181;
        public const int EM_SCROLLCARET = 183;
        public const int EM_GETMODIFY = 184;
        public const int EM_SETMODIFY = 185;
        public const int EM_GETLINECOUNT = 186;
        public const int EM_REPLACESEL = 194;
        public const int EM_GETLINE = 196;
        public const int EM_LIMITTEXT = 197;
        public const int EM_CANUNDO = 198;
        public const int EM_UNDO = 199;
        public const int EM_SETPASSWORDCHAR = 204;
        public const int EM_GETPASSWORDCHAR = 210;
        public const int EM_EMPTYUNDOBUFFER = 205;
        public const int EM_SETREADONLY = 207;
        public const int EM_SETMARGINS = 211;
        public const int EM_POSFROMCHAR = 214;
        public const int EM_CHARFROMPOS = 215;
        public const int EM_LINEFROMCHAR = 201;
        public const int EM_GETFIRSTVISIBLELINE = 206;
        public const int EM_LINEINDEX = 187;
        public const int ERROR_INVALID_HANDLE = 6;
        public const int ERROR_CLASS_ALREADY_EXISTS = 1410;
        public const int FNERR_SUBCLASSFAILURE = 12289;
        public const int FNERR_INVALIDFILENAME = 12290;
        public const int FNERR_BUFFERTOOSMALL = 12291;
        public const int FRERR_BUFFERLENGTHZERO = 16385;
        public const int FADF_BSTR = 256;
        public const int FADF_UNKNOWN = 512;
        public const int FADF_DISPATCH = 1024;
        public const int FADF_VARIANT = 2048;
        public const int FORMAT_MESSAGE_FROM_SYSTEM = 4096;
        public const int FORMAT_MESSAGE_IGNORE_INSERTS = 512;
        public const int FVIRTKEY = 1;
        public const int FSHIFT = 4;
        public const int FALT = 16;
        public const int GMEM_FIXED = 0;
        public const int GMEM_MOVEABLE = 2;
        public const int GMEM_NOCOMPACT = 16;
        public const int GMEM_NODISCARD = 32;
        public const int GMEM_ZEROINIT = 64;
        public const int GMEM_MODIFY = 128;
        public const int GMEM_DISCARDABLE = 256;
        public const int GMEM_NOT_BANKED = 4096;
        public const int GMEM_SHARE = 8192;
        public const int GMEM_DDESHARE = 8192;
        public const int GMEM_NOTIFY = 16384;
        public const int GMEM_LOWER = 4096;
        public const int GMEM_VALID_FLAGS = 32626;
        public const int GMEM_INVALID_HANDLE = 32768;
        public const int GHND = 66;
        public const int GPTR = 64;
        public const int GCL_WNDPROC = -24;
        public const int GWL_WNDPROC = -4;
        public const int GWL_HWNDPARENT = -8;
        public const int GWL_STYLE = -16;
        public const int GWL_EXSTYLE = -20;
        public const int GWL_ID = -12;
        public const int GW_HWNDFIRST = 0;
        public const int GW_HWNDLAST = 1;
        public const int GW_HWNDNEXT = 2;
        public const int GW_HWNDPREV = 3;
        public const int GW_CHILD = 5;
        public const int GMR_VISIBLE = 0;
        public const int GMR_DAYSTATE = 1;
        public const int GDI_ERROR = -1;
        public const int GDTR_MIN = 1;
        public const int GDTR_MAX = 2;
        public const int GDT_VALID = 0;
        public const int GDT_NONE = 1;
        public const int GA_PARENT = 1;
        public const int GA_ROOT = 2;
        public const int GCS_COMPSTR = 8;
        public const int GCS_COMPATTR = 16;
        public const int GCS_RESULTSTR = 2048;
        public const int ATTR_INPUT = 0;
        public const int ATTR_TARGET_CONVERTED = 1;
        public const int ATTR_CONVERTED = 2;
        public const int ATTR_TARGET_NOTCONVERTED = 3;
        public const int ATTR_INPUT_ERROR = 4;
        public const int ATTR_FIXEDCONVERTED = 5;
        public const int NI_COMPOSITIONSTR = 21;
        public const int CPS_COMPLETE = 1;
        public const int CPS_CANCEL = 4;
        public const int HC_ACTION = 0;
        public const int HC_GETNEXT = 1;
        public const int HC_SKIP = 2;
        public const int HTTRANSPARENT = -1;
        public const int HTNOWHERE = 0;
        public const int HTCLIENT = 1;
        public const int HTLEFT = 10;
        public const int HTBOTTOM = 15;
        public const int HTBOTTOMLEFT = 16;
        public const int HTBOTTOMRIGHT = 17;
        public const int HTBORDER = 18;
        public const int HELPINFO_WINDOW = 1;
        public const int HCF_HIGHCONTRASTON = 1;
        public const int HDI_ORDER = 128;
        public const int HDI_WIDTH = 1;
        public const int HDM_GETITEMCOUNT = 4608;
        public const int HDM_INSERTITEMA = 4609;
        public const int HDM_INSERTITEMW = 4618;
        public const int HDM_GETITEMA = 4611;
        public const int HDM_GETITEMW = 4619;
        public const int HDM_LAYOUT = 4613;
        public const int HDM_SETITEMA = 4612;
        public const int HDM_SETITEMW = 4620;
        public const int HDN_ITEMCHANGINGA = -300;
        public const int HDN_ITEMCHANGINGW = -320;
        public const int HDN_ITEMCHANGEDA = -301;
        public const int HDN_ITEMCHANGEDW = -321;
        public const int HDN_ITEMCLICKA = -302;
        public const int HDN_ITEMCLICKW = -322;
        public const int HDN_ITEMDBLCLICKA = -303;
        public const int HDN_ITEMDBLCLICKW = -323;
        public const int HDN_DIVIDERDBLCLICKA = -305;
        public const int HDN_DIVIDERDBLCLICKW = -325;
        public const int HDN_BEGINTDRAG = -310;
        public const int HDN_BEGINTRACKA = -306;
        public const int HDN_BEGINTRACKW = -326;
        public const int HDN_ENDDRAG = -311;
        public const int HDN_ENDTRACKA = -307;
        public const int HDN_ENDTRACKW = -327;
        public const int HDN_TRACKA = -308;
        public const int HDN_TRACKW = -328;
        public const int HDN_GETDISPINFOA = -309;
        public const int HDN_GETDISPINFOW = -329;
        public const int HDS_FULLDRAG = 128;
        public const int HBMMENU_CALLBACK = -1;
        public const int HBMMENU_SYSTEM = 1;
        public const int HBMMENU_MBAR_RESTORE = 2;
        public const int HBMMENU_MBAR_MINIMIZE = 3;
        public const int HBMMENU_MBAR_CLOSE = 5;
        public const int HBMMENU_MBAR_CLOSE_D = 6;
        public const int HBMMENU_MBAR_MINIMIZE_D = 7;
        public const int HBMMENU_POPUP_CLOSE = 8;
        public const int HBMMENU_POPUP_RESTORE = 9;
        public const int HBMMENU_POPUP_MAXIMIZE = 10;
        public const int HBMMENU_POPUP_MINIMIZE = 11;
        public static HandleRef HWND_TOP;
        public static HandleRef HWND_BOTTOM;
        public static HandleRef HWND_TOPMOST;
        public static HandleRef HWND_NOTOPMOST;
        public static HandleRef HWND_MESSAGE;
        public const int IME_CMODE_NATIVE = 1;
        public const int IME_CMODE_KATAKANA = 2;
        public const int IME_CMODE_FULLSHAPE = 8;
        public const int INPLACE_E_NOTOOLSPACE = -2147221087;
        public const int ICON_SMALL = 0;
        public const int ICON_BIG = 1;
        public const int IDC_ARROW = 32512;
        public const int IDC_IBEAM = 32513;
        public const int IDC_WAIT = 32514;
        public const int IDC_CROSS = 32515;
        public const int IDC_SIZEALL = 32646;
        public const int IDC_SIZENWSE = 32642;
        public const int IDC_SIZENESW = 32643;
        public const int IDC_SIZEWE = 32644;
        public const int IDC_SIZENS = 32645;
        public const int IDC_UPARROW = 32516;
        public const int IDC_NO = 32648;
        public const int IDC_APPSTARTING = 32650;
        public const int IDC_HELP = 32651;
        public const int IMAGE_ICON = 1;
        public const int IMAGE_CURSOR = 2;
        public const int ICC_LISTVIEW_CLASSES = 1;
        public const int ICC_TREEVIEW_CLASSES = 2;
        public const int ICC_BAR_CLASSES = 4;
        public const int ICC_TAB_CLASSES = 8;
        public const int ICC_PROGRESS_CLASS = 32;
        public const int ICC_DATE_CLASSES = 256;
        public const int ILC_MASK = 1;
        public const int ILC_COLOR = 0;
        public const int ILC_COLOR4 = 4;
        public const int ILC_COLOR8 = 8;
        public const int ILC_COLOR16 = 16;
        public const int ILC_COLOR24 = 24;
        public const int ILC_COLOR32 = 32;
        public const int ILC_MIRROR = 8192;
        public const int ILD_NORMAL = 0;
        public const int ILD_TRANSPARENT = 1;
        public const int ILD_MASK = 16;
        public const int ILD_ROP = 64;
        public const int ILP_NORMAL = 0;
        public const int ILP_DOWNLEVEL = 1;
        public const int ILS_NORMAL = 0;
        public const int ILS_GLOW = 1;
        public const int ILS_SHADOW = 2;
        public const int ILS_SATURATE = 4;
        public const int ILS_ALPHA = 8;
        public const int IDM_PRINT = 27;
        public const int IDM_PAGESETUP = 2004;
        public const int IDM_PRINTPREVIEW = 2003;
        public const int IDM_PROPERTIES = 28;
        public const int IDM_SAVEAS = 71;
        public const int CSC_NAVIGATEFORWARD = 1;
        public const int CSC_NAVIGATEBACK = 2;
        public const int STG_E_INVALIDFUNCTION = -2147287039;
        public const int STG_E_FILENOTFOUND = -2147287038;
        public const int STG_E_PATHNOTFOUND = -2147287037;
        public const int STG_E_TOOMANYOPENFILES = -2147287036;
        public const int STG_E_ACCESSDENIED = -2147287035;
        public const int STG_E_INVALIDHANDLE = -2147287034;
        public const int STG_E_INSUFFICIENTMEMORY = -2147287032;
        public const int STG_E_INVALIDPOINTER = -2147287031;
        public const int STG_E_NOMOREFILES = -2147287022;
        public const int STG_E_DISKISWRITEPROTECTED = -2147287021;
        public const int STG_E_SEEKERROR = -2147287015;
        public const int STG_E_WRITEFAULT = -2147287011;
        public const int STG_E_READFAULT = -2147287010;
        public const int STG_E_SHAREVIOLATION = -2147287008;
        public const int STG_E_LOCKVIOLATION = -2147287007;
        public const int INPUT_KEYBOARD = 1;
        public const int KEYEVENTF_EXTENDEDKEY = 1;
        public const int KEYEVENTF_KEYUP = 2;
        public const int KEYEVENTF_UNICODE = 4;
        public const int LOGPIXELSX = 88;
        public const int LOGPIXELSY = 90;
        public const int LB_ERR = -1;
        public const int LB_ERRSPACE = -2;
        public const int LBN_SELCHANGE = 1;
        public const int LBN_DBLCLK = 2;
        public const int LB_ADDSTRING = 384;
        public const int LB_INSERTSTRING = 385;
        public const int LB_DELETESTRING = 386;
        public const int LB_RESETCONTENT = 388;
        public const int LB_SETSEL = 389;
        public const int LB_SETCURSEL = 390;
        public const int LB_GETSEL = 391;
        public const int LB_GETCARETINDEX = 415;
        public const int LB_GETCURSEL = 392;
        public const int LB_GETTEXT = 393;
        public const int LB_GETTEXTLEN = 394;
        public const int LB_GETTOPINDEX = 398;
        public const int LB_FINDSTRING = 399;
        public const int LB_GETSELCOUNT = 400;
        public const int LB_GETSELITEMS = 401;
        public const int LB_SETTABSTOPS = 402;
        public const int LB_SETHORIZONTALEXTENT = 404;
        public const int LB_SETCOLUMNWIDTH = 405;
        public const int LB_SETTOPINDEX = 407;
        public const int LB_GETITEMRECT = 408;
        public const int LB_SETITEMHEIGHT = 416;
        public const int LB_GETITEMHEIGHT = 417;
        public const int LB_FINDSTRINGEXACT = 418;
        public const int LB_ITEMFROMPOINT = 425;
        public const int LB_SETLOCALE = 421;
        public const int LBS_NOTIFY = 1;
        public const int LBS_MULTIPLESEL = 8;
        public const int LBS_OWNERDRAWFIXED = 16;
        public const int LBS_OWNERDRAWVARIABLE = 32;
        public const int LBS_HASSTRINGS = 64;
        public const int LBS_USETABSTOPS = 128;
        public const int LBS_NOINTEGRALHEIGHT = 256;
        public const int LBS_MULTICOLUMN = 512;
        public const int LBS_WANTKEYBOARDINPUT = 1024;
        public const int LBS_EXTENDEDSEL = 2048;
        public const int LBS_DISABLENOSCROLL = 4096;
        public const int LBS_NOSEL = 16384;
        public const int LOCK_WRITE = 1;
        public const int LOCK_EXCLUSIVE = 2;
        public const int LOCK_ONLYONCE = 4;
        public const int LV_VIEW_TILE = 4;
        public const int LVBKIF_SOURCE_NONE = 0;
        public const int LVBKIF_SOURCE_URL = 2;
        public const int LVBKIF_STYLE_NORMAL = 0;
        public const int LVBKIF_STYLE_TILE = 16;
        public const int LVS_ICON = 0;
        public const int LVS_REPORT = 1;
        public const int LVS_SMALLICON = 2;
        public const int LVS_LIST = 3;
        public const int LVS_SINGLESEL = 4;
        public const int LVS_SHOWSELALWAYS = 8;
        public const int LVS_SORTASCENDING = 16;
        public const int LVS_SORTDESCENDING = 32;
        public const int LVS_SHAREIMAGELISTS = 64;
        public const int LVS_NOLABELWRAP = 128;
        public const int LVS_AUTOARRANGE = 256;
        public const int LVS_EDITLABELS = 512;
        public const int LVS_NOSCROLL = 8192;
        public const int LVS_ALIGNTOP = 0;
        public const int LVS_ALIGNLEFT = 2048;
        public const int LVS_NOCOLUMNHEADER = 16384;
        public const int LVS_NOSORTHEADER = 32768;
        public const int LVS_OWNERDATA = 4096;
        public const int LVSCW_AUTOSIZE = -1;
        public const int LVSCW_AUTOSIZE_USEHEADER = -2;
        public const int LVM_REDRAWITEMS = 4117;
        public const int LVM_SCROLL = 4116;
        public const int LVM_SETBKCOLOR = 4097;
        public const int LVM_SETBKIMAGEA = 4164;
        public const int LVM_SETBKIMAGEW = 4234;
        public const int LVM_SETCALLBACKMASK = 4107;
        public const int LVM_GETCALLBACKMASK = 4106;
        public const int LVM_GETCOLUMNORDERARRAY = 4155;
        public const int LVM_GETITEMCOUNT = 4100;
        public const int LVM_SETCOLUMNORDERARRAY = 4154;
        public const int LVM_SETINFOTIP = 4269;
        public const int LVSIL_NORMAL = 0;
        public const int LVSIL_SMALL = 1;
        public const int LVSIL_STATE = 2;
        public const int LVM_SETIMAGELIST = 4099;
        public const int LVM_SETSELECTIONMARK = 4163;
        public const int LVM_SETTOOLTIPS = 4170;
        public const int LVIF_TEXT = 1;
        public const int LVIF_IMAGE = 2;
        public const int LVIF_INDENT = 16;
        public const int LVIF_PARAM = 4;
        public const int LVIF_STATE = 8;
        public const int LVIF_GROUPID = 256;
        public const int LVIF_COLUMNS = 512;
        public const int LVIS_FOCUSED = 1;
        public const int LVIS_SELECTED = 2;
        public const int LVIS_CUT = 4;
        public const int LVIS_DROPHILITED = 8;
        public const int LVIS_OVERLAYMASK = 3840;
        public const int LVIS_STATEIMAGEMASK = 61440;
        public const int LVM_GETITEMA = 4101;
        public const int LVM_GETITEMW = 4171;
        public const int LVM_SETITEMA = 4102;
        public const int LVM_SETITEMW = 4172;
        public const int LVM_SETITEMPOSITION32 = 4145;
        public const int LVM_INSERTITEMA = 4103;
        public const int LVM_INSERTITEMW = 4173;
        public const int LVM_DELETEITEM = 4104;
        public const int LVM_DELETECOLUMN = 4124;
        public const int LVM_DELETEALLITEMS = 4105;
        public const int LVM_UPDATE = 4138;
        public const int LVNI_FOCUSED = 1;
        public const int LVNI_SELECTED = 2;
        public const int LVM_GETNEXTITEM = 4108;
        public const int LVFI_PARAM = 1;
        public const int LVFI_NEARESTXY = 64;
        public const int LVFI_PARTIAL = 8;
        public const int LVFI_STRING = 2;
        public const int LVM_FINDITEMA = 4109;
        public const int LVM_FINDITEMW = 4179;
        public const int LVIR_BOUNDS = 0;
        public const int LVIR_ICON = 1;
        public const int LVIR_LABEL = 2;
        public const int LVIR_SELECTBOUNDS = 3;
        public const int LVM_GETITEMPOSITION = 4112;
        public const int LVM_GETITEMRECT = 4110;
        public const int LVM_GETSUBITEMRECT = 4152;
        public const int LVM_GETSTRINGWIDTHA = 4113;
        public const int LVM_GETSTRINGWIDTHW = 4183;
        public const int LVHT_NOWHERE = 1;
        public const int LVHT_ONITEMICON = 2;
        public const int LVHT_ONITEMLABEL = 4;
        public const int LVHT_ABOVE = 8;
        public const int LVHT_BELOW = 16;
        public const int LVHT_RIGHT = 32;
        public const int LVHT_LEFT = 64;
        public const int LVHT_ONITEM = 14;
        public const int LVHT_ONITEMSTATEICON = 8;
        public const int LVM_SUBITEMHITTEST = 4153;
        public const int LVM_HITTEST = 4114;
        public const int LVM_ENSUREVISIBLE = 4115;
        public const int LVA_DEFAULT = 0;
        public const int LVA_ALIGNLEFT = 1;
        public const int LVA_ALIGNTOP = 2;
        public const int LVA_SNAPTOGRID = 5;
        public const int LVM_ARRANGE = 4118;
        public const int LVM_EDITLABELA = 4119;
        public const int LVM_EDITLABELW = 4214;
        public const int LVCDI_ITEM = 0;
        public const int LVCDI_GROUP = 1;
        public const int LVCF_FMT = 1;
        public const int LVCF_WIDTH = 2;
        public const int LVCF_TEXT = 4;
        public const int LVCF_SUBITEM = 8;
        public const int LVCF_IMAGE = 16;
        public const int LVCF_ORDER = 32;
        public const int LVCFMT_IMAGE = 2048;
        public const int LVGA_HEADER_LEFT = 1;
        public const int LVGA_HEADER_CENTER = 2;
        public const int LVGA_HEADER_RIGHT = 4;
        public const int LVGA_FOOTER_LEFT = 8;
        public const int LVGA_FOOTER_CENTER = 16;
        public const int LVGA_FOOTER_RIGHT = 32;
        public const int LVGF_NONE = 0;
        public const int LVGF_HEADER = 1;
        public const int LVGF_FOOTER = 2;
        public const int LVGF_STATE = 4;
        public const int LVGF_ALIGN = 8;
        public const int LVGF_GROUPID = 16;
        public const int LVGS_NORMAL = 0;
        public const int LVGS_COLLAPSED = 1;
        public const int LVGS_HIDDEN = 2;
        public const int LVIM_AFTER = 1;
        public const int LVTVIF_FIXEDSIZE = 3;
        public const int LVTVIM_TILESIZE = 1;
        public const int LVTVIM_COLUMNS = 2;
        public const int LVM_ENABLEGROUPVIEW = 4253;
        public const int LVM_MOVEITEMTOGROUP = 4250;
        public const int LVM_GETCOLUMNA = 4121;
        public const int LVM_GETCOLUMNW = 4191;
        public const int LVM_SETCOLUMNA = 4122;
        public const int LVM_SETCOLUMNW = 4192;
        public const int LVM_INSERTCOLUMNA = 4123;
        public const int LVM_INSERTCOLUMNW = 4193;
        public const int LVM_INSERTGROUP = 4241;
        public const int LVM_REMOVEGROUP = 4246;
        public const int LVM_INSERTMARKHITTEST = 4264;
        public const int LVM_REMOVEALLGROUPS = 4256;
        public const int LVM_GETCOLUMNWIDTH = 4125;
        public const int LVM_SETCOLUMNWIDTH = 4126;
        public const int LVM_SETINSERTMARK = 4262;
        public const int LVM_GETHEADER = 4127;
        public const int LVM_SETTEXTCOLOR = 4132;
        public const int LVM_SETTEXTBKCOLOR = 4134;
        public const int LVM_GETTOPINDEX = 4135;
        public const int LVM_SETITEMPOSITION = 4111;
        public const int LVM_SETITEMSTATE = 4139;
        public const int LVM_GETITEMSTATE = 4140;
        public const int LVM_GETITEMTEXTA = 4141;
        public const int LVM_GETITEMTEXTW = 4211;
        public const int LVM_GETHOTITEM = 4157;
        public const int LVM_SETITEMTEXTA = 4142;
        public const int LVM_SETITEMTEXTW = 4212;
        public const int LVM_SETITEMCOUNT = 4143;
        public const int LVM_SORTITEMS = 4144;
        public const int LVM_GETSELECTEDCOUNT = 4146;
        public const int LVM_GETISEARCHSTRINGA = 4148;
        public const int LVM_GETISEARCHSTRINGW = 4213;
        public const int LVM_SETEXTENDEDLISTVIEWSTYLE = 4150;
        public const int LVM_SETVIEW = 4238;
        public const int LVM_GETGROUPINFO = 4245;
        public const int LVM_SETGROUPINFO = 4243;
        public const int LVM_HASGROUP = 4257;
        public const int LVM_SETTILEVIEWINFO = 4258;
        public const int LVM_GETTILEVIEWINFO = 4259;
        public const int LVM_GETINSERTMARK = 4263;
        public const int LVM_GETINSERTMARKRECT = 4265;
        public const int LVM_SETINSERTMARKCOLOR = 4266;
        public const int LVM_GETINSERTMARKCOLOR = 4267;
        public const int LVM_ISGROUPVIEWENABLED = 4271;
        public const int LVS_EX_GRIDLINES = 1;
        public const int LVS_EX_CHECKBOXES = 4;
        public const int LVS_EX_TRACKSELECT = 8;
        public const int LVS_EX_HEADERDRAGDROP = 16;
        public const int LVS_EX_FULLROWSELECT = 32;
        public const int LVS_EX_ONECLICKACTIVATE = 64;
        public const int LVS_EX_TWOCLICKACTIVATE = 128;
        public const int LVS_EX_INFOTIP = 1024;
        public const int LVS_EX_UNDERLINEHOT = 2048;
        public const int LVS_EX_DOUBLEBUFFER = 65536;
        public const int LVN_ITEMCHANGING = -100;
        public const int LVN_ITEMCHANGED = -101;
        public const int LVN_BEGINLABELEDITA = -105;
        public const int LVN_BEGINLABELEDITW = -175;
        public const int LVN_ENDLABELEDITA = -106;
        public const int LVN_ENDLABELEDITW = -176;
        public const int LVN_COLUMNCLICK = -108;
        public const int LVN_BEGINDRAG = -109;
        public const int LVN_BEGINRDRAG = -111;
        public const int LVN_ODFINDITEMA = -152;
        public const int LVN_ODFINDITEMW = -179;
        public const int LVN_ITEMACTIVATE = -114;
        public const int LVN_GETDISPINFOA = -150;
        public const int LVN_GETDISPINFOW = -177;
        public const int LVN_ODCACHEHINT = -113;
        public const int LVN_ODSTATECHANGED = -115;
        public const int LVN_SETDISPINFOA = -151;
        public const int LVN_SETDISPINFOW = -178;
        public const int LVN_GETINFOTIPA = -157;
        public const int LVN_GETINFOTIPW = -158;
        public const int LVN_KEYDOWN = -155;
        public const int LWA_COLORKEY = 1;
        public const int LWA_ALPHA = 2;
        public const int LANG_NEUTRAL = 0;
        public const int LOCALE_IFIRSTDAYOFWEEK = 4108;
        public const int LOCALE_IMEASURE = 13;
        public static readonly int LOCALE_USER_DEFAULT;
        public static readonly int LANG_USER_DEFAULT;
        public const int MEMBERID_NIL = -1;
        public const int MAX_PATH = 260;
        public const int MA_ACTIVATE = 1;
        public const int MA_ACTIVATEANDEAT = 2;
        public const int MA_NOACTIVATE = 3;
        public const int MA_NOACTIVATEANDEAT = 4;
        public const int MM_TEXT = 1;
        public const int MM_ANISOTROPIC = 8;
        public const int MK_LBUTTON = 1;
        public const int MK_RBUTTON = 2;
        public const int MK_SHIFT = 4;
        public const int MK_CONTROL = 8;
        public const int MK_MBUTTON = 16;
        public const int MNC_EXECUTE = 2;
        public const int MNC_SELECT = 3;
        public const int MIIM_STATE = 1;
        public const int MIIM_ID = 2;
        public const int MIIM_SUBMENU = 4;
        public const int MIIM_TYPE = 16;
        public const int MIIM_DATA = 32;
        public const int MIIM_STRING = 64;
        public const int MIIM_BITMAP = 128;
        public const int MIIM_FTYPE = 256;
        public const int MB_OK = 0;
        public const int MF_BYCOMMAND = 0;
        public const int MF_BYPOSITION = 1024;
        public const int MF_ENABLED = 0;
        public const int MF_GRAYED = 1;
        public const int MF_POPUP = 16;
        public const int MF_SYSMENU = 8192;
        public const int MFS_DISABLED = 3;
        public const int MFT_MENUBREAK = 64;
        public const int MFT_SEPARATOR = 2048;
        public const int MFT_RIGHTORDER = 8192;
        public const int MFT_RIGHTJUSTIFY = 16384;
        public const int MDIS_ALLCHILDSTYLES = 1;
        public const int MDITILE_VERTICAL = 0;
        public const int MDITILE_HORIZONTAL = 1;
        public const int MDITILE_SKIPDISABLED = 2;
        public const int MCM_SETMAXSELCOUNT = 4100;
        public const int MCM_SETSELRANGE = 4102;
        public const int MCM_GETMONTHRANGE = 4103;
        public const int MCM_GETMINREQRECT = 4105;
        public const int MCM_SETCOLOR = 4106;
        public const int MCM_SETTODAY = 4108;
        public const int MCM_GETTODAY = 4109;
        public const int MCM_HITTEST = 4110;
        public const int MCM_SETFIRSTDAYOFWEEK = 4111;
        public const int MCM_SETRANGE = 4114;
        public const int MCM_SETMONTHDELTA = 4116;
        public const int MCM_GETMAXTODAYWIDTH = 4117;
        public const int MCHT_TITLE = 65536;
        public const int MCHT_CALENDAR = 131072;
        public const int MCHT_TODAYLINK = 196608;
        public const int MCHT_TITLEBK = 65536;
        public const int MCHT_TITLEMONTH = 65537;
        public const int MCHT_TITLEYEAR = 65538;
        public const int MCHT_TITLEBTNNEXT = 16842755;
        public const int MCHT_TITLEBTNPREV = 33619971;
        public const int MCHT_CALENDARBK = 131072;
        public const int MCHT_CALENDARDATE = 131073;
        public const int MCHT_CALENDARDATENEXT = 16908289;
        public const int MCHT_CALENDARDATEPREV = 33685505;
        public const int MCHT_CALENDARDAY = 131074;
        public const int MCHT_CALENDARWEEKNUM = 131075;
        public const int MCSC_TEXT = 1;
        public const int MCSC_TITLEBK = 2;
        public const int MCSC_TITLETEXT = 3;
        public const int MCSC_MONTHBK = 4;
        public const int MCSC_TRAILINGTEXT = 5;
        public const int MCN_SELCHANGE = -749;
        public const int MCN_GETDAYSTATE = -747;
        public const int MCN_SELECT = -746;
        public const int MCS_DAYSTATE = 1;
        public const int MCS_MULTISELECT = 2;
        public const int MCS_WEEKNUMBERS = 4;
        public const int MCS_NOTODAYCIRCLE = 8;
        public const int MCS_NOTODAY = 16;
        public const int MSAA_MENU_SIG = -1441927155;
        public const int NIM_ADD = 0;
        public const int NIM_MODIFY = 1;
        public const int NIM_DELETE = 2;
        public const int NIF_MESSAGE = 1;
        public const int NIM_SETVERSION = 4;
        public const int NIF_ICON = 2;
        public const int NIF_INFO = 16;
        public const int NIF_TIP = 4;
        public const int NIIF_NONE = 0;
        public const int NIIF_INFO = 1;
        public const int NIIF_WARNING = 2;
        public const int NIIF_ERROR = 3;
        public const int NIN_BALLOONSHOW = 1026;
        public const int NIN_BALLOONHIDE = 1027;
        public const int NIN_BALLOONTIMEOUT = 1028;
        public const int NIN_BALLOONUSERCLICK = 1029;
        public const int NFR_ANSI = 1;
        public const int NFR_UNICODE = 2;
        public const int NM_CLICK = -2;
        public const int NM_DBLCLK = -3;
        public const int NM_RCLICK = -5;
        public const int NM_RDBLCLK = -6;
        public const int NM_CUSTOMDRAW = -12;
        public const int NM_RELEASEDCAPTURE = -16;
        public const int NONANTIALIASED_QUALITY = 3;
        public const int OFN_READONLY = 1;
        public const int OFN_OVERWRITEPROMPT = 2;
        public const int OFN_HIDEREADONLY = 4;
        public const int OFN_NOCHANGEDIR = 8;
        public const int OFN_SHOWHELP = 16;
        public const int OFN_ENABLEHOOK = 32;
        public const int OFN_NOVALIDATE = 256;
        public const int OFN_ALLOWMULTISELECT = 512;
        public const int OFN_PATHMUSTEXIST = 2048;
        public const int OFN_FILEMUSTEXIST = 4096;
        public const int OFN_CREATEPROMPT = 8192;
        public const int OFN_EXPLORER = 524288;
        public const int OFN_NODEREFERENCELINKS = 1048576;
        public const int OFN_ENABLESIZING = 8388608;
        public const int OFN_USESHELLITEM = 16777216;
        public const int OLEIVERB_PRIMARY = 0;
        public const int OLEIVERB_SHOW = -1;
        public const int OLEIVERB_HIDE = -3;
        public const int OLEIVERB_UIACTIVATE = -4;
        public const int OLEIVERB_INPLACEACTIVATE = -5;
        public const int OLEIVERB_DISCARDUNDOSTATE = -6;
        public const int OLEIVERB_PROPERTIES = -7;
        public const int OLE_E_INVALIDRECT = -2147221491;
        public const int OLE_E_NOCONNECTION = -2147221500;
        public const int OLE_E_PROMPTSAVECANCELLED = -2147221492;
        public const int OLEMISC_RECOMPOSEONRESIZE = 1;
        public const int OLEMISC_INSIDEOUT = 128;
        public const int OLEMISC_ACTIVATEWHENVISIBLE = 256;
        public const int OLEMISC_ACTSLIKEBUTTON = 4096;
        public const int OLEMISC_SETCLIENTSITEFIRST = 131072;
        public const int OBJ_PEN = 1;
        public const int OBJ_BRUSH = 2;
        public const int OBJ_DC = 3;
        public const int OBJ_METADC = 4;
        public const int OBJ_PAL = 5;
        public const int OBJ_FONT = 6;
        public const int OBJ_BITMAP = 7;
        public const int OBJ_REGION = 8;
        public const int OBJ_METAFILE = 9;
        public const int OBJ_MEMDC = 10;
        public const int OBJ_EXTPEN = 11;
        public const int OBJ_ENHMETADC = 12;
        public const int ODS_CHECKED = 8;
        public const int ODS_COMBOBOXEDIT = 4096;
        public const int ODS_DEFAULT = 32;
        public const int ODS_DISABLED = 4;
        public const int ODS_FOCUS = 16;
        public const int ODS_GRAYED = 2;
        public const int ODS_HOTLIGHT = 64;
        public const int ODS_INACTIVE = 128;
        public const int ODS_NOACCEL = 256;
        public const int ODS_NOFOCUSRECT = 512;
        public const int ODS_SELECTED = 1;
        public const int OLECLOSE_SAVEIFDIRTY = 0;
        public const int OLECLOSE_PROMPTSAVE = 2;
        public const int PDERR_SETUPFAILURE = 4097;
        public const int PDERR_PARSEFAILURE = 4098;
        public const int PDERR_RETDEFFAILURE = 4099;
        public const int PDERR_LOADDRVFAILURE = 4100;
        public const int PDERR_GETDEVMODEFAIL = 4101;
        public const int PDERR_INITFAILURE = 4102;
        public const int PDERR_NODEVICES = 4103;
        public const int PDERR_NODEFAULTPRN = 4104;
        public const int PDERR_DNDMMISMATCH = 4105;
        public const int PDERR_CREATEICFAILURE = 4106;
        public const int PDERR_PRINTERNOTFOUND = 4107;
        public const int PDERR_DEFAULTDIFFERENT = 4108;
        public const int PD_ALLPAGES = 0;
        public const int PD_SELECTION = 1;
        public const int PD_PAGENUMS = 2;
        public const int PD_NOSELECTION = 4;
        public const int PD_NOPAGENUMS = 8;
        public const int PD_COLLATE = 16;
        public const int PD_PRINTTOFILE = 32;
        public const int PD_PRINTSETUP = 64;
        public const int PD_NOWARNING = 128;
        public const int PD_RETURNDC = 256;
        public const int PD_RETURNIC = 512;
        public const int PD_RETURNDEFAULT = 1024;
        public const int PD_SHOWHELP = 2048;
        public const int PD_ENABLEPRINTHOOK = 4096;
        public const int PD_ENABLESETUPHOOK = 8192;
        public const int PD_ENABLEPRINTTEMPLATE = 16384;
        public const int PD_ENABLESETUPTEMPLATE = 32768;
        public const int PD_ENABLEPRINTTEMPLATEHANDLE = 65536;
        public const int PD_ENABLESETUPTEMPLATEHANDLE = 131072;
        public const int PD_USEDEVMODECOPIES = 262144;
        public const int PD_USEDEVMODECOPIESANDCOLLATE = 262144;
        public const int PD_DISABLEPRINTTOFILE = 524288;
        public const int PD_HIDEPRINTTOFILE = 1048576;
        public const int PD_NONETWORKBUTTON = 2097152;
        public const int PD_CURRENTPAGE = 4194304;
        public const int PD_NOCURRENTPAGE = 8388608;
        public const int PD_EXCLUSIONFLAGS = 16777216;
        public const int PD_USELARGETEMPLATE = 268435456;
        public const int PSD_MINMARGINS = 1;
        public const int PSD_MARGINS = 2;
        public const int PSD_INHUNDREDTHSOFMILLIMETERS = 8;
        public const int PSD_DISABLEMARGINS = 16;
        public const int PSD_DISABLEPRINTER = 32;
        public const int PSD_DISABLEORIENTATION = 256;
        public const int PSD_DISABLEPAPER = 512;
        public const int PSD_SHOWHELP = 2048;
        public const int PSD_ENABLEPAGESETUPHOOK = 8192;
        public const int PSD_NONETWORKBUTTON = 2097152;
        public const int PS_SOLID = 0;
        public const int PS_DOT = 2;
        public const int PLANES = 14;
        public const int PRF_CHECKVISIBLE = 1;
        public const int PRF_NONCLIENT = 2;
        public const int PRF_CLIENT = 4;
        public const int PRF_ERASEBKGND = 8;
        public const int PRF_CHILDREN = 16;
        public const int PM_NOREMOVE = 0;
        public const int PM_REMOVE = 1;
        public const int PM_NOYIELD = 2;
        public const int PBM_SETRANGE = 1025;
        public const int PBM_SETPOS = 1026;
        public const int PBM_SETSTEP = 1028;
        public const int PBM_SETRANGE32 = 1030;
        public const int PBM_SETBARCOLOR = 1033;
        public const int PBM_SETMARQUEE = 1034;
        public const int PBM_SETBKCOLOR = 8193;
        public const int PSM_SETTITLEA = 1135;
        public const int PSM_SETTITLEW = 1144;
        public const int PSM_SETFINISHTEXTA = 1139;
        public const int PSM_SETFINISHTEXTW = 1145;
        public const int PATCOPY = 15728673;
        public const int PATINVERT = 5898313;
        public const int PBS_SMOOTH = 1;
        public const int PBS_MARQUEE = 8;
        public const int QS_KEY = 1;
        public const int QS_MOUSEMOVE = 2;
        public const int QS_MOUSEBUTTON = 4;
        public const int QS_POSTMESSAGE = 8;
        public const int QS_TIMER = 16;
        public const int QS_PAINT = 32;
        public const int QS_SENDMESSAGE = 64;
        public const int QS_HOTKEY = 128;
        public const int QS_ALLPOSTMESSAGE = 256;
        public const int QS_MOUSE = 6;
        public const int QS_INPUT = 7;
        public const int QS_ALLEVENTS = 191;
        public const int QS_ALLINPUT = 255;
        public const int MWMO_INPUTAVAILABLE = 4;
        public const int RECO_DROP = 1;
        public const int RPC_E_CHANGED_MODE = -2147417850;
        public const int RPC_E_CANTCALLOUT_ININPUTSYNCCALL = -2147417843;
        public const int RGN_AND = 1;
        public const int RGN_XOR = 3;
        public const int RGN_DIFF = 4;
        public const int RDW_INVALIDATE = 1;
        public const int RDW_ERASE = 4;
        public const int RDW_ALLCHILDREN = 128;
        public const int RDW_ERASENOW = 512;
        public const int RDW_UPDATENOW = 256;
        public const int RDW_FRAME = 1024;
        public const int RB_INSERTBANDA = 1025;
        public const int RB_INSERTBANDW = 1034;
        public const int stc4 = 1091;
        public const int SHGFP_TYPE_CURRENT = 0;
        public const int STGM_READ = 0;
        public const int STGM_WRITE = 1;
        public const int STGM_READWRITE = 2;
        public const int STGM_SHARE_EXCLUSIVE = 16;
        public const int STGM_CREATE = 4096;
        public const int STGM_TRANSACTED = 65536;
        public const int STGM_CONVERT = 131072;
        public const int STGM_DELETEONRELEASE = 67108864;
        public const int STARTF_USESHOWWINDOW = 1;
        public const int SB_HORZ = 0;
        public const int SB_VERT = 1;
        public const int SB_CTL = 2;
        public const int SB_LINEUP = 0;
        public const int SB_LINELEFT = 0;
        public const int SB_LINEDOWN = 1;
        public const int SB_LINERIGHT = 1;
        public const int SB_PAGEUP = 2;
        public const int SB_PAGELEFT = 2;
        public const int SB_PAGEDOWN = 3;
        public const int SB_PAGERIGHT = 3;
        public const int SB_THUMBPOSITION = 4;
        public const int SB_THUMBTRACK = 5;
        public const int SB_LEFT = 6;
        public const int SB_RIGHT = 7;
        public const int SB_ENDSCROLL = 8;
        public const int SB_TOP = 6;
        public const int SB_BOTTOM = 7;
        public const int SIZE_RESTORED = 0;
        public const int SIZE_MAXIMIZED = 2;
        public const int ESB_ENABLE_BOTH = 0;
        public const int ESB_DISABLE_BOTH = 3;
        public const int SORT_DEFAULT = 0;
        public const int SUBLANG_DEFAULT = 1;
        public const int SW_HIDE = 0;
        public const int SW_NORMAL = 1;
        public const int SW_SHOWMINIMIZED = 2;
        public const int SW_SHOWMAXIMIZED = 3;
        public const int SW_MAXIMIZE = 3;
        public const int SW_SHOWNOACTIVATE = 4;
        public const int SW_SHOW = 5;
        public const int SW_MINIMIZE = 6;
        public const int SW_SHOWMINNOACTIVE = 7;
        public const int SW_SHOWNA = 8;
        public const int SW_RESTORE = 9;
        public const int SW_MAX = 10;
        public const int SWP_NOSIZE = 1;
        public const int SWP_NOMOVE = 2;
        public const int SWP_NOZORDER = 4;
        public const int SWP_NOACTIVATE = 16;
        public const int SWP_SHOWWINDOW = 64;
        public const int SWP_HIDEWINDOW = 128;
        public const int SWP_DRAWFRAME = 32;
        public const int SWP_NOOWNERZORDER = 512;
        public const int SM_CXSCREEN = 0;
        public const int SM_CYSCREEN = 1;
        public const int SM_CXVSCROLL = 2;
        public const int SM_CYHSCROLL = 3;
        public const int SM_CYCAPTION = 4;
        public const int SM_CXBORDER = 5;
        public const int SM_CYBORDER = 6;
        public const int SM_CYVTHUMB = 9;
        public const int SM_CXHTHUMB = 10;
        public const int SM_CXICON = 11;
        public const int SM_CYICON = 12;
        public const int SM_CXCURSOR = 13;
        public const int SM_CYCURSOR = 14;
        public const int SM_CYMENU = 15;
        public const int SM_CYKANJIWINDOW = 18;
        public const int SM_MOUSEPRESENT = 19;
        public const int SM_CYVSCROLL = 20;
        public const int SM_CXHSCROLL = 21;
        public const int SM_DEBUG = 22;
        public const int SM_SWAPBUTTON = 23;
        public const int SM_CXMIN = 28;
        public const int SM_CYMIN = 29;
        public const int SM_CXSIZE = 30;
        public const int SM_CYSIZE = 31;
        public const int SM_CXFRAME = 32;
        public const int SM_CYFRAME = 33;
        public const int SM_CXMINTRACK = 34;
        public const int SM_CYMINTRACK = 35;
        public const int SM_CXDOUBLECLK = 36;
        public const int SM_CYDOUBLECLK = 37;
        public const int SM_CXICONSPACING = 38;
        public const int SM_CYICONSPACING = 39;
        public const int SM_MENUDROPALIGNMENT = 40;
        public const int SM_PENWINDOWS = 41;
        public const int SM_DBCSENABLED = 42;
        public const int SM_CMOUSEBUTTONS = 43;
        public const int SM_CXFIXEDFRAME = 7;
        public const int SM_CYFIXEDFRAME = 8;
        public const int SM_SECURE = 44;
        public const int SM_CXEDGE = 45;
        public const int SM_CYEDGE = 46;
        public const int SM_CXMINSPACING = 47;
        public const int SM_CYMINSPACING = 48;
        public const int SM_CXSMICON = 49;
        public const int SM_CYSMICON = 50;
        public const int SM_CYSMCAPTION = 51;
        public const int SM_CXSMSIZE = 52;
        public const int SM_CYSMSIZE = 53;
        public const int SM_CXMENUSIZE = 54;
        public const int SM_CYMENUSIZE = 55;
        public const int SM_ARRANGE = 56;
        public const int SM_CXMINIMIZED = 57;
        public const int SM_CYMINIMIZED = 58;
        public const int SM_CXMAXTRACK = 59;
        public const int SM_CYMAXTRACK = 60;
        public const int SM_CXMAXIMIZED = 61;
        public const int SM_CYMAXIMIZED = 62;
        public const int SM_NETWORK = 63;
        public const int SM_CLEANBOOT = 67;
        public const int SM_CXDRAG = 68;
        public const int SM_CYDRAG = 69;
        public const int SM_SHOWSOUNDS = 70;
        public const int SM_CXMENUCHECK = 71;
        public const int SM_CYMENUCHECK = 72;
        public const int SM_MIDEASTENABLED = 74;
        public const int SM_MOUSEWHEELPRESENT = 75;
        public const int SM_XVIRTUALSCREEN = 76;
        public const int SM_YVIRTUALSCREEN = 77;
        public const int SM_CXVIRTUALSCREEN = 78;
        public const int SM_CYVIRTUALSCREEN = 79;
        public const int SM_CMONITORS = 80;
        public const int SM_SAMEDISPLAYFORMAT = 81;
        public const int SM_REMOTESESSION = 4096;
        public const int HLP_FILE = 1;
        public const int HLP_KEYWORD = 2;
        public const int HLP_NAVIGATOR = 3;
        public const int HLP_OBJECT = 4;
        public const int SW_SCROLLCHILDREN = 1;
        public const int SW_INVALIDATE = 2;
        public const int SW_ERASE = 4;
        public const int SW_SMOOTHSCROLL = 16;
        public const int SC_SIZE = 61440;
        public const int SC_MINIMIZE = 61472;
        public const int SC_MAXIMIZE = 61488;
        public const int SC_CLOSE = 61536;
        public const int SC_KEYMENU = 61696;
        public const int SC_RESTORE = 61728;
        public const int SC_MOVE = 61456;
        public const int SC_CONTEXTHELP = 61824;
        public const int SS_LEFT = 0;
        public const int SS_CENTER = 1;
        public const int SS_RIGHT = 2;
        public const int SS_OWNERDRAW = 13;
        public const int SS_NOPREFIX = 128;
        public const int SS_SUNKEN = 4096;
        public const int SBS_HORZ = 0;
        public const int SBS_VERT = 1;
        public const int SIF_RANGE = 1;
        public const int SIF_PAGE = 2;
        public const int SIF_POS = 4;
        public const int SIF_TRACKPOS = 16;
        public const int SIF_ALL = 23;
        public const int SPI_GETFONTSMOOTHING = 74;
        public const int SPI_GETDROPSHADOW = 4132;
        public const int SPI_GETFLATMENU = 4130;
        public const int SPI_GETFONTSMOOTHINGTYPE = 8202;
        public const int SPI_GETFONTSMOOTHINGCONTRAST = 8204;
        public const int SPI_ICONHORIZONTALSPACING = 13;
        public const int SPI_ICONVERTICALSPACING = 24;
        public const int SPI_GETICONTITLEWRAP = 25;
        public const int SPI_GETICONTITLELOGFONT = 31;
        public const int SPI_GETKEYBOARDCUES = 4106;
        public const int SPI_GETKEYBOARDDELAY = 22;
        public const int SPI_GETKEYBOARDPREF = 68;
        public const int SPI_GETKEYBOARDSPEED = 10;
        public const int SPI_GETMOUSEHOVERWIDTH = 98;
        public const int SPI_GETMOUSEHOVERHEIGHT = 100;
        public const int SPI_GETMOUSEHOVERTIME = 102;
        public const int SPI_GETMOUSESPEED = 112;
        public const int SPI_GETMENUDROPALIGNMENT = 27;
        public const int SPI_GETMENUFADE = 4114;
        public const int SPI_GETMENUSHOWDELAY = 106;
        public const int SPI_GETCOMBOBOXANIMATION = 4100;
        public const int SPI_GETGRADIENTCAPTIONS = 4104;
        public const int SPI_GETHOTTRACKING = 4110;
        public const int SPI_GETLISTBOXSMOOTHSCROLLING = 4102;
        public const int SPI_GETMENUANIMATION = 4098;
        public const int SPI_GETSELECTIONFADE = 4116;
        public const int SPI_GETTOOLTIPANIMATION = 4118;
        public const int SPI_GETUIEFFECTS = 4158;
        public const int SPI_GETACTIVEWINDOWTRACKING = 4096;
        public const int SPI_GETACTIVEWNDTRKTIMEOUT = 8194;
        public const int SPI_GETANIMATION = 72;
        public const int SPI_GETBORDER = 5;
        public const int SPI_GETCARETWIDTH = 8198;
        public const int SM_CYFOCUSBORDER = 84;
        public const int SM_CXFOCUSBORDER = 83;
        public const int SM_CYSIZEFRAME = 33;
        public const int SM_CXSIZEFRAME = 32;
        public const int SPI_GETDRAGFULLWINDOWS = 38;
        public const int SPI_GETNONCLIENTMETRICS = 41;
        public const int SPI_GETWORKAREA = 48;
        public const int SPI_GETHIGHCONTRAST = 66;
        public const int SPI_GETDEFAULTINPUTLANG = 89;
        public const int SPI_GETSNAPTODEFBUTTON = 95;
        public const int SPI_GETWHEELSCROLLLINES = 104;
        public const int SBARS_SIZEGRIP = 256;
        public const int SB_SETTEXTA = 1025;
        public const int SB_SETTEXTW = 1035;
        public const int SB_GETTEXTA = 1026;
        public const int SB_GETTEXTW = 1037;
        public const int SB_GETTEXTLENGTHA = 1027;
        public const int SB_GETTEXTLENGTHW = 1036;
        public const int SB_SETPARTS = 1028;
        public const int SB_SIMPLE = 1033;
        public const int SB_GETRECT = 1034;
        public const int SB_SETICON = 1039;
        public const int SB_SETTIPTEXTA = 1040;
        public const int SB_SETTIPTEXTW = 1041;
        public const int SB_GETTIPTEXTA = 1042;
        public const int SB_GETTIPTEXTW = 1043;
        public const int SBT_OWNERDRAW = 4096;
        public const int SBT_NOBORDERS = 256;
        public const int SBT_POPOUT = 512;
        public const int SBT_RTLREADING = 1024;
        public const int SRCCOPY = 13369376;
        public const int SRCAND = 8913094;
        public const int SRCPAINT = 15597702;
        public const int NOTSRCCOPY = 3342344;
        public const int STATFLAG_DEFAULT = 0;
        public const int STATFLAG_NONAME = 1;
        public const int STATFLAG_NOOPEN = 2;
        public const int STGC_DEFAULT = 0;
        public const int STGC_OVERWRITE = 1;
        public const int STGC_ONLYIFCURRENT = 2;
        public const int STGC_DANGEROUSLYCOMMITMERELYTODISKCACHE = 4;
        public const int STREAM_SEEK_SET = 0;
        public const int STREAM_SEEK_CUR = 1;
        public const int STREAM_SEEK_END = 2;
        public const int S_OK = 0;
        public const int S_FALSE = 1;
        public const int TRANSPARENT = 1;
        public const int OPAQUE = 2;
        public const int TME_HOVER = 1;
        public const int TME_LEAVE = 2;
        public const int TPM_LEFTBUTTON = 0;
        public const int TPM_RIGHTBUTTON = 2;
        public const int TPM_LEFTALIGN = 0;
        public const int TPM_RIGHTALIGN = 8;
        public const int TPM_VERTICAL = 64;
        public const int TV_FIRST = 4352;
        public const int TBSTATE_CHECKED = 1;
        public const int TBSTATE_ENABLED = 4;
        public const int TBSTATE_HIDDEN = 8;
        public const int TBSTATE_INDETERMINATE = 16;
        public const int TBSTYLE_BUTTON = 0;
        public const int TBSTYLE_SEP = 1;
        public const int TBSTYLE_CHECK = 2;
        public const int TBSTYLE_DROPDOWN = 8;
        public const int TBSTYLE_TOOLTIPS = 256;
        public const int TBSTYLE_FLAT = 2048;
        public const int TBSTYLE_LIST = 4096;
        public const int TBSTYLE_EX_DRAWDDARROWS = 1;
        public const int TB_ENABLEBUTTON = 1025;
        public const int TB_ISBUTTONCHECKED = 1034;
        public const int TB_ISBUTTONINDETERMINATE = 1037;
        public const int TB_ADDBUTTONSA = 1044;
        public const int TB_ADDBUTTONSW = 1092;
        public const int TB_INSERTBUTTONA = 1045;
        public const int TB_INSERTBUTTONW = 1091;
        public const int TB_DELETEBUTTON = 1046;
        public const int TB_GETBUTTON = 1047;
        public const int TB_SAVERESTOREA = 1050;
        public const int TB_SAVERESTOREW = 1100;
        public const int TB_ADDSTRINGA = 1052;
        public const int TB_ADDSTRINGW = 1101;
        public const int TB_BUTTONSTRUCTSIZE = 1054;
        public const int TB_SETBUTTONSIZE = 1055;
        public const int TB_AUTOSIZE = 1057;
        public const int TB_GETROWS = 1064;
        public const int TB_GETBUTTONTEXTA = 1069;
        public const int TB_GETBUTTONTEXTW = 1099;
        public const int TB_SETIMAGELIST = 1072;
        public const int TB_GETRECT = 1075;
        public const int TB_GETBUTTONSIZE = 1082;
        public const int TB_GETBUTTONINFOW = 1087;
        public const int TB_SETBUTTONINFOW = 1088;
        public const int TB_GETBUTTONINFOA = 1089;
        public const int TB_SETBUTTONINFOA = 1090;
        public const int TB_MAPACCELERATORA = 1102;
        public const int TB_SETEXTENDEDSTYLE = 1108;
        public const int TB_MAPACCELERATORW = 1114;
        public const int TB_GETTOOLTIPS = 1059;
        public const int TB_SETTOOLTIPS = 1060;
        public const int TBIF_IMAGE = 1;
        public const int TBIF_TEXT = 2;
        public const int TBIF_STATE = 4;
        public const int TBIF_STYLE = 8;
        public const int TBIF_COMMAND = 32;
        public const int TBIF_SIZE = 64;
        public const int TBN_GETBUTTONINFOA = -700;
        public const int TBN_GETBUTTONINFOW = -720;
        public const int TBN_QUERYINSERT = -706;
        public const int TBN_DROPDOWN = -710;
        public const int TBN_HOTITEMCHANGE = -713;
        public const int TBN_GETDISPINFOA = -716;
        public const int TBN_GETDISPINFOW = -717;
        public const int TBN_GETINFOTIPA = -718;
        public const int TBN_GETINFOTIPW = -719;
        public const int TTS_ALWAYSTIP = 1;
        public const int TTS_NOPREFIX = 2;
        public const int TTS_NOANIMATE = 16;
        public const int TTS_NOFADE = 32;
        public const int TTS_BALLOON = 64;
        public const int TTI_WARNING = 2;
        public const int TTF_IDISHWND = 1;
        public const int TTF_RTLREADING = 4;
        public const int TTF_TRACK = 32;
        public const int TTF_CENTERTIP = 2;
        public const int TTF_SUBCLASS = 16;
        public const int TTF_TRANSPARENT = 256;
        public const int TTF_ABSOLUTE = 128;
        public const int TTDT_AUTOMATIC = 0;
        public const int TTDT_RESHOW = 1;
        public const int TTDT_AUTOPOP = 2;
        public const int TTDT_INITIAL = 3;
        public const int TTM_TRACKACTIVATE = 1041;
        public const int TTM_TRACKPOSITION = 1042;
        public const int TTM_ACTIVATE = 1025;
        public const int TTM_POP = 1052;
        public const int TTM_ADJUSTRECT = 1055;
        public const int TTM_SETDELAYTIME = 1027;
        public const int TTM_SETTITLEA = 1056;
        public const int TTM_SETTITLEW = 1057;
        public const int TTM_ADDTOOLA = 1028;
        public const int TTM_ADDTOOLW = 1074;
        public const int TTM_DELTOOLA = 1029;
        public const int TTM_DELTOOLW = 1075;
        public const int TTM_NEWTOOLRECTA = 1030;
        public const int TTM_NEWTOOLRECTW = 1076;
        public const int TTM_RELAYEVENT = 1031;
        public const int TTM_GETTIPBKCOLOR = 1046;
        public const int TTM_SETTIPBKCOLOR = 1043;
        public const int TTM_SETTIPTEXTCOLOR = 1044;
        public const int TTM_GETTIPTEXTCOLOR = 1047;
        public const int TTM_GETTOOLINFOA = 1032;
        public const int TTM_GETTOOLINFOW = 1077;
        public const int TTM_SETTOOLINFOA = 1033;
        public const int TTM_SETTOOLINFOW = 1078;
        public const int TTM_HITTESTA = 1034;
        public const int TTM_HITTESTW = 1079;
        public const int TTM_GETTEXTA = 1035;
        public const int TTM_GETTEXTW = 1080;
        public const int TTM_UPDATE = 1053;
        public const int TTM_UPDATETIPTEXTA = 1036;
        public const int TTM_UPDATETIPTEXTW = 1081;
        public const int TTM_ENUMTOOLSA = 1038;
        public const int TTM_ENUMTOOLSW = 1082;
        public const int TTM_GETCURRENTTOOLA = 1039;
        public const int TTM_GETCURRENTTOOLW = 1083;
        public const int TTM_WINDOWFROMPOINT = 1040;
        public const int TTM_GETDELAYTIME = 1045;
        public const int TTM_SETMAXTIPWIDTH = 1048;
        public const int TTN_GETDISPINFOA = -520;
        public const int TTN_GETDISPINFOW = -530;
        public const int TTN_SHOW = -521;
        public const int TTN_POP = -522;
        public const int TTN_NEEDTEXTA = -520;
        public const int TTN_NEEDTEXTW = -530;
        public const int TBS_AUTOTICKS = 1;
        public const int TBS_VERT = 2;
        public const int TBS_TOP = 4;
        public const int TBS_BOTTOM = 0;
        public const int TBS_BOTH = 8;
        public const int TBS_NOTICKS = 16;
        public const int TBM_GETPOS = 1024;
        public const int TBM_SETTIC = 1028;
        public const int TBM_SETPOS = 1029;
        public const int TBM_SETRANGE = 1030;
        public const int TBM_SETRANGEMIN = 1031;
        public const int TBM_SETRANGEMAX = 1032;
        public const int TBM_SETTICFREQ = 1044;
        public const int TBM_SETPAGESIZE = 1045;
        public const int TBM_SETLINESIZE = 1047;
        public const int TB_LINEUP = 0;
        public const int TB_LINEDOWN = 1;
        public const int TB_PAGEUP = 2;
        public const int TB_PAGEDOWN = 3;
        public const int TB_THUMBPOSITION = 4;
        public const int TB_THUMBTRACK = 5;
        public const int TB_TOP = 6;
        public const int TB_BOTTOM = 7;
        public const int TB_ENDTRACK = 8;
        public const int TVS_HASBUTTONS = 1;
        public const int TVS_HASLINES = 2;
        public const int TVS_LINESATROOT = 4;
        public const int TVS_EDITLABELS = 8;
        public const int TVS_SHOWSELALWAYS = 32;
        public const int TVS_RTLREADING = 64;
        public const int TVS_CHECKBOXES = 256;
        public const int TVS_TRACKSELECT = 512;
        public const int TVS_FULLROWSELECT = 4096;
        public const int TVS_NONEVENHEIGHT = 16384;
        public const int TVS_INFOTIP = 2048;
        public const int TVS_NOTOOLTIPS = 128;
        public const int TVIF_TEXT = 1;
        public const int TVIF_IMAGE = 2;
        public const int TVIF_PARAM = 4;
        public const int TVIF_STATE = 8;
        public const int TVIF_HANDLE = 16;
        public const int TVIF_SELECTEDIMAGE = 32;
        public const int TVIS_SELECTED = 2;
        public const int TVIS_EXPANDED = 32;
        public const int TVIS_EXPANDEDONCE = 64;
        public const int TVIS_STATEIMAGEMASK = 61440;
        public const int TVI_ROOT = -65536;
        public const int TVI_FIRST = -65535;
        public const int TVM_INSERTITEMA = 4352;
        public const int TVM_INSERTITEMW = 4402;
        public const int TVM_DELETEITEM = 4353;
        public const int TVM_EXPAND = 4354;
        public const int TVE_COLLAPSE = 1;
        public const int TVE_EXPAND = 2;
        public const int TVM_GETITEMRECT = 4356;
        public const int TVM_GETINDENT = 4358;
        public const int TVM_SETINDENT = 4359;
        public const int TVM_GETIMAGELIST = 4360;
        public const int TVM_SETIMAGELIST = 4361;
        public const int TVM_GETNEXTITEM = 4362;
        public const int TVGN_NEXT = 1;
        public const int TVGN_PREVIOUS = 2;
        public const int TVGN_FIRSTVISIBLE = 5;
        public const int TVGN_NEXTVISIBLE = 6;
        public const int TVGN_PREVIOUSVISIBLE = 7;
        public const int TVGN_DROPHILITE = 8;
        public const int TVGN_CARET = 9;
        public const int TVM_SELECTITEM = 4363;
        public const int TVM_GETITEMA = 4364;
        public const int TVM_GETITEMW = 4414;
        public const int TVM_SETITEMA = 4365;
        public const int TVM_SETITEMW = 4415;
        public const int TVM_EDITLABELA = 4366;
        public const int TVM_EDITLABELW = 4417;
        public const int TVM_GETEDITCONTROL = 4367;
        public const int TVM_GETVISIBLECOUNT = 4368;
        public const int TVM_HITTEST = 4369;
        public const int TVM_ENSUREVISIBLE = 4372;
        public const int TVM_ENDEDITLABELNOW = 4374;
        public const int TVM_GETISEARCHSTRINGA = 4375;
        public const int TVM_GETISEARCHSTRINGW = 4416;
        public const int TVM_SETITEMHEIGHT = 4379;
        public const int TVM_GETITEMHEIGHT = 4380;
        public const int TVN_SELCHANGINGA = -401;
        public const int TVN_SELCHANGINGW = -450;
        public const int TVN_GETINFOTIPA = -413;
        public const int TVN_GETINFOTIPW = -414;
        public const int TVN_SELCHANGEDA = -402;
        public const int TVN_SELCHANGEDW = -451;
        public const int TVC_UNKNOWN = 0;
        public const int TVC_BYMOUSE = 1;
        public const int TVC_BYKEYBOARD = 2;
        public const int TVN_GETDISPINFOA = -403;
        public const int TVN_GETDISPINFOW = -452;
        public const int TVN_SETDISPINFOA = -404;
        public const int TVN_SETDISPINFOW = -453;
        public const int TVN_ITEMEXPANDINGA = -405;
        public const int TVN_ITEMEXPANDINGW = -454;
        public const int TVN_ITEMEXPANDEDA = -406;
        public const int TVN_ITEMEXPANDEDW = -455;
        public const int TVN_BEGINDRAGA = -407;
        public const int TVN_BEGINDRAGW = -456;
        public const int TVN_BEGINRDRAGA = -408;
        public const int TVN_BEGINRDRAGW = -457;
        public const int TVN_BEGINLABELEDITA = -410;
        public const int TVN_BEGINLABELEDITW = -459;
        public const int TVN_ENDLABELEDITA = -411;
        public const int TVN_ENDLABELEDITW = -460;
        public const int TCS_BOTTOM = 2;
        public const int TCS_RIGHT = 2;
        public const int TCS_FLATBUTTONS = 8;
        public const int TCS_HOTTRACK = 64;
        public const int TCS_VERTICAL = 128;
        public const int TCS_TABS = 0;
        public const int TCS_BUTTONS = 256;
        public const int TCS_MULTILINE = 512;
        public const int TCS_RIGHTJUSTIFY = 0;
        public const int TCS_FIXEDWIDTH = 1024;
        public const int TCS_RAGGEDRIGHT = 2048;
        public const int TCS_OWNERDRAWFIXED = 8192;
        public const int TCS_TOOLTIPS = 16384;
        public const int TCM_SETIMAGELIST = 4867;
        public const int TCIF_TEXT = 1;
        public const int TCIF_IMAGE = 2;
        public const int TCM_GETITEMA = 4869;
        public const int TCM_GETITEMW = 4924;
        public const int TCM_SETITEMA = 4870;
        public const int TCM_SETITEMW = 4925;
        public const int TCM_INSERTITEMA = 4871;
        public const int TCM_INSERTITEMW = 4926;
        public const int TCM_DELETEITEM = 4872;
        public const int TCM_DELETEALLITEMS = 4873;
        public const int TCM_GETITEMRECT = 4874;
        public const int TCM_GETCURSEL = 4875;
        public const int TCM_SETCURSEL = 4876;
        public const int TCM_ADJUSTRECT = 4904;
        public const int TCM_SETITEMSIZE = 4905;
        public const int TCM_SETPADDING = 4907;
        public const int TCM_GETROWCOUNT = 4908;
        public const int TCM_GETTOOLTIPS = 4909;
        public const int TCM_SETTOOLTIPS = 4910;
        public const int TCN_SELCHANGE = -551;
        public const int TCN_SELCHANGING = -552;
        public const int TBSTYLE_WRAPPABLE = 512;
        public const int TVM_SETBKCOLOR = 4381;
        public const int TVM_SETTEXTCOLOR = 4382;
        public const int TYMED_NULL = 0;
        public const int TVM_GETLINECOLOR = 4393;
        public const int TVM_SETLINECOLOR = 4392;
        public const int TVM_SETTOOLTIPS = 4376;
        public const int TVSIL_STATE = 2;
        public const int TVM_SORTCHILDRENCB = 4373;
        public const int TMPF_FIXED_PITCH = 1;
        public const int TVHT_NOWHERE = 1;
        public const int TVHT_ONITEMICON = 2;
        public const int TVHT_ONITEMLABEL = 4;
        public const int TVHT_ONITEM = 70;
        public const int TVHT_ONITEMINDENT = 8;
        public const int TVHT_ONITEMBUTTON = 16;
        public const int TVHT_ONITEMRIGHT = 32;
        public const int TVHT_ONITEMSTATEICON = 64;
        public const int TVHT_ABOVE = 256;
        public const int TVHT_BELOW = 512;
        public const int TVHT_TORIGHT = 1024;
        public const int TVHT_TOLEFT = 2048;
        public const int UIS_SET = 1;
        public const int UIS_CLEAR = 2;
        public const int UIS_INITIALIZE = 3;
        public const int UISF_HIDEFOCUS = 1;
        public const int UISF_HIDEACCEL = 2;
        public const int USERCLASSTYPE_FULL = 1;
        public const int USERCLASSTYPE_SHORT = 2;
        public const int USERCLASSTYPE_APPNAME = 3;
        public const int UOI_FLAGS = 1;
        public const int VIEW_E_DRAW = -2147221184;
        public const int VK_PRIOR = 33;
        public const int VK_NEXT = 34;
        public const int VK_LEFT = 37;
        public const int VK_UP = 38;
        public const int VK_RIGHT = 39;
        public const int VK_DOWN = 40;
        public const int VK_TAB = 9;
        public const int VK_SHIFT = 16;
        public const int VK_CONTROL = 17;
        public const int VK_MENU = 18;
        public const int VK_CAPITAL = 20;
        public const int VK_KANA = 21;
        public const int VK_ESCAPE = 27;
        public const int VK_END = 35;
        public const int VK_HOME = 36;
        public const int VK_NUMLOCK = 144;
        public const int VK_SCROLL = 145;
        public const int VK_INSERT = 45;
        public const int VK_DELETE = 46;
        public const int WH_JOURNALPLAYBACK = 1;
        public const int WH_GETMESSAGE = 3;
        public const int WH_MOUSE = 7;
        public const int WSF_VISIBLE = 1;
        public const int WM_NULL = 0;
        public const int WM_CREATE = 1;
        public const int WM_DELETEITEM = 45;
        public const int WM_DESTROY = 2;
        public const int WM_MOVE = 3;
        public const int WM_SIZE = 5;
        public const int WM_ACTIVATE = 6;
        public const int WA_INACTIVE = 0;
        public const int WA_ACTIVE = 1;
        public const int WA_CLICKACTIVE = 2;
        public const int WM_SETFOCUS = 7;
        public const int WM_KILLFOCUS = 8;
        public const int WM_ENABLE = 10;
        public const int WM_SETREDRAW = 11;
        public const int WM_SETTEXT = 12;
        public const int WM_GETTEXT = 13;
        public const int WM_GETTEXTLENGTH = 14;
        public const int WM_PAINT = 15;
        public const int WM_CLOSE = 16;
        public const int WM_QUERYENDSESSION = 17;
        public const int WM_QUIT = 18;
        public const int WM_QUERYOPEN = 19;
        public const int WM_ERASEBKGND = 20;
        public const int WM_SYSCOLORCHANGE = 21;
        public const int WM_ENDSESSION = 22;
        public const int WM_SHOWWINDOW = 24;
        public const int WM_WININICHANGE = 26;
        public const int WM_SETTINGCHANGE = 26;
        public const int WM_DEVMODECHANGE = 27;
        public const int WM_ACTIVATEAPP = 28;
        public const int WM_FONTCHANGE = 29;
        public const int WM_TIMECHANGE = 30;
        public const int WM_CANCELMODE = 31;
        public const int WM_SETCURSOR = 32;
        public const int WM_MOUSEACTIVATE = 33;
        public const int WM_CHILDACTIVATE = 34;
        public const int WM_QUEUESYNC = 35;
        public const int WM_GETMINMAXINFO = 36;
        public const int WM_PAINTICON = 38;
        public const int WM_ICONERASEBKGND = 39;
        public const int WM_NEXTDLGCTL = 40;
        public const int WM_SPOOLERSTATUS = 42;
        public const int WM_DRAWITEM = 43;
        public const int WM_MEASUREITEM = 44;
        public const int WM_VKEYTOITEM = 46;
        public const int WM_CHARTOITEM = 47;
        public const int WM_SETFONT = 48;
        public const int WM_GETFONT = 49;
        public const int WM_SETHOTKEY = 50;
        public const int WM_GETHOTKEY = 51;
        public const int WM_QUERYDRAGICON = 55;
        public const int WM_COMPAREITEM = 57;
        public const int WM_GETOBJECT = 61;
        public const int WM_COMPACTING = 65;
        public const int WM_COMMNOTIFY = 68;
        public const int WM_WINDOWPOSCHANGING = 70;
        public const int WM_WINDOWPOSCHANGED = 71;
        public const int WM_POWER = 72;
        public const int WM_COPYDATA = 74;
        public const int WM_CANCELJOURNAL = 75;
        public const int WM_NOTIFY = 78;
        public const int WM_INPUTLANGCHANGEREQUEST = 80;
        public const int WM_INPUTLANGCHANGE = 81;
        public const int WM_TCARD = 82;
        public const int WM_HELP = 83;
        public const int WM_USERCHANGED = 84;
        public const int WM_NOTIFYFORMAT = 85;
        public const int WM_CONTEXTMENU = 123;
        public const int WM_STYLECHANGING = 124;
        public const int WM_STYLECHANGED = 125;
        public const int WM_DISPLAYCHANGE = 126;
        public const int WM_GETICON = 127;
        public const int WM_SETICON = 128;
        public const int WM_NCCREATE = 129;
        public const int WM_NCDESTROY = 130;
        public const int WM_NCCALCSIZE = 131;
        public const int WM_NCHITTEST = 132;
        public const int WM_NCPAINT = 133;
        public const int WM_NCACTIVATE = 134;
        public const int WM_GETDLGCODE = 135;
        public const int WM_NCMOUSEMOVE = 160;
        public const int WM_NCMOUSELEAVE = 674;
        public const int WM_NCLBUTTONDOWN = 161;
        public const int WM_NCLBUTTONUP = 162;
        public const int WM_NCLBUTTONDBLCLK = 163;
        public const int WM_NCRBUTTONDOWN = 164;
        public const int WM_NCRBUTTONUP = 165;
        public const int WM_NCRBUTTONDBLCLK = 166;
        public const int WM_NCMBUTTONDOWN = 167;
        public const int WM_NCMBUTTONUP = 168;
        public const int WM_NCMBUTTONDBLCLK = 169;
        public const int WM_NCXBUTTONDOWN = 171;
        public const int WM_NCXBUTTONUP = 172;
        public const int WM_NCXBUTTONDBLCLK = 173;
        public const int WM_KEYFIRST = 256;
        public const int WM_KEYDOWN = 256;
        public const int WM_KEYUP = 257;
        public const int WM_CHAR = 258;
        public const int WM_DEADCHAR = 259;
        public const int WM_CTLCOLOR = 25;
        public const int WM_SYSKEYDOWN = 260;
        public const int WM_SYSKEYUP = 261;
        public const int WM_SYSCHAR = 262;
        public const int WM_SYSDEADCHAR = 263;
        public const int WM_KEYLAST = 264;
        public const int WM_IME_STARTCOMPOSITION = 269;
        public const int WM_IME_ENDCOMPOSITION = 270;
        public const int WM_IME_COMPOSITION = 271;
        public const int WM_IME_KEYLAST = 271;
        public const int WM_INITDIALOG = 272;
        public const int WM_COMMAND = 273;
        public const int WM_SYSCOMMAND = 274;
        public const int WM_TIMER = 275;
        public const int WM_HSCROLL = 276;
        public const int WM_VSCROLL = 277;
        public const int WM_INITMENU = 278;
        public const int WM_INITMENUPOPUP = 279;
        public const int WM_MENUSELECT = 287;
        public const int WM_MENUCHAR = 288;
        public const int WM_ENTERIDLE = 289;
        public const int WM_UNINITMENUPOPUP = 293;
        public const int WM_CHANGEUISTATE = 295;
        public const int WM_UPDATEUISTATE = 296;
        public const int WM_QUERYUISTATE = 297;
        public const int WM_CTLCOLORMSGBOX = 306;
        public const int WM_CTLCOLOREDIT = 307;
        public const int WM_CTLCOLORLISTBOX = 308;
        public const int WM_CTLCOLORBTN = 309;
        public const int WM_CTLCOLORDLG = 310;
        public const int WM_CTLCOLORSCROLLBAR = 311;
        public const int WM_CTLCOLORSTATIC = 312;
        public const int WM_MOUSEFIRST = 512;
        public const int WM_MOUSEMOVE = 512;
        public const int WM_LBUTTONDOWN = 513;
        public const int WM_LBUTTONUP = 514;
        public const int WM_LBUTTONDBLCLK = 515;
        public const int WM_RBUTTONDOWN = 516;
        public const int WM_RBUTTONUP = 517;
        public const int WM_RBUTTONDBLCLK = 518;
        public const int WM_MBUTTONDOWN = 519;
        public const int WM_MBUTTONUP = 520;
        public const int WM_MBUTTONDBLCLK = 521;
        public const int WM_XBUTTONDOWN = 523;
        public const int WM_XBUTTONUP = 524;
        public const int WM_XBUTTONDBLCLK = 525;
        public const int WM_MOUSEWHEEL = 522;
        public const int WM_MOUSELAST = 522;
        public const int WHEEL_DELTA = 120;
        public const int WM_PARENTNOTIFY = 528;
        public const int WM_ENTERMENULOOP = 529;
        public const int WM_EXITMENULOOP = 530;
        public const int WM_NEXTMENU = 531;
        public const int WM_SIZING = 532;
        public const int WM_CAPTURECHANGED = 533;
        public const int WM_MOVING = 534;
        public const int WM_POWERBROADCAST = 536;
        public const int WM_DEVICECHANGE = 537;
        public const int WM_IME_SETCONTEXT = 641;
        public const int WM_IME_NOTIFY = 642;
        public const int WM_IME_CONTROL = 643;
        public const int WM_IME_COMPOSITIONFULL = 644;
        public const int WM_IME_SELECT = 645;
        public const int WM_IME_CHAR = 646;
        public const int WM_IME_KEYDOWN = 656;
        public const int WM_IME_KEYUP = 657;
        public const int WM_MDICREATE = 544;
        public const int WM_MDIDESTROY = 545;
        public const int WM_MDIACTIVATE = 546;
        public const int WM_MDIRESTORE = 547;
        public const int WM_MDINEXT = 548;
        public const int WM_MDIMAXIMIZE = 549;
        public const int WM_MDITILE = 550;
        public const int WM_MDICASCADE = 551;
        public const int WM_MDIICONARRANGE = 552;
        public const int WM_MDIGETACTIVE = 553;
        public const int WM_MDISETMENU = 560;
        public const int WM_ENTERSIZEMOVE = 561;
        public const int WM_EXITSIZEMOVE = 562;
        public const int WM_DROPFILES = 563;
        public const int WM_MDIREFRESHMENU = 564;
        public const int WM_MOUSEHOVER = 673;
        public const int WM_MOUSELEAVE = 675;
        public const int WM_CUT = 768;
        public const int WM_COPY = 769;
        public const int WM_PASTE = 770;
        public const int WM_CLEAR = 771;
        public const int WM_UNDO = 772;
        public const int WM_RENDERFORMAT = 773;
        public const int WM_RENDERALLFORMATS = 774;
        public const int WM_DESTROYCLIPBOARD = 775;
        public const int WM_DRAWCLIPBOARD = 776;
        public const int WM_PAINTCLIPBOARD = 777;
        public const int WM_VSCROLLCLIPBOARD = 778;
        public const int WM_SIZECLIPBOARD = 779;
        public const int WM_ASKCBFORMATNAME = 780;
        public const int WM_CHANGECBCHAIN = 781;
        public const int WM_HSCROLLCLIPBOARD = 782;
        public const int WM_QUERYNEWPALETTE = 783;
        public const int WM_PALETTEISCHANGING = 784;
        public const int WM_PALETTECHANGED = 785;
        public const int WM_HOTKEY = 786;
        public const int WM_PRINT = 791;
        public const int WM_PRINTCLIENT = 792;
        public const int WM_THEMECHANGED = 794;
        public const int WM_HANDHELDFIRST = 856;
        public const int WM_HANDHELDLAST = 863;
        public const int WM_AFXFIRST = 864;
        public const int WM_AFXLAST = 895;
        public const int WM_PENWINFIRST = 896;
        public const int WM_PENWINLAST = 911;
        public const int WM_APP = 32768;
        public const int WM_USER = 1024;
        public const int WM_REFLECT = 8192;
        public const int WS_OVERLAPPED = 0;
        public const int WS_POPUP = -2147483648;
        public const int WS_CHILD = 1073741824;
        public const int WS_MINIMIZE = 536870912;
        public const int WS_VISIBLE = 268435456;
        public const int WS_DISABLED = 134217728;
        public const int WS_CLIPSIBLINGS = 67108864;
        public const int WS_CLIPCHILDREN = 33554432;
        public const int WS_MAXIMIZE = 16777216;
        public const int WS_CAPTION = 12582912;
        public const int WS_BORDER = 8388608;
        public const int WS_DLGFRAME = 4194304;
        public const int WS_VSCROLL = 2097152;
        public const int WS_HSCROLL = 1048576;
        public const int WS_SYSMENU = 524288;
        public const int WS_THICKFRAME = 262144;
        public const int WS_TABSTOP = 65536;
        public const int WS_MINIMIZEBOX = 131072;
        public const int WS_MAXIMIZEBOX = 65536;
        public const int WS_EX_DLGMODALFRAME = 1;
        public const int WS_EX_MDICHILD = 64;
        public const int WS_EX_TOOLWINDOW = 128;
        public const int WS_EX_CLIENTEDGE = 512;
        public const int WS_EX_CONTEXTHELP = 1024;
        public const int WS_EX_RIGHT = 4096;
        public const int WS_EX_LEFT = 0;
        public const int WS_EX_RTLREADING = 8192;
        public const int WS_EX_LEFTSCROLLBAR = 16384;
        public const int WS_EX_CONTROLPARENT = 65536;
        public const int WS_EX_STATICEDGE = 131072;
        public const int WS_EX_APPWINDOW = 262144;
        public const int WS_EX_LAYERED = 524288;
        public const int WS_EX_TOPMOST = 8;
        public const int WS_EX_LAYOUTRTL = 4194304;
        public const int WS_EX_NOINHERITLAYOUT = 1048576;
        public const int WPF_SETMINPOSITION = 1;
        public const int WM_CHOOSEFONT_GETLOGFONT = 1025;
        public const int IMN_OPENSTATUSWINDOW = 2;
        public const int IMN_SETCONVERSIONMODE = 6;
        public const int IMN_SETOPENSTATUS = 8;
        public static int START_PAGE_GENERAL;
        public const int PD_RESULT_CANCEL = 0;
        public const int PD_RESULT_PRINT = 1;
        public const int PD_RESULT_APPLY = 2;
        public const int XBUTTON1 = 1;
        public const int XBUTTON2 = 2;
        public const int WH_KEYBOARD_LL = 13;
        public const int SW_Min = 0x2;
        public const int SW_Max = 0x3;
        public const int SW_Norm = 0x4;
    }

    /// <summary>
    /// Pointer to a native buffer with a specific size.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DataPointer : IEquatable<DataPointer>
    {
        /// <summary>
        /// Gets an Empty Data Pointer.
        /// </summary>
        public static readonly DataPointer Zero = new DataPointer(IntPtr.Zero, 0);

        /// <summary>
        /// Initializes a new instance of the <see cref="DataPointer" /> struct.
        /// </summary>
        /// <param name="pointer">The pointer.</param>
        /// <param name="size">The size.</param>
        public DataPointer(IntPtr pointer, int size)
        {
            Pointer = pointer;
            Size = size;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataPointer" /> struct.
        /// </summary>
        /// <param name="pointer">The pointer.</param>
        /// <param name="size">The size.</param>
        public unsafe DataPointer(void* pointer, int size)
        {
            Pointer = (IntPtr)pointer;
            Size = size;
        }

        /// <summary>
        /// Pointer to the buffer.
        /// </summary>
        public IntPtr Pointer;

        /// <summary>
        /// Size in bytes of the buffer.
        /// </summary>
        public int Size;

        /// <summary>
        /// Gets a value indicating whether this instance is empty (zeroed).
        /// </summary>
        /// <value><c>true</c> if this instance is empty; otherwise, <c>false</c>.</value>
        public bool IsEmpty
        {
            get { return Equals(Zero); }
        }

        public bool Equals(DataPointer other)
        {
            return Pointer.Equals(other.Pointer) && Size == other.Size;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is DataPointer && Equals((DataPointer)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Pointer.GetHashCode() * 397) ^ Size;
            }
        }
        /// <summary>
        /// Converts this instance to a read only byte buffer.
        /// </summary>
        /// <returns>A readonly byte buffer.</returns>
        /// <exception cref="System.InvalidOperationException">
        /// DataPointer is Zero
        /// or
        /// Size cannot be &lt; 0
        /// </exception>
        public byte[] ToArray()
        {
            if (Pointer == IntPtr.Zero) throw new InvalidOperationException("DataPointer is Zero");
            if (Size < 0) throw new InvalidOperationException("Size cannot be < 0");
            var buffer = new byte[Size];
            NativeMethods.Read(Pointer, buffer, 0, Size);
            return buffer;
        }

        /// <summary>
        /// Converts this instance to a read only typed buffer.
        /// </summary>
        /// <typeparam name="T">Type of a buffer element</typeparam>
        /// <returns>A readonly typed buffer.</returns>
        /// <exception cref="System.InvalidOperationException">DataPointer is Zero</exception>
        public T[] ToArray<T>() where T : struct
        {
            if (Pointer == IntPtr.Zero) throw new InvalidOperationException("DataPointer is Zero");
            var buffer = new T[Size / NativeMethods.SizeOf<T>()];
            CopyTo(buffer, 0, buffer.Length);
            return buffer;
        }

        /// <summary>
        /// Reads the content of the unmanaged memory location of this instance to the specified buffer.
        /// </summary>
        /// <typeparam name="T">Type of a buffer element</typeparam>
        /// <param name="buffer">The buffer.</param>
        /// <param name="offset">The offset in the array to write to.</param>
        /// <param name="count">The number of T element to read from the memory location.</param>
        /// <exception cref="System.ArgumentNullException">buffer</exception>
        /// <exception cref="System.InvalidOperationException">DataPointer is Zero</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">buffer;Total buffer size cannot be larger than size of this data pointer</exception>
        public void CopyTo<T>(T[] buffer, int offset, int count) where T : struct
        {
            if (buffer == null) throw new ArgumentNullException("buffer");
            if (Pointer == IntPtr.Zero) throw new InvalidOperationException("DataPointer is Zero");
            if (offset < 0) throw new ArgumentOutOfRangeException("offset", "Must be >= 0");
            if (count <= 0) throw new ArgumentOutOfRangeException("count", "Must be > 0");
            if (count * NativeMethods.SizeOf<T>() > Size) throw new ArgumentOutOfRangeException("buffer", "Total buffer size cannot be larger than size of this data pointer");
            NativeMethods.Read(Pointer, buffer, offset, count);
        }

        /// <summary>
        /// Writes the content of the specified buffer to the unmanaged memory location of this instance.
        /// </summary>
        /// <typeparam name="T">Type of a buffer element</typeparam>
        /// <param name="buffer">The buffer.</param>
        /// <exception cref="System.ArgumentNullException">buffer</exception>
        /// <exception cref="System.InvalidOperationException">DataPointer is Zero</exception>
        public void CopyFrom<T>(T[] buffer) where T : struct
        {
            if (buffer == null) throw new ArgumentNullException("buffer");
            if (Pointer == IntPtr.Zero) throw new InvalidOperationException("DataPointer is Zero");
            CopyFrom(buffer, 0, buffer.Length);
        }

        /// <summary>
        /// Writes the content of the specified buffer to the unmanaged memory location of this instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="buffer">The buffer to read from.</param>
        /// <param name="offset">The offset in the array to read from.</param>
        /// <param name="count">The number of T element to write to the memory location.</param>
        /// <exception cref="System.ArgumentNullException">buffer</exception>
        /// <exception cref="System.InvalidOperationException">DataPointer is Zero</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">buffer;Total buffer size cannot be larger than size of this data pointer</exception>
        public void CopyFrom<T>(T[] buffer, int offset, int count) where T : struct
        {
            if (buffer == null) throw new ArgumentNullException("buffer");
            if (Pointer == IntPtr.Zero) throw new InvalidOperationException("DataPointer is Zero");
            if (offset < 0) throw new ArgumentOutOfRangeException("offset", "Must be >= 0");
            if (count <= 0) throw new ArgumentOutOfRangeException("count", "Must be > 0");
            if (count * NativeMethods.SizeOf<T>() > Size) throw new ArgumentOutOfRangeException("buffer", "Total buffer size cannot be larger than size of this data pointer");
            NativeMethods.Write(Pointer, buffer, offset, count);
        }

        /// <summary>
        /// Implements the ==.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator ==(DataPointer left, DataPointer right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Implements the !=.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator !=(DataPointer left, DataPointer right)
        {
            return !left.Equals(right);
        }
    }

    [Flags]
    public enum MouseEventFlags
    {
        LeftDown = 0x00000002,
        LeftUp = 0x00000004,
        MiddleDown = 0x00000020,
        MiddleUp = 0x00000040,
        Move = 0x00000001,
        Absolute = 0x00008000,
        RightDown = 0x00000008,
        RightUp = 0x00000010
    }
    public class POINT
    {
        public int x;
        public int y;
        public POINT()
        {
        }
        public POINT(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
    public struct POINTSTRUCT
    {
        public int x;
        public int y;
        public POINTSTRUCT(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
    public delegate IntPtr WndProc(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);
    /// <summary>
    ///   The maximum number of bytes to which a pointer can point. Use for a count that must span the full range of a pointer.
    ///   Equivalent to Windows type SIZE_T.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct PointerSize
    {
        private IntPtr _size;

        /// <summary>
        /// An empty pointer size initialized to zero.
        /// </summary>
        public static readonly PointerSize Zero = new PointerSize(0);

        /// <summary>
        /// Initializes a new instance of the <see cref="PointerSize"/> struct.
        /// </summary>
        /// <param name="size">The size.</param>
        public PointerSize(IntPtr size)
        {
            _size = size;
        }

        /// <summary>
        ///   Default constructor.
        /// </summary>
        /// <param name = "size">value to set</param>
        private unsafe PointerSize(void* size)
        {
            _size = new IntPtr(size);
        }

        /// <summary>
        ///   Default constructor.
        /// </summary>
        /// <param name = "size">value to set</param>
        public PointerSize(int size)
        {
            _size = new IntPtr(size);
        }

        /// <summary>
        ///   Default constructor.
        /// </summary>
        /// <param name = "size">value to set</param>
        public PointerSize(long size)
        {
            _size = new IntPtr(size);
        }

        /// <summary>
        ///   Returns a <see cref = "System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        ///   A <see cref = "System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return string.Format(CultureInfo.CurrentCulture, "{0}", _size);
        }

        /// <summary>
        ///   Returns a <see cref = "System.String" /> that represents this instance.
        /// </summary>
        /// <param name = "format">The format.</param>
        /// <returns>
        ///   A <see cref = "System.String" /> that represents this instance.
        /// </returns>
        public string ToString(string format)
        {
            if (format == null)
                return ToString();

            return string.Format(CultureInfo.CurrentCulture, "{0}", _size.ToString(format));
        }

        /// <summary>
        ///   Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        ///   A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            return _size.ToInt32();
        }

        /// <summary>
        ///   Determines whether the specified <see cref = "PointerSize" /> is equal to this instance.
        /// </summary>
        /// <param name = "other">The <see cref = "PointerSize" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref = "PointerSize" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(PointerSize other)
        {
            return _size == other._size;
        }

        /// <summary>
        ///   Determines whether the specified <see cref = "System.Object" /> is equal to this instance.
        /// </summary>
        /// <param name = "value">The <see cref = "System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref = "System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object value)
        {
            if (value == null)
                return false;

            if (!ReferenceEquals(value.GetType(), typeof(PointerSize)))
                return false;

            return Equals((PointerSize)value);
        }

        /// <summary>
        ///   Adds two sizes.
        /// </summary>
        /// <param name = "left">The first size to add.</param>
        /// <param name = "right">The second size to add.</param>
        /// <returns>The sum of the two sizes.</returns>
        public static PointerSize operator +(PointerSize left, PointerSize right)
        {
            return new PointerSize(left._size.ToInt64() + right._size.ToInt64());
        }

        /// <summary>
        ///   Assert a size (return it unchanged).
        /// </summary>
        /// <param name = "value">The size to assert (unchanged).</param>
        /// <returns>The asserted (unchanged) size.</returns>
        public static PointerSize operator +(PointerSize value)
        {
            return value;
        }

        /// <summary>
        ///   Subtracts two sizes.
        /// </summary>
        /// <param name = "left">The first size to subtract.</param>
        /// <param name = "right">The second size to subtract.</param>
        /// <returns>The difference of the two sizes.</returns>
        public static PointerSize operator -(PointerSize left, PointerSize right)
        {
            return new PointerSize(left._size.ToInt64() - right._size.ToInt64());
        }

        /// <summary>
        ///   Reverses the direction of a given size.
        /// </summary>
        /// <param name = "value">The size to negate.</param>
        /// <returns>A size facing in the opposite direction.</returns>
        public static PointerSize operator -(PointerSize value)
        {
            return new PointerSize(-value._size.ToInt64());
        }

        /// <summary>
        ///   Scales a size by the given value.
        /// </summary>
        /// <param name = "value">The size to scale.</param>
        /// <param name = "scale">The amount by which to scale the size.</param>
        /// <returns>The scaled size.</returns>
        public static PointerSize operator *(int scale, PointerSize value)
        {
            return new PointerSize(scale * value._size.ToInt64());
        }

        /// <summary>
        ///   Scales a size by the given value.
        /// </summary>
        /// <param name = "value">The size to scale.</param>
        /// <param name = "scale">The amount by which to scale the size.</param>
        /// <returns>The scaled size.</returns>
        public static PointerSize operator *(PointerSize value, int scale)
        {
            return new PointerSize(scale * value._size.ToInt64());
        }

        /// <summary>
        ///   Scales a size by the given value.
        /// </summary>
        /// <param name = "value">The size to scale.</param>
        /// <param name = "scale">The amount by which to scale the size.</param>
        /// <returns>The scaled size.</returns>
        public static PointerSize operator /(PointerSize value, int scale)
        {
            return new PointerSize(value._size.ToInt64() / scale);
        }

        /// <summary>
        ///   Tests for equality between two objects.
        /// </summary>
        /// <param name = "left">The first value to compare.</param>
        /// <param name = "right">The second value to compare.</param>
        /// <returns><c>true</c> if <paramref name = "left" /> has the same value as <paramref name = "right" />; otherwise, <c>false</c>.</returns>
        public static bool operator ==(PointerSize left, PointerSize right)
        {
            return left.Equals(right);
        }

        /// <summary>
        ///   Tests for inequality between two objects.
        /// </summary>
        /// <param name = "left">The first value to compare.</param>
        /// <param name = "right">The second value to compare.</param>
        /// <returns><c>true</c> if <paramref name = "left" /> has a different value than <paramref name = "right" />; otherwise, <c>false</c>.</returns>
        public static bool operator !=(PointerSize left, PointerSize right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        ///   Performs an implicit conversion from <see cref = "PointerSize" /> to <see cref = "int" />.
        /// </summary>
        /// <param name = "value">The value.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator int (PointerSize value)
        {
            return value._size.ToInt32();
        }

        /// <summary>
        ///   Performs an implicit conversion from <see cref = "PointerSize" /> to <see cref = "long" />.
        /// </summary>
        /// <param name = "value">The value.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator long (PointerSize value)
        {
            return value._size.ToInt64();
        }

        /// <summary>
        ///   Performs an implicit conversion from <see cref = "PointerSize" /> to <see cref = "int" />.
        /// </summary>
        /// <param name = "value">The value.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator PointerSize(int value)
        {
            return new PointerSize(value);
        }

        /// <summary>
        ///   Performs an implicit conversion from <see cref = "PointerSize" /> to <see cref = "long" />.
        /// </summary>
        /// <param name = "value">The value.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator PointerSize(long value)
        {
            return new PointerSize(value);
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="System.IntPtr"/> to <see cref="PointerSize"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator PointerSize(IntPtr value)
        {
            return new PointerSize(value);
        }

        /// <summary>
        ///   Performs an implicit conversion from <see cref = "PointerSize" /> to <see cref = "IntPtr" />.
        /// </summary>
        /// <param name = "value">The value.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator IntPtr(PointerSize value)
        {
            return value._size;
        }

        /// <summary>
        ///   Performs an implicit conversion from void* to <see cref = "PointerSize" />.
        /// </summary>
        /// <param name = "value">The value.</param>
        /// <returns>The result of the conversion.</returns>
        public static unsafe implicit operator PointerSize(void* value)
        {
            return new PointerSize(value);
        }

        /// <summary>
        ///   Performs an implicit conversion from <see cref = "PointerSize" /> to void*.
        /// </summary>
        /// <param name = "value">The value.</param>
        /// <returns>The result of the conversion.</returns>
        public static unsafe implicit operator void* (PointerSize value)
        {
            return (void*)value._size;
        }
    }
    /// <summary>
    /// Structure using the same layout than <see cref="System.Drawing.Size"/>.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct Size : IEquatable<Size>
    {
        /// <summary>
        /// A zero size with (width, height) = (0,0)
        /// </summary>
        public static readonly Size Zero = new Size(0, 0);

        /// <summary>
        /// A zero size with (width, height) = (0,0)
        /// </summary>
        public static readonly Size Empty = Zero;

        /// <summary>
        /// Initializes a new instance of the <see cref="Size"/> struct.
        /// </summary>
        /// <param name="width">The x.</param>
        /// <param name="height">The y.</param>
        public Size(int width, int height)
        {
            Width = width;
            Height = height;
        }

        /// <summary>
        /// Width.
        /// </summary>
        public int Width;

        /// <summary>
        /// Height.
        /// </summary>
        public int Height;

        /// <summary>
        /// Determines whether the specified <see cref="System.Object"/> is equal to this instance.
        /// </summary>
        /// <param name="other">The <see cref="System.Object"/> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object"/> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(Size other)
        {
            return other.Width == Width && other.Height == Height;
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (obj.GetType() != typeof(Size)) return false;
            return Equals((Size)obj);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            unchecked
            {
                return (Width * 397) ^ Height;
            }
        }

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator ==(Size left, Size right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator !=(Size left, Size right)
        {
            return !left.Equals(right);
        }

        public override string ToString()
        {
            return string.Format("({0},{1})", Width, Height);
        }
    }
    /// <summary>
    /// Structure using the same layout than <see cref="System.Drawing.SizeF"/>.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct Size2F : IEquatable<Size2F>
    {
        /// <summary>
        /// A zero size with (width, height) = (0,0)
        /// </summary>
        public static readonly Size2F Zero = new Size2F(0, 0);

        /// <summary>
        /// A zero size with (width, height) = (0,0)
        /// </summary>
        public static readonly Size2F Empty = Zero;

        /// <summary>
        /// Initializes a new instance of the <see cref="Size2F"/> struct.
        /// </summary>
        /// <param name="width">The x.</param>
        /// <param name="height">The y.</param>
        public Size2F(float width, float height)
        {
            Width = width;
            Height = height;
        }

        /// <summary>
        /// Width.
        /// </summary>
        public float Width;

        /// <summary>
        /// Height.
        /// </summary>
        public float Height;

        /// <summary>
        /// Determines whether the specified <see cref="System.Object"/> is equal to this instance.
        /// </summary>
        /// <param name="other">The <see cref="System.Object"/> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object"/> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(Size2F other)
        {
            return other.Width == Width && other.Height == Height;
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (obj.GetType() != typeof(Size2F)) return false;
            return Equals((Size2F)obj);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            unchecked
            {
                return (Width.GetHashCode() * 397) ^ Height.GetHashCode();
            }
        }

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator ==(Size2F left, Size2F right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator !=(Size2F left, Size2F right)
        {
            return !left.Equals(right);
        }

        public override string ToString()
        {
            return string.Format("({0},{1})", Width, Height);
        }
    }
    /// <summary>
    /// Содержит набор из четырех целых чисел, определяющих расположение и размер прямоугольника.
    /// </summary>
    [Serializable]
    public struct Rectangle
    {
        /// <summary>Представляет структуру <see cref="Rectangle"/>, свойства которой не инициализированы.</summary>
        /// <filterpriority>1</filterpriority>
        public static readonly Rectangle Empty;
        private int x;
        private int y;
        private int width;
        private int height;
        /// <summary>Возвращает или задает координаты левого верхнего угла структуры <see cref="Rectangle"/>.</summary>
        /// <returns>Объект <see cref="T:System.Drawing.Point" />, представляющий верхний левый угол структуры <see cref="Rectangle"/>.</returns>
        public Point Location
        {
            get
            {
                return new Point(this.X, this.Y);
            }
            set
            {
                this.X = value.X;
                this.Y = value.Y;
            }
        }
        /// <summary>Получает или задает координату по оси X левого верхнего угла структуры <see cref="Rectangle"/>.</summary>
        /// <returns>Координата по оси X верхнего левого угла структуры <see cref="Rectangle"/>.Значение по умолчанию — 0.</returns>
        /// <filterpriority>1</filterpriority>
        public int X
        {
            get
            {
                return this.x;
            }
            set
            {
                this.x = value;
            }
        }
        /// <summary>Получает или задает координату по оси Y левого верхнего угла структуры <see cref="Rectangle"/>.</summary>
        /// <returns>Координата по оси Y верхнего левого угла структуры <see cref="Rectangle"/>.Значение по умолчанию — 0.</returns>
        public int Y
        {
            get
            {
                return this.y;
            }
            set
            {
                this.y = value;
            }
        }
        /// <summary>Возвращает или задает ширину структуры <see cref="Rectangle"/>.</summary>
        /// <returns>Ширина этой структуры <see cref="Rectangle"/>.Значение по умолчанию — 0.</returns>
        public int Width
        {
            get
            {
                return this.width;
            }
            set
            {
                this.width = value;
            }
        }
        /// <summary>Возвращает или задает высоту в структуре <see cref="Rectangle"/>.</summary>
        /// <returns>Высота этой структуры <see cref="Rectangle"/>.Значение по умолчанию — 0.</returns>
        public int Height
        {
            get
            {
                return this.height;
            }
            set
            {
                this.height = value;
            }
        }
        /// <summary>Возвращает координату по оси X левого края структуры <see cref="Rectangle"/>.</summary>
        /// <returns>Координата по оси X левого края структуры <see cref="Rectangle"/>.</returns>
        public int Left
        {
            get
            {
                return this.X;
            }
        }
        /// <summary>Возвращает координату по оси Y верхнего края структуры <see cref="Rectangle"/>.</summary>
        /// <returns>Координата по оси Y верхнего края структуры <see cref="Rectangle"/>.</returns>
        public int Top
        {
            get
            {
                return this.Y;
            }
        }
        /// <summary>Возвращает координату по оси X, являющуюся суммой значений свойств <see cref="P:System.Drawing.Rectangle.X" /> и <see cref="Rectangle.Width"/> данной структуры <see cref="Rectangle"/>.</summary>
        /// <returns>Координата по оси X, являющаяся суммой значений свойств <see cref="P:System.Drawing.Rectangle.X" /> и <see cref="Rectangle.Width"/> данной структуры <see cref="Rectangle"/>.</returns>
        public int Right
        {
            get
            {
                return this.X + this.Width;
            }
        }
        /// <summary>Возвращает координату по оси Y, являющуюся суммой значений свойств <see cref="Rectangle.Y"/> <see cref="Rectangle.Y"/> и <see cref="Rectangle.Height"/> данной структуры <see cref="Rectangle"/>.</summary>
        /// <returns>Координата по оси Y, являющаяся суммой значений свойств <see cref="Rectangle.Y"/> и <see cref="Rectangle.Height"/> данной структуры <see cref="Rectangle"/>.</returns>
        public int Bottom
        {
            get
            {
                return this.Y + this.Height;
            }
        }
        public bool IsEmpty
        {
            get
            {
                return this.height == 0 && this.width == 0 && this.x == 0 && this.y == 0;
            }
        }
        /// <summary>Инициализирует новый экземпляр класса <see cref="Rectangle"/> с указанным расположением и размером.</summary>
        /// <param name="x">Координата по оси X верхнего левого угла прямоугольника. </param>
        /// <param name="y">Координата по оси Y верхнего левого угла прямоугольника. </param>
        /// <param name="width">Ширина прямоугольника. </param>
        /// <param name="height">Высота прямоугольника. </param>
        public Rectangle(int x, int y, int width, int height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }
        /// <summary>Создает структуру <see cref="Rectangle"/> с заданным положением краев.</summary>
        /// <returns>Новый объект <see cref="Rectangle"/>, созданный данным методом.</returns>
        /// <param name="left">Координата по оси X верхнего левого угла структуры <see cref="Rectangle"/>. </param>
        /// <param name="top">Координата по оси Y верхнего левого угла структуры <see cref="Rectangle"/>. </param>
        /// <param name="right">Координата по оси X нижнего правого угла структуры <see cref="Rectangle"/>. </param>
        /// <param name="bottom">Координата по оси Y нижнего правого угла структуры <see cref="Rectangle"/>. </param>
        /// <filterpriority>1</filterpriority>
        public static Rectangle FromLTRB(int left, int top, int right, int bottom)
        {
            return new Rectangle(left, top, right - left, bottom - top);
        }
        /// <summary>Проверяет, является ли <paramref name="obj" /> структурой <see cref="Rectangle"/> с таким же расположением и размером, что и структура <see cref="Rectangle"/>.</summary>
        /// <returns>Этот метод возвращает значение true, если параметр <paramref name="obj" /> является структурой <see cref="Rectangle"/>, и ее свойства <see cref="P:System.Drawing.Rectangle.X" />, <see cref="Rectangle.Y"/>, <see cref="Rectangle.Width"/> и <see cref="Rectangle.Height"/> равны соответствующим свойствам данной структуры <see cref="Rectangle"/>; в противном случае — значение false.</returns>
        /// <param name="obj">Объект <see cref="T:System.Object" /> для проверки. </param>
        /// <filterpriority>1</filterpriority>
        public override bool Equals(object obj)
        {
            if (!(obj is Rectangle))
            {
                return false;
            }
            Rectangle rectangle = (Rectangle)obj;
            return rectangle.X == this.X && rectangle.Y == this.Y && rectangle.Width == this.Width && rectangle.Height == this.Height;
        }
        /// <summary>Проверяет, имеют ли две структуры <see cref="Rectangle"/> одинаковое положение и размер.</summary>
        /// <returns>Этот оператор возвращает значение true, если у двух структур <see cref="Rectangle"/> равны свойства <see cref="P:System.Drawing.Rectangle.X" />, <see cref="Rectangle.Y"/>, <see cref="Rectangle.Width"/> и <see cref="Rectangle.Height"/>.</returns>
        /// <param name="left">Структура <see cref="Rectangle"/>, которая находится слева от оператора равенства. </param>
        /// <param name="right">Структура <see cref="Rectangle"/>, которая находится справа от оператора равенства. </param>
        /// <filterpriority>3</filterpriority>
        public static bool operator ==(Rectangle left, Rectangle right)
        {
            return left.X == right.X && left.Y == right.Y && left.Width == right.Width && left.Height == right.Height;
        }
        /// <summary>Проверяет, различаются ли две структуры <see cref="Rectangle"/> по положению или размеру.</summary>
        /// <returns>Этот оператор возвращает значение true, если значения каких-либо из свойств <see cref="P:System.Drawing.Rectangle.X" />, <see cref="Rectangle.Y"/>, <see cref="Rectangle.Width"/> или <see cref="Rectangle.Height"/> двух структур <see cref="Rectangle"/> не совпадают; в противном случае — значение false.</returns>
        /// <param name="left">Структура <see cref="Rectangle"/>, которая находится слева от оператора неравенства. </param>
        /// <param name="right">Структура <see cref="Rectangle"/>, которая находится справа от оператора неравенства. </param>
        /// <filterpriority>3</filterpriority>
        public static bool operator !=(Rectangle left, Rectangle right)
        {
            return !(left == right);
        }
        /// <summary>Определяет, содержится ли заданная точка в структуре <see cref="Rectangle"/>.</summary>
        /// <returns>Этот метод возвращает значение true, если точка, определенная параметрами <paramref name="x" /> и <paramref name="y" />, содержится в структуре <see cref="Rectangle"/>; в противном случае — значение false.</returns>
        /// <param name="x">Координата тестируемой точки по оси X. </param>
        /// <param name="y">Координата тестируемой точки по оси Y. </param>
        /// <filterpriority>1</filterpriority>
        public bool Contains(int x, int y)
        {
            return this.X <= x && x < this.X + this.Width && this.Y <= y && y < this.Y + this.Height;
        }
        /// <summary>Определяет, содержится ли заданная точка в структуре <see cref="Rectangle"/>.</summary>
        /// <returns>Этот метод возвращает значение true, если точка, представленная <paramref name="pt" />, содержится в структуре <see cref="Rectangle"/>; в противном случае — значение false.</returns>
        /// <param name="pt">Объект <see cref="T:System.Drawing.Point" /> для проверки. </param>
        /// <filterpriority>1</filterpriority>
        public bool Contains(Point pt)
        {
            return this.Contains(pt.X, pt.Y);
        }
        /// <summary>Определяет, содержится ли вся прямоугольная область, представленная параметром <paramref name="rect" />, в структуре <see cref="Rectangle"/>.</summary>
        /// <returns>Этот метод возвращает значение true, если прямоугольная область, представленная параметром <paramref name="rect" />, полностью содержится в структуре <see cref="Rectangle"/>; в противном случае — значение false.</returns>
        /// <param name="rect">Объект <see cref="Rectangle"/> для проверки. </param>
        /// <filterpriority>1</filterpriority>
        public bool Contains(Rectangle rect)
        {
            return this.X <= rect.X && rect.X + rect.Width <= this.X + this.Width && this.Y <= rect.Y && rect.Y + rect.Height <= this.Y + this.Height;
        }
        /// <summary>Возвращает хэш-код для этой структуры <see cref="Rectangle"/>.Дополнительные сведения об использовании хэш-кодов см. в разделе <see cref="M:System.Object.GetHashCode" />.</summary>
        /// <returns>Целое число, представляющее хэш-код для этого прямоугольника.</returns>
        /// <filterpriority>1</filterpriority>
        public override int GetHashCode()
        {
            return this.X ^ (this.Y << 13 | (int)((uint)this.Y >> 19)) ^ (this.Width << 26 | (int)((uint)this.Width >> 6)) ^ (this.Height << 7 | (int)((uint)this.Height >> 25));
        }
        /// <summary>Увеличивает данный объект <see cref="Rectangle"/> на заданную величину.</summary>
        /// <param name="width">Величина, на которую требуется увеличить данный прямоугольник <see cref="Rectangle"/> в горизонтальном направлении. </param>
        /// <param name="height">Величина, на которую требуется увеличить данный прямоугольник <see cref="Rectangle"/> в вертикальном направлении. </param>
        /// <filterpriority>1</filterpriority>
        public void Inflate(int width, int height)
        {
            this.X -= width;
            this.Y -= height;
            this.Width += 2 * width;
            this.Height += 2 * height;
        }
        /// <summary>Создает и возвращает увеличенную копию заданной структуры <see cref="Rectangle"/>.Копия увеличивается на заданную величину.Исходная структура <see cref="Rectangle"/> остается без изменений.</summary>
        /// <returns>Увеличенный объект <see cref="Rectangle"/>.</returns>
        /// <param name="rect">
        ///   <see cref="Rectangle"/>, являющийся исходным.Этот прямоугольник не изменяется.</param>
        /// <param name="x">Величина, на которую требуется увеличить данный прямоугольник <see cref="Rectangle"/> в горизонтальном направлении. </param>
        /// <param name="y">Величина, на которую требуется увеличить данный прямоугольник <see cref="Rectangle"/> в вертикальном направлении. </param>
        /// <filterpriority>1</filterpriority>
        public static Rectangle Inflate(Rectangle rect, int x, int y)
        {
            Rectangle result = rect;
            result.Inflate(x, y);
            return result;
        }
        /// <summary>Заменяет данный <see cref="Rectangle"/> его пересечением с указанным прямоугольником <see cref="Rectangle"/>.</summary>
        /// <param name="rect">
        ///   <see cref="Rectangle"/>, с которым происходит пересечение. </param>
        /// <filterpriority>1</filterpriority>
        public void Intersect(Rectangle rect)
        {
            Rectangle rectangle = Rectangle.Intersect(rect, this);
            this.X = rectangle.X;
            this.Y = rectangle.Y;
            this.Width = rectangle.Width;
            this.Height = rectangle.Height;
        }
        /// <summary>Возвращает третью структуру <see cref="Rectangle"/>, представляющую собой пересечение двух других структур <see cref="Rectangle"/>.Если пересечение отсутствует, возвращается пустая структура <see cref="Rectangle"/>.</summary>
        /// <returns>Прямоугольник <see cref="Rectangle"/>, представляющий собой пересечение параметров <paramref name="a" /> и <paramref name="b" />.</returns>
        /// <param name="a">Прямоугольник для пересечения. </param>
        /// <param name="b">Прямоугольник для пересечения. </param>
        /// <filterpriority>1</filterpriority>
        public static Rectangle Intersect(Rectangle a, Rectangle b)
        {
            int num = Math.Max(a.X, b.X);
            int num2 = Math.Min(a.X + a.Width, b.X + b.Width);
            int num3 = Math.Max(a.Y, b.Y);
            int num4 = Math.Min(a.Y + a.Height, b.Y + b.Height);
            if (num2 >= num && num4 >= num3)
            {
                return new Rectangle(num, num3, num2 - num, num4 - num3);
            }
            return Rectangle.Empty;
        }
        /// <summary>Определяет, пересекается ли данный прямоугольник с прямоугольником <paramref name="rect" />.</summary>
        /// <returns>При наличии пересечения этот метод возвращает значение true, в противном случае возвращается значение false.</returns>
        /// <param name="rect">Прямоугольник для проверки. </param>
        /// <filterpriority>1</filterpriority>
        public bool IntersectsWith(Rectangle rect)
        {
            return rect.X < this.X + this.Width && this.X < rect.X + rect.Width && rect.Y < this.Y + this.Height && this.Y < rect.Y + rect.Height;
        }
        /// <summary>Получает структуру <see cref="Rectangle"/>, содержащую объединение двух структур прямоугольника <see cref="Rectangle"/>.</summary>
        /// <returns>Структура <see cref="Rectangle"/>, заключающая в себе объединение двух структур <see cref="Rectangle"/>.</returns>
        /// <param name="a">Прямоугольник, предназначенный для объединения. </param>
        /// <param name="b">Прямоугольник, предназначенный для объединения. </param>
        /// <filterpriority>1</filterpriority>
        public static Rectangle Union(Rectangle a, Rectangle b)
        {
            int num = Math.Min(a.X, b.X);
            int num2 = Math.Max(a.X + a.Width, b.X + b.Width);
            int num3 = Math.Min(a.Y, b.Y);
            int num4 = Math.Max(a.Y + a.Height, b.Y + b.Height);
            return new Rectangle(num, num3, num2 - num, num4 - num3);
        }
        /// <summary>Изменяет положение этого прямоугольника на указанную величину.</summary>
        /// <param name="pos">Величина, на которую смещается положение. </param>
        /// <filterpriority>1</filterpriority>
        public void Offset(Point pos)
        {
            this.Offset(pos.X, pos.Y);
        }
        /// <summary>Изменяет положение этого прямоугольника на указанную величину.</summary>
        /// <param name="x">Горизонтальное смещение. </param>
        /// <param name="y">Вертикальное смещение. </param>
        /// <filterpriority>1</filterpriority>
        public void Offset(int x, int y)
        {
            this.X += x;
            this.Y += y;
        }
        /// <summary>Преобразует атрибуты этого прямоугольника <see cref="Rectangle"/> в удобную для восприятия строку.</summary>
        /// <returns>Строка, содержащая положение, ширину и высоту структуры <see cref="Rectangle"/>, например: {X=20, Y=20, Width=100, Height=50}. </returns>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode" />
        /// </PermissionSet>
        public override string ToString()
        {
            return string.Concat(new string[]
            {
                "{X=",
                this.X.ToString(CultureInfo.CurrentCulture),
                ",Y=",
                this.Y.ToString(CultureInfo.CurrentCulture),
                ",Width=",
                this.Width.ToString(CultureInfo.CurrentCulture),
                ",Height=",
                this.Height.ToString(CultureInfo.CurrentCulture),
                "}"
            });
        }
    }
    /// <summary>
    /// Представляет упорядоченную пару целых чисел — координат Х и Y, определяющую точку на двумерной плоскости.
    /// </summary>
	[YamlSerialize(YamlSerializeMethod.Assign)]
    public struct Point
    {
        /// <summary>Представляет объект <see cref="T:System.Drawing.Point" />, у которого значения <see cref="P:System.Drawing.Point.X" /> и <see cref="P:System.Drawing.Point.Y" /> установлены равными нулю. </summary>
        /// <filterpriority>1</filterpriority>
        public static readonly Point Empty;
        private int x;
        private int y;
        /// <summary>Получает значение, определяющее, пуст ли класс <see cref="T:System.Drawing.Point" />.</summary>
        /// <returns>Значениеtrue, если оба свойства <see cref="P:System.Drawing.Point.X" /> и <see cref="P:System.Drawing.Point.Y" /> равны 0, в противном случае возвращается значение false.</returns>
        /// <filterpriority>1</filterpriority>
        public bool IsEmpty
        {
            get
            {
                return this.x == 0 && this.y == 0;
            }
        }
        /// <summary>Получает или задает координату Х точки <see cref="T:System.Drawing.Point" />.</summary>
        /// <returns>Координата Х точки <see cref="T:System.Drawing.Point" />.</returns>
        /// <filterpriority>1</filterpriority>
        public int X
        {
            get
            {
                return this.x;
            }
            set
            {
                this.x = value;
            }
        }
        /// <summary>Получает или задает координату Y точки <see cref="T:System.Drawing.Point" />.</summary>
        /// <returns>Координата Y точки <see cref="T:System.Drawing.Point" />.</returns>
        /// <filterpriority>1</filterpriority>
        public int Y
        {
            get
            {
                return this.y;
            }
            set
            {
                this.y = value;
            }
        }
        /// <summary>Инициализирует новый экземпляр класса <see cref="T:System.Drawing.Point" /> с указанными координатами.</summary>
        /// <param name="x">Положение точки по горизонтали. </param>
        /// <param name="y">Положение точки по вертикали. </param>
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        /// <summary>Инициализирует новый экземпляр класса <see cref="T:System.Drawing.Point" />, используя в качестве координат указанное целое значение.</summary>
        /// <param name="dw">32-разрядное целое число, задающее координаты для нового объекта <see cref="T:System.Drawing.Point" />. </param>
        public Point(int dw)
        {
            this.x = (int)((short)Point.LOWORD(dw));
            this.y = (int)((short)Point.HIWORD(dw));
        }
        /// <summary>Преобразует заданную структуру <see cref="T:System.Drawing.Point" /> в структуру <see cref="T:System.Drawing.Size" />.</summary>
        /// <returns>Объект <see cref="T:System.Drawing.Size" />, являющийся результатом преобразования.</returns>
        /// <param name="p">Преобразуемый объект <see cref="T:System.Drawing.Point" />.</param>
        /// <filterpriority>3</filterpriority>
        public static explicit operator Size(Point p)
        {
            return new Size(p.X, p.Y);
        }
        /// <summary>Сравнивает два объекта <see cref="T:System.Drawing.Point" />.Результат определяет, равны значения свойств <see cref="P:System.Drawing.Point.X" /> и <see cref="P:System.Drawing.Point.Y" /> двух объектов <see cref="T:System.Drawing.Point" /> или нет.</summary>
        /// <returns>Значение true, если значения <see cref="P:System.Drawing.Point.X" /> и <see cref="P:System.Drawing.Point.Y" /> параметров <paramref name="left" /> и <paramref name="right" /> равны, в противном случае значение false.</returns>
        /// <param name="left">Объект <see cref="T:System.Drawing.Point" /> для сравнения. </param>
        /// <param name="right">Объект <see cref="T:System.Drawing.Point" /> для сравнения. </param>
        /// <filterpriority>3</filterpriority>
        public static bool operator ==(Point left, Point right)
        {
            return left.X == right.X && left.Y == right.Y;
        }
        /// <summary>Сравнивает два объекта <see cref="T:System.Drawing.Point" />.Результат показывает неравенство значений свойств <see cref="P:System.Drawing.Point.X" /> или <see cref="P:System.Drawing.Point.Y" /> двух объектов <see cref="T:System.Drawing.Point" />.</summary>
        /// <returns>Значение true, если значения либо свойств <see cref="P:System.Drawing.Point.X" />, либо свойств <see cref="P:System.Drawing.Point.Y" /> параметров <paramref name="left" /> и <paramref name="right" /> отличаются, в противном случае значение false.</returns>
        /// <param name="left">Объект <see cref="T:System.Drawing.Point" /> для сравнения. </param>
        /// <param name="right">Объект <see cref="T:System.Drawing.Point" /> для сравнения. </param>
        /// <filterpriority>3</filterpriority>
        public static bool operator !=(Point left, Point right)
        {
            return !(left == right);
        }
        /// <summary>Определяет, содержит объект ли <see cref="T:System.Drawing.Point" /> те же координаты, что и указанный объект <see cref="T:System.Object" />, или нет.</summary>
        /// <returns>Значение true, если параметром <paramref name="obj" /> является объект <see cref="T:System.Drawing.Point" /> с тем же координатами, что и у объекта <see cref="T:System.Drawing.Point" />.</returns>
        /// <param name="obj">Объект <see cref="T:System.Object" /> для проверки. </param>
        /// <filterpriority>1</filterpriority>
        public override bool Equals(object obj)
        {
            if (!(obj is Point))
            {
                return false;
            }
            Point point = (Point)obj;
            return point.X == this.X && point.Y == this.Y;
        }
        /// <summary>Возвращает хэш-код для объекта <see cref="T:System.Drawing.Point" />.</summary>
        /// <returns>Целочисленное значение, определяющее хэш-код для этой структуры <see cref="T:System.Drawing.Point" />.</returns>
        /// <filterpriority>1</filterpriority>
        public override int GetHashCode()
        {
            return this.x ^ this.y;
        }
        /// <summary>Смещает точку <see cref="T:System.Drawing.Point" /> на указанное значение.</summary>
        /// <param name="dx">Число для смещения координаты Х. </param>
        /// <param name="dy">Число для смещения координаты Y. </param>
        /// <filterpriority>1</filterpriority>
        public void Offset(int dx, int dy)
        {
            this.X += dx;
            this.Y += dy;
        }
        /// <summary>Смещает точку <see cref="T:System.Drawing.Point" /> на указанную точку <see cref="T:System.Drawing.Point" />.</summary>
        /// <param name="p">Точка <see cref="T:System.Drawing.Point" />, полученная смещением на значения точки <see cref="T:System.Drawing.Point" />.</param>
        public void Offset(Point p)
        {
            this.Offset(p.X, p.Y);
        }
        /// <summary>Преобразует объект <see cref="T:System.Drawing.Point" /> в строку, доступную для чтения.</summary>
        /// <returns>Строка, представляющая точку <see cref="T:System.Drawing.Point" />.</returns>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode" />
        /// </PermissionSet>
        public override string ToString()
        {
            return string.Concat(new string[]
            {
                "{X=",
                this.X.ToString(CultureInfo.CurrentCulture),
                ",Y=",
                this.Y.ToString(CultureInfo.CurrentCulture),
                "}"
            });
        }
        private static int HIWORD(int n)
        {
            return n >> 16 & 65535;
        }
        private static int LOWORD(int n)
        {
            return n & 65535;
        }
    }
    public struct RECT
    {
        public int left;
        public int top;
        public int right;
        public int bottom;
        public Size Size
        {
            get
            {
                return new Size(this.right - this.left, this.bottom - this.top);
            }
        }
        public RECT(int left, int top, int right, int bottom)
        {
            this.left = left;
            this.top = top;
            this.right = right;
            this.bottom = bottom;
        }
        public RECT(Rectangle r)
        {
            this.left = r.Left;
            this.top = r.Top;
            this.right = r.Right;
            this.bottom = r.Bottom;
        }
        public static RECT FromXYWH(int x, int y, int width, int height)
        {
            return new RECT(x, y, x + width, y + height);
        }
    }
    public struct MARGINS
    {
        public int cxLeftWidth;
        public int cxRightWidth;
        public int cyTopHeight;
        public int cyBottomHeight;
    }

    /// <summary>
    /// Determines the concurrency model used for incoming calls to objects created by this thread. 
    /// This concurrency model can be either apartment-threaded or multi-threaded.
    /// </summary>
    public enum CoInit
    {
        /// <summary>
        /// Initializes the thread for apartment-threaded object concurrency.
        /// </summary>
        MultiThreaded = 0x0,

        /// <summary>
        /// Initializes the thread for multi-threaded object concurrency.
        /// </summary>
        ApartmentThreaded = 0x2,

        /// <summary>
        /// Disables DDE for OLE1 support.
        /// </summary>
        DisableOle1Dde = 0x4,

        /// <summary>
        /// Trade memory for speed.
        /// </summary>
        SpeedOverMemory = 0x8
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct MultiQueryInterface
    {
        public IntPtr InterfaceIID;
        public IntPtr IUnknownPointer;
        public Result ResultCode;
    };
    [Flags]
    public enum CLSCTX : uint
    {
        ClsctxInprocServer = 0x1,
        ClsctxInprocHandler = 0x2,
        ClsctxLocalServer = 0x4,
        ClsctxInprocServer16 = 0x8,
        ClsctxRemoteServer = 0x10,
        ClsctxInprocHandler16 = 0x20,
        ClsctxReserved1 = 0x40,
        ClsctxReserved2 = 0x80,
        ClsctxReserved3 = 0x100,
        ClsctxReserved4 = 0x200,
        ClsctxNoCodeDownload = 0x400,
        ClsctxReserved5 = 0x800,
        ClsctxNoCustomMarshal = 0x1000,
        ClsctxEnableCodeDownload = 0x2000,
        ClsctxNoFailureLog = 0x4000,
        ClsctxDisableAaa = 0x8000,
        ClsctxEnableAaa = 0x10000,
        ClsctxFromDefaultContext = 0x20000,
        ClsctxInproc = ClsctxInprocServer | ClsctxInprocHandler,
        ClsctxServer = ClsctxInprocServer | ClsctxLocalServer | ClsctxRemoteServer,
        ClsctxAll = ClsctxServer | ClsctxInprocHandler
    }
    public delegate int ListViewCompareCallback(IntPtr lParam1, IntPtr lParam2, IntPtr lParamSort);
    public delegate int TreeViewCompareCallback(IntPtr lParam1, IntPtr lParam2, IntPtr lParamSort);
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public class FONTDESC
    {
        public int cbSizeOfStruct = Marshal.SizeOf(typeof(FONTDESC));
        public string lpstrName;
        public long cySize;
        public short sWeight;
        public short sCharset;
        public bool fItalic;
        public bool fUnderline;
        public bool fStrikethrough;
    }
    [StructLayout(LayoutKind.Sequential)]
    public class PICTDESCbmp
    {
        public int cbSizeOfStruct = Marshal.SizeOf(typeof(PICTDESCbmp));
        public int picType = 1;
        public IntPtr hbitmap = IntPtr.Zero;
        public IntPtr hpalette = IntPtr.Zero;
        public int unused;
    }
    [StructLayout(LayoutKind.Sequential)]
    public class PICTDESCicon
    {
        public int cbSizeOfStruct = Marshal.SizeOf(typeof(PICTDESCicon));
        public int picType = 3;
        public IntPtr hicon = IntPtr.Zero;
        public int unused1;
        public int unused2;
    }
    [StructLayout(LayoutKind.Sequential)]
    public class PICTDESCemf
    {
        public int cbSizeOfStruct = Marshal.SizeOf(typeof(PICTDESCemf));
        public int picType = 4;
        public IntPtr hemf = IntPtr.Zero;
        public int unused1;
        public int unused2;
    }
    [StructLayout(LayoutKind.Sequential)]
    public class USEROBJECTFLAGS
    {
        public int fInherit;
        public int fReserved;
        public int dwFlags;
    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public class SYSTEMTIMEARRAY
    {
        public short wYear1;
        public short wMonth1;
        public short wDayOfWeek1;
        public short wDay1;
        public short wHour1;
        public short wMinute1;
        public short wSecond1;
        public short wMilliseconds1;
        public short wYear2;
        public short wMonth2;
        public short wDayOfWeek2;
        public short wDay2;
        public short wHour2;
        public short wMinute2;
        public short wSecond2;
        public short wMilliseconds2;
    }
    public delegate bool EnumChildrenCallback(IntPtr hwnd, IntPtr lParam);
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public class HH_AKLINK
    {
        public int cbStruct = Marshal.SizeOf(typeof(HH_AKLINK));
        public bool fReserved;
        public string pszKeywords;
        public string pszUrl;
        public string pszMsgText;
        public string pszMsgTitle;
        public string pszWindow;
        public bool fIndexOnFail;
    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public class HH_POPUP
    {
        public int cbStruct = Marshal.SizeOf(typeof(HH_POPUP));
        public IntPtr hinst = IntPtr.Zero;
        public int idString;
        public IntPtr pszText;
        public POINT pt;
        public int clrForeground = -1;
        public int clrBackground = -1;
        public RECT rcMargins = RECT.FromXYWH(-1, -1, -1, -1);
        public string pszFont;
    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public class HH_FTS_QUERY
    {
        public int cbStruct = Marshal.SizeOf(typeof(HH_FTS_QUERY));
        public bool fUniCodeStrings;
        [MarshalAs(UnmanagedType.LPStr)]
        public string pszSearchQuery;
        public int iProximity = -1;
        public bool fStemmedSearch;
        public bool fTitleOnly;
        public bool fExecute = true;
        [MarshalAs(UnmanagedType.LPStr)]
        public string pszWindow;
    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto, Pack = 4)]
    public class MONITORINFOEX
    {
        public int cbSize = Marshal.SizeOf(typeof(MONITORINFOEX));
        public RECT rcMonitor;
        public RECT rcWork;
        public int dwFlags;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public char[] szDevice = new char[32];
    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto, Pack = 4)]
    public class MONITORINFO
    {
        public int cbSize = Marshal.SizeOf(typeof(MONITORINFO));
        public RECT rcMonitor;
        public RECT rcWork;
        public int dwFlags;
    }
    public delegate int EditStreamCallback(IntPtr dwCookie, IntPtr buf, int cb, out int transferred);
    [StructLayout(LayoutKind.Sequential)]
    public class EDITSTREAM
    {
        public IntPtr dwCookie = IntPtr.Zero;
        public int dwError;
        public EditStreamCallback pfnCallback;
    }
    [StructLayout(LayoutKind.Sequential)]
    public class EDITSTREAM64
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        public byte[] contents = new byte[20];
    }
    /// <summary>
    /// Задает угол экрана.
    /// </summary>
	public enum ScreenOrientation
    {
        /// <summary>
        /// Экран ориентирован под углом в 0 градусов.
        /// </summary>
        Angle0,
        /// <summary>
        /// Экран ориентирован под углом в 90 градусов.
        /// </summary>
        Angle90,
        /// <summary>
        /// Экран ориентирован под углом в 180 градусов.
        /// </summary>
        Angle180,
        /// <summary>
        /// Экран ориентирован под углом в 270 градусов.
        /// </summary>
        Angle270
    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct DEVMODE
    {
        private const int CCHDEVICENAME = 32;
        private const int CCHFORMNAME = 32;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string dmDeviceName;
        public short dmSpecVersion;
        public short dmDriverVersion;
        public short dmSize;
        public short dmDriverExtra;
        public int dmFields;
        public int dmPositionX;
        public int dmPositionY;
        public ScreenOrientation dmDisplayOrientation;
        public int dmDisplayFixedOutput;
        public short dmColor;
        public short dmDuplex;
        public short dmYResolution;
        public short dmTTOption;
        public short dmCollate;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string dmFormName;
        public short dmLogPixels;
        public int dmBitsPerPel;
        public int dmPelsWidth;
        public int dmPelsHeight;
        public int dmDisplayFlags;
        public int dmDisplayFrequency;
        public int dmICMMethod;
        public int dmICMIntent;
        public int dmMediaType;
        public int dmDitherType;
        public int dmReserved1;
        public int dmReserved2;
        public int dmPanningWidth;
        public int dmPanningHeight;
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct SYSTEM_INFO
    {
        public _PROCESSOR_INFO_UNION uProcessorInfo;
        public uint dwPageSize;
        public IntPtr lpMinimumApplicationAddress;
        public IntPtr lpMaximumApplicationAddress;
        public IntPtr dwActiveProcessorMask;
        public uint dwNumberOfProcessors;
        public uint dwProcessorType;
        public uint dwAllocationGranularity;
        public ushort dwProcessorLevel;
        public ushort dwProcessorRevision;
    }
    [StructLayout(LayoutKind.Explicit)]
    public struct _PROCESSOR_INFO_UNION
    {
        [FieldOffset(0)]
        public uint dwOemId;
        [FieldOffset(0)]
        public ushort wProcessorArchitecture;
        [FieldOffset(2)]
        public ushort wReserved;
    }
    public static class NativeStruct
    {
        public struct KeyBoardHookStruct
        {
            public int vkCode;
            public int scanCode;
            public int flags;
            public int time;
            public int dwExtraInfo;
        }
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct MousePoint
    {
        public int X;
        public int Y;

        public MousePoint(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
    public static class NativeMethods
    {
        /// <summary>
        /// Determines whether the type inherits from the specified type (used to determine a type without using an explicit type instance).
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="parentType">Name of the parent type to find in inheritance hierarchy of type.</param>
        /// <returns><c>true</c> if the type inherits from the specified type; otherwise, <c>false</c>.</returns>
        public static bool IsTypeInheritFrom(Type type, string parentType)
        {
            while (type != null)
            {
                if (type.FullName == parentType)
                {
                    return true;
                }
                type = type.GetTypeInfo().BaseType;
            }

            return false;
        }
        /// <summary>
        /// Selects distinct elements from an enumeration.
        /// </summary>
        /// <typeparam name="TSource">The type of the T source.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="comparer">The comparer.</param>
        /// <returns>A enumeration of selected values</returns>
        public static IEnumerable<TSource> Distinct<TSource>(IEnumerable<TSource> source, IEqualityComparer<TSource> comparer = null)
        {
            if (comparer == null)
                comparer = EqualityComparer<TSource>.Default;

            // using Dictionary is not really efficient but easy to implement
            var values = new Dictionary<TSource, object>(comparer);
            foreach (TSource sourceItem in source)
            {
                if (!values.ContainsKey(sourceItem))
                {
                    values.Add(sourceItem, null);
                    yield return sourceItem;
                }
            }
        }
        /// <summary>
        /// Select elements from an enumeration.
        /// </summary>
        /// <typeparam name="TSource">The type of the T source.</typeparam>
        /// <typeparam name="TResult">The type of the T result.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="selector">The selector.</param>
        /// <returns>A enumeration of selected values</returns>
        public static IEnumerable<TResult> SelectMany<TSource, TResult>(IEnumerable<TSource> source, Func<TSource, IEnumerable<TResult>> selector)
        {
            foreach (TSource sourceItem in source)
            {
                foreach (TResult result in selector(sourceItem))
                    yield return result;
            }
        }
        /// <summary>
        /// Test if there is an element in this enumeration.
        /// </summary>
        /// <typeparam name="T">Type of the element</typeparam>
        /// <param name="source">The enumerable source.</param>
        /// <returns><c>true</c> if there is an element in this enumeration, <c>false</c> otherwise</returns>
        public static bool Any<T>(IEnumerable<T> source)
        {
            return source.GetEnumerator().MoveNext();
        }
        /// <summary>
        /// Transforms an <see cref="IEnumerable{T}"/> to an array of T.
        /// </summary>
        /// <typeparam name="T">Type of the element</typeparam>
        /// <param name="source">The enumerable source.</param>
        /// <returns>an array of T</returns>
        public static T[] ToArray<T>(IEnumerable<T> source)
        {
            return new RBuffer<T>(source).ToArray();
        }
        /// <summary>
        /// Safely dispose a reference if not null, and set it to null after dispose.
        /// </summary>
        /// <typeparam name="T">The type of COM interface to dispose.</typeparam>
        /// <param name="comObject">Object to dispose.</param>
        /// <remarks>
        /// The reference will be set to null after dispose.
        /// </remarks>
        public static void Dispose<T>(ref T comObject) where T : class, IDisposable
        {
            if (comObject != null)
            {
                comObject.Dispose();
                comObject = null;
            }
        }
        /// <summary>
        /// Compute a FNV1-modified Hash from <a href="http://bretm.home.comcast.net/~bretm/hash/6.html">Fowler/Noll/Vo Hash</a> improved version.
        /// </summary>
        /// <param name="data">Data to compute the hash from.</param>
        /// <returns>A hash value.</returns>
        public static int ComputeHashFNVModified(byte[] data)
        {
            const uint p = 16777619;
            uint hash = 2166136261;
            foreach (byte b in data)
                hash = (hash ^ b) * p;
            hash += hash << 13;
            hash ^= hash >> 7;
            hash += hash << 3;
            hash ^= hash >> 17;
            hash += hash << 5;
            return unchecked((int)hash);
        }
        [DllImport("kernel32", EntryPoint = "GetProcAddress", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        static extern IntPtr GetProcAddress_(IntPtr hModule, string procName);
        [DllImport("ole32.dll", ExactSpelling = true, EntryPoint = "CoCreateInstance", PreserveSig = true)]
        public static extern Result CoCreateInstance([In, MarshalAs(UnmanagedType.LPStruct)] Guid rclsid, IntPtr pUnkOuter, CLSCTX dwClsContext, [In, MarshalAs(UnmanagedType.LPStruct)] Guid riid, out IntPtr comObject);

        public static void CreateComInstance(Guid clsid, CLSCTX clsctx, Guid riid, ComObject comObject)
        {
            IntPtr pointer;
            var result = CoCreateInstance(clsid, IntPtr.Zero, clsctx, riid, out pointer);
            result.CheckError();
            comObject.NativePointer = pointer;
        }

        public static bool TryCreateComInstance(Guid clsid, CLSCTX clsctx, Guid riid, ComObject comObject)
        {
            IntPtr pointer;
            var result = CoCreateInstance(clsid, IntPtr.Zero, clsctx, riid, out pointer);
            comObject.NativePointer = pointer;
            return result.Success;
        }

        /// <summary>
        /// Compares two block of memory.
        /// </summary>
        /// <param name="from">The pointer to compare from.</param>
        /// <param name="against">The pointer to compare against.</param>
        /// <param name="sizeToCompare">The size in bytes to compare.</param>
        /// <returns><c>true</c> if the buffers are equivalent; otherwise, <c>false</c>.</returns>
        public unsafe static bool CompareMemory(IntPtr from, IntPtr against, int sizeToCompare)
        {
            var pSrc = (byte*)@from;
            var pDst = (byte*)against;

            // Compare 8 bytes.
            int numberOf = sizeToCompare >> 3;
            while (numberOf > 0)
            {
                if (*(long*)pSrc != *(long*)pDst)
                    return false;
                pSrc += 8;
                pDst += 8;
                numberOf--;
            }

            // Compare remaining bytes.
            numberOf = sizeToCompare & 7;
            while (numberOf > 0)
            {
                if (*pSrc != *pDst)
                    return false;
                pSrc++;
                pDst++;
                numberOf--;
            }

            return true;
        }
        /// <summary>
        /// Clears the memory.
        /// </summary>
        /// <param name="dest">The dest.</param>
        /// <param name="value">The value.</param>
        /// <param name="sizeInBytesToClear">The size in bytes to clear.</param>
        public static void ClearMemory(IntPtr dest, byte value, int sizeInBytesToClear)
        {
            unsafe
            {
                Interop.memset((void*)dest, value, sizeInBytesToClear);
            }
        }
        /// <summary>
        /// Return the sizeof a struct from a CLR. Equivalent to sizeof operator but works on generics too.
        /// </summary>
        /// <typeparam name="T">A struct to evaluate.</typeparam>
        /// <returns>Size of this struct.</returns>
        public static int SizeOf<T>() where T : struct
        {
            return Interop.SizeOf<T>();
        }

        /// <summary>
        /// Return the sizeof an array of struct. Equivalent to sizeof operator but works on generics too.
        /// </summary>
        /// <typeparam name="T">A struct.</typeparam>
        /// <param name="array">The array of struct to evaluate.</param>
        /// <returns>Size in bytes of this array of struct.</returns>
        public static int SizeOf<T>(T[] array) where T : struct
        {
            return array == null ? 0 : array.Length * Interop.SizeOf<T>();
        }

        /// <summary>
        /// Pins the specified source and call an action with the pinned pointer.
        /// </summary>
        /// <typeparam name="T">The type of the structure to pin.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="pinAction">The pin action to perform on the pinned pointer.</param>
        public static void Pin<T>(ref T source, Action<IntPtr> pinAction) where T : struct
        {
            unsafe
            {
                pinAction((IntPtr)Interop.Fixed(ref source));
            }
        }

        /// <summary>
        /// Pins the specified source and call an action with the pinned pointer.
        /// </summary>
        /// <typeparam name="T">The type of the structure to pin.</typeparam>
        /// <param name="source">The source array.</param>
        /// <param name="pinAction">The pin action to perform on the pinned pointer.</param>
        public static void Pin<T>(T[] source, Action<IntPtr> pinAction) where T : struct
        {
            unsafe
            {
                pinAction(source == null ? IntPtr.Zero : (IntPtr)Interop.Fixed(source));
            }
        }

        /// <summary>
        /// Converts a structured array to an equivalent byte array.
        /// </summary>
        /// <typeparam name="T">The type of source array.</typeparam>
        /// <param name="source">The source array.</param>
        /// <returns>Converted byte array.</returns>
        public static byte[] ToByteArray<T>(T[] source) where T : struct
        {
            if (source == null) return null;

            var buffer = new byte[SizeOf<T>() * source.Length];

            if (source.Length == 0)
                return buffer;

            unsafe
            {
                fixed (void* pBuffer = buffer)
                    Interop.Write(pBuffer, source, 0, source.Length);
            }
            return buffer;
        }

        /// <summary>
        /// Swaps the value between two references.
        /// </summary>
        /// <typeparam name="T">Type of a data to swap.</typeparam>
        /// <param name="left">The left value.</param>
        /// <param name="right">The right value.</param>
        public static void Swap<T>(ref T left, ref T right)
        {
            var temp = left;
            left = right;
            right = temp;
        }

        /// <summary>
        /// Reads the specified T data from a memory location.
        /// </summary>
        /// <typeparam name="T">Type of a data to read.</typeparam>
        /// <param name="source">Memory location to read from.</param>
        /// <returns>The data read from the memory location.</returns>
        public static T Read<T>(IntPtr source) where T : struct
        {
            unsafe
            {
                return Interop.ReadInline<T>((void*)source);
            }
        }

        /// <summary>
        /// Reads the specified T data from a memory location.
        /// </summary>
        /// <typeparam name="T">Type of a data to read.</typeparam>
        /// <param name="source">Memory location to read from.</param>
        /// <param name="data">The data write to.</param>
        /// <returns>source pointer + sizeof(T).</returns>
        public static void Read<T>(IntPtr source, ref T data) where T : struct
        {
            unsafe
            {
                Interop.CopyInline(ref data, (void*)source);
            }
        }

        /// <summary>
        /// Reads the specified T data from a memory location.
        /// </summary>
        /// <typeparam name="T">Type of a data to read.</typeparam>
        /// <param name="source">Memory location to read from.</param>
        /// <param name="data">The data write to.</param>
        /// <returns>source pointer + sizeof(T).</returns>
        public static void ReadOut<T>(IntPtr source, out T data) where T : struct
        {
            unsafe
            {
                Interop.CopyInlineOut(out data, (void*)source);
            }
        }

        /// <summary>
        /// Reads the specified T data from a memory location.
        /// </summary>
        /// <typeparam name="T">Type of a data to read.</typeparam>
        /// <param name="source">Memory location to read from.</param>
        /// <param name="data">The data write to.</param>
        /// <returns>source pointer + sizeof(T).</returns>
        public static IntPtr ReadAndPosition<T>(IntPtr source, ref T data) where T : struct
        {
            unsafe
            {
                return (IntPtr)Interop.Read((void*)source, ref data);
            }
        }

        /// <summary>
        /// Reads the specified array T[] data from a memory location.
        /// </summary>
        /// <typeparam name="T">Type of a data to read.</typeparam>
        /// <param name="source">Memory location to read from.</param>
        /// <param name="data">The data write to.</param>
        /// <param name="offset">The offset in the array to write to.</param>
        /// <param name="count">The number of T element to read from the memory location.</param>
        /// <returns>source pointer + sizeof(T) * count.</returns>
        public static IntPtr Read<T>(IntPtr source, T[] data, int offset, int count) where T : struct
        {
            unsafe
            {
                return (IntPtr)Interop.Read((void*)source, data, offset, count);
            }
        }

        /// <summary>
        /// Writes the specified T data to a memory location.
        /// </summary>
        /// <typeparam name="T">Type of a data to write.</typeparam>
        /// <param name="destination">Memory location to write to.</param>
        /// <param name="data">The data to write.</param>
        /// <returns>destination pointer + sizeof(T).</returns>
        public static void Write<T>(IntPtr destination, ref T data) where T : struct
        {
            unsafe
            {
                Interop.CopyInline((void*)destination, ref data);
            }
        }

        /// <summary>
        /// Writes the specified T data to a memory location.
        /// </summary>
        /// <typeparam name="T">Type of a data to write.</typeparam>
        /// <param name="destination">Memory location to write to.</param>
        /// <param name="data">The data to write.</param>
        /// <returns>destination pointer + sizeof(T).</returns>
        public static IntPtr WriteAndPosition<T>(IntPtr destination, ref T data) where T : struct
        {
            unsafe
            {
                return (IntPtr)Interop.Write((void*)destination, ref data);
            }
        }

        /// <summary>
        /// Writes the specified array T[] data to a memory location.
        /// </summary>
        /// <typeparam name="T">Type of a data to write.</typeparam>
        /// <param name="destination">Memory location to write to.</param>
        /// <param name="data">The array of T data to write.</param>
        /// <param name="offset">The offset in the array to read from.</param>
        /// <param name="count">The number of T element to write to the memory location.</param>
        /// <returns>destination pointer + sizeof(T) * count.</returns>
        public static IntPtr Write<T>(IntPtr destination, T[] data, int offset, int count) where T : struct
        {
            unsafe
            {
                return (IntPtr)Interop.Write((void*)destination, data, offset, count);
            }
        }

        /// <summary>
        /// Converts bool array to integer pointers array.
        /// </summary>
        /// <param name="array">The bool array.</param>
        /// <param name="dest">The destination array of int pointers.</param>
        public unsafe static void ConvertToIntArray(bool[] array, int* dest)
        {
            for (int i = 0; i < array.Length; i++)
                dest[i] = array[i] ? 1 : 0;
        }

        /// <summary>
        /// Converts integer pointer array to bool array.
        /// </summary>
        /// <param name="array">The array of integer pointers.</param>
        /// <param name="length">Array size.</param>
        /// <returns>Converted array of bool.</returns>
        public static unsafe bool[] ConvertToBoolArray(int* array, int length)
        {
            var temp = new bool[length];
            for (int i = 0; i < temp.Length; i++)
                temp[i] = array[i] != 0;
            return temp;
        }
        /// <summary>
        /// Gets the <see cref="System.Guid"/> from a type.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>The guid associated with this type.</returns>
        public static Guid GetGuidFromType(Type type)
        {
            return type.GetTypeInfo().GUID;
        }

        /// <summary>
        /// Determines whether a given type inherits from a generic type.
        /// </summary>
        /// <param name="givenType">Type of the class to check if it inherits from generic type.</param>
        /// <param name="genericType">Type of the generic.</param>
        /// <returns><c>true</c> if [is assignable to generic type] [the specified given type]; otherwise, <c>false</c>.</returns>
        public static bool IsAssignableToGenericType(Type givenType, Type genericType)
        {
            // from http://stackoverflow.com/a/1075059/1356325
            var interfaceTypes = givenType.GetTypeInfo().ImplementedInterfaces;

            foreach (var it in interfaceTypes)
            {
                if (it.GetTypeInfo().IsGenericType && it.GetGenericTypeDefinition() == genericType)
                    return true;
            }

            if (givenType.GetTypeInfo().IsGenericType && givenType.GetGenericTypeDefinition() == genericType)
                return true;

            Type baseType = givenType.GetTypeInfo().BaseType;
            if (baseType == null) return false;

            return IsAssignableToGenericType(baseType, genericType);
        }

        /// <summary>
        /// Allocate an aligned memory buffer.
        /// </summary>
        /// <param name="sizeInBytes">Size of the buffer to allocate.</param>
        /// <param name="align">Alignment, 16 bytes by default.</param>
        /// <returns>A pointer to a buffer aligned.</returns>
        /// <remarks>
        /// To free this buffer, call <see cref="FreeMemory"/>.
        /// </remarks>
        public unsafe static IntPtr AllocateMemory(int sizeInBytes, int align = 16)
        {
            int mask = align - 1;
            var memPtr = Marshal.AllocHGlobal(sizeInBytes + mask + IntPtr.Size);
            var ptr = (long)((byte*)memPtr + sizeof(void*) + mask) & ~mask;
            ((IntPtr*)ptr)[-1] = memPtr;
            return new IntPtr(ptr);
        }

        /// <summary>
        /// Allocate an aligned memory buffer and clear it with a specified value (0 by default).
        /// </summary>
        /// <param name="sizeInBytes">Size of the buffer to allocate.</param>
        /// <param name="clearValue">Default value used to clear the buffer.</param>
        /// <param name="align">Alignment, 16 bytes by default.</param>
        /// <returns>A pointer to a buffer aligned.</returns>
        /// <remarks>
        /// To free this buffer, call <see cref="FreeMemory"/>.
        /// </remarks>
        public static IntPtr AllocateClearedMemory(int sizeInBytes, byte clearValue = 0, int align = 16)
        {
            var ptr = AllocateMemory(sizeInBytes, align);
            ClearMemory(ptr, clearValue, sizeInBytes);
            return ptr;
        }

        /// <summary>
        /// Determines whether the specified memory pointer is aligned in memory.
        /// </summary>
        /// <param name="memoryPtr">The memory pointer.</param>
        /// <param name="align">The align.</param>
        /// <returns><c>true</c> if the specified memory pointer is aligned in memory; otherwise, <c>false</c>.</returns>
        public static bool IsMemoryAligned(IntPtr memoryPtr, int align = 16)
        {
            return ((memoryPtr.ToInt64() & (align - 1)) == 0);
        }

        /// <summary>
        /// Allocate an aligned memory buffer.
        /// </summary>
        /// <returns>A pointer to a buffer aligned.</returns>
        /// <remarks>
        /// The buffer must have been allocated with <see cref="AllocateMemory"/>.
        /// </remarks>
        public unsafe static void FreeMemory(IntPtr alignedBuffer)
        {
            if (alignedBuffer == IntPtr.Zero) return;
            Marshal.FreeHGlobal(((IntPtr*)alignedBuffer)[-1]);
        }

        /// <summary>
        /// Converts a pointer to a null-terminating string up to maxLength characters to a .Net string.
        /// </summary>
        /// <param name="pointer">The pointer to an ANSI null string.</param>
        /// <param name="maxLength">Maximum length of the string.</param>
        /// <returns>The converted string.</returns>
        public static string PtrToStringAnsi(IntPtr pointer, int maxLength)
        {
            return Marshal.PtrToStringAnsi(pointer, maxLength);
        }

        /// <summary>
        /// Converts a pointer to a null-terminating string up to maxLength characters to a .Net string.
        /// </summary>
        /// <param name="pointer">The pointer to an Unicode null string.</param>
        /// <param name="maxLength">Maximum length of the string.</param>
        /// <returns>The converted string.</returns>
        public static string PtrToStringUni(IntPtr pointer, int maxLength)
        {
            return Marshal.PtrToStringUni(pointer, maxLength);
        }

        /// <summary>
        /// Copies the contents of a managed String into unmanaged memory, converting into ANSI format as it copies.
        /// </summary>
        /// <param name="s">A managed string to be copied.</param> 
        /// <returns>The address, in unmanaged memory, to where s was copied, or IntPtr.Zero if s is null.</returns>
        public static unsafe IntPtr StringToHGlobalAnsi(string s)
        {
            return Marshal.StringToHGlobalAnsi(s);
        }

        /// <summary>
        /// Copies the contents of a managed String into unmanaged memory.
        /// </summary>
        /// <param name="s">A managed string to be copied.</param> 
        /// <returns>The address, in unmanaged memory, to where s was copied, or IntPtr.Zero if s is null.</returns>
        public static unsafe IntPtr StringToHGlobalUni(string s)
        {
            return Marshal.StringToHGlobalUni(s);
        }
        /// <summary>
        /// Gets the IUnknown from object. Similar to <see cref="Marshal.GetIUnknownForObject"/> but accept null object
        /// by returning an IntPtr.Zero IUnknown pointer.
        /// </summary>
        /// <param name="obj">The managed object.</param>
        /// <returns>An IUnknown pointer to a  managed object.</returns>
        public static IntPtr GetIUnknownForObject(object obj)
        {
            IntPtr objPtr = obj == null ? IntPtr.Zero : Marshal.GetIUnknownForObject(obj);
            //if (obj is ComObject && ((ComObject)obj).NativePointer == IntPtr.Zero) 
            //    (((ComObject)obj).NativePointer) = objPtr;
            return objPtr;
        }

        /// <summary>
        /// Gets an object from an IUnknown pointer. Similar to <see cref="Marshal.GetObjectForIUnknown"/> but accept IntPtr.Zero
        /// by returning a null object.
        /// </summary>
        /// <param name="iunknownPtr">an IUnknown pointer to a  managed object.</param>
        /// <returns>The managed object.</returns>
        public static object GetObjectForIUnknown(IntPtr iunknownPtr)
        {
            return iunknownPtr == IntPtr.Zero ? null : Marshal.GetObjectForIUnknown(iunknownPtr);
        }

        /// <summary>
        /// String helper join method to display an array of object as a single string.
        /// </summary>
        /// <param name="separator">The separator.</param>
        /// <param name="array">The array.</param>
        /// <returns>A string with array elements separated by the separator.</returns>
        public static string Join<T>(string separator, T[] array)
        {
            var text = new StringBuilder();
            if (array != null)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    if (i > 0) text.Append(separator);
                    text.Append(array[i]);
                }
            }
            return text.ToString();
        }

        /// <summary>
        /// String helper join method to display an enumerable of object as a single string.
        /// </summary>
        /// <param name="separator">The separator.</param>
        /// <param name="elements">The enumerable.</param>
        /// <returns>A string with array elements separated by the separator.</returns>
        public static string Join(string separator, IEnumerable elements)
        {
            var elementList = new List<string>();
            foreach (var element in elements)
                elementList.Add(element.ToString());

            var text = new StringBuilder();
            for (int i = 0; i < elementList.Count; i++)
            {
                var element = elementList[i];
                if (i > 0) text.Append(separator);
                text.Append(element);
            }
            return text.ToString();
        }

        /// <summary>
        /// String helper join method to display an enumerable of object as a single string.
        /// </summary>
        /// <param name="separator">The separator.</param>
        /// <param name="elements">The enumerable.</param>
        /// <returns>A string with array elements separated by the separator.</returns>
        public static string Join(string separator, IEnumerator elements)
        {
            var elementList = new List<string>();
            while (elements.MoveNext())
                elementList.Add(elements.Current.ToString());

            var text = new StringBuilder();
            for (int i = 0; i < elementList.Count; i++)
            {
                var element = elementList[i];
                if (i > 0) text.Append(separator);
                text.Append(element);
            }
            return text.ToString();
        }

        /// <summary>
        /// Equivalent to IntPtr.Add method from 3.5+ .NET Framework.
        /// Adds an offset to the value of a pointer.
        /// </summary>
        /// <param name="ptr">A native pointer.</param>
        /// <param name="offset">The offset to add (number of bytes).</param>
        /// <returns>A new pointer that reflects the addition of offset to pointer.</returns>
        public unsafe static IntPtr IntPtrAdd(IntPtr ptr, int offset)
        {
            return new IntPtr(((byte*)ptr) + offset);
        }

        /// <summary>
        /// Read stream to a byte[] buffer.
        /// </summary>
        /// <param name="stream">Input stream.</param>
        /// <returns>A byte[] buffer.</returns>
        public static byte[] ReadStream(Stream stream)
        {
            int readLength = 0;
            return ReadStream(stream, ref readLength);
        }

        /// <summary>
        /// Read stream to a byte[] buffer.
        /// </summary>
        /// <param name="stream">Input stream.</param>
        /// <param name="readLength">Length to read.</param>
        /// <returns>A byte[] buffer.</returns>
        public static byte[] ReadStream(Stream stream, ref int readLength)
        {
            Debug.Assert(stream != null);
            Debug.Assert(stream.CanRead);
            int num = readLength;
            Debug.Assert(num <= (stream.Length - stream.Position));
            if (num == 0)
                readLength = (int)(stream.Length - stream.Position);
            num = readLength;

            Debug.Assert(num >= 0);
            if (num == 0)
                return new byte[0];

            byte[] buffer = new byte[num];
            int bytesRead = 0;
            if (num > 0)
            {
                do
                {
                    bytesRead += stream.Read(buffer, bytesRead, readLength - bytesRead);
                } while (bytesRead < readLength);
            }
            return buffer;
        }

        /// <summary>
        /// Compares two collection, element by elements.
        /// </summary>
        /// <param name="left">A "from" enumerator.</param>
        /// <param name="right">A "to" enumerator.</param>
        /// <returns><c>true</c> if lists are identical, <c>false</c> otherwise.</returns>
        public static bool Compare(IEnumerable left, IEnumerable right)
        {
            if (ReferenceEquals(left, right))
                return true;
            if (ReferenceEquals(left, null) || ReferenceEquals(right, null))
                return false;

            return Compare(left.GetEnumerator(), right.GetEnumerator());
        }

        /// <summary>
        /// Compares two collection, element by elements.
        /// </summary>
        /// <param name="leftIt">A "from" enumerator.</param>
        /// <param name="rightIt">A "to" enumerator.</param>
        /// <returns><c>true</c> if lists are identical; otherwise, <c>false</c>.</returns>
        public static bool Compare(IEnumerator leftIt, IEnumerator rightIt)
        {
            if (ReferenceEquals(leftIt, rightIt))
                return true;
            if (ReferenceEquals(leftIt, null) || ReferenceEquals(rightIt, null))
                return false;

            bool hasLeftNext;
            bool hasRightNext;
            while (true)
            {
                hasLeftNext = leftIt.MoveNext();
                hasRightNext = rightIt.MoveNext();
                if (!hasLeftNext || !hasRightNext)
                    break;

                if (!Equals(leftIt.Current, rightIt.Current))
                    return false;
            }

            // If there is any left element
            if (hasLeftNext != hasRightNext)
                return false;

            return true;
        }

        /// <summary>
        /// Compares two collection, element by elements.
        /// </summary>
        /// <param name="left">The collection to compare from.</param>
        /// <param name="right">The collection to compare to.</param>
        /// <returns><c>true</c> if lists are identical (but not necessarily of the same time); otherwise , <c>false</c>.</returns>
        public static bool Compare(ICollection left, ICollection right)
        {
            if (ReferenceEquals(left, right))
                return true;
            if (ReferenceEquals(left, null) || ReferenceEquals(right, null))
                return false;

            if (left.Count != right.Count)
                return false;

            int count = 0;
            var leftIt = left.GetEnumerator();
            var rightIt = right.GetEnumerator();
            while (leftIt.MoveNext() && rightIt.MoveNext())
            {
                if (!Equals(leftIt.Current, rightIt.Current))
                    return false;
                count++;
            }

            // Just double check to make sure that the iterator actually returns
            // the exact number of elements
            if (count != left.Count)
                return false;

            return true;
        }

        /// <summary>
        /// Gets the custom attribute.
        /// </summary>
        /// <typeparam name="T">Type of the custom attribute.</typeparam>
        /// <param name="memberInfo">The member info.</param>
        /// <param name="inherited">if set to <c>true</c> [inherited].</param>
        /// <returns>The custom attribute or null if not found.</returns>
        public static T GetCustomAttribute<T>(MemberInfo memberInfo, bool inherited = false) where T : Attribute
        {
            return memberInfo.GetCustomAttribute<T>(inherited);
        }

        /// <summary>
        /// Gets the custom attributes.
        /// </summary>
        /// <typeparam name="T">Type of the custom attribute.</typeparam>
        /// <param name="memberInfo">The member info.</param>
        /// <param name="inherited">if set to <c>true</c> [inherited].</param>
        /// <returns>The custom attribute or null if not found.</returns>
        public static IEnumerable<T> GetCustomAttributes<T>(MemberInfo memberInfo, bool inherited = false) where T : Attribute
        {
            return memberInfo.GetCustomAttributes<T>(inherited);
        }

        /// <summary>
        /// Determines whether fromType can be assigned to toType.
        /// </summary>
        /// <param name="toType">To type.</param>
        /// <param name="fromType">From type.</param>
        /// <returns>
        /// <c>true</c> if [is assignable from] [the specified to type]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsAssignableFrom(Type toType, Type fromType)
        {
            return toType.GetTypeInfo().IsAssignableFrom(fromType.GetTypeInfo());
        }

        /// <summary>
        /// Determines whether the specified type to test is an enum.
        /// </summary>
        /// <param name="typeToTest">The type to test.</param>
        /// <returns>
        /// <c>true</c> if the specified type to test is an enum; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsEnum(Type typeToTest)
        {
            return typeToTest.GetTypeInfo().IsEnum;
        }

        /// <summary>
        /// Determines whether the specified type to test is a value type.
        /// </summary>
        /// <param name="typeToTest">The type to test.</param>
        /// <returns>
        /// <c>true</c> if the specified type to test is a value type; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsValueType(Type typeToTest)
        {
            return typeToTest.GetTypeInfo().IsValueType;
        }

        private static MethodInfo GetMethod(Type type, string name, Type[] typeArgs)
        {
            foreach (var method in type.GetTypeInfo().GetDeclaredMethods(name))
            {
                if (method.GetParameters().Length == typeArgs.Length)
                {
                    var parameters = method.GetParameters();
                    bool methodFound = true;
                    for (int i = 0; i < typeArgs.Length; i++)
                    {
                        if (parameters[i].ParameterType != typeArgs[i])
                        {
                            methodFound = false;
                            break;
                        }
                    }
                    if (methodFound)
                    {
                        return method;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Builds a fast property getter from a type and a property info.
        /// </summary>
        /// <typeparam name="T">Type of the getter.</typeparam>
        /// <param name="customEffectType">Type of the custom effect.</param>
        /// <param name="propertyInfo">The property info to get the value from.</param>
        /// <returns>A compiled delegate.</returns>
        public static GetValueFastDelegate<T> BuildPropertyGetter<T>(Type customEffectType, PropertyInfo propertyInfo)
        {
            var valueParam = Expression.Parameter(typeof(T).MakeByRefType());
            var objectParam = Expression.Parameter(typeof(object));
            var castParam = Expression.Convert(objectParam, customEffectType);
            var propertyAccessor = Expression.Property(castParam, propertyInfo);

            Expression convertExpression;
            if (propertyInfo.PropertyType == typeof(bool))
            {
                // Convert bool to int: effect.Property ? 1 : 0
                convertExpression = Expression.Condition(propertyAccessor, Expression.Constant(1), Expression.Constant(0));
            }
            else
            {
                convertExpression = Expression.Convert(propertyAccessor, typeof(T));
            }
            return Expression.Lambda<GetValueFastDelegate<T>>(Expression.Assign(valueParam, convertExpression), objectParam, valueParam).Compile();
        }

        /// <summary>
        /// Builds a fast property setter from a type and a property info.
        /// </summary>
        /// <typeparam name="T">Type of the setter.</typeparam>
        /// <param name="customEffectType">Type of the custom effect.</param>
        /// <param name="propertyInfo">The property info to set the value to.</param>
        /// <returns>A compiled delegate.</returns>
        public static SetValueFastDelegate<T> BuildPropertySetter<T>(Type customEffectType, PropertyInfo propertyInfo)
        {
            var valueParam = Expression.Parameter(typeof(T).MakeByRefType());
            var objectParam = Expression.Parameter(typeof(object));
            var castParam = Expression.Convert(objectParam, customEffectType);
            var propertyAccessor = Expression.Property(castParam, propertyInfo);

            Expression convertExpression;
            if (propertyInfo.PropertyType == typeof(bool))
            {
                // Convert int to bool: value != 0
                convertExpression = Expression.NotEqual(valueParam, Expression.Constant(0));
            }
            else
            {
                convertExpression = Expression.Convert(valueParam, propertyInfo.PropertyType);
            }
            return Expression.Lambda<SetValueFastDelegate<T>>(Expression.Assign(propertyAccessor, convertExpression), objectParam, valueParam).Compile();
        }

        /// <summary>
        /// Finds an explicit conversion between a source type and a target type.
        /// </summary>
        /// <param name="sourceType">Type of the source.</param>
        /// <param name="targetType">Type of the target.</param>
        /// <returns>The method to perform the conversion. null if not found.</returns>
        private static MethodInfo FindExplicitConverstion(Type sourceType, Type targetType)
        {
            // No need for cast for similar source and target type
            if (sourceType == targetType)
                return null;

            var methods = new List<MethodInfo>();

            var tempType = sourceType;
            while (tempType != null)
            {
                methods.AddRange(tempType.GetTypeInfo().DeclaredMethods); //target methods will be favored in the search
                tempType = tempType.GetTypeInfo().BaseType;
            }

            tempType = targetType;
            while (tempType != null)
            {
                methods.AddRange(tempType.GetTypeInfo().DeclaredMethods); //target methods will be favored in the search
                tempType = tempType.GetTypeInfo().BaseType;
            }

            foreach (MethodInfo mi in methods)
            {
                if (mi.Name == "op_Explicit") //will return target and take one parameter
                    if (mi.ReturnType == targetType)
                        if (IsAssignableFrom(mi.GetParameters()[0].ParameterType, sourceType))
                            return mi;
            }

            return null;
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int GetClipboardFormatName(int format, StringBuilder lpString, int cchMax);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int RegisterClipboardFormat(string format);
        [DllImport("shell32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr ShellExecute(HandleRef hwnd, string lpOperation, string lpFile, string lpParameters, string lpDirectory, int nShowCmd);
        [DllImport("shell32.dll", BestFitMapping = false, CharSet = CharSet.Auto, EntryPoint = "ShellExecute")]
        public static extern IntPtr ShellExecute_NoBFM(HandleRef hwnd, string lpOperation, string lpFile, string lpParameters, string lpDirectory, int nShowCmd);
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true, SetLastError = true)]
        public static extern int SetScrollPos(HandleRef hWnd, int nBar, int nPos, bool bRedraw);
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true, SetLastError = true)]
        public static extern bool EnableScrollBar(HandleRef hWnd, int nBar, int value);
        [DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "CreateMenu", ExactSpelling = true)]
        private static extern IntPtr IntCreateMenu();
        [DllImport("user32.dll", ExactSpelling = true)]
        public static extern bool EndDialog(HandleRef hWnd, IntPtr result);
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, ExactSpelling = true, SetLastError = true)]
        public static extern int MultiByteToWideChar(int CodePage, int dwFlags, byte[] lpMultiByteStr, int cchMultiByte, char[] lpWideCharStr, int cchWideChar);
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, ExactSpelling = true)]
        public static extern int WideCharToMultiByte(int codePage, int flags, [MarshalAs(UnmanagedType.LPWStr)] string wideStr, int chars, [In] [Out] byte[] pOutBytes, int bufferBytes, IntPtr defaultChar, IntPtr pDefaultUsed);
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, EntryPoint = "RtlMoveMemory", ExactSpelling = true, SetLastError = true)]
        public static extern void CopyMemory(HandleRef destData, HandleRef srcData, int size);
        [DllImport("kernel32.dll", EntryPoint = "RtlMoveMemory", ExactSpelling = true)]
        public static extern void CopyMemory(IntPtr pdst, byte[] psrc, int cb);
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "RtlMoveMemory", ExactSpelling = true)]
        public static extern void CopyMemoryW(IntPtr pdst, string psrc, int cb);
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "RtlMoveMemory", ExactSpelling = true)]
        public static extern void CopyMemoryW(IntPtr pdst, char[] psrc, int cb);
        [DllImport("kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "RtlMoveMemory", ExactSpelling = true)]
        public static extern void CopyMemoryA(IntPtr pdst, string psrc, int cb);
        [DllImport("kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "RtlMoveMemory", ExactSpelling = true)]
        public static extern void CopyMemoryA(IntPtr pdst, char[] psrc, int cb);
        [DllImport("kernel32.dll", EntryPoint = "DuplicateHandle", ExactSpelling = true, SetLastError = true)]
        private static extern IntPtr IntDuplicateHandle(HandleRef processSource, HandleRef handleSource, HandleRef processTarget, ref IntPtr handleTarget, int desiredAccess, bool inheritHandle, int options);
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern int GetKeyboardState(byte[] keystate);
        [DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "keybd_event", ExactSpelling = true)]
        public static extern void Keybd_event(byte vk, byte scan, int flags, int extrainfo);
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern int SetKeyboardState(byte[] keystate);
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern bool UnhookWindowsHookEx(HandleRef hhook);
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern short GetAsyncKeyState(int vkey);
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr CallNextHookEx(HandleRef hhook, int code, IntPtr wparam, IntPtr lparam);
        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int GetObject(HandleRef hObject, int nSize, ref int nEntries);
        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int GetObject(HandleRef hObject, int nSize, int[] nEntries);
        [DllImport("gdi32.dll", CharSet = CharSet.Auto, ExactSpelling = true, SetLastError = true)]
        public static extern int GetObjectType(HandleRef hObject);
        [DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "CreateAcceleratorTable")]
        private static extern IntPtr IntCreateAcceleratorTable(HandleRef pentries, int cCount);
        [DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "DestroyAcceleratorTable", ExactSpelling = true)]
        private static extern bool IntDestroyAcceleratorTable(HandleRef hAccel);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern short VkKeyScan(char key);
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr GetCapture();
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr SetCapture(HandleRef hwnd);
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr GetFocus();
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern short GetKeyState(int keyCode);
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern uint GetShortPathName(string lpszLongPath, StringBuilder lpszShortPath, uint cchBuffer);
        [DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "SetWindowRgn", ExactSpelling = true)]
        private static extern int IntSetWindowRgn(HandleRef hwnd, HandleRef hrgn, bool fRedraw);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int GetWindowText(HandleRef hWnd, StringBuilder lpString, int nMaxCount);
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern void GetTempFileName(string tempDirName, string prefixName, int unique, StringBuilder sb);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool SetWindowText(HandleRef hWnd, string text);
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr GlobalAlloc(int uFlags, int dwBytes);
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr GlobalReAlloc(HandleRef handle, int bytes, int flags);
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr GlobalLock(HandleRef handle);
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern bool GlobalUnlock(HandleRef handle);
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr GlobalFree(HandleRef handle);
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern int GlobalSize(HandleRef handle);
        [DllImport("imm32.dll", CharSet = CharSet.Auto)]
        public static extern bool ImmSetConversionStatus(HandleRef hIMC, int conversion, int sentence);
        [DllImport("imm32.dll", CharSet = CharSet.Auto)]
        public static extern bool ImmGetConversionStatus(HandleRef hIMC, ref int conversion, ref int sentence);
        [DllImport("imm32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr ImmGetContext(HandleRef hWnd);
        [DllImport("imm32.dll", CharSet = CharSet.Auto)]
        public static extern bool ImmReleaseContext(HandleRef hWnd, HandleRef hIMC);
        [DllImport("imm32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr ImmAssociateContext(HandleRef hWnd, HandleRef hIMC);
        [DllImport("imm32.dll", CharSet = CharSet.Auto)]
        public static extern bool ImmDestroyContext(HandleRef hIMC);
        [DllImport("imm32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr ImmCreateContext();
        [DllImport("imm32.dll", CharSet = CharSet.Auto)]
        public static extern bool ImmSetOpenStatus(HandleRef hIMC, bool open);
        [DllImport("imm32.dll", CharSet = CharSet.Auto)]
        public static extern bool ImmGetOpenStatus(HandleRef hIMC);
        [DllImport("imm32.dll", CharSet = CharSet.Auto)]
        public static extern bool ImmNotifyIME(HandleRef hIMC, int dwAction, int dwIndex, int dwValue);
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr SetFocus(HandleRef hWnd);
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr GetParent(HandleRef hWnd);
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr GetAncestor(HandleRef hWnd, int flags);
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern bool IsChild(HandleRef hWndParent, HandleRef hwnd);
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern bool IsZoomed(HandleRef hWnd);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr FindWindow(string className, string windowName);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, bool wParam, int lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, int wParam, int[] lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, int[] wParam, int[] lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, ref int wParam, ref int lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, int wParam, string lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, IntPtr wParam, string lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int Msg, ref short wParam, ref short lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int Msg, [MarshalAs(UnmanagedType.Bool)] [In] [Out] ref bool wParam, IntPtr lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int Msg, int wParam, IntPtr lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessageTimeout(HandleRef hWnd, int msg, IntPtr wParam, IntPtr lParam, int flags, int timeout, out IntPtr pdwResult);
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr SetParent(HandleRef hWnd, HandleRef hWndParent);
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr GetWindow(HandleRef hWnd, int uCmd);
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr GetDlgItem(HandleRef hWnd, int nIDDlgItem);
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetModuleHandle(string modName);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr DefWindowProc(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr DefMDIChildProc(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr CallWindowProc(IntPtr wndProc, IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern short GlobalDeleteAtom(short atom);
        [DllImport("kernel32.dll", CharSet = CharSet.Ansi, ExactSpelling = true)]
        public static extern IntPtr GetProcAddress(HandleRef hModule, string lpProcName);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool SystemParametersInfo(int nAction, int nParam, bool[] flag, bool nUpdate);
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern bool GetComputerName(StringBuilder lpBuffer, int[] nSize);
        [DllImport("advapi32.dll", CharSet = CharSet.Auto)]
        public static extern bool GetUserName(StringBuilder lpBuffer, int[] nSize);
        [DllImport("user32.dll", ExactSpelling = true)]
        public static extern IntPtr GetProcessWindowStation();
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr GetForegroundWindow();
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern int MsgWaitForMultipleObjectsEx(int nCount, IntPtr pHandles, int dwMilliseconds, int dwWakeMask, int dwFlags);
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr GetDesktopWindow();
        [DllImport("ole32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern int RevokeDragDrop(HandleRef hwnd);
        public static extern bool PostMessage(HandleRef hwnd, int msg, IntPtr wparam, IntPtr lparam);
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern short GlobalAddAtom(string atomName);
        [DllImport("oleacc.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr LresultFromObject(ref Guid refiid, IntPtr wParam, HandleRef pAcc);
        [DllImport("oleacc.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern int CreateStdAccessibleObject(HandleRef hWnd, int objID, ref Guid refiid, [MarshalAs(UnmanagedType.Interface)] [In] [Out] ref object pAcc);
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern void NotifyWinEvent(int winEvent, HandleRef hwnd, int objType, int objID);
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern int GetMenuItemID(HandleRef hMenu, int nPos);
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr GetSubMenu(HandleRef hwnd, int index);
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern int GetMenuItemCount(HandleRef hMenu);
        [DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "GetDC", ExactSpelling = true)]
        private static extern IntPtr IntGetDC(HandleRef hWnd);
        [DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "GetWindowDC", ExactSpelling = true)]
        private static extern IntPtr IntGetWindowDC(HandleRef hWnd);
        [DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "ReleaseDC", ExactSpelling = true)]
        private static extern int IntReleaseDC(HandleRef hWnd, HandleRef hDC);
        [DllImport("gdi32.dll", CharSet = CharSet.Auto, EntryPoint = "CreateDC", SetLastError = true)]
        private static extern IntPtr IntCreateDC(string lpszDriver, string lpszDeviceName, string lpszOutput, HandleRef devMode);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool SystemParametersInfo(int nAction, int nParam, [In] [Out] IntPtr[] rc, int nUpdate);
        [DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "SendMessage")]
        public static extern IntPtr SendCallbackMessage(HandleRef hWnd, int Msg, IntPtr wParam, IntPtr lParam);
        [DllImport("shell32.dll", CharSet = CharSet.Ansi, ExactSpelling = true)]
        public static extern void DragAcceptFiles(HandleRef hWnd, bool fAccept);
        [DllImport("gdi32.dll", CharSet = CharSet.Auto, ExactSpelling = true, SetLastError = true)]
        public static extern int GetDeviceCaps(HandleRef hDC, int nIndex);
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr GetActiveWindow();
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool FreeLibrary(HandleRef hModule);
        [DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "GetWindowLong")]
        public static extern IntPtr GetWindowLong32(HandleRef hWnd, int nIndex);
        [DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "GetWindowLongPtr")]
        public static extern IntPtr GetWindowLongPtr64(HandleRef hWnd, int nIndex);
        [DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "SetWindowLong")]
        public static extern IntPtr SetWindowLongPtr32(HandleRef hWnd, int nIndex, HandleRef dwNewLong);
        [DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "SetWindowLongPtr")]
        public static extern IntPtr SetWindowLongPtr64(HandleRef hWnd, int nIndex, HandleRef dwNewLong);
        [DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "CreatePopupMenu", ExactSpelling = true)]
        private static extern IntPtr IntCreatePopupMenu();
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern bool RemoveMenu(HandleRef hMenu, int uPosition, int uFlags);
        [DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "DestroyMenu", ExactSpelling = true)]
        private static extern bool IntDestroyMenu(HandleRef hMenu);
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern bool SetForegroundWindow(HandleRef hWnd);
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr GetSystemMenu(HandleRef hWnd, bool bRevert);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr DefFrameProc(IntPtr hWnd, IntPtr hWndClient, int msg, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true, SetLastError = true)]
        public static extern bool SetLayeredWindowAttributes(HandleRef hwnd, int crKey, byte bAlpha, int dwFlags);
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern bool SetMenu(HandleRef hWnd, HandleRef hMenu);
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern bool SetMenuDefaultItem(HandleRef hwnd, int nIndex, bool pos);
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern bool EnableMenuItem(HandleRef hMenu, int UIDEnabledItem, int uEnable);
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr SetActiveWindow(HandleRef hWnd);
        [DllImport("gdi32.dll", CharSet = CharSet.Auto, EntryPoint = "CreateIC", SetLastError = true)]
        private static extern IntPtr IntCreateIC(string lpszDriverName, string lpszDeviceName, string lpszOutput, HandleRef lpInitData);
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr SetCursor(HandleRef hcursor);
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern bool SetCursorPos(int x, int y);
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern int ShowCursor(bool bShow);
        [DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "DestroyCursor", ExactSpelling = true)]
        private static extern bool IntDestroyCursor(HandleRef hCurs);
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern bool IsWindow(HandleRef hWnd);
        [DllImport("gdi32.dll", CharSet = CharSet.Auto, EntryPoint = "DeleteDC", ExactSpelling = true, SetLastError = true)]
        private static extern bool IntDeleteDC(HandleRef hDC);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr PostMessage(HandleRef hwnd, int msg, int wparam, int lparam);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr PostMessage(HandleRef hwnd, int msg, int wparam, IntPtr lparam);
        [DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "CreateWindowEx", SetLastError = true)]
        public static extern IntPtr IntCreateWindowEx(int dwExStyle, string lpszClassName, string lpszWindowName, int style, int x, int y, int width, int height, HandleRef hWndParent, HandleRef hMenu, HandleRef hInst, [MarshalAs(UnmanagedType.AsAny)] object pvParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "DestroyWindow", ExactSpelling = true)]
        public static extern bool IntDestroyWindow(HandleRef hWnd);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool UnregisterClass(string className, HandleRef hInstance);
        [DllImport("gdi32.dll", CharSet = CharSet.Auto, ExactSpelling = true, SetLastError = true)]
        public static extern IntPtr GetStockObject(int nIndex);
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern void PostQuitMessage(int nExitCode);
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern void WaitMessage();
        [DllImport("Powrprof.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern bool SetSuspendState(bool hiberate, bool forceCritical, bool disableWakeEvent);
        [DllImport("gdi32.dll", CharSet = CharSet.Auto, ExactSpelling = true, SetLastError = true)]
        public static extern int GetRegionData(HandleRef hRgn, int size, IntPtr lpRgnData);

        [DllImport("user32.dll")]
        private static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);

        /// <summary>
        /// Sets the windows hook, do the desired event, one of hInstance or threadId must be non-null
        /// </summary>
        /// <param name="idHook">The id of the event you want to hook</param>
        /// <param name="callback">The callback.</param>
        /// <param name="hInstance">The handle you want to attach the event to, can be null</param>
        /// <param name="threadId">The thread you want to attach the event to, can be null</param>
        /// <returns>a handle to the desired hook</returns>
        [DllImport("user32.dll")]
        public static extern IntPtr SetWindowsHookEx(int idHook, KeyBoardHookProc callback, IntPtr hInstance, uint threadId);
        /// <summary>
        /// Unhooks the windows hook.
        /// </summary>
        /// <param name="hInstance">The hook handle that was returned from SetWindowsHookEx</param>
        /// <returns>True if successful, false otherwise</returns>
        [DllImport("user32.dll")]
        public static extern bool UnhookWindowsHookEx(IntPtr hInstance);
        /// <summary>
        /// Calls the next hook.
        /// </summary>
        /// <param name="idHook">The hook id</param>
        /// <param name="nCode">The hook code</param>
        /// <param name="wParam">The wparam.</param>
        /// <param name="lParam">The lparam.</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern int CallNextHookEx(IntPtr idHook, int nCode, int wParam, ref NativeStruct.KeyBoardHookStruct lParam);
        /// <summary>
        /// Loads the library.
        /// </summary>
        /// <param name="lpFileName">Name of the library</param>
        /// <returns>A handle to the library</returns>
        [DllImport("kernel32.dll")]
        public static extern IntPtr LoadLibrary(string lpFileName);
        /// <summary>
        /// Open Handle Windows Console
        /// </summary>
        /// <returns></returns>
        [DllImport("kernel32.dll")]
        public static extern Boolean AllocConsole();
        /// <summary>
        /// Copy Memory
        /// </summary>
        /// <param name="dst"></param>
        /// <param name="src"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        [DllImport("ntdll.dll", CallingConvention = CallingConvention.Cdecl)]
        public unsafe static extern byte* memcpy(byte* dst, byte* src, int count);
        /// <summary>
        /// Set Memory
        /// </summary>
        /// <param name="dst"></param>
        /// <param name="filler"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        [DllImport("ntdll.dll", CallingConvention = CallingConvention.Cdecl)]
        public unsafe static extern byte* memset(byte* dst, int filler, int count);
        /// <summary>
        /// Find HWND to get intPtr Handle
        /// </summary>
        /// <param name="zeroOnly"></param>
        /// <param name="lpWindowName"></param>
        /// <returns></returns>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindow(IntPtr zeroOnly, string lpWindowName);
        /// <summary>
        /// Send Message to handle Windows
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="wMsg"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int wMsg, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool PostMessage(HandleRef hWnd, uint Msg, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll")]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);


        [DllImport("kernel32")]
        public static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        public static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);
    }
    public class GlobalKeyboardHook
    {
        #region Instance Variables
        /// <summary>
        /// The collections of keys to watch for
        /// </summary>
        public List<Keys> HookedKeys = new List<Keys>();
        /// <summary>
        /// Handle to the hook, need this to unhook and call the next hook
        /// </summary>
        IntPtr hhook = IntPtr.Zero;
        /// <summary>
        /// Data Base Keys, Shift, Alt, Ctrl, etc 
        /// </summary>
        public Dictionary<Keys, bool> BDKey = new Dictionary<Keys, bool>();
        #endregion
        #region Events
        /// <summary>
        /// Occurs when one of the hooked keys is pressed
        /// </summary>
        public event KeyEventHandler KeyDown;
        /// <summary>
        /// Occurs when one of the hooked keys is released
        /// </summary>
        public event KeyEventHandler KeyUp;
        /// <summary>
        /// Fix to CG Collector Delegate
        /// </summary>
        public event KeyBoardHookProc KeyProc;
        #endregion
        #region Constructors and Destructors
        /// <summary>
        /// Initializes a new instance of the <see cref="GlobalKeyboardHook"/> class and installs the keyboard hook.
        /// </summary>
        public GlobalKeyboardHook()
        {
            Keys[] kd = (Keys[])Enum.GetValues(typeof(Keys));
            foreach (Keys key in kd)
            {
                if((key != Keys.None) && (key != Keys.Modifiers) && !BDKey.ContainsKey(key))
                    BDKey.Add(key, false);
            }
            KeyProc += hookProc;
            hook();
        }

        /// <summary>
        /// Releases unmanaged resources and performs other cleanup operations before the
        /// <see cref="GlobalKeyboardHook"/> is reclaimed by garbage collection and uninstalls the keyboard hook.
        /// </summary>
        ~GlobalKeyboardHook()
        {
            unhook();
        }
        #endregion
        #region Public Methods
        /// <summary>
        /// Installs the global hook
        /// </summary>
        public void hook()
        {
            IntPtr hInstance = NativeMethods.LoadLibrary("User32");
            hhook = NativeMethods.SetWindowsHookEx(NativeConstat.WH_KEYBOARD_LL, KeyProc, hInstance, 0);
        }

        /// <summary>
        /// Uninstalls the global hook
        /// </summary>
        public void unhook()
        {
            NativeMethods.UnhookWindowsHookEx(hhook);
        }

        /// <summary>
        /// The callback for the keyboard hook
        /// </summary>
        /// <param name="code">The hook code, if it isn't >= 0, the function shouldn't do anyting</param>
        /// <param name="wParam">The event type</param>
        /// <param name="lParam">The keyhook event information</param>
        /// <returns></returns>
        public int hookProc(int code, int wParam, ref NativeStruct.KeyBoardHookStruct lParam)
        {
            if (code >= 0)
            {
                Keys key = (Keys)lParam.vkCode;
                Terminal.WriteLine($"Keys:{key}");
                BDKey[key] = !BDKey[key];
                if (HookedKeys.Contains(key))
                {
                    KeyEventArgs kea = new KeyEventArgs(key);

                    if (BDKey[Keys.LShiftKey])
                        kea.Shift = BDKey[Keys.LShiftKey];
                    else if (BDKey[Keys.RShiftKey])
                        kea.Shift = BDKey[Keys.RShiftKey];
                    if (BDKey[Keys.LControlKey])
                        kea.Shift = BDKey[Keys.LControlKey];
                    else if (BDKey[Keys.RControlKey])
                        kea.Shift = BDKey[Keys.RControlKey];
                    if (BDKey[Keys.Alt])
                        kea.Shift = BDKey[Keys.Alt];
                    if ((wParam == NativeConstat.WM_KEYDOWN || wParam == NativeConstat.WM_SYSKEYDOWN) && (KeyDown != null))
                    {
                        KeyDown(this, kea);
                    }
                    else if ((wParam == NativeConstat.WM_KEYUP || wParam == NativeConstat.WM_SYSKEYUP) && (KeyUp != null))
                    {
                        KeyUp(this, kea);
                    }
                    if (kea.Handled)
                        return 1;
                }
            }
            return NativeMethods.CallNextHookEx(hhook, code, wParam, ref lParam);
        }
        #endregion
    }
}
