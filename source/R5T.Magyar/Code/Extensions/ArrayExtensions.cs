using System;


namespace R5T.Magyar.Extensions
{
    public static class ArrayExtensions
    {
        public static T[] Copy<T>(this T[] array)
        {
            var output = ArrayHelper.Copy(array);
            return output;
        }

        public static T[] Copy<T>(this T[] array, int end)
        {
            var output = ArrayHelper.Copy(array, end);
            return output;
        }

        public static T[] Copy<T>(this T[] array, int start, int end)
        {
            var output = ArrayHelper.Copy(array, start, end);
            return output;
        }
    }
}
