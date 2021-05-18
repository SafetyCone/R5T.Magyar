using System;


namespace System.Collections.Generic
{
    public class DistinctValuedDictionary<TKey, TValue> : IDistinctValuedDictionary<TKey, TValue>
    {
        private Dictionary<TKey, TValue> Dictionary { get; }
        private HashSet<TValue> ValuesHashSet { get; }


        public DistinctValuedDictionary(IEqualityComparer<TKey> keyEqualityComparer, IEqualityComparer<TValue> valueEqualityComparer)
        {
            this.Dictionary = new Dictionary<TKey, TValue>(keyEqualityComparer);
            this.ValuesHashSet = new HashSet<TValue>(valueEqualityComparer);
        }

        public DistinctValuedDictionary()
            : this(EqualityComparer<TKey>.Default, EqualityComparer<TValue>.Default)
        {
        }

        public TValue this[TKey key]
        {
            get
            {
                return this.Dictionary[key];
            }

            set
            {
                var oldValue = this.Dictionary[key];

                this.ValuesHashSet.Remove(oldValue);

                this.Dictionary[key] = value;

                this.ValuesHashSet.Add(value);
            }
        }

        public ICollection<TKey> Keys => this.Dictionary.Keys;
        public ICollection<TValue> Values => this.Dictionary.Values;
        public int Count => this.Dictionary.Count;
        public bool IsReadOnly => (this.Dictionary as IDictionary<TKey, TValue>).IsReadOnly;

        public void Add(TKey key, TValue value)
        {
            this.Dictionary.Add(key, value);
            this.ValuesHashSet.Add(value);
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            this.Add(item.Key, item.Value);
        }

        public void Clear()
        {
            this.Dictionary.Clear();
            this.ValuesHashSet.Clear();
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
            var value = this.Dictionary[key];

            var output = this.Dictionary.Remove(key);

            this.ValuesHashSet.Remove(value);

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
