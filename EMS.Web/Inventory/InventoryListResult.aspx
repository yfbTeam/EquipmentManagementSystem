<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InventoryListResult.aspx.cs" Inherits="EMS.Web.Inventory.InventoryListResult" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>盘点单</title>
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
            <td>${AssetNumber}</td>
            <td>${AssetName}</td>
            {{if Type == 2}}
                 <td>${CreateName}</td>
            {{/if}}             
            {{if Type == 0}}
                 <td>${EquipStatusChange(Status)}</td>
            {{/if}} 
            <td>${Unit}</td>
            <td>${Storage}</td>   
            <td>${EquipSource=='0'?'本院资产':'资产系统'}</td>                
            <td>{{if loss == 0}}<span style="color:red;">拟盘亏</span>{{else}}<span>未盘亏</span>{{/if}}</td>
            <td>{{if loss == 0}}<input type="button" class="Topic_btn" value="盘回" onclick="javascript: DiskBackEquip('${Id}');"/>{{/if}}</td>
        </tr>
    </script>     
    <script id="tr_GroupRoom" type="text/x-jquery-tmpl">
        <tr>
            <td>${pageIndex()}</td>
            <td>${Name}</td>
            <td>${InventoryNo}</td>
            <td>${Quantity}</td>
            <td>${RealQuantity}</td>
            {{if Type == 0}}
                   <td>${BorrowQuantity}</td>
            {{/if}}            
            <td>${LossQuantity}</td>
            <td>${Storage}</td>
            <td>${TwoUserName}</td>             
        </tr>
    </script>
</head>
<body>
    <input type="hidden" id="hid_Id" runat="server" />
    <input type="hidden" id="hid_Type" runat="server" />
    <input type="hidden" id="hid_UserIDCard" runat="server" />
    <form id="form1" runat="server">
        <div class="Teaching_plan_management">
            <input class="Topic_btn" type="button" value="返回" onclick="javascript: location.href = 'Inventory.aspx';" style="float: right;" />
            <h1 class="Page_name">盘点单</h1><span id="span_countinfo"></span>
            <div class="Operation_area">
                <div class="left_choice fl">
                    <ul>
                        <li class="Sear">
                            <label style="display:none;"><input type="checkbox" id="ck_isRoomGroup" name="ck_isRoomGroup" onchange="SearchData();"/>按房间分组</label>
                            <%--<select id="sel_Room" name="sel_Room" class="search_w"></select>--%>
                            设备来源：<select id="sel_equipsource" name="sel_equipsource" class="search_w">
                                <option value="" selected="selected">全部</option>
                                <option value="0">本院资产</option>
                                <option value="1">资产系统</option>
                            </select>
                            是否拟盘亏：<select id="sel_isloss" name="sel_isloss" class="search_w">
                                <option value="" selected="selected">全部</option>
                                <option value="0">拟盘亏</option>
                                <option value="1">未盘亏</option>
                            </select>                            
                            <input type="text" id="ser_name" name="ser_name" class="search_w" placeholder="请输入资产名称" value="" />
                            <a class="sea" href="#" onclick="SearchData();" style="margin-left:5px;">搜索</a>
                        </li>
                    </ul>
                </div>
                <div class="right_add fr">
                    <a class="add" href="javascript:void(0);" onclick="javascript:ExportInventoryExcel(1);"><i class="iconfont">&#xe726;</i>导出Excel</a>
                    <asp:Button runat="server" ID="ExportInventoryEquip" style="display:none;" Text="导出Excel"  OnClick="ExportInventoryEquip_Click"/>
                </div>
            </div>
            <div class="Honor_management">                
                <table class="W_form" id="tb_UserList">
                    <thead>
                        <tr class="trth">
                            <th class="number">序号</th>
                            <%--<th class="Project_name">盘点名称</th>
                            <th>盘点单号</th>
                            <th>账面数量</th>
                            <th>实盘数量</th>
                            <th>借出数量</th>
                            <th>缺失数量</th>--%>
                            <th class="Project_name">资产号</th>
                            <th class="">资产名称</th>
                            <th>负责人</th>
                            <th class="">状态</th>
                            <th>计量单位</th>
                            <th>存放地点</th>  
                            <th>设备来源</th>
                            <th>是否拟盘亏</th>   
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
            <asp:HiddenField ID="hidExcelCenter" runat="server" />
        </div>
    </form>
