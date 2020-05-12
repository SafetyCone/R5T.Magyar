using System;


namespace R5T.Magyar
{
    public static class VersionHelper
    {
        public static Version None = null;


        public static bool IsNone(Version version)
        {
            var isNone = version == VersionHelper.None;
            return isNone;
        }
    }
}
