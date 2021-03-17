using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Viags.Data;
using Viags.Simple;

namespace Viags.WebApp.Transit.DanhSachTaiXe
{
    public partial class AjaxFormTaiXe : Base.BaseWebPage
    {
        public List<KhuVucItem> listkhuvuc;
        protected static TransitDA TransitDA;
        public List<int> ListYear;
        protected ThongTinTaiXe ThongTinTaiXe;

        public AjaxFormTaiXe()
        {
            ListYear = new List<int>();
            listkhuvuc = new List<KhuVucItem>();
            TransitDA = new TransitDA();
            ThongTinTaiXe = new ThongTinTaiXe();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            for (int i = 1965; i <= DateTime.Now.Year - 18; i++)
            {
                ListYear.Add(i);
            }

            listkhuvuc = TransitDA.GetListKhuVuc();

            if (ItemID > 0)
            {
                ThongTinTaiXe = TransitDA.GetSimpleByID_TaiXe(ItemID);
            }

        }
    }
}