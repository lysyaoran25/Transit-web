using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Viags.Base;
using Viags.Simple;

namespace Viags.Data
{
    public class TransitDA : BaseDA
    {
        public TransitDA() : base(HttpContext.Current) { }
        public List<KhuVucItem> GetListKhuVuc()
        {
            using (var context = new FoldioContext())
            {
                var query = (from p in context.TS_KhuVuc
                             where p.SuDung == true
                             select new KhuVucItem()
                             {
                                 ID = p.ID,
                                 Ten = p.Ten,
                                 SuDung = p.SuDung,
                             }).OrderBy(p=>p.Ten).ToList();
                return query;
            }
        }
        public List<LookupData> GetListPhuongXa(int khuvucID)
        {
            using (var context = new FoldioContext())
            {
                var listphuongxa = context.TS_PhuongXa.Where(p => p.KhuVucID == khuvucID && p.isSuDung != false).Select(p => new LookupData()
                {
                    id = p.ID.ToString(),
                    text = p.TenPhuongXa,
                }).ToList();
                return listphuongxa;
            }
        }
        public List<LookupData> GetListDuongAp(int phuongxaID)
        {
            using (var context = new FoldioContext())
            {
                var listduongap = context.TS_DuongAp.Where(p => p.PhuongXaID == phuongxaID && p.isSuDung != false).Select(p => new LookupData()
                {
                    id = p.ID.ToString(),
                    text = p.TenDuongAp ,

                }).ToList();
                return listduongap;
            }
        }
    }
}
