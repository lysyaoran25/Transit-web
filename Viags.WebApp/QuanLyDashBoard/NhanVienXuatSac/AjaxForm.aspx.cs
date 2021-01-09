using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Viags.Simple;
using Viags.Data;
namespace Viags.WebApp.QuanLyDashBoard.NhanVienXuatSac
{
    public partial class AjaxForm : Base.BaseWebPage
    {
        NguoiDungDA nguoiDungDA;
        public DashBoardDA dashBoardDA;
        public List<NguoiDungItem> LstNguoiDung { get; set; }
        public NhanVienXuatSacItem NhanVienXuatSac { get; set; }
        public List<int> ListMonth;
        public List<int> ListQuarter;
        public List<int> ListYear;

        public AjaxForm()
        {
            nguoiDungDA = new NguoiDungDA();
            dashBoardDA = new DashBoardDA();
            LstNguoiDung = new List<NguoiDungItem>();
            NhanVienXuatSac = new NhanVienXuatSacItem();
            ListMonth = new List<int>();
            ListQuarter = new List<int> { 1, 2, 3, 4 };
            ListYear = new List<int>();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            LstNguoiDung = nguoiDungDA.GetListNguoiDungTheoDonVi(CurrentUser.DonViID).ToList() ;
            if (ItemID > 0)
            {
                NhanVienXuatSac = dashBoardDA.GetsimpleByID(ItemID);
            }
            for (int i = 1; i < 13; i++)
            {
                ListMonth.Add(i);
            }
            for (int i = 2019; i < 2030; i++)
            {
                ListYear.Add(i);
            }
        }
    }
}