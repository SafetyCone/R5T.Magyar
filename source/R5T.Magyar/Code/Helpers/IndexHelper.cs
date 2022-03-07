using System;


namespace System
{
    public class IndexHelper
    {
        public const int DefaultStartIndex = 0;
        
        
        public static int One => 1;
        public static int Zero => 0;
        public static int NegativeOne => -1;

        public static int FirstInsertionIndex => 0;
        public static int NotFound => IndexHelper.NegativeOne;


        /// <summary>
        /// Assumes a zero-based first index.
        /// </summary>
        public static bool IsFirstIndex(int index)
        {
            var output = index == IndexHelper.Zero;
            return output;
        }

        public static bool IsFirstInsertionIndex(int index)
        {
            var output = IndexHelper.FirstInsertionIndex == index;
            return output;
        }

        public static bool IsFound(int index)
        {
            var isNotFound = IndexHelper.IsNotFound(index);

            var output = !isNotFound;
            return output;
        }

        public static bool IsLastIndex(
            int index,
            int count)
        {
            var output = index == (count - 1);
            return output;
        }

        public static bool IsNegativeOne(int index)
        {
            var output = IndexHelper.NegativeOne == index;
            return output;
        }

        public static bool IsNotFound(int index)
        {
            var output = IndexHelper.NotFound == index;
            return output;
        }

        public static bool IsZero(int index)
        {
            var output = IndexHelper.Zero == index;
            return output;
        }

        /// <summary>
        /// The last index is simply the count of elements minus one.
        /// NOTE: For zero counts, this will return -1.
        /// </summary>
        public static int LastIndex(int count)
        {
            var output = count - 1;
            return output;
        }

        /// <summary>
        /// The last index at which you could insert is simply the count of elements (one more than the index of the last element).
        /// </summary>
        public static int LastInsertionIndex(int count)
        {
            var output = count;
            return output;
        }
    }
}
