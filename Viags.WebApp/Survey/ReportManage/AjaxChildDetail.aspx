<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AjaxChildDetail.aspx.cs" Inherits="Viags.WebApp.Survey.ReportManage.AjaxChildDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <table class="table table-striped" id="survey-table-report-detail">
        <thead>
            <tr>
                <th class="survey-order-header">STT</th>
                <th class="survey-name-header">MaNV</th>
                <th class="survey-name-header">HoTen</th>
                <th class="survey-name-header">Phòng ban</th>
                <th class="survey-name-header">Chức danh</th>
                <th class="survey-name-header">QLTT</th>
                <th class="survey-name-header">QLCC</th>
                <th class="survey-name-header">BGD</th>
                <th class="survey-action-header">Thao tác</th>
            </tr>
        </thead>
        <tbody>
            <%foreach (var item in report)
                {%>
            <tr>
                <td class="survey-order-cell"><%=Index %></td>
                <td class="survey-name-cell"><%=item.MaNV %></td>
                <td class="survey-name-cell"><%=item.Name %></td>
                <td class="survey-name-cell"><%=item.Deparment %></td>
                <td class="survey-name-cell"><%=item.Title %></td>
                <td class="survey-name-cell"><%=item.Manager1 %></td>
                <td class="survey-name-cell"><%=item.Manager2 %></td>
                <td class="survey-name-cell"><%=item.Manager3 %></td>
                <td class="survey-action-cell">
                    <button type="button" class="btn btn-survey-detail" onclick="open_view_report_detail(<%=item.TestID %>,<%=item.UserID %>)">
                        <span class="glyphicon glyphicon-search" aria-hidden="true"></span>
                    </button>
                </td>
            </tr>
            <%Index++;
                } %>
        </tbody>
    </table>
    <%=HtmlPager %>
</body>
</html>
