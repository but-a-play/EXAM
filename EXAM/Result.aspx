<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Result.aspx.cs" Inherits="EXAM.Result1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link rel="stylesheet" href="layui/css/layui.css" />
    
</head>
<body>
    <form id="tabs" runat="server">
        <div class="layui-tab">
            <ul class="layui-tab-title">
                <li class="layui-this">考生信息</li>
                <li>教室甲</li>
                <li>教室乙</li>

                <li>考生信息2</li>
                <li>教室甲2</li>
                <li>教室乙2</li>

                <li>考生信息3</li>
                <li>教室甲3</li>
                <li>教室乙3</li>

                <li>考生信息4</li>
                <li>教室甲4</li>
                <li>教室乙4</li>
            </ul>
            <div class="layui-tab-content">
                <div class="layui-tab-item layui-show" style="height:800px">
                    <iframe frameborder="0" scrolling="yes" src="/RosterPage.aspx" style="height: 100%; visibility: inherit; width: 100%; z-index: 1;"></iframe>
                </div>
                <div class="layui-tab-item" style="height:800px">
                    <iframe frameborder="0" scrolling="yes" src="/Room1Page.aspx" style="height: 100%; visibility: inherit; width: 100%; z-index: 1;"></iframe>
                </div>
                <div class="layui-tab-item"  style="height:800px">
                    <iframe frameborder="0" scrolling="yes" src="/Room2Page.aspx" style="height: 100%; visibility: inherit; width: 100%; z-index: 1;"></iframe>
                </div>

                <div class="layui-tab-item" style="height:800px">
                    <iframe frameborder="0" scrolling="yes" src="/RosterPage2.aspx" style="height: 100%; visibility: inherit; width: 100%; z-index: 1;"></iframe>
                </div>
                <div class="layui-tab-item" style="height:800px">
                    <iframe frameborder="0" scrolling="yes" src="/Room1Page2.aspx" style="height: 100%; visibility: inherit; width: 100%; z-index: 1;"></iframe>
                </div>
                <div class="layui-tab-item"  style="height:800px">
                    <iframe frameborder="0" scrolling="yes" src="/Room2Page2.aspx" style="height: 100%; visibility: inherit; width: 100%; z-index: 1;"></iframe>
                </div>

                <div class="layui-tab-item" style="height:800px">
                    <iframe frameborder="0" scrolling="yes" src="/RosterPage3.aspx" style="height: 100%; visibility: inherit; width: 100%; z-index: 1;"></iframe>
                </div>
                <div class="layui-tab-item" style="height:800px">
                    <iframe frameborder="0" scrolling="yes" src="/Room1Page3.aspx" style="height: 100%; visibility: inherit; width: 100%; z-index: 1;"></iframe>
                </div>
                <div class="layui-tab-item"  style="height:800px">
                    <iframe frameborder="0" scrolling="yes" src="/Room2Page3.aspx" style="height: 100%; visibility: inherit; width: 100%; z-index: 1;"></iframe>
                </div>

                <div class="layui-tab-item" style="height:800px">
                    <iframe frameborder="0" scrolling="yes" src="/RosterPage4.aspx" style="height: 100%; visibility: inherit; width: 100%; z-index: 1;"></iframe>
                </div>
                <div class="layui-tab-item" style="height:800px">
                    <iframe frameborder="0" scrolling="yes" src="/Room1Page4.aspx" style="height: 100%; visibility: inherit; width: 100%; z-index: 1;"></iframe>
                </div>
                <div class="layui-tab-item"  style="height:800px">
                    <iframe frameborder="0" scrolling="yes" src="/Room2Page4.aspx" style="height: 100%; visibility: inherit; width: 100%; z-index: 1;"></iframe>
                </div>
            </div>
        </div>
    </form>
    <script type="text/javascript" src="layui/layui.js"></script>
    <script type="text/javascript">
        layui.use('element', function () {
            var element = layui.element;
           
        });

    </script>
</body>
</html>

