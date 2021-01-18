<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucListTaiXe.ascx.cs" Inherits="Viags.WebApp.Transit.DanhSachTaiXe.ucListTaiXe" %>

<script type="text/javascript">

    urlLists = "/Transit/DanhSachTaiXe/AjaxListTaiXe.aspx";

    urlForm = "/Transit/DanhSachTaiXe/AjaxFormTaiXe.aspx";

    urlPostAction = "/Transit/DanhSachTaiXe/Action.ashx";

    
 

    $(document).ready(function () {

        bindHotkey();
        initAjaxLoad(urlLists, '#gridview-container', "gridDanhMuc");

        
        $("#btnSearch").click(function () {
            focusGridview();
            //fix trường hợp: enter khi chuyển trang
            var inputname = '';
            $("input:focus").each(function () {
                inputname = $(this).attr('name');
            });
            if (inputname != 'page') {
                //window.location.href = '#' + $("#gridSearch").mySerialize();
                var urlLists_search = urlLists + "?" + $("#gridSearch").mySerialize();
                LoadAjaxPage(urlLists_search, '#gridview-container');
                return false;
            }
            else
                return false;
        });
                       

        $('#SearchIn').select2();


        $('#btnAddForm').on('click', function (ev) {
            ev.preventDefault();
            $('body').modalmanager('loading');
            $('#dialog-form').load(urlForm, function () {
                $('#dialog-form').modal({ width: 650 });
            });
        });
 
     
    });
       
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
                    Thiết lập chung
                </div>
            </div>

            <%--tab region--%>
            <ul class="nav nav-tabs">


                <li class="active">
                    <a  href="#DanhMucCaTab" data-toggle="tab" aria-expanded="false">Danh sách tài xế</a>
                </li>        
                  
            </ul>
            <%--tab region--%>
            <div class="tab-content">
                <%--tabDanhMucCa--%>
                <div class="tab-pane fade active in" id="DanhMucCaTab">
                    <div class="action-bar">
                        <div class="box-search">
                            <a id="btnAddForm" class="btn brown btn-fix-height"><i class="fa fa-plus"></i>&nbsp;<%=Resources.TaiKhoan.lblThemMoi %></a>
                            <a id="opensearch" class="btn brown btn-fix-height"><i class="fa fa-search"></i>&nbsp;<%=Resources.TaiKhoan.lblTimKiem %></a>
                            <a href="/Pagess/transit.aspx" class="btn brown btn-fix-height">DS điều phối</a>
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
                                                                    <option value="TenDanhMuc" selected>Tên ca</option>
                                                                    <option value="MoTa"><%=Resources.TaiKhoan.lblMoTa %></option>
                                                                    <option value="TenNguoiTao">Người tạo</option>

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
                                                <div class="col-md-6 col-sm-6">
                                                </div>
                                                <div class="col-md-6 col-sm-6">
                                                    <div class="form-group">
                                                        <label class="col-sm-4 control-label">
                                                            Trạng Thái
                                                        </label>
                                                        <div class="col-sm-8">
                                                            <select name="TrangThai" id="TrangThai" data-placeholder="<%=Resources.TaiKhoan.lblChonPhamViTimKiem %>" class="chosen span6 form-control">
                                                                <option value="1" selected>Đang dùng</option>
                                                                <option value="0">Không dùng</option>
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
                    <div id="gridview-container" class="portlet-body_deletecss  content-border_deletecss">
                    </div>
                </div>        
            </div>
        </div>
    </div>
</div>


<script>

</script>