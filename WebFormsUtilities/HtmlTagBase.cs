using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebFormsUtilities
{
    //http://code.google.com/p/jquerycontainers
    [Serializable]
    public abstract class HtmlTagBase
    {
        /// <summary>
        /// Will OVERRIDE InnerText but can be used for tags like BR
        /// </summary>
        public virtual bool SelfClosing { get; set; }
        private Dictionary<string, string> _HTMLProperties = new Dictionary<string, string>();
        public virtual Dictionary<string, string> HTMLProperties
        {
            get { return _HTMLProperties; }
            set { _HTMLProperties = value; }
        }
        /// <summary>
        /// The name of the element<br/>ie: "a" for anchor tag, "table" for table tag.
        /// </summary>
        public virtual string HTMLTagName { get; set; }
        /// <summary>
        /// The innertext of the element.<br/>Will NOT be displayed if Children.Count > 0
        /// </summary>
        public virtual string InnerText { get; set; }
        private List<HtmlTagBase> _Children = new List<HtmlTagBase>();
        /// <summary>
        /// Will OVERRIDE InnerText
        /// </summary>
        public virtual List<HtmlTagBase> Children
        {
            get { return _Children; }
            set { _Children = value; }
        }
        /// <summary>
        /// Similar to jQuery's attr() method. Retrieve an attribute value.<br/>
        /// If the attribute does not exist, returns an empty string.
        /// </summary>
        /// <param name="attName"></param>
        /// <returns></returns>
        public virtual string Attr(string attName)
        {
            if (HTMLProperties.ContainsKey(attName.ToLower()))
            {
                return HTMLProperties[attName.ToLower()];
            }
            else
            {
                return "";
            }

        }
        /// <summary>
        /// Similar to jQuery's attr() method. Assign an attribute value.<br/>
        /// If the attribute does not exist, a new attribute is created.
        /// </summary>
        /// <param name="attName">The name of the attribute.</param>
        /// <param name="attValue">The value of the attribute.</param>
        /// <returns>Returns the value supplied for attValue.</returns>
        public virtual string Attr(string attName, string attValue)
        {
            if (HTMLProperties.ContainsKey(attName.ToLower()))
            {
                HTMLProperties[attName.ToLower()] = attValue;
            }
            else
            {
                HTMLProperties.Add(attName.ToLower(), attValue);
            }
            return attValue;
        }

        /// <summary>
        /// This renders the opening tag &lt;MyTag&gt; with attributes. Ignores SelfClosing, InnerText and Children.
        /// </summary>
        /// <returns>Selectively render only the beginning of the tag.<br/>ie: for an anchor tag this might be '&lt;a href=""&gt;'</returns>
        public virtual string RenderBeginningOnly()
        {
            string retTxt = "";
            retTxt += "<" + HTMLTagName;
            if (HTMLProperties != null && HTMLProperties.Count > 0)
            {
                foreach (KeyValuePair<string, string> kvp in HTMLProperties)
                {
                    retTxt += " " + kvp.Key + " = \"" + kvp.Value + "\"";
                }
            }
            retTxt += ">";
            return retTxt;
        }
        /// <summary>
        /// This renders the closing tag &lt;/MyTag&gt;. Ignores SelfClosing, InnerText and Children.
        /// </summary>
        /// <returns>Selectively render only the beginning of the tag.<br/>ie: for an anchor tag this might be '&lt;/a&gt;</returns>
        public virtual string RenderEndingOnly()
        {
            string retTxt = "";
            retTxt += "</" + HTMLTagName + ">\r\n";
            return retTxt;
        }
        /// <summary>
        /// Render the HTML tag and all child HTML tags (or just displaying InnerText).
        /// </summary>
        /// <returns>Renders the HTML tag and all children to a string.</returns>
        public virtual string Render()
        {
            string retTxt = "";
            if (!SelfClosing)
            {
                retTxt += "<" + HTMLTagName;
                if (HTMLProperties != null && HTMLProperties.Count > 0)
                {
                    foreach (KeyValuePair<string, string> kvp in HTMLProperties)
                    {
                        retTxt += " " + kvp.Key + " = \"" + kvp.Value + "\"";
                    }
                }
                retTxt += ">";
                if (Children.Count > 0)
                {
                    foreach (HtmlTagBase ht in Children)
                    {
                        retTxt += ht.Render();
                    }
                }
                else
                {
                    retTxt += InnerText;
                }
                retTxt += "</" + HTMLTagName + ">\r\n";
            }
            else
            {
                retTxt = "<" + HTMLTagName;
                if (HTMLProperties != null && HTMLProperties.Count > 0)
                {
                    foreach (KeyValuePair<string, string> kvp in HTMLProperties)
                    {
                        retTxt += " " + kvp.Key + " = \"" + kvp.Value + "\"";
                    }
                }
                retTxt += " />";
            }
            return retTxt;
        }
        /// <summary>
        /// Calls .Render()
        /// </summary>
        /// <returns>Outputs the HTML string from .Render()</returns>
        public override string ToString()
        {
            return Render();
        }
        /// <summary>
        /// Add a CSS class to the HTML tag. If the class is already found (case-sensitive), no change is applied.
        /// </summary>
        /// <param name="clsName">The name of the CSS class.</param>
        public virtual void AddClass(string clsName)
        {
            if (HTMLProperties.ContainsKey("class"))
            {
                if (!String.IsNullOrEmpty(HTMLProperties["class"]))
                {
                    foreach (string cls in HTMLProperties["class"].Split(' '))
                    {
                        if (cls.ToUpper() == clsName.ToUpper())
                        { return; }
                    }
                    HTMLProperties["class"] = HTMLProperties["class"] + " " + clsName;
                }
                else
                {
                    HTMLProperties["class"] = clsName;
                }
            }
            else
            {
                HTMLProperties.Add("class", clsName);
            }
        }
        /// <summary>
        /// Remove a CSS class from the HTML tag. If the class is not found, no change is applied.
        /// </summary>
        /// <param name="clsName">The name of the CSS class.</param>
        public virtual void RemoveClass(string clsName)
        {
            if (HTMLProperties.ContainsKey("class"))
            {
                if (!String.IsNullOrEmpty(HTMLProperties["class"]))
                {
                    string newClasses = "";
                    foreach (string cls in HTMLProperties["class"].Split(' '))
                    {
                        if (cls != clsName)
                        {
                            newClasses += (newClasses == "" ? cls : " " + cls);
                        }
                    }
                    this.Attr("class", newClasses);
                }
            }
            else
            {
                return;
            }
        }
        /// <summary>
        /// Returns 'true' if the HTML tag contains the supplied CSS class.<br/>
        /// Returns 'false' if the CSS class is not found or if the tag has no 'class' property.
        /// </summary>
        /// <param name="clsName">The name of the CSS class to check for.</param>
        /// <returns>Returns true if the supplied CSS class is found in the class="" attribute.</returns>
        public virtual bool IsClass(string clsName)
        {
            if (HTMLProperties.ContainsKey("class"))
            {
                foreach (string cls in HTMLProperties["class"].Split(' '))
                {
                    if (cls == clsName)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        ///// <summary>
        ///// Use XML escape codes for &amp;, &lt;, &gt;, &quote, &apos;.
        ///// This method is not automatically used by HtmlTagBase.
        ///// </summary>
        ///// <param name="input"></param>
        ///// <returns></returns>
        /// <summary>
        /// Use System.Security.SecurityElement.Escape(string); to sanitize for XML.
        /// This method is not automatically used by HtmlTagBase.
        /// </summary>
        /// <param name="input">Non-XML content string to be sanitized.</param>
        /// <returns></returns>
        public virtual string SanitizeForMarkup(string input) {
            //return input.Replace("&", "&amp;")
            //        .Replace("<", "&lt;")
            //        .Replace(">", "&gt;")
            //        .Replace("\"", "&quot;")
            //        .Replace("'", "&apos;");
            //Use built-in .net function to do this:
            return System.Security.SecurityElement.Escape(input);
        }

    }
}
