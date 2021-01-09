<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AjaxFormCreate.aspx.cs" Inherits="Viags.WebApp.Survey.QuestionManage.Evaluate.AjaxFormCreate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="/Survey/assets/QuestionManage/form.css" />
    <script defer="defer" src="/Survey/assets/QuestionManage/form.js"></script>
</head>
<body>
    <form id="form-survey-evaluate" class="form-horizontal" action="#">
        <input type="hidden" id="do" name="do" value="<%=ItemID > 0 ? "edit" : "add"  %>" />
        <input type="hidden" id="ItemID" name="ItemID" value="<%=ItemID %>" />
        <div class="create-survey-form-contain">
            <!--Header-->
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true"></button>
                <h4 class="modal-title text-center text-uppercase"><%=ActionText %> tiêu chí</h4>
            </div>
            <!--Body -->
            <div class="modal-body">

                <div class="row survey-contain-answer-part">
                    <div class="row survey-contain-answer-part" style="margin-top: 25px !important;">
                        <h4 class="survey-title-for-answer-list">Tiêu chí đánh giá</h4>
                        <div class="col-sm-12">
                            <div class="form-inline row">
                                <label class="control-label col-sm-1"></label>
                                <label class="control-label col-sm-7">Tên tiêu chí</label>
                                <label class="control-label col-sm-2">Loại</label>
                                <label class="control-label col-sm-2">Điểm (%)</label>
                            </div>
                        </div>
                        <div class="answer-r col-sm-12">
                            <%if (Evaluate != null)
                                {
                                    Index = 1;
                                    foreach (var item in Evaluate.Detail)
                                    {%>
                            <div class="form-inline row">
                                <label class="control-label col-sm-1"><%=Index %></label>
                                <textarea rows="5" class="form-control col-sm-7 evaluate_detail"><%=item.Detail %></textarea>
                                <input type="text" class="form-control col-sm-2 evaluate_grade" value="<%=item.Grade %>" />
                                <input type="number" class="form-control col-sm-2 evaluate_point" min="0" max="100" value="<%=item.Point %>" />
                            </div>
                            <br />
                            <%Index++;
                                    }
                                }
                                else
                                { %>
                            <div class="form-inline row">
                                <label class="control-label col-sm-1">1</label>
                                <textarea rows="5" class="form-control col-sm-7 evaluate_detail"></textarea>
                                <input type="text" class="form-control col-sm-2 evaluate_grade" />
                                <input type="number" class="form-control col-sm-2 evaluate_point" min="0" max="100" />
                            </div>
                            <div class="form-inline row">
                                <label class="control-label col-sm-1">2</label>
                                <textarea rows="5" class="form-control col-sm-7 evaluate_detail"></textarea>
                                <input type="text" class="form-control col-sm-2 evaluate_grade" />
                                <input type="number" class="form-control col-sm-2 evaluate_point" min="0" max="100" />
                            </div>
                            <div class="form-inline row">
                                <label class="control-label col-sm-1">3</label>
                                <textarea rows="5" class="form-control col-sm-7 evaluate_detail"></textarea>
                                <input type="text" class="form-control col-sm-2 evaluate_grade" />
                                <input type="number" class="form-control col-sm-2 evaluate_point" min="0" max="100" />
                            </div>
                            <div class="form-inline row">
                                <label class="control-label col-sm-1">4</label>
                                <textarea rows="5" class="form-control col-sm-7 evaluate_detail"></textarea>
                                <input type="text" class="form-control col-sm-2 evaluate_grade" />
                                <input type="number" class="form-control col-sm-2 evaluate_point" min="0" max="100" />
                            </div>
                            <br />
                            <%} %>
                        </div>
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
