using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Viags.Data;
using Viags.Simple;
namespace Viags.WebApp.Home
{
    public partial class ucHomeNewDesignDashBoard : Base.BaseUserControl
    {
        //Nhân Viên Xuất Sắc - Cải Tiến
        public DashBoardDA dashBoardDA;
        public string Series;
        public string Labels;
        public string SeriesKhuVuc;
        public string LabelsKhuVuc;
        public string LstDonViID;
        public string LstPhongBanID;


        public string Series2;
        public string Labels2;
        public string SeriesKhuVuc2;
        public string LabelsKhuVuc2;
        public string LstDonViID2;
        public string LstPhongBanID2;

        public string LstKhuVucNVXS;
        public List<int> ListKhuVucNVXS;

        //public int Quy;
        List<NhanVienXuatSacChart> ListNhanVienChart;
        List<NhanVienXuatSacChart> ListNhanVienChartThang;



        //Thông Báo -Tin tức
        ThongBaoTinTucDA thongbaoDA;
        TinTucSuKienDA TinTucDA;
        public NguoiDungDA nd;

        CayPheDuyetDA cayPheDuyetDA = new CayPheDuyetDA();
        public List<ThongBaoTinTucItem> Lst { get; set; }
        public List<TinTucSuKienItem> LstTin { get; set; }


        //qlcv
        DonViDA DonViDA;
        public List<DonViItem> LstDonvi { get; set; }
        public List<CongViecItem> CongViecItem;
        public CongViecDA CongViecDA;

        //qly tài liệu
        public HoSoTaiLieuDA HoSoTaiLieuDA;

        //ho so trinh ky
        public DuThaoVanBanDA DuThaoVanBanDA;

        //dinh bien nhan su
        public DinhBienNhanSuDA DinhBienNhanSuDA;

        //CEO
        public int? TotalCountQLCV = 0;
        public int? TotalCountKTGS = 0;
        public int? TotalCountQLTL = 0;
        public int? TotalCountHSTK = 0;
        public string TotalTiLeDinhBien;
        public int? TotalDinhBien = 0;
        public int? TotalThucTe = 0;
        public int? TotalNghiPhep = 0;

        //
        public DonViItem DonViItem;
        public int KhuVucUser;
        public int testcheck = 1;
        public DangKyNghiPhepDA DangKyNghiPhepDA;
        public NguoiDungDA NguoiDungDA;

        public ucHomeNewDesignDashBoard()
        {
            //Thông Báo Tin tức
            thongbaoDA = new ThongBaoTinTucDA();
            TinTucDA = new TinTucSuKienDA();
            cayPheDuyetDA = new CayPheDuyetDA();
            nd = new NguoiDungDA();
            Lst = new List<ThongBaoTinTucItem>();
            LstTin = new List<TinTucSuKienItem>();

            //Nhan viên xuất sắc - cải tiến
            dashBoardDA = new DashBoardDA();
            ListNhanVienChart = new List<NhanVienXuatSacChart>();
            ListNhanVienChartThang = new List<NhanVienXuatSacChart>();
            ListKhuVucNVXS = new List<int>();

            //qlcv
            CongViecItem = new List<CongViecItem>();
            LstDonvi = new List<DonViItem>();
            DonViDA = new DonViDA();
            CongViecDA = new CongViecDA();

            //qly tài liệu
            HoSoTaiLieuDA = new HoSoTaiLieuDA();

            //ho so trinh ky
            DuThaoVanBanDA = new DuThaoVanBanDA();

            //dinh bien nhan su
            DinhBienNhanSuDA = new DinhBienNhanSuDA();

            //
            DonViItem = new DonViItem();
            DangKyNghiPhepDA = new DangKyNghiPhepDA();
            NguoiDungDA = new NguoiDungDA();

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!CheckQuyen(CurrentUser.QuyenHan, (int)Utils.Enum.QuyenHan.XemDashBoard) && !CheckQuyen(CurrentUser.QuyenHan, (int)Utils.Enum.QuyenHan.XemDashboardToanKhuVuc) && nd.CheckUserCEO() == false)
            {
                Response.Redirect("/Pagess/error.aspx");
            }

            KhuVucUser = CurrentUser.DonViID;
            DonViItem = DonViDA.GetSimpleByID(KhuVucUser);

            //Nhân Viên Xuất Sắc
            //Quy = dashBoardDA.GetQuy();
            #region[Nhân viên xuất sắc]
            LstKhuVucNVXS = JsonConvert.SerializeObject(dashBoardDA.GetListKhuVucNVXS());
            ListKhuVucNVXS = dashBoardDA.GetListKhuVucNVXS();

            ListNhanVienChart = dashBoardDA.GetNhanVienXuatSacChart(ListKhuVucNVXS,1);
            ListNhanVienChartThang = dashBoardDA.GetNhanVienXuatSacChart(ListKhuVucNVXS,2);


