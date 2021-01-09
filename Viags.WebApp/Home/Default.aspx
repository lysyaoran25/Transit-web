﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Viags.WebApp.Home.Default" %>

<%--<%@ Register Src="~/Common/ucMenuLeftNew.ascx" TagPrefix="uc1" TagName="ucMenuLeftNew" %>--%>




<!DOCTYPE html>
<!-- saved from url=(0111)/Pagess/van-ban-den.aspx#Field=ThuTu&SoVanBanID=1235&LoaiDanhSachID=0&Page=1&RowPerPage=10 -->
<html dir="ltr" lang="en-US">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=10">
    <meta name="GENERATOR" content="Microsoft SharePoint">
    <meta http-equiv="Expires" content="0">
    <title>Quản lý văn bản, điều hành tác nghiệp và lưu trữ tại công ty Viags
</title>
    <link href="/Publishing_Resources/img/sg31/logo-nhnn.ico" rel="shortcut icon" type="image/x-icon" />  
    <style>
        .modal-overflow .modal-body {
            overflow: hidden !important;
            overflow-y: auto !important;
            max-height: 493px !important;
        }
    </style>
</head>
<body class="desktop-detected ms-backgroundImage" id="page-top" onhashchange="if (typeof(_spBodyOnHashChange) != &#39;undefined&#39;) _spBodyOnHashChange();">
    <link rel="shortcut icon" href="/_catalogs/masterpage/favicon.ico">
    <meta content="width=device-width, initial-scale=1.0" name="viewport">
    <meta name="description">
    <meta name="author">
    <!-- styles sử dụng -->
    <link href="/Publishing_Resources/dist/app.min.css" rel="stylesheet" type="text/css">

    <script src="/Publishing_Resources/dist/app.min.js" type="text/javascript"></script>

    <style type="text/css">
        div#suiteBar {
            display: none;
        }

        #s4-workspace {
            overflow: inherit;
        }

        body {
            overflow: auto;
        }

        .page-container {
            margin-top: 40px;
        }

        .page-footer {
            height: auto !important;
        }

        #s4-bodyContainer {
            padding-bottom: 0px;
        }
    </style>
    <script type="text/javascript">
        jQuery(document).ready(function () {
            Index.init();
            Layout.init(); // init layout
            setInterval(function () {
                var time = new Date();
                var year = time.getFullYear();
                var month = time.getMonth() + 1; if (month < 10) month = "0" + month;
                var day = time.getDate(); if (day < 10) day = "0" + day;
                var hour = time.getHours(); if (hour < 10) hour = "0" + hour;
                var minute = time.getMinutes(); if (minute < 10) minute = "0" + minute;
                var second = time.getSeconds(); if (second < 10) second = "0" + second;
                $(".current-time").html(hour + ":" + minute + ":" + second + " - " + day + "/" + month + "/" + year);
            }, 1000);
            //Dropdownlist select
            $(".select2").select2();
            $(".select2ReadOnly").select2("readonly", true);
            //$(".js-example-tags").select2({tags:true});
            //Hiện form search
            $(".gridSearch").hide();
            $(".opensearch").click(function () {
                var _rel = $(this).attr('rel');
                $(".gridSearch").slideUp();
                $("#" + _rel).slideDown();
            });
            $(".btnclosesearch").click(function () {
                $(".gridSearch").slideUp();
                $("#gridSearch").slideUp();
            });
            $('#selectAll').click(function (event) {  //on click 
                if (this.checked) { // check select status
                    $('.selectItem').prop('checked', true);
                    $('.selectItem').parent().addClass('checked');
                } else {
                    $('.selectItem').prop('checked', false);
                    $('.selectItem').parent().removeClass('checked');
                }
            });
            $("#btnThem,#btnAddForm").click(function () {
                myfocus();
            });
        });
        function myfocus() {
            $('.modal').on('shown.bs.modal', function () {
                setTimeout(function () {
                    $('.form-horizontal').find("input[type=text]:first").focus();
                }, 100);
            });
        }
          </script>

    <!-- END JAVASCRIPTS -->
    <!-- END JAVASCRIPTS -->
    <style type="text/css">
        .s4-skipribbonshortcut {
            display: none;
        }
    </style>
    <!-- menu  link <a data-target=".nav-collapse" data-toggle="collapse" class="btn-navbar collapsed" href="javascript:;"><img alt="" src="/Admin_Resources/img/sidebar-toggler.jpg"></a>-->
    <form method="post" action="/Pagess/van-ban-den.aspx" onsubmit="javascript:return WebForm_OnSubmit();" id="aspnetForm">
        <div id="s4-workspace" style="">
            <div id="s4-bodyContainer">
                <!-- BEGIN HEADER -->
                <!-- Phần đầu trang -->
                <div class="page-header -i navbar navbar-fixed-top">
                    <!-- BEGIN TOP NAVIGATION BAR -->
                    <div class="page-header-inner">
                        <div class="page-logo">
                            <a href="/Pagess/Home.aspx">
                                <img src="/Publishing_Resources/img/sg31/logo-nhnn.png" alt="logo" class="logo-default">
                            </a>

                        </div>
                        <!-- END LOGO -->
                        <!-- BEGIN RESPONSIVE MENU TOGGLER -->
                        <a href="javascript:;" class="menu-toggler responsive-toggler" data-toggle="collapse" data-target=".navbar-collapse"></a>
                        <!-- END RESPONSIVE MENU TOGGLER -->
                        <!-- BEGIN TOP NAVIGATION MENU -->
                        <div class="top-menu">
                            <div id="centerdesk">HỆ THỐNG QUẢN LÝ VĂN BẢN VÀ ĐIỀU HÀNH CÔNG TY</div>

                            <div class="page-header -i navbar navbar-fixed-top hidden-xs-bg hidden-sm-bg">
                                <!-- BEGIN HEADER INNER -->
                                <div class="page-header-inner">
                                    <div class="page-logo hidden-xs hidden-sm">
                                        <a href="/Pagess/Home.aspx">
                                            <img src="/Publishing_Resources/img/sg31/logo-nhnn.png" alt="logo" class="logo-default">
                                        </a>

                                    </div>
                                    <div class="top-menu">
                                        <div id="centerdesk" class="margin-right-30">HỆ THỐNG  QUẢN LÝ VĂN BẢN VÀ ĐIỀU HÀNH</div>
                                        <span class="contant-current-time" style="padding: 15px; margin: 0px; display: inline-block">
                                            <i class="fa fa-clock-o"></i><span class="current-time">17:27:10 - 18/08/2016</span>
                                        </span>
                                        <ul class="nav navbar-nav pull-right" id="divNotification">
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
                                        setTimeout(function () { loadTopNav(); }, 1);
                                    }, 300000);

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



                        </div>
                        <!-- END TOP NAVIGATION MENU -->
                    </div>
                </div>
                <div class="clearfix">
                </div>
                <!-- END HEADER -->
                <!-- BEGIN CONTAINER -->
                <div class="page-container" style="margin-top: 73px;">
                    <!-- BEGIN SIDEBAR MENU LEFT-->
                    <%--<uc1:ucMenuLeftNew runat="server" ID="ucMenuLeftNew" />--%>
                     
                    <!-- END SIDEBAR MENU LEFT-->
                    <!-- BEGIN CONTENT -->
                    <div class="page-content-wrapper">
                        <div class="page-content" style="min-height: 904px">
                            <!-- BEGIN PAGE CONTENT-->
                            <asp:PlaceHolder ID="plhLoadControl" runat="server"></asp:PlaceHolder>

                        </div>
                    </div>
                    <!-- END CONTENT-->
                    <div id="dialog-form" class="modal fade" tabindex="-1" role="basic" aria-hidden="true" data-focus-on="input:first" data-keyboard="false">
                    </div>
                    <div id="dialog-message" class="modal fade" tabindex="-1" data-keyboard="false">
                    </div>
                    <div id="dialog-ultility" class="modal fade" tabindex="-1" data-backdrop="static" data-keyboard="false" data-focus-on="input:first"></div>
                    <div id="dialog-confirm" class="modal fade" tabindex="-1" data-backdrop="static" data-keyboard="false"></div>
                    <div id="dialog-loading" class="modal fade" tabindex="-1" data-keyboard="false"></div>
                </div>
                <!-- END CONTAINER-->
                <!-- END PAGE -->

                <!-- END CONTAINER -->
                <!-- BEGIN FOOTER -->

                <div class="page-footer">
                    <div class="page-footer-inner">
                        © Trang tin điện tử công ty Viags. Số cấp phép: 101/GP-BC do Bộ Văn hoá - Thông tin cấp ngày 10/03/2004. Cơ quan chủ quản: Công ty Viags.
 
                        <div style="color: red; text-align: center; font-weight: bold; font-size: 14px">Thông tin liên hệ (04) 558 9970  máy lẻ 27 hoặc 01698 432 197	</div>
                    </div>

                    <div class="scroll-to-top">
                        <i class="icon-arrow-up"></i>
                    </div>
                </div>
                <!-- END FOOTER -->
                <!-- END BODY -->
            </div>
        </div>
    </form>
</body>
</html>
