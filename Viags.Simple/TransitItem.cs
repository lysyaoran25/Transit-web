using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viags.Simple
{
    public class TransitItem : BaseSimple
    {

    }
    public class KhuVucItem : BaseSimple
    {
        public bool? SuDung { get; set; }

    }
    public class PhuongXaItem : BaseSimple
    {
        public bool? SuDung { get; set; }
    }
    public class DuongApItem : BaseSimple
    {
        public bool? SuDung { get; set; }
    }
    public class DanhMucChuyenItem : BaseSimple
    {
        public int? KhuVucID { get; set; }
        public int? GioKhoiHanh { get; set; }
        public int? PhutKhoiHanh { get; set; }
        public bool? SuDung { get; set; }
    }

    public class ListTemp
    {
        public List<LookupData> LstPhuongXaItem { get; set; }
        public List<LookupData> LstDanhMucChuyenItem { get; set; }
    }

    public class ThongTinTaiXe
    {
        public int ID { get; set; }
        public string TenTaiXe { get; set; }
        public string SoDienThoai { get; set; }
        public string CMND { get; set; }
        public string NamSinh { get; set; }
        public int? LoaiXe { get; set; }
        public string TenLoaiXe { get; set; }
        public int? TrangThai { get; set; }
        public string GPS_Lat { get; set; }
        public string GPS_Long { get; set; }
        public int? KhuVucID { get; set; }
        public string TenKhuVuc { get; set; }
        public string DiaChi { get; set; }
        
    }

    public class ThongTinDonKhachItem
    {
        public int ID { get; set; }
        public DateTime? NgayKhoiHanh { get; set; }
        public int? SoGhe { get; set; }
        public bool? isTrungChuyen { get; set; }
        public string DiaChi { get; set; }
        public int? KhuVucID { get; set; }
        public string TenKhuVuc { get; set; }
        public int? PhuongXaID { get; set; }
        public string TenPhuongXa { get; set; }
        public int? DuongApID { get; set; }
        public string TenDuongAp { get; set; }
        public int? DanhMucChuyenID { get; set; }
        public int? GioKhoiHanh { get; set; }
        public int? PhutKhoiHanh { get; set; }
        public string SoDienThoai { get; set; }
        public int? TrangThai { get; set; }
    }
}
