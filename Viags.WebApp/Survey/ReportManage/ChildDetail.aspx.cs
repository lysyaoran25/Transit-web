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
    public partial class ChildDetail : Base.BaseWebPage
    {
        SurveyDA surveyDA;
        public ucDanhGiaHanhViThaiDo uc;
        public List<SurveyQuestionItem> Questions { get; set; }
        public int UserID = 0;
        public int TestID = 0;
        public int Manager;
        public ChildDetail()
        {
            surveyDA = new SurveyDA();
            Questions = new List<SurveyQuestionItem>();
            uc = new ucDanhGiaHanhViThaiDo();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            UserID = string.IsNullOrEmpty(Request["UserID"]) ? 0 : Convert.ToInt32(Request["UserID"]);
            if (ItemID > 0)
            {
                TestID = string.IsNullOrEmpty(Request["TestID"]) ? 0 : Convert.ToInt32(Request["TestID"]);
                Questions = surveyDA.Get_Survey_Test_Question_Category(TestID, ItemID);
                Manager = surveyDA.GetFinalSubmit(TestID, UserID);
            }

        }
    }
}