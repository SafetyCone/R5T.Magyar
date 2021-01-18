using System;
using System.Collections.Generic;


namespace R5T.Magyar
{
    public static class ListExtensions
    {
        public static bool IsEmpty<T>(this List<T> list)
        {
            var isEmpty = list.Count < 1; // Assumes less-than is faster than equals.
            return isEmpty;
        }
    }
}
