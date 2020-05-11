using System;
using System.IO;
using System.Xml;


namespace R5T.Magyar.IO
{
    public static class XmlWriterHelper
    {
        /// <summary>
        /// The System XML writer includes an XML declaration by default, however this is often not desired.
        /// An XML writer can be created with settings specifying to omit the XML declaration, but other settings must be set to get the desired default behavior.
        /// This method produces an XML writer that omits the declaration.
        /// </summary>
        public static XmlWriter NewOmitDeclaration(Stream stream)
        {
            var settings = XmlWriterSettingsHelper.GetNoDeclaration();

            var writer = XmlWriter.Create(stream, settings);
            return writer;
        }

        /// <summary>
        /// Gets the standard XML writer.
        /// </summary>
        public static XmlWriter New(Stream stream)
        {
            var settings = XmlWriterSettingsHelper.GetStandardSettings();

            var writer = XmlWriter.Create(stream, settings);
            return writer;
        }

        public static XmlWriter New(string xmlFilePath)
        {
            var settings = XmlWriterSettingsHelper.GetStandardSettings();

            var writer = XmlWriter.Create(xmlFilePath, settings);
            return writer;
        }
    }
}
