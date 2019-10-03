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
    }
}
