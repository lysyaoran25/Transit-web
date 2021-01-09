using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Web.UI;

namespace WebFormsUtilities
{
    //http://code.google.com/p/jquerycontainers
    [Serializable]
    public class HtmlTag : HtmlTagBase
    {
        /// <summary>
        /// A class used to render HTML tags.
        /// </summary>
        public HtmlTag()
        { }
        /// <summary>
        /// A class used to render HTML tags.
        /// </summary>
        /// <param name="name">The name of the element<br/>ie: "a" for anchor tag, "table" for table tag.</param>
        public HtmlTag(string name)
        {
            HTMLTagName = name;
            SelfClosing = false;
        }
        /// <summary>
        /// A class used to render HTML tags.
        /// </summary>
        /// <param name="name">The name of the element<br/>ie: "a" for anchor tag, "table" for table tag.</param>
        /// <param name="properties">An anonymous object whose properties are applied to the element.<br/>
        /// ie: new { Class = "cssClass", onchange = "jsFunction()" } </param>
        public HtmlTag(string name, object properties)
        {
            HTMLTagName = name;
            foreach (PropertyInfo pi in properties.GetType().GetProperties())
            {
                if (HTMLProperties.ContainsKey(pi.Name.ToLower()))
                {
                    HTMLProperties[pi.Name.ToLower()] = pi.GetValue(properties, null).ToString();
                }
                else
                {
                    object oVal = (pi.GetValue(properties, null) ?? new Object());
                    HTMLProperties.Add(pi.Name.ToLower(), oVal.ToString());
                }
            }
            SelfClosing = false;
        }
        /// <summary>
        /// A class used to render HTML tags.
        /// </summary>
        /// <param name="name">The name of the element<br/>ie: "a" for anchor tag, "table" for table tag.</param>
        /// <param name="properties">An anonymous object whose properties are applied to the element.<br/>
        /// ie: new { Class = "cssClass", onchange = "jsFunction()" } </param>
        /// <param name="selfClosing">Whether or not the tag is self-closing.<br/>ie: This would be 'true' for BR tags.</param>
        public HtmlTag(string name, object properties, bool selfClosing)
        {
            HTMLTagName = name;
            MergeObjectProperties(properties);
            SelfClosing = selfClosing;
        }

        /// <summary>
        /// Adds new properties to the HTML tag and overrides existing properties.
        /// </summary>
        /// <param name="properties">An anonymous object whose properties are applied to the element.<br/>
        /// ie: new { Class = "cssClass", onchange = "jsFunction()" } </param>
        /// <returns>Returns 'this'.</returns>
        public virtual HtmlTag MergeObjectProperties(object properties)
        {
            if (properties == null) { return this; }
            foreach (PropertyInfo pi in properties.GetType().GetProperties())
            {
                if (HTMLProperties.ContainsKey(pi.Name.ToLower()))
                {
                    HTMLProperties[pi.Name.ToLower()] = pi.GetValue(properties, null).ToString();
                }
                else
                {
                    HTMLProperties.Add(pi.Name.ToLower(), pi.GetValue(properties, null).ToString());
                }
            }
            return this;
        }

        /// <summary>
        /// Adds new properties to the HTML tag and overrides existing properties.
        /// </summary>
        /// <param name="attribs">Attributes collected from an ASP.net server control.</param>
        /// <returns>Returns 'this'.</returns>
        public virtual HtmlTag MergeObjectProperties(AttributeCollection attribs)
        {
            if (attribs == null) { return this; }
            foreach (var key in attribs.Keys)
            {
                if (HTMLProperties.ContainsKey(key.ToString().ToLower()))
                {
                    HTMLProperties[key.ToString().ToLower()] = HTMLProperties[key.ToString().ToLower()] + attribs[key.ToString()];
                }
                else
                {
                    HTMLProperties.Add(key.ToString().ToLower(), attribs[key.ToString()]);
                }
            }
            return this;
        }

        public virtual HtmlTag MergeObjectProperties(Dictionary<string, object> htmlAttributes)
        {
            if (htmlAttributes == null) { return this; }
            if (htmlAttributes.Count < 1) { return this; }
            foreach (KeyValuePair<string, object> kvp in htmlAttributes)
            {
                if (HTMLProperties.ContainsKey(kvp.Key.ToLower()))
                {
                    HTMLProperties[kvp.Key.ToLower()] = htmlAttributes[kvp.Key].ToString();
                }
                else
                {
                    HTMLProperties.Add(kvp.Key.ToLower(), htmlAttributes[kvp.Key].ToString());
                }
            }
            return this;
        }

        /// <summary>
        /// A class used to render HTML tags. 
        /// </summary>
        /// <param name="name">The name of the element<br/>ie: "a" for anchor tag, "table" for table tag.</param>
        /// <param name="selfClosing">Whether or not the tag is self-closing.<br/>ie: This would be 'true' for BR tags.</param>
        public HtmlTag(string name, bool selfClosing)
        {
            HTMLTagName = name;
            SelfClosing = selfClosing;
        }
    }
}
