using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;

namespace WebFormsUtilities
{
    public class WFWebFormsView<T> : Page
    {
        /// <summary>
        /// form1 control.
        /// </summary>
        /// <remarks>
        /// Auto-generated field.
        /// To modify move field declaration from designer file to code-behind file.
        /// </remarks>
        protected global::System.Web.UI.HtmlControls.HtmlForm form1;


        private WFModelMetaData _WFMetaData = new WFModelMetaData();
        private HtmlHelper<T> _Html = null;
        public virtual T Model { get; set; }
        public string EnableClientValidation()
        {
            return WFPageUtilities.EnableClientValidation(WFMetaData, this.Form.ClientID);
        }
        public void CallJSMethod()
        {
            WFPageUtilities.CallJSMethod(this, Request);
        }

        #region IWebFormsView<WFPageBase> Members

        public object GetModel()
        {
            return (object)Model;
        }

        public void SetModel(object model)
        {
            Model = (T)model;
        }

        public WFModelMetaData WFMetaData
        {
            get
            {
                if (_WFMetaData == null) { _WFMetaData = new WFModelMetaData(); }
                return _WFMetaData;
            }
            set
            {
                _WFMetaData = value;
            }
        }

        public HtmlHelper<T> Html
        {
            get
            {
                if (_Html == null)
                { _Html = new HtmlHelper<T>(this, Model, WFMetaData); }
                return _Html;
            }
            set
            {
                _Html = value;
            }
        }

        #endregion
    }
}
