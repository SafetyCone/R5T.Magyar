using System;


namespace R5T.Magyar
{
    public static class WasFoundExtensions
    {
        /// <summary>
        /// Useful in the cases where C# does not realize it should use the implicit conversion operator (such as returning when you need to return a boolean and C# will not accept a WasFound).
        /// </summary>
        public static bool AsBoolean<TResult>(this WasFound<TResult> wasFound)
        {
#pragma warning disable CS0618 // Type or member is obsolete
            return wasFound.Exists;
#pragma warning restore CS0618 // Type or member is obsolete
        }

        public static (bool WasFound, TOutput output) ToTuple<TResult, TOutput>(this WasFound<TResult> wasFound, Func<TResult, TOutput> selector)
        {
            var output = selector(wasFound.Result);

            return (wasFound, output);
        }

        public static WasFound<TDestination> Convert<TSource, TDestination>(this WasFound<TSource> wasFound, Func<TSource, TDestination> converter)
        {
            if(wasFound)
            {
                var convertedResult = converter(wasFound.Result);

                var output = WasFound.From(wasFound, convertedResult);
                return output;
            }
            else
            {
                var output = WasFound.From(wasFound, default(TDestination));
                return output;
            }
        }

        public static WasFound<T> Is<T>(this WasFound<T> wasFound, Func<T, bool> predicate)
        {
            if(!wasFound)
            {
                return wasFound;
            }

            var exists = predicate(wasFound.Result);
            var result = exists ? wasFound.Result : default;

            return WasFound.From(exists, result);
        }
    }
}
