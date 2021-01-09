using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Viags.Simple;
using Viags.Data;
namespace Viags.WebApp.Hiface.NhanVien
{
    public partial class ucNhanVien : Base.BaseUserControl
    {
        public List<NhomNguoiDungItem> LtsNhomNguoiDung { get; set; }
        NhomNguoiDungDA NhomNguoiDungDA;
        /// <summary>
        /// Hàm page load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            NhomNguoiDungDA = new NhomNguoiDungDA();
            LtsNhomNguoiDung = NhomNguoiDungDA.GetListChucVu();
            
        }
    }
}