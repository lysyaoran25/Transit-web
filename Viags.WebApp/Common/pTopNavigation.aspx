<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pTopNavigation.aspx.cs" Inherits="Viags.WebApp.Common.pTopNavigation" %>

<%
    //var thongBaoChung = LtsThongBaoChung.Where(x => x.TrangThaiID == false).ToList();
    //var vanBanChung = LtsThongBaoChungVanBan.Where(x => x.TrangThaiID == false).ToList();
    //var congViec = LtsThongBaoChungCongViec.Where(x => x.TrangThaiID == false).ToList();
    //var luutru = LtsThongBaoChungLuuTru.Where(x => x.TrangThaiID == false).ToList();
    var url = string.Format("https://mail.tinhvan.com/worldclient.dll?View=Main&User={0}&Password={1}",(CurrentUser.TenTruyCap + "@tinhvan.com"),"123Abc");
%>

<li class="dropdown dropdown-extended dropdown-inbox hasAccount" style="padding-top: 1.3em;padding-left: 5px;">
    <div class="sidebar-toggler" id="IdMenuToggle">
        <a href="#"><i class="fas fa-bars"></i></a>
    </div>
</li>

<!-- BEGIN NOTIFICATION DROPDOWN -->
<!-- thông báo mới -->
<li class="dropdown dropdown-extended dropdown-notification hasAccount" id="header_notification_bar7" title="<%=Resources.Other.lblThongBaoChungGuiDenBan %>">
    <a href="javascript:;" class="dropdown-toggle" data-toggle="dropdown" data-hover="dropdown" data-close-others="true" >
        <i class="icon-bell"></i>
       <%-- <%if (thongBaoChung.Count > 0)
          { %>
        <span class="badge badge-default"><%=thongBaoChung.Count %>
        </span>
        <%} %>--%>
    </a>
    <ul class="dropdown-menu">
        <li class="external">
            <h3><%=Resources.Other.lblBanCo %> <span class="bold"><%--<%=thongBaoChung.Count  %>--%> <%=Resources.Other.lblThongBaoMoi %></span> 
            </h3>
            <%-- <a title="Xóa tất cả" class="btnDeleteAll" rel="<%=Viags.Utils.Enum.ThongBao.ThongBaoChung %>">Xóa tất cả</a>--%>
        </li>
        <li>
            <ul class="dropdown-menu-list scroller" style="height: 275px;" data-handle-color="#637283">
                <%--<%foreach (var item in LtsThongBaoChung.Take(20))
                  {%>
                <li class="content-noti <%:item.TrangThaiID == true ? "": "unread" %>">
                    <img src="/Publishing_Resources/img/icon_close.png" alt="<%=Resources.Other.lblXoaThongBao %>" class="btnaction" rel="<%:item.ID %>" style="float: right" />
                    <a href="<%=item.Link %>" class="addtome" id="<%:item.ID%>" target="_blank">
                        <span class="photo">
                            <img width="50" src="<%:string.IsNullOrEmpty(item.AnhDaiDien)? "/Publishing_Resources/img/avatar.png" : "/Publishing_Resources/img/avatar.png" %>" alt="<%:item.TenNguoiGui %>" title="<%:item.TenNguoiGui %>" class="avatar" />
                        </span>
                        <span class="subject">
                            <span class="from"><%=item.TenNguoiGui %> 
                            </span>
                            <span class="time" style="float: inherit"><%=string.Format("{0:dd/MM/yyyy hh:mm tt}",item.NgayTao.Value ) %></span>
                        </span>
                        <span class="message">
                            <%  
                                HttpCookie cookie = Request.Cookies["ngonngu"];
                                if (cookie != null && cookie.Value != null)
                                {
                                    if (cookie.Value.ToString() == "en-US")
                                    {
                            %>
                                        <%=item.NoiDungTiengAnh %>
                            <%
                                    }
                                    else
                                    {
                                        if (cookie.Value.ToString() == "vi-VN")
                                        {
                            %>
                                            <%=item.NoiDung %>
                            <%                                
                                        }
                                    }
                                }
                                else
                                {
                            %>
                                    <%=item.NoiDung %>
                            <%
                                }
                            %>
                        </span>
                    </a>
                </li>
                <%} %>--%>
            </ul>
        </li>
        <li class="external">
            <h3><span class="bold" style="margin-left: 85px"><a style="color: #62878f" href="/Pagess/danh-sach-notification.aspx"><%=Resources.Other.lblXemTatCa %></a></span>
            </h3>
        </li>
    </ul>
