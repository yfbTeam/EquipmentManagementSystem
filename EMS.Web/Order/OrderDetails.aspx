<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderDetails.aspx.cs" Inherits="EMS.Web.Order.OrderDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link type="text/css" rel="stylesheet" href="../css/style.css" />
    <link type="text/css" rel="stylesheet" href="../css/common.css" />
    <link type="text/css" rel="stylesheet" href="../css/iconfont.css" />
    <link type="text/css" rel="stylesheet" href="../css/animate.css" />
    <script type="text/javascript" src="../js/jquery-1.11.2.min.js"></script>
    <script type="text/javascript" src="../js/tz_slider.js"></script>
    <script src="../js/Common.js"></script>

    <script src="../js/jquery.tmpl.js"></script>
    <script src="../js/PageBar.js"></script>
</head>
<script>
    //根据Status字段转换
    function GetStatus(Status) {
        var strStatus = "";
        switch (Status) {
            case 0:
                strStatus = "未借出";
                break
            case 1:
                strStatus = "部分借出";
                break
            case 2:
                strStatus = "已借出";
                break
            case 3:
                strStatus = "部分归还";
                break
            case 4:
                strStatus = "完成";
                break
            default:

        }
        return strStatus;
    }

</script>

<script id="trTemp" type="text/x-jquery-tmpl">
    <tr>
        <td class="">${pageIndex()}</td>
        <td class="">${EQNUM}</td>
        <td class="">${EQNAME}</td>
        <td class="">${EQUNIT}</td>
        <td class="">${Count}</td>
        <td class="">${CountL}</td>
        <td class="">${CountE}</td>
    </tr>

</script>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="Teaching_plan_management">
<%--                <h1 class="Page_name">订单详情</h1>--%>
                <div class="Form_details">
                    <div class="Order_details">
                        <ul class="formcon">
                            <li class="Select" >
                                <span>订单编号：</span><span id="orderNO"></span>
                            </li>
                            <li class="Select" >
                               <span> 借用人：</span><span id="LoanName"></span>
                            </li>
                            <li class="Select" >
                                <span>订单类型：</span><span id="Type"></span>
                            </li>
                            <li class="Select" >
                                <span>创建时间：</span><span id="CreateTime"></span>
                            </li>
                            <li class="Select" >
                                <span>订单状态：</span><span id="Status"></span>
                            </li>
                        </u>
                    </div>

                </div>
                <br />
                <div class="Honor_management">
                    <table class="W_form" id="tbList" cellspacing="0">
                        <colgroup>
                            <col width="10%" />
                            <col width="25%" />
                            <col width="30%" />

                        </colgroup>
                        <thead>
                            <tr class="trth">
                                <th class="number">序号</th>
                                <th class="Project_name">仪器编号</th>
                                <th class="">仪器名称</th>
                                <th class="">单位</th>
                                <th class=" ">计划借出数量</th>
                                <th class=" ">借出数量</th>
                                <th class=" ">归还数量</th>
                            </tr>
                        </thead>
                        <tbody>
                        </tbody>
                    </table>

                </div>

                <!--分页页码开始-->
                <div class="dataTables_info" id="dataTable1_info"></div>
                <div class="dataTables_paginate paging_bs_normal" id="datatable_paginate">
                    <ul class="pagination pagination-sm" id="pageBar">
                    </ul>
                </div>
                <!--分页页码结束-->
            </div>

        </div>
    </form>
</body>


<script type="text/javascript">

    function GetUrlDate() {
        var name, value;
        var str = location.href; //取得整个地址栏
        var num = str.indexOf("?")
        str = str.substr(num + 1); //取得所有参数   stringvar.substr(start [, length ]

        var arr = str.split("&"); //各个参数放到数组里
        for (var i = 0; i < arr.length; i++) {
            num = arr[i].indexOf("=");
            if (num > 0) {
                name = arr[i].substring(0, num);
                value = arr[i].substr(num + 1);
                this[name] = value;
            }
        }
    }
    var UrlDate = new GetUrlDate(); //实例化
    $(document).ready(function () {
        
        getDataByID(UrlDate.orderid);
        
    });
    //获取订单详细数据
    function getDataByID(orderID) {
        $.ajax({
            url: WebServiceUrl + "/Order/Order.ashx",//random" + Math.random(),//方法所在页面和方法名
            async: false,
            dataType: "jsonp",
            jsonp: "jsoncallback",
            data: { "OrderID": orderID, "action": "GetDateByID" },
            success: getDataByIDOnSuccess,
            error:getDataByIDOnError
        });

    }
    function getDataByIDOnSuccess(json) {
        if (json.result == "no") {
            $("#tbList tbody").html('<tr><td colspan="100"  style="text-align:center;">无内容</td></tr>');
        } else {
            $("#orderNO").html(json.result.OrderNo);
            $("#LoanName").html( json.result.LoanName);
            $("#Type").html(json.result.Type == 1 ? "外借订单" : "教学计划订单");
            $("#CreateTime").html(  DateTimeConvert(json.result.CreateTime));
            $("#Status").html(GetStatus(json.result.Status));
            getData(1, json.result.OrderNo, 3);
        }
    }
    function getDataByIDOnError(XMLHttpRequest, textStatus, errorThrown) {
        $("#tbList tbody").html('<tr><td colspan="100"  style="text-align:center;">无内容</td></tr>');
    }

    //获取借还数量数据
    function getData(startIndex, orderNo, Type) {

        $.ajax({
            url: WebServiceUrl + "/Order/Order.ashx",//random" + Math.random(),//方法所在页面和方法名
            async: false,
            dataType: "jsonp",
            jsonp: "jsoncallback",
            data: { "startIndex": startIndex, "orderNo": orderNo, "Type": Type, "action": "GetDateL" },
            success: OnSuccess,
            error: OnError
        });

    }
    function OnSuccess(json) {

        if (json.result == "no") {
            $("#tbList tbody").html('<tr><td colspan="100"  style="text-align:center;">无内容</td></tr>');
        } else {
            $("#tbList tbody").html('');
            $("#trTemp").tmpl(json.result.Data.PagedData).appendTo("#tbList");
            //隔行变色以及鼠标移动高亮
            $(".main-bd table tbody tr").mouseover(function () {
                $(this).addClass("over");
            }).mouseout(function () {
                $(this).removeClass("over");
            })
            $(".main-bd table tbody tr:odd").addClass("alt");
            //生成页码条方法（方法对象,页码条容器，当前页码，总页数，页码组容量，总行数）
            //makePageBar(getData, document.getElementById("pageBar"), json.result.Data.PageIndex, json.result.Data.PageCount, 8, json.result.Data.RowCount, document.getElementById("dataTable1_info"));
        }
    }
    function OnError(XMLHttpRequest, textStatus, errorThrown) {
        $("#tbList tbody").html('<tr><td colspan="100"  style="text-align:center;">无内容</td></tr>');

    }
</script>

</html>
