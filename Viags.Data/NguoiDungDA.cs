using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Viags.Base;
using Viags.Utils;
using Viags.Simple;
using System.Configuration;
using System.Web;
using System.DirectoryServices.AccountManagement;
using System.Transactions;
using Viags.Utils.Enum;
using System.Globalization;
using System.IO;
using Viags.Data.UploadFileServices;

namespace Viags.Data
{
    public class NguoiDungDA : BaseDA
    {
        /// <summary>
        /// Thông tin lấy từ web config
        /// </summary>
        public static string sUser = ConfigurationSettings.AppSettings["ADUser"];
        public static string sPass = ConfigurationSettings.AppSettings["ADPassword"];
        public static string sPath = ConfigurationSettings.AppSettings["ADPathLDAP"];
        public static string sServerType = ConfigurationSettings.AppSettings["ADPath"];


        public string domain = ConfigurationManager.AppSettings["ADDomain"];
        public string strFullName = ConfigurationManager.AppSettings["FullPCName"];
        public string strADPath = ConfigurationManager.AppSettings["ADPath"];
        public string strAdUserNameAdmin = ConfigurationManager.AppSettings["ADUser"];
        public string strADpassWordAdmin = ConfigurationManager.AppSettings["ADPassword"];
        public string DC = ConfigurationManager.AppSettings["DC"];
        public const string SPDefaultUserGroup = @"Quản lý văn bản và điều hành tác nghiệp Acecook Members";
        // Khởi tạo đối tượng Ldap
        public string UrlSite = ConfigurationManager.AppSettings["UrlSite"];
        public string UrlUpload = ConfigurationManager.AppSettings["UrlUpload"];



