using System;
using System.Collections.Generic;


namespace R5T.Magyar
{
    public class Result<T>
    {
        public T Value { get; }
        public IEnumerable<string> Messages { get; }


        public Result(T value, IEnumerable<string> messages)
        {
            this.Value = value;
            this.Messages = messages;
        }
    }
}
