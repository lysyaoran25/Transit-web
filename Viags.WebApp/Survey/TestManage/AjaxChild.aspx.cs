using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Viags.Data;
using Viags.Simple;
namespace Viags.WebApp.Survey.TestManage
{
    public partial class AjaxChild : Base.BaseWebPage
    {
        SurveyDA surveyDA;
        public List<SurveyTestItem> Surveys;
        public ucDanhGiaHanhViThaiDo uc;
        public string type = "do";
        public string status = "Chờ nhân viên đánh giá";
        public AjaxChild()
        {
            surveyDA = new SurveyDA();
            Surveys = new List<SurveyTestItem>();
            uc = new ucDanhGiaHanhViThaiDo();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            int total = 0;
            int Month = string.IsNullOrEmpty(Request["Month"]) ? DateTime.Now.Month : Convert.ToInt32(Request["Month"]);
            int Year = string.IsNullOrEmpty(Request["Year"]) ? DateTime.Now.Month : Convert.ToInt32(Request["Year"]);
            Index = RowPerPage * (CurrentPage - 1) + 1;
            type = string.IsNullOrEmpty(Request["type"]) ? "" : Request["type"];
            if (type == "do")
            {
                Surveys = surveyDA.Get_List_Survey_Test_Rule(RowPerPage, CurrentPage, Month, Year, ref total);
                HtmlPager = uc.pagination("do", CurrentPage, RowPerPage, total, Month, Year);
            }
            else
            {
                Surveys = surveyDA.Get_List_Survey_Test_Approve(RowPerPage, CurrentPage, Month, Year, ref total);
                HtmlPager = uc.pagination("approve", CurrentPage, RowPerPage, total, Month, Year);
            }
        }

        public string CheckStatus(int test, int user)
        {
            return surveyDA.CheckStatus(test, user);
        }

    }
}