function validationSartDateEndDate(sectionStart, sectionEnd) {
    var startDate;
    var endDate;
    $(sectionStart).datepicker()
                 .on('changeDate', function (ev) {
                     startDate = '';
                     startDate = new Date(ev.date.getFullYear(), ev.date.getMonth(), ev.date.getDate(), 0, 0, 0);
                     if (endDate != null && endDate != 'undefined' && endDate != '') {
                         if (endDate < startDate) {
                             $("#ThoiGianBatDaut").val('');
                             $(this).val("");
                             return false;
                         }
                     }
                 });
    $(sectionEnd).datepicker()
        .on("changeDate", function (ev) {
            endDate = '';
            endDate = new Date(ev.date.getFullYear(), ev.date.getMonth(), ev.date.getDate(), 0, 0, 0);
            if (startDate != null && startDate != 'undefined' && startDate != '') {
                if (endDate < startDate) {
                    $("#ThoiGianKetThuct").val('');
                    $(this).val("");
                    return false;

                }
            }
        });
}
function validationLichTuan(sectionStart, sectionEnd) {
    var startDate;
    var endDate;


    $(sectionStart).datepicker()
                 .on('changeDate', function (ev) {
                     var Ends = new Date($("#endDate").text());
                     startDate = '';
                     startDate = new Date(ev.date.getFullYear(), ev.date.getMonth(), ev.date.getDate(), 0, 0, 0);
                     if (endDate != null && endDate != 'undefined' && endDate != '') {
                         if (Starts <= startDate) {
                             $("#ThoiGianBatDau").val("");
                         }
                     }
                 });
    $(sectionEnd).datepicker()
        .on("changeDate", function (ev) {
            endDate = '';
            var Starts = new Date($("#startDate").text());
            endDate = new Date(ev.date.getFullYear(), ev.date.getMonth(), ev.date.getDate(), 0, 0, 0);
            if (startDate != null && startDate != 'undefined' && startDate != '') {
                if (endDate <= Ends) {
                    $("#ThoiGianKetThuc").val("");
                }
            }
        });
}