using System;


namespace R5T.Magyar.IO
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
