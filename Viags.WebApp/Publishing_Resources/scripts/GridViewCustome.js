
var lastGirdHeight;
var urlDeleteFrefix = "";
var urlHideFrefix = "";
var urlShowFrefix = "";
var urlApprovedFrefix = "";
var urlPendingFrefix = "";
var imageLoading = "<div style='text-align:center'><img src='/Publishing_Resources/img/loadingAnimation.gif' alt='Đang tải dữ liệu'/></div>";
var urlLists = '';
var urlForm = '';
var urlWorkFlow = '';
var urlFormGroup = '';
var urlPostAction = '';
var urlPostActionGroup = '';
var urlSort = '';
var urlListRole = '';
var urlListRoleVaiTro = '';
var urlResetPass = '';
var urlSortGroup = '';
var urlView = '';
var urlViewGroup = '';
var formHeight = 'auto';
var formWidth = '600';
var STTRow = '';
var boolCheck = false;
var boolCheckup = false;
var gridContainer = '';
(function ($) {
    $.fn.mySerialize = function () {
        var returning = '';
        var indexOfKeyValue = 0;
        var startValue = '';
        var endValue = '';
        //Dùng cho select, multiSelect đều đc
        $('select', this).each(function () {
            var valueSelect = '';
            $(this).find("option:selected ").each(function () {
                valueSelect += $(this).attr("value") + ',';
            });
            if (valueSelect.length > 0)
                valueSelect = valueSelect.substring(0, valueSelect.length - 1)
            if (valueSelect != '')
                returning += this.name + '=' + decodeURIComponent(valueSelect) + '&';
        });

        //Checkbox = false;
        $('input[type=checkbox]:not(:checked)', this).not('.group').each(function () {
            this.value = 'false';
            returning += this.name + '=false&';
        });

        //checkbox = true
        $('input[type=checkbox]:checked', this).not('.group').each(function () {
            this.value = 'true';
        });

        //input và textarea
        returning += $('input, textarea', this).not('.group').serialize();
        return returning;
    };
})(jQuery);
function checkdate(tager, newdate) {
    if (($(tager).val().length > 0 && ValidDate($(tager).val()) == false)) {
        $(tager).datepicker({ dateFormat: "yy/mm/dd" }).datepicker("setDate", newdate);
    }
}
function Printscript(starHeight, selectBindParent, selectBindChildrent) {
    var startPage = 1;
    var maxHeight = 610; //Chiều cao mỗi trang
    // var starHeight = 225; //Bắt đầu từ top đến trang đầu tiên

    var htmlBinding = '';
    var htmlTempStart = '<table class="table table-bordered table-responsive">';//Mã html tem
    var htmlTempEnd = '</table>';
    var headingTemp = '';
    htmlBinding += htmlTempStart; //Bắt đầu table
    htmlBinding += headingTemp;
    selectBindChildrent.each(function (index, element) {
        starHeight += $(this).height();
        htmlBinding += "<tr>" + $(this).html() + "</tr>";
        if (starHeight > maxHeight) { //nếu vượt quá 1 dòng
            htmlBinding += htmlTempEnd;
            htmlBinding += "<div class=\"break-page\">Page " + startPage + "</div>";
            htmlBinding += htmlTempStart; //Bắt đầu table
            htmlBinding += headingTemp;
            starHeight = 0;
            startPage++;
        }
    });
    htmlBinding += htmlTempEnd; //Kết thúc table
    htmlBinding += "<div class=\"break-page\">Page " + (startPage) + "</div>";
    selectBind.html(htmlBinding);
}
function validateCombobox() {
    $("select").change(function () {
        if ($(this).val() != "" && $(this).attr("aria-required") == "true") {
            $(this).removeClass("error");
            $(this).parent().children(".select2-container").attr("data-original-title", "");
            $(".tooltip").css("display", "none");
        }
        if ($(this).val() == "" && $(this).attr("aria-required") == "true") {
            $(this).addClass("error");
            $(this).parent().children().attr("data-original-title", "Trường dữ liệu này cần phải nhập");
        }

    });
}
function resetformvalidate() {
    $("input,select,textarea").removeClass("error");
    $("input,select,textarea").tooltip('destroy');
    $("label.error").css("display", "none");

}
//căn popub ra giữa màn hình
function centerModals() {
    var $modals;
    $modals = $('.modal:visible');
    $modals.each(function (i) {
        var $clone = $(this).clone().css('display', 'block').appendTo('body');
        var top = Math.round(($clone.height() - $clone.find('.modal-content').height()) / 2);
        top = top > 0 ? top : 0;
        $clone.remove();
        $(this).find('.modal-content').css("margin-top", top);
    });
}
function resetchecbox() {
    $("input[type=checkbox]").attr("checked", false);
}
///Lấy giá trị form
function getValueFormMutilSelect(form) {
    var arrParam = '';
    var idMselect;
    $(form).find("input,textarea,select,hidden").not("input[type='checkbox'], input[type='radio']:checked").each(function () {
        idMselect = $(this).attr("name");
        if ($(this).val() != '' && $(this).val() != 'Từ khóa tìm kiếm')
            arrParam += "&" + idMselect + "=" + $(this).val();
    });
    $("a.multiSelect").each(function () {
        idMselect = $(this).attr("id");
        if (getValueMutilSelect(idMselect) != '')
            arrParam += "&" + idMselect + "=" + getValueMutilSelect(idMselect);
    });
    if (arrParam != '')
        arrParam = arrParam.substring(1);

    if (arrParam.contains("&SearchIn=null&Keyword=") || arrParam.indexOf("&SearchIn=null&Keyword=") > 0) {
        createMessage("Thông báo", "Chưa chọn phạm vi tìm kiếm");
        return false;

    } else {
        return arrParam;
    }
}




// load ajax page
//function LoadAjaxPage(urlPage, container) {
//    $.post(urlPage, function (data) {
//        $(container).html(data);
//    });
//}
//load data
function LoadAjaxPage(urlPage, container) {
    console.log(urlPage);
    debugger
    $.ajax({
        type: "GET",
        url: urlPage,
        cache: false,
        success: function (data) {
            $(container).html(data);
        }
    });
}
function LoadAjaxPage(urlPage, container, async) {
    console.log(urlPage);
    $.ajax({
        type: "GET",
        async: async,
        url: urlPage,
        cache: false,
        success: function (data) {
            $(container).html(data);
        }
    });
}


//Thay đổi thứ tự order
function Reorder(eSelect, iCurrentField, numSelects) {
    var eForm = eSelect.form;
    var iNewOrder = eSelect.selectedIndex + 1;
    var iPrevOrder;
    var positions = new Array(numSelects);
    var ix;
    for (ix = 0; ix < numSelects; ix++) {
        positions[ix] = 0;
    }
    for (ix = 0; ix < numSelects; ix++) {
        positions[eSelect.form["ViewOrder" + ix].selectedIndex] = 1;
    }
    for (ix = 0; ix < numSelects; ix++) {
        if (positions[ix] == 0) {
            iPrevOrder = ix + 1;
            break;
        }
    }
    if (iNewOrder != iPrevOrder) {
        var iInc = iNewOrder > iPrevOrder ? -1 : 1
        var iMin = Math.min(iNewOrder, iPrevOrder);
        var iMax = Math.max(iNewOrder, iPrevOrder);
        for (var iField = 0; iField < numSelects; iField++) {
            if (iField != iCurrentField) {
                if (eSelect.form["ViewOrder" + iField].selectedIndex + 1 >= iMin &&
					eSelect.form["ViewOrder" + iField].selectedIndex + 1 <= iMax) {
                    eSelect.form["ViewOrder" + iField].selectedIndex += iInc;
                }
            }
        }
    }
}

//Lấy giá trị Order
function getValueOrder(form, input) {
    var values = '';
    $("#" + form).find("select").each(function (index) {
        values += "|" + $(this).attr("id") + '_' + $(this).val();
    });
    values = values.substring(1);
    $("#" + input).val(values);
}

