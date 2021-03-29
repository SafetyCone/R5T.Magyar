using System;
using System.Collections.Generic;


namespace R5T.Magyar.Extensions
{
    public static class ObjectExtensions
    {
        public static T[] ToArray<T>(this T item)
        {
            var output = new T[] { item };
            return output;
        }

        public static IEnumerable<T> ToEnumerable<T>(this T item)
        {
            yield return item;
        }
    }
}
