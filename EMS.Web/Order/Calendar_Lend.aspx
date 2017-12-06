<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Calendar_Lend.aspx.cs" Inherits="EMS.Web.Order.Calendar_Lend" %>

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
                <h1 class="Page_name clearfix"><span class="fl">借还管理</span>  <a href="BorrowAndAlso.aspx" class="all_select fr"><span class="moren_wxz">列表视图</span><span class="visited_xz">日历视图</span></a></h1>

                <div class="container">
                    <div class="content">
                        <div class="row-fluid">
                            <div class="span12">

                                <div class="box">
                                    <div class="box-head">
                                        <h3>日历视图</h3>
                                        &nbsp &nbsp 
                                        <select id="sel" onchange="selChange()" style="color:#666">
                                            <option value="0">未借出</option>
                                            <option value="2">已借出</option>
                                            <option value="4">完成</option>
                                        </select>
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
                type:"post",
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
               
                for (var i = 0; i < e.length ; i++) {

                    switch (e[i].isStatus) {
                        case 0:
                            strUrl = "NewOrder.aspx?id=" + e[i].Id + "&orderNo=" + e[i].orderid + "&IDCard= 520113198103275935 &stuIDCard=";
                            break;
                        case 2:
                            strUrl = "Escheat.aspx?id=" + e[i].Id + "&orderNo=" + e[i].orderid;
                            break;
                        case 4:
                            strUrl = "";
                            break;
                        default:
                            break;
                    }
                    if (ee != "[") {
                        ee += ",";
                    }

                    if (e[i].num == 3) {
                        ee += "{title: '更多...',start: " + e[i].start + "}";
                    } else {
                        ee += "{title: '" + e[i].title + "',start: " + e[i].start + ",url: '" + strUrl + "'}";
                    }
                }
                ee += "]";
                var eee = eval('(' + ee + ')');
                $('.calendar').html('');
                if ($('.calendar').length > 0) {
                    $('.calendar').fullCalendar({
                        header: {
                            left: 'prev,next,today',
                            center: 'title',
                            right: 'month,agendaWeek,agendaDay'
                        },
                        buttonText: {
                            today: '跳转到当天'
                        },
                        editable: true,
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
