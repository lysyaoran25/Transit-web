<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucHomeNewDesign.ascx.cs" Inherits="Viags.WebApp.Home.ucHomeNewDesign" %>

<meta name="viewport" content="width=device-width, initial-scale=1">
<script src="https://cdn.jsdelivr.net/npm/apexcharts"></script>

<script src="/Publishing_Resources/global/plugins/bootstrap-toastr/toastr.js"></script>
<link href="/Publishing_Resources/global/plugins/bootstrap-toastr/toastr.css" rel="stylesheet" type="text/css" />
<link href="/Publishing_Resources/global/plugins/jquery-notific8/jquery.notific8.min.css" rel="stylesheet" type="text/css" />
<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" integrity="sha256-eZrrJcwDc/3uDhsdt61sL2oOBY362qM3lon1gyExkL0=" crossorigin="anonymous" />


<!-- SLICK -->
<!-- Slick JS -->
<script type="text/javascript" src="//cdn.jsdelivr.net/npm/slick-carousel@1.8.1/slick/slick.min.js"></script>
<!-- Slick CSS -->
<link rel="stylesheet" type="text/css" href="//cdn.jsdelivr.net/npm/slick-carousel@1.8.1/slick/slick.css" />
<!-- Slick CSS -->
<link rel="stylesheet" type="text/css" href="//cdn.jsdelivr.net/npm/slick-carousel@1.8.1/slick/slick-theme.css" />

<script type="text/javascript">

</script>

