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

    box += "<label class='control-label col-sm-6 col-md-4'>Unit process</label>";
    box += "<div class='controls col-sm-6 col-md-8'>";
    box += "<input class='form-control phongban' value='{{text}}' readonly/>";
    box += "</div></div></div>";

    box += "<div class='col-md-6 col-sm-6'>";
    box += "<div class='control-group row'>";

    box += "<label class='control-label col-sm-6 col-md-4'>Deadline</label>";
    box += "<div class='controls col-sm-6 col-md-8'>";
    box += "    <input class='form-control date-picker hanxuly' maxlength='10' value=''/>";
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

    box += "<label class='control-label col-sm-6 col-md-4'>Manager</label>";
    box += "<div class='controls col-sm-6 col-md-8'>";
    box += "<input class='form-control nguoidung' value='{{text}}' readonly/>";
    box += "</div></div></div>";

    box += "<div class='col-md-6 col-sm-6'>";
    box += "<div class='control-group row'>";

    box += "<label class='control-label col-sm-6 col-md-4'>Deadline</label>";
    box += "<div class='controls col-sm-6 col-md-8'>";
    box += "    <input class='form-control date-picker hanxuly' maxlength='10' value=''/>";
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

    box += "<label class='control-label col-sm-6 col-md-4'>Dep't/ Branch coordinate</label>";
    box += "<div class='controls col-sm-6 col-md-8'>";
    box += "<input class='form-control phongban' value='{{text}}' readonly/>";
    box += "</div></div></div>";

    box += "<div class='col-md-6 col-sm-6'>";
    box += "<div class='control-group row'>";

    box += "<label class='control-label col-sm-6 col-md-4'>Deadline</label>";
    box += "<div class='controls col-sm-6 col-md-8'>";
    box += "    <input class='form-control date-picker hanxuly' maxlength='10' value=''/>";
    box += "</div></div>";
    box += "</div>";
    box += "</div>";

    box = box.replace("{{id}}", id).replace("{{text}}", text).replace("{{value}}", value);
    //box = box.replace("{{id}}", id).replace("{{text}}", text).replace("{{hanxuly}}", hanxuly).replace("{{value}}", value);
    $("#listTrangThai3").append(box);
}

function appendboxCBPH(id, text, hanxuly, value, action) {
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

    box += "<label class='control-label col-sm-6 col-md-4'>Coordinator</label>";
    box += "<div class='controls col-sm-6 col-md-8'>";
    box += "<input class='form-control nguoidung' value='{{text}}' readonly/>";
    box += "</div></div></div>";

    box += "<div class='col-md-6 col-sm-6'>";
    box += "<div class='control-group row'>";

    box += "<label class='control-label col-sm-6 col-md-4'>Deadline</label>";
    box += "<div class='controls col-sm-6 col-md-8'>";
    box += "    <input class='form-control date-picker hanxuly' maxlength='10' value=''/>";
    box += "</div></div>";
    box += "</div>";
    box += "</div>";

    box = box.replace("{{id}}", id).replace("{{text}}", text).replace("{{value}}", value);
    //box = box.replace("{{id}}", id).replace("{{text}}", text).replace("{{hanxuly}}", hanxuly).replace("{{value}}", value);
    $("#listTrangThai3").append(box);
}

function appendboxCBDM(id, text, hanxuly, value, action) {
    $("#listTrangThai3").css("display", "block");
    if (action) {
        $("#kengang3").css("display", "block");
    }
    var box = "";
    box += "<div class='box-cauhinh row marginB-10'>";

    box += "    <input type='hidden' class='m-wrap span3 idnguoidung' value='{{id}}'>";
    box += "    <input type='hidden' class='m-wrap span3 idtrangthai' value='{{value}}'>";
    box += "<div class='col-md-12 col-sm-12'><div class='col-md-6 col-sm-6'>";
    box += "<div class='control-group row'>";

    box += "<label class='control-label col-sm-6 col-md-4'>Processor</label>";
    box += "<div class='controls col-sm-6 col-md-8'>";
    box += "<input class='form-control nguoidung' value='{{text}}' readonly/>";
    box += "</div></div></div>";

    box += "<div class='col-md-6 col-sm-6'>";
    box += "<div class='control-group row'>";

    box += "<label class='control-label col-sm-6 col-md-4'>Department</label>";
    box += "<div class='controls col-sm-6 col-md-8'>";
    box += "<input class='form-control phongban' value='{{text}}' readonly/>";
    box += "</div></div>";
    box += "</div>";
    box += "</div>";
    box +=
        "<div class='col-md-12 col-sm-12' style='margin-top: 10px'><div class='col-md-6 col-sm-6'><div class='control-group row'></div></div><div class='col-md-6 col-sm-6'><div class='control-group row'><label class='control-label col-sm-6 col-md-4'>Deadline</label><div class='controls col-sm-6 col-md-8'><input class='form-control date-picker hanxuly' maxlength='10' value=''/></div></div></div></div>";

    //box = box.replace("{{id}}", id).replace("{{text}}", text).replace("{{hanxuly}}", hanxuly).replace("{{value}}", value);
    box = box.replace("{{id}}", id).replace("{{text}}", text).replace("{{value}}", value);
    $("#listTrangThai3").append(box);
}