            Series = JsonConvert.SerializeObject(ListNhanVienChart.Select(p => p.Count).ToList());
            Labels = JsonConvert.SerializeObject(ListNhanVienChart.Select(p => p.TenPhongBan).ToList());

            Series2 = JsonConvert.SerializeObject(ListNhanVienChartThang.Select(p => p.Count).ToList());
            Labels2 = JsonConvert.SerializeObject(ListNhanVienChartThang.Select(p => p.TenPhongBan).ToList());

            SeriesKhuVuc = JsonConvert.SerializeObject(ListNhanVienChart.Select(p => p.Count).ToList());
            LabelsKhuVuc = JsonConvert.SerializeObject(ListNhanVienChart.Select(p => p.TenDonVi).ToList());

            SeriesKhuVuc2 = JsonConvert.SerializeObject(ListNhanVienChartThang.Select(p => p.Count).ToList());
            LabelsKhuVuc2 = JsonConvert.SerializeObject(ListNhanVienChartThang.Select(p => p.TenDonVi).ToList());

            LstDonViID = JsonConvert.SerializeObject(ListNhanVienChart.Select(p => p.DonViID).ToList());
            LstDonViID2 = JsonConvert.SerializeObject(ListNhanVienChartThang.Select(p => p.DonViID).ToList());

            LstPhongBanID = JsonConvert.SerializeObject(ListNhanVienChart.Select(p => p.PhongBanID).ToList());
            LstPhongBanID2 = JsonConvert.SerializeObject(ListNhanVienChartThang.Select(p => p.PhongBanID).ToList());


            #endregion



            var khuvuc = nd.GetAllKhuVucQuanLy(CurrentUser.ID);

            //Thông Báo
            #region [Thông Báo]
            var currentDonVi = CurrentUser.DonViID;
            var currentPhongBan = CurrentUser.LtsPhongBanID;
            foreach (var item in khuvuc)
            {
                var phongban = cayPheDuyetDA.GetListDonViPhongBan(item).Select(a => a.ID).ToList();
                currentPhongBan.AddRange(phongban);
            }
            Lst = thongbaoDA.getAllThongBaoByPhongBan();
            List<int> count = CurrentUser.LtsPhongBanID;
            Lst = Lst.Where(x => cayPheDuyetDA.GetListNguoiDuyetChucNang(x.CayPheDuyetID).Contains(CurrentUser.ID) || x.NguoiTaoID == CurrentUser.ID || x.LstNhomNguoiDung.Any(w => w.LstVanBanDiID.Contains(CurrentUser.ID)) || (x.LstDonVi.Any(a => a.IsTong == true) || (thongbaoDA.getcondition(khuvuc, x.LstDonVi, currentDonVi).Any() ? x.LstDonVi.Any(n => currentPhongBan.Contains(n.ID) && n.IsDonVi == false) : x.LstDonVi.Any(l => l.ID == currentDonVi || khuvuc.Contains(l.ID))))).OrderByDescending(p => p.NgayTao).ToList();
            Lst = Lst.Take(3).ToList();
            #endregion

            //Tin Tức
            #region[Tin Tức]
            LstTin = TinTucDA.getAllTinTucByPhongBan();
            LstTin = LstTin.Where(x => x.KhuVucNhan.Any(a => a.IsTong == true) || x.KhuVucNhan.Any(w => w.ID == CurrentUser.DonViID || khuvuc.Contains(w.ID)) || (x.NguoiTao == CurrentUser.ID) || (x.NguoiDuyet1 == CurrentUser.ID) || (x.NguoiDuyet2 == CurrentUser.ID)).OrderByDescending(p => p.NgayXuatBan).ToList();
            LstTin = LstTin.Take(3).ToList();
            #endregion


            //get list đơn vị 
            LstDonvi = DonViDA.GetListDonViItem();

            foreach (var item in LstDonvi.OrderBy(a=>a.ThuTu))
            {
                TotalCountQLCV += CongViecDA.CountCongViecQuaHan_StoreProcedures(item.ID);
                TotalCountKTGS += CongViecDA.CountGiamSatDashBoard_StoreProcedures(item.ID);
                TotalCountQLTL += HoSoTaiLieuDA.CountHoSoTaiLieuDashBoard_StoreProcedures(item.ID);
                TotalCountHSTK += DuThaoVanBanDA.countHoSoTrinhKyDashBoard_StoreProcedures(item.ID);
                //TotalDinhBien += DinhBienNhanSuDA.CountSoDinhBienKhuVucCEO(item.ID);
                TotalThucTe += DinhBienNhanSuDA.CountSoThucTeKhuVuc(item.ID);
                TotalNghiPhep += DangKyNghiPhepDA.countThongKetNghiPhepDashBoard_StoreProcedures(item.ID);
            }
            
        }
    }
}