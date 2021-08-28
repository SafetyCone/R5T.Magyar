using System;
using System.Collections.Generic;
using System.Text;

using R5T.Magyar;
using R5T.Magyar.Base64Url;
using R5T.Magyar.Extensions;


namespace System
{
    public static class StringHelper
    {
        public const string Empty = "";
        public const string Space = " ";
        public const string Invalid = null;

        /// <summary>
        /// The return value of the <see cref="String.IndexOf(string)"/> method when the search string is not found.
        /// </summary>
        public const int IndexOfNotFound = -1;


        public static bool BeginsWith(
            string @string,
            string beginning)
        {
            var stringIsTooShort = @string.Length < beginning.Length;
            if (stringIsTooShort)
            {
                return false;
            }

            var output = @string.Substring(0, beginning.Length) == beginning;
            return output;
        }

        public static string Enquote(string value)
        {
            var output = $"\"{value}\"";
            return output;
        }

        /// <summary>
        /// Useful for testing the return value of the <see cref="String.IndexOf(string)"/> method to see if the search string was found.
        /// </summary>
        public static bool IsFound(int index)
        {
            var isFound = index != StringHelper.IndexOfNotFound;
            return isFound;
        }

        /// <summary>
        /// <paramref name="rhs"/> is less than <paramref name="lhs"/>.
        /// </summary>
        public static bool IsGreaterThan(string lhs, string rhs)
        {
            var output = lhs.CompareTo(rhs) > 0;
            return output;
        }

        /// <summary>
        /// <paramref name="lhs"/> is less than <paramref name="rhs"/>.
        /// </summary>
        public static bool IsLessThan(string lhs, string rhs)
        {
            var output = lhs.CompareTo(rhs) < 0;
            return output;
        }

        public static bool IsValid(string value)
        {
            var output = value != StringHelper.Invalid;
            return output;
        }

        public static string Join(string separator, params string[] values)
        {
            var output = String.Join(separator, values);
            return output;
        }

        public static string Join(string separator, IEnumerable<string> values)
        {
            var output = String.Join(separator, values);
            return output;
        }

        public static string NullIfNull(string value)
        {
            var isNull = value is null;

            var output = isNull
                ? $"<{Words.Null}>"
                : value;

            return output;
        }

        public static string Repeat(string value, int numberOfTimes)
        {
            var output = value.Repeat(numberOfTimes);
            return output;
        }

        public static string[] Split(string separator, string value)
        {
            var output = value.Split(separator);
            return output;
        }

        #region Encode/Decode Base64

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Source: https://jasonwatmore.com/post/2020/09/12/c-encode-and-decode-base64-strings
        /// </remarks>
        public static string EncodeBase64(string @string)
        {
            var valueBytes = Encoding.UTF8.GetBytes(@string);

            var output = Convert.ToBase64String(valueBytes);
            return output;
        }

        public static string DecodeBase64(string @string)
        {
            var valueBytes = Convert.FromBase64String(@string);

            var output = Encoding.UTF8.GetString(valueBytes);
            return output;
        }

        #endregion

        #region Encode/Decode Base64Url (for example, this is what Gmail actually uses)

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Source: https://github.com/neosmart/UrlBase64/blob/master/UrlBase64/UrlBase64.cs
        /// </remarks>
        public static string EncodeBase64Url(string @string, PaddingPolicy paddingPolicy = PaddingPolicy.Discard)
        {
            var valueBytes = Encoding.UTF8.GetBytes(@string);

            var base64String = Convert.ToBase64String(valueBytes);

            var base64UrlString = base64String.PerformBase64ToBase64UrlCharacterReplacements();

            base64UrlString = base64UrlString.TrimEndOfTrailingEquals(paddingPolicy);

            return base64UrlString;
        }

        public static string DecodeBase64Url(string @string)
        {
            var base64String = @string.PerformBase64UrlToBase64CharacterReplacements();

            base64String = base64String.PadEndWithTrailingEquals();

            var valueBytes = Convert.FromBase64String(base64String);

            return Encoding.UTF8.GetString(valueBytes);
        }

        #endregion

        public static string FormatAsTwoDigits(int value)
        {
            var output = $"{value:00}";
            return output;
        }

        /// <summary>
        /// Determines if the input is specifically the <see cref="Strings.Empty"/> string.
        /// </summary>
        public static bool IsEmpty(string value)
        {
            var isEmpty = value == Strings.Empty;
            return isEmpty;
        }

        /// <summary>
        /// Determines if the input is specifically *not* the <see cref="Strings.Empty"/> string.
        /// </summary>
        public static bool IsNotEmpty(string value)
        {
            var isEmpty = !StringHelper.IsEmpty(value);
            return isEmpty;
        }

        /// <summary>
        /// Determines if the input is specifically the <see cref="Strings.Null"/> string.
        /// </summary>
        public static bool IsNull(string value)
        {
            var isEmpty = value == Strings.Null;
            return isEmpty;
        }

        /// <summary>
        /// Determines if the input is specifically *not* the <see cref="Strings.Null"/> string.
        /// </summary>
        public static bool IsNotNull(string value)
        {
            var isEmpty = !StringHelper.IsNull(value);
            return isEmpty;
        }

        public static bool IsNotNullOrEmpty(string value)
        {
            var output = !String.IsNullOrEmpty(value);
            return output;
        }
    }
}
