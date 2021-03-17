using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using Viags.Data;
using Viags.Utils;

namespace Viags.WebApp.Transit.DanhSachTaiXe
{
    /// <summary>
    /// Summary description for Action
    /// </summary>
    public class Action : Base.BaseAction, IHttpHandler, IRequiresSessionState
    {
        Transit_TaiXeDA Transit_TaiXeDA = new Transit_TaiXeDA();
        public void ProcessRequest(HttpContext context)
        {
            Message objMsg = new Message();
            switch (Action)
            {
                case TypeOfAction.Add:
                    objMsg = Add();
                    break;
                case TypeOfAction.Edit:
                    objMsg = Edit();
                    break;
                case TypeOfAction.Delete:
                    objMsg = Delete();
                    break;

                default:
                    objMsg = new Message()
                    {
                        Error = true,
                        Title = "Bạn chưa chọn thao tác nào."
                    };
                    break;
            }
            context.Response.ContentType = "application/json";
            context.Response.Write(JsonConvert.SerializeObject(objMsg));
        }
        public Message Add()
        {
            return Transit_TaiXeDA.Add();
        }
        public Message Edit()
        {
            return Transit_TaiXeDA.Edit();
        }
        public Message Delete()
        {
            return Transit_TaiXeDA.Delete();
        }


        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}