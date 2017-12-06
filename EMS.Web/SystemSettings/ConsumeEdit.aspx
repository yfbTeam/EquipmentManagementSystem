<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConsumeEdit.aspx.cs" Inherits="EMS.Web.SystemSettings.ConsumeEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>新增耗材</title>
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
                                        <tr>
                                            <td class="mi"><span class="m">耗材名称：</span></td>
                                            <td class="ku">
                                                <input id="txt_name" type="text" class="hu" placeholder="请输入耗材名称" /><span class="wstar">*</span></td>
                                        <td class="mi" style="padding-left: 15px;"><span class="m">计量单位：</span></td>
                                            <td class="ku">
                                                <input id="txt_unit" type="text" class="hu" placeholder="请输入计量单位" /><span class="wstar">*</span></td>
                                        </tr>
                                        <tr>
                                            <td class="mi"><span class="m">类别：</span></td>
                                                <td class="ku">
                                                    <select class="option" id="sel_type">
                                                        <option value="0">教学设备</option>
                                                        <option value="1">科研设备</option>
                                                        <option value="2">办公设备</option>
                                                    </select>
                                                </td>
                                            <td class="mi" id="td_countword" name="td_countword" style="padding-left: 15px;" runat="server"><span class="m">耗材数量：</span></td>
                                            <td class="ku" id="td_count" nae="td_count" runat="server">
                                                <input id="txt_count" type="text" class="hu" placeholder="请输入耗材数量" /><span class="wstar">*</span></td>
                                        </tr>
                                        <tr>
                                            <td class="mi"><span class="m">备注：</span></td>
                                            <td class="ku" colspan="3">
                                                <textarea id="te_remark" name="te_remark" rows="4" style="width: 500px;" form="usrform" placeholder="请在此处输入文本..."></textarea>
                                            </td>
                                        </tr>
                                    </table>
                                </form>
                            </div>
                        </div>
                        <div class="submit_btn">
                            <span class="Save_and_submit">
                                <input type="submit" value="确定" class="Save_and_submit" onclick="SaveConsume();" /></span>
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
            success: OnBindSuccess,
            //error: OnBindError
        });
    }
    function OnBindSuccess(json) {
        var model = json.result;
        if (model.toString() != "") {
            $("#txt_name").val(model.AssetName);
            $("#txt_unit").val(model.Unit);
            $("#te_remark").val(model.Remarks);
            $("#sel_type").val(model.Type);
        }
    }
    //保存耗材
    function SaveConsume() {
        var name = $("#txt_name").val().trim(), unit = $("#txt_unit").val().trim();        
        var itemid = $("#<%=hid_Id.ClientID%>").val();
        var url;
        var count;
        var actionp;
        if (itemid.length) {
            url = WebServiceUrl + "/SystemSettings/Consume.ashx";
            actionp = "EditConsume";
            count = "0";
        } else {
            url = WebServiceUrl + "/SystemSettings/Consume.ashx";
            actionp = "AddConsume";
            count = $("#txt_count").val().trim()
        }
        if (!name.length || !count.length || !unit.length) {
            layer.msg("请填写完整信息！");
            return;
        }
        $.ajax({
            url: url,//random" + Math.random(),//方法所在页面和方法名
            type: "post",
            async: false,
            dataType: "jsonp",
            jsonp: "jsoncallback",
            data: {
                itemid: itemid, name: name, count: count, unit: unit,
                type: $("#sel_type").val(), remarks: $("#te_remark").val(), useridcard: $("#hid_UserIDCard").val(), action: actionp
            },
            success: function (json) {
                if (json.result == "-1") {
                    layer.msg("该耗材已存在！");
                }
                else if (json.result != "0" && json.result != "-1") {
                    parent.layer.msg('操作成功!');
                    parent.getData(1);
                    parent.CloseIFrameWindow();
                } else {
                    layer.msg("操作失败！");
                }
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                layer.msg("操作失败！");
            }
        });
    }
</script>
</html>

