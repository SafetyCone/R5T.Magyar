using System;


namespace System.Additions
{
    /// <summary>
    /// Tests two instances for equality.
    /// Separate from <see cref="Collections.Generic.IEqualityComparer{T}"/>, this type does not require defining <see cref="Collections.Generic.IEqualityComparer{T}.GetHashCode(T)"/>.
    /// </summary>
    public interface IEqualityComparer<in T>
    {
        bool Equals(T x, T y);
    }
}
