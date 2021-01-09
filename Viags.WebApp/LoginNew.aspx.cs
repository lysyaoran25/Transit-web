using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Viags.Base;

namespace Viags.WebApp
{
    public partial class LoginNew : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["VIAG2016"] = null;
            Session.Clear();
            Session.Abandon();
        }
    }
}