        public NguoiDungDA() : base(HttpContext.Current) { }
        /// <summary>
        /// Thêm mới người dùng
        /// </summary>
        /// <returns>Message</returns>
        /// <modified>
        /// Author				    created date					comments
        /// QuanLH					05/07/2013				        Tạo mới
        ///</modified>
        public Message Add()
        {
            using (var context = new FoldioContext())
            {
                GetCurrentUser();
                NguoiDung nguoidung = new NguoiDung(); // Entity Trong database
                var PhongBanDonViNguoiDung = new Base.NguoiDungDonViNhomNguoiDung();
                int DonViID = int.Parse(Request.Params["DonViID"]);
                var commentLDAP = string.Empty;
                UpdateModel(nguoidung);
                int NhomNguoiDungID = 0;
                if (!string.IsNullOrEmpty(HttpContext.Current.Request["NhomNguoiDungID"]))
                {
                    NhomNguoiDungID = Convert.ToInt32(HttpContext.Current.Request["NhomNguoiDungID"]);
                }

                Message objMsg;
                try
                {
                    using (var ts = new TransactionScope())
                    {
                        if (DonViID == 0) //Nếu tồn tại rồi
                        {
                            objMsg = new Message()
                            {
                                ID = nguoidung.ID,
                                Title = string.Format(HttpContext.GetGlobalResourceObject("Other", "lblBanChuaChonDonVi").ToString()),
                                Error = true
                            };
                            return objMsg;
                        }
                        if (nguoidung.NgaySinh.HasValue)
                        {
                            if (nguoidung.NgaySinh.Value >= DateTime.Now)
                            {
                                objMsg = new Message()
                                {
                                    ID = nguoidung.ID,
                                    Title = string.Format(HttpContext.GetGlobalResourceObject("Other", "lblNgaySinhKhongDuocLonHonNgayHienTai").ToString() + "."),
                                    Error = true
                                };
                                return objMsg;
                            }
                        }
                        if (CheckExist(nguoidung)) //Nếu tồn tại rồi
                        {
                            objMsg = new Message()
                            {
                                ID = nguoidung.ID,
                                Title = string.Format(HttpContext.GetGlobalResourceObject("Other", "lblNguoiDung").ToString() + ": <b>{0}</b> " + HttpContext.GetGlobalResourceObject("Other", "lblDaTonTai").ToString() + ".", nguoidung.TenTruyCap),
                                Error = true
                            };
                            return objMsg;
                        }
                        else if (nguoidung.IsLargest.HasValue && nguoidung.IsLargest == true && CheckIsLarget(DonViID, 0)) //Nếu tồn tại rồi
                        {
                            objMsg = new Message()
                            {
                                ID = nguoidung.ID,
                                Title = string.Format(HttpContext.GetGlobalResourceObject("Other", "lblPhongBanDonViDaCoViTriLonNhat").ToString()),
                                Error = true
                            };
                        }
                        nguoidung.TenHienThi = Viags.Utils.Utility.TrimAllSpace(nguoidung.TenHienThi);

                        nguoidung.Ten = Viags.Utils.Utility.TrimAllSpace(nguoidung.Ten);
                        nguoidung.Ho = Viags.Utils.Utility.TrimAllSpace(nguoidung.Ho);
                        if (!string.IsNullOrEmpty(HttpContext.Current.Request["listValueFileAttach"]))
                        {
                            if (HttpContext.Current.Request["listValueFileAttach"].Equals("avatar-default"))
                            {
                                nguoidung.AnhData = null;
                                nguoidung.AnhDaiDien = "";
                            }
                            else
                            {
                                if (ListFileAttachAdd.Count > 0)
                                {
                                    //nguoidung.AnhData = ListFileAttachAdd.FirstOrDefault().FileData;
                                    nguoidung.AnhDaiDien = ListFileAttachAdd.FirstOrDefault().FileServer;
                                }
                            }
                        }

                        //Cập nhật pass mặc định
                        if (!string.IsNullOrEmpty(nguoidung.MatKhau))
                        {
                            nguoidung.MatKhau = Utility.GetMd5x2(nguoidung.MatKhau);
                        }
                        else
                        {
                            nguoidung.MatKhau = Utility.GetMd5x2("123123");
                        }
                        nguoidung.NguoiTaoID = CurrentUser.ID;

                        //save
                        context.NguoiDung.Add(nguoidung);
                        context.SaveChanges();
                        #region Thêm vào bảng NguoiDungDonViNhomNguoiDung
                        foreach (var source in nguoidung.NguoiDungDonViNhomNguoiDung.Where(n => NguoiDungID == nguoidung.ID))
                        {
                            context.NguoiDungDonViNhomNguoiDung.Remove(source);
                        }

                        PhongBanDonViNguoiDung.DonViID = DonViID;
                        PhongBanDonViNguoiDung.NguoiDungID = nguoidung.ID;
                        PhongBanDonViNguoiDung.NhomNguoiDungID = NhomNguoiDungID;
                        var listKVQL = string.Empty;
                        if (!string.IsNullOrEmpty(HttpContext.Current.Request["lstKhuVucQL"]))
                        {
                            var listint = String2Array(HttpContext.Current.Request["lstKhuVucQL"]);
                            foreach (var item in listint)
                            {
                                var donvi = context.DonVi.FirstOrDefault(a => a.ID == item);
                                if (donvi != null)
                                {
                                    listKVQL += donvi.Ten + ",";
                                }
                            }
                            if (listKVQL.Length > 2)
                            {
                                listKVQL = listKVQL.Remove(listKVQL.Length - 1);
                            }

                        }
                        PhongBanDonViNguoiDung.CommentLDAP = listKVQL;
                        context.NguoiDungDonViNhomNguoiDung.Add(PhongBanDonViNguoiDung);
                        #endregion Thêm vào bảng NguoiDungDonViNhomNguoiDung


                        if (!string.IsNullOrEmpty(HttpContext.Current.Request["LstNguoiDung"]))
                        {
                            var list_int = String2Array(HttpContext.Current.Request["LstNguoiDung"]);
                            foreach (var item in list_int)
                            {

                                var nguoidungshare = new NguoiDungChiaSeLichQuanLy();
                                nguoidungshare.NguoiDungID = nguoidung.ID;
                                nguoidungshare.NguoiDuocChiaSe = item;
                                context.NguoiDungChiaSeLichQuanLy.Add(nguoidungshare);
                            }
                        }
                        if (!string.IsNullOrEmpty(HttpContext.Current.Request["LstNguoiDungSDTC"]))
                        {
                            var list_int = String2Array(HttpContext.Current.Request["LstNguoiDungSDTC"]);
                            foreach (var item in list_int)
                            {

                                var nguoidungshareSDTC = new DinhBien_ChiaSe();
                                nguoidungshareSDTC.NguoiChiaSeID = nguoidung.ID;
                                nguoidungshareSDTC.NguoiNhanID = item;
                                nguoidungshareSDTC.NgayChiaSe = DateTime.Now;
                                context.DinhBien_ChiaSe.Add(nguoidungshareSDTC);
                            }
                        }
                        context.SaveChanges();

                        objMsg = new Message()
                        {
                            ID = nguoidung.ThuTu + 1,
                            Title = string.Format(HttpContext.GetGlobalResourceObject("Other", "lblThemMoiThanhCongNguoiDung").ToString() + ": <b>{0}</b>", nguoidung.TenHienThi),
                            Error = false
                        };

                        ts.Complete();
                    }
                }
                catch (Exception ex)
                {
                    objMsg = new Message()
                    {
                        ID = nguoidung.ID,
                        Title = string.Format(HttpContext.GetGlobalResourceObject("Other", "lblThemMoiKhongThanhCong").ToString() + "!"),
                        Error = true,
                        Obj = ex
                    };
                }

                return objMsg;
            }
        }

