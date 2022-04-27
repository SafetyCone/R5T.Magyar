using System;
using System.Collections.Generic;


namespace System
{
    public static class IReadOnlyListExtensions
    {
        public static int LastIndex_ForReadOnlyList<T>(this IReadOnlyList<T> readOnlyList)
        {
            var output = readOnlyList.Count - 1;
            return output;
        }
    }
}
