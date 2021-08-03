using System;
using System.Collections.Generic;
using System.Linq;


namespace R5T.Magyar.Extensions
{
    public static class ICollectionExtensions
    {
        /// <summary>
        /// Different than <see cref="ICollection{T}.Clear"/>, this allows use of an <see cref="IEnumerable{T}"/> to specific items to remove.
        /// </summary>
        public static void RemoveRange<T>(this ICollection<T> collection, IEnumerable<T> enumerable)
        {
            foreach (var item in enumerable)
            {
                collection.Remove(item);
            }
        }
    }
}

namespace System.Linq
{
    public static class ICollectionExtensions
    {
        public static bool AreUnique<T>(this ICollection<T> collection)
        {
            var elementCount = collection.Count;

            var uniqueElementCount = collection.Distinct().Count();

            var output = uniqueElementCount == elementCount;
            return output;
        }

        public static bool SameElements<T>(this ICollection<T> collection, ICollection<T> other)
        {
            var sameCount = collection.Count == other.Count;
            if(!sameCount)
            {
                return false;
            }

            // Now that we know the two collections have the same number of elements, if one collection except the other collection has no elements, then they have the same elements.
            var anyElementsRemaining = collection.Except(other).Any();

            var output = !anyElementsRemaining;
            return output;
        }
    }
}
