using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Viags.Simple;
using WebFormsUtilities;
using Viags.Data;
using System.Configuration;

namespace Viags.WebApp.Base
{
    /// <summary>
    /// Class base của tất cả các UserControls.
    /// Tất cả các usercontrols trên project bắt buộc phải thừa kế từ class này.
    /// </summary>
    /// <modified>
    /// Author				    created date					comments
    /// QuangNĐ					04/07/2013				        Tạo mới
    ///</modified>
    public partial class BaseUserControl : System.Web.UI.UserControl
    {
        public NguoiDungSession CurrentUser { get; set; }
        /// <summary>
        /// ID của đối tượng
        /// </summary>
        public int ItemID { get; set; }
        /// <summary>
        /// VanBanNoiBoDenID
        /// </summary>
        public int VanBanNoiBoDenID { get; set; }
        /// <summary>
        /// VanBanDenID
        /// </summary>
        public int VanBanDenID { get; set; }
        public int CongViecID { get; set; }
        /// <summary>
        /// HoSoCongViecID
        /// </summary>
        public int HoSoCongViecID { get; set; }
        /// <summary>
        /// HoSoCongViecConID
        /// </summary>
        public int HoSoCongViecConID { get; set; }
        /// <summary>
        /// LanhDao
        /// </summary>
        public int LanhDao { get; set; }
        /// <summary>
        /// Trạng thái văn bản
        /// </summary>
        public int TrangThaiVanBan { get; set; }
        /// <summary>
        /// ID của đối tượng
        /// </summary>
        public int DonViID { get; set; }
        /// <summary>
        /// Action của form
        /// </summary>
        public string DoAction { set; get; }
        /// <summary>
        /// Tên của action
        /// </summary>
        public string ActionText { get; set; }
        public string IsNoiBo { get; set; }

