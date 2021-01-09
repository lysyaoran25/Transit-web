using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormsUtilities.WebControls
{
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:RenderControl runat=server></{0}:RenderControl>")]
    public class RenderControl : WebControl
    {
        //[Bindable(true)]
        //[Category("Appearance")]
        //[DefaultValue("")]
        //[Localizable(true)]
        //public string Text
        //{
        //    get
        //    {
        //        String s = (String)ViewState["Text"];
        //        return ((s == null) ? String.Empty : s);
        //    }

        //    set
        //    {
        //        ViewState["Text"] = value;
        //    }
        //}


        [Bindable(true)]
        [Category("Appearance")]
        [DefaultValue("")]
        [Localizable(true)]
        public string Path
        {
            get
            {
                String s = (String)ViewState["Path"];
                return ((s == null) ? String.Empty : s);
            }

            set
            {
                ViewState["Path"] = value;
            }
        }

        private object _Model = null;

        [Bindable(true)]
        [Category("Appearance")]
        [DefaultValue("")]
        [Localizable(true)]
        public object Model
        {
            get
            {
                return _Model;
            }

            set
            {
                _Model  = value;
            }
        }

        protected override void RenderContents(HtmlTextWriter output)
        {
            if (String.IsNullOrEmpty(Path))
            {
                output.Write("");
            }
            else
            {
                if (_Model != null)
                {
                    output.Write(WFUtilities.RenderControl(Path, _Model));
                }
                else
                {
                    output.Write(WFUtilities.RenderControl(Path));
                }
            }
        }
    }
}