function getTenKhongDau(alias) {
    var str = alias;
    str = str.replace(/\s+/g, ' ');
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

function getTenVietTat(tendaydu) {
    tendaydu = trim12(tendaydu);
    tendaydu = tendaydu.replace(/\s+/g, ' ');

    var tenviettat = '';
    if (tendaydu.length > 0) {
        tenviettat += tendaydu[0];
        for (var indexc = 0; indexc < tendaydu.length; indexc++) {
            if (tendaydu[indexc] == ' ') {
                tenviettat += tendaydu[indexc + 1];
            }
        }
    }
    return tenviettat.toUpperCase();
}
//kiểm tra sự tồn tại của id trong chuỗi List ID
function CheckExist(s, value) {
    var array = s.split(",");
    var i;
    for (i = 0; i < array.length; i++) {
        if (array[i] === value)
            return true;
    }
    ;
    return false;
}
//get parameter url
function getQueryStrings(name, strUrl) {
    name = name.replace(/[\[]/, "\\\[").replace(/[\]]/, "\\\]");
    var regexS = "[\\?&]" + name + "=([^&#]*)";
    var regex = new RegExp(regexS);
    var results = regex.exec(strUrl);
    if (results == null)
        return "";
    else
        return results[1];
}
//ham load dữ liệu
function initAjaxLoad(urlListLoad, container, selector) {
    debugger
    $.address.init().unbind('change');
    $.address.init().change(function (event) {
        debugger
        var urlTransform = urlListLoad;
        var urlHistory = event.value;
        if (urlHistory.length > 0) {
            urlHistory = urlHistory.substring(1, urlHistory.length);
            if (urlTransform.indexOf('?') > 0)
                urlTransform = urlTransform + '&' + urlHistory;
            else
                urlTransform = urlTransform + '?' + urlHistory;
        }
        console.log(urlTransform);
        $(container).html(imageLoading);
        $.post(urlTransform, function (data) {
            $(container).html(data);
        });
        // mới thêm check row hight light
        setTimeout(function () {
            //hight light row đầu tiên
            if (getQueryStrings("HightLight", urlTransform) == "1") {
                $(selector + " .gridView-detail tbody tr").eq(0).addClass("hightlight");
            } else {
                //nếu không có tham số hightlight, hightlight row đầu tiên
                if (getQueryStrings("HightLight", urlTransform) == "") {
                    $(selector + " .gridView-detail tbody tr").eq(0).addClass("hightlight");
                } else {
                    //hight light row cuối cùng
                    $(selector + " .gridView-detail tbody tr").eq($(selector + " .gridView-detail tbody tr").length - 1).addClass("hightlight");
                }
            }
        }, 100);

    });

}

function changeHashValue(key, value, source) {
    debugger
    value = encodeURIComponent(value);
    var currentLink = source.substring(1);
    var returnLink = '#';
    var exits = false;
    if (currentLink.indexOf('&') > 0) { // lớn hơn 1
        var tempLink = currentLink.split('&');
        for (idx = 0; idx < tempLink.length; idx++) {
            if (key == tempLink[idx].split('=')[0]) { //check Exits
                returnLink += key + '=' + value;
                exits = true;
            }
            else {
                returnLink += tempLink[idx];
            }
            if (idx < tempLink.length - 1)
                returnLink += '&';
        }
        if (!exits)
            returnLink += '&' + key + '=' + value;
    } else if (currentLink.indexOf('=') > 0) { //Chỉ 1
        returnLink = '#' + currentLink + '&' + key + '=' + value;
    }
    else
        returnLink = '#' + key + '=' + value;
    return returnLink;
}

//Chuyển trang với value mới
function changeHashUrl(key, value) {
    var currentLink = $.address.value();
    return changeHashValue(key, value, currentLink);
}

//Hủy đăng ký phím tắt cho grid
function unbindHotkey() {
    $(document).unbind('keypress');

}

//Đăng ký phím tắt cho grid
function bindHotkey() {
    unbindHotkey(); //hủy bỏ đăng ký hotkey
    selector = gridContainer; //Gán lại container truyền từ usercontrols


    //T = mo form them moi
    $(document).bind('keypress', 't', function (evt) {
        $('#btnAddForm').click();
        return false;
    });

    //tim kiem
    $(document).bind('keypress', 'f', function () {
        $("#Keyword").focus();
        return false;
    });


    //Di chuyển các row
    $(document).bind('keypress', 'up', function (evt) {
        evt.preventDefault();
        $(selector + " .gridView-detail tbody tr").each(function (index) {
            if ($(this).hasClass("hightlight")) {
                if (index == 0) {
                    var urlFw = $(".bottomdetail_" + valueindex + " .left a.pre").attr("href");
                    if (urlFw != null && urlFw != 'undefined')
                        window.location.href = urlFw + "&HightLight=0";
                } else {
                    $(this).removeClass("hightlight");
                    STTRow = index - 1;
                    boolCheckup = true;
                    return false;
                }
            }
        });
        if (boolCheckup) {
            $(selector + " .gridView-detail tbody tr:eq(" + (STTRow) + ")").addClass("hightlight");
        }
    });

    //Phím xuống
    $(document).bind('keypress', 'down', function (evt) {
        evt.preventDefault();
        $(selector + " .gridView-detail tbody tr").each(function (index) {
            if ($(this).hasClass("hightlight")) {

                if (index == ($(selector + " .gridView-detail tbody tr").length - 1)) { //Nếu select row cuối
                    var urlFw = $(".bottomdetail_" + valueindex + " .left a.next").attr("href");
                    if (urlFw != null && urlFw != 'undefined')
                        window.location.href = urlFw + "&HightLight=1";
                } else {
                    $(this).removeClass("hightlight");
                    STTRow = index + 1;
                    boolCheck = true;
                }
                return false;
            }
        });
        if (boolCheck) {
            $(selector + " .gridView-detail tbody tr").eq(STTRow).addClass("hightlight");
        }
    });

    //phím shift+a - Chọn tất cả các  bản ghi
    $(document).bind('keypress', 'ctrl+a', function () {
        $(selector + ' input.checkAll').click();
        return false;
    });

    //Chuyển trang
    $(document).bind('keypress', 'right', function (evt) {
        var urlFw = $(".bottomdetail_" + valueindex + " .left a.next").attr("href");
        if (urlFw != null && urlFw != 'undefined')
            window.location.href = urlFw + "&HightLight=1";

    });
    $(document).bind('keypress', 'left', function (evt) {
        var urlFw = $(".bottomdetail_" + valueindex + " .left a.pre").attr("href");
        if (urlFw != null && urlFw != 'undefined')
            window.location.href = urlFw + "&HightLight=0";
    });

    //Phím s - Sửa row
    $(document).bind('keypress', 's', function (evt) {
        evt.preventDefault();
        $(selector + " .gridView-detail tr").each(function (index) {
            if ($(this).hasClass("hightlight")) {
                $(this).find("a.edit").click();
            }
        });
    });

    //phím x - xóa row
    $(document).bind('keypress', 'x', function (evt) {
        evt.preventDefault();
        $(selector + " .gridView-detail tr").each(function (index) {
            if ($(this).hasClass("hightlight")) {
                $(this).find("a.delete").click();
            }
        });
    });
    //phím alt+x - Xóa các row đã chọn
    $(document).bind('keypress', 'alt+x', function (evt) {
        evt.preventDefault();
        $(selector + ' .deleteAll').click();
    });

    //phím a - Ẩn row
    $(document).bind('keypress', 'a', function (evt) {
        evt.preventDefault();
        $(selector + " .gridView-detail tr").each(function (index) {
            if ($(this).hasClass("hightlight")) {
                $(this).find("a.hide").click();
            }
        });
    });
    //Phím alt+a ẩn tất cả các row đã được checkbox
    $(document).bind('keypress', 'alt+a', function (evt) {
        evt.preventDefault();
        $(selector + ' a.hideAll').click();
    });

    //phím h - Hiển thị
    $(document).bind('keypress', 'h', function (evt) {
        evt.preventDefault();
        $(selector + " .gridView-detail tr").each(function (index) {
            if ($(this).hasClass("hightlight")) {
                $(this).find("a.show").click();
            }
        });
    });
    //Phím alt+h hiển thị tất cả các row đã được checkbox
    $(document).bind('keypress', 'alt+h', function (evt) {
        evt.preventDefault();
        $(selector + ' a.showAll').click();
    });

    //phím v - xem row
    $(document).bind('keypress', 'v', function (evt) {
        evt.preventDefault();
        $(selector + " .gridView-detail tr").each(function (index) {
            if ($(this).hasClass("hightlight")) {
                $(this).find("a.view").click();
            }
        });
    });
}

function registerGridViewDetail(selector, valueindex) {
    //bindHotkey(selector); //Đăng ký phím tắt cho grid
    //Đổi màu row
    $(selector + " .gridView-detail tr").each(function (index) {
        if (index % 2 == 0)
            $(this).addClass("odd");
        else {
            $(this).addClass("even");
        }
    });

    //Sắp xếp các cột
    $(selector + " .gridView-detail th a").each(function (idx) {
        //var link = $(this).attr("href");
        //link = link.substring(1, link.length);
        //if ($.address.value().indexOf(link) > 0) {
        //    if ($.address.value().indexOf('FieldOption=1') > 0) {
        //        $(this).addClass('desc');
        //        $(this).attr("href", '#' + link + '&FieldOption=0');
        //    }
        //    else {
        //        $(this).addClass('asc');
        //        $(this).attr("href", '#' + link + '&FieldOption=1');
        //    }
        //}
    });

    //khi người dùng click trên 1 row
    $(selector + " .gridView-detail tr").not("first").click(function () {
        if ($(selector + " .gridView-detail tr").hasClass("tdunread") == false) {
            $(selector + " .gridView-detail tr").removeClass("hightlight");
            $(this).addClass("hightlight");
        }
        //Đăng ký button hiển thị


    });
    //checkall
    $(selector + ' .checkAll').click(function () {

        var selectQuery = selector + " input[type='checkbox']";
        if ($(this).val() != '')
            selectQuery = selector + " #" + $(this).val() + " input[type='checkbox']";
        $(selectQuery).attr('checked', $(this).is(':checked'));
    });
    //uncheckall DuyNV
    $(selector + ' input[type=checkbox]').click(function () {
        if ($(this).val() != '') {
            if ($(this).attr('checked')) {
                //CuongND: kiem tra xem neu tat cac checkbox duoc check => check all = check
                var resutl = true;
                $(selector + ' input[type=checkbox]').each(function () {
                    var cbo = $(this);
                    if (cbo.val() != '') {
                        if (cbo.is(':checked') == false) {
                            resutl = false;
                        }
                    }
                });
                if (resutl == true) {
                    $(selector + ' .checkAll').attr('checked', true);
                }
            } else {
                $(selector + ' .checkAll').attr('checked', false);
            }
        }
    });
    //Nhảy trang
    $(selector + " .bottomdetail_" + valueindex + " input").change(function () {
        var cPage = trim12($(this).val());
        var maxPage = $(selector + " .bottomdetail_" + valueindex + " input[type=hidden]").val();
        if (cPage.length == 0)
            createMessage("Thông báo", "Yêu cầu nhập trang cần chuyển đến");
        else if (isNaN(cPage)) {
            cPage = 1;
            createMessage("Thông báo", "Trang chuyển đến phải là kiểu số");

        } else if (parseInt(cPage) > maxPage) {
            cPage = 1;
            createMessage("Thông báo", "Trang không được lớn hơn " + maxPage + "");
        } else if (parseInt(cPage) <= 0) {
            {
                cPage = 1;
                createMessage("Thông báo", "Trang phải lớn hơn 0");
            }
        } else if (cPage.indexOf(".") > 0) //|| cPage.contains(".") => ham contains => chrome không hiểu
        {
            cPage = 1;
            createMessage("Thông báo", "Trang chuyển đến phải là kiểu số nguyên dương");
        } else {
            // CuongND : Nhap so trang >1 lan hop le nhung khong load lai du lieu tu
            var currentLink = window.location.href;
            var index = currentLink.indexOf("#Page=");
            if (index > 0) {
                window.location.href = currentLink.replace("#Page=", "#None=") + "&Page=" + cPage;
            }
            else {
                window.location.href = changeHashUrl('Page', cPage);
            }
        }
    });
    //ẩn hiện nhóm
    $(selector + " .gridView-detail a.group").click(function () {
        var idShowHide = $(this).attr("href");
        if ($(this).text() == '+') {
            $(idShowHide).show();
            $(this).text("-");
        } else {
            $(idShowHide).hide();
            $(this).text("+");
        }
        return false;
    });

    //Thay đổi số bản ghi trên trang
    $(selector + " .bottomdetail_" + valueindex + " select").change(function () {
        debugger;
        var urlFWs = $.address.value();
        var p = $(selector + " .bottomdetail_" + valueindex + " input").val();
       
        //truong hop chi truyen 1 tham so #Page 
        if (urlFWs.indexOf("&") <= 0) {
            urlFWs = '/';
        }
        urlFWs = changeHashValue("Page", p, urlFWs); //Replace  &Page=.. => Page=1
        urlFWs = changeHashValue("RowPerPage", $(this).val(), urlFWs); //Replace  &TenDonVi=.. => TenDonVi=donViNhan
       
        window.location.href = urlFWs;
    });
    //Đăng ký xóa nhiều
    $(selector + " a.deleteAll").click(function () {
        var arrRowId = '';
        var rowTitle = '';
        var linkFW = '';
        var linkFW = (linkFW == '') ? '#' + urlDeleteFrefix + 'Page=1' : '#' + urlDeleteFrefix + linkFW;
        $(selector + " input[type='checkbox']:checked").not("#checkAll").not(".checkAll").each(function () {
            arrRowId += $(this).val() + ",";
            rowTitle += "<li>" + escapeHTML($(this).parent().parent().attr("title")) + "</li>";
        });
        //rowTitle = "<ul>" + rowTitle + "</ul>";

        arrRowId = (arrRowId.length > 0) ? arrRowId.substring(0, arrRowId.length - 1) : arrRowId;
        rowDelete(urlPostAction, arrRowId, rowTitle, linkFW);
        return false;
    });
    //Đăng ký xóa nhiều quyet dinh
    $(selector + " a.deleteQuyetDinhAll").click(function () {
        var arrRowId = '';
        var rowTitle = '';
        var linkFW = '';
        var linkFW = (linkFW == '') ? '#' + urlDeleteFrefix + 'Page=1' : '#' + urlDeleteFrefix + linkFW;
        $(selector + " input[type='checkbox']:checked").not("#checkAll").not(".checkAll").each(function () {
            arrRowId += $(this).val() + ",";
            rowTitle += "<li>" + escapeHTML($(this).parent().parent().attr("title")) + "</li>";
        });
        rowTitle = "<ul>" + rowTitle + "</ul>";

        arrRowId = (arrRowId.length > 0) ? arrRowId.substring(0, arrRowId.length - 1) : arrRowId;
        rowDeleteQuyetDinh(urlPostAction, arrRowId, rowTitle, linkFW);
        return false;
    });

    $(selector + " a.updateTrangThaiAll").click(function () {
        var arrRowId = '';
        var rowTitle = '';
        var linkFW = '';
        var linkFW = (linkFW == '') ? '#' + urlDeleteFrefix + 'Page=1' : '#' + urlDeleteFrefix + linkFW;
        $(selector + " input[type='checkbox']:checked").not("#checkAll").not(".checkAll").each(function () {
            arrRowId += $(this).val() + ",";
            rowTitle += "<li>" + escapeHTML($(this).parent().parent().attr("title")) + "</li>";
        });
        rowTitle = "<ul>" + rowTitle + "</ul>";

        arrRowId = (arrRowId.length > 0) ? arrRowId.substring(0, arrRowId.length - 1) : arrRowId;
        rowCapNhatTrangThai(urlPostAction, arrRowId, rowTitle, linkFW);
        return false;
    });
    //Đăng ký từ chối nhiều yêu cầu có lý do
    $(selector + " a.rejectAll").click(function () {
        var arrRowId = '';
        var rowTitle = '';
        var linkFW = '';
        var linkFW = (linkFW == '') ? '#' + urlDeleteFrefix + 'Page=1' : '#' + urlDeleteFrefix + linkFW;
        $(selector + " input[type='checkbox']:checked").not("#checkAll").not(".checkAll").each(function () {
            arrRowId += $(this).val() + ",";
            rowTitle += "<li>" + escapeHTML($(this).parent().parent().attr("title")) + "</li>";
        });
        rowTitle = "<ul>" + rowTitle + "</ul>";

        arrRowId = (arrRowId.length > 0) ? arrRowId.substring(0, arrRowId.length - 1) : arrRowId;
        rowReject(urlPostAction, arrRowId, rowTitle, linkFW);
        return false;
    });
    $(selector + " a.duyetYeuCauMuonAll").click(function () {
        var arrRowId = '';
        var rowTitle = '';
        var linkFW = '';
        var linkFW = (linkFW == '') ? '#' + urlDeleteFrefix + 'Page=1' : '#' + urlDeleteFrefix + linkFW;
        $(selector + " input[type='checkbox']:checked").not("#checkAll").not(".checkAll").each(function () {
            arrRowId += $(this).val() + ",";
            rowTitle += "<li>" + escapeHTML($(this).parent().parent().attr("title")) + "</li>";
        });
        rowTitle = "<ul>" + rowTitle + "</ul>";

        arrRowId = (arrRowId.length > 0) ? arrRowId.substring(0, arrRowId.length - 1) : arrRowId;
        rowDuyetYeuCauKhaiThac(urlPostAction, arrRowId, rowTitle, linkFW);
        return false;
    });
    // Đăng ký nộp lưu nhiều
    $(selector + " a.nopLuuAll").click(function () {
        var arrRowId = '';
        var rowTitle = '';
        var linkFW = '';
        var linkFW = (linkFW == '') ? '#' + urlDeleteFrefix + 'Page=1' : '#' + urlDeleteFrefix + linkFW;
        $(selector + " input[type='checkbox']:checked").not("#checkAll").not(".checkAll").each(function () {
            arrRowId += $(this).val() + ",";
            rowTitle += "<li>" + escapeHTML($(this).parent().parent().attr("title")) + "</li>";
        });
        rowTitle = "<ul>" + rowTitle + "</ul>";

        arrRowId = (arrRowId.length > 0) ? arrRowId.substring(0, arrRowId.length - 1) : arrRowId;
        rowNopLuuTru(urlPostAction, arrRowId, rowTitle, linkFW);
        return false;
    });

    //Đăng ký xóa nhiều
    $(selector + " a.xoatamAll").click(function () {
        var arrRowId = '';
        var rowTitle = '';
        var linkFW = '';
        var linkFW = (linkFW == '') ? '#' + urlDeleteFrefix + 'Page=1' : '#' + urlDeleteFrefix + linkFW;
        $(selector + " input[type='checkbox']:checked").not("#checkAll").not(".checkAll").each(function () {
            arrRowId += $(this).val() + ",";
            rowTitle += "<li>" + escapeHTML($(this).parent().parent().attr("title")) + "</li>";
        });
        rowTitle = "<ul>" + rowTitle + "</ul>";

        arrRowId = (arrRowId.length > 0) ? arrRowId.substring(0, arrRowId.length - 1) : arrRowId;
        rowXoaTam(urlPostAction, arrRowId, rowTitle, linkFW);
        return false;
    });

    $(selector + " a.recoverXoaTamAll").click(function () {
        var arrRowId = '';
        var rowTitle = '';
        var linkFW = '';
        var linkFW = (linkFW == '') ? '#' + urlDeleteFrefix + 'Page=1' : '#' + urlDeleteFrefix + linkFW;
        $(selector + " input[type='checkbox']:checked").not("#checkAll").not(".checkAll").each(function () {
            arrRowId += $(this).val() + ",";
            rowTitle += "<li>" + escapeHTML($(this).parent().parent().attr("title")) + "</li>";
        });
        rowTitle = "<ul>" + rowTitle + "</ul>";

        arrRowId = (arrRowId.length > 0) ? arrRowId.substring(0, arrRowId.length - 1) : arrRowId;
        rowRecoverXoaTam(urlPostAction, arrRowId, rowTitle, linkFW);
        return false;
    });

    //Đăng ký Hiển thị nhiều
    $(selector + " .gridView-detail a.showAll").click(function () {
        var arrRowId = '';
        var rowTitle = '';
        var linkFW = '';
        var linkFW = (linkFW == '') ? '#' + urlShowFrefix + 'Page=1' : '#' + urlShowFrefix + linkFW;
        $(selector + " input[type='checkbox']:checked").not("#checkAll").not(".checkAll").each(function () {
            arrRowId += $(this).val() + ",";
            rowTitle += "<li>" + escapeHTML($(this).parent().parent().attr("title")) + "</li>";
        });
        rowTitle = "<ul>" + rowTitle + "</ul>";

        arrRowId = (arrRowId.length > 0) ? arrRowId.substring(0, arrRowId.length - 1) : arrRowId;
        rowShow(urlPostAction, arrRowId, rowTitle, linkFW);
        return false;
    });
    //Đăng ký ẩn nhiều
    $(selector + " .gridView-detail a.hideAll").click(function () {
        var arrRowId = '';
        var rowTitle = '';
        var linkFW = '';
        var linkFW = (linkFW == '') ? '#' + urlHideFrefix + 'Page=1' : '#' + urlHideFrefix + linkFW;
        $(selector + " input[type='checkbox']:checked").not("#checkAll").not(".checkAll").each(function () {
            arrRowId += $(this).val() + ",";
            rowTitle += "<li>" + escapeHTML($(this).parent().parent().attr("title")) + "</li>";
        });
        rowTitle = "<ul>" + rowTitle + "</ul>";

        arrRowId = (arrRowId.length > 0) ? arrRowId.substring(0, arrRowId.length - 1) : arrRowId;
        rowHide(urlPostAction, arrRowId, rowTitle, linkFW);
        return false;
    });
    //Đăng ký duyệt nhiều
    $(selector + " .gridView-detail a.approvedAll").click(function () {
        var arrRowId = '';
        var rowTitle = '';
        var linkFW = '';
        var linkFW = (linkFW == '') ? '#' + urlHideFrefix + 'Page=1' : '#' + urlApprovedFrefix + linkFW;
        $(selector + " input[type='checkbox']:checked").not("#checkAll").not(".checkAll").each(function () {
            arrRowId += $(this).val() + ",";
            rowTitle += "<li>" + escapeHTML($(this).parent().parent().attr("title")) + "</li>";
        });
        rowTitle = "<ul>" + rowTitle + "</ul>";

        arrRowId = (arrRowId.length > 0) ? arrRowId.substring(0, arrRowId.length - 1) : arrRowId;
        rowApproved(urlPostAction, arrRowId, rowTitle, linkFW);
        return false;
    });
    // Đăng ký gửi nhiều
    $(selector + " .gridView-detail a.sendAll").click(function () {
        var arrRowId = '';
        var rowTitle = '';
        var linkFW = '';
        var linkFW = (linkFW == '') ? '#' + urlHideFrefix + 'Page=1' : '#' + urlApprovedFrefix + linkFW;
        $(selector + " input[type='checkbox']:checked").not("#checkAll").not(".checkAll").each(function () {
            arrRowId += $(this).val() + ",";
            rowTitle += "<li>" + escapeHTML($(this).parent().parent().attr("title")) + "</li>";
        });
        rowTitle = "<ul>" + rowTitle + "</ul>";

        arrRowId = (arrRowId.length > 0) ? arrRowId.substring(0, arrRowId.length - 1) : arrRowId;
        rowSend(urlPostAction, arrRowId, rowTitle, linkFW);
        return false;
    });
    //Đăng ký trả lại nhiều
    $(selector + " .gridView-detail a.giveBackAll").click(function () {
        var arrRowId = '';
        var rowTitle = '';
        var linkFW = '';
        var linkFW = (linkFW == '') ? '#' + urlHideFrefix + 'Page=1' : '#' + urlApprovedFrefix + linkFW;
        $(selector + " input[type='checkbox']:checked").not("#checkAll").not(".checkAll").each(function () {
            arrRowId += $(this).val() + ",";
            rowTitle += "<li>" + escapeHTML($(this).parent().parent().attr("title")) + "</li>";
        });
        rowTitle = "<ul>" + rowTitle + "</ul>";

        arrRowId = (arrRowId.length > 0) ? arrRowId.substring(0, arrRowId.length - 1) : arrRowId;
        rowGiveBack(urlPostAction, arrRowId, rowTitle, linkFW);
        return false;
    });
    //Đăng ký báo cáo nhiều
    $(selector + " .gridView-detail a.baocaoAll").click(function () {
        var arrRowId = '';
        var rowTitle = '';
        var linkFW = '';
        var linkFW = (linkFW == '') ? '#' + urlHideFrefix + 'Page=1' : '#' + urlApprovedFrefix + linkFW;
        $(selector + " input[type='checkbox']:checked").not("#checkAll").not(".checkAll").each(function () {
            arrRowId += $(this).val() + ",";
            rowTitle += "<li>" + escapeHTML($(this).parent().parent().attr("title")) + "</li>";
        });
        rowTitle = "<ul>" + rowTitle + "</ul>";

        arrRowId = (arrRowId.length > 0) ? arrRowId.substring(0, arrRowId.length - 1) : arrRowId;
        rowChuyenBaoCao(urlPostAction, arrRowId, rowTitle, linkFW);
        return false;
    });
    //Đăng ký hủy duyệt nhiều
    $(selector + " .gridView-detail a.pendingAll").click(function () {
        var arrRowId = '';
        var rowTitle = '';
        var linkFW = '';
        var linkFW = (linkFW == '') ? '#' + urlHideFrefix + 'Page=1' : '#' + urlPendingFrefix + linkFW;
        $(selector + " input[type='checkbox']:checked").not("#checkAll").not(".checkAll").each(function () {
            arrRowId += $(this).val() + ",";
            rowTitle += "<li>" + escapeHTML($(this).parent().parent().attr("title")) + "</li>";
        });
        rowTitle = "<ul>" + rowTitle + "</ul>";

        arrRowId = (arrRowId.length > 0) ? arrRowId.substring(0, arrRowId.length - 1) : arrRowId;
        rowPending(urlPostAction, arrRowId, rowTitle, linkFW);
        return false;
    });

    //Đăng ký hủy duyệt nhiều
    $(selector + " .gridView-detail a.pendingAll").click(function () {
        var arrRowId = '';
        var rowTitle = '';
        var linkFW = '';
        var linkFW = (linkFW == '') ? '#' + urlHideFrefix + 'Page=1' : '#' + urlPendingFrefix + linkFW;
        $(selector + " input[type='checkbox']:checked").not("#checkAll").not(".checkAll").each(function () {
            arrRowId += $(this).val() + ",";
            rowTitle += "<li>" + escapeHTML($(this).parent().parent().attr("title")) + "</li>";
        });
        rowTitle = "<ul>" + rowTitle + "</ul>";

        arrRowId = (arrRowId.length > 0) ? arrRowId.substring(0, arrRowId.length - 1) : arrRowId;
        rowPending(urlPostAction, arrRowId, rowTitle, linkFW);
        return false;
    });
    //Duyệt hủy tài liệu
    $(selector + " .gridView-detail a.approvedDestructionAll").click(function () {
        var arrRowId = '';
        var rowTitle = '';
        var linkFW = '';
        linkFW = (linkFW == '') ? '#' + urlShowFrefix + 'Page=1' : '#' + urlShowFrefix + linkFW;
        $("#gridHoSoTieuHuy input[type='checkbox']:checked").not("#checkAll").not(".checkAll").each(function () {
            arrRowId += $(this).val() + ",";
            rowTitle += "<li>" + escapeHTML($(this).parent().parent().attr("title")) + "</li>";
        });
        rowTitle = "<ul>" + rowTitle + "</ul>";

        arrRowId = (arrRowId.length > 0) ? arrRowId.substring(0, arrRowId.length - 1) : arrRowId;
        HuyHoSo(urlPostAction, arrRowId, rowTitle, linkFW);
        return false;

    });
    //Đăng ký button xóa row
    $(selector + " .gridView-detail a.delete").click(function () {
        rowDelete(urlPostAction, $(this).attr("href").substring(1), escapeHTML($(this).attr("title")), "#" + urlDeleteFrefix + "Page=1");
        return false;
    });
    $(selector + " .gridView-detail a.deletequyetdinh").click(function () {
        rowDeleteQuyetDinh(urlPostAction, $(this).attr("href").substring(1), escapeHTML($(this).attr("title")), "#" + urlDeleteFrefix + "Page=1");
        return false;
    });

    $(selector + " .gridView-detail a.xoatam").click(function () {
        rowXoaTam(urlPostAction, $(this).attr("href").substring(1), escapeHTML($(this).attr("title")), "#" + urlDeleteFrefix + "Page=1");
        return false;
    });

    $(selector + " .gridView-detail a.recoverxoatam").click(function () {
        rowRecoverXoaTam(urlPostAction, $(this).attr("href").substring(1), escapeHTML($(this).attr("title")), "#" + urlDeleteFrefix + "Page=1");
        return false;
    });
    //Đăng ký button xóa người dùng
    $(selector + " .gridView-detail a.deleteNguoiDung").click(function () {
        deletenguoidungphongban(urlPostAction, $(this).attr("href").substring(1), $(this).attr("data-donviId"), escapeHTML($(this).attr("title")), "#" + urlDeleteFrefix + "Page=1");
        return false;
    });
    //Đăng ký button hiển thị
    $(selector + " .gridView-detail a.show").click(function () {
        rowShow(urlPostAction, $(this).attr("href").substring(1), escapeHTML($(this).attr("title")), "#" + urlDeleteFrefix + "Page=1");
        return false;
    });

    //Đăng ký button ẩn
    $(selector + " .gridView-detail a.hide").click(function () {
        rowHide(urlPostAction, $(this).attr("href").substring(1), escapeHTML($(this).attr("title")), "#" + urlHideFrefix + "Page=1");
        return false;
    });
    //Đăng ký button duyệt
    $(selector + " .gridView-detail a.approved").click(function () {
        rowApproved(urlPostAction, $(this).attr("href").substring(1), escapeHTML($(this).attr("title")), "#" + urlHideFrefix + "Page=1");
        return false;
    });
    //Đăng ký button gửi 
    $(selector + " .gridView-detail a.send").click(function () {
        rowSend(urlPostAction, $(this).attr("href").substring(1), escapeHTML($(this).attr("title")), "#" + urlHideFrefix + "Page=1");
        return false;
    });
    //Đăng ký button duyệt
    $(selector + " .gridView-detail a.baocao").click(function () {
        rowChuyenBaoCao(urlPostAction, $(this).attr("href").substring(1), escapeHTML($(this).attr("title")), "#" + urlHideFrefix + "Page=1");
        return false;
    });
    //Đăng ký button hủy duyệt
    $(selector + " .gridView-detail a.pending").click(function () {
        rowPending(urlPostAction, $(this).attr("href").substring(1), escapeHTML($(this).attr("title")), "#" + urlHideFrefix + "Page=1");
        return false;
    });
    //Đăng ký button hủy duyệt
    $(selector + " .gridView-detail a.reject").click(function () {
        rowReject(urlPostAction, $(this).attr("href").substring(1), escapeHTML($(this).attr("title")), "#" + urlHideFrefix + "Page=1");
        return false;
    });
    //đăng ký sửa row
    $(selector + " .gridView-detail a.edit").click(function () {
        var urlRequest = '';
        if (urlForm.indexOf('?') > 0)
            urlRequest = urlForm + '&do=edit&ItemId=' + $(this).attr("href").substring(1);
        else
            urlRequest = urlForm + '?do=edit&ItemId=' + $(this).attr("href").substring(1);

        $('body').modalmanager('loading');

        $('#dialog-form').load(urlRequest, function () {
            $('#dialog-form').modal();
        });
        return false;
    });

    //đăng ký sửa row
    $(selector + " .gridView-detail a.edit-customer").click(function () {
        var urlRequest = '';
        if (urlForm.indexOf('?') > 0)
            urlRequest = urlForm + '&do=edit&ItemId=' + $(this).attr("href").substring(1);
        else
            urlRequest = urlForm + '?do=edit&ItemId=' + $(this).attr("href").substring(1);

        var w = $(this).attr("rel");
        $('body').modalmanager('loading');
        $('#dialog-form').load(urlRequest, function () {
            $('#dialog-form').modal({ width: w });
        });
        return false;
    });
    //đăng ký config row
    $(selector + " .gridView-detail a.configuser").click(function () {
        var urlRequest = '';
        if (urlListRole.indexOf('?') > 0)
            urlRequest = urlListRole + '&do=configrole&ItemId=' + $(this).attr("href").substring(1) + '&DonViID=' + $(this).data('donviid') + '&rnd=' + String((new Date()).getTime()).replace(/\D/gi, '');
        else
            urlRequest = urlListRole + '?do=configrole&ItemId=' + $(this).attr("href").substring(1) + '&DonViID=' + $(this).data('donviid') + "&rnd=" + String((new Date()).getTime()).replace(/\D/gi, '');
        $('body').modalmanager('loading');
        $('#dialog-form').load(urlRequest, function () {
            $('#dialog-form').modal({ width: 650 });
        });
        return false;
    });

    //đăng ký config row
    $(selector + " .gridView-detail a.config").click(function () {
        var urlRequest = '';
        if (urlListRole.indexOf('?') > 0)
            urlRequest = urlListRole + '&do=config&ItemId=' + $(this).attr("href").substring(1);
        else
            urlRequest = urlListRole + '?do=config&ItemId=' + $(this).attr("href").substring(1);
        $('body').modalmanager('loading');
        $('#dialog-form').load(urlRequest, function () {
            $('#dialog-form').modal({ width: 650 });
        });
        return false;
    });
    //đăng ký config row
    $(selector + " .gridView-detail a.config-vaitro").click(function () {
        var urlRequest = '';
        var donviid = $(this).data('donviid');
        if (urlListRoleVaiTro.indexOf('?') > 0)
            urlRequest = urlListRoleVaiTro + '&do=config&ItemId=' + $(this).attr("href").substring(1) + '&DonViID=' + donviid + "&rnd=" + String((new Date()).getTime()).replace(/\D/gi, '');
        else
            urlRequest = urlListRoleVaiTro + '?do=config&ItemId=' + $(this).attr("href").substring(1) + '&DonViID=' + donviid + "&rnd=" + String((new Date()).getTime()).replace(/\D/gi, '');
        $('body').modalmanager('loading');
        $('#dialog-form').load(urlRequest, function () {
            $('#dialog-form').modal({ width: 650 });
        });
        return false;
    });


    //đăng ký Resetpass row
    $(selector + " .gridView-detail a.resetpass").click(function () {
        var urlRequest = '';
        if (urlResetPass.indexOf('?') > 0)
            urlRequest = urlResetPass + '&do=resetpass&ItemId=' + $(this).attr("href").substring(1);
        else
            urlRequest = urlResetPass + '?do=resetpass&ItemId=' + $(this).attr("href").substring(1);
        $('body').modalmanager('loading');
        $('#dialog-form').load(urlRequest, function () {
            $('#dialog-form').modal({ width: 600 });
        });
        return false;
    });
    //đăng ký xem row
    $(selector + " .gridView-detail a.view").click(function () {
        var w = $(this).attr("popup-w");
        var urlRequest = '';
        if (urlView.indexOf('?') > 0)
            urlRequest = urlView + '&itemId=' + $(this).attr("href").substring(1);
        else
            urlRequest = urlView + '?itemId=' + $(this).attr("href").substring(1);

        $('body').modalmanager('loading');
        $('#dialog-form').load(urlRequest, function () {
            if (w) {
                $('#dialog-form').modal({ width: w });
            } else {
                $('#dialog-form').modal({ width: 650 });
            }
        });

        return false;
    });
    //đang kí duyệt đặt phòng
    $(selector + " .gridView-detail a.GridApprovedRom").click(function () {
        var w = $(this).attr("popup-w");
        var urlRequest = '';
        if (urlView.indexOf('?') > 0)
            urlRequest = urlApprovedRom + '&do=approved&itemId=' + $(this).attr("href").substring(1);
        else
            urlRequest = urlApprovedRom + '?do=approved&itemId=' + $(this).attr("href").substring(1);

        $('body').modalmanager('loading');
        $('#dialog-form').load(urlRequest, function () {
            if (w) {
                $('#dialog-form').modal({ width: w });
            } else {
                $('#dialog-form').modal({ width: 650 });
            }
        });

        return false;
    });
}

//Hiển thị row tren grid
function rowShow(urlPost, arrRowId, rowTitle, urlFw) {
    if (arrRowId == '')
        createMessageDelete("Thông báo", "<div class=\"alert\"><strong>Chú ý!</strong> Bạn chưa chọn bản ghi nào.");
    else {
        var htmlResponse = "";
        var urlNewFW = urlFw + '&do=show&ItemID=' + arrRowId + '&temp=' + Math.floor(Math.random() * 11);
        htmlResponse += "<script type=\"text/javascript\">\r\n";
        htmlResponse += "$(document).ready(function(){\r\n";
        htmlResponse += "   unbindHotkey();\r\n";
        //Đăng ký sự kiện khi click vào nút delete
        htmlResponse += "   $(\"#btnComfirmShow\").click(function(){\r\n";
        htmlResponse += "       $.post(encodeURI(\"" + urlPost + "\"), { \"do\": \"show\", \"itemId\": \"" + arrRowId + "\" }, function (data) {\r\n";
        htmlResponse += "       $('#btnComfirmClose').click();\r\n";
        htmlResponse += "           if (data.Error) {\r\n";
        htmlResponse += "               createMessage(\"Có lỗi xảy ra\", data.Title);\r\n";
        htmlResponse += "           }\r\n";
        htmlResponse += "           else {\r\n";
        htmlResponse += "               createCloseMessage(\"Thông báo\", data.Title, '" + urlNewFW + "');\r\n";
        htmlResponse += "           }\r\n";
        htmlResponse += "       });\r\n";
        htmlResponse += "   });\r\n";
        htmlResponse += "   $(document).bind('keypress', 'h', function (evt) {\r\n"; //Sự kiện bấm phím h
        htmlResponse += "       $('#btnComfirmShow').click();\r\n";
        htmlResponse += "   });\r\n";
        htmlResponse += "   $(document).bind('keypress', 'return', function (evt) {\r\n"; //Sự kiện bấm phím enter
        htmlResponse += "       $('#btnComfirmShow').click();\r\n";
        htmlResponse += "   });\r\n";
        htmlResponse += "   $(document).bind('keypress', 'd', function (evt) {\r\n"; // Sự kiện bấm phím d
        htmlResponse += "       $('#btnComfirmClose').click();\r\n";
        htmlResponse += "   });\r\n";
        htmlResponse += "   $('#dialog-confirm').on('hidden', function () {\r\n";
        htmlResponse += "      bindHotkey();\r\n";
        htmlResponse += "   })\r\n";
        htmlResponse += "});";
        htmlResponse += "</script>\r\n";

        htmlResponse += "<div id=\"ComfirmBox\">";
        htmlResponse += "<div class=\"modal-header\">";
        htmlResponse += "	<button type=\"button\" class=\"close\" data-dismiss=\"modal\" aria-hidden=\"true\"></button>";
        htmlResponse += "	<h4 class=\"modal-title\">Hiển thị bản ghi đã chọn</h4>";
        htmlResponse += "</div>";
        htmlResponse += "<div class=\"modal-body\">";
        htmlResponse += "    <div class=\"alert\">";
        htmlResponse += "		<strong>Chú ý!</strong> Bạn có chắc chắn muốn hiển thị!";
        htmlResponse += "	</div>";
        htmlResponse += "<ul>";
        htmlResponse += rowTitle;
        htmlResponse += "</ul>";
        htmlResponse += "</div>";
        htmlResponse += "<div class=\"modal-footer\">";
        htmlResponse += "	<button type=\"submit\" id=\"btnComfirmShow\" class=\"btn brown\" tabindex=\"5\"><i class=\"icon-eye-open\"></i> <b>H</b>iển thị</button>";
        htmlResponse += "	<button type=\"button\" id=\"btnComfirmClose\" class=\"btn red\" data-dismiss=\"modal\" tabindex=\"8\"  onclick=\"resetchecbox()\"><i class=\"fa fa-close\"></i> <b>Đ</b>óng lại</button>";
        htmlResponse += "</div>";
        htmlResponse += "</div>";
        $('#dialog-confirm').html(htmlResponse);
        $('#dialog-confirm').modal({ width: 650 });
    }
}

//Approved row tren grid
function rowApproved(urlPost, arrRowId, rowTitle, urlFw) {

    if (arrRowId == '')
        createMessageDelete("Thông báo", "<div class=\"alert\"><strong>Chú ý!</strong> Bạn chưa chọn bản ghi nào!</div>");
    else {
        var htmlResponse = "";
        var urlNewFW = urlFw + '&do=approved&ItemID=' + arrRowId + '&temp=' + Math.floor(Math.random() * 11);
        htmlResponse += "<script type=\"text/javascript\">\r\n";
        htmlResponse += "$(document).ready(function(){\r\n";
        htmlResponse += "   unbindHotkey();\r\n";
        //Đăng ký sự kiện khi click vào nút delete
        htmlResponse += "   $(\"#btnComfirmApproved\").click(function(){\r\n";
        htmlResponse += "       $.post(encodeURI(\"" + urlPost + "\"), { \"do\": \"approved\", \"itemId\": \"" + arrRowId + "\" }, function (data) {\r\n";
        htmlResponse += "       $('#btnComfirmClose').click();\r\n";
        htmlResponse += "           if (data.Error) {\r\n";
        htmlResponse += "               createMessage(\"Có lỗi xảy ra\", data.Title);\r\n";
        htmlResponse += "           }\r\n";
        htmlResponse += "           else {\r\n";
        htmlResponse += "               createCloseMessage(\"Thông báo\", data.Title, '" + urlNewFW + "');\r\n";
        htmlResponse += "           }\r\n";
        htmlResponse += "       });\r\n";
        htmlResponse += "   });\r\n";
        htmlResponse += "   $(document).bind('keypress', 'h', function (evt) {\r\n"; //Sự kiện bấm phím h
        htmlResponse += "       $('#btnComfirmApproved').click();\r\n";
        htmlResponse += "   });\r\n";
        htmlResponse += "   $(document).bind('keypress', 'return', function (evt) {\r\n"; //Sự kiện bấm phím enter
        htmlResponse += "       $('#btnComfirmApproved').click();\r\n";
        htmlResponse += "   });\r\n";
        htmlResponse += "   $(document).bind('keypress', 'd', function (evt) {\r\n"; // Sự kiện bấm phím d
        htmlResponse += "       $('#btnComfirmClose').click();\r\n";
        htmlResponse += "   });\r\n";
        htmlResponse += "   $('#dialog-confirm').on('hidden', function () {\r\n";
        htmlResponse += "      bindHotkey();\r\n";
        htmlResponse += "   })\r\n";
        htmlResponse += "});";
        htmlResponse += "</script>\r\n";

        htmlResponse += "<div id=\"ComfirmBox\">";
        htmlResponse += "<div class=\"modal-header\">";
        htmlResponse += "	<button type=\"button\" class=\"close\" data-dismiss=\"modal\" aria-hidden=\"true\"></button>";
        htmlResponse += "	<h4 class=\"modal-title\">Duyệt bản ghi đã chọn</h4>";
        htmlResponse += "</div>";
        htmlResponse += "<div class=\"modal-body\">";
        htmlResponse += "    <div class=\"alert\">";
        htmlResponse += "		<strong>Chú ý!</strong> Bạn có chắc chắn muốn duyệt!";
        htmlResponse += "	</div>";
        htmlResponse += "<ul>";
        htmlResponse += rowTitle;
        htmlResponse += "</ul>";
        htmlResponse += "</div>";
        htmlResponse += "<div class=\"modal-footer\">";
        htmlResponse += "	<button type=\"submit\" id=\"btnComfirmApproved\" class=\"btn brown\" tabindex=\"5\"><i class=\"icon-eye-open\"></i> <b>D</b>uyệt</button>";
        htmlResponse += "	<button type=\"button\" id=\"btnComfirmClose\" class=\"btn red\" data-dismiss=\"modal\" tabindex=\"8\"><i class=\"fa fa-close\"></i> <b>Đ</b>óng lại</button>";
        htmlResponse += "</div>";
        htmlResponse += "</div>";
        $('#dialog-confirm').html(htmlResponse);
        $('#dialog-confirm').modal({ width: 650 });
    }
}
function rowSend(urlPost, arrRowId, rowTitle, urlFw) {

    if (arrRowId == '')
        createMessageDelete("Thông báo", "<div class=\"alert\"><strong>Chú ý!</strong> Bạn chưa chọn bản ghi nào!</div>");
    else {
        var htmlResponse = "";
        var urlNewFW = urlFw + '&do=approved&ItemID=' + arrRowId + '&temp=' + Math.floor(Math.random() * 11);
        htmlResponse += "<script type=\"text/javascript\">\r\n";
        htmlResponse += "$(document).ready(function(){\r\n";
        htmlResponse += "   unbindHotkey();\r\n";
        //Đăng ký sự kiện khi click vào nút delete
        htmlResponse += "   $(\"#btnComfirmApproved\").click(function(){\r\n";
        htmlResponse += "       $.post(encodeURI(\"" + urlPost + "\"), { \"do\": \"send\", \"itemId\": \"" + arrRowId + "\" }, function (data) {\r\n";
        htmlResponse += "       $('#btnComfirmClose').click();\r\n";
        htmlResponse += "           if (data.Error) {\r\n";
        htmlResponse += "               createMessage(\"Có lỗi xảy ra\", data.Title);\r\n";
        htmlResponse += "           }\r\n";
        htmlResponse += "           else {\r\n";
        htmlResponse += "               createCloseMessage(\"Thông báo\", data.Title, '" + urlNewFW + "');\r\n";
        htmlResponse += "           }\r\n";
        htmlResponse += "       });\r\n";
        htmlResponse += "   });\r\n";
        htmlResponse += "   $(document).bind('keypress', 'h', function (evt) {\r\n"; //Sự kiện bấm phím h
        htmlResponse += "       $('#btnComfirmApproved').click();\r\n";
        htmlResponse += "   });\r\n";
        htmlResponse += "   $(document).bind('keypress', 'return', function (evt) {\r\n"; //Sự kiện bấm phím enter
        htmlResponse += "       $('#btnComfirmApproved').click();\r\n";
        htmlResponse += "   });\r\n";
        htmlResponse += "   $(document).bind('keypress', 'd', function (evt) {\r\n"; // Sự kiện bấm phím d
        htmlResponse += "       $('#btnComfirmClose').click();\r\n";
        htmlResponse += "   });\r\n";
        htmlResponse += "   $('#dialog-confirm').on('hidden', function () {\r\n";
        htmlResponse += "      bindHotkey();\r\n";
        htmlResponse += "   })\r\n";
        htmlResponse += "});";
        htmlResponse += "</script>\r\n";

        htmlResponse += "<div id=\"ComfirmBox\">";
        htmlResponse += "<div class=\"modal-header\">";
        htmlResponse += "	<button type=\"button\" class=\"close\" data-dismiss=\"modal\" aria-hidden=\"true\"></button>";
        htmlResponse += "	<h4 class=\"modal-title\">Gửi bản ghi đã chọn</h4>";
        htmlResponse += "</div>";
        htmlResponse += "<div class=\"modal-body\">";
        htmlResponse += "    <div class=\"alert\">";
        htmlResponse += "		<strong>Chú ý!</strong> Bạn có chắc chắn muốn gửi các bản ghi đã chọn!";
        htmlResponse += "	</div>";
        htmlResponse += "<ul>";
        htmlResponse += rowTitle;
        htmlResponse += "</ul>";
        htmlResponse += "</div>";
        htmlResponse += "<div class=\"modal-footer\">";
        htmlResponse += "	<button type=\"submit\" id=\"btnComfirmApproved\" class=\"btn brown\" tabindex=\"5\"><i class=\"icon-eye-open\"></i> <b>Đ</b>ồng ý</button>";
        htmlResponse += "	<button type=\"button\" id=\"btnComfirmClose\" class=\"btn red\" data-dismiss=\"modal\" tabindex=\"8\"><i class=\"fa fa-close\"></i> <b>Đ</b>óng lại</button>";
        htmlResponse += "</div>";
        htmlResponse += "</div>";
        $('#dialog-confirm').html(htmlResponse);
        $('#dialog-confirm').modal({ width: 650 });
    }
}
// Trả lại trên grid
function rowGiveBack(urlPost, arrRowId, rowTitle, urlFw) {

    if (arrRowId == '')
        createMessageDelete("Thông báo", "<div class=\"alert\"><strong>Chú ý!</strong> Bạn chưa chọn bản ghi nào!</div>");
    else {
        var htmlResponse = "";
        var urlNewFW = urlFw + '&do=approved&ItemID=' + arrRowId + '&temp=' + Math.floor(Math.random() * 11);
        htmlResponse += "<script type=\"text/javascript\">\r\n";
        htmlResponse += "$(document).ready(function(){\r\n";
        htmlResponse += "   unbindHotkey();\r\n";
        //Đăng ký sự kiện khi click vào nút delete
        htmlResponse += "   $(\"#btnComfirmApproved\").click(function(){\r\n";
        htmlResponse += "       $.post(encodeURI(\"" + urlPost + "\"), { \"do\": \"tralai\", \"itemId\": \"" + arrRowId + "\" }, function (data) {\r\n";
        htmlResponse += "       $('#btnComfirmClose').click();\r\n";
        htmlResponse += "           if (data.Error) {\r\n";
        htmlResponse += "               createMessage(\"Có lỗi xảy ra\", data.Title);\r\n";
        htmlResponse += "           }\r\n";
        htmlResponse += "           else {\r\n";
        htmlResponse += "               createCloseMessage2(\"Thông báo\", data.Title, 'ghi-tra-tai-lieu-luu-tru.aspx?TenTruyCap=' + data.TenTruyCap);\r\n";
        htmlResponse += "           }\r\n";
        htmlResponse += "       });\r\n";
        htmlResponse += "   });\r\n";
        htmlResponse += "   $(document).bind('keypress', 'h', function (evt) {\r\n"; //Sự kiện bấm phím h
        htmlResponse += "       $('#btnComfirmApproved').click();\r\n";
        htmlResponse += "   });\r\n";
        htmlResponse += "   $(document).bind('keypress', 'return', function (evt) {\r\n"; //Sự kiện bấm phím enter
        htmlResponse += "       $('#btnComfirmApproved').click();\r\n";
        htmlResponse += "   });\r\n";
        htmlResponse += "   $(document).bind('keypress', 'd', function (evt) {\r\n"; // Sự kiện bấm phím d
        htmlResponse += "       $('#btnComfirmClose').click();\r\n";
        htmlResponse += "   });\r\n";
        htmlResponse += "   $('#dialog-confirm').on('hidden', function () {\r\n";
        htmlResponse += "      bindHotkey();\r\n";
        htmlResponse += "   })\r\n";
        htmlResponse += "});";
        htmlResponse += "</script>\r\n";

        htmlResponse += "<div id=\"ComfirmBox\">";
        htmlResponse += "<div class=\"modal-header\">";
        htmlResponse += "	<button type=\"button\" class=\"close\" data-dismiss=\"modal\" aria-hidden=\"true\"></button>";
        htmlResponse += "	<h4 class=\"modal-title\">Ghi trả tài liệu</h4>";
        htmlResponse += "</div>";
        htmlResponse += "<div class=\"modal-body\">";
        htmlResponse += "    <div class=\"alert\">";
        htmlResponse += "		<strong>Chú ý!</strong> Bạn có chắc chắn muốn ghi trả tài liệu!";
        htmlResponse += "	</div>";
        htmlResponse += "<ul>";
        htmlResponse += rowTitle;
        htmlResponse += "</ul>";
        htmlResponse += "</div>";
        htmlResponse += "<div class=\"modal-footer\">";
        htmlResponse += "	<button type=\"submit\" id=\"btnComfirmApproved\" class=\"btn brown\" tabindex=\"5\"><i class=\"icon-eye-open\"></i> <b>Đ</b>ồng ý</button>";
        htmlResponse += "	<button type=\"button\" id=\"btnComfirmClose\" class=\"btn red\" data-dismiss=\"modal\" tabindex=\"8\"><i class=\"fa fa-close\"></i> <b>Đ</b>óng lại</button>";
        htmlResponse += "</div>";
        htmlResponse += "</div>";
        $('#dialog-confirm').html(htmlResponse);
        $('#dialog-confirm').modal({ width: 650 });
    }
}

//Approved row tren grid
function rowChuyenBaoCao(urlPost, arrRowId, rowTitle, urlFw) {

    if (arrRowId == '')
        createMessageDelete("Thông báo", "<div class=\"alert\"><strong>Chú ý!</strong> Bạn chưa chọn bản ghi nào!</div>");
    else {
        var htmlResponse = "";
        var urlNewFW = urlFw + '&do=baocao&ItemID=' + arrRowId + '&temp=' + Math.floor(Math.random() * 11);
        htmlResponse += "<script type=\"text/javascript\">\r\n";
        htmlResponse += "$(document).ready(function(){\r\n";
        htmlResponse += "   unbindHotkey();\r\n";
        //Đăng ký sự kiện khi click vào nút delete
        htmlResponse += "   $(\"#btnComfirmApproved\").click(function(){\r\n";
        htmlResponse += "       $.post(encodeURI(\"" + urlPost + "\"), { \"do\": \"baocao\", \"itemId\": \"" + arrRowId + "\" }, function (data) {\r\n";
        htmlResponse += "       $('#btnComfirmClose').click();\r\n";
        htmlResponse += "           if (data.Error) {\r\n";
        htmlResponse += "               createMessage(\"Có lỗi xảy ra\", data.Title);\r\n";
        htmlResponse += "           }\r\n";
        htmlResponse += "           else {\r\n";
        htmlResponse += "               createCloseMessage(\"Thông báo\", data.Title, '" + urlNewFW + "');\r\n";
        htmlResponse += "           }\r\n";
        htmlResponse += "       });\r\n";
        htmlResponse += "   });\r\n";
        htmlResponse += "   $(document).bind('keypress', 'h', function (evt) {\r\n"; //Sự kiện bấm phím h
        htmlResponse += "       $('#btnComfirmApproved').click();\r\n";
        htmlResponse += "   });\r\n";
        htmlResponse += "   $(document).bind('keypress', 'return', function (evt) {\r\n"; //Sự kiện bấm phím enter
        htmlResponse += "       $('#btnComfirmApproved').click();\r\n";
        htmlResponse += "   });\r\n";
        htmlResponse += "   $(document).bind('keypress', 'd', function (evt) {\r\n"; // Sự kiện bấm phím d
        htmlResponse += "       $('#btnComfirmClose').click();\r\n";
        htmlResponse += "   });\r\n";
        htmlResponse += "   $('#dialog-confirm').on('hidden', function () {\r\n";
        htmlResponse += "      bindHotkey();\r\n";
        htmlResponse += "   })\r\n";
        htmlResponse += "});";
        htmlResponse += "</script>\r\n";

        htmlResponse += "<div id=\"ComfirmBox\">";
        htmlResponse += "<div class=\"modal-header\">";
        htmlResponse += "	<button type=\"button\" class=\"close\" data-dismiss=\"modal\" aria-hidden=\"true\"></button>";
        htmlResponse += "	<h4 class=\"modal-title\">Chuyển báo cáo các bản ghi đã chọn</h4>";
        htmlResponse += "</div>";
        htmlResponse += "<div class=\"modal-body\">";
        htmlResponse += "    <div class=\"alert\">";
        htmlResponse += "		<strong>Chú ý!</strong> Bạn có chắc chắn muốn chuyển báo cáo đến lãnh đạo!";
        htmlResponse += "	</div>";
        htmlResponse += "<ul>";
        htmlResponse += rowTitle;
        htmlResponse += "</ul>";
        htmlResponse += "</div>";
        htmlResponse += "<div class=\"modal-footer\">";
        htmlResponse += "	<button type=\"submit\" id=\"btnComfirmApproved\" class=\"btn brown\" tabindex=\"5\"><i class=\"icon-eye-open\"></i> <b>C</b>huyển</button>";
        htmlResponse += "	<button type=\"button\" id=\"btnComfirmClose\" class=\"btn red\" data-dismiss=\"modal\" tabindex=\"8\"><i class=\"fa fa-close\"></i> <b>Đ</b>óng lại</button>";
        htmlResponse += "</div>";
        htmlResponse += "</div>";
        $('#dialog-confirm').html(htmlResponse);
        $('#dialog-confirm').modal({ width: 650 });
    }
}
//Pedding row tren grid
function rowPending(urlPost, arrRowId, rowTitle, urlFw) {

    if (arrRowId == '')
        createMessageDelete("Thông báo", "<div class=\"alert\"><strong>Chú ý!</strong> Bạn chưa chọn bản ghi nào!</div>");
    else {
        var htmlResponse = "";
        var urlNewFW = urlFw + '&do=pending&ItemID=' + arrRowId + '&temp=' + Math.floor(Math.random() * 11);
        htmlResponse += "<script type=\"text/javascript\">\r\n";
        htmlResponse += "$(document).ready(function(){\r\n";
        htmlResponse += "   unbindHotkey();\r\n";
        //Đăng ký sự kiện khi click vào nút delete
        htmlResponse += "   $(\"#btnComfirmPending\").click(function(){\r\n";
        htmlResponse += "       $.post(encodeURI(\"" + urlPost + "\"), { \"do\": \"pending\", \"itemId\": \"" + arrRowId + "\" }, function (data) {\r\n";
        htmlResponse += "       $('#btnComfirmClose').click();\r\n";
        htmlResponse += "           if (data.Error) {\r\n";
        htmlResponse += "               createMessage(\"Có lỗi xảy ra\", data.Title);\r\n";
        htmlResponse += "           }\r\n";
        htmlResponse += "           else {\r\n";
        htmlResponse += "               createCloseMessage(\"Thông báo\", data.Title, '" + urlNewFW + "');\r\n";
        htmlResponse += "           }\r\n";
        htmlResponse += "       });\r\n";
        htmlResponse += "   });\r\n";
        htmlResponse += "   $(document).bind('keypress', 'a', function (evt) {\r\n"; //Sự kiện bấm phím h
        htmlResponse += "       $('#btnComfirmPending').click();\r\n";
        htmlResponse += "   });\r\n";
        htmlResponse += "   $(document).bind('keypress', 'return', function (evt) {\r\n"; //Sự kiện bấm phím enter
        htmlResponse += "       $('#btnComfirmPending').click();\r\n";
        htmlResponse += "   });\r\n";
        htmlResponse += "   $(document).bind('keypress', 'd', function (evt) {\r\n"; // Sự kiện bấm phím d
        htmlResponse += "       $('#btnComfirmClose').click();\r\n";
        htmlResponse += "   });\r\n";
        htmlResponse += "   $('#dialog-confirm').on('hidden', function () {\r\n";
        htmlResponse += "      bindHotkey();\r\n";
        htmlResponse += "   })\r\n";
        htmlResponse += "});";
        htmlResponse += "</script>\r\n";

        htmlResponse += "<div id=\"ComfirmBox\">";
        htmlResponse += "<div class=\"modal-header\">";
        htmlResponse += "	<button type=\"button\" class=\"close\" data-dismiss=\"modal\" aria-hidden=\"true\"></button>";
        htmlResponse += "	<h4 class=\"modal-title\">Hủy duyệt bản ghi đã chọn</h4>";
        htmlResponse += "</div>";
        htmlResponse += "<div class=\"modal-body\">";
        htmlResponse += "    <div class=\"alert\">";
        htmlResponse += "		<strong>Chú ý!</strong> Bạn có chắc chắn muốn hủy duyệt!";
        htmlResponse += "	</div>";
        htmlResponse += "<ul>";
        htmlResponse += rowTitle;
        htmlResponse += "</ul>";
        htmlResponse += "</div>";
        htmlResponse += "<div class=\"modal-footer\">";
        htmlResponse += "	<button type=\"submit\" id=\"btnComfirmPending\" class=\"btn brown\" tabindex=\"5\"><i class=\"icon-eye-open\"></i> <b>H</b>ủy duyệt</button>";
        htmlResponse += "	<button type=\"button\" id=\"btnComfirmClose\" class=\"btn red\" data-dismiss=\"modal\" tabindex=\"8\"><i class=\"fa fa-close\"></i> <b>Đ</b>óng lại</button>";
        htmlResponse += "</div>";
        htmlResponse += "</div>";
        $('#dialog-confirm').html(htmlResponse);
        $('#dialog-confirm').modal({ width: 650 });
    }
}
//ẩn row tren grid
function rowHide(urlPost, arrRowId, rowTitle, urlFw) {

    if (arrRowId == '')
        createMessageDelete("Thông báo", "<div class=\"alert\"><strong>Chú ý!</strong> Bạn chưa chọn bản ghi nào!</div>");
    else {
        var htmlResponse = "";
        var urlNewFW = urlFw + '&do=hide&ItemID=' + arrRowId + '&temp=' + Math.floor(Math.random() * 11);
        htmlResponse += "<script type=\"text/javascript\">\r\n";
        htmlResponse += "$(document).ready(function(){\r\n";
        htmlResponse += "   unbindHotkey();\r\n";
        htmlResponse += "   $(\"#btnComfirmHide\").click(function(){\r\n";
        htmlResponse += "       $.post(encodeURI(\"" + urlPost + "\"), { \"do\": \"hide\", \"itemId\": \"" + arrRowId + "\" }, function (data) {\r\n";
        htmlResponse += "       $('#btnComfirmClose').click();\r\n";
        htmlResponse += "           if (data.Error) {\r\n";
        htmlResponse += "               createMessage(\"Có lỗi xảy ra\", data.Title);\r\n";
        htmlResponse += "           }\r\n";
        htmlResponse += "           else {\r\n";
        htmlResponse += "               createCloseMessage(\"Thông báo\", data.Title, '" + urlNewFW + "');\r\n";
        htmlResponse += "           }\r\n";
        htmlResponse += "       });\r\n";
        htmlResponse += "   });\r\n";
        htmlResponse += "   $(document).bind('keypress', 'a', function (evt) {\r\n"; //Sự kiện bấm phím a
        htmlResponse += "       $('#btnComfirmHide').click();\r\n";
        htmlResponse += "   });\r\n";
        htmlResponse += "   $(document).bind('keypress', 'return', function (evt) {\r\n"; //Sự kiện bấm phím enter
        htmlResponse += "       $('#btnComfirmHide').click();\r\n";
        htmlResponse += "   });\r\n";
        htmlResponse += "   $(document).bind('keypress', 'd', function (evt) {\r\n"; // Sự kiện bấm phím d
        htmlResponse += "       $('#btnComfirmClose').click();\r\n";
        htmlResponse += "   });\r\n";
        htmlResponse += "   $('#dialog-confirm').on('hidden', function () {\r\n";
        htmlResponse += "      bindHotkey();\r\n";
        htmlResponse += "   })\r\n";
        htmlResponse += "});";
        htmlResponse += "</script>\r\n";

        htmlResponse += "<div class=\"modal-header\">";
        htmlResponse += "	<button type=\"button\" class=\"close\" data-dismiss=\"modal\" aria-hidden=\"true\"></button>";
        htmlResponse += "	<h4 class=\"modal-title\">Ẩn bản ghi đã chọn</h4>";
        htmlResponse += "</div>";
        htmlResponse += "<div class=\"modal-body\">";
        htmlResponse += "    <div class=\"alert\">";
        htmlResponse += "		<strong>Chú ý!</strong> Bạn có chắc chắn muốn ẩn!";
        htmlResponse += "	</div>";
        htmlResponse += "<ul>";
        htmlResponse += rowTitle;
        htmlResponse += "</ul>";
        htmlResponse += "</div>";
        htmlResponse += "<div class=\"modal-footer\">";
        htmlResponse += "	<button type=\"submit\" id=\"btnComfirmHide\" class=\"btn brown\" tabindex=\"5\"><i class=\"far fa-eye-slash\"></i> <b>Ẩ</b>n</button>";
        htmlResponse += "	<button type=\"button\" id=\"btnComfirmClose\" class=\"btn red\" data-dismiss=\"modal\" tabindex=\"8\" onclick=\"resetchecbox()\"><i class=\"fa fa-close\"></i> <b>Đ</b>óng lại</button>";
        htmlResponse += "</div>";

        $('#dialog-confirm').html(htmlResponse);
        $('#dialog-confirm').modal({ width: 650 });
    }

}
//ẩn/ Hiện, thay đổi trạng thái bản ghi
function rowHideShow(urlPost, arrRowId, rowTitle, urlFw) {

    if (arrRowId == '')
        createMessageDelete("Thông báo", "<div class=\"alert\"><strong>Chú ý!</strong> Bạn chưa chọn bản ghi nào!</div>");
    else {
        var htmlResponse = "";
        var urlNewFW = urlFw + '&do=hide&ItemID=' + arrRowId + '&temp=' + Math.floor(Math.random() * 11);
        htmlResponse += "<script type=\"text/javascript\">\r\n";
        htmlResponse += "$(document).ready(function(){\r\n";
        htmlResponse += "   unbindHotkey();\r\n";
        htmlResponse += "   $(\"#btnComfirmHide\").click(function(){\r\n";
        htmlResponse += "       $.post(encodeURI(\"" + urlPost + "\"), { \"do\": \"hide\", \"itemId\": \"" + arrRowId + "\" }, function (data) {\r\n";
        htmlResponse += "       $('#btnComfirmClose').click();\r\n";
        htmlResponse += "           if (data.Error) {\r\n";
        htmlResponse += "               createMessage(\"Có lỗi xảy ra\", data.Title);\r\n";
        htmlResponse += "           }\r\n";
        htmlResponse += "           else {\r\n";
        htmlResponse += "               createCloseMessage(\"Thông báo\", data.Title, '" + urlNewFW + "');\r\n";
        htmlResponse += "           }\r\n";
        htmlResponse += "       });\r\n";
        htmlResponse += "   });\r\n";
        htmlResponse += "   $(document).bind('keypress', 'a', function (evt) {\r\n"; //Sự kiện bấm phím a
        htmlResponse += "       $('#btnComfirmHide').click();\r\n";
        htmlResponse += "   });\r\n";
        htmlResponse += "   $(document).bind('keypress', 'return', function (evt) {\r\n"; //Sự kiện bấm phím enter
        htmlResponse += "       $('#btnComfirmHide').click();\r\n";
        htmlResponse += "   });\r\n";
        htmlResponse += "   $(document).bind('keypress', 'd', function (evt) {\r\n"; // Sự kiện bấm phím d
        htmlResponse += "       $('#btnComfirmClose').click();\r\n";
        htmlResponse += "   });\r\n";
        htmlResponse += "   $('#dialog-confirm').on('hidden', function () {\r\n";
        htmlResponse += "      bindHotkey();\r\n";
        htmlResponse += "   })\r\n";
        htmlResponse += "});";
        htmlResponse += "</script>\r\n";

        htmlResponse += "<div class=\"modal-header\">";
        htmlResponse += "	<button type=\"button\" class=\"close\" data-dismiss=\"modal\" aria-hidden=\"true\"></button>";
        htmlResponse += "	<h4 class=\"modal-title\">Thay đổi trạng thái bản ghi đã chọn</h4>";
        htmlResponse += "</div>";
        htmlResponse += "<div class=\"modal-body\">";
        htmlResponse += "    <div class=\"alert\">";
        htmlResponse += "		<strong>Chú ý!</strong> Bạn có chắc thay đổi trạng thái!";
        htmlResponse += "	</div>";
        htmlResponse += "<ul>";
        htmlResponse += rowTitle;
        htmlResponse += "</ul>";
        htmlResponse += "</div>";
        htmlResponse += "<div class=\"modal-footer\">";
        htmlResponse += "	<button type=\"submit\" id=\"btnComfirmHide\" class=\"btn brown\" tabindex=\"5\"><i class=\"far fa-eye-slash\"></i> <b>Ẩ</b>n</button>";
        htmlResponse += "	<button type=\"button\" id=\"btnComfirmClose\" class=\"btn red\" data-dismiss=\"modal\" tabindex=\"8\" onclick=\"resetchecbox()\"><i class=\"fa fa-close\"></i> <b>Đ</b>óng lại</button>";
        htmlResponse += "</div>";

        $('#dialog-confirm').html(htmlResponse);
        $('#dialog-confirm').modal({ width: 650 });
    }

}

function deletenguoidungphongban(urlPost, arrRowId, donviid, rowTitle, urlFw) {
    if (arrRowId == '')
        createMessageDelete("Thông báo", "<div class=\"alert\"><strong>Chú ý!</strong> Bạn chưa chọn bản ghi nào!</div>");
    else {
        var htmlResponse = "";
        var urlNewFW = urlFw + '&do=delete&ItemID=' + arrRowId + 'DonViID=' + donviid + '&temp=' + Math.floor(Math.random() * 11);
        htmlResponse += "<script type=\"text/javascript\">\r\n";
        htmlResponse += "$(document).ready(function(){\r\n";
        htmlResponse += "   unbindHotkey();\r\n";
        //Đăng ký sự kiện khi click vào nút delete
        htmlResponse += "   $(\"#btnComfirmDelete\").click(function(){\r\n";
        htmlResponse += "       $.post(encodeURI(\"" + urlPost + "\"), { \"do\": \"delete\", \"itemId\": \"" + arrRowId + "\", \"DonViID\": \"" + donviid + "\" }, function (data) {\r\n";
        htmlResponse += "       $('#btnComfirmClose').click();\r\n";
        htmlResponse += "           if (data.Error) {\r\n";
        htmlResponse += "               createMessage(\"Có lỗi xảy ra\", data.Title);\r\n";
        htmlResponse += "           }\r\n";
        htmlResponse += "           else {\r\n";
        htmlResponse += "               createCloseMessage(\"Thông báo\", data.Title, '" + urlNewFW + "');\r\n";
        htmlResponse += "           }\r\n";
        htmlResponse += "       });\r\n";
        htmlResponse += "   });\r\n";
        htmlResponse += "   $(document).bind('keypress', 'x', function (evt) {\r\n"; //Sự kiện bấm phím x
        htmlResponse += "       $('#btnComfirmDelete').click();\r\n";
        htmlResponse += "   });\r\n";
        htmlResponse += "   $(document).bind('keypress', 'return', function (evt) {\r\n"; //Sự kiện bấm phím enter
        htmlResponse += "       $('#btnComfirmDelete').click();\r\n";
        htmlResponse += "   });\r\n";
        htmlResponse += "   $(document).bind('keypress', 'd', function (evt) {\r\n"; // Sự kiện bấm phím d
        htmlResponse += "       $('#btnComfirmClose').click();\r\n";
        htmlResponse += "   });\r\n";
        htmlResponse += "   $('#dialog-confirm').on('hidden', function () {\r\n";
        htmlResponse += "      bindHotkey();\r\n";
        htmlResponse += "   })\r\n";
        htmlResponse += "});";
        htmlResponse += "</script>\r\n";

        htmlResponse += "<div class=\"modal-header\">";
        htmlResponse += "	<button type=\"button\" class=\"close\" data-dismiss=\"modal\" aria-hidden=\"true\"></button>";
        htmlResponse += "	<h4 class=\"modal-title\">Xóa bản ghi đã chọn</h4>";
        htmlResponse += "</div>";
        htmlResponse += "<div class=\"modal-body\">";
        htmlResponse += "    <div class=\"alert\">";
        htmlResponse += "		<strong>Chú ý!</strong> Bạn có chắc chắn muốn xóa?";
        htmlResponse += "	</div>";
        htmlResponse += "<ul>";
        htmlResponse += rowTitle;
        htmlResponse += "</ul>";
        htmlResponse += "</div>";
        htmlResponse += "<div class=\"modal-footer\">";
        htmlResponse += "	<button type=\"submit\" id=\"btnComfirmDelete\" class=\"btn brown \" tabindex=\"5\"><i class=\"icon-trash\"></i> <b>X</b>óa</button>";
        htmlResponse += "	<button type=\"button\" id=\"btnComfirmClose\" class=\"btn red\" data-dismiss=\"modal\" tabindex=\"8\" onclick=\"resetchecbox()\"><i class='fa fa-remove'></i> <b>Đ</b>óng lại</button>";
        htmlResponse += "</div>";

        $('#dialog-confirm').html(htmlResponse);
        $('#dialog-confirm').modal({ width: 650 });
    }
}

//xoa row tren grid
function rowDelete(urlPost, arrRowId, rowTitle, urlFw) {
    if (arrRowId == '')
        createMessageDelete("Thông báo", "<div class=\"alert\"><strong>Chú ý!</strong> Bạn chưa chọn bản ghi nào!</div>");
    else {
        var htmlResponse = "";
        var urlNewFW = urlFw + '&do=delete&ItemID=' + arrRowId + '&temp=' + Math.floor(Math.random() * 11);
        htmlResponse += "<script type=\"text/javascript\">\r\n";
        htmlResponse += "$(document).ready(function(){\r\n";
        htmlResponse += "   unbindHotkey();\r\n";
        //Đăng ký sự kiện khi click vào nút delete
        htmlResponse += "   $(\"#btnComfirmDelete\").click(function(){\r\n";
        htmlResponse += "       $.post(encodeURI(\"" + urlPost + "\"), { \"do\": \"delete\", \"itemId\": \"" + arrRowId + "\" }, function (data) {\r\n";
        htmlResponse += "       $('#btnComfirmClose').click();\r\n";
        htmlResponse += "           if (data.Error) {\r\n";
        htmlResponse += "               createMessage(\"Có lỗi xảy ra\", data.Title);\r\n";
        htmlResponse += "           }\r\n";
        htmlResponse += "           else {\r\n";
        htmlResponse += "               createCloseMessage(\"Thông báo\", data.Title, '" + urlNewFW + "');\r\n";
        htmlResponse += "           }\r\n";
        htmlResponse += "       });\r\n";
        htmlResponse += "   });\r\n";
        htmlResponse += "   $(document).bind('keypress', 'x', function (evt) {\r\n"; //Sự kiện bấm phím x
        htmlResponse += "       $('#btnComfirmDelete').click();\r\n";
        htmlResponse += "   });\r\n";
        htmlResponse += "   $(document).bind('keypress', 'return', function (evt) {\r\n"; //Sự kiện bấm phím enter
        htmlResponse += "       $('#btnComfirmDelete').click();\r\n";
        htmlResponse += "   });\r\n";
        htmlResponse += "   $(document).bind('keypress', 'd', function (evt) {\r\n"; // Sự kiện bấm phím d
        htmlResponse += "       $('#btnComfirmClose').click();\r\n";
        htmlResponse += "   });\r\n";
        htmlResponse += "   $('#dialog-confirm').on('hidden', function () {\r\n";
        htmlResponse += "      bindHotkey();\r\n";
        htmlResponse += "   })\r\n";
        htmlResponse += "});";
        htmlResponse += "</script>\r\n";

        htmlResponse += "<div class=\"modal-header\">";
        htmlResponse += "	<button type=\"button\" class=\"close\" data-dismiss=\"modal\" aria-hidden=\"true\"></button>";
        htmlResponse += "	<h4 class=\"modal-title\">Xóa bản ghi đã chọn</h4>";
        htmlResponse += "</div>";
        htmlResponse += "<div class=\"modal-body\">";
        htmlResponse += "    <div class=\"alert\">";
        htmlResponse += "		<strong>Chú ý!</strong> Bạn có chắc chắn muốn xóa?";
        htmlResponse += "	</div>";
        htmlResponse += "<ul>";
        htmlResponse += rowTitle;
        htmlResponse += "</ul>";
        htmlResponse += "</div>";
        htmlResponse += "<div class=\"modal-footer\">";
        htmlResponse += "	<button type=\"submit\" id=\"btnComfirmDelete\" class=\"btn brown \" tabindex=\"5\"><i class=\"icon-trash\"></i> <b>X</b>óa</button>";
        htmlResponse += "	<button type=\"button\" id=\"btnComfirmClose\" class=\"btn red\" data-dismiss=\"modal\" tabindex=\"8\" onclick=\"resetchecbox()\"><i class='fa fa-remove'></i> <b>Đ</b>óng lại</button>";
        htmlResponse += "</div>";

        $('#dialog-confirm').html(htmlResponse);
        $('#dialog-confirm').modal({ width: 650 });
    }
}

//xoa row tren grid
function rowDeleteQuyetDinh(urlPost, arrRowId, rowTitle, urlFw) {
    if (arrRowId == '')
        createMessageDelete("Thông báo", "<div class=\"alert\"><strong>Chú ý!</strong> Bạn chưa chọn bản ghi nào!</div>");
    else {
        var htmlResponse = "";
        var urlNewFW = urlFw + '&do=deletequyetdinh&ItemID=' + arrRowId + '&temp=' + Math.floor(Math.random() * 11);
        htmlResponse += "<script type=\"text/javascript\">\r\n";
        htmlResponse += "$(document).ready(function(){\r\n";
        htmlResponse += "   unbindHotkey();\r\n";
        //Đăng ký sự kiện khi click vào nút delete
        htmlResponse += "   $(\"#btnComfirmDelete\").click(function(){\r\n";
        htmlResponse += "       $.post(encodeURI(\"" + urlPost + "\"), { \"do\": \"deletequyetdinh\", \"itemId\": \"" + arrRowId + "\" }, function (data) {\r\n";
        htmlResponse += "       $('#btnComfirmClose').click();\r\n";
        htmlResponse += "           if (data.Error) {\r\n";
        htmlResponse += "               createMessage(\"Có lỗi xảy ra\", data.Title);\r\n";
        htmlResponse += "           }\r\n";
        htmlResponse += "           else {\r\n";
        htmlResponse += "               createCloseMessage(\"Thông báo\", data.Title, '" + urlNewFW + "');\r\n";
        htmlResponse += "           }\r\n";
        htmlResponse += "       });\r\n";
        htmlResponse += "   });\r\n";
        htmlResponse += "   $(document).bind('keypress', 'x', function (evt) {\r\n"; //Sự kiện bấm phím x
        htmlResponse += "       $('#btnComfirmDelete').click();\r\n";
        htmlResponse += "   });\r\n";
        htmlResponse += "   $(document).bind('keypress', 'return', function (evt) {\r\n"; //Sự kiện bấm phím enter
        htmlResponse += "       $('#btnComfirmDelete').click();\r\n";
        htmlResponse += "   });\r\n";
        htmlResponse += "   $(document).bind('keypress', 'd', function (evt) {\r\n"; // Sự kiện bấm phím d
        htmlResponse += "       $('#btnComfirmClose').click();\r\n";
        htmlResponse += "   });\r\n";
        htmlResponse += "   $('#dialog-confirm').on('hidden', function () {\r\n";
        htmlResponse += "      bindHotkey();\r\n";
        htmlResponse += "   })\r\n";
        htmlResponse += "});";
        htmlResponse += "</script>\r\n";

        htmlResponse += "<div class=\"modal-header\">";
        htmlResponse += "	<button type=\"button\" class=\"close\" data-dismiss=\"modal\" aria-hidden=\"true\"></button>";
        htmlResponse += "	<h4 class=\"modal-title\">Xóa bản ghi đã chọn</h4>";
        htmlResponse += "</div>";
        htmlResponse += "<div class=\"modal-body\">";
        htmlResponse += "    <div class=\"alert\">";
        htmlResponse += "		<strong>Chú ý!</strong> Bạn có chắc chắn muốn xóa?";
        htmlResponse += "	</div>";
        htmlResponse += "<ul>";
        htmlResponse += rowTitle;
        htmlResponse += "</ul>";
        htmlResponse += "</div>";
        htmlResponse += "<div class=\"modal-footer\">";
        htmlResponse += "	<button type=\"submit\" id=\"btnComfirmDelete\" class=\"btn brown \" tabindex=\"5\"><i class=\"icon-trash\"></i> <b>X</b>óa</button>";
        htmlResponse += "	<button type=\"button\" id=\"btnComfirmClose\" class=\"btn red\" data-dismiss=\"modal\" tabindex=\"8\" onclick=\"resetchecbox()\"><i class='fa fa-remove'></i> <b>Đ</b>óng lại</button>";
        htmlResponse += "</div>";

        $('#dialog-confirm').html(htmlResponse);
        $('#dialog-confirm').modal({ width: 650 });
    }
}
//xoa row tren grid có truyền tham số action: ID là HoSoTaiLieuID, arrRowId: ID văn bản liên quan 
function rowDeleteAction(urlPost, arrRowId, rowTitle, urlFw, action, ID, container) {
    if (arrRowId == '')
        createMessageDelete("Thông báo", "<div class=\"alert\"><strong>Chú ý!</strong> Bạn chưa chọn bản ghi nào!</div>");
    else {
        var htmlResponse = "";
        var urlNewFW = urlFw + '&do=delete&ItemID=' + arrRowId + '&temp=' + Math.floor(Math.random() * 11);
        htmlResponse += "<script type=\"text/javascript\">\r\n";
        htmlResponse += "$(document).ready(function(){\r\n";
        htmlResponse += "   unbindHotkey();\r\n";
        //Đăng ký sự kiện khi click vào nút delete
        htmlResponse += "   $(\"#btnComfirmDelete\").click(function(){\r\n";
        htmlResponse += "       $.post(encodeURI(\"" + urlPost + "\"), { \"do\": \"" + action + "\",\"ID\": \"" + ID + "\", \"itemId\": \"" + arrRowId + "\" }, function (data) {\r\n";
        htmlResponse += "       $('#btnComfirmClose').click();\r\n";
        htmlResponse += "           if (data.Error) {\r\n";
        htmlResponse += "               createMessage(\"Có lỗi xảy ra\", data.Title);\r\n";
        htmlResponse += "           }\r\n";
        htmlResponse += "           else {\r\n";
        htmlResponse += "               LoadAjaxPage(\"" + urlFw + "\", \"" + container + "\");\r\n";
        htmlResponse += "               createCloseMessage(\"Thông báo\", data.Title, '" + urlNewFW + "');\r\n";
        htmlResponse += "           }\r\n";
        htmlResponse += "       });\r\n";
        htmlResponse += "   });\r\n";
        htmlResponse += "   $(document).bind('keypress', 'x', function (evt) {\r\n"; //Sự kiện bấm phím x
        htmlResponse += "       $('#btnComfirmDelete').click();\r\n";
        htmlResponse += "   });\r\n";
        htmlResponse += "   $(document).bind('keypress', 'return', function (evt) {\r\n"; //Sự kiện bấm phím enter
        htmlResponse += "       $('#btnComfirmDelete').click();\r\n";
        htmlResponse += "   });\r\n";
        htmlResponse += "   $(document).bind('keypress', 'd', function (evt) {\r\n"; // Sự kiện bấm phím d
        htmlResponse += "       $('#btnComfirmClose').click();\r\n";
        htmlResponse += "   });\r\n";
        htmlResponse += "   $('#dialog-confirm').on('hidden', function () {\r\n";
        htmlResponse += "      bindHotkey();\r\n";
        htmlResponse += "   })\r\n";
        htmlResponse += "});";
        htmlResponse += "</script>\r\n";

        htmlResponse += "<div class=\"modal-header\">";
        htmlResponse += "	<button type=\"button\" class=\"close\" data-dismiss=\"modal\" aria-hidden=\"true\"></button>";
        htmlResponse += "	<h4 class=\"modal-title\">Xóa bản ghi đã chọn</h4>";
        htmlResponse += "</div>";
        htmlResponse += "<div class=\"modal-body\">";
        htmlResponse += "    <div class=\"alert\">";
        htmlResponse += "		<strong>Chú ý!</strong> Bạn có chắc chắn muốn xóa!";
        htmlResponse += "	</div>";
        htmlResponse += "<ul>";
        htmlResponse += rowTitle;
        htmlResponse += "</ul>";
        htmlResponse += "</div>";
        htmlResponse += "<div class=\"modal-footer\">";
        htmlResponse += "	<button type=\"submit\" id=\"btnComfirmDelete\" class=\"btn brown \" tabindex=\"5\"><i class=\"icon-trash\"></i> <b>X</b>óa</button>";
        htmlResponse += "	<button type=\"button\" id=\"btnComfirmClose\" class=\"btn red\" data-dismiss=\"modal\" tabindex=\"8\"><i class='fa fa-remove'></i> <b>Đ</b>óng lại</button>";
        htmlResponse += "</div>";

        $('#dialog-confirm').html(htmlResponse);
        $('#dialog-confirm').modal({ width: 650 });
    }
}
//truyen tham so kieu: method = 'submit()'
function alertpopup(Noidung, method) {
    var htmlResponse = "";
    htmlResponse += "<script>";
    htmlResponse += "$(document).ready(function () {";
    htmlResponse += "$('#btnComfirmDelete').click(function () {";
    htmlResponse += " $('#dialog-confirm').modal('hide');";
    htmlResponse += " $('#btnComfirmClose').click();";
    htmlResponse += method + ";";
    htmlResponse += "});";
    htmlResponse += "});";
    htmlResponse += "</script>";
    htmlResponse += "<div class=\"modal-header\">";
    htmlResponse += "    <button aria-hidden=\"true\" data-dismiss=\"modal\" class=\"close\" type=\"button\"></button>";
    htmlResponse += "    <h4 class=\"modal-title\">Thông báo</h4>";
    htmlResponse += "</div>";
    htmlResponse += "<div class=\"modal-body\">";
    htmlResponse += "    <div class=\"alert\">";
    htmlResponse += "		<strong>Chú ý! </strong> " + Noidung;
    htmlResponse += "	</div>";
    htmlResponse += "</div>";
    htmlResponse += "<div class=\"modal-footer\">";
    htmlResponse += "	<button type=\"submit\" id=\"btnComfirmDelete\" class=\"btn brown\" tabindex=\"5\"><b>C</b>ó</button>";
    htmlResponse += "	<button type=\"button\" id=\"btnComfirmClose\" class=\"btn red\" data-dismiss=\"modal\" tabindex=\"8\"><i class='fa fa-remove'></i> <b>K</b>hông</button>";
    htmlResponse += "</div>";
    $('#dialog-confirm').html(htmlResponse);
    $('#dialog-confirm').modal({ width: 650 });
    $("#dialog-form").modal("hide");
}
//truyen tham so kieu: method = 'submit()'
function alertpopup3(Noidung, method, title) {
    var htmlResponse = "";
    htmlResponse += "<script>";
    htmlResponse += "$(document).ready(function () {";
    htmlResponse += "$('#btnComfirmDelete').click(function () {";
    htmlResponse += " $('#dialog-confirm').modal('hide');";
    htmlResponse += " $('#btnComfirmClose').click();";
    htmlResponse += method + ";";
    htmlResponse += "});";
    htmlResponse += "});";
    htmlResponse += "</script>";
    htmlResponse += "<div class=\"modal-header\">";
    htmlResponse += "    <button aria-hidden=\"true\" data-dismiss=\"modal\" class=\"close\" type=\"button\"></button>";
    htmlResponse += "    <h4 class=\"modal-title\">" + title + "</h4>";
    htmlResponse += "</div>";
    htmlResponse += "<div class=\"modal-body\">";
    //htmlResponse += "    <div class=\"alert\">";
    htmlResponse += Noidung;
    //htmlResponse += "	</div>";
    htmlResponse += "</div>";
    htmlResponse += "<div class=\"modal-footer\">";
    htmlResponse += "	<button type=\"submit\" id=\"btnComfirmDelete\" class=\"btn brown\" tabindex=\"5\">Lưu</button>";
    htmlResponse += "	<button type=\"button\" id=\"btnComfirmClose\" class=\"btn red\" data-dismiss=\"modal\" tabindex=\"8\"><i class='fa fa-remove'></i> <b>Thoát</button>";
    htmlResponse += "</div>";
    $('#dialog-confirm').html(htmlResponse);
    $('#dialog-confirm').modal({ width: 650 });
    $("#dialog-form").modal("hide");
}
function rowCapNhatTrangThai(urlPost, arrRowId, rowTitle, urlFw) {
    if (arrRowId == '')
        createMessage("Thông báo", "<div class=\"alert\"><strong>Chú ý.!</strong> Bạn chưa chọn bản ghi nào.");
    else {
        var htmlResponse = "";
        var urlNewFW = urlFw + '&do=hide&ItemID=' + arrRowId + '&temp=' + Math.floor(Math.random() * 11);
        htmlResponse += "<script type=\"text/javascript\">\r\n";
        htmlResponse += "$(document).ready(function(){\r\n";
        htmlResponse += "   unbindHotkey();$('#TrangThaiID').select2();\r\n";
        //Đăng ký sự kiện khi click vào nút delete

        htmlResponse += "   $(\"#btnComfirmDelete\").click(function(){\r\n";

        htmlResponse += "       $.post(encodeURI(\"" + urlPost + "\"), { \"do\": \"capnhatthongtin\", \"itemId\": \"" + arrRowId + "\", \"TrangThaiID\": $('#TrangThaiID').val(), \"LyDo\": $('#LyDo').val()}, function (data) {\r\n";

        htmlResponse += "       $('#btnComfirmClose').click();\r\n";
        htmlResponse += "           if (data.Error) {\r\n";
        htmlResponse += "               createMessage(\"Có lỗi xảy ra\", data.Title);\r\n";
        htmlResponse += "           }\r\n";
        htmlResponse += "           else {\r\n";
        htmlResponse += "               createCloseMessage(\"Thông báo\", data.Title, '" + urlNewFW + "');\r\n";
        htmlResponse += "           }\r\n";
        htmlResponse += "       });\r\n";
        htmlResponse += "   });\r\n";
        htmlResponse += "});";
        htmlResponse += "</script>\r\n";
        htmlResponse += "<div class=\"modal-header\">";
        htmlResponse += "	<button type=\"button\" class=\"close\" data-dismiss=\"modal\" aria-hidden=\"true\"></button>";
        htmlResponse += "	<h4 class=\"modal-title\">Cập nhật trạng thái hồ sơ</h4>";
        htmlResponse += "</div>";
        htmlResponse += "<div class=\"modal-body\">";
        htmlResponse += "   <div class=\"form-horizontal\">";
        htmlResponse += "       <div class=\"row\">";
        htmlResponse += "           <div class=\"col-md-12 col-sm-12\">";
        htmlResponse += "               <div class=\"form-group\">";
        htmlResponse += "                   <label class=\"col-sm-3 col-md-3 control-label\">";
        htmlResponse += "                   Trạng thái<span class=\"required\" aria-required=\"true\">*</span>";
        htmlResponse += "                   </label>";
        htmlResponse += "                   <div class=\"col-sm-9 col-md-9\">";
        htmlResponse += loadTrangThai();
        htmlResponse += "                   </div>";
        htmlResponse += "               </div>";
        htmlResponse += "           </div>";
        htmlResponse += "           <div class=\"col-md-12 col-sm-12\">";
        htmlResponse += "               <div class=\"form-group\">";
        htmlResponse += "                   <label class=\"col-sm-3 col-md-3 control-label\">";
        htmlResponse += "                   Lý do<span class=\"required\" aria-required=\"true\">*</span>";
        htmlResponse += "                   </label>";
        htmlResponse += "                   <div class=\"col-sm-9 col-md-9\">";
        htmlResponse += "                       <textarea class=\"form-control\" name=\"LyDo\" id=\"LyDo\" placeholder=\"Nhập lý do của trạng thái\" rows=\"3\"></textarea>";
        htmlResponse += "                   </div>";
        htmlResponse += "           </div>";
        htmlResponse += "       </div>";
        htmlResponse += "   </div>";
        htmlResponse += "</div>";

        htmlResponse += "<div class=\"modal-footer\">";
        htmlResponse += "	<button type=\"submit\" id=\"btnComfirmDelete\" class=\"btn brown\" tabindex=\"5\"><i class=\"icon-save\"></i> Đồng ý</button>";
        htmlResponse += "	<button type=\"button\" id=\"btnComfirmClose\" class=\"btn red\" data-dismiss=\"modal\" tabindex=\"8\"><i class=\"fa fa-close\"></i> Đóng lại</button>";
        htmlResponse += "</div>";

        $('#dialog-confirm').html(htmlResponse);
        $('#dialog-confirm').modal({ width: 650 });
    }
}

function rowReject(urlPost, arrRowId, rowTitle, urlFw) {
    if (arrRowId == '')
        createMessage("Thông báo", "<div class=\"alert\"><strong>Chú ý.!</strong> Bạn chưa chọn bản ghi nào.");
    else {
        var htmlResponse = "";
        var urlNewFW = urlFw + '&do=hide&ItemID=' + arrRowId + '&temp=' + Math.floor(Math.random() * 11);
        htmlResponse += "<script type=\"text/javascript\">\r\n";
        htmlResponse += "$(document).ready(function(){\r\n";
        htmlResponse += "   unbindHotkey();$('#TrangThaiID').select2();\r\n";
        //Đăng ký sự kiện khi click vào nút delete

        htmlResponse += "   $(\"#btnComfirmDelete\").click(function(){\r\n";

        htmlResponse += "       $.post(encodeURI(\"" + urlPost + "\"), { \"do\": \"reject\", \"itemId\": \"" + arrRowId + "\", \"LyDo\": $('#LyDo').val()}, function (data) {\r\n";

        htmlResponse += "       $('#btnComfirmClose').click();\r\n";
        htmlResponse += "           if (data.Error) {\r\n";
        htmlResponse += "               createMessage(\"Có lỗi xảy ra\", data.Title);\r\n";
        htmlResponse += "           }\r\n";
        htmlResponse += "           else {\r\n";
        htmlResponse += "               createCloseMessage(\"Thông báo\", data.Title, '" + urlNewFW + "');\r\n";
        htmlResponse += "           }\r\n";
        htmlResponse += "       });\r\n";
        htmlResponse += "   });\r\n";
        htmlResponse += "});";
        htmlResponse += "</script>\r\n";
        htmlResponse += "<div class=\"modal-header\">";
        htmlResponse += "	<button type=\"button\" class=\"close\" data-dismiss=\"modal\" aria-hidden=\"true\"></button>";
        htmlResponse += "	<h4 class=\"modal-title\">Từ chối yêu cầu</h4>";
        htmlResponse += "</div>";
        htmlResponse += "<div class=\"modal-body\">";
        htmlResponse += "   <div class=\"form-horizontal\">";
        htmlResponse += "       <div class=\"row\">";
        htmlResponse += "           <div class=\"col-md-12 col-sm-12\">";
        htmlResponse += "               <div class=\"form-group\">";
        htmlResponse += "                   <label class=\"col-sm-3 col-md-3 control-label\">";
        htmlResponse += "                   Lý do<span class=\"required\" aria-required=\"true\">*</span>";
        htmlResponse += "                   </label>";
        htmlResponse += "                   <div class=\"col-sm-9 col-md-9\">";
        htmlResponse += "                       <textarea class=\"form-control\" name=\"LyDo\" id=\"LyDo\" placeholder=\"Nhập lý do của trạng thái\" rows=\"3\"></textarea>";
        htmlResponse += "                   </div>";
        htmlResponse += "           </div>";
        htmlResponse += "       </div>";
        htmlResponse += "   </div>";
        htmlResponse += "</div>";

        htmlResponse += "<div class=\"modal-footer\">";
        htmlResponse += "	<button type=\"submit\" id=\"btnComfirmDelete\" class=\"btn brown\" tabindex=\"5\"><i class=\"icon-save\"></i> Đồng ý</button>";
        htmlResponse += "	<button type=\"button\" id=\"btnComfirmClose\" class=\"btn red\" data-dismiss=\"modal\" tabindex=\"8\"><i class=\"fa fa-close\"></i> Đóng lại</button>";
        htmlResponse += "</div>";

        $('#dialog-confirm').html(htmlResponse);
        $('#dialog-confirm').modal({ width: 650 });
    }
}

function rowExtend(urlPost, arrRowId, rowTitle, urlFw) {
    if (arrRowId == '')
        createMessage("Thông báo", "<div class=\"alert\"><strong>Chú ý.!</strong> Bạn chưa chọn bản ghi nào.");
    else {
        var htmlResponse = "";
        var urlNewFW = urlFw + '&do=hide&ItemID=' + arrRowId + '&temp=' + Math.floor(Math.random() * 11);
        htmlResponse += "<script type=\"text/javascript\">\r\n";
        htmlResponse += "$(document).ready(function(){\r\n";
        htmlResponse += "   unbindHotkey();$('#TrangThaiID').select2();$('.date').datepicker({format: 'dd/mm/yyyy',}).on('changeDate', function (e) {$(this).datepicker('hide');});\r\n";
        //Đăng ký sự kiện khi click vào nút delete

        htmlResponse += "   $(\"#btnComfirmDelete\").click(function(){\r\n";

        htmlResponse += "       $.post(encodeURI(\"" + urlPost + "\"), { \"do\": \"giahanluutru\", \"itemId\": \"" + arrRowId + "\", \"NgayGiaHan\": $('#NgayGiaHan').val(), \"NoiDung\": $('#NoiDung').val()}, function (data) {\r\n";

        htmlResponse += "       $('#btnComfirmClose').click();\r\n";
        htmlResponse += "           if (data.Error) {\r\n";
        htmlResponse += "               createMessage(\"Có lỗi xảy ra\", data.Title);\r\n";
        htmlResponse += "           }\r\n";
        htmlResponse += "           else {\r\n";
        htmlResponse += "               createCloseMessage(\"Thông báo\", data.Title, '" + urlNewFW + "');\r\n";
        htmlResponse += "           }\r\n";
        htmlResponse += "       });\r\n";
        htmlResponse += "   });\r\n";
        htmlResponse += "});";
        htmlResponse += "</script>\r\n";
        htmlResponse += "<div class=\"modal-header\">";
        htmlResponse += "	<button type=\"button\" class=\"close\" data-dismiss=\"modal\" aria-hidden=\"true\"></button>";
        htmlResponse += "	<h4 class=\"modal-title\">Gửi yêu cầu gia hạn</h4>";
        htmlResponse += "</div>";
        htmlResponse += "<div class=\"modal-body\">";
        htmlResponse += "   <div class=\"form-horizontal\">";
        htmlResponse += "       <div class=\"row\">";
        htmlResponse += "           <div class=\"col-md-12 col-sm-12\">";
        htmlResponse += "               <div class=\"form-group\">";
        htmlResponse += "                   <label class=\"col-sm-3 col-md-3 control-label\">";
        htmlResponse += "                   Ngày gia hạn<span class=\"required\" aria-required=\"true\">*</span>";
        htmlResponse += "                   </label>";
        htmlResponse += "                   <div class=\"col-sm-9 col-md-9\">";
        htmlResponse += "                       <div class=\"input-group date date-picker\" data-date-format=\"dd-mm-yyyy\">";
        htmlResponse += "                           <input class=\"form-control\" name=\"NgayGiaHan\" id=\"NgayGiaHan\" placeholder=\"Chọn ngày gia hạn\" />";
        htmlResponse += "                           <span class=\"input-group-btn\">";
        htmlResponse += "                               <button class=\"btn default btn-date\" type=\"button\"><i class=\"fa fa-calendar\"></i></button>";
        htmlResponse += "                           </span>";
        htmlResponse += "                       </div>";
        htmlResponse += "                   </div>";
        htmlResponse += "               </div>";
        htmlResponse += "           </div>";
        htmlResponse += "           <div class=\"col-md-12 col-sm-12\">";
        htmlResponse += "               <div class=\"form-group\">";
        htmlResponse += "                   <label class=\"col-sm-3 col-md-3 control-label\">";
        htmlResponse += "                   Lý do<span class=\"required\" aria-required=\"true\">*</span>";
        htmlResponse += "                   </label>";
        htmlResponse += "                   <div class=\"col-sm-9 col-md-9\">";
        htmlResponse += "                       <textarea class=\"form-control\" name=\"NoiDung\" id=\"NoiDung\" placeholder=\"Nhập lý do gia hạn\" rows=\"3\"></textarea>";
        htmlResponse += "                   </div>";
        htmlResponse += "           </div>";
        htmlResponse += "       </div>";
        htmlResponse += "   </div>";
        htmlResponse += "</div>";

        htmlResponse += "<div class=\"modal-footer\">";
        htmlResponse += "	<button type=\"submit\" id=\"btnComfirmDelete\" class=\"btn brown\" tabindex=\"5\"><i class=\"icon-save\"></i> Đồng ý</button>";
        htmlResponse += "	<button type=\"button\" id=\"btnComfirmClose\" class=\"btn red\" data-dismiss=\"modal\" tabindex=\"8\"><i class=\"fa fa-close\"></i> Đóng lại</button>";
        htmlResponse += "</div>";

        $('#dialog-confirm').html(htmlResponse);
        $('#dialog-confirm').modal({ width: 650 });
    }
}

function rowThongBao(urlPost, arrRowId, rowTitle, urlFw) {
    if (arrRowId == '')
        createMessage("Thông báo", "<div class=\"alert\"><strong>Chú ý.!</strong> Bạn chưa chọn bản ghi nào.");
    else {
        var htmlResponse = "";
        var urlNewFW = urlFw + '&do=hide&ItemID=' + arrRowId + '&temp=' + Math.floor(Math.random() * 11);
        htmlResponse += "<script type=\"text/javascript\">\r\n";
        htmlResponse += "$(document).ready(function(){\r\n";
        htmlResponse += "   unbindHotkey();$('#TrangThaiID').select2();$('.date').datepicker({format: 'dd/mm/yyyy',}).on('changeDate', function (e) {$(this).datepicker('hide');});\r\n";
        //Đăng ký sự kiện khi click vào nút delete

        htmlResponse += "   $(\"#btnComfirmDelete\").click(function(){\r\n";

        htmlResponse += "       $.post(encodeURI(\"" + urlPost + "\"), { \"do\": \"thongbaohethan\", \"itemId\": \"" + arrRowId + "\", \"NoiDung\": $('#NoiDung').val()}, function (data) {\r\n";

        htmlResponse += "       $('#btnComfirmClose').click();\r\n";
        htmlResponse += "           if (data.Error) {\r\n";
        htmlResponse += "               createMessage(\"Có lỗi xảy ra\", data.Title);\r\n";
        htmlResponse += "           }\r\n";
        htmlResponse += "           else {\r\n";
        htmlResponse += "               createCloseMessage(\"Thông báo\", data.Title, '" + urlNewFW + "');\r\n";
        htmlResponse += "           }\r\n";
        htmlResponse += "       });\r\n";
        htmlResponse += "   });\r\n";
        htmlResponse += "});";
        htmlResponse += "</script>\r\n";
        htmlResponse += "<div class=\"modal-header\">";
        htmlResponse += "	<button type=\"button\" class=\"close\" data-dismiss=\"modal\" aria-hidden=\"true\"></button>";
        htmlResponse += "	<h4 class=\"modal-title\">Gửi thông báo hết hạn mượn tài liệu</h4>";
        htmlResponse += "</div>";
        htmlResponse += "<div class=\"modal-body\">";
        htmlResponse += "   <div class=\"form-horizontal\">";
        htmlResponse += "       <div class=\"row\">";
        htmlResponse += "           <div class=\"col-md-12 col-sm-12\">";
        htmlResponse += "               <div class=\"form-group\">";
        htmlResponse += "                   <label class=\"col-sm-3 col-md-3 control-label\">";
        htmlResponse += "                   Nội dung<span class=\"required\" aria-required=\"true\">*</span>";
        htmlResponse += "                   </label>";
        htmlResponse += "                   <div class=\"col-sm-9 col-md-9\">";
        htmlResponse += "                       <textarea class=\"form-control\" name=\"NoiDung\" id=\"NoiDung\" placeholder=\"Nhập nội dung thông báo\" rows=\"3\"></textarea>";
        htmlResponse += "                   </div>";
        htmlResponse += "           </div>";
        htmlResponse += "       </div>";
        htmlResponse += "   </div>";
        htmlResponse += "</div>";

        htmlResponse += "<div class=\"modal-footer\">";
        htmlResponse += "	<button type=\"submit\" id=\"btnComfirmDelete\" class=\"btn brown\" tabindex=\"5\"><i class=\"icon-save\"></i> Đồng ý</button>";
        htmlResponse += "	<button type=\"button\" id=\"btnComfirmClose\" class=\"btn red\" data-dismiss=\"modal\" tabindex=\"8\"><i class=\"fa fa-close\"></i> Đóng lại</button>";
        htmlResponse += "</div>";

        $('#dialog-confirm').html(htmlResponse);
        $('#dialog-confirm').modal({ width: 650 });
    }
}

function rowNopLuuTru(urlPost, arrRowId, rowTitle, urlFw) {
    if (arrRowId == '')
        createMessage("Thông báo", "<div class=\"alert\"><strong>Chú ý.!</strong> Bạn chưa chọn bản ghi nào.");
    else {
        var htmlResponse = "";
        var urlNewFW = urlFw + '&do=hide&ItemID=' + arrRowId + '&temp=' + Math.floor(Math.random() * 11);
        htmlResponse += "<script type=\"text/javascript\">\r\n";
        htmlResponse += "$(document).ready(function(){\r\n";
        htmlResponse += "   unbindHotkey();$('.date').datepicker({format: 'dd/mm/yyyy',}).on('changeDate', function (e) {$(this).datepicker('hide');});\r\n";
        //Đăng ký sự kiện khi click vào nút delete

        htmlResponse += "   $(\"#btnComfirmDelete\").click(function(){\r\n";

        htmlResponse += "       $.post(encodeURI(\"" + urlPost + "\"), { \"do\": \"capnhatthongtin\", \"itemId\": \"" + arrRowId + "\", \"NgayNopLuu\": $('#NgayNopLuu').val(), \"MoTa\": $('#MoTa').val(), \"NguoiGiao\": $('#NguoiGiao').val(), \"NguoiNhan\": $('#NguoiNhan').val()}, function (data) {\r\n";

        htmlResponse += "       $('#btnComfirmClose').click();\r\n";
        htmlResponse += "           if (data.Error) {\r\n";
        htmlResponse += "               createMessage(\"Có lỗi xảy ra\", data.Title);\r\n";
        htmlResponse += "           }\r\n";
        htmlResponse += "           else {\r\n";
        htmlResponse += "               createCloseMessage(\"Thông báo\", data.Title, '" + urlNewFW + "');\r\n";
        htmlResponse += "           }\r\n";
        htmlResponse += "       });\r\n";
        htmlResponse += "   });\r\n";
        htmlResponse += "});";
        htmlResponse += "</script>\r\n";
        htmlResponse += "<div class=\"modal-header\">";
        htmlResponse += "	<button type=\"button\" class=\"close\" data-dismiss=\"modal\" aria-hidden=\"true\"></button>";
        htmlResponse += "	<h4 class=\"modal-title\">Cập nhật thông tin nộp hồ sơ</h4>";
        htmlResponse += "</div>";
        htmlResponse += "<div class=\"modal-body\">";
        htmlResponse += "   <div class=\"form-horizontal\">";
        htmlResponse += "       <div class=\"row\">";
        htmlResponse += "           <div class=\"col-md-12 col-sm-12\">";
        htmlResponse += "               <div class=\"form-group\">";
        htmlResponse += "                   <label class=\"col-sm-3 col-md-3 control-label\">";
        htmlResponse += "                   Người giao<span class=\"required\" aria-required=\"true\">*</span>";
        htmlResponse += "                   </label>";
        htmlResponse += "                   <div class=\"col-sm-9 col-md-9\">";
        htmlResponse += "                       <input class=\"form-control\" name=\"NguoiGiao\" id=\"NguoiGiao\" placeholder=\"Chọn người giao\" />";
        htmlResponse += "                   </div>";
        htmlResponse += "               </div>";
        htmlResponse += "           </div>";
        htmlResponse += "           <div class=\"col-md-12 col-sm-12\">";
        htmlResponse += "               <div class=\"form-group\">";
        htmlResponse += "                   <label class=\"col-sm-3 col-md-3 control-label\">";
        htmlResponse += "                   Người nhận<span class=\"required\" aria-required=\"true\">*</span>";
        htmlResponse += "                   </label>";
        htmlResponse += "                   <div class=\"col-sm-9 col-md-9\">";
        htmlResponse += "                       <input class=\"form-control\" name=\"NguoiNhan\" id=\"NguoiNhan\" placeholder=\"Chọn người nhận\" />";
        htmlResponse += "                   </div>";
        htmlResponse += "               </div>";
        htmlResponse += "           </div>";
        htmlResponse += "           <div class=\"col-md-12 col-sm-12\">";
        htmlResponse += "               <div class=\"form-group\">";
        htmlResponse += "                   <label class=\"col-sm-3 col-md-3 control-label\">";
        htmlResponse += "                   Ngày nộp lưu<span class=\"required\" aria-required=\"true\">*</span>";
        htmlResponse += "                   </label>";
        htmlResponse += "                   <div class=\"col-sm-9 col-md-9\">";
        htmlResponse += "                       <div class=\"input-group date date-picker\" data-date-format=\"dd-mm-yyyy\">";
        htmlResponse += "                           <input class=\"form-control\" name=\"NgayNopLuu\" id=\"NgayNopLuu\" placeholder=\"Chọn ngày nộp lưu\" />";
        htmlResponse += "                           <span class=\"input-group-btn\">";
        htmlResponse += "                               <button class=\"btn default btn-date\" type=\"button\"><i class=\"fa fa-calendar\"></i></button>";
        htmlResponse += "                           </span>";
        htmlResponse += "                       </div>";
        htmlResponse += "                   </div>";
        htmlResponse += "               </div>";
        htmlResponse += "           </div>";
        htmlResponse += "           <div class=\"col-md-12 col-sm-12\">";
        htmlResponse += "               <div class=\"form-group\">";
        htmlResponse += "                   <label class=\"col-sm-3 col-md-3 control-label\">";
        htmlResponse += "                   Mô tả";
        htmlResponse += "                   </label>";
        htmlResponse += "                   <div class=\"col-sm-9 col-md-9\">";
        htmlResponse += "                       <textarea class=\"form-control\" name=\"MoTa\" id=\"MoTa\" placeholder=\"Nhập mô tả\" rows=\"3\"></textarea>";
        htmlResponse += "                   </div>";
        htmlResponse += "           </div>";
        htmlResponse += "       </div>";
        htmlResponse += "   </div>";
        htmlResponse += "</div>";

        htmlResponse += "<div class=\"modal-footer\">";
        htmlResponse += "	<button type=\"submit\" id=\"btnComfirmDelete\" class=\"btn brown\" tabindex=\"5\"><i class=\"icon-save\"></i> Đồng ý</button>";
        htmlResponse += "	<button type=\"button\" id=\"btnComfirmClose\" class=\"btn red\" data-dismiss=\"modal\" tabindex=\"8\"><i class=\"fa fa-close\"></i> Đóng lại</button>";
        htmlResponse += "</div>";

        $('#dialog-confirm').html(htmlResponse);
        $('#dialog-confirm').modal({ width: 650 });
    }
}

function rowDongKho(urlPost, arrRowId, rowTitle, urlFw) {

    if (arrRowId == '')
        createMessageDelete("Thông báo", "<div class=\"alert\"><strong>Chú ý!</strong> Bạn chưa chọn bản ghi nào!</div>");
    else {
        var htmlResponse = "";
        var urlNewFW = urlFw + '&do=hide&ItemID=' + arrRowId + '&temp=' + Math.floor(Math.random() * 11);
        htmlResponse += "<script type=\"text/javascript\">\r\n";
        htmlResponse += "$(document).ready(function(){\r\n";
        htmlResponse += "   unbindHotkey();\r\n";
        htmlResponse += "   $(\"#btnComfirmHide\").click(function(){\r\n";
        htmlResponse += "       $.post(encodeURI(\"" + urlPost + "\"), { \"do\": \"dongkho\", \"itemId\": \"" + arrRowId + "\" }, function (data) {\r\n";
        htmlResponse += "       $('#btnComfirmClose').click();\r\n";
        htmlResponse += "           if (data.Error) {\r\n";
        htmlResponse += "               createMessage(\"Có lỗi xảy ra\", data.Title);\r\n";
        htmlResponse += "           }\r\n";
        htmlResponse += "           else {\r\n";
        htmlResponse += "               createCloseMessage(\"Thông báo\", data.Title, '" + urlNewFW + "');\r\n";
        htmlResponse += "           }\r\n";
        htmlResponse += "       });\r\n";
        htmlResponse += "   });\r\n";
        htmlResponse += "   $(document).bind('keypress', 'a', function (evt) {\r\n"; //Sự kiện bấm phím a
        htmlResponse += "       $('#btnComfirmHide').click();\r\n";
        htmlResponse += "   });\r\n";
        htmlResponse += "   $(document).bind('keypress', 'return', function (evt) {\r\n"; //Sự kiện bấm phím enter
        htmlResponse += "       $('#btnComfirmHide').click();\r\n";
        htmlResponse += "   });\r\n";
        htmlResponse += "   $(document).bind('keypress', 'd', function (evt) {\r\n"; // Sự kiện bấm phím d
        htmlResponse += "       $('#btnComfirmClose').click();\r\n";
        htmlResponse += "   });\r\n";
        htmlResponse += "   $('#dialog-confirm').on('hidden', function () {\r\n";
        htmlResponse += "      bindHotkey();\r\n";
        htmlResponse += "   })\r\n";
        htmlResponse += "});";
        htmlResponse += "</script>\r\n";

        htmlResponse += "<div class=\"modal-header\">";
        htmlResponse += "	<button type=\"button\" class=\"close\" data-dismiss=\"modal\" aria-hidden=\"true\"></button>";
        htmlResponse += "	<h4 class=\"modal-title\">Đóng kho</h4>";
        htmlResponse += "</div>";
        htmlResponse += "<div class=\"modal-body\">";
        htmlResponse += "    <div class=\"alert\">";
        htmlResponse += "		<strong>Chú ý!</strong> Bạn có chắc chắn muốn đóng kho!";
        htmlResponse += "	</div>";
        htmlResponse += "<ul>";
        htmlResponse += rowTitle;
        htmlResponse += "</ul>";
        htmlResponse += "</div>";
        htmlResponse += "<div class=\"modal-footer\">";
        htmlResponse += "	<button type=\"submit\" id=\"btnComfirmHide\" class=\"btn brown\" tabindex=\"5\"><i class=\"far fa-eye-slash\"></i> Đóng</button>";
        htmlResponse += "	<button type=\"button\" id=\"btnComfirmClose\" class=\"btn red\" data-dismiss=\"modal\" tabindex=\"8\" onclick=\"resetchecbox()\"><i class=\"fa fa-close\"></i> Hủy</button>";
        htmlResponse += "</div>";

        $('#dialog-confirm').html(htmlResponse);
        $('#dialog-confirm').modal({ width: 650 });
    }

}

function rowMoKho(urlPost, arrRowId, rowTitle, urlFw) {

    if (arrRowId == '')
        createMessageDelete("Thông báo", "<div class=\"alert\"><strong>Chú ý!</strong> Bạn chưa chọn bản ghi nào!</div>");
    else {
        var htmlResponse = "";
        var urlNewFW = urlFw + '&do=hide&ItemID=' + arrRowId + '&temp=' + Math.floor(Math.random() * 11);
        htmlResponse += "<script type=\"text/javascript\">\r\n";
        htmlResponse += "$(document).ready(function(){\r\n";
        htmlResponse += "   unbindHotkey();\r\n";
        htmlResponse += "   $(\"#btnComfirmHide\").click(function(){\r\n";
        htmlResponse += "       $.post(encodeURI(\"" + urlPost + "\"), { \"do\": \"mokho\", \"itemId\": \"" + arrRowId + "\" }, function (data) {\r\n";
        htmlResponse += "       $('#btnComfirmClose').click();\r\n";
        htmlResponse += "           if (data.Error) {\r\n";
        htmlResponse += "               createMessage(\"Có lỗi xảy ra\", data.Title);\r\n";
        htmlResponse += "           }\r\n";
        htmlResponse += "           else {\r\n";
        htmlResponse += "               createCloseMessage(\"Thông báo\", data.Title, '" + urlNewFW + "');\r\n";
        htmlResponse += "           }\r\n";
        htmlResponse += "       });\r\n";
        htmlResponse += "   });\r\n";
        htmlResponse += "   $(document).bind('keypress', 'a', function (evt) {\r\n"; //Sự kiện bấm phím a
        htmlResponse += "       $('#btnComfirmHide').click();\r\n";
        htmlResponse += "   });\r\n";
        htmlResponse += "   $(document).bind('keypress', 'return', function (evt) {\r\n"; //Sự kiện bấm phím enter
        htmlResponse += "       $('#btnComfirmHide').click();\r\n";
        htmlResponse += "   });\r\n";
        htmlResponse += "   $(document).bind('keypress', 'd', function (evt) {\r\n"; // Sự kiện bấm phím d
        htmlResponse += "       $('#btnComfirmClose').click();\r\n";
        htmlResponse += "   });\r\n";
        htmlResponse += "   $('#dialog-confirm').on('hidden', function () {\r\n";
        htmlResponse += "      bindHotkey();\r\n";
        htmlResponse += "   })\r\n";
        htmlResponse += "});";
        htmlResponse += "</script>\r\n";

        htmlResponse += "<div class=\"modal-header\">";
        htmlResponse += "	<button type=\"button\" class=\"close\" data-dismiss=\"modal\" aria-hidden=\"true\"></button>";
        htmlResponse += "	<h4 class=\"modal-title\">Mở kho</h4>";
        htmlResponse += "</div>";
        htmlResponse += "<div class=\"modal-body\">";
        htmlResponse += "    <div class=\"alert\">";
        htmlResponse += "		<strong>Chú ý!</strong> Bạn có chắc chắn muốn mở kho!";
        htmlResponse += "	</div>";
        htmlResponse += "<ul>";
        htmlResponse += rowTitle;
        htmlResponse += "</ul>";
        htmlResponse += "</div>";
        htmlResponse += "<div class=\"modal-footer\">";
        htmlResponse += "	<button type=\"submit\" id=\"btnComfirmHide\" class=\"btn brown\" tabindex=\"5\"><i class=\"far fa-eye-slash\"></i> Mở</button>";
        htmlResponse += "	<button type=\"button\" id=\"btnComfirmClose\" class=\"btn red\" data-dismiss=\"modal\" tabindex=\"8\" onclick=\"resetchecbox()\"><i class=\"fa fa-close\"></i> Đóng</button>";
        htmlResponse += "</div>";

        $('#dialog-confirm').html(htmlResponse);
        $('#dialog-confirm').modal({ width: 650 });
    }

}

function rowDongKyKiemKe(urlPost, arrRowId, rowTitle, urlFw) {

    if (arrRowId == '')
        createMessageDelete("Thông báo", "<div class=\"alert\"><strong>Chú ý!</strong> Bạn chưa chọn bản ghi nào!</div>");
    else {
        var htmlResponse = "";
        var urlNewFW = urlFw + '&do=hide&ItemID=' + arrRowId + '&temp=' + Math.floor(Math.random() * 11);
        htmlResponse += "<script type=\"text/javascript\">\r\n";
        htmlResponse += "$(document).ready(function(){\r\n";
        htmlResponse += "   unbindHotkey();\r\n";
        htmlResponse += "   $(\"#btnComfirmHide\").click(function(){\r\n";
        htmlResponse += "       $.post(encodeURI(\"" + urlPost + "\"), { \"do\": \"khoakykiemke\", \"itemId\": \"" + arrRowId + "\" }, function (data) {\r\n";
        htmlResponse += "       $('#btnComfirmClose').click();\r\n";
        htmlResponse += "           if (data.Error) {\r\n";
        htmlResponse += "               createMessage(\"Có lỗi xảy ra\", data.Title);\r\n";
        htmlResponse += "           }\r\n";
        htmlResponse += "           else {\r\n";
        htmlResponse += "               createCloseMessage(\"Thông báo\", data.Title, '" + urlNewFW + "');\r\n";
        htmlResponse += "           }\r\n";
        htmlResponse += "       });\r\n";
        htmlResponse += "   });\r\n";
        htmlResponse += "   $(document).bind('keypress', 'a', function (evt) {\r\n"; //Sự kiện bấm phím a
        htmlResponse += "       $('#btnComfirmHide').click();\r\n";
        htmlResponse += "   });\r\n";
        htmlResponse += "   $(document).bind('keypress', 'return', function (evt) {\r\n"; //Sự kiện bấm phím enter
        htmlResponse += "       $('#btnComfirmHide').click();\r\n";
        htmlResponse += "   });\r\n";
        htmlResponse += "   $(document).bind('keypress', 'd', function (evt) {\r\n"; // Sự kiện bấm phím d
        htmlResponse += "       $('#btnComfirmClose').click();\r\n";
        htmlResponse += "   });\r\n";
        htmlResponse += "   $('#dialog-confirm').on('hidden', function () {\r\n";
        htmlResponse += "      bindHotkey();\r\n";
        htmlResponse += "   })\r\n";
        htmlResponse += "});";
        htmlResponse += "</script>\r\n";

        htmlResponse += "<div class=\"modal-header\">";
        htmlResponse += "	<button type=\"button\" class=\"close\" data-dismiss=\"modal\" aria-hidden=\"true\"></button>";
        htmlResponse += "	<h4 class=\"modal-title\">Đóng kho</h4>";
        htmlResponse += "</div>";
        htmlResponse += "<div class=\"modal-body\">";
        htmlResponse += "    <div class=\"alert\">";
        htmlResponse += "		<strong>Chú ý!</strong> Bạn có chắc chắn muốn khóa kỳ kiểm kê!";
        htmlResponse += "	</div>";
        htmlResponse += "<ul>";
        htmlResponse += rowTitle;
        htmlResponse += "</ul>";
        htmlResponse += "</div>";
        htmlResponse += "<div class=\"modal-footer\">";
        htmlResponse += "	<button type=\"submit\" id=\"btnComfirmHide\" class=\"btn brown\" tabindex=\"5\"><i class=\"far fa-eye-slash\"></i> Khóa</button>";
        htmlResponse += "	<button type=\"button\" id=\"btnComfirmClose\" class=\"btn red\" data-dismiss=\"modal\" tabindex=\"8\" onclick=\"resetchecbox()\"><i class=\"fa fa-close\"></i> Hủy</button>";
        htmlResponse += "</div>";

        $('#dialog-confirm').html(htmlResponse);
        $('#dialog-confirm').modal({ width: 650 });
    }

}

function rowMoKyKiemKe(urlPost, arrRowId, rowTitle, urlFw) {

    if (arrRowId == '')
        createMessageDelete("Thông báo", "<div class=\"alert\"><strong>Chú ý!</strong> Bạn chưa chọn bản ghi nào!</div>");
    else {
        var htmlResponse = "";
        var urlNewFW = urlFw + '&do=hide&ItemID=' + arrRowId + '&temp=' + Math.floor(Math.random() * 11);
        htmlResponse += "<script type=\"text/javascript\">\r\n";
        htmlResponse += "$(document).ready(function(){\r\n";
        htmlResponse += "   unbindHotkey();\r\n";
        htmlResponse += "   $(\"#btnComfirmHide\").click(function(){\r\n";
        htmlResponse += "       $.post(encodeURI(\"" + urlPost + "\"), { \"do\": \"mokykiemke\", \"itemId\": \"" + arrRowId + "\" }, function (data) {\r\n";
        htmlResponse += "       $('#btnComfirmClose').click();\r\n";
        htmlResponse += "           if (data.Error) {\r\n";
        htmlResponse += "               createMessage(\"Có lỗi xảy ra\", data.Title);\r\n";
        htmlResponse += "           }\r\n";
        htmlResponse += "           else {\r\n";
        htmlResponse += "               createCloseMessage(\"Thông báo\", data.Title, '" + urlNewFW + "');\r\n";
        htmlResponse += "           }\r\n";
        htmlResponse += "       });\r\n";
        htmlResponse += "   });\r\n";
        htmlResponse += "   $(document).bind('keypress', 'a', function (evt) {\r\n"; //Sự kiện bấm phím a
        htmlResponse += "       $('#btnComfirmHide').click();\r\n";
        htmlResponse += "   });\r\n";
        htmlResponse += "   $(document).bind('keypress', 'return', function (evt) {\r\n"; //Sự kiện bấm phím enter
        htmlResponse += "       $('#btnComfirmHide').click();\r\n";
        htmlResponse += "   });\r\n";
        htmlResponse += "   $(document).bind('keypress', 'd', function (evt) {\r\n"; // Sự kiện bấm phím d
        htmlResponse += "       $('#btnComfirmClose').click();\r\n";
        htmlResponse += "   });\r\n";
        htmlResponse += "   $('#dialog-confirm').on('hidden', function () {\r\n";
        htmlResponse += "      bindHotkey();\r\n";
        htmlResponse += "   })\r\n";
        htmlResponse += "});";
        htmlResponse += "</script>\r\n";

        htmlResponse += "<div class=\"modal-header\">";
        htmlResponse += "	<button type=\"button\" class=\"close\" data-dismiss=\"modal\" aria-hidden=\"true\"></button>";
        htmlResponse += "	<h4 class=\"modal-title\">Mở kho</h4>";
        htmlResponse += "</div>";
        htmlResponse += "<div class=\"modal-body\">";
        htmlResponse += "    <div class=\"alert\">";
        htmlResponse += "		<strong>Chú ý!</strong> Bạn có chắc chắn muốn mở kỳ kiểm kê!";
        htmlResponse += "	</div>";
        htmlResponse += "<ul>";
        htmlResponse += rowTitle;
        htmlResponse += "</ul>";
        htmlResponse += "</div>";
        htmlResponse += "<div class=\"modal-footer\">";
        htmlResponse += "	<button type=\"submit\" id=\"btnComfirmHide\" class=\"btn brown\" tabindex=\"5\"><i class=\"far fa-eye-slash\"></i> Mở</button>";
        htmlResponse += "	<button type=\"button\" id=\"btnComfirmClose\" class=\"btn red\" data-dismiss=\"modal\" tabindex=\"8\" onclick=\"resetchecbox()\"><i class=\"fa fa-close\"></i> Đóng</button>";
        htmlResponse += "</div>";

        $('#dialog-confirm').html(htmlResponse);
        $('#dialog-confirm').modal({ width: 650 });
    }

}

function rowDuyetYeuCauKhaiThac(urlPost, arrRowId, rowTitle, urlFw) {
    if (arrRowId == '')
        createMessage("Thông báo", "<div class=\"alert\"><strong>Chú ý.!</strong> Bạn chưa chọn bản ghi nào.");
    else {
        var htmlResponse = "";
        var urlNewFW = urlFw + '&do=hide&ItemID=' + arrRowId + '&temp=' + Math.floor(Math.random() * 11);
        htmlResponse += "<script type=\"text/javascript\">\r\n";
        htmlResponse += "$(document).ready(function(){\r\n";
        htmlResponse += "   createUploader();";
        htmlResponse += "   unbindHotkey();$('#TrangThaiID').select2();\r\n";
        //Đăng ký sự kiện khi click vào nút delete

        htmlResponse += "   $(\"#btnComfirmDelete\").click(function(){\r\n";

        htmlResponse += "       $.post(encodeURI(\"" + urlPost + "\"), { \"do\": \"approved\", \"itemId\": \"" + arrRowId + "\", \"LyDo\": $('#LyDo').val(), \"listValueFileAttach\": $('#listValueFileAttach').val(), \"listValueFileAttachRemove\": $('#listValueFileAttachRemove').val()}, function (data) {\r\n";

        htmlResponse += "       $('#btnComfirmClose').click();\r\n";
        htmlResponse += "           if (data.Error) {\r\n";
        htmlResponse += "               createMessage(\"Có lỗi xảy ra\", data.Title);\r\n";
        htmlResponse += "           }\r\n";
        htmlResponse += "           else {\r\n";
        htmlResponse += "               createCloseMessage(\"Thông báo\", data.Title, '" + urlNewFW + "');\r\n";
        htmlResponse += "           }\r\n";
        htmlResponse += "       });\r\n";
        htmlResponse += "   });\r\n";
        htmlResponse += "});";
        htmlResponse += "</script>\r\n";
        htmlResponse += "<div class=\"modal-header\">";
        htmlResponse += "	<button type=\"button\" class=\"close\" data-dismiss=\"modal\" aria-hidden=\"true\"></button>";
        htmlResponse += "	<h4 class=\"modal-title\">Duyệt yêu cầu mượn tài liệu</h4>";
        htmlResponse += "</div>";
        htmlResponse += "<div class=\"modal-body\">";
        htmlResponse += "<input type=\"hidden\" id=\"listValueFileAttach\" name=\"listValueFileAttach\" />";
        htmlResponse += "<input type=\"hidden\" id=\"listValueFileAttachRemove\" name=\"listValueFileAttachRemove\" />";
        htmlResponse += "   <div class=\"form-horizontal\">";
        htmlResponse += "    <div class=\"alert\">";
        htmlResponse += "		<strong>Chú ý!</strong> Bạn có chắc chắn muốn duyệt!";
        htmlResponse += "	</div>";
        htmlResponse += "<ul style=\"margin-left:137px;\">";
        htmlResponse += "<li style=\"list-style-type:circle\">";
        htmlResponse += rowTitle;
        htmlResponse += "</li>";
        htmlResponse += "</ul>";
        htmlResponse += "       <div class=\"row\">";
        htmlResponse += "           <div class=\"col-md-12 col-sm-12\">";
        htmlResponse += "               <div class=\"form-group\">";
        htmlResponse += "                   <label class=\"col-sm-3 col-md-3 control-label\">";
        htmlResponse += "                   Lý do<span class=\"required\" aria-required=\"true\">*</span>";
        htmlResponse += "                   </label>";
        htmlResponse += "                   <div class=\"col-sm-9 col-md-9\">";
        htmlResponse += "                       <textarea class=\"form-control\" name=\"LyDo\" id=\"LyDo\" placeholder=\"Nhập lý do của trạng thái\" rows=\"3\"></textarea>";
        htmlResponse += "                   </div>";
        htmlResponse += "           </div>";
        htmlResponse += "           <div class=\"col-md-12 col-sm-12\" style=\"margin-left:-8px;\">";
        htmlResponse += "               <div class=\"form-group\">";
        htmlResponse += "                   <label class=\"col-sm-3 col-md-3 control-label\">";
        htmlResponse += "                   File đính kèm";
        htmlResponse += "                   </label>";
        htmlResponse += "                   <div class=\"col-sm-9 col-md-9\">";
        htmlResponse += "                       <div class=\"fileAttach\" style=\"float: left;\">";
        htmlResponse += "                           <div id=\"btnChosse\">";
        htmlResponse += "                                Chọn file đính kèm";
        htmlResponse += "                           </div>";
        htmlResponse += "                           <ul id=\"listFileAttach\">";
        htmlResponse += "                           </ul>";
        htmlResponse += "                       </div>";
        htmlResponse += "                   </div>";
        htmlResponse += "               </div>";
        htmlResponse += "           </div>";
        htmlResponse += "       </div>";
        htmlResponse += "   </div>";
        htmlResponse += "</div>";

        htmlResponse += "<div class=\"modal-footer\">";
        htmlResponse += "	<button type=\"submit\" id=\"btnComfirmDelete\" class=\"btn brown\" tabindex=\"5\"><i class=\"icon-save\"></i> Đồng ý</button>";
        htmlResponse += "	<button type=\"button\" id=\"btnComfirmClose\" class=\"btn red\" data-dismiss=\"modal\" tabindex=\"8\"><i class=\"fa fa-close\"></i> Đóng lại</button>";
        htmlResponse += "</div>";

        $('#dialog-confirm').html(htmlResponse);
        $('#dialog-confirm').modal({ width: 650 });
    }
}

function loadTrangThai() {
    var html = "";
    $.ajax({
        type: "POST",
        async: false,
        url: '/API/pLoadTrangThai.ashx',
        data: {},
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            html += "<select id='TrangThaiID' class='form-control chosen select2' >";
            //html += "    <option value='' >Chọn trạng thái</option>";
            $.each(data, function (key, val) {
                html += "    <option value='" + val.ID + "' >" + val.Ten + "</option>";
            });
            html += "</select>";
        }
    });

    return html;
}

