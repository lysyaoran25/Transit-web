using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Resources;
using System.Reflection;
using System.IO;

namespace WebFormsUtilities.Handlers {

    //Add this to web.config to use this class:
    // Cassini:
    //<add verb="GET,HEAD" path="WFUtilities.axd" type="WebFormsUtilities.Handlers.ScriptResourceHandler, WebFormsUtilities"/>
    // IIS 7:
    //<add name="WebFu" verb="GET,HEAD" path="WFUtilities.axd" type="WebFormsUtilities.Handlers.ScriptResourceHandler, WebFormsUtilities" />
    class ScriptResourceHandler : IHttpHandler {
        #region IHttpHandler Members

        public bool IsReusable {
            get { return true; }
        }

        public void ProcessRequest(HttpContext context) {
            context.Response.ContentType = "text/javascript";
            context.Response.Cache.SetExpires(DateTime.Now.AddYears(1));
            if (!String.IsNullOrEmpty(context.Request["script"])) {
                if (context.Request["script"] == "SetupClientValidation") {
                    context.Response.Write(JSResources.SetupClientValidation);
                } else if (context.Request["script"] == "Utilities") {
                    context.Response.Write(JSResources.WFUtilitiesJquery);
                } else if (context.Request["script"] == "Combine") {
                    context.Response.Write(JSResources.SetupClientValidation);
                    context.Response.Write("\r\n\r\n");
                    context.Response.Write(JSResources.WFUtilitiesJquery);
                } else if (context.Request["script"] == "SetupUnobtrusiveValidation") {
                    context.Response.Write(JSResources.jqueryValidateUnobtrusive);
                }
            }
            
        }

        #endregion
    }
}
