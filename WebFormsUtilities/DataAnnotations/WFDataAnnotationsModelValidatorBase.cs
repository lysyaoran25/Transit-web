using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebFormsUtilities.Json;
using System.ComponentModel.DataAnnotations;

namespace WebFormsUtilities.DataAnnotations
{
    public abstract class WFDataAnnotationsModelValidatorBase
    {
        public virtual ValidationAttribute Attribute { get; set; }
        public virtual WFModelMetaProperty MetaProperty { get; set; }
        public virtual IEnumerable<WFModelClientValidationRule> GetClientValidationRules()
        {
            return null;
        }
        public WFDataAnnotationsModelValidatorBase(ValidationAttribute attr, WFModelMetaProperty metaprop)
        {
            Attribute = attr;
            MetaProperty = metaprop;
        }
    }
    public class WFModelClientValidationRule
    {
        public string ErrorMessage { get; set; }
        public string ValidationType { get; set; }
        private Dictionary<string, object> _ValidationParameters = new Dictionary<string, object>();

        public Dictionary<string, object> ValidationParameters
        {
            get { return _ValidationParameters; }
            set { _ValidationParameters = value; }
        }
        
    }
}
