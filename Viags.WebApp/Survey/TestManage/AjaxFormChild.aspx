<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AjaxFormChild.aspx.cs" Inherits="Viags.WebApp.Survey.TestManage.AjaxFormChild" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script>
        $(".selectpoint-" +<%=ItemID%>).select2({
            minimumResultsForSearch: Infinity
        });
    </script>
</head>
<body>
    <table class="table table-striped" id="survey-table-approval-result-1">
        <thead>
            <tr>
                <th class="survey-order-header">STT</th>
                <th class="survey-question-header">Nội dung</th>
                <th class="survey-answer-header">Tiêu chí - Diễn giải</th>
                <%if (isSubmit || ValidateUser == false)
                    {%>
                <th class="survey-evaluate-header">NV</th>
                <th class="survey-evaluate-header">QLTT</th>
                <th class="survey-evaluate-header">QLCC</th>
                <%if (Level >= 3)
                    {%>
                <th class="survey-evaluate-header">BGĐ</th>

                <%}
                    }
                    else
                    {
                        if ((surveyDA.BGD.Contains(CurrentUser.ID) && (manager.Manager1 != CurrentUser.ID && manager.Manager2 != CurrentUser.ID && manager.Manager3 != CurrentUser.ID)) || manager.Manager2 == CurrentUser.ID)
                        { %>
                <th class="survey-evaluate-header">NV</th>
                <th class="survey-evaluate-header">QLTT</th>
                <%if (manager.Manager2 != CurrentUser.ID)
                    {%>
                <th class="survey-evaluate-header">QLCC</th>

                <%} %>
                <th class="survey-evaluate-header">Đánh giá</th>
                <th class="survey-evaluate-header">Ghi chú</th>
                <%}
                    else
                    { %>
                <th class="survey-evaluate-header">Đánh giá</th>
                <th class="survey-evaluate-header">Ghi chú</th>
                <%}
                    }
                %>
            </tr>
        </thead>
        <tbody>
            <%Index = 1;
                foreach (var question in Questions)
                {
                    var point1 = uc.GetPoint(TestID, ItemID, question.ID, UserID, -1);
                    var point2 = uc.GetPoint(TestID, ItemID, question.ID, UserID, (int)manager.Manager1);
                    var point3 = uc.GetPoint(TestID, ItemID, question.ID, UserID, (int)manager.Manager2);%>
            <tr>
                <td class="survey-order-cell"><%=Index %></td>
                <td class="survey-question-cell"><%=question.Name %>
                </td>
                <td class="survey-answer-cell" id="survey-evaluate-div-<%=question.ID %>">
                    <script>
                        RenderEvaluate("#survey-evaluate-div-" +<%=question.ID%>,'<%=string.Join("<>",question.Detail.Select(p=>p.Detail.Replace("\n", "<br>")))%>');
                    </script>
                </td>
                <%if (isSubmit || ValidateUser == false)
                    {
                %>
                <td class="survey-evaluate-cell survey-evaluate-point">
                    <p tooltip-position='left' data-c-tooltip="<%=uc.GetNote(TestID, ItemID, question.ID, UserID, -1) %>"><%=point1 + (!string.IsNullOrEmpty(point1) ? "%" : "")%></p>
                </td>
                <td class="survey-evaluate-cell survey-evaluate-point">
                    <p tooltip-position='left' data-c-tooltip="<%=uc.GetNote(TestID, ItemID, question.ID, UserID, (int)manager.Manager1) %>"><%=point2 + (!string.IsNullOrEmpty(point2) ? "%" : "")%></p>
                </td>
                <td class="survey-evaluate-cell survey-evaluate-point">
                    <p tooltip-position='left' data-c-tooltip="<%=uc.GetNote(TestID, ItemID, question.ID, UserID, (int)manager.Manager2) %>"><%=point3 + (!string.IsNullOrEmpty(point3) ? "%" : "")%></p>
                </td>
                <%if (Level >= 3)
                    {
                        var point4 = uc.GetPoint(TestID, ItemID, question.ID, UserID, (int)manager.Manager3);%>
                <td class="survey-evaluate-cell survey-evaluate-point">
                    <p tooltip-position='left' data-c-tooltip="<%=uc.GetNote(TestID, ItemID, question.ID, UserID, (int)manager.Manager3) %>"><%= point4 + (!string.IsNullOrEmpty(point4) ? "%" : "")%></p>
                </td>
                <%}
                    }
                    else
                    {
                        if (surveyDA.BGD.Contains(CurrentUser.ID) && (manager.Manager1 != CurrentUser.ID && manager.Manager2 != CurrentUser.ID && manager.Manager3 != CurrentUser.ID) || manager.Manager2 == CurrentUser.ID)
                        {%>
                <td class="survey-evaluate-cell survey-evaluate-point">
                    <p tooltip-position='left' data-c-tooltip="<%=uc.GetNote(TestID, ItemID, question.ID, UserID, -1) %>"><%=point1 + (!string.IsNullOrEmpty(point1) ? "%" : "")%></p>
                </td>
                <td class="survey-evaluate-cell survey-evaluate-point">
                    <p tooltip-position='left' data-c-tooltip="<%=uc.GetNote(TestID, ItemID, question.ID, UserID, (int)manager.Manager1) %>"><%=point2 + (!string.IsNullOrEmpty(point2) ? "%" : "")%></p>
                </td>
                <%if (manager.Manager2 != CurrentUser.ID)
                    {%>
                <td class="survey-evaluate-cell survey-evaluate-point">
                    <p tooltip-position='left' data-c-tooltip="<%=uc.GetNote(TestID, ItemID, question.ID, UserID, (int)manager.Manager2) %>"><%=point3 + (!string.IsNullOrEmpty(point3) ? "%" : "")%></p>
                </td>
                <%} %>
                <td class="survey-evaluate-cell survey-evaluate-point"><%=RenderSelect(ItemID, question.ID, count)%></td>
                <td class="survey-evaluate-cell ">
                    <textarea rows="2" class="survey-evaluate-note"><%=GetNote(TestID, ItemID, question.ID, UserID) %></textarea>
                </td>
                <%}
                    else
                    { %>

                <td class="survey-evaluate-cell survey-evaluate-point"><%=RenderSelect(ItemID, question.ID, count)%></td>
                <td class="survey-evaluate-cell ">
                    <textarea rows="2" class="survey-evaluate-note"><%=GetNote(TestID, ItemID, question.ID, UserID) %></textarea>
                </td>
                <%}
                    }%>
            </tr>
            <%Index++;
                } %>
        </tbody>
    </table>
</body>
</html>
