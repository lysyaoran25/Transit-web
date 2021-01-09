<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChildDetail.aspx.cs" Inherits="Viags.WebApp.Survey.ReportManage.ChildDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <table class="table table-striped" id="survey-table-approval-result-1">
        <thead>
            <tr>
                <th class="survey-order-header">STT</th>
                <th class="survey-question-header">Nội dung</th>
                <th class="survey-point-header">Điểm</th>
            </tr>
        </thead>
        <tbody>

            <%            var index = 1;
                foreach (var question in Questions)
                {
                    var point = uc.GetPoint(TestID, ItemID, question.ID, UserID, Manager);
            %>
            <tr>
                <td class="survey-order-cell"><%=index %></td>
                <td class="survey-question-cell"><%=question.Name %>
                </td>
                <td class="survey-point-cell"><%=point +(!string.IsNullOrEmpty(point) ?"%":"")%></td>
            </tr>
            <%index++;
                }
                var categorypoint = uc.GetCategoryTotal(TestID, ItemID, UserID, 0, 1);%>
            <tr>
                <td colspan="2" class="survey-category-cell point-total">điểm</td>
                <td class="survey-point-cell point-total"><%=categorypoint +(categorypoint>0 ?"%":"")%></td>
            </tr>
        </tbody>
    </table>
</body>
</html>
