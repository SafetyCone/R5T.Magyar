using System;

using System.IO;


namespace System
{
    public static class DirectoryInfoExtensions
    {
        public static bool IsRoot(this DirectoryInfo directoryInfo)
        {
            var output = directoryInfo.Parent is null;
            return output;
        }
    }
}
