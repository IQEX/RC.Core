using System;
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
    /// Returns a value indicating whether a specified substring occurs within this string.
    /// </summary>
    /// <param name="text">Text</param>
    /// <param name="value">The string to seek.</param>
    /// <param name="comparison">Setting</param>
    /// <returns></returns>
    public static bool Contains(this string text, string value, StringComparison comparison = StringComparison.CurrentCulture)
    {
        return text.IndexOf(value, comparison) >= 0;
    }
    /// <summary>
    /// Short expression of string.IsNullOrWhiteSpace(<see cref="String"/>)
    /// 
    /// It indicates whether the specified string is null, the whether it is an empty string or a string consisting only of white space.
    /// </summary>
    /// <param name="t">
    /// The string for checking.
    /// </param>
    /// <returns>
    /// Is true, if the parameter <paramref name="t"/> is null or <see cref="String.Empty"/>, or if the parameter is <paramref name="t"/> contains only simvoly - delimiters.
    /// </returns>
    public static bool IsNullOrWhiteSpace(this string t)
    {
        return string.IsNullOrWhiteSpace(t);
    }

    /// <summary>
    /// Short expression of string.IsNullOrEmpty(<see cref="String"/>)
    /// 
    /// It indicates whether the specified string is null or the string <see cref="System.String.Empty"/>.
    /// </summary>
    /// <param name="t">
    /// The string for checking.
    /// </param>
    /// <returns>
    /// Is true, if the parameter <paramref name = "t" /> is null or empty string (""); otherwise - to false.
    /// </returns>
    public static bool IsNullOrEmpty(this string t)
    {
        return string.IsNullOrEmpty(t);
    }
    /// <summary>
    /// Short expression of string.IsNullOrEmpty(<see cref="String"/>) or string.IsNullOrWhiteSpace(<see cref="String"/>)
    /// </summary>
    /// <param name="t">
    /// The string for checking.
    /// </param>
    /// <returns></returns>
    public static bool IsNullOrEmptyOrWhiteSpace(this string t)
    {
        return string.IsNullOrEmpty(t) && string.IsNullOrWhiteSpace(t);
    }
}