<style>
    .pi-top-10 {
        margin-top: 10px;
        font-weight: 400 !important;
    }

    .pi-bot-20 {
        margin-bottom: 20px;
        font-weight: bolder !important;
    }

    .nvxs-main {
        width: 100%;
        position: absolute;
        top: 0;
        left: 0;
    }

    .slideshow-container {
        position: relative;
        height: 150px;
    }

    .mautam {
        /*color: #d2d2d2 !important;*/
    }

    @media (min-width: 320px) and (max-width: 480px) {
        .BanTinNoiBo {
            padding-top: 20px
        }
    }

    .header {
        text-align: center;
        vertical-align: middle;
        font-size: 20px;
    }


    /*@media (min-width: 320px) and (max-width: 480px) {
        .BanTinNoiBo {
            padding-top: 20px
        }
    }*/


    body {
        background: #eee;
        font-family: Helvetica Neue, Helvetica, Arial, sans-serif;
        font-size: 14px;
        color: #000;
        margin: 0;
        padding: 0;
    }

    h3 {
        margin: 5px 0 10px !important;
    }

    .nhanvienxuatsac {
        padding: 10px !important;
        display: flex !important;
        justify-content: center !important;
        align-content: center;
        border-radius: 15px !important;
        width: 60%;
        min-width: 250px;
        max-width: 80%;
        margin: 0 auto 0 auto !important;
    }

        .nhanvienxuatsac.slick-initialized.slick-slider .slick-list {
            border: 0.5px solid #d1d8e0 !important;
            border-radius: 10px !important;
        }

    .slick-prev, .slick-next {
        background-color: white;
        border: none;
        padding: 0 !important;
        border-radius: 50% !important;
        width: 50px !important;
        height: 50px !important;
        color: #1B9CFC !important;
        justify-content: center !important;
        align-items: center !important;
    }

        /*Sick prev next*/
        .slick-prev:hover,
        .slick-prev:focus,
        .slick-next:hover,
        .slick-next:focus {
            color: #1B9CFC;
            outline: none;
            background-color: white;
        }

            .slick-prev:hover:before,
            .slick-prev:focus:before,
            .slick-next:hover:before,
            .slick-next:focus:before {
                opacity: 1;
            }

        .slick-prev.slick-disabled:before,
        .slick-next.slick-disabled:before {
            opacity: .25;
        }

        .slick-prev:before,
        .slick-next:before {
            font-family: 'slick';
            background-color: white;
            font-size: 30px;
            line-height: 30px;
            opacity: 1;
            color: #1B9CFC;
            margin: auto !important;
        }

    .slick-prev {
        left: -50px;
    }

        .slick-prev:before {
            content: '←';
        }

    .slick-next {
        right: -50px;
    }

        .slick-next:before {
            content: '→';
        }


    .slick-slide {
        transform: scale(0.95);
        transition: transform .2s cubic-bezier(.4, 0, .2, 1);
    }

    /*.slick-center {
        transform: scale(1.0);
        transition: 0.2s;
        border: 3px solid black !important;
    }*/

    .slick-cloned {
        visibility: hidden;
    }

    .our-team {
        padding: 25px;
        background-color: #ffffff;
        text-align: center;
        overflow: hidden;
        position: relative;
        width: 220px;
        min-width: 200px;
        max-width: 300px;
        height: 275px;
        min-height: 275px;
        max-height: 300px;
        margin-left: 15px;
        border: 3px solid #1B9CFC;
        border-radius: 15px !important;
    }

        .our-team .picture {
            display: inline-block;
            height: 100px;
            width: 100px;
            z-index: 1;
            position: relative;
        }

            .our-team .picture::before {
                content: "";
                width: 100%;
                height: 0;
                border-radius: 50% !important;
                background-color: #00a8ff;
                position: absolute;
                bottom: 140%;
                right: 0;
                left: 0;
                opacity: 0.9;
                transform: scale(3);
                transition: all 0.3s linear 0s;
            }

        .our-team:hover .picture::before {
            height: 100%;
            transition: 0.3s;
        }

        .our-team .picture::after {
            content: "";
            width: 100%;
            height: 100%;
            border-radius: 50% !important;
            background-color: #00a8ff;
            position: absolute;
            top: 0;
            left: 0;
            z-index: -1;
        }

        .our-team .picture img {
            width: 100%;
            height: auto;
            border-radius: 50% !important;
            transform: scale(1);
            transition: all 0.4s ease 0s;
        }

        .our-team:hover {
            border: 3px dashed #1B9CFC;
            transition: 0.1s ease-in;
        }

            .our-team:hover .picture img {
                box-shadow: 0 0 0 14px #f7f5ec;
                transform: scale(0.7);
                border: 1px solid #1B9CFC;
                transition: 0.1s;
            }

        .our-team .team-content {
            display: flex !important;
            justify-content: center !important;
        }

            .our-team .team-content .name {
                position: absolute;
                display: flex;
                align-items: center;
                justify-content: center;
                font-size: 18px;
                color: black;
                text-transform: uppercase;
                text-align: center;
                font-weight: bold;
                margin-top: 10px !important;
                padding: 5px 10px 5px 10px;
            }

            .our-team .team-content .title {
                position: absolute;
                display: flex;
                align-items: center;
                justify-content: center;
                text-align: center;
                font-size: 14px;
                text-transform: capitalize;
                border-radius: 20px;
                background-color: #0fbcf9;
                color: white;
                width: auto;
                padding: 5px 10px 5px 10px;
                border: 0.5px solid #0fbcf9;
                font-weight: bold;
                bottom: 0;
                margin-top: 10px !important;
            }

        .our-team .social {
            width: 100%;
            padding: 0;
            margin: 0;
            background-color: #1369ce;
            position: absolute;
            bottom: -100px;
            left: 0;
            transition: all 0.5s ease 0s;
        }

        .our-team:hover .social {
            bottom: 0;
        }

        .our-team .social ul {
            margin-bottom: 0px !important
        }

        .our-team .social li {
            display: inline-block;
        }

            .our-team .social li a {
                /*display: block;
                padding: 10px;
                font-size: 17px;
                color: white;
                transition: all 0.3s ease 0s;
                text-decoration: none;*/
            }

                .our-team .social li a:hover {
                    /*color: #1369ce;
                    background-color: #f7f5ec;*/
                }

    .card_header {
        background-color: white;
        border-radius: 10px !important;
        box-shadow: 0 20px 40px -14px rgba(0,0,0,0.25);
        display: flex;
        flex-direction: column;
        overflow: hidden;
        width: 450px !important;
    }

    .card_header_title {
        font-size: 20px;
        font-weight: 100;
        color: white;
        padding: 10px 0 10px 0;
        background: linear-gradient(50deg,#0066a4,#85c44e) !important;
    }

    .Button-header {
        position: absolute;
        top: 50%;
        left: 50%;
        transform: translate(-50%,-50%);
        width: 85% !important
    }

    .Button-header {
        background: linear-gradient(90deg, #00FFFF, #9900FF);
        border: 1px solid #338033;
        border-radius: 10px !important;
        transition: .6s;
        overflow: hidden;
        font-size: 15px !important
    }

        .Button-header:focus {
            outline: none;
        }

        .Button-header:before {
            content: "";
            display: none;
            position: absolute;
            background: linear-gradient(to right top, #287eff, #00afff, #00d1e5, #00e795, #c0f151);
            height: 100%;
            left: 0;
            top: 0;
            opacity: .5;
            filter: blur(30px);
            transform: translateX(-130px) skewX(-15deg)
        }

        .Button-header:after {
            content: "";
            display: block;
            position: absolute;
            background: linear-gradient(to right top, #21ff1f, #8aff5c, #bbfe8a, #defcb9, #f6fcea);
            /*background: blue;*/
            height: 100%;
            left: 0;
            top: 0;
            opacity: 0;
            filter: blur(30px);
            transform: translate(-100px) scaleX(-15deg)
        }

        .Button-header:hover {
            background: linear-gradient(50deg,#0066a4,#85c44e);
            /*background: blue;*/
            color: white;
            cursor: pointer;
        }

            .Button-header:hover:before {
                transform: translateX(300px) skewX(-15deg);
                opacity: 1;
                transition: .7s;
            }

    .apexcharts-legend-text {
        color: black !important;
    }
    /*Flex*/
    .vertical-items-center {
        display: flex !important;
        align-items: center !important;
    }

    .horizontal-space-between {
        display: flex !important;
        justify-content: space-between !important;
    }

    .horizontal-space-around {
        display: flex !important;
        justify-content: space-around !important;
    }

    .horizontal-left {
        display: flex !important;
        justify-content: flex-start !important;
    }

    .horizontal-right {
        display: flex !important;
        justify-content: flex-end !important;
    }

    .horizontal-center {
        display: flex !important;
        justify-content: center !important;
    }

    .horizontal-space-around .col-md-6.col-sm-6.portlet.content-border.content-padding .portlet-body {
        border: 0.5px solid #d1d8e0 !important;
        border-radius: 10px !important;
    }

    a.nvxs-arrow {
        position: absolute;
        font-size: 30px;
        line-height: 30px;
        padding: 0px;
        font-weight: normal;
        margin-right: 5px;
        margin-left: 5px;
    }

        a.nvxs-arrow .fa {
            color: white !important;
        }

            a.nvxs-arrow .fa:hover {
                color: #018ffb !important;
            }

        a.nvxs-arrow:hover {
            transition: 0.2s;
            transform: scale(1.2);
        }

        a.nvxs-arrow.nvxs-arrow-left {
            right: 6%;
            margin-right: 10px;
        }

        a.nvxs-arrow.nvxs-arrow-right {
            right: 2%;
        }

    .horizontal-space-around .portlet-body.horizontal-center.vertical-items-center {
        height: 350px !important;
    }
</style>

<div class="row">
    <div class="col-md-8 col-sm-8 ml-auto mr-auto">

        
        <%--<h3 class="title text-center">Page Subcategories</h3>
        <br />--%>
        <ul class="nav nav-pills nav-pills-warning nav-pills-icons justify-content-center" role="tablist">
            <li class="nav-item">
                <a class="nav-link active" data-toggle="tab" href="#Work" role="tablist">
                    <i class="material-icons">location_on</i> Công Việc
                </a>
            </li>
            <li class="nav-item">
                <a class="nav-link" data-toggle="tab" href="#Ultility" role="tablist">
                    <i class="material-icons">gavel</i> Tiện Ích
                </a>
            </li>
            <li class="nav-item">
                <a class="nav-link" data-toggle="tab" href="#Other" role="tablist">
                    <i class="material-icons">help_outline</i> Khác
                </a>
            </li>
            <%--<li class="nav-item">
                <a class="nav-link" data-toggle="tab" href="#Hiface" role="tablist">
                    <i class="material-icons">help_outline</i> Hiface
                </a>
            </li>--%>
        </ul>

        <div class="tab-content tab-space tab-subcategories">
            <div class="tab-pane active" id="Work">
                <div class="card card-home">
                    <div class="card-header">
                        <h4 class="card-title">Công Việc</h4>
                        <%--<p class="card-category">
                            More information here
                        </p>--%>
                    </div>
                    <div class="card-body text-center">
                        <div class="col-md-4 col-sm-4">
                            <a href="../Pagess/van-ban-du-thao.aspx">
                                <img src="../Image/icon/icon-document.png" class="img-fluid" />
                                <h4 class="pi-top-10 mautam">Hồ Sơ Trình Ký</h4>
                                <p class="post-summary-2 pi-bot-20">Hồ sơ cần phải trình ký...</p>
                                <%--<p class="post-summary-2 pi-bot-20 mautam">Chức năng đang hoàn thiện.</p>--%>
                            </a>
                        </div>
                        <div class="col-md-4 col-sm-4">
                            <a href="../Pagess/cong-viec.aspx">
                                <img src="../Image/icon/icon-toolbox.png" class="img-fluid" />
                                <h4 class="pi-top-10">Công việc</h4>
                                <p class="post-summary-2 pi-bot-20">Danh sách công việc...</p>
                            </a>
                        </div>
                        <div class="col-md-4 col-sm-4">
                            <a href="../Pagess/quan-ly-ho-so-tai-lieu.aspx">
                                <img src="../Image/icon/icon-box.png" class="img-fluid" />
                                <h4 class="pi-top-10">OPL/OJT/CS</h4>
                                <p class="post-summary-2 pi-bot-20">Quản lý lưu trữ</p>
                            </a>
                        </div>
                    </div>
                </div>
            </div>
            <div class="tab-pane" id="Ultility">
                <div class="card card-home">
                    <div class="card-header">
                        <h4 class="card-title">Tiện Ích</h4>
                    </div>
                    <div class="card-body text-center">
                        <div class="col-md-4 col-sm-4 padding-in-home">
                            <a href="../Pagess/lich-dat-phong.aspx">
                                <img src="../Image/icon/icon-user-male.png" class="img-fluid" />
                                <h4 class="pi-top-10 mautam">Lịch phòng họp</h4>
                                <p class="post-summary-2 pi-bot-20">Bạn có bao nhiêu cuộc họp, bạn họp vào thời gian nào? Ở đâu</p>
                                <%--<p class="post-summary-2 pi-bot-20 mautam">Chức năng đang hoàn thiện.</p>--%>
                            </a>
                        </div>
                        <div class="col-md-4 col-sm-4 padding-in-home">
                            <a href="../Pagess/lich-dat-xe.aspx">
                                <img src="../Image/icon/icon-lunacy.png" class="img-fluid" />
                                <h4 class="pi-top-10 mautam">Đặt xe</h4>
                                <p class="post-summary-2 pi-bot-20">Bạn cần đi công tác? Các phiếu chờ tôi xử lý...</p>
                                <%--<p class="post-summary-2 pi-bot-20 mautam">Chức năng đang hoàn thiện.</p>--%>
                            </a>
                        </div>
                        <div class="col-md-4 col-sm-4 padding-in-home">
                            <a href="../Pagess/dang-ky-com.aspx">
                                <img src="../Image/icon/icon-bookmark.png" class="img-fluid" />
                                <h4 class="pi-top-10 mautam">Đăng ký ca-cơm</h4>
                                <p class="post-summary-2 pi-bot-20">Đăng ký, tổng hợp suất ăn cho từng đơn vị...</p>
                                <%--<p class="post-summary-2 pi-bot-20 mautam">Chức năng đang hoàn thiện.</p>--%>
                            </a>
                        </div>
                        <div class="clearfix"></div>
                        <div class="col-md-4 col-sm-4 padding-in-home">
                            <a href="../Pagess/lich-ca-nhan.aspx">
                                <img src="../Image/icon/icon-calendar.png" class="img-fluid" />
                                <h4 class="pi-top-10">Lịch làm việc</h4>
                                <p class="post-summary-2 pi-bot-20">Bạn làm gì hôm nay? Công việc bạn như thế nào?</p>
                                <%--<p class="post-summary-2 pi-bot-20">Chức năng đang hoàn thiện.</p>--%>
                            </a>
                        </div>
                        <div class="col-md-4 col-sm-4 padding-in-home">
                            <a href="../Pagess/trang-chu.aspx">
                                <img src="../Image/icon/icon-about.png" class="img-fluid" />
                                <h4 class="pi-top-10 mautam">Bản tin - Thông báo</h4>
                                <p class="post-summary-2 pi-bot-20">Bản tin nội bộ - Thông báo</p>
                                <%--<p class="post-summary-2 pi-bot-20 mautam">Chức năng đang hoàn thiện.</p>--%>
                            </a>
                        </div>
                        <div class="col-md-4 col-sm-4 padding-in-home">
                            <a href="../Pagess/list-dang-ky-nghi-phep.aspx">
                                <img src="../Image/icon/icon-puzzle.png" class="img-fluid" />
                                <h4 class="pi-top-10 mautam">Nghỉ phép</h4>
                                <p class="post-summary-2 pi-bot-20">Bạn muốn nghỉ phép? Tra cứu phép, phiếu nghỉ phép chờ tôi xử lý...</p>
                                <%--<p class="post-summary-2 pi-bot-20 mautam">Chức năng đang hoàn thiện.</p>--%>
                            </a>
                        </div>
                        <div class="clearfix"></div>
                        <div class="col-md-4 col-sm-4 padding-in-home">
                            <a href="../Pagess/van-phong-pham-dang-ky.aspx">
                                <img src="../Image/icon/icon-edit.png" class="img-fluid" />
                                <h4 class="pi-top-10 mautam">Văn phòng phẩm</h4>
                                <p class="post-summary-2 pi-bot-20">Phiếu đăng ký VPP chờ tôi xử lý...</p>
                                <%--<p class="post-summary-2 pi-bot-20 mautam">Chức năng đang hoàn thiện.</p>--%>
                            </a>
                        </div>
                    </div>
                </div>
            </div>
            <div class="tab-pane" id="Other">
                <div class="card card-home">
                    <div class="card-header">
                        <h4 class="card-title">Khác</h4>
                    </div>
                    <div class="card-body text-center">
                        <div class="col-md-4 col-sm-4 padding-in-home">
                            <a href="../Pagess/danh-ba.aspx">
                                <img src="../Image/icon/icon-contacts.png" class="img-fluid" />
                                <h4 class="pi-top-10">Danh bạ</h4>
                                <p class="post-summary-2 pi-bot-20">Thông tin phòng ban, nhân viên, công ty, tập đoàn...</p>
                            </a>
                        </div>
                    </div>
                </div>
            </div>
            <%--<div class="tab-pane" id="Hiface">
                <div class="card card-home">
                    <div class="card-header">
                        <h4 class="card-title">Hiface</h4>
                    </div>
                    <div class="card-body text-center">
                        <div class="col-md-4 col-sm-4 padding-in-home">
                            <a href="../Pagess/hiface-nhan-vien.aspx">
                                <img src="../Image/icon/icon-contacts.png" class="img-fluid" />
                                <h4 class="pi-top-10">Nhân viên</h4>
                                <p class="post-summary-2 pi-bot-20">...</p>
                            </a>
                        </div>
                         <div class="col-md-4 col-sm-4 padding-in-home">
                            <a href="../Pagess/hiface-khach-tham-quan.aspx">
                                <img src="../Image/icon/icon-contacts.png" class="img-fluid" />
                                <h4 class="pi-top-10">Khách tham quan</h4>
                                <p class="post-summary-2 pi-bot-20">...</p>
                            </a>
                        </div>
                          <div class="col-md-4 col-sm-4 padding-in-home">
                            <a href="../Pagess/hiface-cham-cong.aspx">
                                <img src="../Image/icon/icon-contacts.png" class="img-fluid" />
                                <h4 class="pi-top-10">Chấm công</h4>
                                <p class="post-summary-2 pi-bot-20">...</p>
                            </a>
                        </div>
                    </div>
                </div>
            </div>--%>
        </div>
</div>
<%--Nhân viên xuất sắc--%>
<script>
    $(document).ready(function () {
        $(".linkfeat").hover(
            function () {
                $(".textfeat").show(500);
            },
            function () {
                $(".textfeat").hide(500);
            }
        );

    });
    $(window).load(function () {
        $('#wrapper').addClass('loaded');
    })

    $('.more-info').click(function () {
        $("#card").toggleClass('flip');
        $('#arrow').remove();
    });
    $('#background').click(function () {
        $('#card').removeClass('flip');
    })

    $(".slideshowsss").each(function () {
        console.log($(this).parent().data("index"));
        var value_index = $(this).parent().data("index");
        var count_value = 0;
        var init = $("#slideshow" + value_index + " > div").length;
        if (init > 1) {
            $("#slideshow" + value_index + " > div:gt(0)").hide();
            setInterval(function () {
                $('#slideshow' + value_index + ' > div:first')
                    .fadeOut(1000)
                    .next()
                    .fadeIn(1000)
                    .end()
                    .appendTo('#slideshow' + value_index);
            }, 7000);
        }
    }); 
</script>







