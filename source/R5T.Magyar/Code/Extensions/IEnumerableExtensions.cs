using System;
using System.Collections.Generic;
using System.Linq;


namespace R5T.Magyar.Extensions
{
    public static class IEnumerableExtensions
    {
        public static T NthToLast<T>(this IEnumerable<T> enumerable, int nth)
        {
            var array = enumerable.ToArray();

            var secondToLast = array[array.Length - nth];
            return secondToLast;
        }

        public static T SecondToLast<T>(this IEnumerable<T> enumerable)
        {
            var output = enumerable.NthToLast(2);
            return output;
        }

        public static IEnumerable<T> ExceptLast<T>(this IEnumerable<T> enumerable)
        {
            var output = enumerable.ExceptLast(1);
            return output;
        }

        public static IEnumerable<T> ExceptLast<T>(this IEnumerable<T> enumerable, int nElements)
        {
            var count = enumerable.Count();

            var enumerator = enumerable.GetEnumerator();
            for (int iElement = nElements; iElement < count; iElement++) // For each except the last N.
            {
                enumerator.MoveNext();

                yield return enumerator.Current;
            }
        }
    }

    public static class IEnumerableStringExtensions
    {
        public static IEnumerable<string> SortAlphabetically(this IEnumerable<string> strings)
        {
            var output = strings.OrderBy(x => x);
            return output;
        }
    }
}
