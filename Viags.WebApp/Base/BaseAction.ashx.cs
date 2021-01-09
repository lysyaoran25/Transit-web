using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Viags.Utils;
using WebFormsUtilities;


namespace Viags.WebApp.Base
{
    /// <summary>
    /// Summary description for BaseAction
    /// </summary>
    public class BaseAction
    {
        public Simple.NguoiDungSession CurrentUser { get; set; }


        /// <summary>
        /// Loại Action
        /// </summary>
        public Utils.TypeOfAction Action
        {
            get;
            set;
        }

        /// <summary>
        /// ID bản ghi, đối với các trường hợp, xóa, sửa, ẩn, hiện....
        /// </summary>
        public List<int> ListID
        {
            get;
            set;
        }
        /// <summary>
        /// List File Attachment
        /// </summary>
        List<FileAttach> listFileAttachAdd = new List<FileAttach>();
        /// <summary>
        /// List File Attachment
        /// </summary>
        public List<FileAttach> ListFileAttachAdd
        {
            get { return listFileAttachAdd; }
            set { listFileAttachAdd = value; }
        }

        List<FileAttach> listFileAttach = new List<FileAttach>();
        /// <summary>
        /// List File Attachment
        /// </summary>
        public List<FileAttach> ListFileAttach
        {
            get { return listFileAttach; }
            set { listFileAttach = value; }
        }
        /// <summary>
        /// List File Attach Remove
        /// </summary>
        List<string> _ListFileRemove = new List<string>();
        public List<string> ListFileRemove
        {
            get { return _ListFileRemove; }
            set { _ListFileRemove = value; }
        }

        public int AddEdit { get; set; }
        public string LinkFile { get; set; }
        public int Version { get; set; }

