using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Viags.Data;
using Viags.Simple;
using Newtonsoft.Json;
namespace Viags.WebApp.Survey.QuestionManage.Test
{
    public partial class AjaxFormCreate : Base.BaseWebPage
    {
        public static SurveyDA SurveyDA;
        DonViDA DonViDA;
        NguoiDungDA nguoiDungDA;
        public SurveyTestItem Test;
        public List<DonViItem> ListArea;
        public List<SurveyCategoryItem> Categories { get; set; }
        public List<NguoiDungItem> ListUser { get; set; }
        public string questions = string.Empty;
        public AjaxFormCreate()
        {
            SurveyDA = new SurveyDA();
            DonViDA = new DonViDA();
            Categories = new List<SurveyCategoryItem>();
            Test = new SurveyTestItem();
            ListArea = new List<DonViItem>();
            nguoiDungDA = new NguoiDungDA();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Categories = SurveyDA.GetListSurveyCategory_Select();
            ListArea = DonViDA.GetAllDonVi();
            ListUser = nguoiDungDA.GetNguoiDungByLanhDao_ThemMoi(CurrentUser.ID);

            if (ItemID > 0)
            {
                Test = SurveyDA.Get_Survey_Test_id(ItemID);
                int i = 1;
                foreach (var category in Test.ListCategory)
                {
                    questions += LoadQuestion_Edit(SurveyDA.Get_Survey_Test_Question_Category(ItemID, category.ID), ref i, category.Name);
                }
            }
        }

        public string LoadQuestion_Edit(List<SurveyQuestionItem> questions, ref int i, string name)
        {
            var html = "";
            html += "<div class='form-inline row'>";
            html += "<label class='control-label col-sm-12'>" + name + "</label>";
            html += "</div>";
            foreach (var question in questions)
            {
                html += "<div class='form-inline row'>";
                html += "   <label class='control-label col-sm-1'>" + i + "</label>";
                html += "   <input type='text' disabled='disabled' class='form-control col-sm-9' value='" + question.Name + "'/>";
                html += "   <input type='checkbox' checked='checked' class='form-control col-sm-2 checkbox-custom surveytest-question' data-question='" + question.ID + "'/>";
                html += "</div></br>";
                i++;
            }
            html += "</hr>";
            return html;
        }
        [WebMethod]
        public static object ChangeArea(string listarea)
        {
            DonViDA donViDA = new DonViDA();
            try
            {
                var listid = string.IsNullOrEmpty(listarea) || listarea == "null" ? new List<int>() : listarea.Split(',').Select(p => Convert.ToInt32(p)).ToList();
                var list = donViDA.GetListPhongBan_ListDonVi(listid);
                return list;
            }
            catch (Exception ex)
            {
                return null;
            }


        }

        [WebMethod]
        public static string LoadQuestion_Add(string category)
        {
            var html = "";
            var list = category != "null" ? category.Split(',').Select(p => Convert.ToInt32(p)).OrderBy(p => p).ToList() : new List<int>();
            var index = 1;
            foreach (var item in list)
            {
                var questions = SurveyDA.Get_Survey_Question_Category(item);
                var name = SurveyDA.Get_Survey_Category_id(item);
                html += "<div class='form-inline row'>";
                html += "<label class='control-label col-sm-12'>" + name.Name + "</label>";
                html += "</div>";
                foreach (var question in questions)
                {
                    html += "<div class='form-inline row'>";
                    html += "   <label class='control-label col-sm-1'>" + index + "</label>";
                    html += "   <input type='text' disabled='disabled' class='form-control col-sm-9' value='" + question.Name + "'/>";
                    html += "   <input type='checkbox' checked='checked' class='form-control col-sm-2 checkbox-custom surveytest-question' data-question='" + question.ID + "'/>";
                    html += "</div></br>";
                    index++;
                }
            }
            html += "</hr>";
            return html;
        }
    }
}