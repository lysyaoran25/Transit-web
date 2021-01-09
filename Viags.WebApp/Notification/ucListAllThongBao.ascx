<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucListAllThongBao.ascx.cs" Inherits="Viags.WebApp.Notification.ucListAllThongBao" %>

<script type="text/javascript">

    const currentuserID = <%=CurrentUser.ID%>

    urlLists = "/Notification/pListAllThongBao.aspx";
    urlPostAction = "/Notification/Action.ashx";
    gridContainer = '#gridDanhMuc';
    $(document).ready(function () {
        bindHotkey();
        initAjaxLoad(urlLists, '#gridview-container', '#gridDanhMuc');

        $("#btnSearch").click(function () {
            focusGridview();
            //fix trường hợp: enter khi chuyển trang
            var inputname = '';
            $("input:focus").each(function () {
                inputname = $(this).attr('name');
            });
            if (inputname != 'page') {
                window.location.href = '#' + $("#gridSearch").mySerialize();
                return false;
            }
            else
                return false;
        });
        $("#btnRead").click(function () {
            ReadNotification();
        });
        $('#SearchIn').select2();
    });
    function ReadNotification() {
        var arrRowId = '';
        var rowTitle = '';
        var _url = window.location + "";
        var _index = _url.indexOf("#");
        var linkFW = (_index < 0) ? '#Page=1' : (_url + '&temp=' + Math.floor(Math.random() * 11) + '');
        $("#gridDanhMuc input[type='checkbox']:checked").not("#checkAll").not(".checkAll").each(function () {
            arrRowId += $(this).val() + ",";
            rowTitle += "<li>" + escapeHTML($(this).parent().parent().attr("title")) + "</li>";
        });
        rowTitle = "<ul>" + rowTitle + "</ul>";
        arrRowId = (arrRowId.length > 0) ? arrRowId.substring(0, arrRowId.length - 1) : arrRowId;

        var urlCapNhatTrangThai = "/Notification/Action.ashx?do=request&ItemId=" + arrRowId;
        $.post(urlCapNhatTrangThai, function (data) {
            if (data.Error) {
                createMessage('"<%=Resources.CongViec.lblDaCoLoiXayRa %>"', data.Title); // Tạo thông báo lỗi
            }
            else {
                createCloseMessage2('"<%=Resources.CongViec.lblThongBao %>"', data.Title, '/Pagess/danh-sach-notification.aspx'); // Tạo thông báo lỗi
            }
        });

    }


</script>
<div class="row">
    <div class="col-md-12 col-sm-12 ">
        <ol class="breadcrumb ">
            <li><a href="/Pagess/Home.aspx"><%=Resources.Notification.lblTrangChu %></a></li>
            <li><a href="/Pagess/danh-sach-notification.aspx"><%=Resources.Notification.lblThongBaoCuaBan %></a></li>
        </ol>
    </div>
