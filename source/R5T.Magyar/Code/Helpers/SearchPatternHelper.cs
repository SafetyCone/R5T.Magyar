using System;


namespace R5T.Magyar
{
    public static class SearchPatternHelper
    {
        public const string All = "*";


        public static string AllFilesWithExtension(string fileExtension)
        {
            var output = $"{SearchPatternHelper.All}{fileExtension}";
            return output;
        }
    }
}
