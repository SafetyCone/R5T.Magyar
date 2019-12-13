using System;


namespace R5T.Magyar
{
    public static class ActionHelper
    {
        /// <summary>
        /// Does nothing.
        /// This is the "empty" action.
        /// </summary>
        public static void DoNothing()
        {
            // Do nothing.
        }

        /// <summary>
        /// Does nothing with input.
        /// This is the "empty" action.
        /// </summary>
        public static void DoNothing<T>(T _)
        {
            // Do nothing.
        }
    }
}
