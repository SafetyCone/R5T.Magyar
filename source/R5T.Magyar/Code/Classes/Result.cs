using System;
using System.Collections.Generic;


namespace R5T.Magyar
{
    public class Result<T>
    {
        public T Value { get; }
        public IEnumerable<string> ErrorMessages { get; }
        public IEnumerable<string> OutputMessages { get; }


        public Result(T value, IEnumerable<string> errorMessages, IEnumerable<string> outputMessages)
        {
            this.Value = value;
            this.ErrorMessages = errorMessages;
            this.OutputMessages = outputMessages;
        }
    }
}
