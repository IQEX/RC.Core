using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using RC.Framework.Screens;

/// <summary>
/// Класс расширений
/// </summary>
public static class ExtensionMethods
{
    /// <summary>
    /// The extension for types time, like in ruby
    /// </summary>
    public static long Minutes(this int i) => (long)TimeSpan.FromMinutes(i).TotalMilliseconds;
    public static long Hours(this int i) => (long)TimeSpan.FromHours(i).TotalMilliseconds;
    public static long Days(this int i) => (long)TimeSpan.FromDays(i).TotalMilliseconds;
    public static long Second(this int i) => (long)TimeSpan.FromSeconds(i).TotalMilliseconds;


    /// <summary>
    /// Regex Replace
    /// </summary>
    /// <param name="value">
    /// current string
    /// </param>
    /// <param name="rule">
    /// Regex rule match
    /// </param>
    /// <param name="to">
    /// Replace to text
    /// </param>
    /// <returns>
    /// Complete string
    /// </returns>
    public static string ReplaceRex(this string value, string rule, string to = "") => Regex.Replace(value, rule, to);

    /// <summary>
    /// Colored string [RCL]
    /// </summary>
    public static string To(this string s, Color c) => RCL.Wrap(s, c);
    public static Tuple<string, string> GetFullExceptionMessage(this Exception exception)
    {
        if (exception.InnerException == null)
        {
            if (exception.GetType() != typeof(ArgumentException))
                return new Tuple<string, string>(exception.Message, exception.StackTrace);
            var argumentName = ((ArgumentException)exception).ParamName;
            return new Tuple<string, string>($"{exception.Message} With null argument named '{argumentName}'.", exception.StackTrace);
        }
        var innerExceptionInfo = GetFullExceptionMessage(exception.InnerException);
        return new Tuple<string, string>(
            $"{innerExceptionInfo.Item1}{Environment.NewLine}{exception.Message}",
            $"{innerExceptionInfo.Item2}{Environment.NewLine}{exception.StackTrace}");
    }
    public static Exception GetOriginalException(this Exception ex) => ex.InnerException == null ? ex : ex.InnerException.GetOriginalException();

    /// <summary>
    /// Short expression of string.Format(XXX, arg1, arg2, ...)
    /// </summary>
    /// <param name="format"></param>
    /// <param name="args"></param>
    /// <returns></returns>
    public static string DoFormat(this string format, params object[] args) => string.Format(format, args);
    /// <summary>
    /// Returns a value indicating whether a specified substring occurs within this string.
    /// </summary>
    /// <param name="text">Text</param>
    /// <param name="value">The string to seek.</param>
    /// <param name="comparison">Setting</param>
    /// <returns></returns>
    public static bool Contains(this string text, string value, StringComparison comparison = StringComparison.CurrentCulture) => text.IndexOf(value, comparison) >= 0;

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
    public static bool IsNullOrWhiteSpace(this string t) => string.IsNullOrWhiteSpace(t);
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
    public static bool IsNullOrEmpty(this string t) => string.IsNullOrEmpty(t);
    /// <summary>
    /// Short expression of string.IsNullOrEmpty(<see cref="String"/>) or string.IsNullOrWhiteSpace(<see cref="String"/>)
    /// </summary>
    /// <param name="t">
    /// The string for checking.
    /// </param>
    /// <returns></returns>
    public static bool IsNullOrEmptyOrWhiteSpace(this string t) => string.IsNullOrEmpty(t) && string.IsNullOrWhiteSpace(t);
    /// <summary>
    /// To get an ID(num) enumeration
    /// </summary>
    /// <typeparam name="TEnum">
    /// Type of Enum
    /// </typeparam>
    /// <returns>
    /// ID(num)
    /// </returns>
    public static int getID<TEnum>(this TEnum s) where TEnum : struct, IConvertible
    {
        if (!typeof(TEnum).IsEnum) throw new ArgumentException($"'{nameof(TEnum)}' must be an enumerated type!");

        return (int)(object)s; // So shit :(
    }


    public static bool IsNum(this string source) => int.TryParse(source, out _);

    /// <summary>
    ///     Strips the last specified chars from a string.
    /// </summary>
    /// <param name="sourceString"> The source string. </param>
    /// <param name="removeFromEnd"> The remove from end. </param>
    /// <returns> </returns>
    public static string Chop(this string sourceString, int removeFromEnd = 1)
    {
        var result = sourceString;
        if ((removeFromEnd > 0) && (sourceString.Length > removeFromEnd - 1))
            result = result.Remove(sourceString.Length - removeFromEnd, removeFromEnd);
        return result;
    }

