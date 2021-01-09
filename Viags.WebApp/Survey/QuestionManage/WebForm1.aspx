<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Viags.WebApp.Survey.QuestionManage.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.5.1/jquery.min.js" integrity="sha512-bLT0Qm9VnAYZDflyKcBaQ2gg0hSYNQrJ8RilYldYQ1FxQYoCLtUjuuRuZo+fjqhx/qtq/1itJ0C2ejDxltZVFg==" crossorigin="anonymous"></script>
    <link href="https://cdn.jsdelivr.net/npm/select2@4.1.0-beta.1/dist/css/select2.min.css" rel="stylesheet" />
    <script type="text/javascript" src="https://cdn.jsdelivr.net/npm/select2@4.1.0-beta.1/dist/js/select2.min.js"></script>
    <style>
        .table-scroll {
            position: relative;
            max-width: 600px;
            margin: auto;
            overflow: hidden;
            border: 1px solid #000;
        }

        .table-wrap {
            width: 100%;
            overflow: auto;
        }

        .table-scroll table {
            width: 100%;
            margin: auto;
            border-collapse: separate;
            border-spacing: 0;
        }

            .table-scroll table .width-header {
                width: 100px
            }

            .table-scroll table .width-body {
                width: 100px
            }
    </style>
    <script>
        // requires jquery library

        $(document).ready(function () {
            var x = screen.width;
            $(".table-scroll").css("max-width", x);
        })

    </script>
</head>
<body>
    <div id="table-scroll" class="table-scroll">
        <div class="table-wrap">
            <table class="main-table">
                <thead>
                    <tr>
                        <th class="fixed-side">&nbsp;</th>
                        <th class="width-header">Header 2</th>
                        <th class="width-header">Header 3</th>
                        <th class="width-header">Header 4</th>
                        <th class="width-header">Header 5</th>
                        <th class="width-header">Header 6</th>
                        <th class="width-header">Header 7</th>
                        <th class="width-header">Header 8</th>
                        <th class="width-header">Cell content</th>
                        <th class="width-header">Cell content</th>
                        <th class="width-header">Cell content</th>
                        <th class="width-header">Cell content</th>
                        <th class="width-header">Cell content</th>
                        <th class="width-header">Cell content</th>
                        <th class="width-header">Cell content</th>
                        <th class="width-header">Cell content</th>
                        <th class="width-header">Cell content</th>
                        <th class="width-header">Cell content</th>
                        <th class="width-header">Cell content</th>
                        <th class="width-header">Cell content</th>
                        <th class="width-header">Cell content</th>
                        <th class="width-header">Cell content</th>
                        <th class="width-header">Cell content</th>
                        <th class="width-header">Cell content</th>
                        <th class="width-header">Cell content</th>
                        <th class="width-header">Cell content</th>
                        <th class="width-header">Cell content</th>
                        <th class="width-header">Cell content</th>
                        <th class="width-header">Cell content</th>
                        <th class="width-header">Cell content</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td class="fixed-side">Left Column</td>
                        <td class="width-body">Cell content<br>
                            test</td>
                        <td class="width-body"><a href="#">Cell content longer</a></td>
                        <td class="width-body">Cell content</td>
                        <td class="width-body">Cell content</td>
                        <td class="width-body">Cell content</td>
                        <td class="width-body">Cell content</td>
                        <td class="width-body">Cell content</td>
                        <td class="width-body">Cell content</td>
                        <td class="width-body">Cell content</td>
                        <td class="width-body">Cell content</td>
                        <td class="width-body">Cell content</td>
                        <td class="width-body">Cell content</td>
                        <td class="width-body">Cell content</td>
                        <td class="width-body">Cell content</td>
                        <td class="width-body">Cell content</td>
                        <td class="width-body">Cell content</td>
                        <td class="width-body">Cell content</td>
                        <td class="width-body">Cell content</td>
                        <td class="width-body">Cell content</td>
                        <td class="width-body">Cell content</td>
                        <td class="width-body">Cell content</td>
                        <td class="width-body">Cell content</td>
                        <td class="width-body">Cell content</td>
                        <td class="width-body">Cell content</td>
                        <td class="width-body">Cell content</td>
                        <td class="width-body">Cell content</td>
                        <td class="width-body">Cell content</td>
                        <td class="width-body">Cell content</td>
                        <td class="width-body">Cell content</td>
                    </tr>
                    
                </tbody>

            </table>
        </div>
    </div>

    <p>See <a href="https://codepen.io/paulobrien/pen/LBrMxa" target="blank">position Sticky version </a>with no JS</p>
</body>
</html>

