function appendboxLDDM(id, text, hanxuly, value, action) {
    $("#listTrangThai1").css("display", "block");
    if (action) {
        $("#kengang1").css("display", "block");
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

    box += "<label class='control-label col-sm-6 col-md-4'>Hạn xử lý</label>";
    box += "<div class='controls col-sm-6 col-md-8'>";
    box += "    <input class='form-control date-picker hanxuly' autocomplete='off' maxlength='10' value='{{hanxuly}}'/>";
    box += "</div></div>";
    box += "</div>";
    box += "</div>";

    box = box.replace("{{id}}", id).replace("{{text}}", text).replace("{{hanxuly}}", hanxuly).replace("{{value}}", value);
    $("#listTrangThai1").append(box);
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

    box += "<label class='control-label col-sm-6 col-md-4'>Hạn xử lý</label>";
    box += "<div class='controls col-sm-6 col-md-8'>";
    box += "    <input class='form-control date-picker hanxuly' autocomplete='off' maxlength='10' value='{{hanxuly}}'/>";
    box += "</div></div>";
    box += "</div>";
    box += "</div>";

    box = box.replace("{{id}}", id).replace("{{text}}", text).replace("{{hanxuly}}", hanxuly).replace("{{value}}", value);
    $("#listTrangThai3").append(box);
}

function appendboxDVDM(id, text, hanxuly, value, action) {
    $("#listTrangThai1").css("display", "block");
    if (action) {
        $("#kengang1").css("display", "block");
    }
    var box = "";
    box += "<div class='box-cauhinh row marginB-10'>";

    box += "    <input type='hidden' class='m-wrap span3 idphongban' value='{{id}}'>";
    box += "    <input type='hidden' class='m-wrap span3 idtrangthai' value='{{value}}'>";
    box += "<div class='col-md-6 col-sm-6'>";
    box += "<div class='control-group row'>";

    box += "<label class='control-label col-sm-6 col-md-4'>Đơn vị đầu mối</label>";
    box += "<div class='controls col-sm-6 col-md-8'>";
    box += "<input class='form-control phongban' value='{{text}}' readonly/>";
    box += "</div></div></div>";

    box += "<div class='col-md-6 col-sm-6'>";
    box += "<div class='control-group row'>";

    box += "<label class='control-label col-sm-6 col-md-4'>Hạn xử lý</label>";
    box += "<div class='controls col-sm-6 col-md-8'>";
    box += "    <input class='form-control date-picker hanxuly' autocomplete='off' maxlength='10' value='{{hanxuly}}'/>";
    box += "</div></div>";
    box += "</div>";
    box += "</div>";

    box = box.replace("{{id}}", id).replace("{{text}}", text).replace("{{hanxuly}}", hanxuly).replace("{{value}}", value);
    $("#listTrangThai1").append(box);
}

function appendboxDVPH(id, text, hanxuly, value, action) {
    $("#listTrangThai1").css("display", "block");
    if (action) {
        $("#kengang1").css("display", "block");
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

    box += "<label class='control-label col-sm-6 col-md-4'>Hạn xử lý</label>";
    box += "<div class='controls col-sm-6 col-md-8'>";
    box += "    <input class='form-control date-picker hanxuly' autocomplete='off' maxlength='10' value='{{hanxuly}}'/>";
    box += "</div></div>";
    box += "</div>";
    box += "</div>";

    box = box.replace("{{id}}", id).replace("{{text}}", text).replace("{{hanxuly}}", hanxuly).replace("{{value}}", value);
    $("#listTrangThai1").append(box);
}

function appendboxCBDM(id, text, hanxuly, value, action) {
    $("#listTrangThai2").css("display", "block");
    if (action) {
        $("#kengang2").css("display", "block");
    }
    var box = "";
    box += "<div class='box-cauhinh row marginB-10'>";

    box += "    <input type='hidden' class='m-wrap span3 idnguoidung' value='{{id}}'>";
    box += "    <input type='hidden' class='m-wrap span3 idtrangthai' value='{{value}}'>";
    box += "<div class='col-md-6 col-sm-6'>";
    box += "<div class='control-group row'>";

    box += "<label class='control-label col-sm-6 col-md-4'>Cán bộ đầu mối</label>";
    box += "<div class='controls col-sm-6 col-md-8'>";
    box += "<input class='form-control nguoidung' value='{{text}}' readonly/>";
    box += "</div></div></div>";

    box += "<div class='col-md-6 col-sm-6'>";
    box += "<div class='control-group row'>";

    box += "<label class='control-label col-sm-6 col-md-4'>Hạn xử lý</label>";
    box += "<div class='controls col-sm-6 col-md-8'>";
    box += "    <input class='form-control date-picker hanxuly' autocomplete='off' maxlength='10' value='{{hanxuly}}'/>";
    box += "</div></div>";
    box += "</div>";
    box += "</div>";

    box = box.replace("{{id}}", id).replace("{{text}}", text).replace("{{hanxuly}}", hanxuly).replace("{{value}}", value);
    $("#listTrangThai2").append(box);
}

function appendboxCBPH(id, text, hanxuly, value, action) {
    $("#listTrangThai2").css("display", "block");
    if (action) {
        $("#kengang2").css("display", "block");
    }
    var box = "";
    box += "<div class='box-cauhinh row marginB-10'>";

    box += "    <input type='hidden' class='m-wrap span3 idnguoidung' value='{{id}}'>";
    box += "    <input type='hidden' class='m-wrap span3 idtrangthai' value='0'>";
    box += "<div class='col-md-6 col-sm-6'>";
    box += "<div class='control-group row'>";

    box += "<label class='control-label col-sm-6 col-md-4'>Cán bộ phối hợp</label>";
    box += "<div class='controls col-sm-6 col-md-8'>";
    box += "<input class='form-control nguoidung' value='{{text}}' readonly/>";
    box += "</div></div></div>";

    box += "<div class='col-md-6 col-sm-6'>";
    box += "<div class='control-group row'>";

    box += "<label class='control-label col-sm-6 col-md-4'>Hạn xử lý</label>";
    box += "<div class='controls col-sm-6 col-md-8'>";
    box += "    <input class='form-control date-picker hanxuly' autocomplete='off' maxlength='10' value='{{hanxuly}}'/>";
    box += "</div></div>";
    box += "</div>";
    box += "</div>";

    box = box.replace("{{id}}", id).replace("{{text}}", text).replace("{{hanxuly}}", hanxuly).replace("{{value}}", value);
    $("#listTrangThai2").append(box);
}

function appendboxLanhDao(id, text, hanxuly, value, action) {
    $("#listTrangThai2").css("display", "block");
    if (action) {
        $("#kengang2").css("display", "block");
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

    box += "<label class='control-label col-sm-6 col-md-4'>Hạn xử lý</label>";
    box += "<div class='controls col-sm-6 col-md-8'>";
    box += "    <input class='form-control date-picker hanxuly' autocomplete='off' maxlength='10' value='{{hanxuly}}'/>";
    box += "</div></div>";
    box += "</div>";
    box += "</div>";

    box = box.replace("{{id}}", id).replace("{{text}}", text).replace("{{hanxuly}}", hanxuly).replace("{{value}}", value);
    $("#listTrangThai2").append(box);
}

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

    box += "<label class='control-label col-sm-6 col-md-4'>Phòng ban đầu mối</label>";
    box += "<div class='controls col-sm-6 col-md-8'>";
    box += "<input class='form-control phongban' value='{{text}}' readonly/>";
    box += "</div></div></div>";

    box += "<div class='col-md-6 col-sm-6'>";
    box += "<div class='control-group row'>";

    box += "<label class='control-label col-sm-6 col-md-4'>Hạn xử lý</label>";
    box += "<div class='controls col-sm-6 col-md-8'>";
    box += "    <input class='form-control date-picker hanxuly' autocomplete='off' maxlength='10' value='{{hanxuly}}'/>";
    box += "</div></div>";
    box += "</div>";
    box += "</div>";

    box = box.replace("{{id}}", id).replace("{{text}}", text).replace("{{hanxuly}}", hanxuly).replace("{{value}}", value);
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

    box += "<label class='control-label col-sm-6 col-md-4'>Phòng phối hợp</label>";
    box += "<div class='controls col-sm-6 col-md-8'>";
    box += "<input class='form-control phongban' value='{{text}}' readonly/>";
    box += "</div></div></div>";

    box += "<div class='col-md-6 col-sm-6'>";
    box += "<div class='control-group row'>";

    box += "<label class='control-label col-sm-6 col-md-4'>Hạn xử lý</label>";
    box += "<div class='controls col-sm-6 col-md-8'>";
    box += "    <input class='form-control date-picker hanxuly' autocomplete='off' maxlength='10' value='{{hanxuly}}'/>";
    box += "</div></div>";
    box += "</div>";
    box += "</div>";

    box = box.replace("{{id}}", id).replace("{{text}}", text).replace("{{hanxuly}}", hanxuly).replace("{{value}}", value);
    $("#listTrangThai3").append(box);
}

function appendboxPBPHTab2(id, text, hanxuly, value, action) {
    $("#listTrangThai2").css("display", "block");
    if (action) {
        $("#kengang2").css("display", "block");
    }
    var box = "";
    box += "<div class='box-cauhinh row marginB-10'>";

    box += "    <input type='hidden' class='m-wrap span3 idphongban' value='{{id}}'>";
    box += "    <input type='hidden' class='m-wrap span3 idtrangthai' value='0'>";
    box += "<div class='col-md-6 col-sm-6'>";
    box += "<div class='control-group row'>";

    box += "<label class='control-label col-sm-6 col-md-4'>Phòng ban phối hợp</label>";
    box += "<div class='controls col-sm-6 col-md-8'>";
    box += "<input class='form-control phongban' value='{{text}}' readonly/>";
    box += "</div></div></div>";

    box += "<div class='col-md-6 col-sm-6'>";
    box += "<div class='control-group row'>";

    box += "<label class='control-label col-sm-6 col-md-4'>Hạn xử lý</label>";
    box += "<div class='controls col-sm-6 col-md-8'>";
    box += "    <input class='form-control date-picker hanxuly' autocomplete='off' maxlength='10' value='{{hanxuly}}'/>";
    box += "</div></div>";
    box += "</div>";
    box += "</div>";

    box = box.replace("{{id}}", id).replace("{{text}}", text).replace("{{hanxuly}}", hanxuly).replace("{{value}}", value);
    $("#listTrangThai2").append(box);
}

function onchangeTabThree(action) {
    $("#listTrangThai3").html("");
    var hanxuly = $("#HanXuLy").val();
    var value = "1";
    // Phòng ban đầu mối
    var pbDauMoi = $("#PhongDauMoi").val();
    var pbDauMoiText = $("#PhongDauMoi option:selected").text().trim();
    // Lãnh đạo đầu mối
    var ldDauMoi = $("#LanhDaoDauMoiTab3").val();
    var ldDauMoiText = $("#LanhDaoDauMoiTab3 option:selected").text().trim();
    if (pbDauMoi != "" || ldDauMoi != "") {
        if (ldDauMoi != "") {
            appendboxLDDMTab3(ldDauMoi, ldDauMoiText, hanxuly, value, action);
        }
        if (pbDauMoi != ""){
            appendboxPBDM(pbDauMoi, pbDauMoiText, hanxuly, value, action);
        }
    }
    else {
        $("#kengang3").css("display", "none");
    }

    // Phòng ban phối hợp
    var listpbPhoiHop = new Array();
    $('#PhongBanPhoiHop option:selected').each(function () {
        appendboxPBPH($(this).val(), $(this).text().trim(), hanxuly, value, action);
        listpbPhoiHop.push($(this).val() + "");
    });
    var index = listpbPhoiHop.indexOf(pbDauMoi);
    if (index >= 0) {
        listpbPhoiHop.splice(index, 1);
    }
    $(".date-picker").datepicker({
        format: 'dd/mm/yyyy'
    }).on('changeDate', function (e) {
        $(this).datepicker('hide');
    });
}

function onchangeTabTwo(action) {
    $("#listTrangThai2").html("");
    var hanxuly = $("#HanXuLy").val();
    var value = "1";
    // Lãnh đao đầu mối
    var lanhDaoDauMoi = $("#LanhDaoDauMoi").val();
    var lanhDaoDauMoiText = $("#LanhDaoDauMoi option:selected").text().trim();
    // Cán bộ đầu mối
    var canboDauMoi = $("#NguoiDauMoiID").val();
    var canboDauMoiText = $("#NguoiDauMoiID option:selected").text().trim();
    if (lanhDaoDauMoi != "" || canboDauMoi != "") {
        if (lanhDaoDauMoi != "") {
            appendboxLanhDao(lanhDaoDauMoi, lanhDaoDauMoiText, hanxuly, value, action);
        }
        if (canboDauMoi != "") {
            appendboxCBDM(canboDauMoi, canboDauMoiText, hanxuly, value, action);
        }
    } else {
        $("#kengang2").css("display", "none");
    }

    // Cán bộ phối hợp
    var listCBPhoiHop = new Array();
    $('#CanBoPhoiHop option:selected').each(function () {
        appendboxCBPH($(this).val(), $(this).text().trim(), hanxuly, value, action);
        listCBPhoiHop.push($(this).val() + "");
    });
    var index = listCBPhoiHop.indexOf(canboDauMoi);
    if (index >= 0) {
        listCBPhoiHop.splice(index, 1);
    }
    // Phòng ban phối hợp
    var listPBPhoiHop = new Array();
    
    $('#PhongBanPhoiHopTab2 option:selected').each(function () {
        appendboxPBPHTab2($(this).val(), $(this).text().trim(), hanxuly, value, action);
        listPBPhoiHop.push($(this).val() + "");
    });
    $(".date-picker").datepicker({
        format: 'dd/mm/yyyy'
    }).on('changeDate', function (e) {
        $(this).datepicker('hide');
    });
}

function onchangeTabOne(action) {
    $("#listTrangThai1").html("");
    var hanxuly = $("#HanXuLy").val();
    var value = "1";
    // Lãnh đao đầu mối
    var lanhDaoDauMoi = $("#LanhDaoID").val();
    var lanhDaoDauMoiText = $("#LanhDaoID option:selected").text().trim();
    // Đơn vị đầu mối
    var donViDauMoi = $("#DonViDauMoiID").val();
    var donViDauMoiText = $("#DonViDauMoiID option:selected").text().trim();
    if (lanhDaoDauMoi != "" || donViDauMoi != "") {
        if (lanhDaoDauMoi != "") {
            appendboxLDDM(lanhDaoDauMoi, lanhDaoDauMoiText, hanxuly, value, action);
        }
        if (donViDauMoi != "") {
            appendboxDVDM(donViDauMoi, donViDauMoiText, hanxuly, value, action);
        }
    } else {
        $("#kengang1").css("display", "none");
    }

    // Đơn vị phối hợp
    var listDVPhoiHop = new Array();
    $('#DonViPhoiHop option:selected').each(function () {
        appendboxDVPH($(this).val(), $(this).text(), hanxuly, value, action);
        listDVPhoiHop.push($(this).val() + "");
    });
    var index = listDVPhoiHop.indexOf(donViDauMoi);
    if (index >= 0) {
        listDVPhoiHop.splice(index, 1);
    }
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
            HanXuLy:{date:true}
        },
        submitHandler: function () {
            $("#btnSubmit").attr('disabled', true);
            // Validate cán bộ phòng ban phụ trách
            //if (($("#DonViDauMoiID").val() == "" || $("#DonViDauMoiID").val() == undefined) && $("#NguoiDauMoiID").val() == "" && (($('#PhongDauMoi').val() == "") || $('#PhongDauMoi').val() == undefined)) {
            //    $("#FormMessage").html('<div class="alert alert-success"><button data-dismiss="alert" class="close"></button><strong>Chú ý: </strong>Bạn chưa chọn đơn vị hoặc cán bộ đầu mối.</div>');
            //    $("#btnSubmit").attr('disabled', false);
            //    setTimeout(function () {
            //        $("#FormMessage").html("");
            //    }, 5000);
            //    $('html, body').animate({ scrollTop: 0 }, 100);
            //    return false;
            //}
            // Validate ngày tháng
            if ($('#NgayBatDau').val() != '') {
                if (!isValidDate($('#NgayBatDau').val())) {
                    submit = false;
                    $("#FormMessage").html('<div class="alert alert-success"><button data-dismiss="alert" class="close"></button><strong>Có lỗi xảy ra: </strong>Bạn vui lòng nhập lại định dạng ngày tháng.</div>');
                    $("#btnSubmit").attr('disabled', false);
                    $('html, body').animate({ scrollTop: 0 }, 100);
                    return false;
                }
            }
            if ($('#HanXuLy').val() != '') {
                if (!isValidDate($('#HanXuLy').val())) {
                    submit = false;
                    $("#FormMessage").html('<div class="alert alert-success"><button data-dismiss="alert" class="close"></button><strong>Có lỗi xảy ra: </strong>Bạn vui lòng nhập lại định dạng ngày tháng.</div>');
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
            // Validate hạn xử lý vs ngày bắt đầu
            if (hxl < nbd) {
                $("#btnSubmit").attr('disabled', false);
                $("#FormMessage").html('<div class="alert alert-success"><button data-dismiss="alert" class="close"></button><strong>Có lỗi xảy ra: </strong>Hạn xử lý không được nhỏ hơn ngày bắt đầu công việc.</div>');
                setTimeout(function () { $("#HanXuLy").focus(); }, 3100);
                setTimeout(function () {
                    $("#FormMessage").html("");
                }, 3000);
                $('html, body').animate({ scrollTop: 0 }, 100);
                return false;
            }
            // Validate hạn xử lý người dùng  vs hạn xử lý công việc
            $("#listTrangThai1 .box-cauhinh").each(function () {
                var arrHxlND = $(this).find('.hanxuly').val().split('/');
                var hxlnd = new Date(arrHxlND[2], arrHxlND[1] - 1, arrHxlND[0]);
                if ($('#HanXuLy').val() != "" && $(this).find('.hanxuly').val() == "") {
                    submit = false;
                    $("#FormMessage").html('<div class="alert alert-success"><button data-dismiss="alert" class="close"></button><strong>Có lỗi xảy ra: </strong>Bạn chưa chọn hạn xử lý cá nhân.</div>');
                    $("#btnSubmit").attr('disabled', false);
                    $('html, body').animate({ scrollTop: 0 }, 100);
                    return false;
                }
                if ($('.hanxuly').val() != '') {
                    if (!isValidDate($('.hanxuly').val())) {
                        submit = false;
                        $("#FormMessage").html('<div class="alert alert-success"><button data-dismiss="alert" class="close"></button><strong>Có lỗi xảy ra: </strong>Bạn vui lòng nhập lại định dạng ngày tháng.</div>');
                        $("#btnSubmit").attr('disabled', false);
                        $('html, body').animate({ scrollTop: 0 }, 100);
                        return false;
                    }
                }
                if ((hxl < hxlnd || hxlnd < nbd)) {
                    submit = false;
                    $("#FormMessage").html('<div class="alert alert-success"><button data-dismiss="alert" class="close"></button><strong>Có lỗi xảy ra: </strong>Hạn xử lý công việc cá nhân không được lớn hơn hạn xử lý công việc hoặc nhỏ hơn ngày bắt đầu công việc.</div>');
                    $("#btnSubmit").attr('disabled', false);
                    $('html, body').animate({ scrollTop: 0 }, 100);
                    return false;
                }
            });
            $("#listTrangThai2 .box-cauhinh").each(function () {
                var arrHxlND = $(this).find('.hanxuly').val().split('/');
                var hxlnd = new Date(arrHxlND[2], arrHxlND[1] - 1, arrHxlND[0]);
                if ($('#HanXuLy').val() != "" && $(this).find('.hanxuly').val() == "") {
                    submit = false;
                    $("#FormMessage").html('<div class="alert alert-success"><button data-dismiss="alert" class="close"></button><strong>Có lỗi xảy ra: </strong>Bạn chưa chọn hạn xử lý cá nhân.</div>');
                    $("#btnSubmit").attr('disabled', false);
                    $('html, body').animate({ scrollTop: 0 }, 100);
                    return false;
                }
                if ($('.hanxuly').val() != '') {
                    if (!isValidDate($('.hanxuly').val())) {
                        submit = false;
                        $("#FormMessage").html('<div class="alert alert-success"><button data-dismiss="alert" class="close"></button><strong>Có lỗi xảy ra: </strong>Bạn vui lòng nhập lại định dạng ngày tháng.</div>');
                        $("#btnSubmit").attr('disabled', false);
                        $('html, body').animate({ scrollTop: 0 }, 100);
                        return false;
                    }
                }
                if ((hxl < hxlnd || hxlnd < nbd)) {
                    submit = false;
                    $("#FormMessage").html('<div class="alert alert-success"><button data-dismiss="alert" class="close"></button><strong>Có lỗi xảy ra: </strong>Hạn xử lý công việc cá nhân không được lớn hơn hạn xử lý công việc hoặc nhỏ hơn ngày bắt đầu công việc.</div>');
                    $("#btnSubmit").attr('disabled', false);
                    $('html, body').animate({ scrollTop: 0 }, 100);
                    return false;
                }
            });
            $("#listTrangThai3 .box-cauhinh").each(function () {
                var arrHxlND = $(this).find('.hanxuly').val().split('/');
                var hxlnd = new Date(arrHxlND[2], arrHxlND[1] - 1, arrHxlND[0]);
                // Trường hợp hạn xử lý cá nhân trống
                //if ($('#HanXuLy').val() != "" && $(this).find('.hanxuly').val() == "") {
                //    submit = false;
                //    $("#FormMessage").html('<div class="alert alert-success"><button data-dismiss="alert" class="close"></button><strong>Có lỗi xảy ra: </strong>Bạn chưa chọn hạn xử lý cá nhân.</div>');
                //    $("#btnSubmit").attr('disabled', false);
                //    $('html, body').animate({ scrollTop: 0 }, 100);
                //    return false;
                //}
                // Trường hợp hạn xử lý sai định dạng ngày tháng
                if ($('.hanxuly').val() != '') {
                    if (!isValidDate($('.hanxuly').val())) {
                        submit = false;
                        $("#FormMessage").html('<div class="alert alert-success"><button data-dismiss="alert" class="close"></button><strong>Có lỗi xảy ra: </strong>Bạn vui lòng nhập lại định dạng ngày tháng.</div>');
                        $("#btnSubmit").attr('disabled', false);
                        $('html, body').animate({ scrollTop: 0 }, 100);
                        return false;
                    }
                }
                // Trường hợp validate dữ liệu
                if ((hxl < hxlnd || hxlnd < nbd)) {
                    submit = false;
                    $("#FormMessage").html('<div class="alert alert-success"><button data-dismiss="alert" class="close"></button><strong>Có lỗi xảy ra: </strong>Hạn xử lý công việc cá nhân không được lớn hơn hạn xử lý công việc hoặc nhỏ hơn ngày bắt đầu công việc.</div>');
                    $("#btnSubmit").attr('disabled', false);
                    $('html, body').animate({ scrollTop: 0 }, 100);
                    return false;
                }
            });
            
            if (!submit)
                return false;
            getTrangThai();
            getTrangThai2();
            getTrangThai3();
            $.post(urlPostAction, $("#FormCongViec").mySerialize(), function (data) {

                if (data.Error) {
                    $("#btnSubmit").attr('disabled', false);
                    $("#FormMessage").html('<div class="alert alert-success"><button data-dismiss="alert" class="close"></button><strong>Có lỗi xảy ra.!</strong> ' + data.Title + '</div>');
                    $('html, body').animate({ scrollTop: 0 }, 100);
                }
                else {
                    $("#btnCloseModal").click();
                    $("#btnSubmit").attr('disabled', false);
                    createCloseMessage2("Thông báo", data.Title, '/Pagess/chi-tiet-cong-viec.aspx?do=view&HoSoCongViecID=' + data.ID); // Tạo thông báo khi click đóng thì chuyển đến url đích
                }
            });
            //}
            return false;
        }
    });
}

function getTrangThai() {
    var trangthai = "";
    $('#listTrangThai1 .box-cauhinh').each(function () {
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
    $("#hdfTrangThai").val(trangthai);
}

function getTrangThai2() {
    var trangthai = "";
    $('#listTrangThai2 .box-cauhinh').each(function () {
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
    $("#hdfTrangThai2").val(trangthai);
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
