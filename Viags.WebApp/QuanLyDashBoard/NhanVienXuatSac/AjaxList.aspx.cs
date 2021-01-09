using Newtonsoft.Json;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Viags.Data;
using Viags.Simple;
namespace Viags.WebApp.QuanLyDashBoard.NhanVienXuatSac
{
    public partial class AjaxList : Base.BaseWebPage
    {
        DashBoardDA dashBoardDA = new DashBoardDA();
        public List<NhanVienXuatSacItem> nhanVienXuatSacItems { get; set; }
        public AjaxList()
        {
            dashBoardDA = new DashBoardDA();
            nhanVienXuatSacItems = new List<NhanVienXuatSacItem>();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            nhanVienXuatSacItems = dashBoardDA.GetNhanVienXuatSacPagingWithSearch(CurrentPage, RowPerPage, Field, FieldOption, Keyword, SearchInFiled);
            HtmlPager = Viags.Utils.HtmlPager.getPage(
                string.Format("#RowPerPage={0}&PageStep={1}&Field={2}&FieldOption={3}&Keyword={4}&SearchIn={5}&Page=", RowPerPage, PageStep,
                                Field, (FieldOption) ? 0 : 1, Keyword, string.Join(",", SearchInFiled.ToArray())), CurrentPage, RowPerPage, dashBoardDA.TotalRecord);

            if (DoAction == "excel")
            {
                var sheetNVXS = "NhanVienXuatSac";
                var startRowIndex = 2;
                var filePathTemplate = Server.MapPath("/Template/QuanlyDashboard/nhan_vien_xuat_sac_template.xlsx");
                try
                {
                    using (var excel = new ExcelPackage(new FileInfo(filePathTemplate)))
                    {

                        if (excel.File.Exists)
                        {
                            var sheetDB = excel.Workbook.Worksheets[sheetNVXS];
                            var Listtemp = dashBoardDA.GetNhanVienXuatSacExcel();

                            if (Listtemp.Any())
                            {
                                foreach (var item in Listtemp)
                                {

                                    sheetDB.Cells[startRowIndex, 1].Value = item.MaNV;
                                    sheetDB.Cells[startRowIndex, 2].Value = item.TenNguoiDung;
                                    sheetDB.Cells[startRowIndex, 3].Value = item.Mota;
                                    sheetDB.Cells[startRowIndex, 4].Value = item.Thang;
                                    sheetDB.Cells[startRowIndex, 5].Value = item.Quy;
                                    sheetDB.Cells[startRowIndex, 6].Value = item.TenPhongBan;
                                    sheetDB.Cells[startRowIndex, 7].Value = item.TenDonVi;
                                    sheetDB.Cells[startRowIndex, 8].Value = item.TenNguoiTao;
                                    sheetDB.Cells[startRowIndex, 9].Value = string.Format("{0:dd/MM/yyyy}", item.NgayTao);
                                    sheetDB.Cells[startRowIndex, 10].Value = item.HienThi == true ? "Hiển thị" : "Ẩn";
                                    startRowIndex++;
                                }

                            }

                            //excel.Save();
                            var streamBytes = new MemoryStream(excel.GetAsByteArray());

                            // Clear Rsponse reference  
                            Response.Clear();
                            // Add header by specifying file name  
                            Response.AddHeader("Content-Disposition", "attachment; filename=NhanVienXuatSac.xlsx");
                            // Add header for content length  
                            //Response.AddHeader("Content-Length", excel.File.Length.ToString());
                            // Specify content type  
                            Response.ContentType = "application/application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                            Response.BinaryWrite(streamBytes.ToArray());
                            // Clearing flush  
                            Response.Flush();
                            // Transimiting file  
                            Response.Close();
                            Response.End();
                        }

                        //var streamBytes = new MemoryStream(excel.GetAsByteArray());
                        //return ;
                    }
                }
                catch (Exception ex)
                {

                }
            }
        }