        /// <summary>
        /// Load action lấy ra hành động tương ứng
        /// </summary>
        public BaseAction()
        {
            #region Lấy thông tin ID
            ListID = new List<int>();
            if (!string.IsNullOrEmpty(HttpContext.Current.Request["ItemId"]))
            {
                string arrID = HttpContext.Current.Request["ItemId"].Trim();
                if (arrID.Contains(','))
                {
                    ListID = arrID.Split(',').Select(o => Convert.ToInt32(o.Trim())).ToList();
                }
                else
                    ListID.Add(Convert.ToInt32(arrID));
            }

            if (!string.IsNullOrEmpty(HttpContext.Current.Request["AddEdit"]))
            {
                AddEdit = Convert.ToInt32(HttpContext.Current.Request["AddEdit"].Trim());

            }
            if (!string.IsNullOrEmpty(HttpContext.Current.Request["LinkFile"]))
            {
                LinkFile = HttpContext.Current.Request["LinkFile"];
            }
            if (!string.IsNullOrEmpty(HttpContext.Current.Request["Version"]))
            {
                try
                {
                    string strVersion = HttpContext.Current.Request["Version"].Trim();
                    Version = Convert.ToInt32(strVersion.Substring(0, strVersion.LastIndexOf(".")));
                }
                catch
                {
                    Version = 0;
                }
            }
            #endregion

            #region Lấy thông tin action
            string actionName = string.Empty;
            if (!string.IsNullOrEmpty(HttpContext.Current.Request["do"]))
            {
                actionName = HttpContext.Current.Request["do"].ToLower().Trim();
                switch (actionName)
                {
                    case "add":
                        Action = Utils.TypeOfAction.Add;
                        break;
                    case "editfile":
                        Action = Utils.TypeOfAction.Editfile;
                        break;
                    case "chiase":
                        Action = Utils.TypeOfAction.chiase;
                        break;
                    case "ctcttrinh":
                        Action = Utils.TypeOfAction.CTCTTrinh;
                        break;
                    case "danhgia":
                        Action = Utils.TypeOfAction.DanhGia;
                        break;
                    case "ctctduyet":
                        Action = Utils.TypeOfAction.CTCTDuyet;
                        break;
                    case "ctcttuchoi":
                        Action = Utils.TypeOfAction.CTCTTuChoi;
                        break;
                    case "huychiase":
                        Action = Utils.TypeOfAction.Huychiase;
                        break;
                    case "kinhtrinh":
                        Action = Utils.TypeOfAction.KinhTrinh;
                        break;
                    case "reply":
                        Action = Utils.TypeOfAction.Add;
                        break;
                    case "sendmessage":
                        Action = Utils.TypeOfAction.SendMessage;
                        break;
                    case "checkskh":
                        Action = Utils.TypeOfAction.CheckSKH;
                        break;
                    case "checksovb":
                        Action = Utils.TypeOfAction.CheckSoVB;
                        break;
                    case "quickadd":
                        Action = Utils.TypeOfAction.QuickAdd;
                        break;
                    case "quickaddvbdi":
                        Action = Utils.TypeOfAction.QuickAddVBDi;
                        break;
                    case "edit":
                        Action = Utils.TypeOfAction.Edit;
                        break;
                    case "replacefile":
                        Action = Utils.TypeOfAction.ReplaceFile;
                        break;
                    case "forward":
                        Action = Utils.TypeOfAction.Forward;
                        break;
                    case "approved":
                        Action = Utils.TypeOfAction.Approved;
                        break;
                    case "delete":
                        Action = Utils.TypeOfAction.Delete;
                        break;
                    case "share":
                        Action = Utils.TypeOfAction.Share;
                        break;
                    case "login":
                        Action = Utils.TypeOfAction.Login;
                        break;
                    case "hide":
                        Action = Utils.TypeOfAction.Hide;
                        break;
                    case "distribute":
                        Action = Utils.TypeOfAction.Distribute;
                        break;
                    case "chuyenlanhdaophong":
                        Action = Utils.TypeOfAction.ChuyenLanhDaoPhong;
                        break;
                    case "chuyennguoixuly":
                        Action = Utils.TypeOfAction.ChuyenNguoiXuLy;
                        break;
                    case "reject":
                        Action = Utils.TypeOfAction.Reject;
                        break;
                    case "show":
                        Action = Utils.TypeOfAction.Show;
                        break;
                    case "send":
                        Action = Utils.TypeOfAction.Send;
                        break;
                    case "sendtoall":
                        Action = Utils.TypeOfAction.SendToAll;
                        break;
                    case "butphe":
                        Action = Utils.TypeOfAction.ButPhe;
                        break;
                    case "butphevanban":
                        Action = Utils.TypeOfAction.ButPheVanBan;
                        break;
                    case "ykien":
                        Action = Utils.TypeOfAction.YKien;
                        break;
                    case "thuhoi":
                        Action = Utils.TypeOfAction.ThuHoi;
                        break;
                    case "addpxl":
                        Action = Utils.TypeOfAction.AddPXL;
                        break;
                    case "finish":
                        Action = Utils.TypeOfAction.Finish;
                        break;
                    case "thayhan":
                        Action = Utils.TypeOfAction.ChangeDeadLine;
                        break;
                    case "editpxl":
                        Action = Utils.TypeOfAction.EditPXL;
                        break;
                    case "duyetdkcv":
                        Action = Utils.TypeOfAction.DuyetDKCV;
                        break;
                    case "tuchoidkcv":
                        Action = Utils.TypeOfAction.TuChoiDKCV;
                        break;
                    case "pending":
                        Action = Utils.TypeOfAction.Pending;
                        break;
                    case "dongbo":
                        Action = Utils.TypeOfAction.DongBo;
                        break;
                    case "order":
                    case "sort":
                        Action = Utils.TypeOfAction.Order;
                        break;
                    case "trinhky":
                        Action = Utils.TypeOfAction.TrinhKy;
                        break;
                    case "config":
                        Action = Utils.TypeOfAction.ConfigRole;
                        break;
                    case "configrole":
                        Action = Utils.TypeOfAction.ConfigRoleUser;
                        break;
                    case "resetpass":
                        Action = Utils.TypeOfAction.ResetPass;
                        break;
                    case "saveworkflow":
                        Action = Utils.TypeOfAction.SaveWorkFlow;
                        break;
                    case "tonghopykien":
                        Action = Utils.TypeOfAction.TongHopYKien;
                        break;
                    case "tylehoanthanh":
                        Action = Utils.TypeOfAction.TyLeHoanThanh;
                        break;
                    case "addusertodonvi":
                        Action = Utils.TypeOfAction.AddUserToDonVi;
                        break;
                    case "denghilamlai":
                        Action = Utils.TypeOfAction.DeNghiLamLai;
                        break;
                    case "duyetdangkyxe":
                        Action = Utils.TypeOfAction.DuyetDangKyXe;
                        break;
                    case "phanxulyxe":
                        Action = Utils.TypeOfAction.PhanXuLyXe;
                        break;
                    case "capnhapkm":
                        Action = Utils.TypeOfAction.CapNhapKM;
                        break;
                    case "xemdebiet":
                        Action = Utils.TypeOfAction.XemDeBiet;
                        break;
                    case "hoanthanh":
                        Action = Utils.TypeOfAction.HoanThanh;
                        break;
                    case "chuyenthuvien":
                        Action = Utils.TypeOfAction.ChuyenThuVien;
                        break;
                    case "chuyenvanban":
                        Action = Utils.TypeOfAction.ChuyenVanBan;
                        break;
                    case "chuyenvanbanall":
                        Action = Utils.TypeOfAction.ChuyenVanBanAll;
                        break;
                    case "updatelq":
                        Action = Utils.TypeOfAction.UpdateLQ;
                        break;
                    case "successnd":
                        Action = Utils.TypeOfAction.SuccessND;
                        break;
                    case "tralai":
                        Action = Utils.TypeOfAction.TraLai;
                        break;
                    case "deleteversion":
                        Action = Utils.TypeOfAction.DeleteVersion;
                        break;
                    case "recoverversion":
                        Action = Utils.TypeOfAction.RecoverVersion;
                        break;
                    case "capso":
                        Action = Utils.TypeOfAction.CapSo;
                        break;
                    case "deletefile":
                        Action = Utils.TypeOfAction.DeleteFile;
                        break;
                    case "deleteykien":
                        Action = Utils.TypeOfAction.DeleteYKien;
                        break;
                    case "deletequyetdinh":
                        Action = Utils.TypeOfAction.DeleteQuyetDinh;
                        break;
                    case "capnhatthongtin":
                        Action = Utils.TypeOfAction.CapNhatThongTin;
                        break;
                    case "phathanh":
                        Action = Utils.TypeOfAction.PhatHanh;
                        break;
                    case "updatetrichyeu":
                        Action = Utils.TypeOfAction.UpdateTrichYeu;
                        break;
                    case "theodoi":
                        Action = Utils.TypeOfAction.TheoDoi;
                        break;
                    case "huytheodoi":
                        Action = Utils.TypeOfAction.HuyTheoDoi;
                        break;
                    case "huyduyet":
                        Action = Utils.TypeOfAction.HuyDuyet;
                        break;
                    case "xoatam":
                        Action = Utils.TypeOfAction.XoaTam;
                        break;
                    case "baocao":
                        Action = Utils.TypeOfAction.BaoCao;
                        break;
                    case "recoverxoatam":
                        Action = Utils.TypeOfAction.RecoverXoaTam;
                        break;
                    case "xoanguoidunghscv":
                        Action = Utils.TypeOfAction.XoaNguoiHSCV;
                        break;
                    case "addnguoidunghscv":
                        Action = Utils.TypeOfAction.AddNguoiHSCV;
                        break;
                    case "trinhlanhdao":
                        Action = Utils.TypeOfAction.TrinhLanhDao;
                        break;
                    case "trinhnhanhld":
                        Action = Utils.TypeOfAction.TrinhNhanhLD;
                        break;
                    case "huyhoanthanh":
                        Action = Utils.TypeOfAction.HuyHoanThanh;
                        break;
                    case "bangiaocv":
                        Action = Utils.TypeOfAction.BanGiaoCV;
                        break;
                    case "updateprogress":
                        Action = Utils.TypeOfAction.Updateprogress;
                        break;
                    case "request":
                        Action = Utils.TypeOfAction.Request;
                        break;
                    case "requestvbden":
                        Action = Utils.TypeOfAction.Requestvbden;
                        break;
                    case "confirm":
                        Action = Utils.TypeOfAction.Confirm;
                        break;
                    case "tiendo":
                        Action = Utils.TypeOfAction.TienDo;
                        break;
                    case "addctct":
                        Action = Utils.TypeOfAction.AddCTCT;
                        break;
                    case "addhstl":
                        Action = Utils.TypeOfAction.AddHSTL;
                        break;
                    case "addcv":
                        Action = Utils.TypeOfAction.AddCV;
                        break;
                    case "addvb":
                        Action = Utils.TypeOfAction.AddVB;
                        break;
                    case "deletecv":
                        Action = Utils.TypeOfAction.DeleteCV;
                        break;
                    case "deletevb":
                        Action = Utils.TypeOfAction.DeleteVB;
                        break;
                    case "pheduyetlich":
                        Action = Utils.TypeOfAction.PheDuyetLich;
                        break;
                    case "duyetthethuc":
                        Action = Utils.TypeOfAction.DuyetTheThuc;
                        break;
                    case "tuchoithethuc":
                        Action = Utils.TypeOfAction.TuChoiTheThuc;
                        break;
                    case "capnhattiendo":
                        Action = Utils.TypeOfAction.CapNhatTienDo;
                        break;
                    case "capnhattiendocanhan":
                        Action = Utils.TypeOfAction.CapNhatTienDoCaNhan;
                        break;
                    case "bangiao":
                        Action = Utils.TypeOfAction.BanGiao; // bàn giao: hồ sơ nộp lưu
                        break;
                    case "giahancvnguoilap":
                        Action = Utils.TypeOfAction.GiaHanCVNguoiLap;
                        break;
                    case "tiepnhan":
                        Action = Utils.TypeOfAction.TiepNhan; // tiếp nhận: hồ sơ  nộp lưu
                        break;
                    case "khongtiepnhan":
                        Action = Utils.TypeOfAction.KhongTiepNhan; // không tiếp nhân: hồ sơ nộp lưu
                        break;
                    case "donghopcap":
                        Action = Utils.TypeOfAction.DongHopCap; // Đóng hộp cặp
                        break;
                    case "mohopcap":
                        Action = Utils.TypeOfAction.MoHopCap; // Mở hộp cặp
                        break;
                    case "capnhathoso":
                        Action = Utils.TypeOfAction.CapNhatHoSo; // cập nhật hồ sơ tài liệu từ phân hệ QLVB
                        break;
                    case "guithongbaotieuhuy":
                        Action = Utils.TypeOfAction.ThongBaoTieuHuyTaiLieu; // thông báo tiêu hủy tới đơn vị nộp lưu
                        break;
                    case "tieuhuy":
                        Action = Utils.TypeOfAction.XacNhanTieuHuyTaiLieu; // thông báo tiêu hủy tới đơn vị nộp lưu
                        break;
                    case "giahanluutru":
                        Action = Utils.TypeOfAction.GiaHanLuuTru; // thông báo tiêu hủy tới đơn vị nộp lưu
                        break;
                    case "duyetthoihannopluu":
                        Action = Utils.TypeOfAction.DuyetThoiGian; // duyệt thời hạn nộp lưu tại đơn vị
                        break;
                    case "huyduyetthoihannopluu":
                        Action = Utils.TypeOfAction.HuyDuyetThoiGian; // hủy duyệt thời hạn nộp lưu tại đơn vị
                        break;
                    case "thongbaohethan":
                        Action = Utils.TypeOfAction.ThongBaoHetHan; // hủy duyệt thời hạn nộp lưu tại đơn vị
                        break;
                    case "themhosovaoquyetdinhhuy":
                        Action = Utils.TypeOfAction.ThemHoSoVaoQuyetDinhHuy; // hủy duyệt thời hạn nộp lưu tại đơn vị
                        break;
                    case "dongkho":
                        Action = Utils.TypeOfAction.DongKho;
                        break;
                    case "guilienthong":
                        Action = Utils.TypeOfAction.GuiLienThong;
                        break;
                    case "mokho":
                        Action = Utils.TypeOfAction.MoKho;
                        break;
                    case "kiemketailieu":
                        Action = Utils.TypeOfAction.KiemKeTaiLieu;
                        break;
                    case "khoakykiemke":
                        Action = Utils.TypeOfAction.KhoaKyKiemKe;
                        break;
                    case "mokykiemke":
                        Action = Utils.TypeOfAction.MoKyKiemKe;
                        break;
                    case "deletevbdi":
                        Action = Utils.TypeOfAction.DeleteVBDi;
                        break;
                    case "molaicv":
                        Action = Utils.TypeOfAction.MoLaiCV;
                        break;
                    case "tralaicv":
                        Action = Utils.TypeOfAction.TraLaiCV;
                        break;
                    case "giahanchitietctct":
                        Action = Utils.TypeOfAction.GiaHanChiTietCTCT;
                        break;
                    case "duyetgiahanctct":
                        Action = Utils.TypeOfAction.DuyetGiaHanCTCT;
                        break;
                    case "tuchoigiahan":
                        Action = Utils.TypeOfAction.TuChoiGiaHanCV;
                        break;
                    case "xoavbden":
                        Action = Utils.TypeOfAction.XoaVanBanChoVaoSo;
                        break;
                    case "updatelkvbd":
                        Action = Utils.TypeOfAction.UpDateLKVBDi;
                        break;
                    case "tuchoiguibangoc":
                        Action = Utils.TypeOfAction.TuChoiGuiBanGoc;
                        break;
                    case "updatenoinhan":
                        Action = Utils.TypeOfAction.UpDateNoiNhan;
                        break;
                    case "addrow":
                        Action = Utils.TypeOfAction.AddRowThamGia;
                        break;
                    default:
                    case "addduthaovaovbd":
                        Action = Utils.TypeOfAction.AddduThaoVaoVBD;
                        break;
                    case "view":
                        Action = Utils.TypeOfAction.View;
                        break;
                    case "capnhattrangthaixe":
                        Action = Utils.TypeOfAction.CapNhatTrangThaiXe;
                        break;
                    case "lock":
                        Action = Utils.TypeOfAction.Lock;
                        break;
                    case "trinhduyetdatcom":
                        Action = Utils.TypeOfAction.TrinhDuyetDatCom;
                        break;
                    case "duyetdatcom":
                        Action = Utils.TypeOfAction.DuyetDatCom;
                        break;
                    case "tuchoidatcom":
                        Action = Utils.TypeOfAction.TuChoiDatCom;
                        break;
                    case "chuyentaomoi":
                        Action = Utils.TypeOfAction.ChuyenTaoMoi; // chuyển trạng thái từ từ chối sang tạo mới
                        break;
                    case "comment":
                        Action = Utils.TypeOfAction.Comment;
                        break;
                    case "rate":
                        Action = Utils.TypeOfAction.Rate;
                        break;
                    case "addquickgiamsat":
                        Action = Utils.TypeOfAction.AddQuickGiamSat;
                        break;
                    case "upavatar":
                        Action = Utils.TypeOfAction.UpAvatar;
                        break;
                    case "editthietlapvpp":
                        Action = Utils.TypeOfAction.EditThietLapVPP;
                        break;                    
                    case "edit_khach":
                        Action = Utils.TypeOfAction.Edit_Khach;
                        break;
                    case "checkqrcode":
                        Action = Utils.TypeOfAction.CheckQRcode;
                        break;
                }
            }
            else
                Action = Utils.TypeOfAction.View;
            #endregion
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
        /// Convert xâu có dạng 1,2,3,4 sang list int
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        /// <modified>
        /// Author				    created date					comments
        /// QuangNĐ					05/07/2013				        Tạo mới
        ///</modified>
        public List<int> String2Array(string source)
        {
            List<int> LtsValue = new List<int>();
            if (!string.IsNullOrEmpty(source))
            {
                if (source.Contains(','))
                {
                    LtsValue = source.Split(',').Select(o => Convert.ToInt32(o)).ToList();
                }
                else
                    LtsValue.Add(Convert.ToInt32(source));
            }
            return LtsValue;
        }

        public void GetCurrentUser()
        {
            if (HttpContext.Current.Session["VIAG2016"] != null)
                CurrentUser = (Viags.Simple.NguoiDungSession)HttpContext.Current.Session["VIAG2016"];
        }

    }
}