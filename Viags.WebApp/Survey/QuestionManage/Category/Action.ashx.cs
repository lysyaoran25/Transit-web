using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using Viags.Data;
using Viags.Simple;
using Viags.Utils;

namespace Viags.WebApp.Survey.QuestionManage.Category
{
    /// <summary>
    /// Summary description for Action
    /// </summary>
    public class Action : Base.BaseAction, IHttpHandler, IRequiresSessionState
    {
        SurveyDA SurveyDA = new SurveyDA();
        public void ProcessRequest(HttpContext context)
        {
            Message objMsg = new Message();
            switch (Action)
            {
                //Thêm mới 
                case TypeOfAction.Add:
                    objMsg = Add();
                    break;
                // Cập nhật 
                case TypeOfAction.Edit:
                    objMsg = Edit();
                    break;
                // Xóa
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
            return SurveyDA.Add_Category();
        }
        public Message Edit()
        {
            return SurveyDA.Edit_Category();
        }
        public Message Delete()
        {
            return SurveyDA.Delete_Category();
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