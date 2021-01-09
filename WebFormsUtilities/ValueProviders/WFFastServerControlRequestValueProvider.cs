using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace WebFormsUtilities.ValueProviders {
    /// <summary>
    /// Provides values from an HttpContext's form or query values. Form values take precedence.<br/>
    /// The provider will strip the asp.net prefix attached to control IDs<br/>
    /// ie: 'some$prefix$myControl' can be retrieved using only 'myControl'
    /// </summary>
    public class WFFastServerControlRequestValueProvider : IWFValueProvider {
        Dictionary<string, string> formValues = new Dictionary<string, string>();
        public WFFastServerControlRequestValueProvider(HttpContext context) {
            foreach (string key in context.Request.QueryString.AllKeys) {
                //Grab query string values
                if (formValues.ContainsKey(key)) {
                    formValues[key] = context.Request.QueryString[key];
                } else {
                    formValues.Add(key, context.Request.QueryString[key]);
                }
            }
            //Grab form values and add them after stripping the .net server control prefix
            foreach (string key in context.Request.Form.AllKeys) {
                string friendlyName = "";
                int dIndex = key.LastIndexOf('$');
                if (dIndex < 0) { dIndex = key.IndexOf('$'); }
                if (dIndex < 0
                    || key.Length < (dIndex + 1)) {
                    friendlyName = key;
                } else {
                    friendlyName = key.Substring(dIndex) + 1;
                }

                if (formValues.ContainsKey(friendlyName)) {
                    formValues[friendlyName] = context.Request.Form[key];
                } else {
                    formValues.Add(friendlyName, context.Request.QueryString[key]);
                }
            }
        }


        #region IWFValueProvider Members

        public bool ContainsKey(string keyName) {
            return formValues.ContainsKey(keyName);
        }

        public object KeyValue(string keyName) {
            return formValues[keyName];
        }

        public object KeyValue(string keyName, object defaultValue) {
            if (!formValues.ContainsKey(keyName)
                || String.IsNullOrEmpty(formValues[keyName])) { return defaultValue; }
            return formValues[keyName];
        }

        public IEnumerable<String> GetPropertyEnumerator() {
            return formValues.Keys.AsEnumerable<String>();
        }

        #endregion
    }
}
