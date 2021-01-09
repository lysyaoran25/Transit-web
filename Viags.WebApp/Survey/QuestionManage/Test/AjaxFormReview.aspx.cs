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
    public partial class AjaxFormReview : Base.BaseWebPage
    {
        SurveyDA surveyDA;
        public SurveyTestItem Test;
        public string Department;
        public string Area;
        public string Users;
        public AjaxFormReview()
        {
            Test = new SurveyTestItem();
            surveyDA = new SurveyDA();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (ItemID > 0)
            {
                Test = surveyDA.Get_Survey_Test_id(ItemID);
                Area = surveyDA.GetArea(Test.Area);
                Department = surveyDA.GetDepartment(Test.Department);
                Users = surveyDA.GetUser(Test.ID);
            }
        }
    }
}