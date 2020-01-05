using System;


namespace R5T.Magyar
{
    using System;


    namespace R5T.Venetia
    {
        /// <summary>
        /// Solves a problem that asynchronous (async) methods cannot use out parameters.
        /// Instead, an instance providing both whether the output exists, and the result instance if it does, it output from the asynchronous method.
        /// </summary>
        /// <typeparam name="T">The type of the result.</typeparam>
        /// <remarks>
        /// This is the same idea as suggested in Stack Overflow: https://stackoverflow.com/questions/18716928/how-to-write-a-async-method-with-out-parameter
        /// </remarks>
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

}
