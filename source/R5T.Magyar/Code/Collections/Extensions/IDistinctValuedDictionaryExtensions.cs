using System;


namespace System.Collections.Generic
{
    public static class IDistinctValuedDictionaryExtensions
    {
        public static IDistinctValuedDictionary<TValue, TKey> Invert<TKey, TValue>(this IDistinctValuedDictionary<TKey, TValue> dictionary)
        {
            var invertedDictionary = new Dictionary<TValue, TKey>().AsDistinctValued();

            dictionary.ForEach(pair => invertedDictionary.Add(pair.Value, pair.Key));

            return invertedDictionary;
        }
    }
}
