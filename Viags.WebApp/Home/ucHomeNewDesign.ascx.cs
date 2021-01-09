using Newtonsoft.Json;
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
    public partial class ucHomeNewDesign : Base.BaseUserControl
    {
        //public List<string> countImages = new List<string>();
        //HomeDA HomeDA;     

        //public int CountVBDi { get; set; }

        //public int CountKienNghi { get; set; }
        //public int CountCongViecSapHetHan { get; set; }
        //public int CountVanBanSapHetHan { get; set; }
        //public List<ThongBaoItem> LtsThongBao { get; set; }
        //public List<BieuMauItem> LtsBieuMau { get; set; }
        //public List<CongViecItem> LtsCongViecSapHetHan { get; set; }
        //public List<VanBanDenItem> LtsVanBanDenSapHetHan { get; set; }
        //public List<NguoiDungItem> listNVXuatSac { get; set; }
        //public List<int> listDonViNVXuatSac { get; set; }
        //public List<UyQuyenItem> LtsUyQuyen { get; set; }
        //public List<DonViItem> LtsKhuVuc { get; set; }
        //public DateTime StartDate { get; set; }
        //public DateTime EndDate { get; set; }
        //public bool CheckNguoiNhanVanBan { get; set; }
        //public List<ThongBaoTinTucItem> Lst { get; set; }
        //ThongBaoTinTucDA thongbaoDA;
        //CayPheDuyetDA cayPheDuyetDA;
        //public List<TinTucSuKienItem> LstTin { get; set; }
        //TinTucSuKienDA TinTucDA;
        //CayPheDuyetDA caypheduyetDa;
        //public NguoiDungDA nguoidungDA { get; set; }

        //List<NhanVienXuatSacChart> ListNhanVienChart;
        //List<NhanVienXuatSacChart> ListNhanVienChartThang;
        ////Nhân Viên Xuất Sắc - Cải Tiến
        //public DashBoardDA dashBoardDA;
        //public string Series;
        //public string Labels;
        //public string SeriesKhuVuc;
        //public string LabelsKhuVuc;
        //public string LstDonViID;
        //public string LstPhongBanID;

        //public string Series2;
        //public string Labels2;
        //public string SeriesKhuVuc2;
        //public string LabelsKhuVuc2;
        //public string LstDonViID2;
        //public string LstPhongBanID2;

        //public string LstKhuVucNVXS;
        //public List<int> ListKhuVucNVXS;

        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        public ucHomeNewDesign()
        {

            //LtsBieuMau = new List<BieuMauItem>();
            //LtsThongBao = new List<ThongBaoItem>();
            //LtsUyQuyen = new List<UyQuyenItem>();

            //LtsVanBanDenSapHetHan = new List<VanBanDenItem>();
            //LtsCongViecSapHetHan = new List<CongViecItem>();
            //CheckNguoiNhanVanBan = true;

            //Lst = new List<ThongBaoTinTucItem>();
            //thongbaoDA = new ThongBaoTinTucDA();
            //cayPheDuyetDA = new CayPheDuyetDA();

            //LstTin = new List<TinTucSuKienItem>();
            //TinTucDA = new TinTucSuKienDA();
            //listNVXuatSac = new List<NguoiDungItem>();
            //listDonViNVXuatSac = new List<int>();
            //nguoidungDA = new NguoiDungDA();
            //caypheduyetDa = new CayPheDuyetDA();
            //LtsKhuVuc = new List<DonViItem>();
            //#region[Nhân viên xuất sắc]
            //dashBoardDA = new DashBoardDA();
            //ListNhanVienChart = new List<NhanVienXuatSacChart>();
            //ListNhanVienChartThang = new List<NhanVienXuatSacChart>();
            //ListKhuVucNVXS = new List<int>();
            //#endregion

            //ListKhuVucNVXS = new List<int>();
        }
        /// <summary>
        /// Hàm page load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
        //    if (!string.IsNullOrEmpty(HttpContext.Current.Request["CurrentDonViID"]))
        //    {
        //        NguoiDungDA NguoiDungDA = new NguoiDungDA();
        //        NguoiDungSession nguoiDungSession;
        //        nguoiDungSession = NguoiDungDA.GetThongTinDangNhapCuaNguoiDung(CurrentUser.TenTruyCap, Convert.ToInt32(HttpContext.Current.Request["CurrentDonViID"]));

        //        Session["VIAG2016"] = nguoiDungSession;

        //        Page.Response.Redirect("/Pagess/Home.aspx", true);
        //    }

        //    bool flag = CheckQuyen(CurrentUser.QuyenHan, (int)Utils.Enum.QuyenHan.Xemtatcavanbanden);
        //    HomeDA = new HomeDA();
        //    LtsBieuMau = HomeDA.GetListBieuMau(CurrentUser.DonViID, (int)Viags.Utils.Enum.ConfigSoBanGhi.HomePage);
        //    LtsThongBao = HomeDA.GetListThongBao(CurrentUser.DonViID, (int)Viags.Utils.Enum.ConfigSoBanGhi.HomePage);
        //    var today = DateTime.Now;
        //    int CurrentWeek = DateTimeUtils.GetCurrentWeek();
        //    //Xét trạng thái cookie để hiện tuần chính xác
        //    HttpCookie cookie = Request.Cookies["ngonngu"];
        //    if (cookie != null && cookie.Value != null)
        //    {
        //        if (cookie.Value.IndexOf("en-") >= 0)
        //        {
        //            StartDate = DateTimeUtils.GetFirstDateOfWeek(today.Year, CurrentWeek);
        //        }
        //        else
        //        {
        //            if (cookie.Value.IndexOf("vi-") >= 0)
        //            {
        //                StartDate = DateTimeUtils.GetFirstDateOfWeek(today.Year, CurrentWeek - 1);
        //            }
        //        }
        //    }

        //    EndDate = StartDate.AddDays(7).AddSeconds(-1);
        //    LtsUyQuyen = HomeDA.GetListUyQuyen();
        //    LtsCongViecSapHetHan = new List<CongViecItem>();
        //    // Công việc sắp hết hạn
        //    //LtsCongViecSapHetHan = HomeDA.GetListCongViecSapHetHan(CurrentUser.ID); 
        //    //foreach (var item in LtsCongViecSapHetHan)
        //    //{
        //    //    if (((item.HanXuLy.Value.Date - DateTime.Now.Date).Days <= 3 && item.NguoiLapID == CurrentUser.ID) // Trường hợp người lập
        //    //            || (item.HanXuLyNguoiDung.Value.Date - DateTime.Now.Date).Days <= 3) // TH hạn xử lý của thành phần tham gia
        //    //    {
        //    //        CountCongViecSapHetHan++;
        //    //    }
        //    //}
        //    // Văn bản sắp hết hạn
        //    // Thông tin người ủy quyền
        //    List<int> LtsUyQuyenBoiID = CurrentUser.LtsUyQuyenBoiID;
        //    // Thông tin về thư ký của Lãnh đạo
        //    List<int> LtsThuKyCuaLanhDaoID = CurrentUser.LtsThuKyCuaLanhDaoID;
        //    LtsVanBanDenSapHetHan = new List<VanBanDenItem>();
        //    //LtsVanBanDenSapHetHan = HomeDA.GetListVanBanDenSapHetHan(LtsUyQuyenBoiID, LtsThuKyCuaLanhDaoID);
        //    //foreach (var value in LtsVanBanDenSapHetHan)
        //    //{
        //    //    if ((value.HanXuLyCuoi.Value.Date - DateTime.Now.Date).Days <= 3)
        //    //    {
        //    //        CountVanBanSapHetHan++;
        //    //    }
        //    //}

        //    #region[Nhân viên xuất sắc]
        //    LstKhuVucNVXS = JsonConvert.SerializeObject(dashBoardDA.GetListKhuVucNVXS());
        //    ListKhuVucNVXS = dashBoardDA.GetListKhuVucNVXS();

        //    ListNhanVienChart = dashBoardDA.GetNhanVienXuatSacChart(ListKhuVucNVXS, 1);
        //    ListNhanVienChartThang = dashBoardDA.GetNhanVienXuatSacChart(ListKhuVucNVXS, 2);


        //    Series = JsonConvert.SerializeObject(ListNhanVienChart.Select(p => p.Count).ToList());
        //    Labels = JsonConvert.SerializeObject(ListNhanVienChart.Select(p => p.TenPhongBan).ToList());

        //    Series2 = JsonConvert.SerializeObject(ListNhanVienChartThang.Select(p => p.Count).ToList());
        //    Labels2 = JsonConvert.SerializeObject(ListNhanVienChartThang.Select(p => p.TenPhongBan).ToList());

        //    SeriesKhuVuc = JsonConvert.SerializeObject(ListNhanVienChart.Select(p => p.Count).ToList());
        //    LabelsKhuVuc = JsonConvert.SerializeObject(ListNhanVienChart.Select(p => p.TenDonVi).ToList());

        //    SeriesKhuVuc2 = JsonConvert.SerializeObject(ListNhanVienChartThang.Select(p => p.Count).ToList());
        //    LabelsKhuVuc2 = JsonConvert.SerializeObject(ListNhanVienChartThang.Select(p => p.TenDonVi).ToList());

        //    LstDonViID = JsonConvert.SerializeObject(ListNhanVienChart.Select(p => p.DonViID).ToList());
        //    LstDonViID2 = JsonConvert.SerializeObject(ListNhanVienChartThang.Select(p => p.DonViID).ToList());

        //    LstPhongBanID = JsonConvert.SerializeObject(ListNhanVienChart.Select(p => p.PhongBanID).ToList());
        //    LstPhongBanID2 = JsonConvert.SerializeObject(ListNhanVienChartThang.Select(p => p.PhongBanID).ToList());


        //    #endregion

        //    NguoiDungDA nd = new NguoiDungDA();
        //    var khuvuc = nd.GetAllKhuVucQuanLy(CurrentUser.ID);
        //    var currentDonVi = CurrentUser.DonViID;
        //    var currentPhongBan = CurrentUser.LtsPhongBanID;
        //    foreach (var item in khuvuc)
        //    {
        //        var phongban = cayPheDuyetDA.GetListDonViPhongBan(item).Select(a => a.ID).ToList();
        //        currentPhongBan.AddRange(phongban);
        //    }
        //    Lst = thongbaoDA.getAllThongBaoByPhongBan();
        //    List<int> count = CurrentUser.LtsPhongBanID;
        //    Lst = Lst.Where(x => cayPheDuyetDA.GetListNguoiDuyetChucNang(x.CayPheDuyetID).Contains(CurrentUser.ID) || x.NguoiTaoID == CurrentUser.ID || x.LstNhomNguoiDung.Any(w => w.LstVanBanDiID.Contains(CurrentUser.ID)) || (x.LstDonVi.Any(a => a.IsTong == true) || (thongbaoDA.getcondition(khuvuc, x.LstDonVi, currentDonVi).Any() ? x.LstDonVi.Any(n => currentPhongBan.Contains(n.ID) && n.IsDonVi == false) : x.LstDonVi.Any(l => l.ID == currentDonVi || khuvuc.Contains(l.ID))))).OrderByDescending(p => p.NgayTao).ToList();
        //    Lst = Lst.Take(3).ToList();

        //    LstTin = TinTucDA.getAllTinTucByPhongBan();
        //    //ist<int> count1 = CurrentUser.LtsPhongBanID;
        //    LstTin = LstTin.Where(x => x.KhuVucNhan.Any(a => a.IsTong == true) || x.KhuVucNhan.Any(w => w.ID == CurrentUser.DonViID || khuvuc.Contains(w.ID)) || (x.NguoiTao == CurrentUser.ID) || (x.NguoiDuyet1 == CurrentUser.ID) || (x.NguoiDuyet2 == CurrentUser.ID)).OrderByDescending(p => p.NgayXuatBan).ToList();
        //    LstTin = LstTin.Take(3).ToList();

        //    #region Check người nhận văn bản
        //    if (CurrentUser.ViTriID == (int)Viags.Utils.Enum.TypeOfRole.VanThuDonVi)
        //    {
        //        NguoiDungDA da = new NguoiDungDA();
        //        CheckNguoiNhanVanBan = da.CheckNguoiNhanVanBan(CurrentUser.DonViID);
        //    }
        //    #endregion
        //    LtsKhuVuc = cayPheDuyetDA.GetListDonViChiNhanh();
        //    listNVXuatSac = nguoidungDA.GetNVXuatSac(0);
        //    listDonViNVXuatSac = listNVXuatSac.Select(a => a.DonViChaID).ToList();

        //    string filepath = Server.MapPath("~/Publishing_Resources/img/slider/");
        //    List<string> extensions = new List<string>{
        //    ".jpg",
        //    ".jpeg",
        //    ".png",
        //};

        //    var Images = System.IO.Directory.GetFiles(filepath);
        //    foreach (var item in Images)
        //    {
        //        var xx = Path.GetFileName(item);
        //        countImages.Add("../Publishing_Resources/img/slider/" + xx);
        //    }
        //    var kkk = countImages.Take(1).FirstOrDefault();
        }

    }
}