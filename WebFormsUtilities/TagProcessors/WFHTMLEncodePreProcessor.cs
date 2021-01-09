using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace WebFormsUtilities.TagProcessors {
    public class WFHTMLEncodePreProcessor : IHtmlTagPreProcessor {
        #region IHtmlTagPreProcessor Members

        public HtmlTag PreRenderProcess(HtmlTag tag, ref WFModelMetaData metadata, TagTypes tagType, string markupName, string reflectName, object model) {
            if (tagType == TagTypes.Span
                || tagType == TagTypes.TextArea
                || tagType == TagTypes.Label
                || tagType == TagTypes.ValidationMessage
                || tagType == TagTypes.ValidationItem) {
                if (!String.IsNullOrEmpty(tag.InnerText)) {
                    tag.InnerText = HttpUtility.HtmlEncode(tag.InnerText);
                }
            } else if (new TagTypes[] {
                TagTypes.Checkbox,
                TagTypes.Hidden,
                TagTypes.InputBox,
                TagTypes.RadioButton,
                    }.Contains(tagType)) {

                if (!String.IsNullOrEmpty(tag.Attr("value"))) {
                    tag.Attr("value", HttpUtility.HtmlEncode(tag.Attr("value")));
                }

            } else if (tagType == TagTypes.Select) {
                foreach (HtmlTag child in tag.Children) {
                    if (!String.IsNullOrEmpty(child.HTMLTagName)
                        && child.HTMLTagName.ToLower() == "option") {
                        //<option value="encode">encode</option>
                        child.InnerText = HttpUtility.HtmlEncode(child.InnerText);
                        if (!String.IsNullOrEmpty(child.Attr("value"))) {
                            child.Attr("value", HttpUtility.HtmlEncode(child.Attr("value")));
                        }
                    }
                }
            }

            return tag;
        }

        public HtmlTag PreRenderProcess(HtmlTag tag, ref WFModelMetaData metadata, TagTypes tagType, string propertyName, System.Reflection.PropertyInfo targetProperty, object model) {
            if (tagType == TagTypes.Span
                || tagType == TagTypes.TextArea
                || tagType == TagTypes.Label
                || tagType == TagTypes.ValidationMessage
                || tagType == TagTypes.ValidationItem) {
                if (!String.IsNullOrEmpty(tag.InnerText)) {
                    tag.InnerText = HttpUtility.HtmlEncode(tag.InnerText);
                }
            } else if (new TagTypes[] {
                TagTypes.Checkbox,
                TagTypes.Hidden,
                TagTypes.InputBox,
                TagTypes.RadioButton,
                    }.Contains(tagType)) {

                if (!String.IsNullOrEmpty(tag.Attr("value"))) {
                    tag.Attr("value", HttpUtility.HtmlEncode(tag.Attr("value")));
                }

            } else if (tagType == TagTypes.Select) {
                foreach (HtmlTag child in tag.Children) {
                    if (!String.IsNullOrEmpty(child.HTMLTagName)
                        && child.HTMLTagName.ToLower() == "option") {
                        //<option value="encode">encode</option>
                        child.InnerText = HttpUtility.HtmlEncode(child.InnerText);
                        if (!String.IsNullOrEmpty(child.Attr("value"))) {
                            child.Attr("value", HttpUtility.HtmlEncode(child.Attr("value")));
                        }
                    }
                }
            }

            return tag;
        }

        #endregion
    }
}
