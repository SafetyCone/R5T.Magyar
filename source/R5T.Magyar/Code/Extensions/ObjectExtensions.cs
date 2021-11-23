using System;
using System.Collections.Generic;


namespace R5T.Magyar
{
    public static class ObjectExtensions
    { 
        public static TIn As<TIn, T>(this TIn value, Action<T> action)
            where T : class
        {
            var valueAsT = value as T;

            action(valueAsT);

            return value;
        }

        public static T For<T>(this T value, Action<T> action)
        {
            action(value);

            return value;
        }

        public static T Modify<T>(this T value, Action<T> action)
        {
            action(value);

            return value;
        }    
    }
}

namespace R5T.Magyar.Extensions
{
    public static class ObjectExtensions
    {
        public static T[] ToArray<T>(this T item)
        {
            var output = new T[] { item };
            return output;
        }

        public static IEnumerable<T> ToEnumerable<T>(this T item)
        {
            yield return item;
        }
    }
}
