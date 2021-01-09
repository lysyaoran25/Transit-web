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
namespace Viags.WebApp.Home
{
    public partial class ucHome : Base.BaseUserControl
    {
        HomeDA HomeDA;
        public int CountVBDi { get; set; }

        public int CountKienNghi { get; set; }
        public int CountCongViecSapHetHan { get; set; }
        public int CountVanBanSapHetHan { get; set; }
        public List<ThongBaoItem> LtsThongBao { get; set; }
        public List<BieuMauItem> LtsBieuMau { get; set; }
        public List<CongViecItem> LtsCongViecSapHetHan { get; set; }
        public List<VanBanDenItem> LtsVanBanDenSapHetHan { get; set; }
        public List<UyQuyenItem> LtsUyQuyen { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool CheckNguoiNhanVanBan { get; set; }
        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        public ucHome()
        {
            
            LtsBieuMau = new List<BieuMauItem>();
            LtsThongBao = new List<ThongBaoItem>();
            LtsUyQuyen = new List<UyQuyenItem>();
          
            LtsVanBanDenSapHetHan = new List<VanBanDenItem>();
            LtsCongViecSapHetHan = new List<CongViecItem>();
            CheckNguoiNhanVanBan = true;
        }
        /// <summary>
        /// Hàm page load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
    


            if (!string.IsNullOrEmpty(HttpContext.Current.Request["CurrentDonViID"]))
            {
                NguoiDungDA NguoiDungDA = new NguoiDungDA();
                NguoiDungSession nguoiDungSession;
                nguoiDungSession = NguoiDungDA.GetThongTinDangNhapCuaNguoiDung(CurrentUser.TenTruyCap, Convert.ToInt32(HttpContext.Current.Request["CurrentDonViID"]));

                Session["VIAG2016"] = nguoiDungSession;

                Page.Response.Redirect("/Pagess/Home.aspx", true);
            }

            bool flag = CheckQuyen(CurrentUser.QuyenHan, (int)Utils.Enum.QuyenHan.Xemtatcavanbanden);
            HomeDA = new HomeDA();
            LtsBieuMau = HomeDA.GetListBieuMau(CurrentUser.DonViID, (int)Viags.Utils.Enum.ConfigSoBanGhi.HomePage);
            LtsThongBao = HomeDA.GetListThongBao(CurrentUser.DonViID, (int)Viags.Utils.Enum.ConfigSoBanGhi.HomePage);
            var today = DateTime.Now;
            int CurrentWeek = DateTimeUtils.GetCurrentWeek();
            //Xét trạng thái cookie để hiện tuần chính xác
            HttpCookie cookie = Request.Cookies["ngonngu"];
            if (cookie != null && cookie.Value != null)
            {
                if (cookie.Value.IndexOf("en-") >= 0)
                {
                    StartDate = DateTimeUtils.GetFirstDateOfWeek(today.Year, CurrentWeek);
                }
                else
                {
                    if (cookie.Value.IndexOf("vi-") >= 0)
                    {
                        StartDate = DateTimeUtils.GetFirstDateOfWeek(today.Year, CurrentWeek - 1);
                    }
                }
            }
            
            EndDate = StartDate.AddDays(7).AddSeconds(-1);
            LtsUyQuyen = HomeDA.GetListUyQuyen();
            LtsCongViecSapHetHan = new List<CongViecItem>();
            // Công việc sắp hết hạn
            //LtsCongViecSapHetHan = HomeDA.GetListCongViecSapHetHan(CurrentUser.ID); 
            //foreach (var item in LtsCongViecSapHetHan)
            //{
            //    if (((item.HanXuLy.Value.Date - DateTime.Now.Date).Days <= 3 && item.NguoiLapID == CurrentUser.ID) // Trường hợp người lập
            //            || (item.HanXuLyNguoiDung.Value.Date - DateTime.Now.Date).Days <= 3) // TH hạn xử lý của thành phần tham gia
            //    {
            //        CountCongViecSapHetHan++;
            //    }
            //}
            // Văn bản sắp hết hạn
            // Thông tin người ủy quyền
            List<int> LtsUyQuyenBoiID = CurrentUser.LtsUyQuyenBoiID;
            // Thông tin về thư ký của Lãnh đạo
            List<int> LtsThuKyCuaLanhDaoID = CurrentUser.LtsThuKyCuaLanhDaoID;
            LtsVanBanDenSapHetHan = new List<VanBanDenItem>();
            //LtsVanBanDenSapHetHan = HomeDA.GetListVanBanDenSapHetHan(LtsUyQuyenBoiID, LtsThuKyCuaLanhDaoID);
            //foreach (var value in LtsVanBanDenSapHetHan)
            //{
            //    if ((value.HanXuLyCuoi.Value.Date - DateTime.Now.Date).Days <= 3)
            //    {
            //        CountVanBanSapHetHan++;
            //    }
            //}

                #region Check người nhận văn bản
                if (CurrentUser.ViTriID == (int)Viags.Utils.Enum.TypeOfRole.VanThuDonVi)
            {
                NguoiDungDA da = new NguoiDungDA();
                CheckNguoiNhanVanBan = da.CheckNguoiNhanVanBan(CurrentUser.DonViID);
            }
            #endregion
        }
    }
}