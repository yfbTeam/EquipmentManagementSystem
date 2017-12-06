<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EquipStock.aspx.cs" Inherits="EMS.Web.Statistical.EquipStock" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>设备库存</title>
    <link href="../css/common.css" rel="stylesheet" />
    <link href="../css/style.css" rel="stylesheet" />
    <link href="../css/iconfont.css" rel="stylesheet" />
    <link href="../css/animate.css" rel="stylesheet" />

    <script src="../js/Common.js"></script>
    <script src="../js/jquery-1.11.2.min.js"></script>
    <script src="/js/layer/layer.js"></script>
    <script src="../js/jquery.tmpl.js"></script>
    <script src="../js/PageBar.js"></script>
    <script src="../js/tz_slider.js"></script>
    <script src="../js/layer/layer.js"></script>
    <script src="../js/json2.js"></script>

    <script id="trTemp" type="text/x-jquery-tmpl">
        <tr class="Single">
            <%--<td class="checkbox">
                            <input type="checkbox" /></td>--%>
            <td>${pageIndex()}</td>
            <td><a href="javascript: location.href = 'EquipClassInfo.aspx?Id=${AssetsClassName}';"><span title="${AssetsClassName}">${NameLengthUpdate(AssetsClassName,15)}</span></a></td>
            <td>${IsConsumeToStr(IsConsume)}</td>
            <%--<td>${WJCCount}</td>
            <td>${YJCCount}</td>--%>
            <td>${Total}</td>
            <td>${Unit}</td>
            <td>
                <span class=" ">
                    <input type="button" class="Topic_btn" value="查看" onclick="javascript: location.href = 'EquipClassInfo.aspx?Id=${AssetsClassName}';" />
                </span>
            </td>
        </tr>
    </script>

</head>

<body>
    <form id="form1" runat="server">
        <div class="Teaching_plan_management">
            <h1 class="Page_name">设备库存</h1>
            <h2><span id="EquipCount"></span>&nbsp;<span id="EquipCount0"></span>&nbsp;<span id="EquipCount1"></span>&nbsp;<span id="EquipCount2"></span></h2>
            <div class="Operation_area">
                <div class="left_choice fl">
                    <ul>
                        <%--<li class="Select">仓库名称：
								<select class="option" id="Warehouse">
                                    <option value=''>全部</option>
                                </select>
                        </li>--%>
                        <%--<li class="Select">类型：
							<select class="option" id="Type">
                                <option value=''>全部</option>
                                <option value='0'>非耗材</option>
                                <option value='1'>耗材</option>
                            </select>
                        </li>--%>
                        <li class="Sear">
                            <input id="Name" type="text" name="search_w" class="search_w" placeholder="请输入分类名称" value=""/>
                        </li>
                        <li>
                            <a class="btn1" href="#" onclick="javascript:SearchData();">搜索</a>
                        </li>
                    </ul>
                </div>
                <div class="right_add fr">
                    <a class="add" href="javascript:ExportEquipExcel();"><i class="iconfont">&#xe726;</i>导出</a>
                    <a class="add" href="javascript:OpenIFrameWindow('新增仪器设备', 'EquipEdit.aspx?Type=Add', '700px', '500px');"><i class="iconfont">&#xe726;</i>新增仪器设备</a>
                    <a class="add" href="javascript:ImportEquip();"><i class="iconfont">&#xe726;</i>仪器设备导入</a>
                </div>
            </div>
            <div class="Honor_management">
                <table class="W_form">
                    <thead>
                        <tr class="trth">
                            <%--<th class="checkbox">
                                <input type="checkbox"></th>--%>
                            <th>序号</th>
                            <th>资产分类名称</th>
                            <th>是否耗材</th>
                            <%--<th>品牌及规格型号</th>
                            <th>存放地点</th>
                            <th>库存数量</th>
                            <th>借出数量</th>--%>
                            <th>总数</th>
                            <th>单位</th>
                            <th>操作</th>
                        </tr>
                    </thead>
                    <tbody id="TbodyList">
                    </tbody>

                </table>
            </div>


        </div>
        <!--分页页码开始-->
        <div class="paging">
            <span id="pageBar"></span>
        </div>
        <!--分页页码结束-->
        <asp:HiddenField ID="hidUserLgoinName" runat="server" />
        <asp:HiddenField ID="hidExcelCenter" runat="server" />
    </form>
