using System;


namespace System.Additions
{
    public class ComparisonBasedEqualityComparer<T> : IEqualityComparer<T>
    {
        public EqualityComparison<T> EqualityComparison { get; set; }


        public bool Equals(T x, T y)
        {
            var output = this.EqualityComparison(x, y);
            return output;
        }
    }


    public static class ComparisonBasedEqualityComparer
    { 
        public static ComparisonBasedEqualityComparer<T> From<T>(EqualityComparison<T> equalityComparison)
        {
            var output = new ComparisonBasedEqualityComparer<T>
            {
                EqualityComparison = equalityComparison,
            };

            return output;
        }
    }
}
