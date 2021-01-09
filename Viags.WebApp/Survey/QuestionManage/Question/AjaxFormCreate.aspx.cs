using Newtonsoft.Json;
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
    public partial class AjaxFormCreate : Base.BaseWebPage
    {
        public static SurveyDA SurveyDA;

        public SurveyQuestionItem Question;
        public List<SurveyCategoryItem> Categories { get; set; }
        public AjaxFormCreate()
        {
            SurveyDA = new SurveyDA();
            Categories = new List<SurveyCategoryItem>();
            Question = new SurveyQuestionItem();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Categories = SurveyDA.GetListSurveyCategory_Select();
            if (ItemID > 0)
            {
                Question = SurveyDA.Get_Survey_Question_id(ItemID);
            }
        }

       
    }
}