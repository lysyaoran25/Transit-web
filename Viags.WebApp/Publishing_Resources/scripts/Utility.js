
// Action cho việc nếu số điện thoại đăng ký không có.
function actionSoDienThoaiDK(action) {
    $.each($('#otpValidType').find('option'), function (i, v) {
        try {
            if ($(v).attr('data-firstBK') == undefined)
                $(v).attr('data-firstBK', 'false');
            if (action == true) {
                if ($(v).attr('data-firstBK') == 'false') {
                    $(v).attr('data-disable-backup', $(v).attr('data-disable'));
                    $(v).attr('data-firstBK', 'true');
                }
                $(v).attr('data-disable', 0);
            }
            else
                $(v).attr('data-disable', $(v).attr('data-disable-backup'));
        } catch (e) {

        }
    });
}

// get status OTP
function getOTPStatus() {
    var el = $('#otpValidType').find('option:selected');
    var check = $(el).attr('data-disable');
    return check == 1 ? 1 : 0;
}

// ham doc Cookie chuyen doi ngon ngu

function writeCookie(name, value, days) {
    var date, expires;
    if (days) {
        date = new Date();
        date.setTime(date.getTime() + (days * 24 * 60 * 60 * 1000));
        expires = "; expires=" + date.toGMTString();
    } else {
        expires = "";
    }
    document.cookie = name + "=" + value + expires + "; path=/";
}

function readCookie(name) {
    var nameEQ = name + "=";
    var ca = document.cookie.split(';');
    for (var i = 0; i < ca.length; i++) {
        var c = ca[i];
        while (c.charAt(0) == ' ') c = c.substring(1, c.length);
        if (c.indexOf(nameEQ) == 0) return c.substring(nameEQ.length, c.length);
    }
    return null;
}

function clearCookie(name) {
    writeCookie(name, '', -1);
}

var _cultureValue = readCookie('_cultureValue');
if (_cultureValue == null) {
    document.cookie = '_cultureValue=vi-VN;path=/';
    $('#linkLanguage').attr('language', 'en');
    $('#liLanguague').addClass('vietnamese');
    $('#liLanguague').removeClass('english');
}
else if (_cultureValue == 'en-US') {
    $('#linkLanguage').attr('language', 'vi');
    $('#liLanguague').addClass('vietnamese');
    $('#liLanguague').removeClass('english');
}
else if (_cultureValue == 'vi-VN') {
    $('#linkLanguage').attr('language', 'en');
    $('#liLanguague').removeClass('vietnamese');
    $('#liLanguague').addClass('english');
}

// indexOf for IE
if (!Array.prototype.indexOf) {
    Array.prototype.indexOf = function (elt /*, from*/) {
        var len = this.length >>> 0;
        var from = Number(arguments[1]) || 0;
        from = (from < 0) ? Math.ceil(from) : Math.floor(from);
        if (from < 0) from += len;

        for (; from < len; from++) {
            if (from in this && this[from] === elt) return from;
        }
        return -1;
    };
}

//overwrite method ajax


// Sự kiện hiện chú ý
function viewNote() {
    $('.moreDetails').click(function () {
        $.each($('#popupDialog').find('.infoHiden'), function (i, v) {
            $(v).show();
        });
        $('.infoHiden').show();
        $('.divMoreDetails').hide();
        $('.divCollapseDetails').show();
        return false;
    });
    $('.collapseDetails').click(function () {
        $.each($('#popupDialog').find('.infoHiden'), function (i, v) {
            $(v).hide();
        });
        $('.infoHiden').hide();
        $('.divMoreDetails').show();
        $('.divCollapseDetails').hide();
        return false;
    });
}

// xử lý phương thức nhận mã OTP
function checkOTPResult(data) {
    if (data == undefined)
        return false;
    $("#ST2_Challenge").html(data.Status.Obj.Challenge);
    $("#OTPmessage").html(data.Status.Title);
    $("#ST2_SoLenh").html(data.SoLenh);

    $("#step3ChildForm tr").hide();
    //Hiển thị thông tin hình thức tt
    if (data.HinhThucNhanOTP == "3") {
        $("#step3ChildForm tr.smsContent").show();
    } else if (data.HinhThucNhanOTP == "2" || data.HinhThucNhanOTP == "7") {
        $("#step3ChildForm tr.emvContent").show();
    } else {
        $("#step3ChildForm tr.otpContent").show();
    }
}

