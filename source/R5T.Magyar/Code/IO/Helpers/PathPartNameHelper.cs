using System;


namespace R5T.Magyar.IO
{
    public static class PathPartNameHelper
    {
        public const char HiddenIndicatedNameInitialChar = '.';


        public static bool IsHiddenIndicated(string pathPartName)
        {
            var output = pathPartName[0] == PathPartNameHelper.HiddenIndicatedNameInitialChar;
            return output;
        }
    }
}
