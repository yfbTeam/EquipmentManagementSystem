<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClassManagement.aspx.cs" Inherits="EMS.Web.SystemSettings.ClassManagement" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>班级管理</title>
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
            <td>${DateTimeConvert(CreateTime)}</td>
            {{if UseStatus==0}}
            <td class="Status">${'启用'}</td>
            {{else}}
            <td class="DisableStatus">${'禁用'}</td>
            {{/if}}   
            <td>
                <input type="button" class="Topic_btn" value="编辑" onclick="javascript: OpenIFrameWindow('编辑班级', 'ClassEdit.aspx?itemid=${Id}', '560px', '240px');" />
                {{if UseStatus==0}}
                <input type="button" class="DisableTopic_btn" value="禁用" onclick="javascript: ChangeUseStatus(this, '${Id}', '${UseStatus==0?1:0}', 'ClassInfo');"/>
                {{else}}
                <input type="button" class="EnableTopic_btn" value="启用" onclick="javascript: ChangeUseStatus(this, '${Id}', '${UseStatus==0?1:0}', 'ClassInfo');"/>
                {{/if}}
            </td>
        </tr>

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="Teaching_plan_management">
            <h1 class="Page_name">班级管理</h1>
            <div class="Operation_area">
                <div class="left_choice fl">
                    <ul>
                        <li class="Sear">
                            <input type="text" id="search_w" name="search_w" class="search_w" placeholder="请输入班级名称" value="" /><a class="sea" href="#" onclick="SearchClass();" style="margin-left:10px;">搜索</a>
                        </li>
                    </ul>
                </div>
                <div class="right_add fr">
                    <a class="add" href="javascript:void(0);" onclick="javascript: OpenIFrameWindow('新增班级','ClassEdit.aspx', '560px', '240px');"><i class="iconfont">&#xe726;</i>新增班级</a>
                </div>
            </div>
            <div class="Honor_management">
                <table class="W_form" id="tb_UserList">
                    <thead>
                        <tr class="trth">
                            <th class="number">序号</th>                            
                            <th class="Project_name">班级名称</th>
                            <th>创建时间</th>
                            <th>状态</th>
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
    function SearchClass() {
        sername = $("#search_w").val().trim();
        getData(1);
    }
    //获取数据
    function getData(startIndex) {
        //初始化序号 
        pageNum = (startIndex - 1) * 10 + 1;
        $.ajax({
            url: WebServiceUrl + "/SystemSettings/ClassInfo.ashx",//random" + Math.random(),//方法所在页面和方法名
            type: "post",
            async: false,
            dataType: "jsonp",
            jsonp: "jsoncallback",
            data: { name: sername, startIndex: startIndex, pageSize: 10, action: "GetDataPage" },
            success: OnSuccess,
            error: OnError
        });
    }
    function OnSuccess(json) {
        if (json.result.Status.toString() == "no") {
            $("#tb_UserList tbody").html('<tr><td colspan="100"  style="text-align:center;">无内容</td></tr>');
        } else {
            $("#tb_UserList tbody").html('');
            $("#tr_User").tmpl(json.result.Data.PagedData).appendTo("#tb_UserList");
            //隔行变色以及鼠标移动高亮
            $(".main-bd table tbody tr").mouseover(function () {
                $(this).addClass("over");
            }).mouseout(function () {
                $(this).removeClass("over");
            })
            $(".main-bd table tbody tr:odd").addClass("alt");
            //生成页码条方法（方法对象,页码条容器，当前页码，总页数，页码组容量，总行数）
            makePageBar(getData, document.getElementById("pageBar"), json.result.Data.PageIndex, json.result.Data.PageCount, 8, json.result.Data.RowCount);
        }
    }
    function OnError(XMLHttpRequest, textStatus, errorThrown) {
        $("#tb_UserList tbody").html('<tr><td colspan="100"  style="text-align:center;">无内容</td></tr>');
    }
</script>
</html>
