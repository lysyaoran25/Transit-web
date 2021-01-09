using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Viags.Data;
using Viags.Simple;
namespace Viags.WebApp.Common
{
    public partial class pNav : Base.BaseWebPage
    {
        //public int countLtsThongBaoChung;
        //public int countLtsThongBaoChungVanBan;
        //public int countLtsThongBaoChungCongViec;
        //public int countLtsThongBaoChungLuuTru;

        //public List<Simple.NotificationItem> LstThongBao { get; set; }
        //public List<Simple.NotificationItem> LtsThongBaoChung { get; set; }

        //public List<Simple.NotificationItem> LtsThongBaoChungCongViec { get; set; }
        //public List<Simple.NotificationItem> LtsThongBaoChungVanBan { get; set; }
        //public List<Simple.NotificationItem> LtsThongBaoChungLuuTru { get; set; }
        /// <summary>
        /// Ham khoi tao
        /// </summary>
        public pNav()
        {
            //LstThongBao = new List<NotificationItem>();
            //LtsThongBaoChung = new List<NotificationItem>();
            //LtsThongBaoChungLuuTru = new List<NotificationItem>();
            //LtsThongBaoChungVanBan = new List<NotificationItem>();
            //LtsThongBaoChungCongViec = new List<NotificationItem>();
        }
        /// <summary>
        /// Ham page load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            //NotificationDA thongbaoDA = new NotificationDA();
            //// Lấy toàn bộ thông báo của người dùng
            //LstThongBao = thongbaoDA.GetListThongBaoTheoNguoiDungHomePage(CurrentUser.ID, CurrentUser.LtsThuKyCuaLanhDaoID);
            //// Lấy thông báo về lịch làm việc

            //countLtsThongBaoChungVanBan = LstThongBao.Where(x => x.TrangThaiID == false && x.NguoiNhanID == CurrentUser.ID && (x.KieuID == (int)Viags.Utils.Enum.ThongBao.VanBanDen || x.KieuID == (int)Viags.Utils.Enum.ThongBao.VanBanDi || x.KieuID == (int)Viags.Utils.Enum.ThongBao.DuThao || x.KieuID == (int)Viags.Utils.Enum.ThongBao.YKienVanBanDen || x.KieuID == (int)Viags.Utils.Enum.ThongBao.ThongBaoTinTuc || x.KieuID == (int)Viags.Utils.Enum.ThongBao.TinTucSuKien || x.KieuID == (int)Viags.Utils.Enum.ThongBao.DatCom)).Skip(0).ToList().Count;
            //LtsThongBaoChungVanBan = LstThongBao.Where(x => x.TrangThaiID == false && x.NguoiNhanID == CurrentUser.ID && (x.KieuID == (int)Viags.Utils.Enum.ThongBao.VanBanDen || x.KieuID == (int)Viags.Utils.Enum.ThongBao.VanBanDi || x.KieuID == (int)Viags.Utils.Enum.ThongBao.DuThao || x.KieuID == (int)Viags.Utils.Enum.ThongBao.YKienVanBanDen || x.KieuID == (int)Viags.Utils.Enum.ThongBao.ThongBaoTinTuc || x.KieuID == (int)Viags.Utils.Enum.ThongBao.TinTucSuKien || x.KieuID == (int)Viags.Utils.Enum.ThongBao.DatCom)).Skip(0).Take(20).ToList();

            //countLtsThongBaoChungCongViec = LstThongBao.Where(x => x.TrangThaiID == false && x.NguoiNhanID == CurrentUser.ID && (x.KieuID == (int)Viags.Utils.Enum.ThongBao.CongViec || x.KieuID == (int)Viags.Utils.Enum.ThongBao.UyQuyen || x.KieuID == (int)Utils.Enum.ThongBao.BaoCaoCongViec || x.KieuID == (int)Viags.Utils.Enum.ThongBao.BanGiaoCongViec)).Skip(0).ToList().Count;
            //LtsThongBaoChungCongViec = LstThongBao.Where(x => x.TrangThaiID == false && x.NguoiNhanID == CurrentUser.ID && (x.KieuID == (int)Viags.Utils.Enum.ThongBao.CongViec || x.KieuID == (int)Viags.Utils.Enum.ThongBao.UyQuyen || x.KieuID == (int)Utils.Enum.ThongBao.BaoCaoCongViec || x.KieuID == (int)Viags.Utils.Enum.ThongBao.BanGiaoCongViec)).Skip(0).Take(20).ToList();

            //countLtsThongBaoChung = LstThongBao.Where(x => x.TrangThaiID == false && x.NguoiNhanID == CurrentUser.ID && (x.KieuID == (int)Viags.Utils.Enum.ThongBao.DatPhong || x.KieuID == (int)Viags.Utils.Enum.ThongBao.DatXe || x.KieuID == (int)Viags.Utils.Enum.ThongBao.LichLamViec || x.KieuID == (int)Viags.Utils.Enum.ThongBao.ThongBaoChung || x.KieuID == (int)Viags.Utils.Enum.ThongBao.VanPhongPham || x.KieuID == (int)Viags.Utils.Enum.ThongBao.NghiPhep || x.KieuID == (int)Viags.Utils.Enum.ThongBao.LichDatPhong || x.KieuID == (int)Viags.Utils.Enum.ThongBao.TrungTamGiaiDap || x.KieuID == (int)Utils.Enum.ThongBao.YeuCauTuyenDung)).Skip(0).ToList().Count;
            //LtsThongBaoChung = LstThongBao.Where(x => x.TrangThaiID == false && x.NguoiNhanID == CurrentUser.ID && (x.KieuID == (int)Viags.Utils.Enum.ThongBao.DatPhong || x.KieuID == (int)Viags.Utils.Enum.ThongBao.DatXe || x.KieuID == (int)Viags.Utils.Enum.ThongBao.LichLamViec || x.KieuID == (int)Viags.Utils.Enum.ThongBao.ThongBaoChung || x.KieuID == (int)Viags.Utils.Enum.ThongBao.VanPhongPham || x.KieuID == (int)Viags.Utils.Enum.ThongBao.NghiPhep || x.KieuID == (int)Viags.Utils.Enum.ThongBao.LichDatPhong || x.KieuID == (int)Viags.Utils.Enum.ThongBao.TrungTamGiaiDap || x.KieuID == (int)Utils.Enum.ThongBao.YeuCauTuyenDung)).Skip(0).Take(20).ToList();

            //countLtsThongBaoChungLuuTru = LstThongBao.Where(x => x.NguoiNhanID == CurrentUser.ID && (x.KieuID == (int)Viags.Utils.Enum.ThongBao.LuuTru)).Skip(0).ToList().Count;
            //LtsThongBaoChungLuuTru = LstThongBao.Where(x => x.NguoiNhanID == CurrentUser.ID && (x.KieuID == (int)Viags.Utils.Enum.ThongBao.LuuTru)).Skip(0).Take(25).ToList();
        }
    }
}