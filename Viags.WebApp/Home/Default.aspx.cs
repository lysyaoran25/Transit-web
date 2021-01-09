using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Viags.WebApp.Home
{
    public partial class Default : Base.BaseWebPage
    {
        private string go = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (HttpContext.Current.Request["go"] != null)
            //    go = HttpContext.Current.Request["go"].ToString().ToLower();

            //UserControl uc = (UserControl)Page.LoadControl("/LuuTru/ThuThapTaiLieu/KeHoachThuThap/ucKeHoachThuThap.ascx");

            //#region Load Control
            //switch (go)
            //{
            //    case "vanbanden":
            //        plhLoadControl.Controls.Add(LoadControl(""));
            //        break;
            //    case "fromvanbanden":
            //        plhLoadControl.Controls.Add(LoadControl(""));
            //        break;

            //    #region kế hoạch thu thập
            //    case "ke-hoach-thu-thap":
            //        //plhLoadControl.Controls.Add(LoadControl("/LuuTru/ThuThapTaiLieu/KeHoachThuThap/ucKeHoachThuThap.ascx"));
            //        plhLoadControl.Controls.Add(uc);
            //        break;
            //    case "quan-ly-don-vi-nop-luu":
            //        //plhLoadControl.Controls.Add(LoadControl("/LuuTru/ThuThapTaiLieu/KeHoachThuThap/ucChiTietKeHoach.ascx"));
            //        plhLoadControl.Controls.Add(uc);
            //        break;
            //    #endregion

            //    default:
            //        plhLoadControl.Controls.Add(LoadControl("/Home/ucHome.ascx"));
            //        break;
            //}
            //#endregion
        }

        //protected override void CreateChildControls()
        //{
        //    base.CreateChildControls();

        //    if (HttpContext.Current.Request["go"] != null)
        //        go = HttpContext.Current.Request["go"].ToString().ToLower();

        //    UserControl uc = (UserControl)Page.LoadControl("/LuuTru/ThuThapTaiLieu/KeHoachThuThap/ucKeHoachThuThap.ascx");

        //    switch (go)
        //    {
        //        case "vanbanden":
        //            plhLoadControl.Controls.Add(LoadControl(""));
        //            break;
        //        case "fromvanbanden":
        //            plhLoadControl.Controls.Add(LoadControl(""));
        //            break;

        //        #region kế hoạch thu thập
        //        case "ke-hoach-thu-thap":
        //            //plhLoadControl.Controls.Add(LoadControl("/LuuTru/ThuThapTaiLieu/KeHoachThuThap/ucKeHoachThuThap.ascx"));
        //            plhLoadControl.Controls.Add(uc);
        //            break;
        //        case "quan-ly-don-vi-nop-luu":
        //            //plhLoadControl.Controls.Add(LoadControl("/LuuTru/ThuThapTaiLieu/KeHoachThuThap/ucChiTietKeHoach.ascx"));
        //            plhLoadControl.Controls.Add(uc);
        //            break;
        //        #endregion

        //        default:
        //            plhLoadControl.Controls.Add(LoadControl("/Home/ucHome.ascx"));
        //            break;
        //    }
        //}
        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static bool checksession()
        {

            return true;
        }
    }
}