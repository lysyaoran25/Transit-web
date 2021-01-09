using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Viags.Data;
using Viags.Simple;

namespace Viags.WebApp.Survey.QuestionManage.Evaluate
{
    public partial class AjaxFormCreate : Base.BaseWebPage
    {
        public SurveyDA SurveyDA;

        public SurveyEvaluateItem Evaluate;
        public AjaxFormCreate()
        {
            SurveyDA = new SurveyDA();
            Evaluate = new SurveyEvaluateItem();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Evaluate = SurveyDA.Get_Survey_Evaluate_id();
        }
    }
}