using System;
using System.Threading.Tasks;


namespace System
{
    public static class AsyncAwaitHelper
    {
        public static Task IfNullThenCompletedTask(
            Task task)
        {
            var actionIsNonNull = NullHelper.IsNonNull(task);

            var output = actionIsNonNull
                ? task
                : Task.CompletedTask
                ;

            return output;
        }

        public static Task IfNullThenCompletedTask(
            Func<Task> action)
        {
            var actionIsNonNull = NullHelper.IsNonNull(action);

            var output = actionIsNonNull
                ? action()
                : Task.CompletedTask
                ;

            return output;
        }
    }
}
