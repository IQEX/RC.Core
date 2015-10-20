// =====================================//==============================================================//
// License="root\\LICENSE"              //   Copyright © Of Fire Twins Wesp 2015  <ls-micro@ya.ru>      //
// LicenseType="MIT"                    //                  Alise Wesp & Yuuki Wesp                     //
// =====================================//==============================================================//
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace Rc.Framework.Native
{
    
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
        public const int WH_KEYBOARD_LL = 13;
        public const int WM_KEYDOWN = 0x100;
        public const int WM_KEYUP = 0x101;
        public const int WM_SYSKEYDOWN = 0x104;
        public const int WM_SYSKEYUP = 0x105;

        public const int SW_HIDE = 0x0;
        public const int SW_SHOW = 0x5;
        public const int SW_Min = 0x2;
        public const int SW_Max = 0x3;
        public const int SW_Norm = 0x4;
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

    [StructLayout(LayoutKind.Sequential)]
    public struct SYSTEM_INFO
    {
        internal _PROCESSOR_INFO_UNION uProcessorInfo;
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
        internal uint dwOemId;
        [FieldOffset(0)]
        internal ushort wProcessorArchitecture;
        [FieldOffset(2)]
        internal ushort wReserved;
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
        [DllImport("kernel32.dll")]
        public static extern void GetSystemInfo([MarshalAs(UnmanagedType.Struct)] out SYSTEM_INFO lpSystemInfo);

        [DllImport("user32.dll", EntryPoint = "SetCursorPos")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SetCursorPos(int X, int Y);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetCursorPos(out MousePoint lpMousePoint);

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
