using System;

using R5T.Magyar;
using R5T.Magyar.T003;


namespace System
{
    public static class IWordExtensions
    {
        public static string No(this IWord _)
        {
            return Words.No;
        }

        public static string Null(this IWord _)
        {
            return Words.Null;
        }

        public static string Unspecified(this IWord _)
        {
            return Words.Unspecified;
        }

        public static string Yes(this IWord _)
        {
            return Words.Yes;
        }
    }
}