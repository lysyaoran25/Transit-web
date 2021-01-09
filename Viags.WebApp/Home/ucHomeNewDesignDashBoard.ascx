<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucHomeNewDesignDashBoard.ascx.cs" Inherits="Viags.WebApp.Home.ucHomeNewDesignDashBoard" %>

<meta name="viewport" content="width=device-width, initial-scale=1">
<script src="https://cdn.jsdelivr.net/npm/apexcharts"></script>
<link rel="stylesheet" href="https://unpkg.com/swiper/css/swiper.css">
<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" integrity="sha256-eZrrJcwDc/3uDhsdt61sL2oOBY362qM3lon1gyExkL0=" crossorigin="anonymous" />
<%--<script src="https://unpkg.com/swiper/js/swiper.js"></script>
<script src="../package/js/swiper.min.js"></script>--%>
<!-- SLICK -->
<!-- Slick JS -->
<script type="text/javascript" src="//cdn.jsdelivr.net/npm/slick-carousel@1.8.1/slick/slick.min.js"></script>
<!-- Slick CSS -->
<link rel="stylesheet" type="text/css" href="//cdn.jsdelivr.net/npm/slick-carousel@1.8.1/slick/slick.css" />
<!-- Slick CSS -->
<link rel="stylesheet" type="text/css" href="//cdn.jsdelivr.net/npm/slick-carousel@1.8.1/slick/slick-theme.css" />
<script>
    var urlListsCongViec = "/CongViec/pListCongViec.aspx?type=1";
    var urlListsGiamSat = "/GiamSatCongViec/pListGiamSat.aspx?type=1";
    var urlListsTaiLieu = "/HoSoTaiLieu/AjaxList.aspx?type=1";
    var urlListsHSTK = "/VanBanDuThao/pListVanBanDuThao.aspx?type=1";
    var urlListNghiPhep = "/DangKyNghiPhep/AjaxList.aspx?type=1";

    //initAjaxLoad(urlLists, '#gridview-container', '#gridVanBanDen');

    //type = 1: qlcv
    //type = 2: giamsat
    //type = 3: qltl
    //type = 4: hstk
    //type = 5: dbns
    //type = 6: nghiphep
    function OpenList(donviID, type, input, phongbanID) {
        $('#gridview-container').empty();
        $("#iddonvi").val(donviID);
        switch (type) {
            case 1:
                debugger
                $.address.init().unbind('change');
                initAjaxLoad(urlListsCongViec + "&donviidcv=" + donviID + "&phongbanidcv=" + phongbanID, '#gridview-container', '#gridVanBanDen');
                LoadAjaxPage(urlListsCongViec + "&donviidcv=" + donviID + "&phongbanidcv=" + phongbanID, '#gridview-container');
                $(".Button-header").removeClass("Button_select");
                $(input).addClass("Button_select");
                LoadAjaxPage("/CongViec/pLoadTimKiem.aspx", "#timkiemnangcao");
                $("#clickopensearch").show();
                //$("#SearchView").show();
                break;
            case 2:
                $.address.init().unbind('change');
                initAjaxLoad(urlListsGiamSat + "&donviidgs=" + donviID + "&phongbanidgs=" + phongbanID, '#gridview-container', '#gridVanBanDen');
                LoadAjaxPage(urlListsGiamSat + "&donviidgs=" + donviID + "&phongbanidgs=" + phongbanID, '#gridview-container');
                $(".Button-header").removeClass("Button_select");
                $(input).addClass("Button_select");
                $("#SearchView").hide();

                break;
            case 3:
                debugger;
                $.address.init().unbind('change');
                initAjaxLoad(urlListsTaiLieu + "&donviidhs=" + donviID + "&phongbanidhs=" + phongbanID, '#gridview-container', '#gridDanhMuc');
                LoadAjaxPage(urlListsTaiLieu + "&donviidhs=" + donviID + "&phongbanidhs=" + phongbanID, '#gridview-container');
                $(".Button-header").removeClass("Button_select");
                $(input).addClass("Button_select");
                $("#SearchView").hide();

                break;
            case 4:
                $.address.init().unbind('change');
                initAjaxLoad(urlListsHSTK + "&donviidhstk=" + donviID + "&phongbanidhstk=" + phongbanID, '#gridview-container', '#gridVanBanDuThao');
                LoadAjaxPage(urlListsHSTK + "&donviidhstk=" + donviID + "&phongbanidhstk=" + phongbanID, '#gridview-container');
                $(".Button-header").removeClass("Button_select");
                $(input).addClass("Button_select");
                $("#SearchView").hide();
                break;
            case 5:
                break;
            case 6:
                $.address.init().unbind('change');
                initAjaxLoad(urlListNghiPhep + "&donviidnghiphep=" + donviID + "&phongbanidnghiphep=" + phongbanID, '#gridview-container', '#gridDanhMuc');
                LoadAjaxPage(urlListNghiPhep + "&donviidnghiphep=" + donviID + "&phongbanidnghiphep=" + phongbanID, '#gridview-container');
                $(".Button-header").removeClass("Button_select");
                $(input).addClass("Button_select");
                $("#SearchView").hide();
                break;

        }

    }

    function SearchCongViec() {
        debugger
        focusGridview();
        //fix trường hợp: enter khi chuyển trang
        var inputname = '';
        $("input:focus").each(function () {
            inputname = $(this).attr('name');
        });
        if (inputname != 'page') {
            debugger
            var search = $("#timkiemnangcao").mySerialize();
            window.location.href = '#' + search;
            var urlListsFlows = "/CongViec/pListCongViec.aspx?type=1&donviidcv=" + $("#iddonvi").val();
            urlListsFlows = urlListsFlows + '&' + search;
            LoadAjaxPage(urlListsFlows, '#gridviewflow-container');
            return false;
        }
        else
            return false;
    }
    function OpenSearchBox() {
        $("#SearchView").slideDown()();
    }
    function CloseSearchCV() {
        $("#SearchView").slideUp();

    }
</script>

