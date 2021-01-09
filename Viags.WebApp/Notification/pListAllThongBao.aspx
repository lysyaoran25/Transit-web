<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pListAllThongBao.aspx.cs" Inherits="Viags.WebApp.Notification.pListAllThongBao" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        $(document).ready(function () {
            registerGridView('#gridDanhMuc');
        });

        /* Thêm vào nhằm kết hợp sort + search */
        $('.gridView thead tr th a').not(".deleteAll, .showAll, .hideAll").click(function (e) {
            var url = window.location.href;
            var parameters;
            var link = $(this).attr("href");
            link = link.substring(1, link.length);
            if (url.indexOf(link) > 0) {
                if (url.indexOf('FieldOption=1') > 0) {
                    $(this).addClass('desc');
                    $(this).attr("href", '#' + link + '&FieldOption=0');
                    parameters = link + '&FieldOption=0';
                } else {
                    $(this).addClass('asc');
                    $(this).attr("href", '#' + link + '&FieldOption=1');
                    parameters = link + '&FieldOption=1';
                }
            } else {
                parameters = url.indexOf('#') >= 0 ? $(this).attr('href').substring(1) : $(this).attr('href');
            }
            var index = url.indexOf('Field');
            if (index >= 0) {
                //Không giữ được kết quả tìm kiếm khi click chuyển trang, sau đó click tiêu đề cột
                if (url.indexOf('FieldOption')) {
                    url = url.replace("&FieldOption=1", "").replace("&FieldOption=0", "")
                }
                url = url.replace("Field=ID", parameters).replace("Field=NoiDung", parameters).replace("Field=NgayTao", parameters).replace("Field=KieuID", parameters);
                window.location.href = url;
            } else {
                if (url.indexOf('#') > 0) {
                    url = url + '&' + parameters;
                } else {
                    url = url + parameters;
                }
            }
            window.location.href = url;
            e.preventDefault();
        });
        function updatestatus(id) {
            $.ajax({
                type: "POST",
                url: "/api/notification.asmx/updatestatus",
                data: "{id:'" + id + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (msg) {
                }
            });
        }
    </script>
    <style type="text/css">
        .tdunread {
            background: #d6b48e !important;
        }
    </style>