</li>

<!-- END NOTIFICATION DROPDOWN -->
<!-- BEGIN INBOX -->
<li class="dropdown dropdown-extended dropdown-inbox hasAccount" id="header_inbox_bar" title="<%=Resources.Other.lblThongBaoNhomVanBanGuiDenBan %>">
    <a href="javascript:;" class="dropdown-toggle" data-toggle="dropdown" data-hover="dropdown" data-close-others="true">
        <i class="icon-envelope-open"></i>
       <%-- <%if (vanBanChung.Count > 0)
          { %>
        <span class="badge badge-default"><%=vanBanChung.Count %>
        </span>
        <%} %>--%>
    </a>
    <ul class="dropdown-menu">
        <li class="external">
            <h3><%=Resources.Other.lblBanCo %> <span class="bold"><%--<%=vanBanChung.Count %--%>> <%=Resources.Other.lblThongBao %></span> <%=Resources.Other.lblMoiVeVanBanDen %>
            </h3>
            <%--<a title="Xóa tất cả" class="btnDeleteAll" rel="<%=Viags.Utils.Enum.ThongBao.VanBanDen %>">Xóa tất cả</a>--%>
        </li>
        <li>
            <ul class="dropdown-menu-list scroller" style="height: 275px;" data-handle-color="#637283">
                <%--<%foreach (var item in LtsThongBaoChungVanBan.OrderByDescending(x => x.ID).Take(25))
                  {%>
                <li class="content-noti <%:item.TrangThaiID == true ? "": "unread" %>">
                    <img src="/Publishing_Resources/img/icon_close.png" alt="<%=Resources.Other.lblXoaThongBao %>" class="btnaction" rel="<%:item.ID %>" style="float: right" />
                    <a href="<%=item.Link %>" class="addtome" id="<%:item.ID %>" target="_blank">
                        <span class="photo">
                            <img width="50" src="<%:string.IsNullOrEmpty(item.AnhDaiDien)? "/Publishing_Resources/img/avatar.png" :  "/Publishing_Resources/img/avatar.png" %>" alt="<%:item.TenNguoiGui %>" title="<%:item.TenNguoiGui %>" class="avatar" />
                        </span>
                        <span class="subject">
                            <span class="from"><%=item.TenNguoiGui %>
                            </span>
                            <span class="time" style="float: inherit"><%=string.Format("{0:dd/MM/yyyy hh:mm tt}",item.NgayTao.Value ) %></span>
                        </span>
                        <span class="message">
                            <%  
                                HttpCookie cookie = Request.Cookies["ngonngu"];
                                if (cookie != null && cookie.Value != null)
                                {
                                    if (cookie.Value.ToString() == "en-US")
                                    {
                            %>
                                        <%=item.NoiDungTiengAnh %>
                            <%
                                    }
                                    else
                                    {
                                        if (cookie.Value.ToString() == "vi-VN")
                                        {
                            %>
                                            <%=item.NoiDung %>
                            <%                                
                                        }
                                    }
                                }
                            %>

                        </span>
                    </a>
                </li>
                <%} %>--%>
            </ul>
        </li>
        <li class="external">
            <h3><span class="bold" style="margin-left: 85px"><a style="color: #62878f" href="/Pagess/danh-sach-notification.aspx"><%=Resources.Other.lblXemTatCa %></a></span>
            </h3>
        </li>
    </ul>
</li>

