using System;
using System.Collections.Generic;


namespace System
{
    using N8;


    public static class HashSetExtensions
    {
        /// <summary>
        /// Chooses <see cref="AddRangeKeepLast{T}(HashSet{T}, IEnumerable{T})"/> as the default behavior (which it is for <see cref="HashSet{T}"/>).
        /// </summary>
        public static HashSet<T> AddRange<T>(this HashSet<T> hashSet, IEnumerable<T> items)
        {
            return hashSet.AddRangeKeepLast(items);
        }

        /// <summary>
        /// If the hash set already contains the item, replace it with any later items.
        /// This is the default behavior for <see cref="HashSet{T}"/>.
        /// </summary>
        public static HashSet<T> AddRangeKeepLast<T>(this HashSet<T> hashSet, IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                hashSet.Add(item);
            }

            return hashSet;
        }

        /// <summary>
        /// If the hash set already contains the item, do not replace it with any later items.
        /// </summary>
        public static HashSet<T> AddRangeKeepFirst<T>(this HashSet<T> hashSet, IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                var containsItem = hashSet.Contains(item);

                // Only add the item if the hash set does not already have the item.
                if(!containsItem)
                {
                    hashSet.Add(item);
                }
            }

            return hashSet;
        }

        public static void AddRangeThrowIfDuplicate<T>(this HashSet<T> hashSet, IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                var alreadyPresent = hashSet.Contains(item);
                if(alreadyPresent)
                {
                    throw hashSet.GetValueAlreadyExistsException();
                }
            }
        }

        // Exists in a new version of .NET Core: https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.hashset-1.trygetvalue?redirectedfrom=MSDN&view=net-6.0#System_Collections_Generic_HashSet_1_TryGetValue__0__0__
        ///// <summary>
        ///// For use with hash sets of a type where the same identity might not correspond to the same object instance (or with hash sets using a custom equality comparer).
        ///// Thus a test item can be used to determine whether an item with the identity of the test item exists in the hash set, but the hash set's instance of the identity is the one of interest.
        ///// </summary>
        //public static bool Contains<T>(this HashSet<T> hashSet, T testItem, out T hashItem)
        //{
        //    var output = hashSet.Contains(testItem);

        //    hashItem = hashSet.tryget
        //}
    }
}


namespace N8
{
    public static class HashSetExtensions
    {
        public static Exception GetValueAlreadyExistsException<T>(this HashSet<T> _)
        {
            var output = new Exception("Value already exists. Attempted to add duplicate value.");
            return output;
        }
    }
}
