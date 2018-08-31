<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DragDemo.aspx.cs" Inherits="EXAM.DragDemo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>可拖动块-Demo</title>
    <style>
        .seat {
            width: 100px;
            height: 80px;
            border: 1px solid black;
            text-align: center;
            padding: 0;
            background-color:gray;
        }

        .stu {
            width: 80px;
            height: 60px;
            border: 1px solid gray;
            background-color:beige;
        }

        .seat .stu{
            background-color:yellowgreen;
        }
    </style>
    <script src="scripts/jquery.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="seats" style="width:500px;height:400px;border:1px solid black">
            <div class="seat" ondrop="drop(event)" ondragover="allowDrop(event)">
                <div class="stu" id="stu" draggable="true" ondragstart="drag(event)">
                    A
                </div>
            </div>
        </div>

        <div class="stus"style="width:300px;height:200px;border:1px solid red" ondrop="drop(event)" ondragover="allowDrop(event)">
            <div class="stu" id="stu1" draggable="true" ondragstart="drag(event)">
                B
            </div>
        </div>
    </form>
    <script>
        function allowDrop(ev) {
            ev.preventDefault();
        }

        function drag(ev) {
            ev.dataTransfer.setData("text", ev.target.id);
        }

        function drop(ev) {
            ev.preventDefault();
            var data = ev.dataTransfer.getData("Text");
            var oldStu = document.getElementById(ev.target.id);//stu
            var temp = ev.target.id;
            var tempHtml = $(oldStu).html();
            var newStu = document.getElementById(data);//stu1
            $(oldStu).attr("id", data);
            $(newStu).attr("id", temp);
            $(oldStu).html($(newStu).html());
            $(newStu).html(tempHtml);

            

        }
    </script>
</body>
</html>
