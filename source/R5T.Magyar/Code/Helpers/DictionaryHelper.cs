using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using R5T.Magyar.IO;


namespace R5T.Magyar
{
    public static class DictionaryHelper
    {
        public static IDictionary<TKey, TValue> From<TKey, TValue>(TKey key, TValue value)
        {
            var output = new Dictionary<TKey, TValue>
            {
                { key, value }
            };

            return output;
        }

        public static Dictionary<string, List<string>> FromFile_StringsByString(string filePath)
        {
            var output = new Dictionary<string, List<string>>();

            output.FillFromFile(filePath);

            return output;
        }

        public static string GetDefaultKeyNotFoundExceptionMessage(string key)
        {
            var message = $"Key not found: '{key}'";
            return message;
        }

        public static KeyNotFoundException GetDefaultKeyNotFoundException(string key)
        {
            var message = DictionaryHelper.GetDefaultKeyNotFoundExceptionMessage(key);

            var exception = new KeyNotFoundException(message);
            return exception;
        }

        public static Task ProcessSingular<TKey, TValue>(Func<IDictionary<TKey, TValue>, Task> processor, TKey key, TValue value)
        {
            var dictionary = DictionaryHelper.From(key, value);

            return processor(dictionary);
        }

        public static Task ProcessSingular<TKey, TValue>(Func<IDistinctValuedDictionary<TKey, TValue>, Task> processor, TKey key, TValue value)
        {
            var dictionary = DictionaryHelper.From(key, value).AsDistinctValued();

            return processor(dictionary);
        }

        public static async Task<IEnumerable<TOut>> Process<TIn, TOut>(
            Func<IDistinctValuedDictionary<TIn, TIn>, Task<IDictionary<TIn, TOut>>> processor,
            IDistinctEnumerable<TIn> inputs)
        {
            var inputsByInput = inputs.ToDictionarySameKeyAndValue().AsDistinctValued();

            var resultsByInput = await processor(inputsByInput);
            return resultsByInput.Values;
        }

        // Aync, awaits each iteration.
        public static async Task<IDictionary<TKey, TOut>> ProcessByKey<TKey, TIn, TOut>(
            Func<TIn, Task<TOut>> processor,
            IDistinctValuedDictionary<TKey, TIn> inputsByKey)
        {
            var output = new Dictionary<TKey, TOut>();
            foreach (var pair in inputsByKey)
            {
                var result = await processor(pair.Value);

                output.Add(pair.Key, result);
            }

            return output;
        }

        // Sync.
        public static IDictionary<TKey, TOut> ProcessByKey<TKey, TIn, TOut>(
            Func<TIn, TOut> processor,
            IDistinctValuedDictionary<TKey, TIn> inputsByKey)
        {
            var output = new Dictionary<TKey, TOut>();
            foreach (var pair in inputsByKey)
            {
                var result = processor(pair.Value);

                output.Add(pair.Key, result);
            }

            return output;
        }
    }
}
