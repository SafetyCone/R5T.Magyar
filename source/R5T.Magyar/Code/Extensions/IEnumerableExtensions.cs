using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace R5T.Magyar
{
    public static class IEnumerableExtensions
    {
        public static IEnumerable<T> Append2<T>(this IEnumerable<T> enumerable, T value)
        {
            foreach (var item in enumerable)
            {
                yield return item;
            }

            yield return value;
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
            var enumerableCount = enumerable.Count();
            var distinctEnumerableCount = distinctEnumerable.Count();

            var isDistinct = distinctEnumerableCount == enumerableCount;
            return isDistinct;
        }

        public static bool IsDistinct<T>(this IEnumerable<T> enumerable)
        {
            return enumerable.IsDistinct(EqualityComparer<T>.Default);
        }

        /// <summary>
        /// Named with -Enumerable to allow resolution of ambiguous IList.VerifyDistinct() vs. IEnumerable.VerifyDistinct() when required.
        /// </summary>
        public static IDistinctEnumerable<T> VerifyDistinctEnumerable<T>(this IEnumerable<T> enumerable, IEqualityComparer<T> equalityComparer)
        {
            var isDistinct = enumerable.IsDistinct(equalityComparer);
            if (!isDistinct)
            {
                throw new ArgumentException("Enumerable was not distinct.");
            }

            return enumerable.Wrap();
        }

        public static IDistinctEnumerable<T> VerifyDistinct<T>(this IEnumerable<T> enumerable, IEqualityComparer<T> equalityComparer)
        {
            return enumerable.VerifyDistinctEnumerable(equalityComparer);
        }

        /// <summary>
        /// Named with -Enumerable to allow resolution of ambiguous IList.VerifyDistinct() vs. IEnumerable.VerifyDistinct() when required.
        /// </summary>
        public static IDistinctEnumerable<T> VerifyDistinctEnumerable<T>(this IEnumerable<T> enumerable)
        {
            return enumerable.VerifyDistinctEnumerable(EqualityComparer<T>.Default);
        }

        public static IDistinctEnumerable<T> VerifyDistinct<T>(this IEnumerable<T> enumerable)
        {
            return enumerable.VerifyDistinctEnumerable();
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
        public static bool AnyDuplicates<T>(this IEnumerable<T> items)
        {
            var anyDuplicates = items.GetDuplicates().Any();
            return anyDuplicates;
        }

        public static IEnumerable<T> GetDistinct_KeepFirst<T>(this IEnumerable<T> items, IEqualityComparer<T> equalityComparer)
        {
            var hash = new HashSet<T>(equalityComparer);
            foreach (var item in items)
            {
                if(hash.Contains(item))
                {
                    continue;
                }
                // Else

                hash.Add(item);

                yield return item;
            }
        }

        public static IEnumerable<T> GetDistinct_KeepFirst<T>(this IEnumerable<T> items)
        {
            var output = items.GetDistinct_KeepFirst(EqualityComparer<T>.Default);
            return output;
        }

        public static IEnumerable<T> GetDistinct_KeepLast<T>(this IEnumerable<T> items, IEqualityComparer<T> equalityComparer)
        {
            var hash = new HashSet<T>(equalityComparer);

            hash.AddRangeKeepLast(items);

            return hash;
        }

        public static IEnumerable<T> GetDistinct_KeepLast<T>(this IEnumerable<T> items)
        {
            var output = items.GetDistinct_KeepLast(EqualityComparer<T>.Default);
            return output;
        }

        /// <summary>
        /// Chooses <see cref="GetDistinct_KeepFirst{T}(IEnumerable{T}, IEqualityComparer{T})"/> as the default.
        /// </summary>
        public static IEnumerable<T> GetDistinct<T>(this IEnumerable<T> items, IEqualityComparer<T> equalityComparer)
        {
            var output = items.GetDistinct_KeepFirst(equalityComparer);
            return output;
        }

        /// <summary>
        /// Chooses <see cref="GetDistinct_KeepFirst{T}(IEnumerable{T})"/> as the default.
        /// </summary>
        public static IEnumerable<T> GetDistinct<T>(this IEnumerable<T> items)
        {
            var output = items.GetDistinct_KeepFirst();
            return output;
        }

        public static IEnumerable<T> GetDuplicates<T>(this IEnumerable<T> items)
        {
            var output = items
                .GroupBy(item => item)
                .Where(group => group.Count() > 1)
                .Select(group => group.Key)
                ;

            return output;
        }

        public static WasFound<T[]> AnyMissing<T>(this IEnumerable<T> required, IEnumerable<T> available)
        {
            var theMissing = required.Except(available).ToArray();

            var anyMissing = theMissing.Any();

            var output = WasFound.From(anyMissing, theMissing);
            return output;
        }

        public static IEnumerable<T> Append<T>(this IEnumerable<T> enumerable, IEnumerable<T> appendix)
        {
            return enumerable.Concat(appendix);
        }

        public static IEnumerable<T> Append<T>(this IEnumerable<T> enumerable, params T[] appendix)
        {
            return enumerable.Concat(appendix);
        }

        public static IEnumerable<T> AppendRange<T>(this IEnumerable<T> enumerable, IEnumerable<T> appendix)
        {
            return enumerable.Concat(appendix);
        }

        public static bool AreUnique<T>(this IEnumerable<T> items)
        {
            var itemCount = items.Count();

            var uniqueItemCount = items.Distinct().Count();

            var output = uniqueItemCount == itemCount;
            return output;
        }

        public static IDistinctList<T> AsDistinctList<T>(this IEnumerable<T> enumerable)
        {
            var output = new DistinctList<T>(enumerable);
            return output;
        }

        public static IDistinctList<T> AsDistinctList<T>(this IEnumerable<T> enumerable, IEqualityComparer<T> equalityComparer)
        {
            var output = new DistinctList<T>(enumerable, equalityComparer);
            return output;
        }

        public static bool ContainsAll<T>(this IEnumerable<T> superset, IEnumerable<T> subset)
        {
            var output = subset.Except(superset).None_OLD();
            return output;
        }

        /// <summary>
        /// Returns an empty enumerable if the input enumerable has the default IEnumerable&lt;T&gt; value.
        /// The default for an IEnumerable&lt;T&gt; is null. This can cause problems with null reference exceptions.
        /// This method allows easily providing an empty enumerable if the input is default (with the drawback that you have to remember to use it).
        /// </summary>
        public static IEnumerable<T> EmptyIfDefault<T>(this IEnumerable<T> items)
        {
            var itemsIsDefault = items == default;

            var output = itemsIsDefault
                ? Enumerable.Empty<T>()
                : items
                ;

            return output;
        }

        /// <summary>
        /// Selects array as the preferred data structure for an evaluated enumerable.
        /// </summary>
        public static T[] Evaluate<T>(this IEnumerable<T> items)
        {
            var output = items.ToArray();
            return output;
        }

        public static IEnumerable<T> Except<T>(this IEnumerable<T> items, T item)
            where T : IEquatable<T>
        {
            var output = items.Where(x => !x.Equals(item));
            return output;
        }

        public static IEnumerable<T> Except<T>(this IEnumerable<T> items, T item, IEqualityComparer<T> equalityComparer)
        {
            var output = items.Where(x => !equalityComparer.Equals(x, item));
            return output;
        }

        /// <summary>
        /// Same as where, except that the output contains values where the predicate is false.
        /// </summary>
        public static IEnumerable<T> ExceptWhere<T>(this IEnumerable<T> items, Func<T, bool> predicate)
        {
            var output = items
                .Where(x => !predicate(x))
                ;

            return output;
        }

        public static IEnumerable<T> ExceptFirst<T>(this IEnumerable<T> enumerable)
        {
            var output = enumerable.Skip(1);
            return output;
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

        public static T[] FindArray<T>(this IEnumerable<T> items, Func<T, bool> predicate)
        {
            var filteredItems = items
                .Where(predicate)
                .ToArray();

            return filteredItems;
        }

        public static WasFound<T> FindSingleByValue<T>(this IEnumerable<T> items, T value)
            where T : IEquatable<T>
        {
            var itemOrDefault = items
                .Where(xItem => xItem.Equals(value))
                .SingleOrDefault();

            var output = WasFound.From(itemOrDefault);
            return output;
        }

        public static IEnumerable<T> FirstN<T>(this IEnumerable<T> enumerable, int nElements)
        {
            return enumerable.Take(nElements);
        }

        public static void For<T>(this IEnumerable<T> enumerable, Action<T, int> actionWithIndex)
        {
            var index = 0;
            foreach (var item in enumerable)
            {
                actionWithIndex(item, index);

                index++;
            }
        }

        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            foreach (var item in enumerable)
            {
                action(item);
            }
        }

        /// <summary>
        /// Counter starts at one by default (unlike index, which starts at zero by default).
        /// </summary>
        public static void ForEach_WithCounter<T>(this IEnumerable<T> enumerable, Action<T, int> action_WithCounter)
        {
            var counter = 1;
            foreach (var item in enumerable)
            {
                action_WithCounter(item, counter);

                counter++;
            }
        }

        public static async Task ForEach<T>(this IEnumerable<T> enumerable, Func<T, Task> action)
        {
            foreach (var item in enumerable)
            {
                await action(item);
            }
        }

        public static IEnumerable<T> FromIndex<T>(this IEnumerable<T> enumerable, int startIndexInclusive)
        {
            var output = enumerable.Skip(startIndexInclusive);
            return output;
        }

        public static IEnumerable<T> FromIndex<T>(this IEnumerable<T> enumerable, int startIndexInclusive, int endIndexInclusive)
        {
            var takeCount = endIndexInclusive - startIndexInclusive + 1;

            var output = enumerable.FromIndex(startIndexInclusive).Take(takeCount);
            return output;
        }

        public static Dictionary<T, int> GetIndexByItem<T>(this IEnumerable<T> elements)
        {
            var count = 0;

            var output = elements
                .ToDictionary(
                    x => x,
                    x => count++);

            return output;
        }

        public static WasFound<T> GetPostAlphabeticalElement<T>(this IEnumerable<T> elements, Func<T, string> keySelector, string key)
        {
            var element = elements
                .OrderAlphabetically(keySelector)
                .Where(x => StringHelper.IsGreaterThan(keySelector(x), key))
                .FirstOrDefault()
                ;

            var wasFound = WasFound.From(element);
            return wasFound;
        }

        public static WasFound<T> GetPriorAlphabeticalElement<T>(this IEnumerable<T> elements, Func<T, string> keySelector, string key)
        {
            var element = elements
                .OrderAlphabetically(keySelector)
                .Where(x => StringHelper.IsLessThan(keySelector(x), key))
                .LastOrDefault()
                ;

            var wasFound = WasFound.From(element);
            return wasFound;
        }

        /// <inheritdoc cref="IListExtensions.GetTrailingAppendix{T}(IList{T}, IList{T})"/>
        public static IEnumerable<T> GetTrailingAppendix<T>(this IEnumerable<T> elements,
            IEnumerable<T> otherElements)
        {
            var output = elements.Now_OLD().GetTrailingAppendix(otherElements.Now_OLD());
            return output;
        }

        /// <summary>
        /// Returns the elements in <paramref name="elements"/> that are after the last common element in other elements.
        /// Example: elements [A, B, C, E] with other elements [A, B, D, E] would return [C, E]. This is not just a set complement.
        /// </summary>
        public static IEnumerable<T> GetTrailingComplement<T>(this IEnumerable<T> elements,
            IEnumerable<T> otherElements)
        {
            var equalityComparer = EqualityComparer<T>.Default;

            var elementsEnumerator = elements.GetEnumerator();
            var otherElementsEnumerator = otherElements.GetEnumerator();

            // Determine how many elements to skip. Stop skipping elements if either enumerable runs out of elements, or at the first element that is not the same.
            var elementsToSkip = 0;
            while(true)
            {
                var elementsCanMoveNext = elementsEnumerator.MoveNext();
                var otherElementsCanMoveNext = otherElementsEnumerator.MoveNext();

                if (elementsCanMoveNext && otherElementsCanMoveNext)
                {
                    var currentElement = elementsEnumerator.Current;
                    var currentOtherElement = otherElementsEnumerator.Current;

                    if(equalityComparer.Equals(currentElement, currentOtherElement))
                    {
                        elementsToSkip++;
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    break;
                }
            }

            var output = elements.Skip(elementsToSkip);
            return output;
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

        public static int LastIndexOf<T>(this IEnumerable<T> enumerable, T value, IEqualityComparer<T> equalityComparer)
        {
            var output = enumerable.LastIndexWhere(x => equalityComparer.Equals(x, value));
            return output;
        }

        public static int LastIndexOf<T>(this IEnumerable<T> enumerable, T value)
        {
            var equalityComparer = EqualityComparer<T>.Default;

            var output = enumerable.LastIndexOf(value, equalityComparer);
            return output;
        }

        /// <summary>
        /// Returns the last index where the predicate is true, else if the predicate is not true for any of the items of the enumerable, returns <see cref="IndexHelper.NotFound"/>.
        /// </summary>
        public static int LastIndexWhere<T>(this IEnumerable<T> enumerable,
            Func<T, bool> predicate)
        {
            var index = IndexHelper.NotFound;

            var counter = 0;
            foreach (var item in enumerable)
            {
                var success = predicate(item);
                if (success)
                {
                    index = counter;
                }

                counter++;
            }

            // Not found.
            return index;
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

        public static bool HasMoreThan<T>(this IEnumerable<T> enumerable, int count, out T[] elements)
        {
            // Take one more than desired, and then test the length of the array.
            var elementsPlusOne = enumerable.Take(count + 1).ToArray();

            var output = elementsPlusOne.Length > count;

            elements = elementsPlusOne.Take(count).ToArray();

            return output;
        }

        public static bool HasMoreThanOne<T>(this IEnumerable<T> items)
        {
            var enumerator = items.GetEnumerator();

            // Ignore the first element.
            enumerator.MoveNext();

            // Return whether there is a second element.
            var output = enumerator.MoveNext();
            return output;
        }

        /// <summary>
        /// Quality-of-life overload for <see cref="HasMoreThanOne{T}(IEnumerable{T})"/>.
        /// </summary>
        public static bool Multiple<T>(this IEnumerable<T> items)
        {
            var output = items.HasMoreThanOne();
            return output;
        }

        /// <summary>
        /// Returns true if there are no entries.
        /// </summary>
        public static bool None_OLD<T>(this IEnumerable<T> enumerable)
        {
            var output = !enumerable.Any();
            return output;
        }

        /// <summary>
        /// Selects array as the preferred data structure for an evaluated enumerable.
        /// </summary>
        public static T[] Now_OLD<T>(this IEnumerable<T> items)
        {
            var output = items.ToArray();
            return output;
        }

        /// <summary>
        /// Returns the first index where the predicate is true, else if the predicate is not true for any of the items of the enumerable, returns <see cref="IndexHelper.NotFound"/>.
        /// </summary>
        public static int IndexWhere<T>(this IEnumerable<T> enumerable,
            Func<T, bool> predicate)
        {
            var index = IndexHelper.NotFound;

            var counter = 0;
            foreach (var item in enumerable)
            {
                var success = predicate(item);
                if (success)
                {
                    return counter;
                }

                counter++;
            }

            // Not found.
            return index;
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

        public static bool OnlyOne<T>(this IEnumerable<T> items)
        {
            var output = items.Count() == 1;
            return output;
        }

        public static IOrderedEnumerable<T> OrderAlphabetically<T>(this IEnumerable<T> items, Func<T, string> keySelector)
        {
            var output = items.OrderBy(keySelector);
            return output;
        }

        public static IEnumerable<T> OrderByDescending<T, TKey>(this IEnumerable<T> items,
            Func<T, TKey> keySelector,
            Comparison<TKey> comparison)
        {
            var output = items.OrderByDescending(
                keySelector,
                new ComparisonBasedComparer<TKey>(comparison));

            return output;
        }

        public static T SecondOrDefault<T>(this IEnumerable<T> items)
        {
            var output = items
                .SkipFirst()
                .FirstOrDefault();

            return output;
        }

        public static T Second<T>(this IEnumerable<T> items)
        {
            var output = items
                .SkipFirst()
                .First();

            return output;
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
                    .Where(x => NullHelper.IsNonNull(x));

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

        public static Dictionary<T, bool> SetContains<T>(this IEnumerable<T> set,
            IEnumerable<T> values)
        {
            // Ensure unique.
            var valuesHash = new HashSet<T>(values);
            var setHash = new HashSet<T>(set);

            var output = valuesHash
                .Select(x => new { Guid = x, SetContains = setHash.Contains(x) })
                .ToDictionary(
                    x => x.Guid,
                    x => x.SetContains);

            return output;
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

        public static IEnumerable<T> TakeFirst<T>(this IEnumerable<T> enumerable)
        {
            var output = enumerable.Take(1);
            return output;
        }

        public static List<T> ToList_HandleDefault<T>(this IEnumerable<T> enumerable)
        {
            var output = enumerable?.ToList() ?? new List<T>();
            return output;
        }

        public static Dictionary<TKey, T[]> ToDictionaryOfArrays<TKey, T>(this IEnumerable<T> enumerable, Func<T, TKey> keySelector)
        {
            var output = enumerable
                .GroupBy(keySelector)
                .ToDictionary(
                    xGroup => xGroup.Key,
                    xGroup => xGroup.ToArray());

            return output;
        }

        public static HashSet<T> Unique<T>(this IEnumerable<T> enumerable)
        {
            var output = new HashSet<T>(enumerable);
            return output;
        }

        public static IEnumerable<IGrouping<TKey, TElement>> WhereDuplicates<TKey, TElement>(this IEnumerable<TElement> elements,
            Func<TElement, TKey> keySelector,
            IEqualityComparer<TKey> equalityComparer)
        {
            var output = elements
                .GroupBy(
                    keySelector,
                    equalityComparer)
                .Where(xGroup => xGroup.Count() > 1)
                ;

            return output;
        }

        public static IEnumerable<IGrouping<TKey, TElement>> WhereDuplicates<TKey, TElement>(this IEnumerable<TElement> elements,
            Func<TElement, TKey> keySelector)
        {
            var output = elements.WhereDuplicates(
                keySelector,
                EqualityComparer<TKey>.Default);

            return output;
        }

        public static IEnumerable<IGrouping<T, T>> WhereDuplicates<T>(this IEnumerable<T> elements)
        {
            var output = elements.WhereDuplicates(
                x => x);

            return output;
        }

        public static IEnumerable<(T1, T2)> ZipWithEqualLengthRequirement<T1, T2>(this IEnumerable<T1> first, IEnumerable<T2> second)
        {
            var firstEnumerator = first.GetEnumerator();
            var secondEnumerator = second.GetEnumerator();

            while(firstEnumerator.MoveNext())
            {
                var secondIsAvailable = secondEnumerator.MoveNext();
                if(!secondIsAvailable)
                {
                    throw new InvalidOperationException("The second enumeration did not have as many elements as the first.");
                }

                yield return (firstEnumerator.Current, secondEnumerator.Current);
            }

            // At this point, we are all out of elements in the first enumeration. We should be out of elements in the second as well.
            var secondIsAvailableAfterFirstIsExhausted = secondEnumerator.MoveNext();
            if(secondIsAvailableAfterFirstIsExhausted)
            {
                throw new InvalidOperationException("The second enumeration had more elements than the first.");
            }
        }
    }
}