function onchangeTabThree(action) {
    $("#listTrangThai3").html("");
    var hanxuly = $("#HanXuLy").val();
    var value = "1";
    // Unit process
    var listDonViXuLy = new Array();
    $('#DonViXuLy option:selected').each(function () {
        appendboxPBDM($(this).val(), $(this).text().trim(), hanxuly, value, action);
        listDonViXuLy.push($(this).val() + "");
    });
    // Dep't/ Branch coordinate
    var listpbPhoiHop = new Array();
    $('#DonViPhoiHop option:selected').each(function () {
        appendboxPBPH($(this).val(), $(this).text().trim(), hanxuly, value, action);
        listpbPhoiHop.push($(this).val() + "");
    });
    // Processor
    var listNguoiXuLy = new Array();
    $('#NguoiXuLy option:selected').each(function () {
        appendboxCBDM($(this).val(), $(this).text().trim(), hanxuly, value, action);
        listNguoiXuLy.push($(this).val() + "");
    });

    // Coordinator
    var listCBPhoiHop = new Array();
    $('#NguoiPhoiHop option:selected').each(function () {
        appendboxCBPH($(this).val(), $(this).text().trim(), hanxuly, value, action);
        listCBPhoiHop.push($(this).val() + "");
    });


    $(".date-picker").datepicker({
        format: 'dd/mm/yyyy'
    }).on('changeDate', function (e) {
        $(this).datepicker('hide');
    });
}

