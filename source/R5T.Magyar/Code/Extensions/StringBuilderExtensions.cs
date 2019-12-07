using System;
using System.Text;


namespace R5T.Magyar
{
    public static class StringBuilderExtensions
    {
        public static void Trim(this StringBuilder stringBuilder, int count)
        {
            stringBuilder.Remove(stringBuilder.Length - count, count);
        }

        public static void TrimLast(this StringBuilder stringBuilder)
        {
            stringBuilder.Trim(1);
        }
    }
}
