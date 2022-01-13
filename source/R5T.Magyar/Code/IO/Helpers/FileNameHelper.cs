using System;


namespace System.IO
{
    public static class FileNameHelper
    {
        public static bool IsHiddenIndicated(string fileName)
        {
            var output = PathPartNameHelper.IsHiddenIndicated(fileName);
            return output;
        }
    }
}
