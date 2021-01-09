using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace WebFormsUtilities.ValueProviders {
    /// <summary>
    /// Provides values from an HttpContext's Form values.
    /// </summary>
    public class WFHttpContextValueProvider : IWFValueProvider {
        private HttpContext _HttpContext = null;
        private HttpRequest _Request = null;
        public WFHttpContextValueProvider(HttpContext context) {
            _HttpContext = context;
            _Request = _HttpContext.Request;
        }
        public WFHttpContextValueProvider(HttpRequest request) {
            _Request = request;
        }

        #region IWFValueProvider Members

        public bool ContainsKey(string keyName) {
            return _Request.Form.AllKeys.Contains(keyName);
        }

        public object KeyValue(string keyName, object defaultValue) {
            if (_Request.Form.AllKeys.Contains(keyName)
                && !String.IsNullOrEmpty(_Request.Form[keyName])) {
                return _Request.Form[keyName];
            } else {
                return defaultValue;
            }
        }

        public object KeyValue(string keyName) {
            return _Request.Form[keyName].Trim();
        }

        public IEnumerable<String> GetPropertyEnumerator() {
            return _Request.Form.AllKeys.AsEnumerable<String>();
        }

        #endregion
    }
}