    /// <summary>
    ///     Strips the last specified chars from a string.
    /// </summary>
    /// <param name="sourceString"> The source string. </param>
    /// <param name="backDownTo"> The back down to. </param>
    /// <returns> </returns>
    public static string Chop(this string sourceString, string backDownTo)
    {
        var removeDownTo = sourceString.LastIndexOf(backDownTo, StringComparison.Ordinal);
        var removeFromEnd = 0;
        if (removeDownTo > 0)
            removeFromEnd = sourceString.Length - removeDownTo;

        var result = sourceString;

        if (sourceString.Length > removeFromEnd - 1)
            result = result.Remove(removeDownTo, removeFromEnd);

        return result;
    }
    

    /// <summary>
    ///     Removes the specified chars from the beginning of a string.
    /// </summary>
    /// <param name="sourceString"> The source string. </param>
    /// <param name="removeFromBeginning"> The remove from beginning. </param>
    /// <returns> </returns>
    public static string Clip(this string sourceString, int removeFromBeginning)
    {
        var result = sourceString;
        if (sourceString.Length > removeFromBeginning)
            result = result.Remove(0, removeFromBeginning);
        return result;
    }

    /// <summary>
    ///     Removes chars from the beginning of a string, up to the specified string
    /// </summary>
    /// <param name="sourceString"> The source string. </param>
    /// <param name="removeUpTo"> The remove up to. </param>
    /// <returns> </returns>
    public static string Clip(this string sourceString, string removeUpTo)
    {
        var removeFromBeginning = sourceString.IndexOf(removeUpTo, StringComparison.Ordinal);
        var result = sourceString;

        if (sourceString.Length > removeFromBeginning && removeFromBeginning > 0)
            result = result.Remove(0, removeFromBeginning);

        return result;
    }

    /// <summary>
    ///     Strips the last char from a a string.
    /// </summary>
    /// <param name="sourceString"> The source string. </param>
    /// <returns> </returns>
    public static string Clip(this string sourceString)
    {
        return Clip(sourceString, 1);
    }

    /// <summary>
    ///     Fasts the replace.
    /// </summary>
    /// <param name="original"> The original. </param>
    /// <param name="pattern"> The pattern. </param>
    /// <param name="replacement"> The replacement. </param>
    /// <param name="comparisonType"> Type of the comparison. </param>
    /// <returns> </returns>
    public static string FastReplace(this string original, string pattern, string replacement,
                                     StringComparison comparisonType = StringComparison.InvariantCultureIgnoreCase)
    {
        if (original == null)
            return null;

        if (string.IsNullOrEmpty(pattern))
            return original;

        var lenPattern = pattern.Length;
        var idxPattern = -1;
        var idxLast = 0;

        var result = new StringBuilder();

        while (true)
        {
            idxPattern = original.IndexOf(pattern, idxPattern + 1, comparisonType);

            if (idxPattern < 0)
            {
                result.Append(original, idxLast, original.Length - idxLast);
                break;
            }

            result.Append(original, idxLast, idxPattern - idxLast);
            result.Append(replacement);

            idxLast = idxPattern + lenPattern;
        }

        return result.ToString();
    }

    /// <summary>
    ///     Returns text that is located between the startText and endText tags.
    /// </summary>
    /// <param name="sourceString"> The source string. </param>
    /// <param name="startText"> The text from which to start the crop </param>
    /// <param name="endText"> The endpoint of the crop </param>
    /// <returns> </returns>
    public static string Crop(this string sourceString, string startText, string endText)
    {
        var startIndex = sourceString.IndexOf(startText, StringComparison.CurrentCultureIgnoreCase);
        if (startIndex == -1)
            return string.Empty;

        startIndex += startText.Length;
        var endIndex = sourceString.IndexOf(endText, startIndex, StringComparison.CurrentCultureIgnoreCase);
        if (endIndex == -1)
            return string.Empty;

        return sourceString.Substring(startIndex, endIndex - startIndex);
    }

