using System;
using System.Collections.Generic;


namespace R5T.Magyar
{
    public struct ItemCount<T>
    {
        #region Static

        public static ItemCount<T> From(KeyValuePair<T, int> pair)
        {
            var output = new ItemCount<T>
            {
                Item = pair.Key,
                Count = pair.Value,
            };

            return output;
        }

        #endregion


        public T Item { get; set; }
        public int Count { get; set; }
    }
}
