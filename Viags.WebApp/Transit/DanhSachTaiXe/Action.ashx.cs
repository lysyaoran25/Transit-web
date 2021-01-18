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
        TransitDA TransitDA = new TransitDA();
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
            return TransitDA.Add();
        }
        public Message Edit()
        {
            return TransitDA.Edit();
        }
        public Message Delete()
        {
            return TransitDA.Delete();
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