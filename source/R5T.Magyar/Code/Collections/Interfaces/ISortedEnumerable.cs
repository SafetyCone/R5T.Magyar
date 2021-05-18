using System;


namespace System.Collections.Generic
{
    /// <summary>
    /// Indicates (but does not guarantee) that an enumerable is sorted (in an implicit order).
    /// Extension methods can be used to verify/ensure the enumerable is sorted (in an implicit) order if desirable (and the cost of computation is justified).
    /// </summary>
    /// <remarks>
    /// There is the <see cref="SortedList{TKey, TValue}"/> class, but it includes an extraneous extra key type parameter.
    /// There is also the <see cref="System.Linq.IOrderedEnumerable{TElement}"/> interface, but it demands an implication of a verification method instead of leaving that to an optional extension method.
    /// </remarks>
    public interface ISortedEnumerable<T> : IEnumerable<T>
    {
    }
}
