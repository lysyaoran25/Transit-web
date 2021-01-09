$(function () {
    ActiveTab();
    $('.date').datepicker({
        format: 'dd/mm/yyyy',
    }).on('changeDate', function (e) {
        $(this).datepicker('hide');
    });
});
// lấy giá trị gán vào select2
function GetValueSelect2(select, value) {
    var arrdata = value;
    if (arrdata != "") {
        arrdata = arrdata.substring(0, arrdata.lastIndexOf(","));
        var thdprdata = [];
        $(arrdata.split(",")).each(function () {
            thdprdata.push({ id: this.split(':')[0], text: this.split(':')[1] });
        });
        $(select).select2("data", thdprdata);
    }
}
// validate ngày tháng năm
function ValidDate(strDate) {
    var regex = /^(((0[1-9]|[12]\d|3[01])\/(0[13578]|1[02])\/((1[6-9]|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\/(0[13456789]|1[012])\/((1[6-9]|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\/02\/((1[6-9]|[2-9]\d)\d{2}))|(29\/02\/((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$/;
    if (!(regex.test(strDate))) {
        return false;
    }
    return true;
}
//validate number
function ValidNumber(strNumber) {
    var regex = /^[0-9]+$/;
    if (!(regex.test(strNumber))) {
        return false;
    }
    return true;
}
//function ActiveTab() {
//    $(".content-tab div[id *= 'tab']").hide();
//    $(".content-tab div:first-child").show();
//    $(".tab > ul > li").click(function () {
//        if (!$(this).hasClass("active")) {
//            $(".content-tab div[id *= 'tab']").slideUp();
//            $(".tab ul li").removeClass("active");
//            var tabid = $(this).attr("rel");
//            $(this).addClass("active");
//            $(".content-tab #" + tabid).slideDown();

//        }
//    })
//}

function ShowQuickTool(id) {
    $('.quickTool').removeClass('show-inline');
    $("#" + id).addClass('show-inline');
}

function printPage(donvi, title, fromDate, toDate) {
    //function printPage() {
    var today = new Date();
    var dd = today.getDate();
    var mm = today.getMonth() + 1; //January is 0!
    var yyyy = today.getFullYear();
    var printContents = "<div class=\"row margin-0\">";
    printContents += "<div class=\"col-md-6 col-sm-6 textUppercase font-bold\">";
    printContents += donvi == '' || donvi == undefined ? "NGÂN HÀNG NHÀ NƯỚC <p class=\"paddingL-40\">VIỆT NAM</p>" : donvi;
    printContents += "</div>";
    printContents += "<span class=\"font-bold\" style=\"  position: absolute;top:5;right:5\">";
    printContents += "Ngày " + dd + " tháng " + mm + " năm " + yyyy;
    printContents += "</span>";
    printContents += "</div>";
    printContents += "<div class=\"row align-center margin-0 paddingB-20\">";
    printContents += "<h3 class=\"textUppercase margin-0\">" + title + "</h3>";
    printContents += "<span class=\"font-italic\">Từ ngày " + fromDate + " đến ngày " + toDate + "</span>";
    printContents += "</div>";
    printContents += $('.data-table').html();
    printContents += '<html><head><title>In so van ban</title><link href="/Publishing_Resources/css/custom.css" rel="stylesheet" type="text/css" /><link href="/Publishing_Resources/global/plugins/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css" /><link href="/Publishing_Resources/global/plugins/simple-line-icons/simple-line-icons.min.css" rel="stylesheet" type="text/css" /><link href="/Publishing_Resources/global/plugins/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />';
    var params = [
    'height=' + screen.height,
    'width=' + screen.width,
    'fullscreen=yes' // only works in IE, but here for completeness
    ].join(',');
    var printWindow = window.open('', '', params, 'scrollbars=1');
    printWindow.document.write(printContents);
    printWindow.print();
}

function printBiaHoSo() {
    var printContents = $('.data-table').html();
    printContents += '<html><head><title>In so van ban</title><link href="/Publishing_Resources/css/custom.css" rel="stylesheet" type="text/css" /><link href="/Publishing_Resources/global/plugins/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css" /><link href="/Publishing_Resources/global/plugins/simple-line-icons/simple-line-icons.min.css" rel="stylesheet" type="text/css" /><link href="/Publishing_Resources/global/plugins/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />';
    var params = [
    'height=' + screen.height,
    'width=' + screen.width,
    'fullscreen=yes' // only works in IE, but here for completeness
    ].join(',');
    var printWindow = window.open('', '', params, 'scrollbars=1');
    printWindow.document.write(printContents);
    printWindow.print();
}


$(document).ready(function () {
    var heght = $(window).height() - 130;
    $("head").append("<style> .modal-overflow .modal-body{overflow: hidden !important;overflow-y: auto !important;max-height:" + heght + "px !important} </style>");
    HideRowID();

    //show detailt when cxlick link
    $('.viewmore').click(function () {
        $('.show').click();
    });
var heightNav = $('.page-header.navbar').height();
    $('.page-container').css('margin-top', heightNav +'px');
});

//Hide col ID in table
function HideRowID() {
    var firstCol = $('table.gridView thead tr th:first a');
    if(firstCol.text().toLowerCase() =='id') {
        var gridView = $('table.gridView');
        gridView.find('thead tr th:first').hide();
        gridView.find('tbody tr').each(function (index,item) {
            $(this).find('td:first').hide();
        });
        
    }

};
function removeParameter() {
    var url = window.location.href;
    var idx1 = url.indexOf('#');
    if (idx1 > 0) {
        window.location.href = url.substring(0, (idx1 + 1));
    }
}
//Chuyển trang khi thêm mới hoặc update
function RedirectPage(DoAction, Title) {
    if (DoAction == 'add') {
        removeParameter();
        createCloseMessage2("Thông báo", Title, '#Page=1'); // Tạo thông báo khi click đóng thì chuyển đến url đích
    }
    else {
        createCloseMessage("Thông báo", Title, '#Page=1&message=' + Title + '&temp=' + Math.floor(Math.random() * 11) + ''); // Tạo thông báo khi click đóng thì chuyển đến url đích
    }
}

function focusGridview() {
    if ($(".gridView").offset() != null && $(".gridView").offset() != "undefined") {
        var headHeight = $('.page-header').height() + 20;
        var scrollTop = $(".gridView").offset().top > headHeight ? $(".gridView").offset().top - headHeight : $(".gridView").offset().top;
        $('html, body').animate({
            scrollTop: scrollTop
        }, 100);
    }
   
}
// AF
function GetValueSelect2_AF(select, value) {
    debugger;
    var arrdata = value;
    if (arrdata != "") {
        arrdata = arrdata.substring(0, arrdata.lastIndexOf(";"));
        var thdprdata = [];
        $(arrdata.split(";")).each(function () {
            thdprdata.push({ id: this.split(':')[0], text: this.split(':')[1] });
        });
        $(select).select2("data", thdprdata);
    }
}