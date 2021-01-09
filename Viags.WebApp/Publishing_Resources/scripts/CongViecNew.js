function appendboxPBDM(id, text, hanxuly, value, action) {
    $("#listTrangThai3").css("display", "block");
    if (action) {
        $("#kengang3").css("display", "block");
    }
    var box = "";
    box += "<div class='box-cauhinh row marginB-10'>";

    box += "    <input type='hidden' class='m-wrap span3 idphongban' value='{{id}}'>";
    box += "    <input type='hidden' class='m-wrap span3 idtrangthai' value='{{value}}'>";
    box += "<div class='col-md-6 col-sm-6'>";
    box += "<div class='control-group row'>";

    box += "<label class='control-label col-sm-6 col-md-4'>Đơn vị xử lý</label>";
    box += "<div class='controls col-sm-6 col-md-8'>";
    box += "<input class='form-control phongban' value='{{text}}' readonly/>";
    box += "</div></div></div>";

    box += "<div class='col-md-6 col-sm-6'>";
    box += "<div class='control-group row'>";

    box += "<label class='control-label col-sm-6 col-md-4'>Ngày kết thúc</label>";
    box += "<div class='controls col-sm-6 col-md-8'>";
    box += "    <input class='form-control date-picker hanxuly' autocomplete='off' maxlength='10' value=''/>";
    box += "</div></div>";
    box += "</div>";
    box += "</div>";

    //box = box.replace("{{id}}", id).replace("{{text}}", text).replace("{{hanxuly}}", hanxuly).replace("{{value}}", value);
    box = box.replace("{{id}}", id).replace("{{text}}", text).replace("{{value}}", value);
    $("#listTrangThai3").append(box);
}

function appendboxLDDMTab3(id, text, hanxuly, value, action) {
    $("#listTrangThai3").css("display", "block");
    if (action) {
        $("#kengang3").css("display", "block");
    }
    var box = "";
    box += "<div class='box-cauhinh row marginB-10'>";

    box += "    <input type='hidden' class='m-wrap span3 idnguoidung' value='{{id}}'>";
    box += "    <input type='hidden' class='m-wrap span3 idtrangthai' value='0'>";
    box += "<div class='col-md-6 col-sm-6'>";
    box += "<div class='control-group row'>";

    box += "<label class='control-label col-sm-6 col-md-4'>Lãnh đạo đầu mối</label>";
    box += "<div class='controls col-sm-6 col-md-8'>";
    box += "<input class='form-control nguoidung' value='{{text}}' readonly/>";
    box += "</div></div></div>";

    box += "<div class='col-md-6 col-sm-6'>";
    box += "<div class='control-group row'>";

    box += "<label class='control-label col-sm-6 col-md-4'>Ngày kết thúc</label>";
    box += "<div class='controls col-sm-6 col-md-8'>";
    box += "    <input class='form-control date-picker hanxuly' autocomplete='off' maxlength='10' value=''/>";
    box += "</div></div>";
    box += "</div>";
    box += "</div>";

    box = box.replace("{{id}}", id).replace("{{text}}", text).replace("{{value}}", value);
    //box = box.replace("{{id}}", id).replace("{{text}}", text).replace("{{hanxuly}}", hanxuly).replace("{{value}}", value);
    $("#listTrangThai3").append(box);
}