<style>
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

    .Button_select {
        background: linear-gradient(50deg,#0066a4,#85c44e) !important;
        color: #FFF;
    }

    /*Nhân viên xuất sắc*/
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

    /*Nhân viên xuất sắc*/

    /*Slick custom*/
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
        z-index: 1;
    }

        .slick-prev:before {
            content: '←';
        }

    .slick-next {
        right: -50px;
        z-index: 1;
    }

        .slick-next:before {
            content: '→';
        }

    .slick-slide {
        transform: scale(0.95);
        transition: transform .2s cubic-bezier(.4, 0, .2, 1);
    }

    .nhanvienxuatsac .slick-cloned {
        visibility: hidden;
    }

    .slick-track, .slick-list {
        background-color: #f2f2f2;
    }
    .slick-list {
        border-radius: 10px !important;
        border: 1px solid #b2bec3;  
    }

    .qlcv_slick .slick-dots,
    .ktgs_slick .slick-dots,
    .qlobl_slick .slick-dots,
    .hstk_slick .slick-dots,
    .dbns_slick .slick-dots,
    .dnp_slick .slick-dots {
        bottom: auto !important;
        margin: 0 !important;
    }
    /*Slick custom*/
    /*Title NVXS*/
    .portlet > .portlet-title {
        margin-bottom: 10px !important;
        border-radius: 10px !important;
    }
    /*Title NVXS*/

    /*Button next,prev*/
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
    /*Button next,prev*/

    /*Box nhân viên*/
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

                
    /*Box nhân viên*/

    /*Box quản lí*/
    .card_header {
        background-color: white;
        border-radius: 10px !important;
        display: flex;
        flex-direction: column;
        overflow: hidden;
        width: 100% !important;
        border: 1px solid #b2bec3;
    }

    .card_header_title {
        font-size: 14px;
        font-weight: bold;
        color: white;
        padding: 10px 0 10px 0;
        background: linear-gradient(50deg,#0066a4,#85c44e) !important;
        text-transform: uppercase;
        text-align: center;
    }
    /*Box quản lí*/

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
        background-color: #ffffff !important;
    }

    .horizontal-space-around .portlet-body.horizontal-center.vertical-items-center {
        height: 350px !important;
    }
    /*Flex*/

    /*REGION QUANLY*/
    .action-bar#clickopensearch {
        background-color: #f2f2f2 !important;
        border: 1px solid #b2bec3 !important;
        border-radius: 10px !important;
        box-shadow: none !important;
    }

    .row.quanly-container {
        background-color: #f2f2f2;
        display: flex;
        flex-wrap: wrap;
        justify-content: center;
        border: 1px solid #b2bec3;
        border-radius: 10px !important;
        padding: 10px;
        margin: auto !important;
    }
    /*REGION QUANLY*/

    /*REGION NVXS*/
    .row.horizontal-space-around {
        margin-left: 0 !important;
        margin-right: 0 !important;
        border: 1px solid #b2bec3;
        border-radius: 10px !important;
        background-color: #f2f2f2;
    }

    .portlet-title {
        border-radius: 10px !important;
    }

    .panel.list-panel {
        padding: 10px 20px 10px 20px !important;
        background-color: white !important;
        border-radius: 10px !important;
    }

    .col-md-4.quanly-item {
        display: flex;
        justify-content: center;
        align-items: center;
        padding: 5px !important;
    }

        .col-md-4.quanly-item .card_header .row {
            margin-left: 0 !important;
            margin-right: 0 !important;
            padding: 5px;
        }

            .col-md-4.quanly-item .card_header .row .slick-list,
            .col-md-4.quanly-item .card_header .row .slick-track {
                border-radius: 10px !important;
            }

            .col-md-4.quanly-item .card_header .row .col-sm-0.col-md-0,
            .col-md-4.quanly-item .card_header .row .col-sm-1.col-md-1,
            .col-md-4.quanly-item .card_header .row .col-sm-2.col-md-2,
            .col-md-4.quanly-item .card_header .row .col-sm-3.col-md-3,
            .col-md-4.quanly-item .card_header .row .col-sm-4.col-md-4,
            .col-md-4.quanly-item .card_header .row .col-sm-5.col-md-5,
            .col-md-4.quanly-item .card_header .row .col-sm-6.col-md-6,
            .col-md-4.quanly-item .card_header .row .col-sm-7.col-md-7,
            .col-md-4.quanly-item .card_header .row .col-sm-8.col-md-8,
            .col-md-4.quanly-item .card_header .row .col-sm-9.col-md-9,
            .col-md-4.quanly-item .card_header .row .col-sm-10.col-md-10,
            .col-md-4.quanly-item .card_header .row .col-sm-11.col-md-11,
            .col-md-4.quanly-item .card_header .row .col-sm-12.col-md-12 {
                height: 65px;
                margin-top: 5px;
                margin-bottom: 5px;
                margin-left: 0;
                margin-right: 0;
                padding-left: 5px !important;
                padding-right: 5px !important;
                display: flex;
                justify-content: center;
                align-items: center;
            }

                .col-md-4.quanly-item .card_header .row .col-sm-0.col-md-0.slick-slide,
                .col-md-4.quanly-item .card_header .row .col-sm-1.col-md-1.slick-slide,
                .col-md-4.quanly-item .card_header .row .col-sm-2.col-md-2.slick-slide,
                .col-md-4.quanly-item .card_header .row .col-sm-3.col-md-3.slick-slide,
                .col-md-4.quanly-item .card_header .row .col-sm-4.col-md-4.slick-slide,
                .col-md-4.quanly-item .card_header .row .col-sm-5.col-md-5.slick-slide,
                .col-md-4.quanly-item .card_header .row .col-sm-6.col-md-6.slick-slide,
                .col-md-4.quanly-item .card_header .row .col-sm-7.col-md-7.slick-slide,
                .col-md-4.quanly-item .card_header .row .col-sm-8.col-md-8.slick-slide,
                .col-md-4.quanly-item .card_header .row .col-sm-9.col-md-9.slick-slide,
                .col-md-4.quanly-item .card_header .row .col-sm-10.col-md-10.slick-slide,
                .col-md-4.quanly-item .card_header .row .col-sm-11.col-md-11.slick-slide,
                .col-md-4.quanly-item .card_header .row .col-sm-12.col-md-12.slick-slide {
                    padding-left: 0px !important;
                    padding-right: 0px !important;
                }
    /*REGION NVXS*/
    /*Ajax box load*/
    #gridVanBanDen.content-padding {
        margin-top: 20px;
        border: 1px solid #b2bec3;
        border-radius: 10px !important;
        background-color: #f2f2f2;
    }

    #gridDanhMuc.content-padding {
        margin-top: 20px;
        border: 1px solid #b2bec3;
        border-radius: 10px !important;
        background-color: #f2f2f2;
    }

    #gridVanBanDuThao.content-padding {
        margin-top: 20px;
        border: 1px solid #b2bec3;
        border-radius: 10px !important;
        background-color: #f2f2f2;
    }
    /*Ajax box load*/

    /* Search box form*/
    #SearchView .content-border.content-padding {
        margin-top: 20px;
        border: 1px solid #b2bec3 !important;
        border-radius: 10px !important;
        padding: 10px 10px 10px 10px !important;
    }
    /* Search box form*/

    /*Button*/
    .Button-header {
        position: relative;
        height: 100%;
        max-height: 80px;
        width: 100% !important;
        white-space: nowrap;
        border-radius: 10px !important;
        border: none;
        background-image: linear-gradient(to right, #25aae1, #4481eb, #04befe, #3f86ed);
        background-size: 300% 100%;
        cursor: pointer;
        font-size: 18px;
        color: white;
        -o-transition: all .4s ease-in-out;
        -webkit-transition: all .4s ease-in-out;
        transition: all .4s ease-in-out;
        text-align: center;
    }

        .Button-header:focus {
            outline: none;
            box-shadow: 0 0 0 4px #00a8ff;
        }

        .Button-header:hover {
            background-position: 100% 0;
            -o-transition: all .4s ease-in-out;
            -webkit-transition: all .4s ease-in-out;
            transition: all .4s ease-in-out;
        }
    /*Button*/
</style>

<script>
    var objectKhuVucNVXS = JSON.parse('<%=LstKhuVucNVXS%>');
    var checkkhuvuc =<%=dashBoardDA.GetListKhuVucNVXS().Count()%> ;
    var chartNVThang = "";
    var chartNVQuy = "";
    function getChartNhanVien() {
        var Series = '';
        var Labels = '';
        debugger;
        if (checkkhuvuc == 0) {
            Series =<%=Series%>;
            Labels = <%=Labels%>;

        } else {
            Series =<%=SeriesKhuVuc%>;
            Labels = <%=LabelsKhuVuc%>;
        }
        var object = JSON.parse('<%=LstDonViID%>');
        var object2 = JSON.parse('<%=LstPhongBanID%>');

        var options = {
            series: Series,
            chart: {
                width: 380,
                type: 'pie',
                events: {
                    dataPointSelection: function (event, chartContext, config) {
                        debugger;
                        var DonViID = config.dataPointIndex;
                        var currentpb = <%=CurrentUser.LtsPhongBanID.FirstOrDefault()%>;
                        var temp = object2[DonViID];
                        if (currentpb == temp) {
                            LoadNhanVienXacSac(null, 1, 0, moment().year(),<%=dashBoardDA.GetQuy() - 1 ==0 ? 4 :dashBoardDA.GetQuy() - 1 %>);

                        } else if (checkkhuvuc != 0) {
                            LoadNhanVienXacSac(object[DonViID], 1, 0, moment().year(),<%=dashBoardDA.GetQuy() - 1 ==0 ? 4 :dashBoardDA.GetQuy() - 1 %>);
                        }
                        else {
                            $('.nhanvienxuatsac').empty();

                        }
                    }
                },
            },
            labels: Labels,
            responsive: [{
                breakpoint: 480,
                options: {
                    chart: {
                        width: 200
                    },
                    legend: {
                        position: 'bottom'
                    }
                }
            }],

        };

        chartNVQuy = new ApexCharts(document.querySelector("#chartNhanVien"), options);
        chartNVQuy.render();
    }

    function getChartNhanVienThang() {
        var Series = '';
        var Labels = '';
        debugger;
        if (checkkhuvuc == 0) {
            Series =<%=Series2%>;
            Labels = <%=Labels2%>;

        } else {
            Series =<%=SeriesKhuVuc2%>;
            Labels = <%=LabelsKhuVuc2%>;
        }

        var object = JSON.parse('<%=LstDonViID2%>');
        var object2 = JSON.parse('<%=LstPhongBanID2%>');

        //console.log(object2);

        var options = {
            series: Series,
            chart: {
                width: 380,
                type: 'pie',
                events: {
                    dataPointSelection: function (event, chartContext, config) {
                        debugger;
                        var DonViID = config.dataPointIndex;
                        var currentpb = <%=CurrentUser.LtsPhongBanID.FirstOrDefault()%>;
                        var temp = object2[DonViID];
                        if (currentpb == temp && checkkhuvuc == 0) {
                            LoadNhanVienXacSac(null, 2, moment().month(), moment().year(), 0);

                        } else if (checkkhuvuc != 0) {
                            LoadNhanVienXacSac(object[DonViID], 2, moment().month(), moment().year(), 0);
                        }
                        else {
                            $('.nhanvienxuatsac').empty();
                        }

                    }
                },
            },
            labels: Labels,
            responsive: [{
                breakpoint: 480,
                options: {
                    chart: {
                        width: 200
                    },
                    legend: {
                        position: 'bottom'
                    }
                }
            }],

        };

        chartNVThang = new ApexCharts(document.querySelector("#chartNhanVienThang"), options);
        chartNVThang.render();
    }

    function getChartCaiTien() {
        var Series =<%=Series%>;
        var Labels = <%=Labels%>;
        var options = {
            series: Series,
            chart: {
                width: 380,
                type: 'pie',
                events: {
                    dataPointSelection: function (event, chartContext, config) {


                    }
                },
            },
            labels: Labels,
            responsive: [{
                breakpoint: 480,
                options: {
                    chart: {
                        width: 200
                    },
                    legend: {
                        position: 'bottom'
                    }
                }
            }]
        };

        var chart = new ApexCharts(document.querySelector("#chartCaiTien"), options);
        chart.render();
    }
    var count = 0;
    /* LOAD NHÂN VIÊN XUẤT SẮC */
    function LoadNhanVienXacSac(khuvucnvxs, timetype, Month, Year, Quater) {
        $.ajax({
            type: "POST",
            url: "/QuanLyDashBoard/NhanVienXuatSac/AjaxList.aspx/GetListNhanVien",
            data: JSON.stringify({ KhuVucNVXS: khuvucnvxs, TimeType: timetype, month: Month, year: Year, quarter: Quater }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                if (count > 0) {
                    $('.nhanvienxuatsac').slick('unslick')
                }
                $('.nhanvienxuatsac').empty();
                $('.nhanvienxuatsac').append(data.d);
                $('.nhanvienxuatsac').slick({
                    slidesToShow: 1,
                    slidesToScroll: 1,
                    autoplay: true,
                    adaptiveHeight: true,
                    variableWidth: true,
                    autoplaySpeed: 0,
                    speed: 1500,
                    infinite: true,
                    dots: true,
                    centerMode: true,
                    cssEase: 'linear',
                });
                count++;
            },
        });
    }
    var now = moment();
    var now1 = moment();
    var quy = <%=dashBoardDA.GetQuy() - 1 ==0 ? 4 :dashBoardDA.GetQuy() - 1  %>;

        /* NEXT MONTH BUTTON */
    function NextMonth() {
        now = now.add(1, 'months');
        console.log(now.month())
        $("#chartNhanVienThang").empty();
        $('.nhanvienxuatsac').empty();
        $.ajax({
            type: "POST",
            url: "/QuanLyDashBoard/NhanVienXuatSac/AjaxList.aspx/NextPreMonth",
            data: JSON.stringify({ CheckKhuVuc: checkkhuvuc, ListKhuVucNVXS: objectKhuVucNVXS, Month: now.month(), Year: now.year() }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                var bb = JSON.parse(data.d)
                $("#TitleMonth").text("Nhân viên xuất sắc Tháng " + now.month() + "/" + now.year())
                var Series = JSON.parse(bb.series);
                var Labels = JSON.parse(bb.label);
                var object = JSON.parse(bb.LstDonViID);

                <%--chartNVThang.updateOptions({
                    series: Series,
                    chart: {
                        width: 380,
                        type: 'pie',
                        events: {
                            dataPointSelection: function (event, chartContext, config) {
                                var cc = now.month();
                                var xx = moment().month();
                                var DonViID = config.dataPointIndex;
                                var currentpb = <%=CurrentUser.LtsPhongBanID.FirstOrDefault()%>;
                                var temp = object[DonViID];
                                if (currentpb == temp) {
                                    LoadNhanVienXacSac(null, 2, now.month(), now.year(), 0);
                                } else if (checkkhuvuc != 0) {
                                    LoadNhanVienXacSac(object[DonViID], 2, now.month(), now.year(), 0);
                                }
                                else {
                                    $('.nhanvienxuatsac').empty();

                                }
                            }
                        },
                    },
                    labels: Labels,

                })--%>
                //chartNVThang.render();

                var options = ({
                    series: Series,
                    chart: {
                        width: 380,
                        type: 'pie',
                        events: {
                            dataPointSelection: function (event, chartContext, config) {
                                var cc = now.month();
                                var xx = moment().month();
                                var DonViID = config.dataPointIndex;
                                var currentpb = <%=CurrentUser.LtsPhongBanID.FirstOrDefault()%>;
                                var temp = object[DonViID];
                                if (currentpb == temp) {
                                    LoadNhanVienXacSac(null, 2, now.month(), now.year(), 0);
                                } else if (checkkhuvuc != 0) {
                                    LoadNhanVienXacSac(object[DonViID], 2, now.month(), now.year(), 0);
                                }
                                else {
                                    $('.nhanvienxuatsac').empty();

                                }
                            }
                        },
                    },
                    labels: Labels,
                    noData: {
                        text: 'Chưa có dữ liệu'
                    },
                })
                chartNVThang = new ApexCharts(document.querySelector("#chartNhanVienThang"), options);
                chartNVThang.render();

            }
        });
    }

    /* PREVIOUS MONTH BUTTON */
    function PreviousMonth() {
        now = now.add(-1, 'months');
        $("#chartNhanVienThang").empty();
        $('.nhanvienxuatsac').empty();
        $.ajax({
            type: "POST",
            url: "/QuanLyDashBoard/NhanVienXuatSac/AjaxList.aspx/NextPreMonth",
            data: JSON.stringify({ CheckKhuVuc: checkkhuvuc, ListKhuVucNVXS: objectKhuVucNVXS, Month: now.month(), Year: now.year() }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                var bb = JSON.parse(data.d)
                $("#TitleMonth").text("Nhân viên xuất sắc Tháng " + now.month() + "/" + now.year())
                var Series = JSON.parse(bb.series);
                var Labels = JSON.parse(bb.label);
                var object = JSON.parse(bb.LstDonViID);

                <%--chartNVThang.updateOptions({
                    series: Series,
                    chart: {
                        width: 380,
                        type: 'pie',
                        events: {
                            dataPointSelection: function (event, chartContext, config) {

                                var DonViID = config.dataPointIndex;
                                var currentpb = <%=CurrentUser.LtsPhongBanID.FirstOrDefault()%>;
                                var temp = object[DonViID];
                                if (currentpb == temp) {
                                    LoadNhanVienXacSac(null, 2, now.month(), now.year(), 0);

                                } else if (checkkhuvuc != 0) {
                                    LoadNhanVienXacSac(object[DonViID], 2, now.month(), now.year(), 0);
                                }
                                else {
                                    $('.nhanvienxuatsac').empty();

                                }
                            }
                        },
                    },
                    labels: Labels,

                })--%>

                //chartNVThang.render();

                var options = ({
                    series: Series,
                    chart: {
                        width: 380,
                        type: 'pie',
                        events: {
                            dataPointSelection: function (event, chartContext, config) {

                                var DonViID = config.dataPointIndex;
                                var currentpb = <%=CurrentUser.LtsPhongBanID.FirstOrDefault()%>;
                                var temp = object[DonViID];
                                if (currentpb == temp) {
                                    LoadNhanVienXacSac(null, 2, now.month(), now.year(), 0);

                                } else if (checkkhuvuc != 0) {
                                    LoadNhanVienXacSac(object[DonViID], 2, now.month(), now.year(), 0);
                                }
                                else {
                                    $('.nhanvienxuatsac').empty();

                                }
                            }
                        },
                    },
                    labels: Labels,
                    noData: {
                        text: 'Chưa có dữ liệu'
                    },
                })
                chartNVThang = new ApexCharts(document.querySelector("#chartNhanVienThang"), options);
                chartNVThang.render();
            }
        });
    }

    /* NEXT QUATER BUTTON */
    function NextQuater() {
        quy = quy + 1;
        if (quy > 4) {
            quy = 1;
            now1.add(1, 'years');
        }
        $("#chartNhanVien").empty();
        $('.nhanvienxuatsac').empty();
        $.ajax({
            type: "POST",
            url: "/QuanLyDashBoard/NhanVienXuatSac/AjaxList.aspx/NextPreQuater",
            data: JSON.stringify({ CheckKhuVuc: checkkhuvuc, ListKhuVucNVXS: objectKhuVucNVXS, Quy: quy, Year: now1.year() }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                var bb = JSON.parse(data.d)
                $("#TitleQuater").text("Nhân viên xuất sắc quý " + quy + "/" + now1.year())
                var Series = JSON.parse(bb.series);
                var Labels = JSON.parse(bb.label);
                var object = JSON.parse(bb.LstDonViID);

               <%-- chartNVQuy.updateOptions({
                    series: Series,
                    chart: {
                        width: 380,
                        type: 'pie',
                        events: {
                            dataPointSelection: function (event, chartContext, config) {

                                var DonViID = config.dataPointIndex;
                                var currentpb = <%=CurrentUser.LtsPhongBanID.FirstOrDefault()%>;
                                var temp = object[DonViID];
                                if (currentpb == temp) {
                                    LoadNhanVienXacSac(null, 1, 0, now1.year(), quy);
                                } else if (checkkhuvuc != 0) {
                                    LoadNhanVienXacSac(object[DonViID], 1, 0, now1.year(), quy);
                                }
                                else {
                                    $('.nhanvienxuatsac').empty();

                                }

                            }
                        },
                    },
                    labels: Labels,

                })--%>
                //chartNVThang.render();

                var options = ({
                    series: Series,
                    chart: {
                        width: 380,
                        type: 'pie',
                        events: {
                            dataPointSelection: function (event, chartContext, config) {

                                var DonViID = config.dataPointIndex;
                                var currentpb = <%=CurrentUser.LtsPhongBanID.FirstOrDefault()%>;
                                var temp = object[DonViID];
                                if (currentpb == temp) {
                                    LoadNhanVienXacSac(null, 1, 0, now1.year(), quy);
                                } else if (checkkhuvuc != 0) {
                                    LoadNhanVienXacSac(object[DonViID], 1, 0, now1.year(), quy);
                                }
                                else {
                                    $('.nhanvienxuatsac').empty();

                                }

                            }
                        },
                    },
                    labels: Labels,
                    noData: {
                        text: 'Chưa có dữ liệu'
                    },
                })
                chartNVQuy = new ApexCharts(document.querySelector("#chartNhanVien"), options);
                chartNVQuy.render();
            }
        });
    }

    /* PREVIOUS QUATER BUTTON */
    function PreviousQuater() {
        quy = quy - 1;
        if (quy == 0) {
            quy = 4;
            now1.add(-1, 'years');
        }
        $("#chartNhanVien").empty();
        $('.nhanvienxuatsac').empty();
        $.ajax({
            type: "POST",
            url: "/QuanLyDashBoard/NhanVienXuatSac/AjaxList.aspx/NextPreQuater",
            data: JSON.stringify({ CheckKhuVuc: checkkhuvuc, ListKhuVucNVXS: objectKhuVucNVXS, Quy: quy, Year: now1.year() }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                var bb = JSON.parse(data.d)
                $("#TitleQuater").text("Nhân viên xuất sắc quý " + quy + "/" + now1.year())
                var Series = JSON.parse(bb.series);
                var Labels = JSON.parse(bb.label);
                var object = JSON.parse(bb.LstDonViID);

                <%--chartNVQuy.updateOptions({
                    series: Series,
                    chart: {
                        width: 380,
                        type: 'pie',
                        events: {
                            dataPointSelection: function (event, chartContext, config) {

                                var DonViID = config.dataPointIndex;
                                var currentpb = <%=CurrentUser.LtsPhongBanID.FirstOrDefault()%>;
                                var temp = object[DonViID];
                                if (currentpb == temp) {
                                    LoadNhanVienXacSac(null, 1, 0, now1.year(), quy);

                                } else if (checkkhuvuc != 0) {
                                    LoadNhanVienXacSac(object[DonViID], 1, 0, now1.year(), quy);
                                }
                                else {
                                    $('.nhanvienxuatsac').empty();

                                }
                            }
                        },
                    },
                    labels: Labels,

                })--%>
                //chartNVThang.render();

                var options = ({
                    series: Series,
                    chart: {
                        width: 380,
                        type: 'pie',
                        events: {
                            dataPointSelection: function (event, chartContext, config) {

                                var DonViID = config.dataPointIndex;
                                var currentpb = <%=CurrentUser.LtsPhongBanID.FirstOrDefault()%>;
                                var temp = object[DonViID];
                                if (currentpb == temp) {
                                    LoadNhanVienXacSac(null, 1, 0, now1.year(), quy);

                                } else if (checkkhuvuc != 0) {
                                    LoadNhanVienXacSac(object[DonViID], 1, 0, now1.year(), quy);
                                }
                                else {
                                    $('.nhanvienxuatsac').empty();

                                }
                            }
                        },
                    },
                    labels: Labels,
                    noData: {
                        text: 'Chưa có dữ liệu'
                    },
                })
                chartNVQuy = new ApexCharts(document.querySelector("#chartNhanVien"), options);
                chartNVQuy.render();
            }
        });
    }

</script>
<input type="hidden" id="iddonvi" name="iddonvi" value="" />
<div class="row" style="padding: 0; margin-left:0; margin-right: 0">

    <!-- LIST QUẢN LÍ-->
    <div class="row quanly-container">

        <!--Quản lý công việc-->
        <div class="col-md-4 quanly-item ">
            <div class="card_header">
                <!-- Header-->
                <div class="card_header_title">Quản lý công việc (Quá hạn)</div>

                <%if (nd.CheckUserCEO() == false && CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.XemDashboardToanKhuVuc))
                    {%>
                <div class="row">
                    <div class="qlcv_slick">
                        <%foreach (var item in LstDonvi.OrderBy(a => a.ThuTu))
                            {%>
                        <div class="col-sm-12 col-md-12 col-lg-12 col-xl-12">
                            <button class="Button-header" type="button" onclick="OpenList(<%=item.ID%>,1,this,-1)" title="<%=item.TenVietTat %>">
                                <%=DonViItem.TenVietTat.Length > 20 ? item.TenVietTat.Substring(0, 5) : item.TenVietTat %>
                                <br />
                                <%=CongViecDA.CountCongViecQuaHan_StoreProcedures(item.ID) %>
                            </button>
                        </div>
                        <%} %>
                    </div>
                </div>
                <%}
                    else if (nd.CheckUserCEO() == false && CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.XemDashBoard))
                    {%>

                <div class="row">
                    <%if (NguoiDungDA.GetKhuVucDashBoardUser(CurrentUser.ID).Count() == 0)
                        {%>
                    <div class="qlcv_slick">
                        <div class="col-sm-12 col-md-12 col-lg-12 col-xl-12">
                            <button class="Button-header" type="button" onclick="OpenList(<%=DonViItem.ID%>,1,this,-1)" title="<%=DonViItem.TenVietTat %>">
                                <%=DonViItem.TenVietTat.Length > 20 ? DonViItem.TenVietTat.Substring(0, 5) : DonViItem.TenVietTat %>
                                <br />
                                <%=CongViecDA.CountCongViecQuaHan_StoreProcedures(DonViItem.ID) %>
                            </button>
                        </div>
                    </div>
                    <%}
                        else
                        {%>
                    <div class="qlcv_slick">
                        <%foreach (var item in NguoiDungDA.GetKhuVucDashBoardUser(CurrentUser.ID))
                            {%>
                        <%--<div class="col-sm-<%=12/NguoiDungDA.GetKhuVucDashBoardUser(CurrentUser.ID).Count() %> col-md-<%=12/NguoiDungDA.GetKhuVucDashBoardUser(CurrentUser.ID).Count() %>">
                        <button class="Button-header" type="button" onclick="OpenList(<%=item.KhuVucID%>,1,this,<%=item.PhongBanID %>)" title="<%=item.TenPhongBan+"-"+ item.TenKhuVuc %>">
                            <%=item.TenKhuVuc.Length > 20 ? item.TenPhongBan+"-"+ item.TenKhuVuc.Substring(0, 5) :item.TenPhongBan+"-"+ item.TenKhuVuc %>
                            <br />
                            <%=CongViecDA.GetListCongViecKhongPhanTrangCustom(item.KhuVucID, item.PhongBanID) %>
                        </button>
                    </div>--%>
                        <div class="col-sm-12 col-md-12 col-lg-12 col-xl-12">
                            <button class="Button-header" type="button" onclick="OpenList(<%=item.KhuVucID%>,1,this,<%=item.PhongBanID %>)" title="<%=item.TenPhongBan+"-"+ item.TenKhuVuc %>">
                                <%=item.TenKhuVuc.Length > 20 ? item.TenPhongBan+"-"+ item.TenKhuVuc.Substring(0, 5) :item.TenPhongBan+"-"+ item.TenKhuVuc %>
                                <br />
                                <%=CongViecDA.CountCongViecQuaHan_StoreProcedures(item.KhuVucID, item.PhongBanID) %>
                            </button>
                        </div>
                        <%} %>
                    </div>
                    <%} %>
                </div>

                <%}
                    else
                    {%>
                <div class="qlcv_slick">
                    <div class="col-sm-4 col-md-4">
                        <button class="Button-header" type="button">
                            AF<br />
                            <%=TotalCountQLCV%>
                        </button>
                    </div>
                    <%foreach (var item in LstDonvi.OrderBy(a => a.ThuTu))
                        {%>
                    <div class="col-sm-4 col-md-4">
                        <button class="Button-header" type="button" onclick="OpenList(<%=item.ID%>,1,this,-1)" title="<%=item.TenVietTat %>">
                            <%=item.TenVietTat.Length > 20 ? item.TenVietTat.Substring(0, 5) : item.TenVietTat %>
                            <br />
                            <%=CongViecDA.CountCongViecQuaHan_StoreProcedures(item.ID) %>
                        </button>
                    </div>
                    <%} %>
                </div>
                <%} %>
            </div>
        </div>
        <!--Quản lý công việc-->

        <!--Kiểm tra giám sát-->
        <div class="col-md-4 quanly-item">
            <div class="card_header">
                <div class="card_header_title">Kiểm tra giám sát (Quá hạn)</div>
                <%if (nd.CheckUserCEO() == false && CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.XemDashboardToanKhuVuc))
                    {%>
                <div class="row">
                    <div class="ktgs_slick">
                        <%foreach (var item in LstDonvi.OrderBy(a => a.ThuTu))
                            {%>
                        <div class="col-sm-12 col-md-12 col-lg-12 col-xs-12">
                            <button class="Button-header" type="button" onclick="OpenList(<%=item.ID%>,2,this,-1)" title="<%=item.TenVietTat %>">
                                <%=item.TenVietTat.Length > 20 ? item.TenVietTat.Substring(0, 5) : item.TenVietTat %>
                                <br />
                                <%=CongViecDA.CountGiamSatDashBoard_StoreProcedures(item.ID) %>
                            </button>
                        </div>
                        <%} %>
                    </div>
                </div>
                <%}
                    else if (nd.CheckUserCEO() == false && CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.XemDashBoard))
                    {%>
                <div class="row">
                    <%if (NguoiDungDA.GetKhuVucDashBoardUser(CurrentUser.ID).Count() == 0)
                        {%>
                    <div class="ktgs_slick">
                        <div class="col-sm-12 col-md-12 col-lg-12 col-xs-12">
                            <button class="Button-header" type="button" onclick="OpenList(<%=DonViItem.ID%>,2,this,-1)" title="<%=DonViItem.TenVietTat %>">
                                <%=DonViItem.TenVietTat.Length > 20 ? DonViItem.TenVietTat.Substring(0, 5) : DonViItem.TenVietTat %>
                                <br />
                                <%=CongViecDA.CountGiamSatDashBoard_StoreProcedures(DonViItem.ID) %>
                            </button>
                        </div>
                    </div>
                    <%}
                        else
                        {%>
                    <div class="ktgs_slick">
                        <%foreach (var item in NguoiDungDA.GetKhuVucDashBoardUser(CurrentUser.ID))
                            {%>
                        <%--<div class="col-sm-<%=12/NguoiDungDA.GetKhuVucDashBoardUser(CurrentUser.ID).Count() %> col-md-<%=12/NguoiDungDA.GetKhuVucDashBoardUser(CurrentUser.ID).Count() %>">
                        <button class="Button-header" type="button" onclick="OpenList(<%=item.KhuVucID%>,2,this,<%=item.PhongBanID %>)" title="<%=item.TenPhongBan+"-"+ item.TenKhuVuc %>">
                            <%=item.TenKhuVuc.Length > 20 ? item.TenPhongBan+"-"+ item.TenKhuVuc.Substring(0, 5) :item.TenPhongBan+"-"+ item.TenKhuVuc %>
                            <br />
                            <%=CongViecDA.GetListGiamSatKhongPhanTrang(item.KhuVucID, item.PhongBanID) %>
                        </button>
                    </div>--%>
                        <div class="col-sm-12 col-md-12 col-lg-12 col-xl-12">
                            <button class="Button-header" type="button" onclick="OpenList(<%=item.KhuVucID%>,2,this,<%=item.PhongBanID %>)" title="<%=item.TenPhongBan+"-"+ item.TenKhuVuc %>">
                                <%=item.TenKhuVuc.Length > 20 ? item.TenPhongBan+"-"+ item.TenKhuVuc.Substring(0, 5) :item.TenPhongBan+"-"+ item.TenKhuVuc %>
                                <br />
                                <%=CongViecDA.CountGiamSatDashBoard_StoreProcedures(item.KhuVucID, item.PhongBanID) %>
                            </button>
                        </div>

                        <%} %>
                    </div>
                    <%} %>
                </div>
                <%}
                    else
                    {%>
                <div class="ktgs_slick">
                    <div class="col-sm-4 col-md-4">
                        <button class="Button-header" type="button">
                            AF<br />
                            <%=TotalCountKTGS%>
                        </button>
                    </div>
                    <%foreach (var item in LstDonvi.OrderBy(a => a.ThuTu))
                        {%>
                    <div class="col-sm-4 col-md-4">
                        <button class="Button-header" type="button" onclick="OpenList(<%=item.ID%>,2,this,-1)" title="<%=item.TenVietTat %>">
                            <%=item.TenVietTat.Length > 20 ? item.TenVietTat.Substring(0, 5) : item.TenVietTat %>
                            <br />
                            <%=CongViecDA.CountGiamSatDashBoard_StoreProcedures(item.ID) %>
                        </button>
                    </div>
                    <%} %>
                </div>
                <%} %>
            </div>
        </div>
        <!--Kiểm tra giám sát-->

        <!--Quản lý OPL/OJT/CS-->
        <div class="col-md-4 quanly-item ">
            <div class="card_header">
                <div class="card_header_title">Quản lý OPL/OJT/CS</div>
                <%if (nd.CheckUserCEO() == false && CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.XemDashboardToanKhuVuc))
                    {%>
                <div class="row">
                    <div class="qlobl_slick">
                        <%foreach (var item in LstDonvi.OrderBy(a => a.ThuTu))
                            {%>
                        <div class="col-sm-12 col-md-12 col-lg-12 col-xs-12">
                            <button class="Button-header" type="button" onclick="OpenList(<%=item.ID%>,3,this,-1)" title="<%=item.TenVietTat %>">
                                <%=item.TenVietTat.Length > 20 ? item.TenVietTat.Substring(0, 5) : item.TenVietTat %>
                                <br />
                                <%=HoSoTaiLieuDA.CountHoSoTaiLieuDashBoard_StoreProcedures(item.ID) %>
                            </button>
                        </div>
                        <%} %>
                    </div>
                </div>
                <%}
                    else if (nd.CheckUserCEO() == false && CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.XemDashBoard))
                    {%>
                <div class="row">
                    <%if (NguoiDungDA.GetKhuVucDashBoardUser(CurrentUser.ID).Count() == 0)
                        {%>
                    <div class="qlobl_slick">
                        <div class="col-sm-12 col-md-12 col-lg-12 col-xs-12">
                            <button class="Button-header" type="button" onclick="OpenList(<%=DonViItem.ID%>,3,this,-1)" title="<%=DonViItem.TenVietTat %>">
                                <%=DonViItem.TenVietTat.Length > 20 ? DonViItem.TenVietTat.Substring(0, 5) : DonViItem.TenVietTat %>
                                <br />
                                <%=HoSoTaiLieuDA.CountHoSoTaiLieuDashBoard_StoreProcedures(DonViItem.ID) %>
                            </button>
                        </div>
                    </div>
                    <%}
                        else
                        {%>
                    <div class="qlobl_slick">
                        <%foreach (var item in NguoiDungDA.GetKhuVucDashBoardUser(CurrentUser.ID))
                            {%>
                        <%--<div class="col-sm-<%=12/NguoiDungDA.GetKhuVucDashBoardUser(CurrentUser.ID).Count() %> col-md-<%=12/NguoiDungDA.GetKhuVucDashBoardUser(CurrentUser.ID).Count() %>">
                        <button class="Button-header" type="button" onclick="OpenList(<%=DonViItem.ID%>,3,this,-1)" title="<%=item.TenPhongBan+"-"+ item.TenKhuVuc %>">
                            <%=item.TenKhuVuc.Length > 20 ? item.TenPhongBan+"-"+ item.TenKhuVuc.Substring(0, 5) :item.TenPhongBan+"-"+ item.TenKhuVuc %>
                            <br />
                            <%=HoSoTaiLieuDA.GetSimpleKhongPhanTrang(item.KhuVucID,item.PhongBanID) %>
                        </button>
                    </div>--%>
                        <div class="col-sm-12 col-md-12 col-lg-12 col-xl-12">
                            <button class="Button-header" type="button" onclick="OpenList(<%=DonViItem.ID%>,3,this,<%=item.PhongBanID %>)" title="<%=item.TenPhongBan+"-"+ item.TenKhuVuc %>">
                                <%=item.TenKhuVuc.Length > 20 ? item.TenPhongBan+"-"+ item.TenKhuVuc.Substring(0, 5) :item.TenPhongBan+"-"+ item.TenKhuVuc %>
                                <br />
                                <%=HoSoTaiLieuDA.CountHoSoTaiLieuDashBoard_StoreProcedures(item.KhuVucID,item.PhongBanID) %>
                            </button>
                        </div>
                        <%} %>
                    </div>
                    <%} %>
                </div>
                <%}
                    else
                    {%>
                <div class="qlobl_slick">
                    <div class="col-sm-4 col-md-4">
                        <button class="Button-header" type="button">
                            AF<br />
                            <%=TotalCountQLTL%>
                        </button>
                    </div>
                    <%foreach (var item in LstDonvi.OrderBy(a => a.ThuTu))
                        {%>
                    <div class="col-sm-4 col-md-4">
                        <button class="Button-header" type="button" onclick="OpenList(<%=item.ID%>,3,this,-1)" title="<%=item.TenVietTat %>">
                            <%=item.TenVietTat.Length > 20 ? item.TenVietTat.Substring(0, 5) : item.TenVietTat %>
                            <br />
                            <%=HoSoTaiLieuDA.CountHoSoTaiLieuDashBoard_StoreProcedures(item.ID) %>
                        </button>
                    </div>
                    <%} %>
                </div>
                <%} %>
            </div>
        </div>
        <!--Quản lý OPL/OJT/CS-->

        <!--Hồ sơ tài liệu-->
        <div class="col-md-4 quanly-item ">
            <div class="card_header">
                <div class="card_header_title">Hồ sơ trình ký (Chờ duyệt)</div>
                <%if (nd.CheckUserCEO() == false && CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.XemDashboardToanKhuVuc))
                    {%>
                <div class="row">
                    <div class="hstk_slick">
                        <%foreach (var item in LstDonvi.OrderBy(a => a.ThuTu))
                            {%>
                        <div class="col-sm-12 col-md-12 col-lg-12 col-xs-12">
                            <button class="Button-header" type="button" onclick="OpenList(<%=item.ID%>,4,this,-1)" title="<%=item.TenVietTat %>">
                                <%=item.TenVietTat.Length > 20 ? item.TenVietTat.Substring(0, 5) : item.TenVietTat %>
                                <br />
                                <%=DuThaoVanBanDA.countHoSoTrinhKyDashBoard_StoreProcedures(item.ID) %>
                            </button>
                        </div>
                        <%} %>
                    </div>
                </div>
                <%}
                    else if (nd.CheckUserCEO() == false && CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.XemDashBoard))
                    {%>
                <div class="row">
                    <%if (NguoiDungDA.GetKhuVucDashBoardUser(CurrentUser.ID).Count() == 0)
                        {%>
                    <div class="hstk_slick">
                        <div class="col-sm-12 col-md-12 col-lg-12 col-xs-12">
                            <button class="Button-header" type="button" onclick="OpenList(<%=DonViItem.ID%>,4,this,-1)" title="<%=DonViItem.TenVietTat %>">
                                <%=DonViItem.TenVietTat.Length > 20 ? DonViItem.TenVietTat.Substring(0, 5) : DonViItem.TenVietTat %>
                                <br />
                                <%=DuThaoVanBanDA.countHoSoTrinhKyDashBoard_StoreProcedures(DonViItem.ID) %>
                            </button>
                        </div>
                    </div>
                    <%}
                        else
                        {%>
                    <div class="hstk_slick">
                        <%foreach (var item in NguoiDungDA.GetKhuVucDashBoardUser(CurrentUser.ID))
                            {%>
                        <%--<div class="col-sm-<%=12/NguoiDungDA.GetKhuVucDashBoardUser(CurrentUser.ID).Count() %> col-md-<%=12/NguoiDungDA.GetKhuVucDashBoardUser(CurrentUser.ID).Count() %>">
                        <button class="Button-header" type="button" onclick="OpenList(<%=item.KhuVucID%>,4,this,<%=item.PhongBanID %>)" title="<%=item.TenPhongBan+"-"+ item.TenKhuVuc %>">
                            <%=item.TenKhuVuc.Length > 20 ? item.TenPhongBan+"-"+ item.TenKhuVuc.Substring(0, 5) :item.TenPhongBan+"-"+ item.TenKhuVuc %>
                            <br />
                            <%=DuThaoVanBanDA.GetListVanBanDuThaoKhongPhanTrang_27092016(item.KhuVucID, item.PhongBanID) %>
                        </button>
                    </div>--%>
                        <div class="col-sm-12 col-md-12 col-lg-12 col-xl-12">
                            <button class="Button-header" type="button" onclick="OpenList(<%=item.KhuVucID%>,4,this,<%=item.PhongBanID %>)" title="<%=item.TenPhongBan+"-"+ item.TenKhuVuc %>">
                                <%=item.TenKhuVuc.Length > 20 ? item.TenPhongBan+"-"+ item.TenKhuVuc.Substring(0, 5) :item.TenPhongBan+"-"+ item.TenKhuVuc %>
                                <br />
                                <%=DuThaoVanBanDA.countHoSoTrinhKyDashBoard_StoreProcedures(item.KhuVucID, item.PhongBanID) %>
                            </button>
                        </div>
                        <%} %>
                    </div>
                    <%} %>
                </div>
                <%}
                    else
                    {%>
                <div class="hstk_slick">
                    <div class="col-sm-4 col-md-4">
                        <button class="Button-header" type="button">
                            AF<br />
                            <%=TotalCountHSTK%>
                        </button>
                    </div>
                    <%foreach (var item in LstDonvi.OrderBy(a => a.ThuTu))
                        {%>
                    <div class="col-sm-4 col-md-4">
                        <button class="Button-header" type="button" onclick="OpenList(<%=item.ID%>,4,this,-1)" title="<%=item.TenVietTat %>">
                            <%=DonViItem.TenVietTat.Length > 20 ? item.TenVietTat.Substring(0, 5) : item.TenVietTat %>
                            <br />
                            <%=DuThaoVanBanDA.countHoSoTrinhKyDashBoard_StoreProcedures(item.ID) %>
                        </button>
                    </div>
                    <%} %>
                </div>
                <%} %>
            </div>
        </div>
        <!--Hồ sơ tài liệu-->

        <!--Định biên nhân sư-->
        <div class="col-md-4 quanly-item">
            <div class="card_header">
                <div class="card_header_title">Định biên nhân sự (Số thực tế)</div>
                <%if (nd.CheckUserCEO() == false && CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.XemDashboardToanKhuVuc))
                    {%>
                <div class="row">
                    <div class="dbns_slick">
                        <%foreach (var item in LstDonvi.OrderBy(a => a.ThuTu))
                            {%>
                        <div class="col-sm-12 col-md-12 col-lg-12 col-xs-12">
                            <button class="Button-header" type="button" title="<%=item.TenVietTat %>">
                                <%=DonViItem.TenVietTat.Length > 10 ? item.TenVietTat.Substring(0, 5) : item.TenVietTat %>
                                <br />
                                <%=DinhBienNhanSuDA.CountSoThucTeKhuVuc(item.ID)%>
                            </button>
                        </div>
                        <%} %>
                    </div>
                </div>
                <%}
                    else if (nd.CheckUserCEO() == false && CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.XemDashBoard))
                    { %>
                <div class="row">

                    <%if (NguoiDungDA.GetKhuVucDashBoardUser(CurrentUser.ID).Count() == 0)
                        {%>
                    <div class="dbns_slick">
                        <div class="col-sm-12 col-md-12 col-lg-12 col-xs-12">
                            <button class="Button-header" type="button" title="<%=DonViItem.TenVietTat %>">
                                <%=DonViItem.TenVietTat.Length > 10 ? DonViItem.TenVietTat.Substring(0, 5) : DonViItem.TenVietTat %>
                                <br />
                                <%=DinhBienNhanSuDA.CountSoThucTeKhuVuc(DonViItem.ID)%>
                            </button>
                        </div>
                    </div>
                    <%}
                        else
                        {%>
                    <div class="dbns_slick">
                        <%foreach (var item in NguoiDungDA.GetKhuVucDashBoardUser(CurrentUser.ID))
                            {%>
                        <%--<div class="col-sm-<%=12/NguoiDungDA.GetKhuVucDashBoardUser(CurrentUser.ID).Count() %> col-md-<%=12/NguoiDungDA.GetKhuVucDashBoardUser(CurrentUser.ID).Count() %>" style="height: 50px; margin: 10px 0  0 0; padding: 0 !important">
                            <button class="Button-header" type="button" title="<%=item.TenPhongBan+"-"+ item.TenKhuVuc %>">
                                <%=item.TenKhuVuc.Length > 20 ? item.TenPhongBan+"-"+ item.TenKhuVuc.Substring(0, 5) :item.TenPhongBan+"-"+ item.TenKhuVuc %>
                                <br />
                                <%=DinhBienNhanSuDA.CountSoThucTeKhuVuc(item.KhuVucID, item.PhongBanID) %>
                            </button>
                        </div>--%>

                        <div class="col-sm-12 col-md-12 col-lg-12 col-xs-12">
                            <button class="Button-header" type="button" title="<%=item.TenPhongBan+"-"+ item.TenKhuVuc %>">
                                <%=item.TenKhuVuc.Length > 20 ? item.TenPhongBan+"-"+ item.TenKhuVuc.Substring(0, 5) :item.TenPhongBan+"-"+ item.TenKhuVuc %>
                                <br />
                                <%=DinhBienNhanSuDA.CountSoThucTeKhuVuc(item.KhuVucID, item.PhongBanID)%>
                                
                            </button>
                        </div>

                        <%} %>
                    </div>
                    <%} %>
                </div>
                <%}
                    else
                    {%>

                <div class="dbns_slick">
                    <div class="col-sm-4 col-md-4">
                        <button class="Button-header" type="button">
                            AF<br />
                            <%=TotalThucTe%>
                        </button>
                    </div>
                    <%foreach (var item in LstDonvi.OrderBy(a => a.ThuTu))
                        {%>
                    <div class="col-sm-4 col-md-4">
                        <button class="Button-header" type="button" title="<%=item.TenVietTat %>">
                            <%=DonViItem.TenVietTat.Length > 10 ? item.TenVietTat.Substring(0, 5) : item.TenVietTat %>
                            <br />
                            <%=DinhBienNhanSuDA.CountSoThucTeKhuVuc(item.ID)%>
                        </button>
                    </div>
                    <%} %>
                </div>
                <%} %>
            </div>
        </div>
        <!--Định biên nhân sự-->

        <%--Thống kê nghỉ phép--%>
        <div class="col-md-4 quanly-item ">
            <div class="card_header">
                <div class="card_header_title">Đang nghỉ phép</div>
                <%if (nd.CheckUserCEO() == false && CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.XemDashboardToanKhuVuc))
                    {%>
                <div class="row">
                    <div class="dnp_slick">
                        <%foreach (var item in LstDonvi.OrderBy(a => a.ThuTu))
                            {%>
                        <div class="col-sm-12 col-md-12 col-lg-12 col-xs-12">
                            <button class="Button-header" type="button" onclick="OpenList(<%=item.ID%>,6,this,-1)" title="<%=item.TenVietTat %>">
                                <%=DonViItem.TenVietTat.Length > 10 ? item.TenVietTat.Substring(0, 5) : item.TenVietTat %>
                                <br />
                                <%=DangKyNghiPhepDA.countThongKetNghiPhepDashBoard_StoreProcedures(item.ID)%>
                            </button>
                        </div>
                        <%} %>
                    </div>
                </div>
                <%}
                    else if (nd.CheckUserCEO() == false && CheckQuyen(CurrentUser.QuyenHan, (int)Viags.Utils.Enum.QuyenHan.XemDashBoard))
                    { %>
                <div class="row">
                    <%if (NguoiDungDA.GetKhuVucDashBoardUser(CurrentUser.ID).Count() == 0)
                        {%>
                    <div class="dnp_slick">
                        <div class="col-sm-12 col-md-12 col-lg-12 col-xs-12">
                            <button class="Button-header" type="button" onclick="OpenList(<%=DonViItem.ID%>,6,this,-1)" title="<%=DonViItem.TenVietTat %>">
                                <%=DonViItem.TenVietTat.Length > 10 ? DonViItem.TenVietTat.Substring(0, 5) : DonViItem.TenVietTat %>
                                <br />
                                <%=DangKyNghiPhepDA.countThongKetNghiPhepDashBoard_StoreProcedures(DonViItem.ID)%>
                            </button>
                        </div>
                    </div>
                    <%}
                        else
                        {%>
                    <div class="dnp_slick">
                        <%foreach (var item in NguoiDungDA.GetKhuVucDashBoardUser(CurrentUser.ID))
                            {%>
                        <%--<div class="col-sm-<%=12/NguoiDungDA.GetKhuVucDashBoardUser(CurrentUser.ID).Count() %> col-md-<%=12/NguoiDungDA.GetKhuVucDashBoardUser(CurrentUser.ID).Count() %>">
                        <button class="Button-header" type="button" onclick="OpenList(<%=item.KhuVucID%>,6,this,<%=item.PhongBanID %>)" title="<%=item.TenPhongBan+"-"+ item.TenKhuVuc %>">
                            <%=item.TenKhuVuc.Length > 20 ? item.TenPhongBan+"-"+ item.TenKhuVuc.Substring(0, 5) :item.TenPhongBan+"-"+ item.TenKhuVuc %>
                            <br />
                            <%=DangKyNghiPhepDA.ThongKeNghiPhep(item.KhuVucID,item.PhongBanID)%>
                        </button>
                    </div>--%>
                        <div class="col-sm-12 col-md-12 col-lg-12 col-xl-12">
                            <button class="Button-header" type="button" onclick="OpenList(<%=item.KhuVucID%>,6,this,<%=item.PhongBanID %>)" title="<%=item.TenPhongBan+"-"+ item.TenKhuVuc %>">
                                <%=item.TenKhuVuc.Length > 20 ? item.TenPhongBan+"-"+ item.TenKhuVuc.Substring(0, 5) :item.TenPhongBan+"-"+ item.TenKhuVuc %>
                                <br />
                                <%=DangKyNghiPhepDA.countThongKetNghiPhepDashBoard_StoreProcedures(item.KhuVucID,item.PhongBanID)%>
                            </button>
                        </div>
                        <%} %>
                    </div>
                    <%} %>
                </div>
                <%}
                    else
                    {%>

                <div class="dnp_slick">
                    <div class="col-sm-4 col-md-4">
                        <button class="Button-header" type="button">
                            AF<br />
                            <%=TotalNghiPhep%>
                        </button>
                    </div>
                    <%foreach (var item in LstDonvi.OrderBy(a => a.ThuTu))
                        {%>
                    <div class="col-sm-4 col-md-4">
                        <button class="Button-header" type="button" onclick="OpenList(<%=item.ID%>,6,this,-1)" title="<%=item.TenVietTat %>">
                            <%=DonViItem.TenVietTat.Length > 10 ? item.TenVietTat.Substring(0, 5) : item.TenVietTat %>
                            <br />
                            <%=DangKyNghiPhepDA.countThongKetNghiPhepDashBoard_StoreProcedures(item.ID)%>
                        </button>
                    </div>
                    <%} %>
                </div>
                <%} %>
            </div>
        </div>
        <%--Thống kê nghỉ phép--%>

    </div>
    <!-- LIST QUẢN LÍ-->

