using System;

using R5T.Magyar.T002;

using Instances = R5T.Magyar.T002.X000.Instances;


namespace System
{
    public static class IExceptionGeneratorExtensions
    {
        public static InvalidOperationException PathWasNullOrEmpty_InvalidOperation(this IExceptionGenerator _)
        {
            var message = Instances.ExceptionMessageGenerator.PathWasNullOrEmpty();

            var output = new InvalidOperationException(message);
            return output;
        }

        /// <summary>
        /// Chooses <see cref="PathWasNullOrEmpty_InvalidOperation(IExceptionGenerator)"/> as the default.
        /// </summary>
        public static InvalidOperationException PathWasNullOrEmpty(this IExceptionGenerator _)
        {
            var output = _.PathWasNullOrEmpty_InvalidOperation();
            return output;
        }
    }
}
