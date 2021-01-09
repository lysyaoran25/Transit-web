<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucChamCong.ascx.cs" Inherits="Viags.WebApp.Hiface.ChamCong.ucChamCong" %>

<link rel="stylesheet" type="text/css" crossorigin="anonymous" href="https://cdnjs.cloudflare.com/ajax/libs/spectrum/1.8.0/spectrum.min.css" />

<script src="https://cdnjs.cloudflare.com/ajax/libs/moment.js/2.24.0/moment-with-locales.min.js"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/fullcalendar/3.10.0/fullcalendar.js"></script>
<%--<script src="\Publishing_Resources\plugin\fullcalendarCustom.js"></script>--%>
<script src="https://cdnjs.cloudflare.com/ajax/libs/fullcalendar/3.10.0/locale-all.js"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/spectrum/1.8.0/spectrum.min.js"></script>
<script type="text/javascript">
    $(document).ready(function () {

    });
    function replacehtml(template, data) {
        const pattern = /\{(.*?)\}/g; // {property}
        return template.replace(pattern, (match, token) => data[token]);
    }
</script>
<style>
    /* css cho calenar*/
    .card-calendar {
        font-size: 14px;
        /*font-family: Roboto;*/
        line-height: 24px;
        position: relative;
    }

    fc-view-container {
        border: 1px solid #ffbb3b;
        border-top: 0;
    }

    .fc-toolbar h2 {
        text-transform: capitalize;
    }

    .fc-unthemed .fc-content, .fc-unthemed .fc-divider, .fc-unthemed .fc-list-heading td, .fc-unthemed .fc-list-view, .fc-unthemed .fc-popover, .fc-unthemed .fc-row, .fc-unthemed tbody, .fc-unthemed td, .fc-unthemed th, .fc-unthemed thead {
        border-color: #ffbb3b;
    }

    .fc-basic-view .fc-day-number, .fc-basic-view .fc-week-number {
        font-size: 16px;
        float: left !important;
    }

    .card-calendar .fc th {
        text-align: left;
        color: #333;
        line-height: 42px;
    }

    .fc-today .fc-day-number {
        width: 22px;
        height: 22px;
        text-align: center;
        background: #135de6;
        border-radius: 50% !important;
        color: #fff;
        font-weight: bold;
        margin: 2px 2px 0 2px;
    }

    .fc-sat:not(.fc-widget-header), .fc-sun:not(.fc-widget-header) {
        background-color: #fafafa;
    }

    .fc-sat > span {
        color: #3162ea;
    }

    .fc-sun > span {
        color: #ff4040;
    }

    .fc-content .fc-time {
        display: none;
    }

    .fc-right {
        display: none;
    }
</style>

<div class="row">
    <div class="col-md-12 col-sm-12 ">
        <ol class="breadcrumb ">
            <li><a href="/Pagess/Home.aspx"><%=Resources.TaiKhoan.lblTrangChu %></a></li>
            <li><a href="javascript:;"><%=Resources.TaiKhoan.lblHeThong %></a></li>
            <li><a href="/Pagess/nguoi-dung.aspx"><%=Resources.TaiKhoan.lblNguoiDung %></a></li>
        </ol>
    </div>
