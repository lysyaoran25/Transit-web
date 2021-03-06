﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Viags.Base;
using Viags.Data;
using Viags.Simple;

namespace Viags.WebApp.Transit
{
    public partial class AjaxList : Base.BaseWebPage
    {
        public List<ThongTinDonKhachItem> LstDonKhach;
        public TransitDA TransitDA;
        protected int khuvucid = 0;
        public AjaxList()
        {
            LstDonKhach = new List<ThongTinDonKhachItem>();
            TransitDA = new TransitDA();

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            khuvucid = string.IsNullOrEmpty(Request["khuvucid"]) ? 0 : int.Parse(Request["khuvucid"]);
            LstDonKhach = TransitDA.GetListThongTinDonKhach(CurrentPage, RowPerPage, Field, FieldOption, Keyword, SearchInFiled);
        
            HtmlPager =
                pagination(
                    string.Format("#RowPerPage={0}&PageStep={1}&Field={2}&FieldOption={3}&Keyword={4}&SearchIn={5}&Page=", RowPerPage, PageStep,
                                  Field, (FieldOption) ? 0 : 1, Keyword, string.Join(",", SearchInFiled.ToArray())), CurrentPage, RowPerPage, 0);
        }
        public string GetTenHienThi(int ID)
        {
            using (var context = new FoldioContext())
            {
                var nguoidung = context.NguoiDung.FirstOrDefault(c => c.ID == ID);
                return nguoidung == null ? string.Empty : nguoidung.TenHienThi;
            }
        }

    }
}