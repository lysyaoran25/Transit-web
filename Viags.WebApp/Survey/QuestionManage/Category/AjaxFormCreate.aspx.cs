using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Viags.Data;
using Viags.Simple;

namespace Viags.WebApp.Survey.QuestionManage.Category
{
    public partial class AjaxFormCreate : Base.BaseWebPage
    {
        public SurveyDA SurveyDA;

        public SurveyCategoryItem Category;
        public AjaxFormCreate()
        {
            SurveyDA = new SurveyDA();
            Category = new SurveyCategoryItem();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (ItemID > 0)
            {
                Category = SurveyDA.Get_Survey_Category_id(ItemID);
            }
        }
    }
}