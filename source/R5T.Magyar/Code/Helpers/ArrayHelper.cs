using System;


namespace R5T.Magyar
{
    public static class ArrayHelper
    {
        public static T[] Copy<T>(T[] array)
        {
            var nElements = array.Length;

            var output = new T[nElements];

            Array.Copy(array, output, nElements);

            return output;
        }
    }
}
