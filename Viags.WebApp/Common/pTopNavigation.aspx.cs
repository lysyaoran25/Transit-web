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
    public partial class pTopNavigation : Base.BaseWebPage
    {
        //public List<Simple.NotificationItem> LstThongBao { get; set; }
        //public List<Simple.NotificationItem> LtsThongBaoChung { get; set; }

        //public List<Simple.NotificationItem> LtsThongBaoChungCongViec { get; set; }
        //public List<Simple.NotificationItem> LtsThongBaoChungVanBan { get; set; }
        //public List<Simple.NotificationItem> LtsThongBaoChungLuuTru { get; set; }
        /// <summary>
        /// Ham khoi tao
        /// </summary>
        public pTopNavigation()
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

            //LtsThongBaoChungVanBan = LstThongBao.Where(x => x.NguoiNhanID == CurrentUser.ID && ((x.KieuID == (int)Viags.Utils.Enum.ThongBao.VanBanDen || x.KieuID == (int)Viags.Utils.Enum.ThongBao.VanBanDi || x.KieuID == (int)Viags.Utils.Enum.ThongBao.DuThao || x.KieuID == (int)Viags.Utils.Enum.ThongBao.YKienVanBanDen|| x.KieuID == (int)Viags.Utils.Enum.ThongBao.ThuHoi))).ToList();

            //LtsThongBaoChungCongViec = LstThongBao.Where(x => x.NguoiNhanID == CurrentUser.ID && ((x.KieuID == (int)Viags.Utils.Enum.ThongBao.CongViec || x.KieuID == (int)Viags.Utils.Enum.ThongBao.UyQuyen || x.KieuID == (int)Utils.Enum.ThongBao.BaoCaoCongViec  || x.KieuID == (int)Viags.Utils.Enum.ThongBao.BanGiaoCongViec))).ToList();

            //LtsThongBaoChung = LstThongBao.Where(x => x.NguoiNhanID == CurrentUser.ID && ((x.KieuID == (int)Viags.Utils.Enum.ThongBao.DatPhong || x.KieuID == (int)Viags.Utils.Enum.ThongBao.DatXe || x.KieuID == (int)Viags.Utils.Enum.ThongBao.LichLamViec || x.KieuID == (int)Viags.Utils.Enum.ThongBao.ThongBaoChung || x.KieuID == (int)Viags.Utils.Enum.ThongBao.LichDatPhong || x.KieuID== (int)Viags.Utils.Enum.ThongBao.YeuCauTuyenDung))).ToList();

            //LtsThongBaoChungLuuTru = LstThongBao.Where(x => x.NguoiNhanID == CurrentUser.ID && (x.KieuID == (int)Viags.Utils.Enum.ThongBao.LuuTru)).ToList();
        }
    }
}