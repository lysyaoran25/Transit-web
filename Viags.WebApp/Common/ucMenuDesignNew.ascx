<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucMenuDesignNew.ascx.cs" Inherits="Viags.WebApp.Common.ucMenuDesignNew" %>
<%string path = HttpContext.Current.Request.Url.AbsolutePath; %>
<!-- Fonts and icons -->
<link rel="stylesheet" type="text/css" href="https://fonts.googleapis.com/css?family=Roboto:300,400,500,700|Roboto+Slab:400,700|Material+Icons" />

<!-- CSS Files -->
<link href="/Publishing_Resources/dist/corgi/login/material-dashboard.min.css" rel="stylesheet" />
<style>
    .sidebar .nav li.active > [data-toggle=collapse], .sidebar .nav li .dropdown-menu a:focus, .sidebar .nav li .dropdown-menu a:hover, .sidebar .nav li:hover > a {
        background-color: hsla(92, 50%, 54%, 1) !important;
        color: #3c4858;
        box-shadow: none
    }
</style>
<div class="sidebar" data-color="rose" data-background-color="huy" data-image="/Publishing_Resources/img/sidebar-1.jpg">
    <div class="logo_mini">
        <a href="/Pagess/home-dash-board.aspx" class="logo-mini">
            <img src="../Publishing_Resources/img/home/image_logoAF.jpg" style="width: 100%" />
        </a>
    </div>

    <%if (true)
        {%>
    <div class="logo" style="display: none">
        <a href="/Pagess/Home.aspx" class="logo-normal">
            <img src="../Publishing_Resources/img/home/image_logoAF.jpg" style="width: 100%;" />
        </a>
    </div>
    <%}
        else
        {%>
    <div class="logo" style="display: none">
        <a href="/Pagess/Home.aspx" class="logo-normal">
            <img src="../Publishing_Resources/img/home/image_logoAF.jpg" style="width: 100%;" />
        </a>
    </div>

    <%} %>


    <div class="sidebar-wrapper ps-container ps-theme-default ps-active-y" data-ps-id="c2697860-0559-ff19-aa84-be2ae77dd54a">
        <div class="user">
            <div class="photo">
                <img class="img-circle" style="width: 34px; height: 34px" src="<%:string.IsNullOrEmpty(CurrentUser.LinkAnh) ? "../Publishing_Resources/img/avatar.png" : "/"+CurrentUser.LinkAnh %>">
            </div>
            <div class="user-info">
                <a data-toggle="collapse" href="#collapseExample" class="username" style="text-decoration: none">
                    <span>
                        <%if (CurrentUser != null)
                            { %>
                        <%=CurrentUser.TenHienThi %>
                        <%} %>
                        <%else
                            { %>
                        <%=Resources.Other.lblNguoiDung %>
                        <%} %>
                        <b class="caret"></b>
                    </span>
                </a>
                <div class="collapse" id="collapseExample">
                    <ul class="nav">
                        <li class="nav-item">
                            <a class="nav-link nav-marg" href="/Pagess/ca-nhan.aspx">
                                <span class="sidebar-mini"><i class="icon-user"></i></span>
                                <span class="sidebar-normal" style="padding-top: 5px;">Hồ Sơ Cá Nhân </span>
                            </a>
                        </li>
                        <%--<li class="nav-item">
                            <a class="nav-link nav-marg" href="/Pagess/uy-quyen.aspx">
                                <span class="sidebar-mini"><i class="icon-calendar"></i></span>
                                <span class="sidebar-normal" style="padding-top: 5px;">Lịch Cá Nhân </span>
                            </a>
                        </li>--%>
                        <li class="nav-item">
                            <a class="nav-link nav-marg login" <%--href="/LoginNew.aspx"--%>>
                                <span class="sidebar-mini"><i class="icon-key"></i></span>
                                <span class="sidebar-normal" style="padding-top: 5px;">Thoát </span>
                            </a>
                        </li>
                    </ul>
                </div>
            </div>
        </div>
        <ul class="nav">
            <li class="nav-item ">
                <a class="nav-link active-color" data-toggle="collapse" aria-expanded="false" href="#pagesEx">
                    <i class="fa fa-laptop icon-root" style="padding-left: 4px; margin-top: -0.2em;"></i>
                    <p>E-OFFICE</p>
                </a>
                <div class="collapse in " id="pagesEx">
                    <ul class="nav">

                        <!--BEGIN LỊCH CÁ NHÂN-->
                        <li class="nav-item ">
                            <a class="nav-link" title="" href="/Pagess/trang-chu.aspx">
                                <span class="sidebar-mini"><i class="fab fa-twitch"></i></span>
                                <span class="sidebar-normal">Bản Tin - Thông Báo</span>
                            </a>
                        </li>
                        <li class="nav-item ">
                            <a class="nav-link" title="" href="/Pagess/DGHV.aspx">
                                <span class="sidebar-mini"><i class="fas fa-tasks"></i></span>
                                <span class="sidebar-normal">Hành vi - thái độ</span>
                            </a>
                        </li>
                        <!--BEGIN NHIỆM VỤ TRỌNG TÂM -->
                        <li class="nav-item ">
                            <a class="nav-link" title="" href="/Pagess/nhiem-vu-trong-tam.aspx?refresh=1">
                                <span class="sidebar-mini"><i class="fas fa-thumb-tack"></i></span>
                                <span class="sidebar-normal">Nhiệm vụ trọng tâm</span>
                            </a>
                        </li>
                         <!--BEGIN ĐIỀU PHỐI -->
                        <li class="nav-item ">
                            <a class="nav-link" title="" href="/Pagess/transit.aspx">
                                <span class="sidebar-mini"><i class="fas fa-thumb-tack"></i></span>
                                <span class="sidebar-normal">Điều phối</span>
                            </a>
                        </li>
                               <!--BEGIN danh mục chuyến -->
                        <li class="nav-item ">
                            <a class="nav-link" title="" href="/Pagess/transit.aspx">
                                <span class="sidebar-mini"><i class="fas fa-thumb-tack"></i></span>
                                <span class="sidebar-normal">Danh mục chuyến</span>
                            </a>
                        </li>
                                 <!--BEGIN danh mục ca -->
                        <li class="nav-item ">
                            <a class="nav-link" title="" href="/Pagess/transit.aspx">
                                <span class="sidebar-mini"><i class="fas fa-thumb-tack"></i></span>
                                <span class="sidebar-normal">Danh mục ca</span>
                            </a>
                        </li>
                                       <!--BEGIN quản lý khách -->
                        <li class="nav-item ">
                            <a class="nav-link" title="" href="/Pagess/transit.aspx">
                                <span class="sidebar-mini"><i class="fas fa-thumb-tack"></i></span>
                                <span class="sidebar-normal">Quản lý khách</span>
                            </a>
                        </li>

                        <!--BEGIN VĂN BẢN ĐẾN-->
                        <%--      <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Vanbanden))
                          { %>
                        <li class="nav-item ">
                            <a class="nav-link" data-toggle="collapse" aria-expanded="false" href="#pagesVBDEN">
                                <i class="fas fa-file-import"></i>
                                <p>
                                    <%=Resources.Common.lblVanBanDen %>
                                    <b class="caret"></b>
                                </p>
                            </a>
                            <div class="collapse " id="pagesVBDEN">
                                <ul class="nav">
                                    <li class="nav-item ">
                                        <a class="nav-link" href="#">
                                            <span class="sidebar-mini"><i class="fas fa-stream"></i></span>
                                            <span class="sidebar-normal"> Danh sách </span>
                                        </a>
                                    </li>                           
                                    <%if (CurrentUser.ViTriID == (int)Viags.Utils.Enum.TypeOfRole.VanThuDonVi)
                                      { %>
                                    <% if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Themmoivanbanden))
                                        { %>
                                    <li class="nav-item ">
                                        <a class="nav-link" title="" href="/Pagess/form-van-ban-den.aspx">
                                            <span class="sidebar-mini"><i class="icon-plus"></i></span>
                                            <span class="sidebar-normal"><%=Resources.Common.lblThemMoiVanBan %></span>
                                        </a>
                                    </li>
                                    <%} %>
                                    <li class="nav-item ">
                                        <a class="nav-link" title="" href="/Pagess/van-ban-den-cho-vao-so.aspx">
                                            <span class="sidebar-mini"><i class="fa fa-book"></i></span>
                                            <span class="sidebar-normal"><%=Resources.Common.lblVanBanDenMoi %> <b id="idvanbanchovaoso"></b></span> 
                                        </a>
                                    </li>
                                    <li class="nav-item ">
                                        <a class="nav-link" title="" href="/Pagess/van-ban-den.aspx">
                                            <span class="sidebar-mini"><i class="fa fa-book "></i></span>
                                            <span class="sidebar-normal"><%=Resources.Common.lblDanhSachVanBan %></span>
                                        </a>
                                    </li>
                                <%}
                                else
                                { %>
                                    <li class="nav-item ">
                                        <a class="nav-link" title="" href="/Pagess/van-ban-den.aspx">
                                            <span class="sidebar-mini"><i class="fa fa-book "></i></span>
                                            <span class="sidebar-normal"><%=Resources.Common.lblDanhSachVanBan %></span>
                                        </a>
                                    </li>
                                <%} %>
                                <%if (path.ToLower() == "/pagess/chi-tiet-van-ban-den.aspx")
                                    {%>
                                    <li class="nav-item ">
                                        <a class="nav-link" title="" href="/pagess/chi-tiet-van-ban-den.aspx?ItemID=<%=ItemID%>&do=view">
                                            <span class="sidebar-mini"><i class="fa fa-book"></i></span>
                                            <span class="sidebar-normal"><%=Resources.Common.lblChiTietVanBan %></span>
                                        </a>
                                    </li>
                                <%} %>
                                <li class="nav-item ">
                                    <a class="nav-link" title="" href="/Pagess/van-ban-den-chua-xu-ly.aspx">
                                        <span class="sidebar-mini"><i class="fa fa-book "></i></span>
                                        <span class="sidebar-normal"><%=Resources.Common.lblVanBanChuaXuLy %></span>
                                    </a>
                                </li>
                                <li class="nav-item ">
                                    <a class="nav-link" title="" href="/Pagess/van-ban-den-dang-xu-ly.aspx">
                                        <span class="sidebar-mini"><i class="fa fa-book "></i></span>
                                        <span class="sidebar-normal"><%=Resources.Common.lblVanBanDangXuLy %></span>
                                    </a>
                                </li>
                                <li class="nav-item ">
                                    <a class="nav-link" title="" href="/Pagess/van-ban-den-da-xu-ly.aspx">
                                        <span class="sidebar-mini"><i class="fa fa-book "></i></span>
                                        <span class="sidebar-normal"><%=Resources.Common.lblVanBanDaXuLy %></span>
                                    </a>
                                </li>
                                <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Insovanbanden))
                                  { %>
                                    <li class="nav-item ">
                                        <a class="nav-link" title="" href="/Pagess/in-so-van-ban-den.aspx#NgayDenDau=<%:DateTime.Now.ToString("dd/MM/yyyy") %>&InSo=1">
                                            <span class="sidebar-mini"><i class="fa fa-print"></i></span>
                                            <span class="sidebar-normal"><%=Resources.Common.lblInSoVanBan %></span>
                                        </a>
                                    </li>
                                <%} %>
                                </ul>
                            </div>                            
                        </li>
                        <%} %>--%>
                        <!--END VĂN BẢN ĐẾN-->
                        <!--BEGIN VĂN BẢN ĐI-->
                        <%--      <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Vanbandi))
                            { %>
                        <li class="nav-item ">
                            <a href="#pagesVBDI" data-toggle="collapse" aria-expanded="false" class="nav-link">
                                <i class="fas fa-file-export"></i>
                                <p>
                                    <%=Resources.Common.lblVanBanDi %>
                                    <b class="caret"></b>
                                </p>
                            </a>
                            <div class="collapse" id="pagesVBDI">
                                <ul class="nav">
                                    <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Themmoivanbandi))
                                        {%>
                                    <li class="nav-item ">
                                        <a class="nav-link" title="" href="/Pagess/form-van-ban-di.aspx">
                                            <span class="sidebar-mini"><i class="icon-plus"></i></span>
                                            <span class="sidebar-normal"><%=Resources.Common.lblThemMoiVanBan %></span>
                                        </a>
                                    </li>
                                    <%}%>
                                    <li class="nav-item ">
                                        <a class="nav-link" title="" href="/Pagess/van-ban-di.aspx">
                                            <span class="sidebar-mini"><i class="fa fa-list-alt"></i></span>
                                            <span class="sidebar-normal"><%=Resources.Common.lblDanhSach %> <b id="idvanbandithuong"></b></span>
                                        </a>
                                    </li>
                                    <%if (CurrentUser.ViTriID == (int)Viags.Utils.Enum.TypeOfRole.VanThuDonVi)
                                        { %>
                                    <li class="nav-item ">
                                        <a class="nav-link" title="" href="/Pagess/van-ban-cho-vao-so.aspx">
                                            <span class="sidebar-mini"><i class="fa fa-book "></i></span>
                                            <span class="sidebar-normal">Văn bản chờ vào sổ <b id="idvanbanduthaochovaoso"></b></span>
                                        </a>
                                    </li>
                                    <%} %>
                                    <li class="nav-item ">
                                        <a class="nav-link" title="" href="/Pagess/van-ban-di.aspx#LoaiID=1">
                                            <span class="sidebar-mini"><i class="fa fa-list-alt"></i></span>
                                            <span class="sidebar-normal"><%=Resources.Common.lblVanBanPhatHanh %></span>
                                        </a>
                                    </li>
                                    <li class="nav-item ">
                                        <a class="nav-link" title="" href="/Pagess/van-ban-di.aspx#LoaiID=2">
                                            <span class="sidebar-mini"><i class="fa fa-list-alt"></i></span>
                                            <span class="sidebar-normal"><%=Resources.Common.lblVanBanChuaPhatHanh %></span>
                                        </a>
                                    </li>
                                    <li class="nav-item ">
                                        <a class="nav-link" title="" href="/Pagess/in-so-van-ban-di.aspx#ThoiGianBatDau=<%:DateTime.Now.ToString("dd/MM/yyyy") %>&InSo=1">
                                            <span class="sidebar-mini"><i class="fa fa-book"></i></span>
                                            <span class="sidebar-normal"><%=Resources.Common.lblInSo %></span>
                                        </a>
                                    </li>
                                    <!--BEGIN Chuyến phát bưu điện-->
                                    <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.ChuyenPhatBuuDien))
                                        { %>
                                    <li class="nav-item ">
                                        <a href="#pagesCPBD" data-toggle="collapse" aria-expanded="false" class="nav-link">
                                            <i class="fa fa-envelope"></i>
                                            <p>
                                                Quản lý chuyển phát
                                                <b class="caret"></b>
                                            </p>
                                        </a>
                                        <div class="collapse" id="pagesCPBD">
                                            <ul class="nav">
                                                <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.ChuyenPhatHanhQuaBuuDien))
                                                    {%>
                                                <li class="nav-item ">
                                                    <a class="nav-link" title="" href="/Pagess/chuyen-phat-hanh-buu-dien.aspx">
                                                        <span class="sidebar-mini"><i class="fa fa-university"></i></span>
                                                        <span class="sidebar-normal">Chuyển phát hành qua bưu điện</span>
                                                    </a>
                                                </li>
                                                <li class="nav-item ">
                                                    <a class="nav-link" title="" href="/Pagess/don-vi-chuyen-phat.aspx">
                                                        <span class="sidebar-mini"><i class="fa fa-university"></i></span>
                                                        <span class="sidebar-normal">Đơn vị chuyển phát</span>
                                                    </a>
                                                </li>
                                                <li class="nav-wid nav-item ">
                                                    <a class="nav-link" title="" href="/Pagess/pham-vi-noi-den.aspx">
                                                        <span class="sidebar-mini"><i class="fa fa-university"></i></span>
                                                        <span class="sidebar-normal">Phạm vi nơi đến</span>
                                                    </a>
                                                </li>
                                                <li class="nav-wid nav-item ">
                                                    <a class="nav-link" title="" href="/Pagess/pham-vi-trong-luong.aspx">
                                                        <span class="sidebar-mini"><i class="fa fa-university"></i></span>
                                                        <span class="sidebar-normal">Phạm vi trọng lượng</span>
                                                    </a>
                                                </li>
                                                <li class="nav-wid nav-item ">
                                                    <a class="nav-link" title="" href="/Pagess/thong-tin-buu-dien.aspx">
                                                        <span class="sidebar-mini"><i class="fa fa-university"></i></span>
                                                        <span class="sidebar-normal">Thông tin bưu điện</span>
                                                    </a>
                                                </li>
                                                <%}%>
                                            </ul>
                                        </div>
                                    </li>
                                    <%} %>
                                    <!--END Chuyến phát bưu điện-->
                                </ul>
                            </div>
                        </li>
                        <%} %>--%>
                        <!--END VĂN BẢN ĐI-->
                        <!--BEGIN VĂN BẢN DỰ THẢO - HỒ SƠ TRÌNH KÝ-->
                        <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Vanbanduthao))
                            { %>
                        <li class="nav-item ">
                            <a class="nav-link" title="" href="/Pagess/van-ban-du-thao.aspx">
                                <span class="sidebar-mini"><i class="fas fa-file-contract"></i></span>
                                <span class="sidebar-normal">Hồ Sơ Trình Ký</span>
                            </a>
                        </li>
                        <%--<li class="nav-item ">
                            <a href="#pagesVBDT" data-toggle="collapse" aria-expanded="false" class="nav-link">
                                <i class="fas fa-file-contract"></i>
                                <p>
                                    <%=Resources.Common.lblVanBanDuThao %>
                                    <b class="caret"></b>
                                </p>
                            </a>
                            <div class="collapse" id="pagesVBDT">
                                <ul class="nav">
                                    <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Themmoivanbanduthao))
                                        { %>
                                    <li class="nav-item ">
                                        <a class="nav-link" title="" href="/Pagess/form-van-ban-du-thao.aspx">
                                            <span class="sidebar-mini"><i class="icon-plus"></i></span>
                                            <span class="sidebar-normal"><%=Resources.Common.lblThemMoiVanBan %></span>
                                        </a>
                                    </li>
                                    <%} %>
                                    <%if (path.ToLower() == "/pagess/chi-tiet-van-ban-du-thao.aspx")
                                        {%>
                                    <li class="nav-item ">
                                        <a class="nav-link" title="" href="/Pagess/chi-tiet-van-ban-du-thao.aspx?do=view&ItemID=<%=ItemID %>">
                                            <span class="sidebar-mini"><i class="fa fa-book"></i></span>
                                            <span class="sidebar-normal"><%=Resources.Common.lblChiTietVanBan %></span>
                                        </a>
                                    </li>
                                    <%} %>
                                    <li class="nav-item ">
                                        <a class="nav-link" title="" href="/Pagess/van-ban-du-thao.aspx">
                                            <span class="sidebar-mini"><i class="fa fa-book"></i></span>
                                            <span class="sidebar-normal"><%=Resources.Common.lblDanhSachVanBan %></span>
                                        </a>
                                    </li>
                                    <li class="nav-item ">
                                        <a class="nav-link" title="" href="/Pagess/van-ban-du-thao-chua-xu-ly.aspx">
                                            <span class="sidebar-mini"><i class="fa fa-book"></i></span>
                                            <span class="sidebar-normal"><%=Resources.Common.lblChuaXuLy %></span>
                                        </a>
                                    </li>
                                    <li class="nav-item ">
                                        <a class="nav-link" title="" href="/Pagess/van-ban-du-thao-dang-xu-ly.aspx">
                                            <span class="sidebar-mini"><i class="fa fa-book"></i></span>
                                            <span class="sidebar-normal"><%=Resources.Common.lblDangXuLy %></span>
                                        </a>
                                    </li>
                                    <li class="nav-wid nav-item ">
                                        <a class="nav-link" title="" href="/Pagess/van-ban-du-thao-da-xu-ly.aspx">
                                            <span class="sidebar-mini"><i class="fa fa-book"></i></span>
                                            <span class="sidebar-normal"><%=Resources.Common.lblDaXuLy %></span>
                                        </a>
                                    </li>
                                </ul>
                            </div>
                        </li>--%>
                        <%} %>
                        <!--END VĂN BẢN DỰ THẢO-->
                        <!--BEGIN CÔNG VIỆC-->
                        <%--<%if (!CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.QuantrihethongAdmin))
                            {%>--%>
                        <li class="nav-item ">
                            <a href="#pagesCV" data-toggle="collapse" aria-expanded="false" class="nav-link">
                                <i class="fas fa-balance-scale"></i>
                                <p>
                                    <%=Resources.Common.lblDieuHanh %>
                                    <b class="caret"></b>
                                </p>
                            </a>
                            <div class="collapse" id="pagesCV">
                                <ul class="nav">
                                    <%--hoalt: đóng lại khi nào cần xài đa cấp cho công việc thì mở ra
                                    <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Congviec))
                                      { %>
                                    <li class="nav-item ">
                                        <a href="#pagesQLCV" data-toggle="collapse" aria-expanded="false" class="nav-link">
                                            <i class="fa fa-briefcase"></i>
                                            <p>
                                                <%=Resources.Common.lblQuanLyCongViec %>
                                                <b class="caret"></b>
                                            </p>
                                        </a>
                                        <div class="collapse page-sidebar-menu " id="pagesQLCV">
                                            <ul class="nav">
                                                <li class="nav-item ">
                                                    <a class="nav-link" title="" href="/Pagess/form-ho-so-cong-viec.aspx">
                                                        <span class="sidebar-mini"><i class="icon-plus"></i></span>
                                                        <span class="sidebar-normal"><%=Resources.Common.lblThemMoiCongViec %></span>
                                                    </a>
                                                </li>
                                                <li class="nav-wid nav-item ">
                                                    <a class="nav-link" title="" href="/Pagess/cong-viec.aspx">
                                                        <span class="sidebar-mini"><i class="fa fa-book"></i></span>
                                                        <span class="sidebar-normal"><%=Resources.Common.lblDanhSachCongViec %></span>
                                                    </a>
                                                </li>
                                                <%if (path.ToLower() == "/pagess/chi-tiet-cong-viec.aspx")
                                                  {%>
                                                <li class="nav-wid nav-item ">
                                                    <a class="nav-link" title="" href="/Pagess/chi-tiet-cong-viec.aspx?do=view&ItemID=<%=ItemID %>">
                                                        <span class="sidebar-mini"><i class="fa fa-book"></i></span>
                                                        <span class="sidebar-normal"><%=Resources.Common.lblChiTietCongViec %></span>
                                                    </a>
                                                <%} %>
                                                <li class="nav-wid nav-item ">
                                                    <a class="nav-link" title="" href="/Pagess/cong-viec-chua-xu-ly.aspx">
                                                        <span class="sidebar-mini"><i class="fa fa-book"></i></span>
                                                        <span class="sidebar-normal"><%=Resources.Common.lblCongViecChuaXuLy %> <b id="idcongviecchuaxuly"></b></span>
                                                    </a>
                                                </li>
                                                <li class="nav-wid nav-item ">
                                                    <a class="nav-link" title="" href="/Pagess/cong-viec-dang-xu-ly.aspx">
                                                        <span class="sidebar-mini"><i class="fa fa-book"></i></span>
                                                        <span class="sidebar-normal"><%=Resources.Common.lblCongViecDangXuLy %> <b id="idcongviecdangkxuly"></b></span>
                                                    </a>
                                                </li>
                                                <li class="nav-wid nav-item ">
                                                    <a class="nav-link" title="" href="/Pagess/cong-viec-da-xu-ly.aspx">
                                                        <span class="sidebar-mini"><i class="fa fa-book"></i></span>
                                                        <span class="sidebar-normal"><%=Resources.Common.lblCongViecDaXuLy %></span>
                                                    </a>
                                                </li>
                                                <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Tonghopcongviec))
                                                  { %>
                                                <li class="nav-wid nav-item ">
                                                    <a class="nav-link" title="" href="/Pagess/tong-hop-cong-viec.aspx">
                                                        <span class="sidebar-mini"><i class="fa fa-bar-chart-o"></i></span>
                                                        <span class="sidebar-normal"><%=Resources.Common.lblTongHopCongViec %></span>
                                                    </a>
                                                </li>
                                                <%} %>
                                                <li class="nav-wid nav-item " style="display: none">
                                                    <a class="nav-link" title="" href="/Pagess/bao-cao-cong-viec.aspx">
                                                        <span class="sidebar-mini"><i class="fa fa-bar-chart-o"></i></span>
                                                        <span class="sidebar-normal"><%=Resources.Common.lblBaoCaoCongViec %></span>
                                                    </a>
                                                </li>
                                            </ul>
                                        </div>
                                    </li>
                                    <%} %>--%>
                                    <li class="nav-item ">
                                        <a class="nav-link" title="" href="/Pagess/cong-viec.aspx">
                                            <span class="sidebar-mini"><i class="fa fa-briefcase"></i></span>
                                            <span class="sidebar-normal"><%=Resources.Common.lblQuanLyCongViec %></span>
                                        </a>
                                    </li>
                                    <li class="nav-item ">
                                        <a class="nav-link" title="" href="/Pagess/duyet-ngan-sach.aspx">
                                            <span class="sidebar-mini"><i class="fas fa-key"></i></span>
                                            <span class="sidebar-normal">Duyệt Ngân Sách</span>
                                        </a>
                                    </li>
                                    <li class="nav-item ">
                                        <a class="nav-link" title="" href="/Pagess/ban-giao-cong-viec.aspx">
                                            <span class="sidebar-mini"><i class="fas fa-random"></i></span>
                                            <span class="sidebar-normal"><%=Resources.Common.lblBanGiaoCongViec %></span>
                                        </a>
                                    </li>
                                    <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Baocaocongviec))
                                        { %>
                                    <li class="nav-item ">
                                        <a class="nav-link" title="" href="/BaoCaoCongViec/BaoCaoCuaDonVi/Default.aspx">
                                            <span class="sidebar-mini"><i class="icon-plus"></i></span>
                                            <span class="sidebar-normal"><%=Resources.Common.lblBaoCaoCongViec %></span>
                                        </a>
                                    </li>
                                    <%} %>


                                    <%--<%if (CurrentUser != null && (CurrentUser.ViTriID == (int)Viags.Utils.Enum.TypeOfRole.LanhDaoPhongBan || CurrentUser.ViTriID == (int)Viags.Utils.Enum.TypeOfRole.LanhDaoHanhChinh || CurrentUser.ViTriID == (int)Viags.Utils.Enum.TypeOfRole.LanhDaoVanPhong || CurrentUser.ViTriID == (int)Viags.Utils.Enum.TypeOfRole.LanhDaoDonVi || CurrentUser.ViTriID == (int)Viags.Utils.Enum.TypeOfRole.LanhDaoNHNN))
                                        { %>
                                    <li class="nav-item ">
                                        <a class="nav-link" href="/Pagess/uy-quyen.aspx">
                                            <span class="sidebar-mini"><i class="icon-calendar"></i></span>
                                            <span class="sidebar-normal"><%=Resources.Common.lblUyQuyen %></span>
                                        </a>
                                    </li>
                                    <%} %>
                                    <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Theodoiuyquyen))
                                        { %>
                                    <li class="nav-item ">
                                        <a class="nav-link" title="" href="/Pagess/theo-doi-uy-quyen.aspx">
                                            <span class="sidebar-mini"><i class="fa fa-legal"></i></span>
                                            <span class="sidebar-normal"><%=Resources.Common.lblTheoDoiUyQuyen %></span>
                                        </a>
                                    </li>
                                    <%} %>--%>

                                    <%-- <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Thongbao))
                                        { %>
                                    <li class="nav-item ">
                                        <a class="nav-link" title="" href="/Pagess/thong-bao.aspx">
                                            <span class="sidebar-mini"><i class="fab fa-wpforms"></i></span>
                                            <span class="sidebar-normal"><%=Resources.Common.lblThongBaoChung %></span>
                                        </a>
                                    </li>
                                    <%} %>--%>
                                </ul>
                            </div>
                        </li>
                        <%--<%} %>--%>
                        <!--END CÔNG VIỆC-->
                        <!--BEGIN HỒ SƠ TÀI LIỆU-->
                        <%--<%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Hosotailieu))
                            { %>--%>
                        <li class="nav-item ">
                            <%--<a href="#pagesQLHS" data-toggle="collapse" aria-expanded="false" class="nav-link">
                                <i class="fas fa-folder"></i>
                                <p>
                                    <%=Resources.Common.lblQuanLyHoSo %>
                                    <b class="caret"></b>
                                </p>
                            </a>
                            <div class="collapse" id="pagesQLHS">
                                <ul class="nav">
                                    <li class="nav-item ">
                                        <a class="nav-link" title="Danh sách hồ sơ" href="/Pagess/quan-ly-ho-so-tai-lieu.aspx">
                                            <span class="sidebar-mini"><i class="fa fa-file-archive-o"></i></span>
                                            <span class="sidebar-normal"><%=Resources.Common.lblDanhSachHoSo %></span>
                                        </a>
                                    </li>
                                    <%if (ItemID > 0)
                                      {%>
                                    <li class="nav-wid nav-item ">
                                        <a class="nav-link" title="Chi tiết hồ sơ" href="/Pagess/chi-tiet-ho-so-tai-lieu.aspx?ItemID=<%=ItemID %>">
                                            <span class="sidebar-mini"><i class="fa fa-file-archive-o"></i></span>
                                            <span class="sidebar-normal"><%=Resources.Common.lblChiTietHoSo %></span>
                                        </a>
                                    </li>
                                    <%} %>
                                </ul>
                            </div>--%>
                            <a class="nav-link" title="" href="/Pagess/quan-ly-ho-so-tai-lieu.aspx">
                                <span class="sidebar-mini"><i class="fas fa-boxes"></i></span>
                                <span class="sidebar-normal">Quản Lý OPL - OJT - CS</span>
                            </a>
                        </li>
                        <%--<%} %>--%>
                        <!--END HỒ SƠ TÀI LIỆU-->
                        <!--BEGIN TIỆN ÍCH-->
                        <li class="nav-item ">
                            <a href="#pagesTI" data-toggle="collapse" aria-expanded="false" class="nav-link">
                                <i class="fab fa-medapps"></i>
                                <p>
                                    <%=Resources.Common.lblTienIch %>
                                    <b class="caret"></b>
                                </p>
                            </a>
                            <div class="collapse" id="pagesTI">
                                <ul class="nav">
                                    <%--<%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Lichhopcongtactuan))
                                        { %>
                                    <li class="nav-item ">
                                        <a class="nav-link" title="" href="/Pagess/lich-hop-cong-tac.aspx">
                                            <span class="sidebar-mini"><i class="fa fa-calendar-o"></i></span>
                                            <span class="sidebar-normal"><%=Resources.Common.lblLichHopCongTac %></span>
                                        </a>
                                    </li>
                                    <%} %>--%>
                                    <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.ThongBao1))
                                        { %>
                                    <li class="nav-item ">
                                        <a class="nav-link" title="" href="/Pagess/thong-bao-tin-tuc.aspx">
                                            <span class="sidebar-mini"><i class="far fa-newspaper"></i></span>
                                            <span class="sidebar-normal">Thông báo tin tức</span>
                                        </a>
                                    </li>
                                    <%} %>
                                    <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.TinTuc))
                                        { %>
                                    <li class="nav-item ">
                                        <a class="nav-link" title="" href="/Pagess/tin-tuc-su-kien.aspx">
                                            <span class="sidebar-mini"><i class="far fa-newspaper"></i></span>
                                            <span class="sidebar-normal">Bản tin nội bộ</span>
                                        </a>
                                    </li>
                                    <%} %>
                                    <%--           <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Datphonghop) || true)
                                        { %>--%>
                                    <li class="nav-wid nav-item ">
                                        <a href="/Pagess/lich-dat-phong.aspx" aria-expanded="false" class="nav-link">
                                            <i class="fa fa-calendar"></i>
                                            <p>
                                                <%=Resources.Common.lblLichDatPhong %>
                                                <%-- <b class="caret"></b>--%>
                                            </p>
                                        </a>
                                        <%--                           <div class="collapse" id="pagesQLPH">
                                            <ul class="nav">
                                                <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Phonghop))
                                                    {%>
                                                <li class="nav-item ">
                                                    <a class="nav-link" title="" href="/Pagess/danh-muc-phong-hop.aspx">
                                                        <span class="sidebar-mini"><i class="fas fa-door-open"></i></span>
                                                        <span class="sidebar-normal"><%=Resources.Common.lblPhongHop %></span>
                                                    </a>
                                                </li>
                                                <%}%>
                                                <li class="nav-item ">
                                                    <a class="nav-link" title="" href="/Pagess/lich-dat-phong.aspx">
                                                        <span class="sidebar-mini"><i class="fa fa-calendar"></i></span>
                                                        <span class="sidebar-normal"><%="Lịch đặt phòng" %></span>
                                                    </a>
                                                </li>
                                            </ul>
                                        </div>--%>
                                    </li>
                                    <%--      <%} %>--%>
                                    <%-- BEGIN VĂN PHÒNG PHẨM --%>
                                    <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.VanPhongPham))
                                        { %>
                                    <li class="nav-item ">
                                        <a href="#pagesVPP" data-toggle="collapse" aria-expanded="false" class="nav-link">
                                            <i class="fas fa-highlighter"></i>
                                            <p>
                                                Quản lý VPP
                                                <b class="caret"></b>
                                            </p>
                                        </a>
                                        <div class="collapse" id="pagesVPP">
                                            <ul class="nav">
                                                <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.CapNhatVanPhongPham))
                                                    { %>
                                                <li class="nav-item ">
                                                    <a class="nav-link" title="" href="/Pagess/van-phong-pham.aspx">
                                                        <span class="sidebar-mini"><i class="fas fa-pencil-ruler"></i></span>
                                                        <span class="sidebar-normal">Văn phòng phẩm</span>
                                                    </a>
                                                </li>
                                                <%} %>
                                                <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.CapNhatDonViTinh))
                                                    { %>
                                                <li class="nav-item ">
                                                    <a class="nav-link" title="" href="/Pagess/van-phong-pham-don-vi-tinh.aspx">
                                                        <span class="sidebar-mini"><i class="icon-plus"></i></span>
                                                        <span class="sidebar-normal">Đơn Vị Tính</span>
                                                    </a>
                                                </li>
                                                <%} %>
                                                <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.CapNhatDinhMuc))
                                                    { %>
                                                <li class="nav-item ">
                                                    <a class="nav-link" title="" href="/Pagess/van-phong-pham-dinh-muc.aspx">
                                                        <span class="sidebar-mini"><i class="fas fa-donate"></i></span>
                                                        <span class="sidebar-normal">Định mức</span>
                                                    </a>
                                                </li>
                                                <%} %>
                                                <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.DangKyVanPhongPham) || CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.XuatBaoCao))
                                                    { %>
                                                <li class="nav-item ">
                                                    <a class="nav-link" title="" href="/Pagess/van-phong-pham-dang-ky.aspx">
                                                        <span class="sidebar-mini"><i class="fab fa-leanpub"></i></span>
                                                        <span class="sidebar-normal">Đăng ký VPP</span>
                                                    </a>
                                                </li>
                                                <%} %>
                                            </ul>
                                        </div>
                                    </li>
                                    <%} %>
                                    <%-- END VĂN PHÒNG PHẨM --%>
                                    <%-- BEGIN ĐẶT XE --%>
                                    <li class="nav-wid nav-item ">
                                        <a <%--href="#pagesDX" data-toggle="collapse"--%> href="/Pagess/thong-tin-dat-xe.aspx" aria-expanded="false" class="nav-link">
                                            <i class="fas fa-car-side"></i>
                                            <p>
                                                Quản lý thông tin đặt xe
                                               <%-- <b class="caret"></b>--%>
                                            </p>
                                        </a>
                                    </li>
                                    <%--<%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.DatXe))
                                        { %>
                                    <li class="nav-wid nav-item ">
                                       
                                        <div class="collapse page-sidebar-menu " id="pagesDX">
                                            <ul class="nav page-sidebar-menu ">
                                                <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Xe))
                                                    {%>
                                                <li class="nav-wid nav-item ">
                                                    <a class="nav-link" title="" href="/Pagess/danh-muc-xe.aspx">
                                                        <span class="sidebar-mini"><i class="fa fa-bus"></i></span>
                                                        <span class="sidebar-normal"><%=Resources.DanhMucXe.lblXe %></span>
                                                    </a>
                                                </li>
                                                <%}%>
                                                <li class="nav-item ">
                                                    <a class="nav-link" title="" href="/Pagess/lich-dat-xe.aspx">
                                                        <span class="sidebar-mini"><i class="fa fa-calendar"></i></span>
                                                        <span class="sidebar-normal"><%="Lịch đặt xe" %></span>
                                                    </a>
                                                </li>
                                                <% if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.ThongTinDatXe))
                                                    { %>
                                                <li class="nav-wid nav-item ">
                                                    <a class="nav-link" title="" href="/Pagess/thong-tin-dat-xe.aspx">
                                                        <span class="sidebar-mini"><i class="fas fa-info-circle"></i></span>
                                                        <span class="sidebar-normal"><%= Resources.DanhMucXe.lblThongTinDatXe %></span>
                                                    </a>
                                                </li>
                                                <% } %>
                                                <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.CapNhatThongTinDatXe))
                                                    {%>
                                                <li class="nav-wid nav-item ">
                                                    <a class="nav-link" title="" href="/Pagess/chi-phi-chuyen-di.aspx">
                                                        <span class="sidebar-mini"><i class="fas fa-file-invoice-dollar"></i></span>
                                                        <span class="sidebar-normal">Chi phí chuyến đi</span>
                                                    </a>
                                                </li>
                                                <%}%>
                                            </ul>
                                        </div>
                                    </li>
                                    <%} %>--%>
                                    <%-- END ĐẶT XE --%>
                                    <%-- BEGIN NGHỈ PHÉP --%>
                                    <%if (true)
                                        { %>
                                    <li class="nav-wid nav-item ">
                                        <a href="/Pagess/list-dang-ky-nghi-phep.aspx" aria-expanded="false" class="nav-link">
                                            <i class="fas fa-feather"></i>
                                            <p>
                                                Quản lý nghỉ phép
                                                
                                            </p>
                                        </a>
                                        <div class="collapse page-sidebar-menu " id="pagesNP">
                                            <ul class="nav page-sidebar-menu ">
                                                <%--<%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.HinhThucNghiPhep))
                                                    {%>
                                                <li class="nav-wid nav-item ">
                                                    <a class="nav-link" title="" href="/Pagess/hinh-thuc-nghi-phep.aspx">
                                                        <span class="sidebar-mini"><i class="fas fa-quote-right"></i></span>
                                                        <span class="sidebar-normal">Hình thức nghỉ phép</span>
                                                    </a>
                                                </li>
                                                <%}%>--%>
                                                <%if (true)
                                                    {%>
                                                <li class="nav-item ">
                                                    <a class="nav-link" title="" href="/Pagess/list-dang-ky-nghi-phep.aspx">
                                                        <span class="sidebar-mini"><i class="fas fa-file-invoice"></i></span>
                                                        <span class="sidebar-normal">Danh sách đăng ký</span>
                                                    </a>
                                                </li>
                                                <%}%>
                                                <%--<%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.DinhMucNgayPhep))
                                                    {%>
                                                <li class="nav-wid nav-item ">
                                                    <a class="nav-link" title="" href="/Pagess/dinh-muc-ngay-phep.aspx">
                                                        <span class="sidebar-mini"><i class="fas fa-ruler"></i></span>
                                                        <span class="sidebar-normal">Định mức ngày phép</span>
                                                    </a>
                                                </li>
                                                <%}%>--%>
                                            </ul>
                                        </div>
                                    </li>
                                    <%} %>
                                    <%-- END NGHỈ PHÉP --%>
                                    <%-- BEGIN ĐẶT CƠM --%>
                                    <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.DangKyCaCom))
                                        { %>
                                    <li class="nav-wid nav-item ">
                                        <a class="nav-link" title="" href="/Pagess/dang-ky-com.aspx">
                                            <span class="sidebar-mini"><i class="fa fa-cutlery"></i></span>
                                            <span class="sidebar-normal"><%=Resources.DanhMucCom.lblQuanLyDatCom %></span>
                                        </a>
                                    </li>
                                    <%}%>
                                    <%-- <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.ThongTinDatCom))
                                        { %>
                                    <li class="nav-wid nav-item ">
                                        <a class="nav-link" title="" href="/Pagess/dat-com.aspx">
                                            <span class="sidebar-mini"><i class="fa fa-cutlery"></i></span>
                                            <span class="sidebar-normal"><%=Resources.DanhMucCom.lblDatCom %></span>
                                        </a>
                                    </li>
                                    <%} %>--%>
                                    <%-- END ĐẶT CƠM --%>
                                </ul>
                            </div>
                        </li>
                        <%--END TIỆN ÍCH--%>
                        <!--BEGIN ISO-->
                        <%if (!CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.NhanVienISO))
                            { %>
                        <li class="nav-item ">
                            <a class="nav-link" title="" href="/Pagess/tai-lieu-iso.aspx">
                                <span class="sidebar-mini"><i class="far fa-file-alt"></i></span>
                                <span class="sidebar-normal">ISO</span>
                            </a>
                        </li>
                        <%} %>
                        <!--BEGIN ISO-->
                        <!--BEGIN KIỂM TRA GIÁM SÁT-->
                        <%if (!CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.QuantrihethongAdmin))
                            { %>
                        <li class="nav-item ">
                            <a class="nav-link" title="" href="/Pagess/giam-sat.aspx">
                                <span class="sidebar-mini"><i class="fas fa-tasks"></i></span>
                                <span class="sidebar-normal">Kiểm tra giám sát</span>
                            </a>
                        </li>
                        <%} %>
                        <!--END KIỂM TRA GIÁM SÁT-->
                        <!--BEGIN BIỂU MẪU-->
                        <%--<li class="nav-item ">
                            <a class="nav-link" title="" href="/Pagess/bieu-mau.aspx">
                                <span class="sidebar-mini"><i class="far fa-file-alt"></i></span>
                                <span class="sidebar-normal"><%=Resources.Common.lblBieuMau %></span>
                            </a>
                        </li>--%>
                        <!--END BIỂU MẪU-->
                        <!--BEGIN LỊCH CÁ NHÂN-->
                        <%--<% if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Lichlamviec))
                            { %>--%>
                        <li class="nav-item ">
                            <a class="nav-link" title="" href="/Pagess/lich-ca-nhan.aspx">
                                <span class="sidebar-mini"><i class="fas fa-business-time"></i></span>
                                <span class="sidebar-normal"><%="Lịch làm việc" %></span>
                            </a>
                        </li>
                        <%--<%} %>--%>
                        <!--END LỊCH CÁ NHÂN-->
                        <!--BEGIN DANH MUC LUONG-->
                        <% if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.DanhMucLuong))
                            { %>
                        <li class="nav-item ">
                            <a class="nav-link" title="Danh mục lương" href="/Pagess/danh-muc-luong.aspx">
                                <span class="sidebar-mini"><i class="fas fa-clipboard-list"></i></span>
                                <span class="sidebar-normal"><%= Resources.Common.lblDanhMucLuong %></span>
                            </a>
                        </li>
                        <% } %>
                        <!--END DANH MUC LUONG-->

                        <!--BEGIN DANH BA -->

                        <li class="nav-item ">
                            <a class="nav-link" title="" href="/Pagess/danh-ba.aspx">
                                <span class="sidebar-mini"><i class="far fa-address-card"></i></span>
                                <span class="sidebar-normal"><%="Danh bạ" %></span>
                            </a>
                        </li>

                        <!--END DANH BA-->
                        <!--BEGIN NHAN VIEN XUAT SAC -->
                        <li class="nav-item ">
                            <a class="nav-link" title="" href="/Pagess/dashboard-quan-ly.aspx">
                                <span class="sidebar-mini"><i class="fas fa-medal"></i></span>
                                <span class="sidebar-normal">Nhân viên xuất sắc</span>
                            </a>
                        </li>

                        <!--BEGIN KHOA TAI KHOAN -->
                        <li class="nav-item ">
                            <a class="nav-link" title="" href="/Pagess/khoa-tai-khoan.aspx">
                                <span class="sidebar-mini"><i class="fas fa-user-lock"></i></span>
                                <span class="sidebar-normal">DS tài khoản bị khóa</span>
                            </a>
                        </li>

                        <!--BEGIN THONG KE CAM XUC-->
                        <li class="nav-item ">
                            <a class="nav-link" title="" href="/Pagess/thong-ke-cam-xuc-nguoi-dung.aspx">
                                <span class="sidebar-mini"><i class="fas fa-smile"></i></span>
                                <span class="sidebar-normal">Thống kê cảm xúc</span>
                            </a>
                        </li>
                        <!--END SƠ ĐỒ TỔ CHỨC-->
                        <!--BEGIN ĐINH BIÊN NHÂN SỰ-->
                        <li class="nav-item ">
                            <a href="#pagesDB" data-toggle="collapse" aria-expanded="false" class="nav-link">
                                <i class="fa fa-cog"></i>
                                <p>
                                    Định biên nhân sự
                                    <b class="caret"></b>
                                </p>
                            </a>
                            <div class="collapse" id="pagesDB">
                                <ul class="nav">
                                    <li class="nav-item">
                                        <a class="nav-link" title="" href="/Pagess/dinh-bien-nhan-su.aspx">
                                            <span class="sidebar-mini"><i class="fa fa-wrench"></i></span>
                                            <span class="sidebar-normal">Quản lý định biên</span>
                                        </a>
                                    </li>
                                </ul>
                                <ul class="nav">
                                    <li class="nav-item ">
                                        <a class="nav-link" title="" href="/Pagess/so-do-dinh-bien.aspx">
                                            <span class="sidebar-mini"><i class="fas fa-project-diagram"></i></span>
                                            <span class="sidebar-normal">Sơ đồ định biên</span>
                                        </a>
                                    </li>
                                </ul>
                                <%--<ul class="nav">
                                    <li class="nav-item ">
                                        <a class="nav-link" title="" href="/Pagess/thong-bao-tin-tuc.aspx">
                                            <span class="sidebar-mini"><i class="fa fa-user"></i></span>
                                            <span class="sidebar-normal">Đánh giá kết quả</span>
                                        </a>
                                    </li>
                                </ul>--%>
                            </div>
                        </li>
                        <%--END ĐỊNH BIÊN NHÂN SỰ--%>
                        <!--BEGIN BÁO CÁO THỐNG KÊ-->
                        <%--<%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Thongkebaocao))
                            { %>
                        <li class="nav-item ">
                            <a href="#pagesBCTK" data-toggle="collapse" aria-expanded="false" class="nav-link">
                                <i class="fas fa-chart-line"></i>
                                <p>
                                    <%=Resources.Common.lblBaoCaoThongKe %>
                                    <b class="caret"></b>
                                </p>
                            </a>
                            <div class="collapse" id="pagesBCTK">
                                <ul class="nav">
                                    <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Thongkebaocaovanbanden))
                                      { %>
                                    <li class="nav-item ">
                                        <a href="#pagesTKVBDEN" data-toggle="collapse" aria-expanded="false" class="nav-link">
                                            <i class="fa fa-book"></i>
                                            <p>
                                                <%=Resources.Common.lblVanBanDen %>
                                                <b class="caret"></b>
                                            </p>
                                        </a>
                                        <div class="collapse" id="pagesTKVBD">
                                            <ul class="nav">
                                                <li class="nav-item ">
                                                    <a class="nav-link" title="" href="/Pagess/thong-ke-van-ban-den-ban-lanh-dao.aspx">
                                                        <span class="sidebar-mini"><i class="fa fa-list-alt"></i></span>
                                                        <span class="sidebar-normal"><%=Resources.Common.lblBaoCaoTinhHinhXuLy %></span>
                                                    </a>
                                                </li>
                                            </ul>
                                        </div>
                                    </li>
                                    <%} %>
                                    <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Thongkebaocaovanbandi))
                                      { %>
                                    <li class="nav-item ">
                                        <a href="#pagesTKVBDI" data-toggle="collapse" aria-expanded="false" class="nav-link">
                                            <i class="fa fa-book"></i>
                                            <p>
                                                <%=Resources.Common.lblVanBanDi %>
                                                <b class="caret"></b>
                                            </p>
                                        </a>
                                        <div class="collapse" id="pagesTKVBDI">
                                            <ul class="nav">
                                                <li class="nav-item ">
                                                    <a class="nav-link" title="" href="/Pagess/thong-ke-van-ban-di.aspx">
                                                        <span class="sidebar-mini"><i class="fa fa-list-alt"></i></span>
                                                        <span class="sidebar-normal"><%=Resources.Common.lblThongKeVanBanDi %></span>
                                                    </a>
                                                </li>
                                                <li class="nav-item ">
                                                    <a class="nav-link" title="" href="/Pagess/thong-ke-van-ban-di-tong-hop.aspx">
                                                        <span class="sidebar-mini"><i class="fa fa-list-alt"></i></span>
                                                        <span class="sidebar-normal"><%=Resources.Common.lblThongKeTongHopVanBanDi %></span>
                                                    </a>
                                                </li>
                                            </ul>
                                        </div>
                                    </li>
                                    <%} %>
                                </ul>
                            </div>
                        </li>
                        <%} %>--%>
                        <!--END BÁO CÁO THỐNG KÊ-->
                        <!--BEGIN TRUNG TÂM GIẢI ĐÁP & PHẢN HỒI THÔNG TIN-->
                        <li class="nav-item ">
                            <a class="nav-link" title="" href="/Pagess/trung-tam-giai-dap.aspx">
                                <span class="sidebar-mini"><i class="fas fa-question"></i></span>
                                <span class="sidebar-normal">Trung tâm giải đáp</span>
                            </a>
                        </li>
                        <%--<li class="nav-item ">
                            <a class="nav-link" title="" href="/Pagess/phan-hoi-thong-tin.aspx">
                                <span class="sidebar-mini"><i class="fab fa-replyd"></i></span>
                                <span class="sidebar-normal">Phản hồi thông tin</span>
                            </a>
                        </li>--%>
                        <!--END TRUNG TÂM GIẢI ĐÁP & PHẢN HỒI THÔNG TIN-->
                    </ul>
                </div>
            </li>
            <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Hethong) || CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Capnhatnguoidung))
                {%>
            <li class="nav-item ">
                <a class="nav-link active-color" data-toggle="collapse" aria-expanded="false" href="#pagesEs">
                    <i class="fa fa-laptop icon-root" style="padding-left: 4px; margin-top: -0.2em;"></i>
                    <p><%=Resources.Common.lblTieuDeQuanTri %> </p>
                </a>
                <div class="collapse in" id="pagesEs">
                    <ul class="nav">
                        <!--BEGIN DANH MỤC-->
                        <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Danhmuc))
                            {%>
                        <li class="nav-item ">
                            <a href="#pagesDM" data-toggle="collapse" aria-expanded="false" class="nav-link">
                                <i class="fas fa-list-alt"></i>
                                <p>
                                    <%=Resources.Common.lblDanhMuc %>
                                    <b class="caret"></b>
                                </p>
                            </a>
                            <div class="collapse" id="pagesDM">
                                <ul class="nav">
                                    <li class="nav-item " style="display: none">
                                        <a class="nav-link" title="Nhóm danh mục" href="/Pagess/nhom-danh-muc.aspx">
                                            <span class="sidebar-mini"><i class="fa fa-clipboard"></i></span>
                                            <span class="sidebar-normal">Nhóm danh mục </span>
                                        </a>
                                    </li>
                                    <li class="nav-item " style="display: none">
                                        <a class="nav-link" title="Nhóm danh mục" href="/Pagess/danh-muc-chuc-nang.aspx">
                                            <span class="sidebar-mini"><i class="fa fa-list-alt"></i></span>
                                            <span class="sidebar-normal">Danh mục chức năng </span>
                                        </a>
                                    </li>
                                    <li class="nav-item ">
                                        <a class="nav-link" title="Danh mục" href="/Pagess/ten-danh-muc.aspx">
                                            <span class="sidebar-mini"><i class="fa fa-list-alt"></i></span>
                                            <span class="sidebar-normal"><%=Resources.Common.lblDanhMuc %></span>
                                        </a>
                                    </li>

                                    <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.ThietLapChungCaCom))
                                        {%>
                                    <li class="nav-item ">
                                        <a class="nav-link" title="Danh mục ca" href="/Pagess/danh-muc-ca.aspx">
                                            <span class="sidebar-mini"><i class="fas fa-code-branch"></i></span>
                                            <span class="sidebar-normal">Danh mục ca</span>
                                        </a>
                                    </li>
                                    <%} %>

                                    <li class="nav-item ">
                                        <a class="nav-link" title="Danh mục nhiệm vụ trọng tâm" href="/Pagess/danh-muc-nvtt.aspx">
                                            <span class="sidebar-mini"><i class="fas fa-th-list"></i></span>
                                            <span class="sidebar-normal">Danh mục NVTT</span>
                                        </a>
                                    </li>

                                    <li class="nav-item ">
                                        <a class="nav-link" title="Nơi nhận" href="/Pagess/noi-nhan.aspx">
                                            <span class="sidebar-mini"><i class="far fa-building"></i></span>
                                            <span class="sidebar-normal"><%=Resources.Common.lblCoQuanGuiNhan %></span>
                                        </a>
                                    </li>
                                    <li class="nav-item ">
                                        <a class="nav-link" title="Loại văn bản" href="/Pagess/loai-van-ban.aspx">
                                            <span class="sidebar-mini"><i class="fa fa-file-text-o"></i></span>
                                            <span class="sidebar-normal"><%=Resources.Common.lblLoaiVanBan %></span>
                                        </a>
                                    </li>
                                    <li class="nav-item ">
                                        <a class="nav-link" title="Sổ văn bản" href="/Pagess/so-van-ban.aspx">
                                            <span class="sidebar-mini"><i class="fa fa-book"></i></span>
                                            <span class="sidebar-normal"><%=Resources.Common.lblSoVanBan %></span>
                                        </a>
                                    </li>
                                    <li class="nav-item ">
                                        <a class="nav-link" title="Cây Phê Duyệt" href="/Pagess/cay-phe-duyet.aspx">
                                            <span class="sidebar-mini"><i class="fas fa-code-branch"></i></span>
                                            <span class="sidebar-normal">Cây Phê Duyệt</span>
                                        </a>
                                    </li>
                                </ul>
                            </div>
                        </li>
                        <%} %>
                        <!--END DANH MỤC-->
                        <!--BEGIN QUYỀN HẠN HỆ THỐNG-->
                        <li class="nav-item ">
                            <a href="#pagesTK" data-toggle="collapse" aria-expanded="false" class="nav-link">
                                <i class="far fa-address-card"></i>
                                <p>
                                    <%=Resources.Common.lblTaiKhoan %>
                                    <b class="caret"></b>
                                </p>
                            </a>
                            <div class="collapse" id="pagesTK">
                                <ul class="nav">
                                    <li class="nav-item " style="display: none">
                                        <a class="nav-link" title="" href="/Pagess/quyen-han.aspx">
                                            <span class="sidebar-mini"><i class="fa fa-gavel"></i></span>
                                            <span class="sidebar-normal">Quyền hạn hệ thống</span>
                                        </a>
                                    </li>
                                    <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Vaitro))
                                        {%>
                                    <li class="nav-item ">
                                        <a class="nav-link" title="" href="/Pagess/vai-tro-he-thong.aspx">
                                            <span class="sidebar-mini"><i class="fa fa-warning"></i></span>
                                            <span class="sidebar-normal"><%=Resources.Common.lblVaiTroHeThong %></span>
                                        </a>
                                    </li>
                                    <%} %>
                                    <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Chucvu))
                                        {%>
                                    <li class="nav-item ">
                                        <a class="nav-link" title="" href="/Pagess/nhom-nguoi-dung.aspx">
                                            <span class="sidebar-mini"><i class="fa fa-sitemap"></i></span>
                                            <span class="sidebar-normal"><%=Resources.Common.lblChucDanh %></span>
                                        </a>
                                    </li>
                                    <%} %>
                                    <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Nhomnguoidung))
                                        {%>
                                    <li class="nav-item ">
                                        <a class="nav-link" title="" href="/Pagess/nhom-ca-nhan.aspx">
                                            <span class="sidebar-mini"><i class="fa fa-group"></i></span>
                                            <span class="sidebar-normal"><%=Resources.Common.lblNhomNguoiDung %></span>
                                        </a>
                                    </li>
                                    <%} %>
                                    <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Nguoidung))
                                        {%>
                                    <li class="nav-item ">
                                        <a class="nav-link" title="" href="/Pagess/nguoi-dung.aspx">
                                            <span class="sidebar-mini"><i class="fa fa-user"></i></span>
                                            <span class="sidebar-normal"><%=Resources.Common.lblNguoiDung %></span>
                                        </a>
                                    </li>
                                    <%} %>
                                </ul>
                            </div>
                        </li>
                        <!--END QUYỀN HẠN HỆ THỐNG-->
                        <!--BEGIN CƠ CẤU TỔ CHỨC-->
                        <li class="nav-wid nav-item ">
                            <a href="#pagesCCTC" data-toggle="collapse" aria-expanded="false" class="nav-link">
                                <i class="fas fa-sitemap"></i>
                                <p>
                                    <%=Resources.Common.lblCoCauToChuc %>
                                    <b class="caret"></b>
                                </p>
                            </a>
                            <div class="collapse" id="pagesCCTC">
                                <ul class="nav page-sidebar-menu ">
                                    <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Donvi))
                                        {%>
                                    <li class="nav-wid nav-item ">
                                        <a class="nav-link" title="" href="/Pagess/don-vi.aspx">
                                            <span class="sidebar-mini"><i class="fa fa-sitemap"></i></span>
                                            <span class="sidebar-normal"><%=Resources.Common.lblDonViPhongBan %></span>
                                        </a>
                                    </li>
                                    <%} %>
                                    <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Nhomdonvi))
                                        {%>
                                    <li class="nav-wid nav-item " style="display: none">
                                        <a class="nav-link" title="" href="/Pagess/nhom-don-vi.aspx">
                                            <span class="sidebar-mini"><i class="fa fa-object-group"></i></span>
                                            <span class="sidebar-normal">Nhóm đơn vị phòng ban</span>
                                        </a>
                                    </li>
                                    <%} %>
                                </ul>
                            </div>
                        </li>
                        <!--END CƠ CẤU TỔ CHỨC-->
                        <!--BEGIN CẤU HÌNH MODULE-->
                        <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.CauhinhModule))
                            {%>
                        <li class="nav-item ">
                            <a href="#pagesCHHT" data-toggle="collapse" aria-expanded="false" class="nav-link">
                                <i class="fas fa-cogs"></i>
                                <p>
                                    <%=Resources.Common.lblCauHinhHeThong %>
                                    <b class="caret"></b>
                                </p>
                            </a>
                            <div class="collapse" id="pagesCHHT">
                                <ul class="nav">
                                    <li class="nav-item ">
                                        <a class="nav-link" title="" href="/Pagess/cau-hinh-sms-email.aspx">
                                            <span class="sidebar-mini"><i class="fa fa-wrench"></i></span>
                                            <span class="sidebar-normal"><%=Resources.Common.lblCauHinhSMSEmail %></span>
                                        </a>
                                    </li>
                                    <li class="nav-item " style="display: none">
                                        <a class="nav-link" title="" href="/HeThong/CauHinhDuLieu/danhsach.aspx">
                                            <span class="sidebar-mini"><i class="fa fa-wrench"></i></span>
                                            <span class="sidebar-normal">Cấu hình số bản ghi</span>
                                        </a>
                                    </li>
                                    <li class="nav-item " style="display: none">
                                        <a class="nav-link" title="" href="/Pagess/cau-hinh-module.aspx">
                                            <span class="sidebar-mini"><i class="fa fa-wrench"></i></span>
                                            <span class="sidebar-normal">Cấu hình hiển thị module</span>
                                        </a>
                                    </li>
                                </ul>
                            </div>
                        </li>
                        <%} %>
                        <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Loghethong))
                            {%>
                        <li class="nav-wid nav-item ">
                            <a class="nav-link" title="" href="/Pagess/log.aspx">
                                <span class="sidebar-mini"><i class="fas fa-database"></i></span>
                                <span class="sidebar-normal"><%=Resources.Common.lblLogHeThong %></span>
                            </a>
                        </li>
                        <%} %>
                        <!--END CẤU HÌNH MODULE-->
                    </ul>
                </div>
            </li>
            <%} %>
        </ul>
    </div>
    <div class="sidebar-background" style="background-image: url(/Publishing_Resources/img/sidebar-1.jpg)"></div>