// Chuyển từ số sang chữ tiếng Việt
var mangso = ['không', 'một', 'hai', 'ba', 'bốn', 'năm', 'sáu', 'bảy', 'tám', 'chín'];
function fnDocHangChuc(so, daydu) {
    var chuoi = "";
    chuc = Math.floor(so / 10);
    donvi = so % 10;
    if (chuc > 1) {
        chuoi = " " + mangso[chuc] + " mươi";
        if (donvi == 1) {
            chuoi += " mốt";
        }
    } else if (chuc == 1) {
        chuoi = " mười";
        if (donvi == 1) {
            chuoi += " một";
        }
    } else if (daydu && donvi > 0) {
        chuoi = " lẻ";
    }
    if (donvi == 5 && chuc > 1) {
        chuoi += " lăm";
    } else if (donvi > 1 || (donvi == 1 && chuc == 0)) {
        chuoi += " " + mangso[donvi];
    }
    return chuoi;
}
function fnDocBlock(so, daydu) {
    var chuoi = "";
    tram = Math.floor(so / 100);
    so = so % 100;
    if (daydu || tram > 0) {
        chuoi = " " + mangso[tram] + " trăm";
        chuoi += fnDocHangChuc(so, true);
    } else {
        chuoi = fnDocHangChuc(so, false);
    }
    return chuoi;
}
function fnDocHangTrieu(so, daydu) {
    var chuoi = "";
    trieu = Math.floor(so / 1000000);
    so = so % 1000000;
    if (trieu > 0) {
        chuoi = fnDocBlock(trieu, daydu) + " triệu";
        daydu = true;
    }
    nghin = Math.floor(so / 1000);
    so = so % 1000;
    if (nghin > 0) {
        chuoi += fnDocBlock(nghin, daydu) + " nghìn";
        daydu = true;
    }
    if (so > 0) {
        chuoi += fnDocBlock(so, daydu);
    }
    return chuoi;
}
function fnConvertTienTiengViet(so) {
    if (so == 0) return mangso[0];
    var chuoi = "", hauto = "";
    do {
        ty = so % 1000000000;
        so = Math.floor(so / 1000000000);
        if (so > 0) {
            chuoi = fnDocHangTrieu(ty, true) + hauto + chuoi;
        } else {
            chuoi = fnDocHangTrieu(ty, false) + hauto + chuoi;
        }
        hauto = " tỷ";
    } while (so > 0);
    return chuoi;
}

Number.prototype.formatMoney = function (decPlaces, thouSeparator, decSeparator) {
    var n = this,
        decPlaces = isNaN(decPlaces = Math.abs(decPlaces)) ? 2 : decPlaces,
        decSeparator = decSeparator == undefined ? "." : decSeparator,
        thouSeparator = thouSeparator == undefined ? "," : thouSeparator,
        sign = n < 0 ? "-" : "",
        i = parseInt(n = Math.abs(+n || 0).toFixed(decPlaces)) + "",
        j = (j = i.length) > 3 ? j % 3 : 0;
    return sign + (j ? i.substr(0, j) + thouSeparator : "") + i.substr(j).replace(/(\d{3})(?=\d)/g, "$1" + thouSeparator) + (decPlaces ? decSeparator + Math.abs(n - i).toFixed(decPlaces).slice(2) : "");
};


function moneyFormat(money) {
    var strFormat = (money == null) ? "0" : money.toString();
    //strFormat = strFormat.replace(/\D+/g, '');
    //strFormat = strFormat.replace(/\d(?=(?:\d{3})+(?!\d))/g, '$&,');
    return strFormat.replace(/\d(?=(?:\d{3})+(?!\d))/g, '$&,');
}

$.curCSS = function (element, attrib, val) {
    $(element).css(attrib, val);
};


/// loading khi thực hiện các chức năng
function loading() {
    $("#dialog-loading").html("<div style=\"text-align:center\"><img src=\"" + appPath + "/Content/web/images/icon_loading.gif\" /></div>");
    $("#dialog-loading").dialog({
        closeOnEscape: false,
        resizable: false,
        height: 170,
        width: 100,
        modal: true
    });
    $('#dialog-loading').dialog('widget').find(".ui-dialog-titlebar").hide();
    $('#dialog-loading').dialog('widget').find(".ui-resizable-handle").hide();
    $('#dialog-loading').css('height', '100px', 'overflow', 'hidden');

}

