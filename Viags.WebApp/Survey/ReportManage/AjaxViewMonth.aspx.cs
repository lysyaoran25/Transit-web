using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Viags.Data;
using Viags.Simple;
namespace Viags.WebApp.Survey.ReportManage
{
    public partial class AjaxViewMonth : Base.BaseWebPage
    {
        public SurveyDA surveyDA;
        NguoiDungDA nguoiDungDA;
        public SurveyTestItem survey { get; set; }
        public int UserID = 0;
        public string UserName = "";
        public ucDanhGiaHanhViThaiDo uc;
        public NguoiDungItem user;
        public AjaxViewMonth()
        {
            surveyDA = new SurveyDA();
            nguoiDungDA = new NguoiDungDA();
            survey = new SurveyTestItem();
            uc = new ucDanhGiaHanhViThaiDo();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            UserID = string.IsNullOrEmpty(Request["UserID"]) ? 0 : Convert.ToInt32(Request["UserID"]);
            user = nguoiDungDA.Get_User_ID(UserID);
            if (user != null)
            {
                UserName = user.TenHienThi;
            }
            survey = surveyDA.Get_Survey_Test_id(ItemID);
        }
    }
}