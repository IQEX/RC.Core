// =====================================//==============================================================//
// License="root\\LICENSE"              //   Copyright © Of Fire Twins Wesp 2015  <ls-micro@ya.ru>      //
// LicenseType="MIT"                    //                  Alise Wesp & Yuuki Wesp                     //
// =====================================//==============================================================//
using System;
using System.Globalization;
using RC.Framework;
/// <summary>
/// Класс расширения конвертации
/// </summary>
internal static class ExtensionConvert
{
    /// <summary>
    /// Конвертация строки в <see cref="Guid"/>
    /// </summary>
    /// <param name="t">строка содержащие <see cref="Guid"/> для преобразования.</param>
    /// <returns>Преобразованное <see cref="Guid"/>.</returns>
    public static Guid ToGUID(this string t) => new Guid(t);
    /// <summary>
    /// Конвертация строки в <see cref="Int32"/>
    /// </summary>
    /// <param name="t">строка содержащие число для преобразования.</param>
    /// <returns>Преобразованное число.</returns>
    public static int ToInt32(this string t) => int.Parse(t);
    /// <summary>
    /// Конвертация строки в <see cref="Int64"/>
    /// </summary>
    /// <param name="t">строка содержащие число для преобразования.</param>
    /// <returns>Преобразованное число.</returns>
    public static long ToInt64(this string t) => long.Parse(t);
    /// <summary>
    /// Конвертация строки в <see cref="Int16"/>
    /// </summary>
    /// <param name="t">строка содержащие число для преобразования.</param>
    /// <returns>Преобразованное число.</returns>
    public static short ToInt16(this string t) => short.Parse(t);
    /// <summary>
    /// Конвертация строки в <see cref="UInt16"/>
    /// </summary>
    /// <param name="t">строка содержащие число для преобразования.</param>
    /// <returns>Преобразованное число.</returns>
    public static ushort ToUInt16(this string t) => ushort.Parse(t);
    /// <summary>
    /// Конвертация строки в <see cref="UInt32"/>
    /// </summary>
    /// <param name="t">строка содержащие число для преобразования.</param>
    /// <returns>Преобразованное число.</returns>
    public static uint ToUInt32(this string t) => uint.Parse(t);
    /// <summary>
    /// Конвертация строки в <see cref="UInt64"/>
    /// </summary>
    /// <param name="t">строка содержащие число для преобразования.</param>
    /// <returns>Преобразованное число.</returns>
    public static ulong ToUInt64(this string t) => ulong.Parse(t);
    /// <summary>
    /// Конвертация строки в <see cref="sbyte"/>
    /// </summary>
    /// <param name="t">строка содержащие число для преобразования.</param>
    /// <returns>Преобразованное число.</returns>
    public static sbyte ToSByte(this string t) => sbyte.Parse(t);
    /// <summary>
    /// Конвертация строки в <see cref="byte"/>
    /// </summary>
    /// <param name="t">строка содержащие число для преобразования.</param>
    /// <returns>Преобразованное число.</returns>
    public static byte ToByte(this string t) => byte.Parse(t);

    /// <summary>
    /// Конвертация строки в <see cref="float"/>
    /// </summary>
    /// <param name="t">строка содержащие число для преобразования.</param>
    /// <returns>Преобразованное число.</returns>
    public static float ToSingle(this string t) => float.Parse(t, CultureInfo.InvariantCulture);
    /// <summary>
    /// Конвертация строки в <see cref="double"/>
    /// </summary>
    /// <param name="t">строка содержащие число для преобразования.</param>
    /// <returns>Преобразованное число.</returns>
    public static double ToDouble(this string t) => double.Parse(t, CultureInfo.InvariantCulture);
    /// <summary>
    /// Конвертация строки в <typeparamref name="TEnum"/>
    /// </summary>
    /// <typeparam name="TEnum">строка содержащие значение для преобразования.</typeparam>
    /// <param name="t"></param>
    /// <returns></returns>
    public static TEnum ToEnum<TEnum>(this string t) => (TEnum)Enum.Parse(typeof(TEnum), t);
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
    /// <summary>
    /// Конвертация типа <see cref="DateTime"/> в <see cref="TimeSpan"/>.
    /// </summary>
    public static TimeSpan ToTime(this DateTime s) => new TimeSpan(s.Ticks);
}