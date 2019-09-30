using System;


namespace R5T.Magyar
{
    public static class StringHelper
    {
        public const string Invalid = null;

        /// <summary>
        /// The return value of the <see cref="String.IndexOf(string)"/> method when the search string is not found.
        /// </summary>
        public const int IndexOfNotFound = -1;


        /// <summary>
        /// Useful for testing the return value of the <see cref="String.IndexOf(string)"/> method to see if the search string was found.
        /// </summary>
        public static bool IsFound(int index)
        {
            var isFound = index != StringHelper.IndexOfNotFound;
            return isFound;
        }

        public static bool IsValid(string value)
        {
            var output = value != StringHelper.Invalid;
            return output;
        }
    }
}
