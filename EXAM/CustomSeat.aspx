<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomSeat.aspx.cs" Inherits="EXAM.CustomSeat" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style>
        #template_tr, #template_td {
            display: none;
        }

        td {
            border: 1px solid black;
            width: 80px;
            height: 60px;
            background-color:antiquewhite;
        }
    </style>
</head>
<script src="scripts/jquery.min.js"></script>
<body>
    <form id="form1" runat="server">
        <div>

            <div>
                行：<input type="text" name="row" id="row" />
                列：<input type="text" name="col" id="col" />
                生成：<input id="btnCreate" type="button" value="生成教室" onclick="createRoom()" />
            </div>

            <table id="room">
                
                <tr id="template_tr">
                    <td id="template_td"></td>
                </tr>
            </table>
        </div>
    </form>
    <script type="text/javascript">
        function createRoom() {
            var row = $("#row").val();
            var col = $("#col").val();
            for (var r = 0; r < row; ++r) {
                var newTr = $("#template_tr").clone();

                $("#room").append(newTr.html());
                for (var c = 0; c < col; ++c) {
                    var newTd = $("#template_td").clone();

                    newTr.append(newTd.html());
                }
            }
        }
        
        function createRoom2() {
            var row = $("#row").val();
            var col = $("#col").val();
            var html;
            for (var r = 0; r < row; ++r) {
                html += "<tr>";

                
                for (var c = 0; c < col; ++c) {
                    html += "<td>"+r+","+c+"</td>";
                }

                html += "</tr>";
            }

            $("#room").html(html);
        }
    </script>
</body>
</html>