function appendboxPBPH(id, text, hanxuly, value, action) {
    $("#listTrangThai3").css("display", "block");
    if (action) {
        $("#kengang3").css("display", "block");
    }
    var box = "";
    box += "<div class='box-cauhinh row marginB-10'>";

    box += "    <input type='hidden' class='m-wrap span3 idphongban' value='{{id}}'>";
    box += "    <input type='hidden' class='m-wrap span3 idtrangthai' value='0'>";
    box += "<div class='col-md-6 col-sm-6'>";
    box += "<div class='control-group row'>";

    box += "<label class='control-label col-sm-6 col-md-4'>Đơn vị phối hợp</label>";
    box += "<div class='controls col-sm-6 col-md-8'>";
    box += "<input class='form-control phongban' value='{{text}}' readonly/>";
    box += "</div></div></div>";

    box += "<div class='col-md-6 col-sm-6'>";
    box += "<div class='control-group row'>";

    box += "<label class='control-label col-sm-6 col-md-4'>Ngày kết thúc</label>";
    box += "<div class='controls col-sm-6 col-md-8'>";
    box += "    <input class='form-control date-picker hanxuly' autocomplete='off' maxlength='10' value=''/>";
    box += "</div></div>";
    box += "</div>";
    box += "</div>";

    box = box.replace("{{id}}", id).replace("{{text}}", text).replace("{{value}}", value);
    //box = box.replace("{{id}}", id).replace("{{text}}", text).replace("{{hanxuly}}", hanxuly).replace("{{value}}", value);
    $("#listTrangThai3").append(box);
}

function appendboxCBPH(id, text, stringphongBan, hanxuly, value, action) {
    var res = stringphongBan.split(",");

    $("#listTrangThai3").css("display", "block");
    //if (action) {
    //    $("#kengang3").css("display", "block");
    //}
    var box = "";
    box += "<div class='box-cauhinh row marginB-10' style='display: none'>";

    box += "    <input type='hidden' class='m-wrap span3 phongbanPH' value='{{idphongban}}'>";
    box += "    <input type='hidden' class='m-wrap span3 idnguoidung' value='{{id}}'>";
    box += "    <input type='hidden' class='m-wrap span3 idtrangthai' value='0'>";
    box += "<div class='col-md-6 col-sm-6'>";
    box += "<div class='control-group row'>";

    box += "<label class='control-label col-sm-4 col-md-4'>Người phối hợp</label>";
    box += "<div class='controls col-sm-8 col-md-8'>";
    box += "<input class='form-control nguoidung' value='{{text}}' readonly/>";
    box += "</div></div></div>";

    box += "<div class='col-md-3 col-sm-3'>";

    box += "<div class='control-group row'>";
    box += "<label class='control-label col-sm-4 col-md-4'>Phòng ban</label>";
    box += "<div class='controls col-sm-8 col-md-8'>";
    box += "<input class='form-control' id='PhongBanDonViID' name='PhongBanDonViID' value='{{stringphongBan}}' readonly/>";
    box += "</div>";

    box += "<div class='control-group row' style='display:none'>";
    box += "<label class='control-label col-sm-6 col-md-4'>Ngày kết thúc</label>";
    box += "<div class='controls col-sm-6 col-md-8'>";
    box += "    <input class='form-control date-picker hanxuly' autocomplete='off' maxlength='10' value=' '/>";
    box += "</div></div>";
    box += "</div>";
    box += "</div></div>";
    //box += "<hr />";
    box = box.replace("{{idphongban}}", res[0]).replace("{{id}}", id).replace("{{text}}", text).replace("{{stringphongBan}}", res[1]).replace("{{value}}", value).replace("{{value}}", value);
    //box = box.replace("{{id}}", id).replace("{{text}}", text).replace("{{hanxuly}}", hanxuly).replace("{{value}}", value);
    $("#listTrangThai3").append(box);
}

