using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Reflection;

namespace WebFormsUtilities.RuleProviders {
    public class WFTypeRuleProvider : IWFRuleProvider {
        public Type ValidationType { get; set; }
        //private Type ProxyType { get; set; }
        private Dictionary<string, WFTypeRuleProviderProperty> Properties { get; set; }
        private IEnumerable<ValidationAttribute> modelAttribs = null;

        private PropertyInfo[] _PropertyInfoObjects = null;

        public IEnumerable<PropertyInfo> GetProperties() {
            return _PropertyInfoObjects;
        }

        public WFTypeRuleProvider(object model) {
            ValidationType = model.GetType();

            var metaDataAtt = ValidationType.GetCustomAttributes(typeof(MetadataTypeAttribute), true).OfType<MetadataTypeAttribute>().FirstOrDefault();
            if (metaDataAtt != null) {
                ValidationType = metaDataAtt == null ? null : metaDataAtt.MetadataClassType;
            }

            InitializeType(ValidationType);
        }
        public WFTypeRuleProvider(Type t) {
            ValidationType = t;

            var metaDataAtt = ValidationType.GetCustomAttributes(typeof(MetadataTypeAttribute), true).OfType<MetadataTypeAttribute>().FirstOrDefault();
            if (metaDataAtt != null) {
                ValidationType = metaDataAtt == null ? null : metaDataAtt.MetadataClassType;
            }

            InitializeType(ValidationType);
        }
        ///// <summary>
        ///// Only use this overload if you want to validate against BOTH proxy and model types.
        ///// </summary>
        ///// <param name="model"></param>
        ///// <param name="proxy"></param>
        //public WFTypeRuleProvider(object model, Type proxy)
        //{
        //    ValidationType = model.GetType();
        //    ProxyType = proxy;
        //}
        ///// <summary>
        ///// Only use this overload if you want to validate against BOTH proxy and model types.
        ///// </summary>
        ///// <param name="modelType"></param>
        ///// <param name="proxyType"></param>
        //public WFTypeRuleProvider(Type modelType, Type proxyType)
        //{
        //    ValidationType = modelType;
        //    ProxyType = proxyType;
        //}

        //Was in WFUtilities for doing both buddy and model types, useful for future
        /*                    if (metaDataType != null)
                    {
                        PropertyInfo buddyPI = buddyProps.FirstOrDefault(p => p.Name == (prefix + pi.Name));
                        if (buddyPI != null)
                        {
                            object[] custAtts = pi.GetCustomAttributes(false);
                            object[] buddyAtts = buddyPI.GetCustomAttributes(false);
                            attribs = new object[buddyAtts.Length + custAtts.Length];
                            buddyAtts.CopyTo(attribs, 0);
                            custAtts.CopyTo(attribs, buddyAtts.Length);
                        }
                        else
                        {
                            attribs = pi.GetCustomAttributes(false);
                        }
                    }
                    else
                    {
                        attribs = pi.GetCustomAttributes(false);
                    }

                    if (attribs.Length == 0) { continue; } //no attributes to validate*/

        private void InitializeType(Type t) {
            //There is probably a faster way to do this -- ie: IsSubClassOf ? I'm sure I've seen something better, in any case...
            modelAttribs = t.GetCustomAttributes(false).Where(x => x as ValidationAttribute != null).Cast<ValidationAttribute>();
            var modelDisplayAttr = t.GetCustomAttributes(typeof(DisplayNameAttribute), true).OfType<DisplayNameAttribute>().FirstOrDefault();
            ModelDisplayName = modelDisplayAttr == null ? t.Name : modelDisplayAttr.DisplayName;

            Properties = new Dictionary<string, WFTypeRuleProviderProperty>();
            _PropertyInfoObjects = t.GetProperties();
            foreach (PropertyInfo pi in _PropertyInfoObjects) {
                var displayNameAttr = pi.GetCustomAttributes(typeof(DisplayNameAttribute), true).OfType<DisplayNameAttribute>().FirstOrDefault();
                string displayName = displayNameAttr == null ? pi.Name : displayNameAttr.DisplayName;
                Properties.Add(pi.Name.ToLower(), new WFTypeRuleProviderProperty() {
                    DisplayName = displayName,
                    ValidationAttributes = pi.GetCustomAttributes(false).Where(x => x as ValidationAttribute != null).Cast<ValidationAttribute>()
                });
            }
        }
        #region IWFRuleProvider Members

        public IEnumerable<ValidationAttribute> GetClassValidationAttributes() {
            return modelAttribs;
        }

        public IEnumerable<ValidationAttribute> GetPropertyValidationAttributes(string propertyName) {
            return Properties.ContainsKey(propertyName.ToLower()) ?
                Properties[propertyName.ToLower()].ValidationAttributes : new List<ValidationAttribute>();
        }

        public string GetDisplayNameForProperty(string propertyName) {
            return Properties.ContainsKey(propertyName.ToLower()) ?
                Properties[propertyName.ToLower()].DisplayName : null;
        }

        public string ModelDisplayName { get; set; }

        #endregion
    }

    public class WFTypeRuleProviderProperty {
        PropertyInfo PropertyInfo { get; set; }
        public IEnumerable<ValidationAttribute> ValidationAttributes { get; set; }
        public string DisplayName { get; set; }
    }
}
