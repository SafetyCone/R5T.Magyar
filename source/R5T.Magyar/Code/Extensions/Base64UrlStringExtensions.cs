using System;


namespace R5T.Magyar.Base64Url
{
    public static class Base64UrlStringExtensions
    {
        public static string ReplacePlusWithMinus(this string base64String)
        {
            var output = base64String.Replace(Characters.Plus, Characters.Minus);
            return output;
        }

        public static string ReplaceSlashWithUnderScore(this string base64String)
        {
            var output = base64String.Replace(Characters.Slash, Characters.Underscore);
            return output;
        }

        public static string PerformBase64ToBase64UrlCharacterReplacements(this string base64String)
        {
            var output = base64String
                .ReplacePlusWithMinus()
                .ReplaceSlashWithUnderScore()
                ;

            return output;
        }

        public static string ReplaceMinusWithPlus(this string base64UrlString)
        {
            var output = base64UrlString.Replace(Characters.Minus, Characters.Plus);
            return output;
        }

        public static string ReplaceUnderscoreWithSlash(this string base64UrlString)
        {
            var output = base64UrlString.Replace(Characters.Underscore, Characters.Slash);
            return output;
        }

        public static string PerformBase64UrlToBase64CharacterReplacements(this string base64UrlString)
        {
            var output = base64UrlString
                .ReplaceMinusWithPlus()
                .ReplaceUnderscoreWithSlash()
                ;

            return output;
        }

        public static string TrimEndOfTrailingEquals(this string base64UrlString, PaddingPolicy paddingPolicy = PaddingPolicy.Discard)
        {
            var output = paddingPolicy == PaddingPolicy.Discard
                ? base64UrlString.TrimEnd(Characters.Equals)
                : base64UrlString;
            
            return output;
        }

        public static string PadEndWithTrailingEquals(this string base64String)
        {
            // This is super weird, but correct, and has to do with the difference between 6 bits and a byte (which is 8 bits).
            // See: https://en.wikipedia.org/wiki/Base64#Examples
            switch (base64String.Length % 4)
            {
                case 2:
                    base64String += Strings.DoubleEquals;
                    break;
                case 3:
                    base64String += Characters.Equals;
                    break;
            }

            return base64String;
        }
    }
}
