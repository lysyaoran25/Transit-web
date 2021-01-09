<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucHome.ascx.cs" Inherits="Viags.WebApp.Home.ucHome" %>

<script src="/Publishing_Resources/global/plugins/bootstrap-toastr/toastr.js"></script>

<%--<link href="/Publishing_Resources/global/plugins/bootstrap-toastr/toastr.min.css" rel="stylesheet" type="text/css" />--%>
<link href="/Publishing_Resources/global/plugins/bootstrap-toastr/toastr.css" rel="stylesheet" type="text/css" />
<link href="/Publishing_Resources/global/plugins/jquery-notific8/jquery.notific8.min.css" rel="stylesheet" type="text/css" />

<script type="text/javascript">
    $(document).ready(function () {
        var urlRequestBM = "/BieuMau/AjaxViewHome.aspx";
        $("a.act_viewbm").click(function () {

            urlRequestBM = "/BieuMau/AjaxViewHome.aspx";
            if (urlRequestBM.indexOf('?') > 0)
                urlRequestBM = urlRequestBM + '&itemId=' + $(this).attr("href").substring(1);
            else
                urlRequestBM = urlRequestBM + '?itemId=' + $(this).attr("href").substring(1);
            $('body').modalmanager('loading');
            $('#dialog-form').load(urlRequestBM, function () {
                $('#dialog-form').modal({ width: 650 });
            });
        });
        var urlRequestTB = "/ThongBao/AjaxViewHome.aspx";
        $("a.act_viewtb").click(function () {
            urlRequestTB = "/ThongBao/AjaxViewHome.aspx";
            if (urlRequestTB.indexOf('?') > 0)
                urlRequestTB = urlRequestTB + '&itemId=' + $(this).attr("href").substring(1);
            else
                urlRequestTB = urlRequestTB + '?itemId=' + $(this).attr("href").substring(1);
            $('body').modalmanager('loading');
            $('#dialog-form').load(urlRequestTB, function () {
                $('#dialog-form').modal({ width: 650 });
            });
        });
        <%if (CountCongViecSapHetHan > 0)
    {%>
        viewPopup();
        <%}%>
        <%if (CountVanBanSapHetHan > 0)
    {%>
        viewPopupVanBan();
        <%}%>
        function viewPopup(closeButton, positionClass, timeOut) {
            toastr.options = {
                "closeButton": true,
                "debug": false,
                "positionClass": "toast-bottom-right",
                "onclick": null,
                "showDuration": "1000",
                "hideDuration": "1000",
                "timeOut": "5000",
                "extendedTimeOut": "1000",
                "showEasing": "swing",
                "hideEasing": "linear",
                "showMethod": "fadeIn",
                "hideMethod": "fadeOut"
            }
            Command: toastr["error"]("Bạn có " + <%:CountCongViecSapHetHan%> + " công việc sắp hết hạn xử lý", "Thông báo")
        };

        function viewPopupVanBan(closeButton, positionClass, timeOut) {
            toastr.options = {
                "closeButton": true,
                "debug": false,
                "positionClass": "toast-bottom-right",
                "onclick": null,
                "showDuration": "1000",
                "hideDuration": "1000",
                "timeOut": "5000",
                "extendedTimeOut": "1000",
                "showEasing": "swing",
                "hideEasing": "linear",
                "showMethod": "fadeIn",
                "hideMethod": "fadeOut"
            }
            Command: toastr["error"]("Bạn có " + <%:CountVanBanSapHetHan%> + " văn bản sắp hết hạn xử lý", "Thông báo")
        };

        <%--<%if (CountCongViecSapHetHan > 0)
          {%>
        showNotification(5000, 'tangerine', false, 'bottom', 'right', 'Bạn có ' + <%:CountCongViecSapHetHan%> + ' công việc sắp hết hạn', '', '', 'pencil');
        <%}%>
        //showNotification(5000, 'ruby', false, 'bottom', 'right', 'Bạn có 5 văn bản sắp hết hạn', '', '', 'pencil');
        function showNotification(life, theme, sticky, horizontalEdge, verticalEdge, content, heading, strClose, icon) {
            var params = {
                life: life,
                theme: theme,
                sticky: sticky,
                horizontalEdge: horizontalEdge,
                verticalEdge: verticalEdge,
            },
            text = content;

            if ($.trim(heading) !== '') {
                params.heading = heading;
            }
            if ($.trim(icon) !== '') {
                params.icon = icon;
            }
            if ($.trim(strClose) !== '') {
                params.closeText = strClose;
            }

            // show notification
            $.notific8('zindex', 11500);
            $.notific8(text, params);
        };--%>
        $("#HomeID").load("/Home/pListHome.aspx");

        <%if (CheckNguoiNhanVanBan == false)
    {%>
        createCloseMessage2("Thông báo", "Đơn vị chưa có người dùng đại diện nhận văn bản. Liên hệ với quản trị hệ thống đơn vị để cấu hình.", "#");
        <%} %>

    });
    function myfocus() {
        $('.modal').on('shown.bs.modal', function () {
            setTimeout(function () {
                $('.form-horizontal').find("input[type=text]:first").focus();
            }, 100);
        });
    }

