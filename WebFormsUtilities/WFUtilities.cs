using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web;
using System.Reflection;
using System.ComponentModel.DataAnnotations;
using WebFormsUtilities.Json;
using System.ComponentModel;
using WebFormsUtilities.DataAnnotations;
using System.Xml;
using System.Web.Configuration;
using System.Configuration;
using System.IO;
using System.Resources;
using System.Linq.Expressions;
using WebFormsUtilities.RuleProviders;
using WebFormsUtilities.ValueProviders;

namespace WebFormsUtilities {
    public static class WFUtilities
    {

        #region Default CSS Classes
        private static string _FieldValidationErrorClass = "field-validation-error";
        private static string _InputValidationErrorClass = "input-validation-error";
        private static string _ValidationSummaryValidClass = "validation-summary-valid";
        private static string _ValidationSummaryErrorsClass = "validation-summary-error";
        private static string _FieldValidationValidClass = "field-validation-valid";
        private static string _InputValidationValidClass = "input-validation-valid";

        public static string FieldValidationValidClass
        {
            get { return WFUtilities._FieldValidationValidClass; }
            set { WFUtilities._FieldValidationValidClass = value; }
        }

        public static string InputValidationValidClass
        {
            get { return WFUtilities._InputValidationValidClass; }
            set { WFUtilities._InputValidationValidClass = value; }
        }

        public static string ValidationSummaryValidClass
        {
            get { return WFUtilities._ValidationSummaryValidClass; }
            set { WFUtilities._ValidationSummaryValidClass = value; }
        }

        public static string ValidationSummaryErrorsClass
        {
            get { return WFUtilities._ValidationSummaryErrorsClass; }
            set { WFUtilities._ValidationSummaryErrorsClass = value; }
        }

        public static string InputValidationErrorClass
        {
            get { return WFUtilities._InputValidationErrorClass; }
            set { WFUtilities._InputValidationErrorClass = value; }
        }
        public static string FieldValidationErrorClass
        {
            get { return WFUtilities._FieldValidationErrorClass; }
            set { WFUtilities._FieldValidationErrorClass = value; }
        }
        #endregion

        private static bool _HandlerChecked = false;
        private static bool _HandlerRegistered = false;
        public static bool HandlerRegistered {
            get {
                if (!_HandlerChecked) {
                    _HandlerChecked = true;
                    if (String.IsNullOrEmpty(ConfigurationManager.AppSettings["WFUseHandler"])
                        || ConfigurationManager.AppSettings["WFUseHandler"].ToUpper() != "TRUE") {
                        _HandlerRegistered = false;
                    } else {
                        _HandlerRegistered = true;
                    }
                }
                return _HandlerRegistered;
            }
        }

        /// <summary>
        /// Render a Control (.aspx, .ascx) and return it as a string
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string RenderControl(string path) {
            return RenderControl(path, null);
        }
        /// <summary>
        /// Render a Control (.aspx, .ascx) and return it as a string, setting the Model property to Model
        /// </summary>
        /// <param name="path"></param>
        /// <param name="Model"></param>
        /// <returns></returns>
        public static string RenderControl(string path, object Model) {
            return RenderControl(path, Model, null);
        }
        /// <summary>
        /// Use discretion when specifying the pageInstance, as some server controls will throw an error when WFPageHolder is not used.
        /// You should not pass the current page as the pageInstance. This method assumes you know what you're doing.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="pageInstance"></param>
        /// <returns></returns>
        public static string RenderControl(string path, System.Web.UI.Page pageInstance) {
            return RenderControl(path, null, pageInstance);
        }
        /// <summary>
        /// Use discretion when specifying the pageInstance, as some server controls will throw an error when WFPageHolder is not used.
        /// !! You should not pass the current page as the pageInstance !! This method assumes you know what you're doing.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="Model"></param>
        /// <param name="pageInstance"></param>
        /// <returns></returns>
        public static string RenderControl(string path, object Model, System.Web.UI.Page pageInstance) {
            Page wph = pageInstance == null ? new WFPageHolder() as Page : pageInstance;
            Control ctrl = wph.LoadControl(path);
            if (ctrl == null) { return ""; }

            PropertyInfo pi = ctrl.GetType().GetProperties().FirstOrDefault(p => p.Name == "Model");
            if (pi == null && Model != null) {
                throw new Exception("Make sure 'Model' is a public property with a 'setter'");
            } else if (pi != null && Model != null) {
                pi.SetValue(ctrl, Model, null);
            }

            wph.Controls.Add(ctrl);

            StringWriter output = new StringWriter();
            HttpContext.Current.Server.Execute(wph, output, false);
            return output.ToString();
        }

