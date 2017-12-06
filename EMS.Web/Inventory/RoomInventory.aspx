<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RoomInventory.aspx.cs" Inherits="EMS.Web.Inventory.RoomInventory" %>

<!DOCTYPE html>
<%--  --%>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>房间盘点</title>
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
        <tr id="${Id}">
            <td>${pageIndex()}</td>
            <td>${AssetName}</td>
            <td>${Barcode}</td>
            <td style="display:none;">${ImageName}</td>
            <td>
                <img src="${IsLoss==false?'/images/cha.png':'/images/dui.png'}" class="state_img" isloss="${IsLoss}" onclick="imgStateClick(this)" /></td>
        </tr>
    </script>
    <style type="text/css">
        .state_img{
            width:20px;
            height:20px;
        }
    </style>
</head>
<body onload="this.focus();">
    <input type="hidden" id="hid_Id" runat="server" />
    <input type="hidden" id="hid_Invenid" runat="server" />
    <input type="hidden" id="hid_PPid" runat="server" />
    <input type="hidden" id="hid_UserIDCard" runat="server" />
    <!--tz_dialog start-->
    <div class="yy_dialog">
        <div class="t_content">
            <div class="yy_tab">
                <div class="content">
                    <div class="tc">
                        <div class="Operation_area">
                            <div style="text-align: left; height: 22px;">当前房间：<span id="span_name" name="span_name" runat="server"></span></div>
                            <div class="left_choice fl">
                                <ul>
                                    <li class="Sear"></li>
                                </ul>
                            </div>
                        </div>
                        <div class="Honor_management">
                            <table class="W_form" id="tb_InsEquipList" style="background: white;">
                                <thead>
                                    <tr class="trth">
                                        <th class="number" style="display: none;">id</th>
                                        <th class="number">序号</th>
                                        <th class="Project_name">资产名称</th>
                                        <th class="">条码</th>
                                        <th style="display:none;">缩略图</th>
                                        <th class="">是否扫描</th>
                                    </tr>
                                </thead>
                                <tbody></tbody>
                            </table>
                        </div>
                        <div class="submit_btn">
                            <span class="Save_and_submit">
                                <input type="submit" id="Btn_Sure" name="Btn_Sure" runat="server" value="确定" class="Save_and_submit" onclick="SaveRoomInventory();" /></span>
                            <%-- <span class="cancel">
                                <input type="submit" value="取消" class="cancel" onclick="javascript: parent.CloseIFrameWindow();" /></span>--%>
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
    var num = "";
    $(document).ready(function () {
        //获取数据        
        GetRoomEquip();
        document.onkeydown = function (event) {
            var e = event || window.event || arguments.callee.caller.arguments[0];
            switch (event.which) {
                case 49:
                    num += "1";
                    break;
                case 50:
                    num += "2";
                    break;
                case 51:
                    num += "3";
                    break;
                case 52:
                    num += "4";
                    break;
                case 53:
                    num += "5";
                    break;
                case 54:
                    num += "6";
                    break;
                case 55:
                    num += "7";
                    break;
                case 56:
                    num += "8";
                    break;
                case 57:
                    num += "9";
                    break;
                case 48:
                    num += "0";
                    break;
                default:
            }
            if (e && e.keyCode == 13) { // enter 键
                //禁用回车刷新
                e.preventDefault();
                //获取数据
                // alert(num);
                if (num.length > 3) {
                    HandleRoomEquip(num);
                }
                //清空 纪录
                num = "";
            }
        };
    });
    function HandleRoomEquip(barcode) {
        var isExist = false;
        var leg = $("#tb_InsEquipList tr").length - 1;  //$("#tb_InsEquipList tr").length是获取table的行数
        $("#tb_InsEquipList tr:gt(0):lt(" + leg + ")").each(function () {  //gt（0）代表是大于第一行，从第二行起;  lt（10）代表小于；
            if ($(this).children("td").eq(2)[0].innerHTML == barcode) {
                isExist = true;
                $(this).children("td").eq(4)[0].innerHTML = "<img src=\"/images/dui.png\" class=\"state_img\" isLoss=\"true\" onclick=\"imgStateClick(this)\" />";
                return;
            }
        });
        if (!isExist) {
            $.ajax({
                url: WebServiceUrl + "/Inventory/Inventory.ashx",//random" + Math.random(),//方法所在页面和方法名
                type: "post",
                async: false,
                dataType: "jsonp",
                jsonp: "jsoncallback",
                data: { invenid: $("#<%=hid_Invenid.ClientID%>").val(), barcode: barcode, action: "GetInvenModelByBarcode" },
                success: function (json) {
                    var model = json.result;
                    if (model != null && model.toString() != "") {
                        AddInsEquipTR(model);
                    }
                },
            });
        }
    }
    function AddInsEquipTR(model) {
        var strTR = "";
        strTR += "<tr id='edit_" + model.Id + "'> ";
        strTR += "<td >" + pageIndex() + "</td>";
        strTR += "<td >" + model.AssetName + "</td>";
        strTR += "<td >" + model.Barcode + "</td>";
        strTR += "<td style='display:none;'>" + (model.ImageName == null ? " " : model.ImageName) + "</td>";
        strTR += "<td ><img src=\"/images/dui.png\" class=\"state_img\" isLoss=\"true\" onclick=\"imgStateClick(this)\" /></td>";
        if ($("#tb_InsEquipList tbody").html() == "<tr><td colspan="100"  style="text-align:center;">无内容</td></tr>") {
            $("#tb_InsEquipList tbody").html(strTR);
        } else {
            $("#tb_InsEquipList").append(strTR);
        }
    }
    //获取数据
    function GetRoomEquip() {
        $.ajax({
            url: WebServiceUrl + "/Inventory/Inventory.ashx",//random" + Math.random(),//方法所在页面和方法名
            type: "post",
            async: false,
            dataType: "jsonp",
            jsonp: "jsoncallback",
            data: { invenid: $("#<%=hid_Invenid.ClientID%>").val(), roomid: $("#<%=hid_Id.ClientID%>").val(), action: "GetEquipByInvenRoomId" },
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
        }
    }
    function OnError(XMLHttpRequest, textStatus, errorThrown) {
        $("#tb_InsEquipList tbody").html('<tr><td colspan="100"  style="text-align:center;">无内容</td></tr>');
    }

    //保存房间仪器设备盘点信息
    function SaveRoomInventory() {
        layer.msg("确定房间内已经扫描完了么，确定后将不能修改？", {
            time: 0 //不自动关闭
           , btn: ['确定', '取消']
           , yes: function (index) {
               layer.close(index);
               var idArray = [], editArray = [];
               var leg = $("#tb_InsEquipList tr").length - 1;
               //if (leg == 0) {
               //    return;
               //}
               $("#tb_InsEquipList tr:gt(0):lt(" + leg + ")").each(function () {
                   if ($($(this).children("td").eq(4).children("img")[0]).attr("isLoss") == "true") {
                       if (this.id.indexOf('edit_') > -1) {
                           editArray.push(this.id.replace('edit_', ''));
                       } else {
                           idArray.push(this.id);
                       }
                   }
               });
               $.ajax({
                   url: WebServiceUrl + "/Inventory/Inventory.ashx",//random" + Math.random(),//方法所在页面和方法名
                   type: "post",
                   async: false,
                   dataType: "jsonp",
                   jsonp: "jsoncallback",
                   data: {
                       invenid: $("#<%=hid_Invenid.ClientID%>").val(),
                       roomid: $("#<%=hid_Id.ClientID%>").val(),
                       idStr: idArray.join(","),
                       editStr: editArray.join(","),
                       useridcard: $("#hid_UserIDCard").val(),
                       action: "SaveRoomInventory"
                   },
                   success: function (json) {
                       if (json.result.Status == "ok") {
                           parent.layer.msg(json.result.Msg);
                           parent.GetLayersAndRoomsByInvenId($("#<%=hid_PPid.ClientID%>").val());
                    parent.CloseIFrameWindow();
                } else {
                    layer.msg(json.result.Msg);
                }
            },
                   error: function (XMLHttpRequest, textStatus, errorThrown) {
                       layer.msg("操作失败！");
                   }
               });
           }
        });
}
function imgStateClick(obj) {
    var isloss = $(obj).attr("isLoss");
    isloss = isloss == "false" ? "true" : "false";
    $(obj).attr("isLoss", isloss);
    $(obj).attr('src', isloss == "false" ? "/images/cha.png" : "/images/dui.png");
}
</script>
</html>


