﻿using System;
using System.Collections.Generic;
using System.Text;


namespace System
{
    public static class StringBuilderExtensions
    {
        public static string GetString(this StringBuilder stringBuilder, Action<StringBuilder> modifier)
        {
            modifier(stringBuilder);

            var output = stringBuilder.ToString();
            return output;
        }
    }
}

namespace R5T.Magyar
{
    public static class StringBuilderExtensions
    {
        public static StringBuilder ReplaceRange(this StringBuilder stringBuilder, IEnumerable<string> oldValues, string newValue)
        {
            foreach (var oldValue in oldValues)
            {
                stringBuilder.Replace(oldValue, newValue);
            }

            return stringBuilder;
        }

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
