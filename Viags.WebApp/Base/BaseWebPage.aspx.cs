using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Viags.Simple;
using Viags.Utils;
using WebFormsUtilities;
using Viags.Data;
using System.Text;

namespace Viags.WebApp.Base
{
    /// <summary>
    /// Class base của tất cả các page.
    /// Tất cả các page trên project bắt buộc phải thừa kế từ class này.
    /// Tất cả các class, các function và các biến quan trọng phải được comment cụ thể theo mẫu này.
    /// </summary>
    /// <modified>
    /// Author				    created date					comments
    /// QuangNĐ					04/07/2013				        Tạo mới
    ///</modified>
    public partial class BaseWebPage : System.Web.UI.Page
    {
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

        public NguoiDungSession CurrentUser { get; set; }
        public string sUser
        {
            get { return ConfigurationSettings.AppSettings["ADUser"]; }
        }

        public string sPass
        {
            get { return ConfigurationSettings.AppSettings["ADPassword"]; }
        }

        public string sPath
        {
            get { return ConfigurationSettings.AppSettings["ADPathLDAP"]; }
        }
        public string week { get; set; }

        public string sServerType
        {
            get { return ConfigurationSettings.AppSettings["ADPath"]; }
        }
        public int Show { get; set; }
        /// <summary>
        /// Tên của action
        /// </summary>
        public string ActionText { get; set; }
        DateTimeFormatInfo dtfiParser;
        public Utils.ChucNang ChucNangType { get; set; }
        /// <summary>
        /// SoCongVanID
        /// </summary>
        public int SoCongVanID { get; set; }

        /// <summary>
        /// VanBanDenID
        /// </summary>
        public int VanBanDenID { get; set; }
        public int PhongLuuTruID { get; set; }
        public int DonViNopLuuID { get; set; }

        public int GiaLuuTruID { get; set; }
        /// <summary>
        /// SoCongVanID
        /// </summary>
        public int ChucNangID { get; set; }
        public string LinkBack { get; set; }
        /// <summary>
        /// Kiểu action
        /// </summary>
        public Utils.TypeOfAction ActionType { get; set; }

        /// <summary>
        /// Phân trang dữ liệu
        /// </summary>
        public string HtmlPager { get; set; }
        public string HtmlPagerDetail { get; set; }
        /// <summary>
        /// Trường search
        /// </summary>
        public List<string> SearchInFiled { get; set; }
        /// <summary>
        /// Trường search
        /// </summary>
        public List<string> SearchInAll { get; set; }
        public string Container { get; set; }
        /// <summary>
        /// Danh sách ID
        /// </summary>
        public List<int> ltsID = new List<int>();
        /// <summary>
        /// Số bản ghi trên trang
        /// </summary>
        public int RowPerPage { get; set; }
        /// <summary>
        /// Số trang hiển thị
        /// </summary>
        public int PageStep { get; set; }
        /// <summary>
        /// Trang hiện tại
        /// </summary>
        public int CurrentPage { get; set; }
        /// <summary>
        /// Cột sắp xếp
        /// </summary>
        public string Field { get; set; }
        /// <summary>
        /// Cột sắp xếp danh mục
        /// </summary>
        public string FieldDanhMuc { get; set; }
        /// <summary>
        /// File ID
        /// </summary>
        public int FileID { get; set; }
        /// <summary>
        /// Trạng thái sắp xếp
        /// </summary>
        public bool FieldOption { get; set; }
        /// <summary>
        /// Action của form
        /// </summary>
        public string DoAction { set; get; }
        /// <summary>
        /// ID của đối tượng
        /// </summary>
        public int ItemID { get; set; }
        /// ID của đơn vị
        /// </summary>
        public int DonViID { get; set; }

        /// <summary>
        /// Tên đơn vị
        /// </summary>
        public string TenDonVi { get; set; }
        /// <summary>
        /// Hồ sơ công việc ID
        /// </summary>
        public int HoSoCongViecID { get; set; }
        public int TruyenKhoID { get; set; }

        /// <summary>
        /// Từ khóa tìm kiếm
        /// </summary>
        public string Keyword { get; set; }
        /// <summary>
        /// Từ khóa tìm kiếm
        /// </summary>
        public string KeywordTK { get; set; }
        /// <summary>
        /// Kiểm tra xem row đã hight light chưa
        /// </summary>
        public string HightLight { get; set; }

