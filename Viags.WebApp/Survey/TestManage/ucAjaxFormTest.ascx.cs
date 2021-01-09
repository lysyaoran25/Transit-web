using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Viags.WebApp.Survey.TestManage
{
    public partial class ucAjaxFormTest : Base.BaseUserControl
    {
        public int ManagerID = 0;
        public int UserID = 0;
        public string Type;
        protected void Page_Load(object sender, EventArgs e)
        {
            UserID = string.IsNullOrEmpty(Request["UserID"]) ? CurrentUser.ID : Convert.ToInt32(Request["UserID"]);
            ManagerID = string.IsNullOrEmpty(Request["ManagerID"]) ? -1 : Convert.ToInt32(Request["ManagerID"]);
            Type = string.IsNullOrEmpty(Request["Type"]) ? "" : Request["Type"];
        }
    }
}