<!-- END TODO DROPDOWN -->
<!-- BEGIN TODO DROPDOWN -->
<li class="dropdown dropdown-extended dropdown-tasks hasAccount" id="header_task_bar2" title="<%=Resources.Other.lblThongBaoNhomDieuHanhGuiDenBan %>">
    <a href="javascript:;" class="dropdown-toggle" data-toggle="dropdown" data-hover="dropdown" data-close-others="true">
        <i class="icon-wrench"></i>
        <%--<%if (congViec.Count > 0)
          { %>
        <span class="badge badge-default"><%=congViec.Count %>
        </span>
        <%} %>--%>
    </a>
    <ul class="dropdown-menu">
        <li class="external">
            <h3><%=Resources.Other.lblBanCo %> <span class="bold"><%--<%=congViec.Count %>--%> <%=Resources.Other.lblTinNhan %></span> <%=Resources.Other.lblMoiVeCongViec %>
            </h3>
            <%-- <a title="Xóa tất cả" class="btnDeleteAll" rel="<%=Viags.Utils.Enum.ThongBao.CongViec %>">Xóa tất cả</a>--%>
        </li>
        <li>
            <ul class="dropdown-menu-list scroller" style="height: 275px;" data-handle-color="#637283">
                <%--<%foreach (var item in LtsThongBaoChungCongViec.OrderByDescending(x => x.ID).Take(25))
                  {%>
                <li class="content-noti <%:item.TrangThaiID == true ? "": "unread" %>">
                    <img src="/Publishing_Resources/img/icon_close.png" alt="<%=Resources.Other.lblXoaThongBao %>" class="btnaction" rel="<%:item.ID %>" style="float: right" />
                    <a href="<%=item.Link %>" class="addtome" id="<%=item.ID %>" target="_blank">
                        <span class="photo">
                            <img width="50" src="<%:string.IsNullOrEmpty(item.AnhDaiDien)? "/Publishing_Resources/img/avatar.png" :  "/Publishing_Resources/img/avatar.png" %>" alt="<%:item.TenNguoiGui %>" title="<%:item.TenNguoiGui %>" class="avatar" />
                        </span>
                        <span class="subject">
                            <span class="from"><%=item.TenNguoiGui %>
                            </span>
                            <span class="time" style="float: inherit"><%=string.Format("{0:dd/MM/yyyy hh:mm}",item.NgayTao.Value ) %></span>
                        </span>
                        <span class="message">
                            <%  
                                HttpCookie cookie = Request.Cookies["ngonngu"];
                                if (cookie != null && cookie.Value != null)
                                {
                                    if (cookie.Value.ToString() == "en-US")
                                    {
                            %>
                                        <%=item.NoiDungTiengAnh %>
                            <%
                                    }
                                    else
                                    {
                                        if (cookie.Value.ToString() == "vi-VN")
                                        {
                            %>
                                            <%=item.NoiDung %>
                            <%                                
                                        }
                                    }
                                }
                                else
                                {
                            %>
                                    <%=item.NoiDung %>
                            <%
                                }
                            %>
                        </span>

                    </a>
                </li>
                <%} %>--%>
            </ul>
        </li>
        <li class="external">
            <h3><span class="bold" style="margin-left: 85px"><a style="color: #62878f" href="/Pagess/danh-sach-notification.aspx"><%=Resources.Other.lblXemTatCa %></a></span>
            </h3>
        </li>
    </ul>
</li>


<!-- BEGIN TODO DROPDOWN -->
<li class="dropdown dropdown-extended dropdown-tasks hasAccount" id="header_task_bar2" title="<%=Resources.Other.lblThongBaoNhomDieuHanhGuiDenBan %>">
    <a href="/Pagess/emailMD.aspx" class="dropdown-toggle" style="padding-right:10px;">
        <i class="icon-envelope"></i>
      <%--  <%if (congViec.Count > 0)
          { %>
        <span class="badge badge-default"><%=congViec.Count %>
        </span>
        <%} %>--%>
    </a>
</li>

<%--<li class="dropdown dropdown-extended dropdown-tasks hasAccount" id="header_task_bar4" title="Thông báo nhóm lưu trữ gửi đến bạn">
    <a href="javascript:;" class="dropdown-toggle" data-toggle="dropdown" data-hover="dropdown" data-close-others="true">
        <i class="fa fa-database"></i>
        <%if (luutru.Count > 0)
          { %>
        <span class="badge badge-default"><%=luutru.Count %>
        </span>
        <%} %>
    </a>
    <ul class="dropdown-menu">
        <li class="external">
            <h3>Bạn có <span class="bold"><%=luutru.Count %> tin nhắn</span> mới về lưu trữ hồ sơ
            </h3>
        </li>
        <li>
            <ul class="dropdown-menu-list scroller" style="height: 275px;" data-handle-color="#637283">
                <%foreach (var item in LtsThongBaoChungLuuTru.OrderByDescending(x => x.ID).Take(25))
                  {%>
                <li class="content-noti <%:item.TrangThaiID == true ? "": "unread" %>">
                    <img src="/Publishing_Resources/img/icon_close.png" alt="Xóa thông báo" class="btnaction" rel="<%:item.ID %>" style="float: right" />
                    <a href="<%=item.Link %>" class="addtome" id="<%=item.ID %>" target="_blank">
                        <span class="photo">
                            <img width="50" src="<%:string.IsNullOrEmpty(item.AnhDaiDien)? "/Publishing_Resources/img/avatar.png" :  "/Publishing_Resources/img/avatar.png" %>" alt="<%:item.TenNguoiGui %>" title="<%:item.TenNguoiGui %>" class="avatar" />
                        </span>
                        <span class="subject">
                            <span class="from"><%=item.TenNguoiGui %>
                            </span>
                            <span class="time" style="float: inherit"><%=string.Format("{0:dd/MM/yyyy hh:mm}",item.NgayTao.Value ) %></span>
                        </span>
                        <span class="message"><%=item.NoiDung %>
                        </span>

                    </a>
                </li>
                <%} %>
            </ul>
        </li>
        <li class="external">
            <h3><span class="bold" style="margin-left: 85px"><a style="color: #62878f" href="/Pagess/danh-sach-notification.aspx">Xem tất cả</a></span>
            </h3>
        </li>
    </ul>
