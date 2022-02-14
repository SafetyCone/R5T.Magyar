using System;


namespace System
{
    public static class ComparisonHelper
    {
        public static int LessThan => -1;
        public static int GreaterThan => 1;
        public static int EqualTo => 0;


        public static bool IsEqualResult(
            int comparisonValue)
        {
            var output = comparisonValue == ComparisonHelper.EqualTo;
            return output;
        }

        public static bool IsNotEqualResult(
            int comparisonValue)
        {
            var output = !ComparisonHelper.IsEqualResult(comparisonValue);
            return output;
        }
    }
}