</body>
<script type="text/javascript">
    var Name = "";
    var PageSize = 10;
    $(document).ready(function () {
        //加载仓库
        //BindWarehouse();
        //GetList(1);
        SearchData();
    });
    
    //加载仓库
    function BindWarehouse() {
        $.ajax({
            type: "Post",
            url: WebServiceUrl + "/SystemSettings/Warehouse.ashx",//random" + Math.random(),//方法所在页面和方法名
            //async: false,
            dataType: "jsonp",
            jsonp: "jsoncallback",
            data: { "warehousename": "", "action": "GetData" },
            success: function (json) {
                $("#Warehouse").empty();
                $("#Warehouse").append("<option value=''>全部</option>");
                if (json.result.Status == "error") {
                    //layer.msg(json.result.Msg);
                    return;
                }
                if (json.result.Status == "no") {
                    //layer.msg(json.result.Msg);
                    return;
                }
                if (json.result.Status == "ok") {
                    $.each(json.result.Data.PagedData, function (i, item) {
                        var option = "<option value='" + item.Id + "'>" + item.Name + "</option>"
                        $("#Warehouse").append(option);
                    });
                }
            },
            error: OnError
        });
    }
    function SearchData() {
        //初始化序号 
        Name = $('#Name').val().trim();
        GetList(1);
    }
    //获取数据
    function GetList(PageIndex) {
        //初始化序号 
        pageNum = (PageIndex - 1) * 10 + 1
        //Warehouse = $('#Warehouse option:selected').val();
        //Name = $('#Name').val().trim();
        //UserLgoinName = $('#hidUserLgoinName').val();
        //Type = $('#Type option:selected').val();
        $.ajax({
            type: "Post",
            url: WebServiceUrl + "/Statistical/Statistical.ashx",
            //async: false,
            dataType: "jsonp",
            jsonp: "jsoncallback",
            //data: { "PageIndex": PageIndex, "PageSize": PageSize, "Name": Name, "WarehouseId": Warehouse, "Type": Type },
            data: { "PageIndex": PageIndex, "PageSize": PageSize, "Name": Name, "action": "GetPageStock" },
            success: function (json) {
                if (json.result.Status == "error") {

                    return;
                }
                if (json.result.Status == "no") {
                    //$("#ulList").html("<tr><td style=\"text-align:center;width:100%;\">" + json.result.Msg + "</td></tr>");
                    //alert(json.result.Msg);
                    $("#TbodyList").html('');
                    //生成页码条方法（方法对象,页码条容器，当前页码，总页数，页码组容量，总行数）
                    makePageBar(GetList, document.getElementById("pageBar"), 1, 1, 8, 0);
                    
                    return;
                }
                if (json.result.Status == "ok") {

                    $("#TbodyList").html('');
                    //var ds = json.result.Data.PagedData[0];
                    //var dsJson = $.parseJSON(ds);
                    //alert(dsJson.ds[0].Name);
                    $("#trTemp").tmpl(json.result.Data.PagedData).appendTo("#TbodyList");
                    //生成页码条方法（方法对象,页码条容器，当前页码，总页数，页码组容量，总行数）
                    makePageBar(GetList, document.getElementById("pageBar"), json.result.Data.PageIndex, json.result.Data.PageCount, 8, json.result.Data.RowCount);

                    $("#EquipCount").html("总数量：" + json.result2.Data);
                    $("#EquipCount0").html("教学设备数量：" + json.result3.Data);
                    $("#EquipCount1").html("科研设备数量：" + json.result4.Data);
                    $("#EquipCount2").html("办公设备数量：" + json.result5.Data);
                }

            },
            error: OnError
        });

    }
    //各行变色
    function RowColor() {

    }
    //错误处理
    function OnError(XMLHttpRequest, textStatus, errorThrown) {
        //layer.msg('');
    }

    //导入设备Excel
    function ImportEquip() {
        OpenIFrameWindow('导入教师', '../Statistical/ImportEquip.aspx', '500px', '200px');
        //return;
    }

    //导出设备Excel
    function ExportEquipExcel() {
        OpenIFrameWindow('导出数据', 'ExportEquip.aspx', '600px', '170px');
    }
</script>
</html>
