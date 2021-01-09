var UrlAjaxFormChild = "/Survey/TestManage/AjaxFormChild.aspx"
var urlPostAction = "/Survey/TestManage/Action.ashx"
var urlSurveyDoTest = "/Survey/TestManage/AjaxFormTest.aspx"
var urlSurveySum = "/Survey/TestManage/AjaxFormTotal.aspx"

var renderEvaluate = "";
var ListQuestion = []
var ListComment = [];
function Load_Survey_Do_Test(id, manager, user, type) {
    LoadAjaxPage(urlSurveyDoTest + "?ItemID=" + id + "&ManagerID=" + manager + "&UserID=" + user + "&Type=" + type, '#survey-do-test');
}

function Load_Survey_Sum(id, user) {
    LoadAjaxPage(urlSurveySum + "?ItemID=" + id + "&UserID=" + user, "#survey-sum");
}

function RenderEvaluate(input, detail) {
    var res = detail.split("<>");
    var new_string = renderEvaluate;
    for (var i = 0; i < res.length; i++) {
        new_string = new_string.replace("data" + (i + 1), res[i]);
    }
    $(input).append(new_string);
}

function SubmitForm(issubmit) {
    //$("#SubmitFormTestFalse").attr("disabled", true)
    //$("#SubmitFormTestTrue").attr("disabled", true)
    //$("#btnCloseModal").attr("disabled", true)    

    $(".modal-footer button").css("disabled", 'true')
    var checkvalue = checkValue();
    var checkcomment = checkComment();
    if (checkvalue) {
        createMessage("Thông báo", "Chưa nhập kết quả");
        return false;
    }
    if (checkcomment) {
        createMessage("Thông báo", "Chưa nhập đánh giá");
        return false;
    }
    LoadData();
    LoadComment();
    $.post(urlPostAction, $("#form-survey-do-test").mySerialize() + "&isSubmit=" + issubmit + "&Details=" + JSON.stringify(ListQuestion) + "&Comments=" + JSON.stringify(ListComment), function (data) {
        {
            ListQuestion = []
            ListComment = [];
            if (data.Error) {
                createMessage("Có lỗi xảy ra", data.Title);
                console.log(data.Obj);
            }
            else {
                Load_Survey_Do_Test(data.ID, data.SoDong, data.SoTrang, data.TitleAPI)
                createMessage("Thông báo", data.Title);
            }
        }
    });
    return false;
}

function LoadResult(count, testid, userid, submit, manager, level, type) {
    $(".survey_result").each(function () {
        var categoryid = $(this).data("category")
        var div = $("#survey_result_div_" + categoryid);
        LoadAjaxPage(UrlAjaxFormChild + "?ItemID=" + categoryid + "&Count=" + count + "&TestID=" + testid + "&UserID=" + userid + "&isSubmit=" + submit + "&ManagerID=" + manager + "&Level=" + level + "&Type=" + type, div);
    })
}

function LoadData() {
    $('.Point[id="divpoint"]').each(function (e, v) {
        var categoryid = $(v).data("category");
        var questionid = $(v).data("question");
        var note = encodeURIComponent($(v).parent().parent().find(".survey-evaluate-note").val());
        var value = $(v).val().split("-");
        var obj = { "CategoryID": categoryid, "QuestionID": questionid, "Grade": value[0], "Point": value[1], "Note": note }
        ListQuestion.push(obj);
    })
}

function checkValue() {
    var check = false;
    $('.Point[id="divpoint"]').each(function (e, v) {
        var value = $(v).val()
        if (value == "") {
            check = true;
            return false;
        }
    })
    if (check) {
        return true;
    }
    return false;
}
function checkComment() {
    var check = false;
    $('.approval-comment').each(function (e, v) {
        var value = $(v).val()
        if (value == "") {
            check = true;
            return false;
        }
    })
    if (check) {
        return true;
    }
    return false;
}

function LoadComment() {
    $('.approval-comment').each(function (e, v) {
        var commentid = $(v).data("comment");
        var value = encodeURIComponent($(v).val());
        var obj = { "CommentID": commentid, "Detail1": value }
        ListComment.push(obj);
    })
}

function CloseSurveyForm() {
    window.close();
}