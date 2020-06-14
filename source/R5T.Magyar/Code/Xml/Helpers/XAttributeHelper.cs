using System;
using System.Xml.Linq;


namespace R5T.Magyar.Xml
{
    public static class XAttributeHelper
    {
        public const XAttribute NotFound = default; // null


        public static bool WasFound(XAttribute xElement)
        {
            var wasFound = xElement != XAttributeHelper.NotFound;
            return wasFound;
        }

        public static XAttribute New(XName xName)
        {
            var xAttribute = new XAttribute(xName, String.Empty);
            return xAttribute;
        }
    }
}
