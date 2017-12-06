<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserEdit.aspx.cs" Inherits="EMS.Web.SystemSettings.UserEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>新增教师</title>
    <link href="/css/style.css" rel="stylesheet" />
    <link href="/css/common.css" rel="stylesheet" />
    <link href="/css/iconfont.css" rel="stylesheet" />
    <link href="/css/animate.css" rel="stylesheet" />
    <script src="/js/jquery-1.11.2.min.js"></script>
    <script src="/js/layer/layer.js"></script>
    <script src="/js/Common.js"></script>
    <script src="/js/jquery.tmpl.js"></script>
</head>
<body onload="this.focus();">
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
                                            <td class="mi"><span class="m">姓名：</span></td>
                                            <td class="ku">
                                                <input id="txt_name" type="text" class="hu" placeholder="请输入姓名" /><span class="wstar">*</span></td>
                                            <td class="mi" style="padding-left:15px;"><span class="m">性别：</span></td>
                                            <td id="td_sex">
                                                <span>
                                                    <input id="ra_man" type="radio" name="sex" value="男" checked="checked" />男</span>
                                                <span>
                                                    <input id="ra_woman" type="radio" name="sex" value="女" />女</span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="mi"><span class="m">卡号：</span></td>
                                            <td class="ku">
                                                <input id="txt_kano" type="text" readonly="true" class="hu" placeholder="请输入卡号" /></td>
                                            <td class="mi" style="padding-left: 15px;"><span class="m">身份证号：</span></td>
                                            <td class="ku">
                                                <input id="txt_idcard" type="text" class="hu" placeholder="请输入身份证号" /><span class="wstar">*</span></td>
                                        </tr>
                                        <tr>
                                            <td class="mi" style="padding-left:15px;"><span class="m">登录名：</span></td>
                                            <td class="ku">
                                                <input id="txt_LoginName" type="text" class="hu" placeholder="请输入登录名" /><span class="wstar">*</span></td>
                                        </tr>
                                        <tr>
                                            <td class="mi"><span class="m">密码：</span></td>
                                            <td class="ku">
                                                <input id="txt_Pwd" type="password" class="hu" placeholder="请输入密码" /><span class="wstar">*</span></td>
                                            <td class="mi" style="padding-left:15px;"><span class="m">确认密码：</span></td>
                                            <td class="ku">
                                                <input id="txt_ConfirmPwd" type="password" class="hu" placeholder="请输入确认密码" /><span class="wstar">*</span></td>
                                        </tr>
                                    </table>

                                </form>
                            </div>
                        </div>
                        <div class="submit_btn">
                            <span class="Save_and_submit">
                                <input type="submit" value="确定" class="Save_and_submit" onclick="SaveTeacher();" /></span>
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
    var num = "";
    $(document).ready(function () {
        var itemid = $("#<%=hid_Id.ClientID%>").val();
        if (itemid.length) {
            $("#txt_LoginName").css("pointer-events", "none");
            //为控件绑定数据
            BindDataById(itemid);
        }
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
                if (num.length > 3) {
                    $("#txt_kano").val(num);
                }
                //清空 纪录
                num = "";
            }
        };
    });
    function BindDataById(itemid) {
        $.ajax({
            url: WebServiceUrl + "/SystemSettings/UserInfo.ashx",//random" + Math.random(),//方法所在页面和方法名
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
            $("#txt_LoginName").val(model.LoginName);
            //$("#txt_Pwd").val(model.PassWord);
            //$("#txt_ConfirmPwd").val(model.PassWord);
            $("#txt_name").val(model.Name);
            if (model.Sex.trim() == "男") {
                $("#ra_man").attr("checked", "checked");
            } else {
                $("#ra_woman").attr("checked", "checked");
            }
            $("#txt_kano").val(model.KaNo);
            $("#txt_idcard").val(model.IDCard);
        }
    }
    //保存教师信息
    function SaveTeacher() {
        var addloginname = $("#txt_LoginName").val().trim();
        var pwd = $("#txt_Pwd").val().trim();
        var confirmpwd = $("#txt_ConfirmPwd").val().trim();
        var name = $("#txt_name").val().trim();
        var kano = $("#txt_kano").val().trim();
        var idcard = $("#txt_idcard").val().trim();
        var itemid = $("#<%=hid_Id.ClientID%>").val();
        var actionp = "AddUserInfo";
        var url = WebServiceUrl + "/SystemSettings/UserInfo.ashx";
        var judge = !addloginname.length || !pwd.length || !confirmpwd.length || !name.length || !idcard.length;
        if (itemid.length) {
            url = WebServiceUrl + "/SystemSettings/UserInfo.ashx";
            judge = !name.length || !idcard.length;
            actionp = "EditUserInfo";
        }
        if (judge) {
            layer.msg("请填写完整信息！");
            return;
        }
        if (pwd != confirmpwd) {
            layer.msg("密码不一致!");
            return;
        }
        $.ajax({
            url: url,//random" + Math.random(),//方法所在页面和方法名
            type: "post",
            async: false,
            dataType: "jsonp",
            jsonp: "jsoncallback",
            data: {
                itemid: itemid,
                addloginname: addloginname,
                pwd: pwd,
                name: name.trim(),
                useridcard: $("#hid_UserIDCard").val(),
                sex: $('#td_sex input[name="sex"]:checked').val(),
                kano: kano,
                idcard: idcard,
                action:actionp
            },
            success: OnSaveSuccess,
            error: OnSaveError
        });

    }

    function OnSaveSuccess(json) {
        if (json.result == "-1") {
            layer.msg("该登录名已存在！");
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
</script>
</html>

