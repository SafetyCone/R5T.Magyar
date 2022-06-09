using System;


namespace R5T.Magyar
{
    public static class SearchPatternHelper
    {
        public const string All = "*";


        public static string AllFilesStartingWith(string fileNameStart)
        {
            var output = $"{fileNameStart}{SearchPatternHelper.All}";
            return output;
        }

        public static string AllFilesWithExtension(string fileExtension)
        {
            var output = $"{SearchPatternHelper.All}{fileExtension}";
            return output;
        }
    }
}
