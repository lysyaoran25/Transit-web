using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Reflection;
using System.Web;

namespace WebFormsUtilities
{
    /// <summary>
    /// Provides a generic interface to provide values from a dictionary, HttpContext or an object (via reflection).
    /// </summary>
    public interface IWFValueProvider
    {
        /// <summary>
        /// Check if the ValueProvider's keys contains keyName.
        /// </summary>
        /// <param name="keyName">The name of the key to check for.</param>
        /// <returns>Returns true if the key is found.</returns>
        bool ContainsKey(string keyName);
        /// <summary>
        /// Returns the value of the given key from the provider.<br/>
        /// This method may not check if the key already exists depending on implementation of the provider.
        /// </summary>
        /// <param name="keyName">The key of the value to return.</param>
        /// <returns>Returns an object.</returns>
        object KeyValue(string keyName);
        /// <summary>
        /// Performs ContainsKey() check and returns defaultValue if null/empty
        /// </summary>
        /// <param name="keyName">The name of the value's key.</param>
        /// <param name="defaultValue">The default value to return if null/empty.</param>
        /// <returns>Returns an object.</returns>
        object KeyValue(string keyName, object defaultValue);

        /// <summary>
        /// Allows to walk through all the properties provided by this value provider.<br/>
        /// IE: A Dictionary provider would walk through all dictionary keys.<br/>
        ///     An HttpContext provider would walk through all form value keys.<br/>
        ///     An Object provider would walk through all applicable PropertyInfo.Name's.
        /// </summary>
        /// <returns></returns>
        IEnumerable<String> GetPropertyEnumerator();

    }

}
