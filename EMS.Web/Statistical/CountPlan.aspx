<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CountPlan.aspx.cs" Inherits="EMS.Web.Statistical.CountPlan" %>

<!DOCTYPE html>

<html>
<head>
    <meta charset="utf-8">
    <title>ECharts</title>
    <!-- 引入 echarts.js -->
    <script src="../js/echarts.js"></script>
    <script src="../js/jquery-1.11.2.min.js"></script>
     <link href="../css/style.css" rel="stylesheet" />

    <script src="../js/Common.js"></script>
    <script src="../js/layer/layer.js"></script> 
</head>
<body>
    <!-- 为ECharts准备一个具备大小（宽高）的Dom -->
    <div>
        <div style="width: 50%; float: left;">
            <div id="main1" style="width: 100%; height: 400px;"></div>
            <div>
                <table id="myTb" style="width: 98%; border: 1px solid #ccc;"  class="W_form">
                    <thead>
                        <tr class="trth1">
                            <th>生成情况</th>
                            <th>数量</th>
                        </tr>
                    </thead>
                    <tbody id="tbody1"></tbody>
                </table>
            </div>
        </div>
        <div style="width: 50%; float: right;">
            <div id="main2" style="float: left; width: 100%; height: 400px;"></div>
            <div>
                <table id="myTb1" style="width: 98%; border: 1px solid #ccc;"  class="W_form">
                    <thead>
                        <tr class="trth1">
                            <th>实验类型</th>
                            <th>数量</th>
                        </tr>
                    </thead>
                    <tbody id="tbody2"></tbody>
                </table>
            </div>
        </div>
    </div>

    <script type="text/javascript">

        //--------------------订单生成情况统计------------------------
        // 基于准备好的dom，初始化echarts实例
        var myChart1 = echarts.init(document.getElementById('main1'));

        // 指定图表的配置项和数据
        option = {
            title: {
                text: '订单生成情况',
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
                data: ['已生成', '未生成']
            },
            series: [
                {
                    name: '订单生成情况',
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
        myChart1.setOption(option);
        var name = [];

        $.ajax({
            type: "post",
            async: false, //异步请求（同步请求将会锁住浏览器，用户其他操作必须等待请求完成才可以执行）
            url: WebServiceUrl + "/Statistical/Statistical.ashx",
            data: { action: "SelectCountPlan_Status" },//demo 没加条件
            dataType: "jsonp",
            jsonp: "jsoncallback",
            success: function (result) {

                for (var i = 0; i < result.result.length; i++) {
                    name.push(result.result[i].name);
                }
                myChart1.setOption({ //加载数据图表
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
                    $("#tbody1").append(tbBody);
                });


            },
            error: function (errorMsg) {
                alert("请求数据失败!");
            }
        });
   


        ///----------------实验类型统计----------------------
        // 基于准备好的dom，初始化echarts实例
        var myChart2 = echarts.init(document.getElementById('main2'));

        // 指定图表的配置项和数据
        option = {
            title: {
                text: '实验类型统计'
            },
            tooltip: {},
            legend: {
                data: ['姓名']
            },
            xAxis: {
                data: []
            },
            yAxis: {},
            series: [{
                name: '实验类型数量',
                type: 'bar',
                data: []
            }]
        };

        // 使用刚指定的配置项和数据显示图表。
        myChart2.setOption(option);


        myChart2.showLoading(); //数据加载完之前先显示一段简单的loading动画
        var names = []; //类别数组（实际用来盛放X轴坐标值）
        var nums = []; //销量数组（实际用来盛放Y坐标值）
        $.ajax({
            type: "get",
            async: true, //异步请求（同步请求将会锁住浏览器，用户其他操作必须等待请求完成才可以执行）
            url: WebServiceUrl + "/Statistical/Statistical.ashx", //请求发送到../Handler/DepartmentHandler处
            data: { action: "SelectCountPlan_Type" },
            dataType: "jsonp",
            jsonp: "jsoncallback",
            success: function (result) {
                //请求成功时执行该函数内容，result即为服务器返回的json对象
                if (result) {
                    for (var i = 0; i < result.result.length; i++) {
                        names.push(result.result[i].name); //挨个取出类别并填入类别数组
                    }
                    for (var i = 0; i < result.result.length; i++) {
                        nums.push(result.result[i].value); //挨个取出销量并填入销量数组
                    }
                    myChart2.hideLoading(); //隐藏加载动画
                    myChart2.setOption({ //加载数据图表
                        xAxis: { data: names },
                        series: [{ data: nums }]
                    });
                }
            },
            error: function (errorMsg) {
                //请求失败时执行该函数
                alert("图表请求数据失败!");
                myChart2.hideLoading();
            }
        })


        var name = [];
        $.ajax({
            type: "post",
            async: false, //异步请求（同步请求将会锁住浏览器，用户其他操作必须等待请求完成才可以执行）
            url: WebServiceUrl + "/Statistical/Statistical.ashx",
            data: { action: "SelectCountPlan_Type" },//demo 没加条件
            dataType: "jsonp",
            jsonp: "jsoncallback",
            success: function (result) {

                for (var i = 0; i < result.result.length; i++) {
                    name.push(result.result[i].name);
                }
                myChart2.setOption({ //加载数据图表
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
                    $("#tbody2").append(tbBody);
                });

            },
            error: function (errorMsg) {
                alert("请求数据失败!");
            }
        });

    </script>




</body>
</html>
