<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginNew.aspx.cs" Inherits="Viags.WebApp.LoginNew" %>

<!DOCTYPE html>
<!-- saved from url=(0111)/Pagess/van-ban-den.aspx#Field=ThuTu&SoVanBanID=1235&LoaiDanhSachID=0&Page=1&RowPerPage=10 -->
<html dir="ltr" lang="vi-VN">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <meta content='width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0, shrink-to-fit=no' name='viewport' />
    <title>Hệ thống ứng dụng E-Office</title>
    <link href="/Publishing_Resources/img/sg31/icon.ico" rel="shortcut icon" type="image/x-icon" />
    <!--Fonts and icons-->
    <link rel="stylesheet" type="text/css" href="https://fonts.googleapis.com/css?family=Roboto:300,400,500,700|Roboto+Slab:400,700|Material+Icons" />
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.6.1/css/all.css" integrity="sha384-gfdkjb5BdAXd+lj+gudLWI+BXq4IuLW5IT+brZEZsLFm++aCMlF1V92rMkPaX4PP" crossorigin="anonymous" />
    <!-- CSS Files -->
    <link href="/Publishing_Resources/dist/corgi/login/material-dashboard.min.css" rel="stylesheet" />
    <link href="/Publishing_Resources/dist/corgi/login/corgi_login.css" rel="stylesheet" type="text/css" />
    <link href="/Publishing_Resources/dist/corgi/toastr/toastr.min.css" rel="stylesheet" type="text/css" />
