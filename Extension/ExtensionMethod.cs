using System;
using System.Collections.Generic;
using System.Linq;
/// <summary>
/// Класс расширений
/// </summary>
public static class ExtensionMethods
{
    /// <summary>
    /// Short expression of string.Format(XXX, arg1, arg2, ...)
    /// </summary>
    /// <param name="format"></param>
    /// <param name="args"></param>
    /// <returns></returns>
    public static string DoFormat(this string format, params object[] args)
    {
        return string.Format(format, args);
    }
    /// <summary>
    /// Переводит в лист
    /// </summary>
    /// <typeparam name="T">Тип</typeparam>
    /// <param name="source">Исходная</param>
    /// <returns></returns>
    public static List<T> AsList<T>(this IEnumerable<T> source)
    {
        List<T> list = source as List<T>;
        if (list != null)
        {
            return list;
        }
        return source.ToList<T>();
    }
    /// <summary>
    /// Returns a value indicating whether a specified substring occurs within this string.
    /// </summary>
    /// <param name="text">Text</param>
    /// <param name="value">The string to seek.</param>
    /// <param name="comparison">Setting</param>
    /// <returns></returns>
    public static bool Contains(this string text, string value, StringComparison comparison)
    {
        if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(value))
            return false;
        return text.IndexOf(value, comparison) >= 0;
    }
    /// <summary>
    /// null
    /// </summary>
    /// <param name="text"></param>
    /// <param name="value"></param>
    /// <param name="startIndex"></param>
    /// <param name="comparison"></param>
    /// <returns></returns>
    public static bool StartsWith(this string text, string value, int startIndex, StringComparison comparison = StringComparison.Ordinal)
    {
        return !string.IsNullOrEmpty(text) && startIndex <= text.Length && !string.IsNullOrEmpty(value) && text.IndexOf(value, startIndex, comparison) == startIndex;
    }
    /// <summary>
    /// null
    /// </summary>
    /// <param name="text"></param>
    /// <param name="strings"></param>
    /// <param name="comparison"></param>
    /// <returns></returns>
    public static string StartsWithOneOf(this string text, string[] strings, StringComparison comparison = StringComparison.Ordinal)
    {
        if (string.IsNullOrEmpty(text) || strings == null || strings.Length == 0)
        {
            return null;
        }
        for (int i = 0; i < strings.Length; i++)
        {
            string text2 = strings[i];
            if (text.StartsWith(text2, comparison))
            {
                return text2;
            }
        }
        return null;
    }
    /// <summary>
    /// null
    /// </summary>
    /// <param name="text"></param>
    /// <param name="startIndex"></param>
    /// <param name="strings"></param>
    /// <param name="comparison"></param>
    /// <returns></returns>
    public static string StartsWithOneOf(this string text, int startIndex, string[] strings, StringComparison comparison = StringComparison.Ordinal)
    {
        if (string.IsNullOrEmpty(text) || strings == null || strings.Length == 0)
        {
            return null;
        }
        for (int i = 0; i < strings.Length; i++)
        {
            string text2 = strings[i];
            if (text.StartsWith(text2, startIndex, comparison))
            {
                return text2;
            }
        }
        return null;
    }
}
