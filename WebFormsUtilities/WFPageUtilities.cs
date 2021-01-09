using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Reflection;
using System.Web.UI;
using System.Resources;
using System.IO;
using WebFormsUtilities.Json;
using WebFormsUtilities.DataAnnotations;
using WebFormsUtilities.RuleProviders;
using WebFormsUtilities.ValueProviders;

namespace WebFormsUtilities {
    public static class WFPageUtilities {
        /// <summary>
        /// This method can be used if WFUtilitiesJquery.js is not included in the project.<br/>
        /// Returns a &lt;script&gt; tag which should be placed in &lt;head&gt; after jQuery.
        /// </summary>
        /// <returns>Returns a &lt;script&gt; tag which should be placed in &lt;head&gt; after jQuery.</returns>
        public static string ScriptRegisterClientFunctions() {
            return new HtmlTag("script") { InnerText = JSResources.WFUtilitiesJquery }.Render();
        }

        /// <summary>
        /// Call this method when posting back from the JavaScript webfu.callPage(); function<br/>
        /// Use Request["JSMethod"] to find a matching Page method that is decorated with WFJScriptMethod<br/>
        /// This prevents methods from being called by JavaScript unless explicitly opt-in.<br/>
        /// The method must accept an [object] and an [EventArgs]. As of this compile, these will be empty.<br/>
        /// </summary>
        public static void CallJSMethod(Control pageControl, HttpRequest request) {
            if (!String.IsNullOrEmpty(request["JSMethod"])) {
                MethodInfo mi = pageControl.GetType().GetMethod(request["JSMethod"], BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                if (mi != null) {
                    if (mi.GetCustomAttributes(typeof(WFJScriptMethodAttribute), false).Length > 0) {
                        mi.Invoke(pageControl, new object[] { null, new EventArgs() });
                    }
                } else {
                    throw new Exception("No matching method " + request["JSMethod"] + " that is marked with [WFJScriptMethod] attribute.");
                }
            }
        }

        /// <summary>
        /// Validate the model against form values (not against itself).
        /// </summary>
        /// <typeparam name="TModel">The type of the model tied to this page</typeparam>
        /// <param name="metadata">The metadata object which stores validation information. This usually lives on the Html object.</param>
        /// <param name="model">The model being validated.</param>
        /// <param name="context">The HTTP context where form values are stored to validate. This is usually HttpContext.Current.</param>
        /// <returns>Returns 'true' if the values in the form data validate successfully.</returns>
        public static bool TryValidateModel<TModel>(WFModelMetaData metadata, TModel model, HttpContext context) {
            return WFUtilities.TryValidateModel(model, "", new WFHttpContextValueProvider(context), metadata, new WFTypeRuleProvider(model));
        }

        /// <summary>
        /// Validate the model against form values (not against itself).
        /// </summary>
        /// <typeparam name="TModel">The type of the model tied to this page</typeparam>
        /// <param name="metadata">The metadata object which stores validation information. This usually lives on the Html object.</param>
        /// <param name="model">The model being validated.</param>
        /// <param name="context">The HTTP context where form values are stored to validate. This is usually HttpContext.Current.</param>
        /// <param name="prefix">The prefix to separate different objects in form data.<br/>
        /// ie: object1_FirstName=John, object2_FirstName=Joe</param>
        /// <returns>Returns 'true' if the values in the form data validate successfully.</returns>
        public static bool TryValidateModel<TModel>(WFModelMetaData metadata, TModel model, HttpContext context, string prefix) {
            return WFUtilities.TryValidateModel(model, prefix, new WFHttpContextValueProvider(context), metadata, new WFTypeRuleProvider(model));
        }

        /// <summary>
        /// Validate the model against form values (not against itself).<br/>
        /// Use WFUtilities.TryValidateModel() to validate against targets other than the current HttpRequest.
        /// </summary>
        /// <typeparam name="TModel">The type of the model object to be validated.</typeparam>
        /// <param name="wfView">The page or usercontrol implementing IWebFormsView&lt;TModel&gt;</param>
        /// <returns>Returns 'true' if the values in the form data validate successfully.</returns>
        public static bool TryValidateModel<TModel>(IWebFormsView<TModel> wfView) {
            return TryValidateModel(wfView, wfView.Model.GetType(), "");
        }

        /// <summary>
        /// Validate the model against form values (not against itself).<br/>
        /// Use WFUtilities.TryValidateModel() to validate against targets other than the current HttpRequest.
        /// </summary>
        /// <typeparam name="TModel">The type of the model object to be validated.</typeparam>
        /// <param name="wfView">The page or usercontrol implementing IWebFormsView&lt;TModel&gt;</param>
        /// <param name="prefix">Optional. The prefix to separate different objects in form data.<br/>
        /// ie: object1_FirstName=John, object2_FirstName=Joe</param>
        /// <returns>Returns 'true' if the values in the form data validate successfully.</returns>
        public static bool TryValidateModel<TModel>(IWebFormsView<TModel> wfView, string prefix) {
            return TryValidateModel(wfView, null, prefix);
        }
        /// <summary>
        /// Validate the model against form values (not against itself).<br/>
        /// Use WFUtilities.TryValidateModel() to validate against targets other than the current HttpRequest.
        /// </summary>
        /// <typeparam name="TModel">The type of the model object to be validated.</typeparam>
        /// <param name="wfView">The page or usercontrol implementing IWebFormsView&lt;TModel&gt;</param>
        /// <param name="proxyClass">Optional. Validation can use this class to validate against, instead of the model class.</param>
        /// <returns>Returns 'true' if the values in the form data validate successfully.</returns>
        public static bool TryValidateModel<TModel>(IWebFormsView<TModel> wfView, Type proxyClass) {
            return TryValidateModel(wfView, proxyClass, "");
        }

        public static bool TryValidateModel<TModel>(IWebFormsView<TModel> wfView, XmlDataAnnotationsRuleSet ruleSet) {
            List<string> errors = new List<string>();
            IWFRuleProvider ruleProvider = new WFXmlRuleSetRuleProvider(ruleSet);
            return WFUtilities.TryValidateModel(wfView.Model, "", new WFHttpContextValueProvider(HttpContext.Current), wfView.Html.MetaData, ruleProvider);

        }

        /// <summary>
        /// Validate the model against form values (not against itself).<br/>
        /// Use WFUtilities.TryValidateModel() to validate against targets other than the current HttpRequest.
        /// </summary>
        /// <typeparam name="TModel">The type of the model object to be validated.</typeparam>
        /// <param name="wfView">The page or usercontrol implementing IWebFormsView&lt;TModel&gt;</param>
        /// <param name="proxyClass">Optional. Validation can use this class to validate against, instead of the model class.</param>
        /// <param name="prefix">Optional. The prefix to separate different objects in form data.<br/>
        /// ie: object1_FirstName=John, object2_FirstName=Joe</param>
        /// <returns>Returns 'true' if the values in the form data validate successfully.</returns>
        public static bool TryValidateModel<TModel>(IWebFormsView<TModel> wfView, Type proxyClass, string prefix) {
            List<string> errors = new List<string>();
            return WFUtilities.TryValidateModel(wfView.Model, prefix, new WFHttpContextValueProvider(HttpContext.Current), wfView.Html.MetaData, new WFTypeRuleProvider(proxyClass));
        }


        public static string EnableClientValidation(WFModelMetaData WFMetaData) {
            return EnableClientValidation(WFMetaData, "");
        }

        /// <summary>
        /// !! MUST be run at the end of the form in markup. !!
        /// Outputs a script tag containing JavaScript code to enable validation on client side.
        /// </summary>
        /// <returns></returns>
        public static string EnableClientValidation(WFModelMetaData WFMetaData, string formId) {
            return
                (new HtmlTag("script", new { type = "text/javascript", language = "javascript" }) { InnerText = WFScriptGenerator.EnableClientValidationScript(WFMetaData, formId) }.Render()) +
                WFScriptGenerator.SetupClientValidationScriptHtmlTag().Render();
        }

        /// <summary>
        /// Updates the specified model instance using values from the value provider.
        /// </summary>
        /// <typeparam name="TModel">The type of model object</typeparam>
        /// <param name="model">The model instance to update</param>
        public static void UpdateModel<TModel>(HttpRequest request, TModel model) {
            UpdateModel<TModel>(request, model, "");
        }
        /// <summary>
        /// Updates the specified model instance using values from the value provider.
        /// </summary>
        /// <typeparam name="TModel">The type of model object</typeparam>
        /// <param name="model">The model instance to update</param>
        /// <param name="prefix">The prefix to use when looking up values in the value provider</param>
        public static void UpdateModel<TModel>(HttpRequest request, TModel model, string prefix) {
            WFHttpContextValueProvider vp = new WFHttpContextValueProvider(request);
            UpdateModel<TModel>(vp, model, prefix, null, new string[] { });
        }
        /// <summary>
        /// Updates the specified model instance using values from the value provider.
        /// </summary>
        /// <typeparam name="TModel">The type of model object</typeparam>
        /// <param name="model">The model instance to update</param>
        /// <param name="includeProperties">A list of properties of the model to update</param>
        public static void UpdateModel<TModel>(HttpRequest request, TModel model, string[] includeProperties) {
            WFHttpContextValueProvider vp = new WFHttpContextValueProvider(request);
            UpdateModel<TModel>(vp, model, "", includeProperties, new string[] { });
        }
        /// <summary>
        /// Updates the specified model instance using values from the value provider.
        /// </summary>
        /// <typeparam name="TModel">The type of model object</typeparam>
        /// <param name="model">The model instance to update</param>
        /// <param name="prefix">The prefix to use when looking up values in the value provider</param>
        /// <param name="includeProperties">A list of properties of the model to update</param>
        public static void UpdateModel<TModel>(HttpRequest request, TModel model, string prefix, string[] includeProperties) {
            WFHttpContextValueProvider vp = new WFHttpContextValueProvider(request);
            UpdateModel<TModel>(vp, model, prefix, includeProperties, new string[] { });
        }

        /// <summary>
        /// Updates the specified model instance using values from the value provider.
        /// </summary>
        /// <typeparam name="TModel">The type of the model object.</typeparam>
        /// <param name="model">The model instance to update.</param>
        /// <param name="prefix">The prefix to use when looking up values in the value provider.</param>
        /// <param name="includeProperties">A list of properties of the model to update.</param>
        /// <param name="excludeProperties">A list of properties to explicitly exclude from the update. These are excluded even if they are listed in the includeProperties parameter list.</param>
        public static void UpdateModel<TModel>(IWFValueProvider valueprovider, TModel model, string prefix, string[] includeProperties, string[] excludeProperties) {
            if (model == null) { throw new Exception("Model cannot be null!"); }
            Type t = typeof(TModel);
            PropertyInfo[] props = t.GetProperties();

            //var query = props.AsQueryable();
            var query = valueprovider.GetPropertyEnumerator();
            if (includeProperties != null) { query = query.Where(p => includeProperties.Contains(p)); }
            if (excludeProperties != null && excludeProperties.Length > 0) { query = query.Where(p => !excludeProperties.Contains(p)); }

            foreach (string s in query) {
                string propExpression = s;
                //When searching for the target property, we ignore the prefix
                if (!String.IsNullOrEmpty(prefix) && s.StartsWith(prefix)) {
                    //If there is a prefix, and it is found in this string, remove it
                    propExpression = s.Substring(prefix.Length);
                }
                //Use the resulting string to find the target property without the prefix
                PropertyInfo pi = WFUtilities.GetTargetProperty(propExpression, t, true);
                object targetObject = WFUtilities.GetTargetObject(propExpression, model);
                if (pi != null) {
                    try {
                        if (pi.PropertyType.IsEnum) {
                            pi.SetValue(targetObject, Enum.Parse(pi.PropertyType, valueprovider.KeyValue(prefix + s).ToString()), null);
                        } else if (pi.PropertyType == typeof(Int32?)
                            || pi.PropertyType == typeof(Double?)
                            || pi.PropertyType == typeof(DateTime?)) {

                            object kV = valueprovider.KeyValue(prefix + s);
                            if (kV == null) { pi.SetValue(targetObject, null, null); } else {
                                pi.SetValue(targetObject, WFUtilities.ParseNullable(pi.PropertyType, kV.ToString()), null);
                            }
                        } else if (pi.PropertyType == typeof(Boolean?) || pi.PropertyType == typeof(bool)) {
                            string[] trueValues = new string[] { "true", "true,false", "on" };

                            object kV = valueprovider.KeyValue(prefix + s);
                            string kString = (kV == null ? "" : kV.ToString()).Trim();

                            if (String.IsNullOrEmpty(kString) || kString.ToLower() == "null") //If the value passed is empty...
                            {
                                if (pi.PropertyType == typeof(Boolean?)) //..and it is nullable, set to null.
                                { pi.SetValue(targetObject, null, null); } else if (pi.PropertyType == typeof(bool)) //..and not nullable, set to false.
                                {
                                    pi.SetValue(targetObject, false, null);
                                }
                            } else if (kString == "off" || kString == "false") //If the value passed is false/off...
                            {
                                pi.SetValue(targetObject, false, null); //...set to false.
                            } else if (trueValues.Contains(kString)) //If the value passed is "true"...
                            {
                                pi.SetValue(targetObject, true, null); //...set to true
                            } else {
                                //If all else fails, at least try to convert it to boolean
                                pi.SetValue(targetObject, Convert.ChangeType(kString, pi.PropertyType), null);
                            }
                        } else {
                            Type[] defaultTypes = new Type[] 
                            { typeof(byte), typeof(short), typeof(int), typeof(long), typeof(float), typeof(double), typeof(decimal),typeof(Decimal?),
                              typeof(DateTime) };
                            if (defaultTypes.Contains(pi.PropertyType)) {
                                object kV = valueprovider.KeyValue(prefix + s);
                                if (kV != null && !String.IsNullOrEmpty(kV.ToString())) {
                                    if (pi.PropertyType == typeof(Decimal?))
                                    {
                                        pi.SetValue(targetObject, Convert.ChangeType(kV, pi.PropertyType, null));
                                    }
                                    else
                                    {
                                        //Get the value
                                        pi.SetValue(targetObject, Convert.ChangeType(kV.ToString(), pi.PropertyType,new System.Globalization.CultureInfo("en-US")), null);
                                    }
                                } else {
                                    //Set default value
                                    if (pi.PropertyType == typeof(DateTime)) {
                                        pi.SetValue(targetObject, default(DateTime), null);
                                    } else {
                                        pi.SetValue(targetObject, Activator.CreateInstance(pi.PropertyType), null); //Set to default value
                                    }
                                }
                            } else {
                                pi.SetValue(targetObject, Convert.ChangeType((valueprovider.KeyValue(prefix + s)), pi.PropertyType), null);
                            }
                        }
                    } catch (Exception ex) {
                        throw new Exception("An exception occurred updating a model from property [" + s + "] value supplied [" + (valueprovider.KeyValue(prefix + s) ?? "null/empty").ToString() + "]. InnerException may have additional information. The message was: " + ex.Message, ex);
                    }
                }
            }
        }
    }
}
