using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using WebFormsUtilities.DataAnnotations;
using System.Reflection;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.UI.WebControls;
using WebFormsUtilities.WebControls;
using WebFormsUtilities.ValueProviders;
using System.Collections;

namespace WebFormsUtilities {
    public static class WebControlUtilities {

        public static Control FindControlRecursive(Control rootControl, string id) {
            if (rootControl.ID == id) { return rootControl; }
            foreach (Control controlToSearch in rootControl.Controls) {
                Control controlToReturn = FindControlRecursive(controlToSearch, id);
                if (controlToReturn != null) { return controlToReturn; }
            }
            return null;
        }
        /// <summary>
        /// Find all of the DataAnnotationValidatorControl controls that are children of rootControl.
        /// </summary>
        /// <param name="page">The root parent control whose children will be searched.</param>
        /// <returns></returns>
        public static List<DataAnnotationValidatorControl> FindValidators(Control rootControl) {
            List<DataAnnotationValidatorControl> validators = new List<DataAnnotationValidatorControl>();
            if (rootControl.Controls != null && rootControl.Controls.Count > 0) {
                foreach (Control cx in rootControl.Controls) {
                    //Is it a DataAnnotationValidator?
                    if (cx.GetType() == typeof(DataAnnotationValidatorControl)) {
                        validators.Add((DataAnnotationValidatorControl)cx);
                    }
                    //Does it have children? If so, scan them
                    if (cx.Controls != null && cx.Controls.Count > 0) {
                        foreach (DataAnnotationValidatorControl dvc in FindValidators(cx)) {
                            validators.Add(dvc);
                        }
                    }
                }
            }
            return validators;
        }

