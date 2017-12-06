<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EquipClassSettings.aspx.cs" Inherits="EMS.Web.SystemSettings.EquipClassSettings" %>

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
            <td>
                <input type="checkbox" name="cb_sub" /></td>
            <td style="display: none;">${Id}</td>
            <td>${pageIndex()}</td>
            <td>${Name}</td>
            <td>${Model}</td>
            <td>${Type==0?"非耗材":"耗材"}</td>
            <td>${WarehouseName}</td>
            <td>${DateTimeConvert(CreateTime)}</td>
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
                            <div style="text-align: left; height: 22px;">当前库房：<span id="span_name" name="span_name" runat="server"></span></div>
                            <div class="left_choice fl">
                                <ul>
                                    <li class="Sear">库房：<select id="sel_warehouse" class="option">
                                        <option value=''>全部</option>
                                    </select>
                                        <input type="text" id="sea_name" name="sea_name" class="search_w" placeholder="请输入仪器名称" value="" />
                                        <input type="text" id="sea_model" name="sea_model" class="search_w" placeholder="请输入仪器型号" value="" />
                                        <a class="sea" href="#" onclick="GetNotInsEquipByWareId(1);">搜索</a>
                                    </li>
                                </ul>
                            </div>
                        </div>
                        <div class="Honor_management">
                            <table class="W_form" id="tb_InsEquipList" style="background:white;">
                                <thead>
                                    <tr class="trth">
                                        <th class="cbox">
                                            <input type="checkbox" id="cb_all" name="cb_all" onclick="CheckAll(this);" /></th>
                                        <th class="number" style="display: none;">id</th>
                                        <th class="number">序号</th>
                                        <th class="Project_name">仪器名称</th>
                                        <th class="">仪器型号</th>
                                        <th class="">类型</th>
                                        <th class="">库房</th>
                                        <th class="">创建时间</th>
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
                        <div class="submit_btn">
                            <span class="Save_and_submit">
                                <input type="submit" value="确定" class="Save_and_submit" onclick="SaveInsEquipSetting();" /></span>
                            <span class="cancel">
                                <input type="submit" value="取消" class="cancel" onclick="javascript: parent.CloseIFrameWindow();" /></span>
                        </div>
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
        BindWarehouse();
        //获取数据        
        GetNotInsEquipByWareId(1);
    });
    //全选或全不选
    function CheckAll(obj) {
        var flag = obj.checked;//判断全选按钮的状态 
        $("input[type=checkbox][name=cb_sub]").each(function () {//查找每一个name为cb_sub的checkbox 
            this.checked = flag;//选中或者取消选中 
        });
    }
    //获取数据
    function GetNotInsEquipByWareId(startIndex) {
        //初始化序号 
        pageNum = (startIndex - 1) * 10 + 1;
        var curwareid = $("#<%=hid_Id.ClientID%>").val();
        var name = $("#sea_name").val();
        var model = $("#sea_model").val();
        var selwareid = $("#sel_warehouse").val();
        $.ajax({
            url: WebServiceUrl + "/SystemSettings/Warehouse.ashx",//random" + Math.random(),//方法所在页面和方法名
            type: "post",
            async: false,
            dataType: "jsonp",
            jsonp: "jsoncallback",
            data: { curwareid: curwareid, name: name, model: model, selwareid: selwareid, startIndex: startIndex, pageSize: 10, action: "GetNotInsEquipByWareId" },
            success: OnSuccess,
            error: OnError
        });

    }
    function OnSuccess(json) {
        if (json.result.Status.toString() == "no") {
            $("#tb_InsEquipList tbody").html('<tr><td colspan="100"  style="text-align:center;">无内容</td></tr>');
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
            makePageBar(GetNotInsEquipByWareId, document.getElementById("pageBar"), json.result.Data.PageIndex, json.result.Data.PageCount, 8, json.result.Data.RowCount);
        }
    }
    function OnError(XMLHttpRequest, textStatus, errorThrown) {
        $("#tb_InsEquipList tbody").html('<tr><td colspan="100"  style="text-align:center;">无内容</td></tr>');
    }

    //保存仪器设备分类设置
    function SaveInsEquipSetting() {
        var idArray = [];
        var leg = $("#tb_InsEquipList tr").length - 1;  //$("#tb_InsEquipList tr").length是获取table的行数
        $("#tb_InsEquipList tr:gt(0):lt(" + leg + ")").each(function () {  //gt（0）代表是大于第一行，从第二行起;  lt（10）代表小于；
            if ($(this).children("td").eq(0).children("input")[0].checked) {
                temp = $(this).children("td").eq(1)[0].innerHTML; //获取仪器设备分类id
                if (temp.length > 0) {
                    idArray.push(temp);
                }
            }
        });
        if (!idArray.length) {
            layer.msg("请选择要设置的仪器设备!");
            return false;
        }
        var itemid = $("#<%=hid_Id.ClientID%>").val();
        $.ajax({
            url: WebServiceUrl + "/SystemSettings/Warehouse.ashx",//random" + Math.random(),//方法所在页面和方法名
            type: "post",
            async: false,
            dataType: "jsonp",
            jsonp: "jsoncallback",
            data: {
                itemid: itemid,
                idsStr: idArray.join(","),
                useridcard: $("#hid_UserIDCard").val(),
                action: "SetInstrumentEquip"
            },
            success: OnSaveSuccess,
            error: OnSaveError
        });
    }
    function OnSaveSuccess(json) {
        if (json.result.Status == "ok") {
            parent.layer.msg(json.result.Msg);
            parent.CloseIFrameWindow();           
        } else {
            layer.msg(json.result.Msg);
        }
    }
    function OnSaveError(XMLHttpRequest, textStatus, errorThrown) {
        layer.msg("操作失败！");
    }
    //绑定库房
    function BindWarehouse() {
        $.ajax({
            url: WebServiceUrl + "/SystemSettings/Warehouse.ashx",//random" + Math.random(),//方法所在页面和方法名
            type: "post",
            async: false,
            dataType: "jsonp",
            jsonp: "jsoncallback",
            data: { startIndex: 1, pageSize: 1000, action: "GetDataPage" },
            success: function (json) {
                $("#sel_warehouse").empty();
                $("#sel_warehouse").append("<option value=''>全部</option>");
                if (json.result.Status.toString() == "error") {
                    layer.msg(json.result.Msg);
                    return;
                }
                if (json.result.Status.toString() == "no") {
                    return;
                }
                $.each(json.result.Data.PagedData, function (i, item) {
                    if (item.Id != $("#<%=hid_Id.ClientID%>").val()) {
                        var option = "<option value='" + item.Id + "'>" + item.Name + "</option>"
                        $("#sel_warehouse").append(option);
                    }
                });
            },
            error: function () { }
        });
        }
</script>
</html>


