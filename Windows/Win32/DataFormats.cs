using Rc.Framework.Native;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rc.Framework.Windows.Win32
{
    /// <summary>Предоставляет static, предопределенные имена формата <see cref="T:System.Windows.Forms.Clipboard" />.Используйте их для для обозначения формата данных, хранимых в <see cref="T:System.Windows.Forms.IDataObject" />.</summary>
	/// <filterpriority>2</filterpriority>
	public class DataFormats
    {
        /// <summary>Представляет тип формата буфера обмена.</summary>
        public class Format
        {
            private readonly string name;
            private readonly int id;
            /// <summary>Возвращает имя данного формата.</summary>
            /// <returns>Имя этого формата.</returns>
            public string Name
            {
                get
                {
                    return this.name;
                }
            }
            /// <summary>Получает идентификационный номер для этого формата.</summary>
            /// <returns>Идентификационный номер для этого формата.</returns>
            public int Id
            {
                get
                {
                    return this.id;
                }
            }
            /// <summary>Инициализирует новый экземпляр класса <see cref="T:System.Windows.Forms.DataFormats.Format" /> с логическим значением, указывающим, ожидается ли дескриптор Win32.</summary>
            /// <param name="name">Имя этого формата. </param>
            /// <param name="id">Идентификационный номер для этого формата. </param>
            public Format(string name, int id)
            {
                this.name = name;
                this.id = id;
            }
        }
        /// <summary>Задает стандартный текстовый формат ANSI.Это static поле доступно только для чтения.</summary>
        /// <filterpriority>1</filterpriority>
        public static readonly string Text = "Text";
        /// <summary>Задает стандартный текстовый формат Windows Unicode.Это static поле доступно только для чтения.</summary>
        /// <filterpriority>1</filterpriority>
        public static readonly string UnicodeText = "UnicodeText";
        /// <summary>Задает формат аппаратно-независимых точечных рисунков Windows (Device Independent Bitmap, DIB).Это static поле доступно только для чтения.</summary>
        /// <filterpriority>1</filterpriority>
        public static readonly string Dib = "DeviceIndependentBitmap";
        /// <summary>Задает формат точечного рисунка Windows.Это static поле доступно только для чтения.</summary>
        /// <filterpriority>1</filterpriority>
        public static readonly string Bitmap = "Bitmap";
        /// <summary>Задает формат расширенного метафайла Windows.Это static поле доступно только для чтения.</summary>
        /// <filterpriority>1</filterpriority>
        public static readonly string EnhancedMetafile = "EnhancedMetafile";
        /// <summary>Задает формат метафайла Windows, который формы Windows Forms напрямую не используют.Это static поле доступно только для чтения.</summary>
        /// <filterpriority>1</filterpriority>
        public static readonly string MetafilePict = "MetaFilePict";
        /// <summary>Задает формат символической ссылки Windows, который формы Windows Forms напрямую не используют.Это static поле доступно только для чтения.</summary>
        /// <filterpriority>1</filterpriority>
        public static readonly string SymbolicLink = "SymbolicLink";
        /// <summary>Задает формат обмена данными Windows (Data Interchange Format, DIF), который формы Windows Forms напрямую не используют.Это static поле доступно только для чтения.</summary>
        /// <filterpriority>1</filterpriority>
        public static readonly string Dif = "DataInterchangeFormat";
        /// <summary>Задает теговый формат файла изображения Windows (Tagged Image File Format, TIFF), который формы Windows Forms напрямую не используют.Это static поле доступно только для чтения.</summary>
        /// <filterpriority>1</filterpriority>
        public static readonly string Tiff = "TaggedImageFileFormat";
        /// <summary>Задает стандартный текстовый формат системы поставщиков основного оборудования (original equipment manufacturer, OEM) Windows.Это static поле доступно только для чтения.</summary>
        /// <filterpriority>1</filterpriority>
        public static readonly string OemText = "OEMText";
        /// <summary>Задает формат палитры Windows.Это static поле доступно только для чтения.</summary>
        /// <filterpriority>1</filterpriority>
        public static readonly string Palette = "Palette";
        /// <summary>Задает формат данных пера Windows, который состоит из штрихов пера для программного обеспечения ручного письма; формы Windows Forms не используют этот формат.Это static поле доступно только для чтения.</summary>
        /// <filterpriority>1</filterpriority>
        public static readonly string PenData = "PenData";
        /// <summary>Задает звуковой формат файла обмена ресурсами Windows (Resource Interchange File Format, RIFF), который формы Windows Forms напрямую не используют.Это static поле доступно только для чтения.</summary>
        /// <filterpriority>1</filterpriority>
        public static readonly string Riff = "RiffAudio";
        /// <summary>Задает формат WAV, который Win Forms напрямую не использует.Это static поле доступно только для чтения.</summary>
        /// <filterpriority>1</filterpriority>
        public static readonly string WaveAudio = "WaveAudio";
        /// <summary>Задает формат обмена данными Windows, который формы Windows Forms напрямую не используют.Это static поле доступно только для чтения.</summary>
        /// <filterpriority>1</filterpriority>
        public static readonly string FileDrop = "FileDrop";
        /// <summary>Задает формат языка и региональных параметров Windows, который формы Windows Forms напрямую не используют.Это static поле доступно только для чтения.</summary>
        /// <filterpriority>1</filterpriority>
        public static readonly string Locale = "Locale";
        /// <summary>Задает текст, состоящий из данных HTML.Это static поле доступно только для чтения.</summary>
        /// <filterpriority>1</filterpriority>
        public static readonly string Html = "HTML Format";
        /// <summary>Задает текст, состоящий из данных формата Rich Text Format (RTF).Это static поле доступно только для чтения.</summary>
        /// <filterpriority>1</filterpriority>
        public static readonly string Rtf = "Rich Text Format";
        /// <summary>Задает формат значений, разделенных запятой (comma-separated value, CSV), являющийся общепринятым форматом, используемым для обмена между программами электронных таблиц.Этот формат не используется непосредственно формами Windows Forms.Это static поле доступно только для чтения.</summary>
        /// <filterpriority>1</filterpriority>
        public static readonly string CommaSeparatedValue = "Csv";
        /// <summary>Задает формат строкового класса форм Windows Forms, который формы Windows Forms используют для хранения строковых объектов.Это static поле доступно только для чтения.</summary>
        /// <filterpriority>1</filterpriority>
        public static readonly string StringFormat = typeof(string).FullName;
        /// <summary>Задает формат, инкапсулирующий любой тип объекта форм Windows Forms.Это static поле доступно только для чтения.</summary>
        /// <filterpriority>1</filterpriority>
        private static DataFormats.Format[] formatList;
        private static int formatCount = 0;
        private static object internalSyncObject = new object();
        private DataFormats()
        {
        }
        /// <summary>Возвращает <see cref="T:System.Windows.Forms.DataFormats.Format" /> с цифровым идентификатором буфера обмена Windows и именем указанного формата.</summary>
        /// <returns>
        ///   <see cref="T:System.Windows.Forms.DataFormats.Format" /> с цифровым идентификатором буфера обмена Windows и именем формата.</returns>
        /// <param name="format">Имя формата. </param>
        /// <exception cref="T:System.ComponentModel.Win32Exception">Регистрация нового формата <see cref="T:System.Windows.Forms.Clipboard" /> неудачна. </exception>
        /// <filterpriority>1</filterpriority>
        public static DataFormats.Format GetFormat(string format)
        {
            bool flag = false;
            DataFormats.Format result;
            try
            {
                object obj = DataFormats.internalSyncObject;
                Monitor.Enter(obj, ref flag);
                DataFormats.EnsurePredefined();
                for (int i = 0; i < DataFormats.formatCount; i++)
                {
                    if (DataFormats.formatList[i].Name.Equals(format))
                    {
                        result = DataFormats.formatList[i];
                        return result;
                    }
                }
                for (int j = 0; j < DataFormats.formatCount; j++)
                {
                    if (string.Equals(DataFormats.formatList[j].Name, format, StringComparison.OrdinalIgnoreCase))
                    {
                        result = DataFormats.formatList[j];
                        return result;
                    }
                }
                int num = NativeMethods.RegisterClipboardFormat(format);
                if (num == 0)
                {
                    throw new Win32Exception(Marshal.GetLastWin32Error(), null);
                }
                DataFormats.EnsureFormatSpace(1);
                DataFormats.formatList[DataFormats.formatCount] = new DataFormats.Format(format, num);
                result = DataFormats.formatList[DataFormats.formatCount++];
            }
            catch
            {
                result = null;
            }
            return result;
        }
        /// <summary>Возвращает <see cref="T:System.Windows.Forms.DataFormats.Format" /> с цифровым идентификатором буфера обмена Windows и именем указанного идентификатора.</summary>
        /// <returns>
        ///   <see cref="T:System.Windows.Forms.DataFormats.Format" /> с цифровым идентификатором буфера обмена Windows и именем формата.</returns>
        /// <param name="id">Идентификатор формата. </param>
        /// <filterpriority>1</filterpriority>
        public static DataFormats.Format GetFormat(int id)
        {
            return DataFormats.InternalGetFormat(null, (ushort)(id & 65535));
        }
        private static DataFormats.Format InternalGetFormat(string strName, ushort id)
        {
            bool flag = false;
            DataFormats.Format result;
            try
            {
                object obj = DataFormats.internalSyncObject;
                Monitor.Enter(obj, ref flag);
                DataFormats.EnsurePredefined();
                for (int i = 0; i < DataFormats.formatCount; i++)
                {
                    if (DataFormats.formatList[i].Id == (int)id)
                    {
                        result = DataFormats.formatList[i];
                        return result;
                    }
                }
                StringBuilder stringBuilder = new StringBuilder(128);
                StringBuilder expr_4F = stringBuilder;
                if (NativeMethods.GetClipboardFormatName((int)id, expr_4F, expr_4F.Capacity) == 0)
                {
                    stringBuilder.Length = 0;
                    if (strName == null)
                    {
                        stringBuilder.Append("Format").Append(id);
                    }
                    else
                    {
                        stringBuilder.Append(strName);
                    }
                }
                DataFormats.EnsureFormatSpace(1);
                DataFormats.formatList[DataFormats.formatCount] = new DataFormats.Format(stringBuilder.ToString(), (int)id);
                result = DataFormats.formatList[DataFormats.formatCount++];
            }
            catch
            {
                result = null;
            }
            return result;
        }
        private static void EnsureFormatSpace(int size)
        {
            if (DataFormats.formatList == null || DataFormats.formatList.Length <= DataFormats.formatCount + size)
            {
                DataFormats.Format[] array = new DataFormats.Format[DataFormats.formatCount + 20];
                for (int i = 0; i < DataFormats.formatCount; i++)
                {
                    array[i] = DataFormats.formatList[i];
                }
                DataFormats.formatList = array;
            }
        }
        private static void EnsurePredefined()
        {
            if (DataFormats.formatCount == 0)
            {
                DataFormats.formatList = new DataFormats.Format[]
                {
                    new DataFormats.Format(DataFormats.UnicodeText, 13),
                    new DataFormats.Format(DataFormats.Text, 1),
                    new DataFormats.Format(DataFormats.Bitmap, 2),
                    new DataFormats.Format(DataFormats.MetafilePict, 3),
                    new DataFormats.Format(DataFormats.EnhancedMetafile, 14),
                    new DataFormats.Format(DataFormats.Dif, 5),
                    new DataFormats.Format(DataFormats.Tiff, 6),
                    new DataFormats.Format(DataFormats.OemText, 7),
                    new DataFormats.Format(DataFormats.Dib, 8),
                    new DataFormats.Format(DataFormats.Palette, 9),
                    new DataFormats.Format(DataFormats.PenData, 10),
                    new DataFormats.Format(DataFormats.Riff, 11),
                    new DataFormats.Format(DataFormats.WaveAudio, 12),
                    new DataFormats.Format(DataFormats.SymbolicLink, 4),
                    new DataFormats.Format(DataFormats.FileDrop, 15),
                    new DataFormats.Format(DataFormats.Locale, 16)
                };
                DataFormats.formatCount = DataFormats.formatList.Length;
            }
        }
    }
}
