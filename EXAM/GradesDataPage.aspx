<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GradesDataPage.aspx.cs" Inherits="EXAM.GradesDataPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="scripts/jquery.min.js"></script>
    <style>
        .div-center {
            text-align: center;
            margin: 0 auto;
        }

        .left {
            float: left;
        }

        .right {
            float: left;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="div-center">
            <%--<asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="left">
                        选择年份：<asp:DropDownList ID="ddlYears" runat="server" OnSelectedIndexChanged="ddlYears_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                        <div id="container1" style="width: 600px; height: 400px;"></div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="right">
                        选择单位：<asp:DropDownList ID="ddlDepartments" runat="server" OnSelectedIndexChanged="ddlDepartments_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                        <div id="container2" style="width: 600px; height: 400px;"></div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>--%>
            <div class="left">
                选择年份：<asp:DropDownList ID="ddlYears" runat="server" OnSelectedIndexChanged="ddlYears_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                <div id="container1" style="width: 600px; height: 400px;"></div>
            </div>
            <div class="right">
                选择单位：<asp:DropDownList ID="ddlDepartments" runat="server" OnSelectedIndexChanged="ddlDepartments_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                <div id="container2" style="width: 600px; height: 400px;"></div>
            </div>
        </div>
        <script src="scripts/highcharts.js"></script>
        <script>
            var dataJson1 = '<%=DataJson1%>';
            var dataJson2 = '<%=DataJson2%>';
            var dataObj1, dataObj2;
            if (dataJson1.length != 0) {
                dataObj1 = JSON.parse(dataJson1);
                init1(dataObj1);
            }
            if (dataJson2.length != 0) {
                dataObj2 = JSON.parse(dataJson2);
                init2(dataObj2);
            }

            function init1(dataObj) {
                if (dataObj != undefined && dataObj.length != 0) {
                    // 图表配置
                    var options = {
                        chart: {
                            type: 'bar'                          //指定图表的类型，默认是折线图（line）
                        },
                        title: {
                            text: $("#ddlYears").val() + '年每家单位分数段排行'                 // 标题
                        },
                        xAxis: {
                            categories: ['90-100分', '70-89分', '60-69分', '0-59分']   // x 轴分类
                        },
                        yAxis: {
                            title: {
                                text: '人数'                // y 轴标题
                            }
                        },
                        series: [{                              // 数据列
                            name: dataObj[0].DeptName,                        // 数据列名
                            data: dataObj[0].PeopleCount                    // 数据
                        }, {
                            name: dataObj[1].DeptName,
                            data: dataObj[1].PeopleCount
                        }, {
                            name: dataObj[2].DeptName,
                            data: dataObj[2].PeopleCount
                        }, {
                            name: dataObj[3].DeptName,
                            data: dataObj[3].PeopleCount
                        }, {
                            name: dataObj[4].DeptName,
                            data: dataObj[4].PeopleCount
                        }, {
                            name: dataObj[5].DeptName,
                            data: dataObj[5].PeopleCount
                        }, {
                            name: dataObj[6].DeptName,
                            data: dataObj[6].PeopleCount
                        }]
                    };
                    // 图表初始化函数
                    var chart = Highcharts.chart('container1', options);
                }
            }

            function init2(dataObj) {
                if (dataObj != undefined) {
                    // 图表配置
                    var options = {
                        chart: {
                            type: 'line'                          //指定图表的类型，默认是折线图（line）
                        },
                        title: {
                            text: $("#ddlDepartments").val() + '逐年平均分变化情况'
                        },
                        yAxis: {
                            title: {
                                text: '平均分'
                            }
                        },
                        legend: {
                            layout: 'vertical',
                            align: 'right',
                            verticalAlign: 'middle'
                        },
                        plotOptions: {
                            series: {
                                label: {
                                    connectorAllowed: false
                                },
                                pointStart: 2010
                            }
                        },
                        series: [{
                            name: $("#ddlDepartments").val(),
                            data: dataObj.Grades
                        }],
                        responsive: {
                            rules: [{
                                condition: {
                                    maxWidth: 500
                                },
                                chartOptions: {
                                    legend: {
                                        layout: 'horizontal',
                                        align: 'center',
                                        verticalAlign: 'bottom'
                                    }
                                }
                            }]
                        }
                    };
                    // 图表初始化函数
                    var chart = Highcharts.chart('container2', options);
                }
            }

        </script>

    </form>
</body>
</html>