</div>
<div class="row">
    <div class="col-md-12 col-sm-12">
        <div class="portlet content-padding">
            <div class="portlet-title">
                <div class="caption">
                    <%=Resources.Notification.lblThongBaoCuaBan %>
                </div>
            </div>
            <div class="action-bar">

                <div class="box-search">
                    <a id="opensearch" class="btn brown btn-fix-height"><i class="fa fa-search"></i><%=Resources.Notification.lblTimKiem %></a>
                    <a id="btnRead" class="btn brown btn-fix-height"><%=Resources.Notification.lblCapNhatDaDoc %></a>
                    <a data-toggle="modal" data-target="#modalNotification" id="clearNotification" class="btn brown btn-fix-height"><%=Resources.Notification.lblClearNotification %></a>
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
                                                    <%=Resources.Notification.lblPhamVi %>
                                                </label>
                                                <div class="col-sm-8">
                                                    <select name="SearchIn" id="SearchIn" data-placeholder="<%=Resources.Notification.lblChonPhamViTimKiem %>" class="chosen span6" multiple="multiple" tabindex="6">
                                                        <optgroup label="<%=Resources.Notification.lblTimKiemTrong %>">
                                                            <option value="NoiDung" selected><%=Resources.Notification.lblNoiDung %></option>
                                                        </optgroup>
                                                    </select>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6 col-sm-6">
                                            <div class="form-group">
                                                <label class="col-sm-4 control-label">
                                                    <%=Resources.Notification.lblTuKhoa %>
                                                </label>
                                                <div class="col-sm-8">
                                                    <input class="form-control" type="text" id="Keyword" name="Keyword" placeholder="<%=Resources.Notification.lblNhapTuKhoaTimKiem %>">
                                                </div>
                                            </div>
                                        </div>
                                        <div class="clearfix"></div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-6 col-sm-6">
                                            <div class="form-group">
                                                <label class="col-sm-4 control-label">
                                                    <%=Resources.Notification.lblChucNang %>
                                                </label>
                                                <div class="col-sm-8">
                                                    <select tabindex="0" name="ChucNangID" id="ChucNangID" class="select2 form-control">
                                                        <option value=""><%=Resources.Notification.lblChonChucNang %></option>
                                                        <option value="1"><%=Resources.Notification.lblVanBanDen %></option>
                                                        <option value="2"><%=Resources.Notification.lblVanBanDi %></option>
                                                        <option value="3"><%=Resources.Notification.lblDuThao %></option>
                                                        <option value="4"><%=Resources.Notification.lblChuongTrinhCongTac %></option>
                                                        <option value="5"><%=Resources.Notification.lblXuLyKienNghi %></option>
                                                        <option value="6"><%=Resources.Notification.lblLichLamViec %></option>
                                                        <option value="7"><%=Resources.Notification.lblDatPhong %></option>
                                                        <option value="8"><%=Resources.Notification.lblCongViec %></option>
                                                        <option value="17"><%=Resources.Notification.lblDatXe %></option>
                                                        <option value="18"><%=Resources.TinTuc.lblTinTuc %></option>
                                                        <option value="19"><%=Resources.ThongBao.lblThongBao %></option>
                                                        <option value="21">Đặt cơm</option>
                                                        <option value="22">Nghỉ phép</option>
                                                        <option value="23">Lịch đặt phòng</option>
                                                        <option value="24">Trung tâm giải đáp</option>
                                                    </select>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6 col-sm-6">
                                        </div>
                                        <div class="clearfix"></div>
                                    </div>
                                    <div class="row" style="text-align: center">
                                        <button type="submit" id="btnSearch" name="submit.Search" class="btn brown"><i class="icon-search"></i><%=Resources.Notification.lblTimKiem %></button>
                                        <button type="button" id="btnclosesearch" class="btn red">
                                            <i class="icon-remove"></i><%=Resources.Notification.lblDong %></button>
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

<div id="modalNotification" class="modal fade modal-overflow in" tabindex="-1" data-keyboard="false">
    <div class="modal-dialog" role="document">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true"></button>
                <h4 class="modal-title">Xóa tất cả thông báo</h4>
            </div>
            <div class="modal-body">Bạn muốn xóa tất cả thông báo ?</div>
            <div class="modal-footer">
                <button type="button" id="btnSubmitNotification" class="btn red" data-dismiss="modal" tabindex="8"><b>Đ</b>ồng ý</button>
                <button type="button" id="btnCancelNotification" style="color: black" class="btn" data-dismiss="modal" tabindex="8"><b>H</b>ủy</button>
            </div>
        </div>
    </div>
</div>

<script>

    $('#btnSubmitNotification').on('click', function () {
        clearNotifications();
    });

    function clearNotifications() {
        $.ajax({
            type: "POST",
            url: "/api/notification.asmx/clearnotification",
            data: "{currentuserID:'" + currentuserID + "'}", //must have
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (msg) {

                location.reload();
            }
        });
    }

</script>
