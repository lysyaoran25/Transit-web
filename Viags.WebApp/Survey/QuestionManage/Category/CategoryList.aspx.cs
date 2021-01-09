using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Viags.Data;
using Viags.Simple;

namespace Viags.WebApp.Survey.QuestionManage.Category
{
    public partial class CategoryList : Base.BaseWebPage
    {
        SurveyDA SurveyDA = new SurveyDA();
        public List<SurveyCategoryItem> Categories;
        ucDanhGiaHanhViThaiDo uc;
        public CategoryList()
        {
            Categories = new List<SurveyCategoryItem>();
            uc = new ucDanhGiaHanhViThaiDo();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            int total = 0;
            Index = RowPerPage * (CurrentPage - 1) + 1;
            Categories = SurveyDA.GetListSurveyCategory(RowPerPage, CurrentPage, ref total);
            HtmlPager = uc.pagination("Category", CurrentPage, RowPerPage, total);
        }

        [WebMethod]
        public static string ChangeStatus_Category(int id, bool status)
        {
            SurveyDA surveyDA = new SurveyDA();
            surveyDA.ChangeStatus_Category(id, status);
            return "";
        }
    }
}