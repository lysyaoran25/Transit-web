using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Viags.Data;
using Viags.Simple;

namespace Viags.WebApp.Transit
{
    public partial class ucTransit : Base.BaseUserControl    {

        public List<KhuVucItem> listkhuvuc = new List<KhuVucItem>();
        protected TransitDA TransitDA = new TransitDA();
        public int NguoidungID = 0;
        public int Ngay = 1;
        public int Thang = 1;
        public int Nam = 2020;
        public string TenNGuoiDung = string.Empty;
     

        public string nguoinhan = string.Empty;
        NguoiDungDA nguoiDungDA = new NguoiDungDA();
       
 

        protected int Tab = 1;

        protected void Page_Load(object sender, EventArgs e)
        {

            listkhuvuc = TransitDA.GetListKhuVuc();
   
            Tab = string.IsNullOrEmpty(Request["Tab"]) ? 1 : Convert.ToInt32(Request["Tab"]);
            Ngay = string.IsNullOrEmpty(Request["Ngay"]) ? DateTime.Now.Day : Convert.ToInt32(Request["Ngay"]);     
            Thang = string.IsNullOrEmpty(Request["Thang"]) ? DateTime.Now.Month : Convert.ToInt32(Request["Thang"]);
            Nam = string.IsNullOrEmpty(Request["Nam"]) ? DateTime.Now.Year : Convert.ToInt32(Request["Nam"]);
            //ListDonVi = donViDA.GetListDonViChiNhanh();

        }
    }
}