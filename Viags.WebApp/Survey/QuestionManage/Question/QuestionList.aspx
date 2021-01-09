<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QuestionList.aspx.cs" Inherits="Viags.WebApp.Survey.QuestionManage.Question.QuestionList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <table class="table table-striped" id="survey-table-question-manage">
        <thead>
            <tr>
                <%--<th class="survey-select-header">
                    <input type="checkbox" />
                </th>--%>
                <th class="survey-order-header">STT</th>
                <th class="survey-name-header">Câu hỏi</th>
                <th class="survey-category-header">Danh mục</th>
                <th class="survey-date-header">Ngày tạo</th>
                <th class="survey-status-header">Trạng thái</th>
                <th class="survey-action-header">Thao tác</th>
            </tr>
        </thead>
        <tbody>
            <%foreach (var item in Questions)
                {%>
            <tr>
                <%--<td class="survey-select-cell">
                    <input type="checkbox" value="<%=item.ID %>" />
                </td>--%>
                <td class="survey-order-cell"><%=Index %></td>
                <td class="survey-name-cell"><%=item.Name %></td>
                <td class="survey-category-cell">
                    <%=item.CategoryName %>
                </td>
                <td class="survey-date-cell">
                    <%=(item.CreateDate.HasValue?item.CreateDate.Value.ToString("dd-MM-yyyy"):string.Empty) %>
                </td>
                <td class="survey-status-cell">
                    <label class="switch">
                        <input type="checkbox" id="<%="Question_Status_"+item.ID %>" <%=item.IsActive == true ?"checked" :"" %> onchange="QuestionActive(<%=item.ID %>,this)" />
                        <span class="slider round"></span>
                    </label>
                </td>
                <td class="survey-action-cell">
                    <button type="button" class="btn btn-survey-edit" onclick="Edit_Survey_Question(<%=item.ID %>)">
                        <span class="glyphicon glyphicon-edit" aria-hidden="true"></span>
                    </button>
                    <button type="button" class="btn btn-survey-delete" onclick="Delete_Survey_Question(<%=item.ID %>)">
                        <span class="glyphicon glyphicon-trash" aria-hidden="true"></span>
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
