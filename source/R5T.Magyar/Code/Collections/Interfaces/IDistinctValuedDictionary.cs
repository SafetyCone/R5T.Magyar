using System;


namespace System.Collections.Generic
{
    /// <summary>
    /// The <see cref="Dictionary{TKey, TValue}"/> type must have distinct keys, but it can have non-distinct values.
    /// With an <see cref="IDistinctValuedDictionary{TKey, TValue}"/>, both the keys and values are distinct.
    /// </summary>
    public interface IDistinctValuedDictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
    }
}
