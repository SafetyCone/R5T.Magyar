using System;
using System.Collections.Generic;


// Extensions for which referencing the Magyar library and using the Magyar namespace is sufficient to indicate desire for use.
namespace R5T.Magyar
{
    public static class DictionaryExtensions
    {
        public static Dictionary<TKey, TValue> Add<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, KeyValuePair<TKey, TValue> pair)
        {
            dictionary.Add(pair.Key, pair.Value);

            return dictionary;
        }

        public static Dictionary<TKey, TValue> AddRange<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, Dictionary<TKey, TValue> other)
        {
            foreach (var pair in other)
            {
                dictionary.Add(pair.Key, pair.Value);
            }

            return dictionary;
        }

        public static Dictionary<TValue, TKey> Invert<TKey, TValue>(this Dictionary<TKey, TValue> dictionary,
            DuplicateValueHandling duplicateValueHandling = DuplicateValueHandling.Error)
        {
            var output = new Dictionary<TValue, TKey>();

            foreach (var pair in dictionary)
            {
                var key = pair.Value;
                var value = pair.Key;

                if (output.ContainsKey(key))
                {
                    var existing = output[key];
                    var chosen = duplicateValueHandling.Choose(existing, value);

                    output[key] = chosen;
                }
                else
                {
                    output.Add(key, value);
                }
            }

            return output;
        }
    }
}

// Extensions for which referencing the Magyar library, using the Magyar namespace, and appending the extensions namespace name token is sufficient to indicate desire for use.
namespace R5T.Magyar.Extensions
{
    public static class DictionaryExtensions
    {
        public static Dictionary<TKey, TValue> ShallowClone<TKey, TValue>(this Dictionary<TKey, TValue> dictionary)
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
