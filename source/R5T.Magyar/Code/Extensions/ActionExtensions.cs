using System;
using System.Threading.Tasks;


namespace System.Threading.Tasks
{
    public static class ActionExtensions
    {
        public static Func<TInput, Task> AsTask<TInput>(this Action<TInput> action)
        {
            return xInput =>
            {
                action(xInput);

                return Task.CompletedTask;
            };
        }
    }
}


namespace R5T.Magyar.Extensions
{
    public static class ActionExtensions
    {
        public static Func<Task> ToAsyncAction(this Action action)
        {
            Task asyncAction()
            {
                action();

                return Task.CompletedTask;
            }

            return asyncAction;
        }
    }
}