</script>
<style type="text/css">
    div.portlet-title div.caption span.caption a:visited, div.portlet-title div.caption span.caption a:link, div.portlet-title div.caption span.caption a {
        color: #333;
    }

    .toast-close-button {
        margin-right: -108px !important;
    }

    .portlet > .portlet-title > .captionview {
        float: right;
        display: inline-block;
        font-size: 15px;
        line-height: 12px;
        padding: 10px 0 0;
        text-transform: uppercase;
        font-weight: 700;
        color: #585858;
    }

    /*#home_left .col-md-4, #home_left .col-md-12 {
        padding: 5px !important;
    }*/

    #home_left h5 {
        font-size: 14px;
        font-weight: bold;
        text-transform: uppercase;
    }

    #home_left p {
        font-size: 11px;
        margin-top: -6px;
        color: #545050;
    }

    p.post-summary-2 {
        overflow: hidden;
        display: -webkit-box;
        -webkit-line-clamp: 2;
        -webkit-box-orient: vertical;
    }

    .padding-in-home {
        padding-right: 3px;
        padding-left: 3px;
        padding-bottom: 3px;
    }

    .content-border {
        background: #fff;
        -webkit-box-shadow: 0 3px 2px rgba(0,0,0,0.05);
        box-shadow: 0 3px 2px rgba(0,0,0,0.05);
        box-shadow: 0 3px 2px rgba(0,0,0,0.5)
    }

        .content-border:hover {
            -webkit-box-shadow: 0 3px 2px rgba(0,0,0,0.05);
            box-shadow: 0 3px 2px rgba(0,0,0,0.05);
            box-shadow: 0 3px 2px rgba(0,0,0,0.5)
        }

    .sticky-green .content-border {
        background-color: #d1f9d0b5;
    }

    .sticky-blue .content-border {
        background-color: #d0d5f9b5;
    }

    .sticky-pink .content-border {
        background-color: #f9d0e3b5;
    }
</style>
<%--<div class="row">
    <div class="col-md-12 col-sm-12 ">
        <ol class="breadcrumb ">
            <li><a href="/Pagess/Home.aspx">Trang chủ</a></li>
        </ol>
    </div>
</div>--%>


