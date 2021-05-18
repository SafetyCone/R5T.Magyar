using System;


namespace R5T.Magyar
{
    public static class NullHelper
    {
        public const string StandardStringRepresentation = "<null>";


        public static bool IsNullStandardStringRepresention(string value)
        {
            var output = value == NullHelper.StandardStringRepresentation;
            return output;
        }

        public static bool IsNull<T>(T value)
            where T : class
        {
            var notNull = value is null;
            return notNull;
        }

        public static bool NotNull<T>(T value)
            where T : class
        {
            var notNull = value != null;
            return notNull;
        }
    }
}
