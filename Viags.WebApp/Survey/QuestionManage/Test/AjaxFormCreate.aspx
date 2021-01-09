<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AjaxFormCreate.aspx.cs" Inherits="Viags.WebApp.Survey.QuestionManage.Test.AjaxFormCreate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="/Survey/assets/QuestionManage/form.css" />
    <script defer="defer" src="/Survey/assets/QuestionManage/form.js"></script>
    <script>
        $(document).ready(function () {
            $("#CategoryID").select2();
            $("#Area").select2();
            $("#User").select2();
            $("#Month,#Year").select2({
                minimumResultsForSearch: Infinity
            });
            ChangeArea('<%=Test.Department%>')
        })
    </script>
</head>
<body>
    <form id="form-survey-test" class="form-horizontal" action="#">
        <input type="hidden" id="do" name="do" value="<%=DoAction %>" />
        <input type="hidden" id="ItemID" name="ItemID" value="<%=ItemID %>" />
        <input type="hidden" id="isSubmit" name="isSubmit" />
        <div class="create-survey-form-contain">
            <!--Header-->
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true"></button>
                <h4 class="modal-title text-center text-uppercase">Thêm bài đánh giá</h4>
            </div>
            <!--Body -->
            <div class="modal-body">

                <div class="row survey-contain-part">
                    <div class="row r-contain">
                        <div class="col-sm-12">
                            <div class="form-inline row">
                                <!-- Nhập tên -->
                                <label class="control-label col-sm-2">Bài đánh giá: </label>
                                <input type="text" class="form-control col-sm-10" id="Name" name="Name" value="<%=Test.Name %>" />
                            </div>
                        </div>
                    </div>
                </div>

                <div class="row survey-contain-part">
                    <div class="row r-contain">
                        <div class="col-sm-12">
                            <div class="form-inline row">
                                <!-- Chọn danh mục-->
                                <label class="control-label col-sm-2">Danh mục: </label>
                                <select class="form-control col-sm-10" multiple="multiple" id="CategoryID" name="CategoryID" onchange="LoadQuestion(this)">
                                    <%foreach (var item in Categories)
                                        {%>
                                    <option value="<%=item.ID %>" <%=ItemID > 0 ? Test.ListCategory.Any(p=>p.ID == item.ID) ? "selected" : "" : "" %>><%=item.Name %></option>
                                    <%} %>
                                </select>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row survey-contain-part">
                    <div class="row r-contain">
                        <div class="col-sm-5">
                            <div class="form-inline row">
                                <!-- Chọn tháng -->
                                <label class="control-label col-sm-5">Tháng: </label>
                                <select class="form-control col-sm-7 select2" id="Month" name="Month">
                                    <%for (var i = 1; i <= 12; i++)
                                        {%>
                                    <option value="<%=i %>" <%=ItemID >0 ? Test.Month == i ? "selected" :"" : DateTime.Now.Month == i ? "selected":"" %>><%=i %></option>
                                    <%} %>
                                </select>
                            </div>
                        </div>
                        <div class="col-sm-5">
                            <div class="form-inline row">
                                <!-- Chọn năm -->
                                <label class="control-label col-sm-5">Năm: </label>
                                <select class="form-control col-sm-7 select2" id="Year" name="Year">
                                    <%for (var i = 2020; i <= 2050; i++)
                                        {%>
                                    <option value="<%=i %>" <%=ItemID >0 ? Test.Year == i ? "selected" :"" : DateTime.Now.Year == i ? "selected" : "" %>><%=i %></option>
                                    <%} %>
                                </select>
                            </div>
                        </div>
                    </div>
                </div>
                <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.SurveyEmployee))
                    {%>
                <div class="row survey-contain-part">
                    <div class="row r-contain">
                        <div class="col-sm-5">
                            <div class="form-inline row">
                                <!-- Chọn Đơn vị-->
                                <label class="control-label col-sm-5">Đơn vị: </label>
                                <select class="form-control col-sm-7" multiple="multiple" id="Area" name="Area" onchange="ChangeArea('<%=Test.Department %>')">
                                    <%foreach (var item in ListArea)
                                        {%>
                                    <option value="<%=item.ID %>" <%=ItemID > 0 ? Test.Area.Contains(item.ID.ToString()) ? "selected" : "" : "" %>><%=item.Ten %></option>
                                    <%} %>
                                </select>
                            </div>
                        </div>
                        <div class="col-sm-5">
                            <div class="form-inline row">
                                <!-- Chọn phòng ban-->
                                <label class="control-label col-sm-5">Phòng ban: </label>
                                <input class="form-control col-sm-7" id="Department" name="Department" />
                            </div>
                        </div>
                    </div>
                </div>
                <%} %>
                <div class="row survey-contain-part">
                    <div class="row r-contain">
                        <div class="col-sm-12">
                            <div class="form-inline row">
                                <!-- Chọn nhân viên-->
                                <label class="control-label col-sm-2">Nhân viên: </label>
                                <select class="form-control col-sm-10" multiple="multiple" id="User" name="User">
                                    <%foreach (var item in ListUser)
                                        { %>
                                    <option value="<%=item.ID %>" <%=ItemID>0 ? Test.ListUserID.Contains(item.ID) ? "selected":"" : "" %>><%=item.TenHienThi+"-"+item.TenChucVu+"-"+item.TenVietTatPhongBan %></option>
                                    <%} %>
                                </select>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row survey-contain-answer-part" style="margin-top: 25px !important;">
                    <h4 class="survey-title-for-answer-list">Câu hỏi</h4>
                    <div class="col-sm-12" id="question">
                        <%=questions %>
                    </div>
                </div>
                <div class="row survey-contain-answer-part" style="margin-top: 25px !important;">
                    <h4 class="survey-title-for-answer-list">Đánh giá</h4>
                    <div class="col-sm-12" id="Evaluate">
                        <%if (ItemID > 0)
                            {
                                foreach (var item in Test.Comments)
                                {%>
                        <div class="form-inline row">
                            <label class="col-sm-1"></label>
                            <input type="text" class="form-control col-sm-9 test_detail" value="<%=item.Name %>" />
                            <button type="button" class="btn btn-survey-delete col-sm-1" onclick="Survey_Remove_Point_Evaluate(this)">
                                <span class="glyphicon glyphicon-trash" aria-hidden="true"></span>
                            </button>
                        </div>
                        <br />
                        <%}
                            } %>
                    </div>
                    <div class="col-sm-12" style="text-align: center !important;">
                        <button type="button" class="btn btn-survey-add"
                            onclick="AddForm()">
                            <span class="fa fa-plus" aria-hidden="true"></span>
                        </button>
                    </div>
                </div>
            </div>
            <!--Footer -->
            <div class="modal-footer">
                <div class="row">
                    <div class="col-sm-12 col-md-12 col-lg-12 survey-modal-footer">
                        <button type="button" id="btnCloseModal" class="btn btn-survey-exit" data-dismiss="modal">
                            Đóng
                        </button>
                        <button type="submit" id="Submit" style="display: none"></button>
                        <button type="button" id="submitFormFalse" class="btn btn-survey-save" onclick="SubmitForm(false)">
                            Lưu nháp
                        </button>
                        <button type="button" id="submitFormTrue" class="btn btn-survey-save" onclick="SubmitForm(true)">
                            Lưu
                        </button>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
