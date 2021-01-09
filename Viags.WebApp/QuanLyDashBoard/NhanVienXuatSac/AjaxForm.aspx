<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AjaxForm.aspx.cs" Inherits="Viags.WebApp.QuanLyDashBoard.NhanVienXuatSac.AjaxForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script>
        $("#ListYear").select2({
            closeOnSelect: false,
        });
        $("#ListQuarter").select2({
            closeOnSelect: false,
        });
        $("#ListMonth").select2({
            closeOnSelect: false,
        });
        $("#ListnguoiDung").select2({
            closeOnSelect: false,
        });
        $("#NhanVienXuatSacForm").validate({
            rules: {
                NguoiDungID: { required: true },
                Mota: { required: true },
            },
            submitHandler: function () {
                //onSubmit
                $.post(urlPostAction, $("#NhanVienXuatSacForm").mySerialize(), function (data) {
                    if ($('#cbxAddMutil').attr('checked')) { //Trường hợp thêm liên tiếp
                        if (data.Error)
                            $("#FormMessage").html('<div class="alert alert-error"><button data-dismiss="alert" class="close"></button><strong><%=Resources.TaiKhoan.lblCoLoiXayRa%></strong> ' + data.Title + '</div>');
                        else {
                            $("#FormMessage").html('<div class="alert alert-success"><button data-dismiss="alert" class="close"></button>' + data.Title + '</div>');
                            setTimeout(function () {
                                $("#FormMessage").html("");
                            }, 2000);
                            ClearMessage("#FormMessage", "");
                            $('#cbxAddMutil').attr('checked', true);
                            refreshList();
                        }
                    } else { //Trường hợp thêm bình thường
                        if (data.Error) {
                            createMessage("<%=Resources.TaiKhoan.lblDaCoLoiXayRa%>", data.Title); // Tạo thông báo lỗi
                        }
                        else {
                            $("#btnCloseModal").click();
                            createCloseMessage("<%=Resources.TaiKhoan.lblThongBao%>", data.Title, '#Page=1&itemId=' + data.ID + '&message=' + data.Title + '&temp=' + Math.floor(Math.random() * 11) + ''); // Tạo thông báo khi click đóng thì chuyển đến url đích
                        }
                    }

                });
                return false;
            }
        });

        function ChangeType(input) {
            debugger
            switch ($(input).val()) {
                case '1': {
                    $("#Quarter").hide();
                    $("#Month").show();
                    $("#Year").show();
                    break;
                }
                case '2': {
                    $("#Quarter").show();
                    $("#Month").hide();
                    $("#Year").hide();
                    break;
                }
            }
        }
    </script>
