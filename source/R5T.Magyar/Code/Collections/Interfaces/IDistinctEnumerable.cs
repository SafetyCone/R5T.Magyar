using System;


namespace System.Collections.Generic
{
    /// <summary>
    /// Indicates (but does not guarantee) that an enumerable contains distinct elements.
    /// /// Extension methods can be used to verify/ensure the enumerable contains unique if desirable (and the cost of computation is justified).
    /// </summary>
    /// <remarks>
    /// Conceptually similar to <see cref="IReadOnlyCollection{T}"/>, but indicates the distict property instead of being read-only.
    /// </remarks>
    public interface IDistinctEnumerable<T> : IEnumerable<T>
    {
    }
}
