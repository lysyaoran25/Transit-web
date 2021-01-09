using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.IO;
using System.Reflection;
using System.Web;
using System.Linq.Expressions;
using System.ComponentModel;
using WebFormsUtilities.TagProcessors;

namespace WebFormsUtilities
{
    public partial class HtmlHelper<TModel>
    {
        private Control _PageControl = null;
        private TModel _Model = default(TModel);
        private WFModelMetaData _MetaData = null;

        private List<IHtmlTagPreProcessor> _PreProcessors = new List<IHtmlTagPreProcessor>();

        public WFModelMetaData MetaData
        {
            get { return _MetaData; }
            set { _MetaData = value; }
        }

        public HtmlHelper(Control pageControl, TModel model)
        {
            _MetaData = new WFModelMetaData();
            _Model = model;
            _PageControl = pageControl;

            _PreProcessors.Add(new WFValidationPreProcessor());
            _PreProcessors.Add(new WFHTMLEncodePreProcessor());
        }

        public HtmlHelper(Control pageControl, TModel model, WFModelMetaData metadata)
        {
            _PageControl = pageControl;
            _Model = model;
            _MetaData = metadata;

            _PreProcessors.Add(new WFValidationPreProcessor());
            _PreProcessors.Add(new WFHTMLEncodePreProcessor());
        }
        
        public HtmlHelper(IWebFormsView<TModel> wfv)
        {
            _PageControl = (Control)wfv;
            _Model = wfv.Model;
            //_MetaData = wfv.WFMetaData;
            _MetaData = new WFModelMetaData();

            _PreProcessors.Add(new WFValidationPreProcessor());
            _PreProcessors.Add(new WFHTMLEncodePreProcessor());

        }

        /// <summary>
        /// Add an IHtmlTagPreProcessor at page or control level which will be invoked before HtmlHelper methods are rendered.<br/>
        /// This processor will only be invoked for the HtmlHelper instance of the page or control it has been added for.
        /// </summary>
        /// <param name="processor">A class implementing IHtmlTagPreProcessor</param>
        public void AddPreProcessor(IHtmlTagPreProcessor processor) {
            _PreProcessors.Add(processor);
        }

        /// <summary>
        /// Clear all IHtmlTagPreProcessors. This will also remove the built-in WFValidationPreProcessor.<br/>
        /// You should not use this unless you want to override the way validation works.
        /// </summary>
        public void ClearPreProcessors() {
            _PreProcessors.Clear();
        }

        internal HtmlTag PreProcess(HtmlTag tag, WFModelMetaData metadata, TagTypes tagType, string propertyName, PropertyInfo expBody, object model) {
            foreach (IHtmlTagPreProcessor processor in _PreProcessors) {
                tag = processor.PreRenderProcess(tag, ref metadata, tagType, propertyName, expBody, model);
            }
            return tag;
        }

        internal HtmlTag PreProcess(HtmlTag tag, WFModelMetaData metadata, TagTypes tagType, string markupName, string reflectName, object model) {
            foreach (IHtmlTagPreProcessor processor in _PreProcessors) {
                tag = processor.PreRenderProcess(tag, ref metadata, tagType, markupName, reflectName, model);
            }
            return tag;
        }

        #region ValidationSummary
        /// <summary>
        /// Renders a div tag with id 'validationSummary'. The class is WFUtilities.ValidationSummaryValidClass or WFUtilities.ValidationSummaryErrorsClass depending on server validation.<br/>
        /// Errors are rendered in a &ltul&gt; child element with &gtli&lt; children.
        /// </summary>
        /// <param name="model">The model object being validated.</param>
        /// <returns>Returns a div tag for validation summary.</returns>
        public string ValidationSummary(object model)
        {
            return ValidationSummary(model, null);
        }
        /// <summary>
        /// Renders a div tag with id 'validationSummary'. The class is WFUtilities.ValidationSummaryValidClass or WFUtilities.ValidationSummaryErrorsClass depending on server validation.<br/>
        /// Errors are rendered in a &lt;ul&gt; child element with &gt;li&lt; children.
        /// </summary>
        /// <param name="model">The model object being validated.</param>
        /// <param name="htmlProperties">An anonymous object whose properties are applied to the element.<br/>
        /// ie: new { Class = "cssClass", onchange = "jsFunction()" } </param>
        /// <returns>Returns a div tag for validation summary.</returns>
        public string ValidationSummary(object model, object htmlProperties)
        {
            List<string> errors = new List<string>();
            foreach (WFModelMetaProperty prop in _MetaData.Properties)
            {
                if (prop.HasError)
                {
                    foreach (string err in prop.Errors)
                    {
                        errors.Add(err);
                    }
                }
            }
            HtmlTag div = new HtmlTag("div", new { id = "validationSummary" });
            if (errors.Count > 0)
            {
                div.AddClass(WFUtilities.ValidationSummaryErrorsClass);
                HtmlTag ul = new HtmlTag("ul");
                foreach (string err in errors)
                {
                    HtmlTag li = new HtmlTag("li");
                    li.InnerText = err;
                    ul.Children.Add(li);
                }
                div.Children.Add(ul);
            }
            else
            {
                div.AddClass(WFUtilities.ValidationSummaryValidClass);
                HtmlTag ul = new HtmlTag("ul");
                HtmlTag li = new HtmlTag("li", new { style = "display: none;" });
                li = PreProcess(li, _MetaData, TagTypes.ValidationItem, "", "", model);
                ul.Children.Add(li);
                div.Children.Add(ul);
            }
            //<div class="validation-summary-valid" id="validationSummary"><ul><li style="display:none"></li></ul></div>

            div.MergeObjectProperties(htmlProperties);

            div = PreProcess(div, _MetaData, TagTypes.ValidationSummary, "", "", model);

            return div.Render();
        }

