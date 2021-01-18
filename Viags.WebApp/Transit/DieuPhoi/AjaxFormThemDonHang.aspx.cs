using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Viags.Data;
using Viags.Simple;
using Viags.Utils;

namespace Viags.WebApp.Transit.DieuPhoi
{
    public partial class AjaxFormThemDonHang : Base.BaseWebPage
    {
        public List<KhuVucItem> listkhuvuc;
        protected static TransitDA TransitDA;


        public AjaxFormThemDonHang()
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
        [WebMethod]
        public static object ChangeKhuVuc(string stringKhuvucid)
        {
            try
            {
                var xx = HttpContext.Current.Request["dayofweek"];
                var dayofweek = (string.IsNullOrEmpty(HttpContext.Current.Request["dayofweek"]) || HttpContext.Current.Request["dayofweek"] == "NaN") ? ((int)DateTime.Now.DayOfWeek + 6) % 7 : int.Parse(HttpContext.Current.Request["dayofweek"]);

                var khuvucid = int.Parse(stringKhuvucid);
                if (khuvucid != 0)
                {
                    var listchuyen = TransitDA.GetListDanhMucChuyen(khuvucid, dayofweek);
                    var list = TransitDA.GetListPhuongXa(khuvucid);
                    return new ListTemp()
                    {
                        LstPhuongXaItem = list,
                        LstDanhMucChuyenItem = listchuyen,

                    };
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                return null;
            }


        }

        [WebMethod]
        public static object ChangePhuongXa(string stringPhuongXaid)
        {
            try
            {
                var phuongxaid = int.Parse(stringPhuongXaid);
                if (phuongxaid != 0)
                {
                    var list = TransitDA.GetListDuongAp(phuongxaid);
                    return list;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                return null;
            }


        }

        [WebMethod]
        public static object ChangeThoiGianKhoiHanh(string stringKhuvucid)
        {
            try
            {
                var xx = HttpContext.Current.Request["dayofweek"];
                var dayofweek = (string.IsNullOrEmpty(HttpContext.Current.Request["dayofweek"]) || HttpContext.Current.Request["dayofweek"] == "NaN") ? ((int)DateTime.Now.DayOfWeek + 6) % 7 : int.Parse(HttpContext.Current.Request["dayofweek"]);

                var khuvucid = int.Parse(stringKhuvucid);
                if (khuvucid != 0)
                {
                    var listchuyen = TransitDA.GetListDanhMucChuyen(khuvucid, dayofweek);

                    return new ListTemp()
                    {

                        LstDanhMucChuyenItem = listchuyen,

                    };
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                return null;
            }


        }

    }
}