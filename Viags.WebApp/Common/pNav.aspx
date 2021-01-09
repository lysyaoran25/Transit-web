<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pNav.aspx.cs" Inherits="Viags.WebApp.Common.pNav" %>

<%
    //var thongBaoChung = LtsThongBaoChung.Where(x => x.TrangThaiID == false).ToList();
    //var vanBanChung = LtsThongBaoChungVanBan.Where(x => x.TrangThaiID == false).ToList();
    //var congViec = LtsThongBaoChungCongViec.Where(x => x.TrangThaiID == false).ToList();
    //var luutru = LtsThongBaoChungLuuTru.Where(x => x.TrangThaiID == false).ToList();
    var url = string.Format("https://mail.tinhvan.com/worldclient.dll?View=Main&User={0}&Password={1}", (CurrentUser.TenTruyCap + "@tinhvan.com"), "123Abc");
%>
<div class="container-fluid">
    <div class="navbar-wrapper">
        <%--<div class="navbar-minimize">
            <button id="minimizeSidebar" class="btn btn-just-icon btn-white btn-fab btn-round">
                <i class="material-icons text_align-center visible-on-sidebar-regular">more_vert</i>
                <i class="material-icons design_bullet-list-67 visible-on-sidebar-mini">view_list</i>
            </button>
        </div>--%>
        <%--<a class="navbar-brand" href="#pablo">Anova</a>--%>
    </div>
    <button style="margin: 5em 25em 0 0;" onclick="closeLayer();" class="navbar-toggler" type="button" data-toggle="collapse" aria-controls="navigation-index" aria-expanded="false" aria-label="Toggle navigation">
        <span class="sr-only">Toggle navigation</span>
        <span class="navbar-toggler-icon icon-bar"></span>
        <span class="navbar-toggler-icon icon-bar"></span>
        <span class="navbar-toggler-icon icon-bar"></span>
    </button>
    <div class="collapse navbar-collapse justify-content-end" style="/*margin-top: 3em; */">
        <ul class="navbar-nav">
            <li class="nav-item">
                <a class="nav-link" href="/Pagess/Home.aspx" title="Về trang chủ">
                    <i class="material-icons" style="color: #0066a4;">dashboard</i>
                    <p class="d-lg-none d-md-block">
                        Stats
                    </p>
                </a>
            </li>
            <li class="nav-item dropdown">
                <a onclick="CheckClick(this)" class="nav-link" href="#" id="navbarDropdownThongBao" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false" title="Thông báo chung gửi đến bạn">
                    <i class="material-icons" style="color: #85c44e;">notifications</i>
                <%--    <%if (countLtsThongBaoChung > 0)
                        { %>
                    <span class="notification"><%=countLtsThongBaoChung %></span>
                    <%} %>--%>
                    <p class="d-lg-none d-md-block">
                        Some Actions
                    </p>
                </a>
                <div class="dropdown-menu dropdown-menu-right menu-nav" aria-labelledby="navbarDropdownThongBao">
                    <div class="menu-nav-item scroll">
                       
                    </div>
                    <div class="external">
                        <h5 class="see-all">
                            <span class="bold">
                                <a style="color: #62878f" href="/Pagess/danh-sach-notification.aspx"><%=Resources.Other.lblXemTatCa %></a>
                            </span>
                        </h5>
                    </div>
                </div>
            </li>
            <li class="nav-item dropdown">
                <a onclick="CheckClick(this)" class="nav-link" href="#" id="navbarDropdownVanBanDen" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false" title="Thông báo tiện ích gửi đến bạn">
                    <i class="material-icons" style="color: #17b978;">email</i>
                  <%--  <%if (countLtsThongBaoChungVanBan > 0)
                        { %>
                    <span class="notification"><%=countLtsThongBaoChungVanBan %></span>
                    <%} %>--%>
                    <p class="d-lg-none d-md-block">
                        Some Actions
                    </p>
                </a>
                <div class="dropdown-menu dropdown-menu-right menu-nav" aria-labelledby="navbarDropdownVanBanDen">
                    <div class="menu-nav-item scroll">
                        
                    </div>
                    <div class="external">
                        <h5 class="see-all">
                            <span class="bold">
                                <a style="color: #62878f" href="/Pagess/danh-sach-notification.aspx"><%=Resources.Other.lblXemTatCa %></a>
                            </span>
                        </h5>
                    </div>
                </div>
            </li>
            <li class="nav-item dropdown">
                <a onclick="CheckClick(this)" class="nav-link" href="#" id="navbarDropdownThongBaoCV" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false" title="Thông báo điều hành gửi đến bạn">
                    <i class="material-icons" style="color: #fc6262;">build</i>
                    <%--<%if (countLtsThongBaoChungCongViec > 0)
                        { %>
                    <span class="notification"><%=countLtsThongBaoChungCongViec %></span>
                    <%} %>--%>
                    <p class="d-lg-none d-md-block">
                        Some Actions
                    </p>
                </a>
                <div class="dropdown-menu dropdown-menu-right menu-nav" aria-labelledby="navbarDropdownThongBaoCV">
                    <div class="menu-nav-item scroll">
                        
                    </div>
                    <div class="external">
                        <h5 class="see-all">
                            <span class="bold">
                                <a style="color: #62878f" href="/Pagess/danh-sach-notification.aspx"><%=Resources.Other.lblXemTatCa %></a>
                            </span>
                        </h5>
                    </div>
                </div>
            </li>
            <li class="nav-item dropdown">
                <a class="nav-link" href="#pablo" id="navbarDropdownProfile" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false" title="Thông tin cá nhân">
                    <i class="material-icons" style="color: #ffd86f">person</i>
                    <p class="d-lg-none d-md-block">
                        Account
                    </p>
                </a>
                <div class="dropdown-menu dropdown-menu-right" aria-labelledby="navbarDropdownProfile">
                    <a class="dropdown-item" href="/Pagess/ca-nhan.aspx">Hồ Sơ</a>
                    <a class="dropdown-item" href="/Pagess/lich-ca-nhan.aspx">Lịch Cá Nhân</a>
                    <div class="dropdown-divider"></div>
                    <a class="dropdown-item login">Đăng Xuất</a>
                </div>
            </li>
        </ul>
    </div>
    <a href="javascript:void(0)" class="switch-trigger" style="display: none;">
        <label class="ml-auto">
            <div class="togglebutton switch-sidebar-mini">
                <label>
                    <input type="checkbox">
                    <span class="toggle"></span>
                </label>
            </div>
        </label>
        <div class="clearfix"></div>
    </a>
