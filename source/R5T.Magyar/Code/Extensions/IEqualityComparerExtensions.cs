using System;
using System.Collections.Generic;


namespace System
{
    public static class IEqualityComparerExtensions
    {
        public static bool NotEquals<T>(this IEqualityComparer<T> equalityComparer,
            T x, T y)
        {
            var isEqual = equalityComparer.Equals(x, y);

            var output = !isEqual;
            return output;
        }
    }
}
