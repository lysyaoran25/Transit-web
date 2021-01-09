using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Viags.Simple;
using Viags.Data;
using System.Web.Services;
using System.Web.Script.Services;

namespace Viags.WebApp.Hiface.ChamCong
{
    public partial class ucChamCong : Base.BaseUserControl
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