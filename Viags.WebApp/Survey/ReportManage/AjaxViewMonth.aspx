<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AjaxViewMonth.aspx.cs" Inherits="Viags.WebApp.Survey.ReportManage.AjaxViewMonth" %>

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
    <form id="form-survey-report-month" class="form-horizontal" action="#">
        <div class="create-survey-form-contain">
            <!--Header-->
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true"></button>
                <h4 class="modal-title text-center text-uppercase">Chi tiết <%=UserName %> tháng  <%=survey.Month %>/<%=survey.Year %></h4>
            </div>
            <!--Body -->

            <div class="modal-body">
                <div>
                    <div class="col-sm-12" id="survey-contain-table-approval-result">
                        <label class="control-label col-sm-12 total" style="text-align: center !important;">Tổng điểm : <%=Math.Round(uc.GetTestTotal(ItemID,UserID,0,0,1),1) %>%</label>
                    </div>

                    <div class="col-sm-12" id="survey-contain-table-approval-result">
                        <!-- DANH MỤC A -->
                        <div class="survey-table-contain table-responsive">
                            <table class="table table-striped" id="survey-table-approval-result-1">
                                <thead>
                                    <tr>
                                        <th class="survey-order-header">STT</th>
                                        <th class="survey-question-header">Danh mục</th>
                                        <th class="survey-point-header">Điểm</th>
                                    </tr>
                                </thead>
                                <tbody>

                                    <%            var index = 1;
                                        foreach (var category in survey.ListCategory)
                                        {%>
                                    <tr>
                                        <td class="survey-order-cell"><%=index %></td>
                                        <td class="survey-question-cell"><%=category.Name %>
                                        </td>
                                        <td class="survey-point-cell"><%=uc.GetCategoryTotal(ItemID,category.ID,UserID,0,1) +"%"%></td>
                                    </tr>
                                    <%index++;
                                        } %>
                                </tbody>
                            </table>
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

            <!--Footer -->
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