</div>
<!--   Core JS Files   -->
<script src="/Publishing_Resources/dist/corgi/login/jquery.min.js"></script>
<script src="/Publishing_Resources/dist/corgi/login/popper.min.js"></script>
<script src="/Publishing_Resources/dist/corgi/login/bootstrap-material-design.min.js"></script>
<script src="/publishing_resources/dist/corgi/login/perfect-scrollbar.jquery.min.js"></script>
<script src="/Publishing_Resources/dist/corgi/login/material-dashboard.min.js" type="text/javascript"></script>

<script type="text/javascript">
    $(document).ready(function () {
        $(".sidebar").hover(function () {
            $(this).css("width", "270px")
            $(".sidebar-wrapper").css("width", "270px")
            $(".sidebar-normal").css({ "work-break": "break-work", "white-space": "normal", "width": "190px" });
            $(".logo_mini").css("display", "none");
            $(".logo").removeAttr("style", "display");
            //Văn bản đi
            $("#pagesVBDI > .nav > .nav-item > .nav-link").css("padding-left", "30px");
            //Văn bản đi > Chuyển phát
            $("#pagesCPBD > .nav > .nav-item > .nav-link").css("padding-left", "45px");

            //Điều hành
            $("#pagesCV > .nav > .nav-item > .nav-link").css("padding-left", "30px");
            //Điều hành > Quản lý báo cáo
            $("#pagesQLBCCV > .nav > .nav-item > .nav-link").css("padding-left", "45px");

            //Tiện ích
            $("#pagesTI > .nav > .nav-item > .nav-link").css("padding-left", "30px");
            //Định biên nhân sự
            $("#pagesDB > .nav > .nav-item > .nav-link").css("padding-left", "30px");

            //Tiện ích > Quản lý phòng họp
            $("#pagesQLPH > .nav > .nav-item > .nav-link").css("padding-left", "45px");
            //Tiện ích > Quản lý văn phòng phẩm
            $("#pagesVPP > .nav > .nav-item > .nav-link").css("padding-left", "45px");
            //Tiện ích > Quản lý xe
            $("#pagesDX > .nav > .nav-item > .nav-link").css("padding-left", "45px");
            //Tiện ích > Quản lý nghỉ phép
            $("#pagesNP > .nav > .nav-item > .nav-link").css("padding-left", "45px");

            //Danh mục
            $("#pagesDM > .nav > .nav-item > .nav-link").css("padding-left", "30px");
            //Tài khoản
            $("#pagesTK > .nav > .nav-item > .nav-link").css("padding-left", "30px");
            //Cơ cấu tổ chức
            $("#pagesCCTC > .nav > .nav-item > .nav-link").css("padding-left", "30px");
            //Cấu hình hệ thống
            $("#pagesCHHT > .nav > .nav-item > .nav-link").css("padding-left", "30px");


        }, function () {
            $(this).removeAttr("style");
            $(".logo_mini").removeAttr("style", "display");
            $(".logo").css("display", "none");
            $(".sidebar-wrapper").removeAttr("style");
            $(".sidebar-normal").removeAttr("style");
            //Văn bản đi
            $("#pagesVBDI > .nav > .nav-item > .nav-link").removeAttr("style");
            //Văn bản đi > Quản lý chuyển phát
            $("#pagesCPBD > .nav > .nav-item > .nav-link").removeAttr("style");

            //Điều hành
            $("#pagesCV > .nav > .nav-item > .nav-link").removeAttr("style");
            //Điều hành > Quản lý báo cáo
            $("#pagesQLBCCV > .nav > .nav-item > .nav-link").removeAttr("style");

            //Tiện ích
            $("#pagesTI > .nav > .nav-item > .nav-link").removeAttr("style");
            //Định biên nhân sự
            $("#pagesDB > .nav > .nav-item > .nav-link").removeAttr("style");
            //Tiện ích > Quản lý phòng họp
            $("#pagesQLPH > .nav > .nav-item > .nav-link").removeAttr("style");
            //Tiện ích > Quản lý văn phòng phẩm
            $("#pagesVPP > .nav > .nav-item > .nav-link").removeAttr("style");
            //Tiện ích > Quản lý xe
            $("#pagesDX > .nav > .nav-item > .nav-link").removeAttr("style");
            //Tiện ích > Quản lý nghỉ phép
            $("#pagesNP > .nav > .nav-item > .nav-link").removeAttr("style");

            //Danh mục
            $("#pagesDM > .nav > .nav-item > .nav-link").removeAttr("style");
            //Tài khoản
            $("#pagesTK > .nav > .nav-item > .nav-link").removeAttr("style");
            //Cơ cấu tổ chức
            $("#pagesCCTC > .nav > .nav-item > .nav-link").removeAttr("style");
            //Cấu hình hệ thống
            $("#pagesCHHT > .nav > .nav-item > .nav-link").removeAttr("style");
        });
    })

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
</script>
<%--<script>
    $(document).ready(function () {
        $().ready(function () {
            $sidebar = $('.sidebar');

            $sidebar_img_container = $sidebar.find('.sidebar-background');

            $full_page = $('.full-page');

            $sidebar_responsive = $('body > .navbar-collapse');

            window_width = $(window).width();

            fixed_plugin_open = $('.sidebar .sidebar-wrapper .nav li.active a p').html();

            if (window_width > 767 && fixed_plugin_open == 'Dashboard') {
                if ($('.fixed-plugin .dropdown').hasClass('show-dropdown')) {
                    $('.fixed-plugin .dropdown').addClass('open');
                }

            }

            $('.fixed-plugin a').click(function (event) {
                // Alex if we click on switch, stop propagation of the event, so the dropdown will not be hide, otherwise we set the  section active
                if ($(this).hasClass('switch-trigger')) {
                    if (event.stopPropagation) {
                        event.stopPropagation();
                    } else if (window.event) {
                        window.event.cancelBubble = true;
                    }
                }
            });

            $('.fixed-plugin .active-color span').click(function () {
                $full_page_background = $('.full-page-background');

                $(this).siblings().removeClass('active');
                $(this).addClass('active');

                var new_color = $(this).data('color');

                if ($sidebar.length != 0) {
                    $sidebar.attr('data-color', new_color);
                }

                if ($full_page.length != 0) {
                    $full_page.attr('filter-color', new_color);
                }

                if ($sidebar_responsive.length != 0) {
                    $sidebar_responsive.attr('data-color', new_color);
                }
            });

            $('.fixed-plugin .background-color .badge').click(function () {
                $(this).siblings().removeClass('active');
                $(this).addClass('active');

                var new_color = $(this).data('background-color');

                if ($sidebar.length != 0) {
                    $sidebar.attr('data-background-color', new_color);
                }
            });

            $('.fixed-plugin .img-holder').click(function () {
                $full_page_background = $('.full-page-background');

                $(this).parent('li').siblings().removeClass('active');
                $(this).parent('li').addClass('active');


                var new_image = $(this).find("img").attr('src');

                if ($sidebar_img_container.length != 0 && $('.switch-sidebar-image input:checked').length != 0) {
                    $sidebar_img_container.fadeOut('fast', function () {
                        $sidebar_img_container.css('background-image', 'url("' + new_image + '")');
                        $sidebar_img_container.fadeIn('fast');
                    });
                }

                if ($full_page_background.length != 0 && $('.switch-sidebar-image input:checked').length != 0) {
                    var new_image_full_page = $('.fixed-plugin li.active .img-holder').find('img').data('src');

                    $full_page_background.fadeOut('fast', function () {
                        $full_page_background.css('background-image', 'url("' + new_image_full_page + '")');
                        $full_page_background.fadeIn('fast');
                    });
                }

                if ($('.switch-sidebar-image input:checked').length == 0) {
                    var new_image = $('.fixed-plugin li.active .img-holder').find("img").attr('src');
                    var new_image_full_page = $('.fixed-plugin li.active .img-holder').find('img').data('src');

                    $sidebar_img_container.css('background-image', 'url("' + new_image + '")');
                    $full_page_background.css('background-image', 'url("' + new_image_full_page + '")');
                }

                if ($sidebar_responsive.length != 0) {
                    $sidebar_responsive.css('background-image', 'url("' + new_image + '")');
                }
            });

            $('.switch-sidebar-image input').change(function () {
                $full_page_background = $('.full-page-background');

                $input = $(this);

                if ($input.is(':checked')) {
                    if ($sidebar_img_container.length != 0) {
                        $sidebar_img_container.fadeIn('fast');
                        $sidebar.attr('data-image', '#');
                    }

                    if ($full_page_background.length != 0) {
                        $full_page_background.fadeIn('fast');
                        $full_page.attr('data-image', '#');
                    }

                    background_image = true;
                } else {
                    if ($sidebar_img_container.length != 0) {
                        $sidebar.removeAttr('data-image');
                        $sidebar_img_container.fadeOut('fast');
                    }

                    if ($full_page_background.length != 0) {
                        $full_page.removeAttr('data-image', '#');
                        $full_page_background.fadeOut('fast');
                    }

                    background_image = false;
                }
            });

            $('.switch-sidebar-mini input').change(function () {
                $body = $('body');

                $input = $(this);

                if (md.misc.sidebar_mini_active == true) {
                    $('body').removeClass('sidebar-mini');
                    md.misc.sidebar_mini_active = false;

                    //$('.sidebar .sidebar-wrapper, .main-panel').perfectScrollbar();

                } else {

                    //$('.sidebar .sidebar-wrapper, .main-panel').perfectScrollbar('destroy');

                    setTimeout(function () {
                        $('body').addClass('sidebar-mini');

                        md.misc.sidebar_mini_active = true;
                    }, 300);
                }

                // we simulate the window Resize so the charts will get updated in realtime.
                var simulateWindowResize = setInterval(function () {
                    window.dispatchEvent(new Event('resize'));
                }, 180);

                // we stop the simulation of Window Resize after the animations are completed
                setTimeout(function () {
                    clearInterval(simulateWindowResize);
                }, 1000);

            });
        });
    });
