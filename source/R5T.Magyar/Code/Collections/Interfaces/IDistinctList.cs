using System;


namespace System.Collections.Generic
{
    /// <summary>
    /// Similar to <see cref="IReadOnlyList{T}"/>, there should be a type that communicates its elements are distinct.
    /// </summary>
    public interface IDistinctList<T> : IList<T>
    {
    }
}
