using System;
using System.Collections.Generic;


namespace R5T.Magyar
{
    public class LabeledList<T> : ILabeled
    {
        public string Label { get; set; }
        public List<T> Items { get; } = new List<T>();
    }
}
