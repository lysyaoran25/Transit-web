<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AjaxList.aspx.cs" Inherits="Viags.WebApp.Survey.QuestionManage.AjaxList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="/Survey/assets/QuestionManage/list.css" />
    <script defer="defer" src="/Survey/assets/QuestionManage/list.js"></script>
    <script>
        $(document).ready(function () {
                                <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.SurveyQuestion))
        {%>

            QuestionList(10, 1);
            <%}
        else
        {%>
            TestList(10, 1);

            <%}%>
            $(".QuestionTab").on('click', function () {
                QuestionList(10, 1);
            })
            $(".CategoryTab").on('click', function () {
                CategoryList(10, 1);
            })
            $(".TestTab").on('click', function () {
                TestList(10, 1);
            })
            $(".EvaluateTab").on('click', function () {
                EvaluateList(10, 1);
            })
        })
    </script>
</head>
<body>
    <div id="grid_QuestionManage">
        <div class="row row-question-manage">
            <!-- Question manage navigation-->
            <div class="col-sm-4 col-md-2 col-lg-2" id="question_manage_nav_box">
                <ul class="nav nav-pills nav nav-pills nav-stacked question-nav-box">
                    <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.SurveyQuestion))
                        {%>
                    <li class="active">
                        <a href="#ListSurveyQuestion" class="QuestionTab" data-toggle="tab" aria-expanded="false">Câu hỏi</a>
                    </li>
                    <li>
                        <a href="#ListSurveyCategory" class="CategoryTab" data-toggle="tab" aria-expanded="false">Danh mục</a>
                    </li>
                    <li>
                        <a href="#ListSurveyEvaluate" class="EvaluateTab" data-toggle="tab" aria-expanded="false">Tiêu chí</a>
                    </li>
                    <li>
                        <a href="#ListSurveyTest" class="TestTab" data-toggle="tab" aria-expanded="false">Bài đánh giá</a>
                    </li>
                    <%}
                        else
                        { %>
                    <li class="active">
                        <a href="#ListSurveyTest" class="TestTab" data-toggle="tab" aria-expanded="false">Bài đánh giá</a>
                    </li>
                    <%} %>
                </ul>
            </div>
            <!-- Question manage content-->
            <div class="col-sm-8 col-md-10 col-lg-10" id="question_manage_content_box">
                <div class="tab-content question-content-box">
                    <%if (CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.SurveyQuestion))
                        {%>
                    <!-- ListSurveyQuestion-->
                    <div class="tab-pane fade in active" id="ListSurveyQuestion">
                        <!-- Tác vụ -->
                        <div class="row survey-button-contain">
                            <div class="col-sm-12 col-md-6 col-lg-6 horizontal-left">
                                <div class="survey-button">
                                    <button type="button" class="btn btn-survey-create" id="btn-survey-create-question">Thêm câu hỏi</button>
                                </div>
                                <%-- <div class="survey-button">
                                    <button type="button" class="btn btn-survey-import" id="">
                                        <span class="glyphicon glyphicon-open" aria-hidden="true"></span>
                                    </button>
                                </div>
                                <div class="survey-button">
                                    <button type="button" class="btn btn-survey-export" id="">
                                        <span class="glyphicon glyphicon-save" aria-hidden="true"></span>
                                    </button>
                                </div>--%>
                            </div>
                            <div class="col-sm-12 col-md-6 col-lg-6 horizontal-right">
                                <%--<div class="survey-button">
                                    <button type="button" class="btn btn-survey-search">Tìm kiếm</button>
                                </div>--%>
                            </div>
                        </div>
                        <!-- Tác vụ -->
                        <!-- Bảng câu hỏi -->
                        <div id="survey-contain-table-question-manage">
                            <h3 class="survey-title">Câu hỏi</h3>
                            <div class="survey-table-contain table-responsive" id="QuestionList">
                            </div>
                        </div>
                        <!-- Bảng câu hỏi -->
                    </div>
                    <!-- ListSurveyCategory-->
                    <div class="tab-pane fade in" id="ListSurveyCategory">
                        <!-- Tác vụ -->
                        <div class="row survey-button-contain">
                            <div class="col-sm-12 col-md-6 col-lg-6 horizontal-left">
                                <div class="survey-button">
                                    <button type="button" class="btn btn-survey-create" id="btn-survey-create-category">Thêm danh mục</button>
                                </div>
                            </div>
                            <div class="col-sm-12 col-md-6 col-lg-6 horizontal-right">
                                <%--<div class="survey-button">
                                    <button type="button" class="btn btn-survey-search">Tìm kiếm</button>
                                </div>--%>
                            </div>
                        </div>
                        <!-- Tác vụ -->
                        <!-- Bảng danh mục -->
                        <div id="survey-contain-table-category-manage">
                            <h3 class="survey-title">Danh mục</h3>
                            <div class="survey-table-contain table-responsive" id="CategoryList">
                            </div>
                        </div>
                        <!-- Bảng danh mục -->
                    </div>
                    <!-- ListSurveyEvaluate-->
                    <div class="tab-pane fade in" id="ListSurveyEvaluate">
                        <!-- Tác vụ -->
                        <div class="row survey-button-contain">
                            <div class="col-sm-12 col-md-6 col-lg-6 horizontal-left">
                                <div class="survey-button">
                                    <button type="button" class="btn btn-survey-create" id="btn-survey-create-evaluate" data-id="<%=AnyEvaluate > 0 ? AnyEvaluate : 0 %>">Cập nhật tiêu chí</button>
                                </div>
                            </div>
                        </div>
                        <!-- Tác vụ -->
                        <!-- Bảng tiêu chí -->
                        <div id="survey-contain-table-evaluate-manage">
                            <h3 class="survey-title">Tiêu chí</h3>
                            <div class="survey-table-contain table-responsive" id="EvaluateList">
                            </div>
                        </div>
                        <!-- Bảng câu hỏi -->
                    </div>
                    <!-- ListSurveyTest-->
                    <div class="tab-pane fade in" id="ListSurveyTest">
                        <!-- Tác vụ -->
                        <div class="row survey-button-contain">
                            <div class="col-sm-12 col-md-6 col-lg-6 horizontal-left">
                                <div class="survey-button">
                                    <button type="button" class="btn btn-survey-create" id="btn-survey-create-test">Thêm bài đánh giá</button>
                                </div>
                            </div>
                            <div class="col-sm-12 col-md-6 col-lg-6 horizontal-right">
                                <%--<div class="survey-button">
                                    <button type="button" class="btn btn-survey-search">Tìm kiếm</button>
                                </div>--%>
                            </div>
                        </div>
                        <!-- Tác vụ -->
                        <!-- Bảng bài đánh giá-->
                        <div id="survey-contain-table-test-manage">
                            <h3 class="survey-title">Bài đánh giá</h3>
                            <div class="survey-table-contain table-responsive" id="TestList">
                            </div>
                        </div>
                        <!-- Bảng bài đánh giá-->
                    </div>
                    <%}
                        else
                        { %>
                    <div class="tab-pane fade in active" id="ListSurveyTest">
                        <!-- Tác vụ -->
                        <div class="row survey-button-contain">
                            <div class="col-sm-12 col-md-6 col-lg-6 horizontal-left">
                                <div class="survey-button">
                                    <button type="button" class="btn btn-survey-create" id="btn-survey-create-test">Thêm bài đánh giá</button>
                                </div>
                            </div>
                            <div class="col-sm-12 col-md-6 col-lg-6 horizontal-right">
                                <%--<div class="survey-button">
                                    <button type="button" class="btn btn-survey-search">Tìm kiếm</button>
                                </div>--%>
                            </div>
                        </div>
                        <!-- Tác vụ -->
                        <!-- Bảng bài đánh giá-->
                        <div id="survey-contain-table-test-manage">
                            <h3 class="survey-title">Bài đánh giá</h3>
                            <div class="survey-table-contain table-responsive" id="TestList">
                            </div>
                        </div>
                        <!-- Bảng bài đánh giá-->
                    </div>
                    <%} %>
                </div>
            </div>
        </div>
    </div>
</body>
</html>
