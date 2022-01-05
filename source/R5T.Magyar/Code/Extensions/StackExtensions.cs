using System;
using System.Collections.Generic;

using R5T.Magyar;


namespace System
{
    public static class StackExtensions
    {
        public static bool IsNotEmpty<T>(this Stack<T> stack)
        {
            var output = stack.Count > 0;
            return output;
        }

        public static bool IsEmpty<T>(this Stack<T> stack)
        {
            var output = stack.Count < 1;
            return output;
        }

        public static WasFound<T> PopOkIfEmpty<T>(this Stack<T> stack)
        {
            var isNotEmpty = stack.IsNotEmpty();

            var value = isNotEmpty
                ? stack.Pop()
                : default
                ;

            var output = WasFound.From(isNotEmpty, value);
            return output;
        }
    }
}
