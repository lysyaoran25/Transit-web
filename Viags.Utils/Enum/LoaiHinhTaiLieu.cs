using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viags.Utils.Enum
{
    /// <summary>
    /// Loại hình tài liệu
    /// </summary>
    /// Author				created date					comments
    /// QuanLH				05/08/2013					    Tạo mới
    public enum LoaiHinhTaiLieu
    {
        HanhChinh = 1,
        ChuyenMon = 2
    }
    /// <summary>
    /// Lưu thông tin loại hồ sơ tài liệu: nhập từ QLVB, hồ sơ tại đơn vị, hay hồ sơ từ phòng ban hồ sơ chuyên môn
    /// </summary>
    public enum ViTriTaoHoSo
    {
        HoSoTaiDonViNopLuu = 1,//hồ sơ nhập từ đơn đơn vị nộp lưu
        HoSoTaiPhongBan = 2,//hồ sơ từ phòng ban
        HoSoTuPhanHeQLVB = 3,//hồ sơ từ phân hệ quản lý văn bản
        HoSoTaiDonViLuuTru = 4,//thêm mới hồ sơ tại đơn vị lưu trữ
    }
    /// <summary>
    /// Độ mật hồ sơ lưu trữ
    /// </summary>
    public enum DoMat
    {
        Thuong = 1,
        Mat = 2,
        ToiMat = 3,
        TuyetMat = 4
    }
    /// <summary>
    /// Phạm vị tài liệu
    /// </summary>
    public enum PhamVi
    {
        HanChe = 0, CongKhai = 1
    }
}