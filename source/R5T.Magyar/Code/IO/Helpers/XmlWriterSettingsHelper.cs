using System;
using System.Xml;


namespace R5T.Magyar.IO
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
    }
}
