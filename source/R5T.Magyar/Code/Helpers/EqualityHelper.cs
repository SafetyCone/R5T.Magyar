using System;


namespace System
{
    public static class EqualityHelper
    {
        public static bool NullHandling<T>(T a, T b)
            where T : class
        {
            var output = a is null
                ? b is null
                : b is object
                ;

            return output;
        }

        public static bool NullHandling<T>(T a, T b, Func<T, T, bool> equalMemberValues)
            where T : class
        {
            var output = a is null
                ? b is null
                : b is object
                    && equalMemberValues(a, b)
                ;

            return output;
        }
    }
}
