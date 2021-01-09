<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucNhanVien.ascx.cs" Inherits="Viags.WebApp.Hiface.NhanVien.ucNhanVien" %>

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
                        Nhân viên 
                    </div>
                </div>

               <a href="javascript:void(0)" onclick="syncHiface()" style=" font-size: 15px; "><i class="fas fa-sync"></i> Click Đồng bộ từ hiface qua</a> 


                <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.10.20/css/jquery.dataTables.css">

                <table id="tbl_employee" class="display" style="width: 100%">
                    <thead>
                        <tr>
                            <th>Tên</th>
                            <th>Thông tin</th>
                            <th>Onboarding time</th>
                            <th>Hình hiển thị</th>
                            <th>Hình kiểm chứng</th>
                            <th>Đồng bộ</th>
                        </tr>
                    </thead>
                </table>

            </div>
        </div>
    </div>
</div>
<script type="text/javascript" src="https://cdn.datatables.net/1.10.20/js/jquery.dataTables.min.js"></script>


<script type="text/javascript">
    $(document).ready(function () {
        var link_employee = "http://hiface.tinhvan.com/subject/list?size=99999999&category=employee";
        $.ajax({
            url: link_employee,
            type: 'GET',
            // Fetch the stored token from localStorage and set in the header
            headers: { "Authorization": 'b990b346-e791-41d5-9e07-590764708819' },
            success: function (data) {
                var o = JSON.stringify(data.data);//A la variable le asigno el json decodificado
                $('#tbl_employee').dataTable({
                    destroy: true,
                    data: JSON.parse(o),
                    pageLength: 10,
                    columns: [
                        { "data": "name" },
                        { "data": "description" }, 
                        {
                            "mData": "entry_date",
                            "mRender": function (data, type, row) {
                                return FormatDateTime(data);
                            }
                        },
                        //{ "data": "avatar" },
                        {
                            "mData": "avatar",
                            "mRender": function (data, type, row) {
                                return '<img src="http://hiface.tinhvan.com' + data + '",width=60px, height=60px />';
                            }
                        },
                        {
                            "mData": "photos",
                            "mRender": function (data, type, row) {
                                var img = "";
                                for (i = 0; i < data.length; i++) {
                                    img += '<img src="http://hiface.tinhvan.com' + data[i].url + '",width=60px, height=60px />';
                                }

                                return img;
                            }
                        },
                        { "data": null }, 
                    ]
                });
            }
        });
    });


    function FormatDateTime(input) {
        if (input === null) {
            return "";
        }
        var date = new Date(input * 1000);
        return date.format('dd-MM-yyyy') ;
    }

    function syncHiface() {
        $.ajax({
            url: "/hiface/NhanVien/AjaxList.aspx/SyncUserHiface",
            type: "POST",
           // data: dataValue,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                //console.log(data.d);
                events = data.d;
        });

    }
</script>
