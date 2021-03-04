using System;

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