        public string PhongBanPT { get; set; }
        public string NguoiPT { get; set; }
        public int IsDonVi { get; set; }
        public string LtsLoTrinhID { get; set; }
        /// <summary>
        /// string từ khóa tìm kiếm solr
        /// </summary>
        public string KeyWordSolr { get; set; }

        /// <summary>
        /// Danh sách phòng ban của người dùng
        /// </summary>
        public List<int> LtsPhongBan { get; set; }
        public int CongViecID { get; set; }
        public string IsNoiBo { get; set; }
        /// <summary>
        /// Set text trường hợp là đơn vị và phòng ban trong phân hệ lưu trữ
        /// </summary>
        public bool IsDonViText { get; set; }
        public List<int> LtsID { get; set; }
        /// <summary>
        /// Tên hiển thị
        /// </summary>
        public string TenHienThi { get; set; }
        /// <summary>
        /// Hàm load và check quyền của người dùng
        /// </summary>
        /// <modified>
        /// Author				    created date					comments
        /// QuangNĐ					04/07/2013				        Tạo mới
        /// QuangNĐ                 06/07/2013                      Cập nhật code check quyền trên từng trang
        ///</modified>
        private void Load_Permission()
        {
            //Load quyền.

        }
        /// <summary>
        /// thư tự trên gridview
        /// </summary>
        public int Index { get; set; }
        /// <summary>
        /// Convert xâu có dạng "1,2,3,4" sang list int
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        /// <modified>
        /// Author				    created date					comments
        /// QuangNĐ					05/07/2013				        Tạo mới
        ///</modified>
        public List<int> String2Array(string source)
        {
            var LtsValue = new List<int>();
            if (string.IsNullOrEmpty(source)) return LtsValue;
            if (source.EndsWith(","))
                source = source.Substring(0, source.LastIndexOf(","));
            if (source.Contains(','))
            {
                LtsValue = source.Split(',').Select(o => Convert.ToInt32(o)).ToList();
            }
            else
                LtsValue.Add(Convert.ToInt32(source));
            return LtsValue;
        }
        

        /// <summary>
        /// Lấy về chuỗi người dùng từ mảng người dùng, phòng ban
        /// </summary>
        /// <param name="LtsNguoiDung">List object</param>
        /// <returns></returns>
        public static string GetValuesFormArray(List<Simple.BaseSimple> LtsObject)
        {
            string strObject = LtsObject.Aggregate(string.Empty, (current, simple) => current + (simple.Ten + ","));
            if (string.IsNullOrEmpty(strObject)) return strObject;
            if (strObject.LastIndexOf(",") > 0)
                strObject = strObject.Substring(0, strObject.LastIndexOf(","));
            return strObject;
        }