var hanxulyIndex = 0;
function appendboxCBDM(id, text, stringphongBan, hanxuly, value, action, noidung) {
    var res = stringphongBan.split(",");

    $("#listTrangThai3").css("display", "block");
    if (action) {
        $("#kengang3").css("display", "block");
    }
    var box = "";
    box += "<div class='box-cauhinh row marginB-12'>";
    box += "    <input type='hidden' class='m-wrap span3 phongbanTH' value='{{idphongban}}'>";
    box += "    <input type='hidden' class='m-wrap span3 idnguoidung' value='{{id}}'>";
    box += "    <input type='hidden' class='m-wrap span3 idtrangthai' value='{{value}}'>";

    box += "<div class='col-md-6 col-sm-6'>";
    box += "<div class='control-group row'>";

    box += "<label class='control-label col-sm-6 col-md-4'>Người thực hiện</label>";
    box += "<div class='controls col-sm-6 col-md-8'>";
    box += "<input class='form-control nguoidung' value='{{text}}' readonly/>";
    box += "</div></div></div>";

    box += "<div class='col-md-3 col-sm-3'>";
    box += "<div class='control-group row'>";
    box += "<label class='control-label col-sm-4 col-md-4'>Phòng ban</label>";
    box += "<div class='controls col-sm-8 col-md-8'>";
    box += "<input class='form-control' id='PhongBanDonViID' name='PhongBanDonViID' value='{{stringphongBan}}' readonly/>";
    box += "</div></div>";
    box += "</div>";


    box += "<div class='col-md-3 col-sm-3'>";
    box += "<div class='control-group row'>";
    box += "<label class='control-label col-sm-6 col-md-6'>Tỷ trọng (%)</label>";
    box += "<div class='form-controls col-sm-6 col-md-6'>";
    box += "<input type='number' class='form-control tytrongnguoixuly' id='TyTrongCaNhan' name='TyTrongCaNhan' value='' />";
    box += "</div></div>";
    box += "</div>";

    box +=
        "<div class='col-md-6 col-sm-6' style='margin-top: 10px'>" +
        "<div class='control-group row'>" +
        "<label class='control-label col-sm-4 col-md-4'>Ngày kết thúc</label>" +
        "<div class='controls col-sm-8 col-md-8'><input class='form-control date-picker hanxuly hanxulyIndex_{{hanxulyIndex}}' autocomplete='off' value=''/>" +
        "</div>" +
        "</div>" +
        "</div>";

    box += "<div class='col-md-6 col-sm-6' style='margin-top: 10px' >";
    box += "<div class='control-group row'>";
    box += "<label class='control-label col-sm-2 col-md-2'>Nội dung</label>";
    box += "<div class='form-controls col-sm-10 col-md-10'>";
    box += "<input class='form-control noidungthuchien' id='NoiDungThucHien' name='NoiDungThucHien' value='{{stringnoidung}}' />";
    box += "</div></div></div>" +
        "</div>";



    box += "<hr />";

    //box = box.replace("{{id}}", id).replace("{{text}}", text).replace("{{hanxuly}}", hanxuly).replace("{{value}}", value);
    box = box.replace("{{idphongban}}", res[0]).replace("{{id}}", id).replace("{{text}}", text).replace("{{stringphongBan}}", res[1]).replace("{{value}}", value).replace("{{hanxulyIndex}}", hanxulyIndex).replace("{{stringnoidung}}", noidung);
    $("#listTrangThai3").append(box);
    var minDate = $('#NgayBatDau').val();
    var maxDate = $('#HanXuLy').val();

    $(".hanxulyIndex_" + hanxulyIndex).datetimepicker({
        'format': 'dd/mm/yyyy hh:ii',
        'setEndDate': maxDate,
        'setStartDate': minDate
    }).on('changeDate', function (e) {
        $(this).datetimepicker('hide');
    });
    hanxulyIndex++;
}

