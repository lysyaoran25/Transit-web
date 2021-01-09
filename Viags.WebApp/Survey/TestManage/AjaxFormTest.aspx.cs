using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Viags.Simple;
using Viags.Data;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Viags.WebApp.Survey.TestManage
{
    public partial class AjaxFormTest : Base.BaseWebPage
    {
        public SurveyTestItem Survey;
        public NguoiDungItem UserTest;
        public SurveyDA surveyDA;
        NguoiDungDA userDA;
        public List<SurveyEvaluate_DetailItem> Evaluate;
        public LanhDaoItem ListManager;
        public string render;
        public bool isSubmit = false;
        public int ManagerID = 0;
        public int UserID = 0;
        public bool ValidateUser = false;
        public string Type;
        public AjaxFormTest()
        {
            UserTest = new NguoiDungItem();
            surveyDA = new SurveyDA();
            userDA = new NguoiDungDA();
            Evaluate = new List<SurveyEvaluate_DetailItem>();
            ListManager = new LanhDaoItem();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Type = string.IsNullOrEmpty(Request["Type"]) ? "" : Request["Type"];
            UserID = string.IsNullOrEmpty(Request["UserID"]) ? CurrentUser.ID : Convert.ToInt32(Request["UserID"]);
            ManagerID = string.IsNullOrEmpty(Request["ManagerID"]) ? -1 : Convert.ToInt32(Request["ManagerID"]);

            UserTest = userDA.Get_User_ID(UserID);
            ListManager = surveyDA.Get_Manager_2Level(UserID);
            if (ItemID > 0)
            {
                Survey = surveyDA.Get_Survey_Test_id(ItemID);
                Evaluate = surveyDA.Get_Survey_Test_Evaluate_id(ItemID);
                render = RenderEvaluate(Evaluate);
                if (ManagerID > 0)
                {
                    isSubmit = surveyDA.CheckSubmit(ItemID, UserID, ManagerID);

                }
                else
                {
                    isSubmit = surveyDA.CheckSubmit(ItemID, UserID);
                }
                if (Type == "Internal")
                {
                    ValidateUser = surveyDA.ValidateUser(CurrentUser.ID, ItemID, UserID);

                }
                else
                {
                    ValidateUser = true;

                }
            }
        }

        public string RenderEvaluate(List<SurveyEvaluate_DetailItem> Evaluate)
        {
            var html = "";
            html = @"<table class='table table-striped survey-table-approval-answer'>";
            html += "<tbody>";
            Index = 1;
            foreach (var item in Evaluate)
            {
                html += "<tr>";
                html += "<td class='survey-order-cell ' style='width:10%'>" + item.Grade + "</td>";
                html += "<td class='survey-name-cell ' style='width:30%'>" + item.Detail.Replace("\n", "<br>") + "</td>";
                html += "<td class='survey-name-cell ' style='width:60%'>data" + Index + "</td>";
                html += "</tr>";
                Index++;
            }
            html += "</tbody>";
            html += "</table>";
            return html;
        }

        public string GetComment(int CommentID, int user, int manager)
        {
            return surveyDA.GetComment(user, manager, ItemID, CommentID);
        }
    }
}