        #endregion

        #region ValidationMessageFor
        /// <summary>
        /// Creates a &lt;span&gt; tag with appropriate validation information used by client side AND server side code.<br/>
        /// WFUtilities.FieldValidationErrorClass is applied if validation fails on a postback. This is used with an Html.&ltcontrol&gt;For() element.
        /// </summary>
        /// <param name="model">The model itself.</param>
        /// <param name="markupName">The markup name of the Html.&lt;control&gt;For() element.</param>
        /// <param name="propertyName">Must be the property name on the model object.</param>
        /// <returns>Returns a span with WFUtilities.FieldValidationErrorClass or WFUtilities.FieldValidationValidClass as the class.</returns>
        public string ValidationMessageFor(object model, string markupName, string propertyName)
        {
            return ValidationMessageFor(model, markupName, propertyName, "", null);
        }
        /// <summary>
        /// Creates a &lt;span&gt; tag with appropriate validation information used by client side AND server side code.<br/>
        /// WFUtilities.FieldValidationErrorClass is applied if validation fails on a postback. This is used with an Html.&ltcontrol&gt;For() element.
        /// </summary>
        /// <param name="model">The model itself.</param>
        /// <param name="markupName">The markup name of the Html.&lt;control&gt;For() element.</param>
        /// <param name="propertyName">Must be the property name on the model object.</param>
        /// <param name="htmlProperties">An anonymous object whose properties are applied to the element.
        /// ie: new { Class = "cssClass", onchange = "jsFunction()" } </param>
        /// <returns>Returns a span with WFUtilities.FieldValidationErrorClass or WFUtilities.FieldValidationValidClass as the class.</returns>
        public string ValidationMessageFor(object model, string markupName, string propertyName, object htmlProperties)
        {
            return ValidationMessageFor(model, markupName, propertyName, "", htmlProperties);
        }
        /// <summary>
        /// Creates a &lt;span&gt; tag with appropriate validation information used by client side AND server side code.<br/>
        /// WFUtilities.FieldValidationErrorClass is applied if validation fails on a postback. This is used with an Html.&ltcontrol&gt;For() element.
        /// </summary>
        /// <param name="model">The model itself.</param>
        /// <param name="markupName">The markup name of the Html.&lt;control&gt;For() element.</param>
        /// <param name="propertyName">Must be the property name on the model object.</param>
        /// <param name="ErrorMessage">Override the error message (use with care)</param>
        /// <returns>Returns a span with WFUtilities.FieldValidationErrorClass or WFUtilities.FieldValidationValidClass as the class.</returns>
        public string ValidationMessageFor(object model, string markupName, string propertyName, string ErrorMessage)
        {
            return ValidationMessageFor(model, markupName, propertyName, ErrorMessage, null);
        }


        /// <summary>
        /// Creates a &lt;span&gt; tag with appropriate validation information used by client side AND server side code.
        /// WFUtilities.FieldValidationErrorClass is applied if validation fails on a postback. This is used with an Html.&ltcontrol&gt;For() element.
        /// </summary>
        /// <param name="model">The model itself.</param>
        /// <param name="markupName">The markup name of the Html.&lt;control&gt;For() element.</param>
        /// <param name="propertyName">Must be the property name on the model object.</param>
        /// <param name="ErrorMessage">Override the error message (use with care)</param>
        /// <param name="htmlProperties">An anonymous object whose properties are applied to the element.<br/>
        /// ie: new { Class = "cssClass", onchange = "jsFunction()" } </param>
        /// <returns>Returns a span with WFUtilities.FieldValidationErrorClass or WFUtilities.FieldValidationValidClass as the class.</returns>
        public string ValidationMessageFor(object model, string markupName, string propertyName, string ErrorMessage, object htmlProperties)
        {
            WFModelMetaProperty metaprop = null;
            HtmlTag span = new HtmlTag("span", new { id = markupName + "_validationMessage", name = markupName + "_validationMessage" });

            string lcName = propertyName.ToLower();
            for (int i = 0; i < _MetaData.Properties.Count; i++)
            {
                //if (_MetaData.Properties[i].ModelObject == model && _MetaData.Properties[i].PropertyName.ToLower() == lcName)
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
                    span.MergeObjectProperties(htmlProperties);
                    span.AddClass(WFUtilities.FieldValidationErrorClass);

                    if (String.IsNullOrEmpty(ErrorMessage))
                    {
                        span.InnerText = metaprop.Errors.FirstOrDefault() ?? "";
                    }
                    else
                    {
                        span.InnerText = ErrorMessage;
                    }
                    return span.Render();
                }
            }

