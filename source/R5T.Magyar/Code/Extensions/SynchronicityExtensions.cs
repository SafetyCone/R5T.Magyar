using System;

using R5T.Magyar;


namespace System
{
    public static class SynchronicityExtensions
    {
        public static bool IsSynchronous(this Synchronicity synchronicity)
        {
            var output = synchronicity == Synchronicity.Synchronous;
            return output;
        }
    }
}
