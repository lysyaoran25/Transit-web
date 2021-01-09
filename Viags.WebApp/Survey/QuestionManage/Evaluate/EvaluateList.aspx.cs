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
    public partial class EvaluateList : Base.BaseWebPage
    {
        SurveyDA surveyDA;
        public SurveyEvaluateItem Evaluates;
        AjaxList ajaxList;
        public EvaluateList()
        {
            surveyDA = new SurveyDA();
            Evaluates = new SurveyEvaluateItem();
            ajaxList = new AjaxList();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Evaluates = surveyDA.GetListSurveyEvaluate();
        }
    }
}