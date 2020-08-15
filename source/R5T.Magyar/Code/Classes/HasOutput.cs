using System;
using System.Collections.Generic;


namespace R5T.Magyar
{
    public static class HasOutput
    {
        public static HasOutput<T> FromReferenceType<T>(T result)
            where T: class
        {
            var hasOutput = new HasOutput<T>(result is object, result);
            return hasOutput;
        }

        /// <summary>
        /// Default assumes a reference type.
        /// </summary>
        public static HasOutput<T> From<T>(T result)
            where T : class
        {
            var hasOutput = HasOutput.FromReferenceType<T>(result);
            return hasOutput;
        }

        public static HasOutput<T> FromValueType<T>(T result, T nonExistenceValue, Func<T, T, bool> equality)
            where T : struct
        {
            var exists = !equality(result, nonExistenceValue);

            var hasOutput = new HasOutput<T>(exists, result);
            return hasOutput;
        }

        public static HasOutput<T> FromValueType<T>(T result, T nonExistenceValue)
            where T : struct
        {
            var equalityComparer = EqualityComparer<T>.Default;

            var hasOutput = HasOutput.FromValueType(result, nonExistenceValue, (x, y) => equalityComparer.Equals(x, y));
            return hasOutput;
        }
    }


    /// <summary>
    /// Solves a problem that asynchronous (async) methods cannot use out parameters.
    /// Instead, an instance providing both whether the output exists, and the result instance if it does, it output from the asynchronous method.
    /// </summary>
    /// <typeparam name="T">The type of the result.</typeparam>
    /// <remarks>
    /// This is the same idea as suggested in Stack Overflow: https://stackoverflow.com/questions/18716928/how-to-write-a-async-method-with-out-parameter
    /// An older version of <see cref="WasFound{T}"/>
    /// </remarks>
    /// <seealso cref="WasFound{T}"/>
    public class HasOutput<T>
    {
        public bool Exists { get; set; }
        public T Result { get; set; }


        public HasOutput()
        {
        }

        public HasOutput(bool exists, T result)
        {
            this.Exists = exists;
            this.Result = result;
        }
    }
}
