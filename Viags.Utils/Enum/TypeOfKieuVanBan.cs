using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Viags.Utils
{
    /// <summary>
    /// Kiểu liên quan hiệu lực
    /// </summary>
    public enum KIEU_LIEN_QUAN : int
    {
        VAN_BAN_DUOC_HUONG_DAN = 1,
        VAN_BAN_DUOC_HOP_NHAT = 2,
        VAN_BAN_BI_SUA_DOI_BO_SUNG = 3,
        VAN_BAN_BI_DINH_CHINH = 4,
        VAN_BAN_BI_THAY_THE = 5,
        VAN_BAN_DUOC_DAN_CHIEU = 6,
        VAN_BAN_DUOC_CAN_CU = 7,
        VAN_BAN_BI_THAY_THE_MOT_PHAN = 8,
    }

    /// <summary>
    /// Kiểu được liên quan
    /// </summary>
    public enum KIEU_DUOC_LIEN_QUAN : int
    {
        VAN_BAN_HUONG_DAN = 1,
        VAN_BAN_HOP_NHAT = 2,
        VAN_BAN_SUA_DOI_BO_SUNG = 3,
        VAN_BAN_DINH_CHINH = 4,
        VAN_BAN_THAY_THE = 5,
        VAN_BAN_DAN_CHIEU = 6,
        VAN_BAN_CAN_CU = 7,
        VAN_BAN_THAY_THE_MOT_PHAN = 8,
    }
    /// <summary>
    /// Kiểu được liên quan
    /// </summary>
    public enum KieuVanBan : int
    {
        VanBanDen = 1,
        VanBanDi = 2,
        VanBanNBDen = 3,
        VanBanNBDi = 4,
        ToTrinh = 5,
        CongViec = 6,
    }
}
