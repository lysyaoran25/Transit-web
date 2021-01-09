<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestList.aspx.cs" Inherits="Viags.WebApp.Survey.QuestionManage.Test.TestList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <table class="table table-striped" id="survey-table-test-manage">
        <thead>
            <tr>
                <%--<th class="survey-select-header">
                    <input type="checkbox" />
                </th>--%>
                <th class="survey-order-header">STT</th>
                <th class="survey-name-header">Tên</th>
                <th class="survey-date-header">Tháng</th>
                <th class="survey-date-header">Năm</th>
                <th class="survey-quantity-header">Số câu</th>
                <th class="survey-action-header">Thao tác</th>
            </tr>
        </thead>
        <tbody>
            <%foreach (var item in Tests)
                { %>
            <tr>
                <%--<td class="survey-select-cell">
                    <input type="checkbox" />
                </td>--%>
                <td class="survey-order-cell"><%=Index %></td>
                <td class="survey-name-cell"><%=item.Name %></td>
                <td class="survey-date-cell">
                    <%=item.Month %>
                </td>
                <td class="survey-date-cell">
                    <%=item.Year %>
                </td>
                <td class="survey-quantity-cell"><%=item.NumberQuestion%></td>

                <td class="survey-action-cell">
                    <%if (CheckTest(item.ID) == false)
                        {%>
                    <button type="button" class="btn btn-survey-edit" onclick="Edit_Survey_Test(<%=item.ID %>)">
                        <span class="glyphicon glyphicon-edit" aria-hidden="true"></span>
                    </button>
                    <%} %>
                    <button type="button" class="btn btn-survey-delete" onclick="Delete_Survey_Test(<%=item.ID %>)">
                        <span class="glyphicon glyphicon-trash" aria-hidden="true"></span>
                    </button>
                    <button type="button" class="btn btn-survey-detail" onclick="Review_Survey_Test(<%=item.ID %>)">
                        <span class="glyphicon glyphicon-search" aria-hidden="true"></span>
                    </button>
                </td>
            </tr>
            <% 
                    Index++;
                }
            %>
        </tbody>
    </table>
    <%=HtmlPager %>
</body>
</html>
