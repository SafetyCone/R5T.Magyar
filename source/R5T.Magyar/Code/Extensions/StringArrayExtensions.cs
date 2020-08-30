using System;


namespace R5T.Magyar.Extensions
{
    public static class StringArrayExtensions
    {
        /// <summary>
        /// Note, this functionality already exists in BCL as <see cref="String.Join(string, object[])"/>.
        /// </summary>
        public static string Join(this string[] values, string separator)
        {
            var output = String.Join(separator, values);
            return output;
        }

        public static string Join(this string[] values, char separator)
        {
            var output = values.Join(separator.ToString());
            return output;
        }
    }
}
