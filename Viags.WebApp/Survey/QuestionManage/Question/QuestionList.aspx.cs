using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Viags.Data;
using Viags.Simple;

namespace Viags.WebApp.Survey.QuestionManage.Question
{
    public partial class QuestionList : Base.BaseWebPage
    {
        SurveyDA SurveyDA = new SurveyDA();
        public List<SurveyQuestionItem> Questions;
        ucDanhGiaHanhViThaiDo uc;

        public QuestionList()
        {
            Questions = new List<SurveyQuestionItem>();
            uc = new ucDanhGiaHanhViThaiDo();

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            int total = 0;
            Index = RowPerPage * (CurrentPage - 1) + 1;
            Questions = SurveyDA.GetListSurveyQuestion(RowPerPage, CurrentPage, ref total);
            HtmlPager = uc.pagination("Question", CurrentPage, RowPerPage, total);
        }

        [WebMethod]
        public static string ChangeStatus_Question(int id, bool status)
        {
            SurveyDA surveyDA = new SurveyDA();
            surveyDA.ChangeStatus_Question(id, status);
            return "";
        }
    }
}