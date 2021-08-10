using System;


// Placed in System namespace since including a reference to Magyar is enough to indicate a desire to use this functionality.
namespace System
{
    public static class Strings
    {
        public const string Ampersand = "&";
        public const string Asterix = "*";
        public const string At = "@";
        public const string Backslash = @"\";
        public const string CloseBrace = "}";
        public const string CloseBracket = "]";
        public const string CloseParenthesis = ")";
        public const string Colon = ":";
        public const string DoubleDot = "..";
        public const string DoubleEquals = "==";
        public const string DoubleSlash = "//";
        public const string DoubleSpaces = "  ";
        public const string Ellipsis = "...";
        public const string Empty = ""; // Constant, as opposed to String.Empty, which is static readonly. Constants can be used as default parameter values.
        public const string GreaterThan = ">";
        public const string Hash = "#";
        public const string LessThan = "<"; // No other than for it: https://english.stackexchange.com/questions/255262/what-is-the-name-of-the-symbols-and
        public const string Null = null;
        public const string NewLineForWindows = "\r\n";
        public const string NewLineForNonWindows = "\n";
        public const string OpenBrace = "{";
        public const string OpenBracket = "[";
        public const string OpenParenthesis = "(";
        public const string Percent = "%";
        public const string Period = ".";
        public const string QuestionMark = "?";
        public const string S_LowerCase = "s";
        public const string Space = " ";
        public const string Slash = "/";
        public const string Tab = "\t";
        public const string Underscore = "_";


        public static string NewLineForEnvironment => Environment.NewLine;


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
            var isEmpty = !Strings.IsEmpty(value);
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
            var isEmpty = !Strings.IsNull(value);
            return isEmpty;
        }
    }
}