function escapeHTML(str) {
    var div = document.createElement('div');
    var text = document.createTextNode(str);
    div.appendChild(text);
    return div.innerHTML;
}


function trim12(str) {
    var str = str.replace(/^\s\s*/, ''),
		ws = /\s/,
		i = str.length;
    while (ws.test(str.charAt(--i)));
    return str.slice(0, i + 1);
}


function alertdelete(method) {
    var htmlResponse = "";
    htmlResponse += "<script>";
    htmlResponse += "$(document).ready(function () {";
    htmlResponse += "$('#btnComfirmDelete').click(function () {";
    htmlResponse += " $('#dialog-confirm').modal('hide');"
    htmlResponse += method + "();";
    htmlResponse += "$('#btnMessageClose').click();";
    htmlResponse += "});";
    htmlResponse += "});";
    htmlResponse += "</script>";

    htmlResponse += "<div class=\"modal-header\">";
    htmlResponse += "	<button type=\"button\" class=\"close\" data-dismiss=\"modal\" aria-hidden=\"true\"></button>";
    htmlResponse += "	<h4 class=\"modal-title\"> Thông báo</h4>";
    htmlResponse += "</div>";
    htmlResponse += "<div class=\"modal-body\">";
    htmlResponse += "<b>Lưu ý: </b>";
    htmlResponse += "Bạn chỉ có thể nhập dữ liệu ở 1 tab. ";
    htmlResponse += "Bạn có muốn xóa dữ liệu tab vừa nhập?";
    htmlResponse += "</div>";
    htmlResponse += "<div class=\"modal-footer\">";
    htmlResponse += "	<button type=\"submit\" id=\"btnComfirmDelete\" class=\"btn brown\" tabindex=\"5\"><i class=\"icon-trash\"></i> Có</button>";
    htmlResponse += "	<button type=\"button\" id=\"btnMessageClose\" class=\"btn red\" data-dismiss=\"modal\" tabindex=\"8\"><i class=\"fa fa-close\"></i> Không</button>";
    htmlResponse += "</div>";

    $('#dialog-message').html(htmlResponse);
    $('#dialog-message').modal({ width: 600 });
}
function createCloseMessage(title, message, urlFw) {
    var add = $.address.value();
    if (add.indexOf("/") > -1) add = add.replace("/", "");
    var urlNewFW = '#' + add + '&temp=' + Math.floor(Math.random() * 11);
    var htmlResponse = "";
    htmlResponse += "<script type=\"text/javascript\">\r\n"; //Đăng ký sự kiện bấm phím D để đóng form
    htmlResponse += "$(document).ready(function () {\r\n";
    htmlResponse += "setTimeout(function () { \r\n";
    htmlResponse += "   unbindHotkey();\r\n";
    htmlResponse += "   $(document).bind('keypress', 'd', function (evt) {\r\n";
    htmlResponse += "       $('#btnMessageClose').click();\r\n";
    htmlResponse += "   });\r\n";
    htmlResponse += "   $(document).bind('keypress', 'return', function (evt) {\r\n";
    htmlResponse += "       $('#btnMessageClose').click();\r\n";
    htmlResponse += "   });\r\n";
    htmlResponse += "   $('#dialog-message').on('hide.bs.modal', function () {\r\n";
    htmlResponse += "      bindHotkey();\r\n";
    htmlResponse += "      window.location.href = '" + urlNewFW + "';\r\n";
    htmlResponse += "   });\r\n";
    htmlResponse += "}, 500);\r\n";
    htmlResponse += "});\r\n";
    htmlResponse += "</script>\r\n";
    htmlResponse += "<div class=\"modal-header\">";
    htmlResponse += "	<button type=\"button\" class=\"close\" data-dismiss=\"modal\" aria-hidden=\"true\"></button>";
    htmlResponse += "	<h4 class=\"modal-title\">" + title + "</h4>";
    htmlResponse += "</div>";
    htmlResponse += "<div class=\"modal-body\">";
    htmlResponse += message;
    htmlResponse += "</div>";
    htmlResponse += "<div class=\"modal-footer\">";
    htmlResponse += "	<button type=\"button\" id=\"btnMessageClose\" class=\"btn red\" data-dismiss=\"modal\" tabindex=\"8\"><i class=\"fa fa-close\"></i> <b>Đ</b>óng lại</button>";
    htmlResponse += "</div>";
    $('#dialog-message').html(htmlResponse);
    $('#dialog-message').modal({ width: 600 });

}
function createOptionMessage(title, message,urlList, urlFw) {
    var urlNewFW = urlFw;
    var htmlResponse = "";
    htmlResponse += "<script type=\"text/javascript\">\r\n"; //Đăng ký sự kiện bấm phím D để đóng form
    htmlResponse += "$(document).ready(function () {\r\n";
    htmlResponse += "setTimeout(function () { \r\n";
    htmlResponse += "   unbindHotkey();\r\n";
    htmlResponse += "   $(document).bind('keypress', 'd', function (evt) {\r\n";
    htmlResponse += "       $('#btnMessageClose').click();\r\n";
    htmlResponse += "   });\r\n";
    htmlResponse += "   $(document).bind('keypress', 'return', function (evt) {\r\n";
    htmlResponse += "       $('#btnMessageClose').click();\r\n";
    htmlResponse += "   });\r\n";
    htmlResponse += "   $('#dialog-message').on('hide.bs.modal', function () {\r\n";
    htmlResponse += "      bindHotkey();\r\n";
    htmlResponse += "      window.location.href = '" + urlNewFW + "';\r\n";
    htmlResponse += "   });\r\n";
    htmlResponse += "   $('#btnList').click(function () {\r\n";
    htmlResponse += "      window.location.href = '" + urlList + "';\r\n";
    htmlResponse += "   });\r\n";
    htmlResponse += "}, 500);\r\n";
    htmlResponse += "});\r\n";
    htmlResponse += "</script>\r\n";
    htmlResponse += "<div class=\"modal-header\">";
    htmlResponse += "	<button type=\"button\" class=\"close\" data-dismiss=\"modal\" aria-hidden=\"true\"></button>";
    htmlResponse += "	<h4 class=\"modal-title\">" + title + "</h4>";
    htmlResponse += "</div>";
    htmlResponse += "<div class=\"modal-body\">";
    htmlResponse += message;
    htmlResponse += "</div>";
    htmlResponse += "<div class=\"modal-footer\">";
    htmlResponse += "	<a id=\"btnList\" class=\"btn brown\">Danh sách</a> <button type=\"button\" id=\"btnMessageClose\" class=\"btn red\" data-dismiss=\"modal\" tabindex=\"8\"><i class=\"fa fa-close\"></i><b>C</b>hi tiết</button>";
    htmlResponse += "</div>";
    $('#dialog-message').html(htmlResponse);
    $('#dialog-message').modal({ width: 600 });
}
function createCloseMessage2(title, message, urlFw) {
    var urlNewFW = urlFw;
    var htmlResponse = "";
    htmlResponse += "<script type=\"text/javascript\">\r\n"; //Đăng ký sự kiện bấm phím D để đóng form
    htmlResponse += "$(document).ready(function () {\r\n";
    htmlResponse += "setTimeout(function () { \r\n";
    htmlResponse += "   unbindHotkey();\r\n";
    htmlResponse += "   $(document).bind('keypress', 'd', function (evt) {\r\n";
    htmlResponse += "       $('#btnMessageClose').click();\r\n";
    htmlResponse += "   });\r\n";
    htmlResponse += "   $(document).bind('keypress', 'return', function (evt) {\r\n";
    htmlResponse += "       $('#btnMessageClose').click();\r\n";
    htmlResponse += "   });\r\n";
    htmlResponse += "   $('#dialog-message').on('hide.bs.modal', function () {\r\n";
    htmlResponse += "      bindHotkey();\r\n";
    htmlResponse += "      window.location.href = '" + urlNewFW + "';\r\n";
    htmlResponse += "   });\r\n";
    htmlResponse += "}, 500);\r\n";
    htmlResponse += "});\r\n";
    htmlResponse += "</script>\r\n";
    htmlResponse += "<div class=\"modal-header\">";
    htmlResponse += "	<button type=\"button\" class=\"close\" data-dismiss=\"modal\" aria-hidden=\"true\"></button>";
    htmlResponse += "	<h4 class=\"modal-title\">" + title + "</h4>";
    htmlResponse += "</div>";
    htmlResponse += "<div class=\"modal-body\">";
    htmlResponse += message;
    htmlResponse += "</div>";
    htmlResponse += "<div class=\"modal-footer\">";
    htmlResponse += "	<button type=\"button\" id=\"btnMessageClose\" class=\"btn red\" data-dismiss=\"modal\" tabindex=\"8\"><i class=\"fa fa-close\"></i> <b>Đ</b>óng lại</button>";
    htmlResponse += "</div>";
    $('#dialog-message').html(htmlResponse);
    $('#dialog-message').modal({ width: 600 });
}
function createCloseMessage3(title, message, urlFw) {
    var add = $.address.value();
    if (add.indexOf("/") > -1) add = add.replace("/", "");
    var urlNewFW = '#' + add + '&temp=' + Math.floor(Math.random() * 11);
    var htmlResponse = "";
    htmlResponse += "<script type=\"text/javascript\">\r\n"; //Đăng ký sự kiện bấm phím D để đóng form
    htmlResponse += "$(document).ready(function () {\r\n";
    htmlResponse += "setTimeout(function () { \r\n";
    htmlResponse += "   unbindHotkey();\r\n";
    htmlResponse += "   $(document).bind('keypress', 'd', function (evt) {\r\n";
    htmlResponse += "       $('#btnMessageClose').click();\r\n";
    htmlResponse += "   });\r\n";
    htmlResponse += "   $(document).bind('keypress', 'return', function (evt) {\r\n";
    htmlResponse += "       $('#btnMessageClose').click();\r\n";
    htmlResponse += "   });\r\n";
    htmlResponse += "   $('#dialog-message').on('hide.bs.modal', function () {\r\n";
    htmlResponse += "      bindHotkey();\r\n";
    htmlResponse += "      window.location.href = '" + urlNewFW + "';\r\n";
    htmlResponse += "   });\r\n";
    htmlResponse += "}, 500);\r\n";
    htmlResponse += "});\r\n";
    htmlResponse += "</script>\r\n";
    htmlResponse += "<div class=\"modal-header\">";
    htmlResponse += "	<button type=\"button\" class=\"close\" data-dismiss=\"modal\" aria-hidden=\"true\"></button>";
    htmlResponse += "	<h4 class=\"modal-title\">" + title + "</h4>";
    htmlResponse += "</div>";
    htmlResponse += "<div class=\"modal-body\">";
    htmlResponse += message;
    htmlResponse += "</div>";
    htmlResponse += "<div class=\"modal-footer\">";
    htmlResponse += "	<button type=\"button\" id=\"btnMessageClose\" class=\"btn red\" data-dismiss=\"modal\" tabindex=\"8\"><i class=\"fa fa-close\"></i> <b>Đ</b>óng lại</button>";
    htmlResponse += "</div>";
    $('#dialog-message').html(htmlResponse);
    $('#dialog-message').modal({ width: 600 });

}
function createCloseMessage4(title, message,fgf) {
    var htmlResponse = "";
    htmlResponse += "<script type=\"text/javascript\">\r\n"; //Đăng ký sự kiện bấm phím D để đóng form
    htmlResponse += "$(document).ready(function () {\r\n";
    htmlResponse += "setTimeout(function () { \r\n";
    htmlResponse += "   unbindHotkey();\r\n";
    htmlResponse += "   $(document).bind('keypress', 'd', function (evt) {\r\n";
    htmlResponse += "       $('#btnMessageClose').click();\r\n";
    htmlResponse += "   });\r\n";
    htmlResponse += "   $(document).bind('keypress', 'return', function (evt) {\r\n";
    htmlResponse += "       $('#btnMessageClose').click();\r\n";
    htmlResponse += "   });\r\n";
    htmlResponse += "   $('#dialog-message').on('hide.bs.modal', function () {\r\n";
    htmlResponse += "      $(\"input:first\").focus();\r\n";
    htmlResponse += "      bindHotkey();\r\n";
    htmlResponse += "   });\r\n";
    htmlResponse += "   $('#btnMessageClose1').bind('click', function () {\r\n";
    htmlResponse += "      bindHotkey();\r\n";
    htmlResponse += "      window.location.href = '" + fgf + "';\r\n";
    htmlResponse += "   });\r\n";
    htmlResponse += "}, 500);\r\n";
    htmlResponse += "});\r\n";
    htmlResponse += "</script>\r\n";

    htmlResponse += "<div class=\"modal-header\">";
    htmlResponse += "	<button type=\"button\" class=\"close\" data-dismiss=\"modal\" aria-hidden=\"true\"></button>";
    htmlResponse += "	<h4 class=\"modal-title\">" + title + "</h4>";
    htmlResponse += "</div>";
    htmlResponse += "<div class=\"modal-body\">";
    htmlResponse += message;
    htmlResponse += "</div>";
    htmlResponse += "<div class=\"modal-footer\">";
    htmlResponse += "	<button type=\"button\" id=\"btnMessageClose\" class=\"btn red\" data-dismiss=\"modal\" tabindex=\"8\"><i class=\"fa fa-close\"></i> <b>C</b>ó</button>";
    htmlResponse += "	<button type=\"button\" id=\"btnMessageClose1\" class=\"btn red\" data-dismiss=\"modal1\" tabindex=\"8\"><i class=\"fa fa-close\"></i> <b>Không</button>";
    htmlResponse += "</div>";


    $('#dialog-message').html(htmlResponse);
    $('#dialog-message').modal({ width: 600 });
}
function createCloseMessageNoload(title, message, urlFw) {

    var urlNewFW = urlFw;
    var htmlResponse = "";
    htmlResponse += "<script type=\"text/javascript\">\r\n"; //Đăng ký sự kiện bấm phím D để đóng form
    htmlResponse += "$(document).ready(function () {\r\n";
    htmlResponse += "setTimeout(function () { \r\n";
    htmlResponse += "   unbindHotkey();\r\n";
    htmlResponse += "   $(document).bind('keypress', 'd', function (evt) {\r\n";
    htmlResponse += "       $('#btnMessageClose').click();\r\n";
    htmlResponse += "   });\r\n";
    htmlResponse += "   $(document).bind('keypress', 'return', function (evt) {\r\n";
    htmlResponse += "       $('#btnMessageClose').click();\r\n";
    htmlResponse += "   });\r\n";
    htmlResponse += "   $('#dialog-message').on('hide.bs.modal', function () {\r\n";
    htmlResponse += "      bindHotkey();\r\n";
    htmlResponse += "   });\r\n";
    htmlResponse += "}, 500);\r\n";
    htmlResponse += "});\r\n";
    htmlResponse += "</script>\r\n";
    htmlResponse += "<div class=\"modal-header\">";
    htmlResponse += "	<button type=\"button\" class=\"close\" data-dismiss=\"modal\" aria-hidden=\"true\"></button>";
    htmlResponse += "	<h4 class=\"modal-title\">" + title + "</h4>";
    htmlResponse += "</div>";
    htmlResponse += "<div class=\"modal-body\">";
    htmlResponse += message;
    htmlResponse += "</div>";
    htmlResponse += "<div class=\"modal-footer\">";
    htmlResponse += "	<button type=\"button\" id=\"btnMessageClose\" class=\"btn red\" data-dismiss=\"modal\" tabindex=\"8\"><i class=\"fa fa-close\"></i> <b>Đ</b>óng lại</button>";
    htmlResponse += "</div>";
    $('#dialog-message').html(htmlResponse);
    $('#dialog-message').modal({ width: 600 });
}
//bảng biểu thông báo
function createMessage(title, message) {
    var htmlResponse = "";
    htmlResponse += "<script type=\"text/javascript\">\r\n"; //Đăng ký sự kiện bấm phím D để đóng form
    htmlResponse += "$(document).ready(function () {\r\n";
    htmlResponse += "setTimeout(function () { \r\n";
    htmlResponse += "   unbindHotkey();\r\n";
    htmlResponse += "   $(document).bind('keypress', 'd', function (evt) {\r\n";
    htmlResponse += "       $('#btnMessageClose').click();\r\n";
    htmlResponse += "   });\r\n";
    htmlResponse += "   $(document).bind('keypress', 'return', function (evt) {\r\n";
    htmlResponse += "       $('#btnMessageClose').click();\r\n";
    htmlResponse += "   });\r\n";
    htmlResponse += "   $('#dialog-message').on('hide.bs.modal', function () {\r\n";
    htmlResponse += "      $(\"input:first\").focus();\r\n";
    htmlResponse += "      bindHotkey();\r\n";
    htmlResponse += "   });\r\n";
    htmlResponse += "}, 500);\r\n";
    htmlResponse += "});\r\n";
    htmlResponse += "</script>\r\n";

    htmlResponse += "<div class=\"modal-header\">";
    htmlResponse += "	<button type=\"button\" class=\"close\" data-dismiss=\"modal\" aria-hidden=\"true\"></button>";
    htmlResponse += "	<h4 class=\"modal-title\">" + title + "</h4>";
    htmlResponse += "</div>";
    htmlResponse += "<div class=\"modal-body\">";
    htmlResponse += message;
    htmlResponse += "</div>";
    htmlResponse += "<div class=\"modal-footer\">";
    htmlResponse += "	<button type=\"button\" id=\"btnMessageClose\" class=\"btn red\" data-dismiss=\"modal\" tabindex=\"8\"><i class=\"fa fa-close\"></i> <b>Đ</b>óng lại</button>";
    htmlResponse += "</div>";

    $('#dialog-message').html(htmlResponse);
    $('#dialog-message').modal({ width: 600 });
}
function BackLink(title, message) {
    var htmlResponse = "";
    htmlResponse += "<script type=\"text/javascript\">\r\n"; //Đăng ký sự kiện bấm phím D để đóng form
    htmlResponse += "$(document).ready(function () {\r\n";
    htmlResponse += "setTimeout(function () { \r\n";
    htmlResponse += "   unbindHotkey();\r\n";
    htmlResponse += "   $(document).bind('keypress', 'd', function (evt) {\r\n";
    htmlResponse += "       $('#btnMessageClose').click();\r\n";
    htmlResponse += "   });\r\n";
    htmlResponse += "   $(document).bind('keypress', 'return', function (evt) {\r\n";
    htmlResponse += "       $('#btnMessageClose').click();\r\n";
    htmlResponse += "   });\r\n";
    htmlResponse += "   $('#dialog-message').on('hide.bs.modal', function () {\r\n";
    htmlResponse += "      $(\"input:first\").focus();\r\n";
    htmlResponse += "      bindHotkey();\r\n";
    htmlResponse += "      window.history.back();\r\n";
    htmlResponse += "   });\r\n";
    htmlResponse += "}, 500);\r\n";
    htmlResponse += "});\r\n";
    htmlResponse += "</script>\r\n";

    htmlResponse += "<div class=\"modal-header\">";
    htmlResponse += "	<button type=\"button\" class=\"close\" data-dismiss=\"modal\" aria-hidden=\"true\"></button>";
    htmlResponse += "	<h4 class=\"modal-title\">" + title + "</h4>";
    htmlResponse += "</div>";
    htmlResponse += "<div class=\"modal-body\">";
    htmlResponse += message;
    htmlResponse += "</div>";
    htmlResponse += "<div class=\"modal-footer\">";
    htmlResponse += "	<button type=\"button\" id=\"btnMessageClose\" class=\"btn red\" data-dismiss=\"modal\" tabindex=\"8\"><i class=\"fa fa-close\"></i> <b>Đ</b>óng lại</button>";
    htmlResponse += "</div>";

    $('#dialog-message').html(htmlResponse);
    $('#dialog-message').modal({ width: 600 });
}
//bảng biểu thông báo
function ThongBao(title, message) {
    var htmlResponse = "";
    htmlResponse += "<script type=\"text/javascript\">\r\n"; //Đăng ký sự kiện bấm phím D để đóng form
    htmlResponse += "$(document).ready(function () {\r\n";
    htmlResponse += "setTimeout(function () { \r\n";
    htmlResponse += "   unbindHotkey();\r\n";
    htmlResponse += "   $(document).bind('keypress', 'd', function (evt) {\r\n";
    htmlResponse += "       $('#btnMessageClose').click();\r\n";
    htmlResponse += "   });\r\n";
    htmlResponse += "   $(document).bind('keypress', 'return', function (evt) {\r\n";
    htmlResponse += "       $('#btnMessageClose').click();\r\n";
    htmlResponse += "   });\r\n";
    htmlResponse += "   $('#dialog-message').on('hide.bs.modal', function () {\r\n";
    htmlResponse += "      $(\"input:first\").focus();\r\n";
    htmlResponse += "      bindHotkey();\r\n";
    htmlResponse += "   });\r\n";
    htmlResponse += "}, 500);\r\n";
    htmlResponse += "});\r\n";
    htmlResponse += "</script>\r\n";

    htmlResponse += "<div class=\"modal-header\">";
    htmlResponse += "	<button type=\"button\" class=\"close\" data-dismiss=\"modal\" aria-hidden=\"true\"></button>";
    htmlResponse += "	<h4 class=\"modal-title\">" + title + "</h4>";
    htmlResponse += "</div>";
    htmlResponse += "<div class=\"modal-body\">";
    htmlResponse += message;
    htmlResponse += "</div>";
    htmlResponse += "<div class=\"modal-footer\">";
    htmlResponse += "	<button type=\"button\" id=\"btnMessageClose\" class=\"btn red\" data-dismiss=\"modal\" tabindex=\"8\"><i class=\"fa fa-close\"></i> <b>Đ</b>óng lại</button>";
    htmlResponse += "</div>";

    $('#dialog-message').html(htmlResponse);
    $('#dialog-message').modal({ width: 600 });
}
//bảng biểu thông báo
function createMessageDelete(title, message) {
    var htmlResponse = "";
    htmlResponse += "<script type=\"text/javascript\">\r\n"; //Đăng ký sự kiện bấm phím D để đóng form
    htmlResponse += "$(document).ready(function () {\r\n";
    htmlResponse += "setTimeout(function () { \r\n";
    htmlResponse += "   unbindHotkey();\r\n";
    htmlResponse += "   $(document).bind('keypress', 'd', function (evt) {\r\n";
    htmlResponse += "       $('#btnMessageClose').click();\r\n";
    htmlResponse += "   });\r\n";
    htmlResponse += "   $(document).bind('keypress', 'return', function (evt) {\r\n";
    htmlResponse += "       $('#btnMessageClose').click();\r\n";
    htmlResponse += "   });\r\n";
    htmlResponse += "   $('#dialog-message').on('hide.bs.modal', function () {\r\n";
    htmlResponse += "      $(\"input:first\").focus();\r\n";
    htmlResponse += "      bindHotkey();\r\n";
    htmlResponse += "   });\r\n";
    htmlResponse += "}, 500);\r\n";
    htmlResponse += "});\r\n";
    htmlResponse += "</script>\r\n";

    htmlResponse += "<div class=\"modal-header\">";
    htmlResponse += "	<button type=\"button\" class=\"close\" data-dismiss=\"modal\" aria-hidden=\"true\"></button>";
    htmlResponse += "	<h4 class=\"modal-title\">" + title + "</h4>";
    htmlResponse += "</div>";
    htmlResponse += "<div class=\"modal-body\">";
    htmlResponse += message;
    htmlResponse += "</div>";
    htmlResponse += "<div class=\"modal-footer\">";
    htmlResponse += "	<button type=\"button\" id=\"btnMessageClose\" class=\"btn red\" data-dismiss=\"modal\" tabindex=\"8\"><i class=\"fa fa-close\"></i> <b>Đ</b>óng lại</button>";
    htmlResponse += "</div>";

    $('#dialog-message').html(htmlResponse);
    $('#dialog-message').modal({ width: 600 });
}


