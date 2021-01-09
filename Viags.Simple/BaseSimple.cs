using Viags.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viags.Simple
{
    /// <summary>
    /// Class base của tất cả các class dùng để hiển thị, display trên tầng ứng dụng
    /// Tất cả các class của project này đều phải thừa kế từ class này.
    /// </summary>
    /// <modified>
    /// Author				    created date					comments
    /// QuangNĐ					04/07/2013				        Tạo mới
    ///</modified>
    public class BaseSimple
    {
        public int ID { get; set; }
        public string Ten { get; set; }
        public string TenEnglish { get; set; }
        public List<FileAttach> LtsFileAttach { get; set; }
    }
    public class BaseSimpleLuuTru
    {
        public int ID { get; set; }
        public string Ten { get; set; }
        public string TenEnglish { get; set; }
        public string SoLuuTru { get; set; }
    }
    /// <summary>
    /// Class lookup data
    /// </summary>
    public class LookupData
    {
        public string id { get; set; }
        public string text { get; set; }
        public string display_text { get; set; }

    }
    /// <summary>
    /// Class lookup data
    /// </summary>
    public class LookupNewData
    {
        public int ID { get; set; }
        public int LoTrinhChaID { get; set; }
        public int Count { get; set; }
        public int TienDo { get; set; }

    }
    public class ActionVB
    {
        public string tdid { get; set; }
        public int id { get; set; }
        public bool Action { get; set; }
        public string text { get; set; }
    }
}
