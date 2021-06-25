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

        public static EnumerableWrapper<T> Wrap<T>(this IEnumerable<T> enumerable)
        {
            var wrapper = EnumerableWrapper.From(enumerable);
            return wrapper;
        }
    }
}

namespace System.Collections.Generic
{
    using R5T.Magyar;


    public static class IEnumerableExtensions
    {
        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            foreach (var item in enumerable)
            {
                action(item);
            }
        }

        public static async Task ForEach<T>(this IEnumerable<T> enumerable, Func<T, Task> action)
        {
            foreach (var item in enumerable)
            {
                await action(item);
            }
        }

        /// <summary>
        /// Get all repeated elements (including all elements in each series of repeats).
        /// </summary>
        public static IEnumerable<T> GetRepeatedElements<T>(this IEnumerable<T> enumerable, IEqualityComparer<T> equalityComparer)
        {
            // Based on: https://stackoverflow.com/questions/2127406/get-non-distinct-elements-from-an-ienumerable
            return enumerable
                .GroupBy(x => x, equalityComparer)
                .Where(group => group.Count() > 1)
                .SelectMany(x => x);
        }

        /// <summary>
        /// Get one of each repeated element.
        /// </summary>
        public static IDistinctEnumerable<T> GetDistinctRepeatedElements<T>(this IEnumerable<T> enumerable, IEqualityComparer<T> equalityComparer)
        {
            return enumerable
                .GetRepeatedElements(equalityComparer)
                .ToDistinct(equalityComparer); // No repeats among the non-distinct elements.
        }

        public static Dictionary<TValue, TValue> ToDictionarySameKeyAndValue<TValue>(this IEnumerable<TValue> enumerable)
        {
            return enumerable.ToDictionary(
                x => x,
                x => x);
        }

        #region Distinct

        public static IDistinctEnumerable<T> AsDistinct<T>(this IEnumerable<T> enumerable)
        {
            return enumerable.Wrap();
        }

        public static IDistinctEnumerable<T> ToDistinct<T>(this IEnumerable<T> enumerable, IEqualityComparer<T> equalityComparer)
        {
            return enumerable
                .Distinct(equalityComparer)
                .Wrap();
        }

        public static IDistinctEnumerable<T> ToDistinct<T>(this IEnumerable<T> enumerable)
        {
            return enumerable.ToDistinct(EqualityComparer<T>.Default);
        }

        public static bool IsDistinct<T>(this IEnumerable<T> enumerable, IEqualityComparer<T> equalityComparer)
        {
            var distinctEnumerable = enumerable.ToDistinct(equalityComparer);

            // If both the distinct and the input enumerable have the same number of elements, the input enumerable is distinct.
            var isDistinct = distinctEnumerable.Count() == enumerable.Count();
            return isDistinct;
        }

        public static bool IsDistinct<T>(this IEnumerable<T> enumerable)
        {
            return enumerable.IsDistinct(EqualityComparer<T>.Default);
        }

        public static IDistinctEnumerable<T> VerifyDistinct<T>(this IEnumerable<T> enumerable, IEqualityComparer<T> equalityComparer)
        {
            var isDistinct = enumerable.IsDistinct(equalityComparer);
            if (!isDistinct)
            {
                throw new ArgumentException("Enumerable was not distinct.");
            }

            return enumerable.Wrap();
        }

        public static IDistinctEnumerable<T> VerifyDistinct<T>(this IEnumerable<T> enumerable)
        {
            return enumerable.VerifyDistinct(EqualityComparer<T>.Default);
        }

        public static IDistinctEnumerable<T> EnsureDistinct<T>(this IEnumerable<T> enumerable, IEqualityComparer<T> equalityComparer)
        {
            var distinctEnumerable = enumerable.ToDistinct(equalityComparer);
            return distinctEnumerable;
        }

        public static IDistinctEnumerable<T> EnsureDistinct<T>(this IEnumerable<T> enumerable)
        {
            return enumerable.EnsureDistinct(EqualityComparer<T>.Default);
        }

