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

        public static async Task<(T, T1, T2)> WhenAlso<T, T1, T2>(this Task<T> gettingT, Task<T1> gettingT1, Task<T2> gettingT2)
        {
            var t = await gettingT;
            var t1 = await gettingT1;
            var t2 = await gettingT2;

            return (t, t1, t2);
        }
    }
}


namespace R5T.Magyar
{
    using System.Threading.Tasks;


    public static class TaskExtensions
    {
        public static Task<T> AsTask<T>(this T value)
        {
            return Task.FromResult(value);
        }
    }
}
