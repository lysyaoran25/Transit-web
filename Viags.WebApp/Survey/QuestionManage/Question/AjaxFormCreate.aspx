<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AjaxFormCreate.aspx.cs" Inherits="Viags.WebApp.Survey.QuestionManage.Question.AjaxFormCreate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="/Survey/assets/QuestionManage/form.css" />
    <script defer="defer" src="/Survey/assets/QuestionManage/form.js"></script>
    <script>
        $(document).ready(function () {
            $("#CategoryID").select2();
        });
    </script>
</head>
<body>
    <form id="form-survey-question" class="form-horizontal" action="#">
        <input type="hidden" id="do" name="do" value="<%=DoAction %>" />
        <input type="hidden" id="ItemID" name="ItemID" value="<%=ItemID %>" />
        <div class="create-survey-form-contain">
            <!--Header-->
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true"></button>
                <h4 class="modal-title text-center text-uppercase"><%=ActionText %> câu hỏi</h4>
            </div>
            <!--Body -->
            <div class="modal-body">

                <div class="row survey-contain-answer-part">
                    <div class="row r-contain">
                        <div class="col-sm-12">
                            <div class="form-inline row">
                                <!-- Chọn danh mục -->
                                <label class="control-label col-sm-3">Danh mục: </label>
                                <select class="form-control col-sm-9" id="CategoryID" name="CategoryID">
                                    <%foreach (var item in Categories)
                                        {%>
                                    <option value="<%=item.ID %>" <%=Question.CategoryID == item.ID ? "selected" :"" %>><%=item.Name %></option>
                                    <%} %>
                                </select>
                            </div>
                        </div>
                    </div>
                    <div class="row r-contain">
                        <div class="col-sm-12">
                            <div class="form-inline row">
                                <!-- Nội dung -->
                                <label class="control-label col-sm-3">Nội dung: </label>
                                <input type="text" class="form-control col-sm-9" tabindex="0" id="Name" name="Name" value="<%=Question.Name %>" />
                            </div>
                        </div>
                    </div>
                    <div class="row r-contain">
                        <div class="col-sm-12">
                            <div class="form-inline row">
                                <!-- Chọn danh mục -->
                                <label class="control-label col-sm-3">Dành cho quản lý: </label>
                                <input type="checkbox" class="checkbox-custom" id="OnlyManager" name="OnlyManager" <%= ItemID > 0 && (bool)Question.OnlyManager ? "checked" : ""%> />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row survey-contain-answer-part" style="margin-top: 25px !important;">
                    <h4 class="survey-title-for-answer-list">Nội dung tiêu chí</h4>
                    <div class="col-sm-12">
                        <div class="form-inline row">
                            <label class="control-label col-sm-1"></label>
                            <label class="control-label col-sm-9">Nội dung</label>
                            <label class="control-label col-sm-2">Loại</label>
                        </div>
                    </div>
                    <div class="answer-r col-sm-12">
                        <%if (ItemID > 0)
                            {
                                Index = 1;
                                foreach (var item in Question.Detail)
                                {%>
                        <div class="form-inline row">
                            <label class="control-label col-sm-1"><%=Index %></label>
                            <textarea rows="5" class="form-control col-sm-9 question_detail"><%=item.Detail.Replace("\n", "<br>") %></textarea>
                            <input type="text" class="form-control col-sm-2 question_grade" value="<%=item.Grade %>" />
                        </div>
                        <br />
                        <%Index++;
                                }
                            }
                            else
                            { %>
                        <div class="form-inline row">
                            <label class="control-label col-sm-1">1</label>
                            <textarea rows="5" class="form-control col-sm-9 question_detail"></textarea>
                            <input type="text" class="form-control col-sm-2 question_grade" />
                        </div>
                        <br />
                        <div class="form-inline row">
                            <label class="control-label col-sm-1">2</label>
                            <textarea rows="5" class="form-control col-sm-9 question_detail"></textarea>
                            <input type="text" class="form-control col-sm-2 question_grade" />
                        </div>
                        <br />
                        <div class="form-inline row">
                            <label class="control-label col-sm-1">3</label>
                            <textarea rows="5" class="form-control col-sm-9 question_detail"></textarea>

                            <input type="text" class="form-control col-sm-2 question_grade" />
                        </div>
                        <br />
                        <div class="form-inline row">
                            <label class="control-label col-sm-1">4</label>
                            <textarea rows="5" class="form-control col-sm-9 question_detail"></textarea>
                            <input type="text" class="form-control col-sm-2 question_grade" />
                        </div>
                        <br />
                        <%} %>
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