        /// <summary>
        /// This method is used to validate class-level attributes
        /// Returns object[] of the model's custom attributes
        /// </summary>
        /// <param name="model"></param>
        /// <param name="modelType"></param>
        /// <param name="errors"></param>
        private static bool validateModelAttributes(object model, IEnumerable<ValidationAttribute> modelAttributes, List<string> errors, string displayName) {
            foreach (ValidationAttribute o in modelAttributes) {
                Type oxType = o.GetType();
                if (oxType.IsSubclassOf(typeof(ValidationAttribute))) {
                    var oVal = (ValidationAttribute)o;

                    if (oVal as IWFRequireValueProviderContext != null) {
                        ((IWFRequireValueProviderContext)oVal).SetValueProvider(new WFObjectValueProvider(model, ""));
                    }

                    if (!oVal.IsValid(model)) {
                        errors.Add(oVal.FormatErrorMessage(displayName));
                    }
                }
            }
            return errors.Count < 1;
        }

        /// <summary>
        /// Root TryValidateModel() method. Returns false if any validation errors are found.
        /// </summary>
        /// <param name="model">A pointer to the current model object</param>
        /// <param name="prefix">Optional. A prefix to search and filter values from the value provider.</param>
        /// <param name="values">A class implementing IWFValueProvider (examples include WFObjectValueProvider and WFHttpContextValueProvider)</param>
        /// <param name="metadata">Optional. Required to collect error data or show error markup on a page. The current WFModelMetaData object.</param>
        /// <param name="ruleProvider">A class implementing IWFRuleProvider (examples include WFTypeRuleProvider and WFXmlRuleSetRuleProvider).<br/>
        /// This object provides the rules (ie: DataAnnotations) that needed to be validated, and which properties to validate them against.<br/>
        /// All other properties are ignored.</param>
        /// <returns>Returns false if any validation errors were found.</returns>
        public static bool TryValidateModel(object model, string prefix, IWFValueProvider values, WFModelMetaData metadata, IWFRuleProvider ruleProvider) {
            bool validated = true;
            //Make sure we have metadata
            metadata = metadata == null ? metadata = new WFModelMetaData() : metadata;
            metadata.Errors = new List<string>();

            //Create a rule provider if one was not provided. WFTypeRuleProvider will handle [MetadataType]
            ruleProvider = ruleProvider == null ? new WFTypeRuleProvider(model) : ruleProvider;

            validated = validateModelAttributes(model, ruleProvider.GetClassValidationAttributes(), metadata.Errors, ruleProvider.ModelDisplayName);

            if (metadata.Errors.Count > 0) { validated = false; }

            foreach (PropertyInfo pi in ruleProvider.GetProperties()) {
                if (values.ContainsKey(prefix + pi.Name)) {
                    WFModelMetaProperty metaprop = null;
                    foreach (ValidationAttribute attr in ruleProvider.GetPropertyValidationAttributes(pi.Name)) {

                        if (attr as IWFRequireValueProviderContext != null) {
                            ((IWFRequireValueProviderContext)attr).SetValueProvider(values);
                        }

                        string displayName = ruleProvider.GetDisplayNameForProperty(pi.Name);
                        bool isValid = false;
                        if (attr.GetType() == typeof(RangeAttribute)) {
                            try { isValid = attr.IsValid(values.KeyValue(prefix + pi.Name)); } catch (Exception ex) {
                                if (ex.GetType() == typeof(FormatException)) { isValid = false; } else { throw ex; }
                            }
                        } else {
                            isValid = attr.IsValid(values.KeyValue(prefix + pi.Name));
                        }

                        if (!isValid) {
                            validated = false;
                            metadata.Errors.Add(attr.FormatErrorMessage(displayName));

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
                                metaprop.ModelObject = model;
                                metaprop.PropertyName = pi.Name;
                                metaprop.DisplayName = displayName;
                                metaprop.MarkupName = prefix + pi.Name;
                                metaprop.ValidationAttributes.Add(attr);

                                metadata.Properties.Add(metaprop);
                            }
                            metaprop.HasError = true;
                            metaprop.Errors.Add(attr.FormatErrorMessage(displayName));

                        }

                    }
                }
            }
            return validated;
        }