//Chuyển chuỗi kí tự (string) sang đối tượng Date()
function parseDate(str) {
    var mdy = str.split('/');
    return new Date(mdy[2], mdy[1], mdy[0]);
}

function DeleteFileUpdate(file) {
    var linkDelete = $("#listValueFileAttachRemove").val();
    if (isNaN(file / 1) == false) {
        $("#listValueFileAttachRemove").val(linkDelete + file + "#");
    }
    $("#listFileAttachRemove span[id='" + file + "']").parent().remove();
    $("#listFileAttach span[id='" + file + "']").parent().remove();
    $("#listValueFileAttach").val(changeHiddenInput());
}
function DeleteFileUpdateoption(file) {
    var linkDelete = $("#listValueFileAttachRemoveoption").val();
    if (isNaN(file / 1) == false) {
        $("#listValueFileAttachRemoveoption").val(linkDelete + file + "#");
    }
    $("#listFileAttachRemoveoption span[id='" + file + "']").parent().remove();
    $("#listFileAttachoption span[id='" + file + "']").parent().remove();
    $("#listValueFileAttachoption").val(changeHiddenInputoption());
}
function createUploaderoption() {
    var listFileAllow = [".jpg", ".jpeg", ".gif", ".bmp", ".png", ".JPG", ".JPEG", ".GIF", ".BMP", ".PNG",
                        //".tif",//".flv",//".mp3",//".mp4",//".avi",//".wmv",//".asx",//".wma",//".flac",
                        ".zip", ".rar", ".7z", ".doc", ".docx", ".xls", ".xlsx", ".xml", ".pdf",//".psd",
                         ".ZIP", ".RAR", ".7Z", ".DOC", ".DOCX", ".XLS", ".XLSX", ".XML", ".PDF",//".psd",
                         ".PPT", ".PPTX", ".TXT",
                        ".ppt", ".pptx", ".txt"];

    var uploader = new qq.FileUploader({
        element: document.getElementById('btnChosseoption'),
        action: '/UploadFile.aspx',
        sizeLimit: 31457280.000008244,
        debug: true,
        onSubmit: function (id, fileName) {
            if (listFileAllow.indexOf(fileName.substring(fileName.lastIndexOf('.'))) == -1) {
                createMessage("Thông báo", "File " + fileName + " không được phép tải lên.");
                return false;
            }
            // check trùng file
            var exits = false;
            //check trong trường hợp mới upload
            $("#listFileAttachoption li").each(function (index, item) {
                if (fileName == $(this).children("span").attr("title"))
                    exits = true;
            });
            //check trên file đã upload
            $("#listFileAttachRemoveoption li").each(function (index, item) {
                if (fileName == $(this).children("span").attr("title"))
                    exits = true;
            });
            if (exits) {
                createMessage("Thông báo", "File " + fileName + " đã tồn tại! Bạn hãy chọn file khác.");
                return false;
            }
        },
        onComplete: function (id, fileName, responseJSON) {
            if (responseJSON.upload) {
                $("#listFileAttachoption").append(getHTMLDeleteLinkoption(responseJSON));
                $("#listValueFileAttachoption").val(changeHiddenInputoption());
            } else {
                createMessage("Thông báo", responseJSON.message);
            }
        }
    });
}
function createUploaderoption1() {
    var listFileAllow = [".jpg", ".jpeg", ".gif", ".bmp", ".png", ".JPG", ".JPEG", ".GIF", ".BMP", ".PNG",
                        //".tif",//".flv",//".mp3",//".mp4",//".avi",//".wmv",//".asx",//".wma",//".flac",
                        ".zip", ".rar", ".7z", ".doc", ".docx", ".xls", ".xlsx", ".xml", ".pdf",//".psd",
                         ".ZIP", ".RAR", ".7Z", ".DOC", ".DOCX", ".XLS", ".XLSX", ".XML", ".PDF",//".psd",
                         ".PPT", ".PPTX", ".TXT",
                        ".ppt", ".pptx", ".txt"];

    var uploader = new qq.FileUploader({
        element: document.getElementById('btnChosseoption1'),
        action: '/UploadFile.aspx',
        sizeLimit: 31457280.000008244,
        debug: true,
        onSubmit: function (id, fileName) {
            if (listFileAllow.indexOf(fileName.substring(fileName.lastIndexOf('.'))) == -1) {
                createMessage("Thông báo", "File " + fileName + " không được phép tải lên.");
                return false;
            }
            // check trùng file
            var exits = false;
            //check trong trường hợp mới upload
            $("#listFileAttachoption1 li").each(function (index, item) {
                if (fileName == $(this).children("span").attr("title"))
                    exits = true;
            });
            //check trên file đã upload
            $("#listFileAttachRemoveoption1 li").each(function (index, item) {
                if (fileName == $(this).children("span").attr("title"))
                    exits = true;
            });
            if (exits) {
                createMessage("Thông báo", "File " + fileName + " đã tồn tại! Bạn hãy chọn file khác.");
                return false;
            }
        },
        onComplete: function (id, fileName, responseJSON) {
            if (responseJSON.upload) {
                $("#listFileAttachoption1").append(getHTMLDeleteLinkoption(responseJSON));
                $("#listValueFileAttachoption1").val(changeHiddenInputoption1());
            } else {
                createMessage("Thông báo", responseJSON.message);
            }
        }
    });
}
//Append li to ul checkbox
function createUploader() {
    var listFileAllow = [".jpg", ".jpeg", ".gif", ".bmp", ".png", ".JPG", ".JPEG", ".GIF", ".BMP", ".PNG",
                        //".tif",//".flv",//".mp3",//".mp4",//".avi",//".wmv",//".asx",//".wma",//".flac",
                        ".zip", ".rar", ".7z", ".doc", ".docx", ".xls", ".xlsx", ".xml", ".pdf",//".psd",
                         ".ZIP", ".RAR", ".7Z", ".DOC", ".DOCX", ".XLS", ".XLSX", ".XML", ".PDF",//".psd",
                         ".PPT", ".PPTX", ".TXT",
                        ".ppt", ".pptx", ".txt",".msg"];

    var uploader = new qq.FileUploader({
        element: document.getElementById('btnChosse'),
        action: '/UploadFile.aspx',
        sizeLimit: 81457280.000008244,
        debug: true,
        onSubmit: function (id, fileName) {
            if (listFileAllow.indexOf(fileName.substring(fileName.lastIndexOf('.'))) == -1) {
                createMessage("Thông báo", "File " + fileName + " không được phép tải lên.");
                return false;
            }
            // check trùng file
            var exits = false;
            //check trong trường hợp mới upload
            $("#listFileAttach li").each(function (index, item) {
                if (fileName == $(this).children("span").attr("title"))
                    exits = true;
            });
           
            //check trên file đã upload
            $("#listFileAttachRemove li").each(function (index, item) {
                if (fileName == $(this).children("span").attr("title"))
                    exits = true;
            });
            if (exits) {
                createMessage("Thông báo", "File " + fileName + " đã tồn tại! Bạn hãy chọn file khác.");
                return false;
            }
            var loadingSoHoa = $("#loadingSoHoa").length;
            if (loadingSoHoa > 0) {
                $("#loadingSoHoa").show();
            }
        },
        onComplete: function (id, fileName, responseJSON) {
            if (responseJSON.upload) {
                $("#listFileAttach").append(getHTMLDeleteLink(responseJSON));
                $("#listValueFileAttach").val(changeHiddenInput());
                if (responseJSON.BatchId != "0"&& responseJSON.BatchId !=null) {
                    FillVanbanSoHoa(responseJSON.BatchId);
                }
            } else {
                createMessage("Thông báo", responseJSON.message);
            }
        }
    });
}

