using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Viags.Simple;
using Viags.Base;
using System.Data.Entity;

namespace Viags.Data
{
    public class APITransitDA : BaseDA
    {
        public List<ThongTinKhachModel> APIGetThongTinDonKhach()
        {
            using (var context = new FoldioContext())
            {
                try
                {
                    var model = context.TS_ThongTinDonKhach.Where(p => p.isTrungChuyen == true).Select(p => new ThongTinKhachModel
                    {
                        DiaChi = p.DiaChi + " " + p.TS_DuongAp.TenDuongAp + " " + p.TS_PhuongXa.TenPhuongXa + " " + p.TS_KhuVuc.Ten,
                        SDT = p.SoDienThoai,
                        SoGhe = (int)p.SoGhe,
                    }).AsNoTracking().ToList();
                    return model;
                }
                catch (Exception)
                {
                    return new List<ThongTinKhachModel>();
                }
            }
        }
    }
}
