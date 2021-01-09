<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pListHome.aspx.cs" Inherits="Viags.WebApp.Home.pListHome" %>

<div class="portlet">
    <div class="portlet-title ">
        <div class="caption">
            <span class="caption"><a href="/Pagess/van-ban-den.aspx#LoaiDanhSachID=1&Page=1&RowPerPage=10"><%=Resources.Home.lblVanBanDenChuaXuLy %></a></span>
            <span class="count">(<%=CountVBDen %>)</span>
        </div>
    </div>
    <div class="portlet-body">
        <div class="data-table table-responsive">
            <table class="table table-bordered table-hover table-striped-custom table-responsive">
                <thead>
                    <tr>
                        <th style="width: 5%" class="text-justify text-center"><%=Resources.Home.lblSTT %></th>
                        <th style="width: 10%" class="text-justify text-center"><%=Resources.Home.lblNgayDen %></th>
                        <th style="width: 14%" class="text-justify text-center"><%=Resources.Home.lblNgayVanBan %></th>
                        <th style="width: 12%" class="text-justify text-center"><%=Resources.Home.lblSoKiHieu %></th>
                        <th style="width: 10%" class="text-justify text-center"><%=Resources.Home.lblHanXuLy %></th>
                        <th class="text-justify text-center"><%=Resources.Home.lblTrichYeu %></th>
                        <th style="width: 3%"><i class="icon-paper-clip"></i></th>
                    </tr>
                </thead>
                <tbody>
                    <%int count = 0; %>
                    <%foreach (var item in LtsVanBanDen)
                      { %>
                    <%count++; %>
                    <tr>
                        <td><%=count %></td>
                        <td><%=item.NgayDen.HasValue?string.Format("{0:dd/MM/yyyy}",item.NgayDen):string.Empty %></td>
                        <td><%=item.NgayBanHanh.HasValue?string.Format("{0:dd/MM/yyyy}",item.NgayBanHanh):string.Empty %></td>
                        <td><a href="<%=Viags.Utils.LinkModule.ChiTietVanBanDen %><%=item.ID %>"><%=item.SoKyHieu %></a></td>
                        <td><%=item.HanXuLy.HasValue?string.Format("{0:dd/MM/yyyy}",item.HanXuLy):string.Empty %></td>
                        <td>
                            <a href="<%=Viags.Utils.LinkModule.ChiTietVanBanDen %><%=item.ID %>"><%=!string.IsNullOrEmpty(item.TrichYeu)?item.TrichYeu:"Xem văn bản" %></a>
                        </td>
                        <td><%if (item.LtsFileAttach != null && item.LtsFileAttach.Count > 0)
                              { %>
                            <%foreach (var file in item.LtsFileAttach)
                              { %>
                            <a target="_blank" title="<%=file.Ten %>" href="/Pagess/view-file-pdf.aspx?UrlFile=<%=file.FileLink %>&FileName=<%=file.Ten %>"><i class="icon-paper-clip"></i></a>
                            <br />
                            <%} %>
                            <%} %>
                        </td>
                    </tr>
                    <%} %>
                </tbody>
            </table>
        </div>
    </div>
</div>

<%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.Congviec))
  { %>
<div class="portlet">
    <div class="portlet-title ">
        <div class="caption">
            <span class="caption"><a href="/Pagess/cong-viec-chua-xu-ly.aspx"><%=Resources.Home.lblCongViecChuaXuLy %></a></span>
            <span class="count">(<%=CountCongViec %>)</span>
        </div>
    </div>
    <div class="portlet-body">
        <div class="data-table table-responsive">
            <table class="table table-bordered table-hover table-striped-custom table-responsive">
                <thead>
                    <tr>
                        <th style="width: 5%;" class="text-justify text-center"><%=Resources.Home.lblSTT %></th>
                        <th class="text-justify text-center"><%=Resources.Home.lblTenCongViec %></th>
                        <th style="width: 14%" class="text-justify text-center"><%=Resources.Home.lblNgayBatDau %></th>
                        <th style="width: 10%" class="text-justify text-center"><%=Resources.Home.lblHanXuLy %></th>
                        <th style="width: 12%" class="text-justify text-center"><%=Resources.Home.lblNguoiLap %></th>
                        <th style="width: 10%" class="text-justify text-center"><%=Resources.Home.lblDauMoi %></th>
                        <th class="text-justify text-center"><%=Resources.Home.lblTrangTrai %></th>
                    </tr>
                </thead>
                <tbody>
                    <%int countCV = 0; %>
                    <%foreach (var item in LtsCongViec)
                      { %>
                    <%countCV++; %>
                    <tr>
                        <td><%=countCV %></td>
                        <td><a href="<%=Viags.Utils.LinkModule.ChiTietCongViec %><%=item.ID %>"><%=item.Ten %></a></td>
                        <td><%=item.NgayBatDau.HasValue?string.Format("{0:dd/MM/yyyy}",item.NgayBatDau):string.Empty %></td>
                        <td><%=item.HanXuLy.HasValue?string.Format("{0:dd/MM/yyyy}",item.HanXuLy):string.Empty %></td>
                        <td><%=item.TenNguoiLap %>
                        </td>
                        <td><%:item.NguoiDauMoiID.HasValue ? item.TenNguoiDauMoi : item.TenDonViDauMoi %></td>
                        <td>
                            <span class="label label-danger"><%=Resources.Action.lblChuaXuLy %></span>
                        </td>
                    </tr>
                    <%} %>
                </tbody>
            </table>
        </div>
    </div>
</div>
<%} %>