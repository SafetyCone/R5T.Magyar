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

        public static void Run(Action action)
        {
            if(action is object)
            {
                action();
            }
        }

        public static void Run<T>(Action<T> action, T value)
        {
            if(action is object)
            {
                action(value);
            }
        }
    }
}
