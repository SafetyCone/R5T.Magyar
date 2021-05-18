using System;
using System.Collections.Generic;
using System.Linq;


namespace R5T.Magyar.Extensions
{
    public static class IEnumerableStringExtensions
    {
        public static IEnumerable<string> SortAlphabetically(this IEnumerable<string> strings)
        {
            var output = strings.OrderBy(x => x);
            return output;
        }

        public static string CommaSeparatorJoin(this IEnumerable<string> strings)
        {
            var separator = $"{Characters.Comma}{Characters.Space}";

            var joined = String.Join(separator, strings);
            return joined;
        }
    }
}