</div>


<%--BEGIN REGION: AjaxList--%>

<div class="action-bar" id="clickopensearch" hidden style="margin-top: 20px">
    <div class="box-search">
        <a id="opensearchCV" onclick="OpenSearchBox()" class="btn brown btn-fix-height"><i class="fa fa-search"></i>&nbsp;<%=Resources.TinTuc.lblTimKiem %></a>
    </div>
    <div class="clearfix"></div>
</div>

<div id="SearchView" hidden>
    <form id="TimKiemVanBan">
        <div class="content-border content-padding">
            <div class="row">
                <div class="col-md-12 col-sm-12">
                    <div class="form-horizontal">
                        <div id="timkiemnangcao">
                        </div>

                        <div class="clearfix"></div>
                        <div class="col-md-12 col-sm-12 text-center margin-top-10">
                            <a onclick="SearchCongViec()" id="btnSearch" class="btn brown"><i class="fa fa-search"></i>&nbsp;<%=Resources.CongViec.lblTimKiem %></a>
                            <button type="button" id="btnclosesearch" onclick="CloseSearchCV()" class="btn red">
                                <i class="fas fa-times"></i>&nbsp;<%=Resources.BieuMau.btnDong %></button>
                        </div>
                    </div>
                </div>
            </div>
            <%-- </from>--%>
        </div>
    </form>
