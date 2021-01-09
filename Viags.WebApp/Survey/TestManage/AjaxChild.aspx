<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AjaxChild.aspx.cs" Inherits="Viags.WebApp.Survey.TestManage.AjaxChild" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <table class="table table-striped" id="survey-table-test">
        <thead>
            <tr>
                <th class="survey-order-header">STT</th>
                <th class="survey-name-header">Tên</th>
                <th class="survey-name-header">NV</th>
                <th class="survey-name-header">Phòng ban</th>
                <th class="survey-name-header">Khu vực</th>
                <th class="survey-date-header">Tháng</th>
                <th class="survey-date-header">Năm</th>
                <th class="survey-point-header">Điểm</th>
                <th class="survey-action-header">Trạng thái</th>
                <th class="survey-action-header">Thao tác</th>
            </tr>
        </thead>
        <tbody>
            <%foreach (var item in Surveys)
                {
            %>
            <tr>
                <td class="survey-order-cell"><%=Index %></td>
                <td class="survey-name-cell"><%=item.Name %></td>
                <td class="survey-name-cell"><%=(string.IsNullOrEmpty(item.UserCode)?"":(item.UserCode + " - ")) +  item.Username %></td>
                <td class="survey-name-cell"><%=item.Department %></td>
                <td class="survey-name-cell"><%=item.Area %></td>
                <td class="survey-date-cell"><%=item.Month%></td>
                <td class="survey-date-cell"><%=item.Year %></td>
                <%if (type == "approve")
                    {
                        var point = uc.GetTestTotal(item.ID, (int)item.UserID, 0, 1, 1);
                %>
                <td class="survey-point-cell"><%=Math.Round(point,1) + (point > 0 ? "%" : "") %></td>
                <%}
                    else
                    {
                        var point = uc.GetTestTotal(item.ID, CurrentUser.ID, 0, 1, 1);
                %>
                <td class="survey-point-cell"><%=Math.Round(point,1) + (point > 0 ? "%" : "") %></td>

                <%} %>
                <td class="survey-status-cell"><%=(type=="do" && item.Type!="External" ?  CheckStatus(item.ID,CurrentUser.ID) : CheckStatus(item.ID,(int)item.UserID)) %></td>
                <td class="survey-action-cell">
                    <%if (type == "do")
                        {%>
                    <%if (item.Type == "Internal")
                        {%>
                    <button type="button" class="btn btn-survey-start" onclick="OpenSurveyForm(<%=item.ID %>,'','','<%=item.Type %>')">
                        <span class="glyphicon glyphicon-play" aria-hidden="true"></span>
                    </button>
                    <%}
                        else
                        { %>
                    <button type="button" class="btn btn-survey-start" onclick="OpenSurveyForm(<%=item.ID %>,'<%=item.UserID %>','','<%=item.Type %>')">
                        <span class="glyphicon glyphicon-play" aria-hidden="true"></span>
                    </button>
                    <%}
                        }
                        else
                        { %>
                    <button type="button" class="btn btn-survey-start" onclick="OpenSurveyForm(<%=item.ID %>,<%=item.UserID %>,<%=CurrentUser.ID %>,'<%=item.Type %>')">
                        <span class="glyphicon glyphicon-play" aria-hidden="true"></span>
                    </button>
                    <%} %>
                </td>
            </tr>
            <%Index++;
                } %>
        </tbody>
    </table>
    <%=HtmlPager %>
</body>
</html>
