using System;
using System.Collections.Generic;


namespace System
{
    using R5T.Magyar;


    public static class BooleanExtensions
    {
        public static void Invert<TKey>(this Dictionary<TKey, bool> dictionary)
        {
            foreach (var key in dictionary.Keys)
            {
                var value = dictionary[key];

                dictionary[key] = !value;
            }
        }

        public static bool Invert(this bool value)
        {
            var output = !value;
            return output;
        }

        public static string YesOrNo(this bool value)
        {
            var output = value
                ? Words.Yes
                : Words.No;

            return output;
        }
    }
}


namespace R5T.Magyar
{
    public static class BooleanExtensions
    {
        public static bool ValueOrFalse(this bool? nullableValue)
        {
            if (nullableValue.HasValue)
            {
                return nullableValue.Value;
            }
            else
            {
                return false;
            }
        }
    }
}


namespace R5T.Magyar.Extensions
{
    public static class BooleanExtensions
    {
        public static string ToStringAllCapitals(this bool value)
        {
            var representation = value
                ? "TRUE"
                : "FALSE"
                ;
            return representation;
        }
    }
}
