<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConsumeHistory.aspx.cs" Inherits="EMS.Web.SystemSettings.ConsumeHistory" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>分类设置</title>
    <link href="/css/style.css" rel="stylesheet" />
    <link href="/css/common.css" rel="stylesheet" />
    <link href="/css/iconfont.css" rel="stylesheet" />
    <link href="/css/animate.css" rel="stylesheet" />
    <script src="/js/jquery-1.11.2.min.js"></script>
    <script src="/js/layer/layer.js"></script>
    <script src="/js/Common.js"></script>
    <script src="/js/jquery.tmpl.js"></script>
    <script src="/js/PageBar.js"></script>
    <script id="tr_InsEquip" type="text/x-jquery-tmpl">
        <tr>
            <td>${pageIndex()}</td>
            <td>${CreateName}</td>
            <td>${Count}</td>
            <td>${Type}</td>
            <td>${DateTimeConvert(LendTime)}</td>
            <td>${Remarks}</td>
        </tr>
    </script>
</head>
<body>
    <input type="hidden" id="hid_Id" runat="server" />
    <input type="hidden" id="hid_UserIDCard" runat="server" />
    <!--tz_dialog start-->
    <div class="yy_dialog">
        <div class="t_content">
            <div class="yy_tab">
                <div class="content">
                    <div class="tc">
                        <div class="Operation_area">
                            <div class="left_choice fl">
                                <ul>
                                    <li class="Sear">
                                        <input type="text" id="sea_name" name="sea_name" class="search_w" placeholder="请输入姓名" value="" />
                                        <a class="sea" href="#" onclick="SearchConsume();" style="margin-left:10px;">搜索</a>
                                    </li>
                                </ul>
                            </div>
                            <div class="right_add fr">
                                <div style="text-align: left; height: 22px;">耗材名称：<span id="sp_AssetName"></span></div>
                                <div style="text-align: left; height: 22px;">计量单位：<span id="sp_Unit" style="margin-right: 30px;"></span>现有库存：<span id="sp_Count"></span></div>
                            </div>
                        </div>
                        <div class="Honor_management">
                            <table class="W_form" id="tb_InsEquipList" style="background: white;">
                                <thead>
                                    <tr class="trth">
                                        <th class="number">序号</th>
                                        <th class="Project_name">姓名</th>
                                        <th class="">耗材数量</th>
                                        <th class="">类型</th>
                                        <th class="">日期</th>
                                        <th class="">备注</th>
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
</body>
<script type="text/javascript">
    var sername = $("#sea_name").val().trim();
    $(document).ready(function () {
        //获取数据        
        getData(1);
        var itemid = $("#<%=hid_Id.ClientID%>").val();
        if (itemid.length) {
            //为控件绑定数据
            BindDataById(itemid);
        }
    });
    function SearchConsume() {
        sername = $("#sea_name").val().trim();
        getData(1);
    }
    //获取数据
    function getData(startIndex) {
        //初始化序号 
        pageNum = (startIndex - 1) * 10 + 1;
        var equipid = $("#<%=hid_Id.ClientID%>").val();
        $.ajax({
            url: WebServiceUrl + "/SystemSettings/Consume.ashx",//random" + Math.random(),//方法所在页面和方法名
            type: "post",
            async: false,
            dataType: "jsonp",
            jsonp: "jsoncallback",
            data: { EquipId: equipid, Name: sername, PageIndex: startIndex, PageSize: 10, action: "GetJsonModelByEquipId" },
            success: OnSuccess,
            error: OnError
        });
    }
    function OnSuccess(json) {
        if (json.result.Status.toString() == "no") {
            $("#tb_InsEquipList tbody").html('<tr><td colspan="100" style="text-align:center;">无内容</td></tr>');
        } else {
            $("#tb_InsEquipList tbody").html('');
            $("#tr_InsEquip").tmpl(json.result.Data.PagedData).appendTo("#tb_InsEquipList");
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
    }
    function OnError(XMLHttpRequest, textStatus, errorThrown) {
        $("#tb_InsEquipList tbody").html('<tr><td colspan="100" style="text-align:center;">无内容</td></tr>');
    }
    function BindDataById(itemid) {
        $.ajax({
            url: WebServiceUrl + "/SystemSettings/Consume.ashx",//random" + Math.random(),//方法所在页面和方法名
            type: "post",
            async: false,
            dataType: "jsonp",
            jsonp: "jsoncallback",
            data: { itemid: itemid, action: "GetModelById" },
            success: function (json) {
                var model = json.result;
                if (model.toString() != "") {
                    $("#sp_AssetName").html(model.AssetName);
                    $("#sp_Unit").html(model.Unit);
                    $("#sp_Count").html(model.Count);
                }
            },
            //error: OnBindError
        });
    }
</script>
</html>


