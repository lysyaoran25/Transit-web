using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Viags.Utils;
using Viags.Data;
using Viags.Simple;
namespace Viags.WebApp.Common
{
    public partial class ucMenuDesignNew : Base.BaseUserControl
    {
        //SoVanBanDA SoVanBanDA;
        //public NguoiDungDA NguoiDungDA;
        //public List<SoVanBanItem> LstSoVanBan;
        //public List<SoVanBanItem> LstSoVanBanDen;
        //public List<LoaiChuongTrinhItem> LtsLoaiChuongTrinh;
        //public List<SoVanBanItem> LstSoVanBanDenPB = new List<SoVanBanItem>();
        //public int VBDCXL { get; set; }
        //public int VBDXL { get; set; }
        //public int VBCVS { get; set; }
        //public string UrlLogout { get; set; }
        //public string KeHoachID = string.Empty;
        //public string HoSoLuuTruID = string.Empty;
        //public string IDMucLucNopLuu = string.Empty;
        //public bool CheckDanhSachBanGoc { get; set; }
        //public bool CheckVanBanDiChuaDoc { get; set; }
          /// <summary>
        /// Hamkhoi tao
        /// </summary>
        public ucMenuDesignNew()
        {
            //NguoiDungDA = new NguoiDungDA();
            //SoVanBanDA = new SoVanBanDA();
            //LstSoVanBan = new List<SoVanBanItem>();
            //LstSoVanBanDen = new List<SoVanBanItem>();
            //LtsLoaiChuongTrinh = new List<LoaiChuongTrinhItem>();
            //LstSoVanBanDenPB = new List<SoVanBanItem>();
          
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (CurrentUser == null || CurrentUser.ID == 0)
            //{
            //    Page.Response.Redirect("/LoginNew.aspx");
            //}
            //else
            //{
            //    LstSoVanBan = SoVanBanDA.GetAllSoVanBanTheoChucNang(CurrentUser.DonViID, (int)Viags.Utils.ChucNang.VanBanDi, false);

            //    LtsLoaiChuongTrinh = SoVanBanDA.GetListLoaiChuongTrinh(CurrentUser.DonViID);
            //    if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.VanthuDonvi) && CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Vanthuphongban))
            //    {
            //        if (CurrentUser.LtsPhongBanSo.Any())
            //            LstSoVanBanDenPB = SoVanBanDA.GetAllSoVanBanTheoChucNang(CurrentUser.LtsPhongBanSo[0], (int)Viags.Utils.ChucNang.VanBanDen);
            //    }

            //    if ((CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Vanthutonghop) 
            //        || CurrentUser.ViTriID == (int)Viags.Utils.Enum.TypeOfRole.VanThuDonVi 
            //        || CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.VanthuDonvi) 
            //        || CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.ThukyBanlanhdao)
            //        || CurrentUser.ViTriID == (int)Viags.Utils.Enum.TypeOfRole.ThuKy)
            //        && CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Themmoivanbanden))
            //    {
            //        LstSoVanBanDen = SoVanBanDA.GetAllSoVanBanTheoChucNangAll(CurrentUser.DonViID, (int)Viags.Utils.ChucNang.VanBanDen);
            //    }
            //    else
            //    {
            //        if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Vanthuphongban) && CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Themmoivanbanden))
            //        {
            //            if (CurrentUser.LtsPhongBanSo.Any())
            //                LstSoVanBanDen = SoVanBanDA.GetAllSoVanBanTheoChucNang(CurrentUser.LtsPhongBanSo[0], (int)Viags.Utils.ChucNang.VanBanDen);
            //        }
            //        else
            //        {
            //            LstSoVanBanDen = SoVanBanDA.GetAllSoVanBanTheoChucNangAll(CurrentUser.DonViID, (int)Viags.Utils.ChucNang.VanBanDen);
            //        }
            //    }
            //    if (!string.IsNullOrEmpty(HttpContext.Current.Request["KeHoachID"]))
            //        KeHoachID = HttpContext.Current.Request["KeHoachID"];
            //    if (!string.IsNullOrEmpty(HttpContext.Current.Request["IDMucLucNopLuu"]))
            //        IDMucLucNopLuu = HttpContext.Current.Request["IDMucLucNopLuu"];
            //    if (!string.IsNullOrEmpty(HttpContext.Current.Request["HoSoLuuTruID"]))
            //        HoSoLuuTruID = HttpContext.Current.Request["HoSoLuuTruID"];
            //    CheckDanhSachBanGoc = SoVanBanDA.CheckVanBanGoc(CurrentUser.ID);
            //    if (CurrentUser.ViTriID != (int)Viags.Utils.Enum.TypeOfRole.VanThuDonVi)
            //    {
            //        VanBanDiDA VanBanDiDA = new Data.VanBanDiDA();
            //        string lstuyquyen = CurrentUser.LtsUyQuyenBoiID.Any() ? string.Join(",", CurrentUser.LtsUyQuyenBoiID) : "0";
            //        CheckVanBanDiChuaDoc = VanBanDiDA.CheckVanBanDiChuaDoc(CurrentUser.ID, lstuyquyen);
            //    }
            //}
        }
    }
}