function validateForm() {
    var urlPostAction = "/CongViec/Action.ashx";
    $("#FormCongViec").validate({
        rules: {
            Ten: { required: true, minlength: 3, maxlength: 255 },
            NgayBatDau: { required: true, date: true },
            HanXuLy: { date: true },
            LoaiXuLyID: { required: true },
        },
        submitHandler: function () {
            //for (var name in CKEDITOR.instances) CKEDITOR.instances[name].updateElement();
            $("#btnSubmit").attr('disabled', true);

            // Validate ngày tháng
            if ($('#NgayBatDau').val() != '') {
                if (!isValidDate($('#NgayBatDau').val())) {
                    submit = false;
                    $("#FormMessage").html('<div class="alert alert-success"><button data-dismiss="alert" class="close"></button><strong>Error: </strong>Please retype date format.</div>');
                    $("#btnSubmit").attr('disabled', false);
                    $('html, body').animate({ scrollTop: 0 }, 100);
                    return false;
                }
            }
            if ($('#HanXuLy').val() != '') {
                if (!isValidDate($('#HanXuLy').val())) {
                    submit = false;
                    $("#FormMessage").html('<div class="alert alert-success"><button data-dismiss="alert" class="close"></button><strong>Error: </strong>Please retype date format.</div>');
                    $("#btnSubmit").attr('disabled', false);
                    $('html, body').animate({ scrollTop: 0 }, 100);
                    return false;
                }
            }
            var submit = true;
            var arrNgayBatDau = $('#NgayBatDau').val().split('/');
            var nbd = new Date(arrNgayBatDau[2], arrNgayBatDau[1] - 1, arrNgayBatDau[0]);
            var arrHanXuLy = $('#HanXuLy').val().split('/');
            var hxl = new Date(arrHanXuLy[2], arrHanXuLy[1] - 1, arrHanXuLy[0]);
            // Validate Deadline vs ngày bắt đầu
            if (hxl < nbd) {
                $("#btnSubmit").attr('disabled', false);
                $("#FormMessage").html('<div class="alert alert-success"><button data-dismiss="alert" class="close"></button><strong>Error: </strong>Processing time should not be less than start date.</div>');
                setTimeout(function () { $("#HanXuLy").focus(); }, 3100);
                setTimeout(function () {
                    $("#FormMessage").html("");
                }, 3000);
                $('html, body').animate({ scrollTop: 0 }, 100);
                return false;
            }
            // Validate Deadline người dùng  vs Deadline công việc
            $("#listTrangThai3 .box-cauhinh").each(function () {
                var arrHxlND = $(this).find('.hanxuly').val().split('/');
                var hxlnd = new Date(arrHxlND[2], arrHxlND[1] - 1, arrHxlND[0]);
                // Trường hợp Deadline cá nhân trống
                if ($('#HanXuLy').val() != "" && $(this).find('.hanxuly').val() == "") {
                    submit = false;
                    $("#FormMessage").html('<div class="alert alert-success"><button data-dismiss="alert" class="close"></button><strong>Error: </strong>You have not selected individual processing limits.</div>');
                    $("#btnSubmit").attr('disabled', false);
                    $('html, body').animate({ scrollTop: 0 }, 100);
                    return false;
                }
                // Trường hợp Deadline sai định dạng ngày tháng
                if ($('.hanxuly').val() != '') {
                    if (!isValidDate($('.hanxuly').val())) {
                        submit = false;
                        $("#FormMessage").html('<div class="alert alert-success"><button data-dismiss="alert" class="close"></button><strong>Error: </strong>Please retype date format.</div>');
                        $("#btnSubmit").attr('disabled', false);
                        $('html, body').animate({ scrollTop: 0 }, 100);
                        return false;
                    }
                }
                // Trường hợp validate dữ liệu
                if ((hxl < hxlnd || hxlnd < nbd)) {
                    submit = false;
                    $("#FormMessage").html('<div class="alert alert-success"><button data-dismiss="alert" class="close"></button><strong>Error: </strong>Handling of personal affairs shall not exceed the duration of work or be less than the date of commencement of work.</div>');
                    $("#btnSubmit").attr('disabled', false);
                    $('html, body').animate({ scrollTop: 0 }, 100);
                    return false;
                }
            });

            if (!submit)
                return false;
            getTrangThai3();
            $.post(urlPostAction, $("#FormCongViec").mySerialize(), function (data) {

                if (data.Error) {
                    $("#btnSubmit").attr('disabled', false);
                    $("#FormMessage").html('<div class="alert alert-success"><button data-dismiss="alert" class="close"></button><strong>Error.!</strong> ' + data.Title + '</div>');
                    $('html, body').animate({ scrollTop: 0 }, 100);
                }
                else {
                    $("#btnCloseModal").click();
                    $("#btnSubmit").attr('disabled', false);
                    createCloseMessage2("Notification", data.Title, '/Pagess/chi-tiet-cong-viec.aspx?do=view&HoSoCongViecID=' + data.ID); // Tạo thông báo khi click đóng thì chuyển đến url đích
                }
            });
            //}
            return false;
        }
    });
}

function getTrangThai3() {
    var trangthai = "";
    $('#listTrangThai3 .box-cauhinh').each(function () {
        var keyND = $(this).find(".idnguoidung").val();
        var keyPB = $(this).find(".idphongban").val();
        var value = $(this).find(".hanxuly").val();
        var status = $(this).find(".idtrangthai").val();
        if (keyND) {
            if (trangthai) {
                trangthai = trangthai + ",{NguoiDungID:'" + keyND + "',HanXuLy:'" + value + "',PhongBanID:0,IsDauMoi:'" + status + "'}";
            } else {
                trangthai = "{NguoiDungID:'" + keyND + "',HanXuLy:'" + value + "',PhongBanID:0,IsDauMoi:'" + status + "'}";
            }

        }
        if (keyPB) {
            if (trangthai) {
                trangthai = trangthai + ",{NguoiDungID:0,HanXuLy:'" + value + "',PhongBanID:'" + keyPB + "',IsDauMoi:'" + status + "'}";
            } else {
                trangthai = "{NguoiDungID:0,HanXuLy:'" + value + "',PhongBanID:'" + keyPB + "',IsDauMoi:'" + status + "'}";
            }

        }
    });
    $("#hdfTrangThai3").val(trangthai);
}