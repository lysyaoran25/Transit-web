using Viags.Data;
using Viags.Simple;
using Viags.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Viags.WebApp.Home
{
    public partial class pListHome : Base.BaseWebPage
    {
        HomeDA HomeDA;
        public int CountVBDen { get; set; }
        public int CountCongViec { get; set; }
        public int CountCongViecSapHetHan { get; set; }
        public int CountVanBanSapHetHan { get; set; }
        public List<ThongBaoItem> LtsThongBao { get; set; }
        public List<BieuMauItem> LtsBieuMau { get; set; }
        public List<VanBanDenItem> LtsVanBanDen { get; set; }
        public List<CongViecItem> LtsCongViec { get; set; }
        public List<CongViecItem> LtsCongViecSapHetHan { get; set; }
        public List<VanBanDenItem> LtsVanBanDenSapHetHan { get; set; }
        public List<UyQuyenItem> LtsUyQuyen { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public pListHome()
        {
            LtsCongViec = new List<CongViecItem>();
            LtsVanBanDen = new List<VanBanDenItem>();
            LtsBieuMau = new List<BieuMauItem>();
            LtsThongBao = new List<ThongBaoItem>();
            LtsUyQuyen = new List<UyQuyenItem>();
            LtsVanBanDenSapHetHan = new List<VanBanDenItem>();
            LtsCongViecSapHetHan = new List<CongViecItem>();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            bool flag = CheckQuyen(CurrentUser.QuyenHan, (int)Utils.Enum.QuyenHan.Xemtatcavanbanden);
            HomeDA = new HomeDA();
            LtsVanBanDen = HomeDA.GetListVanBanDenChuaXuLyHomePage_27092016(flag, CurrentUser.LtsUyQuyenBoiID, (int)Utils.Enum.ConfigSoBanGhi.HomePage);

            CountVBDen = HomeDA.TotalRecord;
           
            LtsCongViec = HomeDA.GetListHSCVInHome((int)Utils.Enum.ConfigSoBanGhi.HomePage, CurrentUser.ID);
            CountCongViec = HomeDA.TotalRecord;
        
            var today = DateTime.Now;
            int CurrentWeek = DateTimeUtils.GetCurrentWeek();
            StartDate = DateTimeUtils.GetFirstDateOfWeek(today.Year, CurrentWeek - 1);
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
            
        }
    }
}