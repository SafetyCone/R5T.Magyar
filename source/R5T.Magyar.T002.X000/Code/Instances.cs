using System;


namespace R5T.Magyar.T002.X000
{
    public static class Instances
    {
        public static IExceptionMessageGenerator ExceptionMessageGenerator { get; } = T002.ExceptionMessageGenerator.Instance;
    }
}
