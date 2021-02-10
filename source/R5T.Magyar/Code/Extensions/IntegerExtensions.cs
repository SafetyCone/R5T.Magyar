using System;


namespace R5T.Magyar.Extensions
{
    public static class IntegerExtensions
    {
        public static bool AnyPositive(this int value)
        {
            var anyPositive = value > 0;
            return anyPositive;
        }

        public static bool Any(this int value)
        {
            var any = value.AnyPositive();
            return any;
        }
    }
}
