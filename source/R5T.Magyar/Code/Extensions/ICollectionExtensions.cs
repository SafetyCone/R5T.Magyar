using System;
using System.Collections.Generic;


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
