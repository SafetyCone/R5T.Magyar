using System;


namespace R5T.Magyar.T001
{
    /// <summary>
    /// Empty implementation as base for extension methods.
    /// </summary>
    public class ModiferGenerator : IModiferGenerator
    {
        #region Static

        public static ModiferGenerator Instance { get; } = new ModiferGenerator();

        #endregion
    }
}