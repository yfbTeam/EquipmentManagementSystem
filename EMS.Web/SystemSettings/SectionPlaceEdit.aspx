<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SectionPlaceEdit.aspx.cs" Inherits="EMS.Web.SystemSettings.SectionPlaceEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>新增科所</title>
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
                                            <td class="mi"><span class="m">科所名称：</span></td>
                                            <td class="ku">
                                                <input id="txt_name" type="text" class="hu" placeholder="请输入科所名称" /><span class="wstar">*</span></td>
                                        </tr>
                                        <tr>
                                            <td class="mi"><span class="m">所长：</span></td>
                                            <td class="ku">
                                                <select id="sel_director" class="option">
                                                </select><span class="wstar">*</span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="mi"><span class="m">副所长：</span></td>
                                            <td class="ku">
                                                <select id="sel_vicedirector" class="option">
                                                    <option value=""></option>
                                                </select>
                                            </td>
                                        </tr>
                                    </table>
                                </form>
                            </div>
                        </div>
                        <div class="submit_btn">
                            <span class="Save_and_submit">
                                <input type="submit" value="确定" class="Save_and_submit" onclick="SaveSectionPlace();" /></span>
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
        BindUserInfo();        
    });
    function BindDataById(itemid) {
        $.ajax({
            url: WebServiceUrl + "/SystemSettings/SectionPlace.ashx",//random" + Math.random(),//方法所在页面和方法名
            type: "post",
            async: false,
            dataType: "jsonp",
            jsonp: "jsoncallback",
            data: { itemid: itemid, action: "GetModelById" },
            success: OnBindSuccess,
            //error: OnBindError
        });
    }
    //绑定用户
    function BindUserInfo() {
        $.ajax({
            url: "/CommonHandler/UnifiedHelpHandler.ashx",
            type: "post",
            async: false,
            dataType: "json",
            data: {
                Func: "GetUserInfoData",
                IsStu: false
            },
            success: function (json) {
                $("#sel_director").empty();
                $("#sel_vicedirector").empty().append("<option value=''></option>");
                if (json.result.errNum.toString() == "0") {
                    $.each(json.result.retData, function (i, item) {
                        var option = "<option value='" + item.UniqueNo + "'>" + item.Name + "</option>"
                        $("#sel_director").append(option);
                        $("#sel_vicedirector").append(option);
                    });                    
                }
                var itemid = $("#<%=hid_Id.ClientID%>").val();
                if (itemid.length) {
                    //为控件绑定数据
                    BindDataById(itemid);
                }
            }
        });
    }
    function OnBindSuccess(json) {
        var model = json.result;
        if (model.toString() != "") {
            $("#txt_name").val(model.Name);
            $("#sel_director").val(model.Director);
            $("#sel_vicedirector").val(model.ViceDirector);
        }
    }
    //保存科所
    function SaveSectionPlace() {
        var name = $("#txt_name").val().trim();
        var director = $("#sel_director").val();
        var vicedirector = $("#sel_vicedirector").val();
        if (!name.length||director==null || !director.length) {
            layer.msg("请填写完整信息！");
            return;
        }
        var itemid = $("#<%=hid_Id.ClientID%>").val();
        var actionp = "AddSectionPlace";
        var url = WebServiceUrl + "/SystemSettings/SectionPlace.ashx";
        if (itemid.length) {
            url = WebServiceUrl + "/SystemSettings/SectionPlace.ashx";
            actionp = "EditSectionPlace";
        }
        $.ajax({
            url: url,//random" + Math.random(),//方法所在页面和方法名
            type: "post",
            async: false,
            dataType: "jsonp",
            jsonp: "jsoncallback",
            data: {
                itemid: itemid,
                name: name.trim(),
                director: director,
                vicedirector: vicedirector,
                useridcard: $("#hid_UserIDCard").val(),
                action:actionp
            },
            success: OnSaveSuccess,
            error: OnSaveError
        });
    }

    function OnSaveSuccess(json) {
        if (json.result == "-1") {
            layer.msg("该科所已存在！");
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