    /// <summary>
    ///     Removes excess white space in a string.
    /// </summary>
    /// <param name="sourceString"> The source string. </param>
    /// <returns> </returns>
    public static string Squeeze(this string sourceString)
    {
        char[] delim = { ' ' };
        var lines = sourceString.Split(delim, StringSplitOptions.RemoveEmptyEntries);
        var sb = new StringBuilder();
        foreach (var s in lines)
        {
            if (!string.IsNullOrEmpty(s.Trim()))
                sb.Append(s + " ");
        }
        //remove the last pipe
        var result = Chop(sb.ToString());
        return result.Trim();
    }

    /// <summary>
    ///     Removes all non-alpha numeric characters in a string
    /// </summary>
    /// <param name="sourceString"> The source string. </param>
    /// <returns> </returns>
    public static string ToAlphaNumericOnly(this string sourceString)
    {
        return Regex.Replace(sourceString, @"\W*", "");
    }

    /// <summary>
    ///     Creates a string array based on the words in a sentence
    /// </summary>
    /// <param name="sourceString"> The source string. </param>
    /// <returns> </returns>
    public static string[] ToWords(this string sourceString)
    {
        var result = sourceString.Trim();
        return result.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
    }

    /// <summary>
    ///     Capitalise Each Word
    /// </summary>
    /// <param name="s">string</param>
    /// <returns>Capitalised String</returns>
    public static string Capitalise(string s)
    {
        var x = s.ToLower();
        var result = string.Empty;
        foreach (var c in x)
            result = result.Length == 0 && c != ' ' ? c.ToString().ToUpper() : (result.EndsWith(" ") ? result + c.ToString().ToUpper() : result + c.ToString());
        return result;
    }

    /// <summary>
    ///     Strips all HTML tags from a string
    /// </summary>
    /// <param name="htmlString"> The HTML string. </param>
    /// <returns> </returns>
    public static string StripHTML(this string htmlString)
    {
        return StripHTML(htmlString, string.Empty);
    }

    /// <summary>
    ///     Strips all HTML tags from a string and replaces the tags with the specified replacement
    /// </summary>
    /// <param name="htmlString"> The HTML string. </param>
    /// <param name="htmlPlaceHolder"> The HTML place holder. </param>
    /// <returns> </returns>
    public static string StripHTML(this string htmlString, string htmlPlaceHolder)
    {
        const string pattern = @"<(.|\n)*?>";
        var sOut = Regex.Replace(htmlString, pattern, htmlPlaceHolder);
        sOut = sOut.Replace("&nbsp;", string.Empty);
        sOut = sOut.Replace("&amp;", "&");
        sOut = sOut.Replace("&gt;", ">");
        sOut = sOut.Replace("&lt;", "<");
        return sOut;
    }

    public static List<string> FindMatches(this string source, string find)
    {
        var reg = new Regex(find, RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.Singleline);

        var result = new List<string>();
        foreach (Match m in reg.Matches(source))
            result.Add(m.Value);
        return result;
    }

    /// <summary>
    ///     Converts a generic List collection to a single string using the specified delimitter.
    /// </summary>
    /// <param name="list"> The list. </param>
    /// <param name="delimiter"> The delimiter. </param>
    /// <returns> </returns>
    public static string ToDelimitedList(this IEnumerable<string> list, string delimiter = ",")
    {
        var sb = new StringBuilder();
        foreach (var s in list)
            sb.Append(string.Concat(s, delimiter));
        var result = sb.ToString();
        result = Chop(result);
        return result;
    }

    /// <summary>
    ///     Strips the specified input.
    /// </summary>
    /// <param name="sourceString"> The source string. </param>
    /// <param name="stripValue"> The strip value. </param>
    /// <returns> </returns>
    public static string Strip(this string sourceString, string stripValue)
    {
        if (string.IsNullOrEmpty(stripValue)) return sourceString;
        var replace = stripValue.Split(new[] { ',' });
        foreach (var t in replace)
        {
            if (!string.IsNullOrEmpty(sourceString))
                sourceString = Regex.Replace(sourceString, t, string.Empty);
        }
        return sourceString;
    }

    /// <summary>
    ///     Converts ASCII encoding to Unicode
    /// </summary>
    /// <param name="asciiCode"> The ASCII code. </param>
    /// <returns> </returns>
    public static string AsciiToUnicode(this int asciiCode)
    {
        var ascii = Encoding.UTF32;
        var c = (char)asciiCode;
        var b = ascii.GetBytes(c.ToString());
        return ascii.GetString((b));
    }
    /// <summary>
    /// Date is between date1 + date2 (inclusive)
    /// </summary>
    /// <param name="input"></param>
    /// <param name="date1"></param>
    /// <param name="date2"></param>
    /// <returns></returns>
    public static bool IsBetween(this DateTime input, DateTime date1, DateTime date2)
    {
        return (input >= date1 && input <= date2);
    }

