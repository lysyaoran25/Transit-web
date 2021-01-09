//var urlScan = '/ScanVanBan/ScanAndUpload.aspx'; // Dynamic Web Twain 9.2
var urlKySo= '/ScanVanBan/KySo.aspx'; // Applet
//var urlView = '/ScanVanBan/OnlineDemoView.aspx';
var urlView = '/_layouts/15/WopiFrame2.aspx?sourcedoc={{SPUrl}}&action=interactivepreview&wdSmallView=0';
var urlDelete = '/API/FileDinhKemService.asmx/DeleteFileScan';
var winScan = 'ScanWindow';
var winView = 'ViewWindow';
var $btnKySo = $('#btnKySo');
var $listScan = $('#listScan');
var $listFileScan = $('#listFileScan');

function openWindow(url, name, width, height) {
    var left = (screen.width / 2) - (width / 2);
    var top = (screen.height / 2) - (height / 2);
    var win = window.open(url, name, 'toolbar=yes,location=no,directories=no,status=yes,menubar=no,scrollbars=yes,resizable=yes,width=' + width + ',height=' + height + ',top=' + top + ',left=' + left);
    win.focus();
    return false;
}

$btnKySo.click(function (e) {
    openWindow(urlKySo, winScan, 1024, 800);
});

function addFileScan(id, spUrl, name, extension) {

    $listScan.append(
        '<li data-fileid="' + id + '"><b>' + name + '</b><br />' +
            '<a href="javascript:deleteFileScan(' + id + ',\'' + spUrl + '\');" title="Xóa">' +
                '<img src="/Publishing_Resources/img/LastIcon/act_filedelete.png" />' +
            '</a>&nbsp;&nbsp;|' +
            '<a href="/' + spUrl + '" title="Xem trước văn bản">' +
                '<img src="/Publishing_Resources/img/LastIcon/view.gif" />' +
            '</a>' +
        '</li>');
    updateListFileScan();
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
