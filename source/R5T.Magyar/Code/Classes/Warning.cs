using System;


namespace R5T.Magyar
{
    public class Warning<T>
    {
        public T Value { get; }
        public string Message { get; }


        public Warning(
            T value,
            string message)
        {
            this.Value = value;
            this.Message = message;
        }
    }


    public static class Warning
    {
        public static Warning<T> For<T>(T value, string message)
        {
            var output = new Warning<T>(value, message);
            return output;
        }
    }
}