            span.MergeObjectProperties(htmlProperties);
            span.AddClass(WFUtilities.FieldValidationValidClass);

            span = PreProcess(span, _MetaData, TagTypes.ValidationMessage, markupName, propertyName, model);

            return span.Render();
        }

        #endregion

        #region RadioButton, RadioButtonFor
        /// <summary>
        /// A radio button without validation enabled. Use Html.&lt;control&gt;For() for validation.
        /// </summary>
        /// <param name="name">The name of the radio button in markup. ID is not set automatically.</param>
        /// <param name="value">The value property of the radio button.</param>
        /// <returns>Returns an input control.</returns>
        public string RadioButton(string name, object value)
        {
            return RadioButton(name, value, false);
        }
        /// <summary>
        /// A radio button without validation enabled. Use Html.&lt;control&gt;For() for validation.
        /// </summary>
        /// <param name="name">The name of the radio button in markup. ID is not set automatically.</param>
        /// <param name="value">The value property of the radio button.</param>
        /// <param name="isChecked">Whether checked="checked" should be used.</param>
        /// <returns>Returns an input control.</returns>
        public string RadioButton(string name, object value, bool isChecked)
        {
            return RadioButton(name, value, isChecked, null);
        }
        /// <summary>
        /// A radio button without validation enabled. Use Html.&lt;control&gt;For() for validation.
        /// </summary>
        /// <param name="name">The name of the radio button in markup. ID is not set automatically.</param>
        /// <param name="value">The value property of the radio button.</param>
        /// <param name="htmlAttributes">An anonymous object whose properties are applied to the element.<br/>
        /// ie: new { Class = "cssClass", onchange = "jsFunction()" } </param>
        /// <returns>Returns an input control.</returns>
        public string RadioButton(string name, object value, object htmlAttributes)
        {
            return RadioButton(name, value, false, htmlAttributes);
        }
        /// <summary>
        /// A radio button without validation enabled. Use Html.&lt;control&gt;For() for validation.
        /// </summary>
        /// <param name="name">The name of the radio button in markup. ID is not set automatically.</param>
        /// <param name="value">The value property of the radio button.</param>
        /// <param name="isChecked"></param>
        /// <param name="htmlAttributes">An anonymous object whose properties are applied to the element.<br/>
        /// ie: new { Class = "cssClass", onchange = "jsFunction()" } </param>
        /// <returns>Returns an input control.</returns>
        public string RadioButton(string name, object value, bool isChecked, object htmlAttributes)
        {
            HtmlTag rb = new HtmlTag("input", new { type = "radio", name = name, value = (value ?? "").ToString() });
            if (isChecked) { rb.Attr("checked", "checked"); }

            rb.MergeObjectProperties(htmlAttributes);

            PreProcess(rb, _MetaData, TagTypes.RadioButton, name, "", null);

            return rb.Render();
        }
        /// <summary>
        /// A radio button with validation enabled.
        /// </summary>
        /// <param name="markupname">The name of the radio button. ID is not set automatically.</param>
        /// <param name="name">The name of the property from the model.</param>
        /// <param name="model">The model itself.</param>
        /// <param name="value">The value property of the radio button.</param>
        /// <returns>Returns an input control.</returns>
        public string RadioButtonFor(string markupname, string name, object model, object value)
        {
            return RadioButtonFor(markupname, name, model, value, false, null);
        }
        /// <summary>
        /// A radio button with validation enabled.
        /// </summary>
        /// <param name="markupname">The name of the radio button. ID is not set automatically.</param>
        /// <param name="name">The name of the property from the model.</param>
        /// <param name="model">The model itself.</param>
        /// <param name="value">The value property of the radio button.</param>
        /// <param name="isChecked">Whether checked="checked" should be used.</param>
        /// <returns>Returns an input control.</returns>
        public string RadioButtonFor(string markupname, string name, object model, object value, bool isChecked)
        {
            return RadioButtonFor(markupname, name, model, value, isChecked, null);
        }
        /// <summary>
        /// A radio button with validation enabled.
        /// </summary>
        /// <param name="markupname">The name of the radio button. ID is not set automatically.</param>
        /// <param name="name">The name of the property from the model.</param>
        /// <param name="model">The model itself.</param>
        /// <param name="value">The value property of the radio button.</param>
        /// <param name="isChecked">Whether checked="checked" should be used.</param>
        /// <param name="htmlAttributes">An anonymous object whose properties are applied to the element.<br/>
        /// ie: new { Class = "cssClass", onchange = "jsFunction()" } </param>
        /// <returns>Returns an input control.</returns>
        public string RadioButtonFor(string markupname, string name, object model, object value, bool isChecked, object htmlAttributes)
        {
            HtmlTag rb = new HtmlTag("input", new { type = "radio", name = markupname, value = (value ?? "").ToString() });
            if (isChecked) { rb.Attr("checked", "checked"); }

            rb.MergeObjectProperties(htmlAttributes);

            PreProcess(rb, _MetaData, TagTypes.RadioButton, markupname, name, model);

            return rb.Render();
        }
        #endregion

