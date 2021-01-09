using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Viags.WebApp.QuanLyDashBoard
{
    public partial class ucDashBoard : Base.BaseUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.NhanVienXuatSac))
            {
                Response.Redirect("/Pagess/error.aspx");
            }
        }
    }
}