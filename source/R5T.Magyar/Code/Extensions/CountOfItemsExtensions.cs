using System;
using System.Collections.Generic;
using System.Linq;


namespace R5T.Magyar
{
    public static class CountOfItemsExtensions
    {
        public static bool AnyDuplicates<T>(this CountOfItems<T> count)
        {
            var anyDuplicates = count.GetDuplicateKeyValuePairs().Any();
            return anyDuplicates;
        }    

        public static bool AllAreUnique<T>(this CountOfItems<T> count)
        {
            var output = !count.AnyDuplicates();
            return output;
        }

        public static IEnumerable<KeyValuePair<T, int>> GetDuplicateKeyValuePairs<T>(this CountOfItems<T> count)
        {
            var output = count.CountByItem.Where(x => x.Value > 1);
            return output;
        }

        public static IEnumerable<ItemCount<T>> GetDuplicates<T>(this CountOfItems<T> count)
        {
            var output = count.GetDuplicateKeyValuePairs()
                .Select(x => ItemCount<T>.From(x));

            return output;
        }

        public static ItemCount<T>[] GetDuplicatesNow<T>(this CountOfItems<T> count)
        {
            var output = count.GetDuplicates().Now_OLD();
            return output;
        }
    }
}
