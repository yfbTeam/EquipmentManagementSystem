<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EquipClassInfo1.aspx.cs" Inherits="EMS.Web.Statistical.EquipClassInfo1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>设备分类信息</title>
    <link href="../css/common.css" rel="stylesheet" />
    <link href="../css/style.css" rel="stylesheet" />
    <link href="../css/iconfont.css" rel="stylesheet" />
    <link href="../css/animate.css" rel="stylesheet" />

    <script src="../js/Common.js"></script>
    <script src="../js/jquery-1.11.2.min.js"></script>
    <script src="../js/jquery.tmpl.js"></script>
    <script src="../js/PageBar.js"></script>
    <script src="../js/tz_slider.js"></script>
    <script src="../js/layer/layer.js"></script>
    <script src="../js/jquery-barcode.js"></script>
  
</head>

<body>
    <form id="form1" runat="server">
        <div class="Teaching_plan_management">
            <h1 class="Page_name">设备信息<span id="Name"></span></h1>
            <div class="Operation_area">
                <div class="left_choice fl">
                    <ul>
                        <li class="Select">设备来源：
                            <select class="option" id="EquipSource">
                                <option value=''>全部</option>
                                <option value='0'>本院资产</option>
                                <option value='1'>资产系统</option>
                            </select>
                        </li>
                        <li>
                            <a class="btn1" href="#" onclick="javascript:SearchData();">搜索</a>
                        </li>
                        
                    </ul>
                </div>
                <div class="right_add fr">
                    <a class="add" href="javascript:ExportEquipExcel();"><i class="iconfont">&#xe726;</i>导出</a>
                    <a class="add" href="javascript:OpenIFrameWindow('新增仪器设备', 'EquipEdit.aspx?Type=Add', '760px', '500px');"><i class="iconfont">&#xe726;</i>新增仪器设备</a>
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
                            <th>资产号</th>
                            <th>资产名称</th>
                            <th>资产类别</th>
                            <th>设备状态</th>
                            <th>计量单位</th>
                            <th>存放地点</th>
                            <th>设备来源</th>
                            <%--<th class="Code">条形码</th>--%>
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
        <asp:HiddenField ID="hidId" runat="server" />
        <asp:HiddenField ID="hidType" runat="server" />
    </form>