function createUploaderSoHoa() {
    var listFileAllow = [".jpg", ".jpeg", ".gif", ".bmp", ".png", ".JPG", ".JPEG", ".GIF", ".BMP", ".PNG",
                        //".tif",//".flv",//".mp3",//".mp4",//".avi",//".wmv",//".asx",//".wma",//".flac",
                        ".zip", ".rar", ".7z", ".doc", ".docx", ".xls", ".xlsx", ".xml", ".pdf",//".psd",
                         ".ZIP", ".RAR", ".7Z", ".DOC", ".DOCX", ".XLS", ".XLSX", ".XML", ".PDF",//".psd",
                         ".PPT", ".PPTX", ".TXT",
                        ".ppt", ".pptx", ".txt"];

    var uploader = new qq.FileUploader({
        element: document.getElementById('btnChosse'),
        action: '/UploadFileSoHoa.aspx',
        sizeLimit: 81457280.000008244,
        debug: true,
        onSubmit: function (id, fileName) {
            if (listFileAllow.indexOf(fileName.substring(fileName.lastIndexOf('.'))) == -1) {
                createMessage("Thông báo", "File " + fileName + " không được phép tải lên.");
                return false;
            }
            // check trùng file
            var exits = false;
            //check trong trường hợp mới upload
            $("#listFileAttach li").each(function (index, item) {
                if (fileName == $(this).children("span").attr("title"))
                    exits = true;
            });

            //check trên file đã upload
            $("#listFileAttachRemove li").each(function (index, item) {
                if (fileName == $(this).children("span").attr("title"))
                    exits = true;
            });
            if (exits) {
                createMessage("Thông báo", "File " + fileName + " đã tồn tại! Bạn hãy chọn file khác.");
                return false;
            }
            var loadingSoHoa = $("#loadingSoHoa").length;
            if (loadingSoHoa > 0) {
                $("#loadingSoHoa").show();
            }
        },
        onComplete: function (id, fileName, responseJSON) {
            if (responseJSON.upload) {
                $("#listFileAttach").append(getHTMLDeleteLink(responseJSON));
                $("#listValueFileAttach").val(changeHiddenInput());
                if (responseJSON.BatchId != "0" && responseJSON.BatchId != null) {
                    FillVanbanSoHoa(responseJSON.BatchId);
                }
            } else {
                createMessage("Thông báo", responseJSON.message);
            }
        }
    });
}

