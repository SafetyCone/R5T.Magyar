using System;
using System.Collections.Generic;


namespace R5T.Magyar
{
    public static class LinqHelper
    {
        public static bool IsDefault<T>(T value)
        {
            var isDefault = EqualityComparer<T>.Default.Equals(value, default);
            return isDefault;
        }

        public static bool IsNotDefault<T>(T value)
        {
            var isDefault = LinqHelper.IsDefault(value);
            return !isDefault;
        }
    }
}