        #endregion

        #region Sorted Ascending

        public static ISortedAscendingEnumerable<T> ToSortedAscending<T>(this IEnumerable<T> enumerable, IComparer<T> comparer)
        {
            return enumerable
                .OrderBy(x => x, comparer)
                .Wrap();
        }

        public static ISortedAscendingEnumerable<T> ToSortedAscending<T>(this IEnumerable<T> enumerable)
        {
            return enumerable.ToSortedAscending(Comparer<T>.Default);
        }

        public static bool IsSortedAscending<T>(this IEnumerable<T> enumerable, IComparer<T> comparer, IEqualityComparer<T> equalityComparer)
        {
            var sortedEnumerable = enumerable.ToSortedAscending(comparer);

            var areEqual = enumerable.SequenceEqual(sortedEnumerable, equalityComparer);
            return areEqual;
        }

        public static bool IsSortedAscending<T>(this IEnumerable<T> enumerable)
        {
            return enumerable.IsSortedAscending(Comparer<T>.Default, EqualityComparer<T>.Default);
        }

        public static ISortedAscendingEnumerable<T> VerifySortedAscending<T>(this IEnumerable<T> enumerable, IComparer<T> comparer, IEqualityComparer<T> equalityComparer)
        {
            var isSortedAscending = enumerable.IsSortedAscending(comparer, equalityComparer);
            if (!isSortedAscending)
            {
                throw new ArgumentException("Enumerable was not sorted in ascending order.");
            }

            return enumerable.Wrap();
        }

        public static ISortedAscendingEnumerable<T> VerifySortedAscending<T>(this IEnumerable<T> enumerable)
        {
            return enumerable.VerifySortedAscending(Comparer<T>.Default, EqualityComparer<T>.Default);
        }

        public static ISortedAscendingEnumerable<T> EnsureSortedAscending<T>(this IEnumerable<T> enumerable, IComparer<T> _0, IEqualityComparer<T> _1)
        {
            var sortedAscendingEnumerable = enumerable.ToSortedAscending();
            return sortedAscendingEnumerable;
        }

        public static ISortedAscendingEnumerable<T> EnsureSortedAscending<T>(this IEnumerable<T> enumerable)
        {
            return enumerable.EnsureSortedAscending(Comparer<T>.Default, EqualityComparer<T>.Default);
        }

        #endregion

        #region Sorted Descending

        public static ISortedDescendingEnumerable<T> ToSortedDescending<T>(this IEnumerable<T> enumerable, IComparer<T> comparer)
        {
            return enumerable
                .OrderByDescending(x => x, comparer)
                .Wrap();
        }

        public static ISortedDescendingEnumerable<T> ToSortedDescending<T>(this IEnumerable<T> enumerable)
        {
            return enumerable.ToSortedDescending(Comparer<T>.Default);
        }

        public static bool IsSortedDescending<T>(this IEnumerable<T> enumerable, IComparer<T> comparer, IEqualityComparer<T> equalityComparer)
        {
            var sortedEnumerable = enumerable.ToSortedDescending(comparer);

            var areEqual = enumerable.SequenceEqual(sortedEnumerable, equalityComparer);
            return areEqual;
        }

        public static bool IsSortedDescending<T>(this IEnumerable<T> enumerable)
        {
            return enumerable.IsSortedDescending(Comparer<T>.Default, EqualityComparer<T>.Default);
        }

        public static ISortedDescendingEnumerable<T> VerifySortedDescending<T>(this IEnumerable<T> enumerable, IComparer<T> comparer, IEqualityComparer<T> equalityComparer)
        {
            var isSortedDescending = enumerable.IsSortedDescending(comparer, equalityComparer);
            if (!isSortedDescending)
            {
                throw new ArgumentException("Enumerable was not sorted in descending order.");
            }

            return enumerable.Wrap();
        }

