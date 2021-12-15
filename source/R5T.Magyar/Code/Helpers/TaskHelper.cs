using System;


namespace System.Threading.Tasks
{
    public static class TaskHelper
    {
        public static Func<TInput, Task<TOutput>> MakeAsynchronous<TInput, TOutput>(this Func<TInput, TOutput> synchronousFunction)
        {
            Task<TOutput> AsynchronousFunction(TInput input)
            {
                var output = synchronousFunction(input);

                return Task.FromResult(output);
            }

            return AsynchronousFunction;
        }

        public static async Task<(T1 Task1Result, T2 Task2Result)> WhenAll<T1, T2>(Func<Task<T1>> t1Task, Func<Task<T2>> t2Task)
        {
            var gettingT1 = t1Task();
            var gettingT2 = t2Task();

            var t1 = await gettingT1;
            var t2 = await gettingT2;

            return (t1, t2);
        }

        public static async Task<(T1 Task1Result, T2 Task2Result)> WhenAll<T1, T2>(Task<T1> gettingT1, Task<T2> gettingT2)
        {
            var t1 = await gettingT1;
            var t2 = await gettingT2;

            return (t1, t2);
        }

        public static async Task<(T1 Task1Result, T2 Task2Result, T3 Task3Result)> WhenAll<T1, T2, T3>(Func<Task<T1>> t1Task, Func<Task<T2>> t2Task, Func<Task<T3>> t3Task)
        {
            var gettingT1 = t1Task();
            var gettingT2 = t2Task();
            var gettingT3 = t3Task();

            var t1 = await gettingT1;
            var t2 = await gettingT2;
            var t3 = await gettingT3;

            return (t1, t2, t3);
        }

        public static async Task<(T1 Task1Result, T2 Task2Result, T3 Task3Result)> WhenAll<T1, T2, T3>(Task<T1> gettingT1, Task<T2> gettingT2, Task<T3> gettingT3)
        {
            var t1 = await gettingT1;
            var t2 = await gettingT2;
            var t3 = await gettingT3;

            return (t1, t2, t3);
        }

        public static async
            Task<(T1 Task1Result, T2 Task2Result, T3 Task3Result, T4 Task4Result)>
        WhenAll<T1, T2, T3, T4>(
            Func<Task<T1>> t1Task,
            Func<Task<T2>> t2Task,
            Func<Task<T3>> t3Task,
            Func<Task<T4>> t4Task)
        {
            var gettingT1 = t1Task();
            var gettingT2 = t2Task();
            var gettingT3 = t3Task();
            var gettingT4 = t4Task();

            var t1 = await gettingT1;
            var t2 = await gettingT2;
            var t3 = await gettingT3;
            var t4 = await gettingT4;

            return (t1, t2, t3, t4);
        }

        public static async
            Task<(T1 Task1Result, T2 Task2Result, T3 Task3Result, T4 Task4Result)>
        WhenAll<T1, T2, T3, T4>(
            Task<T1> gettingT1,
            Task<T2> gettingT2,
            Task<T3> gettingT3,
            Task<T4> gettingT4)
        {
            var t1 = await gettingT1;
            var t2 = await gettingT2;
            var t3 = await gettingT3;
            var t4 = await gettingT4;

            return (t1, t2, t3, t4);
        }

        public static async
            Task<(T1 Task1Result, T2 Task2Result, T3 Task3Result, T4 Task4Result, T5 Task5Result)>
        WhenAll<T1, T2, T3, T4, T5>(
            Task<T1> gettingT1,
            Task<T2> gettingT2,
            Task<T3> gettingT3,
            Task<T4> gettingT4,
            Task<T5> gettingT5)
        {
            var t1 = await gettingT1;
            var t2 = await gettingT2;
            var t3 = await gettingT3;
            var t4 = await gettingT4;
            var t5 = await gettingT5;

            return (t1, t2, t3, t4, t5);
        }

        public static async
            Task<(T1 Task1Result, T2 Task2Result, T3 Task3Result, T4 Task4Result, T5 Task5Result, T6 Task6Result)>
        WhenAll<T1, T2, T3, T4, T5, T6>(
            Task<T1> gettingT1,
            Task<T2> gettingT2,
            Task<T3> gettingT3,
            Task<T4> gettingT4,
            Task<T5> gettingT5,
            Task<T6> gettingT6)
        {
            var t1 = await gettingT1;
            var t2 = await gettingT2;
            var t3 = await gettingT3;
            var t4 = await gettingT4;
            var t5 = await gettingT5;
            var t6 = await gettingT6;

            return (t1, t2, t3, t4, t5, t6);
        }
    }
}
