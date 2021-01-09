using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Viags.Data;
using Viags.Simple;
namespace Viags.WebApp.Survey.TestManage
{
    public partial class AjaxFormTotal : Base.BaseWebPage
    {
        SurveyDA surveyDA;
        public SurveyTestItem Survey;
        public ucDanhGiaHanhViThaiDo uc;
        public int UserID = 0;
        public AjaxFormTotal()
        {
            surveyDA = new SurveyDA();
            Survey = new SurveyTestItem();
            uc = new ucDanhGiaHanhViThaiDo();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            UserID = string.IsNullOrEmpty(Request["UserID"]) ? 0 : Convert.ToInt32(Request["UserID"]);
            if (ItemID > 0)
            {
                Survey = surveyDA.Get_Survey_Test_id(ItemID);
            }
        }


    }
}