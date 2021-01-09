using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Viags.Utils
{
    /// <summary>
    /// Class file attach form
    /// </summary>
    public class FileAttachFrom
    {
        /// <summary>
        /// Tên file 
        /// </summary>
        private string fileName;
        public string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }
        /// <summary>
        /// Tên hiển thị 
        /// </summary>
        private string fileNameDisPlay;
        public string FileNameDisPlay
        {
            get { return fileName; }
            set { fileName = value; }
        }
        /// <summary>
        /// Đường dẫn file server
        /// </summary>
        private string fileServer;
        public string FileServer
        {
            get { return fileServer; }
            set { fileServer = value; }
        }
        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        /// <Modified>        
        ///	Name		Date		    Comment 
        /// QuanLH     05/08/2013      Tạo mới
        /// </Modified>
        public FileAttachFrom()
        {

        }
        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        /// <param name="_filename"></param>
        /// <param name="_fileserver"></param>
        /// <Modified>        
        ///	Name		Date		    Comment 
        /// QuanLH     05/08/2013      Tạo mới
        /// </Modified>
        public FileAttachFrom(string _filename, string _fileserver)
        {
            fileName = _filename;
            fileServer = _fileserver;
        }
    }
}
