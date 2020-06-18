using System;
using System.Xml;
using System.Xml.Linq;


namespace R5T.Magyar.Xml
{
    public static class XNodeExtensions
    {
        public static bool IsText(this XNode xNode)
        {
            var isNotFound = XNodeHelper.IsNotFound(xNode);
            if(isNotFound)
            {
                return false;
            }

            var isText = xNode.NodeType == XmlNodeType.Text;
            return isText;
        }
    }
}
