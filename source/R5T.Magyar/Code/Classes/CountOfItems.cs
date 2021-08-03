using System;
using System.Collections.Generic;


namespace R5T.Magyar
{
    public class CountOfItems<T>
    {
        #region Static

        public static CountOfItems<T> From(IEnumerable<T> items)
        {
            var output = new CountOfItems<T>()
                .AddItems(items);

            return output;
        }

        #endregion


        public Dictionary<T, int> CountByItem { get; } = new Dictionary<T, int>();


        public CountOfItems<T> AddItem(T item)
        {
            if (this.CountByItem.ContainsKey(item))
            {
                this.CountByItem[item] = this.CountByItem[item] + 1;
            }
            else
            {
                this.CountByItem.Add(item, 1);
            }

            return this;
        }

        public CountOfItems<T> AddItems(IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                this.AddItem(item);
            }

            return this;
        }
    }
}
