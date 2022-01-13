using System;


namespace System.IO
{
    public static class DirectoryNameHelper
    {
        public const string CurrentDirectoryName = ".";
        public const string ParentDirectoryName = "..";


        public static bool IsRelativeDirectoryName(string directoryName)
        {
            var output = directoryName == DirectoryNameHelper.CurrentDirectoryName
                || directoryName == DirectoryNameHelper.ParentDirectoryName;

            return output;
        }

        public static bool IsHiddenIndicated(string directoryName)
        {
            var output = PathPartNameHelper.IsHiddenIndicated(directoryName);
            return output;
        }
    }
}