function endLoading() {
    $("#dialog-loading").html("").dialog('close');
}


// Remove dialog when form submit
$(document).ready(function () {
    $('form').bind('submit', function () {
        $('.growl').remove();
    });
});

function createMessage(title, message) {
    $('.growl').remove();
    return $.growl.error({
        title: title,
        message: message
        //fixed: true
    });
}

function createMessageOk(title, message) {
    $('.growl').remove();
    return $.growl.notice({
        title: title,
        message: message
        //fixed: true
    });
}

function createMessageRefresh(title, message) {
    $("#dialog-message").attr("title", title);
    $("#dialog-message").html("<p>" + message + "</p>");
    $("#dialog-message").dialog({
        resizable: true,
        height: 'auto',
        width: 'auto',
        modal: true,
        buttons: {
            "Đóng lại": function () {
                location.reload();
            }
        }
    });
}



// Format Unicode 
function UnicodeToAscii(obj) {
    var str = obj;
    str = str.replace(/à|á|ạ|ả|ã|â|ầ|ấ|ậ|ẩ|ẫ|ă|ằ|ắ|ặ|ẳ|ẵ/g, "a");
    str = str.replace(/è|é|ẹ|ẻ|ẽ|ê|ề|ế|ệ|ể|ễ/g, "e");
    str = str.replace(/ì|í|ị|ỉ|ĩ/g, "i");
    str = str.replace(/ò|ó|ọ|ỏ|õ|ô|ồ|ố|ộ|ổ|ỗ|ơ|ờ|ớ|ợ|ở|ỡ/g, "o");
    str = str.replace(/ù|ú|ụ|ủ|ũ|ư|ừ|ứ|ự|ử|ữ/g, "u");
    str = str.replace(/ỳ|ý|ỵ|ỷ|ỹ/g, "y");
    str = str.replace(/đ/g, "d");
    str = str.replace(/À|Á|Ạ|Ả|Ã|Â|Ầ|Ấ|Ậ|Ẩ|Ẫ|Ă|Ằ|Ắ|Ặ|Ẳ|Ẵ/g, "A");
    str = str.replace(/È|É|Ẹ|Ẻ|Ẽ|Ê|Ề|Ế|Ệ|Ể|Ễ/g, "E");
    str = str.replace(/Ì|Í|Ị|Ỉ|Ĩ/g, "I");
    str = str.replace(/Ò|Ó|Ọ|Ỏ|Õ|Ô|Ồ|Ố|Ộ|Ổ|Ỗ|Ơ|Ờ|Ớ|Ợ|Ở|Ỡ/g, "O");
    str = str.replace(/Ù|Ú|Ụ|Ủ|Ũ|Ư|Ừ|Ứ|Ự|Ử|Ữ/g, "U");
    str = str.replace(/Ỳ|Ý|Ỵ|Ỷ|Ỹ/g, "Y");
    str = str.replace(/Đ/g, "D");
    str = str.replace(/![a-z|A-Z|0-9]/g, "");  /* tìm và thay thế các kí tự đặc biệt trong chuỗi sang kí tự - */
    return str;
}

