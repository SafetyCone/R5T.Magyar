using System;
using System.Collections.Generic;
using System.Linq;

using R5T.Magyar;


namespace System
{
    public static class StringExtensions
    {
        /// <summary>
        /// Returns the beginning, not including the character at the index (index of 1, i.e. the second character, would return the first character only).
        /// </summary>
        public static string BeginningByIndex(this string @string,
            int index)
        {
            var output = @string.Substring(0, index);
            return output;
        }

        /// <inheritdoc cref="BeginningByIndex(string, int)"/>
        public static string Beginning(this string @string,
            int index)
        {
            var output = @string.BeginningByIndex(index);
            return output;
        }

        public static bool BeginsWith(this string @string,
            string beginning)
        {
            var output = StringHelper.BeginsWith(@string, beginning);
            return output;
        }

        /// <summary>
        /// Provides the input string, but without its first character.
        /// </summary>
        public static string ExceptFirstCharacter(this string @string)
        {
            var output = @string.Substring(1);
            return output;
        }

        public static bool IsNullOrEmpty(this string @string)
        {
            var output = String.IsNullOrEmpty(@string);
            return output;
        }

        public static bool IsNonNullOrEmpty(this string @string)
        {
            var output = !String.IsNullOrEmpty(@string);
            return output;
        }

        /// <summary>
        /// The index of the end is one past the index of the last character.
        /// This is the same as the length of the string.
        /// </summary>
        public static int IndexOfEnd(this string @string)
        {
            var output = @string.Length;
            return output;
        }

        public static char Last(this string @string)
        {
            var output = @string[@string.Length - 1];
            return output;
        }

        public static int LastIndex(this string @string)
        {
            var output = @string.Length - 1;
            return output;
        }

        public static int NthLastIndexOfAny(this string @string,
            char[] anyOf,
            int nth)
        {
            if(nth < 1)
            {
                throw new ArgumentException($"Nth must be one or greater. Found: {nth}.");
            }

            var subString = @string;
            var lastIndexOfAny = StringHelper.IndexOfNotFound;

            for (int iPass = 0; iPass < nth; iPass++)
            {
                lastIndexOfAny = subString.LastIndexOfAny(anyOf);
                if(StringHelper.NotFound(lastIndexOfAny))
                {
                    return StringHelper.IndexOfNotFound; // Don't return the last index of any, return that there was no Nth.
                }

                subString = subString.BeginningByIndex(lastIndexOfAny);
            }

            return lastIndexOfAny;
        }
    }
}


namespace System.Linq
{
    public static class StringExtensions
    {
        public static IEnumerable<string> ExceptEmpty(this IEnumerable<string> items)
        {
            var output = items.Where(x => x != Strings.Empty);
            return output;
        }

        public static WasFound<string> FindSingleByValue(this IEnumerable<string> items, string value)
        {
            var itemOrDefault = items
                .Where(xItem => xItem == value)
                .SingleOrDefault();

            var output = WasFound.From(itemOrDefault);
            return output;
        }

        public static IEnumerable<string> GetDuplicatesInAlphabeticalOrder(this IEnumerable<string> strings)
        {
            var output = strings
                .WhereDuplicates(xString => xString)
                .Select(xGroup => xGroup.Key)
                .OrderAlphabetically()
                ;

            return output;
        }

        public static IEnumerable<string> OrderAlphabetically(this IEnumerable<string> items)
        {
            var output = items.OrderBy(x => x);
            return output;
        }

        public static IEnumerable<string> OrderAlphabetically_OnlyIfDebug(this IEnumerable<string> items)
        {
            var output = items
#if DEBUG
                .OrderAlphabetically()
#endif
                ;

            return output;
        }

        public static IEnumerable<string> Trim(this IEnumerable<string> strings)
        {
            var output = strings.Select(x => x.Trim());
            return output;
        }
    }
}


namespace R5T.Magyar
{
    public static class StringExtensions
    {
        /// <summary>
        /// Returns the string, without the ending.
        /// </summary>
        public static string ExceptEnding(this string @string,
            string ending)
        {
            var output = @string.Substring(0, @string.Length - ending.Length);
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

        public static IEnumerable<string> SortAlphabetically(this IEnumerable<string> strings)
        {
            var output = strings.OrderBy(x => x);
            return output;
        }

        public static string CommaSeparatorJoin(this IEnumerable<string> strings)
        {
            var separator = $"{Characters.Comma}{Characters.Space}";

            var joined = String.Join(separator, strings);
            return joined;
        }
    }
}