        #region TextBox, TextBoxFor
        /// <summary>
        /// A textbox control without validation enabled. Use Html.&lt;control&gt;For() for validation.
        /// </summary>
        /// <param name="name">The name/id of the textbox in markup.</param>
        /// <param name="value">The initial value of the textbox, a model is not required.</param>
        /// <returns>Returns an input control.</returns>
        public string TextBox(string name, object value)
        {
            return TextBox(name, value, null);
        }

        /// <summary>
        /// A textbox control without validation enabled. Use Html.&lt;control&gt;For() for validation.
        /// </summary>
        /// <param name="name">The name/id of the textbox in markup.</param>
        /// <param name="value">The initial value of the textbox, a model is not required.</param>
        /// <param name="htmlAttributes">An anonymous object whose properties are applied to the element.
        /// ie: new { Class = "cssClass", onchange = "jsFunction()" } </param>
        /// <returns>Returns an input control.</returns>
        public string TextBox(string name, object value, object htmlAttributes)
        {
            HtmlTag tb = new HtmlTag("input", new { type = "text", name = name, value = (value ?? "").ToString(), id = name }, true);

            tb.MergeObjectProperties(htmlAttributes);

            tb = PreProcess(tb, _MetaData, TagTypes.InputBox, name, "", null);

            return tb.Render();
        }

        /// <summary>
        /// A textbox with validation enabled.
        /// </summary>
        /// <param name="markupname">The name/id of the textbox in markup.</param>
        /// <param name="name">The name of the property from the model.</param>
        /// <param name="model">The model itself.</param>
        /// <param name="value">The initial value of the textbox, usually from the model.</param>
        /// <returns>Returns an input control.</returns>
        public string TextBoxFor(string markupname, string name, object model, object value)
        {
            return TextBoxFor(markupname, name, model, value, null);
        }
        /// <summary>
        /// A textbox with validation enabled.
        /// </summary>
        /// <param name="markupname">The name/id of the textbox in markup.</param>
        /// <param name="name">The name of the property from the model.</param>
        /// <param name="model">The model itself.</param>
        /// <param name="value">The initial value of the textbox, usually from the model.</param>
        /// <param name="htmlAttributes">An anonymous object whose properties are applied to the element.<br/>
        /// ie: new { Class = "cssClass", onchange = "jsFunction()" } </param>
        /// <returns>Returns an input control.</returns>
        public string TextBoxFor(string markupname, string name, object model, object value, object htmlAttributes)
        {
            HtmlTag tb = new HtmlTag("input", new { type = "text", name = markupname, value = (value ?? "").ToString(), id = markupname }, true);

            tb.MergeObjectProperties(htmlAttributes);

            tb = PreProcess(tb, _MetaData, TagTypes.InputBox, markupname, name, model);

            return tb.Render();
        }
        #endregion

        #region TextArea, TextAreaFor
        /// <summary>
        /// A &lt;textarea&gt; element without validation enabled.
        /// </summary>
        /// <param name="name">The name/id of the textarea element.</param>
        /// <param name="value">The innertext of the textarea element.</param>
        /// <returns>Returns a textarea element.</returns>
        public string TextArea(string name, object value)
        {
            return TextArea(name, value, null);
        }
        /// <summary>
        /// A &lt;textarea&gt; element without validation enabled.
        /// </summary>
        /// <param name="name">The name/id of the textarea element.</param>
        /// <param name="value">The innertext of the textarea element.</param>
        /// <param name="htmlProperties">An anonymous object whose properties are applied to the element.<br/>
        /// ie: new { Class = "cssClass", onchange = "jsFunction()" } </param>
        /// <returns>Returns a textarea element.</returns>
        public string TextArea(string name, object value, object htmlProperties)
        {
            HtmlTag txa = new HtmlTag("textarea", new { cols = "20", rows = "2", name = name, id = name }) { InnerText = (value ?? "").ToString() };

            txa.MergeObjectProperties(htmlProperties);

            txa = PreProcess(txa, _MetaData, TagTypes.TextArea, name, "", null);

            return txa.Render();
        }
        /// <summary>
        /// A &lt;textarea&gt; element with validation enabled.
        /// </summary>
        /// <param name="markupname">The name/id of the textarea element.</param>
        /// <param name="name">The name of the property from the model.</param>
        /// <param name="model">The model itself.</param>
        /// <param name="value">The innertext of the textarea element.</param>
        /// <returns>Returns a textarea element.</returns>
        public string TextAreaFor(string markupname, string name, object model, object value)
        {
            return TextAreaFor(markupname, name, model, value, null);
        }
        /// <summary>
        /// A &lt;textarea&gt; element with validation enabled.
        /// </summary>
        /// <param name="markupname">The name/id of the textarea element.</param>
        /// <param name="name">The name of the property from the model.</param>
        /// <param name="model">The model itself.</param>
        /// <param name="value">The innertext of the textarea element.</param>
        /// <param name="htmlAttributes">An anonymous object whose properties are applied to the element.<br/>
        /// ie: new { Class = "cssClass", onchange = "jsFunction()" } </param>
        /// <returns>Returns a textarea element.</returns>
        public string TextAreaFor(string markupname, string name, object model, object value, object htmlAttributes)
        {
            HtmlTag txa = new HtmlTag("textarea", new { cols = "20", rows = "2", name = markupname, id = markupname }) { InnerText = (value ?? "").ToString() };

            txa.MergeObjectProperties(htmlAttributes);

            txa = PreProcess(txa, _MetaData, TagTypes.TextArea, markupname, name, model);

            return txa.MergeObjectProperties(htmlAttributes).Render();
        }
        #endregion

