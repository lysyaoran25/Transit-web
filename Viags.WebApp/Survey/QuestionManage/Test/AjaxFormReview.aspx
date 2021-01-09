<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AjaxFormReview.aspx.cs" Inherits="Viags.WebApp.Survey.QuestionManage.Test.AjaxFormReview" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="/Survey/assets/review.css" />
</head>
<body>
    <form id="form-survey-approval" class="form-horizontal" action="#">
        <div class="create-survey-form-contain">
            <!--Header-->
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true"></button>
                <h4 class="modal-title text-center text-uppercase">REVIEW</h4>
            </div>
            <!--Body -->
            <div class="modal-body">
                <div id="survey-contain-table-approval-result">
                    <div class="12">
                        <label class="control-label col-sm-2 " style="text-align: left !important">Khu vực:</label>
                        <label class="control-label col-sm-10" style="word-wrap: break-word; text-align: left !important"><%=Area %></label>
                    </div>
                    <div class="row">
                        <label class="control-label col-sm-2" style="text-align: left !important">phòng ban:</label>
                        <label class="control-label col-sm-10" style="word-wrap: break-word; text-align: left !important"><%=Department %></label>
                    </div>
                    <div class="row">
                        <label class="control-label col-sm-2" style="text-align: left !important">Nhân viên:</label>
                        <label class="control-label col-sm-10" style="word-wrap: break-word; text-align: left !important"><%=Users %></label>
                    </div>
                </div>
                <!-- Bảng kết quả bài đánh giá -->
                <div id="survey-contain-table-approval-result">
                    <!-- DANH MỤC A -->
                    <div class="survey-table-contain table-responsive">
                        <!-- Show category-->
                        <%foreach (var category in Test.ListCategory)
                            { %>
                        <p class="survey-table-approval-show-category">
                            <%=category.Name %>
                        </p>
                        <!-- Show result-->
                        <div id="list-question-<%=category.ID %>">
                        </div>
                        <script>
                            LoadAjaxPage("/Survey/QuestionManage/Test/AjaxChild.aspx?ItemID=<%=category.ID%>&TestID=<%=ItemID%>", "#list-question-<%=category.ID%>");
                        </script>
                        <%} %>
                    </div>
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
