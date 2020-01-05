using System;
using System.Collections.Generic;


namespace R5T.Magyar.Extensions
{
    public static class DictionaryExtensions
    {
        public static Dictionary<TKey, TValue> Copy<TKey, TValue>(this Dictionary<TKey, TValue> dictionary)
        {
            var output = new Dictionary<TKey, TValue>();

            dictionary.ForEach(keyValuePair =>
            {
                output.Add(keyValuePair.Key, keyValuePair.Value);
            });

            return output;
        }
    }
}
