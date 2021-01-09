using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Viags.WebApp
{
    public static class ViagsHtml
    {
        private const string IMAGE_ADD = "/Publishing_Resources/img/LastIcon/add.gif";
        private const string IMAGE_COMMENT = "/Publishing_Resources/img/LastIcon/comment_icon.gif";
        private const string IMAGE_APPROVED = "/Publishing_Resources/img/LastIcon/approved.gif";
        private const string IMAGE_DELETE = "/Publishing_Resources/img/LastIcon/delete.gif";
        private const string IMAGE_Publising = "/Publishing_Resources/img/LastIcon/up.gif";
        private const string IMAGE_UndoPublising = "/Publishing_Resources/img/LastIcon/undopublishing.jpg";
        private const string IMAGE_EDIT = "/Publishing_Resources/img/LastIcon/edit.gif";
        private const string IMAGE_REPLY = "/Publishing_Resources/img/LastIcon/reply.gif";
        private const string IMAGE_PENDING = "/Publishing_Resources/img/LastIcon/pending.jpg";
        private const string IMAGE_REJECT = "/Publishing_Resources/img/LastIcon/reject.gif";
        private const string IMAGE_REPORT = "/Publishing_Resources/img/LastIcon/report.gif";
        private const string IMAGE_VIEW = "/Publishing_Resources/img/LastIcon/view.gif";
        private const string IMAGE_HOT = "/Publishing_Resources/img/LastIcon/hot.gif";
        private const string IMAGE_UP = "/Publishing_Resources/img/LastIcon/up.gif";
        private const string IMAGE_DOWN = "/Publishing_Resources/img/LastIcon/down.gif";
        private const string IMAGE_SHOW = "/Publishing_Resources/img/LastIcon/show_new.gif";
        private const string IMAGE_HIDE = "/Publishing_Resources/img/LastIcon/hide_new.gif";
        private const string IMAGE_BACK = "/Publishing_Resources/img/LastIcon/back.gif";
        private const string IMAGE_FORWARD = "/Publishing_Resources/img/LastIcon/forward.gif";
        private const string IMAGE_WORKFLOW = "/Publishing_Resources/img/LastIcon/workflow.png";
        private const string IMAGE_ADD_DISABLE = "/Publishing_Resources/img/LastIcon/add_disable.gif";
        private const string IMAGE_COMMENT_DISABLE = "/Publishing_Resources/img/LastIcon/comment_icon_disable.gif";
        private const string IMAGE_APPROVED_DISABLE = "/Publishing_Resources/img/LastIcon/approved_disable.gif";
        private const string IMAGE_DELETE_DISABLE = "/Publishing_Resources/img/LastIcon/delete_disable.gif";
        private const string IMAGE_Publising_DISABLE = "/Publishing_Resources/img/LastIcon/up_disable.gif";
        private const string IMAGE_UndoPublising_DISABLE = "/Publishing_Resources/img/LastIcon/undopublishing_disable.jpg";
        private const string IMAGE_EDIT_DISABLE = "/Publishing_Resources/img/LastIcon/edit_disable.gif";
        private const string IMAGE_REPLY_DISABLE = "/Publishing_Resources/img/LastIcon/reply_disable.gif";
        private const string IMAGE_PENDING_DISABLE = "/Publishing_Resources/img/LastIcon/pending_disable.gif";
        private const string IMAGE_REJECT_DISABLE = "/Publishing_Resources/img/LastIcon/reject_disable.gif";
        private const string IMAGE_REPORT_DISABLE = "/Publishing_Resources/img/LastIcon/report_disable.gif";
        private const string IMAGE_VIEW_DISABLE = "/Publishing_Resources/img/LastIcon/view_disable.gif";
        private const string IMAGE_HOT_DISABLE = "/Publishing_Resources/img/LastIcon/hot_disable.gif";
        private const string IMAGE_UP_DISABLE = "/Publishing_Resources/img/LastIcon/up_disable.gif";
        private const string IMAGE_DOWN_DISABLE = "/Publishing_Resources/img/LastIcon/down_disable.gif";
        private const string IMAGE_SHOW_DISABLE = "/Publishing_Resources/img/LastIcon/show_disable_new.gif";
        private const string IMAGE_HIDE_DISABLE = "/Publishing_Resources/img/LastIcon/hide_disable_new.gif";
        private const string IMAGE_BACK_DISABLE = "/Publishing_Resources/img/LastIcon/back_disable.gif";
        private const string IMAGE_FORWARD_DISABLE = "/Publishing_Resources/img/LastIcon/forward_disable.gif";
        private const string IMAGE_WORKFLOW_DISABLE = "/Publishing_Resources/img/LastIcon/workflow_disable.png";
        private const string IMAGE_CONFIGROLE = "/Publishing_Resources/img/LastIcon/configrole.png";
        private const string IMAGE_CONFIG = "/Publishing_Resources/img/LastIcon/config.png";
        private const string IMAGE_MODIFY_KEY = "/Publishing_Resources/img/LastIcon/modify-key-icon.png";

        public static string LabelYesNo(bool yes)
        {
            if (yes)
                return string.Format("<span class=\"label label-success\">Có</span>");
            else
                return string.Format("<span class=\"label label-warning\">Không</span>");
        }
        public static string LabelYesNoFullDuynv(int? trangthai)
        {
            if (trangthai == 1)
                return string.Format("<span class=\"label label-warning\">Mới tạo</span>");
            if (trangthai == 2)
                return string.Format("<span class=\"label label-warning\">Chờ duyệt</span>");
            if (trangthai == 3)
                return string.Format("<span class=\"label label-success\">Đã duyệt</span>");
            if (trangthai == 4)
                return string.Format("<span class=\"label label-success\">Đang xử lý</span>");
            if (trangthai == 5)
                return string.Format("<span class=\"label label-success\">Đã xử lý</span>");
            if (trangthai == 6)
                return string.Format("<span class=\"label label-warning\">Từ chối</span>");
            return string.Format("<span class=\"label label-warning\">Mới tạo</span>");
        }
        public static string LabelYesNo(int? trangthai)
        {
            if (trangthai == 3)
                return string.Format("<span class=\"label label-success\">Duyệt</span>");
            else
                return string.Format("<span class=\"label label-warning\">Chưa duyệt</span>");
        }
        public static string LabelYesNoVBTK(int? trangthai)
        {
            if (trangthai == 12)
                return string.Format("<span class=\"label label-success\">Duyệt</span>");
            if (trangthai == 2)
                return string.Format("<span class=\"label label-success\">Mới tạo</span>");
            if (trangthai == 11)
                return string.Format("<span class=\"label label-success\">Chờ duyệt</span>");
            else
                return string.Format("<span class=\"label label-warning\">Mới tạo</span>");
        }
        /// <summary>
        /// Trạng thái văn bản nội bộ đi
        /// </summary>
        /// <param name="trangthai"></param>
        /// <returns></returns>
        public static string LabelYesNoVBNBDI(int? trangthai)
        {
            if (trangthai == 14)
                return string.Format("<span class=\"label label-warning\">Không được duyệt</span>");
            if (trangthai == 13)
                return string.Format("<span class=\"label label-success\">Đang trình ký</span>");
                if (trangthai == 3)
                    return string.Format("<span class=\"label label-success\">Đã duyệt</span>");
                if (trangthai == 2)
                    return string.Format("<span class=\"label label-warning\">Chờ duyệt</span>");
                if (trangthai == 9)
                    return string.Format("<span class=\"label label-warning\">Mới tạo</span>");
                if (trangthai == 12)
                    return string.Format("<span class=\"label label-success\">Lãnh đạo đã duyệt</span>");
                else return string.Format("<span class=\"label label-warning\">Mới tạo</span>");
        
        }
        /// <summary>
        /// Trạng thái hồ sơ công việc
        /// </summary>
        /// <param name="trangthai"></param>
        /// <returns></returns>
        public static string LabelYesNoHSCV(int? trangthai)
        {
            if (trangthai == 6)
                return string.Format("<span class=\"label label-success\">Đang xử lý</span>");
            if (trangthai == 8)
                return string.Format("<span class=\"label label-success\">Đã quá hạn</span>");
            if (trangthai == 7)
                return string.Format("<span class=\"label label-success\">Đã hoàn thành</span>");
            if (trangthai == 13)
                return string.Format("<span class=\"label label-success\">Đang trình ký</span>");
            if (trangthai == 14)
                return string.Format("<span class=\"label label-success\">Không được duyệt</span>");
            if (trangthai == 9)
                return string.Format("<span class=\"label label-success\">Mới lập</span>");
            else
                return string.Format("<span class=\"label label-success\">Mới lập</span>");
        }
        public static string LabelYesNoDKCV(int? trangthai)
        {
            if (trangthai == 9)
                return string.Format("<span class=\"label label-success\">Mới tạo</span>");
            if (trangthai == 10)
                return string.Format("<span class=\"label label-success\">Từ chối</span>");
            if (trangthai == 2)
                return string.Format("<span class=\"label label-success\">Chờ duyệt</span>");
            else return string.Format("<span class=\"label label-success\">Mới tạo</span>");
        }
        public static string TitleView(int id, string title)
        {
            return string.Format("<a href=\"#{0}\" class=\"view\" title=\"{1}\">{1}</a>", id, HttpContext.Current.Server.HtmlEncode(title));
        }
        public static string TitleView(int id, string title, bool active)
        {
            if (active)
                return string.Format("<a href=\"#{0}\" class=\"view\" title=\"{1}\">{1}</a>", id, HttpContext.Current.Server.HtmlEncode(title));
            else
                return string.Format("<a href=\"javascript:;\" class=\"view_disable\" title=\"{1}\">{1}</a>", id, HttpContext.Current.Server.HtmlEncode(title));
        }

        /// <summary>
        /// View row gridview
        /// </summary>
        /// <param name="id"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        public static string GridView(int id, string title)
        {
            return string.Format("<a href=\"#{0}\" class=\"view\" title=\"{1}\"><img src=\"{2}\" border=\"0\" title=\"Xem: {1}\" /></a>", id, HttpContext.Current.Server.HtmlEncode(title), IMAGE_VIEW);
        }
        public static string GridView(string prams, string title)
        {
            return string.Format("<a href=\"#{0}\" class=\"view\" title=\"{1}\"><img src=\"{2}\" border=\"0\" title=\"Xem: {1}\" /></a>", prams, HttpContext.Current.Server.HtmlEncode(title), IMAGE_VIEW);
        }
        public static string GridView(int id, string title, bool active)
        {
            if (active)
                return string.Format("<a href=\"#{0}\" class=\"view\" title=\"{1}\"><img src=\"{2}\" border=\"0\" title=\"Xem: {1}\" /></a>", id, HttpContext.Current.Server.HtmlEncode(title), IMAGE_VIEW);
            else
                return string.Format("<a href=\"javascript:;\" class=\"view_disable\" title=\"{1}\"><img src=\"{2}\" border=\"0\" title=\"Xem: {1}\" /></a>", id, HttpContext.Current.Server.HtmlEncode(title), IMAGE_VIEW_DISABLE);
        }
        /// <summary>
        /// Edit row gridview
        /// </summary>
        /// <param name="id"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        public static string GridEdit(int id, string title, bool active)
        {
            if (active)
            {
                return string.Format("<a href=\"#{0}\" class=\"edit\" title=\"{1}\"><img src=\"{2}\" border=\"0\"  title=\"Sửa: {1}\" /></a>", id, HttpContext.Current.Server.HtmlEncode(title), IMAGE_EDIT);
            }
            else
            {
                return string.Format("<a href=\"javascript:;\" class=\"edit_disable\" title=\"{1}\"><img src=\"{2}\" border=\"0\"  title=\"Sửa: {1}\" /></a>", id, HttpContext.Current.Server.HtmlEncode(title), IMAGE_EDIT_DISABLE);
            }
        }
        /// <summary>
        /// Edit row gridview
        /// </summary>
        /// <param name="id"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        public static string GridEdit(int id, string title, int? trangthai)
        {
            if (trangthai!=3)
            {
                return string.Format("<a href=\"#{0}\" class=\"edit\" title=\"{1}\"><img src=\"{2}\" border=\"0\" title=\"Sửa: {1}\" /></a>", id, HttpContext.Current.Server.HtmlEncode(title), IMAGE_EDIT);
            }
            else
            {
                return string.Format("<a href=\"javascript:;\" class=\"edit_disable\" title=\"{1}\"><img src=\"{2}\" border=\"0\" title=\"Sửa: {1}\" /></a>", id, HttpContext.Current.Server.HtmlEncode(title), IMAGE_EDIT_DISABLE);
            }
        }
        public static string GridEdit(int id, string title)
        {
            return string.Format("<a href=\"#{0}\" class=\"edit\" title=\"{1}\"><img src=\"{2}\" border=\"0\" title=\"Sửa: {1}\" /></a>", id, HttpContext.Current.Server.HtmlEncode(title), IMAGE_EDIT);
        }
        public static string GridEdit(string prams, string title)
        {
            return string.Format("<a href=\"#{0}\" class=\"edit\" title=\"{1}\"><img src=\"{2}\" border=\"0\" title=\"Sửa: {1}\" /></a>", prams, HttpContext.Current.Server.HtmlEncode(title), IMAGE_EDIT);
        }
        /// <summary>
        /// Show row gridview
        /// </summary>
        /// <param name="id"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        public static string GridShow(int id, string title, bool active)
        {
            if (active)
            {
                return string.Format("<a href=\"#{0}\" class=\"show\" title=\"{1}\"><img src=\"{2}\" border=\"0\" title=\"Hiển thị: {1}\" /></a>", id, HttpContext.Current.Server.HtmlEncode(title), IMAGE_SHOW);
            }
            else
            {
                return string.Format("<a href=\"javascript:;\" class=\"show_disable\" title=\"{1}\"><img src=\"{2}\" border=\"0\" title=\"Hiển thị: {1}\" /></a>", id, HttpContext.Current.Server.HtmlEncode(title), IMAGE_SHOW_DISABLE);
            }
        }
        public static string GridShow(int id, string title)
        {
            return string.Format("<a href=\"#{0}\" class=\"show\" title=\"{1}\"><img src=\"{2}\" border=\"0\" title=\"Hiển thị: {1}\" /></a>", id, HttpContext.Current.Server.HtmlEncode(title), IMAGE_SHOW);
        }
        public static string GridShow(string prams, string title, bool active)
        {
            if (active)
            {
                return string.Format("<a href=\"#{0}\" class=\"show\" title=\"{1}\"><img src=\"{2}\" border=\"0\" title=\"Hiển thị: {1}\" /></a>", prams, HttpContext.Current.Server.HtmlEncode(title), IMAGE_SHOW);
            }
            else
            {
                return string.Format("<a href=\"javascript:;\" class=\"show_disable\" title=\"{1}\"><img src=\"{2}\" border=\"0\" title=\"Hiển thị: {1}\" /></a>", prams, HttpContext.Current.Server.HtmlEncode(title), IMAGE_SHOW_DISABLE);
            }
        }
        public static string GridApproved(int id, string title)
        {
            return string.Format("<a href=\"#{0}\" class=\"approved\" title=\"{1}\"><img src=\"{2}\" border=\"0\" title=\"Duyệt: {1}\" /></a>", id, HttpContext.Current.Server.HtmlEncode(title), IMAGE_APPROVED);
        }
        public static string GridApproved(int id, string title, bool active)
        {
            if (active)
                return string.Format("<a href=\"#{0}\" class=\"approved\" title=\"{1}\"><img src=\"{2}\" border=\"0\" title=\"Xem: {1}\" /></a>", id, HttpContext.Current.Server.HtmlEncode(title), IMAGE_APPROVED);
            else
                return string.Format("<a href=\"javascript:;\" class=\"approved_disable\" title=\"{1}\"><img src=\"{2}\" border=\"0\" title=\"Duyệt: {1}\" /></a>", id, HttpContext.Current.Server.HtmlEncode(title), IMAGE_APPROVED_DISABLE);
        }
        public static string GridApproved(int id, string title, int? TrangThai)
        {
            if (TrangThai != 3)
                return string.Format("<a href=\"#{0}\" class=\"approved\" title=\"{1}\"><img src=\"{2}\" border=\"0\" title=\"Duyệt: {1}\" /></a>", id, HttpContext.Current.Server.HtmlEncode(title), IMAGE_APPROVED);
            else
                return string.Format("<a href=\"javascript:;\" class=\"approved_disable\" title=\"{1}\"><img src=\"{2}\" border=\"0\" title=\"Duyệt: {1}\" /></a>", id, HttpContext.Current.Server.HtmlEncode(title), IMAGE_APPROVED_DISABLE);
        }
        public static string GridPending(int id, string title)
        {
            return string.Format("<a href=\"#{0}\" class=\"pending\" title=\"{1}\"><img src=\"{2}\" border=\"0\" title=\"Hủy duyệt: {1}\" /></a>", id, HttpContext.Current.Server.HtmlEncode(title), IMAGE_PENDING);
        }
        public static string GridPending(int id, string title, bool active)
        {
            if (active)
                return string.Format("<a href=\"#{0}\" class=\"hide\" title=\"{1}\"><img src=\"{2}\" border=\"0\" title=\"Hủy duyệt: {1}\" /></a>", id, HttpContext.Current.Server.HtmlEncode(title), IMAGE_PENDING_DISABLE);
            else
                return string.Format("<a href=\"javascript:;\" class=\"hide_disable\" title=\"{1}\"><img src=\"{2}\" border=\"0\" title=\"Hủy duyệt: {1}\" /></a>", id, HttpContext.Current.Server.HtmlEncode(title), IMAGE_PENDING_DISABLE);
        }
        public static string GridPending(int id, string title, int? trangthai)
        {
            if (trangthai != 2)
                return string.Format("<a href=\"#{0}\" class=\"pending\" title=\"{1}\"><img src=\"{2}\" border=\"0\" title=\"Hủy duyệt: {1}\" /></a>", id, HttpContext.Current.Server.HtmlEncode(title), IMAGE_HIDE);
            else
                return string.Format("<a href=\"javascript:;\" class=\"pending_disable\" title=\"{1}\"><img src=\"{2}\" border=\"0\" title=\"Hủy duyệt: {1}\" /></a>", id, HttpContext.Current.Server.HtmlEncode(title), IMAGE_HIDE_DISABLE);
        }
        /// <summary>
        /// Hide row gridview
        /// </summary>
        /// <param name="id"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        public static string GridHide(int id, string title, bool active)
        {
            if (active)
            {
                return string.Format("<a href=\"#{0}\" class=\"hide\" title=\"{1}\"><img src=\"{2}\" border=\"0\" title=\"Ẩn: {1}\" /></a>", id, HttpContext.Current.Server.HtmlEncode(title), IMAGE_HIDE);
            }
            else
            {
                return string.Format("<a href=\"javascript:;\" class=\"hide_disable\" title=\"{1}\"><img src=\"{2}\" border=\"0\" title=\"Ẩn: {1}\" /></a>", id, HttpContext.Current.Server.HtmlEncode(title), IMAGE_HIDE_DISABLE);
            }
        }
        public static string GridHide(string prams, string title, bool active)
        {
            if (active)
            {
                return string.Format("<a href=\"#{0}\" class=\"hide\" title=\"{1}\"><img src=\"{2}\" border=\"0\" title=\"Ẩn: {1}\" /></a>", prams, HttpContext.Current.Server.HtmlEncode(title), IMAGE_HIDE);
            }
            else
            {
                return string.Format("<a href=\"javascript:;\" class=\"hide_disable\" title=\"{1}\"><img src=\"{2}\" border=\"0\" title=\"Ẩn: {1}\" /></a>", prams, HttpContext.Current.Server.HtmlEncode(title), IMAGE_HIDE_DISABLE);
            }
        }
        public static string GridHide(int id, string title)
        {
            return string.Format("<a href=\"#{0}\" class=\"hide\" title=\"{1}\"><img src=\"{2}\" border=\"0\" title=\"Ẩn: {1}\" /></a>", id, HttpContext.Current.Server.HtmlEncode(title), IMAGE_HIDE);

        }
        /// <summary>
        /// Delete row gridview
        /// </summary>
        /// <param name="id"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        public static string GridDelete(int id, string title)
        {
            return string.Format("<a href=\"#{0}\" class=\"delete\" title=\"{1}\"><img src=\"{2}\" border=\"0\" title=\"Xóa: {1}\" /></a>", id, HttpContext.Current.Server.HtmlEncode(title), IMAGE_DELETE);
        }
        /// <summary>
        /// Delete row gridview
        /// </summary>
        /// <param name="id"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        public static string GridDeleteNguoiDung(string urlpost, string title)
        {
            return string.Format("<a href=\"?{0}\" class=\"deleteNguoiDung\" title=\"{1}\"><img src=\"{2}\" border=\"0\" title=\"Xóa: {2}\" /></a>", urlpost, HttpContext.Current.Server.HtmlEncode(title), IMAGE_DELETE);
        }

        public static string GridDelete(int id, string title, bool active)
        {
            if (active)
                return string.Format("<a href=\"#{0}\" class=\"delete\" title=\"{1}\"><img src=\"{2}\" border=\"0\" title=\"Xóa: {1}\" /></a>", id, HttpContext.Current.Server.HtmlEncode(title), IMAGE_DELETE);
            else
                return string.Format("<a href=\"javascript:;\" class=\"delete_disable\" title=\"{1}\"><img src=\"{2}\" border=\"0\" title=\"{1}\" /></a>", id, HttpContext.Current.Server.HtmlEncode(title), IMAGE_DELETE_DISABLE);
        }
        /// <summary>
        /// Delete multi row gridview
        /// </summary>
        /// <param name="id"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        public static string GridDelete(string arrid, string title)
        {
            return string.Format("<a href=\"#{0}\" class=\"deleteAll\" title=\"{1}\"><img src=\"{2}\" border=\"0\" title=\"Xóa: {1}\" /></a>", arrid, HttpContext.Current.Server.HtmlEncode(title), IMAGE_DELETE);
        }
        /// <summary>
        /// Delete multi row gridview
        /// </summary>
        /// <param name="id"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        public static string GridHide(string arrid, string title)
        {
            return string.Format("<a href=\"#{0}\" class=\"hideAll\" title=\"{1}\"><img src=\"{2}\" border=\"0\" title=\"Ẩn: {1}\" /></a>", arrid, HttpContext.Current.Server.HtmlEncode(title), IMAGE_HIDE);
        }
        /// <summary>
        /// Delete multi row gridview
        /// </summary>
        /// <param name="id"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        public static string GridShow(string arrid, string title)
        {
            return string.Format("<a href=\"#{0}\" class=\"showAll\" title=\"{1}\"><img src=\"{2}\" border=\"0\" title=\"Hiện: {1}\" /></a>", arrid, HttpContext.Current.Server.HtmlEncode(title), IMAGE_SHOW);
        }
        /// <summary>
        /// Duyệt All
        /// </summary>
        /// <param name="id"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        public static string GridApproved(string arrid, string title)
        {
            return string.Format("<a href=\"#{0}\" class=\"approvedAll\" title=\"{1}\"><img src=\"{2}\" border=\"0\" title=\"Duyệt: {1}\" /></a>", arrid, HttpContext.Current.Server.HtmlEncode(title), IMAGE_APPROVED);
        }
        /// <summary>
        /// Hủy duyệt All
        /// </summary>
        /// <param name="id"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        public static string GridPending(string arrid, string title)
        {
            return string.Format("<a href=\"#{0}\" class=\"pendingAll\" title=\"{1}\"><img src=\"{2}\" border=\"0\" title=\"Duyệt: {1}\" /></a>", arrid, HttpContext.Current.Server.HtmlEncode(title), IMAGE_APPROVED);
        }
        /// <summary>
        /// Cấu hình
        /// </summary>
        /// <param name="id"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        public static string Config(int id, string title)
        {
            return string.Format("<a href=\"#{0}\" class=\"config\" title=\"{1}\"><img src=\"{2}\" border=\"0\" title=\"Cấu hình: {1}\" /></a>", id, HttpContext.Current.Server.HtmlEncode(title), IMAGE_CONFIGROLE);
        }
        /// <summary>
        /// Cấu hình
        /// </summary>
        /// <param name="id"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        public static string Config2(int id, string title)
        {
            return string.Format("<a href=\"#{0}\" class=\"config2\" title=\"{1}\"><img src=\"{2}\" border=\"0\" title=\"Cấu hình: {1}\" /></a>", id, HttpContext.Current.Server.HtmlEncode(title), IMAGE_CONFIG);
        }

         /// <summary>
        /// reset pass
        /// </summary>
        /// <param name="id"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        public static string ResetPass(int id, string title)
        {
            return string.Format("<a href=\"#{0}\" class=\"resetpass\" title=\"{1}\"><img src=\"{2}\" border=\"0\" title=\"Đổi mật khẩu: {1}\" /></a>", id, HttpContext.Current.Server.HtmlEncode(title), IMAGE_MODIFY_KEY);
        }
        
    }
}