var urlQuestionList = "/Survey/QuestionManage/Question/QuestionList.aspx";
var urlCategoryList = "/Survey/QuestionManage/Category/CategoryList.aspx";
var urlTestList = "/Survey/QuestionManage/Test/TestList.aspx";
var urlEvaluateList = "/Survey/QuestionManage/Evaluate/EvaluateList.aspx";

var urlFormCreateSurveyCategory = "/Survey/QuestionManage/Category/AjaxFormCreate.aspx";
var urlFormCreateSurveyQuestion = "/Survey/QuestionManage/Question/AjaxFormCreate.aspx";
var urlFormCreateSurveyTest = "/Survey/QuestionManage/Test/AjaxFormCreate.aspx";
var urlFormCreateSurveyEvaluate = "/Survey/QuestionManage/Evaluate/AjaxFormCreate.aspx";


//Pagination
function refreshPage(type, rowperpage, page) {
    switch (type) {
        case 'Question': {
            QuestionList(rowperpage, page);
            break;
        }
        case 'Category': {
            CategoryList(rowperpage, page);
            break;
        }
        case 'Test': {
            TestList(rowperpage, page);
            break;
        }
    }
}

//Change page
function ChangePage(type, rowperpage, input) {
    var page = $(input).val();
    switch (type) {
        case 'Question': {
            QuestionList(rowperpage, page);
            break;
        }
        case 'Category': {
            CategoryList(rowperpage, page);
            break;
        }
        case 'Test': {
            TestList(rowperpage, page);
            break;
        }
    }
}

//Change row
function ChangeRow(type, input) {
    var rowperpage = $(input).val();
    switch (type) {
        case 'Question': {
            QuestionList(rowperpage, 1);
            break;
        }
        case 'Category': {
            CategoryList(rowperpage, 1);
            break;
        }
        case 'Test': {
            TestList(rowperpage, 1);
            break;
        }
    }
}

//Load Question List
function QuestionList(row, page) {
    LoadAjaxPage(urlQuestionList + "?RowPerPage=" + row + "&Page=" + page, "#QuestionList");
}

//Load Question List
function CategoryList(row, page) {
    LoadAjaxPage(urlCategoryList + "?RowPerPage=" + row + "&Page=" + page, "#CategoryList");
}

//Load Test List
function TestList(row, page) {
    LoadAjaxPage(urlTestList + "?RowPerPage=" + row + "&Page=" + page, "#TestList");
}

function EvaluateList(row, page) {
    LoadAjaxPage(urlEvaluateList + "?RowPerPage=" + row + "&Page=" + page, "#EvaluateList");
}

// Change status active - Question
function QuestionActive(id, input) {
    var status = false;
    if ($(input).is(":checked")) {
        status = true;
    }
    $.ajax({
        type: "POST",
        url: "/Survey/QuestionManage/Question/QuestionList.aspx/ChangeStatus_Question",
        data: "{id:'" + id + "',status:" + status + "}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (msg) {
            $("#Question_Status_" + id).prop("checked", status);
        }
    });
}
// Change status active - Category
function CategoryActive(id, input) {
    var status = false;
    if ($(input).is(":checked")) {
        status = true;
    }
    $.ajax({
        type: "POST",
        url: "/Survey/QuestionManage/Category/CategoryList.aspx/ChangeStatus_Category",
        data: "{id:'" + id + "',status:" + status + "}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (msg) {
            $("#Category_Status_" + id).prop("checked", status);
        }
    });
}

