<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="file.aspx.cs" Inherits="Viags.WebApp.file" %>

<!DOCTYPE html>
<!-- saved from url=(0111)/Pagess/van-ban-den.aspx#Field=ThuTu&SoVanBanID=1235&LoaiDanhSachID=0&Page=1&RowPerPage=10 -->
<html dir="ltr" lang="vi-VN">
<head>
</head>
<body class="page-header-fixed page-container-bg-solid" id="divApp">

    <%if (checkIDM)
        {%>
    tat idm
    <%} else{%>
     <iframe src="/Publishing_Resources/PDFViewer/web/viewer.html?file=<%=path %>" style="width:100%; height:500px;"></iframe>
    <%--<iframe src="http://docs.google.com/gview?url=https://e-office.anovafeed.vn:65002/ajaxupload/6634/2019/pdf-test.pdf&embedded=true" style="width:100%; height:500px;" frameborder="0"></iframe>--%>
       <%}%>
   

    <%--<div id="xxx">
   
           <script src="/Publishing_Resources/dist/app.min.js" type="text/javascript"></script>
   
            <script>
                $(document).keydown(function (event) {
                    if (event.keyCode == 123) {
                        return false;
                    }
                    else if (event.ctrlKey && event.shiftKey && event.keyCode == 73) {
                        return false;
                    }
                });

                $(document).on("contextmenu", function (e) {
                    e.preventDefault();
                });
        </script>
    </div>--%>

    <script>
            //ViewFile('<%=path %>');

            function ViewFile(Path) {
                var headContent = document.getElementById('xxx').innerHTML;
                var model = $('#divApp');
                model.append(imageLoading);
                $.ajax({
                    url: '/API/ConvertToImage.ashx/ConvertToImage',
                    dataType: "json",
                    data: { q: Path },
                    contentType: "application/json; charset=utf-8",
                    success: function (msg) {
                        if (msg.id === "2") {
                            createCloseMessageNoload("Có lỗi xảy ra.", "Không tìm thấy file.");
                        } else if (msg.id === "0") {
                            createCloseMessageNoload("Có lỗi xảy ra.", "Không tìm thấy file.");
                        } else if (msg.id === "1" && msg.text === "") {
                            createCloseMessageNoload("Có lỗi xảy ra.", "Không tìm thấy file.");
                        } else {
                            debugger;
                            var wOpen = window.open($(this).attr("href"), '_parent');
                            wOpen.document.write(headContent);
                            wOpen.document.write(msg.text);
                        }
                    },
                    complete: function (data) {
                        $(".loading").remove();
                    }
                });
            }

    </script>







</body>
</html>