</div>
<div class="row">
    <div class="col-md-12 col-sm-12 padding0">
        <div class="col-md-12 col-sm-12">
            <div class="portlet content-padding">
                <div class="portlet-title">
                    <div class="caption">
                        Chấm công
                    </div>
                </div>



                <ul class="nav nav-tabs">
                    <li class="active"><a data-toggle="tab" href="#home">Style hiface</a></li>
                    <li><a data-toggle="tab" href="#menu1">Coming soon</a></li>
                </ul>

                <div class="tab-content">
                    <div id="home" class="tab-pane fade in active">
                        <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.10.20/css/jquery.dataTables.css">

                        <%--                <input class="col-md-12" type="text" id="txt_QuyTac" value="dassdsa" />
                <input class="col-md-12" type="number" id="txt_Luong" value="11000000" />--%>


                        <div class="col-md-12 col-sm-12">
                            <div class="form-horizontal">
                                <div class="col-md-6 col-sm-6">
                                    <div class="form-group margin-bottom-0">
                                        <label class="col-sm-4 control-label">
                                            Phạm vi
                                        </label>
                                        <div class="col-sm-8">
                                            <select id="select_year" class="col-md-3 form-group form-control" onchange="click_Attendance()">
                                                <%
                                                    for (int i = 15; i < 30; i++)
                                                    {
                                                %>
                                                <option value="20<%=i %>" <%= i ==20 ? "selected":"" %>>20<%=i %></option>
                                                <%
                                                    }
                                                %>
                                            </select>
                                            <select id="select_month" class="col-md-2 form-group form-control" onchange="click_Attendance()">
                                                <%
                                                    for (int i = 1; i <= 12; i++)
                                                    {
                                                %>
                                                <option value="<%=i %>" <%= i == DateTime.Now.Month ? "selected":"" %>><%=i %></option>
                                                <%
                                                    }
                                                %>
                                            </select>
                                        </div>
                                    </div>
                                </div>

                                <div class="clearfix"></div>
                            </div>
                        </div>
                        <div class="col-md-12 col-sm-12">
                            <table id="tbl_Attendance" class="display" style="width: 100%">
                                <thead>
                                    <tr>
                                        <th>Name</th>
                                        <th>Đúng giờ </th>
                                        <th>Vào trễ </th>
                                        <th>Về sớm</th>
                                        <th>Không có dử liệu vào/ra</th>
                                        <th>Vắng mặt</th>
                                        <th>Detail</th>
                                    </tr>
                                </thead>
                            </table>

                            
                        </div>
                    </div>
                    <div id="menu1" class="tab-pane fade">
                        <h3>Coming soon</h3>
                        <img src="../../Image/coming soon 1.png"/>

                       <table id="tbl_Attendancess" class="table table-striped table-bordered table-sm" hidden cellspacing="0"
                                width="100%">
                                <thead>
                                    <tr>
                                        <th>Tên</th>
                                        <%
                                            int days = DateTime.DaysInMonth(2020, 03);
                                            for (int day = 1; day <= days; day++)
                                            {
                                        %>


                                        <th><%= new DateTime(2020, 03, day).ToString("dd")%></th>



                                        <% } %>
                                    </tr>
                                </thead>

                            </table>
                    </div>
                </div>



            </div>
        </div>
    </div>
</div>

<div id="GSCCModal" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
    <div class="modal-dialog modal-lg">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;  </button>
                <h4 class="modal-title" id="myModalLabel">Modal title</h4>
            </div>
            <div class="modal-body">
                <input type="hidden" id="id_user" />
                <div class="col-md-12 col-sm-12">
                    <div class="col-md-6 col-sm-6">
                        <div class="form-group">
                            <label class="col-sm-4 control-label">
                                Xem theo
                            </label>
                            <div class="col-sm-8">
                                <select id="viewtype" class="form-control" onchange="click_Attendance_detail2()">
                                    <option value="0">Công làm việc</option>
                                    <option value="1">Trạng thái Đi làm/Vắng</option>
                                    <option value="2">Trạng thái Đi trễ/Về sớm</option>
                                    <option value="3">Đầy đủ</option>
                                </select>
                            </div>
                        </div>
                    </div>

                </div>

                <div id="calendar"></div>
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                <button type="button" class="btn btn-primary">Save changes</button>
            </div>
        </div>
    </div>
</div>



<script type="text/javascript" src="https://cdn.datatables.net/1.10.20/js/jquery.dataTables.min.js"></script>


