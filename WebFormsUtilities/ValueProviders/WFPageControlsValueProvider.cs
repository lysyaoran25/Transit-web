using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;

namespace WebFormsUtilities.ValueProviders {
    /// <summary>
    /// Caches the page controls on constructor (ByRef) and then provides their values when needed.
    /// Methods like UpdateModel() use IWFValueProvider's.
    /// </summary>
    public class WFPageControlsValueProvider : IWFValueProvider {
        private Control _Page = null;
        private string _Prefix = "";
        private Dictionary<string, Control> _WebControls = new Dictionary<string, Control>();

        /// <summary>
        /// Provide values against an ASP.net server control (or page)
        /// </summary>
        /// <param name="page">The instance of the page or control on which values will be flattened.</param>
        /// <param name="prefix">An optional prefix to select (server side) control names.</param>
        public WFPageControlsValueProvider(Control page, string prefix) {
            _Page = page;
            _Prefix = prefix;
            _WebControls = WebControlUtilities.FlattenPageControls(_Page);
        }


        #region IWFValueProvider Members
        /// <summary>
        /// Check if the page/control has a child with a given (server) ID
        /// </summary>
        /// <param name="keyName">The ID of the control.</param>
        /// <returns>Returns true if the control has been found.</returns>
        public bool ContainsKey(string keyName) {
            return _WebControls.ContainsKey(keyName);
        }

        /// <summary>
        /// Use WebControlUtilities.GetControlValue() to obtain the value of the control with a matching (server) ID.
        /// This method checks if the control is present in the collection (ContainsKey()) and returns defaultValue if it is not found<br/>
        /// or if the value of the control (when cast to a string) is null or empty.
        /// </summary>
        /// <param name="keyName">The (server) ID of the control to get the value from.</param>
        /// <param name="defaultValue">The value to return if the control is not found.</param>
        /// <returns>The value of the control or defaultValue if not found.</returns>
        public object KeyValue(string keyName, object defaultValue) {
            if (ContainsKey(keyName)) {
                string ctlValue = WebControlUtilities.GetControlValue(_WebControls[keyName]);
                if (String.IsNullOrEmpty(ctlValue)) {
                    return defaultValue;
                }
                return ctlValue;
            }
            return defaultValue;
        }

        /// <summary>
        /// Use WebControlUtilities.GetControlValue() to obtain the value of the control with a matching (server) ID.
        /// The collection will not be scanned to verify the control is present.
        /// </summary>
        /// <param name="keyName">The (server) ID of the control to get the value from.</param>
        /// <returns>The value of the control.</returns>
        public object KeyValue(string keyName) {
            return WebControlUtilities.GetControlValue(_WebControls[keyName]);
        }

        public IEnumerable<String> GetPropertyEnumerator() {
            return _WebControls.Keys.AsEnumerable<String>();
        }
        #endregion
    }
}
