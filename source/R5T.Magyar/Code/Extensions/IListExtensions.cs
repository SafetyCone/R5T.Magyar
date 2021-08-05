using System;
using System.Collections.Generic;


namespace System.Linq
{
    public static class IListExtensions
    {
        public static int GetIndexOfPriorAlphabeticalElement<T>(this IList<T> list, Func<T, string> keySelector, string key)
        {
            var priorAlphabeticalElementWasFound = list.GetPriorAlphabeticalElement(keySelector, key);
            
            if(priorAlphabeticalElementWasFound)
            {
                var index = list.IndexOf(priorAlphabeticalElementWasFound);
                return index;
            }
            else
            {
                return IndexHelper.Zero;
            }
        }
    }
}
