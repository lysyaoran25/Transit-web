using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebFormsUtilities.ValueProviders {
    /// <summary>
    /// Provides values from a Dictionary of string,string.
    /// </summary>
    public class WFDictionaryValueProvider : IWFValueProvider {
        private Dictionary<string, string> StringDictionary = null;
        public WFDictionaryValueProvider(Dictionary<string, string> dict) {
            StringDictionary = dict;
        }
        #region IWFValueProvider Members

        public bool ContainsKey(string keyName) {
            return StringDictionary.ContainsKey(keyName);
        }

        public object KeyValue(string keyName, object defaultValue) {
            if (StringDictionary.ContainsKey(keyName)) {
                if (String.IsNullOrEmpty(StringDictionary[keyName])) { return defaultValue; }
                return StringDictionary[keyName];
            } else {
                return defaultValue;
            }
        }

        public object KeyValue(string keyName) {
            return StringDictionary[keyName];
        }

        public IEnumerable<String> GetPropertyEnumerator() {
            return StringDictionary.Keys.AsEnumerable();
        }

        #endregion
    }
}
