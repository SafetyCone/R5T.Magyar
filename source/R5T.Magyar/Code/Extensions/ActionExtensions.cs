using System;
using System.Threading.Tasks;


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