</head>
<body>
    <form id="NhanVienXuatSacForm" class="form-horizontal" action="#">
        <div class="">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true"></button>
                <h4 class="modal-title">Nhân viên xuất sắc</h4>
            </div>
            <div class="modal-body">
                <input type="hidden" name="do" id="do" value="<%=DoAction%>" />
                <input type="hidden" name="ItemId" id="ItemId" value="<%=ItemID%>" />
                <div id="FormMessage"></div>
                <div class="form-horizontal">
                    <div class="row">
                        <div class="col-md-12 col-sm-12">
                            <div class="form-group">
                                <div class="col-sm-9 col-sm-offset-3">
                                    <em><b><%=Resources.TaiKhoan.lblLuuY%>:</b> <%=Resources.TaiKhoan.lblCacTruongCoDau%> <span class="required">*</span> <%=Resources.TaiKhoan.lblBatBuocNhapThongTin%> </em>
                                </div>
                            </div>
                        </div>
                    </div>
                    <%--region [Thang, Quy]--%>
                    <div class="col-md-12 col-sm-12">
                        <div class="form-group">
                            <div class="col-md-4 col-sm-4">
                                <label class="col-sm-6 control-label">
                                    Loại <span class="required" aria-required="true"></span>
                                </label>
                                <div class="col-sm-6 col-md-6">
                                    <select data-placeholder="Chọn loại" class="form-control select2" id="Type" name="Type" onchange="ChangeType(this)">
                                        <option value="1">Theo Tháng</option>
                                        <option value="2">Theo Quý</option>
                                    </select>
                                </div>
                            </div>

                            <div class="col-md-4 col-sm-4" id="Month">
                                <label class="col-sm-6 control-label">
                                    Tháng <span class="required" aria-required="true">*</span>
                                </label>
                                <div class="col-sm-6 col-md-6">
                                    <select data-placeholder="Chọn nhóm người nhận" class="form-control select2" id="ListMonth" name="ListMonth" tabindex="5">
                                        <%foreach (var item in ListMonth)
                                            {%>
                                        <option value="<%=item %>" <%=(NhanVienXuatSac != null) ? (NhanVienXuatSac.Thang == item ? "selected" : (DateTime.Now.Month ==item ? "selected" : "")) : (DateTime.Now.Month ==item ? "selected" : "")%>><%=item %></option>
                                        <%} %>
                                    </select>
                                </div>
                            </div>

                            <div class="col-md-4 col-sm-4" id="Quarter" hidden="hidden">
                                <label class="col-sm-6 control-label">
                                    Quý <span class="required" aria-required="true">*</span>
                                </label>
                                <div class="col-sm-6 col-md-6">
                                    <select class="form-control select2" id="ListQuarter" name="ListQuarter">
                                        <%foreach (var item in ListQuarter)
                                            {%>
                                        <option value="<%=item %>" <%=(NhanVienXuatSac != null) ? (NhanVienXuatSac.Quy == item ? "selected" : (dashBoardDA.GetQuy() == item ? "selected": "")) : (dashBoardDA.GetQuy() == item ? "selected": "")%>><%=item %></option>
                                        <%} %>
                                    </select>
                                </div>
                            </div>
                            <div class="col-md-4 col-sm-4" id="Year">
                                <label class="col-sm-6 control-label">
                                    Năm <span class="required" aria-required="true">*</span>
                                </label>
                                <div class="col-sm-6 col-md-6">
                                    <select class="form-control select2" id="ListYear" name="ListYear" tabindex="5">

                                        <%foreach (var item in ListYear)
                                            {%>
                                        <option value="<%=item %>" <%=(NhanVienXuatSac != null) ? (NhanVienXuatSac.Nam == item ? "selected" : (DateTime.Now.Year == item ? "selected":"")) : (DateTime.Now.Year == item ? "selected":"") %>><%=item %></option>
                                        <%} %>
                                    </select>
                                </div>
                            </div>
                        </div>
                    </div>
                    <%--region [Thang, Quy]--%>

                    <div class="row">
                        <div class="col-md-12 col-sm-12">
                            <div class="form-group">
                                <label class="col-sm-3 col-md-3 control-label">
                                    Nhân viên xuất sắc<span class="required" aria-required="true">*</span>
                                </label>
                                <div class="col-sm-9 col-md-9">
                                    <select required="required" <%=DoAction.Equals("add") ? "multiple='multiple'" :"" %> class="form-control select2" id="ListnguoiDung" name="ListnguoiDung">
                                        <%foreach (var item in LstNguoiDung)
                                            {%>
                                        <option value="<%=item.ID %>" <%=(NhanVienXuatSac.NguoiDungID == item.ID) ? "selected":"" %>><%=string.Format("{0}"+ (string.IsNullOrEmpty(item.MaNV)? "": "- {1} ") + "- {2}" + (string.IsNullOrEmpty(item.TenVietTatPhongBan) ? "{3}" : " - {3}") + (string.IsNullOrEmpty(item.TenVietTatDonVi) ? "{4}" : " - {4}"), item.TenHienThi, item.MaNV, item.TenChucVu, string.IsNullOrEmpty(item.TenVietTatPhongBan) ? string.Empty : item.TenVietTatPhongBan ,string.IsNullOrEmpty(item.TenVietTatDonVi) ? string.Empty : item.TenVietTatDonVi) %></option>
                                        <%} %>
                                    </select>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12 col-sm-12">
                            <div class="form-group">
                                <label class="col-sm-3 col-md-3 control-label">
                                    Mô tả<span class="required" aria-required="true">*</span>
                                </label>
                                <div class="col-sm-9 col-md-9">
                                    <input class="form-control" required="required" id="MoTa" name="MoTa" value="<%=NhanVienXuatSac.Mota %>" />
                                </div>
                            </div>
                        </div>

                        <div class="col-md-12 col-sm-12">
                            <div class="form-group">
                                <label class="col-sm-3 col-md-3 control-label">
                                    Hiển thị
                                </label>
                                <div class="col-sm-9 col-md-9">
                                    <%=Viags.Utils.FormUtils.CheckBox("HienThi", NhanVienXuatSac.HienThi, 5)%>
                                </div>
                            </div>
                        </div>
                    </div>

                </div>
            </div>
            <div class="modal-footer ">
                <button type="submit" id="btnAddModal" class="btn brown"><i class="fa fa-save"></i>&nbsp;<%=Resources.TaiKhoan.lblLuu%></button>
                <button type="button" id="btnCloseModal" class="btn red exit" data-dismiss="modal"><i class="fa fa-remove"></i>&nbsp;<%=Resources.TaiKhoan.lblThoat%></button>
            </div>
        </div>
    </form>
    <div class="clearfix"></div>
</body>
</html>
