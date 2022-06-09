using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;


namespace System
{
    using R5T.Magyar;


    public static class DictionaryExtensions
    {
        public static WasFound<TValue> HasValue<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key)
        {
            var containsKey = dictionary.ContainsKey(key);

            var value = containsKey
                ? dictionary[key]
                : default
                ;

            var output = WasFound.From(containsKey, value);
            return output;
        }
    }
}


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

        public static void DescribeTo<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, StringBuilder stringBuilder)
        {
            foreach (var pair in dictionary)
            {
                stringBuilder.AppendLine($"{pair.Key}: {pair.Value}");
            }
        }

        public static Task DescribeTo<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TextWriter textWriter)
        {
            var stringBuilder = new StringBuilder();

            dictionary.DescribeTo(stringBuilder);

            var description = stringBuilder.ToString();

            return textWriter.WriteAsync(description);
        }
    }
}

// Extensions for which referencing the Magyar library, using the Magyar namespace, and appending the extensions namespace name token is sufficient to indicate desire for use.
namespace R5T.Magyar.Extensions
{
    using System.Linq;


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