// Format Unicode for ThanhToanHoaDon
function UnicodeToAsciiHD(obj) {
    var str = obj;
    str = str.replace(/à|á|ạ|ả|ã|â|ầ|ấ|ậ|ẩ|ẫ|ă|ằ|ắ|ặ|ẳ|ẵ/g, "a");
    str = str.replace(/è|é|ẹ|ẻ|ẽ|ê|ề|ế|ệ|ể|ễ/g, "e");
    str = str.replace(/ì|í|ị|ỉ|ĩ/g, "i");
    str = str.replace(/ò|ó|ọ|ỏ|õ|ô|ồ|ố|ộ|ổ|ỗ|ơ|ờ|ớ|ợ|ở|ỡ/g, "o");
    str = str.replace(/ù|ú|ụ|ủ|ũ|ư|ừ|ứ|ự|ử|ữ/g, "u");
    str = str.replace(/ỳ|ý|ỵ|ỷ|ỹ/g, "y");
    str = str.replace(/đ/g, "d");
    str = str.replace(/À|Á|Ạ|Ả|Ã|Â|Ầ|Ấ|Ậ|Ẩ|Ẫ|Ă|Ằ|Ắ|Ặ|Ẳ|Ẵ/g, "A");
    str = str.replace(/È|É|Ẹ|Ẻ|Ẽ|Ê|Ề|Ế|Ệ|Ể|Ễ/g, "E");
    str = str.replace(/Ì|Í|Ị|Ỉ|Ĩ/g, "I");
    str = str.replace(/Ò|Ó|Ọ|Ỏ|Õ|Ô|Ồ|Ố|Ộ|Ổ|Ỗ|Ơ|Ờ|Ớ|Ợ|Ở|Ỡ/g, "O");
    str = str.replace(/Ù|Ú|Ụ|Ủ|Ũ|Ư|Ừ|Ứ|Ự|Ử|Ữ/g, "U");
    str = str.replace(/Ỳ|Ý|Ỵ|Ỷ|Ỹ/g, "Y");
    str = str.replace(/Đ/g, "D");
    return str;
}


