using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using WebFormsUtilities.DataAnnotations;
using System.Reflection;

namespace WebFormsUtilities.RuleProviders {
    public class WFXmlRuleSetRuleProvider : IWFRuleProvider {
        public XmlDataAnnotationsRuleSet RuleSet { get; set; }

        public IEnumerable<PropertyInfo> GetProperties() {
            return RuleSet.ModelType.GetProperties();
        }

        public WFXmlRuleSetRuleProvider(XmlDataAnnotationsRuleSet ruleSet) {
            RuleSet = ruleSet;
        }
        public WFXmlRuleSetRuleProvider(string ruleSetName) {
            RuleSet = WFUtilities.GetRuleSetForName(ruleSetName);
            ModelDisplayName = RuleSet.ModelDisplayName;
        }



        #region IWFRuleProvider Members

        public Type ModelType {
            get {
                return RuleSet.ModelType;
            }
            set {
                RuleSet.ModelType = value;
            }
        }

        public Type ValidationType {
            get {
                return RuleSet.ModelType;
            }
            set {
                RuleSet.ModelType = value;
            }
        }

        public IEnumerable<ValidationAttribute> GetClassValidationAttributes() {
            try {
                if (RuleSet.ClassValidators != null && RuleSet.ClassValidators.Count > 0) {
                    return RuleSet.ClassValidators.Select(v => WFUtilities.GetValidatorInstanceForXmlDataAnnotationsValidator(v));
                } else {
                    return new List<ValidationAttribute>() { };
                }
            } catch (Exception ex) {
                throw new Exception("Error trying to get class-level validators. InnerException may have more detailed information.", ex);
            }
        }

        public IEnumerable<ValidationAttribute> GetPropertyValidationAttributes(string propertyName) {
            try {
                XmlDataAnnotationsRuleSetProperty property = RuleSet.Properties.FirstOrDefault(p => p.PropertyName.ToLower() == propertyName.ToLower());
                if (property != null) {
                    return property.Validators.Select(v => WFUtilities.GetValidatorInstanceForXmlDataAnnotationsValidator(v));
                } else {
                    return new List<ValidationAttribute>() { };
                }
            } catch (Exception ex) {
                throw new Exception("Error trying to get validators for " + propertyName + ". InnerException may have more detailed information.", ex);
            }
        }

        public string GetDisplayNameForProperty(string propertyName) {
            return RuleSet.Properties.First(p => p.PropertyName.ToLower() == propertyName.ToLower()).DisplayName ?? "";
        }

        public string ModelDisplayName { get; set; }

        #endregion
    }
}