function onchangeTabThree(action) {
    $("#listTrangThai3").html("");
    var hanxuly = $("#HanXuLy").val();
    var value = "1";
    // Đơn vị xử lý
    var listDonViXuLy = new Array();
    $('#DonViXuLy option:selected').each(function () {
        appendboxPBDM($(this).val(), $(this).text().trim(), hanxuly, value, action);
        listDonViXuLy.push($(this).val() + "");
    });
    // Đơn vị phối hợp
    var listpbPhoiHop = new Array();
    $('#DonViPhoiHop option:selected').each(function () {
        appendboxPBPH($(this).val(), $(this).text().trim(), hanxuly, value, action);
        listpbPhoiHop.push($(this).val() + "");
    });
    // Người xử lý
    var listNguoiXuLy = new Array();

    $('#NguoiXuLy option:selected').each(function () {
        var this_ = $(this);
        var stringphongBan = "";
        var noidung = "";
        var cvid = 0;
        if ($("#ts").val() == 0) {
            cvid = $("#ItemId").val();
        }
        $.ajax({
            type: "POST",
            url: "/CongViec/pFormCongViecNew.aspx/GetTenPhongBan",
            data: JSON.stringify({ valuetype: $(this).val(), congviec: cvid }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                stringphongBan += data.d;
                if (cvid != 0) {
                    noidung = data.d.split(",")[2];
                }
                if (stringphongBan !== "") {
                    appendboxCBDM(this_.val(), this_.text().trim(), stringphongBan, hanxuly, value, action, noidung);
                    listNguoiXuLy.push(this_.val() + "");
                }
            }
        });
    });

    // Người phối hợp
    var listCBPhoiHop = new Array();
    $('#NguoiPhoiHop option:selected').each(function () {
        var this_ = $(this);
        var stringphongBan = "";
        $.ajax({
            type: "POST",
            url: "/CongViec/pFormCongViecNew.aspx/GetTenPhongBan",
            data: JSON.stringify({ valuetype: $(this).val(), congviec: 0 }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                stringphongBan += data.d;
                if (stringphongBan !== "") {
                    appendboxCBPH(this_.val(), this_.text().trim(), stringphongBan, hanxuly, value, action);
                    listCBPhoiHop.push($(this).val() + "");
                }
            }
        });
        //appendboxCBPH($(this).val(), $(this).text().trim(), hanxuly, value, action);
        //listCBPhoiHop.push($(this).val() + "");
    });
    $(".date-picker").datepicker({
        format: 'dd/mm/yyyy',
        forceParse: false,
        todayBtn: true,
        todayHighlight: true,
    }).on('changeDate', function (e) {
        $(this).datepicker('hide');
    });
}

function isValidDate_hung(dateString) {
    // Kiểm tra định dạng  
    if (!/^\d{1,2}\/\d{1,2}\/\d{4}$/.test(dateString.split(' ')[0]))
        return false;

    var parts = dateString.split("/");
    var day = parseInt(parts[0], 10);
    var month = parseInt(parts[1], 10);
    var year = parseInt(parts[2], 10);

    // Kiểm tra năm và tháng
    if (year < 1000 || year > 3000 || month == 0 || month > 12)
        return false;

    var monthLength = [31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31];

    // Kiểm tra năm nhuận
    if (year % 400 == 0 || (year % 100 != 0 && year % 4 == 0))
        monthLength[1] = 29;

    return day > 0 && day <= monthLength[month - 1];
};

