using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Viags.WebApp.Transit
{
    /// <summary>
    /// Summary description for Action
    /// </summary>
    public class Action : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write("Hello World");
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