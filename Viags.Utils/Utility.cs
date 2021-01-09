using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI.WebControls;
using System.Globalization;
using System.Xml.Linq;

namespace Viags.Utils
{
    /// <summary>
    /// Class chứa các hàm Utils, hỗ trợ trong việc lập trình
    /// </summary>
    /// <modified>
    /// Author				    created date					comments
    /// QuangNĐ					04/07/2013				        Tạo mới
    ///</modified>
    public static class Utility
    {
        /// <summary>
        /// Chuyển danh sách từ xâu sang mảng int.
        /// Các mảng int có định dạng được ngăn cách nhau bằng dấu ,
        /// VD: 1,2,3,4
        /// </summary>
        /// <param name="LtsSourceValues">Xâu chứa mảng int</param>
        /// <returns>Mảng int</returns>
        /// <modified>
        /// Author				    created date					comments
        /// QuangNĐ					04/07/2013				        Tạo mới
        ///</modified>
        public static List<int> GetValuesArray(string LtsSourceValues)
        {
            List<int> LtsValues = new List<int>();
            if (!string.IsNullOrEmpty(LtsSourceValues))
            {
                if (LtsSourceValues.Contains(","))
                    LtsValues = LtsSourceValues.Split(',').Select(o => Convert.ToInt32(o)).ToList();
                else
                    LtsValues.Add(Convert.ToInt32(LtsSourceValues));
            }
            return LtsValues;
        }
        /// <summary>
        /// Loại bỏ tất cả các khoảng trắng thừa trong chuỗi
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string TrimAllSpace(string source)
        {
            return string.IsNullOrEmpty(source) ? "" : Regex.Replace(source, @"\s+", " ");
        }
        /// <summary>
        /// Stops asp.net from encoding the source HTML string.
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static IHtmlString HTMLRaw(string source)
        {
            return new HtmlString(source);
        }
        public static DateTime convertDate(string date)
        {
            // Specify exactly how to interpret the string.
            IFormatProvider culture = new System.Globalization.CultureInfo("vi-VN", true);

            return DateTime.Parse(date, culture, System.Globalization.DateTimeStyles.AssumeLocal);
        }
        /// <summary>
        /// Đọc 1 file trên file vật lý
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        /// <modified>
        /// Author				    created date					comments
        /// QuangNĐ					04/07/2013				        Tạo mới
        ///</modified>
        public static byte[] ReadFile(string filePath)
        {
            byte[] buffer;
            FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            try
            {
                int length = (int)fileStream.Length;  // get file length
                buffer = new byte[length];            // create buffer
                int count;                            // actual number of bytes read
                int sum = 0;                          // total number of bytes read

                // read until Read method returns 0 (end of the stream has been reached)
                while ((count = fileStream.Read(buffer, sum, length - sum)) > 0)
                    sum += count;  // sum is a buffer offset for next reading
            }
            finally
            {
                fileStream.Close();
            }
            return buffer;
        }


        /// <summary>
        /// Chuyển từ kích thước file sang định dạng chuẩn bao gồm:
        /// Bytes, Kb, MB, GB
        /// </summary>
        /// <param name="bytes">Chiều dài mảng Byte[]. Thường là size.Length</param>
        /// <returns>Xâu đã format</returns>
        /// <modified>
        /// Author				    created date					comments
        /// QuangNĐ					04/07/2013				        Tạo mới
        ///</modified>
        public static string FormatBytes(int bytes)
        {
            const int scale = 1024;
            string[] orders = new string[] { "GB", "MB", "KB", "Bytes" };
            long max = (long)Math.Pow(scale, orders.Length - 1);

            foreach (string order in orders)
            {
                if (bytes > max)
                    return string.Format("{0:##.##} {1}", decimal.Divide(bytes, max), order);

                max /= scale;
            }
            return "0 Bytes";
        }
        /// <summary>
        /// Rewrite url để dùng view file dùng google doc
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        /// <modified>
        /// Author				    created date					comments
        /// QuanLH					14/08/2013				        Tạo mới
        ///</modified>
        public static string UrlRewrite(string url)
        {
            return System.Web.HttpUtility.UrlEncode(url);
        }
        /// <summary>
        /// Rewrite url để dùng view file dùng google doc
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        /// <modified>
        /// Author				    created date					comments
        /// QuanLH					14/08/2013				        Tạo mới
        ///</modified>
        public static string HtmlDecode(string url)
        {
            return System.Web.HttpUtility.HtmlDecode(url);
        }
        /// <summary>
        /// Rewrite url để dùng view file dùng google doc
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        /// <modified>
        /// Author				    created date					comments
        /// QuanLH					14/08/2013				        Tạo mới
        ///</modified>
        public static string UrlViewGoogleDoc(string url)
        {
            string urlPrefix = "https://docs.google.com/viewer?";
            return urlPrefix + UrlRewrite(url) + "&embedded=true";
        }
        /// <summary>
        /// Lấy về đường dẫn file đính kèm vật lý
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        /// <modified>
        /// Author				    created date					comments
        /// QuanLH					14/08/2013				        Tạo mới
        ///</modified>
        public static string GetUrlFilePath()
        {
            string strPathAndQuery = HttpContext.Current.Request.Url.PathAndQuery;
            string strPath = HttpContext.Current.Request.Url.AbsoluteUri.Replace(strPathAndQuery, "/");
            return strPath;
        }

