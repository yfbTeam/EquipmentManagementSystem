<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentManagement.aspx.cs" Inherits="EMS.Web.SystemSettings.StudentManagement" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>学生信息管理</title>
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
            <td>${KaNo}</td> 
            <td>${IDCard}</td>
            <td>${GradeName}</td> 
            <td>${OrgName}</td>
            <td>${Phone}</td>         
            <td>${DateTimeConvert(CreateTime)}</td>
            {{if IsEnable==1}}
            <td class="Status">${'启用'}</td>
            {{else}}
            <td class="DisableStatus">${'禁用'}</td>
            {{/if}}
            <td>
                <input type="button" class="Topic_btn" value="编辑" onclick="javascript: OpenIFrameWindow('编辑学生', 'StudentEdit.aspx?itemid=${Id}', '620px', '400px');" />
                {{if IsEnable==1}}
                <input type="button" class="DisableTopic_btn" value="禁用" onclick="javascript: ChangeUseStatus(this, '${Id}', '${IsEnable==0?1:0}', 'Student');"/>
                {{else}}
                <input type="button" class="EnableTopic_btn" value="启用" onclick="javascript: ChangeUseStatus(this, '${Id}', '${IsEnable==0?1:0}', 'Student');"/>
                {{/if}}
            </td>
        </tr>

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="Teaching_plan_management">
            <h1 class="Page_name">学生信息管理</h1>
            <div class="Operation_area">
                <div class="left_choice fl">
                    <ul>
                        <li class="Sear">
                            <input type="text" id="search_w" name="search_w" class="search_w" placeholder="请输入姓名" value="" /><a class="sea" href="#" onclick="SearchStudent();" style="margin-left:10px;">搜索</a>
                        </li>
                    </ul>
                </div>
                <div class="right_add fr">                   
                    <a class="add" href="javascript:void(0);" onclick="javascript: OpenIFrameWindow('新增学生','StudentEdit.aspx', '620px', '400px');"><i class="iconfont">&#xe726;</i>新增学生</a>
                </div>
            </div>
            <div class="Honor_management">
                <table class="W_form" id="tb_UserList">
                    <thead>
                        <tr class="trth">
                            <th class="number">序号</th>
                            <th>姓名</th>
                            <th>性别</th>
                            <th class="Project_name">卡号</th>
                            <th>身份证号</th>
                            <th>年级</th>
                            <th>班级</th>
                            <th>手机号</th>
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
    function SearchStudent() {
        sername = $("#search_w").val().trim();
        getData(1);
    }
    //获取数据
    function getData(startIndex)
    {
        //初始化序号 
        pageNum = (startIndex - 1) * 10 + 1;
        $.ajax({
            url: "/CommonHandler/UnifiedHelpHandler.ashx",
            type: "post",
            async: false,
            dataType: "json",
            data: { Func: "GetUserInfoData", IsStu: true, Name: sername, Ispage: true, PageIndex: startIndex, pageSize: 10 },
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
</script>
</html>
