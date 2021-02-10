using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace R5T.Magyar
{
    public static class IEnumerableExtensions
    {
        public static IEnumerable<T> Append<T>(this IEnumerable<T> enumerable, T value)
        {
            foreach (var item in enumerable)
            {
                yield return item;
            }

            yield return value;
        }

        public static IEnumerable<T> ExceptLast<T>(this IEnumerable<T> enumerable)
        {
            var output = enumerable.ExceptLast(1);
            return output;
        }

        public static IEnumerable<T> ExceptLast<T>(this IEnumerable<T> enumerable, int nElements)
        {
            var count = enumerable.Count();

            var enumerator = enumerable.GetEnumerator();
            for (int iElement = nElements; iElement < count; iElement++) // For each except the last N.
            {
                enumerator.MoveNext();

                yield return enumerator.Current;
            }
        }

        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            foreach (var item in enumerable)
            {
                action(item);
            }
        }

        public static bool IsEmpty<T>(this IEnumerable<T> enumerable)
        {
            var count = enumerable.Count();

            var isEmpty = count < 1;
            return isEmpty;
        }

        /// <summary>
        /// Get the Nth-to-last element.
        /// N starts at 1st-to-last is the last.
        /// Problematic evaluation of the enumerable (ToArray).
        /// </summary>
        public static T NthToLast<T>(this IEnumerable<T> enumerable, int nth)
        {
            var array = enumerable.ToArray();

            var secondToLast = array[array.Length - nth];
            return secondToLast;
        }

        public static T SecondToLast<T>(this IEnumerable<T> enumerable)
        {
            var output = enumerable.NthToLast(2);
            return output;
        }
    }
}

// Functionality placed in the LINQ namespace since including a reference to Magyar is enough to indicate desire to use this functionality.
namespace System.Linq
{
    using R5T.Magyar;


    public static class IEnumerableExtensions
    {
        public static IEnumerable<T> FirstN<T>(this IEnumerable<T> enumerable, int nElements)
        {
            return enumerable.Take(nElements);
        }

        public static T MaxOrDefault<T>(this IEnumerable<T> enumerable, T defaultValue)
        {
            var maxOrDefault = enumerable.Any()
                ? enumerable.Max()
                : defaultValue;

            return maxOrDefault;
        }

        public static T MaxOrDefault<T>(this IEnumerable<T> enumerable)
        {
            var maxOrDefault = enumerable.MaxOrDefault(default);
            return maxOrDefault;
        }

        public static T MinOrDefault<T>(this IEnumerable<T> enumerable, T defaultValue)
        {
            var minOrDefault = enumerable.Any()
                ? enumerable.Min()
                : defaultValue;

            return minOrDefault;
        }

        public static T MinOrDefault<T>(this IEnumerable<T> enumerable)
        {
            var minOrDefault = enumerable.MinOrDefault(default);
            return minOrDefault;
        }

        // Note, adapted from: https://github.com/morelinq/MoreLINQ/
        public static T MaximumBy<T, TKey>(this IEnumerable<T> enumerable, Func<T, TKey> keySelector, IComparer<TKey> keyComparer)
        {
            var comparer = keyComparer ?? Comparer<TKey>.Default;

            using (var enumerator = enumerable.GetEnumerator())
            {
                if (!enumerator.MoveNext())
                {
                    throw new InvalidOperationException("Enumerable contains no elements.");
                }

                var maximum = enumerator.Current;
                var maximumKey = keySelector(maximum);

                while (enumerator.MoveNext())
                {
                    var candidate = enumerator.Current;
                    var candidateKey = keySelector(candidate);
                    if (comparer.Compare(candidateKey, maximumKey) > 0)
                    {
                        maximum = candidate;
                        maximumKey = candidateKey;
                    }
                }

                return maximum;
            }
        }

        public static T MaximumBy<T, TKey>(this IEnumerable<T> enumerable, Func<T, TKey> keySelector)
        {
            var maximum = enumerable.MaximumBy(keySelector, null);
            return maximum;
        }