</script>--%>
<%--<script>
    $(document).ready(function () {
        $().ready(function () {
            $sidebar = $('.sidebar');

            $sidebar_img_container = $sidebar.find('.sidebar-background');

            $full_page = $('.full-page');

            $sidebar_responsive = $('body > .navbar-collapse');

            window_width = $(window).width();

            fixed_plugin_open = $('.sidebar .sidebar-wrapper .nav li.active a p').html();

            if (window_width > 767 && fixed_plugin_open == 'Dashboard') {
                if ($('.fixed-plugin .dropdown').hasClass('show-dropdown')) {
                    $('.fixed-plugin .dropdown').addClass('open');
                }

            }

            $('.fixed-plugin a').click(function (event) {
                // Alex if we click on switch, stop propagation of the event, so the dropdown will not be hide, otherwise we set the  section active
                if ($(this).hasClass('switch-trigger')) {
                    if (event.stopPropagation) {
                        event.stopPropagation();
                    } else if (window.event) {
                        window.event.cancelBubble = true;
                    }
                }
            });

            $('.fixed-plugin .active-color span').click(function () {
                $full_page_background = $('.full-page-background');

                $(this).siblings().removeClass('active');
                $(this).addClass('active');

                var new_color = $(this).data('color');

                if ($sidebar.length != 0) {
                    $sidebar.attr('data-color', new_color);
                }

                if ($full_page.length != 0) {
                    $full_page.attr('filter-color', new_color);
                }

                if ($sidebar_responsive.length != 0) {
                    $sidebar_responsive.attr('data-color', new_color);
                }
            });

            $('.fixed-plugin .background-color .badge').click(function () {
                $(this).siblings().removeClass('active');
                $(this).addClass('active');

                var new_color = $(this).data('background-color');

                if ($sidebar.length != 0) {
                    $sidebar.attr('data-background-color', new_color);
                }
            });

            $('.fixed-plugin .img-holder').click(function () {
                $full_page_background = $('.full-page-background');

                $(this).parent('li').siblings().removeClass('active');
                $(this).parent('li').addClass('active');


                var new_image = $(this).find("img").attr('src');

                if ($sidebar_img_container.length != 0 && $('.switch-sidebar-image input:checked').length != 0) {
                    $sidebar_img_container.fadeOut('fast', function () {
                        $sidebar_img_container.css('background-image', 'url("' + new_image + '")');
                        $sidebar_img_container.fadeIn('fast');
                    });
                }

                if ($full_page_background.length != 0 && $('.switch-sidebar-image input:checked').length != 0) {
                    var new_image_full_page = $('.fixed-plugin li.active .img-holder').find('img').data('src');

                    $full_page_background.fadeOut('fast', function () {
                        $full_page_background.css('background-image', 'url("' + new_image_full_page + '")');
                        $full_page_background.fadeIn('fast');
                    });
                }

                if ($('.switch-sidebar-image input:checked').length == 0) {
                    var new_image = $('.fixed-plugin li.active .img-holder').find("img").attr('src');
                    var new_image_full_page = $('.fixed-plugin li.active .img-holder').find('img').data('src');

                    $sidebar_img_container.css('background-image', 'url("' + new_image + '")');
                    $full_page_background.css('background-image', 'url("' + new_image_full_page + '")');
                }

                if ($sidebar_responsive.length != 0) {
                    $sidebar_responsive.css('background-image', 'url("' + new_image + '")');
                }
            });

            $('.switch-sidebar-image input').change(function () {
                $full_page_background = $('.full-page-background');

                $input = $(this);

                if ($input.is(':checked')) {
                    if ($sidebar_img_container.length != 0) {
                        $sidebar_img_container.fadeIn('fast');
                        $sidebar.attr('data-image', '#');
                    }

                    if ($full_page_background.length != 0) {
                        $full_page_background.fadeIn('fast');
                        $full_page.attr('data-image', '#');
                    }

                    background_image = true;
                } else {
                    if ($sidebar_img_container.length != 0) {
                        $sidebar.removeAttr('data-image');
                        $sidebar_img_container.fadeOut('fast');
                    }

                    if ($full_page_background.length != 0) {
                        $full_page.removeAttr('data-image', '#');
                        $full_page_background.fadeOut('fast');
                    }

                    background_image = false;
                }
            });

            $('.switch-sidebar-mini input').change(function () {
                $body = $('body');

                $input = $(this);

                if (md.misc.sidebar_mini_active == true) {
                    $('body').removeClass('sidebar-mini');
                    md.misc.sidebar_mini_active = false;

                    $('.sidebar .sidebar-wrapper, .main-panel').perfectScrollbar();

                } else {

                    //$('.sidebar .sidebar-wrapper, .main-panel').perfectScrollbar('destroy');

                    setTimeout(function () {
                        $('body').addClass('sidebar-mini');

                        md.misc.sidebar_mini_active = true;
                    }, 300);
                }

                // we simulate the window Resize so the charts will get updated in realtime.
                var simulateWindowResize = setInterval(function () {
                    window.dispatchEvent(new Event('resize'));
                }, 180);

                // we stop the simulation of Window Resize after the animations are completed
                setTimeout(function () {
                    clearInterval(simulateWindowResize);
                }, 1000);

            });
        });
    });
</script>--%>