        #region Checkbox, CheckboxFor
        /// <summary>
        /// A checkbox control without validation enabled. Use Html.&lt;control&gt;For() for validation.
        /// </summary>
        /// <param name="name">The name/id of the checkbox control.</param>
        /// <param name="isChecked">Whether checked="checked" should be used.</param>
        /// <returns>Returns an input control.</returns>
        public string Checkbox(string name, bool isChecked)
        {
            return Checkbox(name, isChecked, null);
        }
        /// <summary>
        /// A checkbox control without validation enabled. Use Html.&lt;control&gt;For() for validation.
        /// </summary>
        /// <param name="name">The name/id of the checkbox control.</param>
        /// <param name="isChecked">Whether checked="checked" should be used.</param>
        /// <returns>Returns an input control.</returns>
        public string Checkbox(string name, bool? isChecked)
        {
            if (isChecked.HasValue && isChecked.Value) { return Checkbox(name, true, null); }
            return Checkbox(name, false, null);
        }
        /// <summary>
        /// A checkbox control without validation enabled. Use Html.&lt;control&gt;For() for validation.
        /// </summary>
        /// <param name="name">The name/id of the checkbox control.</param>
        /// <param name="htmlProperties">An anonymous object whose properties are applied to the element.<br/>
        /// ie: new { Class = "cssClass", onchange = "jsFunction()" } </param>
        /// <returns>Returns an input control.</returns>
        public string Checkbox(string name, object htmlProperties)
        {
            return Checkbox(name, false, htmlProperties);
        }
        /// <summary>
        /// A checkbox control without validation enabled. Use Html.&lt;control&gt;For() for validation.
        /// </summary>
        /// <param name="name">The name/id of the checkbox control.</param>
        /// <param name="isChecked">Whether checked="checked" should be used.</param>
        /// <param name="htmlProperties">An anonymous object whose properties are applied to the element.<br/>
        /// ie: new { Class = "cssClass", onchange = "jsFunction()" } </param>
        /// <returns>Returns an input control.</returns>
        public string Checkbox(string name, bool isChecked, object htmlProperties)
        {
            bool? ic = isChecked;
            return Checkbox(name, ic, htmlProperties);
        }
        /// <summary>
        /// A checkbox control without validation enabled. Use Html.&lt;control&gt;For() for validation.
        /// </summary>
        /// <param name="name">The name/id of the checkbox control.</param>
        /// <param name="isChecked">Whether checked="checked" should be used.</param>
        /// <param name="htmlProperties">An anonymous object whose properties are applied to the element.<br/>
        /// ie: new { Class = "cssClass", onchange = "jsFunction()" } </param>
        /// <returns>Returns an input control.</returns>
        public string Checkbox(string name, bool? isChecked, object htmlProperties)
        {
            HtmlTag cb = new HtmlTag("input", new { type = "checkbox", id = name, name = name });
            if (isChecked.HasValue && isChecked.Value) { cb.Attr("checked", "checked"); }
            if (htmlProperties != null) { cb.MergeObjectProperties(htmlProperties); }

            cb = PreProcess(cb, _MetaData, TagTypes.Checkbox, name, "", null);

            return cb.Render();
        }
        /// <summary>
        /// A checkbox control with validation enabled.
        /// </summary>
        /// <param name="markupname">The name/id of the checkbox.</param>
        /// <param name="name">The name of the property from the model.</param>
        /// <param name="model">The model itself.</param>
        /// <returns>Returns an input control.</returns>
        public string CheckboxFor(string markupname, string name, object model)
        {
            return CheckboxFor(markupname, name, model, false);
        }
        /// <summary>
        /// A checkbox control with validation enabled.
        /// </summary>
        /// <param name="markupname">The name/id of the checkbox.</param>
        /// <param name="name">The name of the property from the model.</param>
        /// <param name="model">The model itself.</param>
        /// <param name="isChecked">Whether checked="checked" should be used.</param>
        /// <returns>Returns an input control.</returns>
        public string CheckboxFor(string markupname, string name, object model, bool? isChecked)
        {
            return CheckboxFor(markupname, name, model, isChecked);
        }
        /// <summary>
        /// A checkbox control with validation enabled.
        /// </summary>
        /// <param name="markupname">The name/id of the checkbox.</param>
        /// <param name="name">The name of the property from the model.</param>
        /// <param name="model">The model itself.</param>
        /// <param name="isChecked">Whether checked="checked" should be used.</param>
        /// <param name="htmlProperties">An anonymous object whose properties are applied to the element.<br/>
        /// ie: new { Class = "cssClass", onchange = "jsFunction()" } </param>
        /// <returns></returns>
        public string CheckboxFor(string markupname, string name, object model, bool? isChecked, object htmlProperties)
        {
            HtmlTag cb = new HtmlTag("input", new { type = "checkbox", id = markupname, name = markupname });
            if (isChecked.HasValue && isChecked.Value)
            { cb.Attr("checked", "checked"); }
            if (htmlProperties != null) { cb.MergeObjectProperties(htmlProperties); }

            cb = PreProcess(cb, _MetaData, TagTypes.Checkbox, markupname, name, model);

            return cb.Render();
        }
        #endregion