//CREATE
//Open modal create new survey category
$('#btn-survey-create-category').on('click', function (ev) {
    ev.preventDefault();
    $('body').modalmanager('loading');
    $('#dialog-form').load(urlFormCreateSurveyCategory, function () {
        $('#dialog-form').modal({ width: 500 });
    });
});
//Open modal create new survey question
$('#btn-survey-create-question').on('click', function (ev) {
    ev.preventDefault();
    $('body').modalmanager('loading');
    $('#dialog-form').load(urlFormCreateSurveyQuestion, function () {
        $('#dialog-form').modal({ width: 650 });
    });
});
//Open modal create new survey test
$('#btn-survey-create-test').on('click', function (ev) {
    ev.preventDefault();
    $('body').modalmanager('loading');
    $('#dialog-form').load(urlFormCreateSurveyTest, function () {
        $('#dialog-form').modal({ width: 1000 });
    });
});
//Open modal create new survey evaluate
$('#btn-survey-create-evaluate').on('click', function (ev) {
    ev.preventDefault();
    var id = $(this).data("id");
    $('body').modalmanager('loading');
    $('#dialog-form').load(urlFormCreateSurveyEvaluate + "?ItemID=" + id, function () {
        $('#dialog-form').modal({ width: 650 });
    });
});
//EDIT
//Open modal edit survey category
function Edit_Survey_Category(itemid) {
    urlFormEditSurveyCategory = "/Survey/QuestionManage/Category/AjaxFormCreate.aspx?do=edit&ItemID=" + itemid;
    $('body').modalmanager('loading');
    $('#dialog-form').load(urlFormEditSurveyCategory, function () {
        $('#dialog-form').modal({ width: 500 });
    });
}
//Open modal edit survey question
function Edit_Survey_Question(itemid) {
    urlFormEditSurveyQuestion = "/Survey/QuestionManage/Question/AjaxFormCreate.aspx?do=edit&ItemID=" + itemid;
    $('body').modalmanager('loading');
    $('#dialog-form').load(urlFormEditSurveyQuestion, function () {
        $('#dialog-form').modal({ width: 650 });
    });
}
//Open modal edit survey test
function Edit_Survey_Test(itemid) {
    urlFormEditSurveyTest = "/Survey/QuestionManage/Test/AjaxFormCreate.aspx?do=edit&ItemID=" + itemid;
    $('body').modalmanager('loading');
    $('#dialog-form').load(urlFormEditSurveyTest, function () {
        $('#dialog-form').modal({ width: 1000 });
    });
}
//DELETE
//Open modal confirm delete survey question
function Delete_Survey_Question(listitem) {
    swal({
        title: "Thông báo",
        text: "Bạn có chắc muốn xóa câu hỏi!",
        buttons: {
            cancel: {
                text: "Hủy",
                visible: true,
                className: "btn_delete_cancel",
            },
            confirm: {
                text: "Đồng ý",
                className: "btn_delete_confirm",
            },
        },
    }).then(function (isConfirm) {
        if (isConfirm) {
            var urlPostAction = "/Survey/QuestionManage/Question/Action.ashx"
            $.post(urlPostAction, { "do": "delete", "ItemID": JSON.stringify(listitem) }, function (data) {
                if (data.Error) {
                    console.log(data.Obj)
                    swal({
                        title: 'Thông báo',
                        text: data.Title,
                    })
                }
                else {
                    swal({
                        title: 'Thông báo',
                        text: data.Title,
                    })
                    QuestionList(10, 1);
                }
            });
        } else {
        }
    });
}

//Open modal confirm delete survey category
function Delete_Survey_Category(listitem) {
    swal({
        title: "Thông báo",
        text: "Bạn có chắc muốn xóa danh mục!",
        buttons: {
            cancel: {
                text: "Hủy",
                visible: true,
                className: "btn_delete_cancel",
            },
            confirm: {
                text: "Đồng ý",
                className: "btn_delete_confirm",
            },
        },
    }).then(function (isConfirm) {
        if (isConfirm) {
            var urlPostAction = "/Survey/QuestionManage/Category/Action.ashx"
            $.post(urlPostAction, { "do": "delete", "ItemID": JSON.stringify(listitem) }, function (data) {
                if (data.Error) {
                    console.log(data.Obj)
                    swal({
                        title: 'Thông báo',
                        text: data.Title,
                    })
                }
                else {
                    swal({
                        title: 'Thông báo',
                        text: data.Title,
                    })
                    CategoryList(10, 1);
                }
            });

        } else {
        }
    });
}

//Open modal confirm delete survey test
function Delete_Survey_Test(listitem) {
    swal({
        title: "Thông báo",
        text: "Bạn có chắc muốn xóa danh mục!",
        buttons: {
            cancel: {
                text: "Hủy",
                visible: true,
                className: "btn_delete_cancel",
            },
            confirm: {
                text: "Đồng ý",
                className: "btn_delete_confirm",
            },
        },
    }).then(function (isConfirm) {
        if (isConfirm) {
            var urlPostAction = "/Survey/QuestionManage/Test/Action.ashx"
            $.post(urlPostAction, { "do": "delete", "ItemID": JSON.stringify(listitem) }, function (data) {
                if (data.Error) {
                    console.log(data.Obj)
                    swal({
                        title: 'Thông báo',
                        text: data.Title,
                    })
                }
                else {
                    swal({
                        title: 'Thông báo',
                        text: data.Title,
                    })
                    TestList(10, 1);
                }
            });

        } else {
        }
    });
}

//Open model review survey test
function Review_Survey_Test(itemid) {
    var x = getWidth();
    urlFormReviewSurveyTest = "/Survey/QuestionManage/Test/AjaxFormReview.aspx?ItemID=" + itemid;
    $('body').modalmanager('loading');
    $('#dialog-form').load(urlFormReviewSurveyTest, function () {
        $('#dialog-form').modal({ width: x });
    });
}

function getWidth() {

    var autoWidth;

    var w = window.innerWidth
        || document.documentElement.clientWidth
        || document.body.clientWidth;

    if (w >= 1600) {
        autoWidth = 1500;
    }
    else if (w >= 1368 && w < 1600) {
        autoWidth = 1200;
    }
    else if (w >= 1280 && w < 1368) {
        autoWidth = 1000;
    }
    else if (w >= 1024 && w < 1280) {
        autoWidth = 900;
    }
    else if (w < 1024) {
        autoWidth = 700;
    }

    return autoWidth;
}
