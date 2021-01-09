using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.ComponentModel;
using System.Web.Services;
using System.Reflection;
using WebFormsUtilities.Json;

namespace WebFormsUtilities.WebControls {
    /// <summary>
    /// Expose web methods on the page by creating functions for them on the webfu.page object.<br/>
    /// [WebMethod]'s will be called using jQuery AJAX. page.&lt;methodName&gt; calls synchronously.<br/>
    /// page.&lt;methodNameAsync&gt; calls asynchronously.<br/>
    /// When calling async methods, the first two parameters are "success" and "error" callbacks. ie:<br/>
    /// page.&lt;methodNameAsync&gt;(function() { /* success */ }, function() { /* failure */ }, arg1, arg2...);<br/>
    /// [WFJScriptMethod]'s will be called by doing a form submission. Page_Load must call WFPageUtilities.CallJSMethod();
    /// </summary>
    [ToolboxData("<{0}:ExposeWebMethodsControl runat=server></{0}:ExposeWebMethodsControl>")]
    public class ExposeWebMethodsControl : WebControl {

        public bool ReturnSimpleString { get; set; }

        protected override void RenderContents(HtmlTextWriter output) {

            List<MethodInfo> webmethods = this.Page.GetType().BaseType.GetMethods(BindingFlags.Public | BindingFlags.Static)
                .Where(m => m.GetCustomAttributes(false).OfType<WebMethodAttribute>().Count() > 0).ToList();

            List<MethodInfo> jsmethods = this.Page.GetType().GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                .Where(m => m.GetCustomAttributes(false).OfType<WFJScriptMethodAttribute>().Count() > 0).ToList();

            JSONObject pageJSO = new JSONObject();

            foreach (MethodInfo mi in webmethods) {
                string argCSV = "";
                string argJSON = "";
                JSONObject argObject = new JSONObject();

                foreach (ParameterInfo pi in mi.GetParameters()) {
                    argCSV += argCSV == "" ? pi.Name : "," + pi.Name;
                    argObject.Attr(pi.Name, new JSONObjectLiteral() { Value = pi.Name });
                }

                argJSON = argObject.Render();

                pageJSO.Attr(mi.Name, new JSONObjectLiteral() {
                    Value = "function(" + argCSV + "){"
                    + "var retObj;"
                    + "webfu.callPage(\"" + Page.Request.CurrentExecutionFilePath + "/" + mi.Name + "\",{"
                    + "data:" + argJSON + ","
                    + "success:function(msg){ retObj = msg;"
                    + "},"
                    + "async:false,"
                    + "error:function(a) { throw a.responseText; }"
                    + (ReturnSimpleString ? "}); return retObj.d;}" : "}); return retObj;}")
                });

                pageJSO.Attr(mi.Name + "Async", new JSONObjectLiteral() {
                    Value = "function(successCallBack,errorCallBack," + argCSV + "){"
                    + "webfu.callPage(\"" + Page.Request.CurrentExecutionFilePath + "/" + mi.Name + "\",{"
                    + "data:" + argJSON + ","
                    + (ReturnSimpleString ? "success:function(a,b,c) { successCallBack(a.d,b,c); },error:errorCallBack,async:true"
                                    : "success:successCallBack,error:errorCallBack,async:true")
                    + "}); }"
                });
            }
            foreach (MethodInfo mi in jsmethods) {
                pageJSO.Attr(mi.Name, new JSONObjectLiteral() {
                    Value = "function(){"
                    + "webfu.submitForm('" + mi.Name + "');"
                    + "}"
                });
            }

            output.Write("<script>this.webfu = this.webfu || {}; webfu.page = " + pageJSO.Render() + ";</script>");

        }

    }
}
