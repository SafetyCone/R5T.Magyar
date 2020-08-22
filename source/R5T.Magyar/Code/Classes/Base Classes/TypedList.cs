using System;
using System.Collections;
using System.Collections.Generic;


namespace R5T.Magyar
{
    /// <summary>
    /// Allows a <see cref="List{T}"/> to be handled as distinct named type.
    /// </summary>
    public class TypedList<T> : IEnumerable<T>
    {
        public List<T> Values { get; } = new List<T>();


        public TypedList()
        {
        }

        /// <summary>
        /// Adds input values to the internal list.
        /// </summary>
        public TypedList(IEnumerable<T> values)
        {
            this.Values.AddRange(values);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.Values.GetEnumerator();
        }
    }
}
