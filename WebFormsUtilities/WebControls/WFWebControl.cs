using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using System.Reflection;
using System.Web.UI;
using System.ComponentModel;
using WebFormsUtilities.DataAnnotations;

namespace WebFormsUtilities.WebControls {
    public abstract class WFWebControlForBase : WebControl {
        private string _propertyName = "";
        public virtual string PropertyName {
            get { return _propertyName; }
            set { _propertyName = value; }
        }
        private string _sourceTypeString = "";
        public virtual string SourceTypeString {
            get { return _sourceTypeString; }
            set { _sourceTypeString = value; }
        }
        private Type _sourceType = null;
        public virtual Type SourceType {
            get {
                if (_sourceType == null) {
                    _sourceType = GetTypeForControl();
                }
                return _sourceType;
            }
            set { _sourceType = value; }
        }
        private string _XmlRuleSetName = "";
        /// <summary>
        /// Apply validation from rules defined in XML validation configuration.
        /// The XML file(s) may be registered in application start WFUtilities.
        /// </summary>
        public virtual string XmlRuleSetName {
            get { return _XmlRuleSetName; }
            set { _XmlRuleSetName = value; }
        }

        protected virtual void Render(HtmlTextWriter writer) {
            //Override ASP.net's automatic <span> tag
            RenderContents(writer);
        }

        private string _TargetControl = "";

        public virtual string TargetControl {
            get { return _TargetControl; }
            set { _TargetControl = value; }
        }

        private string _DisplayName = "";
        public virtual string DisplayName {
            get {
                if (String.IsNullOrEmpty(_DisplayName)) {
                    //Check if there is an XML rule set specified for this property
                    if (!String.IsNullOrEmpty(XmlRuleSetName)) {
                        XmlDataAnnotationsRuleSet ruleSet = WFUtilities.GetRuleSetForType(SourceType, XmlRuleSetName);
                        XmlDataAnnotationsRuleSetProperty property = ruleSet.Properties.FirstOrDefault(p => p.PropertyName == PropertyName);
                        if (property != null) {
                            if (!String.IsNullOrEmpty(property.DisplayName)) {
                                _DisplayName = property.DisplayName;
                                return _DisplayName;
                            } else if (property.DisplayNameResourceType != null && !String.IsNullOrEmpty(property.DisplayNameResourceName)) {
                                return WFUtilities.GetResourceValueFromTypeName(property.DisplayNameResourceType, property.DisplayNameResourceName);
                            }
                        }
                    }
                    //If no ruleset defined or the ruleset did not set a displayname, check for a DisplayName DataAnnotation
                    PropertyInfo pi = GetTargetProperty();
                    var displayNameAttr = pi.GetCustomAttributes(typeof(DisplayNameAttribute), true).OfType<DisplayNameAttribute>().FirstOrDefault();
                    //If all else fails, return the reflected property name
                    _DisplayName = displayNameAttr == null ? pi.Name : displayNameAttr.DisplayName ?? pi.Name;
                }
                return _DisplayName;
            }
        }

        public virtual PropertyInfo GetTargetProperty() {
            return WFUtilities.GetTargetProperty(_propertyName, SourceType);
        }



        public virtual Control GetTargetControl() {
            PropertyInfo prop = GetTargetProperty();
            Control targetControl = this.FindControl(this.TargetControl); //Search siblings
            if (targetControl == null) //Search page
            {
                targetControl = WebControlUtilities.FindControlRecursive(this.Page, this.TargetControl);
            }
            return targetControl;
        }

        public virtual Type GetTypeForControl() {
            Type modelType = null;
            if (String.IsNullOrEmpty(SourceTypeString)) {
                if (_sourceType == null
                    && String.IsNullOrEmpty(XmlRuleSetName)
                    && this.Page as IWFGetValidationRulesForPage == null) {
                    throw new Exception("The SourceType and SourceTypeString properties are null/empty on one of the validator controls.\r\nPopulate either property.\r\nie: control.SourceType = typeof(Widget); OR in markup SourceTypeString=\"Assembly.Classes.Widget, Assembly\"\r\nThe page can also implement IWFGetValidationRulesForPage.");
                } else if (_sourceType == null && !String.IsNullOrEmpty(XmlRuleSetName)) {
                    //Get the type from the XmlRuleSet
                    SourceType = WFUtilities.GetRuleSetForName(XmlRuleSetName).ModelType;
                } else if (_sourceType == null && String.IsNullOrEmpty(XmlRuleSetName)) {
                    SourceType = ((IWFGetValidationRulesForPage)this.Page).GetValidationClassType();
                }

            } else {
                try {
                    SourceType = Type.GetType(SourceTypeString, true, true);
                } catch (Exception ex) {
                    throw new Exception("Couldn't resolve type " + SourceTypeString + ". You may need to specify the fully qualified assembly name.");
                }
            }
            return SourceType;
        }
    }
}
