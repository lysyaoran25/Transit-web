<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AjaxFormThemDonHang.aspx.cs" Inherits="Viags.WebApp.Transit.DieuPhoi.AjaxFormThemDonHang" %>

<script defer="defer" src="/Transit/asset/DieuPhoi/AjaxFormThemDonHang.js"></script>
<script type="text/javascript">

    $(document).ready(function () {

        if (event.keyCode == 27) {
            $("#btnCloseModal").click();
        }
        $("#btnCloseModal").click();

        $(".NhomNguoiDungID").select2();
        $("#MaTaiLieu").prop("readonly", true);

        ChangeKhuVuc();

    });
    $(document).bind('keypress', 'd', function (evt) {
        $('#btnCloseModal').click();
    });


    var type = "";
    function submitform(duyet) {
        type = duyet;
        $("#btnAddModal").click();
    }
    $(function () {
        $(document).keydown(function (event) {
            if (event.keyCode == 27) {
                $("#btnCloseModal").click();
            }
        });

        setTimeout(function () {
            $("#Ten").focus()
        }, 100)

        $("#FormBaoCao").validate({
            rules: {
                BaoCaoTen: { required: true, minlength: 3, maxlength: 255 },
                BaoCaoNoiDung: { maxlength: 2000 },
                BaoCaoLoaiID: { required: true },

            },
            submitHandler: function () {
                debugger

                //onSubmit
                $.post(urlPostAction, $("#FormBaoCao").mySerialize() + "&type=" + type, function (data) {
                    //Trường hợp thêm bình thường
                    if (data.Error) {
                        $("#FormMessage").html('<div class="alert alert-danger">' + data.Title + '</div>');
                        ClearMessage("#FormMessage", "");
                    }

                    else {
                        $("#btnCloseModal").click();
                        createCloseMessage2("<%=Resources.CongViec.lblThongBao %>", data.Title, "/BaoCaoCongViec/BaoCaoCuaDonVi/Default.aspx"); // Tạo thông báo khi click đóng thì chuyển đến url đích
                    }

                });
                return false;
            }
        });

        unbindHotkey();
        $('#dialog-form').on('hidden', function (ev) {
            bindHotkey();
        });

            <% if (ActionType == Viags.Utils.TypeOfAction.Add)
    { %>
        $(document).bind('keypress', 't', function (evt) {
            $('#btnAddModal').click();
            return false;
        });
        $(document).bind('keypress', 'l', function (evt) {
            $('#cbxAddMutil').click();
            return false;
        });
            <% }
    else
    { %>
        $(document).bind('keypress', 'c', function (evt) {
            $('#btnAddModal').click();
            return false;
        });
            <% } %>
        $(document).bind('keypress', 'n', function (evt) {
            $('#btnResetModal').click();
            return false;
        });
        $(document).bind('keypress', 'd', function (evt) {
            $('#btnCloseModal').click();
        });
        ///Reset form
        $('#btnResetModal').click(function () {
            $("#Ten").focus();
               <% if (ActionType == Viags.Utils.TypeOfAction.Add)
    { %>
            $("#listFileAttach").html('')
            $("#listValueFileAttach").val("");
                <%}%>
            setTimeout(function () {
                $('#FormBaoCao select').select2("destroy").select2();
            }, 100);
        });


        $("#FormBaoCao select").select2();



    });

    $('textarea').focus(function () {
        $(".form-group").addClass("is-focused");
    });
    $('input').focus(function () {
        $(".form-group").addClass("is-focused");
    });

    $("#NhomNguoiNhan").select2();


    $("#ListNguoiNhan").select2();


    //datetime
    $("#NgayBatDauHop").datepicker({
        format: "dd/mm/yyyy",
        autoclose: true,
    }).change(function () {
        $(this).datepicker('hide');


    });

    $("#NgayBatDauHop").datepicker('setDate', '<%:string.Format("{0:dd/MM/yyyy }",DateTime.Now)%>');
    $("#NgayBatDauHop").datepicker('setStartDate', '<%:string.Format("{0:dd/MM/yyyy}",DateTime.Now)%>');




</script>
<style>
    .panel .list-panel {
        padding-left: 15px;
        padding-right: 15px;
    }

    .custom-contain {
        border-radius: 10px !important;
        border: 1px solid #b2bec3;
        padding: 10px 20px;
        margin-top: 10px;
        margin-bottom: 10px;
        margin-right: 0 !important;
        margin-left: 0 !important;
    }

    #FormBaoCao .form-control {
        height: 38px !important;
        border-top: 1px solid #b2bec3 !important;
        border-bottom: 1px solid #b2bec3 !important;
        border-right: 1px solid #b2bec3 !important;
        border-left: 1px solid #b2bec3 !important;
        border-radius: 5px !important;
        padding-left: 10px !important;
        padding-right: 10px !important;
    }

    #FormBaoCao .select2-container .select2-choice {
        line-height: 31px !important;
    }
