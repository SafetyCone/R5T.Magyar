using System;
using System.Text;
using System.Xml;


namespace R5T.Magyar.Xml
{
    public static class XmlWriterSettingsHelper
    {
        /// <summary>
        /// Gets a simple indenting XML writer settings instance.
        /// </summary>
        /// <returns></returns>
        public static XmlWriterSettings GetIndent()
        {
            var xmlWriterSettings = new XmlWriterSettings
            {
                Indent = true,
            };
            return xmlWriterSettings;
        }

        /// <summary>
        /// The System XML writer includes an XML declaration by default, however this is often not desired.
        /// An XML writer can be created with settings specifying to omit the XML declaration, but other settings must be set to get the desired default behavior.
        /// This method produces XML writer settings that replicate the default settings, except specifying to omit the declaration.
        /// </summary>
        public static XmlWriterSettings GetNoDeclaration()
        {
            var settings = new XmlWriterSettings
            {
                OmitXmlDeclaration = true,
            };

            return settings;
        }

        /// <summary>
        /// Gets the standard XML writer settings.
        /// </summary>
        public static XmlWriterSettings GetStandardSettings()
        {
            var settings = XmlWriterSettingsHelper.GetNoDeclaration();

            settings.Encoding = new UTF8Encoding(false);
            settings.Indent = true;

            return settings;
        }
    }
}
