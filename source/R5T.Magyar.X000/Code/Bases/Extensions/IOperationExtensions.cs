using System;
using System.Collections.Generic;

using R5T.Magyar;

using R5T.T0098;


namespace System
{
    public static class IOperationExtensions
    {
        public static Dictionary<T, WasFound<T>> GetWasFoundByValue<T>(this IOperation _,
            IEnumerable<T> toBeSearched,
            IEnumerable<T> toBeFound,
            Func<IEnumerable<T>, T, WasFound<T>> searcher)
        {
            var output = new Dictionary<T, WasFound<T>>();

            foreach (var item in toBeFound)
            {
                var wasFound = searcher(toBeSearched, item);

                output.Add(item, wasFound);
            }

            return output;
        }
    }
}