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
        public static string Comma => ",";
        public static string CommaSeparatedListSpacedSeparator => ", ";
        public static string Dash => "-";
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
        public static string PairedParentheses => "()";
        public const string Percent = "%";
        public const string Period = ".";
        public const string QuestionMark = "?";
        public const string S_LowerCase = "s";
        public const string Space = " ";
        public const string Slash = "/";
        public const string Tab = "\t";
        public const string Underscore = "_";


        public static string NewLineForEnvironment => Environment.NewLine;
    }
}
