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


        public AjaxFormTaiXe()
        {
            listkhuvuc = new List<KhuVucItem>();
            TransitDA = new TransitDA();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            listkhuvuc = TransitDA.GetListKhuVuc();

            if (ItemID > 0)
            {

            }

        }
    }
}