</style>
<form id="FormBaoCao" class="form-horizontal" action="#">

    <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-hidden="true"></button>
        <h4 class="modal-title"><%=ActionText %> Thông tin đơn hàng</h4>
    </div>
    <div class="modal-body">

        <input type="hidden" name="do" id="do" value="<%=DoAction%>" />
        <input type="hidden" name="ItemId" id="ItemId" value="<%=ItemID%>" />

        <div id="FormMessage"></div>

        <div class="form-horizontal">


            <!-- Lưu ý-->
            <div class="row">
                <div class="col-md-12 col-sm-12" style="text-align: center; font-size: 14px; font-weight: 500; font-style: italic">
                    <b><%=Resources.CongViec.lblLuuY %>:</b> <%=Resources.CongViec.lblCacTruongCoDau %> <span class="required">*</span> <%=Resources.CongViec.lblBatBuocNhapThongTin %>
                </div>
            </div>
            <!-- Lưu ý-->

            <div class="row custom-contain">

                <!-- Loại báo cáo/Mã báo cáo -->
                <div class="form-row">

                    <div class="form-group col-md-6">
                        <label class="control-label">
                            Thời gian xe khởi hành<span class="required" aria-required="true">*</span>
                        </label>
                        <select id="LoaiTaiLieuID" name="LoaiTaiLieuID" class="select2 form-control">
                            <option value="">Chọn khung giờ xe chạy</option>
                            <%foreach (var item in new List<int>() { 1, 2, 3 })
                                {%>
                            <option value="<%=item %>">item </option>
                            <%}%>
                        </select>
                    </div>

                    <!-- Ngày bắt đầu -->
                    <div class="form-group col-md-6">
                        <label class="control-label">
                            Ngày đi <span class="required" aria-required="true">*</span>
                        </label>
                        <input class="form-control" name="NgayBatDauHop" id="NgayBatDauHop" autocomplete="off" value="<%:string.Format("{0:dd/MM/yyyy}",DateTime.Now) %>" />
                    </div>
                    <!-- Ngày bắt đầu -->

                </div>
                <!-- Loại báo cáo/Mã báo cáo -->

                <!-- Người duyệt-->

                <div class="col-md-12 col-sm-12" id="divLoai">
                </div>

                <!-- Tên báo cáo -->

                <div class="form-row">
                    <div class="form-group col-md-12">
                        <label class="control-label">
                            Địa chỉ<span class="required" aria-required="true">*</span>
                        </label>
                        <%-- <%=Viags.Utils.FormUtils.TextBox("TenTaiLieu",model.TenTaiLieu,"Nhập địa chỉ",3,255) %>--%>
                        <input class="form-control" name="DiaChi" id="DiaChi" autocomplete="off" value="yên thế" />
                    </div>
                    <!-- Tên báo cáo -->
                </div>
                <!-- Phòng ban -->

                <div class="form-group">
                    <div class="form-group col-md-5">
                        <label class="control-label">
                            Trạm
                        </label>
                        <select id="KhuVuc" name="KhuVuc" class="form-control select2" data-placeholder="Chọn phòng ban" onchange="ChangeKhuVuc(this)">
                            
                            <%foreach (var item in listkhuvuc)
                                {%>
                            <option value="<%=item.ID %>"><%=item.Ten %> </option>
                            <%}%>
                        </select>
                    </div>
                    <div class="form-group col-md-3">
                        <label class="control-label">
                            Số ghế
                        </label>
                        <select id="Soghe" name="Soghe" class="form-control select2">
                            <%foreach (var item in new List<int>() { 1, 2, 3 })
                                {%>
                            <option value="<%=item %>">item </option>
                            <%}%>
                        </select>
                    </div>
                    <div class="form-group col-md-4">
                        <label class="control-label">
                            Trung chuyển
                        </label>
                        <div class="form-group">
                            <input style="width: 30px; height: 20px" type="checkbox" name="isTrungChuyen" id="isTrungChuyen">
                        </div>
                    </div>

                </div>
                <!-- Phòng ban -->

                <%--Phường xã, Đường ấp--%>
                <div class="form-group">
                    <div class="form-group col-md-6">
                        <label class="control-label">
                            Phường xã
                        </label>
                        <%--       <select id="PhuongXa" name="PhuongXa" class="form-control select2" data-placeholder="Chọn phòng ban" onchange="ChangePhongBan(this)">
                            <option value="">Chọn phường xã</option>
                            <%foreach (var item in new List<int>() { 1, 2, 3 })
                                {%>
                            <option value="<%=item %>">item </option>
                            <%}%>
                        </select>--%>
                        <input class="form-control " id="PhuongXa" name="PhuongXa" onchange="ChangePhuongXa(this)" />
                    </div>
                    <div class="form-group col-md-6">
                        <label class="control-label">
                            Đường ấp
                        </label>
         <%--               <select id="DuongAp" name="DuongAp" class="form-control select2">
                            <option value="">Chọn đường ấp</option>
                            <%foreach (var item in new List<int>() { 1, 2, 3 })
                                {%>
                            <option value="<%=item %>">item </option>
                            <%}%>
                        </select>--%>
                         <input class="form-control " id="DuongAp" name="DuongAp" />
                    </div>

                </div>

                <%--Phường xã, Đường ấp--%>




                <!-- Nhóm người nhận -->

                <!-- Ghi chú -->




            </div>

        </div>
    </div>

    <div class="modal-footer">



        <button type="submit" id="btnAddModal" class="btn brown" tabindex="6"><i class="fa fa-save"></i>&nbsp;Lưu</button>

        <button type="button" id="btnCloseModal" class="btn red exit" data-dismiss="modal" tabindex="7"><i class="fa fa-remove"></i>&nbsp;<%=Resources.CongViec.lblThoat %></button>
    </div>
</form>

