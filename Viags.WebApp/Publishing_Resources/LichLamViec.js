var $ddlYear;
var urlListTuan = '/LichLamViec/AjaxList.aspx';
var $ddlWeek = $('#ddlWeek');
var templateLich = '<td style=\"background-color:{{thaydoi}}\">' +
                               '<p class=\"week\">{{Day}}</p>' +
                               '<p class=\"day day{{stt}}\">{{StringDay}}</p>' +
                           '</td>';
var templateLichLanhDao = '<td style=\"background-color:{{thaydoi}}\">' +
                            '<p class=\"week\">{{Day}}</p>' +
                            '<p class=\"day\">{{StringDay}}</p>' +
                        '</td>';

var $nextWeek = $('#btnNext');
var $prevWeek = $("#btnBack");
var $weekRange = $('#lbDayWeek');
$(document).ready(function () {
    //$('#btnNext').die();
    $ddlYear = $('#ddlYear');
    $ddlYear.change(function (e) {
        BindYears(new Number(this.value));
        BindWeeks(new Number(this.value));
    });
});
//Bind Năm
function BindYears(curYear) {
    CurYearChange = curYear;
    if ($ddlYear[0].selectedIndex == 0 || $ddlYear[0].selectedIndex == $ddlYear.find('option').length - 1 || curYear == CurYear) {
        $ddlYear.empty();
        var startYear = curYear >= 10 ? curYear - 10 : 0;
        var endYear = curYear + 10;
        if (startYear == 0) curYear = 0;
        for (var i = startYear; i <= endYear; i++) {
            $ddlYear.append(new Option(i, i, false, i == curYear));
        }
    }
}
function upDateWeekRange() {
    $weekRange.text('Tuần ' + $ddlWeek.val() + ' từ ' + $('#calendar-week').find('#startDate').text() + ' đến ' + $('#calendar-week').find('#endDate').text() + '');
}

//Bin Tuần
function BindWeeks(curYear) {
    $ddlWeek.empty();
    $.ajax({
        async: false,
        cache: false,
        type: 'GET',
        url: '/API/CalendarService.asmx/GetWeeksOfYear',
        contentType: 'application/json; charset=UTF-8',
        data: { year: curYear },
        dataType: 'json',
        success: function (data) {
            MaxWeek = data.d.length;
            $.each(data.d, function (i, x) {
                $("#ddlWeek").append(new Option(x.Range, x.Id, false, x.IsCurrent));
            });
            $("#ddlWeek").select2("data", { id: data.d[0].Id, text: data.d[0].Range });
        }
    });
}

function dayNumberOfWeekToString(dayNumber) {
    var day = '';
    switch (dayNumber) {
        case 0:
            day = "Chủ nhật";
            break;
        case 1:
            day = "Thứ hai";
            break;
        case 2:
            day = "Thứ ba";
            break;
        case 3:
            day = "Thứ tư";
            break;
        case 4:
            day = "Thứ năm";
            break;
        case 5:
            day = "Thứ sáu";
            break;
        case 6:
            day = "Thứ bảy";
            break;
    }
    return day;
}
function twoDigits(n) {
    return n > 9 ? "" + n : "0" + n;
}
function spanNgay() {
    var $calendar = $container.find('#tblCalendar');
    var $items = $calendar.find('tr[class*="colNgay"] td');
    var span = 1;
    var index;
    var flagIndex = true;
    $items.each(function (i, x) {
        if (i <= $items.length - 1) {
            if ($items.eq(i).find('.week').text() == $items.eq(i + 1).find('.week').text()) {
                if (flagIndex) {
                    index = i;
                    flagIndex = false;
                }
                $items.eq(i + 1).remove();
                span++;
            }
            else {
                if (span > 1)
                    $items.eq(index).attr('rowspan', span);
                flagIndex = true;
                span = 1;
            }
        }
    });
}
function nextWeek() {
    CurWeekChange++;
    //if (CurWeekChange > MaxWeek) {
    if ($ddlWeek[0].selectedIndex == $ddlWeek.find('option').length - 1) {
        CurWeekChange = MaxWeek;
        var nextYear = new Number($ddlYear.val()) + 1;
        BindYears(nextYear);
        $ddlYear.select2('val', nextYear.toString());
        BindWeeks(nextYear);
        $ddlWeek[0].selectedIndex = 0;
        changeWeek($ddlWeek.val());
        return;
    }
    changeWeek(CurWeekChange);
    return;
}
function prevWeek() {
    CurWeekChange--;
    //if (CurWeekChange < MinWeek) {
    if ($ddlWeek[0].selectedIndex == 0) {
        var prevYear = new Number($ddlYear.val()) - 1;
        BindYears(prevYear);
        $ddlYear.select2('val', prevYear.toString());
        BindWeeks(prevYear);
        $ddlWeek[0].selectedIndex = $ddlWeek.find('option').length - 1;
        changeWeek($ddlWeek.val());
        return;
    }
    else
        changeWeek(CurWeekChange);
}
function changeWeek(week) {
    $ddlWeek.val(week.toString());
    $ddlWeek.trigger('change');
}

