<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AjaxList.aspx.cs" Inherits="Viags.WebApp.Survey.TestManage.AjaxList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script defer="defer" src="/Survey/assets/TestManage/list.js"></script>
</head>
<body>
    <div id="grid_TestManage">
        <!-- Tác vụ -->
        <div class="row survey-button-contain">
            <div class="col-sm-12 col-md-6 col-lg-6 horizontal-left">
                <div class="survey-button">
                    <input type="text" class=" form-control picker" readonly placeholder="Chọn tháng" value="<%=DateTime.Now.Month + "/"+ DateTime.Now.Year%>" />
                </div>
            </div>
            <div class="col-sm-12 col-md-6 col-lg-6 horizontal-right">
                <div class="survey-button">
                    <button type="button" class="btn btn-survey-search" onclick="OpenSearch()">Tìm kiếm</button>
                </div>
              <%--  <%if (type == "do")
                    {%>
                <div class="survey-button">
                    <button type="button" class="btn btn-survey-search" onclick="OpenImport()">Import</button>
                </div>
                <%} %>--%>
            </div>
        </div>
        <div class="SearchView_approve" id="survey-contain-table-test" hidden="hidden">
            <form id="SearchForm_approve">
                <div class="row">
                    <input type="hidden" name="typeview" id="typeview" value="<%=type %>" />
                    <input type="text" class="form-control col-sm-3 keyword" id="keyword_name" name="keyword_name" placeholder="Tìm kiếm theo tên" />
                    <button type="submit" class="btn btn-survey-search col-sm-1"><i class="fa fa-search"></i>&nbsp;<%=Resources.TaiKhoan.lblTimKiem %></button>
                </div>
            </form>
        </div>
        <%--<div class="ImportView_approve" id="survey-contain-table-test" hidden="hidden">
            <form id="form1" runat="server" enctype="multipart/form-data">
                <div class="row">
                    <input type="hidden" name="typeview" id="typeview" value="<%=type %>" />
                    <input class="form-control col-sm-4" type="file" name="postedFile" id="postedFile" />
                    <asp:Button CssClass="btn btn-survey-search col-sm-1" ID="UploadBtn" runat="server" OnClick="ImportExcel" Text="Upload" PostBackUrl="/Survey/TestManage/AjaxList.aspx" />
                    <asp:Button CssClass=" btn btn-survey-search col-sm-1" ID="ExportBtn" runat="server" OnClick="ExportExcel" Text="Template" PostBackUrl="/Survey/TestManage/AjaxList.aspx" />
                </div>
            </form>
        </div>--%>
        <!-- Tác vụ -->
        <div id="survey-contain-table-test">
            <h3 class="survey-title">BÀI ĐÁNH GIÁ</h3>
            <div class="survey-table-contain table-responsive" id="TestChild_<%=type %>">
            </div>
        </div>
    </div>
</body>
</html>
<script>
    $(document).ready(function () {
        TestChild(50, 1, '<%=type%>',<%=DateTime.Now.Month%>,<%=DateTime.Now.Year%>);
    })
</script>

