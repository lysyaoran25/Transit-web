using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Linq.Expressions;

namespace WebFormsUtilities.TagProcessors {
    public class WFValidationPreProcessor : IHtmlTagPreProcessor {

        private TagTypes[] validationTypes = new TagTypes[] { 
                TagTypes.Checkbox,
                TagTypes.Hidden,
                TagTypes.InputBox,
                //TagTypes.Label,
                TagTypes.RadioButton,
                TagTypes.Select,
                TagTypes.Span,
                TagTypes.TextArea
            };

        #region IHtmlTagPreProcessor Members

        public HtmlTag PreRenderProcess(HtmlTag tag, ref WFModelMetaData metadata, TagTypes tagType, string markupName, string reflectName, object Model) {

            //Ignore tag types that are not tied to a property
            if (!validationTypes.Contains(tagType)) { return tag; }

            if (reflectName == "") { reflectName = markupName; }
            if (Model == null || String.IsNullOrEmpty(markupName) || tag == null || metadata == null) { return tag; }
            WFModelMetaProperty metaprop = null;
            string lcName = markupName.ToLower();
            for (int i = 0; i < metadata.Properties.Count; i++) {
                //if (metadata.Properties[i].ModelObject == Model && metadata.Properties[i].MarkupName.ToLower() == lcName)
                if (metadata.Properties[i].MarkupName.ToLower() == lcName) {
                    metaprop = metadata.Properties[i];
                    break;
                }
            }
            if (metaprop == null) {
                //Create a meta property if it does not exist  
                metaprop = GetMetaProperty(metadata, markupName, Model, reflectName, null);
                metadata.Properties.Add(metaprop);
            }
            if (metaprop.HasError) {
                tag.AddClass(WFUtilities.InputValidationErrorClass);
            }
            return tag;
        }

        #endregion

        /// <summary>
        /// This method is used internally to find or create meta properties in validation data.
        /// </summary>
        /// <param name="metadata">The metadata object.</param>
        /// <param name="markupName">The name of the property in markup.</param>
        /// <param name="model">The model object in memory the property belongs to.</param>
        /// <param name="reflectName">The reflected property name.</param>
        /// <param name="context">The current HTTP context.</param>
        /// <returns>Returns a WFModelMetaProperty class.</returns>
        public WFModelMetaProperty GetMetaProperty(WFModelMetaData metadata, string markupName, object model, string reflectName, HttpContext context) {

            Type tx = model.GetType();
            PropertyInfo foundProperty = null;
            WFModelMetaProperty metaprop = null;
            foreach (PropertyInfo pi in tx.GetProperties()) {
                if (pi.Name == reflectName) {
                    foundProperty = pi;
                    metaprop = CreateMetaProperty(markupName, pi, metadata, metaprop, model, context);
                }
            }
            return metaprop;
        }

        /// <summary>
        /// Create a meta property from the specified PropertyInfo object, run validation on it against the current value and return it.<br/>
        /// If a WFModelMetaProperty is supplied, it will be validated/modified and then returned.
        /// </summary>
        /// <param name="markupName">The HTML markup name of the control rendering the property.<param>
        /// <param name="pi">The PropertyInfo object to retrieve DataAnnotations from.</param>
        /// <param name="metadata">The metadata for the model.</param>
        /// <param name="metaprop">The metadata for this particular property. (optional)</param>
        /// <param name="model">The particular model instance that owns this property.</param>
        /// <param name="context">The HttpContext supplying the value to validate against.</param>
        /// <returns></returns>
        private WFModelMetaProperty CreateMetaProperty(string markupName, PropertyInfo pi, WFModelMetaData metadata, WFModelMetaProperty metaprop, object model, HttpContext context) {
            object[] attribs = pi.GetCustomAttributes(false);
            var displayNameAttr = pi.GetCustomAttributes(typeof(DisplayNameAttribute), true).OfType<DisplayNameAttribute>().FirstOrDefault();
            string displayName = displayNameAttr == null ? pi.Name : displayNameAttr.DisplayName;
            foreach (object o in attribs) {
                Type oType = o.GetType();
                if (oType.IsSubclassOf(typeof(ValidationAttribute))) {
                    var oVal = (ValidationAttribute)o;
                    if (metaprop == null) // Try to find it ...
                            {
                        foreach (WFModelMetaProperty mx in metadata.Properties) {
                            if (mx.ModelObject == model && pi.Name.ToLower() == mx.PropertyName.ToLower()) {
                                metaprop = mx;
                                break;
                            }
                        }
                    }
                    if (metaprop == null) // Make a new one ...
                            {
                        metaprop = new WFModelMetaProperty();
                    }
                    metaprop.ModelObject = model;
                    metaprop.PropertyName = pi.Name;
                    metaprop.DisplayName = displayName;
                    metaprop.MarkupName = markupName;
                    metaprop.ValidationAttributes.Add(oVal);

                    //if (context != null && !oVal.IsValid(context.Request[markupName])) {
                    //    metaprop.HasError = true;
                    //    metaprop.Errors.Add(oVal.FormatErrorMessage(displayName));
                    //}
                }
            }

            if (metaprop == null && pi != null) { //No attributes were found for this property

                metaprop = new WFModelMetaProperty();
                metaprop.ModelObject = model;
                metaprop.PropertyName = pi.Name;
                metaprop.DisplayName = pi.Name; //No attributes, so no displayname
                metaprop.MarkupName = markupName;
            }

            return metaprop;
        }

        /// <summary>
        /// This method should only be called by Html.&lt;control&gt;For() methods.
        /// It registers metadata for model properties if they do not exist for controls on the form and informs the control if there is an error.
        /// </summary>
        /// <param name="metadata"></param>
        /// <param name="Model"></param>
        /// <param name="tag"></param>
        /// <param name="markupName"></param>
        /// <param name="expressionBody"></param>
        /// <returns></returns>
        public HtmlTag PreRenderProcess(HtmlTag tag, ref WFModelMetaData metadata, TagTypes tagType, string markupName, PropertyInfo targetProperty, object model) {

            //Ignore tag types that are not tied to a property
            if (!validationTypes.Contains(tagType)) { return tag; }

            if (model == null || String.IsNullOrEmpty(markupName) || tag == null || metadata == null) { return tag; }
            WFModelMetaProperty metaprop = null;
            string lcName = markupName.ToLower();
            for (int i = 0; i < metadata.Properties.Count; i++) {
                if (metadata.Properties[i].MarkupName.ToLower() == lcName) {
                    metaprop = metadata.Properties[i];
                    break;
                }
            }
            if (metaprop == null) {
                metaprop = CreateMetaProperty(markupName, targetProperty, metadata, metaprop, model, HttpContext.Current);
                metadata.Properties.Add(metaprop);
            }
            if (metaprop.HasError) {
                tag.AddClass(WFUtilities.InputValidationErrorClass);
            }
            return tag;
        }

    }
}
