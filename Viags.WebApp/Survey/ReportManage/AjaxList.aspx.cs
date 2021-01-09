using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Viags.Data;
using Viags.Simple;
using Viags.Utils;

namespace Viags.WebApp.Survey.ReportManage
{
    public partial class AjaxList : Base.BaseWebPage
    {
        SurveyDA surveyDA = new SurveyDA();
        ucDanhGiaHanhViThaiDo uc = new ucDanhGiaHanhViThaiDo();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (DoAction == "excel_month")
            {
                var type = string.IsNullOrEmpty(Request["type"]) ? "" : Request["type"];
                if (type == "detail")
                {
                    Excel_Detail();
                }
                else if (type == "month")
                {
                    Excel_Month();
                }
                else
                {
                    Excel_Year();
                }
            }
        }

        public void Excel_Detail()
        {
            var Month = string.IsNullOrEmpty(Request["Month"]) ? DateTime.Now.Month : Convert.ToInt32(Request["Month"]);
            var Year = string.IsNullOrEmpty(Request["Year"]) ? DateTime.Now.Month : Convert.ToInt32(Request["Year"]);
            var ListUser = surveyDA.Get_Report_Detail_Excel(Month, Year);
            var ListCategory = surveyDA.Get_Report_Categories(Month, Year);
            var ListComment = surveyDA.Get_Report_Comment(Month, Year);
            var ListQuestion = surveyDA.Get_Report_Question(ListCategory.Select(p => p.ID).ToList(), ListUser.Select(p => (int)p.TestID).ToList());
            var Sheet1 = "Sheet1";
            var StartRow = 0;
            var StartColumn = 0;
            var temp = 0;
            var max = 0;
            var index = 1;
            var filePathTemplate = Server.MapPath("/Template/Survey/ReportDetail.xlsx");
            try
            {
                using (var excel = new ExcelPackage(new FileInfo(filePathTemplate)))
                {

                    if (excel.File.Exists)
                    {

                        var sheetExport = excel.Workbook.Worksheets[Sheet1];

                        #region EditExcel
                        sheetExport.Cells[1, 1].Value = "Báo cáo chi tiết tháng 12 Năm 2020";
                        sheetExport.Cells[1, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        StartRow = 4;
                        StartColumn = 9;

                        temp = 9;
                        foreach (var category in ListCategory)
                        {
                            var questions = ListQuestion.Where(p => p.CategoryID == category.ID);
                            foreach (var question in questions)
                            {
                                sheetExport.Cells[StartRow, StartColumn].Value = question.Name;
                                sheetExport.Cells[StartRow, StartColumn].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                                sheetExport.Cells[StartRow, StartColumn].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                                sheetExport.Cells[StartRow, StartColumn].Style.WrapText = true;
                                sheetExport.Column(StartColumn).Width = 20;
                                StartColumn++;
                            }

                            sheetExport.Cells[StartRow, StartColumn].Value = "Tổng (%)";
                            sheetExport.Cells[StartRow, StartColumn].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                            sheetExport.Cells[StartRow, StartColumn].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                            StartColumn++;

                            sheetExport.Cells[StartRow - 1, temp, StartRow - 1, StartColumn - 1].Value = category.Name;
                            sheetExport.Cells[StartRow - 1, temp, StartRow - 1, StartColumn - 1].Merge = true;
                            sheetExport.Cells[StartRow - 1, temp, StartRow - 1, StartColumn - 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                            sheetExport.Cells[StartRow - 1, temp, StartRow - 1, StartColumn - 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                            sheetExport.Cells[StartRow - 1, temp, StartRow - 1, StartColumn - 1].Style.WrapText = true;

                            sheetExport.Cells[StartRow - 1, temp, StartRow, StartColumn - 1].Style.Border.BorderAround(ExcelBorderStyle.Thick);

                            temp = StartColumn;

                        }


                        StartRow = 5;
                        temp = 9;
                        foreach (var item in ListUser)
                        {
                            StartColumn = 9;
                            sheetExport.Cells[StartRow, 1].Value = index;
                            sheetExport.Cells[StartRow, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                            sheetExport.Cells[StartRow, 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                            sheetExport.Column(1).Width = 5;


                            sheetExport.Cells[StartRow, 2].Value = item.MaNV;
                            sheetExport.Cells[StartRow, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                            sheetExport.Cells[StartRow, 2].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                            sheetExport.Column(2).Width = 10;

                            sheetExport.Cells[StartRow, 3].Value = item.Name;
                            sheetExport.Cells[StartRow, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                            sheetExport.Cells[StartRow, 3].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                            sheetExport.Column(3).Width = 15;

                            sheetExport.Cells[StartRow, 4].Value = item.Deparment;
                            sheetExport.Cells[StartRow, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                            sheetExport.Cells[StartRow, 4].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                            sheetExport.Column(4).Width = 10;

                            sheetExport.Cells[StartRow, 5].Value = item.Title;
                            sheetExport.Cells[StartRow, 5].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                            sheetExport.Cells[StartRow, 5].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                            sheetExport.Column(5).Width = 10;

                            sheetExport.Cells[StartRow, 6].Value = item.Manager1.Replace("<br/>", "\n");
                            sheetExport.Cells[StartRow, 6].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                            sheetExport.Cells[StartRow, 6].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                            sheetExport.Column(6).Width = 20;

                            sheetExport.Cells[StartRow, 7].Value = item.Manager2.Replace("<br/>", "\n");
                            sheetExport.Cells[StartRow, 7].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                            sheetExport.Cells[StartRow, 7].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                            sheetExport.Column(7).Width = 20;

                            sheetExport.Cells[StartRow, 8].Value = item.Manager3.Replace("<br/>", "\n");
                            sheetExport.Cells[StartRow, 8].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                            sheetExport.Cells[StartRow, 8].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                            sheetExport.Column(8).Width = 20;

                            foreach (var category in ListCategory)
                            {
                                var questions = ListQuestion.Where(p => p.CategoryID == category.ID);
                                foreach (var question in questions)
                                {
                                    var point = surveyDA.GetGrade((int)item.TestID, category.ID, question.ID, (int)item.UserID, 0, 1);
                                    sheetExport.Cells[StartRow, StartColumn].Value = point + (!string.IsNullOrEmpty(point) ? "%" : "");
                                    sheetExport.Cells[StartRow, StartColumn].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                                    sheetExport.Cells[StartRow, StartColumn].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                                    sheetExport.Cells[StartRow, StartColumn].Style.WrapText = true;
                                    sheetExport.Column(StartColumn).Width = 20;
                                    StartColumn++;
                                }

                                var totalCategory = uc.GetCategoryTotal((int)item.TestID, (int)category.ID, (int)item.UserID, 0, 1);
                                sheetExport.Cells[StartRow, StartColumn].Value = totalCategory + (totalCategory > 0 ? "%" : "");
                                sheetExport.Cells[StartRow, StartColumn].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                                sheetExport.Cells[StartRow, StartColumn].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                                StartColumn++;

                                temp = StartColumn;

                            }

                            var Total = uc.GetTestTotal((int)item.TestID, (int)item.UserID, 0, 0, 1);
                            sheetExport.Cells[StartRow, StartColumn].Value = Math.Round(Total) + (Total > 0 ? "%" : "");
                            sheetExport.Cells[StartRow, StartColumn].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                            sheetExport.Cells[StartRow, StartColumn].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                            StartColumn++;
                            var comments = ListComment.Where(p => p.TestID == item.TestID);
                            if (max < comments.Count())
                            {
                                max = comments.Count();
                            }
                            foreach (var comment in comments)
                            {
                                sheetExport.Cells[StartRow, StartColumn].Value = comment.Name;
                                sheetExport.Cells[StartRow, StartColumn].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                                sheetExport.Cells[StartRow, StartColumn].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                                sheetExport.Cells[StartRow, StartColumn].Style.WrapText = true;
                                sheetExport.Column(StartColumn).Width = 15;

                                StartColumn++;

                                sheetExport.Cells[StartRow, StartColumn].Value = surveyDA.GetComment((int)item.UserID, (int)item.ManagerID, (int)item.TestID, comment.ID);
                                sheetExport.Cells[StartRow, StartColumn].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                                sheetExport.Cells[StartRow, StartColumn].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                                sheetExport.Cells[StartRow, StartColumn].Style.WrapText = true;
                                sheetExport.Column(StartColumn).Width = 15;

                                StartColumn++;
                            }
                            StartRow++;
                            index++;
                        }

                        StartColumn = temp;
                        sheetExport.Cells[4, StartColumn].Value = "Tổng (%)";
                        sheetExport.Cells[4, StartColumn].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        sheetExport.Cells[4, StartColumn].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        sheetExport.Cells[4, StartColumn].Style.Border.BorderAround(ExcelBorderStyle.Thick);
                        StartColumn++;
                        temp = StartColumn;
                        for (int i = 0; i < max; i++)
                        {
                            sheetExport.Cells[4, StartColumn].Value = "Nội dung";
                            sheetExport.Cells[4, StartColumn].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                            sheetExport.Cells[4, StartColumn].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                            sheetExport.Cells[4, StartColumn].Style.WrapText = true;

                            StartColumn++;

                            sheetExport.Cells[4, StartColumn].Value = "Đánh giá";
                            sheetExport.Cells[4, StartColumn].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                            sheetExport.Cells[4, StartColumn].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                            sheetExport.Cells[4, StartColumn].Style.WrapText = true;

                            sheetExport.Cells[3, temp, 3, StartColumn].Value = "QLTT Đánh giá";
                            sheetExport.Cells[3, temp, 3, StartColumn].Merge = true;
                            sheetExport.Cells[3, temp, 3, StartColumn].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                            sheetExport.Cells[3, temp, 3, StartColumn].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                            sheetExport.Cells[3, temp, 3, StartColumn].Style.WrapText = true;

                            sheetExport.Cells[3, temp, 4, StartColumn].Style.Border.BorderAround(ExcelBorderStyle.Thick);

                            StartColumn++;

                            temp = StartColumn;
                        }
                        #endregion

                        #region Export
                        var streamBytes = new MemoryStream(excel.GetAsByteArray());

                        Response.Clear();
                        Response.AddHeader("Content-Disposition", "attachment; filename=" + excel.File.Name);
                        Response.ContentType = "application/application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                        Response.BinaryWrite(streamBytes.ToArray());
                        Response.Flush();
                        Response.Close();
                        Response.End();
                        #endregion
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        public void Excel_Month()
        {
            var Month = string.IsNullOrEmpty(Request["Month"]) ? DateTime.Now.Month : Convert.ToInt32(Request["Month"]);
            var Year = string.IsNullOrEmpty(Request["Year"]) ? DateTime.Now.Month : Convert.ToInt32(Request["Year"]);
            var ListUser = surveyDA.Get_Report_Detail_Excel(Month, Year);
            var ListCategory = surveyDA.Get_Report_Categories(Month, Year);
            var ListComment = surveyDA.Get_Report_Comment(Month, Year);
            var Sheet1 = "Sheet1";
            var StartRow = 0;
            var StartColumn = 0;
            var index = 1;
            var filePathTemplate = Server.MapPath("/Template/Survey/ReportMonth.xlsx");
            try
            {
                using (var excel = new ExcelPackage(new FileInfo(filePathTemplate)))
                {

                    if (excel.File.Exists)
                    {

                        var sheetExport = excel.Workbook.Worksheets[Sheet1];

                        #region EditExcel
                        #endregion
                        sheetExport.Cells[1, 1, 2, 5].Value = "Báo cáo tháng 12 Năm 2020";
                        sheetExport.Cells[1, 1, 2, 5].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                        StartRow = 3;
                        StartColumn = 6;
                        foreach (var category in ListCategory)
                        {
                            sheetExport.Cells[StartRow, StartColumn].Value = category.Name;
                            sheetExport.Cells[StartRow, StartColumn].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                            sheetExport.Cells[StartRow, StartColumn].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                            sheetExport.Cells[StartRow, StartColumn].Style.WrapText = true;
                            sheetExport.Column(StartColumn).Width = 40;
                            StartColumn++;
                        }

                        sheetExport.Cells[StartRow, StartColumn].Value = "Điểm trung bình";
                        sheetExport.Cells[StartRow, StartColumn].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        sheetExport.Cells[StartRow, StartColumn].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        sheetExport.Cells[StartRow, StartColumn].Style.WrapText = true;
                        sheetExport.Column(StartColumn).Width = 40;
                        sheetExport.Cells[StartRow, StartColumn + 1].Value = "Tổng điểm theo tỷ trọng 30%";
                        sheetExport.Cells[StartRow, StartColumn + 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        sheetExport.Cells[StartRow, StartColumn + 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        sheetExport.Cells[StartRow, StartColumn + 1].Style.WrapText = true;
                        sheetExport.Column(StartColumn + 1).Width = 40;
                        StartColumn = StartColumn + 2;
                        foreach (var comment in ListComment)
                        {
                            sheetExport.Cells[StartRow, StartColumn].Value = comment.Name;
                            sheetExport.Cells[StartRow, StartColumn].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                            sheetExport.Cells[StartRow, StartColumn].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                            sheetExport.Cells[StartRow, StartColumn].Style.WrapText = true;
                            sheetExport.Column(StartColumn).Width = 40;
                            StartColumn++;
                        }

                        StartRow = 4;
                        foreach (var item in ListUser)
                        {
                            StartColumn = 6;
                            sheetExport.Cells[StartRow, 1].Value = index;
                            sheetExport.Cells[StartRow, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                            sheetExport.Cells[StartRow, 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                            sheetExport.Cells[StartRow, 1].AutoFitColumns(10, 10);

                            sheetExport.Cells[StartRow, 2].Value = item.MaNV;
                            sheetExport.Cells[StartRow, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                            sheetExport.Cells[StartRow, 2].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                            sheetExport.Cells[StartRow, 2].AutoFitColumns(20, 60);

                            sheetExport.Cells[StartRow, 3].Value = item.Name;
                            sheetExport.Cells[StartRow, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                            sheetExport.Cells[StartRow, 3].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                            sheetExport.Cells[StartRow, 3].AutoFitColumns(20, 60);

                            sheetExport.Cells[StartRow, 4].Value = item.Deparment;
                            sheetExport.Cells[StartRow, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                            sheetExport.Cells[StartRow, 4].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                            sheetExport.Cells[StartRow, 4].AutoFitColumns(20, 60);

                            sheetExport.Cells[StartRow, 5].Value = item.Area;
                            sheetExport.Cells[StartRow, 5].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                            sheetExport.Cells[StartRow, 5].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                            sheetExport.Cells[StartRow, 5].AutoFitColumns(20, 60);

                            foreach (var category in ListCategory)
                            {
                                var point = uc.GetCategoryTotal((int)item.TestID, category.ID, (int)item.UserID, 0, 1);
                                sheetExport.Cells[StartRow, StartColumn].Value = point + (point > 0 ? "%" : "");
                                sheetExport.Cells[StartRow, StartColumn].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                                sheetExport.Cells[StartRow, StartColumn].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                                StartColumn++;
                            }

                            var total = uc.GetTestTotal((int)item.TestID, (int)item.UserID, 0, 0, 1);
                            sheetExport.Cells[StartRow, StartColumn].Value = Math.Round(total / ((30 * 1.0) / (1.0 * 100)), 1) + (total > 0 ? "%" : "");
                            sheetExport.Cells[StartRow, StartColumn].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                            sheetExport.Cells[StartRow, StartColumn].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                            sheetExport.Column(StartColumn).Width = 20;

                            sheetExport.Cells[StartRow, StartColumn + 1].Value = Math.Round(total, 1) + (total > 0 ? "%" : "");
                            sheetExport.Cells[StartRow, StartColumn + 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                            sheetExport.Cells[StartRow, StartColumn + 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                            sheetExport.Column(StartColumn + 1).Width = 20;
                            StartColumn = StartColumn + 2;
                            foreach (var comment in ListComment)
                            {
                                var cm = surveyDA.GetComment((int)item.UserID, (int)item.ManagerID, (int)item.TestID, comment.ID);
                                sheetExport.Cells[StartRow, StartColumn].Value = cm;
                                sheetExport.Cells[StartRow, StartColumn].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                                sheetExport.Cells[StartRow, StartColumn].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                                StartColumn++;
                            }
                            StartRow++;
                            index++;
                        }
                        #region Export
                        var streamBytes = new MemoryStream(excel.GetAsByteArray());

                        Response.Clear();
                        Response.AddHeader("Content-Disposition", "attachment; filename=" + excel.File.Name);
                        Response.ContentType = "application/application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                        Response.BinaryWrite(streamBytes.ToArray());
                        Response.Flush();
                        Response.Close();
                        Response.End();
                        #endregion
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        public void Excel_Year()
        {

        }
    }
}