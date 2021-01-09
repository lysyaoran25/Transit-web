using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Viags.WebApp.Notification
{
    public partial class ucListAllThongBao : Base.BaseUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Danhmuc))
            //{
            //    Response.Redirect("/Pagess/error.aspx");
            //}
        }
    }
}