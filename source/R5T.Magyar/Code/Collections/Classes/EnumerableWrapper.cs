using System;
using System.Collections;
using System.Collections.Generic;


namespace R5T.Magyar
{
    public static class EnumerableWrapper
    {
        public static EnumerableWrapper<T> From<T>(IEnumerable<T> enumerable)
        {
            var output = new EnumerableWrapper<T>(enumerable);
            return output;
        }
    }


    public class EnumerableWrapper<T> : IEnumerable<T>, IDistinctEnumerable<T>, ISortedAscendingEnumerable<T>, ISortedDescendingEnumerable<T>, ISortedEnumerable<T>
    {
        private IEnumerable<T> Enumerable { get; }


        public EnumerableWrapper(IEnumerable<T> enumerable)
        {
            this.Enumerable = enumerable;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.Enumerable.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.Enumerable.GetEnumerator();
        }
    }
}
