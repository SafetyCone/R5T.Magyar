using System;


namespace System.Collections.Generic
{
    public static class ListHelper
    {
        public static IList<T> From<T>(T value)
        {
            return new[] { value };
        }
    }
}