        /// <summary>
        /// Lấy về số thứ tự lớn nhất phục vụ order tự tăng
        /// </summary>
        /// <returns>Số lớn nhất + 1</returns>
        /// <modified>
        /// Author				    created date					comments
        /// QuanLH					06/08/2013				        Tạo mới
        ///</modified>
        public int GetMaxOrder()
        {
            using (var context = new FoldioContext())
            {
                var query = (from c in context.NguoiDung orderby c.ThuTu descending select c.ThuTu).FirstOrDefault();
                return query < 9999 ? query + 1 : query;
            }
        }
        /// <summary>
        /// Lấy về số thứ tự lớn nhất phục vụ order tự tăng
        /// </summary>
        /// <returns>Số lớn nhất + 1</returns>
        /// <modified>
        /// Author				    created date					comments
        /// QuanLH					06/08/2013				        Tạo mới
        ///</modified>
        public int GetMaxOrderID()
        {
            using (var context = new FoldioContext())
            {
                var query = (from c in context.NguoiDung orderby c.ID descending select c.ID).FirstOrDefault();
                return query < 999999 ? query + 1 : query;
            }
        }
        /// <summary>
        /// Cập nhật thông tin người dùng
        /// </summary>
        /// <returns>Message</returns>
        /// <modified>
        /// Author				    created date					comments
        /// QuanLH					05/07/2013				        Tạo mới
        ///</modified>
        public Message Edit()
        {
            using (var context = new FoldioContext())
            {

                return new Message();
            }
        }
        /// <summary>
        /// Kiểm tra đã tồn tại vị trí to nhất chưa
        /// </summary>
        /// <param name="donviID"></param>
        /// <returns></returns>
        private bool CheckIsLarget(int donviID, int nguoidungID)
        {
            using (var context = new FoldioContext())
            {
                var exist = from c in context.NguoiDung where c.ID != nguoidungID && c.NguoiDungDonViNhomNguoiDung.Any(p => p.DonViID == donviID) select c;
                return (exist.Any(p => p.IsLargest.HasValue && p.IsLargest.Value));
            }

        }
        /// <summary>
        /// Cập nhật nhóm người dùng
        /// </summary>
        /// <returns>Message đã cập nhật.</returns>
        /// <modified>
        /// Author				    created date					comments
        /// HungBM					05/09/2014 			            Tạo mới
        ///</modified>
        public Message CapNhatThongTin()
        {
            using (var context = new FoldioContext())
            {
                Message objMsg;
                #region Cập nhật thông tin
                Base.NguoiDung nguoidung = context.NguoiDung.FirstOrDefault(p => p.ID == ListID.FirstOrDefault()); // Entity Trong database

                UpdateModel(nguoidung);

                try
                {

                    objMsg = new Message()
                    {
                        ID = nguoidung.ID,
                        Title = string.Format(HttpContext.GetGlobalResourceObject("Other", "lblCapNhatThanhCongNguoiDung").ToString() + ": <b>{0}</b>", nguoidung.TenHienThi),
                        TitleAPI = string.Format(HttpContext.GetGlobalResourceObject("Other", "lblCapNhatThanhCongNguoiDung").ToString() + ": {0}", nguoidung.TenHienThi),
                        Error = false
                    };
                    using (var ts = new TransactionScope())
                    {
                        if (!string.IsNullOrEmpty(HttpContext.Current.Request["listValueFileAttach"]))
                        {
                            if (HttpContext.Current.Request["listValueFileAttach"].Equals("avatar-default"))
                            {
                                nguoidung.AnhData = null;
                                nguoidung.AnhDaiDien = "";
                            }
                            else
                            {
                                if (ListFileAttachAdd.Count > 0)
                                {
                                    //nguoidung.AnhData = ListFileAttachAdd.FirstOrDefault().FileData;
                                    nguoidung.AnhDaiDien = ListFileAttachAdd.FirstOrDefault().FileServer;
                                }
                            }
                        }


                        context.SaveChanges();

                        ts.Complete();
                    }

                }
                catch (Exception ex)
                {
                    objMsg = new Message()
                    {
                        ID = nguoidung.ID,
                        Title = string.Format(HttpContext.GetGlobalResourceObject("Other", "lblCapNhatKhongThanhCong").ToString()),
                        Error = true,
                        Obj = ex
                    };
                }
                #endregion
                return objMsg;
            }
        }
        /// <summary>
        /// Hiển thị người dùng
        /// </summary>
        /// <param name="ListID">Mảng ID Cần hiển thị</param>
        /// <returns>Message đã hiển thị.</returns>
        /// <modified>
        /// Author				    created date					comments
        /// QuanLH					06/08/2013				        Tạo mới
        ///</modified>
        public Message Show()
        {
            using (var context = new FoldioContext())
            {
                GetCurrentUser();
                Message objMsg;
                var ListNguoidung = context.NguoiDung.Where(p => ListID.Contains(p.ID));
                try
                {
                    objMsg = new Message();
                    string strCatDel = string.Empty;
                    string strCatNotDel = string.Empty;
                    foreach (var NguoiDung in ListNguoidung)
                    {
                        if (NguoiDung.SuDung == false)
                        {
                            NguoiDung.SuDung = true;
                            strCatDel += string.Format("<li>{0}</li>\r\n", HttpUtility.HtmlEncode(NguoiDung.TenHienThi));
                        }
                        else
                        {
                            strCatNotDel += string.Format("<li>{0}</li>\r\n", HttpUtility.HtmlEncode(NguoiDung.TenHienThi));
                        }
                    }
                    if (!string.IsNullOrEmpty(strCatDel))
                    {
                        objMsg.Title += "<div class=\"alert alert-success\">" + HttpContext.GetGlobalResourceObject("Other", "lblHienThiThanhCongNguoiDung").ToString() + "!</div>\r\n";
                        objMsg.Title += "<ul>\r\n";
                        objMsg.Title += strCatDel;
                        objMsg.Title += "</ul>\r\n";
                    }
                    if (!string.IsNullOrEmpty(strCatNotDel))
                    {
                        objMsg.Title += "<div class=\"alert alert-error\">" + HttpContext.GetGlobalResourceObject("Other", "lblNguoiDungDangDuocHienThi").ToString() + "!</div>\r\n";
                        objMsg.Title += "<ul>\r\n";
                        objMsg.Title += strCatNotDel;
                        objMsg.Title += "</ul>\r\n";
                    }
                    context.SaveChanges();

                }
                catch (Exception ex)
                {
                    objMsg = new Message()
                    {
                        Title = string.Format(HttpContext.GetGlobalResourceObject("Other", "lblCapNhatKhongThanhCong").ToString()),
                        Error = true,
                        Obj = ex
                    };
                }
                return objMsg;
            }
        }
        /// <summary>
        /// Ẩn một hoặc nhiều người dùng
        /// </summary>
        /// <param name="ListID">Mảng ID Cần hiển thị</param>
        /// <returns>Message đã hiển thị.</returns>
        /// <modified>
        /// Author				    created date					comments
        /// QuanLH					22/10/2014				        Tạo mới
        ///</modified>
        public Message Hide()
        {
            using (var context = new FoldioContext())
            {
                GetCurrentUser();
                Message objMsg;
                var ListNguoidung = context.NguoiDung.Where(p => ListID.Contains(p.ID));
                try
                {
                    objMsg = new Message();
                    string strCatDel = string.Empty; //Thông báo các danh mục xóa đc
                    string strCatNotDel = string.Empty; //Thông báo các danh mục đang sử dụng.
                    foreach (var NguoiDung in ListNguoidung)
                    {
                        if (NguoiDung.SuDung == true)
                        {
                            NguoiDung.SuDung = false;
                            strCatDel += string.Format("<li>{0}</li>\r\n", HttpUtility.HtmlEncode(NguoiDung.TenHienThi));
                        }
                        else
                        {
                            strCatNotDel += string.Format("<li>{0}</li>\r\n", HttpUtility.HtmlEncode(NguoiDung.TenHienThi));
                        }
                    }

                    if (!string.IsNullOrEmpty(strCatDel))
                    {
                        objMsg.Title += "<div class=\"alert alert-success\">" + HttpContext.GetGlobalResourceObject("Other", "lblAnThanhCongNguoiDung").ToString() + "!</div>\r\n";
                        objMsg.Title += "<ul>\r\n";
                        objMsg.Title += strCatDel;
                        objMsg.Title += "</ul>\r\n";
                    }
                    if (!string.IsNullOrEmpty(strCatNotDel))
                    {
                        objMsg.Title += "<div class=\"alert alert-error\">" + HttpContext.GetGlobalResourceObject("Other", "lblNguoiDungDangDuocAn").ToString() + "!</div>\r\n";
                        objMsg.Title += "<ul>\r\n";
                        objMsg.Title += strCatNotDel;
                        objMsg.Title += "</ul>\r\n";
                    }
                    context.SaveChanges();


                }
                catch (Exception ex)
                {
                    objMsg = new Message()
                    {
                        Title = ex.Message,
                        Error = true,
                        Obj = ex
                    };
                }
                return objMsg;
            }
        }
        /// <summary>
        /// Cập nhật nhóm người dùng
        /// </summary>
        /// <param name="ListID">Mảng id cần xóa</param>
        /// <returns>Message đã cập nhật.</returns>
        /// <modified>
        /// Author				    created date					comments
        /// Duynv					06/08/2013				        Tạo mới
        ///</modified>
        public Message Delete()
        {
            using (var db = new FoldioContext())
            {
                GetCurrentUser();
                var objMsg = new Message();
                var lstNguoiDung = db.NguoiDung.Where(p => ListID.Contains(p.ID));
                Viags.Base.NguoiDung nguoidung = db.NguoiDung.FirstOrDefault(p => p.ID == ListID.FirstOrDefault()); // Entity Trong database
                int NhomNguoiDung = 0;
                if (!string.IsNullOrEmpty(HttpContext.Current.Request["NhomNguoiDungID"]))
                {
                    NhomNguoiDung = Convert.ToInt32(HttpContext.Current.Request["NhomNguoiDungID"]);
                }
                //Xóa người dùng khỏi phòng ban đơn vị
                if (false)//!string.IsNullOrEmpty(Request.Params["DonViID"]))
                {
                    try
                    {
                        var donViId = int.Parse(Request.Params["DonViID"]);
                        //Xóa phòng hiện tại
                        var phongBanDonViNguoiDungItem = db.NguoiDungDonViNhomNguoiDung.FirstOrDefault(p => p.NguoiDungID == nguoidung.ID && p.DonViID == donViId);
                        if (phongBanDonViNguoiDungItem != null)
                        {
                            var donvicha = db.DonVi.FirstOrDefault(c => c.ID == phongBanDonViNguoiDungItem.DonViID);
                            db.NguoiDungDonViNhomNguoiDung.Remove(phongBanDonViNguoiDungItem);
                            //if (nguoidung.NguoiDungDonViNhomNguoiDung.Count == 0)
                            //{
                            //    var phongBanDonViNguoiDung =
                            //        new Base.NguoiDungDonViNhomNguoiDung();
                            //    if (donvicha.DonViChaID != null) phongBanDonViNguoiDung.DonViID = donvicha.DonViChaID.Value;
                            //    phongBanDonViNguoiDung.NguoiDungID = nguoidung.ID;
                            //    db.NguoiDungDonViNhomNguoiDung.Add(phongBanDonViNguoiDung);
                            //}
                        }
                        db.SaveChanges();
                        
                        objMsg = new Message() { Error = false, Title = "Xóa người dùng khỏi phòng ban thành công." };
                    }
                    catch (Exception ex)
                    {
                        objMsg = new Message()
                        {
                            Title = string.Format(HttpContext.GetGlobalResourceObject("Other", "lblNguoiDungKhongXoaDuocDoDangSuDung").ToString() + "!"),
                            Error = true,
                            Obj = ex
                        };
                    }
                }
                else   //Xóa người dùng 
                {
                    try
                    {
                        objMsg = new Message();

                        var strCatDel = string.Empty; //Thông báo các người dùng xóa đc
                        var strCatNotDel = string.Empty; //Thông báo các người dùng đang sử dụng.

                        foreach (Base.NguoiDung NguoiDungItem in lstNguoiDung)
                        {
                            var collPhongBanDonViNguoiDung = from c in db.NguoiDungDonViNhomNguoiDung where c.NguoiDungID == NguoiDungItem.ID select c;
                            //Xóa phòng ban người dùng
                            foreach (var phongBanDonViNguoiDung in collPhongBanDonViNguoiDung)
                            {
                                db.NguoiDungDonViNhomNguoiDung.Remove(phongBanDonViNguoiDung);
                            }
                            //Xóa người dùng
                            db.NguoiDung.Remove(NguoiDungItem);//Xóa khỏi db

                            strCatDel += string.Format("<li>{0}</li>\r\n", NguoiDungItem.TenHienThi);
                         
                        }
                        if (!string.IsNullOrEmpty(strCatDel))
                        {
                            objMsg.Title += "<div class=\"alert alert-success\">" + HttpContext.GetGlobalResourceObject("Other", "lblDaXoaThanhCong").ToString() + "!</div>\r\n";
                            objMsg.Title += "<ul>\r\n";
                            objMsg.Title += strCatDel;
                            objMsg.Title += "</ul>\r\n";
                        }
                        if (!string.IsNullOrEmpty(strCatNotDel))
                        {
                            objMsg.Title += "<div class=\"alert alert-error\">" + HttpContext.GetGlobalResourceObject("Other", "lblNguoiDungKhongXoaDuocDoDangSuDung").ToString() + "!</div>\r\n";
                            objMsg.Title += "<ul>\r\n";
                            objMsg.Title += strCatNotDel;
                            objMsg.Title += "</ul>\r\n";
                        }
                        db.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        objMsg = new Message()
                        {
                            Title = string.Format(HttpContext.GetGlobalResourceObject("Other", "lblNguoiDungKhongXoaDuocDoDangSuDung").ToString() + "!"),
                            Error = true,
                            Obj = ex
                        };
                    }

                }
                return objMsg;
            }
        }
        /// <summary>
        /// Kiểm tra sự tồn tại qua tên truy cập người dùng
        /// </summary>
        /// <param name="DanhMucTen"></param>
        /// <returns>Có tồn tại trong CSDL Chưa?</returns>
        /// <modified>
        /// Author				    created date					comments
        /// QuanLH					06/08/2013				        Tạo mới
        ///</modified>
        public bool CheckExist(Base.NguoiDung nguoidung)
        {
            using (var context = new FoldioContext())
            {
                var queryCheckExits = (from c in context.NguoiDung where c.ID != nguoidung.ID && c.TenTruyCap == nguoidung.TenTruyCap select c).Count();
                return (queryCheckExits > 0);
            }
        }
        /// <summary>
        /// Lấy về thông tin đăng nhập của người dùng
        /// </summary>
        /// <param name="TenTruyCap">Tên truy cập</param>
        /// <returns>Thông tin đăng nhập của người dùng</returns>
        /// <modified>
        /// Author				    created date					comments
        /// QuanLH					05/07/2013				        Tạo mới
        ///</modified>
        public Simple.NguoiDungSession GetThongTinDangNhapCuaNguoiDung(string TenTruyCap, string MatKhau)
        {
            using (var dbcontext = new FoldioContext())
            {
                var dict = new Dictionary<string, string>();
                Viags.Base.NguoiDung objNguoiDung;
                NguoiDungSession NguoiDung;
                string ThongBao = string.Empty;
                string matKhau = Utility.GetMd5x2(MatKhau);
                NguoiDung = new NguoiDungSession();
                objNguoiDung = (from c in dbcontext.NguoiDung where c.TenTruyCap == TenTruyCap select c).FirstOrDefault();//&& c.MatKhau == matKhau
                if (CheckUserActive(objNguoiDung, out ThongBao))
                {
                    if (objNguoiDung != null)
                    {
                        NguoiDung.ID = objNguoiDung.ID;
                        NguoiDung.TenTruyCap = objNguoiDung.TenTruyCap;
                        NguoiDung.TenHienThi = objNguoiDung.TenHienThi;
                        NguoiDung.ChucVuID = (int)objNguoiDung.ChucVuID;
                        NguoiDung.SuDung = objNguoiDung.SuDung;

                        if (string.IsNullOrEmpty(objNguoiDung.Token))
                        {
                            NguoiDung.Token = System.Guid.NewGuid().ToString();
                            objNguoiDung.Token = NguoiDung.Token;
                            dbcontext.SaveChanges();
                        }
                        else
                        {
                            NguoiDung.Token = objNguoiDung.Token;
                        }
                    }
                }
                else
                {
                    NguoiDung = new NguoiDungSession();
                    NguoiDung.Message = ThongBao;
                }
                return NguoiDung;
            }
        }

