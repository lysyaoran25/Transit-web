<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AjaxViewDetail.aspx.cs" Inherits="Viags.WebApp.Survey.ReportManage.AjaxViewDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="/Survey/assets/review.css" />
    <style>
        .total {
            color: white !important;
            font-weight: bold !important;
            background-color: rgb(0, 200, 83) !important;
        }
    </style>
</head>
<body>
    <form id="form-survey-report-detail" class="form-horizontal" action="#">
        <div class="create-survey-form-contain">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true"></button>
                <h4 class="modal-title text-center text-uppercase">Chi tiết <%=UserName %> tháng  <%=survey.Month %>/<%=survey.Year %></h4>
            </div>

            <div class="modal-body">
                <div>
                    <div class="col-sm-12" id="survey-contain-table-approval-result">
                        <label class="control-label col-sm-12 total" style="text-align: center !important;">Tổng điểm : <%=Math.Round(uc.GetTestTotal(ItemID, UserID, 0, 0, 1), 1) %>%</label>
                    </div>

                    <div class="col-sm-12" id="survey-contain-table-approval-result">
                        <div class="survey-table-contain table-responsive">
                            <%foreach (var category in survey.ListCategory)
                                { %>
                            <p class="survey-table-approval-show-category">
                                <%=category.Name %>
                            </p>
                            <div id="list-question-<%=category.ID %>">
                            </div>
                            <script>
                                LoadAjaxPage("/Survey/ReportManage/ChildDetail.aspx?ItemID=<%=category.ID%>&TestID=<%=ItemID%>&UserID=<%=UserID%>", "#list-question-<%=category.ID%>");
                            </script>
                            <%} %>
                        </div>
                    </div>
                    <%if (survey.Comments.Any())
                        {%>
                    <div class="col-sm-12" id="survey-contain-table-approval-result">
                        <div class="survey-table-contain table-responsive">
                            <%foreach (var comment in survey.Comments)
                                { %>
                            <p class="survey-table-approval-show-category">
                                <%=comment.Name %>
                            </p>
                            <textarea class="approval-comment" disabled="disabled"><%=surveyDA.GetComment(UserID,(int)user.LanhDaoID,ItemID,comment.ID) %></textarea>
                            <%} %>
                        </div>
                    </div>
                    <%} %>
                </div>

            </div>

            <div class="modal-footer">
                <div class="row">
                    <div class="col-sm-12 col-md-12 col-lg-12 survey-modal-footer">
                        <button type="button" id="btnCloseModal" class="btn btn-survey-exit" data-dismiss="modal">
                            Đóng
                        </button>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
