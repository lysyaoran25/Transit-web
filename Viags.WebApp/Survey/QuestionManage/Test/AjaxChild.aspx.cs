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
    public partial class AjaxChild : Base.BaseWebPage
    {
        SurveyDA surveyDA;
        public List<SurveyQuestionItem> Questions { get; set; }
        public AjaxChild()
        {
            surveyDA = new SurveyDA();
            Questions = new List<SurveyQuestionItem>();
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            if (ItemID > 0)
            {
                var TestID = string.IsNullOrEmpty(Request["TestID"]) ? 0 : Convert.ToInt32(Request["TestID"]);
                Questions = surveyDA.Get_Survey_Test_Question_Category(TestID, ItemID);
            }
        }
    }
}