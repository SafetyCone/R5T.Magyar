using System;

using R5T.Magyar;


namespace System
{
    /// <summary>
    /// Placed in <see cref="System"/> namespace so as to be available anywhere you might have an instance of a <see cref="TypedList{T}"/>.
    /// </summary>
    public static class TypedListExtensions
    {
        public static void Add<T>(this TypedList<T> list, T value)
        {
            list.Values.Add(value);
        }
    }
}