        /// <summary>
        /// Hàm khởi tạo tránh null
        /// </summary>
        /// <modified>
        /// Author				    created date					comments
        /// QuanLH					18/07/2013				        Tạo mới
        ///</modified>
        public BaseWebPage()
        {
            LtsPhongBan = new List<int>();

            dtfiParser = new DateTimeFormatInfo();
            dtfiParser.ShortDatePattern = "dd/MM/yyyy hh:mm";
            dtfiParser.DateSeparator = "/";

            DoAction = !string.IsNullOrEmpty(HttpContext.Current.Request["do"]) ? HttpContext.Current.Request["do"].Trim() : "add";
         
            #region load action text và action Type
            
            #endregion
            if (!string.IsNullOrEmpty(HttpContext.Current.Request["Keyword"]))
            {
                Keyword = HttpContext.Current.Request["Keyword"].Trim();
                Keyword = Regex.Replace(Keyword, @"\s+", " ");
            }

            if (!string.IsNullOrEmpty(HttpContext.Current.Request["SearchIn"]))
            {
                if (HttpContext.Current.Request["SearchIn"].Contains(","))
                    SearchInFiled = HttpContext.Current.Request["SearchIn"].Split(',').ToList();
                else
                {
                    SearchInFiled = new List<string>();
                    SearchInFiled.Add(HttpContext.Current.Request["SearchIn"].ToString());
                }
            }
            else
                SearchInFiled = new List<string>();
            if (!string.IsNullOrEmpty(HttpContext.Current.Request["SearchInAll"]))
            {
                if (HttpContext.Current.Request["SearchInAll"].Contains(","))
                    SearchInAll = HttpContext.Current.Request["SearchInAll"].Split(',').ToList();
                else
                {
                    SearchInAll = new List<string>();
                    SearchInAll.Add(HttpContext.Current.Request["SearchInAll"].ToString());
                }
            }
            else
                SearchInAll = new List<string>();
            var xxx  = HttpContext.Current.Request["RowPerPage"];
            RowPerPage = !string.IsNullOrEmpty(HttpContext.Current.Request["RowPerPage"]) ? Convert.ToInt32(HttpContext.Current.Request["RowPerPage"]) : 10;
            RowPerPage = RowPerPage > 100 ? 100 : RowPerPage;
            IsNoiBo = !string.IsNullOrEmpty(HttpContext.Current.Request["IsNoiBo"]) ? HttpContext.Current.Request["IsNoiBo"] : "0";
            IsDonVi = !string.IsNullOrEmpty(HttpContext.Current.Request["IsDonVi"]) ? Convert.ToInt32(HttpContext.Current.Request["IsDonVi"]) : 0;
            if (!string.IsNullOrEmpty(HttpContext.Current.Request["ItemId"]) && !HttpContext.Current.Request["ItemId"].Equals(DataHelper.NullString, StringComparison.OrdinalIgnoreCase))
                ItemID = Convert.ToInt32(HttpContext.Current.Request["ItemId"]);
            else
                ItemID = 0;

            if (!string.IsNullOrEmpty(HttpContext.Current.Request["SoVanBanID"]) && !HttpContext.Current.Request["SoVanBanID"].Equals(DataHelper.NullString, StringComparison.OrdinalIgnoreCase))
                SoCongVanID = Convert.ToInt32(HttpContext.Current.Request["SoVanBanID"]);
            else
                SoCongVanID = 0;
            if (!string.IsNullOrEmpty(HttpContext.Current.Request["ChucNangID"]) && !HttpContext.Current.Request["ChucNangID"].Equals(DataHelper.NullString, StringComparison.OrdinalIgnoreCase))
                ChucNangID = Convert.ToInt32(HttpContext.Current.Request["ChucNangID"]);
            else
                ChucNangID = 0;
            if (!string.IsNullOrEmpty(HttpContext.Current.Request["DonViID"]) && !HttpContext.Current.Request["DonViID"].Equals(DataHelper.NullString, StringComparison.OrdinalIgnoreCase))
                DonViID = Convert.ToInt32(HttpContext.Current.Request["DonViID"]);
            else
                DonViID = 0;

            if (!string.IsNullOrEmpty(HttpContext.Current.Request["HoSoCongViecID"]) && !HttpContext.Current.Request["HoSoCongViecID"].Equals(DataHelper.NullString, StringComparison.OrdinalIgnoreCase))
                HoSoCongViecID = Convert.ToInt32(HttpContext.Current.Request["HoSoCongViecID"]);
            else
            {
                HoSoCongViecID = 0;
            }
            if (!string.IsNullOrEmpty(HttpContext.Current.Request["TruyenKhoID"]) && !HttpContext.Current.Request["TruyenKhoID"].Equals(DataHelper.NullString, StringComparison.OrdinalIgnoreCase))
                TruyenKhoID = Convert.ToInt32(HttpContext.Current.Request["TruyenKhoID"]);
            else
            {
                TruyenKhoID = 0;
            }
            if (!string.IsNullOrEmpty(HttpContext.Current.Request["PageStep"]) && !HttpContext.Current.Request["PageStep"].Equals(DataHelper.NullString, StringComparison.OrdinalIgnoreCase))
                PageStep = Convert.ToInt32(HttpContext.Current.Request["PageStep"]);
            else
                PageStep = 3;

            if (!string.IsNullOrEmpty(HttpContext.Current.Request["Page"]) && !HttpContext.Current.Request["Page"].Equals(DataHelper.NullString, StringComparison.OrdinalIgnoreCase))
                CurrentPage = Convert.ToInt32(HttpContext.Current.Request["Page"]);
            else
                CurrentPage = 1;

            TenHienThi = !string.IsNullOrEmpty(HttpContext.Current.Request["TenHienThi"]) ? HttpContext.Current.Request["TenHienThi"] : string.Empty;
            week = !string.IsNullOrEmpty(HttpContext.Current.Request["week"]) ? HttpContext.Current.Request["week"] : string.Empty;

            Field = !string.IsNullOrEmpty(HttpContext.Current.Request["Field"]) ? HttpContext.Current.Request["Field"] : "ID";
            var test = HttpContext.Current.Request["Field"];
            FieldDanhMuc =!string.IsNullOrEmpty(HttpContext.Current.Request["Field"]) ? HttpContext.Current.Request[""] : "ID";

            if (!string.IsNullOrEmpty(HttpContext.Current.Request["FieldOption"]))
                FieldOption = (Convert.ToInt32(HttpContext.Current.Request["FieldOption"]) != 1);
            else
                FieldOption = true;
            Container = !string.IsNullOrEmpty(HttpContext.Current.Request["Container"]) ? HttpContext.Current.Request["Container"] : "VanBanTraLoi";
            LinkBack = !string.IsNullOrEmpty(HttpContext.Current.Request["LinkBack"]) ? HttpContext.Current.Request["LinkBack"] : "#&temp=5";
            VanBanDenID = !string.IsNullOrEmpty(HttpContext.Current.Request["VanBanDenID"]) ? Convert.ToInt32(HttpContext.Current.Request["VanBanDenID"]) : 0;
            PhongLuuTruID = !string.IsNullOrEmpty(HttpContext.Current.Request["PhongLuuTruID"]) ? Convert.ToInt32(HttpContext.Current.Request["PhongLuuTruID"]) : 0;
            DonViNopLuuID = !string.IsNullOrEmpty(HttpContext.Current.Request["DonViNopLuuID"]) ? Convert.ToInt32(HttpContext.Current.Request["DonViNopLuuID"]) : 0;
            GiaLuuTruID = !string.IsNullOrEmpty(HttpContext.Current.Request["GiaLuuTruID"]) ? Convert.ToInt32(HttpContext.Current.Request["GiaLuuTruID"]) : 0;
            PhongBanPT = !string.IsNullOrEmpty(HttpContext.Current.Request["PhongBanPT"]) ? HttpContext.Current.Request["PhongBanPT"] : string.Empty;
            LtsLoTrinhID = !string.IsNullOrEmpty(HttpContext.Current.Request["LtsLoTrinhID"]) ? HttpContext.Current.Request["LtsLoTrinhID"] : string.Empty;
            NguoiPT = !string.IsNullOrEmpty(HttpContext.Current.Request["nguoiPT"]) ? HttpContext.Current.Request["nguoiPT"] : string.Empty;

            //Hiển thị thứ tự trên gird view
            Index = ((CurrentPage - 1) * RowPerPage) + 1;

        }
        /// <summary>
        /// Get session cua nguoi dung
        /// </summary>
        /// <param name="e"></param>
        protected override void OnInit(EventArgs e)
        {

            if (Session["VIAG2016"] != null)
            {
                CurrentUser = (NguoiDungSession)Session["VIAG2016"];
                #region Check thông tin IsDonViText
                if (CurrentUser.IsVanPhong)
                {
                    IsDonViText = true;
                }
                else
                {
                    IsDonViText = false;
                }
                #endregion
            }
            else
                Response.Redirect("/LoginNew.aspx");
            base.OnInit(e);
        }
        /// <summary>
        /// Kiểm tra xem người dùng có quyền 
        /// </summary>
        /// <param name="dsQuyen">danh sách quyền</param>
        /// <param name="idQuyen">id quyền</param>
        /// <returns>true or false</returns>
        public bool CheckQuyen(string dsQuyen, int idQuyen)
        {
            dsQuyen = "," + dsQuyen + ",";
            return dsQuyen.Contains("," + idQuyen + ",");
        }