<script type="text/javascript">
    $(document).ready(function () {
        click_Attendance();
        click_Attendance_sontt();
    });


    function FormatDateTime(input) {
        if (input === null) {
            return "";
        }
        var date = new Date(input * 1000);
        return date.format('dd-MM-yyyy hh:mm');
    }
    function click_Attendance_sontt() {
        var select_year = $("#select_year").val();
        var select_month = $("#select_month").val();
        var link_Attendance = "/hiface/chamcong/AjaxList.aspx/AttendanceList";//'http://hiface.tinhvan.com/attendance/stats?size=99999999&date=' + select_year + select_month;
        var dataValue = "{timefilter: " + select_year + select_month + "}";
        $.ajax({
            url: "/hiface/chamcong/AjaxList.aspx/AttendanceList",
            type: "POST",
            data: dataValue,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                var cc = data.d;
                var o = JSON.stringify(cc.data);//A la variable le asigno el json decodificado
                console.log(o);
                $('#tbl_Attendancess').dataTable({
                    destroy: false,
                    data: JSON.parse(o),
                    pageLength: 10,
                    columns: [
                        { "data": "name" },

                         <%
    int days2 = DateTime.DaysInMonth(2020, 03);
    for (int day = 1; day <= days2; day++)
    {
                            %>


                        { "data": "attendance.normal" },



                            <% } %>





                    ]
                });

            }
        });
    }
    function click_Attendance() {
        var select_year = $("#select_year").val();
        var select_month = $("#select_month").val();
        var link_Attendance = 'http://hiface.tinhvan.com/attendance/stats?size=99999999&date=' + select_year + select_month;
        $.ajax({
            url: link_Attendance,
            type: 'GET',
            // Fetch the stored token from localStorage and set in the header
            headers: { "Authorization": 'b990b346-e791-41d5-9e07-590764708819' },
            success: function (data) {
                var o = JSON.stringify(data.data);//A la variable le asigno el json decodificado
                $('#tbl_Attendance').dataTable({
                    destroy: true,
                    data: JSON.parse(o),
                    pageLength: 10,
                    columns: [
                        { "data": "name" },
                        { "data": "attendance.normal" },
                        { "data": "attendance.late" },
                        { "data": "attendance.leave_early" },
                        { "data": "attendance.unchecked" },
                        { "data": "attendance.absenteeism" },
                        {
                            "mData": "id",
                            "mRender": function (data, type, row) {
                                return '<div class="span4 proj-div" data-toggle="modal" data-target="#GSCCModal"  onclick="click_Attendance_detail(' + data + ')" >Click ME</div>';
                                // return '<a  onclick="click_Attendance_detail(' + data + ')" >Click ME</a>';
                            }
                        }
                    ]
                });
            }
        });
    }
    function click_Attendance_detail(id) {
        $("#id_user").val(id);
        var select_year = $("#select_year").val();
        var select_month = $("#select_month").val();
        $.ajax({
            url: 'http://hiface.tinhvan.com/attendance/records/monthly?date=' + select_year + select_month + '&subject_id=' + id,
            type: 'GET',
            // Fetch the stored token from localStorage and set in the header
            headers: { "Authorization": 'b990b346-e791-41d5-9e07-590764708819' },
            success: function (data) {
                var o = JSON.stringify(data.data.records);
                GenerateCalendar(o);
            }
        });
    }
    function click_Attendance_detail2() {
        var iduser = $("#id_user").val();
        var select_year = $("#select_year").val();
        var select_month = $("#select_month").val();
        $.ajax({
            url: 'http://hiface.tinhvan.com/attendance/records/monthly?date=' + select_year + select_month + '&subject_id=' + iduser,
            type: 'GET',
            // Fetch the stored token from localStorage and set in the header
            headers: { "Authorization": 'b990b346-e791-41d5-9e07-590764708819' },
            success: function (data) {
                var o = JSON.stringify(data.data.records);
                GenerateCalendar(o);
            }
        });
    }

    function LastDayOfMonth(Year, Month) {
        return new Date((new Date(Year, Month, 1)) - 1);
    }
    function luong(check_in_time, check_out_time, salary) {
        var r = "làm ok";
        if (check_in_time === null || check_out_time === null) {
            r = "quyên check vân tay";
        }
        if (check_out_time === null || check_in_time === null) {
            r = "vắng";
        }
        return r;
    }

    function GenerateCalendar(json) {
        var events = [];

        json = JSON.parse(json, (k, v) => Array.isArray(v) ? v.filter(e => e !== null) : v);
        //json = JSON.parse(JSON.stringify(json).split('"check_in_time":').join('"start":'));
        //json = JSON.parse(JSON.stringify(json).split('"check_out_time":').join('"end":'));
        json = JSON.stringify(json);
        var viewtype = $("#viewtype").val();
        var dataValue = "{ datajson: '" + json + "', viewtype: " + viewtype + "}";

        $.ajax({
            url: "/hiface/chamcong/AjaxList.aspx/GenerateCalendar",
            type: "POST",
            data: dataValue,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                //console.log(data.d);
                events = data.d;

                GenerateCalendar2(events);

            }
        });

    }



    function GenerateCalendar2(events) {

        var select_year = $("#select_year").val();
        var select_month = $("#select_month").val();
        //$('#calendar').empty();
        $('#calendar').fullCalendar('destroy');
        $('#calendar').fullCalendar({
            defaultDate: moment(select_year + '-' + select_month + '-01'),
            locale: 'vi',
            firstDay: 1,
            //header: {
            //    left: "month,agendaWeek,agendaDay",
            //    center: 'title',
            //    right: 'prev,next,today',
            //},
            dayNames: ['Chủ nhật', 'Thứ 2', 'Thứ 3', 'Thứ 4', 'Thứ 5', 'Thứ 6', 'Thứ 7'],
            dayNamesShort: ['Chủ nhật', 'Thứ 2', 'Thứ 3', 'Thứ 4', 'Thứ 5', 'Thứ 6', 'Thứ 7'],
            viewRender: function (view, element) {
                var moment = $('#calendar').fullCalendar('getDate');
                var nguoiDungSelect = $('#NguoiDung').select2("val");
                if (nguoiDungSelect != '' && nguoiDungSelect != undefined && nguoiDungSelect != null) {
                    window.location.href = "#Thang=" + moment.format("MM") + "&Nam=" + moment.format("YYYY") + "&nguoiDungSelect=" + nguoiDungSelect;
                } else {
                    window.location.href = "#Thang=" + moment.format("MM") + "&Nam=" + moment.format("YYYY");
                }
            },
            //nextDayThreshold: '00:00:00',
            //eventClick: function (event, jsEvent, view) {
            //    $('body').modalmanager('loading');
            //    var nguoiDungSelect = $('#NguoiDung').select2("val");
            //    $('#dialog-form').load(urlForm + "?do=edit&ItemID=" + event.id + '&ListNguoiDung=' + nguoiDungSelect,
            //        function () {
            //            $('#dialog-form').modal({ width: 650 });
            //        });
            //},
            selectable: true,
            //dayClick: function (date, jsEvent, view) {
            //    var nguoiDungSelect = $('#NguoiDung').select2("val");
            //    if (nguoiDungSelect != '' && nguoiDungSelect != undefined && nguoiDungSelect != null) {
            //        createMessage('Thông báo', 'Anh/Chị quay lại lịch của mình để đặt sự kiện');
            //        return;
            //    }
            //    if (moment(date).isSameOrAfter(new Date, 'day')) {
            //        //$('body').modalmanager('loading');
            //        //var new_date = moment(date).add(1, 'd');

            //        //urlFormNew = urlForm +
            //        //    '?ThoiGianBatDau=' + date.valueOf() +
            //        //    '&ThoiGianKetThuc=' + (new_date.valueOf() - 1);
            //        //$('#dialog-form').load(urlFormNew, function () {
            //        //    $('#dialog-form').modal();
            //        //});
            //        var new_date = moment(date).add(1, 'd');
            //        window.location.href = "/Pagess/form-ho-so-cong-viec.aspx" +
            //            '?ThoiGianBatDau=' + date.valueOf() +
            //            '&ThoiGianKetThuc=' + (new_date.valueOf() - 1);
            //    } else {
            //        createMessage('Thông báo', 'Ngày đặt sự kiện phải sau ngày hiện tại');
            //    }

            //},
            //select: function (start, end, allDay) {
            //    var nguoiDungSelect = $('#NguoiDung').select2("val");
            //    if (nguoiDungSelect != '' && nguoiDungSelect != undefined && nguoiDungSelect != null) {
            //        createMessage('Thông báo', 'Anh/Chị quay lại lịch của mình để đặt sự kiện');
            //        return;
            //    }
            //    if (moment(start).isSameOrAfter(new Date, 'day')) {
            //        //$('body').modalmanager('loading');
            //        //urlFormNew = urlForm +
            //        //    '?ThoiGianBatDau=' + start.valueOf() +
            //        //    '&ThoiGianKetThuc=' + (end.valueOf() - 1);
            //        //$('#dialog-form').load(urlFormNew, function () {
            //        //    $('#dialog-form').modal();
            //        //});
            //        window.location.href = "/Pagess/form-ho-so-cong-viec.aspx" +
            //            '?ThoiGianBatDau=' + start.valueOf() +
            //            '&ThoiGianKetThuc=' + (end.valueOf() - 1);
            //    } else {
            //        createMessage('Thông báo', 'Ngày đặt sự kiện phải sau ngày hiện tại');
            //    }

            //},
            editable: false,
            contentHeight: 700,
            events: $.map(events, function (item, i) {
                //-- here is the event details to show in calendar view.. the data is retrieved via ajax call will be accessed here
                var event = new Object();
                event.id = item.EventId;
                event.start = item.EventStartDate;
                event.end = item.EventEndDate;
                event.timeIn = item.TimeIn;
                event.timeOut = item.TimeOut;
                event.color = item.color;
                event.title = item.Title;
                event.allDay = item.AllDayEvent;
                event.TypeCong = item.TypeCong;
                return event;
            }),
            eventRender: function (event, element) {
                element.qtip({
                    content: {
                        title: { text: replacehtml(`<div class="qtip-title-trung" style="background-color:{color};color:#000">{title}</div>`, event) },
                        text: replacehtml(`<div>

<ul class="nav nav-tabs" style="zoom: 75%;">
  <li class="active"><a data-toggle="tab" href="#home{id}">Tỗng hợp</a></li>
  <li><a data-toggle="tab" href="#menu1{id}">Đơn xin</a></li>
  <li><a data-toggle="tab" href="#menu2{id}">Chốt vân tay</a></li>
  <li><a data-toggle="tab" href="#menu3{id}">Phạt</a></li>
</ul>

<div class="tab-content">
  <div id="home{id}" class="tab-pane fade in active">
                    <div class="d-flex">
                          <div class="flex-grow-3">
                            <label>Chốt vân tay:</label>
                        </div>
                        <div class="flex-grow-3">
                            <p>{timeIn} - {timeOut}</p>
                        </div>
                    </div>
                    <div class="d-flex">
                        <div class="flex-grow-3">
                            <label>Công làm việc trong ngày:</label>
                        </div>
                        <div class="flex-grow-3">
                            <p>{TypeCong}</p>
                        </div>
                    </div>
                    <div class="d-flex">
                         <div class="flex-grow-3">
                            <label>Công ăn trong ngày:</label>
                        </div>
                        <div class="flex-grow-3">
                            <p>pending</p>
                        </div>
                    </div>
                    <div class="d-flex">
                          <div class="flex-grow-3">
                            <label>Thời gian làm:</label>
                        </div>
                        <div class="flex-grow-3">
                            <p>pending</p>
                        </div>
                    </div>
                    <div class="d-flex">
                          <div class="flex-grow-3">
                            <label>Thời gian nghỉ:</label>
                        </div>
                        <div class="flex-grow-3">
                            <p>pending</p>
                        </div>
                    </div>
                     
                     <div class="d-flex">
                          <div class="flex-grow-3">
                            <label>Số giờ làm:</label>
                        </div>
                        <div class="flex-grow-3">
                            <p>pending</p>
                        </div>
                    </div>


  </div>
  <div id="menu1{id}" class="tab-pane fade">
    <h3>pending</h3>
  </div>
  <div id="menu2{id}" class="tab-pane fade">
                     <div class="d-flex">
                          <div class="flex-grow-3">
                            <label>Chốt vân tay:</label>
                        </div>
                        <div class="flex-grow-3">
                            <p>{timeIn} - {timeOut}</p>
                        </div>
                    </div>
                    <div class="d-flex">
                          <div class="flex-grow-3">
                            <label>Đi trể:</label>
                        </div>
                        <div class="flex-grow-3">
                            <p>pending</p>
                        </div>
                    </div>
  </div>
  <div id="menu3{id}" class="tab-pane fade">
    <h3>pending</h3>
  </div>
</div>



    
</div>`, event)
                    },
                    position: {
                        my: 'top center',
                        at: 'bottom center',
                        effect: false,
                        viewport: jQuery(window) // Keep the tooltip on-screen at all times
                        //	effect: false // Disable positioning animation
                    },
                    show: {
                        solo: true,
                        effect: { type: 'slide' },
                        effect: function () {
                            $(this).fadeTo(200, 1);
                        }
                    },
                    hide: { when: 'mouseout', fixed: true },
                    style: {
                        tip: true, // Give it a speech bubble tip
                        border: {
                            width: 2,
                            radius: 5,
                            color: '#474968'
                        },
                        title: {
                            color: '#fff',
                            background: '#9193c4'
                        },
                    }
                });
            },

        });
    }



