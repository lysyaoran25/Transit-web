<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucMenuDesign.ascx.cs" Inherits="Viags.WebApp.Common.ucMenuDesign" %>
<script type="text/javascript">
    $(document).ready(function () {
        if ($.cookie && $.cookie('sidebar_closed') === '1') {
            $("#IdMenuToggle").click();
        }
    });
</script>

<%string path = HttpContext.Current.Request.Url.AbsolutePath; %>

<div class="sidebar page-sidebar-menu page-sidebar-menu-closed " data-color="purple" data-background-color="black" data-image="/Publishing_Resources/img/sidebar-1.jpg" >
    <div class="sidebar-wrapper ps-container page-sidebar">
        <ul class="nav page-sidebar-menu page-sidebar-menu-closed " data-keep-expanded="false" data-auto-scroll="true" data-slide-speed="200">
            <li class="nav-wid nav-item actives-main open ">
                <a href="#pagesEx" data-toggle="collapse" aria-expanded="true">
                    <i class="fa fa-laptop icon-root"></i>
                    <span class="title"><%=Resources.Common.lblTieuDeQuanLy %></span>
                </a>
                <div class="collapse in" id="pagesEx">
                    <ul class="nav page-sidebar-menu " data-keep-expanded="false" data-auto-scroll="true" data-slide-speed="200">                  <!--BEGIN VĂN BẢN ĐẾN-->
                        <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Vanbanden))
                          { %>
                        <li class="nav-wid nav-item ">
                            <a href="#pagesVBDEN" data-toggle="collapse" aria-expanded="false" class="nav-link">
                                <i class="fas fa-file-import"></i>
                                <span class="title"><%=Resources.Common.lblVanBanDen %> <b class="arrow"></b></span>
                            </a>
                            <div class="collapse page-sidebar-menu " id="pagesVBDEN">
                                <ul class="nav page-sidebar-menu ">
                                    <li class="nav-wid nav-item ">
                                        <a class="nav-link" href="#">
                                            <i class="fas fa-stream"></i>
                                            <span class="title">Danh sách</span>
                                        </a>
                                    </li>
                                    
                                    <%if (CurrentUser.ViTriID == (int)Viags.Utils.Enum.TypeOfRole.VanThuDonVi)
                                      { %>
                                    <% if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Themmoivanbanden))
                                        { %>
                                    <li class="nav-wid nav-item ">
                                        <a class="nav-link" title="" href="/Pagess/form-van-ban-den.aspx">
                                            <i class="icon-plus"></i>
                                            <span class="title"><%=Resources.Common.lblThemMoiVanBan %></span>
                                        </a>
                                    </li>
                                    <%} %>
                                    <li class="nav-wid nav-item ">
                                        <a title="" href="/Pagess/van-ban-den-cho-vao-so.aspx">
                                            <i class="fa fa-book"></i>
                                            <span class="title"><%=Resources.Common.lblVanBanDenMoi %> <b id="idvanbanchovaoso"></b></span>   
                                        </a>
                                    </li>
                                    <li class="nav-wid nav-item ">
                                        <a class="nav-link" title="" href="/Pagess/van-ban-den.aspx">
                                            <i class="fa fa-book "></i>
                                            <span class="title"><%=Resources.Common.lblDanhSachVanBan %></span>
                                        </a>
                                        <ul class="nav page-sidebar-menu ">
                                            <%foreach (var item in LstSoVanBanDen.Where(p => p.IsDonVi == false).ToList())
                                              { %>
                                            <li class="nav-wid nav-item ">
                                                <a class="nav-link" title="" href="/Pagess/van-ban-den.aspx#Field=ThuTu&SoVanBanID=<%:item.ID %>&Page=1&RowPerPage=10">
                                                    <i class="fa fa-list-alt"></i>
                                                    <span class="title"><%:item.Ten %></span>
                                                </a>
                                            </li>
                                            <%} %>
                                        </ul>
                                    </li>
                                <%}
                                else
                                { %>
                                    <li class="nav-wid nav-item ">
                                        <a class="nav-link" title="" href="/Pagess/van-ban-den.aspx">
                                            <i class="fa fa-book "></i>
                                            <span class="title"><%=Resources.Common.lblDanhSachVanBan %></span>
                                        </a>
                                    </li>
                                <%} %>
                                <%if (path.ToLower() == "/pagess/chi-tiet-van-ban-den.aspx")
                                    {%>
                                    <li class="nav-wid nav-item ">
                                        <a class="nav-link" title="" href="/pagess/chi-tiet-van-ban-den.aspx?ItemID=<%=ItemID%>&do=view">
                                            <i class="fa fa-book"></i>
                                            <span class="title"><%=Resources.Common.lblChiTietVanBan %></span>
                                        </a>
                                    </li>
                                <%} %>
                                <li class="nav-wid nav-item ">
                                    <a class="nav-link" title="" href="/Pagess/van-ban-den-chua-xu-ly.aspx">
                                        <i class="fa fa-book "></i>
                                        <span class="title"><%=Resources.Common.lblVanBanChuaXuLy %></span>
                                    </a>
                                </li>
                                <li class="nav-wid nav-item ">
                                    <a class="nav-link" title="" href="/Pagess/van-ban-den-dang-xu-ly.aspx">
                                        <i class="fa fa-book "></i>
                                        <span class="title"><%=Resources.Common.lblVanBanDangXuLy %></span>
                                    </a>
                                </li>
                                <li class="nav-wid nav-item ">
                                    <a class="nav-link" title="" href="/Pagess/van-ban-den-da-xu-ly.aspx">
                                        <i class="fa fa-book "></i>
                                        <span class="title"><%=Resources.Common.lblVanBanDaXuLy %></span>
                                    </a>
                                </li>
                                <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Insovanbanden))
                                  { %>
                                    <li class="nav-wid nav-item ">
                                        <a class="nav-link" title="" href="/Pagess/in-so-van-ban-den.aspx#NgayDenDau=<%:DateTime.Now.ToString("dd/MM/yyyy") %>&InSo=1">
                                            <i class="fa fa-print"></i>
                                            <span class="title"><%=Resources.Common.lblInSoVanBan %></span>
                                        </a>
                                    </li>
                                <%} %>
                                </ul>
                            </div>                            
                        </li>
                        <%} %>
                        <!--END VĂN BẢN ĐẾN-->    
                        <!--BEGIN VĂN BẢN ĐI-->
                        <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Vanbandi))
                          { %>
                        <li class="nav-wid nav-item ">
                            <a href="#pagesVBDI" data-toggle="collapse" aria-expanded="false" class="nav-link">
                                <i class="fas fa-file-export"></i>
                                <span class="title"><%=Resources.Common.lblVanBanDi %></span>
                            </a>
                            <div class="collapse page-sidebar-menu " id="pagesVBDI">
                                <ul class="nav page-sidebar-menu ">
                                    <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Themmoivanbandi))
                                      {%>
                                    <li class="nav-wid nav-item ">
                                        <a class="nav-link" title="" href="/Pagess/form-van-ban-di.aspx">
                                            <i class="icon-plus"></i>
                                            <span class="title"><%=Resources.Common.lblThemMoiVanBan %></span>
                                        </a>
                                    </li>
                                    <%}%>
                                    <li class="nav-wid nav-item ">
                                        <a class="nav-link" title="" href="/Pagess/van-ban-di.aspx">
                                            <i class="fa fa-list-alt"></i>
                                            <span class="title"><%=Resources.Common.lblDanhSach %> <b id="idvanbandithuong"></b></span>
                                        </a>
                                    </li>
                                    <%if (CurrentUser.ViTriID == (int)Viags.Utils.Enum.TypeOfRole.VanThuDonVi)
                                      { %>
                                    <li class="nav-wid nav-item ">
                                        <a class="nav-link" title="" href="/Pagess/van-ban-cho-vao-so.aspx">
                                            <i class="fa fa-book "></i>
                                            <span class="title">Văn bản chờ vào sổ <b id="idvanbanduthaochovaoso"></b></span>
                                        </a>
                                    </li>
                                    <%} %>
                                    <li class="nav-wid nav-item ">
                                        <a class="nav-link" title="" href="/Pagess/van-ban-di.aspx#LoaiID=1">
                                            <i class="fa fa-list-alt"></i>
                                            <span class="title"><%=Resources.Common.lblVanBanPhatHanh %></span>
                                        </a>
                                    </li>
                                    <li class="nav-wid nav-item ">
                                        <a class="nav-link" title="" href="/Pagess/van-ban-di.aspx#LoaiID=2">
                                            <i class="fa fa-list-alt"></i>
                                            <span class="title"><%=Resources.Common.lblVanBanChuaPhatHanh %></span>
                                        </a>
                                    </li>
                                    <li class="nav-wid nav-item ">
                                        <a class="nav-link" title="" href="/Pagess/in-so-van-ban-di.aspx#ThoiGianBatDau=<%:DateTime.Now.ToString("dd/MM/yyyy") %>&InSo=1">
                                            <i class="fa fa-book"></i>
                                            <span class="title"><%=Resources.Common.lblInSo %></span>
                                        </a>
                                    </li>
                                    <%--BEGIN Chuyến phát bưu điện--%>
                                    <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.ChuyenPhatBuuDien))
                                      { %>
                                    <li class="nav-wid nav-item ">
                                        <a href="#pagesCPBD" data-toggle="collapse" aria-expanded="false" class="nav-link">
                                            <i class="fa fa-envelope"></i>
                                            <span class="title">Quản lý chuyển phát</span>
                                        </a>
                                        <div class="collapse page-sidebar-menu " id="pagesCPBD">
                                            <ul class="nav page-sidebar-menu ">
                                                <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.ChuyenPhatHanhQuaBuuDien))
                                                  {%>
                                                <li class="nav-wid nav-item ">
                                                    <a class="nav-link" title="" href="/Pagess/chuyen-phat-hanh-buu-dien.aspx">
                                                        <i class="fa fa-university"></i>
                                                        <span class="title">Chuyển phát hành qua bưu điện</span>
                                                    </a>
                                                </li>
                                                <li class="nav-wid nav-item ">
                                                    <a class="nav-link" title="" href="/Pagess/don-vi-chuyen-phat.aspx">
                                                        <i class="fa fa-university"></i>
                                                        <span class="title">Đơn vị chuyển phát</span>
                                                    </a>
                                                </li>
                                                <li class="nav-wid nav-item ">
                                                    <a class="nav-link" title="" href="/Pagess/pham-vi-noi-den.aspx">
                                                        <i class="fa fa-university"></i>
                                                        <span class="title">Phạm vi nơi đến</span>
                                                    </a>
                                                </li>
                                                <li class="nav-wid nav-item ">
                                                    <a class="nav-link" title="" href="/Pagess/pham-vi-trong-luong.aspx">
                                                        <i class="fa fa-university"></i>
                                                        <span class="title">Phạm vi trọng lượng</span>
                                                    </a>
                                                </li>
                                                <li class="nav-wid nav-item ">
                                                    <a class="nav-link" title="" href="/Pagess/thong-tin-buu-dien.aspx">
                                                        <i class="fa fa-university"></i>
                                                        <span class="title">Thông tin bưu điện</span>
                                                    </a>
                                                </li>
                                                <%}%>
                                            </ul>
                                        </div>
                                    </li>
                                    <%} %>
                                    <%--END Chuyến phát bưu điện--%>
                                </ul>
                            </div>
                        </li>
                        <%} %>
                        <!--END VĂN BẢN ĐI-->
                        <!--BEGIN VĂN BẢN DỰ THẢO-->
                        <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Vanbanduthao))
                          { %>
                        <li class="nav-wid nav-item ">
                            <a href="#pagesVBDT" data-toggle="collapse" aria-expanded="false" class="nav-link">
                                <i class="fas fa-file-contract"></i>
                                <span class="title"><%=Resources.Common.lblVanBanDuThao %></span>
                            </a>
                            <div class="collapse page-sidebar-menu " id="pagesVBDT">
                                <ul class="nav page-sidebar-menu ">
                                    <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Themmoivanbanduthao))
                                      { %>
                                        <li class="nav-wid nav-item ">
                                            <a class="nav-link" title="" href="/Pagess/form-van-ban-du-thao.aspx">
                                                <i class="icon-plus"></i>
                                                <span class="title"><%=Resources.Common.lblThemMoiVanBan %></span>
                                            </a>
                                        </li>
                                    <%} %>
                                    <%if (path.ToLower() == "/pagess/chi-tiet-van-ban-du-thao.aspx")
                                      {%>
                                    <li class="nav-wid nav-item ">
                                        <a class="nav-link" title="" href="/Pagess/chi-tiet-van-ban-du-thao.aspx?do=view&ItemID=<%=ItemID %>">
                                            <i class="fa fa-book"></i>
                                            <span class="title"><%=Resources.Common.lblChiTietVanBan %></span>
                                        </a>
                                    <%} %>
                                    <li class="nav-wid nav-item ">
                                        <a class="nav-link" title="" href="/Pagess/van-ban-du-thao.aspx">
                                            <i class="fa fa-book"></i>
                                            <span class="title"><%=Resources.Common.lblDanhSachVanBan %></span>
                                        </a>
                                    </li>
                                    <li class="nav-wid nav-item ">
                                        <a class="nav-link" title="" href="/Pagess/van-ban-du-thao-chua-xu-ly.aspx">
                                            <i class="fa fa-book"></i>
                                            <span class="title"><%=Resources.Common.lblChuaXuLy %></span>
                                        </a>
                                    </li>
                                    <li class="nav-wid nav-item ">
                                        <a class="nav-link" title="" href="/Pagess/van-ban-du-thao-dang-xu-ly.aspx">
                                            <i class="fa fa-book"></i>
                                            <span class="title"><%=Resources.Common.lblDangXuLy %></span>
                                        </a>
                                    </li>
                                    <li class="nav-wid nav-item ">
                                        <a class="nav-link" title="" href="/Pagess/van-ban-du-thao-da-xu-ly.aspx">
                                            <i class="fa fa-book"></i>
                                            <span class="title"><%=Resources.Common.lblDaXuLy %></span>
                                        </a>
                                    </li>
                                </ul>
                            </div>
                        </li>
                        <%} %>  
                        <!--END VĂN BẢN DỰ THẢO-->
                        <!--BEGIN CÔNG VIỆC-->
                        <%if (!CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.QuantrihethongAdmin))
                          {%>
                        <li class="nav-wid nav-item ">
                            <a href="#pagesCV" data-toggle="collapse" aria-expanded="false" class="nav-link">
                                <i class="fas fa-balance-scale"></i>
                                <span class="title"><%=Resources.Common.lblDieuHanh %></span>
                            </a>
                            <div class="collapse page-sidebar-menu " id="pagesCV">
                                <ul class="nav page-sidebar-menu ">
                                <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Congviec))
                                  { %>
                                    <li class="nav-wid nav-item ">
                                        <a href="#pagesQLCV" data-toggle="collapse" aria-expanded="false" class="nav-link">
                                            <i class="fa fa-briefcase"></i>
                                            <span class="title"><%=Resources.Common.lblQuanLyCongViec %></span>
                                        </a>
                                        <div class="collapse page-sidebar-menu " id="pagesQLCV">
                                            <ul class="nav page-sidebar-menu ">
                                                <li class="nav-wid nav-item ">
                                                    <a class="nav-link" title="" href="/Pagess/form-ho-so-cong-viec.aspx">
                                                        <i class="icon-plus"></i>
                                                        <span class="title"><%=Resources.Common.lblThemMoiCongViec %></span>
                                                    </a>
                                                </li>
                                                <li class="nav-wid nav-item ">
                                                    <a class="nav-link" title="" href="/Pagess/cong-viec.aspx">
                                                        <i class="fa fa-book"></i>
                                                        <span class="title"><%=Resources.Common.lblDanhSachCongViec %></span>
                                                    </a>
                                                </li>
                                                <%if (path.ToLower() == "/pagess/chi-tiet-cong-viec.aspx")
                                                  {%>
                                                <li class="nav-wid nav-item ">
                                                    <a class="nav-link" title="" href="/Pagess/chi-tiet-cong-viec.aspx?do=view&ItemID=<%=ItemID %>">
                                                        <i class="fa fa-book"></i>
                                                        <span class="title"><%=Resources.Common.lblChiTietCongViec %></span>
                                                    </a>
                                                <%} %>
                                                <li class="nav-wid nav-item ">
                                                    <a class="nav-link" title="" href="/Pagess/cong-viec-chua-xu-ly.aspx">
                                                        <i class="fa fa-book"></i>
                                                        <span class="title"><%=Resources.Common.lblCongViecChuaXuLy %> <b id="idcongviecchuaxuly"></b></span>
                                                    </a>
                                                </li>
                                                <li class="nav-wid nav-item ">
                                                    <a class="nav-link" title="" href="/Pagess/cong-viec-dang-xu-ly.aspx">
                                                        <i class="fa fa-book"></i>
                                                        <span class="title"><%=Resources.Common.lblCongViecDangXuLy %> <b id="idcongviecdangkxuly"></b></span>
                                                    </a>
                                                </li>
                                                <li class="nav-wid nav-item ">
                                                    <a class="nav-link" title="" href="/Pagess/cong-viec-da-xu-ly.aspx">
                                                        <i class="fa fa-book"></i>
                                                        <span class="title"><%=Resources.Common.lblCongViecDaXuLy %></span>
                                                    </a>
                                                </li>
                                                <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Tonghopcongviec))
                                                  { %>
                                                <li class="nav-wid nav-item ">
                                                    <a class="nav-link" title="" href="/Pagess/tong-hop-cong-viec.aspx">
                                                        <i class="fa fa-bar-chart-o"></i>
                                                        <span class="title"><%=Resources.Common.lblTongHopCongViec %></span>
                                                    </a>
                                                </li>
                                                <%} %>
                                                <li class="nav-wid nav-item " style="display: none">
                                                    <a class="nav-link" title="" href="/Pagess/bao-cao-cong-viec.aspx">
                                                        <i class="fa fa-bar-chart-o"></i>
                                                        <span class="title"><%=Resources.Common.lblBaoCaoCongViec %></span>
                                                    </a>
                                                </li>
                                            </ul>
                                        </div>
                                    </li>
                                    <%} %>
                                    <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Baocaocongviec))
                                      { %>
                                    <li class="nav-wid nav-item ">
                                        <a href="#pagesQLBCCV" data-toggle="collapse" aria-expanded="false" class="nav-link">
                                            <i class="fa fa-briefcase"></i>
                                            <span class="title"><%=Resources.Common.lblQuanLyBaoCaoCongViec %></span>
                                        </a>
                                        <div class="collapse page-sidebar-menu " id="pagesQLBCCV">
                                            <ul class="nav page-sidebar-menu ">
                                                <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Cauhinhthoigianbaocao))
                                                  { %>
                                                <li class="nav-wid nav-item ">
                                                    <a class="nav-link" title="" href="/BaoCaoCongViec/CauHinhThoiGianBaoCao/Default.aspx">
                                                        <i class="icon-plus"></i>
                                                        <span class="title"><%=Resources.Common.lblThietDatThoiGianBaoCao %></span>
                                                    </a>
                                                </li>
                                                <%} %>
                                                <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Cauhinhthoigianbaocao))
                                                  { %>
                                                <li class="nav-wid nav-item ">
                                                    <a class="nav-link" title="" href="/BaoCaoCongViec/CauHinhThoiGianKhongBaoCao/Default.aspx">
                                                        <i class="icon-plus"></i>
                                                        <span class="title"><%=Resources.Common.lblThietDatThoiGianKhongBC %></span>
                                                    </a>
                                                </li>
                                                <%} %>
                                                <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Baocaocongviec))
                                                  { %>
                                                <li class="nav-wid nav-item ">
                                                    <a class="nav-link" title="" href="/BaoCaoCongViec/BaoCaoCuaDonVi/Default.aspx">
                                                        <i class="icon-plus"></i>
                                                        <span class="title"><%=Resources.Common.lblBaoCaoCongViec %></span>
                                                    </a>
                                                </li>
                                                <%} %>
                                                <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Nhanbaocaotudonvi))
                                                  { %>
                                                <li class="nav-wid nav-item ">
                                                    <a class="nav-link" title="" href="/BaoCaoCongViec/TongHopBaoCao/Default.aspx">
                                                        <i class="icon-plus"></i>
                                                        <span class="title"><%=Resources.Common.lblTongHopBaoCao %></span>
                                                    </a>
                                                </li>
                                                <%} %>
                                            </ul>
                                        </div>
                                    </li>
                                    <%} %>
                                    <li class="nav-wid nav-item ">
                                        <a class="nav-link" title="" href="/Pagess/ban-giao-cong-viec.aspx">
                                            <i class="fa fa-legal"></i>
                                            <span class="title"><%=Resources.Common.lblBanGiaoCongViec %></span>
                                        </a>
                                    </li>
                                    <%if (CurrentUser != null && (CurrentUser.ViTriID == (int)Viags.Utils.Enum.TypeOfRole.LanhDaoPhongBan || CurrentUser.ViTriID == (int)Viags.Utils.Enum.TypeOfRole.LanhDaoHanhChinh || CurrentUser.ViTriID == (int)Viags.Utils.Enum.TypeOfRole.LanhDaoVanPhong || CurrentUser.ViTriID == (int)Viags.Utils.Enum.TypeOfRole.LanhDaoDonVi || CurrentUser.ViTriID == (int)Viags.Utils.Enum.TypeOfRole.LanhDaoNHNN))
                                      { %>
                                    <li class="nav-wid nav-item ">
                                        <a class="nav-link" href="/Pagess/uy-quyen.aspx">
                                            <i class="icon-calendar"></i>
                                            <span class="title"><%=Resources.Common.lblUyQuyen %></span>
                                        </a>
                                    </li>
                                    <%} %>
                                    <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Theodoiuyquyen))
                                      { %>
                                    <li class="nav-wid nav-item ">
                                        <a class="nav-link" title="" href="/Pagess/theo-doi-uy-quyen.aspx">
                                            <i class="fa fa-legal"></i>
                                            <span class="title"><%=Resources.Common.lblTheoDoiUyQuyen %></span>
                                        </a>
                                    </li>
                                    <%} %>

                                    <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Thongbao))
                                      { %>
                                    <li class="nav-wid nav-item ">
                                        <a class="nav-link" title="" href="/Pagess/thong-bao.aspx">
                                            <i class="fa fa-book"></i>
                                            <span class="title"><%=Resources.Common.lblThongBaoChung %></span>
                                        </a>
                                    </li>
                                    <%} %>
                                </ul>
                            </div>
                        </li>
                        <%} %>
                        <!--END CÔNG VIỆC-->
                        <!--BEGIN TIỆN ÍCH-->
                        <li class="nav-wid nav-item ">
                            <a href="#pagesTI" data-toggle="collapse" aria-expanded="false" class="nav-link">
                                <i class="fab fa-medapps"></i>
                                <span class="title"><%=Resources.Common.lblTienIch %></span>
                            </a>
                            <div class="collapse page-sidebar-menu " id="pagesTI">
                                <ul class="nav page-sidebar-menu ">
                                    <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Lichhopcongtactuan))
                                      { %>
                                    <li class="nav-wid nav-item ">
                                        <a class="nav-link" title="" href="/Pagess/lich-hop-cong-tac.aspx">
                                            <i class="fa fa-calendar-o"></i>
                                            <span class="title"><%=Resources.Common.lblLichHopCongTac %></span>
                                        </a>
                                    </li>
                                    <%} %>
                                    <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Datphonghop))
                                      { %>
                                    <li class="nav-wid nav-item ">
                                        <a href="#pagesQLPH" data-toggle="collapse" aria-expanded="false" class="nav-link">
                                            <i class="fa fa-bank"></i>
                                            <span class="title"><%=Resources.Common.lblQuanLyPhongHop %></span>
                                        </a>
                                        <div class="collapse page-sidebar-menu " id="pagesQLPH">
                                            <ul class="nav page-sidebar-menu ">
                                                <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Phonghop))
                                                  {%>
                                                <li class="nav-wid nav-item ">
                                                    <a class="nav-link" title="" href="/Pagess/danh-muc-phong-hop.aspx">
                                                        <i class="fa fa-calendar"></i>
                                                        <span class="title"><%=Resources.Common.lblPhongHop %></span>
                                                    </a>
                                                </li>
                                                <%}%>
                                                <li class="nav-wid nav-item ">
                                                    <a class="nav-link" title="" href="/Pagess/thong-tin-dat-phong.aspx">
                                                        <i class="fa fa-calendar"></i>
                                                        <span class="title"><%=Resources.Common.lblThongTinDatPhong %></span>
                                                    </a>
                                                </li>
                                            </ul>
                                        </div>
                                    </li>
                                    <%} %>
                                    <%-- BEGIN VĂN PHÒNG PHẨM --%>
                                    <li class="nav-wid nav-item ">
                                        <a href="#pagesVPP" data-toggle="collapse" aria-expanded="false" class="nav-link">
                                            <i class="fa fa-bank"></i>
                                            <span class="title"><%=Resources.Common.lblQuanLyVanPhongPham %></span>
                                        </a>
                                        <div class="collapse page-sidebar-menu " id="pagesVPP">
                                            <ul class="nav page-sidebar-menu ">
                                                <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Phonghop))
                                                  {%>
                                                    <li class="nav-wid nav-item ">
                                                        <a class="nav-link" title="" href="/Pagess/van-phong-pham.aspx">
                                                            <i class="fa fa-calendar"></i>
                                                            <span class="title"><%=Resources.Common.lblVanPhongPham %></span>
                                                        </a>
                                                    </li>
                                                    <li class="nav-wid nav-item ">
                                                        <a class="nav-link" title="" href="/Pagess/van-phong-pham-don-vi-tinh.aspx">
                                                            <i class="fa fa-calendar"></i>
                                                            <span class="title"><%=Resources.Common.lblVanPhongPhamDonViTinh %></span>
                                                        </a>
                                                    </li>
                                                <%}%>
                                            </ul>
                                        </div>
                                    </li>
                                    <%-- END VĂN PHÒNG PHẨM --%>
                                    <%-- BEGIN ĐẶT XE --%>
                                    <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.DatXe))
                                      { %>
                                    <li class="nav-wid nav-item ">
                                        <a href="#pagesDX" data-toggle="collapse" aria-expanded="false" class="nav-link">
                                            <i class="fa fa-bank"></i>
                                            <span class="title"><%=Resources.DanhMucXe.lblQuanLyXe %></span>
                                        </a>
                                        <div class="collapse page-sidebar-menu " id="pagesDX">
                                            <ul class="nav page-sidebar-menu ">
                                                <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Xe))
                                                  {%>
                                                <li class="nav-wid nav-item ">
                                                    <a class="nav-link" title="" href="/Pagess/danh-muc-xe.aspx">
                                                        <i class="fa fa-bus"></i>
                                                        <span class="title"><%=Resources.DanhMucXe.lblXe %></span>
                                                    </a>
                                                </li>
                                                <%}%>
                                                <li class="nav-wid nav-item ">
                                                    <a class="nav-link" title="" href="/Pagess/thong-tin-dat-xe.aspx">
                                                        <i class="fa fa-bus"></i>
                                                        <span class="title"><%=Resources.DanhMucXe.lblThongTinDatXe %></span>
                                                    </a>
                                                </li>
                                            </ul>
                                        </div>
                                    </li>
                                    <%} %>
                                    <%-- END ĐẶT XE --%>                                  
                                </ul>
                            </div>
                        </li>
                        <%--END TIỆN ÍCH--%>
                        <!--BEGIN HỒ SƠ TÀI LIỆU-->
                        <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Hosotailieu))
                          { %>
                        <li class="nav-wid nav-item ">
                            <a href="#pagesQLHS" data-toggle="collapse" aria-expanded="false" class="nav-link">
                                <i class="fas fa-folder"></i>
                                <span class="title"><%=Resources.Common.lblQuanLyHoSo %></span>
                            </a>
                            <div class="collapse page-sidebar-menu " id="pagesQLHS">
                                <ul class="nav page-sidebar-menu ">
                                    <li class="nav-wid nav-item ">
                                        <a class="nav-link" title="Danh sách hồ sơ" href="/Pagess/quan-ly-ho-so-tai-lieu.aspx">
                                            <i class="fa fa-file-archive-o"></i>
                                            <span class="title"><%=Resources.Common.lblDanhSachHoSo %></span>
                                        </a>
                                    </li>
                                    <%if (ItemID > 0)
                                      {%>
                                    <li class="nav-wid nav-item ">
                                        <a class="nav-link" title="Chi tiết hồ sơ" href="/Pagess/chi-tiet-ho-so-tai-lieu.aspx?ItemID=<%=ItemID %>">
                                            <i class="fa fa-file-archive-o"></i>
                                            <span class="title"><%=Resources.Common.lblChiTietHoSo %></span>
                                        </a>
                                    </li>
                                    <%} %>
                                </ul>
                            </div>
                        </li>
                        <%} %>
                        <!--END HỒ SƠ TÀI LIỆU-->
                        <!--BEGIN BIỂU MẪU-->
                        <li class="nav-wid nav-item ">
                            <a class="nav-link" title="" href="/Pagess/bieu-mau.aspx">
                                <i class="far fa-file-alt"></i>
                                <span class="title"><%=Resources.Common.lblBieuMau %></span>
                            </a>
                        </li>
                        <!--END BIỂU MẪU-->
                        <!--BEGIN LỊCH CÁ NHÂN-->
                        <li class="nav-wid nav-item ">
                            <a class="nav-link" title="" href="/Pagess/lich-ca-nhan.aspx">
                                <i class="fas fa-calendar-alt"></i>
                                <span class="title"><%=Resources.Common.lblLichCaNhan %></span>
                            </a>
                        </li>
                        <!--END LỊCH CÁ NHÂN-->
                        <!--BEGIN BÁO CÁO THỐNG KÊ-->
                        <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Thongkebaocao))
                            { %>
                        <li class="nav-wid nav-item ">
                            <a href="#pagesBCTK" data-toggle="collapse" aria-expanded="false" class="nav-link">
                                <i class="fas fa-chart-line"></i>
                                <span class="title"><%=Resources.Common.lblBaoCaoThongKe %></span>
                            </a>
                            <div class="collapse page-sidebar-menu " id="pagesBCTK">
                                <ul class="nav page-sidebar-menu ">
                                    <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Thongkebaocaovanbanden))
                                      { %>
                                    <li class="nav-wid nav-item ">
                                        <a href="#pagesTKVBDEN" data-toggle="collapse" aria-expanded="false" class="nav-link">
                                            <i class="fa fa-book"></i>
                                            <span class="title"><%=Resources.Common.lblVanBanDen %></span>
                                        </a>
                                        <div class="collapse page-sidebar-menu " id="pagesTKVBD">
                                            <ul class="nav-wid nav-item ">
                                                <li class="nav-wid nav-item ">
                                                    <a class="nav-link" title="" href="/Pagess/thong-ke-van-ban-den-ban-lanh-dao.aspx">
                                                        <i class="fa fa-list-alt"></i>
                                                        <span class="title"><%=Resources.Common.lblBaoCaoTinhHinhXuLy %></span>
                                                    </a>
                                                </li>
                                            </ul>
                                        </div>
                                    </li>
                                    <%} %>
                                    <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Thongkebaocaovanbandi))
                                      { %>
                                    <li class="nav-wid nav-item ">
                                        <a href="#pagesTKVBDI" data-toggle="collapse" aria-expanded="false" class="nav-link">
                                            <i class="fa fa-book"></i>
                                            <span class="title"><%=Resources.Common.lblVanBanDi %></span>
                                        </a>
                                        <div class="collapse page-sidebar-menu " id="pagesTKVBDI">
                                            <ul class="nav-wid nav-item ">
                                                <li class="nav-wid nav-item ">
                                                    <a class="nav-link" title="" href="/Pagess/thong-ke-van-ban-di.aspx">
                                                        <i class="fa fa-list-alt"></i>
                                                        <span class="title"><%=Resources.Common.lblThongKeVanBanDi %></span>
                                                    </a>
                                                </li>
                                                <li class="nav-wid nav-item ">
                                                    <a class="nav-link" title="" href="/Pagess/thong-ke-van-ban-di-tong-hop.aspx">
                                                        <i class="fa fa-list-alt"></i>
                                                        <span class="title"><%=Resources.Common.lblThongKeTongHopVanBanDi %></span>
                                                    </a>
                                                </li>
                                            </ul>
                                        </div>
                                    </li>
                                    <%} %>
                                </ul>
                            </div>
                        </li>
                        <%} %>
                        <!--END BÁO CÁO THỐNG KÊ-->
                        <!--BEGIN TRUNG TÂM GIẢI ĐÁP & PHẢN HỒI THÔNG TIN-->
                        <li class="nav-wid nav-item ">
                            <a class="nav-link" title="" href="/Pagess/trung-tam-giai-dap.aspx">
                                <i class="fas fa-question"></i>
                                <span class="title">Trung tâm giải đáp</span>
                            </a>
                        </li>
                        <li class="nav-wid nav-item ">
                            <a class="nav-link" title="" href="/Pagess/phan-hoi-thong-tin.aspx">
                                <i class="fab fa-replyd"></i>
                                <span class="title">Phản hồi thông tin</span>
                            </a>
                        </li>
                        <!--END TRUNG TÂM GIẢI ĐÁP & PHẢN HỒI THÔNG TIN-->
                    </ul>
                </div>
            </li>
            <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Hethong))
              {%>
            <li class="nav-wid nav-item active open ">
                <a href="#pagesEs" data-toggle="collapse" aria-expanded="false">
                    <i class="fa fa-gears"></i>
                    <span class="title"><%=Resources.Common.lblTieuDeQuanTri %></span>
                </a>
                <div class="collapse page-sidebar-menu " id="pagesEs">
                    <ul class="nav page-sidebar-menu ">
                        <!--BEGIN DANH MỤC-->
                        <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Danhmuc))
                          {%>
                            <li class="nav-wid nav-item ">
                                <a href="#pagesDM" data-toggle="collapse" aria-expanded="false" class="nav-link">
                                    <i class="fas fa-list-alt"></i>
                                    <span class="title"><%=Resources.Common.lblDanhMuc %></span>
                                </a>
                                <div class="collapse page-sidebar-menu " id="pagesDM">
                                    <ul class="nav page-sidebar-menu ">
                                        <li class="nav-wid nav-item " style="display: none">
                                            <a class="nav-link" title="Nhóm danh mục" href="/Pagess/nhom-danh-muc.aspx">
                                                <i class="fa fa-clipboard"></i>
                                                <span class="title">Nhóm danh mục</span>
                                            </a>
                                        </li>
                                        <li class="nav-wid nav-item ">
                                            <a class="nav-link" title="Danh mục" href="/Pagess/ten-danh-muc.aspx">
                                                <i class="fa fa-list-alt"></i>
                                                <span class="title"><%=Resources.Common.lblDanhMuc %></span>
                                            </a>
                                        </li>
                                        <li class="nav-wid nav-item ">
                                            <a class="nav-link" title="Nơi nhận" href="/Pagess/noi-nhan.aspx">
                                                <i class="fa fa-building"></i>
                                                <span class="title"><%=Resources.Common.lblCoQuanGuiNhan %></span>
                                            </a>
                                        </li>
                                        <li class="nav-wid nav-item ">
                                            <a class="nav-link" title="Loại văn bản" href="/Pagess/loai-van-ban.aspx">
                                                <i class="fa fa-file-text-o"></i>
                                                <span class="title"><%=Resources.Common.lblLoaiVanBan %></span>
                                            </a>
                                        </li>
                                        <li class="nav-wid nav-item ">
                                            <a class="nav-link" title="Sổ văn bản" href="/Pagess/so-van-ban.aspx">
                                                <i class="fa fa-book"></i>
                                                <span class="title"><%=Resources.Common.lblSoVanBan %></span>
                                            </a>
                                        </li>
                                    </ul>
                                </div>
                            </li>
                        <%} %>
                        <!--END DANH MỤC-->
                        <!--BEGIN QUYỀN HẠN HỆ THỐNG-->
                        <li class="nav-wid nav-item ">
                            <a href="#pagesTK" data-toggle="collapse" aria-expanded="false" class="nav-link">
                                <i class="far fa-address-card"></i>
                                <span class="title"><%=Resources.Common.lblTaiKhoan %></span>
                            </a>
                            <div class="collapse page-sidebar-menu " id="pagesTK">
                                <ul class="nav page-sidebar-menu ">
                                    <li class="nav-wid nav-item " style="display: none">
                                        <a class="nav-link" title="" href="/Pagess/quyen-han.aspx">
                                            <i class="fa fa-gavel"></i>
                                            <span class="title">Quyền hạn hệ thống</span>
                                        </a>
                                    </li>
                                    <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Vaitro))
                                      {%>
                                    <li class="nav-wid nav-item ">
                                        <a class="nav-link" title="" href="/Pagess/vai-tro-he-thong.aspx">
                                            <i class="fa fa-warning"></i>
                                            <span class="title"><%=Resources.Common.lblVaiTroHeThong %></span>
                                        </a>
                                    </li>
                                    <%} %>
                                    <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Chucvu))
                                      {%>
                                    <li class="nav-wid nav-item ">
                                        <a class="nav-link" title="" href="/Pagess/nhom-nguoi-dung.aspx">
                                            <i class="fa fa-sitemap"></i>
                                            <span class="title"><%=Resources.Common.lblChucDanh %></span>
                                        </a>
                                    </li>
                                    <%} %>
                                    <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Nhomnguoidung))
                                      {%>
                                    <li class="nav-wid nav-item ">
                                        <a class="nav-link" title="" href="/Pagess/nhom-ca-nhan.aspx">
                                            <i class="fa fa-group"></i>
                                            <span class="title"><%=Resources.Common.lblNhomNguoiDung %></span>
                                        </a>
                                    </li>
                                    <%} %>
                                    <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Nguoidung))
                                      {%>
                                    <li class="nav-wid nav-item ">
                                        <a class="nav-link" title="" href="/Pagess/nguoi-dung.aspx">
                                            <i class="fa fa-user"></i>
                                            <span class="title"><%=Resources.Common.lblNguoiDung %></span>
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
                                <span class="title"><%=Resources.Common.lblCoCauToChuc %></span>
                            </a>
                            <div class="collapse page-sidebar-menu " id="pagesCCTC">
                                <ul class="nav page-sidebar-menu ">
                                    <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Donvi))
                                      {%>
                                    <li class="nav-wid nav-item ">
                                        <a class="nav-link" title="" href="/Pagess/don-vi.aspx">
                                            <i class="fa fa-sitemap"></i>
                                            <span class="title"><%=Resources.Common.lblDonViPhongBan %></span>
                                        </a>
                                    </li>
                                    <%} %>
                                    <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Nhomdonvi))
                                      {%>
                                    <li class="nav-wid nav-item " style="display: none">
                                        <a class="nav-link" title="" href="/Pagess/nhom-don-vi.aspx">
                                            <i class="fa fa-object-group"></i>
                                            <span class="title">Nhóm đơn vị phòng ban</span>
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
                        <li class="nav-wid nav-item ">
                            <a href="#pagesCHHT" data-toggle="collapse" aria-expanded="false" class="nav-link">
                                <i class="fas fa-cogs"></i>
                                <%=Resources.Common.lblCauHinhHeThong %><span class="arrow"></span>
                            </a>
                            <div class="collapse page-sidebar-menu " id="pagesCHHT">
                                <ul class="nav page-sidebar-menu ">
                                    <li class="nav-wid nav-item ">
                                        <a class="nav-link" title="" href="/Pagess/cau-hinh-sms-email.aspx">
                                            <i class="fa fa-wrench"></i>
                                            <span class="title"><%=Resources.Common.lblCauHinhSMSEmail %></span>
                                        </a>
                                    </li>
                                    <li class="nav-wid nav-item " style="display: none">
                                        <a class="nav-link" title="" href="/HeThong/CauHinhDuLieu/danhsach.aspx">
                                            <i class="fa fa-wrench"></i>
                                            <span class="title">Cấu hình số bản ghi</span>
                                        </a>
                                    </li>
                                    <li class="nav-wid nav-item " style="display: none">
                                        <a class="nav-link" title="" href="/Pagess/cau-hinh-module.aspx">
                                            <i class="fa fa-wrench"></i>
                                            <span class="title">Cấu hình hiển thị module</span>
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
                                <i class="fas fa-database"></i>
                                <span class="title"><%=Resources.Common.lblLogHeThong %></span>
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
    <script type="text/javascript">
        $(document).ready(function () {
            <%if (CurrentUser.ID == 0 || CurrentUser == null)
              {%>
                window.location.href = "/LoginNew.aspx";
            <%}%>
            MenuAction();
            $(".sub-menu li a").bind("click", function () {
                alert('sss');
                $(this).parent().parent().children().removeClass("active").removeClass("open");
                MenuAction();
            });
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
