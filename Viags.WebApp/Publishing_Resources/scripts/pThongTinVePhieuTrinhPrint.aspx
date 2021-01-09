<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pThongTinVePhieuTrinhPrint.aspx.cs" Inherits="SBV.WebApp.VanBanDen.pThongTinVePhieuTrinhPrint" %>

<script>
    $(document).ready(function () {

        $("#textchucvu").html($("#chucvu").val());
        $("#LtsNguoiDung").keyup(function () {
            $("#textkinhtrinh").html($("#LtsNguoiDung").val());
        }).change(function () {
            $("#textkinhtrinh").html($("#LtsNguoiDung").val());
        });
        $("#tenchanhvp").keyup(function () {
            $("#textchanhvp").html($("#tenchanhvp").val());
        }).change(function () {
            $("#textchanhvp").html($("#tenchanhvp").val());
        });
        $("#chucvu").keyup(function () {
            $(".textchucvu").html($("#chucvu").val());
        }).change(function () {
            $(".textchucvu").html($("#chucvu").val());
        });
        $("#chucvu").hide();
        $("#btnSuaTenChucVu").click(function () {
            if ($(this).hasClass("icon-check")) {
                $("#textchucvu").show();
                $("#chucvu").hide(); $(this).attr("class", "icon-pencil");
                return false;

            }
            $("#textchucvu").hide();
            $("#chucvu").show();
            $("#btnSuaTenChucVu").attr("class", "icon-check");
        })
    });
</script>
<style type="text/css">
   div#divPrint > .table.table-bordered thead > tr > th {
        border-bottom: 0;
        font-weight: bold !important;
        font-size: 13px;
    }

   div#divPrint > .table-bordered > thead > tr > td, .table-bordered > thead > tr > th {
        border-bottom-width: 2px;
    }

   div#divPrint > .table-bordered > tbody > tr > td, .table-bordered > tbody > tr > th, .table-bordered > tfoot > tr > td, .table-bordered > tfoot > tr > th, .table-bordered > thead > tr > td, .table-bordered > thead > tr > th {
        border: 1px solid #333;
    }

   div#divPrint  .text-center {
        text-align: center;
    }

   div#divPrint > .table > tbody > tr > td, .table > tbody > tr > th, .table > tfoot > tr > td, .table > tfoot > tr > th, .table > thead > tr > td, .table > thead > tr > th {
        padding: 8px;
        line-height: 1.42857143;
        vertical-align: top;
        border-top: 1px solid #333;
    }
</style>

<div id="mautotrinh">
    <table style="width: 100%">
        <tbody>
            <tr>
                <td style="text-align: left; width: 60%; font-size: 14px;">
                    <b><%=CurrentUser.DonViID==1?"VĂN PHÒNG NHNN":CurrentUser.TenDonVi %></b><br>
                    <div style="margin-left: 10px !important; font-weight: bold">Số: <%:VanBanDenItem.ThuTu %></div>
                </td>
                <td style="font-weight: bold; font-style: italic; float: right">Hà Nội, ngày <%= DateTime.Now.Day %> tháng <%= DateTime.Now.Month %> năm <%= DateTime.Now.Year %>
                </td>
            </tr>
            <tr style="margin-top: 20px;">
                <td colspan="2" style="text-align: center; text-transform: uppercase; font-weight: bold; font-size: 16px; padding-top: 20px">PHIẾU TRÌNH</td>
            </tr>
            <tr>
                <td style="text-align: center; font-size: 14px; padding-bottom: 10px; font-weight: bold; font-style: italic;"><u>Kính trình:</u>

                </td>
                <td style="padding-bottom: 10px; padding-left: 10px; font-size: 14px; font-weight: bold; font-style: italic">
                    <input name="LtsNguoiDung" id="LtsNguoiDung" class="m-wrap span12" spellcheck="false" /></td>
            </tr>
        </tbody>
    </table>

    <table class="table table-bordered table-responsive">
        <thead>
            <tr>
                <th style="width: 60%" class="text-center">Nội dung</th>
                <th style="width: 40%" class="text-center">Ý kiến của lãnh đạo</th>
            </tr>
            <tr>
                <td class="portlet-body">
                    <div class="marginB-20">
                        Ngày <%=string.Format("{0:dd/MM/yyyy}",VanBanDenItem.NgayDen) %>, <%=CurrentUser.DonViID==1?"VĂN phòng NHNN":CurrentUser.TenDonVi %> nhận được công văn số: <%=VanBanDenItem.SoKyHieu %> (<%=string.Format("{0:dd/MM/yyyy}",VanBanDenItem.NgayBanHanh) %>) của
                    </div>
                    <div class="text-center marginB-20">
                        <b><%=VanBanDenItem.CoQuanBanHanhText %></b>
                        <br>
                    </div>
                    <div class="marginB-20">
                        V/v: <%=VanBanDenItem.TrichYeu %>
                    </div>
                    <div class="text-center marginB-20">
                        Kính trình đồng chí cho ý kiến giải quyết
                                                <br>
                        <span class="textchucvu" id="textchucvu">CHÁNH VĂN PHÒNG</span>
                        <input type="text" id="chucvu" placeholder="Nhập chức vụ"
                            style="font-family: 'Times New Roman;'; font-size: 16px; color: #000; width: 255px; margin-left: 25px;"
                            spellcheck="false" value="Chánh văn phòng" />
                        &nbsp;<i class="icon-pencil" id="btnSuaTenChucVu" style="font-size: 11px; cursor: pointer"></i>
                        <div style="margin: 0px 0px 23px"></div>
                        <input type="text" id="tenchanhvp" placeholder="Nhập tên Lãnh đạo văn phòng"
                            style="font-family: 'Times New Roman;'; font-size: 16px; color: #000"
                            spellcheck="false" />
                    </div>
                    Ghi chú:
                        <br />
                    <ul>
                        <li>Độ khẩn: <%=VanBanDenItem.LtsDanhMucGiaTri[0].Ten %></li>
                        <li>Thời hạn xử lý: <b><%=VanBanDenItem.HanXuLy.HasValue? string.Format("{0:dd/MM/yyyy}",VanBanDenItem.HanXuLy.Value):"" %></b></li>
                    </ul>
                </td>
                <td rowspan="3" class="portlet-body"></td>
            </tr>
            <tr>
                <td class="text-center"><b>Xử lý của Văn Phòng</b></td>
            </tr>
            <tr>
                <td class="portlet-body">
                    <div style="margin-bottom: 90px">
                    </div>
                    <div>Ngày, giờ chuyển Đơn vị chức năng: </div>
                </td>
            </tr>
            <tr>
                <td colspan="2" class="text-center"><b>Xử lý của Đơn vị chức năng</b></td>
            </tr>
            <tr>
                <td colspan="2">
                    <div style="margin-bottom: 150px"></div>
                </td>
            </tr>
        </thead>
    </table>

