using System;
using System.Threading.Tasks;


namespace System
{
    public static class FunctionHelper
    {
        public static Task Run<T>(Func<T, Task> action, T value)
        {
            var output = action is object
                ? action(value)
                : Task.CompletedTask
                ;

            return output;
        }

        public static void Run<T>(Action<T> action, T value)
        {
            if (action is object)
            {
                action(value);
            }
        }

        public static Task Run<T>(Func<T, Task> action, Func<T> valueGenerator)
        {
            if( action is object)
            {
                var value = valueGenerator();

                return action(value);
            }
            else
            {
                return Task.CompletedTask;
            }
        }
    }
}