function validateForm() {
    var urlPostAction = "/CongViec/Action.ashx";
    $("#FormCongViec").validate({
        rules: {
            Ten: { required: true, minlength: 3, maxlength: 255 },
            NoiDung: { required: true },
            NgayBatDau: { required: true, date: true },
            HanXuLy: { required: true, date: true },
            LoaiXuLyID: { required: true },
            TongNganSach: { minlength: 4 },
            TyTrong: { required: true, digits: true, range: [1, 100] },
            NguoiXuLy: { required: true }
        },
        messages: {
            TongNganSach: {
                //required: "Vui lòng nhập ngân sách",
                minlength: "Vui lòng nhập giá trị lớn hơn 1000 !!!"
            }
        },
        submitHandler: function () {
            //for (var name in CKEDITOR.instances) CKEDITOR.instances[name].updateElement();
            $("#btnSubmit").attr('disabled', true);
            var tongTyTrong = 0;
            // Validate ngày tháng
            if ($('#NgayBatDau').val() != '') {
                if (!isValidDate_hung($('#NgayBatDau').val())) {
                    submit = false;
                    $("#FormMessage").html('<div class="alert alert-danger"><button data-dismiss="alert" class="close"></button><strong>Có lỗi xảy ra: </strong>Bạn vui lòng nhập lại định dạng ngày tháng.</div>');
                    $("#btnSubmit").attr('disabled', false);
                    $('html, body').animate({ scrollTop: 0 }, 100);
                    return false;
                }
            }
            if ($('#HanXuLy').val() != '') {
                if (!isValidDate_hung($('#HanXuLy').val())) {
                    submit = false;
                    $("#FormMessage").html('<div class="alert alert-danger"><button data-dismiss="alert" class="close"></button><strong>Có lỗi xảy ra: </strong>Bạn vui lòng nhập lại định dạng ngày tháng.</div>');
                    $("#btnSubmit").attr('disabled', false);
                    $('html, body').animate({ scrollTop: 0 }, 100);
                    return false;
                }
            }
            var submit = true;
            var tempbatdau = $('#NgayBatDau').val().split(' ');
            var arrNgayBatDau = tempbatdau[0].split('/');
            var arrNgayBatDau1 = tempbatdau[1].split(':');
            var nbd = new Date(arrNgayBatDau[2], arrNgayBatDau[1] - 1, arrNgayBatDau[0], arrNgayBatDau1[0], arrNgayBatDau1[1]);
            var tempketthuc = $('#HanXuLy').val().split(' ');
            var arrHanXuLy = tempketthuc[0].split('/');
            var arrHanXuLy1 = tempketthuc[1].split(':');
            var hxl = new Date(arrHanXuLy[2], arrHanXuLy[1] - 1, arrHanXuLy[0], arrHanXuLy1[0], arrHanXuLy1[1]);


            // Validate Ngày kết thúc vs ngày bắt đầu
            if (hxl < nbd) {
                $("#btnSubmit").attr('disabled', false);
                $("#FormMessage").html('<div class="alert alert-danger"><button data-dismiss="alert" class="close"></button><strong>Có lỗi xảy ra: </strong>Ngày kết thúc không được nhỏ hơn ngày bắt đầu công việc.</div>');
                setTimeout(function () { $("#HanXuLy").focus(); }, 3100);
                setTimeout(function () {
                    $("#FormMessage").html("");
                }, 3000);
                $('html, body').animate({ scrollTop: 0 }, 100);
                return false;
            }
            //Validate Ngày kết thúc người dùng  vs Ngày kết thúc công việc
            $("#listTrangThai3 .box-cauhinh").each(function () {
                var isDauMoi = $(this).find(".idtrangthai").val();
                console.log("xxx" + isDauMoi);
                if (isDauMoi == 1) {
                    var tempHxLND = $(this).find('.hanxuly').val().split(' ');
                    var arrHxlND = tempHxLND[0].split('/');
                    var arrHxlND1 = tempHxLND[1].split(':');

                    var hxlnd = new Date(arrHxlND[2], arrHxlND[1] - 1, arrHxlND[0], arrHxlND1[0], arrHxlND1[1]);
                    // Trường hợp Ngày kết thúc cá nhân trống
                    if ($('#HanXuLy').val() != "" && $(this).find('.hanxuly').val() == "") {
                        submit = false;
                        $("#FormMessage").html('<div class="alert alert-danger"><button data-dismiss="alert" class="close"></button><strong>Có lỗi xảy ra: </strong>Bạn chưa chọn Ngày kết thúc cá nhân.</div>');
                        $("#btnSubmit").attr('disabled', false);
                        $('html, body').animate({ scrollTop: 0 }, 100);
                        return false;
                    }
                    // Trường hợp Ngày kết thúc sai định dạng ngày tháng
                    if ($(this).find('.hanxuly').val() != '') {
                        if (!isValidDate_hung($(this).find('.hanxuly').val())) {
                            //console.log($('.hanxuly').val() + "aaaaaaa");
                            submit = false;
                            $("#FormMessage").html('<div class="alert alert-danger"><button data-dismiss="alert" class="close"></button><strong>Có lỗi xảy ra: </strong>Bạn vui lòng nhập lại định dạng ngày tháng.</div>');
                            $("#btnSubmit").attr('disabled', false);
                            $('html, body').animate({ scrollTop: 0 }, 100);
                            return false;
                        }
                    }
                    // Trường hợp validate dữ liệu
                    if ((hxl < hxlnd || hxlnd < nbd)) {
                        submit = false;
                        $("#FormMessage").html('<div class="alert alert-danger"><button data-dismiss="alert" class="close"></button><strong>Có lỗi xảy ra: </strong>Ngày kết thúc công việc cá nhân không được lớn hơn Ngày kết thúc công việc hoặc nhỏ hơn ngày bắt đầu công việc.</div>');
                        $("#btnSubmit").attr('disabled', false);
                        $('html, body').animate({ scrollTop: 0 }, 100);
                        return false;
                    }
                    var tyTrongCaNhan = $(this).find('.tytrongnguoixuly').val();
                    console.log("aaa" + tyTrongCaNhan);
                    if (isNaN(tyTrongCaNhan)) {
                        submit = false;
                        $("#FormMessage")
                            .html(
                                '<div class="alert alert-danger"><button data-dismiss="alert" class="close"></button><strong>Có lỗi xảy ra: </strong>Bạn vui lòng nhập lại định dạng tỷ trọng người thực hiện.</div>');
                        $("#btnSubmit").attr('disabled', false);
                        $('html, body').animate({ scrollTop: 0 }, 100);
                        return false;
                    }
                    if (tyTrongCaNhan == '' || tyTrongCaNhan == ' ') {
                        submit = false;
                        $("#FormMessage")
                            .html(
                                '<div class="alert alert-danger"><button data-dismiss="alert" class="close"></button><strong>Có lỗi xảy ra: </strong>Bạn chưa nhập tỷ trọng cá nhân.</div>');
                        $("#btnSubmit").attr('disabled', false);
                        $('html, body').animate({ scrollTop: 0 }, 100);
                        return false;
                    } else {
                        tongTyTrong += parseFloat(tyTrongCaNhan);
                    }
                }
            });

            if (!submit) {
                return false;
            } else {
                console.log("bbb" + tongTyTrong);
                if (tongTyTrong > 100) {
                    submit = false;
                    $("#FormMessage")
                        .html(
                            '<div class="alert alert-danger"><button data-dismiss="alert" class="close"></button><strong>Có lỗi xảy ra: </strong>Tổng tỷ trọng người thực hiện không được vượt quá 100(%).</div>');
                    $("#btnSubmit").attr('disabled', false);
                    $('html, body').animate({ scrollTop: 0 }, 100);
                    return false;
                }
                if (tongTyTrong < 100) {
                    submit = false;
                    $("#FormMessage")
                        .html(
                            '<div class="alert alert-danger"><button data-dismiss="alert" class="close"></button><strong>Có lỗi xảy ra: </strong>Tổng tỷ trọng người thực hiện không nhỏ hơn 100(%).</div>');
                    $("#btnSubmit").attr('disabled', false);
                    $('html, body').animate({ scrollTop: 0 }, 100);
                    return false;
                }
                getTrangThai3();
                $.post(urlPostAction, $("#FormCongViec").mySerialize(), function (data) {
                    var checkllv = $("#checkLLV").val();
                    if (data.Error) {
                        $("#btnSubmit").attr('disabled', false);
                        $("#FormMessage").html('<div class="alert alert-danger"><button data-dismiss="alert" class="close"></button><strong>Có lỗi xảy ra.!</strong> ' + data.Title + '</div>');
                        $('html, body').animate({ scrollTop: 0 }, 100);
                    }
                    else {
                        $("#btnCloseModal").click();
                        $("#btnSubmit").attr('disabled', false);
                        if (checkllv == 0) {
                            createCloseMessage2("Thông báo", data.Title, '/Pagess/chi-tiet-cong-viec.aspx?do=view&HoSoCongViecID=' + data.ID); // Tạo thông báo khi click đóng thì chuyển đến url đích

                        }
                        else if (checkllv == 1) {
                            createCloseMessage2("Thông báo", data.Title, '/Pagess/lich-ca-nhan.aspx');
                        }
                    }
                });
                //}
                return false;
            }


        }
    });
}

