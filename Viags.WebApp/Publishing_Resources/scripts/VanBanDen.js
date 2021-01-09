// Load cơ quan ban hành
function loadCoQuanBanHanh() {
    var keyword = $("#CoQuanBanHanhText").val();    
    $.ajax({
        cache: false,
        type: 'POST',
        url: "/API/CoQuanBanHanh.asmx/GetList",
        contentType: 'application/json; charset=UTF-8',
        dataType: 'json',
        data: JSON.stringify({ q: keyword,  limit: 10 }),
        success: function (data) {
            //console.log(data);
            //console.log("---------------");
            //console.log(data.d);
            $("#CoQuanBanHanhText").autocomplete({
                minLength: 0,
                delay: 500,
                source: function (request, response) {
                    var matcher = new RegExp($.ui.autocomplete.escapeRegex(request.term), "i");
                    response($.grep(data.d, function (value) {
                        return matcher.test(value.value)
                            || matcher.test(value.tag);
                    }));
                }
            });
        }
    });
}
function loadCoQuanBanHanh22() {
    $("#CoQuanBanHanhText").autocomplete({
        source: function (request, response) {
            jQuery.ajax({
                url: "/API/CoQuanBanHanh.asmx/GetList",
                data: "{ 'q': '" + request.term + "','limit': '10'}",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    response($.map(data.d, function (item) {
                        return {
                            label: item.value,
                            val: item.id,
                            chucvu: item.tag
                        }
                    }))
                },
                error: function (response) {
                    alert(response.responseText);
                },
                failure: function (response) {
                    alert(response.responseText);
                }
            });
        },
        select: function (e, i) {
            var text = this.value.split(/,\s*/);
            text.pop();
            text.push(i.item.label);
            text.push("");
            this.value = text.join("");

            return false;
        },
        minLength: 1
    });

}

