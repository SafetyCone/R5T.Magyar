using System;
using System.Collections.Generic;


namespace System
{
    public static class ArrayExtensions
    {
        public static T[] EmptyIfDefault<T>(this T[] array)
        {
            var arrayIsDefault = array == default;

            var output = arrayIsDefault
                ? Array.Empty<T>()
                : array
                ;

            return output;
        }
    }
}

namespace System.Linq
{
    public static class ArrayExtensions
    {
        public static T[] Append<T>(this T[] array, T item)
        {
            var output = (array as IEnumerable<T>).Append(item).ToArray();
            return output;
        }
    }
}


namespace R5T.Magyar.Extensions
{
    public static class ArrayExtensions
    {
        public static T[] Copy<T>(this T[] array)
        {
            var output = ArrayHelper.Copy(array);
            return output;
        }

        public static T[] Copy<T>(this T[] array, int end)
        {
            var output = ArrayHelper.Copy(array, end);
            return output;
        }

        public static T[] Copy<T>(this T[] array, int start, int end)
        {
            var output = ArrayHelper.Copy(array, start, end);
            return output;
        }
    }
}
