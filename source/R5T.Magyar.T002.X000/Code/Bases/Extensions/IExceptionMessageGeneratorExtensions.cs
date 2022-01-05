using System;

using R5T.Magyar.T002;


namespace System
{
    public static class IExceptionMessageGeneratorExtensions
    {
        public static string PathWasNullOrEmpty(this IExceptionMessageGenerator _)
        {
            var output = "Path was null or empty.";
            return output;
        }
    }
}