</div>

<div id="gridview-container"></div>

<%--END REGION:AjaxList--%>

<%--BEGIN NHÂN VIÊN XUẤT SẮC--%>

<!-- Chart NVXS-->
<div class="row horizontal-space-around" style="padding: 5px !important; margin-top: 20px">

    <!-- NVXS Quý-->
    <div class="col-md-6 col-sm-6 portlet content-border content-padding" style="padding-top: 50px !important; padding-bottom: 5px !important">
        <!-- Title nhân viên xuất sắc quý-->
        <div class="portlet-title">
            <div class="caption test vertical-items-center">
                <!-- Title-->
                <div class="horizontal-left vertical-items-center" style="font-weight: 400">
                    <a id="TitleQuater">Nhân viên xuất sắc Quý <%=(dashBoardDA.GetQuy() - 1 == 0 ? 4 :  dashBoardDA.GetQuy() - 1) + "/" +(dashBoardDA.GetQuy() - 1 == 0 ? DateTime.Now.AddYears(-1).Year : DateTime.Now.Year) %> </a>
                </div>
                <!-- Arrow-->
                <div class="horizontal-right vertical-items-center">
                    <a onclick="PreviousQuater()" class="nvxs-arrow nvxs-arrow-left">
                        <i class="fa fa-arrow-circle-o-left"></i>
                    </a>

                    <a onclick="NextQuater()" class="nvxs-arrow nvxs-arrow-right">
                        <i class="fa fa-arrow-circle-o-right"></i>
                    </a>
                </div>
            </div>
        </div>
        <!-- Chart nhân viên xuất sắc quý-->
        <div class="portlet-body horizontal-center vertical-items-center">
            <div class="portlet-body_deletecss content-border_deletecss">
                <div id="chartNhanVien"></div>
            </div>
        </div>
    </div>

    <!-- NVXS Tháng-->
    <div class="col-md-6 col-sm-6 portlet content-border content-padding" style="padding-top: 50px !important; padding-bottom: 5px !important">
        <!-- Title nhân viên xuất sắc tháng-->
        <div class="portlet-title">
            <div class="caption test vertical-items-center">
                <!-- Title-->
                <div class="horizontal-left vertical-items-center" style="font-weight: 400">
                    <a id="TitleMonth">Nhân viên xuất sắc Tháng <%=DateTime.Now.AddMonths(-1).Month + "/" + DateTime.Now.AddMonths(-1).Year %></a>
                </div>
                <!-- Arrow-->
                <div class="horizontal-right vertical-items-center">
                    <a onclick="PreviousMonth()" class="nvxs-arrow nvxs-arrow-left">
                        <i class="fa fa-arrow-circle-o-left"></i>
                    </a>

                    <a onclick="NextMonth()" class="nvxs-arrow nvxs-arrow-right">
                        <i class="fa fa-arrow-circle-o-right"></i>
                    </a>
                </div>
            </div>
        </div>
        <!-- Chart nhân viên xuất sắc tháng-->
        <div class="portlet-body horizontal-center vertical-items-center">
            <div class="portlet-body_deletecss content-border_deletecss">
                <div id="chartNhanVienThang"></div>
            </div>
        </div>
    </div>

    <%--<div class="col-md-6 col-sm-6 portlet content-border content-padding">
                <div class="portlet-title">
                    <div class="caption">
                        Cải tiến tháng 3/2020
                    </div>
                </div>
                <div class="portlet-body">
                    <div class="portlet-body_deletecss  content-border_deletecss">
                        <div id="chartCaiTien"></div>

                    </div>
                </div>
            </div>--%>