</li>--%>
<!-- END TODO DROPDOWN -->
<!-- BEGIN USER LOGIN DROPDOWN -->
<!-- DOC: Apply "dropdown-dark" class after below "dropdown-extended" to change the dropdown styte -->

<script>
    $(document).ready(function () {
        $(".btnaction").click(function () {
            var id = $(this).attr("rel");
            if (id > 0) {
                deleteitem(id);
                LoadAjaxPage("/Common/pTopNavigation.aspx", "#divNotification");
            }
        });
        $("a.dropdown-toggle").click(function () {
            if ($(this).parent().attr("class").indexOf("open") != -1) {
                $(this).next().hide();
                return;
            }
            $("#divNotification .dropdown-menu").hide();
            $("#divNotification li.dropdown").removeClass("open");
            $(this).next().show();
            var _divscroll = $(this).next().find(".slimScroll");
            if (_divscroll.height() > 350) {
                _divscroll.slimScroll({
                    color: '#3CC051',
                    height: '350px',
                    alwaysVisible: true,
                    railColor: '#222'
                });
            };
            var listid = $(this).attr("data");
            if (listid != "") {
                //updateall(listid);
                $(this).find(".badge").attr("rel", "-1").html("");
            };
        });
        $(".page-content").click(function () {
            $("#divNotification .dropdown-menu").hide();
            $("#divNotification li.dropdown").removeClass("open");
        });
        $(".page-sidebar").click(function () {
            $("#divNotification .dropdown-menu").hide();
            $("#divNotification li.dropdown").removeClass("open");
        });
        $(".btnDeleteAll").click(function () {
            var type = $(this).attr("alt");
            deleteall(type);
            $(this).parent().find(".title-noti").html("&nbsp;");
            //Ẩn div hiển thị danh sách thông báo
            $(this).parent().parent().next().slideUp();
            //Thay đổi lại số thông báo đỏ
            $(this).parent().parent().parent().parent().find(".badge").html("0");
            $(this).parent().parent().parent().parent().find(".badge").attr("rel", "0");
        });

        $(".addtome").click(function () {
            $(this).parent().removeClass("unread");
            updatestatus($(this).attr("id"));
        });
        $('ul.scroller').slimScroll({
            color: '#3CC051',
            height: '280px',
            alwaysVisible: true,
            railColor: '#222'
        });
    });

    //Update trạng thái thông báo đã đọc
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
    //Xóa notification
    function deleteitem(id) {
        $.ajax({
            type: "POST",
            url: "/api/notification.asmx/deletenotification",
            data: "{id:'" + id + "'}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (msg) {
            }
        });
    }
    //xóa tất cả notification theo loại
    function deleteall(type) {
        <%--$.ajax({
            type: "POST",
            url: "/api/notification.asmx/deleteallnotification",
            data: "{type:'" + type + "','nguoidung':'" +<%:CurrentUser.ID%> +"'}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (msg) {
            }
        });--%>
    }
    //Cập nhật notification
    function updateall(listid) {
        $.ajax({
            type: "POST",
            url: "/api/notification.asmx/updateallnotification",
            data: "{listid:'" + listid + "'}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (msg) {
            }
        });
    }
</script>
<style type="text/css">
    ul.scroller {
        overflow-x: auto !important;
    }
</style>