        // Note, adapted from: https://github.com/morelinq/MoreLINQ/
        public static T MinimumBy<T, TKey>(this IEnumerable<T> enumerable, Func<T, TKey> keySelector, IComparer<TKey> keyComparer)
        {
            var comparer = keyComparer ?? Comparer<TKey>.Default;

            using (var enumerator = enumerable.GetEnumerator())
            {
                if (!enumerator.MoveNext())
                {
                    throw new InvalidOperationException("Enumerable contains no elements.");
                }

                var minimum = enumerator.Current;
                var minimumKey = keySelector(minimum);

                while (enumerator.MoveNext())
                {
                    var candidate = enumerator.Current;
                    var candidateKey = keySelector(candidate);
                    if (comparer.Compare(candidateKey, minimumKey) < 0)
                    {
                        minimum = candidate;
                        minimumKey = candidateKey;
                    }
                }

                return minimum;
            }
        }

        public static T MinimumBy<T, TKey>(this IEnumerable<T> enumerable, Func<T, TKey> keySelector)
        {
            var minimum = enumerable.MinimumBy(keySelector, null);
            return minimum;
        }

        public static IEnumerable<TResult> SelectIncludeNulls<T, TResult>(this IEnumerable<T> items, Func<T, TResult> selector, bool includeNulls = false)
            where TResult: class
        {
            var selectedItemsWithNull = items
                .Select(selector);

            if(includeNulls)
            {
                return selectedItemsWithNull;
            }
            else
            {
                var selectedItemsWithoutNull = selectedItemsWithNull
                    .Where(x => NullHelper.NotNull(x));

                return selectedItemsWithoutNull;
            }
        }

        public static async Task<bool> SequenceEqualAsync<T>(this IEnumerable<T> x, IEnumerable<T> y, IEqualityComparer<T> equalityComparer, Func<string, Task> messageHandler, bool stopAtFirstElementDifference = true)
        {
            var areEqual = true;

            int xCount = 0;
            int yCount = 0;

            using (var xEnumerator = x.GetEnumerator())
            using (var yEnumerator = y.GetEnumerator())
            {
                while (xEnumerator.MoveNext())
                {
                    xCount++;

                    var otherHasElement = yEnumerator.MoveNext();
                    if (!otherHasElement)
                    {
                        var message = $"Sequence element count difference:\nX:{xCount}\nY:{yCount}";
                        await messageHandler(message);

                        return false; // Cannot continue comparing values because one is different!
                    }
                    yCount++;

                    var elementsAreEqual = equalityComparer.Equals(xEnumerator.Current, yEnumerator.Current);
                    if(!elementsAreEqual)
                    {
                        var message = $"Element difference at index {xCount - 1}:\nX:\n{xEnumerator.Current.ToString()}\nY:\n{yEnumerator.Current.ToString()}";
                        await messageHandler(message);

                        areEqual = false;

                        if (stopAtFirstElementDifference)
                        {
                            return false;
                        }
                    }
                }
            }

            return areEqual;
        }

        public static async Task<bool> SetEqualAsync<T>(this IEnumerable<T> x, IEnumerable<T> y, IEqualityComparer<T> equalityComparer, Func<string, Task> messageHandler)
        {
            var missingFromX = y.Except(x, equalityComparer).ToList();
            var missingFromY = x.Except(y, equalityComparer).ToList();

            var anyMissingFromX = missingFromX.Any();
            var anyMissingFromY = missingFromY.Any();

            var setEquals = !anyMissingFromX && !anyMissingFromY;
            if (!setEquals)
            {
                var missingFromXBuilder = new StringBuilder();
                var missingFromYBuilder = new StringBuilder();

                if (anyMissingFromX)
                {
                    var message = $"Elements were missing from X. Count: {missingFromX.Count}";
                    await messageHandler(message);

                    foreach (var element in missingFromX)
                    {
                        missingFromXBuilder.Append($"\n{element.ToString()}");
                    }
                }

                if (anyMissingFromY)
                {
                    var message = $"Elements were missing from Y. Count: {missingFromY.Count}";
                    await messageHandler(message);

                    foreach (var element in missingFromY)
                    {
                        missingFromYBuilder.Append($"\n{element.ToString()}");
                    }
                }

                // Separated to allow message output order.

                if (anyMissingFromX)
                {
                    var missingFromXMessage = missingFromXBuilder.ToString();

                    var message = $"Elements missing from X:\n{missingFromXMessage}";
                    await messageHandler(message);
                }

                if (anyMissingFromY)
                {
                    var missingFromYMessage = missingFromYBuilder.ToString();

                    var message = $"Elements missing from Y:\n{missingFromYMessage}";
                    await messageHandler(message);
                }
            }
            
            return setEquals;
        }
    }
}
