using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Viags.Simple;

namespace Viags.WebApp
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                //HttpCookie cookie = Request.Cookies["ngonngu"];
                //if (cookie != null && cookie.Value != null)
                //{
                //    if (cookie.Value.IndexOf("en-") >= 0)
                //    {
                //        ImgBtn_En.Enabled = false;
                //        ImgBtn_Vi.Enabled = true;
                //    }
                //    else
                //    {
                //        if (cookie.Value.IndexOf("vi-") >= 0)
                //        {
                //            ImgBtn_En.Enabled = true;
                //            ImgBtn_Vi.Enabled = false;
                //        }
                //    }
                //}
                //else
                //{
                //    HttpCookie cookiee = new HttpCookie("ngonngu");
                //    cookiee.Value = "vi-VN";
                //    cookiee.Expires = DateTime.Now.AddMonths(6);
                //    Response.SetCookie(cookiee);
                //}
                HttpCookie cookiee = new HttpCookie("ngonngu");
                cookiee.Value = "vi-VN";
                cookiee.Expires = DateTime.Now.AddMonths(6);
                Response.SetCookie(cookiee);
            }
        }

        //protected void ImgBtn_Vi_Click(object sender, ImageClickEventArgs e)
        //{
        //    HttpCookie cookie = new HttpCookie("ngonngu");
        //    cookie.Value = "vi-VN";
        //    cookie.Expires = DateTime.Now.AddMonths(6);
        //    Response.SetCookie(cookie);
        //    Response.Redirect(Request.RawUrl);
        //}

        //protected void ImgBtn_En_Click(object sender, ImageClickEventArgs e)
        //{
        //    HttpCookie cookie = new HttpCookie("ngonngu");
        //    cookie.Value = "en-US";
        //    cookie.Expires = DateTime.Now.AddMonths(6);
        //    Response.SetCookie(cookie);
        //    Response.Redirect(Request.RawUrl);
        //}
        
    }
}