namespace Viags.Utils.Enum
{
    /// <summary>
    /// Kiểu thao tác
    /// </summary>
    /// Author				created date					comments
    /// QuanLH				05/08/2013					    Tạo mới
    public enum LogTypes
    {
        View = 1,
        Add = 2,
        Update = 3,
        Delete = 4,
        Approved = 5,
        Reject = 6,
        Comment = 7,
        Send = 8,
        GetAll = 0,
        DeleteSend = 9,
        Registed = 10,
        Forward = 11,
        Distribute = 12,
        AddPXL = 13,
        EditPXL = 14,
        SaveWorkFlow = 15,
        Hide = 16,
        Show = 17,
        AddExist = 18,
        ChangePass = 19,
        CAS = 20,
        Login = 21,
        Signout = 22,
        Progress = 23,
        Pending = 24,
        AddVB = 25, //thêm văn bản liên quan
        DeleteVB = 26, //Xóa văn bản liên quan
        AddCV = 27, //thêm công việc liên quan
        DeleteCV = 28, //Xóa công việc liên quan
        Finish = 29,
        Request = 30,
        Confirm = 31,
        ChangeDeadLine = 32,
        BanGiao = 33,
        TiepNhan = 34,
        KhongTiepNhan = 35,
        BienMuc = 36, //biên mục tài liệu nộp lưu
        DongHopCap = 37,
        MoHopCap = 38,
        TrinhTheThuc = 39,
        CapNhatHoSo = 40,// cập nhật hồ sơ từ hệ thống quản lý văn bản => sang hồ sơ lưu trữ
        DuyetTheThuc = 41,
        TieuHuyVatLy = 42,
        ThuHoi =43,
        DanhGia=44,
    }
}