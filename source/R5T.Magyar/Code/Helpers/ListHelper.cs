using System;
using System.Collections.Generic;


namespace System
{
    public static class ListHelper
    {
        public static IList<T> From<T>(T value)
        {
            return new[] { value };
        }
    }
}