function getTrangThai3() {
    var trangthai = "";
    $('#listTrangThai3 .box-cauhinh').each(function () {
        var keyND = $(this).find(".idnguoidung").val();
        var keyPBTH = $(this).find(".phongbanTH").val();
        var keyPBPH = $(this).find(".phongbanPH").val();
        var value = $(this).find(".hanxuly").val();
        var status = $(this).find(".idtrangthai").val();
        var tytrongnguoithuchien = $(this).find('.tytrongnguoixuly').val();
        var noidungthuchien = $(this).find('.noidungthuchien').val();

        if (keyPBTH) {
            trangthai = trangthai + ",{NguoiDungID:'" + keyND + "',HanXuLy:'" + value + "',PhongBanID:'" + keyPBTH + "',IsDauMoi:'" + status + "',TyTrongNguoiThucHien:'" + tytrongnguoithuchien + "',IsThucHien:1,Noidung:'" + noidungthuchien + "'}";
        } else if (keyPBPH) {
            trangthai = trangthai + ",{NguoiDungID:'" + keyND + "',HanXuLy:' ',PhongBanID:'" + keyPBPH + "',IsDauMoi:'" + status + "',TyTrongNguoiThucHien:0,IsThucHien:0,Noidung:''}";
        }
        //if (keyND) {
        //    if (trangthai) {
        //        trangthai = trangthai + ",{NguoiDungID:'" + keyND + "',HanXuLy:'" + value + "',PhongBanID:'" + keyPB + "',IsDauMoi:'" + status + "'}";
        //    } else {
        //        trangthai = "{NguoiDungID:'" + keyND + "',HanXuLy:'" + value + "',PhongBanID:0,IsDauMoi:'" + status + "'}";
        //    }

        //}
        //if (keyPB) {
        //    if (trangthai) {
        //        trangthai = trangthai + ",{NguoiDungID:0,HanXuLy:'" + value + "',PhongBanID:'" + keyPB + "',IsDauMoi:'" + status + "'}";
        //    } else {
        //        trangthai = "{NguoiDungID:0,HanXuLy:'" + value + "',PhongBanID:'" + keyPB + "',IsDauMoi:'" + status + "'}";
        //    }

        //}
    });
    $("#hdfTrangThai3").val(trangthai);
}
function ChangeDateTime() {
    $(".date-picker").datepicker({
        format: 'dd/mm/yyyy'
    }).on('changeDate', function (e) {
        $(this).datepicker('hide');
    });
    $("#NgayBatDau").datepicker({
        format: "dd/mm/yyyy",
        forceParse: false
    }).change(function () {
        $(this).datepicker('hide');
        $("#HanXuLy").datepicker('setStartDate', $(this).val());
        $(".hanxuly").datepicker('setStartDate', $(this).val());

    });
    $("#HanXuLy").datepicker({
        format: "dd/mm/yyyy",
        forceParse: false
    }).change(function () {
        $(this).datepicker('hide');
        $("#NgayBatDau").datepicker('setEndDate', $(this).val());
        $(".hanxuly").datepicker('setEndDate', $(this).val());
    });
    if ($("#NgayBatDau").val() != "") {
        var res = $("#NgayBatDau").val().split("/");
        $(".hanxuly").datepicker({
            format: "dd/mm/yyyy",
            forceParse: false,
            startDate: new Date(res[2], res[1], res[0])

        }).change(function () {
            $(this).datepicker('hide');
        });
    }
}