        #region DropDownList, DropDownListFor
        //no DropDownList(name), DropDownList(name, label) exists because there is no ViewData[] as of this compile
        /// <summary>
        /// A &lt;select&gt; tag with &gt;option&lt; elements without validation enabled.
        /// </summary>
        /// <param name="name">The name/id of the select tag.</param>
        /// <param name="selectList">The items in the select tag.</param>
        /// <returns>Returns a select tag with option children.</returns>
        public string DropDownList(string name, IEnumerable<SelectListItem> selectList)
        {
            return DropDownList(name, selectList, null);
        }
        /// <summary>
        /// A &lt;select&gt; tag with &gt;option&lt; elements without validation enabled.
        /// </summary>
        /// <param name="name">The name/id of the select tag.</param>
        /// <param name="selectList">The items in the select tag.</param>
        /// <param name="htmlProperties">An anonymous object whose properties are applied to the element.<br/>
        /// ie: new { Class = "cssClass", onchange = "jsFunction()" } </param>
        /// <returns>Returns a select tag with option children.</returns>
        public string DropDownList(string name, IEnumerable<SelectListItem> selectList, object htmlProperties)
        {
            HtmlTag sel = new HtmlTag("select", new { id = name, name = name });
            foreach (SelectListItem si in selectList)
            {
                HtmlTag opt = new HtmlTag("option", new { value = si.Value ?? "" }) { InnerText = si.Text ?? "" };
                if (si.Selected) { opt.Attr("selected", "selected"); }
                sel.Children.Add(opt);
            }
            if (htmlProperties != null) { sel.MergeObjectProperties(htmlProperties); }

            sel = PreProcess(sel, _MetaData, TagTypes.Select, name, "", null);

            return sel.Render();
        }
        /// <summary>
        /// A &lt;select&gt; tag with &gt;option&lt; elements without validation enabled.
        /// </summary>
        /// <param name="name">The name/id of the select tag.</param>
        /// <param name="selectList">The items in the select tag.</param>
        /// <param name="optionlabel">The text for the default empty item. This parameter can be null.</param>
        /// <returns>Returns a select tag with option children.</returns>
        public string DropDownList(string name, IEnumerable<SelectListItem> selectList, string optionlabel)
        {
            HtmlTag sel = new HtmlTag("select", new { id = name, name = name });

            HtmlTag optx = new HtmlTag("option", new { value = "" }) { InnerText = optionlabel ?? "" };
            sel.Children.Add(optx);

            foreach (SelectListItem si in selectList)
            {
                HtmlTag opt = new HtmlTag("option", new { value = si.Value ?? "" }) { InnerText = si.Text ?? "" };
                if (si.Selected) { opt.Attr("selected", "selected"); }
                sel.Children.Add(opt);
            }

            sel = PreProcess(sel, _MetaData, TagTypes.Select, name, "", null);

            return sel.Render();
        }
        /// <summary>
        /// A &lt;select&gt; tag with &gt;option&lt; elements without validation enabled.
        /// </summary>
        /// <param name="name">The name/id of the select tag.</param>
        /// <param name="selectList">The items in the select tag.</param>
        /// <param name="optionlabel">The text for the default empty item. This parameter can be null.</param>
        /// <param name="htmlProperties">An anonymous object whose properties are applied to the element.<br/>
        /// ie: new { Class = "cssClass", onchange = "jsFunction()" } </param>
        /// <returns>Returns a select tag with option children.</returns>
        public string DropDownList(string name, IEnumerable<SelectListItem> selectList, string optionlabel, object htmlProperties)
        {
            HtmlTag sel = new HtmlTag("select", new { id = name, name = name });

            HtmlTag optx = new HtmlTag("option", new { value = "" }) { InnerText = optionlabel ?? "" };
            sel.Children.Add(optx);

            foreach (SelectListItem si in selectList)
            {
                HtmlTag opt = new HtmlTag("option", new { value = si.Value ?? "" }) { InnerText = si.Text ?? "" };
                if (si.Selected) { opt.Attr("selected", "selected"); }
                sel.Children.Add(opt);
            }
            if (htmlProperties != null) { sel.MergeObjectProperties(htmlProperties); }

            sel = PreProcess(sel, _MetaData, TagTypes.Select, name, "", null);

            return sel.Render();
        }
        /// <summary>
        /// A &lt;select&gt; tag with &gt;option&lt; elements with validation enabled.
        /// </summary>
        /// <param name="markupname">The name/id of the select tag.</param>
        /// <param name="name">The name of the property from the model.</param>
        /// <param name="model">The model itself.</param>
        /// <param name="selectList">The items in the select tag.</param>
        /// <returns>Returns a select tag with option children.</returns>
        public string DropDownListFor(string markupname, string name, object model, IEnumerable<SelectListItem> selectList)
        {
            return DropDownListFor(markupname, name, model, selectList, null);
        }
        /// <summary>
        /// A &lt;select&gt; tag with &gt;option&lt; elements with validation enabled.
        /// </summary>
        /// <param name="markupname">The name/id of the select tag.</param>
        /// <param name="name">The name of the property from the model.</param>
        /// <param name="model">The model itself.</param>
        /// <param name="selectList">The items in the select tag.</param>
        /// <param name="htmlProperties">An anonymous object whose properties are applied to the element.<br/>
        /// ie: new { Class = "cssClass", onchange = "jsFunction()" } </param>
        /// <returns>Returns a select tag with option children.</returns>
        public string DropDownListFor(string markupname, string name, object model, IEnumerable<SelectListItem> selectList, object htmlProperties)
        {
            HtmlTag sel = new HtmlTag("select", new { id = markupname, name = markupname });
            foreach (SelectListItem si in selectList)
            {
                HtmlTag opt = new HtmlTag("option", new { value = si.Value ?? "" }) { InnerText = si.Text ?? "" };
                if (si.Selected) { opt.Attr("selected", "selected"); }
                sel.Children.Add(opt);
            }
            if (htmlProperties != null) { sel.MergeObjectProperties(htmlProperties); }

            sel = PreProcess(sel, _MetaData, TagTypes.Select, markupname, name, model);

            return sel.Render();
        }
        /// <summary>
        /// A &lt;select&gt; tag with &gt;option&lt; elements with validation enabled.
        /// </summary>
        /// <param name="markupname">The name/id of the select tag.</param>
        /// <param name="name">The name of the property from the model.</param>
        /// <param name="model">The model itself.</param>
        /// <param name="selectList">The items in the select tag.</param>
        /// <param name="optionlabel">The text for the default empty item. This parameter can be null.</param>
        /// <returns>Returns a select tag with option children.</returns>
        public string DropDownListFor(string markupname, string name, object model, IEnumerable<SelectListItem> selectList, string optionlabel)
        {
            return DropDownListFor(markupname, name, model, selectList, optionlabel, null);
        }
        /// <summary>
        /// A &lt;select&gt; tag with &gt;option&lt; elements with validation enabled.
        /// </summary>
        /// <param name="markupname">The name/id of the select tag.</param>
        /// <param name="name">The name of the property from the model.</param>
        /// <param name="model">The model itself.</param>
        /// <param name="selectList">The items in the select tag.</param>
        /// <param name="optionlabel">The text for the default empty item. This parameter can be null.</param>
        /// <param name="htmlProperties">An anonymous object whose properties are applied to the element.<br/>
        /// ie: new { Class = "cssClass", onchange = "jsFunction()" } </param>
        /// <returns>Returns a select tag with option children.</returns>
        public string DropDownListFor(string markupname, string name, object model, IEnumerable<SelectListItem> selectList, string optionlabel, object htmlProperties)
        {
            HtmlTag sel = new HtmlTag("select", new { id = markupname, name = markupname });

            HtmlTag optx = new HtmlTag("option", new { value = "" }) { InnerText = optionlabel ?? "" };
            sel.Children.Add(optx);

            foreach (SelectListItem si in selectList)
            {
                HtmlTag opt = new HtmlTag("option", new { value = si.Value ?? "" }) { InnerText = si.Text ?? "" };
                if (si.Selected) { opt.Attr("selected", "selected"); }
                sel.Children.Add(opt);
            }
            if (htmlProperties != null) { sel.MergeObjectProperties(htmlProperties); }

            sel = PreProcess(sel, _MetaData, TagTypes.Select, markupname, name, model);

            return sel.Render();
        }
        #endregion