function createUploaderWithOptions(options) {
    var uploader = new qq.FileUploader({
        element: document.getElementById('btnChosse'),
        action: '/UploadFile.aspx',
        allowedExtensions: options.allowedExtensions,
        sizeLimit: 31457280.000008244,
        debug: true,
        onSubmit: function (id, fileName) {
            // check trùng file
            var exits = false;
            //check trong trường hợp mới upload
            $("#listFileAttach li").each(function (index, item) {
                if (fileName == $(this).children("span").attr("title"))
                    exits = true;
            });
            //check trên file đã upload
            $("#listFileAttachRemove li").each(function (index, item) {
                if (fileName == $(this).children("span").attr("title"))
                    exits = true;
            });
            if (exits) {
                createMessage("Thông báo", "File " + fileName + " đã tồn tại! Bạn hãy chọn file khác");
                return false;
            }
        },
        onComplete: function (id, fileName, responseJSON) {
            if (responseJSON.upload) {
                $("#listFileAttach").append(getHTMLDeleteLink(responseJSON));
                $("#listValueFileAttach").val(changeHiddenInput());
            } else {
                createMessage("Thông báo", responseJSON.message);
            }
        }
    });
}
//Upload file có giới hạn định dạng và cho phép tải 1 file duy nhất
function createUploaderOneFileWithOptions(options) {
    var uploader = new qq.FileUploader({
        element: document.getElementById('btnChosse'),
        action: '/UploadFile.aspx',
        allowedExtensions: options.allowedExtensions,
        sizeLimit: 31457280.000008244,
        debug: true,
        onSubmit: function (id, fileName) {
            // check trùng file
            var exits = false;
            //check trong trường hợp mới upload
            $("#listFileAttach li").each(function (index, item) {
                if (fileName == $(this).children("span").attr("title"))
                    exits = true;
            });
            //check trên file đã upload
            $("#listFileAttachRemove li").each(function (index, item) {
                if (fileName == $(this).children("span").attr("title"))
                    exits = true;
            });
            if (exits) {
                createMessage("Thông báo", "File " + fileName + " đã tồn tại! Bạn hãy chọn file khác");
                return false;
            }
        },
        onComplete: function (id, fileName, responseJSON) {
            if (responseJSON.upload) {
                $("#listFileAttach").html("");
                $("#listFileAttach").append(getHTMLDeleteLink(responseJSON));
                $("#listValueFileAttach").val(changeHiddenInput());
            } else {
                createMessage("Thông báo", responseJSON.message);
            }
        }
    });
}
//Append li to ul checkbox
function createUploaderByID(id) {
    var element = $("#" + id).getElementById("btnChosse");
    alert(element);
    alert(document.getElementById('btnChosse'));
    var uploader = new qq.FileUploader({
        element: element,
        action: '/UploadFile.aspx',
        sizeLimit: 31457280.000008244,
        debug: true,
        onSubmit: function (id, fileName) {
            // check trùng file
            var exits = false;
            //check trong trường hợp mới upload
            $("#" + id + " #listFileAttach li").each(function (index, item) {
                if (fileName == $(this).children("span").attr("title"))
                    exits = true;
            });
            //check trên file đã upload
            $("#" + id + " #listFileAttachRemove li").each(function (index, item) {
                if (fileName == $(this).children("span").attr("title"))
                    exits = true;
            });

            if (exits) {
                createMessage("Thông báo", "File " + fileName + " đã tồn tại! Bạn hãy chọn file khác");
                return false;
            }
        },
        onComplete: function (id, fileName, responseJSON) {
            if (responseJSON.upload) {
                $("#" + id + " #listFileAttach").append(getHTMLDeleteLink(responseJSON));
                $("#" + id + " #listValueFileAttach").val(changeHiddenInput());
            } else {
                createMessage("Thông báo", responseJSON.message);
            }
        }
    });

}
/*file đính kèm*/
//Lấy về html file
function getHTMLDeleteLink(data) {
    var tenfile = "";
    if (data.filename.length > 36) {
        tenfile = data.filename.substring(0, 36) + '...' + data.filename.substring(data.filename.lastIndexOf('.'));
    } else {
        tenfile = data.filename;
    }
    return "<li><span id=\"" + data.fileserver + "\" title=\"" + data.filename + "\">" + tenfile + "</span> <a href=\"javascript:DeleteFileUpdate('" + data.fileserver + "');\"><img src=\"/Publishing_Resources/img/LastIcon/act_filedelete.png\" title=\"Xóa file đính kèm\" border=\"0\"></a></li>";
}

