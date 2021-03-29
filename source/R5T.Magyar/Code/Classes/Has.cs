using System;
using System.Collections.Generic;


namespace R5T.Magyar
{
    public class Has<T>
    {
        public bool HasValue { get; }
        public T Value { get; }


        public Has(bool hasValue, T value)
        {
            this.HasValue = hasValue;
            this.Value = value;
        }

        public Has(T value)
            : this(EqualityComparer<T>.Default.Equals(value, default), value)
        {
        }

        public Has()
            : this(false, default)
        {
        }
    }
}
