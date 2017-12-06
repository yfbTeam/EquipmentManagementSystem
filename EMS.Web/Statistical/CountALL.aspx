<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CountALL.aspx.cs" Inherits="EMS.Web.Statistical.CountALL" %>

<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8">
    <title>ECharts</title>
    <link href="../css/style.css" rel="stylesheet" />
    <!-- 引入 echarts.js -->
    <script src="../js/echarts.js"></script>
    <script src="../js/jquery-1.11.2.min.js"></script>


    <script src="../js/Common.js"></script>
    <script src="../js/layer/layer.js"></script>
</head>
<body>
    <!-- 为ECharts准备一个具备大小（宽高）的Dom -->
    <div>
        <div id="main" style="float:left; width: 40%; height: 400px;"></div>
        <div id="table" style="float:left; text-align:center;  width: 50%; height: 400px;border:1px" >
            <table id="myTb" style=" width:100%;margin-top:260px;border:1px solid #ccc;" class="W_form">
                <%--<tr><td></td><td>数量</td></tr>--%>
                <thead>
                    <tr class="trth1">
                        <th>资产名称</th>
                        <th>数量</th>
                       </tr>
                </thead>
                <tbody id="tbody"></tbody>
           </table>

        </div>
    </div>
    <script type="text/html">

    </script>
    <script type="text/javascript">

        // 基于准备好的dom，初始化echarts实例
        var myChart = echarts.init(document.getElementById('main'));

        // 指定图表的配置项和数据
        option = {
            title: {
                text: '总资产统计',
                subtext: '',
                x: 'center'
            },
            tooltip: {
                trigger: 'item',
                formatter: "{a} <br/>{b} : {c} ({d}%)"
            },
            legend: {
                orient: 'vertical',
                left: 'left',
                data: ['教学资产', '科研资产', '办公资产']
            },
            series: [
                {
                    name: '资产统计',
                    type: 'pie',
                    radius: '55%',
                    center: ['50%', '60%'],
                    data: [

                    ],
                    itemStyle: {
                        emphasis: {
                            shadowBlur: 10,
                            shadowOffsetX: 0,
                            shadowColor: 'rgba(0, 0, 0, 0.5)'
                        }
                    }
                }
            ]
        };
        // 使用刚指定的配置项和数据显示图表。
        myChart.setOption(option);
        var name = [];


        $.ajax({
            type: "post",
            async: false, //异步请求（同步请求将会锁住浏览器，用户其他操作必须等待请求完成才可以执行）
            url: WebServiceUrl + "/Statistical/Statistical.ashx",
            data: { action: "SelectCountALL" },//demo 没加条件
            dataType: "jsonp",
            jsonp: "jsoncallback",
            success: function (result) {

                for (var i = 0; i < result.result.length; i++) {
                    name.push(result.result[i].name);
                }
                myChart.setOption({ //加载数据图表
                    legend: { data: name },
                    series: [{
                        data: result.result
                    }]
                });

                var typeData = result.result;
                $.each(typeData, function (i, n) {
                    var tbBody = ""
                    var trColor = "科目";
                    tbBody += "<tr class='even'><td >" + n.name + "</td>" + "<td>" + n.value + "</td></tr>";
                    $("#tbody").append(tbBody);
                });


            },
            error: function (errorMsg) {
                alert("请求数据失败!");
            }
        });


    </script>
</body>
</html>
