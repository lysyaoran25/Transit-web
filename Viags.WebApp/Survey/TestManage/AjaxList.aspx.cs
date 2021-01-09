using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Viags.Data;
using Viags.Simple;
using Viags.Utils;

namespace Viags.WebApp.Survey.TestManage
{
    public partial class AjaxList : Base.BaseWebPage
    {
        public string type = "";
        public ucDanhGiaHanhViThaiDo uc = new ucDanhGiaHanhViThaiDo();
        public SurveyDA surveyDA = new SurveyDA();
        protected void Page_Load(object sender, EventArgs e)
        {
            type = string.IsNullOrEmpty(Request["type"]) ? "" : Request["type"];
        }

        protected void ImportExcel(object sender, EventArgs e)
        {
            var postedFile = Request.Files["postedFile"];
            if (postedFile.ContentLength > 0)
            {
                var readingFile = new ExcelPackage(postedFile.InputStream);
                var worksheet = readingFile.Workbook.Worksheets.First();
                for (var j = 2; j <= worksheet.Dimension.End.Row; j++)
                {
                    if (CheckNull(worksheet, j, worksheet.Dimension.End.Column - 5))
                    {
                        var temp = new NhiemVuTrongTamItem();
                        //worksheet.Cells[dòng,cột] // get trường dữ liệu theo thứ tự 
                        temp.ID = j - 1;
                        temp.MaNV = worksheet.Cells[j, 2].Text.Trim();
                        temp.ChucDanh = worksheet.Cells[j, 3].Text.Trim();
                        temp.Ten = worksheet.Cells[j, 4].Text.Trim();
                        temp.TenQuanLy = worksheet.Cells[j, 5].Text.Trim();
                        temp.LoaiCongViec = string.IsNullOrEmpty(worksheet.Cells[j, 6].Text.Trim()) ? 1 : 3;
                        temp.KPICha = worksheet.Cells[j, 7].Text.Trim();
                        temp.MaKPI = worksheet.Cells[j, 8].Text.Trim().Replace(" ", "");
                        temp.TenKPI = worksheet.Cells[j, 9].Text.Trim();
                        temp.MucTieu = string.IsNullOrEmpty(worksheet.Cells[j, 10].Text.Trim()) ? 0 : Convert.ToDouble(worksheet.Cells[j, 10].Text.Trim());
                        if (string.IsNullOrEmpty(worksheet.Cells[j, 6].Text.Trim()))
                        {
                            temp.TiTrong = string.IsNullOrEmpty(worksheet.Cells[j, 12].Text.Trim()) ? 0 : Convert.ToDouble(worksheet.Cells[j, 12].Text.Trim());
                            temp.TiTrongBanGiao = string.IsNullOrEmpty(worksheet.Cells[j, 15].Text.Trim()) ? 0 : Convert.ToDouble(worksheet.Cells[j, 15].Text.Trim());
                        }
                        else
                        {
                            temp.TiTrong = string.IsNullOrEmpty(worksheet.Cells[j, 15].Text.Trim()) ? 0 : Convert.ToDouble(worksheet.Cells[j, 15].Text.Trim());
                            temp.TiTrongBanGiao = 0;
                        }
                        temp.DonViTinh = worksheet.Cells[j, 11].Text.Trim();
                        temp.DonViTinhID = string.IsNullOrEmpty(worksheet.Cells[j, 17].Text.Trim()) ? 0 : Convert.ToInt32(worksheet.Cells[j, 17].Text.Trim());
                        temp.QuyTacTinh = worksheet.Cells[j, 13].Text.Trim();
                        temp.TiLe = worksheet.Cells[j, 14].Text.Trim();
                        temp.DuongDan = worksheet.Cells[j, 16].Text.Trim();
                        temp.ChuanDat = string.IsNullOrEmpty(worksheet.Cells[j, 20].Text.Trim()) ? 100 : Convert.ToDouble(worksheet.Cells[j, 20].Text.Trim());
                        temp.NgayBatDau = DateTime.Parse(worksheet.Cells[j, 21].Value.ToString());
                        temp.NgayKetThuc = DateTime.Parse(worksheet.Cells[j, 22].Value.ToString());

                    }
                    else
                    {

                    }
                }

            }

        }

        protected void ExportExcel(object sender, EventArgs e)
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
                            sheetExport.Cells[StartRow, 1].AutoFitColumns(10, 10);


                            sheetExport.Cells[StartRow, 2].Value = item.MaNV;
                            sheetExport.Cells[StartRow, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                            sheetExport.Cells[StartRow, 2].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                            sheetExport.Cells[StartRow, 2].AutoFitColumns(10, 10);

                            sheetExport.Cells[StartRow, 3].Value = item.Name;
                            sheetExport.Cells[StartRow, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                            sheetExport.Cells[StartRow, 3].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                            sheetExport.Cells[StartRow, 3].AutoFitColumns(10, 10);

                            sheetExport.Cells[StartRow, 4].Value = item.Deparment;
                            sheetExport.Cells[StartRow, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                            sheetExport.Cells[StartRow, 4].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                            sheetExport.Cells[StartRow, 4].AutoFitColumns(10, 10);

                            sheetExport.Cells[StartRow, 5].Value = item.Title;
                            sheetExport.Cells[StartRow, 5].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                            sheetExport.Cells[StartRow, 5].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                            sheetExport.Cells[StartRow, 5].AutoFitColumns(10, 10);

                            sheetExport.Cells[StartRow, 6].Value = item.Manager1;
                            sheetExport.Cells[StartRow, 6].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                            sheetExport.Cells[StartRow, 6].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                            sheetExport.Cells[StartRow, 6].AutoFitColumns(10, 10);

                            sheetExport.Cells[StartRow, 7].Value = item.Manager2;
                            sheetExport.Cells[StartRow, 7].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                            sheetExport.Cells[StartRow, 7].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                            sheetExport.Cells[StartRow, 7].AutoFitColumns(10, 10);

                            sheetExport.Cells[StartRow, 8].Value = item.Manager3;
                            sheetExport.Cells[StartRow, 8].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                            sheetExport.Cells[StartRow, 8].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                            sheetExport.Cells[StartRow, 8].AutoFitColumns(10, 10);

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

                            var Total = uc.GetTestTotal((int)item.TestID, (int)item.UserID, 0, 1, 1);
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
        public bool CheckNull(ExcelWorksheet ew, int startRow, int countCol)
        {
            var check = true;
            for (int i = 2; i <= countCol; i++)
            {
                if (i != 6)
                {
                    if (ew.Cells[startRow, i].Text == "")
                    {
                        check = false;
                        break;
                    }
                }
            }
            return check;
        }

        protected void btnUploadClick(object sender, EventArgs e)
        {
            HttpPostedFile file = Request.Files["postedFile"];

            //check file was submitted
            if (file != null && file.ContentLength > 0)
            {
                string fname = Path.GetFileName(file.FileName);
                file.SaveAs(Server.MapPath(Path.Combine("~/App_Data/", fname)));
            }
        }
    }
}