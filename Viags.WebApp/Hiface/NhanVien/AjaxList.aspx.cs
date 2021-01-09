using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Viags.Base;
using Viags.Simple;
using Viags.Utils;
using Viags.Data;
using System.Web.Services;
using System.Web.Script.Services;
using RestSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Viags.WebApp.Hiface.NhanVien
{
    public partial class AjaxList : Base.BaseWebPage
    {
        //private string TIME_START_WORK = "0800";
        //private string TIME_END_WORK = "1730";
        //private string TIME_START_FREE = "1200";
        //private string TIME_END_FREE = "1330";
        //private string START_WORK_LIMIT_START = "15";
        //private string START_WORK_LIMIT_END = "15";


        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static string SyncUserHiface()
        {
            var client = new RestClient("http://hiface.tinhvan.com/subject/list?size=99999999&category=employee");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", "b990b346-e791-41d5-9e07-590764708819");
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);





            #region [sdsa]
            //using (var context = new FoldioContext())
            //{
            //    GetCurrentUser();
            //    Message objMsg;

            //    try
            //    {
            //        var request_maso = !String.IsNullOrEmpty(HttpContext.Current.Request["MaSo"]) ? HttpContext.Current.Request["MaSo"].ToLower().Trim() : String.Empty;
            //        if (request_maso != String.Empty && context.DanhMucXe.FirstOrDefault(x => x.MaSo.ToLower().Equals(request_maso)) != null)
            //        {
            //            throw new Exception("Số xe đã tồn tại! Xin vui lòng nhập lại");
            //        }
            //        var danhMucXe = new DanhMucXe();
            //        var taixe = int.Parse(Request["TaiXe"]);
            //        var soluong = int.Parse(Request["SoLuong"]);
            //        UpdateModel(danhMucXe);
            //        if (!string.IsNullOrEmpty(HttpContext.Current.Request["DinhMucTieuHaoText"]))
            //        {
            //            danhMucXe.DinhMucTieuHao = Convert.ToDecimal(HttpContext.Current.Request["DinhMucTieuHaoText"].Replace(".", ","));
            //        }
            //        danhMucXe.TaiXeID = taixe;
            //        danhMucXe.SoLuongChoPhep = soluong;
            //        danhMucXe.ThuTu = new DanhMucXeDA().GetMaxOrder();
            //        danhMucXe.NgayTao = DateTime.Now;
            //        danhMucXe.NguoiTaoID = CurrentUser.ID;
            //        danhMucXe.DonViID = danhMucXe.DonViID == null || danhMucXe.DonViID == 0 ? CurrentUser.DonViChaID : danhMucXe.DonViID;
            //        context.DanhMucXe.Add(danhMucXe);

            //        context.SaveChanges();

            //        objMsg = new Message()
            //        {
            //            Error = false,
            //            Title = string.Format("" + HttpContext.GetGlobalResourceObject("Other", "lblThemMoiDanhMucXe") + ": <b>{0}</b> " + HttpContext.GetGlobalResourceObject("Other", "lblThanhCong") + "", HttpUtility.HtmlEncode(danhMucXe.Ten)),
            //            ID = danhMucXe.ID
            //        };

            //        #region Log
            //        AddLog(LogTypes.Add, CurrentUser.ID, danhMucXe.Ten, Viags.Utils.LinkModule.DanhMucXe + "?ItemID=" + danhMucXe.ID, CurrentUser.DonViID, "Danh mục xe", IPAddress);
            //        #endregion Log

            //    }
            //    catch (Exception ex)
            //    {
            //        objMsg = new Message()
            //        {
            //            Error = true,
            //            Title = ex.Message,
            //        };
            //    }
            //    return objMsg;
            //}
            #endregion


            return listevent;
        }

        private static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }


    }


}