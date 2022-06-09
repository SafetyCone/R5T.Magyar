using System;
using System.Collections.Generic;
using System.Linq;

using R5T.Magyar;


namespace System
{
    public static class WasFoundExtensions
    {
        public static bool AnyWereFound<TKey, TValue>(this IDictionary<TKey, WasFound<TValue>> wasFoundByValue)
        {
            var output = wasFoundByValue
                .Where(xPair => xPair.Value.Exists)
                .Any();

            return output;
        }

        //public static bool SingleWasFound<TKey, TValue>(this IDictionary<TKey, WasFound<TValue>> wasFoundByValue)
        //{
        //    var singleOrDefault = wasFoundByValue
        //        .Where(xPair => xPair.Value.Exists)
        //        .SingleOrDefault();

        //    var output = singleOrDefault != default;

        //    return output;
        //}

        public static bool AnyNotFound<TKey, TValue>(this IDictionary<TKey, WasFound<TValue>> wasFoundByValue)
        {
            var output = wasFoundByValue.Values.AnyNotFound();
            return output;
        }

        public static bool AnyNotFound<T>(this IEnumerable<WasFound<T>> wasFounds)
        {
            var output = wasFounds
                .Where(xWasFound => !xWasFound.Exists)
                .Any();

            return output;
        }

        public static void ExceptionIfNotFound<T>(this WasFound<T> wasFound, string message)
        {
            wasFound.InvalidOperationIfNotFound(message);
        }

        public static IEnumerable<TKey> GetKeysNotFound<TKey, TValue>(this IDictionary<TKey, WasFound<TValue>> wasFoundByValue)
        {
            var output = wasFoundByValue
                .Where(xPair => !xPair.Value.Exists)
                .Select(xPair => xPair.Key)
                ;

            return output;
        }

        public static T GetOrExceptionIfNotFound<T>(this WasFound<T> wasFound, string exceptionMessage)
        {
            wasFound.ExceptionIfNotFound(exceptionMessage);

            var output = wasFound.Result;
            return output;
        }

        public static void InvalidOperationIfNotFound<T>(this WasFound<T> wasFound, string message)
        {
            if(!wasFound)
            {
                throw new InvalidOperationException(message);
            }
        }

        public static bool IsFound<T>(this WasFound<T> wasFound)
        {
            return wasFound.Exists;
        }

        public static bool IsNotFound<T>(this WasFound<T> wasFound)
        {
            var output = !wasFound.Exists;
            return output;
        }

        public static bool NotFound<T>(this WasFound<T> wasFound)
        {
            var output = !wasFound;
            return output;
        }

        public static WasFound<T> OrIfNotFound<T>(this WasFound<T> wasFound,
            Func<T> orIfNotFound)
        {
            var output = wasFound
                ? wasFound
                : WasFound.From(wasFound.Exists, orIfNotFound())
                ;

            return output;
        }

        public static T ResultOrIfNotFound<T>(this WasFound<T> wasFound,
            Func<T> orIfNotFound)
        {
            var output = wasFound
                ? wasFound.Result
                : orIfNotFound()
                ;

            return output;
        }

        public static Dictionary<TKey, TValue> ToDictionaryFromWasFounds<TKey, TValue>(this IDictionary<TKey, WasFound<TValue>> wasFoundByKey)
        {
            var output = wasFoundByKey
                .ToDictionary(
                    xPair => xPair.Key,
                    xPair => xPair.Value.Result);

            return output;
        }
    }
}

namespace System.Linq
{
    public static class WasFoundExtensions
    {
        public static WasFound<T> FindSingle<T>(this IEnumerable<T> items, Func<T, bool> predicate)
        {
            var selectionOrDefault = items
                .Where(predicate)
                .SingleOrDefault();

            var output = WasFound.From(selectionOrDefault);
            return output;
        }

        public static IEnumerable<WasFound<T>> WhereFound<T>(this IEnumerable<WasFound<T>> items)
        {
            var output = items
                .Where(x => x.Exists)
                ;

            return output;
        }

        public static IEnumerable<WasFound<T>> WhereNotFound<T>(this IEnumerable<WasFound<T>> items)
        {
            var output = items
                .Where(x => !x.Exists)
                ;

            return output;
        }
    }
}

namespace R5T.Magyar
{
    public static class WasFoundExtensions
    {
        /// <summary>
        /// Useful in the cases where C# does not realize it should use the implicit conversion operator (such as returning when you need to return a boolean and C# will not accept a WasFound).
        /// </summary>
        public static bool AsBoolean<TResult>(this WasFound<TResult> wasFound)
        {
            return wasFound.Exists;
        }

        public static (bool WasFound, TOutput output) ToTuple<TResult, TOutput>(this WasFound<TResult> wasFound, Func<TResult, TOutput> selector)
        {
            var output = selector(wasFound.Result);

            return (wasFound, output);
        }

        public static WasFound<TDestination> Convert<TSource, TDestination>(this WasFound<TSource> wasFound, Func<TSource, TDestination> converterIfFound)
        {
            if(wasFound)
            {
                var convertedResult = converterIfFound(wasFound.Result);

                var output = WasFound.From(wasFound, convertedResult);
                return output;
            }
            else
            {
                var output = WasFound.From(wasFound, default(TDestination));
                return output;
            }
        }

        /// <summary>
        /// With no converter specified, the default of <typeparamref name="TDestination"/> is returned.
        /// </summary>
        public static WasFound<TDestination> ConvertDefault<TSource, TDestination>(this WasFound<TSource> wasFound)
        {
            TDestination GetDefaultDestination(TSource source)
            {
                return default;
            }

            var output = wasFound.Convert<TSource, TDestination>(GetDefaultDestination);
            return output;
        }

        public static WasFound<TDestination> Convert<TSource, TDestination>(this WasFound<TSource> wasFound)
            where TDestination : class
        {
            TDestination GetDestination(TSource source)
            {
                return source as TDestination;
            }

            var output = wasFound.Convert<TSource, TDestination>(GetDestination);
            return output;
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

        public static void ThrowExceptionIfNotFound<TValue, TException>(this WasFound<TValue> wasFound, Func<string> messageProvider, Func<string, TException> exceptionConstructor)
            where TException : Exception
        {
            if (!wasFound)
            {
                var message = messageProvider();

                var exception = exceptionConstructor(message);
                throw exception;
            }
        }

        public static void ThrowExceptionIfNotFound<TValue, TException>(this WasFound<TValue> wasFound, string message, Func<string, TException> exceptionConstructor)
            where TException : Exception
        {
            wasFound.ThrowExceptionIfNotFound(() => message, exceptionConstructor);
        }

        public static void ThrowArgumentExceptionIfNotFound<TValue>(this WasFound<TValue> wasFound, string message)
        {
            wasFound.ThrowExceptionIfNotFound(message, ArgumentExceptionHelper.New);
        }

        public static void ThrowArgumentExceptionIfNotFound<TValue>(this WasFound<TValue> wasFound, Func<string> messageProvider)
        {
            wasFound.ThrowExceptionIfNotFound(messageProvider, ArgumentExceptionHelper.New);
        }
    }
}
