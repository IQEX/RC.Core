// =====================================//==============================================================//
// License="root\\LICENSE"              //   Copyright © Of Fire Twins Wesp 2015  <ls-micro@ya.ru>      //
// LicenseType="MIT"                    //                  Alise Wesp & Yuuki Wesp                     //
// =====================================//==============================================================//
using System;
namespace RC.Framework.Extension
{
    /// <summary>
    /// Класс расширения конвертации
    /// </summary>
    public static class ExtensionConvert
    {
        /// <summary>
        /// Reads all available elements from an enumerator and inserts it into a collection.
        /// </summary>
        /// <typeparam name="T">Type of the collection.</typeparam>
        /// <param name="enumerator">The enumerator.</param>
        /// <returns>List</returns>
        public static Collections.Generic.RList<T> ToList<T>(this System.Collections.IEnumerator enumerator)
        {
            Collections.Generic.RList<T> collection = new Collections.Generic.RList<T>();
            while (enumerator.MoveNext())
                collection.Add((T)enumerator.Current);
            return collection;
        }
        /// <summary>
        /// Конвертация строки в <see cref="Guid"/>
        /// </summary>
        /// <param name="t">строка содержащие <see cref="Guid"/> для преобразования.</param>
        /// <returns>Преобразованное <see cref="Guid"/>.</returns>
        public static Guid ToGUID(this string t)
        {
            return new Guid(t);
        }
        /// <summary>
        /// Конвертация строки в <see cref="Int32"/>
        /// </summary>
        /// <param name="t">строка содержащие число для преобразования.</param>
        /// <returns>Преобразованное число.</returns>
        public static Int32 ToInt32(this string t)
        {
            return Int32.Parse(t);
        }
        /// <summary>
        /// Конвертация строки в <see cref="Int64"/>
        /// </summary>
        /// <param name="t">строка содержащие число для преобразования.</param>
        /// <returns>Преобразованное число.</returns>
        public static Int64 ToInt64(this string t)
        {
            return Int64.Parse(t);
        }
        /// <summary>
        /// Конвертация строки в <see cref="Int16"/>
        /// </summary>
        /// <param name="t">строка содержащие число для преобразования.</param>
        /// <returns>Преобразованное число.</returns>
        public static Int16 ToInt16(this string t)
        {
            return Int16.Parse(t);
        }
        /// <summary>
        /// Конвертация строки в <see cref="UInt16"/>
        /// </summary>
        /// <param name="t">строка содержащие число для преобразования.</param>
        /// <returns>Преобразованное число.</returns>
        public static UInt16 ToUInt16(this string t)
        {
            return UInt16.Parse(t);
        }
        /// <summary>
        /// Конвертация строки в <see cref="UInt32"/>
        /// </summary>
        /// <param name="t">строка содержащие число для преобразования.</param>
        /// <returns>Преобразованное число.</returns>
        public static UInt32 ToUInt32(this string t)
        {
            return UInt32.Parse(t);
        }
        /// <summary>
        /// Конвертация строки в <see cref="UInt64"/>
        /// </summary>
        /// <param name="t">строка содержащие число для преобразования.</param>
        /// <returns>Преобразованное число.</returns>
        public static UInt64 ToUInt64(this string t)
        {
            return UInt64.Parse(t);
        }
        /// <summary>
        /// Конвертация строки в <see cref="sbyte"/>
        /// </summary>
        /// <param name="t">строка содержащие число для преобразования.</param>
        /// <returns>Преобразованное число.</returns>
        public static sbyte ToSByte(this string t)
        {
            return sbyte.Parse(t);
        }
        /// <summary>
        /// Конвертация строки в <see cref="byte"/>
        /// </summary>
        /// <param name="t">строка содержащие число для преобразования.</param>
        /// <returns>Преобразованное число.</returns>
        public static byte ToByte(this string t)
        {
            return byte.Parse(t);
        }
        /// <summary>
        /// Конвертация строки в <see cref="float"/>
        /// </summary>
        /// <param name="t">строка содержащие число для преобразования.</param>
        /// <returns>Преобразованное число.</returns>
        public static float ToSingle(this string t)
        {
            return float.Parse(t);
        }
        /// <summary>
        /// Конвертация строки в <see cref="double"/>
        /// </summary>
        /// <param name="t">строка содержащие число для преобразования.</param>
        /// <returns>Преобразованное число.</returns>
        public static double ToDouble(this string t)
        {
            return double.Parse(t);
        }
        /// <summary>
        /// Конвертация строки в <typeparamref name="TEnum"/>
        /// </summary>
        /// <typeparam name="TEnum">строка содержащие значение для преобразования.</typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public static TEnum ToEnum<TEnum>(this string t)
        {
            return (TEnum)Enum.Parse(typeof(TEnum), t);
        }
        /// <summary>
        ///  конвертация строки в  <typeparamref name="TEnum"/>
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="t"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool TryToEnum<TEnum>(this string t, out TEnum obj)
        {
            //& При использовании Enum.TryParse происходит ошибка
            //# Ошибка CS0453
            //# Я хз как её исправить, не умею я генерики переводить
            obj = default(TEnum);
            try
            {
                obj = (TEnum)Enum.Parse(typeof(TEnum), t);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
