var urlTestChild = "/Survey/TestManage/AjaxChild.aspx";
var urlFormDoTheSurvey = "/Survey/TestManage/DoTheSurvey/AjaxFormDoTheSurvey.aspx";
var d = new Date();
var m = d.getMonth() + 1;
var y = d.getFullYear();

function refreshPage(type, rowperpage, page, month, year) {
    switch (type) {
        case 'do': {
            TestChild(rowperpage, page, type, month, year);
            break;
        }
        case 'approve': {
            TestChild(rowperpage, page, type, month, year);
            break;
        }
    }
}

function ChangePage(type, rowperpage, input, month, year) {
    var page = $(input).val();
    switch (type) {
        case 'do': {
            TestChild(rowperpage, page, type, month, year);
            break;
        }
        case 'approve': {
            TestChild(rowperpage, page, type, month, year);
            break;
        }
    }
}

function ChangeRow(type, input,month,year) {
    var rowperpage = $(input).val();
    switch (type) {
        case 'do': {
            TestChild(rowperpage, 1, type, month, year);
            break;
        }
        case 'approve': {
            TestChild(rowperpage, 1, type, month, year);
            break;
        }
    }
}

function TestChild(row, page, type, month, year) {
    LoadAjaxPage(urlTestChild + "?RowPerPage=" + row + "&Page=" + page + "&type=" + type + "&" + $("#SearchForm_approve").serialize() + "&Month=" + month + "&Year=" + year, "#TestChild_" + type);
}

function OpenSurveyForm(id, user, manager, type) {
    window.open(
        '/Pagess/survey-test.aspx?ItemID=' + id + "&ManagerID=" + manager + "&UserID=" + user + "&Type=" + type,
        '_blank' // <- This is what makes it open in a new window.
    );
}

function OpenSearch() {
    $(".SearchView_approve").toggle("slow");
}

function OpenImport() {
    $(".ImportView_approve").toggle("slow");
}


$("#SearchForm_approve").validate({
    submitHandler: function () {
        var type = $("#typeview").val();
        var date = $(".picker").datepicker('getDate');
        month = date.getMonth() + 1;
        year = date.getFullYear();
        TestChild(10, 1, type, month, year)
        return false;
    }
});

$(".picker").datepicker({
    changeMonth: true,
    changeYear: true,
    format: "mm/yyyy",
    viewMode: "months",
    minViewMode: "months",
    autoclose: true,
}).on("changeDate", function () {
    var date = $(this).datepicker('getDate');
    month = date.getMonth() + 1;
    year = date.getFullYear();
    var type = $("#typeview").val();
    TestChild(10, 1, type, month, year)
});