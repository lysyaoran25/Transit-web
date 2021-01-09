<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AjaxFormCreate.aspx.cs" Inherits="Viags.WebApp.Survey.QuestionManage.Category.AjaxFormCreate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="/Survey/assets/QuestionManage/form.css" />
    <script defer="defer" src="/Survey/assets/QuestionManage/form.js"></script>
</head>
<body>
    <form id="form-survey-category" class="form-horizontal" action="#">
        <div class="create-survey-form-contain">
            <!--Header-->
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true"></button>
                <h4 class="modal-title text-center text-uppercase"><%=ActionText %> danh mục</h4>
            </div>
            <!--Body -->
            <div class="modal-body">
                <input type="hidden" name="do" id="do" value="<%=DoAction%>" />
                <input type="hidden" name="ItemId" id="ItemId" value="<%=ItemID%>" />
                <!-- Tên danh mục -->
                <div class="form-inline survey-part-contain">
                    <label class="control-label col-sm-3">Tên: </label>
                    <input type="text" class="form-control col-sm-9" id="Name" name="Name" value="<%=Category.Name %>" />
                </div>
            </div>
            <!--Footer -->
            <div class="modal-footer">
                <div class="row">
                    <div class="col-sm-12 col-md-12 col-lg-12 survey-modal-footer">
                        <button type="button" id="btnCloseModal" class="btn btn-survey-exit" data-dismiss="modal">
                            Đóng
                        </button>
                        <button type="submit" id="btnAddModal" class="btn btn-survey-save">
                            Lưu
                        </button>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
