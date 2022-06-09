using System;
using System.Collections.Generic;


namespace System
{
    public class ComparisonBasedComparer<T> : IComparer<T>
    {
        private Comparison<T> Comparison { get; }


        public ComparisonBasedComparer(
            Comparison<T> comparison)
        {
            this.Comparison = comparison;
        }

        public int Compare(T x, T y)
        {
            var output = this.Comparison(x, y);
            return output;
        }
    }
}
