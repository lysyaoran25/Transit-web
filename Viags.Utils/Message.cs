using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Viags.Utils
{
    /// <summary>
    /// Đối tượng đóng gói các thông báo khi thêm, sửa, xóa...
    /// </summary>
    /// <modified>
    /// Author				    created date					comments
    /// QuangNĐ					05/07/2013				        Tạo mới
    ///</modified>
    public class Message
    {
        /// <summary>
        /// ID của bản ghi được thêm, sửa, xóa
        /// </summary>
        public int? ID { get; set; }
        /// <summary>
        /// Thông báo
        /// </summary>
        public string Title { get; set; }

        public string TitleAPI { get; set; }

        /// <summary>
        /// Có lỗi hay không có lỗi
        /// </summary>
        public bool Error { get; set; }

        /// <summary>
        /// Kiểm tra dịch ngôn ngữ trang
        /// </summary>
        public bool Translate { get; set; }

        /// <summary>
        /// Đối tượng attach kèm theo thông báo
        /// </summary>
        public object Obj { get; set; }
        public int SoVanBanID { get; set; }
        public string CoQuanBanHanh { get; set; }
        public string TenTruyCap { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }
        public int? CongViecConID { get; set; }

        public int SoTrang { get; set; }
        public int SoDong { get; set; }
    }
}
