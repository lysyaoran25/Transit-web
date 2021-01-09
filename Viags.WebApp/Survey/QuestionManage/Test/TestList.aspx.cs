using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Viags.Data;
using Viags.Simple;

namespace Viags.WebApp.Survey.QuestionManage.Test
{
    public partial class TestList : Base.BaseWebPage
    {
        SurveyDA SurveyDA = new SurveyDA();
        public List<SurveyTestItem> Tests;
        ucDanhGiaHanhViThaiDo uc;
        public TestList()
        {
            uc = new ucDanhGiaHanhViThaiDo();
            Tests = new List<SurveyTestItem>();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            int total = 0;
            Index = RowPerPage * (CurrentPage - 1) + 1;
            Tests = SurveyDA.GetListSurveyTest(RowPerPage, CurrentPage, ref total);
            HtmlPager = uc.pagination("Test", CurrentPage, RowPerPage, total);
        }

        public bool CheckTest(int test)
        {
            return SurveyDA.CheckTest(test);
        }
    }
}