</div>

<!-- Slider NVXS-->
<div class="row horizontal-center" style="margin: 10px !important">
    <div class="nhanvienxuatsac"></div>
</div>

<%--END NHÂN VIÊN XUẤT SẮC--%>

<!-- SCRIPT -->
<script type="text/javascript">
    getChartNhanVien();
    getChartNhanVienThang();
    //getChartCaiTien();
</script>

<!-- Slick -->
<script type="text/javascript">
    $(document).ready(function () {
        /*SLICK INIT*/
        /*Quản lí công việc*/
        $('.qlcv_slick').slick({
            slidesToShow: 3,
            slidesToScroll: 1,
            autoplay: false,
            autoplaySpeed: 0,
            speed: 100,
            infinite: false,
            dots: true,
            cssEase: 'linear',
            prevArrow: false,
            nextArrow: false,
            adaptiveHeight: true,
            responsive: [
                {
                    breakpoint: 1366,
                    settings: {
                        slidesToShow: 2,
                        slidesToScroll: 1,
                    }
                },
                {
                    breakpoint: 1280,
                    settings: {
                        slidesToShow: 2,
                        slidesToScroll: 1,
                    }
                },
                {
                    breakpoint: 1024,
                    settings: {
                        slidesToShow: 2,
                        slidesToScroll: 1,
                    }
                },
                {
                    breakpoint: 600,
                    settings: {
                        slidesToShow: 1,
                        slidesToScroll: 1
                    }
                },
            ]
        });
        /*Kiểm tra giám sát*/
        $('.ktgs_slick').slick({
            slidesToShow: 3,
            slidesToScroll: 1,
            autoplay: false,
            autoplaySpeed: 0,
            speed: 100,
            infinite: false,
            dots: true,
            cssEase: 'linear',
            prevArrow: false,
            nextArrow: false,
            adaptiveHeight: true,
            responsive: [
                {
                    breakpoint: 1366,
                    settings: {
                        slidesToShow: 2,
                        slidesToScroll: 1,
                    }
                },
                {
                    breakpoint: 1280,
                    settings: {
                        slidesToShow: 2,
                        slidesToScroll: 1,
                    }
                },
                {
                    breakpoint: 1024,
                    settings: {
                        slidesToShow: 2,
                        slidesToScroll: 1,
                    }
                },
                {
                    breakpoint: 600,
                    settings: {
                        slidesToShow: 1,
                        slidesToScroll: 1
                    }
                },
            ]
        });
        /*Quản lí OBL/OJT/CS*/
        $('.qlobl_slick').slick({
            slidesToShow: 3,
            slidesToScroll: 1,
            autoplay: false,
            autoplaySpeed: 0,
            speed: 100,
            infinite: false,
            dots: true,
            cssEase: 'linear',
            prevArrow: false,
            nextArrow: false,
            adaptiveHeight: true,
            responsive: [
                {
                    breakpoint: 1366,
                    settings: {
                        slidesToShow: 2,
                        slidesToScroll: 1,
                    }
                },
                {
                    breakpoint: 1280,
                    settings: {
                        slidesToShow: 2,
                        slidesToScroll: 1,
                    }
                },
                {
                    breakpoint: 1024,
                    settings: {
                        slidesToShow: 2,
                        slidesToScroll: 1,
                    }
                },
                {
                    breakpoint: 600,
                    settings: {
                        slidesToShow: 1,
                        slidesToScroll: 1
                    }
                },
            ]
        });
        /*Hồ sơ trình kí*/
        $('.hstk_slick').slick({
            slidesToShow: 3,
            slidesToScroll: 1,
            autoplay: false,
            autoplaySpeed: 0,
            speed: 100,
            infinite: false,
            dots: true,
            cssEase: 'linear',
            prevArrow: false,
            nextArrow: false,
            adaptiveHeight: true,
            responsive: [
                {
                    breakpoint: 1366,
                    settings: {
                        slidesToShow: 2,
                        slidesToScroll: 1,
                    }
                },
                {
                    breakpoint: 1280,
                    settings: {
                        slidesToShow: 2,
                        slidesToScroll: 1,
                    }
                },
                {
                    breakpoint: 1024,
                    settings: {
                        slidesToShow: 2,
                        slidesToScroll: 1,
                    }
                },
                {
                    breakpoint: 600,
                    settings: {
                        slidesToShow: 1,
                        slidesToScroll: 1
                    }
                },
            ]
        });
        /*Định biên nhân sự*/
        $('.dbns_slick').slick({
            slidesToShow: 3,
            slidesToScroll: 1,
            autoplay: false,
            autoplaySpeed: 0,
            speed: 100,
            infinite: false,
            dots: true,
            cssEase: 'linear',
            prevArrow: false,
            nextArrow: false,
            adaptiveHeight: true,
            responsive: [
                {
                    breakpoint: 1366,
                    settings: {
                        slidesToShow: 2,
                        slidesToScroll: 1,
                    }
                },
                {
                    breakpoint: 1280,
                    settings: {
                        slidesToShow: 2,
                        slidesToScroll: 1,
                    }
                },
                {
                    breakpoint: 1024,
                    settings: {
                        slidesToShow: 2,
                        slidesToScroll: 1,
                    }
                },
                {
                    breakpoint: 600,
                    settings: {
                        slidesToShow: 1,
                        slidesToScroll: 1
                    }
                },
            ]
        });
        /*Đang nghỉ phép*/
        $('.dnp_slick').slick({
            slidesToShow: 3,
            slidesToScroll: 1,
            autoplay: false,
            autoplaySpeed: 0,
            speed: 100,
            infinite: false,
            dots: true,
            cssEase: 'linear',
            prevArrow: false,
            nextArrow: false,
            adaptiveHeight: true,
            responsive: [
                {
                    breakpoint: 1366,
                    settings: {
                        slidesToShow: 2,
                        slidesToScroll: 1,
                    }
                },
                {
                    breakpoint: 1280,
                    settings: {
                        slidesToShow: 2,
                        slidesToScroll: 1,
                    }
                },
                {
                    breakpoint: 1024,
                    settings: {
                        slidesToShow: 2,
                        slidesToScroll: 1,
                    }
                },
                {
                    breakpoint: 600,
                    settings: {
                        slidesToShow: 1,
                        slidesToScroll: 1
                    }
                },
            ]
        });

        /*MOUSEWHEEL ON SLICK*/

        /*Quản lí công việc*/
        $('.qlcv_slick').on('wheel', (function (e) {
            e.preventDefault();
            scroll = setTimeout(function () { scrollCount = 0; }, 0);
            if (scrollCount) return 0;
            scrollCount = 1;
            if (e.originalEvent.deltaY < 0) {
                $(this).slick('slickPrev');
            }
            else {
                $(this).slick('slickNext');
            }
        }));
        /*Kiểm tra giám sát*/
        $('.ktgs_slick').on('wheel', (function (e) {
            e.preventDefault();
            scroll = setTimeout(function () { scrollCount = 0; }, 0);
            if (scrollCount) return 0;
            scrollCount = 1;
            if (e.originalEvent.deltaY < 0) {
                $(this).slick('slickPrev');
            }
            else {
                $(this).slick('slickNext');
            }
        }));
        /*Quản lí OBL/OJT/CS*/
        $('.qlobl_slick').on('wheel', (function (e) {
            e.preventDefault();
            scroll = setTimeout(function () { scrollCount = 0; }, 0);
            if (scrollCount) return 0;
            scrollCount = 1;
            if (e.originalEvent.deltaY < 0) {
                $(this).slick('slickPrev');
            }
            else {
                $(this).slick('slickNext');
            }
        }));
        /*Hồ sơ trình kí*/
        $('.hstk_slick').on('wheel', (function (e) {
            e.preventDefault();
            scroll = setTimeout(function () { scrollCount = 0; }, 0);
            if (scrollCount) return 0;
            scrollCount = 1;
            if (e.originalEvent.deltaY < 0) {
                $(this).slick('slickPrev');
            }
            else {
                $(this).slick('slickNext');
            }
        }));
        /*Định biên nhân sự*/
        $('.dbns_slick').on('wheel', (function (e) {
            e.preventDefault();
            scroll = setTimeout(function () { scrollCount = 0; }, 0);
            if (scrollCount) return 0;
            scrollCount = 1;
            if (e.originalEvent.deltaY < 0) {
                $(this).slick('slickPrev');
            }
            else {
                $(this).slick('slickNext');
            }
        }));
        /*Đang nghỉ phép*/
        $('.dnp_slick').on('wheel', (function (e) {
            e.preventDefault();
            scroll = setTimeout(function () { scrollCount = 0; }, 0);
            if (scrollCount) return 0;
            scrollCount = 1;
            if (e.originalEvent.deltaY < 0) {
                $(this).slick('slickPrev');
            }
            else {
                $(this).slick('slickNext');
            }
        }));
    });
</script>
