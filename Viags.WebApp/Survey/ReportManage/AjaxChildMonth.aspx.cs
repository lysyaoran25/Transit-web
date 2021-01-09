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
    public partial class AjaxChildMonth : Base.BaseWebPage
    {
        SurveyDA surveyDA;
        public List<SurveyReport_DetailItem> report { get; set; }
        public ucDanhGiaHanhViThaiDo uc;
        public AjaxChildMonth()
        {
            surveyDA = new SurveyDA();
            report = new List<SurveyReport_DetailItem>();
            uc = new ucDanhGiaHanhViThaiDo();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            int total = 0;
            var Month = string.IsNullOrEmpty(Request["Month"]) ? DateTime.Now.Month : Convert.ToInt32(Request["Month"]);
            var Year = string.IsNullOrEmpty(Request["Year"]) ? DateTime.Now.Year : Convert.ToInt32(Request["Year"]);
            Index = RowPerPage * (CurrentPage - 1) + 1;
            report = surveyDA.Get_Report_Detail(RowPerPage, CurrentPage, Month, Year, ref total);
            HtmlPager = uc.pagination("detail", CurrentPage, RowPerPage, total, Month, Year);
        }
    }
}