using System;
using System.Threading;
using System.Threading.Tasks;


namespace System
{
    public static class SyncOverAsyncHelper
    {
        public static void ExecuteTaskSynchronously(Task task)
        {
            // Force synchronously executing thread to wait for the asynchrous work to to be done.
            var semaphore = new SemaphoreSlim(0);

            async Task ExecuteTaskAsynchronously()
            {
                await task;

                semaphore.Release();
            }

            // Fire and forget in the threadpool.
            _ = ExecuteTaskAsynchronously();

            semaphore.Wait();
        }

        public static void ExecuteSynchronously(Func<Task> action)
        {
            // Force synchronously executing thread to wait for the asynchrous work to to be done.
            var semaphore = new SemaphoreSlim(0);

            async Task ExecuteTaskAsynchronously()
            {
                await action();

                semaphore.Release();
            }

            // Fire and forget in the threadpool.
            _ = ExecuteTaskAsynchronously();

            semaphore.Wait();
        }
    }
}
