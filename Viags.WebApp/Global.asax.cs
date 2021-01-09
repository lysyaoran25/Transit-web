using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using SolrNet;
using System.Web.Http;
using System.Web.Routing;
//using Viags.WebApp.Scheduler;

namespace Viags.WebApp
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            Application["OnlineUsers"] = 0;
            GlobalConfiguration.Configure(WebApiConfig.Register);
            //JobScheduler.Start();
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            Application.Lock();
            Application["OnlineUsers"] = (int)Application["OnlineUsers"] + 1;
            Application.UnLock();
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            CultureInfo ci = new CultureInfo("vi-VN");
            ci.DateTimeFormat.SetAllDateTimePatterns(
                new string[] { "dd/MM/yyyy" },
                'd'
            );
            System.Threading.Thread.CurrentThread.CurrentCulture = ci;
            System.Threading.Thread.CurrentThread.CurrentUICulture = ci;

            // Code that runs on application startup                                                            
            HttpCookie cookie = HttpContext.Current.Request.Cookies["ngonngu"];
            if (cookie != null && cookie.Value != null)
            {
                CultureInfo ciCustom = new CultureInfo(cookie.Value);
                ciCustom.DateTimeFormat.SetAllDateTimePatterns(
                    new string[] { "dd/MM/yyyy" },
                    'd'
                );
                System.Threading.Thread.CurrentThread.CurrentUICulture = ciCustom;
                System.Threading.Thread.CurrentThread.CurrentCulture = ciCustom;
            }
            else
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = ci;
                System.Threading.Thread.CurrentThread.CurrentCulture = ci;
            }

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {
            Application.Lock();
            Application["OnlineUsers"] = (int)Application["OnlineUsers"] - 1;
            Application.UnLock();
        }

        protected void Application_End(object sender, EventArgs e)
        {

        }

        void Application_PreRequestHandlerExecute(object sender, EventArgs e)
        {
            //if (Context.Session != null && Context.Session["language"] != null)
            //{
            //    String selectedLanguage = Context.Session["language"].ToString().ToLower();
            //    String currentLanguage = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName.ToLower();
            //    if (!currentLanguage.Equals(selectedLanguage))
            //    {
            //        //System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo(selectedLanguage);
            //        System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo(selectedLanguage.Trim());
            //        System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo(selectedLanguage.Trim());
            //    }
            //}
        }
    }
}