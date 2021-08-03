using System;

using R5T.Magyar;


namespace System
{
    public static class WordExtensions
    {
        public static string No(this IWord _)
        {
            return Words.No;
        }

        public static string Null(this IWord _)
        {
            return Words.Null;
        }

        public static string Yes(this IWord _)
        {
            return Words.Yes;
        }
    }
}