        /// <summary>
        /// Retrieve the first registered XML rule set that matches the name provided.
        /// </summary>
        /// <param name="ruleSetName">The rule set name specified in the XML rule set.</param>
        /// <returns></returns>
        public static XmlDataAnnotationsRuleSet GetRuleSetForName(string ruleSetName) {
            return XmlRuleSets.First(x => x.RuleSetName == ruleSetName);
        }

        /// <summary>
        /// Retrieve the first registered XML rule set that matches the type and rule set name.<br/>
        /// </summary>
        /// <param name="type">The model type specified in the XML rule set.</param>
        /// <param name="ruleSetName">The rule set name specified in the XML rule set.</param>
        /// <returns></returns>
        public static XmlDataAnnotationsRuleSet GetRuleSetForType(Type type, string ruleSetName) {

            foreach (XmlDataAnnotationsRuleSet ruleset in XmlRuleSets) {
                if (ruleset.ModelType == type && ruleSetName == ruleset.RuleSetName) {
                    return ruleset;
                }
            }
            return null;
        }

        /// <summary>
        /// Provides a means to dynamically load a resource value at runtime.<br/>
        /// For example, for globalization of DataAnnotations.
        /// </summary>
        /// <param name="resourceProvider">The resource type that is automatically generated by Visual Studio.</param>
        /// <param name="resourceKey">The key of the resource value to be used.</param>
        /// <returns>Returns the value of the resource key.</returns>
        public static string GetResourceValueFromTypeName(Type resourceProvider, string resourceKey) {
            var properties = resourceProvider.GetProperties(BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);

            foreach (var staticProperty in properties) {
                if (staticProperty.PropertyType == typeof(ResourceManager)) {
                    var rm = (ResourceManager)staticProperty.GetValue(null, null);
                    return rm.GetString(resourceKey);
                }
            }
            return resourceKey;
        }

