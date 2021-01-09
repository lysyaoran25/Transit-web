<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EvaluateList.aspx.cs" Inherits="Viags.WebApp.Survey.QuestionManage.Evaluate.EvaluateList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <table class="table table-striped" id="survey-table-evaluate-manage">
        <thead>
            <tr>
                <%--<th class="survey-select-header">
                    <input type="checkbox" />
                </th>--%>
                <th class="survey-order-header">STT</th>
                <th class="survey-date-header">Loại</th>
                <th class="survey-date-header">Điểm</th>
                <th class="survey-name-header">Tên Tiêu Chí</th>
            </tr>
        </thead>
        <tbody>
            <%Index = 1;
                if (Evaluates != null)
                {
                    foreach (var item in Evaluates.Detail)
                    {%>
            <tr>
                <%--<td class="survey-select-cell">
                    <input type="checkbox" />
                </td>--%>
                <td class="survey-order-cell"><%=Index %></td>
                <td class="survey-date-cell">
                    <%=item.Grade %>
                </td>
                <td class="survey-date-cell">
                    <%=item.Point %>
                </td>
                <td class="survey-name-cell"><%=item.Detail.Replace("\n", "<br>") %></td>
            </tr>
            <%
                        Index++;
                    }
                }
            %>
        </tbody>
    </table>
</body>
</html>

