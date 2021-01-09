using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Viags.Data;
using Viags.Utils;
using Viags.Simple;

namespace Viags.WebApp.Notification
{
    public partial class pListAllThongBao : Base.BaseWebPage
    {
        public List<Simple.NotificationItem> LtsNotification { get; set; }

        NotificationDA notificationDA;
        public pListAllThongBao()
        {
            notificationDA = new NotificationDA();
            LtsNotification = new List<Simple.NotificationItem>();
        }
        /// <summary>
        /// Hàm lấy danh sách notification
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            LtsNotification = notificationDA.GetListAllThongBaoTheoNguoiDung(CurrentPage, RowPerPage, Field, FieldOption, Keyword, SearchInFiled, CurrentUser.ID);
            HtmlPager =
               Viags.Utils.HtmlPager.getPage(
                   string.Format("#RowPerPage={0}&PageStep={1}&Field={2}&FieldOption={3}&Keyword={4}&SearchIn={5}&Page=", RowPerPage, PageStep,
                                 Field, (FieldOption) ? 0 : 1, Keyword, string.Join(",", SearchInFiled.ToArray())), CurrentPage, RowPerPage, notificationDA.TotalRecord);
        }
    }
}