        /// <summary>
        /// Load the specified XML file into memory as one or more XML rule sets in place of DataAnnotations.<br/>
        /// Use GetRuleSetForName() and GetRuleSetForType() to retrieve a rule set for validation.<br/>
        /// The WFXmlRuleSetRuleProvider class with the TryValidateModel() method.
        /// </summary>
        public static void RegisterXMLValidationConfiguration(string filename) {
            XmlDocument doc = new XmlDocument();
            doc.Load(filename);

            foreach (XmlNode node in doc.SelectNodes("validation/type")) {
                string assemblyName = node.Attributes["assemblyName"].Value;
                string name = node.Attributes["name"].Value;
                foreach (XmlNode ruleSetNode in node.SelectNodes("ruleset")) {
                    XmlDataAnnotationsRuleSet ruleset = new XmlDataAnnotationsRuleSet();
                    try {
                        ruleset.ModelType = Type.GetType(name, true, true);
                    } catch (Exception ex) {
                        throw new Exception("Couldn't resolve model type " + name + ". You may need to specify the fully qualified assembly name in the 'name' field. ie: 'MyAssembly.MyClass, MyAssembly'");
                    }
                    ruleset.AssemblyName = assemblyName;
                    ruleset.TypeName = name;
                    ruleset.Properties = new List<XmlDataAnnotationsRuleSetProperty>();
                    ruleset.RuleSetName = ruleSetNode.Attributes["name"].Value;

                    XmlAttribute rattr = ruleSetNode.Attributes["DisplayName"];
                    ruleset.ModelDisplayName = rattr == null ? ruleset.ModelDisplayName : rattr.Value;

                    XmlNode classAttsNode = ruleSetNode.SelectSingleNode("attributes");
                    if (classAttsNode != null) {
                        ruleset.ClassValidators = new List<XmlDataAnnotationsValidator>();
                        foreach (XmlNode classAttr in classAttsNode.SelectNodes("validator")) {
                            XmlDataAnnotationsValidator val = new XmlDataAnnotationsValidator();
                            foreach (XmlAttribute attr in classAttr.Attributes) {
                                if (attr.Name.ToLower() == "negated") {
                                    val.Negated = Boolean.Parse(attr.Value);
                                } else if (attr.Name == "type") {
                                    val.ValidatorTypeName = attr.Name;
                                    try {
                                        val.ValidatorType = Type.GetType(attr.Value, true, true);
                                    } catch (Exception ex) {
                                        throw new Exception("Couldn't resolve validator type " + attr.Value + ". You may need to specify the fully qualified assembly name in the 'type' field. ie: 'MyAssembly.MyClass, MyAssembly'");
                                    }
                                } else {
                                    val.ValidatorAttributes.Add(attr.Name, attr.Value);
                                }
                            }
                            ruleset.ClassValidators.Add(val);
                        }
                    }

                    foreach (XmlNode propertyNode in ruleSetNode.SelectNodes("properties/property")) {
                        XmlDataAnnotationsRuleSetProperty prop = new XmlDataAnnotationsRuleSetProperty();
                        prop.ParentRuleSet = ruleset;
                        prop.PropertyName = propertyNode.Attributes["name"].Value;

                        XmlAttribute xattr = propertyNode.Attributes["DisplayName"];
                        if (xattr != null) {
                            prop.DisplayName = xattr.Value;
                        }

                        XmlAttribute rattrResource = propertyNode.Attributes["DisplayNameResourceName"];
                        XmlAttribute rattrResourceType = propertyNode.Attributes["DisplayNameResourceType"];
                        if (rattrResource != null) {
                            prop.DisplayNameResourceName = rattrResource.Value;
                        }
                        if (rattrResourceType != null) {
                            try {
                                prop.DisplayNameResourceType = Type.GetType(rattrResourceType.Value, true, true);
                            } catch (Exception ex) {
                                throw new Exception("Couldn't resolve resource type " + rattrResourceType.Value + ". You may need to specify the fully qualified assembly name in the 'type' field. ie: 'MyAssembly.MyClass, MyAssembly'");
                            }
                        }

                        //Derive from propertyname if a display name was not found
                        if (xattr == null && rattrResource == null && rattrResourceType == null) {
                            prop.DisplayName = prop.PropertyName;
                        }


                        prop.Validators = new List<XmlDataAnnotationsValidator>();
                        foreach (XmlNode validatorNode in propertyNode.SelectNodes("validator")) {
                            XmlDataAnnotationsValidator validator = new XmlDataAnnotationsValidator();
                            validator.ParentProperty = prop;
                            foreach (XmlAttribute attr in validatorNode.Attributes) {

                                if (attr.Name == "ErrorMessageResourceName") {
                                    validator.ErrorMessageResourceName = attr.Value;
                                } else if (attr.Name == "ErrorMessageResourceType") {
                                    try {
                                        validator.ErrorMessageResourceType = Type.GetType(attr.Value, true, true);
                                    } catch (Exception ex) {
                                        throw new Exception("Couldn't resolve resource type " + attr.Value + ". You may need to specify the fully qualified assembly name in the 'type' field. ie: 'MyAssembly.MyClass, MyAssembly'");
                                    }
                                } else if (attr.Name == "ErrorMessage") {
                                    validator.ErrorMessage = attr.Value;
                                } else if (attr.Name.ToLower() == "negated") {
                                    validator.Negated = Boolean.Parse(attr.Value);
                                } else if (attr.Name == "type") {
                                    validator.ValidatorTypeName = attr.Name;
                                    if (attr.Value == "RequiredAttribute") {
                                        validator.ValidatorType = typeof(RequiredAttribute);
                                    } else if (attr.Value == "StringLengthAttribute") {
                                        validator.ValidatorType = typeof(StringLengthAttribute);
                                    } else if (attr.Value == "RegularExpressionAttribute") {
                                        validator.ValidatorType = typeof(RegularExpressionAttribute);
                                    } else if (attr.Value == "RangeAttribute") {
                                        validator.ValidatorType = typeof(RangeAttribute);
                                    } else {
                                        try {
                                            validator.ValidatorType = Type.GetType(attr.Value, true, true);
                                        } catch (Exception ex) {
                                            throw new Exception("Couldn't resolve validator type " + attr.Value + ". You may need to specify the fully qualified assembly name in the 'type' field. ie: 'MyAssembly.MyClass, MyAssembly'");
                                        }
                                    }

                                } else {
                                    validator.ValidatorAttributes.Add(attr.Name, attr.Value);
                                }
                            }

                            prop.Validators.Add(validator);
                        }
                        ruleset.Properties.Add(prop);
                    }
                    XmlRuleSets.Add(ruleset);
                }

            }

        }

        /// <summary>
        /// The XML rule set collection for all rule sets that have been loaded.<br/>
        /// Use RegisterXMLValidationConfiguration() to load a configuration into memory.<br/>
        /// Use GetRuleSetForName() and GetRuleSetForType() to retrieve a rule set for validation.<br/>
        /// The WFXmlRuleSetRuleProvider class with the TryValidateModel() method.
        /// </summary>
        public static List<XmlDataAnnotationsRuleSet> XmlRuleSets = new List<XmlDataAnnotationsRuleSet>();

