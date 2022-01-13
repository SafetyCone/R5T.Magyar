using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using R5T.Magyar;


namespace System
{
    public static class EnumerableHelper
    {
        public static IEnumerable<T> Empty<T>()
        {
            return Enumerable.Empty<T>();
        }

        public static IEnumerable<T> From<T>(T value)
        {
            yield return value;
        }

        public static IEnumerable<T> From<T>(params T[] values)
        {
            return values;
        }

        public static Task ProcessSingularAction<TIn>(Func<IDistinctEnumerable<TIn>, Task> processor, TIn input)
        {
            var singular = EnumerableHelper.From(input).Wrap();

            return processor(singular);
        }

        public static async Task<TOut> ProcessSingular<TIn, TOut>(Func<IDistinctEnumerable<TIn>, Task<IDictionary<TIn, TOut>>> processor, TIn input)
        {
            var singular = EnumerableHelper.From(input).Wrap();

            var outsByIns = await processor(singular);

            var output = outsByIns[input];
            return output;
        }

        /// <summary>
        /// Random overload for <see cref="IDistinctValuedDictionary{TKey, TValue}"/> since C# compiler does not see covariance to <see cref="IDictionary{TKey, TValue}"/> and specifying the dictionary type parameter for <see cref="IDistinctValuedDictionary{TKey, TValue}"/> is obnoxious.
        /// </summary>
        public static async Task<TOut> ProcessSingular<TIn, TOut>(Func<IDistinctEnumerable<TIn>, Task<IDistinctValuedDictionary<TIn, TOut>>> processor, TIn input)
        {
            var singular = EnumerableHelper.From(input).Wrap();

            var outsByIns = await processor(singular);

            var output = outsByIns[input];
            return output;
        }

        public static async Task<TOut> ProcessSingular<TIn, TDictionary, TOut>(Func<IDistinctEnumerable<TIn>, Task<TDictionary>> processor, TIn input)
            where TDictionary: IDictionary<TIn, TOut>
        {
            var singular = EnumerableHelper.From(input).Wrap();

            var outsByIns = await processor(singular);

            var output = outsByIns[input];
            return output;
        }
    }
}