</body>
<script type="text/javascript">
    var isRoomGroup = $("#ck_isRoomGroup").is(":checked").toString();
    var serisloss = "", equipsource="", assetname = "";
    $(document).ready(function () {
        getCountInfo();
        //获取数据
        SearchData();
    });
    function SearchData() {
        isRoomGroup = $("#ck_isRoomGroup").is(":checked").toString();
        serisloss = $('#sel_isloss option:selected').val();
        equipsource = $('#sel_equipsource option:selected').val();
        assetname = $("#ser_name").val().trim();
        var $thr = $('#tb_UserList tr');

        //if ($("#ck_isRoomGroup").is(":checked")) {
        //    $thr.find('th:eq(7)').show();
        //    $thr.find('th:eq(8)').show();
        //} else {
        //    $thr.find('th:eq(7)').hide();
        //    $thr.find('th:eq(8)').hide();
        //} 
        var type=$("#<%=hid_Type.ClientID%>").val();
        if (type == "0") {
            $thr.find('th:eq(3)').hide();
            $thr.find('th:eq(4)').show();
        } else if (type == "2") {
            $thr.find('th:eq(3)').show();
            $thr.find('th:eq(4)').hide();
        } else {
            $thr.find('th:eq(3)').hide();
            $thr.find('th:eq(4)').hide();
        }
        getData(1);
    }
    //获取盘点数据
    function getData(PageIndex) {
        //初始化序号 
        pageNum = (PageIndex - 1) * 10 + 1;        
        var RoomId = '';// $('#sel_Room option:selected').val();
        $.ajax({
            type: "post",
            url: WebServiceUrl + "/Inventory/Inventory.ashx",//random" + Math.random(),//方法所在页面和方法名
            async: false,
            dataType: "jsonp",
            jsonp: "jsoncallback",
            data: {
                PageIndex: PageIndex, PageSize: 10,
                PlanId: $("#hid_Id").val(),
                IsRoomGroup: isRoomGroup == "false" ? "" : isRoomGroup,
                RoomId: RoomId,
                serisloss: serisloss,
                equipsource: equipsource,
                assetname: assetname,
                type:$("#<%=hid_Type.ClientID%>").val(),
                useridcard: $("#hid_UserIDCard").val(),
                action: "GetInvenListDataPage"
            },
            success: function LoadData(json) {
                if (json.result.Status == "error") {
                    $("#tb_UserList tbody").html('<tr><td colspan="100"  style="text-align:center;">无内容</td></tr>');
                    return;
                }
                if (json.result.Status == "no") {
                    $("#tb_UserList tbody").html('<tr><td colspan="100"  style="text-align:center;">无内容</td></tr>');
                    //生成页码条方法（方法对象,页码条容器，当前页码，总页数，页码组容量，总行数）
                    makePageBar(getData, document.getElementById("pageBar"), 1, 1, 8, 0);
                    return;
                }
                if (json.result.Status == "ok") {
                    $("#tb_UserList tbody").html('');
                    var dtJson = json.result.Data.PagedData;
                    $("#tr_User").tmpl(dtJson).appendTo("#tb_UserList");
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
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                $("#tb_UserList tbody").html('<tr><td colspan="100"  style="text-align:center;">无内容</td></tr>');
            }
        });
    }
    function ExportInventoryExcel(PageIndex) {
        //初始化序号 
        pageNum = (PageIndex - 1) * 10 + 1;
        var RoomId = '';// $('#sel_Room option:selected').val();    
        $.ajax({
            type: "post",
            url: WebServiceUrl + "/Inventory/Inventory.ashx",//random" + Math.random(),//方法所在页面和方法名
            async: false,
            dataType: "jsonp",
            jsonp: "jsoncallback",
            data: {
                PageIndex: PageIndex, PageSize: 10,
                PlanId: $("#hid_Id").val(),
                IsRoomGroup: isRoomGroup == "false" ? "" : isRoomGroup,
                RoomId: RoomId,
                serisloss: serisloss,
                equipsource: equipsource,
                assetname: assetname,
                type: $("#<%=hid_Type.ClientID%>").val(),
                useridcard: $("#hid_UserIDCard").val(),
                ispage: false,
                action: "GetInvenListDataPage"
            },
            success: function LoadData(json) {               
                if (json.result.Status == "ok") {                    
                    $("#hidExcelCenter").val(JSON.stringify(json.result.Data.PagedData));
                    document.getElementById("ExportInventoryEquip").click();
                }
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
               
            }
        });
    }
    //获取盘点统计信息
    function getCountInfo() {
        $.ajax({
            type: "post",
            url: WebServiceUrl + "/Inventory/Inventory.ashx",//random" + Math.random(),//方法所在页面和方法名
            async: false,
            dataType: "jsonp",
            jsonp: "jsoncallback",
            data: {
                PlanId: $("#hid_Id").val(),
                action: "GetInvenListCount"
            },
            success: function LoadData(json) {
                if (json.result != "") {
                    var info = json.result;
                    $("#span_countinfo").html("盘点单名称：" + info.Name + "   盘点单号：" + info.InventoryNo
                                            + "   实盘数量：" + info.RealQuantity + "  拟盘亏数量：<span style='color:red;'>" + info.LossQuantity+"</span>");
                }                
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
               
            }
        });
    }
    function DiskBackEquip(itemid) {
        layer.msg("确定盘回该资产么？", {
            time: 0 //不自动关闭
           , btn: ['确定', '取消']
           , yes: function (index) {
               layer.close(index);
               $.ajax({
                   url: WebServiceUrl + "/Inventory/Inventory.ashx",
                   type: "post",
                   async: false,
                   dataType: "jsonp",
                   jsonp: "jsoncallback",
                   data: {
                       itemid: itemid,
                       useridcard: $("#<%=hid_UserIDCard.ClientID%>").val(),
                       action: "DiskBackEquip"
            },
                     success: function (json) {
                         if (json.result != "0") {
                             layer.msg("盘回成功！");
                             getData(1);
                             getCountInfo();
                         } else {
                             layer.msg("盘回失败！");
                         }
                     },
                     error: function (XMLHttpRequest, textStatus, errorThrown) {
                         layer.msg("盘回失败！");
                     }
                 });
           }
        });     
    }
</script>
</html>
