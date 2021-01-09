<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucMenuLeftNewEnglish.ascx.cs" Inherits="Viags.WebApp.Common.ucMenuLeftNewEnglish" %>
<div class="page-sidebar-wrapper">
    <%string path = HttpContext.Current.Request.Url.AbsolutePath; %>

    <div class="page-sidebar navbar-collapse collapse" >
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
                    <i class="fa fa-laptop icon-root"></i>
                    <span class="title"><%=Resources.Common.lblTieuDeQuanLy %></span>
                </a>
                <ul class="sub-menu">
                    <!--<li>
                        <a title="Trang chủ" href="/home.aspx">Trang chủ</a>
                    </li>-->
                    <!--BEGIN VĂN BẢN ĐẾN-->
                    <% if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Vanbanden))
                       { %>
                    <li>
                        <a title="" href="#"><i class="fas fa-file-import"></i> <%=Resources.Common.lblVanBanDen %><span class="arrow"></span>
                        </a>
                        <ul class="sub-menu">
                            <%if (CurrentUser.ViTriID == (int)Viags.Utils.Enum.TypeOfRole.VanThuDonVi)
                              { %>
                            <% if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Themmoivanbanden))
                               { %>
                            <li><a title="" href="/Pagess/form-van-ban-den.aspx"><i class="icon-plus"></i><%=Resources.Common.lblThemMoiVanBan %></a></li>
                            <%} %>
                            <li>
                                <a title="" href="/Pagess/van-ban-den-cho-vao-so.aspx"><i class="fa fa-book "></i><%=Resources.Common.lblVanBanDenMoi %> <b id="idvanbanchovaoso"></b></a>
                            </li>
                            <li><a title="" href="/Pagess/van-ban-den.aspx"><i class="fa fa-book "></i><%=Resources.Common.lblDanhSachVanBan %></a>
                                <ul class="sub-menu">
                                    <%  
                                        HttpCookie cookie = Request.Cookies["ngonngu"];
                                        if (cookie != null && cookie.Value != null)
                                        {
                                            if (cookie.Value.ToString() == "en-US")
                                            {
                                    %>
                                                <%foreach (var item in LstSoVanBanDen.Where(p => p.IsDonVi == false).ToList())
                                                  { %>
                                                <li><a title="" href="/Pagess/van-ban-den.aspx#Field=ThuTu&SoVanBanID=<%:item.ID %>&Page=1&RowPerPage=10"><i class="fa fa-list-alt"></i><%:item.TenEnglish %></a>
                                                </li>
                                                <%} %>
                                    <%
                                            }
                                            else
                                            {
                                                if (cookie.Value.ToString() == "vi-VN")
                                                {
                                    %>
                                                    <%foreach (var item in LstSoVanBanDen.Where(p => p.IsDonVi == false).ToList())
                                                      { %>
                                                    <li><a title="" href="/Pagess/van-ban-den.aspx#Field=ThuTu&SoVanBanID=<%:item.ID %>&Page=1&RowPerPage=10"><i class="fa fa-list-alt"></i><%:item.Ten %></a>
                                                    </li>
                                                    <%} %>
                                    <%                                
                                                }
                                            }
                                        }
                                        else
                                        {
                                    %>
                                            <%foreach (var item in LstSoVanBanDen.Where(p => p.IsDonVi == false).ToList())
                                              { %>
                                            <li><a title="" href="/Pagess/van-ban-den.aspx#Field=ThuTu&SoVanBanID=<%:item.ID %>&Page=1&RowPerPage=10"><i class="fa fa-list-alt"></i><%:item.Ten %></a>
                                            </li>
                                            <%} %>
                                    <%
                                        }
                                    %>
                                </ul>
                            </li>
                            <%}else{ %>
                            <li><a title="" href="/Pagess/van-ban-den.aspx"><i class="fa fa-book "></i><%=Resources.Common.lblDanhSachVanBan %></a></li>
                            <%} %>
                            <%if (path.ToLower() == "/pagess/chi-tiet-van-ban-den.aspx")
                              {%>
                            <li><a title="" href="/pagess/chi-tiet-van-ban-den.aspx?ItemID=<%=ItemID%>&do=view"><i class="fa fa-book"></i><%=Resources.Common.lblChiTietVanBan %></a></li>
                            <%} %>
                            <li><a title="" href="/Pagess/van-ban-den-chua-xu-ly.aspx"><i class="fa fa-book "></i><%=Resources.Common.lblVanBanChuaXuLy %></a></li>
                            <li><a title="" href="/Pagess/van-ban-den-dang-xu-ly.aspx"><i class="fa fa-book "></i><%=Resources.Common.lblVanBanDangXuLy %></a></li>
                            <li><a title="" href="/Pagess/van-ban-den-da-xu-ly.aspx"><i class="fa fa-book "></i><%=Resources.Common.lblVanBanDaXuLy %></a></li>
                            <% if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Insovanbanden))
                               { %>
                            <li><a title="" href="/Pagess/in-so-van-ban-den.aspx#NgayDenDau=<%:DateTime.Now.ToString("dd/MM/yyyy") %>&InSo=1"><i class="fa fa-print"></i><%=Resources.Common.lblInSoVanBan %></a></li>
                            <%} %>
                        </ul>
                    </li>
                    <%} %>

                    <!--END VĂN BẢN ĐẾN-->

                    <!--BEGIN VĂN BẢN ĐI-->
                    <% if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Vanbandi))
                       { %>
                    <li>
                        <a title="" href="#"><i class="fas fa-file-export"></i> <%=Resources.Common.lblVanBanDi %><span class="arrow"></span>
                        </a>
                        <ul class="sub-menu">
                            <%--<%if (CurrentUser.ViTriID == (int)Viags.Utils.Enum.TypeOfRole.VanThuDonVi)
                              { %>--%>

                            <% if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Themmoivanbandi))
                               {%>
                            <li><a title="" href="/Pagess/form-van-ban-di.aspx"><i class="icon-plus"></i><%=Resources.Common.lblThemMoiVanBan %></a></li>
                            <%}%>
                            <li><a title="" href="/Pagess/van-ban-di.aspx"><i class="fa fa-list-alt"></i><%=Resources.Common.lblDanhSach %><b id="idvanbandithuong"></b></a>
                                <ul class="sub-menu">
                                    <%foreach (var item in LstSoVanBan)
                                        { %>
                                            <li><a title="" href="/Pagess/van-ban-di.aspx#SoVanBanID=<%:item.ID %>&Field=ThuTuSearch&Page=1&RowPerPage=10"><i class="fa fa-list-alt"></i><%:item.TenEnglish %></a></li>                                
                                    <%} %>
                                </ul>
                            </li>
                            <%if (CurrentUser.ViTriID == (int)Viags.Utils.Enum.TypeOfRole.VanThuDonVi)
                              { %>
                            <li><a title="" href="/Pagess/van-ban-cho-vao-so.aspx"><i class="fa fa-book "></i>Waiting list for classifying  <b id="idvanbanduthaochovaoso"></b></a></li>
                            <%} %>   
                            <li><a title="" href="/Pagess/van-ban-di.aspx#LoaiID=1"><i class="fa fa-list-alt"></i><%=Resources.Common.lblVanBanPhatHanh %></a></li>
                            <li><a title="" href="/Pagess/van-ban-di.aspx#LoaiID=2"><i class="fa fa-list-alt"></i><%=Resources.Common.lblVanBanChuaPhatHanh %></a></li>
                            <li><a title="" href="/Pagess/in-so-van-ban-di.aspx#ThoiGianBatDau=<%:DateTime.Now.ToString("dd/MM/yyyy") %>&InSo=1"><i class="fa fa-book"></i><%=Resources.Common.lblInSo %></a></li>
                            <% if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Insovanbandi))
                               { %>

                            <%} %>
                        </ul>
                    </li>
                    <%} %>
                    <!--END VĂN BẢN ĐI-->

                    <!--BEGIN TỜ TRÌNH-->
                    <% if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Vanbanduthao))
                       { %>
                    <li>
                        <a title="" href="#"><i class="fas fa-file-contract"></i> <%=Resources.Common.lblVanBanDuThao %><span class="arrow"></span>
                        </a>
                        <ul class="sub-menu">
                            <% if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Themmoivanbanduthao))
                               { %>
                            <li><a title="" href="/Pagess/form-van-ban-du-thao.aspx"><i class="icon-plus"></i><%=Resources.Common.lblThemMoiVanBan %></a></li>
                            <%} %>
                            <%if (path.ToLower() == "/pagess/chi-tiet-van-ban-du-thao.aspx")
                              {%>
                            <li><a title="" href="/Pagess/chi-tiet-van-ban-du-thao.aspx?do=view&ItemID=<%=ItemID %>"><i class="fa fa-book"></i><%=Resources.Common.lblChiTietVanBan %></a>
                                <%} %>
                            <li><a title="" href="/Pagess/van-ban-du-thao.aspx"><i class="fa fa-book"></i><%=Resources.Common.lblDanhSachVanBan %></a></li>
                            <li><a title="" href="/Pagess/van-ban-du-thao-chua-xu-ly.aspx"><i class="fa fa-book"></i><%=Resources.Common.lblChuaXuLy %></a></li>
                            <li><a title="" href="/Pagess/van-ban-du-thao-dang-xu-ly.aspx"><i class="fa fa-book"></i><%=Resources.Common.lblDangXuLy %></a></li>
                            <li><a title="" href="/Pagess/van-ban-du-thao-da-xu-ly.aspx"><i class="fa fa-book"></i><%=Resources.Common.lblDaXuLy %></a></li>
                        </ul>
                    </li>
                    <%} %>
                    <!--END TỜ TRÌNH-->

                    <!-- Dieu Hanh-->


                    <!-- Dieu Hanh-->
                    <!--BEGIN CÔNG VIỆC-->
                    <% if (!CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.QuantrihethongAdmin))
                       {%>
                    <li>
                        <a title="" href="#"><i class="fas fa-balance-scale"></i> <%=Resources.Common.lblDieuHanh %><span class="arrow"></span>
                        </a>
                        <ul class="sub-menu">
                            <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Congviec))
                              { %>
                            <li>
                                <a title="" href="#"><i class="fa fa-briefcase"></i><%=Resources.Common.lblQuanLyCongViec %><span class="arrow"></span></a>
                                <ul class="sub-menu">
                                    <li><a title="" href="/Pagess/form-ho-so-cong-viec.aspx"><i class="icon-plus"></i><%=Resources.Common.lblThemMoiCongViec %></a></li>

                                    <li><a title="" href="/Pagess/cong-viec.aspx"><i class="fa fa-book"></i><%=Resources.Common.lblDanhSachCongViec %></a></li>
                                    <%if (path.ToLower() == "/pagess/chi-tiet-cong-viec.aspx")
                                      {%>
                                    <li><a title="" href="/Pagess/chi-tiet-cong-viec.aspx?do=view&ItemID=<%=ItemID %>"><i class="fa fa-book"></i><%=Resources.Common.lblChiTietCongViec %></a>
                                        <%} %>
                                    <li><a title="" href="/Pagess/cong-viec-chua-xu-ly.aspx"><i class="fa fa-book"></i><%=Resources.Common.lblCongViecChuaXuLy %> <b id="idcongviecchuaxuly"></b></a></li>
                                    <li><a title="" href="/Pagess/cong-viec-dang-xu-ly.aspx"><i class="fa fa-book"></i><%=Resources.Common.lblCongViecDangXuLy %> <b id="idcongviecdangkxuly"></b></a></li>
                                    <li><a title="" href="/Pagess/cong-viec-da-xu-ly.aspx"><i class="fa fa-book"></i><%=Resources.Common.lblCongViecDaXuLy %></a></li>
                                     <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Tonghopcongviec))
                                    { %>
                                    <li><a title="" href="/Pagess/tong-hop-cong-viec.aspx"><i class="fa fa-bar-chart-o"></i><%=Resources.Common.lblTongHopCongViec %></a></li>
                                     <%} %>
                                    <li style="display: none"><a title="" href="/Pagess/bao-cao-cong-viec.aspx"><i class="fa fa-bar-chart-o"></i><%=Resources.Common.lblBaoCaoCongViec %></a></li>
                                </ul>
                            </li>
                            <%} %>
                            <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Baocaocongviec))
                              { %>
                            <li>
                                <a title="" href="#"><i class="fa fa-briefcase"></i><%=Resources.Common.lblQuanLyBaoCaoCongViec %><span class="arrow"></span></a>
                                <ul class="sub-menu">
                                    <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Cauhinhthoigianbaocao))
                                      { %>
                                    <li><a title="" href="/BaoCaoCongViec/CauHinhThoiGianBaoCao/Default.aspx"><i class="icon-plus"></i><%=Resources.Common.lblThietDatThoiGianBaoCao %></a></li>
                                    <%} %>
                                    <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Cauhinhthoigianbaocao))
                                      { %>
                                    <li><a title="" href="/BaoCaoCongViec/CauHinhThoiGianKhongBaoCao/Default.aspx"><i class="icon-plus"></i><%=Resources.Common.lblThietDatThoiGianKhongBC %></a></li>
                                    <%} %>
                                    <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Baocaocongviec))
                                      { %>
                                    <li><a title="" href="/BaoCaoCongViec/BaoCaoCuaDonVi/Default.aspx"><i class="icon-plus"></i><%=Resources.Common.lblBaoCaoCongViec %></a></li>
                                    <%} %>
                                    <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Nhanbaocaotudonvi))
                                      { %>
                                    <li><a title="" href="/BaoCaoCongViec/TongHopBaoCao/Default.aspx"><i class="icon-plus"></i><%=Resources.Common.lblTongHopBaoCao %></a></li>
                                    <%} %>
                                </ul>
                            </li>
                            <%} %>
                            <li><a title="" href="/Pagess/ban-giao-cong-viec.aspx"><i class="fa fa-legal"></i><%=Resources.Common.lblBanGiaoCongViec %></a></li>
                            <%if (CurrentUser != null && (CurrentUser.ViTriID == (int)Viags.Utils.Enum.TypeOfRole.LanhDaoPhongBan || CurrentUser.ViTriID == (int)Viags.Utils.Enum.TypeOfRole.LanhDaoHanhChinh || CurrentUser.ViTriID == (int)Viags.Utils.Enum.TypeOfRole.LanhDaoVanPhong || CurrentUser.ViTriID == (int)Viags.Utils.Enum.TypeOfRole.LanhDaoDonVi || CurrentUser.ViTriID == (int)Viags.Utils.Enum.TypeOfRole.LanhDaoNHNN))
                              { %>
                            <li><a href="/Pagess/uy-quyen.aspx"><i class="icon-calendar"></i><%=Resources.Common.lblUyQuyen %></a></li>
                            <%} %>
                            <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Theodoiuyquyen))
                              { %>
                            <li><a title="Theo dõi ủy quyền" href="/Pagess/theo-doi-uy-quyen.aspx"><i class="fa fa-legal"></i><%=Resources.Common.lblTheoDoiUyQuyen %></a></li>
                            <%} %>

                            <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Thongbao))
                              { %>
                            <li><a title="" href="/Pagess/thong-bao.aspx"><i class="fa fa-book"></i><%=Resources.Common.lblThongBaoChung %></a></li>
                            <%} %>
                        </ul>
                    </li>
                    <%} %>
                    <li><a title="" href="#"><i class="fab fa-medapps"></i> <%=Resources.Common.lblTienIch %><span class="arrow"></span></a>
                        <ul class="sub-menu">
                            <%--<%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Lichlamviec))
                              { %>
                            <li><a title="" href="/Pagess/lich-lanh-dao.aspx"><i class="fa fa-calendar-o"></i>Lịch làm việc của BLĐ</a></li>
                            <%} %>--%>
                            <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Lichhopcongtactuan))
                              { %>
                            <li><a title="" href="/Pagess/lich-hop-cong-tac.aspx"><i class="fa fa-calendar-o"></i><%=Resources.Common.lblLichHopCongTac %></a></li>
                            <%} %>
                            <%--<li><a title="" href="/Pagess/lich-truc-ban-lanh-dao.aspx"><i class="fa fa-calendar-o"></i><%=Resources.Common.lblLichTrucBLD %></a></li>--%>
                            <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Datphonghop))
                              { %>
                            <li>
                                <a title="" href="#"><i class="fa fa-bank"></i><%=Resources.Common.lblQuanLyPhongHop %><span class="arrow"></span></a>
                                <ul class="sub-menu">
                                    <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Phonghop))
                                      {%>
                                    <li><a title="" href="/Pagess/danh-muc-phong-hop.aspx"><i class="fa fa-calendar"></i><%=Resources.Common.lblPhongHop %></a></li>
                                    <%}%>
                                    <li><a title="" href="/Pagess/thong-tin-dat-phong.aspx"><i class="fa fa-calendar"></i><%=Resources.Common.lblThongTinDatPhong %></a></li>
                                </ul>
                            </li>
                            <%} %>

                            <%--BEGIN Đặt xe--%>
                            <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Datphonghop))
                              { %>
                            <li>
                                <a title="" href="#"><i class="fa fa-bank"></i><%=Resources.DanhMucXe.lblQuanLyXe %><span class="arrow"></span></a>
                                <ul class="sub-menu">
                                    <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Phonghop))
                                      {%>
                                    <li><a title="" href="/Pagess/danh-muc-xe.aspx"><i class="fa fa-bus"></i><%=Resources.DanhMucXe.lblXe %></a></li>
                                    <%}%>
                                    <li><a title="" href="/Pagess/thong-tin-dat-xe.aspx"><i class="fa fa-bus"></i><%=Resources.DanhMucXe.lblThongTinDatXe %></a></li>
                                </ul>
                            </li>
                            <%} %>
                            <%--END Đặt xe--%>

                        </ul>
                    </li>
                    
                    <!--END THƯ VIỆN-->
                    <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Hosotailieu))
                      { %>
                    <li>
                        <a title="" href="#"><i class="fas fa-folder"></i> <%=Resources.Common.lblQuanLyHoSo %><span class="arrow"></span>
                        </a>
                        <ul class="sub-menu">

                            <li><a title="Danh sách hồ sơ" href="/Pagess/quan-ly-ho-so-tai-lieu.aspx"><i class="fa fa-file-archive-o"></i><%=Resources.Common.lblDanhSachHoSo %></a></li>
                            <%if (ItemID > 0)
                              {%>
                            <li><a title="Chi tiết hồ sơ" href="/Pagess/chi-tiet-ho-so-tai-lieu.aspx?ItemID=<%=ItemID %>"><i class="fa fa-file-archive-o"></i><%=Resources.Common.lblChiTietHoSo %></a></li>
                            <%} %>
                        </ul>
                    </li>
                    <%} %>
                    <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Bieumau))
                      { %>
                    <li><a title="" href="/Pagess/bieu-mau.aspx"><i class="far fa-file-alt"></i> <%=Resources.Common.lblBieuMau %></a></li>
                    <%} %>
                    <li><a title="" href="/Pagess/lich-ca-nhan.aspx"><i class="fas fa-calendar-alt"></i> <%=Resources.Common.lblLichCaNhan %></a></li>
                    <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Thongkebaocao))
                      { %>
                    <li>
                        <a title="" href="#"><i class="fas fa-chart-line"></i> <%=Resources.Common.lblBaoCaoThongKe %><span class="arrow"></span>
                        </a>
                        <ul class="sub-menu">
                            <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Thongkebaocaovanbanden))
                              { %>
                            <li><a title="" href="/Pagess/van-ban-den.aspx"><i class="fa fa-book"></i><%=Resources.Common.lblVanBanDen %><span class="arrow"></span></a>
                                <ul class="sub-menu">
                                    <li><a title="" href="/Pagess/thong-ke-van-ban-den-ban-lanh-dao.aspx"><i class="fa fa-list-alt"></i><%=Resources.Common.lblBaoCaoTinhHinhXuLy %></a>
                                    </li>

                                </ul>
                            </li>
                            <%} %>
                            <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Thongkebaocaovanbandi))
                              { %>
                            <li><a title="" href="/Pagess/van-ban-di.aspx"><i class="fa fa-book"></i><%=Resources.Common.lblVanBanDi %><span class="arrow"></span></a>
                                <ul class="sub-menu">
                                    <li><a title="" href="/Pagess/thong-ke-van-ban-di.aspx"><i class="fa fa-list-alt"></i><%=Resources.Common.lblThongKeVanBanDi %></a></li>
                                    <li><a title="" href="/Pagess/thong-ke-van-ban-di-tong-hop.aspx"><i class="fa fa-list-alt"></i><%=Resources.Common.lblThongKeTongHopVanBanDi %></a></li>
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
            <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Hethong))
              {%>
            <li class="active open">
                <a href="#">
                    <i class="fa fa-gears"></i>
                    <%--<span class="title">QUẢN TRỊ HỆ THỐNG</span>--%>
                    <span class="title"><%=Resources.Common.lblTieuDeQuanTri %></span>
                </a>
                <ul class="sub-menu">
                    <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Danhmuc))
                      {%>
                    <li>
                        <a href="#"><i class="fas fa-list-alt"></i> <%=Resources.Common.lblDanhMuc %><span class="arrow"></span></a>
                        <ul class="sub-menu">
                            <li style="display: none"><a title="Nhóm danh mục" href="/Pagess/nhom-danh-muc.aspx"><i class="fa fa-clipboard"></i>Nhóm danh mục</a></li>
                            <li><a title="Danh mục" href="/Pagess/ten-danh-muc.aspx"><i class="fa fa-list-alt"></i><%=Resources.Common.lblDanhMuc %></a></li>
                            <%--<li><a title="Cơ quan ban hành" href="/Pagess/co-quan-ban-hanh.aspx"><i class="fa fa-book"></i></a></li>--%>
                            <li><a title="Nơi nhận" href="/Pagess/noi-nhan.aspx"><i class="fa fa-building"></i><%=Resources.Common.lblCoQuanGuiNhan %></a></li>
                            <li><a title="Loại văn bản" href="/Pagess/loai-van-ban.aspx"><i class="fa fa-file-text-o"></i><%=Resources.Common.lblLoaiVanBan %></a></li>
                            <%--<li><a title="Lĩnh vực" href="/Pagess/linh-vuc.aspx"><i class="fa fa-reorder"></i>Lĩnh vực</a></li>--%>
                            <li><a title="Sổ văn bản" href="/Pagess/so-van-ban.aspx"><i class="fa fa-book"></i><%=Resources.Common.lblSoVanBan %></a></li>

                        </ul>
                    </li>
                    <%} %>

                    <li>
                        <a href="#"><i class="far fa-address-card"></i> <%=Resources.Common.lblTaiKhoan %><span class="arrow"></span></a>
                        <ul class="sub-menu">
                            <li style="display: none"><a title="" href="/Pagess/quyen-han.aspx"><i class="fa fa-gavel"></i>Quyền hạn hệ thống</a></li>
                            <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Vaitro))
                              {%>
                            <li><a title="" href="/Pagess/vai-tro-he-thong.aspx"><i class="fa fa-warning"></i><%=Resources.Common.lblVaiTroHeThong %></a></li>
                            <%} %>
                            <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Chucvu))
                              {%>
                            <li><a title="" href="/Pagess/nhom-nguoi-dung.aspx"><i class="fa fa-sitemap"></i><%=Resources.Common.lblChucDanh %></a></li>
                            <%} %>
                            <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Nhomnguoidung))
                              {%>
                            <li><a title="" href="/Pagess/nhom-ca-nhan.aspx"><i class="fa fa-group"></i><%=Resources.Common.lblNhomNguoiDung %></a></li>
                            <%} %>

                            <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Nguoidung))
                              {%>
                            <li><a title="" href="/Pagess/nguoi-dung.aspx"><i class="fa fa-user"></i><%=Resources.Common.lblNguoiDung %></a></li>
                            <%} %>
                        </ul>
                    </li>
                    <li>
                        <a href="#"><i class="fas fa-sitemap"></i> <%=Resources.Common.lblCoCauToChuc %><span class="arrow"></span></a>
                        <ul class="sub-menu">
                            <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Donvi))
                              {%>
                            <li><a title="" href="/Pagess/don-vi.aspx"><i class="fa fa-sitemap"></i><%=Resources.Common.lblDonViPhongBan %></a></li>
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
                        <a href="#"><i class="fas fa-cogs"></i> <%=Resources.Common.lblCauHinhHeThong %><span class="arrow"></span></a>
                        <ul class="sub-menu">
                            <li><a title="" href="/Pagess/cau-hinh-sms-email.aspx"><i class="fa fa-wrench"></i><%=Resources.Common.lblCauHinhSMSEmail %></a></li>
                            <li style="display: none"><a title="" href="/HeThong/CauHinhDuLieu/danhsach.aspx"><i class="fa fa-wrench"></i>Cấu hình số bản ghi</a></li>
                            <li style="display: none"><a title="" href="/Pagess/cau-hinh-module.aspx"><i class="fa fa-wrench"></i>Cấu hình hiển thị module</a></li>
                        </ul>
                    </li>
                    <%} %>
                    <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Loghethong))
                      {%>
                    <li><a title="" href="/Pagess/log.aspx"><i class="fas fa-database"></i> <%=Resources.Common.lblLogHeThong %></a></li>
                    <%} %>
                </ul>
            </li>
            <%} %>            
        </ul>
        <!-- END SIDEBAR MENU -->
    </div>
    <script type="text/javascript">
        $(document).ready(function () {
            <%if (CurrentUser.ID == 0 || CurrentUser == null)
              {%>
            window.location.href = "/Login.aspx";
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
