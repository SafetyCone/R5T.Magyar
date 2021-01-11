using System;
using System.Collections.Generic;


namespace R5T.Magyar
{
    public static class DictionaryHelper
    {
        public static string GetDefaultKeyNotFoundExceptionMessage(string key)
        {
            var message = $"Key not found: '{key}'";
            return message;
        }

        public static KeyNotFoundException GetDefaultKeyNotFoundException(string key)
        {
            var message = DictionaryHelper.GetDefaultKeyNotFoundExceptionMessage(key);

            var exception = new KeyNotFoundException(message);
            return exception;
        }
    }
}
