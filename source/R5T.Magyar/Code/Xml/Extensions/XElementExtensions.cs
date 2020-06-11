using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;


namespace R5T.Magyar.Xml
{
    public static class XElementExtensions
    {
        /// <summary>
        /// Get the element with the speicified name, if it exists, or adds an element with the specified if it does not exist.
        /// Adds the element as well.
        /// </summary>
        public static XElement AcquireElement(this XElement xElement, XName name)
        {
            var hasElement = xElement.HasElement(name, out var element);
            if (hasElement)
            {
                return element;
            }

            element = xElement.AddElement(name);
            return element;
        }

        public static XElement AcquireElement(this XElement xElement, XName name, string value)
        {
            var element = xElement.AcquireElement(name);

            element.Value = value;

            return element;
        }

        public static XElement AddContents(this XElement xElement, object content)
        {
            xElement.Add(content);

            return xElement;
        }

        public static XElement AddContents(this XElement xElement, params object[] contents)
        {
            xElement.Add(contents);

            return xElement;
        }

        public static XElement AddElement(this XElement xElement, XName name)
        {
            var element = new XElement(name);
            xElement.Add(element);

            return element;
        }

        public static XElement AddElement(this XElement xElement, XName name, string value)
        {
            var element = xElement.AddElement(name);
            element.Value = value;

            return element;
        }

        public static XElement AddElement(this XElement xElement, XName name, object content)
        {
            var element = new XElement(name, content);
            xElement.Add(element);

            return element;
        }

        public static string GetChildValueSingle(this XElement xElement, string childName)
        {
            var output = xElement.GetChildren(childName)
                .Single()
                .Value;

            return output;
        }

        public static string GetChildValueFirst(this XElement xElement, string childName)
        {
            var output = xElement.GetChildren(childName)
                .First()
                .Value;

            return output;
        }

        /// <summary>
        /// Uses <see cref="XElementExtensions.GetChildValueSingle(XElement, string)"/> as the default.
        /// </summary>
        public static string GetChildValue(this XElement xElement, string childName)
        {
            var output = xElement.GetChildValueSingle(childName);
            return output;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the <see cref="XElement"/> does not have an element of the specified name.
        /// </summary>
        public static XElement GetElement(this XElement xElement, XName name)
        {
            var hasElement = xElement.HasElement(name, out var element);
            if (!hasElement)
            {
                throw new ArgumentException($"No element of name '{name}'.", nameof(name));
            }

            return element;
        }

        public static IEnumerable<XElement> GetChildren(this XElement xElement, string childName)
        {
            var output = xElement.Elements()
                .Where(x => x.Name == childName);

            return output;
        }

        public static bool HasElement(this XElement xElement, XName name, out XElement element)
        {
            element = xElement.Element(name);

            var hasElement = XElementHelper.WasFound(element);
            return hasElement;
        }

        public static bool HasElement(this XElement xElement, XName name)
        {
            var hasElement = xElement.HasElement(name, out var dummy);
            return hasElement;
        }

        public static bool HasChildSingle(this XElement xElement, string childName, out XElement child)
        {
            child = xElement.GetChildren(childName)
                .SingleOrDefault();

            var hasChild = XElementHelper.WasFound(child);
            return hasChild;
        }

        /// <summary>
        /// Uses <see cref="XElementExtensions.HasChildSingle(XElement, string, out XElement)"/> as the default.
        /// </summary>
        public static bool HasChild(this XElement xElement, string childName, out XElement child)
        {
            var hasChild = xElement.HasChildSingle(childName, out child);
            return hasChild;
        }

        public static bool HasChild(this XElement xElement, string childName)
        {
            var hasChild = xElement.HasChild(childName, out var _);
            return hasChild;
        }

        /// <summary>
        /// Normalizes an <see cref="XElement"/>.
        /// </summary>
        /// <remarks>
        /// Source: https://weblogs.asp.net/marianor/easy-way-to-compare-two-xmls-for-equality
        /// </remarks>
        public static XElement Normalize(this XElement xElement)
        {
            if (xElement.HasElements)
            {
                return new XElement(
                    xElement.Name,
                    xElement.Attributes()
                        .Where(a => a.Name.Namespace == XNamespace.Xmlns)
                        .OrderBy(a => a.Name.ToString()),
                    xElement.Elements()
                        .OrderBy(a => a.Name.ToString())
                        .Select(e => e.Normalize()));
            }

            if (xElement.IsEmpty)
            {
                return new XElement(
                    xElement.Name,
                    xElement.Attributes()
                        .OrderBy(a => a.Name.ToString()));
            }

            return new XElement(
                xElement.Name,
                xElement.Attributes()
                    .OrderBy(a => a.Name.ToString()),
                xElement.Value);
        }
    }
}
