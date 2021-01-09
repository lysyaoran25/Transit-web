using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Viags.Utils
{
    /// <summary>
    /// Class File Attach
    /// </summary>
    /// 
    public class FileAttach
    {

        private string strName;
        /// <summary>
        /// Tên file
        /// </summary>
        public string Ten
        {
            get { return strName; }
            set { strName = value; }
        }
        /// <summary>
        /// Tên file
        /// </summary>
        public string TenHienThi
        {
            get { return strName; }
            set { strName = value; }
        }

        //Ảnh thu nhỏ
        private string strAnhNho;
        /// <summary>
        /// Tên file
        /// </summary>
        public string AnhNho
        {
            get { return strAnhNho; }
            set { strAnhNho = value; }
        }
        private string strUrl;
        /// <summary>
        /// Url
        /// </summary>
        public string Url
        {
            get { return strUrl; }
            set { strUrl = value; }
        }
        private DateTime? _CreateDate;
        public DateTime? CreateDate
        {
            get { return _CreateDate; }
            set { _CreateDate = value; }
        }
        private byte[] byteDataFile;
        /// <summary>
        /// File Data
        /// </summary>
        public byte[] FileData
        {
            get { return byteDataFile; }
            set { byteDataFile = value; }
        }
        /// <summary>
        /// File Server (thư mục lưu file)
        /// </summary>
        public string FileServer { get; set; }
        /// <summary>
        /// Link file toàn văn
        /// </summary>
        public string FileLink { get; set; }
        /// <summary>
        /// Là file scan hay không?
        /// </summary>
        public bool? IsFileScan { get; set; }
        /// <summary>
        /// ID File Đính kèm
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        /// <param name="name">Tên file</param>
        ///	<param name="url">đường link file</param>
        /// <Modified>        
        ///	Name		Date		    Comment 
        /// QuanLH     05/08/2013      Tạo mới
        /// </Modified>
        public FileAttach(string name, string url)
        {
            Ten = name;
            Url = url;
        }
        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        /// <param name="name">Tên file</param>
        ///	<param name="url">đường link file</param>
        /// <Modified>        
        ///	Name		Date		    Comment 
        /// QuanLH     05/08/2013      Tạo mới
        /// </Modified>
        public FileAttach(string name, byte[] data)
        {
            this.Ten = name;
            this.FileData = data;
        }
        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        /// <param name="name">Tên file</param>
        ///	<param name="url">đường link file</param>
        /// <Modified>        
        ///	Name		Date		    Comment 
        /// QuanLH     05/08/2013      Tạo mới
        /// </Modified>
        public FileAttach()
        {
            Ten = string.Empty;
            Url = string.Empty;
        }
    }
}
