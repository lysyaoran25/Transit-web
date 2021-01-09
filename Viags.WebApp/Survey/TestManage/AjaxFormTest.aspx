<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AjaxFormTest.aspx.cs" Inherits="Viags.WebApp.Survey.TestManage.AjaxFormTest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="/Survey/assets/uc.css" />
    <link rel="stylesheet" type="text/css" href="/Survey/assets/review.css" />
    <script>
        $(document).ready(function () {

            renderEvaluate = "<%=render%>";
        })
    </script>
</head>
<body>
    <form id="form-survey-do-test" class="form-horizontal" action="#">
        <input type="hidden" id="do" name="do" value="add" />
        <input type="hidden" id="ItemID" name="ItemID" value="<%=ItemID %>" />
        <input type="hidden" id="UserID" name="UserID" value="<%=UserTest.ID %>" />
        <input type="hidden" id="ManagerID" name="ManagerID" value="<%=ManagerID %>" />
        <input type="hidden" id="Type" name="Type" value="<%=Type %>" />
        <div class="create-survey-form-contain">
            <!--Body -->
            <div class="modal-body">

                <!-- Bảng thông tin-->
                <div id="survey-contain-table-approval-title">
                    <div class="row">
                        <div class="col-xs-6 col-sm-1 col-md-1 avt-contain">
                            <a href="#" class="thumbnail">
                                <img class="rounded-circle z-depth-2" src="https://www.w3schools.com/w3images/avatar2.png" />
                            </a>
                        </div>
                        <div class="col-xs-6 col-sm-11 col-md-11 inf-contain">
                            <div class="list-group">
                                <h3 class="list-group-item-heading">
                                    <b>Họ tên:</b> <%=UserTest.TenHienThi +" - "+UserTest.MaNV %>
                                </h3>
                                <div class="row">
                                    <div class="col-xs-12 col-sm-4 col-md-4">
                                        <a href="#" class="list-group-item"><b>Phòng ban:</b> <%=UserTest.TenPhongBan +"-"+ UserTest.TenDonVi %>
                                        </a>
                                        <a href="#" class="list-group-item"><b>Cấp QLTT</b> <%=ListManager.Name1 ?? string.Empty %>
                                        </a>
                                    </div>
                                    <div class="col-xs-12 col-sm-4 col-md-4">
                                        <a href="#" class="list-group-item"><b>Chức danh:</b> <%=UserTest.TenChucVu %>
                                        </a>
                                        <a href="#" class="list-group-item"><b>QLCC:</b> <%=ListManager.Name2 ?? string.Empty %>
                                        </a>
                                    </div>
                                    <%--<div class="col-xs-12 col-sm-4 col-md-4">
                                        <a href="#" class="list-group-item"><b>Thâm niên:</b> 1 năm
                                        </a>
                                        <a href="#" class="list-group-item"><b>Chức danh:</b> TN IT
                                        </a>
                                    </div>--%>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <!-- Tổng điểm-->
                <%if (isSubmit)
                    {%>
                <div id="survey-contain-table-approval-argee">
                    <h3 class="survey-title">TỔNG ĐIỂM</h3>
                    <div class="survey-table-contain table-responsive" id="survey-sum">
                    </div>
                </div>
                <%} %>

                <!-- Bảng kết quả bài đánh giá -->
                <div id="survey-contain-table-approval-result">
                    <h3 class="survey-title">BẢNG ĐÁNH GIÁ THÁI ĐỘ HÀNH VI - THÁNG <%=Survey.Month %>/<%=Survey.Year %></h3>
                    <%foreach (var category in Survey.ListCategory)
                        {%>
                    <div class="survey-table-contain table-responsive">
                        <!-- Show category-->
                        <p class="survey-table-approval-show-category">
                            <%=category.Name %>
                        </p>
                        <!-- Show result-->
                        <div class="survey_result" id="survey_result_div_<%=category.ID %>" data-category="<%=category.ID %>">
                            <p>Category <%=category.ID %></p>
                        </div>
                    </div>
                    <%}
                    %>
                </div>
                <!-- Bảng phát triển thêm-->
                <%
                    var manager = (int)surveyDA.GetManagerTest(ItemID, UserID).Manager1;
                    if (manager != CurrentUser.ID && isSubmit != true || UserTest.ID == CurrentUser.ID)
                    {%>
                <%}
                    else
                    {
                        foreach (var comment in Survey.Comments)
                        {%>
                <div id="survey-contain-table-approval-comment-1" class="element">
                    <h3 class="survey-title"><%=comment.Name %></h3>
                    <div class="survey-table-contain table-responsive">
                        <table class="table table-striped" id="survey-table-comment-1">
                            <thead>
                                <tr>
                                    <%if (isSubmit || ValidateUser == false)
                                        {%>
                                    <th class="survey-comment-header">Quản lý trực tiêp đánh giá</th>
                                    <%}
                                        else
                                        {%>
                                    <th class="survey-comment-header">đánh giá</th>
                                    <%} %>
                                </tr>
                            </thead>
                            <tbody>
                                <%if (isSubmit || ValidateUser == false)
                                    {%>
                                <tr>
                                    <td class="survey-comment-cell">
                                        <textarea rows="5" class="approval-comment" disabled="disabled" data-comment="<%=comment.ID %>"><%=GetComment(comment.ID, UserID, manager) %></textarea>
                                    </td>
                                </tr>
                                <%}
                                    else
                                    { %>
                                <tr>
                                    <td class="survey-comment-cell">
                                        <textarea rows="5" class="approval-comment" data-comment="<%=comment.ID %>"><%=GetComment(comment.ID, UserID, manager) %></textarea>
                                    </td>
                                </tr>

                                <%} %>
                            </tbody>
                        </table>
                    </div>
                </div>
                <%}
                    }%>
            </div>
            <!--Footer -->
            <div class="modal-footer">
                <div class="row">
                    <div class="col-sm-12 col-md-12 col-lg-12 survey-modal-footer">
                        <button type="button" id="btnCloseModal" class="btn btn-survey-exit" onclick="CloseSurveyForm()">
                            Đóng
                        </button>
                        <%if (!isSubmit && ValidateUser == true)
                            {%>
                        <button type="button" id="SubmitFormTestFalse" class="btn btn-survey-save" onclick="SubmitForm(false)">
                            Lưu nháp
                        </button>
                        <button type="button" id="SubmitFormTestTrue" class="btn btn-survey-save" onclick="SubmitForm(true)">
                            Lưu
                        </button>
                        <%} %>
                    </div>
                </div>

            </div>
        </div>
    </form>
</body>
</html>

<script>
    LoadResult(<%=Evaluate.Count()%>,<%=ItemID%>,<%=UserTest.ID%>, '<%=isSubmit%>',<%=ManagerID%>,<%=UserTest.Level%>,'<%=Type%>');
    Load_Survey_Sum(<%=ItemID%>,<%=UserTest.ID%>)
</script>
