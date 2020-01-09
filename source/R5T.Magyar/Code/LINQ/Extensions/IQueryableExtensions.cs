using System;
using System.Linq;


namespace R5T.Magyar.LINQ
{
    public static class IQueryableExtensions
    {
        public static HasOutput<T> HasSingle<T>(this IQueryable<T> queryable)
            where T: class
        {
            var singleOrDefault = queryable.SingleOrDefault();

            var hasOutput = HasOutput.FromReferenceType(singleOrDefault);
            return hasOutput;
        }

        public static HasOutput<T> HasSingle<T>(this IQueryable<T> queryable, T nonExistentValue)
            where T : struct
        {
            var singleOrDefault = queryable.SingleOrDefault();

            var hasOutput = HasOutput.FromValueType(singleOrDefault, nonExistentValue);
            return hasOutput;
        }
    }
}
