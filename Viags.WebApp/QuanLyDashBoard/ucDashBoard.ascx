<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucDashBoard.ascx.cs" Inherits="Viags.WebApp.QuanLyDashBoard.ucDashBoard" %>
<script>
    urlLists = "/QuanLyDashBoard/NhanVienXuatSac/AjaxList.aspx";
    urlListsCaiTien = "/QuanLyDashBoard/CaiTien/AjaxList.aspx";

    urlForm = "/QuanLyDashBoard/NhanVienXuatSac/AjaxForm.aspx";
    urlFormCaiTien = "/QuanLyDashBoard/CaiTien/AjaxForm.aspx";

    urlPostAction = "/QuanLyDashBoard/NhanVienXuatSac/Action.ashx";
    urlPostActionCaiTien = "/QuanLyDashBoard/NhanVienXuatSac/Action.ashx";
    $(document).ready(function () {

        bindHotkey();
        initAjaxLoad(urlLists, '#table-nhanvienxuatsac', "NhanVienXuatSac");
        initAjaxLoad(urlListsCaiTien, '#table-caitien', "CaiTien");
        $("#btnSearch").click(function () {
            focusGridview();
            //fix trường hợp: enter khi chuyển trang
            var inputname = '';
            $("input:focus").each(function () {
                inputname = $(this).attr('name');
            });
            if (inputname != 'page') {
                debugger
                var urlLists_search = urlLists + "?" + $("#gridSearch").mySerialize();
                LoadAjaxPage(urlLists_search, '#table-nhanvienxuatsac');
                return false;
            }
            else
                return false;
        });

        $("#btnSearch1").click(function () {
            focusGridview();
            //fix trường hợp: enter khi chuyển trang
            var inputname = '';
            $("input:focus").each(function () {
                inputname = $(this).attr('name');
            });
            if (inputname != 'page') {
                var urlListsCaiTien_search = urlListsCaiTien + "?" + $("#gridSearch1").mySerialize();
                LoadAjaxPage(urlListsCaiTien_search, '#table-caitien');
                return false;
            }
            else
                return false;
        });

        $('#SearchIn').select2();
        $('#Thang').select2();
        $('#Quy').select2();
        $('#Nam').select2();
        $('#AddNhanVienXuatSac').on('click', function (ev) {
            ev.preventDefault();
            $('body').modalmanager('loading');
            $('#dialog-form').load(urlForm, function () {
                $('#dialog-form').modal({ width: 650 });
            });
        });
        $('#AddCaiTien').on('click', function (ev) {
            ev.preventDefault();
            $('body').modalmanager('loading');
            $('#dialog-form').load(urlFormCaiTien, function () {
                $('#dialog-form').modal({ width: 650 });
            });
        });

        $("#btnExportNhanVienXuatSac").click(function () {
            window.location.href = '/QuanLyDashBoard/NhanVienXuatSac/AjaxList.aspx?do=excel';
        })
    });

    function Change1() {
        urlPostAction = "/QuanLyDashBoard/NhanVienXuatSac/Action.ashx";
        refreshList();
    }
    function Change2() {
        urlPostAction = "/QuanLyDashBoard/NhanVienXuatSac/Action.ashx";
        refreshList();
    }

    function refreshList() {
        LoadAjaxPage(urlLists + "#RowPerPage=10&PageStep=3&Field=ID&FieldOption=0&Keyword=&SearchIn=&Page=1", '#table-nhanvienxuatsac');
        LoadAjaxPage(urlListsCaiTien + "#RowPerPage=10&PageStep=3&Field=ID&FieldOption=0&Keyword=&SearchIn=&Page=1", '#table-caitien');
    }
</script>
<div class="row">
    <div class="col-md-12 col-sm-12 ">
        <ol class="breadcrumb ">
            <li><a href="/Pagess/Home.aspx"><%=Resources.TaiKhoan.lblTrangChu %></a></li>
            <li><a href="javascript:;"><%=Resources.TaiKhoan.lblHeThong %></a></li>
            <li><a href="/Pagess/so-van-ban.aspx"><%=Resources.TaiKhoan.lblSoVanBan %></a></li>
        </ol>
    </div>