</body>
<script type="text/javascript">
    var EquipSource = "";//设备来源
    var Name = "";
    var ClassName = "";
    var EquipType = "";
   // var ChangePageCount="EquipClassInfo";
    $(document).ready(function () {
        //if ($("#hidId").val() != "") {
        //    $("#Name").html("--" + $("#hidId").val());
        //}
        SearchData();

    });
    //搜索
    function SearchData() {
        //初始化序号 
        EquipSource = $('#EquipSource option:selected').val();
        Name = "";
        ClassName = "";
        EquipType = "";
        GetList(1);
    }

    //获取数据
    function GetList(PageIndex) {
        //初始化序号 
        pageNum = (PageIndex - 1) * 10 + 1;
        PageSize = 10;
        if (document.getElementById("hidPageSize")!=null) {
            PageSize=$("#hidPageSize").val();
        }
        $.ajax({
            type: "Post",
            url: WebServiceUrl + "/Statistical/Statistical.ashx",//random" + Math.random(),//方法所在页面和方法名
            //async: false,
            dataType: "jsonp",
            jsonp: "jsoncallback",
            data: {
                "PageIndex": PageIndex, "PageSize": PageSize, "AssetsClassName": ClassName, "Name": Name, "Type": EquipType
                , "EquipSource": EquipSource, "action": "GetPageEquipDetail"
            },
            success: function (json) {
                if (json.result.Status == "error") {
                    //layer.msg(json.result.Msg);
                    return;
                }
                if (json.result.Status == "no") {
                    //layer.msg(json.result.Msg);
                    $("#TbodyList").html('');
                    //生成页码条方法（方法对象,页码条容器，当前页码，总页数，页码组容量，总行数）
                    makePageBar(GetList, document.getElementById("pageBar"), 1, 1, 8, 0);

                    return;
                }
                if (json.result.Status == "ok") {
                    $("#TbodyList").html('');
                    $("#trTemp").tmpl(json.result.Data.PagedData).appendTo("#TbodyList");
                    //生成页码条方法（方法对象,页码条容器，当前页码，总页数，页码组容量，总行数）
                    makePageBar(GetList, document.getElementById("pageBar"), json.result.Data.PageIndex, json.result.Data.PageCount, 8, json.result.Data.RowCount);
                    SwitchBarcode();
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
        //layer.msg("");
    }
    //转换条形码
    function SwitchBarcode() {
        $.each($("#TbodyList").children(), function () {
            var td = $(this).find("[name='BarcodeInfo']");
            var code = $(td).html();
            var DIVCode = $("<div/>").empty().barcode(code, "code128", { barWidth: 1, barHeight: 30, showHRI: false });
            $(DIVCode).css("margin", "auto");
            td.empty().append(DIVCode);
            
        });
    }
    //打印
    function Print(obj) {
        var code = $(obj).parents(".Single").find("[name='hidBarcode']").val();
        var AssetNumber = $(obj).parents("td:first").find("[name='AssetNumber']").val();
        var AssetName = $(obj).parents("td:first").find("[name='AssetName']").val();
        var AcquisitionDate = $(obj).parents("td:first").find("[name='AcquisitionDate']").val();
        var UseDepartment = $(obj).parents("td:first").find("[name='UseDepartment']").val();
        //var StorageLocation1 = $(obj).parents("td:first").find("[name='StorageLocation1']").val();
        var WarehouseName = $(obj).parents("td:first").find("[name='WarehouseName']").val();
        var UsePeople = $(obj).parents("td:first").find("[name='UsePeople']").val();

        var DIVCodeP = $("<div/>");
        var DIVCode = $("<div/>");
        $(DIVCode).empty().barcode(code, "code128", { barWidth: 1, barHeight: 40, showHRI: false });
        $(DIVCode).css("margin", "auto");
        $(DIVCodeP).append(DIVCode);
        //alert($(DIVCodeP).html())
        var content = $("#ImportTemp").html();
        content = content.replace("${ImportBarcode}", $(DIVCodeP).html());
        content = content.replace("${AssetNumber}", AssetNumber);
        content = content.replace("${AssetName}", AssetName);
        content = content.replace("${AcquisitionDate}", DateTimeConvert(AcquisitionDate));
        content = content.replace("${UseDepartment}", UseDepartment);
        //content = content.replace("${StorageLocation1}", StorageLocation1);
        content = content.replace("${WarehouseName}", WarehouseName);
        content = content.replace("${UsePeople}", UsePeople);
        content = content.replace("${Barcode}", code);
        var newWindow = window.open("打印窗口", "_blank");//打印窗口要换成页面的url
        var docStr = content;
        newWindow.document.write(docStr);
        newWindow.document.close();
        newWindow.print();
        newWindow.close();
    }

    //导入设备Excel
    function ImportEquip() {
        OpenIFrameWindow('导入数据', '../Statistical/ImportEquip.aspx', '500px', '200px');
        //return;
    }

    //导出设备Excel
    function ExportEquipExcel() {
        OpenIFrameWindow('导出数据', 'ExportEquip.aspx', '600px', '170px');
    }
</script>
<script id="trTemp" type="text/x-jquery-tmpl">
    <tr class="Single">
        <%--<td class="checkbox">
                        <input type="checkbox" /></td>--%>
        <td>${pageIndex()}</td>
        <td>${AssetNumber}</td>
        <td><a href="javascript:OpenIFrameWindow('设备详情','EquipDetailInfo.aspx?Id=${Id}','70%','500px');"><span title="${AssetName}">${NameLengthUpdate(AssetName,15)}</span></a></td>
        <td>${EquipTypeToStr(Type)}</td>
        <td>${EquipStatusChange(EquipStatus)}</td>
        <td>${Unit}</td>
        <%--<td>${StorageLocation1}</td>--%>
        <td>${WarehouseName}</td>
        <td>${EquipSourceToStr(EquipSource)}</td>
        <%--<td name="BarcodeInfo">${Barcode}</td>--%>
        <td>
            <input name="hidBarcode" type="hidden" value="${Barcode}" />
            <input name="AssetNumber" type="hidden" value="${AssetNumber}" /> 
            <input name="AssetName" type="hidden" value="${AssetName}" /> 
            <input name="AcquisitionDate" type="hidden" value="${AcquisitionDate}" /> 
            <input name="UseDepartment" type="hidden" value="${UseDepartment}" /> 
            <%--<input name="StorageLocation1" type="hidden" value="${StorageLocation1}" /> --%>
            <input name="WarehouseName" type="hidden" value="${WarehouseName}" /> 
            <input name="UsePeople" type="hidden" value="${UsePeople}" /> 
            <span class=" ">
                <input type="button" class="Topic_btn" value="详情" onclick="OpenIFrameWindow('设备详情','EquipDetailInfo.aspx?Id=${Id}','80%','80%')" />
            </span>
            <span class=" ">
                <input type="button" class="Topic_btn" value="修改" onclick="OpenIFrameWindow('编辑仪器设备', 'EquipEdit.aspx?Type=Edit&Id=${Id}', '760px', '500px')" />
            </span>
            <%--<span class=" ">
                <input type="button" class="Topic_btn" value="打印条码" onclick="Print(this)"/>
            </span--%>
        </td>
    </tr>
</script>
<script id="ImportTemp" type="text/template">
    <div>
        <table class="PrintTable" style="margin-left:20px;font-size: 16px;table-layout: fixed;empty-cells: show;border-collapse: collapse;border: 1px solid #000;color: #000;">
            <tr>
                <td colspan="2" class="Center" style="text-align:center;border: 1px solid #000;padding: 10px;height: 44px;line-height:21px;width:126px;">北京建筑大学</td>
                <td style=" border: 1px solid #000;padding: 10px;height: 44px;line-height:21px;width:126px;">设备编号</td>
                <td class="Center" style="text-align:center;border: 1px solid #000;padding: 10px;height: 44px;line-height:21px;width:126px;">${AssetNumber}</td>
            </tr>
            <tr>
                <td style=" border: 1px solid #000;padding: 10px;height: 44px;line-height:21px;width:126px;">资产名称</td>
                <td style=" border: 1px solid #000;padding: 10px;height: 44px;line-height:21px;width:126px;">${AssetName}</td>
                <td style=" border: 1px solid #000;padding: 10px;height: 44px;line-height:21px;width:126px;">购置日期</td>
                <td style=" border: 1px solid #000;padding: 10px;height: 44px;line-height:21px;width:126px;">${AcquisitionDate}</td>
            </tr>
            <tr>
                <td style=" border: 1px solid #000;padding: 10px;height: 44px;line-height:21px;width:126px;">领用单位</td>
                <td style=" border: 1px solid #000;padding: 10px;height: 44px;line-height:21px;width:126px;">${UseDepartment}</td>
                <td style=" border: 1px solid #000;padding: 10px;height: 44px;line-height:21px;width:126px;">存放地点</td>
                <%--<td style=" border: 1px solid #000;padding: 10px;height: 44px;line-height:21px;width:126px;">${StorageLocation1}</td>--%>
                <td style=" border: 1px solid #000;padding: 10px;height: 44px;line-height:21px;width:126px;">${WarehouseName}</td>
            </tr>
            <tr>
                <td style=" border: 1px solid #000;padding: 10px;height: 44px;line-height:21px;width:126px;">领用人</td>
                <td style=" border: 1px solid #000;padding: 10px;height: 44px;line-height:21px;width:126px;">${UsePeople}</td>
                <td colspan="2" class="Center" style="text-align:center;border: 1px solid #000;padding: 10px;height: 44px;line-height:21px;width:126px;">${ImportBarcode}<div>${Barcode}</div></td>
            </tr>
        </table>
    </div>
</script>
</html>
