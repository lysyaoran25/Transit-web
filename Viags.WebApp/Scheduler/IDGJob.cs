using Quartz;
using System;
using System.Linq;
using System.Net.Mail;
using System.Threading;
using System.Web;
using Viags.Data;

namespace Viags.WebApp.Scheduler
{
    #region [Send mail]
    public class Mail : IJob
    {
        public Mail()
        {


        }
        public void Execute(IJobExecutionContext context)
        {
            NotificationDA notificationDA = new NotificationDA();
            var Listchuaguimail = notificationDA.GetListThongBaoChuaGuiMail();

            if (Listchuaguimail.Count > 0)
            {
                foreach (var item in Listchuaguimail)
                {
                    string Email;
                    if (item.NguoiNhanID == null || item.NguoiNhanID == 0)
                    {
                        Email = item.EmailDonViNhan;
                    }
                    else
                    {
                        Email = item.EmailNguoiNhan;
                    }
                    var body = item.NoiDung;
                    if (!string.IsNullOrEmpty(item.Link) && item.KieuID != -1 && item.KieuID != -2 && item.KieuID != -3)
                        body += "<br />" + System.Configuration.ConfigurationManager.AppSettings["LinkSite"] + item.Link;

                    var subject = "";
                    if (item.KieuID == -1)
                    {
                        subject = "[Thông báo] " + item.NoiDungTiengAnh; //Gui mail + tieu de cua thong bao
                    }
                    else if (item.KieuID == -2)
                    {
                        subject = "[Duyệt tin] " + item.NoiDungTiengAnh; //Gui mail + tieu de cua tin tuc
                    }
                    else if (item.KieuID == -3)
                    {
                        subject = "[Ban hành] " + item.NoiDungTiengAnh; //Gui mail + tieu de khi ban hanh
                    }
                    else if (item.KieuID == 9999) // Kieu 9999 la Kieu cu dat phong hop
                    {

                        subject = "[Thông báo đặt phòng họp]" + "-" + "[" + item.NoiDungTiengAnh + "]"; //Gui mail + tieu de khi ban hanh
                    }
                    else if (item.KieuID == 22) // nghiphep
                    {
                        subject = "[Thông báo nghỉ phép]";
                    }
                    else
                    {
                        subject = "[Thông báo]";
                    }
                    if (SendMail(Email, subject, body))
                    {

                        notificationDA.UpdateTrangThaiDaGuiMail(item.ID, 1);
                    }
                    else
                    {
                        notificationDA.UpdateTrangThaiDaGuiMail(item.ID, 2);
                    }
                }
            }
        }
        #region [Function Send mail]
        private Boolean SendMail(String MailTo, String Subject, String Content)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.To.Add(MailTo);
                mail.From = new MailAddress(System.Configuration.ConfigurationManager.AppSettings["SendMailAddress"], "HỆ THỐNG ỨNG DỤNG E-OFFICE");
                mail.Subject = Subject;
                mail.Body = Content;
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = System.Configuration.ConfigurationManager.AppSettings["SMTP_Host"];
                smtp.Port = int.Parse(System.Configuration.ConfigurationManager.AppSettings["SMTP_Port"]);
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential
                (mail.From.Address, System.Configuration.ConfigurationManager.AppSettings["SendMailPassword"]);// Enter senders User name and password
                smtp.Send(mail);
                return true;
            }
            catch (Exception ex)
            {
                var body = "<b>" + ex.Message + "</b><br />" + ex.StackTrace;
                if (DateTime.Now.Hour == 0 || DateTime.Now.Hour == 6 || DateTime.Now.Hour == 12 || DateTime.Now.Hour == 18 || DateTime.Now.Hour == 17)
                {
                    if (SendMail_Error(System.Configuration.ConfigurationManager.AppSettings["Email_Administrator"], "[ERROR] Lỗi Cron send mail", body))
                    {

                    }
                }

                return false;
            }
        }
        private Boolean SendMail_Error(String MailTo, String Subject, String Content)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.To.Add(MailTo);
                mail.From = new MailAddress(System.Configuration.ConfigurationManager.AppSettings["BK_SendMailAddress"], "HỆ THỐNG QUẢN LÝ VĂN BẢN VÀ ĐIỀU HÀNH CÔNG VIỆC");
                mail.Subject = Subject;
                mail.Body = Content;
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = System.Configuration.ConfigurationManager.AppSettings["BK_SMTP_Host"];
                smtp.Port = int.Parse(System.Configuration.ConfigurationManager.AppSettings["BK_SMTP_Port"]);
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential
      (System.Configuration.ConfigurationManager.AppSettings["BK_SendMailAddress"], System.Configuration.ConfigurationManager.AppSettings["BK_SendMailPassword"]);// Enter senders User name and password
                smtp.Send(mail);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion
    }
    #endregion
    #region [Schedules]
    public class Schedules : IJob
    {
        public Schedules()
        {
        }
        public void Execute(IJobExecutionContext context)
        {
            //schedule
            var function_1 = new Thread(AddPhongBanChucDanh);
            function_1.Start();
            var function_2 = new Thread(demo_function_2);
            //function_2.Start();
            var function_3 = new Thread(demo_function_3);
            //function_3.Start();
        }
        private static void AddPhongBanChucDanh()
        {
            NguoiDungLdapDA NguoiDungLdapDA = new NguoiDungLdapDA();

            //var Listcdpb = NguoiDungLdapDA.GetListNguoiDung();

            //if (Listcdpb.Count > 0)
            {
                // NguoiDungLdapDA.AddKhuVucLdap(Listcdpb);
                //NguoiDungLdapDA.AddDonViLdap(Listcdpb);
                //NguoiDungLdapDA.AddNChucDanhLdap(Listcdpb);
                //NguoiDungLdapDA.AddNguoiDungLdap(Listcdpb);
                //NguoiDungLdapDA.AddNguoiDungNhomNguoiDung(Listcdpb);
            }
        }
        private static void demo_function_2()
        {
        }
        private static void demo_function_3()
        {
        }
    }
    #endregion


    #region [Auto Add Notification for Food Order]
    public class AddNotiFoodOrder : IJob
    {
        public AddNotiFoodOrder()
        {


        }
        public void Execute(IJobExecutionContext context)
        {
            //var xx = HttpContext.Current.Request.Url.Host;


            //DatComTuanDA datComTuanDA = new DatComTuanDA();
            //datComTuanDA.AutoSendMail();
            VatPhamThietLapDA VatPhamThietLapDA = new VatPhamThietLapDA();
            //VatPhamThietLapDA.WarningNotification();
            DangKyCaComDA dangKyCaComDA = new DangKyCaComDA();
            dangKyCaComDA.WarningOutOfDay();
            var DangKyNghiPhepDA = new DangKyNghiPhepDA();
            DangKyNghiPhepDA.Validation();
            CongViecDA CongViecDA = new CongViecDA();
            NhiemVuTrongTam_CongViecNgayDA NhiemVuTrongTam_CongViecNgayDA = new NhiemVuTrongTam_CongViecNgayDA();
            //NhiemVuTrongTam_CongViecNgayDA.CheckLichLamViecNVTT();
            //CongViecDA.AddCongViecDinhKy();
        }
    }
    #endregion

    #region[Auto duplicate incompleted daily missions // Auto add Nhiệm vụ trọng tâm ngày chưa hoàn thành]
    public class AddNhiemVuTrongTamNgay : IJob
    {
        public AddNhiemVuTrongTamNgay()
        {


        }
        public void Execute(IJobExecutionContext context)
        {
            NhiemVuTrongTam_CongViecNgayDA NhiemVuTrongTam_CongViecNgayDA = new NhiemVuTrongTam_CongViecNgayDA();
            NhiemVuTrongTam_CongViecNgayDA.CheckLichLamViecNVTT();
           
        }
    }
    #endregion
}