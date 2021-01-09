using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using Viags.Data;
using Viags.Simple;
using Viags.Utils;
using Viags.Base;
namespace Viags.WebApp
{
    /// <summary>
    /// Summary description for ActionColumn
    /// </summary>
    public class ActionLogin : BaseDA, IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            if (HttpContext.Current.Request["do"] == "language")
            {
                HttpCookie cookie = new HttpCookie("ngonngu");
                //if (HttpContext.Current.Request["language"] == "ja-JP")
                //{
                //    cookie.Value = "ja-JP";
                //    cookie.Expires = DateTime.Now.AddMonths(6);
                //}
                //else 
                if (HttpContext.Current.Request["language"] == "en-US")
                {
                    cookie.Value = "en-US";
                    cookie.Expires = DateTime.Now.AddMonths(6);
                }
                else
                {
                    cookie.Value = "vi-VN";
                    cookie.Expires = DateTime.Now.AddMonths(6);
                }
                context.Response.SetCookie(cookie);
            }

            NguoiDungSession nguoiDungSession;
            Message objMsg = new Message();
            if (context.Request["do"] == "login")
            {
                string userName = context.Request["Username"];
                string passWord = context.Request["Password"];
                string status = context.Request["Status"];
                NguoiDungDA nguoiDungDA = new NguoiDungDA();
         
                if (String.IsNullOrEmpty(userName))
                {
                    objMsg = new Message()
                    {
                        ID = 0,
                        Error = true,
                        Title = "Bạn chưa nhập tài khoản."
                    };
                }
                else
                {
                    if (String.IsNullOrEmpty(passWord))
                    {
                        objMsg = new Message()
                        {
                            ID = 0,
                            Error = true,
                            Title = "Bạn chưa nhập mật khẩu."
                        };
                    }
                    else
                    {                      
                      
                       
                            if (userName.ToLower() == "administrator" || userName.ToLower().EndsWith("|dev"))
                            {
                                if (userName.ToLower().EndsWith("|dev"))
                                {
                                    userName = userName.Split('|')[0];
                                }
                                nguoiDungSession = nguoiDungDA.GetThongTinDangNhapCuaNguoiDung(userName, passWord);

                                if (nguoiDungSession.ID == 0)
                                {
                                    objMsg = new Message()
                                    {
                                        ID = 0,
                                        Error = false,
                                        Title = "Người dùng không tồn tại trên hệ thống"
                                    };
                                }
                                else
                                {
                                    if (nguoiDungSession.ID != 0)
                                    {
                                        context.Session["VIAG2016"] = nguoiDungSession;
                                        objMsg = new Message()
                                        {
                                            ID = 0,
                                            Error = false,
                                        };
                                    
                                            objMsg.Title = "false";
                                        
                                        //nguoiDungDA.AddLog(Utils.Enum.LogTypes.Login, nguoiDungSession.ID, string.Format("{0} đăng nhập lúc {1}", nguoiDungSession.TenHienThi, DateTime.Now), null, nguoiDungSession.DonViID, "Đăng nhập", nguoiDungDA.IPAddress);
                                        //nguoiDungDA.AddCamXuc(nguoiDungSession, Convert.ToInt32(status));

                                    }
                                    else
                                    {
                                        objMsg = new Message()
                                        {
                                            ID = 0,
                                            Error = true,
                                            Title = "Tài khoản hoặc mật khẩu không chính xác."
                                        };
                                    }
                                }


                            }
                            else
                            {
                                objMsg = new Message()
                                {
                                    ID = 0,
                                    Error = false,
                                    Title = "Tài khoản hoặc mật khẩu không chính xác."
                                };
                            }

                        

                    }
                }

            }
            context.Response.ContentType = "application/json";
            context.Response.Write(JsonConvert.SerializeObject(objMsg));
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        public bool CheckQuyen(string dsQuyen, int idQuyen)
        {
            dsQuyen = "," + dsQuyen + ",";
            return dsQuyen.Contains("," + idQuyen + ",");
        }
    }
}