</div>
<input type="hidden" id="hoa_menu" value="0" />
<script>
    $(document).ready(function () {
        $(".addtome").click(function () {
            $(this).parent().removeClass("unreads");
            updatestatus($(this).attr("id"));
        });
    });

    $(".login").on("click", function () {
        var id = <%=CurrentUser.ID%>;
        var ten = '<%=CurrentUser.TenHienThi%>';
        var donvi = <%=CurrentUser.DonViID%>;
        $.ajax({
            type: "POST",
            url: "/api/notification.asmx/AddLogLogout",
            data: "{id:'" + id + "',ten:'" + ten + "',donvi:'" + donvi + "'}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (msg) {
                window.location.href = "/LoginNew.aspx";
            }
        });
    })

    function closeLayer() {
        var element = document.getElementById("close-Layer");
        //element.classList.remove("visible-hidden");
        var sss = $("#hoa_menu").val();
        if (sss == 0) {
            element.classList.add("visible");
            $("#hoa_menu").val(1);
        } else {
            element.classList.remove("visible");
            $("#hoa_menu").val(0);
        }

    }
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
        $.ajax({
            type: "POST",
            url: "/api/notification.asmx/deleteallnotification",
            data: "{type:'" + type + "','nguoidung':'" +<%:CurrentUser.ID%> +"'}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (msg) {
            }
        });
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

    function CheckClick(input) {
        if ($(input).attr('id') == 'navbarDropdownThongBao') {
            $('#navbarDropdownVanBanDen').parent().removeClass("open show");
            $('#navbarDropdownVanBanDen').attr("aria-expanded", false);
            $('#navbarDropdownVanBanDen').parent().children('div').removeClass("show");

            $('#navbarDropdownThongBaoCV').parent().removeClass("open show");
            $('#navbarDropdownThongBaoCV').attr("aria-expanded", false);
            $('#navbarDropdownThongBaoCV').parent().children('div').removeClass("show");

            $('#navbarDropdownProfile').parent().removeClass("open show");
            $('#navbarDropdownProfile').attr("aria-expanded", false);
            $('#navbarDropdownProfile').parent().children('div').removeClass("show");
            return
        }
        if ($(input).attr('id') == 'navbarDropdownVanBanDen') {
            $('#navbarDropdownThongBao').parent().removeClass("open show");
            $('#navbarDropdownThongBao').attr("aria-expanded", false);
            $('#navbarDropdownThongBao').parent().children('div').removeClass("show");

            $('#navbarDropdownThongBaoCV').parent().removeClass("open show");
            $('#navbarDropdownThongBaoCV').attr("aria-expanded", false);
            $('#navbarDropdownThongBaoCV').parent().children('div').removeClass("show");

            $('#navbarDropdownProfile').parent().removeClass("open show");
            $('#navbarDropdownProfile').attr("aria-expanded", false);
            $('#navbarDropdownProfile').parent().children('div').removeClass("show");
            return
        }
        if ($(input).attr('id') == 'navbarDropdownThongBaoCV') {
            $('#navbarDropdownThongBao').parent().removeClass("open show");
            $('#navbarDropdownThongBao').attr("aria-expanded", false);
            $('#navbarDropdownThongBao').parent().children('div').removeClass("show");

            $('#navbarDropdownVanBanDen').parent().removeClass("open show");
            $('#navbarDropdownVanBanDen').attr("aria-expanded", false);
            $('#navbarDropdownVanBanDen').parent().children('div').removeClass("show");

            $('#navbarDropdownProfile').parent().removeClass("open show");
            $('#navbarDropdownProfile').attr("aria-expanded", false);
            $('#navbarDropdownProfile').parent().children('div').removeClass("show");
            return
        }
        if ($(input).attr('id') == 'navbarDropdownProfile') {
            $('#navbarDropdownThongBao').parent().removeClass("open show");
            $('#navbarDropdownThongBao').attr("aria-expanded", false);
            $('#navbarDropdownThongBao').parent().children('div').removeClass("show");

            $('#navbarDropdownVanBanDen').parent().removeClass("open show");
            $('#navbarDropdownVanBanDen').attr("aria-expanded", false);
            $('#navbarDropdownVanBanDen').parent().children('div').removeClass("show");

            $('#navbarDropdownThongBaoCV').parent().removeClass("open show");
            $('#navbarDropdownThongBaoCV').attr("aria-expanded", false);
            $('#navbarDropdownThongBaoCV').parent().children('div').removeClass("show");
            return
        }
    }

    navbarDropdownProfile
</script>
