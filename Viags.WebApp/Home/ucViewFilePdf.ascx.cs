using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Viags.WebApp.Home
{
    public partial class ucViewFilePdf : Base.BaseUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UploadFileService.UploadFile uploadFile = new UploadFileService.UploadFile();
            string filePath = HttpContext.Current.Request["UrlFile"];
            string fileName = HttpContext.Current.Request["FileName"];
            if (!string.IsNullOrEmpty(filePath))
            {
                if (filePath.Contains("ajaxUpload"))
                {
                    filePath = filePath.Replace("ajaxUpload", "");
                }

                try
                {
                    
                    byte[] data = uploadFile.ReadFileData(filePath);
                    Response.ContentType = "application/pdf";
                    Response.AddHeader("Content-Disposition", "attachment; filename=" +fileName);
                    Response.AddHeader("content-length", data.Length.ToString());
                    Response.BinaryWrite(data);
                    Response.End();
                }
                catch (Exception ex)
                {
                    Page.Response.Write("File not found: " + ex.Message);
                }
            }
        }
    }
}