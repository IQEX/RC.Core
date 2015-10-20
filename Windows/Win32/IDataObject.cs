using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rc.Framework.Windows.Win32
{
    /// <summary>
    /// Предоставляет не зависящий от формата механизм передачи данных.
    /// </summary>
    public interface IDataObject
    {
        /// <summary>Получает данные, связанные с указанным форматом данных, используя значение типа Boolean для определения необходимости преобразования данных в этот формат.</summary>
        /// <returns>Данные, связанные с заданным форматом, или значение null.</returns>
        /// <param name="format">Формат извлекаемых данных.Сведения о предварительно определенных форматах см. в разделе <see cref="T:System.Windows.Forms.DataFormats" />.</param>
        /// <param name="autoConvert">Значение true, если данные необходимо преобразовать в указанный формат, и значение false в противном случае. </param>
        /// <filterpriority>1</filterpriority>
        object GetData(string format, bool autoConvert);
        /// <summary>Получает данные, связанные с заданным форматом.</summary>
        /// <returns>Данные, связанные с заданным форматом, или значение null.</returns>
        /// <param name="format">Формат извлекаемых данных.Сведения о предварительно определенных форматах см. в разделе <see cref="T:System.Windows.Forms.DataFormats" />.</param>
        /// <filterpriority>1</filterpriority>
        object GetData(string format);
        /// <summary>Получает данные, связанные с заданным форматом типа класса.</summary>
        /// <returns>Данные, связанные с заданным форматом, или значение null.</returns>
        /// <param name="format">Объект <see cref="T:System.Type" />, представляющий формат извлекаемых данных.Сведения о предварительно определенных форматах см. в разделе <see cref="T:System.Windows.Forms.DataFormats" />.</param>
        /// <filterpriority>1</filterpriority>
        object GetData(Type format);
        /// <summary>Сохраняет указанные данные и связанный с ними формат в этом экземпляре и в значении типа Boolean задает, возможно ли преобразование данных в другой формат.</summary>
        /// <param name="format">Формат, связанный с данными.Сведения о предварительно определенных форматах см. в разделе <see cref="T:System.Windows.Forms.DataFormats" />.</param>
        /// <param name="autoConvert">Значение true, если необходимо разрешить преобразование данных в другой формат; в противном случае — значение false. </param>
        /// <param name="data">Сохраняемые данные. </param>
        /// <filterpriority>1</filterpriority>
        void SetData(string format, bool autoConvert, object data);
        /// <summary>Сохраняет указанные данные и связанный с ними формат в этом экземпляре.</summary>
        /// <param name="format">Формат, связанный с данными.Сведения о предварительно определенных форматах см. в разделе <see cref="T:System.Windows.Forms.DataFormats" />.</param>
        /// <param name="data">Сохраняемые данные. </param>
        /// <filterpriority>1</filterpriority>
        void SetData(string format, object data);
        /// <summary>Сохраняет указанные данные и связанный с ними тип класса в этом экземпляре.</summary>
        /// <param name="format">Тип <see cref="T:System.Type" />, представляющий формат, связанный с данными.Сведения о предварительно определенных форматах см. в разделе <see cref="T:System.Windows.Forms.DataFormats" />.</param>
        /// <param name="data">Сохраняемые данные. </param>
        /// <filterpriority>1</filterpriority>
        void SetData(Type format, object data);
        /// <summary>Сохраняет указанные данные в этом экземпляре, используя класс данных для формата.</summary>
        /// <param name="data">Сохраняемые данные. </param>
        /// <filterpriority>1</filterpriority>
        void SetData(object data);
        /// <summary>Определяет, связаны ли хранимые в данном экземпляре данные с указанным форматом, определяя с помощью значения типа Boolean, необходимо ли преобразовать данные в этот формат.</summary>
        /// <returns>Значение true, если формат данных совпадает с указанным форматом или может быть преобразован в указанный формат. В противном случае — значение false.</returns>
        /// <param name="format">Формат, для которого выполняется проверка.Сведения о предварительно определенных форматах см. в разделе <see cref="T:System.Windows.Forms.DataFormats" />.</param>
        /// <param name="autoConvert">Значение true, если необходимо определить возможность преобразования данных, хранимых в данном экземпляре, в указанный формат, и значение false, если необходимо проверить наличие данных в указанном формате. </param>
        /// <filterpriority>1</filterpriority>
        bool GetDataPresent(string format, bool autoConvert);
        /// <summary>Определяет, связаны ли хранимые в данном экземпляре данные с указанным форматом или возможно ли их преобразование в этот формат.</summary>
        /// <returns>Значение true, если хранящиеся в данном экземпляре данные связаны с указанным форматом или могут быть преобразованы в него. В противном случае — значение false.</returns>
        /// <param name="format">Формат, для которого выполняется проверка.Сведения о предварительно определенных форматах см. в разделе <see cref="T:System.Windows.Forms.DataFormats" />.</param>
        /// <filterpriority>1</filterpriority>
        bool GetDataPresent(string format);
        /// <summary>Определяет, связаны ли хранимые в данном экземпляре данные с указанным форматом или возможно ли их преобразование в этот формат.</summary>
        /// <returns>Значение true, если хранящиеся в данном экземпляре данные связаны с указанным форматом или могут быть преобразованы в него. В противном случае — значение false.</returns>
        /// <param name="format">Тип <see cref="T:System.Type" />, представляющий формат, для которого выполняется проверка.Сведения о предварительно определенных форматах см. в разделе <see cref="T:System.Windows.Forms.DataFormats" />.</param>
        /// <filterpriority>1</filterpriority>
        bool GetDataPresent(Type format);
        /// <summary>Получает список всех форматов, с которыми связаны хранимые в этом экземпляре данные или в которые они могут быть преобразованы. С помощью значения типа Boolean определяется, необходимо ли извлечь все форматы, в которые данные могут быть преобразованы, или только собственные форматы данных.</summary>
        /// <returns>Массив имен, представляющий список всех форматов, поддерживаемых данными, хранящимися в данном объекте.</returns>
        /// <param name="autoConvert">Значение true, если необходимо извлечь все форматы, с которыми связаны данные, хранящиеся в этом экземпляре, или форматы, в которые они могут быть преобразованы. Значение false, если необходимо извлечь только собственные форматы данных. </param>
        /// <filterpriority>1</filterpriority>
        string[] GetFormats(bool autoConvert);
        /// <summary>Возвращает список всех форматов, с которыми связаны данные, хранящиеся в этом экземпляре, или в которые они могут быть преобразованы.</summary>
        /// <returns>Массив имен, представляющий список всех форматов, поддерживаемых данными, хранящимися в данном объекте.</returns>
        /// <filterpriority>1</filterpriority>
        string[] GetFormats();
    }
}