function insertDays(isSelectDonVi) {
    var today = new Date();
    var dd = today.getDate();
    var mm = today.getMonth() + 1; //January is 0!
    var color = '';
    var yyyy = today.getFullYear()
    /* Thêm ngày (nếu thiếu) */
    var $calendar = $container.find('#tblCalendar');
    $items = $calendar.find('tr[class*="colNgay"]');
    var total = $items.length;
    var firstDate = $('#calendar-week').find('#startDate').text();
    firstDate = firstDate.split('/');
    firstDate = new Date(firstDate[2], firstDate[1] - 1, firstDate[0]);
    var endDate = $('#calendar-week').find('#endDate').text();
    var endDateText = endDate;
    endDate = endDate.split('/');
    endDate = new Date(endDate[2], endDate[1] - 1, endDate[0]);
    var $table = $calendar.find('tbody');
    if (total == 0) {
        for (var i = 0; i <= 6; i++) {
            var d = new Date(firstDate.getFullYear(), firstDate.getMonth(), firstDate.getDate());
            var d1 = new Date(firstDate.getFullYear(), firstDate.getMonth(), firstDate.getDate());
            d.setDate(d.getDate() + i);
            if (d.getFullYear() == yyyy && d.getMonth() + 1 == mm && d.getDate() == dd) {
                color = "#429090";
            }
            var temp = isSelectDonVi ? templateLichLanhDao : templateLich;
            temp = temp.replace(/{{Day}}/g, dayNumberOfWeekToString(d.getDay()));
            temp = temp.replace(/{{stt}}/g, i);
            temp = temp.replace(/{{thaydoi}}/g, color);
            temp = temp.replace(/{{StringDay}}/g, twoDigits(d.getDate()) + '/' + twoDigits(d.getMonth() + 1) + '/' + d.getFullYear());
            $(".colNgay").append(temp);
            color = '';
        }
    }
    else if (total < 7) {
        var stepDate = new Date(firstDate.getFullYear(), firstDate.getMonth(), firstDate.getDate());
        var tempDay = -1;
        for (var step = 1; step <= 7 - total; step++) {
            $items = $calendar.find('tr[class*="colNgay"]');
            for (var i = 0; i < $items.length; i++) {
                var strDay = $items.eq(i).find('.day').text();
                var strDayText = strDay;
                strDay = strDay.split('/');
                var tempDate = new Date(strDay[2], strDay[1] - 1, strDay[0]);
                if (stepDate.getDay() != tempDate.getDay()) {
                    var temp = templateLich;
                    temp = temp.replace(/{{Day}}/g, dayNumberOfWeekToString(stepDate.getDay()));
                    temp = temp.replace(/{{StringDay}}/g, twoDigits(stepDate.getDate()) + '/' + twoDigits(stepDate.getMonth() + 1) + '/' + stepDate.getFullYear());
                    if ((stepDate.getDay() < tempDate.getDay() && stepDate.getDay() != 0)
                        || tempDate.getDay() == 0) {
                        $(temp).insertBefore($items.eq(i).parent('tr'));
                        tempDay = tempDate.getDay();
                        stepDate.setDate(stepDate.getDate() + 1);
                        break;
                    }
                    if (stepDate.getDay() > tempDate.getDay()
                        && stepDate.getDay() > tempDay) {
                        /* Fix lỗi ngày chủ nhật ở giữa tuần */
                        var $sunday = $calendar.find('tr[class="colNgay"] p[class="day"]:contains("' + endDateText + '")');
                        if ($sunday.length > 0) {
                            var $temp = $sunday.parent('td').parent('tr').nextAll('tr:not(td[class="colNgay"])');
                            $(temp).insertBefore($sunday.parent('td').parent('tr'));
                        }
                        else
                            //$table.append(temp);
                            $(".colNgay").append(temp);
                        tempDay = stepDate.getDay();
                        stepDate.setDate(stepDate.getDate() + 1);
                        break;
                    }
                }
                else {
                    stepDate.setDate(stepDate.getDate() + 1);
                }
            }
        }
        /* Xử lý nốt ngày còn thiếu/sai vị trí */
        $items = $calendar.find('tr[class*="colNgay"]');
        if ($items.length < 7) { // Thêm Chủ nhật
            var temp = templateLich;
            temp = temp.replace(/{{Day}}/g, dayNumberOfWeekToString(endDate.getDay()));
            temp = temp.replace(/{{StringDay}}/g, twoDigits(endDate.getDate()) + '/' + twoDigits(endDate.getMonth() + 1) + '/' + endDate.getFullYear());
            //$table.append(temp);
            $(".colNgay").append(temp);
        }
        else { /* Đảo thứ 7 với Chủ nhật */
            //$items.eq($items.length - 1).parent('tr').remove();
            //var d = new Date(endDate.getFullYear(), endDate.getMonth(), endDate.getDate());
            //d.setDate(d.getDate() - 1);
            //var temp = templateLich;
            //temp = temp.replace(/{{Day}}/g, dayNumberOfWeekToString(d.getDay()));
            //temp = temp.replace(/{{StringDay}}/g, twoDigits(d.getDate()) + '/' + twoDigits(d.getMonth() + 1) + '/' + d.getFullYear());
            //$items = $calendar.find('td[class*="colNgay"]');
            //$(temp).insertBefore($items.eq($items.length - 1).parent('tr'));

            /* Fix lỗi ngày chủ nhật ở giữa tuần */
            //var $sunday = $calendar.find('tr td[class="colNgay"] p[class="day"]:contains("' + endDateText + '")');
            //if ($sunday.length > 0) {
            //    var $temp = $sunday.parent('td').parent('tr').nextAll('tr:not(td[class="colNgay"])');
            //    var html = $sunday.parent('td').parent('tr')[0].outerHTML + $temp[0].outerHTML;
            //    $sunday.parent('td').parent('tr').remove();
            //    $temp.remove();
            //    $table.append(html);
            //}
        }
    }
}
function rowDeletelich(urlPost, arrRowId, rowTitle, urlFw) {
    if (arrRowId == '')
        createMessageDelete("Thông báo", "<div class=\"alert\"><strong>Chú ý!</strong> Bạn chưa chọn bản ghi nào!</div>");
    else {
        var htmlResponse1 = "";
        var urlNewFW = urlFw + '&do=delete&ItemID=' + arrRowId + '&temp=' + Math.floor(Math.random() * 11);
        htmlResponse1 += "<script type=\"text/javascript\">\r\n";
        htmlResponse1 += "$(document).ready(function(){\r\n";
        htmlResponse1 += "   unbindHotkey();\r\n";
        //Đăng ký sự kiện khi click vào nút delete
        htmlResponse1 += "   $(\"#btnComfirmDelete1\").click(function(){\r\n";
        htmlResponse1 += "       $.post(encodeURI(\"" + urlPost + "\"), { \"do\": \"delete\", \"itemId\": \"" + arrRowId + "\" }, function (data) {\r\n";
        htmlResponse1 += "       $('#btnComfirmClose').click();\r\n";
        htmlResponse1 += "           if (data.Error) {\r\n";
        htmlResponse1 += "               createMessage(\"Có lỗi xảy ra\", data.Title);\r\n";
        htmlResponse1 += "                loadList();";
        htmlResponse1 += "           }\r\n";
        htmlResponse1 += "           else {\r\n";
        htmlResponse1 += "                loadList();";
        htmlResponse1 += "               createCloseMessage(\"Thông báo\", data.Title, '" + urlNewFW + "');\r\n";
        htmlResponse1 += "           }\r\n";
        htmlResponse1 += "       });\r\n";
        htmlResponse1 += "   });\r\n";
        htmlResponse1 += "   $(document).bind('keypress', 'x', function (evt) {\r\n"; //Sự kiện bấm phím x
        htmlResponse1 += "       $('#btnComfirmDelete1').click();\r\n";
        htmlResponse1 += "   });\r\n";
        htmlResponse1 += "   $(document).bind('keypress', 'return', function (evt) {\r\n"; //Sự kiện bấm phím enter
        htmlResponse1 += "       $('#btnComfirmDelete1').click();\r\n";
        htmlResponse1 += "   });\r\n";
        htmlResponse1 += "   $(document).bind('keypress', 'd', function (evt) {\r\n"; // Sự kiện bấm phím d
        htmlResponse1 += "       $('#btnComfirmClose').click();\r\n";
        htmlResponse1 += "   });\r\n";
        htmlResponse1 += "   $('#dialog-confirm').on('hidden', function () {\r\n";
        htmlResponse1 += "      bindHotkey();\r\n";
        htmlResponse1 += "   })\r\n";
        htmlResponse1 += "});" + "</script" + ">\r\n";
        htmlResponse1 += "<div class=\"modal-header\">";
        htmlResponse1 += "<button type=\"button\" class=\"close\" data-dismiss=\"modal\" aria-hidden=\"true\"></button>";
        htmlResponse1 += "	<h4 class=\"modal-title\">Xóa bản ghi đã chọn</h4>";
        htmlResponse1 += "</div>";
        htmlResponse1 += "<div class=\"modal-body\">";
        htmlResponse1 += "    <div class=\"alert\">";
        htmlResponse1 += "		<strong>Chú ý!</strong> Bạn có chắc chắn muốn xóa!";
        htmlResponse1 += "	</div>";
        htmlResponse1 += "<ul>";
        htmlResponse1 += rowTitle;
        htmlResponse1 += "</ul>";
        htmlResponse1 += "</div>";
        htmlResponse1 += "<div class=\"modal-footer\">";
        htmlResponse1 += "	<button type=\"submit\"  onclick=\"loadList()\" id=\"btnComfirmDelete1\" class=\"btn brown \" tabindex=\"5\"><i class=\"icon-trash\"></i> <b>X</b>óa</button>";
        htmlResponse1 += "	<button type=\"button\" id=\"btnComfirmClose\" class=\"btn red\" data-dismiss=\"modal\" tabindex=\"8\" onclick=\"loadList()\"><i class='fa fa-remove'></i> <b>Đ</b>óng lại</button>";
        htmlResponse1 += "</div>";

        $('#dialog-confirm').html(htmlResponse1);
        $('#dialog-confirm').modal({ width: 650 });
    }
}