using System;


namespace System.Collections.Generic
{
    public class SpecifiedListComparer<T> : IComparer<T>
    {
        public IList<T> List { get; }


        public SpecifiedListComparer(
            IList<T> list)
        {
            this.List = list;
        }

        public SpecifiedListComparer(
            params T[] items)
        {
            this.List = items;
        }

        public int Compare(T x, T y)
        {
            var indexOfX = this.List.IndexOf(x);
            var indexOfY = this.List.IndexOf(y);

            var xWasFound = IndexHelper.IsFound(indexOfX);
            var yWasFound = IndexHelper.IsFound(indexOfY);

            int output;
            if(xWasFound)
            {
                if(yWasFound)
                {
                    output = indexOfX.CompareTo(indexOfY);
                }
                else
                {
                    // Make sure X appears before any unfound Y.
                    output = ComparisonHelper.LessThan;
                }
            }
            else
            {
                if(yWasFound)
                {
                    // Make sure Y appears before any unfound X.
                    output = ComparisonHelper.GreaterThan;
                }
                else
                {
                    output = ComparisonHelper.EqualTo;
                }
            }

            return output;
        }
    }
}
