using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace SCRA.Common.Utilities
{
    public static class StringExtensions
    {
        public static string InnerTrim(this string text)
        {
            return Regex.Replace(text.Trim(), @"\s+", " ");
        }

        public static string CutFirst(this string text, string delimiter)
        {
            if (!string.IsNullOrEmpty(text))
            {
                return text.StartsWith(delimiter) ? text.Substring(delimiter.Length) : text;
            }

            return string.Empty;
        }

        public static string CutLast(this string text, string delimiter)
        {
            if (!string.IsNullOrEmpty(text))
            {
                return text.EndsWith(delimiter) ? text.Substring(0, text.Length - delimiter.Length) : text;
            }

            return string.Empty;
        }

        public static string Capitalize(this string text, char delimiter, bool removeDelimiter)
        {
            string capitalized = text
                .Split(delimiter)
                .Aggregate(string.Empty,
                    (current, w) => current + ((w.Length <= 1
                        ? w.ToUpper()
                        : w.Substring(0, 1).ToUpper() + w.Substring(1, w.Length - 1).ToLower()) + delimiter))
                .CutLast(delimiter.ToString());

            return removeDelimiter
                ? capitalized.Replace(delimiter.ToString(), string.Empty)
                : capitalized;
        }

        public static string Capitalize(this string text)
        {
            return text.Capitalize(' ', false);
        }

        public static string Denormalize(this string text)
        {
            return text.Replace("_lt_", "<").Replace("_gt_", ">");
        }

        public static string ToCamelCase(this string text)
        {
            return text.Substring(0, 1).ToLower() + text.Substring(1);
        }

        public static string ToSentence(this string text)
        {
            return Regex.Replace(text, @"(?x)([A-Z][a-z,0-9]+|[A-Z]+(?![a-z]))", " $0").InnerTrim();
        }

        public static string ToDelimitedSequence(this IEnumerable<string> texts, string delimiter)
        {
            IList<string> list = texts.Where(s => !string.IsNullOrEmpty(s)).ToList();

            return list.Count > 0
                ? list.Aggregate((sequence, s) => sequence + delimiter + s)
                : string.Empty;
        }

        public static string ToDelimitedSequence(this IEnumerable<string> texts)
        {
            return texts.ToDelimitedSequence(", ");
        }

        public static string ToPlainText(this string text)
        {
            return Regex.Replace(text, @"<[^>]*>", string.Empty);
        }

        public static string LimitedTo(this string text, int length, string limiter)
        {
            return text.ToPlainText().Length > length
                ? text.Substring(0, length) + limiter
                : text;
        }

        public static string LimitedTo(this string text, int length)
        {
            return text.LimitedTo(length, "...");
        }

        public static string[] SplitAtFirst(this string text, string delimiter)
        {
            if (!string.IsNullOrEmpty(text))
            {
                int indexOfDelimiter = text.IndexOf(delimiter, System.StringComparison.Ordinal);

                return indexOfDelimiter > 0
                    ? new[] { text.Substring(0, indexOfDelimiter), text.Substring(indexOfDelimiter + delimiter.Length) }
                    : new[] { text, string.Empty };
            }

            return new[] { string.Empty, string.Empty };
        }
    }
}
