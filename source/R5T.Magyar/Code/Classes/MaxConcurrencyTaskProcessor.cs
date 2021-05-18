using System;
using System.Collections.Generic;


namespace System.Threading.Tasks
{
    public static class MaxConcurrencyTaskProcessor
    {
        public static async Task Run<TValue>(Func<TValue, int, Task> actionOnValueN, IEnumerable<TValue> values, int maxConcurrency)
        {
            var currentIndex = 1;

            var exceptions = new List<Exception>();

            using (var maxConcurrencySemaphor = new SemaphoreSlim(maxConcurrency))
            {
                var tasks = new List<Task>();

                foreach (var value in values)
                {
                    maxConcurrencySemaphor.Wait();

                    var task = Task.Run(async () =>
                    {
                        try
                        {
                            await actionOnValueN(value, currentIndex++);
                        }
                        catch(Exception ex)
                        {
                            exceptions.Add(ex);
                        }
                        finally
                        {
                            maxConcurrencySemaphor.Release();
                        }
                    });

                    tasks.Add(task);
                }

                await Task.WhenAll(tasks);
            }

            AggregateExceptionHelper.ThrowIfAny(exceptions);
        }
    }
}