        /// <summary>
        /// Find or create a WFModelMetaProperty for the DataAnnotationValidatorControl.
        /// The WFModelMetaProperty will be added to the WFModelMetaData object.
        /// </summary>
        /// <param name="dvc">The DataAnnotationValidatorControl whose property needs to be added to metadata.</param>
        /// <param name="metadata">The existing metadata to search through.</param>
        /// <returns></returns>
        public static WFModelMetaProperty GetMetaPropertyFromValidator(Control rootControl, DataAnnotationValidatorControl dvc,
    WFModelMetaData metadata) {
            Type sourceType = dvc.SourceType;
            Control controlValidating = WebControlUtilities.FindControlRecursive(rootControl, dvc.ControlToValidate);
            WFModelMetaProperty metaproperty = metadata.Properties.FirstOrDefault(m => m.MarkupName == controlValidating.UniqueID);
            if (metaproperty == null) {
                metaproperty = new WFModelMetaProperty();
                metadata.Properties.Add(metaproperty);
            }

            metaproperty.PropertyName = dvc.PropertyName;
            metaproperty.MarkupName = controlValidating.UniqueID;

            if (String.IsNullOrEmpty(dvc.SourceTypeString)) {
                if (sourceType == null
                    && String.IsNullOrEmpty(dvc.XmlRuleSetName)
                    && dvc.Page as IWFGetValidationRulesForPage == null) {
                    throw new Exception("The SourceType and SourceTypeString properties are null/empty on one of the validator controls.\r\nPopulate either property.\r\nie: control.SourceType = typeof(Widget); OR in markup SourceTypeString=\"Assembly.Classes.Widget, Assembly\"");
                } else if (sourceType == null && !String.IsNullOrEmpty(dvc.XmlRuleSetName)) {
                    sourceType = WFUtilities.GetRuleSetForName(dvc.XmlRuleSetName).ModelType;
                } else if (sourceType == null && String.IsNullOrEmpty(dvc.XmlRuleSetName)) {
                    sourceType = ((IWFGetValidationRulesForPage)dvc.Page).GetValidationClassType();
                }
            } else {
                try {
                    sourceType = Type.GetType(dvc.SourceTypeString, true, true);
                } catch (Exception ex) {
                    throw new Exception("Couldn't resolve type " + dvc.SourceTypeString + ". You may need to specify the fully qualified assembly name.");
                }
            }

            PropertyInfo prop = WFUtilities.GetTargetProperty(dvc.PropertyName, sourceType);

            if (String.IsNullOrEmpty(dvc.XmlRuleSetName)) {
                foreach (var attr in prop.GetCustomAttributes(typeof(ValidationAttribute), true).OfType<ValidationAttribute>()) {
                    var displayNameAttr = prop.GetCustomAttributes(typeof(DisplayNameAttribute), true).OfType<DisplayNameAttribute>().FirstOrDefault();
                    string displayName = displayNameAttr == null ? prop.Name : displayNameAttr.DisplayName;

                    if (attr as IWFRequireValueProviderContext != null) {
                        ((IWFRequireValueProviderContext)attr).SetValueProvider(new WFPageControlsValueProvider(dvc.Page, ""));
                    }

                    metaproperty.DisplayName = displayName;
                    metaproperty.ValidationAttributes.Add(attr);
                    if (!attr.IsValid(GetControlValue(controlValidating))) {
                        metaproperty.HasError = true;
                        if (metaproperty.Errors == null) { metaproperty.Errors = new List<string>(); }
                        metaproperty.Errors.Add(attr.FormatErrorMessage(displayName));
                    }
                }

            } else {
                XmlDataAnnotationsRuleSet ruleset = WFUtilities.GetRuleSetForType(sourceType, dvc.XmlRuleSetName);
                metaproperty.DisplayName = dvc.PropertyName;
                try {
                    //It's OK to have a DataAnnotationValidatorControl for a property that has no validation rules
                    //defined in the XML.
                    XmlDataAnnotationsRuleSetProperty property = ruleset.Properties.FirstOrDefault(p => p.PropertyName == dvc.PropertyName);
                    if (property != null) {
                        foreach (var validator in property.Validators) {
                            ValidationAttribute attr = WFUtilities.GetValidatorInstanceForXmlDataAnnotationsValidator(validator);

                            if (attr as IWFRequireValueProviderContext != null) {
                                ((IWFRequireValueProviderContext)attr).SetValueProvider(new WFPageControlsValueProvider(dvc.Page, ""));
                            }

                            foreach (var key in validator.ValidatorAttributes.Keys) {
                                PropertyInfo pi = attr.GetType().GetProperty(key);
                                if (pi != null) {
                                    pi.SetValue(attr, Convert.ChangeType(validator.ValidatorAttributes[key], pi.PropertyType), null);
                                }
                            }
                            metaproperty.ValidationAttributes.Add(attr);
                            if (!attr.IsValid(GetControlValue(controlValidating))) {
                                metaproperty.HasError = true;
                                if (metaproperty.Errors == null) { metaproperty.Errors = new List<string>(); }
                                metaproperty.Errors.Add(validator.ErrorMessage);

                            }
                        }
                    }
                } catch (Exception ex) {
                    throw new Exception("Error trying to validate " + dvc.PropertyName + ", innerexception may have more details...\r\nMake sure ErrorMessage isn't specified in more than one place.", ex);
                }

            }
            return metaproperty;
        }


        /// <summary>
        /// Attempt to retrieve the string equivalent value of the webControl
        /// </summary>
        /// <param name="webControl">The control whose value will be returned.</param>
        /// <returns>A string equivalent of the control's value.</returns>
        public static string GetControlValue(Control webControl) {
            string val = "";
            Type tx = webControl.GetType();
            if (tx == typeof(TextBox)) {
                val = ((TextBox)webControl).Text;
            } else if (tx == typeof(DropDownList)) {
                DropDownList ddl = (DropDownList)webControl;
                if (ddl.SelectedItem != null) { val = ddl.SelectedValue; } else { val = ""; }
            } else if (tx == typeof(ListBox)) {
                ListBox lb = (ListBox)webControl;
                if (lb.SelectedItem != null) {
                    val = lb.SelectedValue;
                } else {
                    val = "";
                }
            } else if (tx == typeof(RadioButton)) {
                if (((RadioButton)webControl).Checked) {
                    val = "true";
                } else {
                    val = "false";
                }
            } else if (tx == typeof(CheckBox)) {
                if (((CheckBox)webControl).Checked) {
                    val = "true";
                } else {
                    val = "false";
                }
            } else {
                if (webControl as IWFControlValue != null) {
                    return ((IWFControlValue)webControl).GetControlValue().ToString();
                } else {
                    throw new Exception("Error trying to interpret control value of type [" + tx.Name + "]. The type was not recognized and the control does not implement IWFControlValue.");
                }
            }
            return val;
        }

