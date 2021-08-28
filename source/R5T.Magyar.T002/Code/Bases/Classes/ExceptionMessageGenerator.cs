using System;


namespace R5T.Magyar.T002
{
    /// <summary>
    /// Empty implementation as base for extension methods.
    /// </summary>
    public class ExceptionMessageGenerator : IExceptionMessageGenerator
    {
        #region Static

        public static ExceptionMessageGenerator Instance { get; } = new ExceptionMessageGenerator();

        #endregion
    }
}