        /// <summary>
        /// Kiểm tra xem người dùng có được phép hoạt động không
        /// </summary>
        /// <param name="nguoiDung"></param>
        /// <returns>True or false</returns>
        /// <modified>
        /// Author				    created date					comments
        /// QuanLH					05/07/2013				        Tạo mới
        ///</modified>
        public bool CheckUserActive(Base.NguoiDung nguoiDung, out string strThongBao)
        {
            strThongBao = string.Empty;
            if (nguoiDung == null)
            {
                strThongBao = string.Format(HttpContext.GetGlobalResourceObject("Other", "lblNguoiDungKhongTonTaiTrenHeThong").ToString() + ".");
                return false;
            }
            else
            {
                if (nguoiDung.SuDung == false)
                {
                    strThongBao = string.Format(HttpContext.GetGlobalResourceObject("Other", "lblNguoiDungChuaDuocPhepDungTrenHT").ToString() + ".");
                    return false;
                }
                else
                {
                    if (nguoiDung.NguoiDungDonViNhomNguoiDung.Count > 0)
                    {
                        return true;
                    }
                    else
                    {
                        strThongBao = string.Format(HttpContext.GetGlobalResourceObject("Other", "lblNguoiDungChuaDuocGanChoDVPB").ToString() + ".");
                        return false;
                    }
                }
            }
        }
    }
}
