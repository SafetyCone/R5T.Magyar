using System;
using System.Collections.Generic;
using System.Linq;


namespace R5T.Magyar
{
    public static class EnumerableHelper
    {
        public static IEnumerable<T> From<T>(T value)
        {
            yield return value;
        }

        public static IEnumerable<T> From<T>(params T[] values)
        {
            return values;
        }
    }
}