function getHTMLDeleteLinkoption(data) {
    var tenfile = "";
    if (data.filename.length > 36) {
        tenfile = data.filename.substring(0, 36) + '...' + data.filename.substring(data.filename.lastIndexOf('.'));
    } else {
        tenfile = data.filename;
    }
    return "<li><span id=\"" + data.fileserver + "\" title=\"" + data.filename + "\">" + tenfile + "</span> <a href=\"javascript:DeleteFileUpdateoption('" + data.fileserver + "');\"><img src=\"/Publishing_Resources/img/LastIcon/act_filedelete.png\" title=\"Xóa file đính kèm\" border=\"0\"></a></li>";
}

//lấy dữ liệu từ list 
function changeHiddenInput() {
    var valueFile = '[';
    var total = $("#listFileAttach li").length;
    $("#listFileAttach li").each(function (i) {
        valueFile += '{"FileServer": "' + $(this).children("span").attr("id") + '"\,';
        valueFile += '"FileName": "' + $(this).children("span").attr("title") + '"\}';
        if (i + 1 < total)
            valueFile += ',';
    });
    valueFile += "]";
    return valueFile;
}
function changeHiddenInputoption() {
    var valueFile = '[';
    var total = $("#listFileAttachoption li").length;
    $("#listFileAttachoption li").each(function (i) {
        valueFile += '{"FileServer": "' + $(this).children("span").attr("id") + '"\,';
        valueFile += '"FileName": "' + $(this).children("span").attr("title") + '"\}';
        if (i + 1 < total)
            valueFile += ',';
    });
    valueFile += "]";
    return valueFile;
}
function changeHiddenInputoption1() {
    var valueFile = '[';
    var total = $("#listFileAttachoption1 li").length;
    $("#listFileAttachoption1 li").each(function (i) {
        valueFile += '{"FileServer": "' + $(this).children("span").attr("id") + '"\,';
        valueFile += '"FileName": "' + $(this).children("span").attr("title") + '"\}';
        if (i + 1 < total)
            valueFile += ',';
    });
    valueFile += "]";
    return valueFile;
}
//duynv end file đính kém
//xoa row tren grid
function XoaThongTinPhongBanDonViDaChon(nguoidung, phongban, donvi, loai) {
    var htmlResponse = "";

    htmlResponse += "<script type=\"text/javascript\">\r\n";
    htmlResponse += "$(document).ready(function(){\r\n";
    htmlResponse += "   unbindHotkey();\r\n";
    //Đăng ký sự kiện khi click vào nút delete
    htmlResponse += "   $(\"#btnComfirmDelete\").click(function(){\r\n";
    if (loai == "1") {
        htmlResponse += phongban + "\r\n";
        htmlResponse += donvi + "\r\n";
    }
    if (loai == "2") {
        htmlResponse += nguoidung + "\r\n";
        htmlResponse += donvi + "\r\n";
    }
    if (loai == "3") {
        htmlResponse += phongban + "\r\n";
        htmlResponse += nguoidung + "\r\n";
    }
    htmlResponse += "       $('#btnComfirmClose').click();\r\n";
    htmlResponse += "   });\r\n";
    htmlResponse += "       $('#btnComfirmClose').click(function(){\r\n";
    if (loai == "1") {
        htmlResponse += nguoidung + "\r\n";
    }
    if (loai == "2") {
        htmlResponse += phongban + "\r\n";
    }
    if (loai == "3") {
        htmlResponse += donvi + "\r\n";
    }
    htmlResponse += "});\r\n";
    htmlResponse += "   $(document).bind('keypress', 'x', function (evt) {\r\n"; //Sự kiện bấm phím x
    htmlResponse += "       $('#btnComfirmDelete').click();\r\n";
    htmlResponse += "   });\r\n";
    htmlResponse += "   $(document).bind('keypress', 'return', function (evt) {\r\n"; //Sự kiện bấm phím enter
    htmlResponse += "       $('#btnComfirmDelete').click();\r\n";
    htmlResponse += "   });\r\n";
    htmlResponse += "   $(document).bind('keypress', 'd', function (evt) {\r\n"; // Sự kiện bấm phím d
    htmlResponse += "       $('#btnComfirmClose').click(function(){\r\n";
    if (loai == "1") {
        htmlResponse += nguoidung + "\r\n";
    }
    if (loai == "2") {
        htmlResponse += phongban + "\r\n";
    }
    if (loai == "3") {
        htmlResponse += donvi + "\r\n";
    }
    htmlResponse += "});\r\n";
    htmlResponse += "   });\r\n";
    htmlResponse += "   $('#dialog-confirm').on('hidden', function () {\r\n";
    htmlResponse += "      bindHotkey();\r\n";
    htmlResponse += "   })\r\n";
    htmlResponse += "});";
    htmlResponse += "</script>\r\n";

    htmlResponse += "<div class=\"modal-header\">";
    htmlResponse += "	<button type=\"button\" class=\"close\" data-dismiss=\"modal\" aria-hidden=\"true\"></button>";
    htmlResponse += "	<h4 class=\"modal-title\">Xóa thông tin người dùng, phòng ban hoặc đơn vị đã chọn tham gia hồ sơ công việc</h4>";
    htmlResponse += "</div>";
    htmlResponse += "<div class=\"modal-body\">";
    htmlResponse += "    <div class=\"alert\">";
    htmlResponse += "		<strong>Chú ý!</strong> Bạn có chắc chắn muốn xóa!";
    htmlResponse += "	</div>";
    htmlResponse += "<ul>";
    htmlResponse += "</ul>";
    htmlResponse += "</div>";
    htmlResponse += "<div class=\"modal-footer\">";
    htmlResponse += "	<button type=\"submit\" id=\"btnComfirmDelete\" class=\"btn green\" tabindex=\"5\"><i class=\"icon-trash\"></i> <b>X</b>óa</button>";
    htmlResponse += "	<button type=\"button\" id=\"btnComfirmClose\" class=\"btn red\" data-dismiss=\"modal\" tabindex=\"8\"><i class=\"fa fa-close\"></i> <b>Đ</b>óng lại</button>";
    htmlResponse += "</div>";

    $('#dialog-confirm').html(htmlResponse);
    $('#dialog-confirm').modal();
}

