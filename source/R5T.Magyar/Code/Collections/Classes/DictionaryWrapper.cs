using System;
using System.Collections;
using System.Collections.Generic;


namespace R5T.Magyar
{
    public static class DictionaryWrapper
    {
        public static DictionaryWrapper<TKey, TValue> From<TKey, TValue>(IDictionary<TKey, TValue> dictionary)
        {
            var output = new DictionaryWrapper<TKey, TValue>(dictionary);
            return output;
        }
    }


    public class DictionaryWrapper<TKey, TValue> : IDistinctValuedDictionary<TKey, TValue>
    {
        private IDictionary<TKey, TValue> Dictionary { get; }


        public DictionaryWrapper(IDictionary<TKey, TValue> dictionary)
        {
            this.Dictionary = dictionary;
        }

        public TValue this[TKey key]
        {
            get
            {
                return this.Dictionary[key];
            }
            set
            {
                this.Dictionary[key] = value;
            }
        }

        public ICollection<TKey> Keys => this.Dictionary.Keys;
        public ICollection<TValue> Values => this.Dictionary.Values;
        public int Count => this.Dictionary.Count;
        public bool IsReadOnly => (this.Dictionary as IDictionary<TKey, TValue>).IsReadOnly;

        public void Add(TKey key, TValue value)
        {
            this.Dictionary.Add(key, value);
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            this.Add(item.Key, item.Value);
        }

        public void Clear()
        {
            this.Dictionary.Clear();
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            return (this.Dictionary as ICollection<KeyValuePair<TKey, TValue>>).Contains(item);
        }

        public bool ContainsKey(TKey key)
        {
            return this.Dictionary.ContainsKey(key);
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            (this.Dictionary as ICollection<KeyValuePair<TKey, TValue>>).CopyTo(array, arrayIndex);
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return this.Dictionary.GetEnumerator();
        }

        public bool Remove(TKey key)
        {
            var output = this.Dictionary.Remove(key);
            return output;
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            return this.Remove(item.Key);
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            var output = this.Dictionary.TryGetValue(key, out value);
            return output;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.Dictionary.GetEnumerator();
        }
    }
}
