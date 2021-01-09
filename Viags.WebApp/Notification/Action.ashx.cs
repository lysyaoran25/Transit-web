using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Viags.WebApp.Base;
using Viags.Utils;
using Newtonsoft.Json;
using System.Web.SessionState;
using Viags.Data;

namespace Viags.WebApp.Notification
{
    /// <summary>
    /// Summary description for Action
    /// </summary>
    public class Action : BaseAction, IHttpHandler, IRequiresSessionState
    {
        NotificationDA notificationDA = new NotificationDA();
        public void ProcessRequest(HttpContext context)
        {
            Message objMsg = new Message();
            switch (Action)
            {
                case Utils.TypeOfAction.Delete:
                    objMsg = Delete();
                    break;
                case Utils.TypeOfAction.Request:
                    objMsg = ReadNotification();
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

        public Message Delete()
        {
            return notificationDA.Delete();
        }

        /// <summary>
        /// Đọc thông báo
        /// </summary>
        /// <returns></returns>
        public Message ReadNotification()
        {
            return notificationDA.ReadNotification();
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