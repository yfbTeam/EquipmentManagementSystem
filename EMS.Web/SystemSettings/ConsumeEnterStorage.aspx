<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConsumeEnterStorage.aspx.cs" Inherits="EMS.Web.SystemSettings.ConsumeEnterStorage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>入库</title>
    <link href="/css/style.css" rel="stylesheet" />
    <link href="/css/common.css" rel="stylesheet" />
    <link href="/css/iconfont.css" rel="stylesheet" />
    <link href="/css/animate.css" rel="stylesheet" />
    <script src="/js/jquery-1.11.2.min.js"></script>
    <script src="/js/layer/layer.js"></script>
    <script src="/js/Common.js"></script>
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
                                        <tr><td class="mi"><span class="m">耗材名称：</span></td>
                                            <td><span id="sp_AssetName"></span></td>
                                        </tr>
                                        <tr><td class="mi"><span class="m">计量单位：</span></td>
                                            <td><span id="sp_Unit"></span></td>
                                        </tr>
                                        <tr><td class="mi"><span class="m">现有库存：</span></td>
                                            <td><span id="sp_Count"></span></td>
                                        </tr>
                                        <tr></tr>
                                        <tr>
                                            <td class="mi"><span class="m">入库数量：</span></td>
                                            <td class="ku">
                                                <input id="txt_count" type="text" onkeyup="value=value.replace(/[^\d]/g,'') " class="hu" placeholder="请输入入库数量" /><span class="wstar">*</span></td>
                                        </tr>
                                    </table>

                                </form>
                            </div>
                        </div>
                        <div class="submit_btn">
                            <span class="Save_and_submit">
                                <input type="submit" value="确定" class="Save_and_submit" onclick="SaveIntoCount();" /></span>
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
        }
    });
    function BindDataById(itemid) {
        $.ajax({
            url: WebServiceUrl + "/SystemSettings/Consume.ashx",//random" + Math.random(),//方法所在页面和方法名
            type: "post",
            async: false,
            dataType: "jsonp",
            jsonp: "jsoncallback",
            data: { itemid: itemid, action: "GetModelById" },
            success: function(json) {
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
    
    //保存角色
    function SaveIntoCount() {
        var count = $("#txt_count").val().trim();
        var re = /[1-9]+\d*/;
        if (!count.length || !re.test(count)) {
            layer.msg("请填写入库数量！");
            return;
        }
        var itemid = $("#<%=hid_Id.ClientID%>").val();
        $.ajax({
            url: WebServiceUrl + "/SystemSettings/Consume.ashx",//random" + Math.random(),//方法所在页面和方法名
            type: "post",
            async: false,
            dataType: "jsonp",
            jsonp: "jsoncallback",
            data: {
                itemid: itemid,
                count: count,
                useridcard: $("#hid_UserIDCard").val(),
                action: "EquipIntoCount"
            },
            success: OnSaveSuccess,
            error: OnSaveError
        });

    }

    function OnSaveSuccess(json) {
        if (json.result.Status == "ok") {
            parent.layer.msg(json.result.Msg);
            parent.getData(1);
            parent.CloseIFrameWindow();
        } else {
            layer.msg(json.result.Msg);
        }         
    }
    function OnSaveError(XMLHttpRequest, textStatus, errorThrown) {
        layer.msg("操作失败！");
    }
</script>
</html>
