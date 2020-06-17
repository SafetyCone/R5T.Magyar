using System;
using System.Xml.Linq;


namespace R5T.Magyar.Xml
{
    public static class XNodeHelper
    {
        public const XNode NotFound = null;


        public static bool IsNotFound(XNode xNode)
        {
            var isNotFound = xNode == XNodeHelper.NotFound;
            return isNotFound;
        }

        public static bool WasFound(XNode xNode)
        {
            var wasFound = xNode != XNodeHelper.NotFound;
            return wasFound;
        }
    }
}