        public static ISortedDescendingEnumerable<T> VerifySortedDescending<T>(this IEnumerable<T> enumerable)
        {
            return enumerable.VerifySortedDescending(Comparer<T>.Default, EqualityComparer<T>.Default);
        }

        public static ISortedDescendingEnumerable<T> EnsureSortedDescending<T>(this IEnumerable<T> enumerable, IComparer<T> _0, IEqualityComparer<T> _1)
        {
            var sortedDescendingEnumerable = enumerable.ToSortedDescending();
            return sortedDescendingEnumerable;
        }

        public static ISortedDescendingEnumerable<T> EnsureSortedDescending<T>(this IEnumerable<T> enumerable)
        {
            return enumerable.EnsureSortedDescending(Comparer<T>.Default, EqualityComparer<T>.Default);
        }

        #endregion

        #region Sorted

        /// <summary>
        /// Chooses ascending is the default sort order.
        /// </summary>
        public static ISortedEnumerable<T> ToSorted<T>(this IEnumerable<T> enumerable, IComparer<T> _)
        {
            return enumerable.ToSortedAscending();
        }

        /// <summary>
        /// Chooses ascending as the default sort order.
        /// </summary>
        public static ISortedEnumerable<T> ToSorted<T>(this IEnumerable<T> enumerable)
        {
            return enumerable.ToSorted(Comparer<T>.Default);
        }

        /// <summary>
        /// Chooses sorted ascending as the default sort order.
        /// </summary>
        public static bool IsSorted<T>(this IEnumerable<T> enumerable, IComparer<T> comparer, IEqualityComparer<T> equalityComparer)
        {
            return enumerable.Wrap().IsSortedAscending(comparer, equalityComparer);
        }

        /// <summary>
        /// Chooses sorted ascending as the default sort order.
        /// </summary>
        public static bool IsSorted<T>(this IEnumerable<T> enumerable)
        {
            return enumerable.Wrap().IsSortedAscending();
        }

        /// <summary>
        /// Chooses sorted ascending as the default sort order.
        /// </summary>
        public static ISortedEnumerable<T> VerifySorted<T>(this IEnumerable<T> enumerable, IComparer<T> comparer, IEqualityComparer<T> equalityComparer)
        {
            return enumerable.Wrap().VerifySortedAscending(comparer, equalityComparer);
        }

        /// <summary>
        /// Chooses sorted ascending as the default sort order.
        /// </summary>
        public static ISortedEnumerable<T> VerifySorted<T>(this IEnumerable<T> enumerable)
        {
            return enumerable.Wrap().VerifySortedAscending();
        }

        /// <summary>
        /// Chooses sorted ascending as the default sort order.
        /// </summary>
        public static ISortedEnumerable<T> EnsureSorted<T>(this IEnumerable<T> enumerable, IComparer<T> comparer, IEqualityComparer<T> equalityComparer)
        {
            return enumerable.Wrap().EnsureSortedAscending(comparer, equalityComparer);
        }

        /// <summary>
        /// Chooses sorted ascending as the default sort order.
        /// </summary>
        public static ISortedEnumerable<T> EnsureSorted<T>(this IEnumerable<T> enumerable)
        {
            return enumerable.Wrap().EnsureSortedAscending();
        }

        #endregion
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
                        var message = $"Element difference at index {xCount - 1}:\nX:\n{xEnumerator.Current}\nY:\n{yEnumerator.Current}";
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
                        missingFromXBuilder.Append($"\n{element}");
                    }
                }

                if (anyMissingFromY)
                {
                    var message = $"Elements were missing from Y. Count: {missingFromY.Count}";
                    await messageHandler(message);

                    foreach (var element in missingFromY)
                    {
                        missingFromYBuilder.Append($"\n{element}");
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

        public static IEnumerable<T> SkipFirst<T>(this IEnumerable<T> enumerable)
        {
            var output = enumerable.Skip(1);
            return output;
        }
    }
}
