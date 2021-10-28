using System;


namespace R5T.Magyar.T002
{
    /// <summary>
    /// Empty implementation as base for extension methods.
    /// </summary>
    public class ExceptionMessage : IExceptionMessage
    {
        #region Static
        
        public static ExceptionMessage Instance { get; } = new ExceptionMessage();

        #endregion
    }
}