        #region RenderControl
        /// <summary>
        /// Render a UserControl to the Page.Response
        /// </summary>
        /// <param name="controlPath">ie: ~/Controls/MyControl.ascx</param>
        /// <param name="pg"></param>
        public void RenderControl(string controlPath, Page pg)
        {
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            UserControl viewControl = (UserControl)pg.LoadControl(controlPath);
            viewControl.RenderControl(htw);
            pg.Response.Write(sb.ToString());
        }

        /// <summary>
        /// Render a UserControl to the Page.Response<br/>
        /// Use Page.LoadControl(controlpath) to instantiate the control or markup will not be processed.
        /// </summary>
        /// <param name="control"></param>
        /// <param name="pg"></param>
        public void RenderControl(UserControl control, Page pg)
        {
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            HtmlTextWriter htw = new HtmlTextWriter(sw);

            control.RenderControl(htw);
            pg.Response.Write(sb.ToString());
        }

        /// <summary>
        /// Render a UserControl to the Page.Response and set Model property to the specified value.<br/>
        /// Use Page.LoadControl(controlpath) to instantiate the control or markup will not be processed.
        /// </summary>
        /// <param name="control"></param>
        /// <param name="pg"></param>
        /// <param name="model"></param>
        public void RenderControl(UserControl control, Page pg, object Model)
        {
            PropertyInfo pi = control.GetType().GetProperties().FirstOrDefault(p => p.Name == "Model");
            if (pi == null)
            {
                throw new Exception("Make sure 'Model' is a public property with a 'setter'");
            }
            pi.SetValue(control, Model, null);
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            HtmlTextWriter htw = new HtmlTextWriter(sw);

            control.RenderControl(htw);
            pg.Response.Write(sb.ToString());
        }

