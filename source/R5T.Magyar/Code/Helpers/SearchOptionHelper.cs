using System;
using System.IO;


namespace R5T.Magyar
{
    public static class SearchOptionHelper
    {
        public static SearchOption RecursiveToSearchOption(bool recursive)
        {
            if(recursive)
            {
                return SearchOption.AllDirectories;
            }
            else
            {
                return SearchOption.TopDirectoryOnly;
            }
        }
    }
}
