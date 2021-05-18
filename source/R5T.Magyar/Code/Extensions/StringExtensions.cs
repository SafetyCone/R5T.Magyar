using System;
using System.Linq;


namespace System
{
    public static class StringExtensions
    {
        public static bool IsNonNullOrEmpty(this string @string)
        {
            var output = !@String.IsNullOrEmpty(@string);
            return output;
        }
    }
}


namespace R5T.Magyar.Extensions
{
    public static class StringExtensions
    {
        public static string Prefix(this string @string, char prefix)
        {
            var prefixedString = $"{prefix}{@string}";
            return prefixedString;
        }

        public static string Prefix(this string @string, string prefix)
        {
            var prefixedString = $"{prefix}{@string}";
            return prefixedString;
        }

        public static string Suffix(this string @string, char suffix)
        {
            var prefixedString = $"{@string}{suffix}";
            return prefixedString;
        }

        public static string Suffix(this string @string, string suffix)
        {
            var prefixedString = $"{@string}{suffix}";
            return prefixedString;
        }

        /// <summary>
        /// Returns the input string, except without the first specified number of characters (a positive integer).
        /// </summary>
        public static string ExceptFirst(this string @string, int numberOfCharacters)
        {
            var output = @string.Substring(numberOfCharacters);
            return output;
        }

        /// <summary>
        /// Returns the input string, except without the first character.
        /// </summary>
        public static string ExceptFirst(this string @string)
        {
            var output = @string.ExceptFirst(1);
            return output;
        }

        /// <summary>
        /// Returns the input string, except without the last specified number of characters (a positive integer).
        /// </summary>
        public static string ExceptLast(this string @string, int numberOfCharacters)
        {
            var output = @string.Substring(0, @string.Length - numberOfCharacters);
            return output;
        }

        /// <summary>
        /// Returns the input string, except without the last character.
        /// </summary>
        public static string ExceptLast(this string @string)
        {
            var output = @string.ExceptLast(1);
            return output;
        }

        /// <summary>
        /// Removes a number of characters equal to the length of the suffix from the input <paramref name="string"/>.
        /// </summary>
        public static string ExceptLast(this string @string, string suffix)
        {
            var suffixLength = suffix.Length;

            var output = @string.ExceptLast(suffixLength);
            return output;
        }

        /// <summary>
        /// Gets the last number of characters in a string.
        /// </summary>
        public static string Last(this string @string, int numberOfCharacters)
        {
            var last = @string.Substring(@string.Length - numberOfCharacters);
            return last;
        }

        /// <summary>
        /// Gets the last character in a string as a string.
        /// </summary>
        public static string LastString(this string @string)
        {
            var last = @string.Last(1);
            return last;
        }

        public static char LastChar(this string @string)
        {
            var last = @string.LastString();

            var lastChar = last[0];
            return lastChar;
        }

        // See: https://stackoverflow.com/questions/3754582/is-there-an-easy-way-to-return-a-string-repeated-x-number-of-times
        public static string Repeat(this string value, int numberOfTimes)
        {
            var output = String.Concat(Enumerable.Repeat(value, numberOfTimes));
            return output;
        }

        /// <summary>
        /// An ease-of-use overload that allows using a single string as the separator (instead of a full string array).
        /// Fixes the lack of a string.Split(params string[]) function.
        /// </summary>
        // Note: there is no char-equivalent because there is already a string.Split(params char[]) method.
        public static string[] Split(this string @string, string separator, StringSplitOptions stringSplitOptions = StringSplitOptions.None)
        {
            var output = @string.Split(new string[] { separator }, stringSplitOptions);
            return output;
        }

        public static string EncodeToBase64(this string @string)
        {
            var output = StringHelper.EncodeBase64(@string);
            return output;
        }

        public static string DecodeFromBase64(this string @string)
        {
            var output = StringHelper.DecodeBase64(@string);
            return output;
        }

        public static string EncodeToBase64Url(this string @string)
        {
            var output = StringHelper.EncodeBase64Url(@string);
            return output;
        }

        public static string DecodeFromBase64Url(this string @string)
        {
            var output = StringHelper.DecodeBase64Url(@string);
            return output;
        }
    }
}