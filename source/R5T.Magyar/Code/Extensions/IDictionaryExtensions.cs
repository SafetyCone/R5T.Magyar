using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

using R5T.Magyar;


namespace R5T.Magyar
{
    public static class IDictionaryExtensions
    {
        public static IEnumerable<KeyValuePair<object, object>> AsObjectKeyValuePairEnumerable(this IDictionary dictionary)
        {
            var dictionaryEnumerator = dictionary.GetEnumerator();
            while(dictionaryEnumerator.MoveNext())
            {
                yield return new KeyValuePair<object, object>(dictionaryEnumerator.Key, dictionaryEnumerator.Value);
            }
        }

        public static Dictionary<TKey, TValue> ToDictionary<TKey, TValue>(this IDictionary dictionary,
            Func<object, TKey> keyConverter,
            Func<object, TValue> valueConverter)
        {
            var pairs = dictionary.AsObjectKeyValuePairEnumerable();

            var output = pairs.ToDictionary(
                pair => keyConverter(pair.Key),
                pair => valueConverter(pair.Value));
            
            return output;
        }

        public static DictionaryWrapper<TKey, TValue> Wrap<TKey, TValue>(this IDictionary<TKey, TValue> dictionary)
        {
            var wrapper = DictionaryWrapper.From(dictionary);
            return wrapper;
        }

        public static async Task<TDictionary> WrapAs<TKey, TValue, TDictionary>(this Task<IDictionary<TKey, TValue>> gettingDictionary)
            where TDictionary: class, IDictionary<TKey, TValue>
        {
            var dictionary = await gettingDictionary;

            var wrapper = DictionaryWrapper.From(dictionary);
            return wrapper as TDictionary;
        }
    }
}


namespace System.Collections.Generic
{
    public static class IDictionaryExtensions
    {
        /// <summary>
        /// Because the input <see cref="IDictionary{TKey, TValue}"/> is not an <see cref="IDistinctValuedDictionary{TKey, TValue}"/>, duplicate value handling must be specified.
        /// </summary>
        public static Dictionary<TValue, TKey> Invert<TKey, TValue>(this IDictionary<TKey, TValue> dictionary,
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

        public static IDistinctValuedDictionary<TKey, TValue> AsDistinctValued<TKey, TValue>(this IDictionary<TKey, TValue> dictionary)
        {
            return dictionary.Wrap();
        }

        public static async Task<IDistinctValuedDictionary<TKey, TValue>> AsDistinctValued<TKey, TValue>(this Task<IDictionary<TKey, TValue>> gettingDictionary)
        {
            var dictionary = await gettingDictionary;

            return dictionary.Wrap();
        }

        public static IDistinctValuedDictionary<TKey, TValue> ToDistinctValued<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, IEqualityComparer<TValue> valueEqualityComparer)
        {
            // Verify that the values are distinct (exception will be thrown if not).
            dictionary.Values.VerifyDistinct(valueEqualityComparer);

            // Input passes, so just wrap it.
            return dictionary.Wrap();
        }
    }
}


namespace System
{
    public static class IDictionaryExtensions
    {
        public static TValue AddAndReturnValue<TKey, TValue>(this IDictionary<TKey, TValue> dictionary,
            TKey key,
            TValue value)
        {
            dictionary.Add(key, value);

            return value;
        }

        public static void AddUniqueValueByKey<TKey, TValue>(this IDictionary<TKey, HashSet<TValue>> uniqueValuesByKey,
            TKey key,
            TValue value)
        {
            var uniqueValues = uniqueValuesByKey.ContainsKey(key)
                ? uniqueValuesByKey[key]
                : uniqueValuesByKey.AddAndReturnValue(key, new HashSet<TValue>())
                ;

            uniqueValues.Add(value);
        }
    }
}
