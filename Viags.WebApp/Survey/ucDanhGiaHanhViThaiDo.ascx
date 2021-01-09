<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucDanhGiaHanhViThaiDo.ascx.cs" Inherits="Viags.WebApp.Survey.ucDanhGiaHanhViThaiDo" %>
<!-- CSS Custom -->
<link rel="stylesheet" type="text/css" href="/Survey/assets/uc.css" />
<!-- CSS Custom -->
<!-- SurveyJS -->
<script type="text/javascript" src="https://surveyjs.azureedge.net/1.8.8/survey.jquery.js"></script>
<link href="https://surveyjs.azureedge.net/1.8.8/modern.css" type="text/css" rel="stylesheet" />
<script type="text/javascript" src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>

<!-- SurveyJS -->
<!-- Page content -->
<div class="row" style="margin-left: 0; margin-right: 0">
    <div class="col-sm-12 col-md-12 col-lg-12" style="padding: 5px">
        <div class="portlet content-padding" id="survey-portlet">

            <!-- Title-->
            <div class="portlet-title">
                <div class="caption">
                    <a href="/Pagess/danh-gia-hanh-vi-thai-do.aspx">
                        <b>ĐÁNH GIÁ HÀNH VI THÁI ĐỘ</b>
                    </a>
                </div>
            </div>
            <!-- Title -->

            <!-- Tab pill-->
            <div class="row" id="survey-tab-nav">
                <ul id="TabMenuSurvey" class="nav nav-pills nav-justified">
                    <li class="active">
                        <a onclick="ChangeToTabQuestionManage()" href="#TabQuestionManage" data-toggle="tab" aria-expanded="false">NGÂN HÀNG CÂU HỎI</a>
                    </li>

                    <li>
                        <a onclick="ChangeToTabTestManage()" href="#TabTestManage" data-toggle="tab" aria-expanded="false">LÀM BÀI ĐÁNH GIÁ</a>
                    </li>

                    <li>
                        <a onclick="ChangeToTabApprovalManage()" href="#TabApprovalManage" data-toggle="tab" aria-expanded="false">DANH SÁCH</a>
                    </li>
                    <%if (surveyDA.Viewreport.Contains(CurrentUser.ID))
                        {%>
                    <li>
                        <a onclick="ChangeToTabReportManage()" href="#TabReportManage" data-toggle="tab" aria-expanded="false">Báo cáo nhân viên</a>
                    </li>
                    <%} %>
                </ul>
            </div>
            <!-- Tab pill-->

            <!-- Tab content -->
            <div class="tab-content" id="survey-tab-content">

                <!-- #Tab1 -->
                <div class="tab-pane fade active in" id="TabQuestionManage">
                    <div id="gridview_QuestionManage"></div>
                </div>
                <!-- #Tab1 -->

                <!-- #Tab2 -->
                <div class="tab-pane fade in" id="TabTestManage">
                    <div id="gridview_TestManage"></div>
                </div>

                <!-- #Tab2 -->

                <!-- #Tab3 -->
                <div class="tab-pane fade in" id="TabApprovalManage">
                    <div id="gridview_ApprovalManage"></div>
                </div>
                <!-- #Tab3 -->

                <!-- #Tab4-->
                <div class="tab-pane fade in" id="TabReportManage">
                    <div id="gridview_ReportManage"></div>
                </div>
                <!-- #Tab4-->

            </div>
            <!-- Tab content -->

        </div>
    </div>
</div>
<!-- Page content -->

<!-- Script -->
<script type="text/javascript" src="/Survey/assets/uc.js"></script>
<!-- Script -->
