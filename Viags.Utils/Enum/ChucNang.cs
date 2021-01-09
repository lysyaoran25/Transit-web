using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Viags.Utils
{
    /// <summary>
    /// Danh sách chức năng của hệ thống
    /// </summary>
    /// <modified>
    /// Author				    created date					comments
    /// QuanLH					10/07/2013				        Tạo mới
    ///</modified>
    public enum ChucNang
    {
        VanBanDen = 1,
        VanBanDi = 2,
        DuThao = 3,
        CongViec = 4,
        ChuongTrinhCongTac = 5,
        XuLyKienNghi = 6,
        UyQuyen = 7,
        HoSoTaiLieu = 8,
        ThongBaoTinTuc = 9,
        LichLamViec = 10,
        BanTinNoiBo = 11,
        GiamSatCongViec = 12,
        BaoCaoCongViec = 13,
        TaiLieuISO=14,
    }
    /// <summary>
    /// Class loại báo cáo trong module báo cao công việc
    /// </summary>
    public enum LoaiBaoCao
    {
        Tuan=1,
        Thang=2,
        Quy=3
    }
}
