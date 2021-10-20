using System;
using System.Collections.Generic;


namespace System.Linq
{
    public static class IListExtensions
    {
        public static int GetIndexOfPriorAlphabeticalElement<T>(this IList<T> list, Func<T, string> keySelector, string key)
        {
            var priorAlphabeticalElementWasFound = list.GetPriorAlphabeticalElement(keySelector, key);
            
            if(priorAlphabeticalElementWasFound)
            {
                var index = list.IndexOf(priorAlphabeticalElementWasFound);
                return index;
            }
            else
            {
                return IndexHelper.Zero;
            }
        }

        /// <summary>
        /// Named with -List to allow resolution of ambiguous IList.VerifyDistinct() vs. IEnumerable.VerifyDistinct() when required.
        /// </summary>
        public static void VerifyDistinctList<T>(this IList<T> items, IEqualityComparer<T> equalityComparer)
        {
            var count = items.Count;

            var distinctCount = items.Distinct(equalityComparer).Count();

            if (count > distinctCount)
            {
                throw new Exception("List items were not distinct.");
            }
        }

        public static void VerifyDistinct<T>(this IList<T> items, IEqualityComparer<T> equalityComparer)
        {
            items.VerifyDistinctList(equalityComparer);
        }
    }
}
