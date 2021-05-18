using System;


namespace System.Threading.Tasks
{
    public static class TaskExtensions
    {
        public static async Task<TOut> Then<TIn, TOut>(this Task<TIn> task, Func<TIn, TOut> converter)
        {
            var input = await task;

            var output = converter(input);
            return output;
        }

        public static async Task<TOut> ResultAs<TIn, TOut>(this Task<TIn> task)
            where TOut: class
        {
            var input = await task;

            var output = input as TOut;
            return output;
        }
    }
}