        /// <summary>
        /// Decode a post data string (ie: name=value&amp;name2=value2&amp;...) into a Dictionary&lt;string,string&gt;<br/>
        /// This dictionary could be used like an HttpRequest, ie: requestDictionary["name"]<br/>
        /// HttpUtility.UrlDecode() is used to decode the names and values.
        /// </summary>
        /// <param name="decode"></param>
        /// <returns></returns>
        public static Dictionary<string, string> UrlDecodeDictionary(string decode) {
            if (String.IsNullOrEmpty(decode)) { return new Dictionary<string, string>(); }
            if (decode.Contains('&')) {
                string[] strs = decode.Split('&');
                Dictionary<string, string> reqDict = new Dictionary<string, string>();
                foreach (string s in strs) {
                    if (!String.IsNullOrEmpty(s)) {
                        string[] sx = s.Split('=');
                        if (reqDict.ContainsKey(HttpUtility.UrlDecode(sx[0]))) {
                            if (!String.IsNullOrEmpty((reqDict[HttpUtility.UrlDecode(sx[0])] ?? "").Trim())) {
                                reqDict[HttpUtility.UrlDecode(sx[0])] =
                                    reqDict[HttpUtility.UrlDecode(sx[0])] + "," + HttpUtility.UrlDecode(sx[1]);
                            } else {
                                reqDict[HttpUtility.UrlDecode(sx[0])] = HttpUtility.UrlDecode(sx[1]);

                            }
                        } else {
                            if (sx.Length > 1) {
                                reqDict.Add(HttpUtility.UrlDecode(sx[0]), HttpUtility.UrlDecode(sx[1]));
                            } else {
                                reqDict.Add(HttpUtility.UrlDecode(sx[0]), "");
                            }
                        }
                    }
                }
                return reqDict;
            } else {
                if (decode.Contains('=')) {
                    string[] strs = decode.Split('=');
                    return new Dictionary<string, string>() { { HttpUtility.UrlDecode(strs[0]), 
                                                                 HttpUtility.UrlDecode(strs[1]) } };
                } else {
                    string d = HttpUtility.UrlDecode(decode);
                    return new Dictionary<string, string>() { { d, d } };
                }
            }

        }

        /// <summary>
        /// Parse requestValue for the specified nullable type.<br/>
        /// IE: typeof(Int32?) will use int.Parse(requestValue).<br/>
        /// If requestValue is null, empty, whitespace or case-insensitive "null", then null is returned.
        /// </summary>
        /// <param name="nullableType">The nullabe type (Int32?, DateTime?, Boolean?)</param>
        /// <param name="requestValue">The value to be parsed.</param>
        /// <returns></returns>
        public static object ParseNullable(Type nullableType, string requestValue) {

            if (string.IsNullOrEmpty((requestValue ?? "").Trim())) { return null; }
            if (requestValue.ToLower() == "null") { return null; }

            object outValue = null;
            object[] requestArr = new object[] { requestValue };
            outValue = Nullable.GetUnderlyingType(nullableType).GetMethods().First(m => m.Name == "Parse"
                && m.GetParameters().Count() == 1).Invoke(null, requestArr);
            return outValue;
        }

        /// <summary>
        /// TryParse requestValue for the specified nullable type.<br/>
        /// IE: typeof(Int32?) will use int.TryParse(requestValue).<br/>
        /// If TryParse fails, null will be returned.
        /// </summary>
        /// <param name="nullableType">The nullabe type (Int32?, DateTime?, Boolean?)</param>
        /// <param name="requestValue">The value to be parsed.</param>
        /// <returns></returns>
        public static object TryParseNullable(Type nonNullableType, string requestValue) {
            object nonNullableObject = Activator.CreateInstance(nonNullableType);
            object outValue = null;
            object[] requestArr = new object[] { requestValue, outValue };
            bool didParse = (Boolean)nonNullableType.GetMethods().First(m => m.Name == "TryParse"
                            && m.GetParameters().Count() == 2).Invoke(null, requestArr); //.Invoke(nonNullableObject, requestArr);

            if (didParse) {
                return requestArr[1];
            } else {
                return null;
            }
        }

