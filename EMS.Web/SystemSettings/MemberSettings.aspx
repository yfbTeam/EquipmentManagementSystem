<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MemberSettings.aspx.cs" Inherits="EMS.Web.SystemSettings.MemberSettings" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>成员设置</title>
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
            <td>
                <input type="checkbox" name="cb_sub" value="${UniqueNo}"/></td>
            <td>${pageIndex()}</td>
            <td>${Name}</td>
            <td>${LoginName}</td>
            <%--<td>${DateTimeConvert(CreateTime)}</td>--%>
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
                        <%--<div class="t_message">
                            <div class="message_con">
                                
                            </div>
                        </div>--%>
                        <div class="Operation_area">
                            <div class="left_choice fl">
                                <ul>
                                    <li class="Sear">
                                        <input type="text" id="search_w" name="search_w" class="search_w" placeholder="请输入用户名" value="" /><a class="sea" href="#" onclick="SearchUser();">搜索</a>
                                    </li>
                                </ul>
                            </div>
                        </div>
                        <div class="Honor_management">
                            <table class="W_form" id="tb_UserList" style="background:white;">
                                <thead>
                                    <tr class="trth">
                                        <th class="cbox">
                                            <input type="checkbox" id="cb_all" name="cb_all" onclick="CheckAll(this);" /></th>
                                        <th class="number">序号</th>
                                        <th class="Project_name">用户名</th>
                                        <th class="">登录名</th>
                                        <%--<th class="">创建时间</th>--%>
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
                                <input type="submit" value="确定" class="Save_and_submit" onclick="SaveMemberSetting();" /></span>
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
    var memNoArray = [];
    var sername = $("#search_w").val().trim();
    $(document).ready(function () {
        //获取数据
        GetDataByRoleId(1);
    });
    //全选或全不选
    function CheckAll(obj) {
        var flag = obj.checked;//判断全选按钮的状态 
        $("input[type=checkbox][name=cb_sub]").each(function () {//查找每一个name为cb_sub的checkbox 
            this.checked = flag;//选中或者取消选中 
        });
    }
    function SearchUser() {
        sername = $("#search_w").val().trim();
        GetDataByRoleId(1);
    }
    //获取数据
    function GetDataByRoleId(startIndex) {
        var roleid = $("#<%=hid_Id.ClientID%>").val();
        //初始化序号 
        pageNum = (startIndex - 1) * 10 + 1;
        $.ajax({
            url: WebServiceUrl + "/SystemSettings/UserInfo.ashx",//random" + Math.random(),//方法所在页面和方法名
            type: "post",
            async: false,
            dataType: "jsonp",
            jsonp: "jsoncallback",
            data: { roleid: roleid, name: sername, ispage: false, PageIndex: startIndex, pageSize: 10, action: "GetDataByRoleId" },
            success: function (json) {
                if (json.result.Status.toString() == "ok") {
                    $(json.result.Data.PagedData).each(function (i, n) {
                        memNoArray.push(n.LoginName);
                    });
                }
                GetUserInfoData(1, 10);
            }
        });
    }  
   
    //获取用户信息
    function GetUserInfoData(startIndex) {
        var $pageBar = $("#pageBar");
        //初始化序号 
        pageNum = (startIndex - 1) * 10 + 1;
        $.ajax({
            url: "/CommonHandler/UnifiedHelpHandler.ashx",
            type: "post",
            async: false,
            dataType: "json",
            data: {
                Func: "GetUserInfoData",               
                Ispage: true,
                Name: sername,
                JoinNoConn: "not",
                UniqueNos: memNoArray.join(','),
                PageIndex: startIndex, pageSize: 10
            },
            success: function (json) {
                if (json.result.errNum.toString() == "0") {
                    $("#tb_UserList tbody").html('');
                    $("#tr_User").tmpl(json.result.retData.PagedData).appendTo("#tb_UserList");
                    //隔行变色以及鼠标移动高亮
                    $(".main-bd table tbody tr").mouseover(function () {
                        $(this).addClass("over");
                    }).mouseout(function () {
                        $(this).removeClass("over");
                    })
                    $(".main-bd table tbody tr:odd").addClass("alt");
                    $pageBar.show();
                    //生成页码条方法（方法对象,页码条容器，当前页码，总页数，页码组容量，总行数）
                    makePageBar(GetUserInfoData, document.getElementById("pageBar"), json.result.retData.PageIndex, json.result.retData.PageCount, 8, json.result.retData.RowCount);
                } else {
                    $pageBar.hide();
                    $("#tb_UserList tbody").html('<tr><td colspan="100"  style="text-align:center;">无内容</td></tr>');
                }
            },
            error: function (errMsg) {
                $("#tb_UserList tbody").html('<tr><td colspan="100"  style="text-align:center;">无内容</td></tr>');
            }
        });
    }
    //保存成员设置
    function SaveMemberSetting() {
        var nameArray = [];
        var checkedtr = $("input[type='checkbox'][name='cb_sub']:checked");
        if (checkedtr.length == 0) { layer.msg('请选择要添加的成员！'); return; }
        $(checkedtr).each(function (i, n) {
            nameArray.push(n.value);
        });        
        var itemid = $("#<%=hid_Id.ClientID%>").val();
        $.ajax({
            url: WebServiceUrl + "/SystemSettings/RoleInfo.ashx",//random" + Math.random(),//方法所在页面和方法名
            type: "post",
            async: false,
            dataType: "jsonp",
            jsonp: "jsoncallback",
            data: {
                itemid: itemid,
                loginnameStr: nameArray.join(","),
                useridcard: $("#hid_UserIDCard").val(),
                action: "SetRoleMember"
            },
            success: function(json) {
                if (json.result.Status == "ok") {
                    parent.layer.msg(json.result.Msg);
                    parent.getDataByRoleId(1);
                    parent.CloseIFrameWindow();                                       
                } else {
                    layer.msg(json.result.Msg);
                }
            },
            error: function(XMLHttpRequest, textStatus, errorThrown) {
                layer.msg("操作失败！");
            }
        });
    }
</script>
</html>