</div>
<div id="divPrint" style="display: none">
    <table style="width: 100%">
        <tbody>
            <tr>
                <td style="text-align: left; width: 60%; font-size: 14px;">
                    <b><%=CurrentUser.DonViID==1?"VĂN PHÒNG NHNN":CurrentUser.TenDonVi %></b><br>
                    <div style="margin-left: 10px !important; font-weight: bold">Số: <%:VanBanDenItem.ThuTu %></div>
                </td>
                <td style="font-weight: bold; font-style: italic; float: right">Hà Nội, ngày <%= DateTime.Now.Day %> tháng <%= DateTime.Now.Month %> năm <%= DateTime.Now.Year %>
                </td>
            </tr>
            <tr style="margin-top: 20px;">
                <td colspan="2" style="text-align: center; text-transform: uppercase; font-weight: bold; font-size: 16px; padding-top: 20px">PHIẾU TRÌNH</td>
            </tr>
            <tr>
                <td style="text-align: center; font-size: 14px; padding-bottom: 10px; font-weight: bold; font-style: italic;"><u>Kính trình:</u>

                </td>
                <td style="padding-bottom: 10px; padding-left: 10px; font-size: 14px; font-weight: bold; font-style: italic"><span id="textkinhtrinh"></span></td>
            </tr>
        </tbody>
    </table>

    <table style="min-height: .01%; overflow-x: auto; width: 100%; max-width: 100%; margin-bottom: 0px; border: 1px solid #e0d7cd;">
        <thead>
            <tr>
                <th style="width: 60%; text-align: center; border-bottom: 0; font-weight: bold !important; font-size: 13px;">Nội dung</th>
                <th style="width: 40%; text-align: center; border-bottom: 0; font-weight: bold !important; font-size: 13px;">Ý kiến của lãnh đạo</th>
            </tr>
            <tr>
                <td class="portlet-body">
                    <div class="marginB-20">
                        Ngày <%=string.Format("{0:dd/MM/yyyy}",VanBanDenItem.NgayDen) %>, <%=CurrentUser.DonViID==1?"VĂN phòng NHNN":CurrentUser.TenDonVi %> nhận được công văn số: <%=VanBanDenItem.SoKyHieu %> (<%=string.Format("{0:dd/MM/yyyy}",VanBanDenItem.NgayBanHanh) %>) của
                    </div>
                    <div class="text-center marginB-20">
                        <b><%=VanBanDenItem.CoQuanBanHanhText %></b>
                        <br>
                    </div>
                    <div class="marginB-20">
                        V/v: <%=VanBanDenItem.TrichYeu %>
                    </div>
                    <div class="text-center marginB-20">
                        Kính trình đồng chí cho ý kiến giải quyết
                                                <br>
                        <span class="textchucvu" style="font-size: 13px; font-weight: bold">CHÁNH VĂN PHÒNG</span>

                        <div style="height: 34px;">
                            <span id="textchanhvp"></span>
                        </div>
                    </div>
                    Ghi chú:
                        <br />
                    <ul>
                        <li>Độ khẩn: <%=VanBanDenItem.LtsDanhMucGiaTri[0].Ten %></li>
                        <li>Thời hạn xử lý: <b><%=VanBanDenItem.HanXuLy.HasValue? string.Format("{0:dd/MM/yyyy}",VanBanDenItem.HanXuLy.Value):"" %></b></li>
                    </ul>
                </td>
                <td rowspan="3" class="portlet-body"></td>
            </tr>
            <tr>
                <td class="text-center"><b>Xử lý của Văn Phòng</b></td>
            </tr>
            <tr>
                <td class="portlet-body">
                    <div style="margin-bottom: 90px">
                    </div>
                    <div>Ngày, giờ chuyển Đơn vị chức năng: </div>
                </td>
            </tr>
            <tr>
                <td colspan="2" class="text-center"><b>Xử lý của Đơn vị chức năng</b></td>
            </tr>
            <tr>
                <td colspan="2">
                    <div style="margin-bottom: 150px"></div>
                </td>
            </tr>
        </thead>
    </table>
</div>
