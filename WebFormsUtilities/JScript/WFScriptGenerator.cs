using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using WebFormsUtilities.DataAnnotations;

namespace WebFormsUtilities.Json {
    public class WFScriptGenerator {
        public static HtmlTag SetupClientValidationScriptHtmlTag() {
            //<script src="WFUtilities.axd?script=SetupClientValidation" type="text/javascript"></script>
            if (WFUtilities.HandlerRegistered) {
                //Use the cool handler to keep excess JavaScript out of the page HTML
                //The script will be cached (on the client) from the handler, so it should be fast!
                return new HtmlTag("script", new { type = "text/javascript", language = "javascript", src = "/WFUtilities.axd?script=SetupClientValidation&ver=20120508" });
            } else {
                //Inject the javascript right onto the page
                //Adds to what the page must download.
                return new HtmlTag("script", new { type = "text/javascript", language = "javascript" }) { InnerText = JSResources.SetupClientValidation };
            }
        }

        public static HtmlTag SetupClientUnobtrusiveValidationScriptHtmlTag() {
            //<script src="WFUtilities.axd?script=SetupUnobtrusiveValidation" type="text/javascript"></script>
            if (WFUtilities.HandlerRegistered) {
                //Use the cool handler to keep excess JavaScript out of the page HTML
                //The script will be cached (on the client) from the handler, so it should be fast!
                return new HtmlTag("script", new { type = "text/javascript", language = "javascript", src = "/WFUtilities.axd?script=SetupUnobtrusiveValidation" });
                //return new HtmlTag("script", new { type = "text/javascript", language = "javascript", src = "WFUtilities.axd?script=SetupUnobtrusiveValidationAjax" });
            } else {
                //Inject the javascript right onto the page
                //Adds to what the page must download.
                return new HtmlTag("script", new { type = "text/javascript", language = "javascript" }) { InnerText = JSResources.jqueryValidateUnobtrusive };
                //return new HtmlTag("script", new { type = "text/javascript", language = "javascript" }) { InnerText = JSResources.jqueryUnobtrusiveAjax };
            }
        }

        /// <summary>
        /// Build and return script and JSON objects to enable client validation.
        /// This should be called from WFPageBase or WFUserControlBase
        /// </summary>
        /// <param name="metadata"></param>
        /// <returns></returns>
        public static string EnableClientValidationScript(WFModelMetaData metadata, string formId) {
            StringBuilder sb = new StringBuilder();
            sb.Append("if(!window.wfuClientValidationMetadata) { window.wfuClientValidationMetadata = []; }\r\n");
            sb.Append("window.wfuClientValidationMetadata.push(");

            List<JSONObject> fields = new List<JSONObject>();
            foreach (WFModelMetaProperty prop in metadata.Properties) {
                JSONObject field = new JSONObject();
                field.Attr("FieldName", prop.MarkupName);
                field.Attr("ReplaceValidationMessageContents", true);

                //Remove $'s which jQuery doesn't like in ID's
                string spanID = "";
                if (!String.IsNullOrEmpty(prop.OverriddenSpanID)) {
                    spanID = prop.OverriddenSpanID;
                } else {
                    spanID = prop.MarkupName + "_validationMessage";
                }
                spanID = spanID.Replace("$", @"\\$");
                field.Attr("ValidationMessageId", spanID);

                List<JSONObject> validationRules = new List<JSONObject>();
                foreach (object oVal in prop.ValidationAttributes) {
                    ValidationAttribute val = oVal as ValidationAttribute;
                    JSONObject valRule = new JSONObject();
                    JSONObject valParms = new JSONObject();
                    Type valType = oVal.GetType();
                    if (!String.IsNullOrEmpty(prop.OverriddenErrorMessage)) {
                        valRule.Attr("ErrorMessage", prop.OverriddenErrorMessage);
                    } else {
                        valRule.Attr("ErrorMessage", val.FormatErrorMessage(prop.DisplayName));
                    }

                    if (valType == typeof(StringLengthAttribute) || valType.IsSubclassOf(typeof(StringLengthAttribute))) {
                        valParms.Attr("maximumLength", ((StringLengthAttribute)oVal).MaximumLength);
                        valParms.Attr("minimumLength", 0);
                        valRule.Attr("ValidationType", "stringLength");
                        valRule.Attr("ValidationParameters", valParms);
                    } else if (valType == typeof(RequiredAttribute) || valType.IsSubclassOf(typeof(RequiredAttribute))) {
                        valRule.Attr("ValidationType", "required");
                        valRule.Attr("ValidationParameters", new JSONObjectEmpty());
                    } else if (valType == typeof(RangeAttribute) || valType.IsSubclassOf(typeof(RangeAttribute))) {
                        valParms.Attr("minimum", ((RangeAttribute)oVal).Minimum);
                        valParms.Attr("maximum", ((RangeAttribute)oVal).Maximum);
                        valRule.Attr("ValidationType", "range");
                        valRule.Attr("ValidationParameters", valParms);

                        //Create an additional 'number' validation
                        JSONObject numRule = new JSONObject();
                        JSONObject numParms = new JSONObject();
                        numRule.Attr("ErrorMessage", "The field " + prop.DisplayName + " must be a number.");
                        numRule.Attr("ValidationParameters", new JSONObjectEmpty());
                        numRule.Attr("ValidationType", "number");
                        validationRules.Add(numRule);
                    } else if (valType == typeof(RegularExpressionAttribute) || valType.IsSubclassOf((typeof(RegularExpressionAttribute)))) {
                        valRule.Attr("ValidationType", "regularExpression");
                        valRule.Attr("ValidationParameters", new JSONObject(new {
                            pattern = ((RegularExpressionAttribute)oVal).Pattern
                                .Replace("\\", "\\\\")
                                .Replace("\"", "\\\"")
                        }));
                    } else //Custom Validator
                    {
                        if (val as IWFClientValidatable != null) {
                            IWFClientValidatable valAttr = (IWFClientValidatable)val;
                            var cvrs = valAttr.GetClientValidationRules();
                            if (cvrs != null) {
                                bool firstRule = true;
                                foreach (var cvr in cvrs) {
                                    if (firstRule) {
                                        valRule.Attr("ValidationType", cvr.ValidationType);
                                        if (cvr.ValidationParameters != null) {
                                            foreach (KeyValuePair<string, object> kvp in cvr.ValidationParameters) {
                                                valParms.Attr(kvp.Key, kvp.Value);
                                            }
                                        }
                                        valRule.Attr("ValidationParameters", valParms);
                                        firstRule = false;
                                    } else {
                                        JSONObject vrx = new JSONObject();
                                        JSONObject vrxParms = new JSONObject();
                                        vrx.Attr("ErrorMessage", cvr.ErrorMessage);
                                        vrx.Attr("ValidationType", cvr.ValidationType);
                                        if (cvr.ValidationParameters != null) {
                                            foreach (KeyValuePair<string, object> kvp in cvr.ValidationParameters) {
                                                vrxParms.Attr(kvp.Key, kvp.Value);
                                            }
                                        }
                                        vrx.Attr("ValidationParameters", vrxParms);
                                        validationRules.Add(vrx);
                                    }
                                }
                            }
                        }
                    }
                    validationRules.Add(valRule);
                }
                field.Attr("ValidationRules", validationRules);
                fields.Add(field);
            }
            JSONObject jo = new JSONObject(new { Fields = fields, FormId = formId, ReplaceValidationSummary = false });

            sb.Append(jo.Render());

            sb.Append(");");
            return sb.ToString();
        }
    }
}
