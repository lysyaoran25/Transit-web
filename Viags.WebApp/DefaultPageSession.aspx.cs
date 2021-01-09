using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Viags.WebApp
{
    public partial class DefaultPageSession : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod(EnableSession = true)]
        public static void RefreshSession()
        {
            System.Diagnostics.Debug.WriteLine("Session Refreshed At" + DateTime.Now.ToString() + ".");
        }
    }
}