    /// <summary>
    /// Date passed has less than a month remaining
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public static bool IsLessThanAMonthRemaining(this DateTime input)
    {
        return input.Subtract(DateTime.Now).Days / (365.25 / 12) < 1;
    }

    /// <summary>
    ///     Returns the first day of the month
    /// </summary>
    /// <example>
    ///     DateTime firstOfThisMonth = DateTime.Now.FirstOfMonth;
    /// </example>
    /// <param name="dt">Start date</param>
    /// <returns></returns>
    public static DateTime FirstOfMonth(this DateTime dt)
    {
        return (dt.AddDays(1 - dt.Day)).AtMidnight();
    }

    /// <summary>
    ///     Returns the first specified day of the week in the current month
    /// </summary>
    /// <example>
    ///     DateTime firstTuesday = DateTime.Now.FirstDayOfMonth(DayOfWeek.Tuesday);
    /// </example>
    /// <param name="dt">Start date</param>
    /// <param name="dayOfWeek">The required day of week</param>
    /// <returns></returns>
    public static DateTime FirstOfMonth(this DateTime dt, DayOfWeek dayOfWeek)
    {
        DateTime firstDayOfMonth = dt.FirstOfMonth();
        return (firstDayOfMonth.DayOfWeek == dayOfWeek ? firstDayOfMonth :
                    firstDayOfMonth.NextDayOfWeek(dayOfWeek)).AtMidnight();
    }

    /// <summary>
    ///     Returns the last day in the current month
    /// </summary>
    /// <example>
    ///     DateTime endOfMonth = DateTime.Now.LastDayOfMonth();
    /// </example>
    /// <param name="dt" />
    /// Start date
    /// <returns />
    public static DateTime LastOfMonth(this DateTime dt)
    {
        int daysInMonth = DateTime.DaysInMonth(dt.Year, dt.Month);
        return dt.FirstOfMonth().AddDays(daysInMonth - 1).AtMidnight();
    }

    /// <summary>
    ///     Returns the last specified day of the week in the current month
    /// </summary>
    /// <example>
    ///     DateTime finalTuesday = DateTime.Now.LastDayOfMonth(DayOfWeek.Tuesday);
    /// </example>
    /// <param name="dt" />
    /// Start date
    /// <param name="dayOfWeek" />
    /// The required day of week
    /// <returns />
    public static DateTime LastOfMonth(this DateTime dt, DayOfWeek dayOfWeek)
    {
        DateTime lastDayOfMonth = dt.LastOfMonth();
        return lastDayOfMonth.AddDays(lastDayOfMonth.DayOfWeek < dayOfWeek ?
                                          dayOfWeek - lastDayOfMonth.DayOfWeek - 7 :
                                          dayOfWeek - lastDayOfMonth.DayOfWeek);
    }

    /// <summary>
    ///     Returns the next date which falls on the given day of the week
    /// </summary>
    /// <example>
    ///     DateTime nextTuesday = DateTime.Now.NextDayOfWeek(DayOfWeek.Tuesday);
    /// </example>
    /// <param name="dt">Start date</param>
    /// <param name="dayOfWeek">The required day of week</param>
    public static DateTime NextDayOfWeek(this DateTime dt, DayOfWeek dayOfWeek)
    {
        var offsetDays = dayOfWeek - dt.DayOfWeek;
        return dt.AddDays(offsetDays > 0 ? offsetDays : offsetDays + 7).AtMidnight();
    }

    /// <summary>
    ///     Returns the same day, at midnight
    /// </summary>
    /// <example>
    ///     DateTime startOfDay = DateTime.Now.AtMidnight();
    /// </example>
    /// <param name="dt">Start date</param>
    public static DateTime AtMidnight(this DateTime dt) => new DateTime(dt.Year, dt.Month, dt.Day, 0, 0, 0);

    /// <summary>
    ///     Returns the same day, at midday
    /// </summary>
    /// <example>
    ///     DateTime startOfAfternoon = DateTime.Now.AtMidday();
    /// </example>
    /// <param name="dt">Start date</param>
    public static DateTime AtMidday(this DateTime dt) => new DateTime(dt.Year, dt.Month, dt.Day, 12, 0, 0);
}