<div class="row">
    <div class="col-md-8 col-sm-8" id="home_left" style="padding-right: 0px;">

        <div class="col-md-12 col-sm-12  padding-in-home">
            <meta name="viewport" content="width=device-width, initial-scale=1">
            <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/css/bootstrap.min.css">
            <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/js/bootstrap.min.js"></script>
            <div class="panel list-panel" style="margin-bottom: 15px;">
                <div id="myCarousel" class="carousel slide" data-ride="carousel">
                    <!-- Indicators -->
                    <ol class="carousel-indicators">
                        <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
                        <li data-target="#myCarousel" data-slide-to="1"></li>
                        <li data-target="#myCarousel" data-slide-to="2"></li>
                    </ol>

                    <!-- Wrapper for slides -->
                    <div class="carousel-inner" style="height: 40vh;">
                        <div class="item active">
                            <img src="https://www.anovafeed.vn/Data/Sites/1/Banner/banner_chung-nhan-hvn-clc_web-anova-feed-01.jpg" alt="Los Angeles" style="width: 100%;">
                        </div>

                        <div class="item">
                            <img src="https://www.anovafeed.vn/Data/Sites/1/News/12596/hvnclc-4.jpg" alt="Chicago" style="width: 100%;">
                        </div>

                        <div class="item">
                            <img src="https://www.anovafeed.vn/Data/Sites/1/News/342/khanh-thanh-03.jpg" alt="New york" style="width: 100%;">
                        </div>
                    </div>

                    <!-- Left and right controls -->
                    <a class="left carousel-control" href="#myCarousel" data-slide="prev">
                        <span class="glyphicon glyphicon-chevron-left"></span>
                        <span class="sr-only">Previous</span>
                    </a>
                    <a class="right carousel-control" href="#myCarousel" data-slide="next">
                        <span class="glyphicon glyphicon-chevron-right"></span>
                        <span class="sr-only">Next</span>
                    </a>
                </div>
            </div>
        </div>

        <div class="sticky-green">
            <div class="row">
                <div class="col-md-12 col-sm-12" style="margin-top: 15px;">
                    <div class="portlet">
                        <div class="portlet-title">
                            <div class="caption" id="TitleDS">Công việc </div>
                        </div>
                    </div>
                </div>

                <div class="col-md-4 col-sm-4 padding-in-home">
                    <a href="#">
                        <div class="portlet-body">
                            <div class="content-border">
                                <div class="row">
                                    <div class="col-md-4 col-sm-4" style="padding-right: 0px;">
                                        <img src="../Publishing_Resources/img/icon/folder_documents.png" style="width: 100%;" />
                                    </div>
                                    <div class="col-md-8 col-sm-8">
                                        <h5>Hồ Sơ</h5>
                                        <p class="post-summary-2">Công văn đi, công văn đến,...</p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </a>
                </div>
                <div class="col-md-4 col-sm-4 padding-in-home">
                    <a href="../Pagess/cong-viec.aspx">
                        <div class="portlet-body">
                            <div class="content-border">
                                <div class="row">
                                    <div class="col-md-4 col-sm-4" style="padding-right: 0px;">
                                        <img src="../Publishing_Resources/img/icon/text.png" style="width: 100%;" />
                                    </div>
                                    <div class="col-md-8 col-sm-8">
                                        <h5>Công việc</h5>
                                        <p class="post-summary-2">Danh sách công việc...</p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </a>
                </div>
                <div class="col-md-4 col-sm-4 padding-in-home">
                    <a href="../Pagess/quan-ly-ho-so-tai-lieu.aspx">
                        <div class="portlet-body">
                            <div class="content-border">
                                <div class="row">
                                    <div class="col-md-4 col-sm-4" style="padding-right: 0px;">
                                        <img src="../Publishing_Resources/img/icon/chamcong.png" style="width: 140%;" />
                                    </div>
                                    <div class="col-md-8 col-sm-8">
                                        <h5>Quản lý OPL,OJT,CS</h5>
                                        <p class="post-summary-2"></p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </a>
                </div>
            </div>
        </div>

        <div class="sticky-blue">
            <div class="row">
                <div class="col-md-12 col-sm-12" style="margin-top: 15px;">
                    <div class="portlet">
                        <div class="portlet-title">
                            <div class="caption" id="TitleDS">Tiện ích </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-4 col-sm-4 padding-in-home">
                    <a href="../Pagess/lich-hop-cong-tac.aspx">
                        <div class="portlet-body">
                            <div class="content-border">
                                <div class="row">
                                    <div class="col-md-4 col-sm-4" style="padding-right: 0px;">
                                        <img src="../Publishing_Resources/img/icon/meetingicon.png" style="width: 100%;" />
                                    </div>
                                    <div class="col-md-8 col-sm-8">
                                        <h5>Lịch họp</h5>
                                        <p class="post-summary-2">Bạn có bao nhiêu cuộc họp, bạn họp vào thời gian nào? Ở đâu</p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </a>
                </div>
                <div class="col-md-4 col-sm-4 padding-in-home">
                    <a href="javascript:void(0)">
                        <div class="portlet-body">
                            <div class="content-border">
                                <div class="row">
                                    <div class="col-md-4 col-sm-4" style="padding-right: 0px;">
                                        <img src="../Publishing_Resources/img/icon/travel_bus.png" style="width: 100%;" />
                                    </div>
                                    <div class="col-md-8 col-sm-8">
                                        <h5>Điều xe</h5>
                                        <p class="post-summary-2">Bạn cần đi công tác? Các phiếu chờ tôi xử lý...</p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </a>
                </div>
                <div class="col-md-4 col-sm-4 padding-in-home">
                    <a href="javascript:void(0)">
                        <div class="portlet-body">
                            <div class="content-border">
                                <div class="row">
                                    <div class="col-md-4 col-sm-4" style="padding-right: 0px;">
                                        <img src="../Publishing_Resources/img/icon/food.png" style="width: 100%;" />
                                    </div>
                                    <div class="col-md-8 col-sm-8">
                                        <h5>Đăng ký cơm</h5>
                                        <p class="post-summary-2">Đăng ký, tổng hợp suất ăn cho từng đơn vị...</p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </a>
                </div>
                <div class="clearfix"></div>
             
                <div class="col-md-4 col-sm-4 padding-in-home">
                    <a href="../Pagess/lich-ca-nhan.aspx">
                        <div class="portlet-body">
                            <div class="content-border">
                                <div class="row">
                                    <div class="col-md-4 col-sm-4" style="padding-right: 0px;">
                                        <img src="../Publishing_Resources/img/icon/calendar_multiweek.png" style="width: 100%;" />
                                    </div>
                                    <div class="col-md-8 col-sm-8">
                                        <h5>Lịch làm việc</h5>
                                        <p class="post-summary-2">Bạn làm gì hôm nay? Công việc bạn như thế nào?</p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </a>
                </div>
                <div class="col-md-4 col-sm-4 padding-in-home">
                    <a href="../Pagess/thong-bao.aspx">
                        <div class="portlet-body">
                            <div class="content-border">
                                <div class="row">
                                    <div class="col-md-4 col-sm-4" style="padding-right: 0px;">
                                        <img src="../Publishing_Resources/img/icon/ringtone.png" style="width: 100%;" />
                                    </div>
                                    <div class="col-md-8 col-sm-8">
                                        <h5>Thông báo</h5>
                                        <p class="post-summary-2">Thông báo chung.</p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </a>
                </div>
               <div class="col-md-4 col-sm-4 padding-in-home">
                    <a href="javascript:void(0)">
                        <div class="portlet-body">
                            <div class="content-border">
                                <div class="row">
                                    <div class="col-md-4 col-sm-4" style="padding-right: 0px;">
                                        <img src="../Publishing_Resources/img/icon/lightbrown_coffee.png" style="width: 100%;" />
                                    </div>
                                    <div class="col-md-8 col-sm-8">
                                        <h5>Nghỉ phép</h5>
                                        <p class="post-summary-2">Bạn muốn nghỉ phép? tra cứu phép, phiếu nghỉ phép chờ tôi xủ lý...</p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </a>
                </div>
                <div class="clearfix"></div>
                <div class="col-md-4 col-sm-4 padding-in-home">
                    <a href="javascript:void(0)">
                        <div class="portlet-body">
                            <div class="content-border">
                                <div class="row">
                                    <div class="col-md-4 col-sm-4" style="padding-right: 0px;">
                                        <img src="../Publishing_Resources/img/icon/nanosuit_folder_office.png" style="width: 100%;" />
                                    </div>
                                    <div class="col-md-8 col-sm-8">
                                        <h5>Văn phóng phẩm</h5>
                                        <p class="post-summary-2">Phiếu đăng ký VPP chờ tôi xử lý...</p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </a>
                </div>


            </div>
        </div>

        <div class="sticky-pink">
            <div class="row">
                <div class="col-md-12 col-sm-12" style="margin-top: 15px;">
                    <div class="portlet">
                        <div class="portlet-title">
                            <div class="caption" id="TitleDS">Khác </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-4 col-sm-4 padding-in-home">
                    <a href="javascript:void(0)">
                        <div class="portlet-body">
                            <div class="content-border">
                                <div class="row">
                                    <div class="col-md-4 col-sm-4" style="padding-right: 0px;">
                                        <img src="../Publishing_Resources/img/icon/icontexto_aurora_folders_contacts.png" style="width: 100%;" />
                                    </div>
                                    <div class="col-md-8 col-sm-8">
                                        <h5>Danh bạ</h5>
                                        <p class="post-summary-2">Thông tin phòng ban, cán bộ nhân viên, công ty, tập đoàn...</p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </a>
                </div>
                

            </div>
        </div>

    </div>
    <div class="col-md-4 col-sm-4" style="padding-left: 0px;">
        <div class="col-md-12 col-sm-12 ">
            <div class="portlet">
                <div class="portlet-body">

                    <div class="panel list-panel">
                        <img src="https://www.anovafeed.vn/Data/Sites/1/News/12596/hvnclc-4.jpg" width="100%">
                        <h5><b>3 năm liên tiếp đạt chứng nhận “ Hàng Việt Nam Chất lượng cao”</b></h5>
                        <div class="row" style="padding: 13px; margin-top: -15px;">
                            <div class="col-md-4 col-sm-4" style="padding-right: 1px; padding-left: 1px;">
                                <div class="portlet">
                                    <div class="portlet-body">
                                        <div class="">
                                            <img src="https://www.anovafeed.vn/Data/Sites/1/News/12592/img_2539.jpg" width="100%">
                                            <h6><b>Tất niên 2019 “ Trui rèn năng lực - Góp sức vươn xa”</b></h6>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4 col-sm-4" style="padding-right: 1px; padding-left: 1px;">
                                <div class="portlet">
                                    <div class="portlet-body">
                                        <div class="">
                                            <img src="https://www.anovafeed.vn/Data/Sites/1/News/12588/img_4545.jpg" width="100%">
                                            <h6><b>3 năm liên tiếp đạt chứng nhận “ Hàng Việt Nam Chất lượng cao”</b></h6>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4 col-sm-4" style="padding-right: 1px; padding-left: 1px;">
                                <div class="portlet">
                                    <div class="portlet-body">
                                        <div class="">
                                            <img src="https://www.anovafeed.vn/Data/Sites/1/News/12590/img_4476.jpg" width="100%">
                                            <h6><b>Tất niên 2019 “ Trui rèn năng lực - Góp sức vươn xa”</b></h6>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <a href="#" style="float: right; margin-top: -20px;">
                            <p style="font-size: 12px; font-weight: bold;">
                                Xem thêm &gt;&gt;
                            </p>
                        </a>
                    </div>
                </div>
            </div>
        </div>

        <div class="col-md-12 col-sm-12">
            <div class="portlet">
                <div class="portlet-title">
                    <div class="caption" id="TitleDS">Nhân viên xuất sắc </div>
                </div>
                <div class="portlet-body">
                    <style>
                        .content {
                            position: relative;
                            animation: animatop 0.9s cubic-bezier(0.425, 1.14, 0.47, 1.125) forwards;
                        }

                        .card {
                            width: 500px;
                            min-height: 100px;
                            padding: 20px;
                            border-radius: 3px;
                            background-color: white;
                            box-shadow: 0px 10px 20px rgba(0, 0, 0, 0.2);
                            position: relative;
                            overflow: hidden;
                        }

                            .card:after {
                                content: '';
                                display: block;
                                width: 190px;
                                height: 300px;
                                background: #85c44e;
                                position: absolute;
                                animation: rotatemagic 0.75s cubic-bezier(0.425, 1.04, 0.47, 1.105) 1s both;
                            }

                        .badgescard {
                            padding: 10px 20px;
                            border-radius: 3px;
                            background-color: #ECECEC;
                            width: 480px;
                            box-shadow: 0px 10px 20px rgba(0, 0, 0, 0.2);
                            position: absolute;
                            z-index: -1;
                            left: 10px;
                            bottom: 10px;
                            animation: animainfos 0.5s cubic-bezier(0.425, 1.04, 0.47, 1.105) 0.75s forwards;
                        }

                            .badgescard span {
                                font-size: 1.6em;
                                margin: 0px 6px;
                                opacity: 0.6;
                            }

                        .firstinfo {
                            flex-direction: row;
                            z-index: 2;
                            position: relative;
                        }

                            .firstinfo img {
                                border-radius: 50%;
                                width: 120px;
                                height: 120px;
                            }

                            .firstinfo .profileinfo {
                                padding: 0px 20px;
                            }

                                .firstinfo .profileinfo h1 {
                                    font-size: 1.8em;
                                }

                                .firstinfo .profileinfo h3 {
                                    font-size: 1.2em;
                                    color: #009688;
                                    font-style: italic;
                                }

                                .firstinfo .profileinfo p.bio {
                                    padding: 10px 0px;
                                    color: #5A5A5A;
                                    line-height: 1.2;
                                    font-style: initial;
                                }

                        @keyframes animatop {
                            0% {
                                opacity: 0;
                                bottom: -500px;
                            }

                            100% {
                                opacity: 1;
                                bottom: 0px;
                            }
                        }

                        @keyframes animainfos {
                            0% {
                                bottom: 10px;
                            }

                            100% {
                                bottom: -42px;
                            }
                        }

                        @keyframes rotatemagic {
                            0% {
                                opacity: 0;
                                transform: rotate(0deg);
                                top: -24px;
                                left: -253px;
                            }

                            100% {
                                transform: rotate(-30deg);
                                top: -24px;
                                left: -78px;
                            }
                        }
                    </style>
                    <div class="content" style="background: url(../Image/Vuongniem.png) no-repeat scroll right bottom white;background-size: 17%;">
                        <div class="card" style="width: 100%;background:transparent;" >
                            <div class="firstinfo">
                                <img src="https://s3.amazonaws.com/uifaces/faces/twitter/mrvanz/128.jpg">
                                <div class="profileinfo" style="margin-top: -142px; margin-left: 130px;">
                                    <h1 style="font-weight: bold;">Hoàng Việt</h1>
                                    <h3 style="font-size: 1.1em; color: #00962e; font-style: italic; margin-top: 10px;">Nhân viên kinh doanh</h3>

                                    <p class="bio" style="font-size: 12px; font-weight: bold;">
                                        - Top sale tháng 1.
                                    </p>
                                    <p class="bio" style="font-size: 12px; font-weight: bold; margin-top: -20px;">
                                        - Gương mặt của tháng.
                                    </p>
                                    <p class="bio" style="font-size: 12px; font-weight: bold; margin-top: -20px;">
                                        - Nhân viên xuất sắc nhất năm.
                                    </p>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
            </div>

        </div>

        <div class="col-md-12 col-sm-12">
            <div class="portlet" style="margin-top:20px;">
                <div class="portlet-title">
                    <div class="caption" id="TitleDS">Sinh nhật hôm nay </div>
                </div>
                <div class="portlet-body panel panel-body" style="background: url(../Image/sinhnhat.png) no-repeat scroll right bottom white;background-size: 35%;">
                    <style>
                        .event-list {
                            list-style: none;
                            font-family: 'Lato', sans-serif;
                            margin: 0px;
                            padding: 0px;
                        }

                            .event-list > li {
                                background-color: rgb(255, 255, 255);
                                box-shadow: 0px 0px 5px rgb(51, 51, 51);
                                box-shadow: 0px 0px 5px rgba(51, 51, 51, 0.7);
                                padding: 0px;
                                margin: 0px 0px 20px;
                                   
                            }

                                .event-list > li > time {
                                    display: inline-block;
                                    width: 100%;
                                    color: rgb(255, 255, 255);
                                    background-color: rgb(197, 44, 102);
                                    padding: 5px;
                                    text-align: center;
                                    text-transform: uppercase;
                                }

                                .event-list > li:nth-child(even) > time {
                                    background-color: rgb(165, 82, 167);
                                }

                                .event-list > li > time > span {
                                    display: none;
                                }

                                .event-list > li > time > .day {
                                    display: block;
                                    font-size: 56pt;
                                    font-weight: 100;
                                    line-height: 1;
                                }

                                .event-list > li time > .month {
                                    display: block;
                                    font-size: 24pt;
                                    font-weight: 900;
                                    line-height: 1;
                                }

                                .event-list > li > img {
                                    width: 100%;
                                }

                                .event-list > li > .info {
                                    padding-top: 5px;
                                    text-align: center;
                                }

                                    .event-list > li > .info > .title {
                                        font-size: 17pt;
                                        font-weight: 700;
                                        margin: 0px;
                                    }

                                    .event-list > li > .info > .desc {
                                        font-size: 13pt;
                                        font-weight: 300;
                                        margin: 0px;
                                    }

                                    .event-list > li > .info > ul,
                                    .event-list > li > .social > ul {
                                        display: table;
                                        list-style: none;
                                        margin: 10px 0px 0px;
                                        padding: 0px;
                                        width: 100%;
                                        text-align: center;
                                    }

                                .event-list > li > .social > ul {
                                    margin: 0px;
                                }

                                    .event-list > li > .info > ul > li,
                                    .event-list > li > .social > ul > li {
                                        display: table-cell;
                                        cursor: pointer;
                                        color: rgb(30, 30, 30);
                                        font-size: 11pt;
                                        font-weight: 300;
                                        padding: 3px 0px;
                                    }

                                        .event-list > li > .info > ul > li > a {
                                            display: block;
                                            width: 100%;
                                            color: rgb(30, 30, 30);
                                            text-decoration: none;
                                        }

                                    .event-list > li > .social > ul > li {
                                        padding: 0px;
                                    }

                                        .event-list > li > .social > ul > li > a {
                                            padding: 3px 0px;
                                        }

                                        .event-list > li > .info > ul > li:hover,
                                        .event-list > li > .social > ul > li:hover {
                                            color: rgb(30, 30, 30);
                                            background-color: rgb(200, 200, 200);
                                        }

                        .facebook a,
                        .twitter a,
                        .google-plus a {
                            display: block;
                            width: 100%;
                            color: rgb(75, 110, 168) !important;
                        }

                        .twitter a {
                            color: rgb(79, 213, 248) !important;
                        }

                        .google-plus a {
                            color: rgb(221, 75, 57) !important;
                        }

                        .facebook:hover a {
                            color: rgb(255, 255, 255) !important;
                            background-color: rgb(75, 110, 168) !important;
                        }

                        .twitter:hover a {
                            color: rgb(255, 255, 255) !important;
                            background-color: rgb(79, 213, 248) !important;
                        }

                        .google-plus:hover a {
                            color: rgb(255, 255, 255) !important;
                            background-color: rgb(221, 75, 57) !important;
                        }

                        @media (min-width: 768px) {
                            .event-list > li {
                                position: relative;
                                display: block;
                                width: 100%;
                                height: 120px;
                                padding: 0px;
                            }

                                .event-list > li > time,
                                .event-list > li > img {
                                    display: inline-block;
                                }

                                .event-list > li > time,
                                .event-list > li > img {
                                    width: 120px;
                                    float: left;
                                }

                                .event-list > li > .info {
                                    background-color: rgb(245, 245, 245);
                                    overflow: hidden;
                                }

                                .event-list > li > time,
                                .event-list > li > img {
                                    width: 120px;
                                    height: 120px;
                                    padding: 0px;
                                    margin: 0px;
                                }

                                .event-list > li > .info {
                                    position: relative;
                                    height: 120px;
                                    text-align: left;
                                    padding-right: 40px;
                                }

                                    .event-list > li > .info > .title,
                                    .event-list > li > .info > .desc {
                                        padding: 0px 10px;
                                    }

                                    .event-list > li > .info > ul {
                                        position: absolute;
                                        left: 0px;
                                        bottom: 0px;
                                    }

                                .event-list > li > .social {
                                    position: absolute;
                                    top: 0px;
                                    right: 0px;
                                    display: block;
                                    width: 40px;
                                }

                                    .event-list > li > .social > ul {
                                        border-left: 1px solid rgb(230, 230, 230);
                                    }

                                        .event-list > li > .social > ul > li {
                                            display: block;
                                            padding: 0px;
                                        }

                                            .event-list > li > .social > ul > li > a {
                                                display: block;
                                                width: 40px;
                                                padding: 10px 0px 9px;
                                            }
                        }
                    </style>
                    <div class="">
                        <div class="">
                            <div class="">
                                <ul class="event-list">
                                    <li style="height: 75px; padding: 5px;background: transparent;">

                                        <img alt="Independence Day" src="https://www.ruaanhgiare.com/wp-content/uploads/2018/03/anh-the-3x4.jpg" style="width: 74px; height: 66px;">
                                        <div class="info" style="height: 69px;background: transparent;">
                                            <h2 class="title" style="font-size: 15px;">Kiều Thúy Vy</h2>
                                            <p class="desc" style="font-size: 11px; color: #00962e; font-style: italic; margin-top: 2px;">
                                                Văn thư chi nhánh
                                            </p>
                                        </div>
                                    </li>
                                       <li style="height: 75px; padding: 5px;background: transparent;">

                                        <img alt="Independence Day" src="http://laodongngoainuoc.vn/images/uploads/2017/09/16/chup-anh-ho-chieu-mac-ao-gi-2.jpg" style="width: 74px; height: 66px;">
                                        <div class="info" style="height: 69px;background: transparent;">
                                            <h2 class="title" style="font-size: 15px;">Nguyễn Thùy Phương My</h2>
                                            <p class="desc" style="font-size: 11px; color: #00962e; font-style: italic; margin-top: 2px;">
                                               Nhân viên kinh doanh
                                            </p>
                                        </div>
                                    </li>
                                       <li style="height: 75px; padding: 5px;background: transparent;">

                                        <img alt="Independence Day" src="http://2.bp.blogspot.com/-yqHu8ZsQvRg/VjCZdKtyMGI/AAAAAAAAAYA/UA05ZxYe6co/s1600/anh-the-mau-the.jpg" style="width: 74px; height: 66px;">
                                        <div class="info" style="height: 69px;background: transparent;">
                                            <h2 class="title" style="font-size: 15px;">Dương Thùy Dương</h2>
                                            <p class="desc" style="font-size: 11px; color: #00962e; font-style: italic; margin-top: 2px;">
                                                Văn thư chi nhánh
                                            </p>
                                        </div>
                                    </li>


                                </ul>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>

    </div>
</div>