//bỏ chọn người dùng
function BoChonNguoiDung() {
    $("#hdfNguoiTD").val("");
    $("#hdfNguoiPH").val("");
    $("#hdfNguoiPT").val("");
    $("#hdfNguoiDung").val("");

    var urlNguoiDung = "pListChonNguoiDung.aspx?nguoiDungTG=&nguoiPT=&nguoiTD=&nguoiPH=";
    LoadAjaxPage(urlNguoiDung, "#div-ds-user-chon");
}
//xóa bỏ các check ở tab đơn vị
function BoChonDonVi() {
    $("#don-vi input:checked").each(function () {
        $(this).attr('checked', false);
    });
}
//xóa bỏ các check ở tab đơn vị
function BoChonPhongBan() {
    $("#phong-ban input:checked").each(function () {
        $(this).attr('checked', false);
    });
}


$(document).ready(function () {
    $(".tooltip").click(function () {
        $(this).Css("display", "none");
    })
    $(".date-picker").datepicker({
        format: 'dd/mm/yyyy',
        timePicker: true,
        autoclose: true,
        todayBtn: true,
        todayHighlight: true,
    });
    $("#Keyword").focus();
    $("#btnResetModal").click(function () {
        $("label.error").css("display", "none");
    });
    //$(".date-picker").mask("99/99/9999");

    $("#gridSearch").hide();

    $("#opensearch").click(function () {
        $("#gridSearch").slideDown();
    });
    $("#opensearchNangCao").click(function () {
        $("#gridSearch").slideDown();
    });
    $("#btnclosesearch").click(function () {
        $("#gridSearch").slideUp();

    });

    $("#gridSearch1").hide();

    $("#opensearch1").click(function () {
        $("#gridSearch1").slideDown();
    });
    $("#opensearchNangCao1").click(function () {
        $("#gridSearch1").slideDown();
    });
    $("#btnclosesearch1").click(function () {
        $("#gridSearch1").slideUp();

    });
    $("#gridSearch2").hide();

    $("#opensearch2").click(function () {
        $("#gridSearch2").slideDown();
    });
    $("#opensearchNangCao2").click(function () {
        $("#gridSearch2").slideDown();
    });
    $("#btnclosesearch2").click(function () {
        $("#gridSearch2").slideUp();

    });


    $("#NgayBanHanhDau").datepicker({
        format: "dd/mm/yyyy"
    }).change(function () {
        $("#NgayBanHanhCuoi").datepicker('setStartDate', $(this).val());
    });

    $("#NgayBanHanhCuoi").datepicker({
        format: "dd/mm/yyyy"
    }).change(function () {
        $("#NgayBanHanhDau").datepicker('setEndDate', $(this).val());
    });

    $("#NgayDenDau").datepicker({
        format: "dd/mm/yyyy"
    }).change(function () {
        $("#NgayDenCuoi").datepicker('setStartDate', $(this).val());
    });

    $("#NgayDenCuoi").datepicker({
        format: "dd/mm/yyyy"
    }).change(function () {
        $("#NgayDenDau").datepicker('setEndDate', $(this).val());
    });

    $("#NgayMoHoSo").datepicker({
        format: "dd/mm/yyyy"
    }).change(function () {
        $("#HanXuLy").datepicker('setStartDate', $(this).val());
    });

    $("#HanXuLy").datepicker({
        format: "dd/mm/yyyy"
    }).change(function () {
        $("#NgayMoHoSo").datepicker('setEndDate', $(this).val());
    });
    $("#NgayMoHoSoTuNgay").datepicker({
        format: "dd/mm/yyyy"
    }).change(function () {
        $("#NgayMoHoSoDenNgay").datepicker('setStartDate', $(this).val());
    });

    $("#NgayMoHoSoDenNgay").datepicker({
        format: "dd/mm/yyyy"
    }).change(function () {
        $("#NgayMoHoSoTuNgay").datepicker('setEndDate', $(this).val());
    });
    $("#HanXuLyTuNgay").datepicker({
        format: "dd/mm/yyyy"
    }).change(function () {
        $("#HanXuLyDenNgay").datepicker('setStartDate', $(this).val());
    });

    $("#HanXuLyDenNgay").datepicker({
        format: "dd/mm/yyyy"
    }).change(function () {
        $("#HanXuLyTuNgay").datepicker('setEndDate', $(this).val());
    });

    $("#NgayMoHoSoTuNgay").datepicker({
        format: "dd/mm/yyyy"
    }).change(function () {
        $("#NgayMoHoSoDenNgay").datepicker('setStartDate', $(this).val());
    });

    //loadCoQuanBanHanh();
    $('.btnAddModal').dblclick(function (e) {
        e.preventDefault();
    });
});

//function loadCoQuanBanHanh() {
//    var availableTags = [];
//    var keyword = $("#CoQuanBanHanhText").val();
//    $.ajax({
//        type: "POST",
//        async: false,
//        url: '/Coquanbanhanh.ashx?keyword=' + keyword + '&show=10',
//        data: {},
//        contentType: "application/json; charset=utf-8",
//        dataType: "json",
//        success: function (data) {
//            $.each(data, function (key, val) {
//                availableTags.push(val.Ten);
//            });
//            $("#CoQuanBanHanhText").autocomplete({
//                source: availableTags
//            });
//        }
//    });
//}

/* Thêm vào nhằm kết hợp Sort + Search + Paging */
function getSortingParameters() {
    var url = window.location.href;
    var index = url.indexOf('Field');
    if (index > 0) {
        var parameters = url.substring(index, url.length);
        if (parameters.indexOf('FieldOption') < 0) {
            parameters = parameters + '&FieldOption=0';
        }
        var i1 = parameters.indexOf('Field');
        var i2 = parameters.indexOf('FieldOption');
        parameters = parameters.substring(i1, i2 + "FieldOption=0".length);
        return parameters;
    }
    return '';
}
function ajaxFormSearch(selector) {
    var parameters = getSortingParameters();
    window.location.href = parameters != ''
        ? '#' + $(selector).mySerialize() + '&' + parameters
        : '#' + $(selector).mySerialize();
}
//get value of parameter
function GetURLParameter(sParam) {
    var sPageURL = window.location.href;
    var sURLVariables = sPageURL.split('&');
    for (var i = 0; i < sURLVariables.length; i++) {
        var sParameterName = sURLVariables[i].split('=');
        if (sParameterName[0] == sParam) {
            return sParameterName[1];
        }
    }
}
function ActiveTab() {
    $(".content-tab div[id *= 'tab']").hide();
    $(".content-tab div:first-child").show();
    $(".tab > ul > li").click(function () {
        if (!$(this).hasClass("active")) {
            $(".content-tab div[id *= 'tab']").slideUp();
            $(".tab ul li").removeClass("active");
            var tabid = $(this).attr("rel");
            $(this).addClass("active");
            $(".content-tab #" + tabid).slideDown();
        }
        var rel = $(this).attr("rel");
        $(".content-tab div[id*='tab']").each(function () {
            var id = $(this).attr("id");
            if (rel == id) {
                return;
            }
            if (id == "tab1") {
                $("#LanhDaoID").select2("val", "");
                $("#DonViDauMoiID").select2("val", "");
                $("#DonViPhoiHop").select2("val", "");
                $("#listTrangThai1").html("");
                $("#kengang1").css("display", "none");
            } else if (id == "tab2") {
                $("#LanhDaoDauMoi").select2("val", "");
                $("#NguoiDauMoiID").select2("val", "");
                $("#CanBoPhoiHop").select2("val", "");
                $("#listTrangThai2").html("");
                $("#kengang2").css("display", "none");
            } else if (id == "tab3") {
                $("#PhongDauMoi").select2("val", "");
                $("#PhongBanPhoiHop").select2("val", "");
                $("#listTrangThai3").html("");
                $("#kengang3").css("display", "none");
            }
        });
    })
}
function ClickTab() {
    //$(".content-tab div[id *= 'tab']").hide();
    //$(".content-tab div:first-child").show();
    $(".tab > ul > li").click(function () {
        if (!$(this).hasClass("active")) {
            $(".content-tab div[id *= 'tab']").slideUp();
            $(".tab ul li").removeClass("active");
            var tabid = $(this).attr("rel");
            $(this).addClass("active");
            $(".content-tab #" + tabid).slideDown();
        }
        var rel = $(this).attr("rel");
        $(".content-tab div[id*='tab']").each(function () {
            var id = $(this).attr("id");
            if (rel == id) {
                return;
            }
            if (id == "tab1") {
                $("#LanhDaoID").select2("val", "");
                $("#listTrangThai1").html("");
                $("#kengang1").html("");
                //xóa các control tab 1 ở đây
            } else if (id == "tab2") {
                //xóa các control tab 2 ở đây
            } else if (id == "tab3") {
                //xóa các control tab 3 ở đây
            }
        });
    })
}
/* Hỗ trợ Export Word, Excel */
function ExportByUrl(urlExport) {
    var url = window.location.href;
    var idx1 = url.indexOf('#');
    var idx2 = url.indexOf('?');
    var parameters = idx1 < 0 && idx2 < 0 ? '' : url.substring(url.indexOf('#') + 1, url.length);
    window.location.href = parameters != '' ? urlExport + '&' + parameters : urlExport;
}
//ẩn/ Hiện, thay đổi trạng thái bản ghi
function TreeHide(urlPost, arrRowId, rowTitle) {
    var htmlResponse = "";
    htmlResponse += "<script type=\"text/javascript\">\r\n";
    htmlResponse += "$(document).ready(function(){\r\n";
    htmlResponse += "   unbindHotkey();\r\n";
    htmlResponse += "   $(\"#btnComfirmHide\").click(function(){\r\n";
    htmlResponse += "       $.post(encodeURI(\"" + urlPost + "\"), { \"do\": \"hide\", \"itemId\": \"" + arrRowId + "\" }, function (data) {\r\n";
    htmlResponse += "       $('#btnComfirmClose').click();\r\n";
    htmlResponse += "           if (data.Error) {\r\n";
    htmlResponse += "               createMessage(\"Có lỗi xảy ra\", data.Title);\r\n";
    htmlResponse += "           }\r\n";
    htmlResponse += "           else {\r\n";
    htmlResponse += "               getTreeView();\r\n";
    htmlResponse += "           }\r\n";
    htmlResponse += "       });\r\n";
    htmlResponse += "   });\r\n";
    htmlResponse += "   $(document).bind('keypress', 'a', function (evt) {\r\n"; //Sự kiện bấm phím a
    htmlResponse += "       $('#btnComfirmHide').click();\r\n";
    htmlResponse += "   });\r\n";
    htmlResponse += "   $(document).bind('keypress', 'return', function (evt) {\r\n"; //Sự kiện bấm phím enter
    htmlResponse += "       $('#btnComfirmHide').click();\r\n";
    htmlResponse += "   });\r\n";
    htmlResponse += "   $(document).bind('keypress', 'd', function (evt) {\r\n"; // Sự kiện bấm phím d
    htmlResponse += "       $('#btnComfirmClose').click();\r\n";
    htmlResponse += "   });\r\n";
    htmlResponse += "   $('#dialog-confirm').on('hidden', function () {\r\n";
    htmlResponse += "      bindHotkey();\r\n";
    htmlResponse += "   })\r\n";
    htmlResponse += "});";
    htmlResponse += "</script>\r\n";

    htmlResponse += "<div class=\"modal-header\">";
    htmlResponse += "	<button type=\"button\" class=\"close\" data-dismiss=\"modal\" aria-hidden=\"true\"></button>";
    htmlResponse += "	<h4 class=\"modal-title\">Thay đổi trạng thái bản ghi đã chọn</h4>";
    htmlResponse += "</div>";
    htmlResponse += "<div class=\"modal-body\">";
    htmlResponse += "    <div class=\"alert\">";
    htmlResponse += "		<strong>Chú ý!</strong> Bạn có chắc thay đổi trạng thái!";
    htmlResponse += "	</div>";
    htmlResponse += "<ul>";
    htmlResponse += rowTitle;
    htmlResponse += "</ul>";
    htmlResponse += "</div>";
    htmlResponse += "<div class=\"modal-footer\">";
    htmlResponse += "	<button type=\"submit\" id=\"btnComfirmHide\" class=\"btn green\" tabindex=\"5\"><i class=\"far fa-eye-slash\"></i> <b>Ẩ</b>n</button>";
    htmlResponse += "	<button type=\"button\" id=\"btnComfirmClose\" class=\"btn red\" data-dismiss=\"modal\" tabindex=\"8\"><i class=\"fa fa-close\"></i> <b>Đ</b>óng lại</button>";
    htmlResponse += "</div>";

    $('#dialog-confirm').html(htmlResponse);
    $('#dialog-confirm').modal({ width: 650 });
}
//ẩn/ Hiện, thay đổi trạng thái bản ghi
function TreeShow(urlPost, arrRowId, rowTitle) {
    var htmlResponse = "";
    htmlResponse += "<script type=\"text/javascript\">\r\n";
    htmlResponse += "$(document).ready(function(){\r\n";
    htmlResponse += "   unbindHotkey();\r\n";
    htmlResponse += "   $(\"#btnComfirmHide\").click(function(){\r\n";
    htmlResponse += "       $.post(encodeURI(\"" + urlPost + "\"), { \"do\": \"show\", \"itemId\": \"" + arrRowId + "\" }, function (data) {\r\n";
    htmlResponse += "       $('#btnComfirmClose').click();\r\n";
    htmlResponse += "           if (data.Error) {\r\n";
    htmlResponse += "               createMessage(\"Có lỗi xảy ra\", data.Title);\r\n";
    htmlResponse += "           }\r\n";
    htmlResponse += "           else {\r\n";
    htmlResponse += "               getTreeView();\r\n";
    htmlResponse += "           }\r\n";
    htmlResponse += "       });\r\n";
    htmlResponse += "   });\r\n";
    htmlResponse += "   $(document).bind('keypress', 'a', function (evt) {\r\n"; //Sự kiện bấm phím a
    htmlResponse += "       $('#btnComfirmHide').click();\r\n";
    htmlResponse += "   });\r\n";
    htmlResponse += "   $(document).bind('keypress', 'return', function (evt) {\r\n"; //Sự kiện bấm phím enter
    htmlResponse += "       $('#btnComfirmHide').click();\r\n";
    htmlResponse += "   });\r\n";
    htmlResponse += "   $(document).bind('keypress', 'd', function (evt) {\r\n"; // Sự kiện bấm phím d
    htmlResponse += "       $('#btnComfirmClose').click();\r\n";
    htmlResponse += "   });\r\n";
    htmlResponse += "   $('#dialog-confirm').on('hidden', function () {\r\n";
    htmlResponse += "      bindHotkey();\r\n";
    htmlResponse += "   })\r\n";
    htmlResponse += "});";
    htmlResponse += "</script>\r\n";

    htmlResponse += "<div class=\"modal-header\">";
    htmlResponse += "	<button type=\"button\" class=\"close\" data-dismiss=\"modal\" aria-hidden=\"true\"></button>";
    htmlResponse += "	<h4 class=\"modal-title\">Thay đổi trạng thái bản ghi đã chọn</h4>";
    htmlResponse += "</div>";
    htmlResponse += "<div class=\"modal-body\">";
    htmlResponse += "    <div class=\"alert\">";
    htmlResponse += "		<strong>Chú ý!</strong> Bạn có chắc thay đổi trạng thái!";
    htmlResponse += "	</div>";
    htmlResponse += "<ul>";
    htmlResponse += rowTitle;
    htmlResponse += "</ul>";
    htmlResponse += "</div>";
    htmlResponse += "<div class=\"modal-footer\">";
    htmlResponse += "	<button type=\"submit\" id=\"btnComfirmHide\" class=\"btn green\" tabindex=\"5\"><i class=\"far fa-eye-slash\"></i> <b>H</b>iện</button>";
    htmlResponse += "	<button type=\"button\" id=\"btnComfirmClose\" class=\"btn red\" data-dismiss=\"modal\" tabindex=\"8\"><i class=\"fa fa-close\"></i> <b>Đ</b>óng lại</button>";
    htmlResponse += "</div>";

    $('#dialog-confirm').html(htmlResponse);
    $('#dialog-confirm').modal({ width: 650 });
}
//validate
function validationSartDateEndDate(sectionStart, sectionEnd) {
    var startDate;
    var endDate;
    $('#' + sectionStart).datepicker()
                 .on('changeDate', function (ev) {
                     startDate = '';
                     startDate = new Date(ev.date.getFullYear(), ev.date.getMonth(), ev.date.getDate(), 0, 0, 0);
                     if (endDate != null && endDate != 'undefined' && endDate != '') {
                         if (endDate < startDate) {
                             createMessage("Thông báo", " Thời gian bắt đầu phải nhỏ hơn thời gian kết thúc");
                             $("#ThoiGianBatDau").val("");
                         }
                     }
                 });
    $('#' + sectionEnd).datepicker()
        .on("changeDate", function (ev) {
            endDate = '';
            endDate = new Date(ev.date.getFullYear(), ev.date.getMonth(), ev.date.getDate(), 0, 0, 0);
            if (startDate != null && startDate != 'undefined' && startDate != '') {
                if (endDate < startDate) {
                    createMessage("Thông báo", " Thời gian kết thúc phải lớn hơn thời gian bắt đầu");
                    $("#ThoiGianKetThuc").val("");
                }
            }
        });
}
//Xóa message và call functio nếu có
function ClearMessage(tag, method) {
    setTimeout(function () {
        $("" + tag).html("");
        if (method != null && method != "") {
            method;
        }
    }, 10000);
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


