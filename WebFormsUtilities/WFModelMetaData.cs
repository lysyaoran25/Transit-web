using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace WebFormsUtilities
{
    /// <summary>
    /// Stores meta-data for validation and validation errors for a given page.
    /// </summary>
    public class WFModelMetaData
    {
        public List<WFModelMetaProperty> Properties = new List<WFModelMetaProperty>();
        public List<WFModelMetaClassError> ClassErrors = new List<WFModelMetaClassError>();
        public List<string> Errors { get; set; }
        public object PageModel { get; set; }
    }

    public class WFModelMetaClassError
    {
        public string ErrorMessage { get; set; }
    }

    public class WFModelMetaProperty
    {
        /// <summary>
        /// The particular model object this property belongs to.
        /// </summary>
        public object ModelObject { get; set; }
        /// <summary>
        /// Whether or not this property has generated an error via validation.
        /// </summary>
        public bool HasError { get; set; }
        /// <summary>
        /// A plain-text string list of errors.
        /// </summary>
        public List<string> Errors = new List<string>();
        /// <summary>
        /// Caches the name to display for this property.
        /// </summary>
        public string DisplayName { get; set; }
        /// <summary>
        /// The reflected property name from the model.
        /// </summary>
        public string PropertyName { get; set; }
        /// <summary>
        /// The name/id to use in markup for this property.
        /// </summary>
        public string MarkupName { get; set; }
        /// <summary>
        /// Caches the validation attributes collected from the model that apply to this property.
        /// </summary>
        public List<Object> ValidationAttributes = new List<object>();
        /// <summary>
        /// This is used with declarative syntax which does not use MVF-style validator spans
        /// </summary>
        public string OverriddenSpanID { get; set; }

        /// <summary>
        /// This is used to override all DataAnnotations errors for this meta property
        /// </summary>
        public string OverriddenErrorMessage { get; set; }
    }
}
