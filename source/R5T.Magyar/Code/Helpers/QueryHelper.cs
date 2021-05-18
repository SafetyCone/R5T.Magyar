using System;


namespace R5T.Magyar
{
    public static class QueryHelper
    {
        public const int NoLimitMaximumResultsCount = -1;


        public static bool IsNoLimitMaximumResultsCount(int value)
        {
            var output = QueryHelper.NoLimitMaximumResultsCount == value;
            return output;
        }
    }
}