</script>
<style>
    /*---------trung loading bar---------*/
    .load-bar {
        position: absolute;
        width: 100%;
        height: 6px;
        background-color: #fdba2c;
        top: 74px;
        left: 0;
        right: 0;
    }

    .bar {
        content: "";
        display: inline;
        position: absolute;
        width: 0;
        height: 100%;
        left: 50%;
        text-align: center;
    }

        .bar:nth-child(1) {
            background-color: #da4733;
            animation: loading 3s linear infinite;
        }

        .bar:nth-child(2) {
            background-color: #3b78e7;
            animation: loading 3s linear 1s infinite;
        }

        .bar:nth-child(3) {
            background-color: #fdba2c;
            animation: loading 3s linear 2s infinite;
        }

    @keyframes loading {
        from {
            left: 50%;
            width: 0;
            z-index: 100;
        }

        33.3333% {
            left: 0;
            width: 100%;
            z-index: 10;
        }

        to {
            left: 0;
            width: 100%;
        }
    }

    .fc-title {
        color: #000;
        font-size: 1.05em;
    }

    a.fc-day-grid-event.fc-h-event.fc-event.fc-start.fc-end {
        text-align: center;
    }

    /*.fc-month-view span.fc-title{
         white-space: normal;
   }*/

    .fc-day-grid-event .fc-content {
        white-space: normal;
    }
