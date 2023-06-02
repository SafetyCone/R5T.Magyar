using System;

using R5T.Magyar;
using R5T.Magyar.T003;


namespace System
{
    public static class IWordExtensions
    {
        [Obsolete("See R5T.Z0047.IWords.No")]
        public static string No(this IWord _)
        {
            return Words.No;
        }

        [Obsolete("See R5T.Z0047.IWords.Null")]
        public static string Null(this IWord _)
        {
            return Words.Null;
        }

        [Obsolete("See R5T.Z0047.IWords.Unspecified")]
        public static string Unspecified(this IWord _)
        {
            return Words.Unspecified;
        }

        [Obsolete("See R5T.Z0047.IWords.Yes")]
        public static string Yes(this IWord _)
        {
            return Words.Yes;
        }
    }
}