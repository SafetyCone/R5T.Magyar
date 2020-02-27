using System;
using System.Collections.Generic;


namespace R5T.Magyar
{
    public static class EnumerableHelper
    {
        public static IEnumerable<T> From<T>(T value)
        {
            yield return value;
        }
    }
}
