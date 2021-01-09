<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AjaxChildMonth.aspx.cs" Inherits="Viags.WebApp.Survey.ReportManage.AjaxChildMonth" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <table class="table table-striped main-table" id="survey-table-report-month">
        <thead>
            <tr>
                <th class="survey-order-header">STT</th>
                <th class="survey-name-header">MaNV</th>
                <th class="survey-name-header">HoTen</th>
                <th class="survey-name-header">Phòng ban</th>
                <th class="survey-name-header">Khu vực</th>
                <th class="survey-point-header">Điểm</th>
                <th class="survey-action-header">Thao tác</th>
            </tr>
        </thead>
        <tbody>
            <%foreach (var item in report)
                {
                    var point = Math.Round(uc.GetTestTotal((int)item.TestID, (int)item.UserID, 0, 0, 1), 1);%>
            <tr>
                <td class="survey-order-cell"><%=Index %></td>
                <td class="survey-name-cell "><%=item.MaNV %></td>
                <td class="survey-name-cell "><%=item.Name %></td>
                <td class="survey-name-cell "><%=item.Deparment %></td>
                <td class="survey-name-cell "><%=item.Area %></td>
                <td class="survey-point-cell"><%=point + (point >0 ? "%":"") %></td>
                <td class="survey-action-cell">
                    <button type="button" class="btn btn-survey-detail" onclick="open_view_report_month(<%=item.TestID %>,<%=item.UserID %>)">
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
