using System;
using System.Collections.Generic;


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
    public class WasFound<T>
    {
        #region Static

        public static implicit operator bool(WasFound<T> wasFound)
        {
            return wasFound.zExists;
        }

        #endregion


        private bool zExists;
        [Obsolete("Use the implicit conversion of to bool instead.", false)]
        public bool Exists
        {
            get
            {
                return this.zExists;
            }
        }
        public T Result { get; set; }


        public WasFound()
        {
        }

        public WasFound(bool exists, T result)
        {
            this.zExists = exists;
            this.Result = result;
        }
    }

    public static class WasFound
    {
        /// <summary>
        /// Default assumes a reference type.
        /// </summary>
        public static WasFound<T> From<T>(T resultOrDefault)
        {
            var defaultEqualityComparer = EqualityComparer<T>.Default;

            var defaultValue = default(T);
            var exists = !defaultEqualityComparer.Equals(resultOrDefault, defaultValue);

            var wasFound = new WasFound<T>(exists, resultOrDefault);
            return wasFound;
        }

        public static WasFound<T> From<T>(bool exists, T result)
        {
            var wasFound = new WasFound<T>(exists, result);
            return wasFound;
        }

        public static WasFound<T> NotFound<T>()
        {
            var wasFound = new WasFound<T>(false, default(T));
            return wasFound;
        }
    }
}
