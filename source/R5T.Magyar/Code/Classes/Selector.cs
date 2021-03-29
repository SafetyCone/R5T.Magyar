using System;
using System.Linq.Expressions;


namespace R5T.Magyar
{
    public static class Selector
    {
        public static Expression<Func<T, T>> Default<T>()
        {
            Expression<Func<T, T>> output = x => x;
            return output;
        }
    }
}
