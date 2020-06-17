using System;
using System.Xml.Linq;


namespace R5T.Magyar.Xml
{
    public static class XElementHelper
    {
        public const XElement NotFound = default; // null


        public static bool IsLeaf(XElement xElement)
        {
            var isLeaf = !xElement.HasElements;
            return isLeaf;
        }

        public static bool IsNotFound(XElement xElement)
        {
            var isNotFound = xElement == XElementHelper.NotFound;
            return isNotFound;
        }

        public static bool ValueAsBoolean(string xElementValue)
        {
            var valueAsBoolean = Boolean.Parse(xElementValue);
            return valueAsBoolean;
        }

        public static bool WasFound(XElement xElement)
        {
            var wasFound = xElement != XElementHelper.NotFound;
            return wasFound;
        }
    }
}
