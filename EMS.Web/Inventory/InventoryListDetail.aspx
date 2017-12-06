<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InventoryListDetail.aspx.cs" Inherits="EMS.Web.Inventory.InventoryListDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>盘点详情</title>
    <link href="/css/style.css" rel="stylesheet" />
    <link href="/css/common.css" rel="stylesheet" />
    <link href="/css/iconfont.css" rel="stylesheet" />
    <link href="/css/animate.css" rel="stylesheet" />
    <script src="/js/jquery-1.11.2.min.js"></script>
    <script src="/js/layer/layer.js"></script>
    <script src="/js/Common.js"></script>
    <script src="/js/jquery.tmpl.js"></script>
    <script src="/js/PageBar.js"></script>
    <script id="tr_User" type="text/x-jquery-tmpl">
        <tr>
            <td>${pageIndex()}</td>
            <td>${AssetNumber}</td>
            <td>${AssetName}</td>
            <td>${EquipStatusChange(Status)}</td>
            <td>{{if loss == 0}}<span style="color:red;">缺失</span>{{else}}<span>未缺失</span>{{/if}}</td>
        </tr>
    </script>
</head>
<body>
    <input type="hidden" id="hid_Id" runat="server" />
    <input type="hidden" id="hid_Invenid" runat="server" />
    <input type="hidden" id="hid_UserIDCard" runat="server" />
    <!--tz_dialog start-->
    <div class="yy_dialog">        
        <div class="t_content">
            <div class="yy_tab">
                <div class="content">
                    <div class="tc">
                        <div class="Operation_area">
                            <%--<div style="text-align: left; height: 22px;">当前库房：<span id="span_name" name="span_name" runat="server"></span></div>--%>
                            <div class="left_choice fl">
                                <ul>
                                    <li class="Sear">
                                        <%--库房：<select id="sel_warehouse" class="option">
                                        <option value=''>全部</option>
                                    </select>
                                        <input type="text" id="sea_name" name="sea_name" class="search_w" placeholder="请输入仪器名称" value="" />
                                        <input type="text" id="sea_model" name="sea_model" class="search_w" placeholder="请输入仪器型号" value="" />
                                        <a class="sea" href="#" onclick="GetNotInsEquipByWareId(1);">搜索</a>--%>
                                    </li>
                                </ul>
                            </div>
                        </div>
                        <div class="Honor_management">
                            <table class="W_form" id="tb_UserList" style="background:white;">
                                <thead>
                                    <tr class="trth">
                                        <th class="number">序号</th>
                                        <th class="Project_name">仪器资产号</th>
                                        <th class="">仪器名称</th>
                                        <th class="">状态</th>
                                        <th>是否缺失</th>
                                    </tr>
                                </thead>
                                <tbody></tbody>
                            </table>
                        </div>
                        <!--分页页码开始-->
                        <div class="paging">
                            <span id="pageBar"></span>
                        </div>
                        <!--分页页码结束-->
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!--end tz_dialog-->

    <!--tz_yy start-->
    <div class="tz_yy"></div>
    <!--end tz_yy-->
</body>
<script type="text/javascript">
    $(document).ready(function () {
        //获取数据
        getData(1);
    });
    //获取盘点数据
    function getData(PageIndex) {
        //初始化序号 
        pageNum = (PageIndex - 1) * 10 + 1;
        $.ajax({
            type: "post",
            url: WebServiceUrl + "/Inventory/Inventory.ashx",//random" + Math.random(),//方法所在页面和方法名
            async: false,
            dataType: "jsonp",
            jsonp: "jsoncallback",
            data: {
                PageIndex: PageIndex, PageSize: 10,
                PlanId: $("#<%=hid_Invenid.ClientID%>").val(),
                RoomId: $("#<%=hid_Id.ClientID%>").val(),
                useridcard: $("#hid_UserIDCard").val(),
                action: "GetDataPageByInvenRoomId"
            },
            success: function LoadData(json) {
                if (json.result.Status == "error") {
                    $("#tb_UserList tbody").html('<tr><td colspan="100"  style="text-align:center;">无内容</td></tr>');
                    return;
                }
                if (json.result.Status == "no") {
                    $("#tb_UserList tbody").html('<tr><td colspan="100"  style="text-align:center;">无内容</td></tr>');
                    //生成页码条方法（方法对象,页码条容器，当前页码，总页数，页码组容量，总行数）
                    makePageBar(getData, document.getElementById("pageBar"), 1, 1, 8, 0);
                    return;
                }
                if (json.result.Status == "ok") {
                    $("#tb_UserList tbody").html('');
                    var dtJson = $.parseJSON(json.result.Data.PagedData);
                    $("#tr_User").tmpl(dtJson.ds).appendTo("#tb_UserList");
                    //隔行变色以及鼠标移动高亮
                    $(".main-bd table tbody tr").mouseover(function () {
                        $(this).addClass("over");
                    }).mouseout(function () {
                        $(this).removeClass("over");
                    })
                    $(".main-bd table tbody tr:odd").addClass("alt");
                    //生成页码条方法（方法对象,页码条容器，当前页码，总页数，页码组容量，总行数）
                    makePageBar(getData, document.getElementById("pageBar"), json.result.Data.PageIndex, json.result.Data.PageCount, 8, json.result.Data.RowCount);
                }
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                $("#tb_UserList tbody").html('<tr><td colspan="100"  style="text-align:center;">无内容</td></tr>');
            }
        });
    }
</script>
</html>


