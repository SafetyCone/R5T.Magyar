using System;


namespace R5T.Magyar
{
    /// <summary>
    /// Has a GUID (Globally Unique ID).
    /// </summary>
    public interface IGUIDed
    {
        Guid GUID { get; }
    }
}
