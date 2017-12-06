<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InventoryPlanEdit.aspx.cs" Inherits="EMS.Web.Inventory.InventoryPlanEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>新增盘点计划</title>
    <link href="/css/style.css" rel="stylesheet" />
    <link href="/css/common.css" rel="stylesheet" />
    <link href="/css/iconfont.css" rel="stylesheet" />
    <link href="/css/animate.css" rel="stylesheet" />
    <script src="/js/jquery-1.11.2.min.js"></script>
    <script src="/js/layer/layer.js"></script>
    <script src="/js/Common.js"></script>
    <script src="/js/My97DatePicker/WdatePicker.js"></script>
    <script src="/js/jquery.tmpl.js"></script>
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
                        <div class="t_message">
                            <div class="message_con">
                                <form>
                                    <table class="m_top">
                                        <tr>
                                            <td class="mi"><span class="m">盘点计划单号：</span></td>
                                            <td class="ku">
                                                <span id="sp_InventoryNo"></span></td>
                                        </tr>
                                        <tr>
                                            <td class="mi"><span class="m">盘点计划名称：</span></td>
                                            <td class="ku">
                                               <input id="txt_Name" type="text" class="hu" placeholder="请输入盘点计划名称" /><span class="wstar">*</span>                                    
                                           </td>
                                        </tr>                                                           
                                        <tr>
                                            <td class="mi"><span class="m">盘点日期：</span></td>
                                            <td class="ku">
                                              <input id="da_InventoryTime" type="text" class="Wdate hu" onclick="javascript: WdatePicker();"/><span class="wstar">*</span>                                            
                                           </td>
                                        </tr>                                           
                                        <tr>
                                            <td class="mi"><span class="m">类型：</span></td>
                                            <td class="ku">
                                                <select id="sel_Type" class="option">
                                                    <option value="0">教学资产盘点</option>
                                                    <option value="1">科研资产盘点</option>
                                                    <option value="2">办公资产盘点</option>
                                                </select></td>
                                        </tr>                                                                            
                                    </table>
                                </form>
                            </div>
                        </div>
                        <div class="submit_btn">
                            <span class="Save_and_submit">
                                <input type="submit" value="确定" class="Save_and_submit" onclick="SaveStudent();" /></span>
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
        var itemid = $("#<%=hid_Id.ClientID%>").val();
        if (itemid.length) {
            //为控件绑定数据
            BindDataById(itemid);
        } else {
            $("#sp_InventoryNo").html("PD"+GetNowTime());
        }
    });
    function BindDataById(itemid) {
        $.ajax({
            url: WebServiceUrl + "/Inventory/Inventory.ashx",//random" + Math.random(),//方法所在页面和方法名
            type: "post",
            async: false,
            dataType: "jsonp",
            jsonp: "jsoncallback",
            data: { itemid: itemid, action: "GetModelById" },
            success: OnBindSuccess,
        });
    }
    function OnBindSuccess(json) {
        var model = json.result;
        if (model.toString() != "") {
            $("#sp_InventoryNo").html(model.InventoryNo);
            $("#txt_Name").val(model.Name);
            $("#da_InventoryTime").val(DateTimeConvert(model.InventoryTime));
            $("#sel_Type").val(model.Type);
        }
    }
    //保存用户
    function SaveStudent() {
        var invno = $("#sp_InventoryNo").html().trim();
        var name = $("#txt_Name").val().trim();
        var invtime = $("#da_InventoryTime").val().trim();
        if (!name.length || !invtime.length) {
            layer.msg("请填写完整信息！");
            return;
        }
        var itemid = $("#<%=hid_Id.ClientID%>").val();
        var actionp = "AddInventoryPlan";
        var url = WebServiceUrl + "/Inventory/Inventory.ashx";
        if (itemid.length) {
            url = WebServiceUrl + "/Inventory/Inventory.ashx";
            actionp = "EditInventoryPlan";
        }
        $.ajax({
            url: url,//random" + Math.random(),//方法所在页面和方法名
            type: "post",
            async: false,
            dataType: "jsonp",
            jsonp: "jsoncallback",
            data: {
                itemid: itemid,
                invno:invno,
                name: name,
                type: $("#sel_Type").val(),
                invtime: invtime,
                useridcard: $("#hid_UserIDCard").val(),
                action:actionp
            },
            success: OnSaveSuccess,
            error: OnSaveError
        });

    }

    function OnSaveSuccess(json) {
        if (json.result == "-1") {
            layer.msg("该盘点计划已存在！");
        }
        else if (json.result != "0" && json.result != "-1") {
            parent.layer.msg('操作成功!');
            parent.getData(1);
            parent.CloseIFrameWindow();
        } else {
            layer.msg("操作失败！");
        }
    }
    function OnSaveError(XMLHttpRequest, textStatus, errorThrown) {
        layer.msg("操作失败！");
    }
    function GetNowTime(date, format) {
        var date = new Date();        
        var year = date.getFullYear();
        var month = (date.getMonth() + 1).toString();
        month = month.length == 1 ? "0" + month : month; //月份为1位数时，前面加0
        var day = (date.getDate()).toString();
        day = day.length == 1 ? "0" + day : day; //天数为1位数时，前面加0
        var hour = (date.getHours()).toString();
        hour = hour.length == 1 ? "0" + hour : hour; //小时数为1位数时，前面加0
        var minute = (date.getMinutes()).toString();
        minute = minute.length == 1 ? "0" + minute : minute; //分钟数为1位数时，前面加0
        var second = (date.getSeconds()).toString();
        second = second.length == 1 ? "0" + second : second; //秒数为1位数时，前面加0
        return year + month + day  + hour + minute + second;
    }

</script>
</html>


