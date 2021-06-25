using System;


namespace R5T.Magyar
{
    /// <summary>
    /// Empty implementation as base for extension methods.
    /// </summary>
    public class Word : IWord
    {
        #region Static
        
        public static Word Instance { get; } = new Word();
        
        #endregion
    }
}