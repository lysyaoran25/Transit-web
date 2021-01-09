using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace WebFormsUtilities.ValueProviders {
    /// <summary>
    /// Provides values via reflection directly from an object and its properties.
    /// </summary>
    public class WFObjectValueProvider : IWFValueProvider {
        private object _Model = null;
        private string _Prefix = "";
        private PropertyInfo[] _Properties = null;
        /// <summary>
        /// Provide values to validate against from an object (rather than, say, an HTTP request)
        /// </summary>
        /// <param name="model">The object which already has values populated</param>
        /// <param name="prefix">An optional prefix to prepend when checking property names</param>
        public WFObjectValueProvider(object model, string prefix) {
            _Model = model;
            _Properties = _Model.GetType().GetProperties();
            _Prefix = prefix;
        }
        #region IWFValueProvider Members

        public bool ContainsKey(string keyName) {
            if (!String.IsNullOrEmpty(_Prefix)) {
                if (_Properties.FirstOrDefault(p => (_Prefix.ToLower() + p.Name.ToLower()) == keyName.ToLower()) != null) {
                    return true;
                }
            } else {
                if (_Properties.FirstOrDefault(p => p.Name.ToLower() == keyName.ToLower()) != null) {
                    return true;
                }
            }
            return false;
        }

        public object KeyValue(string keyName, object defaultValue) {
            if (_Model == null) { return null; }
            PropertyInfo pi = null;
            if (!String.IsNullOrEmpty(_Prefix)) {
                pi = _Properties.First(p => (_Prefix.ToLower() + p.Name.ToLower()) == keyName.ToLower());
            } else {
                pi = _Properties.First(p => p.Name.ToLower() == keyName.ToLower());
            }
            if (pi == null) { return defaultValue; }
            object piValue = pi.GetValue(_Model, null);
            if (piValue == null) { return defaultValue; }
            return piValue;
        }

        public object KeyValue(string keyName) {
            if (_Model == null) { return null; }
            PropertyInfo pi = null;
            if (!String.IsNullOrEmpty(_Prefix)) {
                pi = _Properties.First(p => (_Prefix.ToLower() + p.Name.ToLower()) == keyName.ToLower());
            } else {
                pi = _Properties.First(p => p.Name.ToLower() == keyName.ToLower());
            }
            return pi.GetValue(_Model, null);
        }

        public IEnumerable<String> GetPropertyEnumerator() {
            return _Properties.Select(p => p.Name).AsEnumerable<String>();
        }
        #endregion
    }
}
