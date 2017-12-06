<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Calendar.aspx.cs" Inherits="EMS.Web.Order.Calendar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <title></title>
    <style type="text/css">
        * {
            margin: 0;
            padding: 0;
            list-style-type: none;
        }

        a, img {
            border: 0;
        }

        body {
            font: 12px/180% Arial, Helvetica, sans-serif, "新宋体";
        }

        .container {
            /*width: 940px;
            margin: 0 auto;*/
        }
    </style>
    <link type="text/css" rel="stylesheet" href="../css/style.css" />
    <link type="text/css" rel="stylesheet" href="../css/common.css" />
    <link type="text/css" rel="stylesheet" href="../css/iconfont.css" />
    <link type="text/css" rel="stylesheet" href="../css/animate.css" />
    <link rel="stylesheet" href="/js/Calendar/css/style.css" />

    <!--必要样式-->
    <link rel="stylesheet" href="/js/Calendar/css/fullcalendar.css" />
    <link rel="stylesheet" href="/js/Calendar/css/fullcalendar.print.css" media='print' />
    <script src="../js/Common.js"></script>

</head>
<body>
    <form id="form1">
        <div>
            <div class="Teaching_plan_management">
                <h1 class="Page_name clearfix"><span class="fl">教学计划管理</span>  <a href="../Plan/PlanList.aspx" class="all_select fr"><span class="moren_wxz">列表视图</span><span class="visited_xz">日历视图</span></a></h1>

                <div class="container">
                    <div class="content">
                        <div class="row-fluid">
                            <div class="span12">

                                <div class="box">
                                    <div class="box-head">
                                        <h3>日历视图</h3>
                                       
                                    </div>
                                    <div class="box-content box-nomargin">
                                        <div class="calendar"></div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </form>

    <script type="text/javascript" src="/js/Calendar/js/jquery-1.7.2.min.js"></script>
    <script type="text/javascript" src="/js/Calendar/js/fullcalendar.min.js"></script>
    <script>

        $(document).ready(function () {
            getData("0");
        });


        function selChange() {
            var selVal = $('#sel option:selected').val();
            getData(selVal);
        }

        //获取数据
        function getData(isStatus) {
            $.ajax({
                url: WebServiceUrl + "/Experiment/Experiment.ashx",//random" + Math.random(),//方法所在页面和方法名
                async: false,
                dataType: "jsonp",
                jsonp: "jsoncallback",
                data: { "isStatus": isStatus, "action": "GetExperiment_Calendar" },
                success: OnSuccessGetData,
                error: OnErrorGetData
            });
        }
        function OnSuccessGetData(json) {
            if (json.toString() == null) {

            } else {
                var date = new Date();
                var d = date.getDate();
                var m = date.getMonth();
                var y = date.getFullYear();
                var e = eval(json.result);



                var ee = "[";
                e = e.sort(function (a, b) {
                    if (DateTimeConvert(a.StartDate) < DateTimeConvert(b.StartDate)) {
                        return -1;
                    } else if (DateTimeConvert(a.StartDate) > DateTimeConvert(b.StartDate)) {
                        return 1;
                    } else {
                        if (a.num < b.num) {
                            return -1;
                        } else if (a.num > b.num) {
                            return 1;
                        }
                        return 0;
                    }
                });

                var reDate = "";
                var lineDate = true;
                var number = 0;
                for (var i = 0; i < e.length ; i++) {
                    var newDate = DateTimeConvert(e[i].StartDate);
                    if (reDate == "") reDate = newDate;
                    if (newDate == reDate) {
                        number++;
                        if (!lineDate) {
                            continue;
                        }
                        if (ee != "[") {
                            ee += ",";
                        }
                        if (e[i].num >= 2) {
                            //ee += "{title: '更多...',start: " + e[i].start + ",url:'../Plan/PlanList.aspx?date=" + newDate + "'}";
                            lineDate = false;

                        } else if (e[i].num < 2) {
                            ee += "{title: '" + e[i].title + "',start: " + e[i].start + ",url: '../Experiment/ExperimentDetails.aspx?Id=" + e[i].Id + "&Name=" + e[i].planName + "'}";

                        }
                    } else {
                        if (!lineDate) {
                            var num = i - number - 1;
                            var planIds = "";
                            for (var j = num; j < i; j++) {
                                planIds += e[j].planId + ","
                            }
                            planIds = planIds.substring(0, planIds.length - 1);
                            ee += "{title: '更多...',start: " + e[i - 1].start + ",url:'../Plan/PlanList.aspx?planIds=" + planIds + "'}";
                        }
                        number = 0;
                        reDate = newDate;
                        if (ee != "[") {
                            ee += ",";
                        }
                        ee += "{title: '" + e[i].title + "',start: " + e[i].start + ",url: '../Experiment/ExperimentDetails.aspx?Id=" + e[i].Id + "&Name=" + e[i].planName + "'}";
                        lineDate = true;
                    }
                }
                ee += "]";
                var eee = eval('(' + ee + ')');
                if ($('.calendar').length > 0) {
                    $('.calendar').fullCalendar({
                        header: {
                            left: 'prev,next,today',
                            center: 'title',
                            right: 'month,basicWeek,basicDay'
                        },
                        buttonText: {
                            today: '跳转到当天'
                        },
                        editable: true,
                        weekMode: 'liquid',
                        events: eee
                    });
                }
            }
        }
        function OnErrorGetData(XMLHttpRequest, textStatus, errorThrown) {
            $("#tbList tbody").html('<tr><td colspan="100"  style="text-align:center;">无内容</td></tr>');
        }
    </script>

</body>
</html>
