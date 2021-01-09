<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AjaxList.aspx.cs" Inherits="Viags.WebApp.QuanLyDashBoard.NhanVienXuatSac.AjaxList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script>
        $(document).ready(function () {
            registerGridView('#NhanVienXuatSac');
        });

        $('.gridView thead tr th a').not(".deleteAll, .showAll, .hideAll, .sendAll").click(function (e) {
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
                url = url.replace("Field=ID", parameters).replace("Field=ChuDe", parameters).replace("Field=ThoiGianBatDau", parameters).replace("Field=ThoiGianKetThuc", parameters).replace("Field=SoNguoi", parameters).replace("Field=TrangThaiID", parameters).replace("Field=TotalDanhMucTen", parameters);
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

        function OpenEdit(id) {
            $('body').modalmanager('loading');
            $('#dialog-form').load("/QuanLyDashBoard/NhanVienXuatSac/AjaxForm.aspx?do=edit&ItemID=" + id, function () {
                $('#dialog-form').modal({ width: 650 });
            });
        }
    </script>
</head>
<body>
    <div class="content-padding" id="NhanVienXuatSac">
        <div class="data-table">
            <table class="table table-bordered table-hover table-striped-custom gridView">
                <thead>
                    <tr>
                        <th class="text-center text-justify" style="width: 3%">STT</th>
                        <th class="text-center text-justify" style="width: 5%">Mã NV</th>
                        <th class="text-center text-justify" style="width: 17%">Tên NV</th>
                        <th class="text-center text-justify" style="width: 10%">Mô tả</th>
                        <th class="text-center text-justify" style="width: 8%">Tháng</th>
                        <th class="text-center text-justify" style="width: 8%">Quý</th>
                        <th class="text-center text-justify" style="width: 10%">Phòng ban</th>
                        <th class="text-center text-justify" style="width: 8%">Khu vực</th>
                        <th class="text-center text-justify" style="width: 17%">Người tạo</th>
                        <th class="text-center text-justify" style="width: 12%">Ngày tạo</th>
                        <th class="text-center text-justify" style="width: 13%">Trạng thái</th>

                        <th></th>
                        <th class="act_delete text-center">
                            <a href="#deleteAll" class="deleteAll" title="<%=Resources.TinTuc.lblXoaDanhSachDaChon %>">
                                <img alt="" src="/Publishing_Resources/img/LastIcon/delete.gif" style="border: none" title="<%=Resources.BieuMau.lblXoaDanhSachDaChon %>" />
                            </a>
                        </th>
                        <th class="act_roles text-center">
                            <input value="" type="checkbox" class="checkAll" />
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <%foreach (var item in nhanVienXuatSacItems)
                        { %>
                    <tr>
                        <td class="text-center"><%:Index %></td>
                        <td class="text-center"><%:item.MaNV %></td>
                        <td class="text-center"><%:item.TenNguoiDung %></td>
                        <td class="text-center"><%:item.Mota %></td>
                        <td class="text-center"><%=string.IsNullOrEmpty(item.Thang.ToString())?string.Empty:item.Thang.ToString()+ "/"+item.Nam %></td>
                        <td class="text-center"><%=string.IsNullOrEmpty(item.Quy.ToString())?string.Empty:"Quý "+ item.Quy.ToString()+ "/"+item.Nam %></td>
                        <td class="text-center"><%:item.TenPhongBan %></td>
                        <td class="text-center"><%:item.TenDonVi %></td>
                        <td class="text-center"><%:item.TenNguoiTao %></td>
                        <td class="text-center"><%:string.Format("{0:dd/MM/yyyy}",item.NgayTao) %></td>
                        <td class="text-center text-justify"><%=Viags.Utils.FoldioHtml.LabelAppearOrHide(item.HienThi)%></td>
                        <%if (item.DonViID == CurrentUser.DonViID)
                            {%>
                        <td class="act_edit">
                            <a onclick="OpenEdit(<%=item.ID %>)" class="edit" title="Cập nhật"><span style="color: green"><i class="fas fa-pencil-alt"></i></span></a>
                        </td>
                        <td class="act_delete">
                            <%=Viags.Utils.ViagsHtml.GridDelete(item.ID, item.TenNguoiDung, true)%>
                        </td>
                        <td class="act_roles text-center">
                            <input value="<%=item.ID %>" type="checkbox" title="Chọn: " />
                        </td>
                        <%}
                            else
                            { %>
                        <td></td>
                        <td></td>
                        <td></td>
                        <%} %>
                    </tr>
                    <% Index++;
                        } %>
                </tbody>
            </table>
        </div>
        <%=HtmlPager %>
    </div>
</body>
</html>
