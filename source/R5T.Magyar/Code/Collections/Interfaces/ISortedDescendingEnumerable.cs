using System;


namespace System.Collections.Generic
{
    /// <summary>
    /// Indicates (but does not guarantee) that an enumerable is sorted in descending order.
    /// Extension methods can be used to verify/ensure the enumerable is sorted in descending order if desirable (and the cost of computation is justified).
    /// </summary>
    /// <remarks>
    /// There is a <see cref="SortedList{TKey, TValue}"/> class, but it includes an extraneous extra key type parameter.
    /// </remarks>
    public interface ISortedDescendingEnumerable<T> : ISortedEnumerable<T>
    {
    }
}
