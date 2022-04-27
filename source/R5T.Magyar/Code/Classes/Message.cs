using System;


namespace R5T.Magyar
{
    public class Message<T>
    {
        public T Value { get; }
        public string Text { get; }


        public Message(
            T value,
            string text)
        {
            this.Value = value;
            this.Text = text;
        }
    }


    public static class Message
    {
        public static Message<T> For<T>(T value, string text)
        {
            var output = new Message<T>(value, text);
            return output;
        }
    }
}
