using System;


namespace R5T.Magyar
{
    public static class ArrayHelper
    {
        public static T[] Copy<T>(T[] array, int startIndex, int endIndex)
        {
            if(startIndex < 0)
            {
                throw new ArgumentException($"Start index must be zero (0) or greater. Found: {startIndex}.", nameof(startIndex));
            }

            int arrayLength = array.Length;
            if (endIndex < 0)
            {
                throw new ArgumentException($"End index must be less than the array length. Array length: {arrayLength}, found: {endIndex}..", nameof(startIndex));
            }

            var nElements = endIndex - startIndex + 1;

            var output = new T[nElements];

            Array.Copy(array, output, nElements);

            return output;
        }

        public static T[] Copy<T>(T[] array, int endIndex)
        {
            var output = ArrayHelper.Copy(array, 0, endIndex);
            return output;
        }

        public static T[] Copy<T>(T[] array)
        {
            var output = ArrayHelper.Copy(array, 0, array.Length - 1);
            return output;
        }

        public static T[] From<T>(T value)
        {
            var output = new T[] { value };
            return output;
        }
    }
}
