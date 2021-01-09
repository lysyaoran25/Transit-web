<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AjaxChild.aspx.cs" Inherits="Viags.WebApp.Survey.QuestionManage.Test.AjaxChild" %>

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
            </tr>
        </thead>
        <tbody>

            <%            var index = 1;
                foreach (var question in Questions)
                {%>
            <tr>
                <td class="survey-order-cell"><%=index %></td>
                <td class="survey-question-cell"><%=question.Name %>
                </td>
            </tr>
            <%index++;
                } %>
        </tbody>
    </table>
</body>
</html>
