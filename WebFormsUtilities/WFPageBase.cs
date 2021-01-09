using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;

namespace WebFormsUtilities
{
    //Inheriting from WFPageBase and WFUserControlBase now only serves as a shortcut to declaring HtmlHelper (Html functions),
    //Model, and WFModelMetaData objects as well as bringing CallJSMethod() and EnableClientValidation() methods to markup without
    //registering namespaces.



    /// <summary>
    /// This class is no longer necessary for any WebFormsUtilities functionality.
    /// Call methods from the WFPageUtilities static class. Inheriting from this class can simplify some aspects.
    /// (ie: declaring HtmlHelper)
    /// </summary>
    public class WFPageBase<T> : Page, IWebFormsView<T>
    {
        private WFModelMetaData _WFMetaData = new WFModelMetaData();
        private HtmlHelper<T> _Html = null;
        public virtual T Model { get; set; }
        public string EnableClientValidation()
        {
            return WFPageUtilities.EnableClientValidation(WFMetaData, this.Page.Form.ClientID);
        }
        public void CallJSMethod()
        {
            WFPageUtilities.CallJSMethod(this, Request);
        }

        #region IWebFormsView<T> Members

        public object GetModel()
        {
            return Model;
        }

        public void SetModel(T model)
        {
            Model = model;
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
    /// <summary>
    /// This class is no longer necessary for any WebFormsUtilities functionality.
    /// Call methods from the WFPageUtilities static class. Inheriting from this class can simplify some aspects.
    /// (ie: declaring HtmlHelper)
    /// </summary>
    public class WFUserControlBase<T> : UserControl, IWebFormsView<T>
    {
        private WFModelMetaData _WFMetaData = new WFModelMetaData();
        private HtmlHelper<T> _Html = null;
        public virtual T Model { get; set; }
        public string EnableClientValidation()
        {
            return WFPageUtilities.EnableClientValidation(WFMetaData, this.Page.Form.ClientID);
        }
        public void CallJSMethod()
        {
            WFPageUtilities.CallJSMethod(this, Request);
        }

        #region IWebFormsView<T> Members

        public object GetModel()
        {
            return Model;
        }

        public void SetModel(T model)
        {
            Model = model;
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
