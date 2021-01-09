using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Viags.Data;
using Viags.Simple;
using Viags.Utils;

namespace Viags.WebApp.Survey.QuestionManage
{
    public partial class AjaxList : Base.BaseWebPage
    {
        SurveyDA SurveyDA = new SurveyDA();
        public int AnyEvaluate = 0;
        public AjaxList()
        {
            SurveyDA = new SurveyDA();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            AnyEvaluate = SurveyDA.CountEvaluate();
        }
        
    }
}