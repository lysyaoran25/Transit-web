using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Viags.Base;

namespace Viags.Simple
{
    public class NguoiDungItem : BaseSimple
    {
        public int NguoiDungID { get; set; } // NguoiDungID (Primary key)
        public string TenTruyCap { get; set; } // TenTruyCap
        public string Ho { get; set; } // Ho
        public string Ten { get; set; } // Ten
        public string TenHienThi { get; set; } // TenHienThi
        public int ThuTu { get; set; } // ThuTu
        public bool SuDung { get; set; } // SuDung
        public DateTime? NgaySinh { get; set; } // NgaySinh
        public string GioiTinh { get; set; } // GioiTinh
        public string Email { get; set; } // Email
        public string DiaChi { get; set; } // DiaChi
        public string DienThoai { get; set; } // DienThoai
        public string DiDong { get; set; } // DiDong
        public string AnhDaiDien { get; set; } // AnhDaiDien
        public int? ChucVuID { get; set; } // ChucVuID
        public int ViTriID { get; set; } // ChucVuID
        public string TenChucVu { get; set; }//Tên chức vụ
        public string TenDonVi { get; set; }//Tên chức vụ
        public int DonViID { get; set; }
        public bool? IsLanhDao { get; set; }
        public bool IsLargest { get; set; }
        public string ChucVuTenHienThi { get; set; }
        public string TenVietTatDonVi { get; set; }
        public string TenVietTatPhongBan { get; set; }
        public bool IsTrong { get; set; }
        public int DonViChaID { get; set; }
        public List<int> LstVanBanDiID { get; set; }
        public string TyTrong { get; set; }
        public int? LanhDaoID { get; set; } // LanhDaoID
        public string LanhDao { get; set; }
        public bool IsBanLanhDao { get; set; }
        public string CommentLDAP { get; set; }
        public string MaNV { get; set; }
        public List<NguoiDungDonViNhomNguoiDung> NguoiDungDonViNhomNguoiDung { get; set; }
        public List<int> NguoiDungDaChiaSeLich { get; set; }
        public string DiemManh { get; set; }
        public string DiemYeu { get; set; }
        public string NangLucDacBiet { get; set; }
        public string NangLucHienTai { get; set; }
        public int? Level { get; set; }
        public int? CountChild { get; set; }
        public int? position { get; set; }
        public int? sodinhbien { get; set; }
        public string SoThich { get; set; }
        public string TenQuanLy { get; set; }
        public int? TrangThaiLockID { get; set; }
        public int? LiDoKhoaID { get; set; }
        public string LiDoKhoa { get; set; }
        public DateTime? UnlockDate { get; set; }
        public string TenPhongBan { get; set; }
        public List<NguoiDungLock_LogItem> NguoiDungLock_LogItem { get; set; }
        public string www { get; set; }
    }
    public class NguoiDungLock_LogItem : BaseSimple
    {
        public int? NguoiDungID { get; set; }
        public string TenNguoiDung { get; set; }
        public string KhuVuc { get; set; }
        public string PhongBan { get; set; }
        public string Log { get; set; }
        public DateTime? Date { get; set; }
        public string MaNV { get; set; }
        public string TenTruyCap { get; set; }
        public string TenNguoiDuyet { get; set; }
        public string TenNguoiMoKhoa { get; set; }
        public string GhiChu { get; set; }

    }
}
