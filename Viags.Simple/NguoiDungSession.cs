using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viags.Simple
{
    /// <summary>
    /// Class lấy thông tin session người dùng khi đăng nhập
    /// </summary>
    public class NguoiDungSession
    {
        public int ID { get; set; }
        public string TenTruyCap { get; set; } //Tên truy cập
        public string TenHienThi { get; set; }  // Ten hiển thị
        public int ChucVuID { get; set; } // Chức vụ ID
        public List<int> LtsPhongBanID { get; set; }  // Danh sách phòng ban, đơn vị mà người dùng có
        public int DonViID { get; set; }  //Đơn vị gần nhất IsDonVi=1
        public List<int> LtsDonViID { get; set; } // Danh sách đơn vị mà người dùng tham gia
        public List<string> LtsDonViTen { get; set; }
        public string AnhDaiDien { get; set; }
        public int DonViChaID { get; set; }
        public string QuyenHan { get; set; }  //Danh sách quyên hạn của người dùng
        public string NhomNguoiDung { get; set; }
        public List<int> LtsNhomNguoiDungID { get; set; }  // Nhóm, chức vụ của người dùng
        public string TenDonVi { get; set; } //Tên đơn vị
        public string LinkAnh { get; set; }  // Đường dẫn ảnh đại diện
        public bool IsLanhDao { get; set; }  // Có phải là Lãnh đạo đơn vị
        public List<int> LtsDaiDienID { get; set; }  //Danh sách các phòng ban, đơn vị mà người dùng làm đại diện
        public List<int> LtsDaiDienCongViecID { get; set; }  //Danh sách các phòng ban, đơn vị mà người dùng làm đại diện
        public int ViTriID { get; set; }  // role
        public List<int> LtsThuKyCuaLanhDaoID { get; set; }  // Là thư ký của lãnh đạo nào
        public List<int> ListAllCapDuoiID { get; set; }  // trung
        public List<int> LtsUyQuyenBoiID { get; set; }  // Danh sách người dùng ủyq uyền
        public List<int> LtsCapDonViID { get; set; }  // cấp đơn vị
        public string TenNhomNguoiDung { get; set; }  // tên nhóm người dùng
        public string Token { get; set; }
        public bool SuDung { get; set; }
        public bool CheckPhongBan { get; set; }
        public string Message { get; set; }
        public string TenNguoiUyQuyen { get; set; }
        /// <summary>
        /// Id người dùng trong SharePoint.
        /// </summary>
        public int SPId { get; set; }
        public string Apple_DeviceToken { get; set; }
        public int Khoi { get; set; }
        public int LanhDaoID { get; set; }//trung
        public bool IsDaCap { get; set; }
        public List<int> LtsThuTuNhomID { get; set; } // thứ tự nhóm 
        public bool IsTrinhDV { get; set; }
        public bool IsPhieuTrinh { get; set; }
        public bool IsVanPhong { get; set; }
        public bool IsTrong { get; set; }
        public List<int> LtsNguoiDungDaiDienID { get; set; }
        public List<int> LtsPhongBanSo { get; set; }
        public List<string> LtsPhongBanVietTat { get; set; }
        public List<string> LtsTenPhongBan { get; set; }
        public DateTime? NgayCauHinh { get; set; }
        public bool IsLargest { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
        public string TenChucVu { get; set; }
        public string FolderScan { get; set; }
        public string MaNV { get; set; }
        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        public NguoiDungSession()
        {

        }
    }

}
