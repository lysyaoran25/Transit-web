var urlPostAction_test = "/Survey/QuestionManage/Test/Action.ashx";
var urlPostAction_category = "/Survey/QuestionManage/Category/Action.ashx";
var urlPostAction_question = '/Survey/QuestionManage/Question/Action.ashx';
var urlPostAction_evaluate = '/Survey/QuestionManage/Evaluate/Action.ashx';
var ListEvaluate = []
var ListQuestion = []
var ListTest = []
var ListTest_Evaluate = []
function SubmitForm(issubmit) {
    $("#submitFormTrue").attr("disabled", true);
    $("#submitFormFalse").attr("disabled", true);
    $("#btnCloseModal").attr("disabled", true);

    $("#isSubmit").val(issubmit)
    $("#Submit").click();


}
$("#form-survey-test").validate({
    rules: {
        Name: { required: true, minlength: 1, maxlength: 255 },
    },
    submitHandler: function () {
        LoadData_Test();
        LoadData_Test_Evaluate();
        $.post(urlPostAction_test, $("#form-survey-test").mySerialize() + "&listquestionid=" + ListTest.join(',') + "&EvaluateDetail=" + JSON.stringify(ListTest_Evaluate), function (data) {
            {
                $("#submitFormTrue").attr("disabled", false);
                $("#submitFormFalse").attr("disabled", false);
                $("#btnCloseModal").attr("disabled", false);
                ListTest = []
                ListTest_Evaluate = []
                if (data.Error) {
                    createMessage("Có lỗi xảy ra", data.Title);
                    console.log(data.Obj);
                    $("#btnCloseModal").click();
                }
                else {
                    createMessage("Thông báo", data.Title);
                    $("#btnCloseModal").click();
                    TestList(10, 1);
                }
            }
        });
        return false;
    }
});
// #region Test


function ChangeArea(surveydepartment) {
    var area = $("#Area").val();
    var listselect = [];
    $.ajax({
        type: "POST",
        url: "/Survey/QuestionManage/Test/AjaxFormCreate.aspx/ChangeArea",
        data: "{listarea:'" + area + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            if (surveydepartment !== "")
                data.d.forEach(element => {
                    if (surveydepartment.includes(element.id)) {
                        listselect.push(element);
                    }
                });
            $('#Department').select2({
                multiple: true,
                data: data.d,
            })
        },
        complete: function (data) {
            $("#Department").select2('data', listselect);
        }
    });
}

function LoadQuestion(input) {
    var category = $(input).val();
    var name = $(input).text();
    $.ajax({
        type: "POST",
        url: "/Survey/QuestionManage/Test/AjaxFormCreate.aspx/LoadQuestion_Add",
        data: "{category:'" + category + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (msg) {
            $("#question").html(msg.d);
        }
    });
}

function LoadData_Test() {
    $('.surveytest-question').each(function (e, v) {
        if ($(v).is(":checked")) {
            ListTest.push($(v).data('question'))
        }
    })
}
function LoadData_Test_Evaluate() {
    $(".test_detail").each(function (e, v) {
        var obj = { "Name": encodeURIComponent($(v).val()) }
        ListTest_Evaluate.push(obj);
    });
}
function AddForm() {
    var html = "";
    html += '<div class="form-inline row">'
    html += '<label class="col-sm-1"></label>';
    html += '<input type="text" class="form-control col-sm-9 test_detail" />'
    html += '<button type="button" class="btn btn-survey-delete col-sm-1" onclick="Survey_Remove_Point_Evaluate(this)" >'
    html += '<span class="glyphicon glyphicon-trash" aria-hidden="true"></span></button >'
    html += '</div><br />'
    $("#Evaluate").append(html);
}

function Survey_Remove_Point_Evaluate(input) {
    var parent = $(input).parent();
    parent.remove();
}
// #endregion


// #region question
$("#form-survey-question").validate({
    rules: {
        DanhMuc: { required: true },
        NoiDung: { required: true }
    },
    submitHandler: function () {
        //onSubmit
        LoadData_Question();
        $.post(urlPostAction_question, $("#form-survey-question").mySerialize() + "&Details=" + JSON.stringify(ListQuestion), function (data) {
            ListQuestion = [];
            if (data.Error) {
                createMessage("Có lỗi xảy ra", data.Title);
                console.log(data.Obj);
                $("#btnCloseModal").click();
            }
            else {
                createMessage("Thông báo", data.Title);
                $("#btnCloseModal").click();
                QuestionList(10, 1);
            }
        });
        return false;
    }
});

// Load Question
function LoadData_Question() {
    $(".answer-r").find(".form-inline").each(function (e, v) {
        var detail = encodeURIComponent($(v).find(".question_detail").val());
        var point = $(v).find(".question_grade").val();
        var obj = { "Detail": detail, "Grade": point }
        ListQuestion.push(obj);
    });
}

// #endregion


// #region category

$("#form-survey-category").validate({
    rules: {
        Name: { required: true, minlength: 1, maxlength: 255 },
    },
    submitHandler: function () {
        $.post(urlPostAction_category, $("#form-survey-category").mySerialize(), function (data) {
            {
                if (data.Error) {
                    createMessage("<%=Resources.TaiKhoan.lblDaCoLoiXayRa%>", data.Title);
                    console.log(data.Obj);
                    $("#btnCloseModal").click();
                }
                else {
                    createMessage("Thông báo", data.Title);
                    $("#btnCloseModal").click();
                    CategoryList(10, 1);
                }
            }
        });
        return false;
    }
});
// #endregion

// #region Evaluate
$("#form-survey-evaluate").validate({
    rules: {
        Month: { required: true, min: 1, max: 12 },
        Year: { required: true },
        Number: { required: true },
    },
    submitHandler: function () {
        LoadData_Evaluate()
        $.post(urlPostAction_evaluate, $("#form-survey-evaluate").mySerialize() + "&Details=" + JSON.stringify(ListEvaluate), function (data) {
            {
                ListEvaluate = [];
                if (data.Error) {
                    createMessage("Thông báo", data.Title);
                    console.log(data.Obj);
                    $("#btnCloseModal").click();
                }
                else {
                    createMessage("Thông báo", data.Title);
                    $("#btnCloseModal").click();
                    EvaluateList(10, 1);
                }
            }
        });
        return false;
    }
});
// Load evaluate
function LoadData_Evaluate() {
    $(".answer-r").find(".form-inline").each(function (e, v) {
        var detail = encodeURIComponent($(v).find(".evaluate_detail").val());
        var point = $(v).find(".evaluate_point").val();
        var grade = $(v).find(".evaluate_grade").val();

        var obj = { "Detail": detail, "Point": point, "Grade": grade }
        ListEvaluate.push(obj);
    });
}
// #endregion