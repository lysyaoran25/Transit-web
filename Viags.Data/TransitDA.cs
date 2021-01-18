using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Viags.Base;
using Viags.Simple;
using Viags.Utils;

namespace Viags.Data
{
    public class TransitDA : BaseDA
    {
        public TransitDA() : base(HttpContext.Current) { }

        public Message Add()
        {
            GetCurrentUser();
            Message objMsg;
            var itemID = string.IsNullOrEmpty(Request["itemID"]) ? 0 : int.Parse(Request["itemID"]);         
            var thoigiankhoihanh = string.IsNullOrEmpty(Request["ThoiGianKhoiHanh"]) ? 0 : int.Parse(Request["ThoiGianKhoiHanh"]);


            using (var context = new FoldioContext())
            {
                try
                {
                    var query = new TS_ThongTinDonKhach();
                    UpdateModel(query);
                    query.DanhMucChuyenID = thoigiankhoihanh;
                    query.TrangThai = (int)Utils.Enum.TrangThai_Transit.ChoDieuPhoi;
                    context.TS_ThongTinDonKhach.Add(query);
                    context.SaveChanges();

                    //AddNotification("aaa",
                    //                            null,
                    //                            query.ID,
                    //                            (int)Viags.Utils.Enum.ThongBao.BaoCaoCongViec,
                    //                            1,
                    //                             "/Pagess/transit", false, false, true);


                    objMsg = new Message
                    {
                        ID = 0,
                        Error = false,
                        Title = "Tạo thông tin đón khách thành công!",
                    };
                }
                catch (Exception ex)
                {
                    objMsg = new Message
                    {
                        ID = 0,
                        Error = true,
                        Title = ex.Message
                    };
                }
                return objMsg;
            }
        }

        public Message Edit()
        {
            return new Message();
        }

        public Message Delete()
        {
            return new Message();
        }

        public List<ThongTinDonKhachItem> GetListTaiXe(int CurrentPage, int PageSize, string Field, bool FieldOption, string Keyword, List<string> SearchInField)
        {
            using (var context = new FoldioContext())
            {
                GetCurrentUser();
                var query = (from p in context.TS_ThongTinDonKhach
                             select new ThongTinDonKhachItem()
                             {
                                 ID = p.ID,
                                 NgayKhoiHanh = p.NgayKhoiHanh,
                                 SoDienThoai = p.SoDienThoai,
                                 SoGhe = p.SoGhe,
                                 isTrungChuyen = p.isTrungChuyen,
                                 DiaChi = p.DiaChi,
                                 TenKhuVuc = p.KhuVucID.HasValue ? p.TS_KhuVuc.Ten : "",
                                 TenPhuongXa = p.PhuongXaID.HasValue ? p.TS_PhuongXa.TenPhuongXa : "",
                                 TenDuongAp = p.DuongApID.HasValue ? p.TS_DuongAp.TenDuongAp : "",
                                 GioKhoiHanh = p.DanhMucChuyenID.HasValue ? p.TS_DanhMucChuyen.GioKhoiHanh : 0,
                                 PhutKhoiHanh = p.DanhMucChuyenID.HasValue ? p.TS_DanhMucChuyen.PhutKhoiHanh : 0,


                             });

                query = query.SortPaging(Field, FieldOption, PageSize, CurrentPage, Keyword, SearchInField, ref TotalRecord);
                return query.ToList();
            }
        }

        public List<ThongTinDonKhachItem> GetListThongTinDonKhach(int CurrentPage, int PageSize, string Field, bool FieldOption, string Keyword, List<string> SearchInField)
        {
            using (var context = new FoldioContext())
            {
                GetCurrentUser();
                var query = (from p in context.TS_ThongTinDonKhach
                             select new ThongTinDonKhachItem()
                             {
                                 ID = p.ID,
                                 NgayKhoiHanh = p.NgayKhoiHanh,
                                 SoDienThoai = p.SoDienThoai,
                                 SoGhe = p.SoGhe,
                                 isTrungChuyen = p.isTrungChuyen,
                                 DiaChi = p.DiaChi,
                                 TenKhuVuc = p.KhuVucID.HasValue ? p.TS_KhuVuc.Ten : "",
                                 TenPhuongXa = p.PhuongXaID.HasValue ? p.TS_PhuongXa.TenPhuongXa : "",
                                 TenDuongAp = p.DuongApID.HasValue ? p.TS_DuongAp.TenDuongAp : "",
                                 GioKhoiHanh = p.DanhMucChuyenID.HasValue ? p.TS_DanhMucChuyen.GioKhoiHanh : 0,
                                 PhutKhoiHanh = p.DanhMucChuyenID.HasValue ? p.TS_DanhMucChuyen.PhutKhoiHanh : 0,
                                 

                             });

                query = query.SortPaging(Field, FieldOption, PageSize, CurrentPage, Keyword, SearchInField, ref TotalRecord);
                return query.ToList();
            }
        }

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
                             }).OrderBy(p => p.Ten).ToList();
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
                    text = p.TenDuongAp,

                }).ToList();
                return listduongap;
            }
        }
        public List<LookupData> GetListDanhMucChuyen(int khuvucID, int? dayofweek)
        {
            using (var context = new FoldioContext())
            {
                var listdanhmucchuyen = context.TS_DanhMucChuyen.Where(p => p.KhuVucID == khuvucID && p.TS_DanhMucChuyenDetail.Any(x => x.DayOfWeek == dayofweek)).Select(p => new LookupData()
                {
                    id = p.ID.ToString(),
                    text = (p.GioKhoiHanh < 10 ? "0" + p.GioKhoiHanh.ToString() : p.GioKhoiHanh.ToString()) + " : " + (p.PhutKhoiHanh < 10 ? "0" + p.PhutKhoiHanh.ToString() : p.PhutKhoiHanh.ToString()),
                }).ToList();
                return listdanhmucchuyen;
            }
        }
    }
}
