<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AjaxListTaiXe.aspx.cs" Inherits="Viags.WebApp.Transit.DanhSachTaiXe.AjaxListTaiXe" %>

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
            debugger
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
                url = url
                    .replace("Field=ChuyenMuc", parameters)
                    .replace("Field=TieuDe", parameters);
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
    </script>
</head>
<body>

    <div class="content-padding" id="gridDanhMuc">
        <div class="data-table <%--table-responsive--%>">
            <table class="table table-bordered table-hover table-striped-custom <%--table-responsive--%> gridView">
                <thead>
                    <tr>
                        <th class="text-center text-justify" style="width: 10%"><%=Resources.TinTuc.lblThuTu %></th>
                        <th class="text-center text-justify" style="width: 8%">Tên tài xế</th>
                        <th class="text-center text-justify" style="width: 10%">SDT</th>
                        <th class="text-center text-justify" style="width: 10%">Loại xe</th>
                        <th class="text-center text-justify" style="width: 10%">Khu vực</th>
                        <th class="text-center text-justify" style="width: 10%">Trạng thái</th>
                        <th class="text-center text-justify" style="width: 10%">Vị trí GPS</th>                             
                        <th class="text-center text-justify" style="width: 20%">Thao tác</th>

                        <th class="act_edit text-center text-justify"></th>
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

                    <%foreach (var item in LstDonKhach)
                        {%>

                    <tr title="<%=item.TenKhuVuc %>">
                        <td class="text-center" style="display: none"><%:item.ID %></td>
                        <td class="text-center"><%:Index %></td>
                        <td class="text-center"><%:(item.GioKhoiHanh<10?"0"+item.GioKhoiHanh: item.GioKhoiHanh.ToString())+":"+(item.PhutKhoiHanh<10?"0"+item.PhutKhoiHanh: item.PhutKhoiHanh.ToString()) %></td>
                        <td class="text-center"><%:item.TenPhuongXa %></td>
                        <td></td>
                        <td class="text-center"><%:item.TenDuongAp %></td>
                        <td class="text-center"><%=item.SoDienThoai%></td>
                        <td class="text-center"><%=item.SoGhe %></td>

                        <td class="text-center text-justify"><%=item.TrangThai%></td>
                 

                        <td class="act_edit"></td>

                        <td class="act_delete"></td>

                        <td class="act_roles text-center">
                            <input value="<%=item.ID %>" type="checkbox" />
                        </td>


                    </tr>
                    <%Index++;
                        } %>
                </tbody>
            </table>
        </div>
        <%=HtmlPager%>
    </div>

</body>
</html>
