<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AjaxList.aspx.cs" Inherits="Viags.WebApp.Survey.ReportManage.AjaxList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script defer="defer" src="/Survey/assets/ReportManage/list.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#Report").select2({
                minimumResultsForSearch: Infinity,
            });
        })
    </script>
</head>
<body>
    <div id="grid_ReportManage">
        <!-- Tác vụ -->
        <div class="row survey-button-contain">
            <div class="col-sm-12 col-md-4 col-lg-4 horizontal-left">
                <div class="survey-button">
                    <input type="text" class=" form-control picker-report" placeholder="Chọn tháng" value="<%=DateTime.Now.Month + "/" + DateTime.Now.Year %>" />
                </div>
            </div>
            <div class="col-sm-12 col-md-4 col-lg-4 horizontal-center">
                <select class="form-control" id="Report" name="Report" onchange="ChangeReport(this)">
                    <option value="detail">Báo cáo chi tiết</option>
                    <option value="month">Báo cáo tháng</option>
                    <%--                    <option value="year">Báo cáo năm</option>--%>
                </select>
            </div>
            <div class="col-sm-12 col-md-4 col-lg-4 horizontal-right">
                <div class="survey-button">
                    <button type="button" class="btn btn-survey-filter" onclick="Export()">Xuất Excel</button>
                </div>
                <%-- <div class="survey-button">
                    <button type="button" class="btn btn-survey-search">Tìm kiếm</button>
                </div>--%>
            </div>
        </div>
        <!-- Tác vụ -->
        <div id="survey-contain-table-report">
            <h3 class="survey-title">DANH SÁCH BÁO CÁO</h3>
            <div class="survey-table-contain table-responsive" id="report-child">
            </div>
        </div>
    </div>
</body>
</html>
<script>
    ReportChild(10, 1, "detail", <%=DateTime.Now.Month%>, <%=DateTime.Now.Year%>)
</script>
