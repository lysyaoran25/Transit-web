var urlReportChildDetail = "/Survey/ReportManage/AjaxChildDetail.aspx";
var urlReportChildMonth = "/Survey/ReportManage/AjaxChildMonth.aspx";
var urlReportViewDetail = "/Survey/ReportManage/AjaxViewDetail.aspx";
var urlReportViewMonth = "/Survey/ReportManage/AjaxViewMonth.aspx";
var d = new Date();
var m = d.getMonth() + 1;
var y = d.getFullYear();

function refreshPage(type, rowperpage, page, month, year) {
    ReportChild(rowperpage, page, type, month, year)
}

function ReportChild(row, page, typereport, month, year) {
    $("#report-child").html("")
    switch (typereport) {
        case "detail": {
            LoadAjaxPage(urlReportChildDetail + "?RowPerPage=" + row + "&Page=" + page + "&Month=" + month + "&Year=" + year, "#report-child");
            break;
        }
        case "month": {
            LoadAjaxPage(urlReportChildMonth + "?RowPerPage=" + row + "&Page=" + page + "&Month=" + month + "&Year=" + year, "#report-child");
            break;
        }
        case "year": {
            //LoadAjaxPage(urlTestChild + "?RowPerPage=" + row + "&Page=" + page + "#Report-child");
            break;
        }
    }
}

function ChangePage(type, rowperpage, input, month, year) {
    var page = $(input).val();
    ReportChild(rowperpage, page, type, month, year)
}

function ChangeRow(type, input, month, year) {
    var rowperpage = $(input).val();
    ReportChild(rowperpage, page, type, month, year)
}

function open_view_report_detail(test, user) {
    $('body').modalmanager('loading');
    $('#dialog-form').load(urlReportViewDetail + "?ItemID=" + test + "&UserID=" + user, function () {
        $('#dialog-form').modal({ width: 650 });
    });
}

function open_view_report_month(test, user) {
    $('body').modalmanager('loading');
    $('#dialog-form').load(urlReportViewMonth + "?ItemID=" + test + "&UserID=" + user, function () {
        $('#dialog-form').modal({ width: 650 });
    });
}

function ChangeReport(input) {
    var date = $(".picker-report").datepicker('getDate');
    month = date.getMonth() + 1;
    year = date.getFullYear();
    var type = $(input).val();
    ReportChild(10, 1, type, month, year)
}

function Export() {
    var date = $(".picker-report").datepicker('getDate');
    month = date.getMonth() + 1;
    year = date.getFullYear();
    window.location.href = "/Survey/ReportManage/AjaxList.aspx?do=excel_month&type=" + $("#Report").val() + "&Month=" + month + "&Year=" + year;
}


$(".picker-report").datepicker({
    changeMonth: true,
    changeYear: true,
    format: "mm/yyyy",
    viewMode: "months",
    minViewMode: "months",
    setDate: new Date(),
    autoclose: true,
}).on("changeDate", function () {
    var date = $(this).datepicker('getDate');
    month = date.getMonth() + 1;
    year = date.getFullYear();
    var type = $("#Report").val();
    ReportChild(10, 1, type, month, year)
});