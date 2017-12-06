<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CountBG.aspx.cs" Inherits="EMS.Web.Statistical.CountBG" %>

<!DOCTYPE html>

<html>
<head>
    <meta charset="utf-8">
    <title>ECharts</title>
    <!-- 引入 echarts.js -->
    <script src="../js/echarts.js"></script>
    <script src="../js/jquery-1.11.2.min.js"></script>
    <script src="../js/Common.js"></script>
    <script src="../js/layer/layer.js"></script>
     <link href="../css/style.css" rel="stylesheet" />
</head>
<body>
    <!-- 为ECharts准备一个具备大小（宽高）的Dom -->
    <div id="main"  style="float:left; width: 40%; height: 400px;"></div>
      <div id="table" style="float:left; text-align:center;  width: 50%; height: 400px;border:1px" >
            <table id="myTb" style=" width:100%;margin-top:260px;border:1px solid #ccc;" class="W_form">
                <%--<tr><td></td><td>数量</td></tr>--%>
                <thead>
                    <tr class="trth1">
                        <th>设备来源</th>
                        <th>数量</th>
                       </tr>
                </thead>
                <tbody id="tbody"></tbody>
           </table>

        </div>


    <script type="text/javascript">
        // 基于准备好的dom，初始化echarts实例
        var myChart = echarts.init(document.getElementById('main'));

        // 指定图表的配置项和数据
        option = {
            title: {
                text: '办公家具缺失排行'
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
                name: '缺失量',
                type: 'bar',
                data: []
            }]
        };

        // 使用刚指定的配置项和数据显示图表。
        myChart.setOption(option);


        myChart.showLoading(); //数据加载完之前先显示一段简单的loading动画
        var names = []; //类别数组（实际用来盛放X轴坐标值）
        var nums = []; //销量数组（实际用来盛放Y坐标值）
        $.ajax({
            type: "get",
            async: true, //异步请求（同步请求将会锁住浏览器，用户其他操作必须等待请求完成才可以执行）
            url: WebServiceUrl + "/Statistical/Statistical.ashx", //请求发送到../Handler/DepartmentHandler处
            data: {action:"SelectCountBG"},
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
                    myChart.hideLoading(); //隐藏加载动画
                    myChart.setOption({ //加载数据图表
                        xAxis: { data: names },
                        series: [{ data: nums }]
                    });
                }
            },
            error: function (errorMsg) {
                //请求失败时执行该函数
                alert("图表请求数据失败!");
                myChart.hideLoading();
            }
        })


        var name = [];
        $.ajax({
            type: "post",
            async: false, //异步请求（同步请求将会锁住浏览器，用户其他操作必须等待请求完成才可以执行）
            url: WebServiceUrl + "/Statistical/Statistical.ashx",
            data: { action: "SelectCountBG" },//demo 没加条件
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