        /// <summary>
        /// Hàm tính toán tỷ trọng % dựa trên số lượng và tổng
        /// </summary>
        /// <param name="currentValue">Giá trị thực tế</param>
        /// <param name="totalValue">Tổng giá trị</param>
        /// <returns>Tỷ lệ % giữa giá trị thực tế và tổng giá trị</returns>
        /// <modified>
        /// Author				    created date					comments
        /// QuangNĐ					04/07/2013				        Tạo mới
        ///</modified>
        public static string GetDataPercent(int currentValue, int totalValue)
        {
            try
            {
                double value = ((double)currentValue / totalValue);
                return (value.ToString("0.0%") == "NaN") ? "0" : value.ToString("0.0%");
            }
            catch { return string.Empty; }
        }

        /// <summary>
        /// Hàm chuyển một chuỗi tiếng việt có dấu thành tiếng việt không dấu
        /// </summary>
        /// <param name="Unicode">xâu tiếng việt có dấu</param>
        /// <modified>
        /// Author				    created date					comments
        /// QuangNĐ					04/07/2013				        Tạo mới
        ///</modified>
        public static string UnicodeToAscii(string Unicode)
        {
            Unicode = Regex.Replace(Unicode, "[á|à|ả|ã|ạ|â|ă|ấ|ầ|ẩ|ẫ|ậ|ắ|ằ|ẳ|ẵ|ặ]", "a", RegexOptions.IgnoreCase);
            Unicode = Regex.Replace(Unicode, "[é|è|ẻ|ẽ|ẹ|ê|ế|ề|ể|ễ|ệ]", "e", RegexOptions.IgnoreCase);
            Unicode = Regex.Replace(Unicode, "[ú|ù|ủ|ũ|ụ|ư|ứ|ừ|ử|ữ|ự]", "u", RegexOptions.IgnoreCase);
            Unicode = Regex.Replace(Unicode, "[í|ì|ỉ|ĩ|ị]", "i", RegexOptions.IgnoreCase);
            Unicode = Regex.Replace(Unicode, "[ó|ò|ỏ|õ|ọ|ô|ơ|ố|ồ|ổ|ỗ|ộ|ớ|ờ|ở|ỡ|ợ]", "o", RegexOptions.IgnoreCase);
            Unicode = Regex.Replace(Unicode, "[đ|Đ]", "d", RegexOptions.IgnoreCase);
            Unicode = Regex.Replace(Unicode, "[ý|ỳ|ỷ|ỹ|ỵ|Ý|Ỳ|Ỷ|Ỹ|Ỵ]", "y", RegexOptions.IgnoreCase);
            Unicode = Regex.Replace(Unicode, "[^A-Za-z0-9-\\s]", "");
            return Unicode;
        }
        /// <summary>
        /// Hàm tạo mã md5
        /// </summary>
        /// <param name="str">xâu cần mã hóa</param>
        /// <modified>
        /// Author				    created date					comments
        /// QuanLH					20/08/2013				        Tạo mới
        ///</modified>
        public static string GetMd5x2(string str)
        {
            MD5CryptoServiceProvider provider = new MD5CryptoServiceProvider();
            byte[] bytes = Encoding.UTF8.GetBytes(str);
            bytes = provider.ComputeHash(bytes);
            StringBuilder builder = new StringBuilder();
            foreach (byte num in bytes)
            {
                builder.Append(num.ToString("x2").ToLower());
            }
            return builder.ToString();
        }
        /// <summary>
        /// Hàm tạo mã md5
        /// </summary>
        /// <param name="str">xâu cần mã hóa</param>
        /// <modified>
        /// Author				    created date					comments
        /// QuangNĐ					04/07/2013				        Tạo mới
        ///</modified>
        public static string GetMd5Sum(string str)
        {
            Encoder enc = System.Text.Encoding.Unicode.GetEncoder();
            byte[] unicodeText = new byte[str.Length * 2];
            enc.GetBytes(str.ToCharArray(), 0, str.Length, unicodeText, 0, true);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] result = md5.ComputeHash(unicodeText);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                sb.Append(result[i].ToString("X2"));
            }
            return sb.ToString();
        }


        /// <summary>
        /// Hàm mã hóa MD5 theo chuẩn function md5() của ngôn ngữ lập trình php
        /// </summary>
        /// <param name="password">Xâu cần mã hóa</param>
        /// <returns>Xâu đã được mã hóa</returns>
        /// <modified>
        /// Author				    created date					comments
        /// QuangNĐ					04/07/2013				        Tạo mới
        ///</modified>
        public static string GetMd5PHP(string password)
        {
            byte[] textBytes = System.Text.Encoding.Default.GetBytes(password);
            try
            {
                System.Security.Cryptography.MD5CryptoServiceProvider cryptHandler;
                cryptHandler = new System.Security.Cryptography.MD5CryptoServiceProvider();
                byte[] hash = cryptHandler.ComputeHash(textBytes);
                string ret = "";
                foreach (byte a in hash)
                {
                    if (a < 16)
                        ret += "0" + a.ToString("x");
                    else
                        ret += a.ToString("x");
                }
                return ret;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Xóa thẻ HTML
        /// </summary>
        /// <param name="source">xâu có chứa HTML</param>
        /// <modified>
        /// Author				    created date					comments
        /// QuangNĐ					04/07/2013				        Tạo mới
        ///</modified>
        public static string RemoveHTMLTag(string source)
        {
            return Regex.Replace(source, "<.*?>", string.Empty);
        }
        public static System.Drawing.Image MyImage(byte[] DataImage)
        {
            System.Drawing.Image img;
            if (DataImage == null) return null;
            MemoryStream mstream = new MemoryStream();
            mstream.Write(DataImage, 0, DataImage.Length);
            mstream.Seek(0, SeekOrigin.Begin);
            img = System.Drawing.Image.FromStream(mstream);
            mstream.Close();
            return img;
        }

        /// <summary>
        /// Danh sách loại văn bản
        /// </summary>      
        /// <modified>
        /// Author				    created date					comments
        /// HungBM					10/06/2014				        Tạo mới
        ///</modified>
        public enum LoaiVB
        {
            VanBanDen = 1,
            VanBanDi = 2,
            VanBanNoiBoDen = 3,
            VanBanNoiBoDi = 4
        }
        /// <summary>
        /// Danh sách trạng thái xử lý văn bản
        /// </summary>      
        /// <modified>
        /// Author				    created date					comments
        /// HungBM					10/06/2014				        Tạo mới
        ///</modified>
        public enum TrangThaiVB
        {
            ChuaXuLy = 0,
            ChoXuLy = 1,
            Tralai = 2,
            DaXuLy = 3,
            ThuHoi=4
        }
        /// <summary>
        /// Trạng thái báo cáo công việc
        /// </summary>
        public enum TrangThaiBaoCaoCongViec
        {
            TaoMoi=0,
            DaGui=1,
            DaNhan=2,
            TraLai=3,
            ThuHoi=4,
            DungHan=5,
            QuaHan=6,
            ChoDuyet=7,
            DaDuyet =8
        }
        /// <summary>
        /// Danh sách loại báo cáo lưu trữ
        /// </summary>
        public enum LoaiBaoCaoCoSo
        {
            CTVT = 1,
            CTLT = 2
        }

        /// <summary>
        /// Convert xâu có dạng 1,2,3,4 sang list int
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        /// <modified>
        /// Author				    created date					comments
        /// QuangNĐ					05/07/2013				        Tạo mới
        ///</modified>
        public static List<int> String2Array(string source)
        {
            List<int> LtsValue = new List<int>();

            if (source.EndsWith(","))
                source = source.Substring(0, source.LastIndexOf(","));
            if (!string.IsNullOrEmpty(source))
            {
                if (source.Contains(','))
                {
                    LtsValue = source.Split(',').Select(o => Convert.ToInt32(o)).ToList();
                }
                else
                    LtsValue.Add(Convert.ToInt32(source));
            }
            return LtsValue;
        }
        /// <summary>
        /// string format text select theo cap
        /// </summary>
        /// <param name="cap"></param>
        /// <param name="ten"></param>
        /// <returns></returns>
        public static string GetTabDonVi(int? cap, string ten)
        {
            if (cap.HasValue == false)
                return ten;
            //
            string s = "";
            for (int i = 1; i < cap; i++)
            {
                s += "---";
            }
            s += ten;
            return s;
        }
        public static bool CheckQuyen(string dsQuyen, int idQuyen)
        {
            dsQuyen = "," + dsQuyen + ",";
            if (dsQuyen.Contains("," + idQuyen + ","))
                return true;
            return false;
        }
        /// <summary>
        /// Format giá tiền
        /// </summary>
        /// <param name="Price"></param>
        /// <returns></returns>
        public static string Format_Price(string Price)
        {
            Price = Price.Replace(".", "");
            Price = Price.Replace(",", "");
            string tmp = "";
            while (Price.Length > 3)
            {
                tmp = "," + Price.Substring(Price.Length - 3) + tmp;
                Price = Price.Substring(0, Price.Length - 3);
            }
            tmp = Price + tmp;
            return tmp;
        }
        /// <summary>
        /// Loại bỏ thẻ html
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string StripHTML(string str)
        {
            //variable to hold the returned value
            string strippedString;
            try
            {
                //variable to hold our RegularExpression pattern
                string pattern = "<.*?>";
                //replace all HTML tags
                strippedString = Regex.Replace(str, pattern, string.Empty);
            }
            catch
            {
                strippedString = string.Empty;
            }
            return strippedString;
        }
        /// <summary>
        /// Lấy thông tin tên viết tắt
        /// </summary>
        /// <param name="Ten"></param>
        /// <returns></returns>
        public static string GetTenVietTat(string Ten)
        {
            if (!string.IsNullOrEmpty(Ten))
            {
                Ten = Ten.Trim();
                var tenviettat = "";
                if (Ten.Length > 0)
                {
                    tenviettat += Ten[0];
                    for (var indexc = 0; indexc < Ten.Length; indexc++)
                    {
                        if (Ten[indexc] == ' ')
                        {
                            tenviettat += Ten[indexc + 1];
                        }
                    }
                }
                return tenviettat.ToUpper();
            }
            else
            {
                return string.Empty;
            }
        }

        

        /// <summary>
        /// Trạng thái duyệt phòng
        /// </summary>
        public enum TrangThaiDuyetPhong : int
        {
            TaoMoi = 4,
            ChuaDuyet = 1,
            DaDuyet = 3,
            HuyDuyet = 2
        }

        /// <summary>
        /// Trạng thái duyệt xe
        /// </summary>
        public enum TrangThaiDuyetXe : int
        {
            TaoMoi = 4,
            ChuaDuyet = 1,
            DaDuyet = 3,
            HuyDuyet = 2
        }

        /// <summary>
        /// Loại chương trình công tác
        /// </summary>
        public enum LoaiCHuongTringCongTac : int
        {
            DinhKi = 1,
            ThongTu = 2,
            DeAnTrinhChinhPhu = 3,
            NhiemVuTrongTam = 4,
        }
        /// <summary>
        /// Laoi ban giao cong viec
        /// </summary>
        public enum LoaiBanGiaoCongViec : int
        {
            BanGiaoToanPhan = 0,
            BanGiaoMotPhan = 1
        }

        /// <summary>
        /// Ghi log hệ thông lỗi
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        public static string MessageException(Exception ex)
        {
            return "Lỗi hệ thống, vui lòng thử lại sau.";
        }
    }
}