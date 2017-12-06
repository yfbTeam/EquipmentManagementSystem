<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WarehouseManagement.aspx.cs" Inherits="EMS.Web.SystemSettings.WarehouseManagement" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>库房管理</title>
    <link href="/css/style.css" rel="stylesheet" />
    <link href="/css/common.css" rel="stylesheet" />
    <link href="/css/iconfont.css" rel="stylesheet" />
    <link href="/css/animate.css" rel="stylesheet" />
    <script src="/js/jquery-1.11.2.min.js"></script>
    <script src="/js/layer/layer.js"></script>
    <script src="/js/Common.js"></script>
    <script src="/js/jquery.tmpl.js"></script>
    <script src="/js/PageBar.js"></script>
    <script id="tr_Warehouse" type="text/x-jquery-tmpl">
        <tr>
            <td>${pageIndex()}</td>
            <td>${Name}</td>
            <td>${DateTimeConvert(CreateTime)}</td> 
            <td>
                <input type="button" class="Topic_btn" value="分类设置" onclick="javascript: OpenIFrameWindow('分类设置','EquipClassSettings.aspx?itemid=${Id}&name=${Name}', '680px', '610px');" />
            </td>
            <td>
                <input type="button" class="Topic_btn" value="权限设置" onclick="javascript: OpenIFrameWindow('权限设置','PermissionSettings.aspx', '560px', '510px');" />
            </td> 
            <td>${UseStatus==0?'启用':'禁用'}</td>                  
            <td>
                <input type="button" class="Topic_btn" value="编辑" onclick="javascript: OpenIFrameWindow('编辑库房','WarehouseEdit.aspx?itemid=${Id}', '560px', '450px');" />
                <input type="button" class="Topic_btn" value="${UseStatus==0?'禁用':'启用'}" onclick="javascript: ChangeUseStatus(this, '${Id}', '${UseStatus==0?1:0}', 'Warehouse');"/>
            </td>
        </tr>

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="Teaching_plan_management">
            <h1 class="Page_name">库房管理</h1>
            <div class="Operation_area">
                <div class="left_choice fl">
                    <ul>
                        <li class="Sear">
                            <input type="text" id="search_w" name="search_w" class="search_w" placeholder="请输入库房名称" value="" /><a class="sea" href="#" onclick="getData(1);">搜索</a>
                        </li>
                    </ul>
                </div>
                <div class="right_add fr">
                    <a class="add" href="javascript:void(0);" onclick="javascript: OpenIFrameWindow('新增库房','WarehouseEdit.aspx', '560px', '450px');"><i class="iconfont">&#xe726;</i>新增库房</a>
                </div>
            </div>
            <div class="Honor_management">
                <table class="W_form" id="tb_WarehouseList">
                    <thead>
                        <tr class="trth">
                            <th class="number">序号</th>
                            <th class="Project_name">库房名称</th>
                            <th class="">创建时间</th>
                            <th class="">设备分类</th>
                            <th class="">管理员</th> 
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
    $(document).ready(function () {
        //获取数据
        getData(1);
    });
    //获取数据
    function getData(startIndex) {
        //初始化序号 
        pageNum = (startIndex - 1) * 10 + 1;
        var name=$("#search_w").val();
        $.ajax({
            url: WebServiceUrl + "/SystemSettings/Warehouse.ashx",//random" + Math.random(),//方法所在页面和方法名
            type: "post",
            async: false,
            dataType: "jsonp",
            jsonp: "jsoncallback",
            data: { warehousename: name, startIndex: startIndex, pageSize: 10, action: "GetDataPage" },
            success: OnSuccess,
            error: OnError
        });

    }

    function OnSuccess(json) {
        if (json.result.Status.toString() == "no") {
            $("#tb_WarehouseList tbody").html('<tr><td colspan="100"  style="text-align:center;">无内容</td></tr>');
        } else {
            $("#tb_WarehouseList tbody").html('');
            $("#tr_Warehouse").tmpl(json.result.Data.PagedData).appendTo("#tb_WarehouseList");
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
        $("#tb_WarehouseList tbody").html('<tr><td colspan="100"  style="text-align:center;">无内容</td></tr>');
    }

    function DeleteWarehouse(id) {
        layer.msg("确定要删除该库房?", {
            time: 0 //不自动关闭
            , btn: ['确定', '取消']
            , yes: function (index) {
                layer.close(index);
                $.ajax({
                    url: WebServiceUrl + "/SystemSettings/Warehouse.ashx",//random" + Math.random(),//方法所在页面和方法名
                    type: "post",
                    async: false,
                    dataType: "jsonp",
                    jsonp: "jsoncallback",
                    data: { "intID": id, "action": "DeleteWarehouse" },
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
