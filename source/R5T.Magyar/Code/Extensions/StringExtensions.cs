using System;


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
    }
}