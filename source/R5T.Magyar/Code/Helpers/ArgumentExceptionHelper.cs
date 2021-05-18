using System;


namespace R5T.Magyar
{
    public static class ArgumentExceptionHelper
    {
        public static ArgumentException New(string message)
        {
            var exception = new ArgumentException(message);
            return exception;
        }
    }
}
