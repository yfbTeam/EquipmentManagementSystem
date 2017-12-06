<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderList.aspx.cs" Inherits="EMS.Web.Order.OrderList" %>

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
    <script src="../js/layer/layer.js"></script>
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
        <td class="">${Name}</td>
        <td class="">${CName}</td>
        <td class="">${DateTimeConvert(StartDate)}</td>
        <%--<td class="">${LoanName}</td>--%>
        <td class="">${stuLoanName}</td>
<%--<a href="OrderDetails.aspx?orderid=${Id}"> --%>
        <td>
             <input type="button" class="Topic_btn" onclick="javascript: Escheat('${Id}', '${orderID}')" value="查看" />
<%--                <span class=" "> <input type="button"  class="Topic_btn"  value="查看" onclick="Showwindows('OrderDetails.aspx?orderid=${Id}')"  /> </span>--%>
<%--                <span class=" "> <input type="button"  class="Topic_btn"  value="测试" onclick="Showwindows('../Plan/PlanEdit.aspx?hidType=Add')"  /> </span>--%>
          <%--  <input type="button"  class="Topic_btn"  value="查看" onclick="alter()"  />--%>
            </td> 
    </tr>
</script>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="Teaching_plan_management">
                <h1 class="Page_name">订单管理</h1>
                <div class="Operation_area">
                    <div class="left_choice fl">
                        <ul>
                            <li class="Select">&nbsp&nbsp&nbsp&nbsp&nbsp
                                <%--订单状态：--%>
								<select id="sel" class="option">
                                    <option value="0">请选择订单状态</option>
                                    <option value="0">未借出</option>ption
                                    <option value="1">部分借出</option>
                                    <option value="2">已借出</option>
                                    <option value="3">部分归还</option>
                                    <option value="4">完成</option>
                                </select>
                            </li>
                            <li class="Sear">
                                <input type="text" name="search_w" class="search_w" placeholder="请输入订单编号" value="" />
                            </li>
                             <li class="Sear">
                                <input type="text" name="search_w" class="search_w" placeholder="请输入订单编号" value="" />
                            </li>
                             <li class="Sear">
                                <a class="sea" onclick="">搜索</a>
                            </li>
                        </ul>
                    </div>

                </div>
                <div class="Honor_management">
                    <table class="W_form" id="tbList" cellspacing="0">
                        <colgroup>
                            <col width="10%" />
                            <col width="25%" />
                            <col width="30%" />

                        </colgroup>
                        <thead>
                            <tr class="trth">
                                <%--<th class="checkbox"><input type="checkbox"></th>--%>
                                <th class="number">序号</th>
                                <th class="Project_name">实验名称</th>
                                <th class="">主讲教师</th>
                                <th class="">使用时间</th>
                                <th class=" ">学生组长</th>
                                <th>操作</th>
                            </tr>
                        </thead>
                        <tbody>
                        </tbody>
                    </table>

                </div>

                <!--分页页码开始-->
                <div class="paging">
            <span id="pageBar"></span>
        </div>
                <!--分页页码结束-->
            </div>

        </div>
    </form>
</body>


<script type="text/javascript">
    
    $(document).ready(function () {
        //获取数据
        getData(1);
        
    });
    
    //获取数据
    function getData(startIndex) {
        //初始化序号 
        pageNum = (startIndex - 1) * 10 + 1
        $.ajax({

            url: WebServiceUrl + "/Order/Order.ashx",//random" + Math.random(),//方法所在页面和方法名
            async: false,
            dataType: "jsonp",
            jsonp: "jsoncallback",
            data: { "startIndex": startIndex, "pageSize": 10, "action": "GetDatePageNEW" },
            success: OnSuccess,
            error: OnError
        });

    }

    function OnSuccess(json) {
        if (json.result == null) {
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
            makePageBar(getData, document.getElementById("pageBar"), json.result.Data.PageIndex, json.result.Data.PageCount, 8, json.result.Data.RowCount);

        }
    }
    function OnError(XMLHttpRequest, textStatus, errorThrown) {
        $("#tbList tbody").html('<tr><td colspan="100"  style="text-align:center;">无内容</td></tr>');

    }

    function Delete(id) {
        $.ajax({
            url: WebServiceUrl + "/Order/Order.ashx",//random" + Math.random(),//方法所在页面和方法名
            //async: false,
            dataType: "jsonp",
            jsonp: "jsoncallback",
            data: { "intID": id, "action": "DeteleOrder" },
            success: OnSuccessUpdate,
            //error: OnError
        });
        function OnSuccessUpdate(json) {
            alert(json.result);
        }

    }
    function Showwindows(url) {
        layer.open({
            type: 2,
            title: '订单详情',
            shadeClose: false,
            shade: 0.3,
            area: ['830px', '377px'],
            content: url //iframe的url
        });
    }

    function Escheat(id, orderNo) {

        location.href = "Escheat.aspx?id=" + id + "&orderNo=" + orderNo;
    }
</script>

</html>
