<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inventory.aspx.cs" Inherits="EMS.Web.Inventory.Inventory" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>盘点管理</title>
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
            <td>${InventoryNo}</td>
            <td>${Name}</td>
            <td>${Type==0?'教学资产盘点':(Type==1?'科研资产盘点':'办公资产盘点')}</td>
            <td>${DateTimeConvert(InventoryTime)}</td>
            <td>{{if Status == 0}}<span style="color:red;">未盘点</span>{{else}}<span>已盘点</span>{{/if}}</td>
            <td>{{if IsGenerate === 0}}
                   <input type="button" class="Topic_btn" value="编辑" onclick="javascript: OpenIFrameWindow('编辑盘点计划', 'InventoryPlanEdit.aspx?itemid=${Id}', '560px', '460px');" />
                   <input type="button" class="Topic_btn" value="删除" onclick="javascript: DeleteInventoryPlan('${Id}');" />
                   <input type="button" class="Topic_btn" value="生成盘点单" onclick="javascript: CreateInventoryList('${Id}', '${Type}');" />
                {{else}}
                    {{if Status === 0}}
                        <input type="button" class="Topic_btn" value="盘点" onclick="javascript: location.href = 'BuildingInventory.aspx?itemid=${Id}&type=${Type}'; " />
                    {{else}}
                        <input type="button" class="Topic_btn" value="查看盘点单" onclick="javascript: location.href = 'InventoryListResult.aspx?itemid=${Id}&type=${Type}'; " />
                    {{/if}}  
                {{/if}}               
            </td>
        </tr>

    </script>
</head>
<body>
    <input type="hidden" id="hid_UserIDCard" runat="server" />
    <form id="form1" runat="server">
        <div class="Teaching_plan_management">
            <h1 class="Page_name">盘点管理</h1>
            <div class="Operation_area">
                <div class="left_choice fl">
                    <ul>
                        <li class="Sear">
                            <input type="text" id="search_w" name="search_w" class="search_w" placeholder="请输入计划名称" value="" /><a class="sea" href="#" onclick="SearchPlan();" style="margin-left:10px;">搜索</a>
                        </li>
                    </ul>
                </div>
                <div class="right_add fr">
                    <a class="add" href="javascript:void(0);" onclick="javascript: OpenIFrameWindow('新增盘点计划','InventoryPlanEdit.aspx', '560px', '460px');"><i class="iconfont">&#xe726;</i>新增盘点计划</a>
                </div>
            </div>
            <div class="Honor_management">
                <table class="W_form" id="tb_UserList">
                    <thead>
                        <tr class="trth">
                            <th class="number">序号</th>
                            <th>盘点计划单号</th>
                            <th class="Project_name">盘点计划名称</th>
                            <th>盘点类型</th>
                            <th>盘点日期</th>
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
    function SearchPlan() {
        sername = $("#search_w").val().trim();
        getData(1);
    }
    //获取数据
    function getData(startIndex) {
        //初始化序号 
        pageNum = (startIndex - 1) * 10 + 1;
        $.ajax({
            url: WebServiceUrl + "/Inventory/Inventory.ashx",//random" + Math.random(),//方法所在页面和方法名
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

    function CreateInventoryList(planid, type) {
        layer.msg("确定要生成盘点单么，生成盘点单后将不能修改盘点计划？", {
            time: 0 //不自动关闭
           , btn: ['确定', '取消']
           , yes: function (index) {
               layer.close(index);
               $.ajax({
                   url: WebServiceUrl + "/Inventory/Inventory.ashx",//random" + Math.random(),//方法所在页面和方法名
                   type: "post",
                   async: false,
                   dataType: "jsonp",
                   jsonp: "jsoncallback",
                   data: { planid: planid, type: type, useridcard: $("#hid_UserIDCard").val(), action: "CreateInventoryList" },
                   success: function (json) {
                       if (json.result.Status == "ok") {
                           layer.msg(json.result.Msg);
                           getData(1);
                       } else {
                           layer.msg(json.result.Msg);
                       }
                   },
                   error: function (XMLHttpRequest, textStatus, errorThrown) {
                       layer.msg("操作失败！");
                   }
               });
           }
        });
    }


    function DeleteInventoryPlan(planid) {
        layer.msg("确定要删除该盘点计划?", {
            time: 0 ,//不自动关闭
             btn: ['确定', '取消'],
             yes: function (index) {
                layer.close(index);
                $.ajax({
                    url: WebServiceUrl + "/Inventory/Inventory.ashx",//random" + Math.random(),//方法所在页面和方法名
                    type: "post",
                    async: false,
                    dataType: "jsonp",
                    jsonp: "jsoncallback",
                    data: { "intID": planid, action: "DeleteInventoryPlan" },
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
