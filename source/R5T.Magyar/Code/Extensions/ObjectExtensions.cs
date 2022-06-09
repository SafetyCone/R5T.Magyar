using System;
using System.Collections.Generic;


namespace R5T.Magyar
{
    public static class ObjectExtensions
    { 
        
    }
}

namespace R5T.Magyar.Extensions
{
    public static class ObjectExtensions
    {
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

        public static TIn ModifyAs<TIn, T>(this TIn value, Action<T> action)
            where T : class
        {
            var valueAsT = value as T;

            action(valueAsT);

            return value;
        }

        public static WasFound<T> WasFound<T>(this T value)
        {
            var output = Magyar.WasFound.From(value);
            return output;
        }

        /// <summary>
        /// Useful for resolving ambiguous extension methods.
        /// For example an instance is an IX, which implements IA and IB, both of which have extension method M().
        /// If the instance was typed as IA or IB, there would be no ambiguity about which extension method to call. However, because IX is both an IA and IB, there is no preference for which extension method to call since all interfaces are equals.
        /// Thus you can cast the type to the desired interface type to select the desired extension method.
        /// </summary>
        /// <seealso cref="Cast{T1, T2}(T1)"/>
        public static T2 As<T2, T1>(this T1 obj)
            where T1 : T2
            where T2 : class
        {
            var output = obj as T2;
            return output;
        }

        public static T As<T>(this object obj)
            where T : class
        {
            var output = obj as T;
            return output;
        }

        /// <summary>
        /// <inheritdoc cref="As{T2, T1}(T1)" path="/summary"/>
        /// </summary>
        /// <seealso cref="As{T2, T1}(T1)"/>
        public static T2 Cast<T1, T2>(this T1 obj)
            where T2 : class
        {
            var output = obj as T2;
            return output;
        }

        public static T IfIsDefaultThen<T>(this T objOrDefault, T alternativeIfDefault)
            where T : class
        {
            var output = objOrDefault == default
                ? alternativeIfDefault
                : objOrDefault
                ;

            return output;
        }

        public static T[] ToArray_FromSingle<T>(this T item)
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

namespace R5T.Magyar.Fluent
{
    public static class ObjectExtensions
    {
        public static T ModifyWith<T>(this T input,
            Func<T, T> modifier)
        {
            var output = modifier(input);
            return output;
        }
    }
}