using System;
using System.Collections.Generic;


namespace System
{
    public static class IListExtensions
    {
        public static int LastIndex<T>(this IList<T> list)
        {
            var output = list.Count - 1;
            return output;
        }

        public static int LastIndexForInsertion<T>(this IList<T> list)
        {
            var lastIndex = list.LastIndex();

            if(IndexHelper.IsNotFound(lastIndex))
            {
                return IndexHelper.FirstInsertionIndex;
            }
            else
            {
                return lastIndex;
            }
        }
    }
}

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
        /// Returns the elements of <paramref name="elements"/> that occur after the common initial elements specified by <paramref name="otherElements"/>.
        /// If <paramref name="elements"/> does not start with the elements of <paramref name="otherElements"/>, an exception is thrown.
        /// </summary>
        public static IEnumerable<T> GetTrailingAppendix<T>(this IList<T> elements,
            IList<T> otherElements)
        {
            var equalityComparer = EqualityComparer<T>.Default;

            var otherElementsLength = otherElements.Count;

            var beginningSequenceEquals = elements.Take(otherElementsLength).SequenceEqual(otherElements, equalityComparer);
            if (!beginningSequenceEquals)
            {
                throw new Exception("The beginning of the elements sequence did not match the other elements sequence. The elements sequence must begin with the same elements as the other sequence.");
            }

            var output = elements.Skip(otherElementsLength);
            return output;
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
