using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Collections;
using System.Data.Linq;
using System.Globalization;
//using WebFormsUtilities.MVC2;
using System.Reflection;
using System.ComponentModel;

/* HtmlHelper_Extended.cs
 * msnead - 1/10/12
 * 
 * An extension of the HtmlHelper class for lambda function parameters.
 * 
 * Allows this: Html.TextBoxFor(m => m.FirstName);
 * Instead of : Html.TextBoxFor("FirstName", "FirstName", Model, Model.FirstName);
 * (one argument vs. 4 arguments)
 * 
 * The page (or calling class) must implement IWebFormsView<ModelType>, where ModelType is the type of the model used for validation and markup.
 * If you can't/don't implement this interface, use the non-lambda methods (HtmlHelper.cs)
 * 
 */


namespace WebFormsUtilities {

    /// <summary>
    /// Strongly-typed HTML helper. This class allows the use of lambda functions with HtmlHelper methods.<br/>
    /// These lambda functions will provide errors at compile-time and are more convenient since you can specify less arguments.<br/>
    /// This only applies for xFor() methods (ie: TextBoxFor()) which are only needed when validation is used.
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    public partial class HtmlHelper<TModel> {
        private static string GetHTMLValue(object objValue) {
            Binary binaryValue = objValue as Binary;
            if (binaryValue != null) { objValue = binaryValue.ToArray(); }
            byte[] byteArrayValue = objValue as Byte[];
            if (byteArrayValue != null) {
                objValue = Convert.ToBase64String(byteArrayValue);
            }
            return (objValue ?? (Object)"").ToString();
        }

        private static bool GetHTMLValueAsBoolean(object objValue) {
            if (objValue != null) {
                bool bVal = false;
                if (Boolean.TryParse(objValue.ToString(), out bVal)
                    && bVal) {
                    return true;
                } else {
                    try {
                        bVal = (Boolean)Convert.ChangeType(objValue, typeof(Boolean));
                        if (bVal) { return true; }
                    } catch (Exception ex) {
                        throw new Exception("Error converting [" + objValue.GetType().Name + "] ToString() [" + (objValue ?? new Object()).ToString() + "] to Boolean. See InnerException for more details.", ex);
                    }
                }
            }
            return false;
        }

        private static HtmlTag GetTagFromExpression<TProperty>(TagTypes tagType,
                    Expression<Func<TModel, TProperty>> expression,
                    TModel model,
                    WFModelMetaData metadata,
                    object htmlProperties,
                    HtmlHelper<TModel> htmlHelper,
                    IEnumerable<SelectListItem> selectList,
                    string optionLabel, bool useLabel, bool isChecked) {

            ModelMetaData mmd = ModelMetaData.FromLambdaExpression(expression, model);

            string reflectName = mmd.PropertyName;
            string markupName = mmd.PropertyName;

            HtmlTag tag = null;

            if (tagType == TagTypes.InputBox) {

                tag = new HtmlTag("input", true);
                tag.Attr("name", mmd.PropertyName);
                tag.Attr("id", mmd.PropertyName);
                tag.Attr("type", "text");
                tag.Attr("value", GetHTMLValue(mmd.ModelAccessor()));

            } else if (tagType == TagTypes.Checkbox) {

                tag = new HtmlTag("input", true);
                tag.Attr("name", mmd.PropertyName);
                tag.Attr("id", mmd.PropertyName);
                tag.Attr("type", "checkbox");
                if (GetHTMLValueAsBoolean(mmd.ModelAccessor())) {
                    tag.Attr("checked", "checked");
                }

            } else if (tagType == TagTypes.Hidden) {

                tag = new HtmlTag("input", true);
                tag.Attr("type", "hidden");
                tag.Attr("value", GetHTMLValue(mmd.ModelAccessor()));
                tag.Attr("name", mmd.PropertyName);
                tag.Attr("id", mmd.PropertyName);

            } else if (tagType == TagTypes.Label) {

                tag = new HtmlTag("label");
                tag.Attr("For", mmd.PropertyName);

                PropertyInfo pi = (PropertyInfo)((MemberExpression)expression.Body).Member;
                DisplayNameAttribute datt = pi.GetCustomAttributes(false).OfType<DisplayNameAttribute>().FirstOrDefault();
                string dispName = "";
                if (datt != null) {
                    dispName = datt.DisplayName ?? pi.Name;
                } else { dispName = pi.Name; }

                tag.InnerText = dispName;

            } else if (tagType == TagTypes.RadioButton) {

                tag = new HtmlTag("input", true);
                tag.Attr("name", mmd.PropertyName);
                tag.Attr("id", mmd.PropertyName);
                tag.Attr("type", "radio");
                tag.Attr("value", GetHTMLValue(mmd.ModelAccessor()));
                if (isChecked) {
                    tag.Attr("checked", "checked");
                }

            } else if (tagType == TagTypes.Select) {

                tag = new HtmlTag("select");
                tag.Attr("id", mmd.PropertyName);
                tag.Attr("name", mmd.PropertyName);

                if (useLabel) {
                    HtmlTag optx = new HtmlTag("option", new { value = "" }) { InnerText = optionLabel ?? "" };
                    tag.Children.Add(optx);
                }

                if (selectList != null) {
                    foreach (SelectListItem si in selectList) {
                        HtmlTag opt = new HtmlTag("option", new { value = si.Value ?? "" }) { InnerText = si.Text ?? "" };
                        if (si.Selected) { opt.Attr("selected", "selected"); }
                        tag.Children.Add(opt);
                    }
                }

            } else if (tagType == TagTypes.TextArea) {

                tag = new HtmlTag("textarea");
                tag.Attr("cols", "20");
                tag.Attr("rows", "2");
                tag.Attr("name", mmd.PropertyName);
                tag.Attr("id", mmd.PropertyName);
                tag.InnerText = GetHTMLValue(mmd.ModelAccessor());

            } else if (tagType == TagTypes.Span) {

                tag = new HtmlTag("span");
                tag.Attr("id", mmd.PropertyName);
                tag.InnerText = GetHTMLValue(mmd.ModelAccessor());

            }

            //WFUtilities.CheckPropertyError(metadata, model, tag, mmd.PropertyName, mmd.PropertyName);
            tag.MergeObjectProperties(htmlProperties);

            if (((MemberExpression)expression.Body).Member is PropertyInfo) {
                tag = htmlHelper.PreProcess(tag, metadata, tagType, mmd.PropertyName, (PropertyInfo)((MemberExpression)expression.Body).Member, model);
            } else {
                throw new Exception("Invalid argument specified in lambda for Html.xFor() method [" + markupName + "] (must be a property). Check your markup.");
            }

            return tag;
        }

        private static HtmlTag GetTagFromExpression<TProperty>(TagTypes tagType,
                    Expression<Func<TModel, TProperty>> expression,
                    TModel model,
                    WFModelMetaData metadata,
                    object htmlProperties,
                    HtmlHelper<TModel> htmlHelper) {

            return GetTagFromExpression<TProperty>(tagType, expression, model, metadata, htmlProperties, htmlHelper, null, "", false, false);
        }

        /// <summary>
        /// A span with validation enabled whose inner text is derived from a strongly-typed lambda.
        /// </summary>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="expression">An expression that identifies the property whose value will be rendered to the inner text of the span.<br/>
        /// ie: m=> m.FirstName will render the 'FirstName' property.</param>
        /// <returns></returns>
        public string SpanFor<TProperty>(Expression<Func<TModel, TProperty>> expression) {
            return SpanFor(expression, null);
        }
        /// <summary>
        /// A span with validation enabled whose inner text is derived from a strongly-typed lambda.
        /// </summary>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="expression">An expression that identifies the property whose value will be rendered to the inner text of the span.<br/>
        /// ie: m=> m.FirstName will render the 'FirstName' property.</param>
        /// <param name="htmlProperties">An anonymous object whose properties are applied to the element.<br/>
        /// ie: new { Class = "cssClass", onchange = "jsFunction()" } </param>
        /// <returns></returns>
        public string SpanFor<TProperty>(Expression<Func<TModel, TProperty>> expression, object htmlProperties) {
            return GetTagFromExpression<TProperty>(TagTypes.Span, expression, _Model, _MetaData, htmlProperties, this).Render();
        }

        /// <summary>
        /// A textbox with validation enabled whose value is derived from a strongly-typed lambda.
        /// </summary>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="expression">An expression that identifies the property whose value will be rendered.<br/>
        /// ie: m => m.FirstName will render the 'FirstName' property.</param>
        /// <returns></returns>
        public string TextBoxFor<TProperty>(Expression<Func<TModel, TProperty>> expression) {
            return TextBoxFor(expression, null);
        }
        /// <summary>
        /// A textbox with validation enabled whose value is derived from a strongly-typed lambda.
        /// </summary>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="expression">An expression that identifies the property whose value will be rendered.<br/>
        /// ie: m => m.FirstName will render the 'FirstName' property.</param>
        /// <param name="htmlProperties">An anonymous object whose properties are applied to the element.<br/>
        /// ie: new { Class = "cssClass", onchange = "jsFunction()" } </param>
        /// <returns></returns>
        public string TextBoxFor<TProperty>(Expression<Func<TModel, TProperty>> expression, object htmlProperties) {
            return GetTagFromExpression<TProperty>(TagTypes.InputBox, expression, _Model, _MetaData, htmlProperties, this).Render();
        }
        /// <summary>
        /// A textarea with validation enabled whose value is derived from a strongly-typed lambda.
        /// </summary>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="expression">An expression that identifies the property whose value will be rendered.<br/>
        /// ie: m => m.FirstName will render the 'FirstName' property.</param>
        /// <returns></returns>
        public string TextAreaFor<TProperty>(Expression<Func<TModel, TProperty>> expression) {
            return TextAreaFor<TProperty>(expression, null);
        }
        /// <summary>
        /// A textarea with validation enabled whose value is derived from a strongly-typed lambda.
        /// </summary>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="expression">An expression that identifies the property whose value will be rendered.<br/>
        /// ie: m => m.FirstName will render the 'FirstName' property.</param>
        /// <param name="htmlProperties">An anonymous object whose properties are applied to the element.<br/>
        /// ie: new { Class = "cssClass", onchange = "jsFunction()" } </param>
        /// <returns></returns>
        public string TextAreaFor<TProperty>(Expression<Func<TModel, TProperty>> expression, object htmlProperties) {
            return GetTagFromExpression<TProperty>(TagTypes.TextArea, expression, _Model, _MetaData, htmlProperties, this).Render();
        }
        /// <summary>
        /// A checkbox with validation enabled whose value is derived from a strongly-typed lambda.
        /// </summary>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="expression">An expression that identifies the property whose value will be rendered.<br/>
        /// ie: m => m.FirstName will render the 'FirstName' property.</param>
        /// <returns></returns>
        public string CheckboxFor<TProperty>(Expression<Func<TModel, TProperty>> expression) {
            return CheckboxFor<TProperty>(expression, null);
        }
        /// <summary>
        /// A checkbox with validation enabled whose value is derived from a strongly-typed lambda.
        /// </summary>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="expression">An expression that identifies the property whose value will be rendered.<br/>
        /// ie: m => m.FirstName will render the 'FirstName' property.</param>
        /// <param name="htmlProperties">An anonymous object whose properties are applied to the element.<br/>
        /// ie: new { Class = "cssClass", onchange = "jsFunction()" } </param>
        /// <returns></returns>
        public string CheckboxFor<TProperty>(Expression<Func<TModel, TProperty>> expression, object htmlProperties) {
            return GetTagFromExpression<TProperty>(TagTypes.Checkbox, expression, _Model, _MetaData, htmlProperties, this).Render();
        }
        /// <summary>
        /// A radiobutton with validation enabled whose value is derived from a strongly-typed lambda.
        /// </summary>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="expression">An expression that identifies the property whose value will be rendered.<br/>
        /// ie: m => m.FirstName will render the 'FirstName' property.</param>
        /// <returns></returns>
        public string RadioButtonFor<TProperty>(Expression<Func<TModel, TProperty>> expression) {
            return RadioButtonFor<TProperty>(expression, null);
        }
        /// <summary>
        /// A radiobutton with validation enabled whose value is derived from a strongly-typed lambda.
        /// </summary>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="expression">An expression that identifies the property whose value will be rendered.<br/>
        /// ie: m => m.FirstName will render the 'FirstName' property.</param>
        /// <param name="htmlProperties">An anonymous object whose properties are applied to the element.<br/>
        /// ie: new { Class = "cssClass", onchange = "jsFunction()" } </param>
        /// <returns></returns>
        public string RadioButtonFor<TProperty>(Expression<Func<TModel, TProperty>> expression, object htmlProperties) {
            return GetTagFromExpression<TProperty>(TagTypes.RadioButton, expression, _Model, _MetaData, htmlProperties, this).Render();
        }


        /// <summary>
        /// A radiobutton with validation enabled whose value is derived from a strongly-typed lambda.
        /// </summary>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="expression">An expression that identifies the property whose value will be rendered.<br/>
        /// ie: m => m.FirstName will render the 'FirstName' property.</param>
        /// <param name="isChecked">Whether or not the radio button is checked (selected).</param>
        /// <returns></returns>
        public string RadioButtonFor<TProperty>(Expression<Func<TModel, TProperty>> expression, bool isChecked) {
            return GetTagFromExpression<TProperty>(TagTypes.RadioButton, expression, _Model, _MetaData, null, this, null, null, false, isChecked).Render();
        }

        /// <summary>
        /// A radiobutton with validation enabled whose value is derived from a strongly-typed lambda.
        /// </summary>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="expression">An expression that identifies the property whose value will be rendered.<br/>
        /// ie: m => m.FirstName will render the 'FirstName' property.</param>
        /// <param name="isChecked">Whether or not the radio button is checked (selected).</param>
        /// <param name="htmlProperties">An anonymous object whose properties are applied to the element.<br/>
        /// ie: new { Class = "cssClass", onchange = "jsFunction()" } </param>
        /// <returns></returns>
        public string RadioButtonFor<TProperty>(Expression<Func<TModel, TProperty>> expression, bool isChecked, object htmlProperties) {
            return GetTagFromExpression<TProperty>(TagTypes.RadioButton, expression, _Model, _MetaData, htmlProperties, this, null, null, false, isChecked).Render();
        }

        /// <summary>
        /// Returns the raw text of any generated server-side validation error for this property.<br/>
        /// This is useful if you want to override the default functionality that generates a &lt;span&gt; tag for validation error messages.
        /// </summary>
        /// <param name="expression">An expression that identifies the property whose value will be rendered.<br/>
        /// ie: m => m.FirstName will render the 'FirstName' property.</param>
        /// <returns></returns>
        public string TextValidationMessageFor<TProperty>(Expression<Func<TModel, TProperty>> expression)
        {
            WFModelMetaProperty metaprop = null;
            ModelMetaData mmd = ModelMetaData.FromLambdaExpression(expression, _Model);
            string lcName = mmd.PropertyName.ToLower();
            for (int i = 0; i < _MetaData.Properties.Count; i++)
            {
                if (_MetaData.Properties[i].MarkupName.ToLower() == lcName)
                {
                    metaprop = _MetaData.Properties[i];
                    break;
                }

            }
            if (metaprop != null)
            {
                if (metaprop.HasError)
                {
                    return metaprop.Errors.FirstOrDefault() ?? "";
                }
            }
            return "";
        }

        /// <summary>
        /// Returns the raw ID of any generated server-side validation error for this property.<br/>
        /// This is useful if you want to override the default functionality that generates a &lt;span&gt; tag for validation error messages.
        /// </summary>
        /// <param name="expression">An expression that identifies the property whose value will be rendered.<br/>
        /// ie: m => m.FirstName will render the 'FirstName' property.</param>
        /// <returns></returns>
        public string TextValidationMessageIDFor<TProperty>(Expression<Func<TModel, TProperty>> expression)
        {
            ModelMetaData mmd = ModelMetaData.FromLambdaExpression(expression, _Model);
            return mmd.PropertyName + "_validationMessage";
        }

        /// <summary>
        /// Creates a &lt;span&gt; tag with appropriate validation information used by client side AND server side code.<br/>
        /// WFUtilities.FieldValidationErrorClass is applied if validation fails on a postback. This is used with an Html.&ltcontrol&gt;For() element.<br/>
        /// The property whose validation state is checked is derived from a strongly-typed lambda.
        /// </summary>
        /// <param name="expression">An expression that identifies the property whose value will be rendered.<br/>
        /// ie: m => m.FirstName will render the 'FirstName' property.</param>
        /// <param name="htmlProperties">An anonymous object whose properties are applied to the element.<br/>
        /// ie: new { Class = "cssClass", onchange = "jsFunction()" } </param>
        /// <returns></returns>
        public string ValidationMessageFor<TProperty>(Expression<Func<TModel, TProperty>> expression) {
            return ValidationMessageFor<TProperty>(expression, null, null);
        }
        /// <summary>
        /// Creates a &lt;span&gt; tag with appropriate validation information used by client side AND server side code.<br/>
        /// WFUtilities.FieldValidationErrorClass is applied if validation fails on a postback. This is used with an Html.&ltcontrol&gt;For() element.<br/>
        /// The property whose validation state is checked is derived from a strongly-typed lambda.
        /// </summary>
        /// <param name="expression">An expression that identifies the property whose value will be rendered.<br/>
        /// ie: m => m.FirstName will render the 'FirstName' property.</param>
        /// <param name="htmlProperties">An anonymous object whose properties are applied to the element.<br/>
        /// ie: new { Class = "cssClass", onchange = "jsFunction()" } </param>
        /// <returns></returns>
        public string ValidationMessageFor<TProperty>(Expression<Func<TModel, TProperty>> expression, object htmlProperties) {
            return ValidationMessageFor<TProperty>(expression, null, htmlProperties);
        }
        /// <summary>
        /// Creates a &lt;span&gt; tag with appropriate validation information used by client side AND server side code.<br/>
        /// WFUtilities.FieldValidationErrorClass is applied if validation fails on a postback. This is used with an Html.&ltcontrol&gt;For() element.<br/>
        /// The property whose validation state is checked is derived from a strongly-typed lambda.
        /// </summary>
        /// <param name="ErrorMessage">(Optional) Override any ErrorMessage provided by resources/xml/validators with this property.</param>
        /// <param name="expression">An expression that identifies the property whose value will be rendered.<br/>
        /// ie: m => m.FirstName will render the 'FirstName' property.</param>
        /// <param name="htmlProperties">An anonymous object whose properties are applied to the element.<br/>
        /// ie: new { Class = "cssClass", onchange = "jsFunction()" } </param>
        /// <returns></returns>
        public string ValidationMessageFor<TProperty>(Expression<Func<TModel, TProperty>> expression, string ErrorMessage, object htmlProperties) {
            WFModelMetaProperty metaprop = null;
            ModelMetaData mmd = ModelMetaData.FromLambdaExpression(expression, _Model);
            HtmlTag span = new HtmlTag("span", new { id = mmd.PropertyName + "_validationMessage", name = mmd.PropertyName + "_validationMessage" });
            string lcName = mmd.PropertyName.ToLower();
            for (int i = 0; i < _MetaData.Properties.Count; i++) {
                if (_MetaData.Properties[i].MarkupName.ToLower() == lcName) {
                    metaprop = _MetaData.Properties[i];
                    break;
                }
            }
            if (metaprop != null) {
                if (metaprop.HasError) {
                    span.MergeObjectProperties(htmlProperties);
                    span.AddClass(WFUtilities.FieldValidationErrorClass);
                    if (String.IsNullOrEmpty(ErrorMessage)) {
                        span.InnerText = metaprop.Errors.FirstOrDefault() ?? "";
                    } else {
                        span.InnerText = ErrorMessage;
                    }
                    return span.Render();
                }
            }

            span.MergeObjectProperties(htmlProperties);
            span.AddClass(WFUtilities.FieldValidationValidClass);

            span = PreProcess(span, _MetaData, TagTypes.ValidationMessage,
                metaprop != null ? metaprop.MarkupName : mmd.PropertyName,
                metaprop != null ? metaprop.PropertyName : mmd.PropertyName,
                _Model);

            return span.Render();
        }

        /// <summary>
        /// A label whose target is derived from a strongly-typed lambda.<br/>
        /// This assumes the 'name' and 'id' values of the target are the default.<br/>
        /// ie: A textbox from Model.FirstName will have id and name of 'FirstName'.
        /// </summary>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="expression">An expression that identifies the property whose value will be rendered.<br/>
        /// ie: m => m.FirstName will render the 'FirstName' property.</param>
        /// <returns></returns>
        public string LabelFor<TProperty>(Expression<Func<TModel, TProperty>> expression) {
            return LabelFor<TProperty>(expression, null);
        }
        /// <summary>
        /// A label whose target is derived from a strongly-typed lambda.<br/>
        /// This assumes the 'name' and 'id' values of the target are the default.<br/>
        /// ie: A textbox from Model.FirstName will have id and name of 'FirstName'.
        /// </summary>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="expression">An expression that identifies the property whose value will be rendered.<br/>
        /// ie: m => m.FirstName will render the 'FirstName' property.</param>
        /// <param name="htmlProperties">An anonymous object whose properties are applied to the element.<br/>
        /// ie: new { Class = "cssClass", onchange = "jsFunction()" } </param>
        /// <returns></returns>
        public string LabelFor<TProperty>(Expression<Func<TModel, TProperty>> expression, object htmlProperties) {
            return GetTagFromExpression<TProperty>(TagTypes.Label, expression, _Model, _MetaData, htmlProperties, this).Render();
        }
        /// <summary>
        /// A hidden input with validation enabled whose value is derived from a strongly-typed lambda.
        /// </summary>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="expression">An expression that identifies the property whose value will be rendered.<br/>
        /// ie: m => m.FirstName will render the 'FirstName' property.</param>
        /// <returns></returns>
        public string HiddenFor<TProperty>(Expression<Func<TModel, TProperty>> expression) {
            return HiddenFor<TProperty>(expression, null);
        }
        /// <summary>
        /// A hidden input with validation enabled whose value is derived from a strongly-typed lambda.
        /// </summary>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="expression">An expression that identifies the property whose value will be rendered.<br/>
        /// ie: m => m.FirstName will render the 'FirstName' property.</param>
        /// <param name="htmlProperties">An anonymous object whose properties are applied to the element.<br/>
        /// ie: new { Class = "cssClass", onchange = "jsFunction()" } </param>
        /// <returns></returns>
        public string HiddenFor<TProperty>(Expression<Func<TModel, TProperty>> expression, object htmlProperties) {
            return GetTagFromExpression<TProperty>(TagTypes.Hidden, expression, _Model, _MetaData, htmlProperties, this).Render();
        }
        /// <summary>
        /// A select tag with validation enabled whose value is derived from a strongly-typed lambda.
        /// </summary>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="expression">An expression that identifies the property whose value will be rendered.<br/>
        /// ie: m => m.FirstName will render the 'FirstName' property.</param>
        /// <param name="selectList">The items in the select tag.</param>
        /// <returns></returns>
        public string DropDownListFor<TProperty>(Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList) {
            return GetTagFromExpression<TProperty>(TagTypes.Select, expression, _Model, _MetaData, null, this, selectList, "", false, false).Render();
        }

        /// <summary>
        /// A select tag with validation enabled whose value is derived from a strongly-typed lambda.
        /// </summary>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="expression">An expression that identifies the property whose value will be rendered.<br/>
        /// ie: m => m.FirstName will render the 'FirstName' property.</param>
        /// <param name="selectList">The items in the select tag.</param>
        /// <param name="optionLabel">The text for the default empty item. This parameter can be null.</param>
        /// <returns></returns>
        public string DropDownListFor<TProperty>(Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, string optionLabel) {
            return GetTagFromExpression<TProperty>(TagTypes.Select, expression, _Model, _MetaData, null, this, selectList, optionLabel, true, false).Render();
        }

        /// <summary>
        /// A select tag with validation enabled whose value is derived from a strongly-typed lambda.
        /// </summary>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="expression">An expression that identifies the property whose value will be rendered.<br/>
        /// ie: m => m.FirstName will render the 'FirstName' property.</param>
        /// <param name="selectList">The items in the select tag.</param>
        /// <param name="htmlProperties">An anonymous object whose properties are applied to the element.<br/>
        /// ie: new { Class = "cssClass", onchange = "jsFunction()" } </param>
        /// <returns></returns>
        public string DropDownListFor<TProperty>(Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, object htmlProperties) {
            return GetTagFromExpression<TProperty>(TagTypes.Select, expression, _Model, _MetaData, htmlProperties, this, selectList, "", false, false).Render();
        }
        /// <summary>
        /// A select tag with validation enabled whose value is derived from a strongly-typed lambda.
        /// </summary>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="expression">An expression that identifies the property whose value will be rendered.<br/>
        /// ie: m => m.FirstName will render the 'FirstName' property.</param>
        /// <param name="selectList">The items in the select tag.</param>
        /// <param name="optionLabel">The text for the default empty item. This parameter can be null.</param>
        /// <param name="htmlProperties">An anonymous object whose properties are applied to the element.<br/>
        /// ie: new { Class = "cssClass", onchange = "jsFunction()" } </param>
        /// <returns></returns>
        public string DropDownListFor<TProperty>(Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, string optionLabel, object htmlProperties) {
            return GetTagFromExpression<TProperty>(TagTypes.Select, expression, _Model, _MetaData, htmlProperties, this, selectList, optionLabel, true, false).Render();
        }
    }
}
