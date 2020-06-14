using System;
using System.Xml.Linq;


namespace R5T.Magyar.Xml
{
    public static class XElementHelper
    {
        public const XElement NotFound = default; // null


        public static bool WasFound(XElement xElement)
        {
            var wasFound = xElement != XElementHelper.NotFound;
            return wasFound;
        }

        public static bool ValueAsBoolean(string xElementValue)
        {
            var valueAsBoolean = Boolean.Parse(xElementValue);
            return valueAsBoolean;
        }
    }
}
