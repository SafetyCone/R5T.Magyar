using System;


namespace R5T.Magyar.T002
{
    /// <summary>
    /// Empty implementation as base for extension methods.
    /// </summary>
    public class ExceptionGenerator : IExceptionGenerator
    {
        #region Static

        public static ExceptionGenerator Instance { get; } = new ExceptionGenerator();

        #endregion
    }
}