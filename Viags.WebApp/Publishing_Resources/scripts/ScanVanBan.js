//var urlScan = '/ScanVanBan/ScanAndUpload.aspx'; // Dynamic Web Twain 9.2
var urlScan = '/ScanVanBan/Scan.aspx'; // Applet
//var urlView = '/ScanVanBan/OnlineDemoView.aspx';
var urlView = '/_layouts/15/WopiFrame2.aspx?sourcedoc={{SPUrl}}&action=interactivepreview&wdSmallView=0';
var urlDelete = '/API/FileDinhKemService.asmx/DeleteFileScan';
var winScan = 'ScanWindow';
var winView = 'ViewWindow';
var $btnScan = $('#btnScan');
var $listScan = $('#listScan');
var $listFileScan = $('#listFileScan');
var $lstBatID= $('#listBatchID');

function openWindow(url, name, width, height) {
   
    var left = (screen.width / 2) - (width / 2);
    var top = (screen.height / 2) - (height / 2);
    var win = window.open(url, name, 'toolbar=yes,location=no,directories=no,status=yes,menubar=no,scrollbars=yes,resizable=yes,width=' + width + ',height=' + height + ',top=' + top + ',left=' + left);
    win.focus();
    return false;
}

$btnScan.click(function (e) {
    openWindow(urlScan, winScan, 1024, 800);
});

function addFileScan(id, spUrl, name, extension) {
    
    $listScan.append(
        '<li data-fileid="' + id + '"><b>' + name + '</b><br />' +
            '<a href="javascript:deleteFileScan(' + id + ',\'' + spUrl + '\');" title="Xóa">' +
                '<img src="/Publishing_Resources/img/LastIcon/act_filedelete.png" />' +
            '</a>&nbsp;&nbsp;|'+
            //'<a href="javascript:viewFileScan(' + id + ',\'' + name + '\',\'' + extension + '\');" title="Xem trước văn bản">' +
            //    '<img src="/Publishing_Resources/img/LastIcon/view.gif" />' +
            //'</a>' +
            '<a href="/'+spUrl+'" title="Xem trước văn bản">' +
                '<img src="/Publishing_Resources/img/LastIcon/view.gif" />' +
            '</a>' +
        '</li>');
    
    updateListFileScan();
}
function addBatchIDandFileScan(id, spUrl, name, extension, batchid) {
    var loadingSoHoa = $("#loadingSoHoa").length;
    if (loadingSoHoa > 0) {
        $("#loadingSoHoa").show();
    }
    $listScan.append(
        '<li data-fileid="' + id + '"><b>' + name + '</b><br />' +
            '<a href="javascript:deleteFileScan(' + id + ',\'' + spUrl + '\');" title="Xóa">' +
                '<img src="/Publishing_Resources/img/LastIcon/act_filedelete.png" />' +
            '</a>&nbsp;&nbsp;|' +
            //'<a href="javascript:viewFileScan(' + id + ',\'' + name + '\',\'' + extension + '\');" title="Xem trước văn bản">' +
            //    '<img src="/Publishing_Resources/img/LastIcon/view.gif" />' +
            //'</a>' +
            '<a href="/' + spUrl + '" title="Xem trước văn bản">' +
                '<img src="/Publishing_Resources/img/LastIcon/view.gif" />' +
            '</a>' +
        '</li>');
    $lstBatID.val(batchid);
    FillVanbanSoHoa(batchid);
    updateListFileScan();
}

function FillVanbanSoHoa(batchid) {
    setTimeout(function(){
            $.ajax({
                type: "POST",
                async: false,
                url: "/API/VanBanService.asmx/GetByBatchId",
                data: "{ bacthId: '" + batchid + "' }",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    if (data.d == null || data.d == undefined) {
                        console.log('callback fill van ban so hoa');
                        FillVanbanSoHoa(batchid);
                    } else {

                        $('#SoKyHieu').val(data.d.SoKyHieu);
                        $('#NgayBanHanh').val(data.d.NgayVanBan);
                        //$('#NgayBanHanh').val(data.d.NgayBanHanh);
                        $('#TrichYeu').val(data.d.TrichYeu);
                        //$('#HanXuLy').val(data.d.HanXuLy);
                        if (data.d.DoMat != null && data.d.DoMat != undefined) {
                            $("#DanhMucGiaTriID_3").val(data.d.DoMat).trigger("change");
                        }
                        if (data.d.DoKhan != null && data.d.DoKhan != undefined) {
                            $("#DanhMucGiaTriID_2").val(data.d.DoKhan).trigger("change");
                        }
                        if (data.d.LoaiVanBan != null && data.d.LoaiVanBan != undefined) {
                            $("#LoaiVanBanID").val(data.d.LoaiVanBan).trigger("change");
                        }
                        //if (data.d.CoQuanBanHanhID != null && data.d.CoQuanBanHanhID != undefined && data.d.CoQuanBanHanh != null && data.d.CoQuanBanHanh != undefined) {
                        //    $("#CoQuanGuiDenID").select2('data', { id: data.d.CoQuanBanHanhID, text: data.d.CoQuanBanHanh });
                        //}
                        var loadingSoHoa = $("#loadingSoHoa").length;
                        if (loadingSoHoa > 0) {
                            $("#loadingSoHoa").hide();
                        }
                    }
           
                }
            });
    }, 2000);
}
function deleteFileScan(id, spUrl) {
    $.ajax({
        async: false,
        type: 'POST',
        url: urlDelete,
        data: JSON.stringify({ id: id, spUrl: spUrl }),
        contentType: 'application/json; charset=UTF-8',
        dataType: 'json',
        success: function (data) {
            var obj = JSON.parse(data.d);
            if (obj.success) {
                $listScan.find('li[data-fileid="' + id + '"]').remove();
                updateListFileScan();
            }
            else
                alert(obj.message);
        }
    });
}

//function viewFileScan(id, name, extension) {
//    openWindow(urlView + '?iImageIndex=' + id + '&ImageName=' + name + '&ImageExtName=' + extension,
//        winView, 1024, 800);
//}
function viewFileScan(spUrl) {
    //openWindow(urlView.replace("{{SPUrl}}", spUrl),
    //    winView, 1024, 800);
    window.open(urlView.replace("{{SPUrl}}", spUrl), '_blank');
    window.focus();
}

function updateListFileScan() {
    $listFileScan.val('');
    $listScan.find('li').each(function (i, x) {
        var id = $(x).attr('data-fileid');
        $listFileScan.val($listFileScan.val() + ',' + id);
    });
    $listFileScan.val($listFileScan.val().substring(1));
}