// Valid định dạng ngày tháng dd/MM/yyy
function isValidDate(dateString) {
    // Kiểm tra định dạng  
    if (!/^\d{1,2}\/\d{1,2}\/\d{4}$/.test(dateString))
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


// Lấy index con trỏ chuột
function getCursorPosition(ctrl) {
    
    try
    {
        var CaretPos = {
            start: 0,
            end: 0
        };
        // IE Support
        if (document.selection) {
            //ctrl.focus();
            var Sel = document.selection.createRange();
            Sel.moveStart('character', -ctrl.value.length);
            CaretPos.start = CaretPos.end = Sel.text.length;
        }
            // Firefox support
        else if (ctrl.selectionStart || ctrl.selectionStart == '0') {
            CaretPos.start = ctrl.selectionStart;
            CaretPos.end = ctrl.selectionEnd;
        }
        return (CaretPos);
    }
    catch(ex)
    {
        return null
    }
    
}

// Set index con trỏ chuột
function setCursorPosition(ctrl, pos) {
    if (ctrl.setSelectionRange) {
        ctrl.focus();
        ctrl.setSelectionRange(pos.start, pos.end);
    }
    else if (ctrl.createTextRange) {
        var range = ctrl.createTextRange();
        range.collapse(true);
        range.moveEnd('character', pos.end);
        range.moveStart('character', pos.start);
        range.select();
    }
}

// Check valid number
function IsNumericVCB(obj) {
    return !jQuery.isArray(obj) && (obj - parseFloat(obj) + 1) >= 0;
}

// Plugins for jQuery - DungNT
(function ($) {

    // Format tiền tệ
    $.fn.formatValidAmount = function () {
        $.fn.formatValidAmount.isVND = ($.fn.formatValidAmount.isVND == true) ? true : false;
        var me = this;

        // Format current value
        var valCurrent =  $(me).val();
        if (valCurrent != undefined && valCurrent != null && valCurrent.length > 0)
        {
            valCurrent = valCurrent.replace(/,/g, '');
            if ($.fn.formatValidAmount.isVND)
            {
                if (valCurrent.indexOf('.') > 0);
                {
                    valCurrent = valCurrent.split('.')[0];
                }
            }
            $(me).val(valCurrent.replace(/\d(?=(?:\d{3})+(?!\d))/g, '$&,'));
        }

        me.keydown(function (e) {
            var val = $(me).val();
            if (val == null || val == undefined || val == '')
            {
                $(me).attr('data-prev', '');
            }
            else if (IsNumericVCB(val.replace(/,/g,''))) {
                $(me).attr('data-prev', $(me).val());
            }
        });

        me.keyup(function (e) {
            var val = $(me).val();
            var valC = $(me).val();
            var prev = $(me).attr('data-prev');
            if (val == prev)
                return;
            if (val != undefined && val != '' && val != null) {
                val = val.replace(/,/g, '');
                if (!IsNumericVCB(val)) {
                    $(me).val(prev);
                }
                else {
                    
                    var strNum = parseFloat(val).toFixed(2);
                    var tt = '';
                    if ($.fn.formatValidAmount.isVND)
                    {
                        strNum = parseInt(val);
                    }
                    else
                    {
                        if (val.indexOf('.') > 0)
                        {
                            tt = '.' + val.split('.')[1].substring(0,2);
                        }
                    }
                    var cur = getCursorPosition(e.currentTarget);
                    var valSet = strNum.toString().split('.')[0].replace(/\d(?=(?:\d{3})+(?!\d))/g, '$&,');
                    $(me).val(valSet + tt);
                    if(cur != undefined && cur != null)
                    {
                        cur.start = cur.end = cur.start + (valSet.length - valC.split('.')[0].length);
                        setCursorPosition(e.currentTarget, cur);
                    }

                }
            }
        });

        me.blur(function (e) {
            var val = $(me).val();
            if (val != undefined && val != '' && val != null) {
                val = val.replace(/,/g, '');
                if (IsNumericVCB(val)) {
                    var strNum = parseFloat(val).toFixed(2);
                    if ($.fn.formatValidAmount.isVND)
                        strNum = parseInt(val);
                    if (strNum - parseInt(strNum) > 0)
                        $(me).val(strNum.toString().split('.')[0].replace(/\d(?=(?:\d{3})+(?!\d))/g, '$&,') + '.' + strNum.toString().split('.')[1]);
                    else
                        $(me).val(strNum.toString().split('.')[0].replace(/\d(?=(?:\d{3})+(?!\d))/g, '$&,'));
                }
            }
        });
    }

    $.fn.IsVND = function (isVND) {
        $.fn.formatValidAmount.isVND = (isVND == true) ? true : false;
        if ($.fn.formatValidAmount.isVND)
            $(this).val($(this).val().split('.')[0]);
    }

    // Nhập liệu không dấu
    $.fn.nonVN = function (OnlyNumber) {
        var me = this;
        var unRegex = /[^A-Za-z0-9@_\-.,&*#!$+:;?\/\|%()><= ]/g;
        OnlyNumber = (OnlyNumber == true) ? true : false;
        if (OnlyNumber)
        {
            unRegex = /\D/g;
        }

        me.keyup(function (e) {
            var temp = $(this).val();
            if (!OnlyNumber)
                temp = UnicodeToAsciiHD(temp);
            var poi = getCursorPosition(e.currentTarget);
            $(this).val(temp.replace(unRegex, ''));
            if(poi != null)
                setCursorPosition(this, poi);
        });
        
    };

    // Nhập liệu không dấu
    $.fn.nonVNHoaDon = function (OnlyNumber) {
        var me = this;
        var unRegex = /[^A-Za-z0-9_\-]/g;
        OnlyNumber = (OnlyNumber == true) ? true : false;
        if (OnlyNumber) {
            unRegex = /\D/g;
        }
        me.keyup(function (e) {
            var temp = $(this).val();
            if (!OnlyNumber)
                temp = UnicodeToAsciiHD(temp);
            var poi = getCursorPosition(e.currentTarget);
            $(this).val(temp.replace(unRegex, ''));
            if (poi != null)
                setCursorPosition(this, poi);
        });

    };
}(jQuery));

// Overwrite Serialize jQuery
(function ($) {

    $.fn.serialize = function (options) {
        return $.param(this.serializeArray(options));
    };

    $.fn.serializeArray = function (options) {
        var o = $.extend({
            checkboxesAsBools: false
        }, options || {});

        var rselectTextarea = /select|textarea/i;
        var rinput = /text|hidden|password|search/i;

        return this.map(function () {
            return this.elements ? $.makeArray(this.elements) : this;
        })
        .filter(function () {
            return this.name && !this.disabled &&
                (this.checked
                || (o.checkboxesAsBools && this.type === 'checkbox')
                || rselectTextarea.test(this.nodeName)
                || rinput.test(this.type));
        })
            .map(function (i, elem) {
                var val = $(this).val();
                return val == null ?
                null :
                $.isArray(val) ?
                $.map(val, function (val, i) {
                    return { name: elem.name, value: val };
                }) :
             {
                 name: elem.name,
                 value: (o.checkboxesAsBools && this.type === 'checkbox') ? //moar ternaries!
                        (this.checked ? 'true' : 'false') :
                        val
             };
            }).get();
    };

})(jQuery);



