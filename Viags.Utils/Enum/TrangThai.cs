namespace Viags.Utils.Enum
{
    /// <summary>
    /// Kiểu thao tác
    /// </summary>
    /// Author				created date					comments
    /// QuanLH				05/08/2013					    Tạo mới
    public enum TrangThai
    {
        TaoMoi = 1,//LT
        ChoDuyet = 2,//LT
        DaDuyet = 3,//LT
        TuChoi = 4,//LT
        KetThuc = 5,
        PhatHanh = 6,
        ChuaXuLy = 7,//LT
        DangXuLy = 8,//LT
        DaXuLy = 9,//LT
        QuaHan = 10,
        ConHan = 11,
        Tot = 12,
        ChuaDat = 13,
        Kem = 14,
        BanGiao = 15,// đơn vị bàn giao tài liệu
        TiepNhan = 16,// đã tiếp nhận tài liệu
        BienMuc = 17, // đã biên mục tài liệu
        KhongTiepNhan = 18, // không tiếp nhận
        XepHopCap = 19, // không tiếp nhận
        ThongBaoTieuHuy = 20, // trạng thái gửi thông báo tài liệu sắp hết hạn
        //XacNhanTieuHuy = 21, // trạng thái xác nhận tiêu hủy tài liệu <=> ChoTieuHuyTaiLieu
        GiaHanLuuTru = 22, // trang thái gửi yêu cầu gia hạn tài liệu
        ChoTieuHuyTaiLieu = 23, // trạng thái tiêu hủy tài liệu
        DaTieuHuyTaiLieu = 24, // trạng thái đã tiêu hủy tài liệu
        DangMuon = 25,
        DaHuy = 26,
        ChuaHuy = 27,
        DaGiaoNop = 28,
        ChuaXuLyConHan = 29,
        ChuaXuLyDenHan = 30,
        ChuaXuLyQuaHan = 31,
        DangXuLyConHan = 32,
        DangXuLyDenHan = 33,
        DangXuLyQuaHan = 34,
        DaXuLyConHan = 35,
        DaXuLyDenHan = 36,
        DaXuLyQuaHan = 37,
        DaMat = 38, // Trạng thái đã mất
        KetThucDotTieuHuy = 39,
        DaGiaHanLuuTru = 40,
        ThamTra = 41,
        DaButPhe = 42,
        ChuaButPhe = 43,
        Datrinh = 44,
        DaButPheChuaChuyen = 45,
        ChoVaoSo = 46,
        TuChoiVaoSo = 10, // dành cho văn bản đi chờ vào sổ
        DaSuDung = 10,
        ChuaSuDung = 11,
        Huy = 47,
        TamDung = 48,
        TraLai = 49,
        ThuHoi = 50,//lamtnh
        TaoEmail = 51,
        ChoDuyet2 = 52,
        DaDuyet2 = 53,
        DaChuyenYeuCauTuyenDung = 54,
        ChoDuyetKetThucNVTT = 55,
        TuChoiKetThucNVTT = 56,
        BiKhoa  = 57,
        ChoMoKhoa = 58,
        DaMoKhoa = 59,
    }
}