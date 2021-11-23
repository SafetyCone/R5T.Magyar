using System;
using System.Collections.Generic;
using System.Linq;


namespace R5T.Magyar
{
    /// <summary>
    /// Solves a problem that asynchronous (async) methods cannot use out parameters.
    /// Instead, an instance providing both whether the output exists, and the result instance if it does, it output from the asynchronous method.
    /// </summary>
    /// <typeparam name="T">The type of the result.</typeparam>
    /// <remarks>
    /// A newer version of <see cref="HasOutput{T}"/>
    /// This is the same idea as suggested in Stack Overflow: https://stackoverflow.com/questions/18716928/how-to-write-a-async-method-with-out-parameter
    /// </remarks>
    /// <seealso cref="HasOutput{T}"/>
    public class WasSuccessful<T>
    {
        #region Static

        public static implicit operator bool(WasSuccessful<T> wasFound)
        {
            return wasFound.Success;
        }

        public static implicit operator T(WasSuccessful<T> wasFound)
        {
            return wasFound.Result;
        }

        #endregion


        //[Obsolete("Use the implicit conversion of to bool instead.", false)]
        public bool Success { get; }
        public T Result { get; set; }


        public WasSuccessful()
        {
        }

        public WasSuccessful(bool success, T result)
        {
            this.Success = success;
            this.Result = result;
        }

        public override string ToString()
        {
            var representation = $"{this.Success}, {this.Result}";
            return representation;
        }
    }

    public static class WasSuccessful
    {
        public static WasSuccessful<T> Successful<T>(T value)
        {
            var wasFound = new WasSuccessful<T>(true, value);
            return wasFound;
        }

        /// <summary>
        /// Default assumes a reference type.
        /// </summary>
        public static WasSuccessful<T> From<T>(T resultOrDefault)
        {
            var defaultEqualityComparer = EqualityComparer<T>.Default;

            var defaultValue = default(T);
            var exists = !defaultEqualityComparer.Equals(resultOrDefault, defaultValue);

            var wasFound = new WasSuccessful<T>(exists, resultOrDefault);
            return wasFound;
        }

        public static WasSuccessful<T> From<T>(bool exists, T result)
        {
            var wasFound = new WasSuccessful<T>(exists, result);
            return wasFound;
        }

        public static WasSuccessful<T[]> FromArray<T>(T[] result)
        {
            var exists = result is object && result.Any();

            var output = new WasSuccessful<T[]>(exists, result);
            return output;
        }

        public static WasSuccessful<T> Unsuccessful<T>()
        {
            var wasFound = new WasSuccessful<T>(false, default);
            return wasFound;
        }
    }
}