</div>
<div class="row">
    <div class="col-md-12 col-sm-12">
        <div class="portlet content-padding">
            <div class="portlet-title">
                <div class="caption">
                    DASHBOARD
                </div>
            </div>

            <%--tab region--%>
            <ul class="nav nav-tabs">

                <li class="active">
                    <a onclick="Change1()" href="#NhanVienXuatSacTab" data-toggle="tab" aria-expanded="false">Nhân viên xuất sắc</a>
                </li>
                <%--  <li class="">
                    <a onclick="Change2()" href="#CaiTienTab" data-toggle="tab" aria-expanded="false">Cải tiến</a>
                </li>--%>
            </ul>
            <%--tab region--%>
            <div class="tab-content">
                <%--tabDanhMucCa--%>
                <div class="tab-pane fade active in" id="NhanVienXuatSacTab">
                    <div class="action-bar">
                        <div class="box-search">
                            <a id="btnExportNhanVienXuatSac" class="btn brown btn-fix-height"><i class="fa fa-print"></i>&nbsp; Xuất Excel</a>
                            <a id="AddNhanVienXuatSac" class="btn brown btn-fix-height"><i class="fa fa-plus"></i>&nbsp;<%=Resources.TaiKhoan.lblThemMoi %></a>
                            <a id="opensearch" class="btn brown btn-fix-height"><i class="fa fa-search"></i>&nbsp;<%=Resources.TaiKhoan.lblTimKiem %></a>
                        </div>
                        <div class="clearfix"></div>
                    </div>
                    <div id="gridSearch">
                        <form>
                            <div class="content-border content-padding">

                                <div class="row">
                                    <div class="col-md-12 col-sm-12">
                                        <div class="form-horizontal">
                                            <div class="row">
                                                <div class="col-md-6 col-sm-6">
                                                    <div class="form-group">
                                                        <label class="col-sm-4 control-label">
                                                            <%=Resources.TaiKhoan.lblPhamVi %>
                                                        </label>
                                                        <div class="col-sm-8">
                                                            <select name="SearchIn" id="SearchIn" data-placeholder="<%=Resources.TaiKhoan.lblChonPhamViTimKiem %>" class="chosen span6 form-control" multiple="multiple" tabindex="6">
                                                                <optgroup label="Tìm kiếm trong">
                                                                    <option value="MaNV" selected>Mã nhân viên</option>
                                                                    <option value="TenNguoiDung" selected>Tên nhân viên</option>
                                                                    <option value="TenPhongBan" selected>Tên phòng ban</option>
                                                                    <option value="TenDonVi" selected>Tên đơn vị</option>
                                                                </optgroup>
                                                            </select>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-6 col-sm-6">
                                                    <div class="form-group">
                                                        <label class="col-sm-4 control-label">
                                                            <%=Resources.TaiKhoan.lblTuKhoa %>
                                                        </label>
                                                        <div class="col-sm-8">
                                                            <input class="form-control" type="text" id="Keyword" name="Keyword" placeholder="<%=Resources.TaiKhoan.lblNhapTuKhoaTimKiem %>">
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="clearfix"></div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-4 col-sm-4">
                                                    <div class="form-group">
                                                        <label class="col-sm-4 control-label">
                                                            Quý
                                                        </label>
                                                        <div class="col-sm-8">
                                                            <select class="chosen span6 form-control" id="Quy" name="Quy">
                                                                <option value="0">Chọn quý</option>
                                                                <option value="1">Quý 1</option>
                                                                <option value="2">Quý 2</option>
                                                                <option value="3">Quý 3</option>
                                                                <option value="4">Quý 4</option>
                                                            </select>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="col-md-4 col-sm-4">
                                                    <div class="form-group">
                                                        <label class="col-sm-4 control-label">
                                                            Tháng
                                                        </label>
                                                        <div class="col-sm-8">
                                                            <select class="chosen span6 form-control" id="Thang" name="Thang">
                                                                <option value="0">Chọn tháng</option>
                                                                <option value="1">Tháng 1</option>
                                                                <option value="2">Tháng 2</option>
                                                                <option value="3">Tháng 3</option>
                                                                <option value="4">Tháng 4</option>
                                                                <option value="1">Tháng 5</option>
                                                                <option value="2">Tháng 6</option>
                                                                <option value="3">Tháng 7</option>
                                                                <option value="4">Tháng 8</option>
                                                                <option value="1">Tháng 9</option>
                                                                <option value="2">Tháng 10</option>
                                                                <option value="3">Tháng 11</option>
                                                                <option value="4">Tháng 12</option>
                                                            </select>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="col-md-4 col-sm-4">
                                                    <div class="form-group">
                                                        <label class="col-sm-4 control-label">
                                                            Năm
                                                        </label>
                                                        <div class="col-sm-8">
                                                            <select class="chosen span6 form-control" id="Nam" name="Nam">
                                                                <%for (var i = 2018; i < 2100; i++)
                                                                    {%>
                                                                <option value="<%=i %>" <%=DateTime.Now.Year== i ? "selected" : "" %>><%=i %></option>
                                                                <%} %>
                                                            </select>

                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="clearfix"></div>
                                            </div>
                                            <div class="row" style="text-align: center">
                                                <button type="button" id="btnSearch" name="Search" class="btn brown"><i class="fa fa-search"></i>&nbsp;<%=Resources.TaiKhoan.lblTimKiem %></button>
                                                <button type="button" id="btnclosesearch" class="btn red">
                                                    <i class="fa fa-remove"></i>&nbsp;<%=Resources.TaiKhoan.lblDongLai %>
                                                </button>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </form>
                    </div>
                    <div id="table-nhanvienxuatsac" class="portlet-body_deletecss  content-border_deletecss">
                    </div>
                </div>
                <%--tabDanhMucCa--%>
                <%--tabThietLapGiaCom--%>
                <%--<div class="tab-pane fade" id="CaiTienTab">
                    <div class="action-bar">
                        <div class="box-search">
                            <a id="AddCaiTien" class="btn brown btn-fix-height"><i class="fa fa-plus"></i>&nbsp;<%=Resources.TaiKhoan.lblThemMoi %></a>
                            <a id="opensearch1" class="btn brown btn-fix-height"><i class="fa fa-search"></i>&nbsp;<%=Resources.TaiKhoan.lblTimKiem %></a>
                        </div>
                        <div class="clearfix"></div>
                    </div>
                    <div id="gridSearch1">
                        <form>
                            <div class="content-border content-padding">

                                <div class="row">
                                    <div class="col-md-12 col-sm-12">
                                        <div class="form-horizontal">
                                            <div class="row">
                                                <div class="col-md-6 col-sm-6">
                                                    <div class="form-group">
                                                        <label class="col-sm-4 control-label">
                                                            <%=Resources.TaiKhoan.lblPhamVi %>
                                                        </label>
                                                        <div class="col-sm-8">
                                                            <select name="SearchIn" id="SearchIn" data-placeholder="<%=Resources.TaiKhoan.lblChonPhamViTimKiem %>" class="chosen span6 form-control" multiple="multiple" tabindex="6">
                                                                <optgroup label="Tìm kiếm trong">
                                                                </optgroup>
                                                            </select>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-6 col-sm-6">
                                                    <div class="form-group">
                                                        <label class="col-sm-4 control-label">
                                                            <%=Resources.TaiKhoan.lblTuKhoa %>
                                                        </label>
                                                        <div class="col-sm-8">
                                                            <input class="form-control" type="text" id="Keyword" name="Keyword" placeholder="<%=Resources.TaiKhoan.lblNhapTuKhoaTimKiem %>">
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="clearfix"></div>
                                            </div>
                                            <div class="row" style="text-align: center">
                                                <button type="button" id="btnSearch1" name="Search" class="btn brown"><i class="fa fa-search"></i>&nbsp;<%=Resources.TaiKhoan.lblTimKiem %></button>
                                                <button type="button" id="btnclosesearch1" class="btn red">
                                                    <i class="fa fa-remove"></i>&nbsp;<%=Resources.TaiKhoan.lblDongLai %>
                                                </button>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </form>
                    </div>
                    <div id="table-caitien" class="portlet-body_deletecss  content-border_deletecss">
                    </div>
                </div>--%>
                <%--tabThietLapGiaCom--%>
            </div>
        </div>
    </div>
</div>
