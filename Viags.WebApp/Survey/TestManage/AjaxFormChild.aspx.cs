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
    public partial class AjaxFormChild : Base.BaseWebPage
    {
        public List<SurveyQuestionItem> Questions { get; set; }
        public static SurveyDA surveyDA;
        public SurveyTest_UserItem manager;
        public List<SurveyEvaluate_DetailItem> Evaluate { get; set; }
        public ucDanhGiaHanhViThaiDo uc;
        public int count = 0;
        public int TestID = 0;
        public int UserID = 0;
        public int ManagerID = 0;
        public bool isSubmit = false;
        public int Level = 0;
        public bool ValidateUser = false;
        public string Type;
        public AjaxFormChild()
        {
            Questions = new List<SurveyQuestionItem>();
            surveyDA = new SurveyDA();
            manager = new SurveyTest_UserItem();
            uc = new ucDanhGiaHanhViThaiDo();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            count = string.IsNullOrEmpty(Request["Count"]) ? 0 : Convert.ToInt32(Request["Count"]);
            TestID = string.IsNullOrEmpty(Request["TestID"]) ? 0 : Convert.ToInt32(Request["TestID"]);
            UserID = string.IsNullOrEmpty(Request["UserID"]) ? CurrentUser.ID : Convert.ToInt32(Request["UserID"]);
            ManagerID = string.IsNullOrEmpty(Request["ManagerID"]) ? -1 : Convert.ToInt32(Request["ManagerID"]);
            isSubmit = string.IsNullOrEmpty(Request["isSubmit"]) ? false : Convert.ToBoolean(Request["isSubmit"]);
            Level = string.IsNullOrEmpty(Request["Level"]) ? CurrentUser.ID : Convert.ToInt32(Request["Level"]);
            Type = string.IsNullOrEmpty(Request["Type"]) ? "" : Request["Type"];

            Questions = surveyDA.Get_Survey_Test_Question_Category(TestID, ItemID);
            Evaluate = surveyDA.Get_Survey_Test_Evaluate_id(TestID);
            manager = surveyDA.GetManagerTest(TestID, UserID);
            if (Type == "Internal")
            {
                ValidateUser = surveyDA.ValidateUser(CurrentUser.ID, TestID, UserID);

            }
            else
            {
                ValidateUser = true;
            }
        }

        public string RenderSelect(int category, int question, int count)
        {
            var html = "";
            html += "<select class='Point selectpoint-" + category + "' id='divpoint' data-category='" + category + "' data-question='" + question + "'>";
            html += "   <option value=''></option>";
            for (int i = 65; i < (65 + count); i++)
            {
                var character = (char)i + "-" + Evaluate.FirstOrDefault(p => p.Grade.Equals(((char)i).ToString())).Point;
                if (ManagerID == manager.Manager1 || ManagerID == manager.Manager2 || ManagerID == manager.Manager3)
                {
                    html += "<option value='" + character + "' " + (surveyDA.GetGrade(TestID, category, question, UserID, ManagerID).Equals(character) ? "selected" : "") + ">" + character + "%</option>";
                }
                else
                {
                    html += "<option value='" + character + "' " + (surveyDA.GetGrade(TestID, category, question, UserID, -1).Equals(character) ? "selected" : "") + " >" + character + "%</option>";
                }

            }
            html += "</select>";
            return html;
        }
        public string GetNote(int test, int category, int question, int user)
        {
            if (ManagerID == manager.Manager1 || ManagerID == manager.Manager2 || ManagerID == manager.Manager3)
            {
                return surveyDA.GetNote(test, category, question, user, ManagerID);
            }
            else
            {
                return surveyDA.GetNote(test, category, question, user, -1);
            }

        }

    }
}