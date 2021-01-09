<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AjaxFormTotal.aspx.cs" Inherits="Viags.WebApp.Survey.TestManage.AjaxFormTotal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <table class="table table-striped" id="survey-table-sum">
        <thead>
            <tr>
                <th class="survey-order-header">STT</th>
                <th class="survey-category-header">Danh mục</th>
                <th class="survey-point-header">Điểm NV (%)</th>
                <th class="survey-point-header">Điểm QLTT (%)</th>
                <th class="survey-point-header">Điểm QLCC (%)</th>
                <th class="survey-point-header">Điểm BGĐ (%)</th>
            </tr>
        </thead>
        <tbody>
            <% Index = 1;
                foreach (var item in Survey.ListCategory)
                {
                    var categorytotal1 = uc.GetCategoryTotal(ItemID, item.ID, UserID, 1);
                    var categorytotal2 = uc.GetCategoryTotal(ItemID, item.ID, UserID, 2);
                    var categorytotal3 = uc.GetCategoryTotal(ItemID, item.ID, UserID, 3);
                    var categorytotal4 = uc.GetCategoryTotal(ItemID, item.ID, UserID, 4);
            %>
            <tr>
                <td class="survey-order-cell"><%=Index %></td>
                <td class="survey-category-cell"><%=item.Name %></td>
                <td class="survey-point-cell"><%=categorytotal1 + (categorytotal1 > 0 ?"%" : "")%></td>
                <td class="survey-point-cell"><%=categorytotal2 + (categorytotal2 > 0 ?"%" : "")%></td>
                <td class="survey-point-cell"><%=categorytotal3 + (categorytotal3 > 0 ?"%" : "")%></td>
                <td class="survey-point-cell"><%=categorytotal4 + (categorytotal4 > 0 ?"%" : "")%></td>

            </tr>
            <% Index++;
                }

                var total1 = uc.GetTestTotal(ItemID, UserID, 1);
                var total2 = uc.GetTestTotal(ItemID, UserID, 2);
                var total3 = uc.GetTestTotal(ItemID, UserID, 3);
                var total4 = uc.GetTestTotal(ItemID, UserID, 4);%>
            <tr>
                <td colspan="2" class="survey-category-cell point-total">Điểm trung bình</td>
                <td class="survey-point-cell point-total"><%=Math.Round(total1 / ((30 * 1.0) / (1.0 * 100)),1) + (total1> 0 ? "%": "")%></td>
                <td class="survey-point-cell point-total"><%=Math.Round(total2 / ((30 * 1.0) / (1.0 * 100)),1) + (total2> 0 ? "%": "")%></td>
                <td class="survey-point-cell point-total"><%=Math.Round(total3 / ((30 * 1.0) / (1.0 * 100)),1) + (total3> 0 ? "%": "")%></td>
                <td class="survey-point-cell point-total"><%=Math.Round(total4 / ((30 * 1.0) / (1.0 * 100)),1) + (total4> 0 ? "%": "")%></td>
            </tr>
            <tr>
                <td colspan="2" class="survey-category-cell point-total">Tổng điểm( Điểm trung bình x 30%)</td>
                <td class="survey-point-cell point-total"><%=Math.Round(total1,1) +(total1 > 0 ? "%": "")%></td>
                <td class="survey-point-cell point-total"><%=Math.Round(total2,1) +(total2 > 0 ? "%": "")%></td>
                <td class="survey-point-cell point-total"><%=Math.Round(total3,1) +(total3 > 0 ? "%": "")%></td>
                <td class="survey-point-cell point-total"><%=Math.Round(total4,1) +(total4 > 0 ? "%": "")%></td>

            </tr>
        </tbody>
    </table>
</body>
</html>