</head>
<body>
    <div class="content-padding" id="gridDanhMuc">
        <div class="data-table table-responsive">
            <table class="table table-bordered table-hover table-striped-custom table-responsive gridView">
                <thead>
                    <tr>
                        <th class="text-center" style="width: 6%"><a href="#Field=ID"><%=Resources.Notification.lblSTT %><span /></a></th>
                        <th class="text-center" style="width: 12%"><a href="#Field=KieuID"><%=Resources.Notification.lblChucNang %><span /></a></th>
                        <th class="text-center" style="width: 68%"><a href="#Field=NoiDung"><%=Resources.Notification.lblNoiDung %><span /></a></th>
                        <th class="text-center"><a href="#Field=NgayTao"><%=Resources.Notification.lblThoiGian %> <span /></a></th>
                        <th class="act_delete text-center">
                            <a href="#deleteAll" class="deleteAll" title="<%=Resources.Notification.lblXoaDanhSachDaChon %>">
                                <img alt="" src="/Publishing_Resources/img/LastIcon/delete.gif" style="border: none" title="<%=Resources.Notification.lblXoaDanhSachDaChon %>" />
                            </a>
                        </th>
                        <th class="act_roles text-center">
                            <input value="" type="checkbox" class="checkAll" />
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <%--<%int i = 0; %>--%>
                    <%foreach (Viags.Simple.NotificationItem item in LtsNotification)
                        { %>
                    <%--<%i++; %>--%>
                    <tr <%--title="<%=item.NoiDung %>"--%>>
                        <%if (!item.TrangThaiID)
                        { %>
                        <td class="text-center tdunread"><%:Index %></td>
                        <td class="tdunread">
                            <%if (item.KieuID == (int)Viags.Utils.Enum.ThongBao.ChuongTrinhCongTac)
                                { %>
                            <%=Resources.Notification.lblChuongTrinhCongTac %>
                            <%} %>
                            <%if (item.KieuID == (int)Viags.Utils.Enum.ThongBao.CongViec)
                                { %>
                            <%=Resources.Notification.lblCongViec %>
                            <%} %>
                            <%if (item.KieuID == (int)Viags.Utils.Enum.ThongBao.DatPhong)
                                { %>
                            <%=Resources.Notification.lblDatPhong %>
                            <%} %>
                            <%if (item.KieuID == (int)Viags.Utils.Enum.ThongBao.DuThao)
                                { %>
                            <%=Resources.Notification.lblDuThao %>
                            <%} %>
                            <%if (item.KieuID == (int)Viags.Utils.Enum.ThongBao.LichLamViec)
                                { %>
                            <%=Resources.Notification.lblLichLamViec %>
                            <%} %>
                            <%if (item.KieuID == (int)Viags.Utils.Enum.ThongBao.VanBanDen)
                                { %>
                            <%=Resources.Notification.lblVanBanDen %>
                            <%} %>
                            <%if (item.KieuID == (int)Viags.Utils.Enum.ThongBao.VanBanDi)
                                { %>
                            <%=Resources.Notification.lblVanBanDi %>
                            <%} %>
                            <%if (item.KieuID == (int)Viags.Utils.Enum.ThongBao.XuLyKienNghi)
                                { %>
                            <%=Resources.Notification.lblXuLyKienNghi %>
                            <%} %>
                            <%if (item.KieuID == (int)Viags.Utils.Enum.ThongBao.DatXe)
                                { %>
                            <%=Resources.Notification.lblDatXe %>
                            <%} %>
                            <%if (item.KieuID == (int)Viags.Utils.Enum.ThongBao.ThongBaoTinTuc)
                                { %>
                            <%=Resources.ThongBao.lblThongBao %>
                            <%} %>
                            <%if (item.KieuID == (int)Viags.Utils.Enum.ThongBao.TinTucSuKien)
                                { %>
                            <%=Resources.TinTuc.lblTinTuc %>
                            <%} %>
                            <%if (item.KieuID == (int)Viags.Utils.Enum.ThongBao.NghiPhep)
                                { %>
                            Nghỉ phép
                            <%} %>
                            <%if (item.KieuID == (int)Viags.Utils.Enum.ThongBao.LichDatPhong)
                                { %>
                            Lịch đặt phòng
                            <%} %>
                            <%if (item.KieuID == (int)Viags.Utils.Enum.ThongBao.TrungTamGiaiDap)
                                { %>
                            Trung tâm giải đáp
                            <%} %>
                            <%if (item.KieuID == (int)Viags.Utils.Enum.ThongBao.DatCom)
                                { %>
                            Thông tin ca - cơm
                            <%} %>
                            <%if (item.KieuID == (int)Viags.Utils.Enum.ThongBao.BaoCaoCongViec)
                                { %>
                            Báo cáo công việc
                            <%} %>
                            <%if (item.KieuID == (int)Viags.Utils.Enum.ThongBao.YeuCauTuyenDung)
                                { %>
                            Yêu cầu tuyển dụng
                            <%} %>
                        </td>
                        <td class="tdunread"><a href="<%=item.Link %>" onclick="updatestatus(<%=item.ID %>)"><%=item.NoiDung %></a></td>
                        <td class="tdunread"><%=string.Format("{0:dd/MM/yyyy}", item.NgayTao)%></td>
                        <td class="act_delete tdunread">
                            <%=Viags.Utils.FoldioHtml.GridDelete(item.ID, item.Ten, true)%>
                        </td>
                        <td class="act_roles tdunread">
                            <input type="checkbox" value="<%=item.ID %>" />
                        </td>
                        <%} %>
                        <%else
                        { %>
                        <td class="text-center "><%:Index %></td>
                        <td>
                            <%if (item.KieuID == (int)Viags.Utils.Enum.ThongBao.ChuongTrinhCongTac)
                                { %>
                            <%=Resources.Notification.lblChuongTrinhCongTac %>
                            <%} %>
                            <%if (item.KieuID == (int)Viags.Utils.Enum.ThongBao.CongViec)
                                { %>
                            <%=Resources.Notification.lblCongViec %>
                            <%} %>
                            <%if (item.KieuID == (int)Viags.Utils.Enum.ThongBao.DatPhong)
                                { %>
                            <%=Resources.Notification.lblDatPhong %>
                            <%} %>
                            <%if (item.KieuID == (int)Viags.Utils.Enum.ThongBao.DuThao)
                                { %>
                            <%=Resources.Notification.lblDuThao %>
                            <%} %>
                            <%if (item.KieuID == (int)Viags.Utils.Enum.ThongBao.LichLamViec)
                                { %>
                            <%=Resources.Notification.lblLichLamViec %>
                            <%} %>
                            <%if (item.KieuID == (int)Viags.Utils.Enum.ThongBao.VanBanDen)
                                { %>
                            <%=Resources.Notification.lblVanBanDen %>
                            <%} %>
                            <%if (item.KieuID == (int)Viags.Utils.Enum.ThongBao.VanBanDi)
                                { %>
                            <%=Resources.Notification.lblVanBanDi %>
                            <%} %>
                            <%if (item.KieuID == (int)Viags.Utils.Enum.ThongBao.XuLyKienNghi)
                                { %>
                            <%=Resources.Notification.lblXuLyKienNghi %>
                            <%} %>
                            <%if (item.KieuID == (int)Viags.Utils.Enum.ThongBao.DatXe)
                                { %>
                            <%=Resources.Notification.lblDatXe %>
                            <%} %>
                            <%if (item.KieuID == (int)Viags.Utils.Enum.ThongBao.ThongBaoTinTuc)
                                { %>
                            <%=Resources.ThongBao.lblThongBao %>
                            <%} %>
                            <%if (item.KieuID == (int)Viags.Utils.Enum.ThongBao.TinTucSuKien)
                                { %>
                            <%=Resources.TinTuc.lblTinTuc %>
                            <%} %>
                            <%if (item.KieuID == (int)Viags.Utils.Enum.ThongBao.NghiPhep)
                                { %>
                            Nghỉ phép
                            <%} %>
                            <%if (item.KieuID == (int)Viags.Utils.Enum.ThongBao.LichDatPhong)
                                { %>
                            Lịch đặt phòng
                            <%} %>
                            <%if (item.KieuID == (int)Viags.Utils.Enum.ThongBao.TrungTamGiaiDap)
                                { %>
                            Trung tâm giải đáp
                            <%} %>
                            <%if (item.KieuID == (int)Viags.Utils.Enum.ThongBao.DatCom)
                                { %>
                            Thông tin ca - cơm
                            <%} %>
                            <%if (item.KieuID == (int)Viags.Utils.Enum.ThongBao.BaoCaoCongViec)
                                { %>
                            Báo cáo công việc
                            <%} %>
                            <%if (item.KieuID == (int)Viags.Utils.Enum.ThongBao.YeuCauTuyenDung)
                                { %>
                            Yêu cầu tuyển dụng
                            <%} %>
                        </td>
                        <td><a href="<%=item.Link %>"><%=item.NoiDung%></a></td>
                        <td><%=string.Format("{0:dd/MM/yyyy}", item.NgayTao)%></td>
                        <td class="act_delete">
                            <%=Viags.Utils.FoldioHtml.GridDelete(item.ID, item.Ten, true)%>
                        </td>
                        <td class="act_roles">
                            <input type="checkbox" value="<%=item.ID %>" />
                        </td>
                        <%} %>
                    </tr>
                    <%Index++;
                        } %>
                </tbody>
            </table>
        </div>
        <%=HtmlPager %>
    </div>
</body>
</html>
