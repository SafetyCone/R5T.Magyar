using System;
using System.Text;


namespace R5T.Magyar
{
    public static class StringBuilderExtensions
    {
        public static void Remove(this StringBuilder stringBuilder, int count)
        {
            stringBuilder.Remove(stringBuilder.Length - count, count);
        }

        public static void RemoveLast(this StringBuilder stringBuilder)
        {
            stringBuilder.Remove(1);
        }
    }
}
