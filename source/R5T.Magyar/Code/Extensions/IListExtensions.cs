using System;
using System.Collections.Generic;


namespace R5T.Magyar.Extensions
{
    public static class IListExtensions
    {
        public static void RemoveAll<T>(this IList<T> list, IEnumerable<T> enumerable)
        {
            foreach (var item in enumerable)
            {
                list.Remove(item);
            }
        }
    }
}