        /// <summary>
        /// Danh sách phòng ban của người dùng
        /// </summary>
        public List<int> LtsPhongBan { get; set; }
        /// <summary>
        /// string kiểu văn bản search solr
        /// </summary>
        public string TypeVB { get; set; }
        /// <summary>
        /// string từ khóa tìm kiếm solr
        /// </summary>
        public string KeyWordSolr { get; set; }
        public string week { get; set; }
        public string TenDangNhap { get; set; }
        /// <summary>
        /// Kiểu action
        /// </summary>
        public Utils.TypeOfAction ActionType { get; set; }
        /// <summary>
        /// Set text trường hợp là đơn vị và phòng ban trong phân hệ lưu trữ
        /// </summary>
        public bool IsDonViText { get; set; }
        /// <summary>
        /// Hàm load và check quyền của người dùng
        /// </summary>
        /// <modified>
        /// Author				    created date					comments
        /// QuangNĐ					04/07/2013				        Tạo mới
        /// QuangNĐ                 06/07/2013                      Cập nhật code check quyền trên từng trang
        ///</modified>
        private void Load_Permission()
        {

        }
        /// <summary>
        /// Convert xâu có dạng 1,2,3,4 sang list int
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        /// <modified>
        /// Author				    created date					comments
        /// QuangNĐ					05/07/2013				        Tạo mới
        ///</modified>
        public List<int> String2Array(string source)
        {
            List<int> LtsValue = new List<int>();
            if (!string.IsNullOrEmpty(source))
            {
                if (source.Contains(','))
                {
                    LtsValue = source.Split(',').Select(o => Convert.ToInt32(o)).ToList();
                }
                else
                    LtsValue.Add(Convert.ToInt32(source));
            }
            return LtsValue;
        }
        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        public BaseUserControl()
        {

            if (!string.IsNullOrEmpty(HttpContext.Current.Request["do"]))
                DoAction = HttpContext.Current.Request["do"].Trim();
            else
                DoAction = "add";
            #region load action text và action Type
            
            if (!string.IsNullOrEmpty(HttpContext.Current.Request["ItemId"]))
                ItemID = Convert.ToInt32(HttpContext.Current.Request["ItemId"]);
            else
                ItemID = 0;


            if (!string.IsNullOrEmpty(HttpContext.Current.Request["DonViID"]))
                DonViID = Convert.ToInt32(HttpContext.Current.Request["DonViID"]);
            else
                DonViID = 0;
            if (!string.IsNullOrEmpty(HttpContext.Current.Request["VanBanDenID"]))
                VanBanDenID = Convert.ToInt32(HttpContext.Current.Request["VanBanDenID"]);
            else
                VanBanDenID = 0;
            if (!string.IsNullOrEmpty(HttpContext.Current.Request["IsNoiBo"]))
                IsNoiBo = HttpContext.Current.Request["IsNoiBo"];
            else
                IsNoiBo = "0";

            if (!string.IsNullOrEmpty(HttpContext.Current.Request["HoSoCongViecID"]))
                HoSoCongViecID = Convert.ToInt32(HttpContext.Current.Request["HoSoCongViecID"]);
            else
            {
                HoSoCongViecID = 0;
            }
            if (!string.IsNullOrEmpty(HttpContext.Current.Request["HoSoCongViecConID"]))
                HoSoCongViecConID = Convert.ToInt32(HttpContext.Current.Request["HoSoCongViecConID"]);
            else
            {
                HoSoCongViecConID = 0;
            }
            if (!string.IsNullOrEmpty(HttpContext.Current.Request["week"]))
                week = HttpContext.Current.Request["week"];
            else
                week = "";
            #endregion


        }
        /// <summary>
        /// Khởi tạo
        /// </summary>
        /// <param name="e"></param>
        /// <modified>
        /// Author				    created date					comments
        /// QuanLH					05/07/2014				        Tạo mới
        ///</modified>
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            if (HttpContext.Current.Session["VIAG2016"]==null)
            {
                Page.Response.Redirect("/LoginNew.aspx");
            }
            else
            {
                TenDangNhap = HttpContext.Current.User.Identity.Name;
                if (Session["VIAG2016"] == null)
                {
                    string username = HttpContext.Current.User.Identity.Name;  //HttpContext.Current.User.Identity.Name;
                    string password = HttpContext.Current.User.Identity.Name;
                    if (username.Contains("\\"))
                    {
                        username = username.Substring(username.IndexOf("\\") + 1);
                    }
                    Session["VIAG2016"] = new NguoiDungDA().GetThongTinDangNhapCuaNguoiDung(username,password);
                }
            }

            if (Session["VIAG2016"] != null)
            {
                CurrentUser = (NguoiDungSession)Session["VIAG2016"];
                #region Check thông tin IsDonViText

                IsDonViText = CurrentUser.IsVanPhong;

                #endregion
            }
            else
            {
                Page.Response.Redirect("/LoginNew.aspx");
            }


        }
        /// <summary>
        /// Kiểm tra xem người dùng có quyền 
        /// </summary>
        /// <param name="dsQuyen">danh sách quyền</param>
        /// <param name="idQuyen">id quyền</param>
        /// <returns>true or false</returns>
        /// <modified>
        /// Author				    created date					comments
        /// QuanLH					05/07/2014				        Tạo mới
        ///</modified>
        public bool CheckQuyen(string dsQuyen, int idQuyen)
        {
            dsQuyen = "," + dsQuyen + ",";
            if (dsQuyen.Contains("," + idQuyen + ","))
                return true;
            return false;
        }

        /// <summary>
        /// Tự động map tất cả thuộc tính của object thông qua các parrams post
        /// </summary>
        /// <param name="model">Obect cần update</param>
        /// <modified>
        /// Author				    created date					comments
        /// QuangNĐ					05/07/2013				        Tạo mới
        ///</modified>
        public void UpdateModel<TModel>(TModel model)
        {
            WFPageUtilities.UpdateModel(HttpContext.Current.Request, model);
        }
    }
}