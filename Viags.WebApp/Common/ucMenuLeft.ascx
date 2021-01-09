<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucMenuLeft.ascx.cs" Inherits="Viags.WebApp.Common.ucMenuLeft" %>
<div class="page-sidebar-wrapper">
    <%string path = HttpContext.Current.Request.Url.AbsolutePath; %>

    <div class="page-sidebar navbar-collapse collapse">
        <!-- BEGIN SIDEBAR MENU -->
        <ul class="page-sidebar-menu page-sidebar-menu-closed " data-keep-expanded="false" data-auto-scroll="true" data-slide-speed="200">
            <li class="sidebar-toggler-wrapper" id="btnHideMenu" title="Ẩn hiện menu trái">
                <!-- BEGIN SIDEBAR TOGGLER BUTTON -->
                <div class="sidebar-toggler" style="float: left">
                </div>
                <!-- END SIDEBAR TOGGLER BUTTON -->
            </li>
            <%--  <li class="active ">
                <a href="/download">
                    <i class="fa fa-university icon-root"></i>
                    <span class="title">TÀI LIỆU & VIDEO HDSD</span>
                </a>
            </li>--%>
            <li class="active open ">
                <a href="javascript:;">
                    <i class="fa fa-university icon-root"></i>
                    <span class="title">QUẢN LÝ VĂN BẢN, ĐIỀU HÀNH</span>

                </a>
                <ul class="sub-menu">
                    <!--<li>
                        <a title="Trang chủ" href="/home.aspx">Trang chủ</a>
                    </li>-->
                    <!--BEGIN VĂN BẢN ĐẾN-->
                    <% if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Vanbanden))
                       { %>
                    <li>
                        <a title="" href="#">Văn bản đến<span class="arrow"></span>
                        </a>
                        <ul class="sub-menu">
                            <%if (CurrentUser.IsDaCap)
                              { %>
                            <%if (CurrentUser.ViTriID == (int)Viags.Utils.Enum.TypeOfRole.VanThuDonVi && CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Vanthutonghop))
                              { %>
                            <li><a title="Văn bản đến BLĐ">Văn bản đến<span class="arrow"></span></a>
                                <ul class="sub-menu">
                                    <% if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Themmoivanbanden))
                                       { %>
                                    <li><a title="" href="/Pagess/form-van-ban-den.aspx"><i class="icon-plus"></i>Thêm mới văn bản</a></li>
                                    <%} %>
                                    <li>
                                        <a title="" href="/Pagess/van-ban-den-cho-vao-so.aspx"><i class="fa fa-book "></i>Văn bản đến mới <b id="idvanbanchovaoso"></b></a>
                                    </li>
                                    <li><a title="" href="/Pagess/van-ban-den.aspx"><i class="fa fa-book "></i>Danh sách văn bản</a>
                                        <% if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.VanthuBanlanhdao) || CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.ThukyBanlanhdao) || CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.VanthuDonvi)
                                   || CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Vanthutonghop))
                                           { %>
                                        <ul class="sub-menu">
                                            <%foreach (var item in LstSoVanBanDen.Where(p => p.IsDonVi == false).ToList())
                                              { %>
                                            <li><a title="" href="/Pagess/van-ban-den.aspx#Field=ThuTu&SoVanBanID=<%:item.ID %>&LoaiDanhSachID=0&Page=1&RowPerPage=10"><i class="fa fa-list-alt"></i><%:item.Ten %></a>
                                            </li>
                                            <%} %>
                                        </ul>
                                        <%} %>
                                    </li>
                                    <% if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Insovanbanden))
                                       { %>
                                    <li><a title="" href="/Pagess/in-so-van-ban-den.aspx#NgayDenDau=<%:DateTime.Now.ToString("dd/MM/yyyy") %>&InSo=1"><i class="fa fa-print"></i>In sổ văn bản</a></li>
                                    <%} %>
                                </ul>
                            </li>
                            <%} %>
                            <%else
                              { %>
                            <% if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Themmoivanbanden))
                               { %>
                            <li><a title="" href="/Pagess/form-van-ban-den.aspx"><i class="icon-plus"></i>Thêm mới văn bản</a></li>

                            <%} %>
                            <% if ((CurrentUser.ViTriID == (int)Viags.Utils.Enum.TypeOfRole.VanThuDonVi))
                               { %>
                            <li>
                                <a title="" href="/Pagess/van-ban-den-cho-vao-so.aspx"><i class="fa fa-book "></i>Văn bản đến mới <b id="idvanbanchovaoso"></b></a>
                            </li>

                            <%} %>
                            <% if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.VanthuBanlanhdao) || CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.ThukyBanlanhdao) || CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.VanthuDonvi)
                                   || CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Vanthutonghop))
                               { %>
                            <li><a title="" href="/Pagess/van-ban-den.aspx"><i class="fa fa-book "></i>Danh sách văn bản</a>
                                <ul class="sub-menu">
                                    <%foreach (var item in LstSoVanBanDen.Where(p => p.IsDonVi == false).ToList())
                                      { %>
                                    <li><a title="" href="/Pagess/van-ban-den.aspx#LoaiDanhSachID=0&SoVanBanID=<%:item.ID %>&Page=1&RowPerPage=10"><i class="fa fa-list-alt"></i><%:item.Ten %></a>
                                    </li>
                                    <%} %>
                                </ul>
                            </li>
                            <%} %>
                            <%else
                               { %>
                            <li>
                                <a title="" href="/Pagess/van-ban-den.aspx#LoaiDanhSachID=0&Page=1&RowPerPage=10"><i class="fa fa-book "></i>Danh sách văn bản</a>
                            </li>
                            <%} %>

                            <% if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Insovanbanden))
                               { %>
                            <%if (CurrentUser.IsDaCap && CurrentUser.DonViChaID > 0)
                              { %>
                            <li><a title="" href="/Pagess/in-so-van-ban-den.aspx#MauBCID=1"><i class="fa fa-print"></i>In sổ văn bản</a></li>
                            <%}
                              else
                              { %>
                            <li><a title="" href="/Pagess/in-so-van-ban-den.aspx?InSo=1"><i class="fa fa-print"></i>In sổ văn bản</a></li>
                            <%} %>
                            <%} %>
                            <%} %>
                            <!--end VBDen NHNN-->
                            <%} %>
                            <%else
                              { %>

                            <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.VanthuDonvi))
                              { %>

                            <% if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Themmoivanbanden))
                               { %>
                            <li><a title="" href="/Pagess/form-van-ban-den.aspx"><i class="icon-plus"></i>Thêm mới văn bản</a></li>
                            <%} %>
                            <li>
                                <a title="" href="/Pagess/van-ban-den-cho-vao-so.aspx"><i class="fa fa-book "></i>Văn bản đến mới <b id="idvanbanchovaoso"></b></a>
                            </li>
                            <%if (path.ToLower() == "/pagess/chi-tiet-van-ban-den.aspx")
                              {%>
                            <li><a title="" href="/pagess/chi-tiet-van-ban-den.aspx?ItemID=<%=ItemID%>&do=view"><i class="fa fa-book"></i>Chi tiết văn bản</a></li>
                            <%} %>
                            <li><a title="" href="/Pagess/van-ban-den.aspx#LoaiDanhSachID=0&Page=1&RowPerPage=10"><i class="fa fa-book "></i>Danh sách văn bản</a>
                                <%if (LstSoVanBanDen.Any() && CurrentUser.ViTriID == (int)Viags.Utils.Enum.TypeOfRole.VanThuDonVi)
                                  { %>
                                <ul class="sub-menu">
                                    <%foreach (var item in LstSoVanBanDen)
                                      { %>
                                    <li><a title="" href="/Pagess/van-ban-den.aspx#Field=ThuTu&LoaiDanhSachID=0&SoVanBanID=<%:item.ID %>&Page=1&RowPerPage=10"><i class="fa fa-list-alt"></i><%:item.Ten %></a>
                                    </li>
                                    <%} %>
                                </ul>
                                <%} %>
                            </li>
                            <% if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Insovanbanden))
                               { %>
                            <li><a title="" href="/Pagess/in-so-van-ban-den.aspx?InSo=1"><i class="fa fa-print"></i>In sổ văn bản</a></li>
                            <%} %>

                            <%}%>
                            <% if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Vanthuphongban))
                               { %>
                            <li><a title="Văn bản đến phòng ban">Văn bản đến phòng ban<span class="arrow"></span></a>

                                <ul class="sub-menu">
                                    <li><a title="" href="/Pagess/van-ban-den.aspx#LoaiDanhSachID=0&Page=1&RowPerPage=10"><i class="fa fa-book "></i>Danh sách văn bản</a>
                                        <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Vanthuphongban))
                                          { %>
                                        <ul class="sub-menu">
                                            <%foreach (var item in LstSoVanBanDenPB)
                                              { %>
                                            <li><a title="" href="/Pagess/van-ban-den.aspx#Field=ThuTu&LoaiDanhSachID=0&SoVanBanID=<%:item.ID %>&Page=1&RowPerPage=10"><i class="fa fa-list-alt"></i><%:item.Ten %></a>
                                            </li>
                                            <%} %>
                                        </ul>
                                        <%} %>
                                    </li>
                                    <% if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Themmoivanbanden))
                                       { %>
                                    <li><a title="" href="/Pagess/form-van-ban-den.aspx?IsPhongBan=True"><i class="fa fa-book "></i>Thêm mới văn bản</a></li>
                                    <li><a title="" href="/Pagess/van-ban-den-phong-ban-cho-vao-so.aspx"><i class="fa fa-book "></i>Văn bản chờ vào sổ <b id="idvanbanchovaosophongban"></b></a></li>
                                    <li><a title="" href="/Pagess/so-van-ban-phong-ban.aspx"><i class="fa fa-book "></i>Sổ phòng ban</a></li>
                                    <%} %>
                                    <% if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Insovanbanden))
                                       { %>
                                    <li><a title="" href="/Pagess/in-so-van-ban-den-phong-ban.aspx"><i class="fa fa-print"></i>In sổ văn bản phòng ban</a></li>
                                    <%} %>
                                </ul>
                            </li>
                            <%} %>
                            <%if (!CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Vanthuphongban) && !CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.VanthuDonvi))
                              {%>
                            <li><a title="" href="/Pagess/van-ban-den.aspx#LoaiDanhSachID=0&Page=1&RowPerPage=10"><i class="fa fa-book "></i>Danh sách văn bản</a></li>
                            <%} %>
                            <%} %>
                            <li><a title="" href="/Pagess/van-ban-den.aspx#LoaiDanhSachID=1&Page=1&RowPerPage=10"><i class="fa fa-book "></i>Văn bản chưa xử lý <b id="idvanbanchuaxuly"></b></a></li>
                            <li><a title="" href="/Pagess/van-ban-den.aspx#LoaiDanhSachID=2&Page=1&RowPerPage=10"><i class="fa fa-book "></i>Văn bản đang xử lý <b id="idvanbandangxuly"></b></a></li>
                            <li><a title="" href="/Pagess/van-ban-den.aspx#LoaiDanhSachID=3&Page=1&RowPerPage=10"><i class="fa fa-book "></i>Văn bản đã xử lý</a></li>
                        </ul>
                    </li>

                    <%} %>
                    <!--END VĂN BẢN ĐẾN-->

                    <!--BEGIN VĂN BẢN ĐI-->
                    <% if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Vanbandi))
                       { %>
                    <li>
                        <a title="" href="#">Văn bản đi<span class="arrow"></span>
                        </a>
                        <ul class="sub-menu">

                            <%if (CurrentUser.ViTriID == (int)Viags.Utils.Enum.TypeOfRole.VanThuDonVi)
                              { %>

                            <% if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Themmoivanbandi))
                               {%>
                            <li><a title="" href="/Pagess/form-van-ban-di.aspx"><i class="icon-plus"></i>Thêm mới văn bản</a></li>
                            <%}%>
                            <li><a title="" href="/Pagess/van-ban-di.aspx"><i class="fa fa-list-alt"></i>Danh sách<b id="idvanbandithuong"></b></a>
                                <ul class="sub-menu">
                                    <%foreach (var item in LstSoVanBan)
                                      { %>
                                    <li><a title="" href="/Pagess/van-ban-di.aspx#SoVanBanID=<%:item.ID %>&Field=ThuTuSearch&Page=1&RowPerPage=10"><i class="fa fa-list-alt"></i><%:item.Ten %></a>  </li>
                                    <%} %>
                                </ul>
                            </li>
                            <li><a title="" href="/Pagess/van-ban-di.aspx#LoaiID=1"><i class="fa fa-list-alt"></i>Văn bản phát hành</a></li>
                            <li><a title="" href="/Pagess/van-ban-di.aspx#LoaiID=2"><i class="fa fa-list-alt"></i>Văn bản chưa phát hành</a></li>
                            <% if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Insovanbandi))
                               { %>
                            <li><a title="" href="/Pagess/in-so-van-ban-di.aspx#ThoiGianBatDau=<%:DateTime.Now.ToString("dd/MM/yyyy") %>&InSo=1"><i class="fa fa-book"></i>In sổ</a></li>
                            <%} %>

                            <%} %>
                            <%if (CurrentUser.ViTriID != (int)Viags.Utils.Enum.TypeOfRole.VanThuDonVi)
                              { %>
                            <li><a title="" href="/Pagess/van-ban-di.aspx"><i class="fa fa-book"></i>Danh sách văn bản
                <%if (CheckVanBanDiChuaDoc)
                  { %>
                                <span class="label label-default" style="border: 1px solid #ff0000; border-radius: 5px 10px 4px;">New</span>
                                <%} %>
                            </a>
                            </li>
                            <%} %>
                            <%if (path.ToLower() == "/pagess/chi-tiet-van-ban-di.aspx")
                              {%>
                            <li><a title="" href="/Pagess/chi-tiet-van-ban-di.aspx?do=view&ItemID=<%=ItemID %>"><i class="fa fa-book"></i>Chi tiết văn bản</a>
                                <%} %>
                                <% if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Themmoivanbandi) && CurrentUser.ViTriID == (int)Viags.Utils.Enum.TypeOfRole.VanThuDonVi)
                                   { %>
                            <li style="display: none"><a title="" href="/Pagess/van-ban-di-cho-cap-so.aspx"><i class="fa fa-book"></i>Văn bản chờ vào sổ <b id="idvanbandichovaoso"></b></a></li>
                            <%} %>

                            <% if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Themmoivanbandi) && CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Vanthuphongban))
                               { %>
                            <li><a title="" href="#"><i class="fa fa-book"></i>Văn bản đi phòng ban<span class="arrow"></span></a>
                                <ul class="sub-menu">
                                    <li><a title="" href="/Pagess/form-van-ban-di.aspx"><i class="fa fa-book "></i>Thêm mới văn bản</a></li>
                                    <li><a title="" href="/Pagess/van-ban-di-phong-ban-cho-vao-so.aspx"><i class="fa fa-book "></i>Văn bản chờ vào sổ<b id="idvanbandiphongbanchovaoso"></b></a></li>
                                    <li><a title="" href="/Pagess/van-ban-di-phong-ban.aspx"><i class="fa fa-book "></i>Văn bản đi phòng ban<b id="idvanbandiphongban"></b></a></li>
                                </ul>
                            </li>
                            <%} %>
                            <% if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.VanthuDonvi) || CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Vanthutonghop))
                               { %>
                            <li><a title="" href="/Pagess/don-vi-lien-thong.aspx"><i class="fa fa-book"></i>Đơn vị liên thông</a></li>
                            <%} %>
                        </ul>
                    </li>
                    <%} %>
                    <!--END VĂN BẢN ĐI-->

                    <!--BEGIN TỜ TRÌNH-->

                    <!--END TỜ TRÌNH-->

                    <!-- Dieu Hanh-->


                    <!-- Dieu Hanh-->
                    <!--BEGIN CÔNG VIỆC-->
                    <% if (!CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.QuantrihethongAdmin))
                       {%>
                    <li>
                        <a title="" href="#">Điều hành<span class="arrow"></span>
                        </a>
                        <ul class="sub-menu">


                            <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Congviec))
                              { %>
                            <li>
                                <a title="" href="#"><i class="fa fa-briefcase"></i>Quản lý Công việc<span class="arrow"></span></a>
                                <ul class="sub-menu">
                                    <li><a title="" href="/Pagess/form-ho-so-cong-viec.aspx"><i class="icon-plus"></i>Thêm mới công việc</a></li>
                                     <li><a title="" href="/Pagess/duyet-ngan-sach.aspx"><i class="fa fa-book"></i>Duyệt ngân sách công việc</a></li>
                                    <li><a title="" href="/Pagess/cong-viec.aspx"><i class="fa fa-book"></i>Danh sách công việc</a></li>
                                    <%if (path.ToLower() == "/pagess/chi-tiet-cong-viec.aspx")
                                      {%>
                                    <li><a title="" href="/Pagess/chi-tiet-cong-viec.aspx?do=view&ItemID=<%=ItemID %>"><i class="fa fa-book"></i>Chi tiết công việc</a>
                                        <%} %>
                                    <li><a title="" href="/Pagess/cong-viec-chua-xu-ly.aspx"><i class="fa fa-book"></i>Công việc chưa xử lý <b id="idcongviecchuaxuly"></b></a></li>
                                    <li><a title="" href="/Pagess/cong-viec-dang-xu-ly.aspx"><i class="fa fa-book"></i>Công việc đang xử lý <b id="idcongviecdangkxuly"></b></a></li>
                                    <li><a title="" href="/Pagess/cong-viec-da-xu-ly.aspx"><i class="fa fa-book"></i>Công việc đã xử lý</a></li>
                                    <li><a title="" href="/Pagess/tong-hop-cong-viec.aspx"><i class="fa fa-bar-chart-o"></i>Tổng hợp công việc</a></li>
                                    <li style="display: none"><a title="" href="/Pagess/bao-cao-cong-viec.aspx"><i class="fa fa-bar-chart-o"></i>Báo cáo công việc</a></li>
                                </ul>
                            </li>
                            <%} %>
                            <li><a title="" href="/Pagess/ban-giao-cong-viec.aspx"><i class="fa fa-legal"></i>Bàn giao công việc</a></li>
                            <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Baocaocongviec))
                              { %>
                            <li>
                                <a title="" href="#"><i class="fa fa-briefcase"></i>Quản lý báo cáo công việc<span class="arrow"></span></a>
                                <ul class="sub-menu">
                                    <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Cauhinhthoigianbaocao))
                                      { %>
                                    <li><a title="" href="/BaoCaoCongViec/CauHinhThoiGianBaoCao/Default.aspx"><i class="icon-plus"></i>Thiết đặt thời gian báo cáo</a></li>
                                    <%} %>
                                     <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Cauhinhthoigianbaocao))
                                      { %>
                                    <li><a title="" href="/BaoCaoCongViec/CauHinhThoiGianKhongBaoCao/Default.aspx"><i class="icon-plus"></i>Thiết đặt thời gian không báo cáo</a></li>
                                    <%} %>
                                     <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Baocaocongviec))
                                      { %>
                                    <li><a title="" href="/BaoCaoCongViec/BaoCaoCuaDonVi/Default.aspx"><i class="icon-plus"></i>Báo cáo công việc</a></li>
                                    <%} %>
                                     <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Nhanbaocaotudonvi))
                                      { %>
                                    <li><a title="" href="/BaoCaoCongViec/TongHopBaoCao/Default.aspx"><i class="icon-plus"></i>Tổng hợp báo cáo</a></li>
                                    <%} %>
                                </ul>
                            </li>
                            <%} %>
                            <%if (CurrentUser != null && (CurrentUser.ViTriID == (int)Viags.Utils.Enum.TypeOfRole.LanhDaoPhongBan || CurrentUser.ViTriID == (int)Viags.Utils.Enum.TypeOfRole.LanhDaoHanhChinh || CurrentUser.ViTriID == (int)Viags.Utils.Enum.TypeOfRole.LanhDaoVanPhong || CurrentUser.ViTriID == (int)Viags.Utils.Enum.TypeOfRole.LanhDaoDonVi || CurrentUser.ViTriID == (int)Viags.Utils.Enum.TypeOfRole.LanhDaoNHNN))
                              { %>
                            <li><a href="/Pagess/uy-quyen.aspx"><i class="icon-calendar"></i>Ủy quyền</a></li>
                            <%} %>
                            <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Theodoiuyquyen))
                              { %>
                            <li><a title="Theo dõi ủy quyền" href="/Pagess/theo-doi-uy-quyen.aspx"><i class="fa fa-legal"></i>Theo dõi ủy quyền</a></li>
                            <%} %>

                            <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Thongbao))
                              { %>
                            <li><a title="" href="/Pagess/thong-bao.aspx"><i class="fa fa-book"></i>Thông báo chung</a></li>
                            <%} %>
                        </ul>
                    </li>
                    <%} %>
                    <li><a title="" href="#">Tiện ích<span class="arrow"></span></a>
                        <ul class="sub-menu">
                            <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Lichlamviec))
                              { %>
                            <li><a title="" href="/Pagess/lich-lanh-dao.aspx"><i class="fa fa-calendar-o"></i>Lịch làm việc của BLĐ</a></li>
                            <%} %>
                            <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Datphonghop))
                              { %>
                            <li>
                                <a title="" href="#"><i class="fa fa-bank"></i>Quản lý phòng họp<span class="arrow"></span></a>
                                <ul class="sub-menu">
                                    <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Phonghop))
                                      {%>
                                    <li><a title="" href="/Pagess/danh-muc-phong-hop.aspx"><i class="fa fa-calendar"></i>Phòng họp</a></li>
                                    <%}%>
                                    <li><a title="" href="/Pagess/thong-tin-dat-phong.aspx"><i class="fa fa-calendar"></i>Thông tin đặt phòng</a></li>
                                </ul>
                            </li>
                            <%} %>
                        </ul>
                    </li>
                    <% if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Vanbanduthao))
                       { %>
                    <li>
                        <a title="" href="#">Văn bản dự thảo<span class="arrow"></span>
                        </a>
                        <ul class="sub-menu">
                            <% if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Themmoivanbanduthao))
                               { %>
                            <li><a title="" href="/Pagess/form-van-ban-du-thao.aspx"><i class="icon-plus"></i>Thêm mới văn bản</a></li>
                            <%} %>
                            <%if (path.ToLower() == "/pagess/chi-tiet-van-ban-du-thao.aspx")
                              {%>
                            <li><a title="" href="/Pagess/chi-tiet-van-ban-du-thao.aspx?do=view&ItemID=<%=ItemID %>"><i class="fa fa-book"></i>Chi tiết văn bản</a>
                                <%} %>
                            <li><a title="" href="/Pagess/van-ban-du-thao.aspx"><i class="fa fa-book"></i>Danh sách văn bản</a></li>
                            <li><a title="" href="/Pagess/van-ban-du-thao-chua-xu-ly.aspx"><i class="fa fa-book"></i>Chưa xử lý</a></li>
                            <li><a title="" href="/Pagess/van-ban-du-thao-dang-xu-ly.aspx"><i class="fa fa-book"></i>Đang xử lý</a></li>
                            <li><a title="" href="/Pagess/van-ban-du-thao-da-xu-ly.aspx"><i class="fa fa-book"></i>Đã xử lý</a></li>
                        </ul>
                    </li>
                    <%} %>
                    <!--END THƯ VIỆN-->
                    <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Hosotailieu))
                      { %>
                    <li>
                        <a title="" href="#">Quản lý hồ sơ<span class="arrow"></span>
                        </a>
                        <ul class="sub-menu">

                            <li><a title="Danh sách hồ sơ" href="/Pagess/quan-ly-ho-so-tai-lieu.aspx"><i class="fa fa-file-archive-o"></i>Danh sách hồ sơ</a></li>
                            <%if (ItemID > 0)
                              {%>
                            <li><a title="Chi tiết hồ sơ" href="/Pagess/chi-tiet-ho-so-tai-lieu.aspx?ItemID=<%=ItemID %>"><i class="fa fa-file-archive-o"></i>Chi tiết hồ sơ</a></li>
                            <%} %>
                        </ul>
                    </li>
                    <%} %>
                    <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Bieumau))
                      { %>
                    <li><a title="" href="/Pagess/bieu-mau.aspx">Biểu mẫu</a></li>
                    <%} %>
                    <li><a title="" href="/Pagess/lich-ca-nhan.aspx">Lịch cá nhân</a></li>
                    <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Thongkebaocao))
                      { %>
                    <li>
                        <a title="" href="#">Báo cáo thống kê<span class="arrow"></span>
                        </a>
                        <ul class="sub-menu">
                            <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Thongkebaocaovanbanden))
                              { %>
                            <li><a title="" href="/Pagess/van-ban-den.aspx"><i class="fa fa-book"></i>Văn bản đến<span class="arrow"></span></a>
                                <ul class="sub-menu">
                                    <li><a title="" href="/Pagess/thong-ke-van-ban-den-ban-lanh-dao.aspx"><i class="fa fa-list-alt"></i>Báo cáo tình hình xử lý</a>
                                    </li>

                                </ul>
                            </li>
                            <%} %>
                            <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Thongkebaocaovanbandi))
                              { %>
                            <li><a title="" href="/Pagess/van-ban-di.aspx"><i class="fa fa-book"></i>Văn bản đi<span class="arrow"></span></a>
                                <ul class="sub-menu">
                                    <li><a title="" href="/Pagess/thong-ke-van-ban-di.aspx"><i class="fa fa-list-alt"></i>Thống kê văn bản đi</a></li>
                                    <li><a title="" href="/Pagess/thong-ke-van-ban-di-tong-hop.aspx"><i class="fa fa-list-alt"></i>Thống kê tổng hợp văn bản đi</a></li>
                                </ul>
                            </li>
                            <%} %>
                        </ul>
                    </li>
                    <%} %>

                    <%--BEGIN Quản lý--%>

                    <!--END Quản lý-->
                </ul>
            </li>

            <!-- BEGIN LUU TRỮ -->
            <%--<%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Luutru))
              {%>--%>
            <li class="active open" style="display: none">
                <a href="#">
                    <i class="fa fa-bar-chart icon-root"></i>
                    <span class="title">QUẢN LÝ LƯU TRỮ</span>
                </a>
                <ul class="sub-menu">
                    <!-- BEGIN THU THẬP TÀI LIỆU-->
                    <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Kehoachthuthap) || CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Kehoachnopluu))
                      {%>
                    <li>
                        <a title="" href="#">Thu thập tài liệu<span class="arrow"></span></a>
                        <ul class="sub-menu">
                            <!--ĐƠN VỊ LƯU TRỮ-->
                            <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Kehoachthuthap))
                              {%>
                            <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Kehoachthuthap))
                              {%>
                            <li><a title="Quản lý kế hoạch thu thập" href="/Pagess/ke-hoach-thu-thap.aspx"><i class="fa fa-folder-open"></i>Quản lý kế hoạch thu thập</a></li>
                            <%if (ItemID > 0)
                              {%>
                            <li><a title="Chi tiết kế hoạch thu thập" href="/Pagess/quan-ly-don-vi-nop-luu.aspx"><i class="fa fa-folder-open"></i>Chi tiết kế hoạch thu thập</a></li>
                            <%} %>
                            <%} %>
                            <%} %>
                            <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Tiepnhantailieu))
                              {%>
                            <li><a href="/Pagess/tiep-nhan-ho-so-nop-luu.aspx" title="Tiếp nhận hồ sơ tài liệu nộp lưu"><i class="fa fa-warning"></i>Tiếp nhận hồ sơ tài liệu nộp lưu</a></li>
                            <%} %>
                            <!--END ĐƠN VỊ LƯU TRỮ-->

                            <!--ĐƠN VỊ NỘP LƯU-->
                            <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Muclucnopluu))
                              {%>
                            <li><a href="/Pagess/ke-hoach-nop-luu-don-vi.aspx" title="Quản lý kế hoạch nộp lưu"><i class="fa fa-th-list"></i>Kế hoạch nộp lưu</a></li>

                            <%if (!string.IsNullOrEmpty(HoSoLuuTruID))
                              {%>
                            <li><a href="/Pagess/van-ban-nop-luu.aspx?HoSoLuuTruID=<%=HoSoLuuTruID %>" title="Danh sách hồ sơ"><i class="fa fa-th-list"></i>Danh sách văn bản</a></li>
                            <%}
                              else if (!string.IsNullOrEmpty(IDMucLucNopLuu))
                              {%>
                            <li><a href="/Pagess/ho-so-nop-luu.aspx?KeHoachID=<%=KeHoachID %>&IDMucLucNopLuu=<%=IDMucLucNopLuu %>" title="Danh sách hồ sơ"><i class="fa fa-th-list"></i>Danh sách hồ sơ</a></li>
                            <%}
                              else if (!string.IsNullOrEmpty(KeHoachID))
                              {%>
                            <li><a href="/Pagess/muc-luc-nop-luu.aspx" title="Quản lý mục lục nộp lưu"><i class="fa fa-th-list"></i>Mục lục nộp lưu</a></li>
                            <%} %>
                            <%} %>
                            <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Tiepnhanhosophongban))
                              {%>
                            <li><a title="Danh sách hồ sơ phòng ban chờ tiếp nhận" href="/Pagess/tiep-nhan-ho-so-phong-ban.aspx"><i class="fa fa-th-list"></i>Tiếp nhận hồ sơ phòng ban</a></li>
                            <%} %>
                            <!--END ĐƠN VỊ NỘP LƯU-->

                            <!--CHUYÊN VIÊN-->
                            <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Hosonopluuphongban))
                              {%>
                            <li><a title="Quản lý tài liệu nộp lưu phòng ban" href="/Pagess/tai-lieu-nop-luu-phong-ban.aspx"><i class="fa fa-th-list"></i>Tài liệu nộp lưu phòng ban</a></li>
                            <%if (CurrentUser.ViTriID == (int)Viags.Utils.Enum.TypeOfRole.LanhDaoPhongBan || CurrentUser.ViTriID == (int)Viags.Utils.Enum.TypeOfRole.LanhDaoDonVi || CurrentUser.ViTriID == (int)Viags.Utils.Enum.TypeOfRole.LanhDaoHanhChinh || CurrentUser.ViTriID == (int)Viags.Utils.Enum.TypeOfRole.LanhDaoVanPhong)
                              {%>
                            <li><a title="Danh sách hồ sơ tài liệu chờ duyệt" href="/Pagess/tai-lieu-nop-luu-phong-ban.aspx?app=choduyet"><i class="fa fa-th-list"></i>Tài liệu chờ duyệt</a></li>
                            <%} %>
                            <%} %>
                            <!--END CHUYÊN VIÊN-->
                        </ul>
                    </li>
                    <%} %>
                    <!-- END THU THẬP TÀI LIỆU-->

                    <!-- BEGIN BIEN MUC-->
                    <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Bienmucchinhly))
                      {%>
                    <li>
                        <a title="" href="#">Chỉnh lý tài liệu<span class="arrow"></span></a>
                        <ul class="sub-menu">
                            <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Bienmuctailieu))
                              {%>
                            <li><a href="/Pagess/bien-muc-tai-lieu.aspx" title="Tài liệu chờ chỉnh lý"><i class="fa fa-warning"></i>Tài liệu chờ biên mục</a></li>
                            <%} %>
                        </ul>
                    </li>
                    <%} %>

                    <!--TÀI LIỆU LƯU TRỮ-->
                    <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Bienmucchinhly))
                      {%>
                    <li>
                        <a title="" href="#">Tài liệu lưu trữ<span class="arrow"></span></a>
                        <ul class="sub-menu">
                            <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Xephopcap))
                              {%><li><a title="Sắp xếp hộp cặp" href="/Pagess/xep-tai-lieu-hop-cap.aspx"><i class="fa fa-briefcase"></i>Xếp tài liệu hộp cặp</a></li>
                            <%} %>
                            <li><a title="Tài liệu lưu trữ" href="/Pagess/phong-luu-tru.aspx"><i class="fa fa-database"></i>Tài liệu lưu trữ</a></li>
                            <!--KIỂM KÊ TÀI LIỆU-->
                            <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Kykiemke))
                              {%>
                            <li>
                                <a title="" href="#">Kiểm kê tài liệu<span class="arrow"></span></a>
                                <ul class="sub-menu">
                                    <li><a title="" href="/Pagess/kho-luu-tru.aspx?VanBanDenID=1"><i class="fa fa-university"></i>Đóng/ mở kho</a></li>
                                    <li><a title="" href="/Pagess/ky-kiem-ke-luu-tru.aspx"><i class="fa fa-calendar"></i>Kỳ kiểm kê</a></li>
                                    <li><a title="" href="/Pagess/ket-qua-ky-kiem-ke.aspx"><i class="fa fa-bar-chart-o"></i>Kết quả kiểm kê</a></li>
                                </ul>
                            </li>
                            <%} %>
                            <!--END KIỂM KÊ TÀI LIỆU-->
                        </ul>
                    </li>
                    <%} %>

                    <!--KHAI THÁC TÀI LIỆU-->
                    <li>
                        <a title="" href="#">Khai thác, sử dụng tài liệu<span class="arrow"></span></a>
                        <ul class="sub-menu">
                            <li><a title="" href="/Pagess/khai-thac-truc-tuyen.aspx"><i class="fa fa-legal"></i>Khai thác trực tuyến</a></li>
                            <% if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Danhsachyeucaukhaithac))
                               { %>
                            <li><a title="" href="/Pagess/danh-sach-yeu-cau-cha.aspx"><i class="fa fa-tasks"></i>Danh sách yêu cầu</a></li>
                            <%} %>
                            <li><a title="" href="/Pagess/danh-sach-muon-tra-luu-tru.aspx"><i class="fa fa-tasks"></i>Danh sách mượn trả</a></li>
                            <% if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Ghimuontailieu))
                               { %>
                            <li><a title="Mượn trả" href="#"><i class="fa fa-th-list"></i>Mượn trả<span class="arrow"></span></a>
                                <ul class="sub-menu">
                                    <% if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Ghimuontailieu))
                                       { %>
                                    <li><a title="Thực hiện ghi mượn tài liệu cho cán bộ" href="/Pagess/ghi-muon-tai-lieu-luu-tru.aspx"><i class="fa fa-sign-in"></i>Ghi mượn tài liệu</a></li>
                                    <%} %>
                                    <% if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Ghitratailieu))
                                       { %>
                                    <li><a title="Thực hiện ghi trả tài liệu cho cán bộ" href="/Pagess/ghi-tra-tai-lieu-luu-tru.aspx"><i class="fa fa-sign-out"></i>Ghi trả tài liệu</a></li>
                                    <%} %>
                                </ul>
                            </li>
                            <%} %>
                            <% if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Danhsachmuontraquahan))
                               { %>
                            <li><a title="" href="/Pagess/danh-sach-muon-tra-qua-han.aspx"><i class="fa fa-exclamation-triangle"></i>Danh sách quá hạn</a></li>
                            <%} %>
                            <% if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Danhsachmuontragiahan))
                               { %>
                            <li><a title="" href="/Pagess/danh-sach-muon-tra-gia-han.aspx"><i class="fa fa-retweet"></i>Danh sách gia hạn</a></li>
                            <%} %>
                            <% if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Ghimuontailieu))
                               {%>
                            <li><a title="" href="/Pagess/bao-cao-khai-thac.aspx"><i class="fa fa-bar-chart-o"></i>Báo cáo thống kê</a></li>
                            <%} %>
                        </ul>
                    </li>
                    <!--END KHAI THÁC TÀI LIỆU-->

                    <!--ĐỢT NỘP LƯU TTLTQG-->
                    <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.NoptailieuTTLTQG))
                      {%>
                    <li><a title="" href="#">Nộp tài liệu về TTLTQG<span class="arrow"></span></a>
                        <ul class="sub-menu">
                            <li><a title="" href="/Pagess/dot-nop-tai-lieu-luu-tru.aspx"><i class="fa fa-newspaper-o"></i>Đợt giao nộp</a></li>
                        </ul>
                    </li>
                    <%} %>
                    <!--END ĐỢT NỘP LƯU TTLTQG-->

                    <!--TIÊU HỦY TÀI LIỆU-->
                    <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Tieuhuytailieu))
                      {%>
                    <li><a title="" href="#">Tiêu hủy tài liệu<span class="arrow"></span></a>
                        <ul class="sub-menu">
                            <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Themmoiquyetdinhtieuhuy))
                              {%>
                            <!--Đợt tiêu hủy-->
                            <li><a title="Đợt tiêu hủy tài liệu" href="<%=Viags.Utils.LinkModule.DotTieuHuyTaiLieu %>"><i class="fa fa-fire"></i>Đợt tiêu hủy</a></li>
                            <%if (ItemID > 0)
                              {%>
                            <li><a title="Đợt tiêu hủy tài liệu" href="<%=Viags.Utils.LinkModule.ChiTietDotTieuHuyTaiLieu %>?ItemID=<%=ItemID %>"><i class="fa fa-fire"></i>Danh sách đơn vị</a></li>
                            <%} %>
                            <!--Quyết định tiêu hủy-->
                            <li><a title="Quyết định hủy tài liệu" href="<%=Viags.Utils.LinkModule.QuyetDinhTieuHuy %>"><i class="fa fa-fire"></i>Quyết định hủy tài liệu</a></li>
                            <%if (ItemID > 0)
                              {%>
                            <li><a title="DANH SÁCH HỒ SƠ TRONG QUYẾT ĐỊNH TIÊU HỦY" href="<%=Viags.Utils.LinkModule.ChiTietQuyetDinhTieuHuy %>?ItemID=<%=ItemID %>"><i class="fa fa-th-list"></i>Danh sách hồ sơ tiêu hủy</a></li>
                            <%} %>
                            <!--Hồ sơ hết giá trị-->
                            <li><a title="Tài liệu đã tiêu hủy" href="<%=Viags.Utils.LinkModule.HoSoHetGiaTri %>"><i class="fa fa-clock-o"></i>Tài liệu đã tiêu hủy</a></li>
                            <%}
                              else
                              {%>
                            <!--Đợt tiêu hủy-->
                            <li><a title="Đợt tiêu hủy tài liệu" href="<%=Viags.Utils.LinkModule.TieuHuyTaiLieuDonViNopLuu %>"><i class="fa fa-fire"></i>Đợt tiêu hủy</a></li>
                            <%if (ItemID > 0)
                              {%>
                            <li><a title="Đợt tiêu hủy tài liệu" href="<%=Viags.Utils.LinkModule.ChiTietDotTieuHuyDonViNopLuu %>?ItemID=<%=ItemID %>"><i class="fa fa-fire"></i>Danh sách đơn vị</a></li>
                            <%} %>
                            <!--Hồ sơ hết giá trị-->
                            <li><a title="Tài liệu đã tiêu hủy" href="<%=Viags.Utils.LinkModule.HoSoHetGiaTriDonVi %>"><i class="fa fa-clock-o"></i>Tài liệu đã tiêu hủy</a></li>
                            <%} %>
                        </ul>
                    </li>
                    <%} %>
                    <!--END TIÊU HỦY TÀI LIỆU-->

                    <!-- BEGIN DANH MUC-->
                    <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Danhmucluutru))
                      {%>
                    <li>
                        <a title="" href="#">Quản lý kho và tài liệu<span class="arrow"></span></a>
                        <ul class="sub-menu">
                            <% if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Kholuutru))
                               { %>
                            <li><a title="Kho lưu trữ" href="/Pagess/kho-luu-tru.aspx"><i class="fa fa-folder-open"></i>Kho lưu trữ</a></li>
                            <%} %>
                        </ul>
                    </li>
                    <%} %>
                    <!-- END DANH MUC-->
                    <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Baocaothongkecoso))
                      {%>
                    <li><a title="Báo cáo thống kê" href="#">Báo cáo thống kê<span class="arrow"></span></a>
                        <ul class="sub-menu">
                            <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Baocaothongkecosocuavanphong))
                              {%>
                            <li><a title="" href="/Pagess/bao-cao-co-so-van-phong-nhan.aspx"><i class="fa fa-bar-chart-o"></i>Báo cáo thống kê cơ sơ</a></li>
                            <%} %>
                            <%-- <li><a title="" href="/Pagess/nhap-lieu-bao-cao-co-so.aspx"><i class="fa fa-briefcase"></i>Nhập báo cáo</a></li>--%>
                            <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Baocaothongkecosocuadonvi))
                              { %>
                            <li><a title="" href="/Pagess/thong-ke-co-so-don-vi.aspx"><i class="fa fa-print"></i>Thống kê cơ sở của đơn vị</a></li>
                            <%} %>
                        </ul>
                    </li>
                    <%} %>
                </ul>
            </li>
            <%--            <%} %>--%>
            <!-- END LUU THONG-->
            <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Hethong))
              {%>
            <li class="active open">
                <a href="#">
                    <i class="fa fa-gears"></i>
                    <span class="title">QUẢN TRỊ HỆ THỐNG
                    </span>
                </a>
                <ul class="sub-menu">
                    <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Danhmuc))
                      {%>
                    <li>
                        <a href="#">Danh mục<span class="arrow"></span></a>
                        <ul class="sub-menu">
                            <li style="display: none"><a title="Nhóm danh mục" href="/Pagess/nhom-danh-muc.aspx"><i class="fa fa-clipboard"></i>Nhóm danh mục</a></li>
                            <li><a title="Danh mục" href="/Pagess/ten-danh-muc.aspx"><i class="fa fa-list-alt"></i>Danh mục</a></li>

                            <li><a title="Nơi nhận" href="/Pagess/noi-nhan.aspx"><i class="fa fa-building"></i>Cơ quan gửi, nhận</a></li>
                            <li><a title="Loại văn bản" href="/Pagess/loai-van-ban.aspx"><i class="fa fa-file-text-o"></i>Loại văn bản</a></li>

                            <li><a title="Sổ văn bản" href="/Pagess/so-van-ban.aspx"><i class="fa fa-book"></i>Sổ văn bản</a></li>

                        </ul>
                    </li>
                    <%} %>

                    <li>
                        <a href="#">Tài khoản<span class="arrow"></span></a>
                        <ul class="sub-menu">
                            <li style="display: none"><a title="" href="/Pagess/quyen-han.aspx"><i class="fa fa-gavel"></i>Quyền hạn hệ thống</a></li>
                            <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Vaitro))
                              {%>
                            <li><a title="" href="/Pagess/vai-tro-he-thong.aspx"><i class="fa fa-warning"></i>Vai trò hệ thống</a></li>
                            <%} %>
                            <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Chucvu))
                              {%>
                            <li><a title="" href="/Pagess/nhom-nguoi-dung.aspx"><i class="fa fa-sitemap"></i>Chức danh</a></li>
                            <%} %>
                            <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Nhomnguoidung))
                              {%>
                            <li><a title="" href="/Pagess/nhom-ca-nhan.aspx"><i class="fa fa-group"></i>Nhóm người dùng</a></li>
                            <%} %>

                            <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Nguoidung))
                              {%>
                            <li><a title="" href="/Pagess/nguoi-dung.aspx"><i class="fa fa-user"></i>Người dùng</a></li>
                            <%} %>
                        </ul>
                    </li>
                    <li>
                        <a href="#">Cơ cấu tổ chức<span class="arrow"></span></a>
                        <ul class="sub-menu">
                            <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Donvi))
                              {%>
                            <li><a title="" href="/Pagess/don-vi.aspx"><i class="fa fa-sitemap"></i>Đơn vị, phòng ban</a></li>
                            <%} %>
                            <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Nhomdonvi))
                              {%>
                            <li style="display: none"><a title="" href="/Pagess/nhom-don-vi.aspx"><i class="fa fa-object-group"></i>Nhóm đơn vị phòng ban</a></li>
                            <%} %>
                        </ul>
                    </li>

                    <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.CauhinhModule))
                      {%>
                    <li>
                        <a href="#">Cấu hình hệ thống<span class="arrow"></span></a>
                        <ul class="sub-menu">
                            <li><a title="" href="/Pagess/cau-hinh-sms-email.aspx"><i class="fa fa-wrench"></i>Cấu hình sms, email</a></li>
                            <li style="display: none"><a title="" href="/HeThong/CauHinhDuLieu/danhsach.aspx"><i class="fa fa-wrench"></i>Cấu hình số bản ghi</a></li>
                            <li style="display: none"><a title="" href="/Pagess/cau-hinh-module.aspx"><i class="fa fa-wrench"></i>Cấu hình hiển thị module</a></li>
                        </ul>
                    </li>
                    <%} %>
                    <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Loghethong))
                      {%>
                    <li><a title="" href="/Pagess/log.aspx">Log hệ thống</a></li>
                    <%} %>
                </ul>
            </li>
            <%} %>
            <!-- END LƯU TRỮ -->
        </ul>
        <!-- END SIDEBAR MENU -->
    </div>
    <script type="text/javascript">
        $(document).ready(function () {
            <%if (CurrentUser.ID == 0 || CurrentUser == null)
              {%>
            window.location.href = "/LoginF.aspx";
            <%}%>
            MenuAction();
            //setTimeout(function () {
            //    LoadMenuLeft();
            //}, 2000);
            $(".sub-menu li a").bind("click", function () {
                $(this).parent().parent().children().removeClass("active").removeClass("open");
                MenuAction();
            });

            //function LoadMenuLeft() {
            //    $.ajax({
            //        type: "POST",
            //        url: '/API/pLoadMenuLeftStore.asmx/GetData',

            //        contentType: "application/json; charset=utf-8",
            //        dataType: "json",
            //        success: function (data) {
            //            $.each(data.d, function (i, value) {
            //                $(value.id).html(value.text);
            //            });
            //        }
            //    });
            //}
            function MenuAction() {
                var currentUrl = location.pathname.toLowerCase();
                if (currentUrl != "") {
                    var Urllink = window.location.href;
                    var index = Urllink.lastIndexOf("#");
                    if (parseInt(index) > 0) {
                        Urllink = Urllink.substring(index + 1).toLowerCase();
                    }
                    $("ul.page-sidebar-menu li a").each(function () {
                        var href = $(this).attr("href");
                        var linkCheck = href == null ? "" : href.toLowerCase();
                        if (linkCheck.indexOf(currentUrl) > -1) {
                            //Cấp 1
                            if (parseInt(index) > 0) {
                                if (linkCheck.indexOf(Urllink) > -1) {
                                    $(this).parent("li").addClass("active").addClass("open");
                                    $(this).parent("li").addClass("active").find("a span.arrow").addClass("open");
                                    //Cấp 2
                                    $(this).parent("li").parent().parent().addClass("active").addClass("open");
                                    $(this).parent("li").parent().parent().find("a span.arrow").addClass("open");
                                    //Cấp 3
                                    $(this).parent("li").parent().parent().parent().parent().addClass("active").addClass("open");
                                    $(this).parent("li").parent().parent().parent().parent().find("a span.arrow").addClass("open");
                                    // Cấp 4
                                    $(this).parent("li").parent().parent().parent().parent().parent().addClass("active").addClass("open");
                                    $(this).parent("li").parent().parent().parent().parent().parent().find("a span.arrow").addClass("open");
                                    // cấp 5
                                    $(this).parent("li").parent().parent().parent().parent().parent().parent().addClass("active").addClass("open");
                                    $(this).parent("li").parent().parent().parent().parent().parent().parent().find("a span.arrow").addClass("open");
                                    //  return false;
                                }
                            }
                            else {
                                $(this).parent("li").addClass("active").addClass("open");
                                $(this).parent("li").addClass("active").find("a span.arrow").addClass("open");

                                //Cấp 2
                                $(this).parent("li").parent().parent().addClass("active").addClass("open");
                                $(this).parent("li").parent().parent().find("a span.arrow").addClass("open");
                                //Cấp 3
                                $(this).parent("li").parent().parent().parent().parent().addClass("active").addClass("open");
                                $(this).parent("li").parent().parent().parent().parent().find("a span.arrow").addClass("open");
                                // Cấp 4
                                $(this).parent("li").parent().parent().parent().parent().parent().addClass("active").addClass("open");
                                $(this).parent("li").parent().parent().parent().parent().parent().find("a span.arrow").addClass("open");
                                // cấp 5
                                $(this).parent("li").parent().parent().parent().parent().parent().parent().addClass("active").addClass("open");
                                $(this).parent("li").parent().parent().parent().parent().parent().parent().find("a span.arrow").addClass("open");

                            }

                        }
                    });
                }
            }
        });
    </script>
</div>
