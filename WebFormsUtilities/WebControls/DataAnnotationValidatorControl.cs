using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Text;
using System.Web.UI.WebControls;
using System.Reflection;
using System.ComponentModel.DataAnnotations;
using System.Web.UI;
using System.ComponentModel;
using WebFormsUtilities.DataAnnotations;
using WebFormsUtilities.ValueProviders;

namespace WebFormsUtilities.WebControls {
    public class DataAnnotationValidatorControl : BaseValidator {
        private string _propertyName = "";
        public string PropertyName {
            get { return _propertyName; }
            set { _propertyName = value; }
        }
        private string _sourceTypeString = "";
        public string SourceTypeString {
            get { return _sourceTypeString; }
            set { _sourceTypeString = value; }
        }
        private Type _sourceType = null;
        public Type SourceType {
            get { return _sourceType; }
            set { _sourceType = value; }
        }

        private bool _HasBeenChecked = false;

        public string HTMLTagName { get; set; }

        private string _XmlRuleSetName = "";
        /// <summary>
        /// Apply validation from rules defined in XML validation configuration.
        /// The XML file(s) may be registered in application start WFUtilities.
        /// </summary>
        public string XmlRuleSetName {
            get { return _XmlRuleSetName; }
            set { _XmlRuleSetName = value; }
        }

        protected override bool EvaluateIsValid() {
            _HasBeenChecked = true;
            if (String.IsNullOrEmpty(SourceTypeString)) {
                if (SourceType == null
                    && String.IsNullOrEmpty(XmlRuleSetName)
                    && this.Page as IWFGetValidationRulesForPage == null) {
                    throw new Exception("The SourceType and SourceTypeString properties are null/empty on one of the validator controls.\r\nPopulate either property.\r\nie: control.SourceType = typeof(Widget); OR in markup SourceTypeString=\"Assembly.Classes.Widget, Assembly\"\r\nFinally, the page can also implement IWFGetValidationRulesForPage.");
                } else if (SourceType == null
                    && !String.IsNullOrEmpty(XmlRuleSetName)) {
                    //Get the type from the XmlRuleSet
                    SourceType = WFUtilities.GetRuleSetForName(XmlRuleSetName).ModelType;
                } else if (SourceType == null && String.IsNullOrEmpty(XmlRuleSetName)) {
                    SourceType = ((IWFGetValidationRulesForPage)this.Page).GetValidationClassType();
                }


            } else {
                try {
                    SourceType = Type.GetType(SourceTypeString, true, true);
                } catch (Exception ex) {
                    throw new Exception("Couldn't resolve type " + SourceTypeString + ". You may need to specify the fully qualified assembly name.");
                }
            }

            PropertyInfo prop = WFUtilities.GetTargetProperty(_propertyName, SourceType);

            Control validateControl = this.FindControl(this.ControlToValidate); //Search siblings
            if (validateControl == null) //Search page
            {
                validateControl = WebControlUtilities.FindControlRecursive(this.Page, this.ControlToValidate);
            }
            string controlValue = WebControlUtilities.GetControlValue(validateControl);

            if (String.IsNullOrEmpty(XmlRuleSetName)) {

                var displayNameAttr = prop.GetCustomAttributes(typeof(DisplayNameAttribute), true).OfType<DisplayNameAttribute>().FirstOrDefault();
                string displayName = displayNameAttr == null ? prop.Name : displayNameAttr.DisplayName;

                foreach (var attr in prop.GetCustomAttributes(typeof(ValidationAttribute), true).OfType<ValidationAttribute>()) {

                    if (attr as IWFRequireValueProviderContext != null) {
                        ((IWFRequireValueProviderContext)attr).SetValueProvider(new WFPageControlsValueProvider(this.Page, ""));
                    }

                    if (!attr.IsValid(controlValue)) {
                        this.ErrorMessage = attr.FormatErrorMessage(displayName);
                        return false;
                    }
                }
                return true;
            } else {
                XmlDataAnnotationsRuleSet ruleset = WFUtilities.GetRuleSetForType(SourceType, XmlRuleSetName);
                XmlDataAnnotationsRuleSetProperty property = ruleset.Properties.FirstOrDefault(p => p.PropertyName == PropertyName);
                if (property != null) {
                    foreach (XmlDataAnnotationsValidator val in property.Validators) {
                        ValidationAttribute attr = WFUtilities.GetValidatorInstanceForXmlDataAnnotationsValidator(val);

                        if (attr as IWFRequireValueProviderContext != null) {
                            ((IWFRequireValueProviderContext)attr).SetValueProvider(new WFPageControlsValueProvider(this.Page, ""));
                        }

                        if (!String.IsNullOrEmpty(ErrorMessage)
                            && String.IsNullOrEmpty(attr.ErrorMessage)) {
                            attr.ErrorMessage = ErrorMessage;
                        }

                        foreach (var key in val.ValidatorAttributes.Keys) {
                            PropertyInfo pi = attr.GetType().GetProperty(key);

                            string[] excludeProps = new string[] { };
                            if (attr.GetType() == typeof(StringLengthAttribute)) { excludeProps = new string[] { "maximumLength" }; }
                            if (attr.GetType() == typeof(RangeAttribute)) { excludeProps = new string[] { "minimum", "maximum" }; }
                            if (attr.GetType() == typeof(RegularExpressionAttribute)) { excludeProps = new string[] { "pattern" }; }
                            if (!excludeProps.Contains(key)) {
                                pi.SetValue(attr, Convert.ChangeType(val.ValidatorAttributes[key], pi.PropertyType), null);
                            }
                        }
                        if (!attr.IsValid(controlValue)) {
                            this.ErrorMessage = attr.FormatErrorMessage(property.DisplayName ?? "");
                            return false;
                        }
                    }
                }

                return true;
            }
        }

        protected override void Render(HtmlTextWriter writer) {
            //Base functionality will make this hidden, causing it not to work for client validation.
            //Override here, rendering the same thing, just without display:none;

            string tagName = "span";
            if (!String.IsNullOrEmpty(HTMLTagName))
            {
                tagName = HTMLTagName;
            }

            HtmlTag spn = new HtmlTag(tagName, new
            {
                id = this.UniqueID,
                //style = "color:Red;"
                Class = WFUtilities.FieldValidationErrorClass
            });
            //Allow server if the validator has been checked before
            if (_HasBeenChecked && !EvaluateIsValid()) {
                //Use Text="" attribute if specified
                if (!String.IsNullOrEmpty(this.Text)) {
                    spn.InnerText = this.Text;
                } else //Otherwise, use the nice formatted error message from DataAnnotations
                {
                    spn.InnerText = this.ErrorMessage;
                }
            }

            spn.MergeObjectProperties(Attributes);
            if (!String.IsNullOrEmpty(this.CssClass)) {
                spn.AddClass(CssClass);
            }

            //base.Render(writer);
            writer.Write(spn.Render());
        }
    }
}
