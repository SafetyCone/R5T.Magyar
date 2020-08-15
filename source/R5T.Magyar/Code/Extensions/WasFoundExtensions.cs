using System;


namespace R5T.Magyar
{
    public static class WasFoundExtensions
    {
        public static (bool WasFound, TOutput output) ToTuple<TResult, TOutput>(this WasFound<TResult> wasFound, Func<TResult, TOutput> selector)
        {
            var output = selector(wasFound.Result);

            return (wasFound, output);
        }
    }
}
