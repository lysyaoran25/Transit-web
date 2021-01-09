using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebFormsUtilities.DataAnnotations;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.ComponentModel;

namespace WebFormsUtilities {
    /// <summary>
    /// Provides a generic interface to provide validation rules from a type, an interface, XML configuration, etc.
    /// </summary>
    public interface IWFRuleProvider {
        Type ValidationType { get; set; } //The type to validate against
        IEnumerable<ValidationAttribute> GetClassValidationAttributes();
        IEnumerable<ValidationAttribute> GetPropertyValidationAttributes(string propertyName);
        string GetDisplayNameForProperty(string propertyName);
        string ModelDisplayName { get; }
        IEnumerable<PropertyInfo> GetProperties();
    }

}
