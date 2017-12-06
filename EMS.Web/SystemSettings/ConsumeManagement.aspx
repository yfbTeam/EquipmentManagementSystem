<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConsumeManagement.aspx.cs" Inherits="EMS.Web.SystemSettings.ConsumeManagement" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>耗材管理</title>
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
            <td>${AssetName}</td>            
            <td>${Count}</td>
            <td>${Unit}</td>             
            <td>${Type==0?'教学设备':(Type==1?'科研设备':'办公设备')}</td>                       
            <td>${DateTimeConvert(CreateTime)}</td>
            {{if UseStatus==0}}
            <td class="Status">${'启用'}</td>
            {{else}}
            <td class="DisableStatus">${'禁用'}</td>
            {{/if}}
            <td>
                <input type="button" class="Topic_btn" value="编辑" onclick="javascript: OpenIFrameWindow('编辑耗材','ConsumeEdit.aspx?itemid=${Id}', '640px', '400px');" />
                {{if UseStatus==0}}
                <input type="button" class="DisableTopic_btn" value="禁用" onclick="javascript: ChangeUseStatus(this, '${Id}', '${UseStatus==0?1:0}', 'EquipDetail');"/>
                {{else}}
                <input type="button" class="EnableTopic_btn" value="启用" onclick="javascript: ChangeUseStatus(this, '${Id}', '${UseStatus==0?1:0}', 'EquipDetail');"/>
                {{/if}}
                <input type="button" class="Topic_btn" value="历史记录" onclick="javascript: OpenIFrameWindow('历史记录', 'ConsumeHistory.aspx?itemid=${Id}', '560px', '550px');" />
                <input type="button" class="Topic_btn" value="入库" onclick="javascript: OpenIFrameWindow('入库', 'ConsumeEnterStorage.aspx?itemid=${Id}', '560px', '350px');" />
            </td>
        </tr>

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="Teaching_plan_management">
            <h1 class="Page_name">耗材管理</h1>
            <div class="Operation_area">
                <div class="left_choice fl">
                    <ul>
                        <li class="Sear">
                            <input type="text" id="sea_name" name="sea_name" class="search_w" placeholder="请输入耗材名称" value="" />
                            <a class="sea" href="javascript:void(0);" onclick="SearchConsume();"style="margin-left:5px;">搜索</a>
                        </li>
                    </ul>
                </div>
                <div class="right_add fr">
                    <a class="add" href="javascript:void(0);" onclick="javascript: OpenIFrameWindow('新增耗材','ConsumeEdit.aspx', '640px', '400px');"><i class="iconfont">&#xe726;</i>新增耗材</a>
                </div>
            </div>
            <div class="Honor_management">
                <table class="W_form" id="tb_UserList">
                    <thead>
                        <tr class="trth">
                            <th class="number">序号</th>                           
                            <th class="Project_name">耗材名称</th>                            
                            <th class="">库存</th>
                            <th class="">计量单位</th>  
                            <th class="">类型</th>                            
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
    var sername = $("#sea_name").val().trim();
    $(document).ready(function () {
        //获取数据
        getData(1);
    });
    function SearchConsume() {
        sername = $("#sea_name").val().trim();
        getData(1);
    }
    //获取数据
    function getData(startIndex) {
        //初始化序号 
        pageNum = (startIndex - 1) * 10 + 1;        
        $.ajax({
            url: WebServiceUrl + "/SystemSettings/Consume.ashx",//random" + Math.random(),//方法所在页面和方法名
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
            $("#tb_UserList tbody").html('<tr><td colspan="100" style="text-align:center;">无内容</td></tr>');
        } else {
            $("#tb_UserList tbody").html('');
            $("#tr_User").tmpl(json.result.Data.PagedData).appendTo("#tb_UserList");
            var status = $(".usestatus").val();
            if (status == "禁用") {
                $(".usestatus").css("color", "ff7070");
            }
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
        $("#tb_UserList tbody").html('<tr><td colspan="100" style="text-align:center;">无内容</td></tr>');
    }

    function DeleteConsume(id) {
        layer.msg("确定要删除该耗材?", {
            time: 0 //不自动关闭
            , btn: ['确定', '取消']
            , yes: function (index) {
                layer.close(index);
                $.ajax({
                    url: WebServiceUrl + "/SystemSettings/Consume.ashx",//random" + Math.random(),//方法所在页面和方法名
                    type: "post",
                    async: false,
                    dataType: "jsonp",
                    jsonp: "jsoncallback",
                    data: { "intID": id, "action": "DeleteConsume" },
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
</script>
</html>