        [WebMethod]
        public static string GetListNhanVien(int? KhuVucNVXS, int TimeType, int month, int year, int quarter)
        {
            DashBoardDA DashBoardDA = new DashBoardDA();
            var list = DashBoardDA.GetNhanViecXuatSacDonVi(KhuVucNVXS, TimeType, month, year, quarter);
            var html = "";
            foreach (var item in list)
            {
                html += "<div class='our-team'>"
                                + "<div class='picture'>"

                                    + "<img class='img-fluid' style='width: 100px;height: 100px;' src='" + (string.IsNullOrEmpty(item.AnhDaiDien) ? "/Publishing_Resources/img/avatar.png" : "/" + item.AnhDaiDien) + "'>"

                                    //+ "<img class='img-fluid' style='width: 100px;height: 100px;' src='https://cdn0.iconfinder.com/data/icons/social-media-network-4/48/male_avatar-512.png'>"

                                + "</div>"

                                + "<div class='team-content'>"
                                    + "<h3 class='name'>" + item.TenNguoiDung + "</h3>"
                                    + "<h3 class='title'>" + item.TenPhongBan + "-" + item.TenDonVi + "</h3>"
                                + "</div>"

                        + "</div>";
            }
            
            return html;
        }

    [WebMethod]
    public static string NextPreMonth(int CheckKhuVuc, List<int> ListKhuVucNVXS, int Month, int Year)
    {
        DashBoardDA dashBoardDA = new DashBoardDA();
        var ListNhanVienChartThang = dashBoardDA.GetNhanVienXuatSacChart(ListKhuVucNVXS, 2, Month, Year);
        LoadChart loadChart = new LoadChart();
        loadChart.series = JsonConvert.SerializeObject(ListNhanVienChartThang.Select(p => p.Count).ToList());

        if (CheckKhuVuc == 0)
        {
            loadChart.label = JsonConvert.SerializeObject(ListNhanVienChartThang.Select(p => p.TenPhongBan).ToList());
            loadChart.LstDonViID = JsonConvert.SerializeObject(ListNhanVienChartThang.Select(p => p.PhongBanID).ToList());
        }
        else
        {
            loadChart.label = JsonConvert.SerializeObject(ListNhanVienChartThang.Select(p => p.TenDonVi).ToList());
            loadChart.LstDonViID = JsonConvert.SerializeObject(ListNhanVienChartThang.Select(p => p.DonViID).ToList());

        }
        return JsonConvert.SerializeObject(loadChart);
    }

    [WebMethod]
    public static string NextPreQuater(int CheckKhuVuc, List<int> ListKhuVucNVXS, int Quy, int Year)
    {
        DashBoardDA dashBoardDA = new DashBoardDA();
        var ListNhanVienChartThang = dashBoardDA.GetNhanVienXuatSacChart(ListKhuVucNVXS, 1, 0, Year, Quy);
        LoadChart loadChart = new LoadChart();
        loadChart.series = JsonConvert.SerializeObject(ListNhanVienChartThang.Select(p => p.Count).ToList());
        if (CheckKhuVuc == 0)
        {
            loadChart.label = JsonConvert.SerializeObject(ListNhanVienChartThang.Select(p => p.TenPhongBan).ToList());
            loadChart.LstDonViID = JsonConvert.SerializeObject(ListNhanVienChartThang.Select(p => p.PhongBanID).ToList());
        }
        else
        {
            loadChart.label = JsonConvert.SerializeObject(ListNhanVienChartThang.Select(p => p.TenDonVi).ToList());
            loadChart.LstDonViID = JsonConvert.SerializeObject(ListNhanVienChartThang.Select(p => p.DonViID).ToList());

        }

        return JsonConvert.SerializeObject(loadChart);
    }

    public class LoadChart
    {
        public string series { get; set; }
        public string label { get; set; }
        public string LstDonViID { get; set; }
    }
}
}