        /// <summary>
        /// Tự động map tất cả thuộc tính của object thông qua các parrams post
        /// </summary>
        /// <param name="model">Obecj cần update</param>
        /// <modified>
        /// Author				    created date					comments
        /// QuangNĐ					05/07/2013				        Tạo mới
        ///</modified>
        public void UpdateModel<TModel>(TModel model)
        {
            WFPageUtilities.UpdateModel(HttpContext.Current.Request, model);
        }
        
        /// <summary>
        /// Chi tiết tháng
        /// </summary>
        /// <param name="strMonthID"></param>
        /// <returns></returns>
        public string GetChiTietMonth(string strMonthID)
        {
            string strResult = string.Empty;
            HttpCookie cookie = Request.Cookies["ngonngu"];
            if (cookie != null && cookie.Value != null)
            {
                if (cookie.Value.IndexOf("en-") >= 0)
                {
                    if (!strMonthID.Contains(","))
                        //strResult = " " + strMonthID;
                        switch (strMonthID)
                        {
                            case "1":
                                strResult = "January";
                                break;
                            case "2":
                                strResult = "February";
                                break;
                            case "3":
                                strResult = "March";
                                break;
                            case "4":
                                strResult = "April";
                                break;
                            case "5":
                                strResult = "May";
                                break;
                            case "6":
                                strResult = "June";
                                break;
                            case "7":
                                strResult = "July";
                                break;
                            case "8":
                                strResult = "August";
                                break;
                            case "9":
                                strResult = "September";
                                break;
                            case "10":
                                strResult = "October";
                                break;
                            case "11":
                                strResult = "November";
                                break;
                            case "12":
                                strResult = "December";
                                break;
                            default:
                                strResult = "Not result";
                                break;
                        }
                    switch (strMonthID)
                    {
                        case "1":
                            strMonthID = "January";
                            break;
                        case "2":
                            strMonthID = "February";
                            break;
                        case "3":
                            strMonthID = "March";
                            break;
                        case "4":
                            strMonthID = "April";
                            break;
                        case "5":
                            strMonthID = "May";
                            break;
                        case "6":
                            strMonthID = "June";
                            break;
                        case "7":
                            strMonthID = "July";
                            break;
                        case "8":
                            strMonthID = "August";
                            break;
                        case "9":
                            strMonthID = "September";
                            break;
                        case "10":
                            strMonthID = "October";
                            break;
                        case "11":
                            strMonthID = "November";
                            break;
                        case "12":
                            strMonthID = "December";
                            break;
                        default:
                            strMonthID = "Not result";
                            break;
                    }
                    //strMonthID = Resources.Action.lblThang + " " + strMonthID;
                    //strMonthID = Resources.Action.lblThang + " " + strMonthID;
                }
                else
                {
                    if (cookie.Value.IndexOf("vi-") >= 0)
                    {
                        if (!strMonthID.Contains(","))
                            strResult = "Tháng " + strMonthID;
                        strMonthID = "Tháng " + strMonthID;
                        //strMonthID = "Tháng " + strMonthID;
                    }
                    else
                    {
                        if (!strMonthID.Contains(","))
                            strResult = "Tháng " + strMonthID;
                        strMonthID = "Tháng " + strMonthID;
                        //strMonthID = Resources.Action.lblThang + " " + strMonthID;
                    }
                }
            }
            
            return strResult;
        }
        /// <summary>
        /// Chi tiết tháng
        /// </summary>
        /// <param name="strMonthID"></param>
        /// <returns></returns>
        public string GetChiTietQuy(string strQuyID)
        {
            string strResult = string.Empty;
            HttpCookie cookie = Request.Cookies["ngonngu"];
            if (cookie != null && cookie.Value != null)
            {
                if (cookie.Value.IndexOf("en-") >= 0)
                {
                    if (!strQuyID.Contains(","))
                        //strResult = "Quý " + strQuyID;
                        switch (strQuyID)
                        {
                            case "1":
                                strResult = "The First Quarter";
                                break;
                            case "2":
                                strResult = "The Second Quarter";
                                break;
                            case "3":
                                strResult = "The Third Quarter";
                                break;
                            case "4":
                                strResult = "The Fourth Quarter";
                                break;
                            default:
                                strResult = "Not result";
                                break;
                        }
                    //strQuyID = "Quý " + strQuyID;
                    switch (strQuyID)
                    {
                        case "1":
                            strQuyID = "The First Quarter";
                            break;
                        case "2":
                            strQuyID = "The Second Quarter";
                            break;
                        case "3":
                            strQuyID = "The Third Quarter";
                            break;
                        case "4":
                            strQuyID = "The Fourth Quarter";
                            break;
                        default:
                            strQuyID = "Not result";
                            break;
                    }
                    strResult = strQuyID.Replace(",", ", Quarter ");
                    strResult = strResult.Replace("Quý 1", "The First Quarter").Replace("Quý 2", "The Second Quarter").Replace("Quý 3", "The Third Quarter").Replace("Quý 4", "The Fourth Quarter");                    
                }
                else
                {
                    if (cookie.Value.IndexOf("vi-") >= 0)
                    {
                        if (!strQuyID.Contains(","))
                            strResult = "Quý " + strQuyID;
                        strQuyID = "Quý " + strQuyID;
                        strResult = strQuyID.Replace(",", ", Quý ");
                        strResult = strResult.Replace("Quý 1", "Quý I").Replace("Quý 2", "Quý II").Replace("Quý 3", "Quý III").Replace("Quý 4", "Quý IV");
                    }
                    else
                    {
                        if (!strQuyID.Contains(","))
                            strResult = "Quý " + strQuyID;
                        strQuyID = "Quý " + strQuyID;
                        strResult = strQuyID.Replace(",", ", Quý ");
                        strResult = strResult.Replace("Quý 1", "Quý I").Replace("Quý 2", "Quý II").Replace("Quý 3", "Quý III").Replace("Quý 4", "Quý IV");
                    }
                }
            }
            
            return strResult;
        }
        public string EncryptURL(string input)
        {
            var _return = "";
            foreach (char c in input.ToLower())
            {
                switch (c.ToString())
                {
                    case "1": _return += "n"; break;
                    case "2": _return += "m"; break;
                    case "3": _return += "/"; break;
                    case "4": _return += "."; break;
                    case "5": _return += "1"; break;
                    case "6": _return += "2"; break;
                    case "7": _return += "3"; break;
                    case "8": _return += "4"; break;
                    case "9": _return += "5"; break;
                    case "0": _return += "6"; break;
                    case "q": _return += "7"; break;
                    case "w": _return += "8"; break;
                    case "e": _return += "9"; break;
                    case "r": _return += "0"; break;
                    case "t": _return += "q"; break;
                    case "y": _return += "w"; break;
                    case "u": _return += "e"; break;
                    case "i": _return += "r"; break;
                    case "o": _return += "t"; break;
                    case "p": _return += "y"; break;
                    case "a": _return += "u"; break;
                    case "s": _return += "i"; break;
                    case "d": _return += "o"; break;
                    case "f": _return += "p"; break;
                    case "g": _return += "a"; break;
                    case "h": _return += "s"; break;
                    case "j": _return += "d"; break;
                    case "k": _return += "f"; break;
                    case "l": _return += "g"; break;
                    case "z": _return += "h"; break;
                    case "x": _return += "j"; break;
                    case "c": _return += "k"; break;
                    case "v": _return += "l"; break;
                    case "b": _return += "z"; break;
                    case "n": _return += "x"; break;
                    case "m": _return += "c"; break;
                    case "/": _return += "v"; break;
                    case ".": _return += "b"; break;
                    case " ": _return += "$"; break;
                    default: _return += c.ToString(); break;
                }
            }
            return _return.Trim();
        }
        public string DecryptURL(string input)
        {
            var _return = "";
            foreach (char c in input.ToLower())
            {
                switch (c.ToString())
                {
                    case "n": _return += "1"; break;
                    case "m": _return += "2"; break;
                    case "/": _return += "3"; break;
                    case ".": _return += "4"; break;
                    case "1": _return += "5"; break;
                    case "2": _return += "6"; break;
                    case "3": _return += "7"; break;
                    case "4": _return += "8"; break;
                    case "5": _return += "9"; break;
                    case "6": _return += "0"; break;
                    case "7": _return += "q"; break;
                    case "8": _return += "w"; break;
                    case "9": _return += "e"; break;
                    case "0": _return += "r"; break;
                    case "q": _return += "t"; break;
                    case "w": _return += "y"; break;
                    case "e": _return += "u"; break;
                    case "r": _return += "i"; break;
                    case "t": _return += "o"; break;
                    case "y": _return += "p"; break;
                    case "u": _return += "a"; break;
                    case "i": _return += "s"; break;
                    case "o": _return += "d"; break;
                    case "p": _return += "f"; break;
                    case "a": _return += "g"; break;
                    case "s": _return += "h"; break;
                    case "d": _return += "j"; break;
                    case "f": _return += "k"; break;
                    case "g": _return += "l"; break;
                    case "h": _return += "z"; break;
                    case "j": _return += "x"; break;
                    case "k": _return += "c"; break;
                    case "l": _return += "v"; break;
                    case "z": _return += "b"; break;
                    case "x": _return += "n"; break;
                    case "c": _return += "m"; break;
                    case "v": _return += "/"; break;
                    case "b": _return += "."; break;
                    case "$": _return += " "; break;
                    default: _return += c.ToString(); break;
                }
            }
            return _return.Trim();
        }
    }
}