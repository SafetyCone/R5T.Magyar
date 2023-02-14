using System;


namespace R5T.Magyar
{
    public static class Strings
    {
        public static string Ampersand => "&";
        public static string Asterix => "*";
        public static string At => "@";
        public static string Backslash => @"\";
        public static string CloseBrace => "}";
        public static string CloseBracket => "]";
        public static string CloseParenthesis => ")";
        public static string Colon => ":";
        public static string Comma => ",";
        public static string CommaSeparatedListSpacedSeparator => ", ";
        public static string Dash => "-";
        public static string DoubleDot => "..";
        public static string DoubleEquals => "==";
        public static string DoubleSlash => "//";
        public static string DoubleSpaces => "  ";
        public static string Ellipsis => "...";
        public static string Empty => "";
        public const string Empty_Const = ""; // Constant, as opposed to String.Empty, which is static readonly. Only constants can be used as default parameter values.
        public static string GreaterThan => ">";
        public static string Hash => "#";
        public static string LessThan => "<"; // No other name for it: https://english.stackexchange.com/questions/255262/what-is-the-name-of-the-symbols-and
        public const string Null = null;
        public static string NewLineForWindows => "\r\n";
        public static string NewLineForNonWindows => "\n";
        public static string OpenBrace => "{";
        public static string OpenBracket => "[";
        public static string OpenParenthesis => "(";
        public static string PairedParentheses => "()";
        public const string Percent_Constant = "%";
        public static string Percent => Strings.Percent_Constant;
        public static string Period => ".";
        public const string Period_Const = ".";
        public static string Pipe => "|";
        public static string PipeSpace => "| ";
        public static string QuestionMark => "?";
        public static string Space => " ";
        public const string Space_Const = " ";
        public static string Slash => "/";
        public static string Tab => "\t";
        public static string Tick => "`";
        public static string Underscore => "_";

#pragma warning disable IDE1006 // Naming Styles
        public static string I_UpperCase => "I";
        public static string S_LowerCase => "s";
#pragma warning restore IDE1006 // Naming Styles

        public static string NewLineForEnvironment => Environment.NewLine;
    }
}