</style>
<script>
    /* ------- script cua trung: ajax setup -------- */
    $.ajaxSetup({
        beforeSend: function (xhr) {
            $('.bar:nth-child(1)').show();
            $('.bar:nth-child(3)').show();
            $('.bar:nth-child(2)').removeAttr('style');
        },
        complete: function (res) {
            $('.bar:nth-child(1)').hide();
            $('.bar:nth-child(3)').hide();
            $('.bar:nth-child(2)').css({
                'width': '100%',
                'left': '0',
                'animation': 'none'
            });
        },
        error: function (data) {
            createMessage("Thông báo", JSON.stringify(data));
        }
    });
</script>
<style>
    /* css cho calenar*/
    .card-calendar {
        font-size: 14px;
        /*font-family: Roboto;*/
        line-height: 24px;
        position: relative;
    }

    fc-view-container {
        border: 1px solid #ffbb3b;
        border-top: 0;
    }

    .fc-toolbar h2 {
        text-transform: capitalize;
    }

    .fc-unthemed .fc-content, .fc-unthemed .fc-divider, .fc-unthemed .fc-list-heading td, .fc-unthemed .fc-list-view, .fc-unthemed .fc-popover, .fc-unthemed .fc-row, .fc-unthemed tbody, .fc-unthemed td, .fc-unthemed th, .fc-unthemed thead {
        border-color: #ffbb3b;
    }

    .fc-basic-view .fc-day-number, .fc-basic-view .fc-week-number {
        font-size: 16px;
        float: left !important;
    }

    .card-calendar .fc th {
        text-align: left;
        color: #333;
        line-height: 42px;
    }

    .fc-today .fc-day-number {
        width: 22px;
        height: 22px;
        text-align: center;
        background: #135de6;
        border-radius: 50% !important;
        color: #fff;
        font-weight: bold;
        margin: 2px 2px 0 2px;
    }

    .fc-sat:not(.fc-widget-header), .fc-sun:not(.fc-widget-header) {
        background-color: #fafafa;
    }

    .fc-sat > span {
        color: #3162ea;
    }

    .fc-sun > span {
        color: #ff4040;
    }

    .fc-content .fc-time {
        display: none;
    }
</style>

<style>
    /* css cho popup detail events*/
    .qtip {
        position: absolute;
        left: -28000px;
        top: -28000px;
        display: none;
        max-width: 400px;
        min-width: 340px;
        font-size: 10.5px;
        line-height: 12px;
        box-shadow: none;
        padding: 0;
    }

    .qtip-default .qtip-titlebar {
        background-color: #ff9800;
        color: #fff;
        font-size: 14px;
    }

    .qtip label {
        position: unset;
        font-size: 12px;
    }

    .qtip-default {
        background-color: #FFF !important;
        color: #555;
    }

    .qtip-titlebar {
        padding: 0 !important;
    }

    .qtip-title-trung {
        padding: 5px 35px 5px 10px;
    }

    .flex-grow-1 {
        flex: 1;
    }

    .flex-grow-2 {
        flex: 2;
    }

    .flex-grow-3 {
        flex: 3;
    }
</style>
