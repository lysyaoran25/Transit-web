<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucTopNavigation.ascx.cs" Inherits="Viags.WebApp.Common.ucTopNavigation" %>
<div class="page-header -i navbar navbar-fixed-top hidden-xs-bg hidden-sm-bg">
    <!-- BEGIN HEADER INNER -->
    <div class="page-header-inner">
        <div class="page-logo hidden-xs hidden-sm">
            <a href="/Pagess/Home.aspx">
                <img src="/Publishing_Resources/img/sg31/logo-nhnn.png" alt="logo" class="logo-default" />
            </a>
            <%--  <div class="menu-toggler sidebar-toggler hide">
            </div>--%>
        </div>
        <div class="top-menu">
            <div id="centerdesk" class="margin-right-30">HỆ THỐNG  QUẢN LÝ VĂN BẢN VÀ ĐIỀU HÀNH</div>
            <span class="contant-current-time" style="padding: 15px; margin: 0px; display: inline-block; float: left" class="hidden-xs hidden-sm">
                <i class="fa fa-clock-o"></i><span class="current-time"></span>
            </span>
            <ul class="nav navbar-nav pull-right" id="divNotification">
                <!-- END USER LOGIN DROPDOWN -->
            </ul>
        </div>
    </div>
    <!-- END HEADER INNER -->
</div>
<!-- END HEADER -->
<div class="clearfix">
</div>
<script type="text/javascript">
    $(document).ready(function () {
        LoadAjaxPage("/Common/pTopNavigation.aspx", "#divNotification");
        setInterval(function () {
            setTimeout(function () { loadTopNav(); }, 1000);
        }, 5000);

    });
    function loadTopNav() {
        LoadAjaxPage("/Common/pTopNavigation.aspx", "#divNotification");
    }
</script>
<style>
    #divNotification .unread a {
        background: #d6b48e;
        border-bottom: 1px solid #E6E6E6 !important;
    }
</style>
