function ChangeKhuVuc(surveydepartment) {
    debugger
    var area = $("#KhuVuc").val();
    var listselect = [];
    $.ajax({
        type: "POST",
        url: "/Transit/DieuPhoi/AjaxFormThemDonHang.aspx/ChangeKhuVuc",
        data: "{stringKhuvucid:'" + area + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            debugger
            if (surveydepartment !== "")
                data.d.forEach(element => {
                    if (surveydepartment==(element.id)) {
                        listselect.push(element);
                    }
                });
            $('#PhuongXa').select2({
                //multiple: true,
                data: data.d,
            })
        },
        complete: function (data) {
            //$("#PhuongXa").select2('data', listselect);
        }
    });
}
function ChangePhuongXa(surveydepartment) {
    debugger
    var area = $("#PhuongXa").val();
    var listselect = [];
    $.ajax({
        type: "POST",
        url: "/Transit/DieuPhoi/AjaxFormThemDonHang.aspx/ChangePhuongXa",
        data: "{stringPhuongXaid:'" + area + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            debugger
            if (surveydepartment !== "")
                data.d.forEach(element => {
                    if (surveydepartment == (element.id)) {
                        listselect.push(element);
                    }
                });
            $('#DuongAp').select2({
                //multiple: true,
                data: data.d,
            })
        },
        complete: function (data) {
            //$("#PhuongXa").select2('data', listselect);
        }
    });
}