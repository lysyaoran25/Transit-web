function ChangeKhuVuc(surveydepartment) {
    debugger
    var area = $("#KhuVucID").val();
    var listselect = [];
    var listselectChuyen = [];
    var dayofweek = $("#NgayKhoiHanh").datepicker('getDate').getUTCDay();
    $.ajax({
        type: "POST",
        url: "/Transit/DieuPhoi/AjaxFormThemDonHang.aspx/ChangeKhuVuc" + "?dayofweek=" + dayofweek,
        data: "{stringKhuvucid:'" + area + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            debugger
            if (surveydepartment !== "")
                data.d.LstDanhMucChuyenItem.forEach(element => {
                    if (surveydepartment == (element.id)) {
                        listselectChuyen.push(element);
                    }
                });
            data.d.LstPhuongXaItem.forEach(element => {
                if (surveydepartment == (element.id)) {
                    listselect.push(element);
                }
            });
            $('#PhuongXaID').select2({
                //multiple: true,
                data: data.d.LstPhuongXaItem,
            })
            $('#ThoiGianKhoiHanh').select2({
                //multiple: true,
                data: data.d.LstDanhMucChuyenItem,
            })
        },
        complete: function (data) {
            //$("#PhuongXa").select2('data', listselect);
        }
    });
}
function ChangePhuongXa(surveydepartment) {
    debugger
    var area = $("#PhuongXaID").val();
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
            $('#DuongApID').select2({
                //multiple: true,
                data: data.d,
            })
        },
        complete: function (data) {
            //$("#PhuongXa").select2('data', listselect);
        }
    });
}
function ChangeThoiGianKhoiHanh() {
    debugger
    var area = $("#KhuVucID").val();  
    var listselectChuyen = [];
    var dayofweek = $("#NgayKhoiHanh").datepicker('getDate').getUTCDay();
    $.ajax({
        type: "POST",
        url: "/Transit/DieuPhoi/AjaxFormThemDonHang.aspx/ChangeThoiGianKhoiHanh" + "?dayofweek=" + dayofweek,
        data: "{stringKhuvucid:'" + area + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            debugger

            data.d.LstDanhMucChuyenItem.forEach(element => {
                listselectChuyen.push(element);
            });

            $('#ThoiGianKhoiHanh').select2({
                //multiple: true,
                data: data.d.LstDanhMucChuyenItem,
            })
        },
        complete: function (data) {
            //$("#PhuongXa").select2('data', listselect);
        }
    });
}