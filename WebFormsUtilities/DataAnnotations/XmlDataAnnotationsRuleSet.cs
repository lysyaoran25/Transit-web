using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebFormsUtilities.DataAnnotations {
    public class XmlDataAnnotationsRuleSet {
        public string RuleSetName { get; set; }
        public string AssemblyName { get; set; }
        public string TypeName { get; set; }
        public string ModelDisplayName { get; set; }
        public Type ModelType { get; set; }
        public List<XmlDataAnnotationsRuleSetProperty> Properties { get; set; }

        public List<XmlDataAnnotationsValidator> ClassValidators { get; set; }

        public XmlDataAnnotationsRuleSet() {
        }
    }
    public class XmlDataAnnotationsRuleSetProperty {
        public XmlDataAnnotationsRuleSet ParentRuleSet { get; set; }
        public string PropertyName { get; set; }
        public string DisplayName { get; set; }
        public string DisplayNameResourceName { get; set; }
        public Type DisplayNameResourceType { get; set; }
        public List<XmlDataAnnotationsValidator> Validators = new List<XmlDataAnnotationsValidator>();
        public XmlDataAnnotationsRuleSetProperty() {
            
        }
    }
    public class XmlDataAnnotationsValidator {
        public string ErrorMessageResourceName { get; set; }
        public Type ErrorMessageResourceType { get; set; }
        public XmlDataAnnotationsRuleSetProperty ParentProperty { get; set; }
        public bool Negated { get; set; }
        public string ErrorMessage { get; set; }
        public Type ValidatorType { get; set; }
        public string ValidatorTypeName { get; set; }

        public Dictionary<string, string> ValidatorAttributes = new Dictionary<string, string>();

        public XmlDataAnnotationsValidator() {
        }
    }
}
