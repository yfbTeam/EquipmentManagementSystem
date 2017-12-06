<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserManagement.aspx.cs" Inherits="EMS.Web.SystemSettings.UserManagement" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>教师信息管理</title>
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
            <td>${pageIndex()}</td>
            <td>${Name}</td>
            <td>${Sex}</td>
            <td>${LoginName}</td> 
            <td>${KaNo}</td> 
            <td>${IDCard}</td>              
            <td>${DateTimeConvert(CreateTime)}</td>
            {{if IsEnable==1}}
            <td class="Status">${'启用'}</td>
            {{else}}
            <td class="DisableStatus">${'禁用'}</td>
            {{/if}}
            <%--<td class="State">
             <span class="qijin"><a href="javascript:void(0);" onclick="javascript:ChangeUseStatus(this,'${Id}',0,'UserInfo');" class="${IsEnable==0?'Enable':'Disable'}">启用</a>
             <a href="javascript:void(0);" onclick="javascript:ChangeUseStatus(this,'${Id}',1,'UserInfo');" class="${IsEnable==1?'Enable':'Disable'}">禁用</a></span>
            </td>--%>
            <td>
                <input type="button" class="Topic_btn" value="编辑" onclick="javascript: OpenIFrameWindow('编辑教师', 'UserEdit.aspx?itemid=${Id}', '630px', '310px');" />
                {{if IsEnable==1}}
                <input type="button" class="DisableTopic_btn" value="禁用" onclick="javascript: ChangeUseStatus(this, '${Id}', '${IsEnable==0?1:0}', 'UserInfo');"/>
                {{else}}
                <input type="button" class="EnableTopic_btn" value="启用" onclick="javascript: ChangeUseStatus(this, '${Id}', '${IsEnable==0?1:0}', 'UserInfo');"/>
                {{/if}}
            </td>
        </tr>

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="Teaching_plan_management">
            <h1 class="Page_name">教师信息管理</h1>
            <div class="Operation_area">
                <div class="left_choice fl">
                    <ul>
                        <li class="Sear">
                            <input type="text" id="search_w" name="search_w" class="search_w" placeholder="请输入姓名" value="" /><a class="sea" href="#" onclick="SearchTeacher();" style="margin-left:10px;">搜索</a>
                        </li>
                    </ul>
                </div>
                <div class="right_add fr">
                    <a class="add" href="javascript:ImportTeacher();"><i class="iconfont">&#xe726;</i>导入教师信息</a>
                    <a class="add" href="javascript:void(0);" onclick="javascript: OpenIFrameWindow('新增教师','UserEdit.aspx', '630px', '310px');"><i class="iconfont">&#xe726;</i>新增教师</a>
                </div>
            </div>
            <div class="Honor_management">
                <table class="W_form" id="tb_UserList">
                    <thead>
                        <tr class="trth">
                            <th class="number">序号</th>
                            <th>姓名</th>
                            <th>性别</th>
                            <th class="">登录名</th>
                            <th class="Project_name">卡号</th>
                            <th class="">身份证号</th>
                            <th class="">创建时间</th>
                            <th class="">状态</th>
                            <th>操作</th>
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
    </form>
</body>
<script type="text/javascript">
    var sername = $("#search_w").val().trim();
    $(document).ready(function () {
        //获取数据
        getData(1);
    });
    function SearchTeacher() {
        sername = $("#search_w").val().trim();
        getData(1);
    }
    //获取数据
    function getData(startIndex) {
        //初始化序号 
        pageNum = (startIndex - 1) * 10 + 1;
        $.ajax({
            url: "/CommonHandler/UnifiedHelpHandler.ashx",
            type: "post",
            async: false,
            dataType: "json",
            data: { Func: "GetUserInfoData", IsStu: false, Name: sername, Ispage: true, PageIndex: startIndex, pageSize: 10 },
            success: OnSuccess,
            error: OnError
        });

    }

    function OnSuccess(json) {
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
            //生成页码条方法（方法对象,页码条容器，当前页码，总页数，页码组容量，总行数）
            makePageBar(getData, document.getElementById("pageBar"), json.result.retData.PageIndex, json.result.retData.PageCount, 8, json.result.retData.RowCount);
        } else {
             $("#tb_UserList tbody").html('<tr><td colspan="100" style="text-align:center;">无内容</td></tr>');
        }
    }
    function OnError(XMLHttpRequest, textStatus, errorThrown) {
        $("#tb_UserList tbody").html('<tr><td colspan="100" style="text-align:center;">无内容</td></tr>');
    }

    function DeleteUser(id) {
        layer.msg("确定要删除该用户?", {
            time: 0 //不自动关闭
            , btn: ['确定', '取消']
            , yes: function (index) {
                layer.close(index);
                $.ajax({
                    url: WebServiceUrl + "/SystemSettings/UserInfo.ashx",//random" + Math.random(),//方法所在页面和方法名
                    type: "post",
                    async: false,
                    dataType: "jsonp",
                    jsonp: "jsoncallback",
                    data: { "intID": id, "action": "DeleteUserInfo" },
                    success: OnSuccessDelete,
                    //error: OnErrorDelete
                });
            }
        });
        function OnSuccessDelete(json) {
            if (json.result != "0") {
                layer.msg("删除成功！");
                getData(1);
            } else {
                layer.msg("删除失败！");
            }
        }
    }
    //导入教师Excel
    function ImportTeacher() {
        OpenIFrameWindow('导入教师', '../Statistical/ImportTeacher.aspx', '500px', '200px');
        //return;
    }
</script>
</html>