        internal static object GetTargetObject(string strPropExpression, object model) {
            if (!strPropExpression.Contains(".")) { return model; }
            string[] props = strPropExpression.Contains(".") ? strPropExpression.Split('.') : new string[] { strPropExpression };
            object target = model;
            object lastTarget = model;
            Type type = model.GetType();
            PropertyInfo pi = null;
            foreach (string prop in props) {
                if (target == null) {
                    throw new Exception("Found a null object to update while crawling expression " + strPropExpression + " the current 'prop' is: " + prop);
                }
                lastTarget = target;
                target = target.GetType().GetProperty(prop).GetValue(target, null);
                pi = type.GetProperty(prop);
                type = pi.PropertyType;
            }
            return lastTarget;
        }

        /// <summary>
        /// Will throw an exception if "ignoreMissing" is false.<br/>
        /// If "ignoreMissing" is true, will return null if the PropertyInfo cannot be found.
        /// </summary>
        /// <param name="strPropExpression"></param>
        /// <param name="sourceType"></param>
        /// <param name="ignoreMissing"></param>
        /// <returns></returns>
        internal static PropertyInfo GetTargetProperty(string strPropExpression, Type sourceType, bool ignoreMissing) {
            //Walk the property tree
            string[] props = strPropExpression.Contains(".") ? strPropExpression.Split('.') : new string[] { strPropExpression };
            PropertyInfo pi = null;
            Type type = sourceType;
            foreach (string prop in props) {
                pi = type.GetProperty(prop);
                if (pi == null) {
                    if (!ignoreMissing) {
                        throw new Exception("There was a problem searching for a property: [" + prop + "]. The source type was: [" + type.Name + "] and the root type was: [" + sourceType.Name + "]");
                    } else {
                        return null;
                    }
                }
                type = pi.PropertyType;
            }
            return pi;
            //return SourceType.GetProperty(_propertyName);
        }

        /// <summary>
        /// Will throw an exception if the target property is not found. Use the overload if this is undesirable behavior.
        /// </summary>
        /// <param name="strPropExpression"></param>
        /// <param name="sourceType"></param>
        /// <returns></returns>
        internal static PropertyInfo GetTargetProperty(string strPropExpression, Type sourceType) {
            return GetTargetProperty(strPropExpression, sourceType, false);
        }

        internal static ValidationAttribute GetValidatorInstanceForXmlDataAnnotationsValidator(XmlDataAnnotationsValidator validator) {
            if (validator == null) { return null; }
            ValidationAttribute attr = null;
            if (validator.ValidatorType == typeof(StringLengthAttribute)) {
                attr = (ValidationAttribute)new StringLengthAttribute(int.Parse(validator.ValidatorAttributes["maximumLength"]));
            } else if (validator.ValidatorType == typeof(RangeAttribute)) {
                attr = (ValidationAttribute)new RangeAttribute(double.Parse(validator.ValidatorAttributes["minimum"]), double.Parse(validator.ValidatorAttributes["maximum"]));
            } else if (validator.ValidatorType == typeof(RegularExpressionAttribute)) {
                attr = (ValidationAttribute)new RegularExpressionAttribute(validator.ValidatorAttributes["pattern"]);
            } else {
                try {
                    attr = (ValidationAttribute)Activator.CreateInstance(validator.ValidatorType);
                } catch (Exception ex) {
                    throw new Exception("Error trying to create an instance of [" + validator.ValidatorType.Name + "].\r\nIf this validator already has a parameterless constructor defined, see InnerException for more information.", ex);
                }
                string currentProperty = "";
                try {
                    foreach (KeyValuePair<string, string> kvp in validator.ValidatorAttributes) {
                        currentProperty = kvp.Key;
                        PropertyInfo pi = attr.GetType().GetProperty(kvp.Key);
                        pi.SetValue(attr, Convert.ChangeType(kvp.Value, pi.PropertyType), null);
                    }
                } catch (Exception ex) {
                    throw new Exception("Error setting properties from XML configuration, current property [" + currentProperty + "]. InnerException may have more details.", ex);
                }
            }
            if (!String.IsNullOrEmpty(validator.ErrorMessage)) {
                attr.ErrorMessage = validator.ErrorMessage;
            }
            if (!String.IsNullOrEmpty(validator.ErrorMessageResourceName)) {
                attr.ErrorMessageResourceName = validator.ErrorMessageResourceName;
            }
            if (validator.ErrorMessageResourceType != null) {
                attr.ErrorMessageResourceType = validator.ErrorMessageResourceType;
            }
            return attr;
        }
    }
}