        /// <summary>
        /// Render a UserControl to the Page.Response and set Model property to the specified value.
        /// Use Page.LoadControl(controlpath) to instantiate the control or markup will not be processed.
        /// </summary>
        /// <param name="controlPath">ie: ~/Controls/MyControl.ascx</param>
        /// <param name="pg"></param>
        public void RenderControl(string controlPath, Page pg, object Model)
        {
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            UserControl viewControl = (UserControl)pg.LoadControl(controlPath);

            PropertyInfo pi = viewControl.GetType().GetProperties().FirstOrDefault(p => p.Name == "Model");
            if (pi == null)
            {
                throw new Exception("Make sure 'Model' is a public property with a 'setter'");
            }
            pi.SetValue(viewControl, Model, null);

            viewControl.RenderControl(htw);
            pg.Response.Write(sb.ToString());
        }
        #endregion

        #region LabelFor

        /// <summary>
        /// Create a &lt;label&gt; tag for a validation-enabled control created from Html.&lt;control&gt;For()<br/>
        /// The inner text is determined by the [DisplayName] attribute on the model property or an overload.
        /// </summary>
        /// <param name="markupName">Set as the 'For' property on the label element.</param>
        /// <param name="name">Must be the property name on the Model object</param>
        /// <param name="model">The model itself.</param>
        /// <returns>Returns a label control.</returns>
        public string LabelFor(string markupName, string name, object model)
        {
            return LabelFor(markupName, name, model, null);
        }
        /// <summary>
        /// Create a &lt;label&gt; tag for a validation-enabled control created from Html.&lt;control&gt;For()<br/>
        /// The inner text is determined by the [DisplayName] attribute on the model property or an overload.
        /// </summary>
        /// <param name="markupName">Set as the 'For' property on the label element.</param>
        /// <param name="name">Must be the property name on the Model object</param>
        /// <param name="model">The model itself.</param>
        /// <param name="displayName">Override the display name (inner text) of the label.</param>
        /// <returns>Returns a label control.</returns>
        public string LabelFor(string markupName, string name, object model, string displayName)
        {
            return LabelFor(markupName, name, model, null, displayName);
        }
        /// <summary>
        /// Create a &lt;label&gt; tag for a validation-enabled control created from Html.&lt;control&gt;For()<br/>
        /// The inner text is determined by the [DisplayName] attribute on the model property or an overload.
        /// </summary>
        /// <param name="markupName">Set as the 'For' property on the label element.</param>
        /// <param name="name">Must be the property name on the Model object</param>
        /// <param name="model">The model itself.</param>
        /// <param name="htmlProperties">An anonymous object whose properties are applied to the textbox.
        /// ie: new { Class = "cssClass", onchange = "jsFunction()" } </param>
        /// <returns>Returns a label control.</returns>
        public string LabelFor(string markupName, string name, object model, object htmlProperties)
        {
            return LabelFor(markupName, name, model, htmlProperties, null);
        }
        /// <summary>
        /// Create a &lt;label&gt; tag for a validation-enabled control created from Html.&lt;control&gt;For()<br/>
        /// The inner text is determined by the [DisplayName] attribute on the model property or an overload.
        /// </summary>
        /// <param name="markupName">Set as the 'For' property on the label element.</param>
        /// <param name="name">Must be the property name on the Model object</param>
        /// <param name="model">The model itself.</param>
        /// <param name="htmlProperties">An anonymous object whose properties are applied to the element.<br/>
        /// ie: new { Class = "cssClass", onchange = "jsFunction()" } </param>
        /// <param name="displayName">Override the display name (inner text) of the label.</param>
        /// <returns>Returns a label control.</returns>
        public string LabelFor(string markupName, string name, object model, object htmlProperties, string displayName)
        {
            string dispName = "";
            PropertyInfo pi = model.GetType().GetProperties().FirstOrDefault(p => p.Name == name);
            if (pi == null) { throw new Exception("[" + name + "] public property not found on object [" + model.GetType().Name + "]"); }
            if (String.IsNullOrEmpty(displayName))
            {
                DisplayNameAttribute datt = pi.GetCustomAttributes(false).OfType<DisplayNameAttribute>().FirstOrDefault();
                if (datt != null)
                {
                    dispName = datt.DisplayName ?? pi.Name;
                }
                else { dispName = pi.Name; }
            }
            else
            {
                dispName = displayName;
            }
            HtmlTag lbl = new HtmlTag("label", new { For = markupName }) { InnerText = dispName };
            lbl.MergeObjectProperties(htmlProperties);

            lbl = PreProcess(lbl, _MetaData, TagTypes.Label, markupName, name, model);

            return lbl.Render();
        }

        #endregion

    }

    public class SelectListItem
    {
        public string Text { get; set; }
        public string Value { get; set; }
        public bool Selected { get; set; }
    }

    public interface IPartialRenderWF
    {
        object Model { get; set; }
    }
}
