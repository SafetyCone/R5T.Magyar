using System;
using System.Collections.Generic;


namespace System
{
    using R5T.Magyar;


    public static class BooleanExtensions
    {
        public static Dictionary<TKey, bool> Invert<TKey>(this Dictionary<TKey, bool> dictionary)
        {
            foreach (var key in dictionary.Keys)
            {
                var value = dictionary[key];

                dictionary[key] = !value;
            }

            return dictionary;
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


namespace System.Linq
{
    public static class BooleanExtensions
    {
        public static bool All(this IEnumerable<bool> booleans)
        {
            foreach (var boolean in booleans)
            {
                if(!boolean)
                {
                    return false;
                }
            }

            return true;
        }

        public static bool AnyTrue(this IEnumerable<bool> booleans)
        {
            foreach (var boolean in booleans)
            {
                if (boolean)
                {
                    return true;
                }
            }

            return false;
        }

        public static bool AnyTrueValues<TKey>(this IDictionary<TKey, bool> dictionary)
        {
            var output = dictionary.Values.AnyTrue();
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