</head>
<body class="off-canvas-sidebar">
    <!-- Navbar -->
    <nav class="navbar navbar-expand-lg navbar-transparent navbar-absolute fixed-top text-white">
        <div class="container" style="justify-content: flex-end;">
            <div class="navbar-wrapper">
                <a class="navbar-brand" href="#pablo">
                    <img src="/Publishing_Resources/img/SG31/logo.png" width="120" />
                </a>
            </div>
            <%--<button class="navbar-toggler" type="button" data-toggle="collapse" aria-controls="navigation-index" aria-expanded="false" aria-label="Toggle navigation">
                <span class="sr-only">Toggle navigation</span>
                <span class="navbar-toggler-icon icon-bar"></span>
                <span class="navbar-toggler-icon icon-bar"></span>
                <span class="navbar-toggler-icon icon-bar"></span>
            </button>
            <div class="collapse navbar-collapse justify-content-end">
                <ul class="navbar-nav">
                    <li class="nav-item">
                        <a href="#" class="nav-link">
                            <i class="material-icons">dashboard</i> Trang chủ
                        </a>
                    </li>
                    <li class="nav-item  active ">
                        <a href="LoginNew.aspx" class="nav-link">
                            <i class="material-icons">fingerprint</i> Đăng nhập
                        </a>
                    </li>
                    <li class="nav-item ">
                        <a href="LoginNew.aspx" class="nav-link">
                            <i class="material-icons">lock_open</i> Quên mật khẩu
                        </a>
                    </li>
                </ul>
            </div>--%>
        </div>
    </nav>
    <!-- End Navbar -->
    <div class="wrapper wrapper-full-page">
        <div class="page-header login-page header-filter" filter-color="black" style="background-image: url('/Image/login/backdrop.jpg'); background-size: cover; background-position: top center;">
            <!--   you can change the color of the filter page using: data-color="blue | purple | green | orange | red | rose" -->
            <div class="container">
                <div class="row">
                    <div class="col-lg-4 col-md-6 col-sm-8 ml-auto mr-auto">
                        <link rel="shortcut icon" href="/_catalogs/masterpage/icon.ico">
                        <meta content="width=device-width, initial-scale=1.0" name="viewport">
                        <meta name="description">
                        <meta name="author">
                        <script src="/Publishing_Resources/dist/app.min.js" type="text/javascript"></script>
                        <script type="text/javascript">
                            var urlPostAction = "/ActionLogin.ashx";
                            jQuery(document).ready(function () {
                                Index.init();
                                Layout.init();
                                // init layout
                                $('#LoginForm input').keypress(function (e) {
                                    if (e.keyCode == 13) {
                                        $("#btnLogin").button();
                                    }
                                });
                                setTimeout(function () {
                                    $("#Username").focus();
                                }, 100);
                                $('#LoginForm').validate({
                                    rules: {
                                        Username: { required: true },
                                        Password: { required: true }
                                    },
                                    messages: {
                                        Username: { required: "Bạn phải nhập tên truy cập." },
                                        Password: { required: "Bạn phải nhập mật khẩu." }
                                    },
                                });
                                $("#language").on("change", function () {
                                    $.post(urlPostAction, { "do": "language", "language": $("#language").val() }, function (data) {
                                        window.location.href = window.location.href;
                                    })
                                });
                                getValueLanguage();
                                function getValueLanguage() {
                                    $("#language option").each(function (index) {
                                        if ($(this).val() == getCookie())
                                            $(this).prop("selected", true);
                                    });
                                }
                                function getCookie() {
                                    var name = 'ngonngu' + "=";
                                    var decodedCookie = decodeURIComponent(document.cookie);
                                    var ca = decodedCookie.split(';');
                                    for (var i = 0; i < ca.length; i++) {
                                        var c = ca[i];
                                        while (c.charAt(0) == ' ') {
                                            c = c.substring(1);
                                        }
                                        if (c.indexOf(name) == 0) {
                                            return c.substring(name.length, c.length);
                                        }
                                    }
                                }
                                $("#btnLogin").on("click", function () {
                                    var status = $("#Status").val();
                                    if (status != 0) {
                                        $.post(urlPostAction, $("#LoginForm").mySerialize(), function (data) {
                                            if (data.Error) {
                                                // Tạo thông báo lỗi
                                                DialogAlert('Thông Báo!', data.Title, 'info');
                                                return false;
                                            } else {
                                                if (data.Title == 'true') {
                                                    window.location.href = "/Pagess/home-dash-board.aspx";
                                                }
                                                else {
                                                    window.location.href = "/Pagess/Home.aspx";

                                                }
                                                //window.location.href = "google.com";
                                            }
                                        });
                                    } else {
                                        DialogAlert('Thông Báo!', 'Hãy chọn một icon cảm xúc để đăng nhập vào hệ thống nhé! ', 'info');
                                        return false;
                                    }
                                })
                            });
                            $(document).keypress(function (e) {
                                var keycode = (e.keyCode ? e.keyCode : e.which);
                                if (keycode == '13') {
                                    var status = $("#Status").val();
                                    if (status != 0) {
                                        $.post(urlPostAction, $("#LoginForm").mySerialize(), function (data) {
                                            if (data.Error) {
                                                // Tạo thông báo lỗi
                                                DialogAlert('Thông Báo!', data.Title, 'info');
                                                return false;
                                            } else {
                                                if (data.Title == 'true') {
                                                    window.location.href = "/Pagess/home-dash-board.aspx";
                                                }
                                                else {
                                                    window.location.href = "/Pagess/Home.aspx";

                                                }
                                            }
                                        });
                                    } else {
                                        DialogAlert('Thông Báo!', 'Hãy chọn một icon cảm xúc để đăng nhập vào hệ thống nhé!', 'info');
                                        return false;
                                    }
                                }
                            });
                            function doingonngu(giatri) {
                                $.post(urlPostAction, { "do": "language", "language": giatri }, function (data) {
                                    window.location.href = window.location.href;
                                })
                            }
                        </script>
                        <form class="form" id="LoginForm" runat="server" autocomplete="off">
                            <div class="card card-login card-hidden">
                                <div class="card-header card-header-rose text-center">
                                    <h4 class="card-title">Hệ Thống Ứng Dụng E-OFFICE</h4>
                                    <div class="social-line">
                                        <%--<a href="#pablo" class="btn btn-just-icon btn-link btn-white">
                                            <i class="fab fa-facebook-square"></i>
                                        </a>
                                        <a href="#pablo" class="btn btn-just-icon btn-link btn-white">
                                            <i class="fab fa-google-plus-g"></i>
                                        </a>--%>
                                    </div>
                                </div>
                                <div class="card-body ">
                                    <p class="card-description text-center">Đăng nhập vào hệ thống</p>
                                    <span class="bmd-form-group">
                                        <div class="input-group">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text">
                                                    <i class="material-icons">face</i>
                                                </span>
                                            </div>
                                            <input type="text" class="form-control" name="Username" id="Username" required placeholder="a.nguyenvan">
                                        </div>
                                    </span>
                                    <span class="bmd-form-group">
                                        <div class="input-group">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text">
                                                    <i class="material-icons">lock_outline</i>
                                                </span>
                                            </div>
                                            <input type="password" class="form-control" name="Password" id="Password" required placeholder="Mật khẩu...">
                                        </div>
                                    </span>
                                    <span style="display: none; flex-wrap: nowrap;">
                                        <span style="width: 100px; margin: 10px; text-align: center;">
                                            <input id="dislike" type="checkbox" value="1" onchange="ChangeStatus(this)" />
                                        </span>
                                        <span style="width: 100px; margin: 10px; text-align: center;">
                                            <input id="normal" type="checkbox" value="2" onchange="ChangeStatus(this)" />
                                        </span>
                                        <span style="width: 100px; margin: 10px; text-align: center;">
                                            <input id="like" type="checkbox" value="3" onchange="ChangeStatus(this)" />
                                        </span>
                                    </span>
                                    <span style="display: flex; flex-wrap: nowrap;">
                                        <span style="width: 100px; margin: 10px; text-align: center;">
                                            <img id="icondislike" onclick="EmoClick(this,1)" width="50" src="../Image/icon/icons-sad.png" />
                                        </span>
                                        <span style="width: 100px; margin: 10px; text-align: center;">
                                            <img id="iconnormal" onclick="EmoClick(this,2)" width="50" src="../Image/icon/icons-nornal.png" />
                                        </span>
                                        <span style="width: 100px; margin: 10px; text-align: center;">
                                            <img id="iconlike" onclick="EmoClick(this,3)" width="50" src="../Image/icon/icons-love.png" />
                                        </span>
                                    </span>
                                </div>
                                <div class="card-footer justify-content-center">
                                    <button type="button" id="btnLogin" class="btn btn-rose btn-link btn-lg" style="color: #0066a4; font-weight: 600;">
                                        <%=Resources.Login.lblDangNhap %>
                                    </button>
                                </div>
                                <input type="hidden" id="do" name="do" value="login" />
                                <input type="hidden" id="Status" name="Status" value="0" />
                            </div>
                        </form>
                    </div>
                </div>
            </div>
            <footer class="footer">
                <div class="container">
                    <nav class="float-left">
                        <ul>
                            <li>
                                <a href="https://www.anovafeed.vn/">Anova Feed
                                </a>
                            </li>
                        </ul>
                    </nav>
                    <div class="copyright float-right">
                        &copy; Copyright 
            <script>
                document.write(new Date().getFullYear())
            </script>
                        Anova Feed. All rights reserved.
                    </div>
                </div>
            </footer>
        </div>
    </div>

    <!--   Core JS Files   -->
    <%--<script src="/Publishing_Resources/dist/corgi/login/jquery.min.js"></script>--%>
    <script src="/Publishing_Resources/dist/corgi/toastr/scriptsToastr.js" type="text/javascript"></script>
    <script src="/Publishing_Resources/dist/corgi/toastr/toastr.min.js" type="text/javascript"></script>
    <script src="/Publishing_Resources/dist/corgi/login/popper.min.js"></script>
    <script src="/publishing_resources/dist/corgi/login/perfect-scrollbar.jquery.min.js"></script>
    <script src="/Publishing_Resources/dist/corgi/login/bootstrap-material-design.min.js"></script>
    <script src="/Publishing_Resources/dist/corgi/login/material-dashboard.min.js" type="text/javascript"></script>

    <script>
        $(document).ready(function () {
            $().ready(function () {
                $sidebar = $('.sidebar');

                $sidebar_img_container = $sidebar.find('.sidebar-background');

                $full_page = $('.full-page');

                $sidebar_responsive = $('body > .navbar-collapse');

                window_width = $(window).width();

                fixed_plugin_open = $('.sidebar .sidebar-wrapper .nav li.active a p').html();

                if (window_width > 767 && fixed_plugin_open == 'Dashboard') {
                    if ($('.fixed-plugin .dropdown').hasClass('show-dropdown')) {
                        $('.fixed-plugin .dropdown').addClass('open');
                    }

                }

                $('.fixed-plugin a').click(function (event) {
                    // Alex if we click on switch, stop propagation of the event, so the dropdown will not be hide, otherwise we set the  section active
                    if ($(this).hasClass('switch-trigger')) {
                        if (event.stopPropagation) {
                            event.stopPropagation();
                        } else if (window.event) {
                            window.event.cancelBubble = true;
                        }
                    }
                });

                $('.fixed-plugin .active-color span').click(function () {
                    $full_page_background = $('.full-page-background');

                    $(this).siblings().removeClass('active');
                    $(this).addClass('active');

                    var new_color = $(this).data('color');

                    if ($sidebar.length != 0) {
                        $sidebar.attr('data-color', new_color);
                    }

                    if ($full_page.length != 0) {
                        $full_page.attr('filter-color', new_color);
                    }

                    if ($sidebar_responsive.length != 0) {
                        $sidebar_responsive.attr('data-color', new_color);
                    }
                });

                $('.fixed-plugin .background-color .badge').click(function () {
                    $(this).siblings().removeClass('active');
                    $(this).addClass('active');

                    var new_color = $(this).data('background-color');

                    if ($sidebar.length != 0) {
                        $sidebar.attr('data-background-color', new_color);
                    }
                });

                $('.fixed-plugin .img-holder').click(function () {
                    $full_page_background = $('.full-page-background');

                    $(this).parent('li').siblings().removeClass('active');
                    $(this).parent('li').addClass('active');


                    var new_image = $(this).find("img").attr('src');

                    if ($sidebar_img_container.length != 0 && $('.switch-sidebar-image input:checked').length != 0) {
                        $sidebar_img_container.fadeOut('fast', function () {
                            $sidebar_img_container.css('background-image', 'url("' + new_image + '")');
                            $sidebar_img_container.fadeIn('fast');
                        });
                    }

                    if ($full_page_background.length != 0 && $('.switch-sidebar-image input:checked').length != 0) {
                        var new_image_full_page = $('.fixed-plugin li.active .img-holder').find('img').data('src');

                        $full_page_background.fadeOut('fast', function () {
                            $full_page_background.css('background-image', 'url("' + new_image_full_page + '")');
                            $full_page_background.fadeIn('fast');
                        });
                    }

                    if ($('.switch-sidebar-image input:checked').length == 0) {
                        var new_image = $('.fixed-plugin li.active .img-holder').find("img").attr('src');
                        var new_image_full_page = $('.fixed-plugin li.active .img-holder').find('img').data('src');

                        $sidebar_img_container.css('background-image', 'url("' + new_image + '")');
                        $full_page_background.css('background-image', 'url("' + new_image_full_page + '")');
                    }

                    if ($sidebar_responsive.length != 0) {
                        $sidebar_responsive.css('background-image', 'url("' + new_image + '")');
                    }
                });

                $('.switch-sidebar-image input').change(function () {
                    $full_page_background = $('.full-page-background');

                    $input = $(this);

                    if ($input.is(':checked')) {
                        if ($sidebar_img_container.length != 0) {
                            $sidebar_img_container.fadeIn('fast');
                            $sidebar.attr('data-image', '#');
                        }

                        if ($full_page_background.length != 0) {
                            $full_page_background.fadeIn('fast');
                            $full_page.attr('data-image', '#');
                        }

                        background_image = true;
                    } else {
                        if ($sidebar_img_container.length != 0) {
                            $sidebar.removeAttr('data-image');
                            $sidebar_img_container.fadeOut('fast');
                        }

                        if ($full_page_background.length != 0) {
                            $full_page.removeAttr('data-image', '#');
                            $full_page_background.fadeOut('fast');
                        }

                        background_image = false;
                    }
                });

                $('.switch-sidebar-mini input').change(function () {
                    $body = $('body');

                    $input = $(this);

                    if (md.misc.sidebar_mini_active == true) {
                        $('body').removeClass('sidebar-mini');
                        md.misc.sidebar_mini_active = false;

                        //$('.sidebar .sidebar-wrapper, .main-panel').perfectScrollbar();

                    } else {

                        //$('.sidebar .sidebar-wrapper, .main-panel').perfectScrollbar('destroy');

                        setTimeout(function () {
                            $('body').addClass('sidebar-mini');

                            md.misc.sidebar_mini_active = true;
                        }, 300);
                    }

                    // we simulate the window Resize so the charts will get updated in realtime.
                    var simulateWindowResize = setInterval(function () {
                        window.dispatchEvent(new Event('resize'));
                    }, 180);

                    // we stop the simulation of Window Resize after the animations are completed
                    setTimeout(function () {
                        clearInterval(simulateWindowResize);
                    }, 1000);

                });
            });
        });
    </script>
    <script>
        $(document).ready(function () {
            //md.checkFullPageBackgroundImage();
            setTimeout(function () {
                // after 1000 ms we add the class animated to the login/register card
                $('.card').removeClass('card-hidden');
            }, 700);
        });

        function ChangeStatus(input) {
            var id = $(input).val();
            switch (id) {
                case "1": {
                    $("#like").prop("checked", false);
                    $("#normal").prop("checked", false);
                    $("#Status").val(1);
                    break;
                }
                case "2": {
                    $("#dislike").prop("checked", false);
                    $("#like").prop("checked", false);
                    $("#Status").val(2);
                    break;
                }
                case "3": {
                    $("#dislike").prop("checked", false);
                    $("#normal").prop("checked", false);
                    $("#Status").val(3);
                    break;
                }
            }
        }

        function EmoClick(input,type) {
            switch (type) {
                case 1: {
                    ChangeStatus($("#dislike"))
                    $(input).animate({ 'zoom': 1.5 }, 400);
                    $("#iconlike").animate({ 'zoom': 1 }, 400);
                    $("#iconnormal").animate({ 'zoom': 1 }, 400);
                    break;
                }
                case 2: {
                    ChangeStatus($("#normal"))
                    $(input).animate({ 'zoom': 1.5 }, 400);
                    $("#icondislike").animate({ 'zoom': 1 }, 400);
                    $("#iconlike").animate({ 'zoom': 1 }, 400);
                    break;
                }
                case 3: {
                    ChangeStatus($("#like"))
                    $(input).animate({ 'zoom': 1.5 }, 400);
                    $("#icondislike").animate({ 'zoom': 1 }, 400);
                    $("#iconnormal").animate({ 'zoom': 1 }, 400);
                    break;
                }
                default: {
                    break;
                }
            }
        }
    </script>
</body>
</html>
