using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace WebFormsUtilities {
    //http://code.google.com/p/jquerycontainers
    /// <summary>
    /// Case-sensitive attribute tag class, sanitizes all input.<br/>
    /// Attributes assigned to this class will not have .ToLower() applied.
    /// </summary>
    [Serializable]
    public class XmlTag : HtmlTagBase {
        /// <summary>
        /// A class used to render XML tags. Attributes are case-sensitive and values are escaped.
        /// </summary>
        public XmlTag() { }
        /// <summary>
        /// A class used to render XML tags. Attributes are case-sensitive and values are escaped.
        /// </summary>
        /// <param name="name">The name of the element<br/>ie: "a" for anchor tag, "table" for table tag.</param>
        public XmlTag(string name) {
            HTMLTagName = name;
            SelfClosing = false;
        }

        /// <summary>
        /// A class used to render XML tags. Attributes are case-sensitive and values are escaped.
        /// </summary>
        /// <param name="name">The name of the element<br/>ie: "a" for anchor tag, "table" for table tag.</param>
        /// <param name="properties">An anonymous object whose properties will become attributes of the XML tag.</param>
        public XmlTag(string name, object properties) {
            HTMLTagName = name;
            foreach (PropertyInfo pi in properties.GetType().GetProperties()) {
                if (HTMLProperties.ContainsKey(pi.Name)) {
                    HTMLProperties[pi.Name] = SanitizeForMarkup(pi.GetValue(properties, null).ToString());
                } else {
                    object oVal = (pi.GetValue(properties, null) ?? new Object());
                    HTMLProperties.Add(pi.Name, SanitizeForMarkup(oVal.ToString()));
                }
            }
            SelfClosing = false;
        }

        /// <summary>
        /// A class used to render XML tags. Attributes are case-sensitive and values are escaped.
        /// </summary>
        /// <param name="name">The name of the element<br/>ie: "a" for anchor tag, "table" for table tag.</param>
        /// <param name="properties">An anonymous object whose properties will become attributes of the XML tag.</param>
        /// <param name="selfClosing">Whether or not the tag is self-closing.<br/>ie: This would be 'true' for BR tags.</param>
        public XmlTag(string name, object properties, bool selfClosing) {
            HTMLTagName = name;
            MergeObjectProperties(properties);
            SelfClosing = selfClosing;
        }

        /// <summary>
        /// Merge this object's tag attributes with another anonymous object.<br/>
        /// The anonymous object (argument) takes precedent.
        /// </summary>
        /// <param name="properties">The anonymous object whose properties will be applied to the tag.</param>
        /// <returns>Returns self.</returns>
        public virtual XmlTag MergeObjectProperties(object properties) {
            if (properties == null) { return this; }
            foreach (PropertyInfo pi in properties.GetType().GetProperties()) {
                if (HTMLProperties.ContainsKey(pi.Name)) {
                    HTMLProperties[pi.Name] = SanitizeForMarkup(pi.GetValue(properties, null).ToString());
                } else {
                    HTMLProperties.Add(pi.Name, SanitizeForMarkup(pi.GetValue(properties, null).ToString()));
                }
            }
            return this;
        }

        /// <summary>
        /// A class used to render XML tags. Attributes are case-sensitive and values are escaped.
        /// </summary>
        /// <param name="name">The name of the element<br/>ie: "a" for anchor tag, "table" for table tag.</param>
        /// <param name="selfClosing">Whether or not the tag is self-closing.<br/>ie: This would be 'true' for BR tags.</param>
        public XmlTag(string name, bool selfClosing) {
            HTMLTagName = name;
            SelfClosing = selfClosing;
        }

        /// <summary>
        /// Retrieve an attribute's value by name. If the value does not exist, returns an empty string.
        /// </summary>
        /// <param name="attName">The name of the attribute to retrieve.</param>
        /// <returns>Returns the value of the attribute or an empty string if not found.</returns>
        public override string Attr(string attName) {
            if (HTMLProperties.ContainsKey(attName)) {
                return HTMLProperties[attName];
            } else {
                return "";
            }

        }
        /// <summary>
        /// Set (or update) an attribute and sanitize attValue.
        /// </summary>
        /// <param name="attName">The name of the attribute.</param>
        /// <param name="attValue">The value to sanitize.</param>
        /// <returns>Returns the value of the attribute.</returns>
        public override string Attr(string attName, string attValue) {
            return Attr(attName, attValue, true);
        }

        /// <summary>
        /// Set (or update) an attribute. Sanitization is optional.
        /// </summary>
        /// <param name="attName">The name of the attribute.</param>
        /// <param name="attValue">The value of the attribute.</param>
        /// <param name="sanitize">Whether to sanitize the value supplied.</param>
        /// <returns>Returns the value of the attribute.</returns>
        public string Attr(string attName, string attValue, bool sanitize) {
            if (HTMLProperties.ContainsKey(attName)) {
                HTMLProperties[attName] = sanitize ? SanitizeForMarkup(attValue) : attValue;
            } else {
                HTMLProperties.Add(attName, sanitize ? SanitizeForMarkup(attValue) : attValue);
            }
            return attValue;
        }

        /// <summary>
        /// CAUTION: Do not use this to store markup as it will be SANITIZED. If you must use this, use UnsafeInnerText.<br/>
        /// This value overrides Children.
        /// </summary>
        public override string InnerText {
            get {
                return base.InnerText;
            }
            set {
                base.InnerText = SanitizeForMarkup(value);
            }
        }

        /// <summary>
        /// CAUTION: This property DOES NOT SANITIZE TEXT. Unless you are using this to drop raw markup into this tag,<br/>
        /// you should use the 'InnerText' property.<br/>
        /// This value overrides Children.
        /// </summary>
        public string UnsafeInnerText {
            get {
                return base.InnerText;
            }
            set {
                base.InnerText = value;
            }
        }
    }
}

