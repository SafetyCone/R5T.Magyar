using System;


namespace R5T.Magyar
{
    public static class UrlTokenSeparators
    {
        /// <summary>
        /// Example: The hash mark in "google.com/results#First".
        /// </summary>
        public const string Fragment = Strings.Hash;
        /// <summary>
        /// Example: The slash in "...google.com/results".
        /// </summary>
        public const string Path = Strings.Slash;
        /// <summary>
        /// Example: The colon in "localhost:5001".
        /// </summary>
        public const string Port = Strings.Colon;
        /// <summary>
        /// Example: The question mark in "google.com?q=stuff".
        /// </summary>
        public const string Query = Strings.QuestionMark;
        /// <summary>
        /// Example: The ampersand in "google.com/q=stuff&amp;results=true".
        /// </summary>
        public const string QueryParameter = Strings.Ampersand;
        /// <summary>
        /// Example: The double-slash in "http://google.com".
        /// </summary>
        public const string Root = Strings.DoubleSlash;
        /// <summary>
        /// Example: The colon in "https://...".
        /// </summary>
        public const string Scheme = Strings.Colon;
        /// <summary>
        /// Example: The colon in "http://user:pass@www.mysite.com".
        /// </summary>
        public const string UserDetails = Strings.Colon;
        /// <summary>
        /// Example: The at symbol in "http://user:pass@www.mysite.com".
        /// </summary>
        public const string UserInfo = Strings.At;
    }
}
