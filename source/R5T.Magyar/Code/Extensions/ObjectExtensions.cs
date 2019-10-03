using System;


namespace R5T.Magyar.Extensions.Object
{
    public static class ObjectExtensions
    {
        public static T[] ToArray<T>(this T item)
        {
            var output = new T[] { item };
            return output;
        }
    }
}