        public static Dictionary<string, Control> FlattenPageControls(Control pageControl) {
            Dictionary<string, Control> controls = new Dictionary<string, Control>();

            foreach (Control cx in pageControl.Controls) {
                if (cx.ID != null) {
                    controls.Add(cx.ID, cx);
                }
                foreach (KeyValuePair<string, Control> kvp in FlattenPageControls(cx)) {
                    controls.Add(kvp.Key, kvp.Value);
                }
            }

            return controls;
        }

        public static void ApplyModelToPage(Control pageControl, object Model) {
            ApplyModelToPage(pageControl, Model, "");
        }

        public static void ApplyModelToPage(Control pageControl, object Model, string prefix) {
            WFObjectValueProvider provider = new WFObjectValueProvider(Model, prefix);
            ApplyModelToPage(pageControl, provider);
        }

        public static void ApplyModelToPage(Control pageControl, IWFValueProvider provider) {
            Dictionary<string, Control> webControls = FlattenPageControls(pageControl);

            foreach (KeyValuePair<string, Control> kvp in webControls) {
                if (provider.ContainsKey(kvp.Key)) {
                    Control wc = kvp.Value;
                    if (wc.GetType() == typeof(TextBox)) {
                        ((TextBox)wc).Text = provider.KeyValue(kvp.Key, "").ToString();
                    } else if (wc.GetType() == typeof(DropDownList)) {
                        DropDownList ddl = (DropDownList)wc;
                        if (ddl.Items != null && ddl.Items.Count > 0) {
                            ddl.SelectedIndex = ddl.Items.IndexOf(ddl.Items.FindByValue(provider.KeyValue(kvp.Key, "").ToString()));
                        }
                    } else if (wc.GetType() == typeof(ListBox)) {
                        ListBox lb = (ListBox)wc;
                        if (lb.Items != null && lb.Items.Count > 0) {

                            if (lb.SelectionMode == ListSelectionMode.Single) {
                                lb.SelectedIndex = lb.Items.IndexOf(lb.Items.FindByValue(provider.KeyValue(kvp.Key, "").ToString()));
                            } else {
                                object val = provider.KeyValue(kvp.Key, "");
                                if (val != null) {
                                    if (val as IEnumerable != null
                                        && val.GetType() != typeof(String)) {
                                        foreach (var x in val as IEnumerable) {
                                            lb.Items.FindByValue(x.ToString()).Selected = true;
                                        }
                                    }
                                    else {
                                        lb.SelectedIndex = lb.Items.IndexOf(lb.Items.FindByValue(provider.KeyValue(kvp.Key, "").ToString()));
                                    }
                                }
                            }
                        }
                    } else if (wc.GetType() == typeof(RadioButton)) {
                        RadioButton rb = (RadioButton)wc;
                        object val = provider.KeyValue(kvp.Key);
                        if (val != null) {
                            string valStr = val.ToString();
                            if (String.IsNullOrEmpty(valStr)) { rb.Checked = false; } else {
                                string[] truth = { "1", "true", "true,false" };
                                if (truth.Contains(valStr.ToLower())) {
                                    rb.Checked = true;
                                }
                            }
                        } else {
                            rb.Checked = false;
                        }
                    } else if (wc.GetType() == typeof(CheckBox)) {
                        CheckBox cb = (CheckBox)wc;
                        object val = provider.KeyValue(kvp.Key);
                        if (val != null) {
                            string valStr = val.ToString();
                            if (String.IsNullOrEmpty(valStr)) { cb.Checked = false; } else {
                                string[] truth = { "1", "true", "true,false" };
                                if (truth.Contains(valStr.ToLower())) {
                                    cb.Checked = true;
                                }
                            }
                        } else {
                            cb.Checked = false;
                        }
                    } else {
                        //Not a known type, does it implement IWFControlValue?
                        if(wc as IWFControlValue != null) {
                            //Set it through the interface
                            ((IWFControlValue)kvp.Value).SetControlValue(provider.KeyValue(kvp.Key));
                        } else {
                            //Not a known type and doesn't implement the interface. We don't know how to assign values to this control.
                            throw new Exception("Error trying to apply value to control " + wc.ID + " typeof [" + wc.GetType().Name + "]. It is not a known type and does not implement IWFControlValue.");
                        }
                    }
                }
            }

        }

    }
}
