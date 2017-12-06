<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddBulidingRoom.aspx.cs" Inherits="EMS.Web.SystemSettings.AddBulidingRoom" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>新增房间</title>
    <link href="/css/style.css" rel="stylesheet" />
    <link href="/css/common.css" rel="stylesheet" />
    <link href="/css/iconfont.css" rel="stylesheet" />
    <link href="/css/animate.css" rel="stylesheet" />
    <script src="/js/jquery-1.11.2.min.js"></script>
    <script src="/js/layer/layer.js"></script>
    <script src="/js/Common.js"></script>
    <script src="/js/PageBar.js"></script>
</head>
<body>
    <input type="hidden" id="hid_Id" runat="server" />
    <input type="hidden" id="hid_Pid" runat="server" />
    <input type="hidden" id="hid_PPid" runat="server" />
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
                                            <td class="mi"><span class="m">房间编号：</span></td>
                                            <td class="ku">
                                                <input id="txt_roomno" type="text" class="search_w" placeholder="请输入房间编号" /><span class="wstar">*</span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="mi"><span class="m">房间名称：</span></td>
                                            <td class="ku">
                                                <input id="txt_name" type="text" class="search_w" placeholder="请输入房间名称" /><span class="wstar">*</span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="mi"><span class="m">类型：</span></td>
                                            <td class="ku">
                                                <select id="sel_type" class="option" onchange="SetControlDiaplay(this.value);">
                                                    <option value="0" selected="selected">仪器室</option>
                                                    <option value="1">实验室</option>
                                                    <option value="2">办公室</option>
                                                </select></td>
                                        </tr>
                                        <tr style="display: none;" id="tr_place">
                                            <td class="mi"><span class="m">实验室科所：</span></td>
                                            <td class="ku">
                                                <select id="sel_secplace" class="option"></select><span class="wstar">*</span>
                                            </td>
                                        </tr>
                                    </table>
                                </form>
                            </div>
                        </div>
                        <div class="submit_btn">
                            <span class="Save_and_submit">
                                <input type="submit" value="确定" class="Save_and_submit" onclick="SaveRoom();" /></span>
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
    var UrlDate = new GetUrlDate(); //实例化
    $(document).ready(function () {
        BindSectionPlace();
    });
    function BindDataById(itemid) {
        $.ajax({
            url: WebServiceUrl + "/SystemSettings/Building.ashx",//random" + Math.random(),//方法所在页面和方法名
            type: "post",
            async: false,
            dataType: "jsonp",
            jsonp: "jsoncallback",
            data: { "itemid": itemid, "action": "GetModelById" },
            success: function (json) {
                var model = json.result;
                if (model.toString() != "") {
                    $("#txt_roomno").val(model.RoomNo);
                    $("#txt_name").val(model.Name);
                    $("#sel_type").val(model.Type);
                    if (model.Type == "1") {
                        $("#sel_secplace").val(model.SectionPlaceId);
                        $("#tr_place").show();
                    } else {
                        $("#tr_place").hide();
                    }
                }
            },
            //error: OnBindError
        });
    }
    //绑定实验室科所
    function BindSectionPlace() {
        var itemid = $("#<%=hid_Id.ClientID%>").val();
        $.ajax({
            type: "post",
            url: WebServiceUrl + "/SystemSettings/SectionPlace.ashx",
            async: false,
            dataType: "jsonp",
            jsonp: "jsoncallback",
            data: itemid.length ? { startIndex: 1, pageSize: 1000, "action": "GetDataPage" } : { usestatus: "0", startIndex: 1, pageSize: 1000, "action": "GetDataPage" },
            success: function (json) {
                $("#sel_secplace").empty();
                if (json.result.Status.toString() == "error") {
                    layer.msg(json.result.Msg);
                } else if (json.result.Status.toString() == "no") {
                } else {
                    $.each(json.result.Data.PagedData, function (i, item) {
                        var option = "<option value='" + item.Id + "'>" + item.Name + "(" + item.Director + ")</option>"
                        $("#sel_secplace").append(option);
                    });
                }
                if (UrlDate.secplaceid) {
                    $("#sel_type").val("1").attr("disabled", "disabled");
                    $("#sel_secplace").val(UrlDate.secplaceid).attr("disabled", "disabled");
                    $("#tr_place").show();
                }
                if (itemid.length) {
                    //为控件绑定数据
                    BindDataById(itemid);
                }
            }//,
            //error: OnError
        });
    }
    //保存房间信息
    function SaveRoom() {
        var name = $("#txt_name").val().trim(), roomno = $("#txt_roomno").val().trim();
        var secplace = $("#sel_secplace").val();
        if (!name.length || !roomno.length || secplace == null || secplace == "") {
            layer.msg("请填写完整信息！");
            return;
        }
        var itemid = $("#<%=hid_Id.ClientID%>").val();
        var pid = $("#<%=hid_Pid.ClientID%>").val();
        var ppid = $("#<%=hid_PPid.ClientID%>").val();
        var actionp = "AddBuilding";
        var url = WebServiceUrl + "/SystemSettings/Building.ashx";
        if (itemid.length) {
            url = WebServiceUrl + "/SystemSettings/Building.ashx";
            actionp = "EditBuilding";
        }
        $.ajax({
            url: url,//random" + Math.random(),//方法所在页面和方法名
            type: "post",
            async: false,
            dataType: "jsonp",
            jsonp: "jsoncallback",
            data: {
                itemid: itemid,
                flag: "room",
                roomno: roomno,
                name: name.trim(),
                pid: pid,
                ppid: ppid,
                type: $("#sel_type").val(),
                secplace: secplace,
                useridcard: $("#hid_UserIDCard").val(),
                action: actionp
            },
            success: function (json) {
                if (json.result == "-1") {
                    layer.msg("该房间编号已存在！");
                } else if (json.result == "-7") {
                    layer.msg("该房间内已存放仪器，不能更换类型!");
                }
                else if (json.result != "0" && json.result != "-1" && json.result != "-7") {
                    parent.layer.msg('操作成功!');
                    parent.GetLayersAndRoomsById(ppid);
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
    function SetControlDiaplay(value) {
        if (value == "1") {
            $("#tr_place").show();
        } else {
            $("#tr_place").hide();
        }
    }
</script>
</html>


