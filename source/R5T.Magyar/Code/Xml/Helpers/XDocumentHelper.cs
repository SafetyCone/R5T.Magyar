using System;
using System.IO;


namespace System.Xml.Linq
{
    public static class XDocumentHelper
    {
        /// <summary>
        /// Loads an XML document.
        /// </summary>
        public static XDocument LoadXDocument(string filePath)
        {
            using (var fileStream = FileStreamHelper.NewRead(filePath))
            {
                var xDocument = XDocument.Load(
                    fileStream,
                    LoadOptions.None);

                return xDocument;
            }
        }
    }
}
