using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Viags.Data;
using Viags.Simple;

namespace Viags.WebApp.Survey
{
    public partial class ucDanhGiaHanhViThaiDo : Base.BaseUserControl
    {
        public SurveyDA surveyDA = new SurveyDA();

        protected void Page_Load(object sender, EventArgs e)
        {
        }
        public string pagination(string type, int intCurrentPage, int intRowPerPage, int intTotalRecord, int month = 0, int year = 0)
        {
            List<int> ltsRowPerpage = new List<int>() { 5, 10, 15, 20, 25, 30, 35, 40, 45, 50, 55, 100 };
            if (!ltsRowPerpage.Contains(intRowPerPage))
                ltsRowPerpage.Add(intRowPerPage);
            ltsRowPerpage.Sort();

            int intTotalPage = (intTotalRecord % intRowPerPage == 0) ? intTotalRecord / intRowPerPage : ((intTotalRecord - (intTotalRecord % intRowPerPage)) / intRowPerPage) + 1; ;
            StringBuilder strBuilder = new StringBuilder();
            if (month > 0 && year > 0)
            {
                if (intTotalRecord > 0)
                {
                    strBuilder.Append("<div class=\"bottom-pager\">\r\n");
                    strBuilder.Append("    <div class=\"left\">\r\n");
                    if (intCurrentPage > 1)
                    {
                        strBuilder.AppendFormat("       <a href=\"javascript:;\" onclick=\"refreshPage('{0}',{1},{2},{3},{4})\" class=\"first\" title=\"" + HttpContext.GetGlobalResourceObject("Other", "lblTrangDau").ToString() + "\"></a>\r\n", type, intRowPerPage, 1, month, year);
                        strBuilder.AppendFormat("       <a href=\"javascript:;\" onclick=\"refreshPage('{0}',{1},{2},{3},{4})\" class=\"pre\" title=\"" + HttpContext.GetGlobalResourceObject("Other", "lblTrangTruoc").ToString() + "\"></a>\r\n", type, intRowPerPage, intCurrentPage - 1, month, year);
                    }
                    else
                    {
                        strBuilder.Append("        <a href=\"javascript:;\" class=\" first-disable\" title=\"" + HttpContext.GetGlobalResourceObject("Other", "lblTrangDau").ToString() + "\"></a>\r\n");
                        strBuilder.Append("        <a href=\"javascript:;\" class=\"pre-disable\" title=\"" + HttpContext.GetGlobalResourceObject("Other", "lblTrangTruoc").ToString() + "\"></a>\r\n");
                    }
                    strBuilder.Append("        <span>" + HttpContext.GetGlobalResourceObject("Other", "lblTrang").ToString() + "</span>\r\n");
                    strBuilder.AppendFormat("        <input onclick=\"ChangePage('{2}',{1},this,{3},{4})\" type=\"text\" name=\"page\" value=\"{0}\" />\r\n", intCurrentPage, intRowPerPage, type, month, year);
                    strBuilder.AppendFormat("        <input type=\"hidden\" value=\"{0}\" />\r\n", intTotalPage);
                    strBuilder.AppendFormat("        <span>/{0}</span>\r\n", intTotalPage);

                    if (intCurrentPage < intTotalPage)
                    {
                        strBuilder.AppendFormat("        <a href=\"javascript:;\" onclick=\"refreshPage('{0}',{1},{2},{3},{4})\" class=\"next\" title=\"" + HttpContext.GetGlobalResourceObject("Other", "lblTrangTiep").ToString() + "\"></a>\r\n", type, intRowPerPage, intCurrentPage + 1, month, year);
                        strBuilder.AppendFormat("        <a href=\"javascript:;\" onclick=\"refreshPage('{0}',{1},{2},{3},{4})\" class=\"last\" title=\"" + HttpContext.GetGlobalResourceObject("Other", "lblTrangCuoi").ToString() + "\"></a>\r\n", type, intRowPerPage, intTotalPage, month, year);
                    }
                    else
                    {
                        strBuilder.Append("        <a href=\"javascript:;\" class=\"next-disable\" title=\"" + HttpContext.GetGlobalResourceObject("Other", "lblTrangTiep").ToString() + "\"></a>\r\n");
                        strBuilder.Append("        <a href=\"javascript:;\" class=\"last-disable\" title=\"" + HttpContext.GetGlobalResourceObject("Other", "lblTrangCuoi").ToString() + "\"></a>\r\n");
                    }
                    strBuilder.Append("    </div>\r\n");
                    strBuilder.Append("    <div class=\"right\">\r\n");
                    strBuilder.Append("        <span>" + HttpContext.GetGlobalResourceObject("Other", "lblKetQuaTrenMotTrang").ToString() + ":</span>\r\n");
                    strBuilder.AppendFormat("        <select name=\"RowPerPage\" onchange=\"ChangeRow('{0}',this,{1},{2})\">\r\n", type, month, year);
                    foreach (var item in ltsRowPerpage)
                    {
                        strBuilder.AppendFormat("            <option value=\"{0}\"{1}>{2}</option>\r\n", item, (item == intRowPerPage) ? " selected" : "", item);
                    }
                    strBuilder.Append("        </select>\r\n");
                    strBuilder.AppendFormat("        <span>/ " + HttpContext.GetGlobalResourceObject("Other", "lblTongSo").ToString() + ": {0}</span>\r\n", intTotalRecord);
                    strBuilder.Append("    </div>\r\n");
                    strBuilder.Append("</div>\r\n");
                }
                else
                {
                    strBuilder.Append("<div class=\"bottom-pager\"><span>" + HttpContext.GetGlobalResourceObject("Other", "lblHienTaiDanhSachNayChuaCoDuLieu").ToString() + ".</span></div>\r\n");
                }
            }
            else
            {
                if (intTotalRecord > 0)
                {
                    strBuilder.Append("<div class=\"bottom-pager\">\r\n");
                    strBuilder.Append("    <div class=\"left\">\r\n");
                    if (intCurrentPage > 1)
                    {
                        strBuilder.AppendFormat("       <a href=\"javascript:;\" onclick=\"refreshPage('{0}',{1},{2})\" class=\"first\" title=\"" + HttpContext.GetGlobalResourceObject("Other", "lblTrangDau").ToString() + "\"></a>\r\n", type, intRowPerPage, 1);
                        strBuilder.AppendFormat("       <a href=\"javascript:;\" onclick=\"refreshPage('{0}',{1},{2})\" class=\"pre\" title=\"" + HttpContext.GetGlobalResourceObject("Other", "lblTrangTruoc").ToString() + "\"></a>\r\n", type, intRowPerPage, intCurrentPage - 1);
                    }
                    else
                    {
                        strBuilder.Append("        <a href=\"javascript:;\" class=\" first-disable\" title=\"" + HttpContext.GetGlobalResourceObject("Other", "lblTrangDau").ToString() + "\"></a>\r\n");
                        strBuilder.Append("        <a href=\"javascript:;\" class=\"pre-disable\" title=\"" + HttpContext.GetGlobalResourceObject("Other", "lblTrangTruoc").ToString() + "\"></a>\r\n");
                    }
                    strBuilder.Append("        <span>" + HttpContext.GetGlobalResourceObject("Other", "lblTrang").ToString() + "</span>\r\n");
                    strBuilder.AppendFormat("        <input onclick=\"ChangePage('{2}',{1},this)\" type=\"text\" name=\"page\" value=\"{0}\" />\r\n", intCurrentPage, intRowPerPage, type);
                    strBuilder.AppendFormat("        <input type=\"hidden\" value=\"{0}\" />\r\n", intTotalPage);
                    strBuilder.AppendFormat("        <span>/{0}</span>\r\n", intTotalPage);

                    if (intCurrentPage < intTotalPage)
                    {
                        strBuilder.AppendFormat("        <a href=\"javascript:;\" onclick=\"refreshPage('{0}',{1},{2})\" class=\"next\" title=\"" + HttpContext.GetGlobalResourceObject("Other", "lblTrangTiep").ToString() + "\"></a>\r\n", type, intRowPerPage, intCurrentPage + 1);
                        strBuilder.AppendFormat("        <a href=\"javascript:;\" onclick=\"refreshPage('{0}',{1},{2})\" class=\"last\" title=\"" + HttpContext.GetGlobalResourceObject("Other", "lblTrangCuoi").ToString() + "\"></a>\r\n", type, intRowPerPage, intTotalPage);
                    }
                    else
                    {
                        strBuilder.Append("        <a href=\"javascript:;\" class=\"next-disable\" title=\"" + HttpContext.GetGlobalResourceObject("Other", "lblTrangTiep").ToString() + "\"></a>\r\n");
                        strBuilder.Append("        <a href=\"javascript:;\" class=\"last-disable\" title=\"" + HttpContext.GetGlobalResourceObject("Other", "lblTrangCuoi").ToString() + "\"></a>\r\n");
                    }
                    strBuilder.Append("    </div>\r\n");
                    strBuilder.Append("    <div class=\"right\">\r\n");
                    strBuilder.Append("        <span>" + HttpContext.GetGlobalResourceObject("Other", "lblKetQuaTrenMotTrang").ToString() + ":</span>\r\n");
                    strBuilder.AppendFormat("        <select name=\"RowPerPage\" onchange=\"ChangeRow('{0}',this)\">\r\n", type);
                    foreach (var item in ltsRowPerpage)
                    {
                        strBuilder.AppendFormat("            <option value=\"{0}\"{1}>{2}</option>\r\n", item, (item == intRowPerPage) ? " selected" : "", item);
                    }
                    strBuilder.Append("        </select>\r\n");
                    strBuilder.AppendFormat("        <span>/ " + HttpContext.GetGlobalResourceObject("Other", "lblTongSo").ToString() + ": {0}</span>\r\n", intTotalRecord);
                    strBuilder.Append("    </div>\r\n");
                    strBuilder.Append("</div>\r\n");
                }
                else
                {
                    strBuilder.Append("<div class=\"bottom-pager\"><span>" + HttpContext.GetGlobalResourceObject("Other", "lblHienTaiDanhSachNayChuaCoDuLieu").ToString() + ".</span></div>\r\n");
                }

            }

            return strBuilder.ToString();
        }

        public string GetPoint(int test, int category, int question, int user, int manager)
        {
            return surveyDA.GetGrade(test, category, question, user, manager);
        }
        public string GetNote(int test, int category, int question, int user, int manager)
        {
            return surveyDA.GetNote(test, category, question, user, manager);
        }

        public double GetCategoryTotal(int test, int category, int user, int level = 0, int type = 0)
        {
            double total = 0;
            total = surveyDA.GetCategoryTotal(test, category, user, level, type);
            return total;
        }
        public double GetTestTotal(int test, int user, int level, int notuser = 0, int type = 0)
        {
            double total = 0;
            total = surveyDA.GetTestTotal(test, user, level, notuser, type);
            return total;
        }
    }
}