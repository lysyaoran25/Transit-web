//Onload
window.onload = function () {
    RefreshTabQuestionManage();
}

//List URL
urlTabSurvey_QuestionManage = "/Survey/QuestionManage/AjaxList.aspx";
urlTabSurvey_TestManage = "/Survey/TestManage/AjaxList.aspx?type=do";
urlTabSurvey_ApprovalManage = "/Survey/TestManage/AjaxList.aspx?type=approve";
urlTabSurvey_ReportManage = "/Survey/ReportManage/AjaxList.aspx";


urlFormApprovalSurvey = "/Survey/ApprovalManage/AjaxFormApproval.aspx";

//Change TAB

function ChangeToTabQuestionManage() {
    RefreshTabQuestionManage();
}
function ChangeToTabTestManage() {
    RefreshTabTestManage();
}
function ChangeToTabApprovalManage() {
    RefreshTabApprovalManage();
}
function ChangeToTabReportManage() {
    RefreshTabReportManage();
}

//Refresh TAB

function RefreshTabQuestionManage() {
    //initAjaxLoad(urlTabSurvey_QuestionManage, '#gridview_QuestionManage', 'grid_QuestionManage');
    LoadAjaxPage(urlTabSurvey_QuestionManage, '#gridview_QuestionManage');
    $("#grid_TestManage").html("");
    $("#grid_ApprovalManage").html("");
    $("#grid_ReportManage").html("");
}
function RefreshTabTestManage() {
    //initAjaxLoad(urlTabSurvey_TestManage, '#gridview_TestManage', 'grid_TestManage');
    LoadAjaxPage(urlTabSurvey_TestManage, '#gridview_TestManage');
    $("#grid_QuestionManage").html("");
    $("#grid_ApprovalManage").html("");
    $("#grid_ReportManage").html("");
}
function RefreshTabApprovalManage() {
    //initAjaxLoad(urlTabSurvey_ApprovalManage, '#gridview_ApprovalManage', 'grid_ApprovalManage');
    LoadAjaxPage(urlTabSurvey_ApprovalManage, '#gridview_ApprovalManage');
    $("#grid_QuestionManage").html("");
    $("#grid_TestManage").html("");
    $("#grid_ReportManage").html("");
}
function RefreshTabReportManage() {
    //initAjaxLoad(urlTabSurvey_ReportManage, '#gridview_ReportManage', 'grid_ReportManage');
    LoadAjaxPage(urlTabSurvey_ReportManage, '#gridview_ReportManage');
    $("#grid_QuestionManage").html("");
    $("#grid_TestManage").html("");
    $("#grid_ApprovalManage").html("");
}
function RefreshAllTab() {
    RefreshTabQuestionManage();
    RefreshTabTestManage();
    RefreshTabApprovalManage();
    RefreshTabReportManage();
}

