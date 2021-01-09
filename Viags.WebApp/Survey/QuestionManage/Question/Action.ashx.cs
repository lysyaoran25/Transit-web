using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using Viags.Data;
using Viags.Utils;

namespace Viags.WebApp.Survey.QuestionManage.Question
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
                    {
                        objMsg = Add();
                        break;
                    }
                case TypeOfAction.Edit:
                    {
                        objMsg = Edit();
                        break;
                    }
                case TypeOfAction.Delete:
                    {
                        objMsg = Delete();
                        break;
                    }
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

        private Message Add()
        {
            return SurveyDA.Add_Question();
        }

        private Message Edit()
        {
            return SurveyDA.Edit_Question();
        }
        private Message Delete()
        {
            return SurveyDA.Delete_Question();
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