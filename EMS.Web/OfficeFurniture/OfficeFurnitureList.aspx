<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OfficeFurnitureList.aspx.cs" Inherits="EMS.Web.OfficeFurniture.OfficeFurnitureList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>办公家具管理</title>
    <link href="/css/style.css" rel="stylesheet" />
    <link href="/css/common.css" rel="stylesheet" />
    <link href="/css/iconfont.css" rel="stylesheet" />
    <link href="/css/animate.css" rel="stylesheet" />
    <script src="/js/jquery-1.11.2.min.js"></script>
    <script src="/js/layer/layer.js"></script>
    <script src="/js/Common.js"></script>
    <script src="/js/jquery-barcode.js"></script>
    <script src="/js/jquery.tmpl.js"></script>
    <script src="/js/PageBar.js"></script>
    <script id="tr_User" type="text/x-jquery-tmpl">
        <tr  class="Single">
            <td>${pageIndex()}</td>
            <td>${Storage}</td>
            <td>${AssetNumber}</td>
            <td>${AssetName}</td>
            <td>${CreateName}</td>
            <td>${Unit}</td>
            <td>${EquipStatusChange(EquipStatus)}</td>
            <%-- <td name="BarcodeInfo">${Barcode}</td>--%>
            <td>
                 <input name="hidEquipId" type="hidden" value="${Id}" />
                <input name="hidBarcode" type="hidden" value="${Barcode}" />
                <input name="AssetNumber" type="hidden" value="${AssetNumber}" />
                <input name="AssetName" type="hidden" value="${AssetName}" />
                <input name="AcquisitionDate" type="hidden" value="${AcquisitionDate}" />
                <input name="UseDepartment" type="hidden" value="${UseDepartment}" />
                <input name="Storage" type="hidden" value="${Storage}" />
                <input name="CreateName" type="hidden" value="${CreateName}" />
                <%--<span class=" ">
                <input type="button" class="Topic_btn" value="详情" onclick="OpenIFrameWindow('设备详情', '/Statistical/EquipDetailInfo.aspx?Id=${Id}', '70%', '650px')" />
            </span>
            <span class=" ">
                <input type="button" class="Topic_btn" value="打印条码" onclick="Print(this)"/>
            </span>--%>
            <%--    <span class=" ">{{if BorrowYN == 1}}
                <input type="button" class="Topic_btn" value="借用申请" onclick="ShenQing(this)" />
                    {{/if}}
                </span>--%>
                <span class=" ">
               <%--  {{if IsConsume == 0}}
                <input type="button" class="Topic_btn" value="报修" onclick="OpenIFrameWindow('报修', '../Order/RepairEdit.aspx?eqID=${Id}', '650px', '360px')" />
                    {{else}}
                {{if EquipStatus == 1 }}
                 {{if IsConsume == 0}}
                <input type="button" class="Topic_btn" value="报修" onclick="OpenIFrameWindow('报修', '../Order/RepairEdit.aspx?eqID=${Id}', '650px', '360px')" />
                    {{/if}}
                   {{/if}}
                   {{/if}}
                 {{/if}}--%>


                  {{if IsConsume == 0}}
                    {{if EquipStatus == 0 }}
                         <input type="button" class="Topic_btn" value="报修" onclick="OpenIFrameWindow('报修', '../Order/RepairEdit.aspx?eqID=${Id}', '650px', '360px')" />
                    {{/if}}
                      {{if EquipStatus != 0 }}
                           <input type="button" class="Topic_btn" value="报修" disabled="disabled" style="background:#ccc;" />
                      {{/if}}
                  {{/if}}
                  {{if IsConsume != 0}}
                          <input type="button" class="Topic_btn" value="报修" disabled="disabled" style="background:#ccc;" />
                   {{/if}}

                </span>
            </td>
        </tr>
    </script>
    <script id="ImportTemp" type="text/template">
        <div>
            <table class="PrintTable" style="margin-left: 20px; font-size: 16px; table-layout: fixed; empty-cells: show; border-collapse: collapse; border: 1px solid #000; color: #000;">
                <tr>
                    <td colspan="2" class="Center" style="text-align: center; border: 1px solid #000; padding: 10px; height: 44px; line-height: 21px; width: 126px;">北京建筑大学</td>
                    <td style="border: 1px solid #000; padding: 10px; height: 44px; line-height: 21px; width: 126px;">设备编号</td>
                    <td class="Center" style="text-align: center; border: 1px solid #000; padding: 10px; height: 44px; line-height: 21px; width: 126px;">${AssetNumber}</td>
                </tr>
                <tr>
                    <td style="border: 1px solid #000; padding: 10px; height: 44px; line-height: 21px; width: 126px;">资产名称</td>
                    <td style="border: 1px solid #000; padding: 10px; height: 44px; line-height: 21px; width: 126px;">${AssetName}</td>
                    <td style="border: 1px solid #000; padding: 10px; height: 44px; line-height: 21px; width: 126px;">购置日期</td>
                    <td style="border: 1px solid #000; padding: 10px; height: 44px; line-height: 21px; width: 126px;">${AcquisitionDate}</td>
                </tr>
                <tr>
                    <td style="border: 1px solid #000; padding: 10px; height: 44px; line-height: 21px; width: 126px;">领用单位</td>
                    <td style="border: 1px solid #000; padding: 10px; height: 44px; line-height: 21px; width: 126px;">${UseDepartment}</td>
                    <td style="border: 1px solid #000; padding: 10px; height: 44px; line-height: 21px; width: 126px;">办公室</td>
                    <td style="border: 1px solid #000; padding: 10px; height: 44px; line-height: 21px; width: 126px;">${Storage}</td>
                </tr>
                <tr>
                    <td style="border: 1px solid #000; padding: 10px; height: 44px; line-height: 21px; width: 126px;">负责人</td>
                    <td style="border: 1px solid #000; padding: 10px; height: 44px; line-height: 21px; width: 126px;">${CreateName}</td>
                    <td colspan="2" class="Center" style="text-align: center; border: 1px solid #000; padding: 10px; height: 44px; line-height: 21px; width: 126px;">${ImportBarcode}<div>${Barcode}</div>
                    </td>
                </tr>
            </table>
        </div>
    </script>
</head>
<body>
    <input type="hidden" id="hid_UserIDCard" runat="server" />
    <input type="hidden" id="hid_UserRoleID" runat="server" />
    <form id="form1" runat="server">
        <div class="Teaching_plan_management">
            <h1 class="Page_name">办公家具管理</h1>
            <div class="Operation_area">
                <div class="left_choice fl">
                    <ul>
                        <li class="Sear">办公室：<select id="sel_Room" name="sel_Room" class="search_w">
                            <option value="">全部</option>
                            <option value="0">未分配</option>
                        </select>
                            负责人：<select id="sel_User" name="sel_User" class="search_w">
                                <option value="">全部</option>
                                <option value="-1">无负责人</option>
                            </select>
                            <input type="text" id="ser_name" name="ser_name" class="search_w" placeholder="请输入资产名称" value="" />
                            <a class="sea" href="#" onclick="SearchData();" style="margin-left: 5px;">搜索</a>
                        </li>
                    </ul>
                </div>
                <div class="right_add fr">
                    <a id="OfficeFP" style="display: none;" class="add" href="javascript:void(0);" onclick="javascript:location.href = 'AssetsDistribution.aspx?type=2';"><i class="iconfont">&#xe726;</i>办公家具分配</a>
                </div>
            </div>
            <div class="Honor_management">
                <table class="W_form" id="tb_UserList">
                    <thead>
                        <tr class="trth">
                            <th class="number">序号</th>
                            <th class="Project_name">办公室</th>
                            <th>资产号</th>
                            <th>资产名称</th>
                            <th>负责人</th>
                            <th>计量单位</th>
                            <%-- <th class="Code">条形码</th>--%>
                            <th>设备状态</th>
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
            <asp:HiddenField ID="hidIsAdmin" runat="server" />
        </div>
    </form>
</body>
<script type="text/javascript">
    var serroomid = $('#sel_Room option:selected').val();
    var serequipowner = $('#sel_User option:selected').val();
    var serassetname = $("#ser_name").val().trim();
    $(document).ready(function () {
        if ($('#hidIsAdmin').val() == 'true') {
            //如果是管理员，显示分配按钮
            $('#OfficeFP').show();
        }
        BindSerDropDownList("sel_Room", WebServiceUrl + "/SystemSettings/Building.ashx", { action: "GetRoomInfoByType" }, true);//根据类型绑定房间信息
        BindSerDropDownList("sel_User", WebServiceUrl + "/Statistical/Statistical.ashx", { action: "GetOfficeFurOwner" }, true);//绑定负责人信息
        //获取数据
        SearchData();
    });
    //获取办公家具数据
    function getData(PageIndex) {
        //初始化序号 
        pageNum = (PageIndex - 1) * 10 + 1;
        $.ajax({
            type: "post",
            url: WebServiceUrl + "/Statistical/Statistical.ashx",//random" + Math.random(),//方法所在页面和方法名
            async: false,
            dataType: "jsonp",
            jsonp: "jsoncallback",
            data: {
                PageIndex: PageIndex,
                PageSize: 10,
                Type: "2",//办公家具
                SerRoomid: serroomid,
                SerEquipOwner: serequipowner,
                UserRoleID: $("#hid_UserIDCard").val(),
                EquipOwner: $("#hid_UserIDCard").val(),
                Name: serassetname,
                useridcard: $("#hid_UserIDCard").val(),
                action: "GetPageEquipDetail"
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
                    $("#tr_User").tmpl(json.result.Data.PagedData).appendTo("#tb_UserList");
                    //var dtJson = $.parseJSON(json.result.Data.PagedData);
                    //$("#tr_User").tmpl(dtJson.ds).appendTo("#tb_UserList");
                    //隔行变色以及鼠标移动高亮
                    $(".main-bd table tbody tr").mouseover(function () {
                        $(this).addClass("over");
                    }).mouseout(function () {
                        $(this).removeClass("over");
                    })
                    $(".main-bd table tbody tr:odd").addClass("alt");
                    //生成页码条方法（方法对象,页码条容器，当前页码，总页数，页码组容量，总行数）
                    makePageBar(getData, document.getElementById("pageBar"), json.result.Data.PageIndex, json.result.Data.PageCount, 8, json.result.Data.RowCount);
                    SwitchBarcode();
                }
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                $("#tb_UserList tbody").html('<tr><td colspan="100"  style="text-align:center;">无内容</td></tr>');
            }
        });
    }

    function SearchData() {
        serroomid = $('#sel_Room option:selected').val();
        serequipowner = $('#sel_User option:selected').val();
        serassetname = $("#ser_name").val().trim();
        getData(1);
    }
    //转换条形码
    function SwitchBarcode() {
        $.each($("#tb_UserList tbody").children(), function () {
            var td = $(this).find("[name='BarcodeInfo']");
            var code = $(td).html();
            var DIVCode = $("<div/>").empty().barcode(code, "code128", { barWidth: 1, barHeight: 30, showHRI: false });
            $(DIVCode).css("margin", "auto");
            td.empty().append(DIVCode);
        });
    }
    //打印
    function Print(obj) {
        var code = $(obj).parents().find("[name='hidBarcode']").val();
        var AssetNumber = $(obj).parents("td:first").find("[name='AssetNumber']").val();
        var AssetName = $(obj).parents("td:first").find("[name='AssetName']").val();
        var AcquisitionDate = $(obj).parents("td:first").find("[name='AcquisitionDate']").val();
        var UseDepartment = $(obj).parents("td:first").find("[name='UseDepartment']").val();
        //var StorageLocation1 = $(obj).parents("td:first").find("[name='StorageLocation1']").val();
        var Storage = $(obj).parents("td:first").find("[name='Storage']").val();
        var CreateName = $(obj).parents("td:first").find("[name='CreateName']").val();

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
        content = content.replace("${Storage}", Storage);
        content = content.replace("${CreateName}", CreateName);
        content = content.replace("${Barcode}", code);
        var newWindow = window.open("打印窗口", "_blank");//打印窗口要换成页面的url
        var docStr = content;
        newWindow.document.write(docStr);
        newWindow.document.close();
        newWindow.print();
        newWindow.close();
    }

    function ShenQing(obj) {
        var ID = $(obj).parents(".Single").find("[name='hidEquipId']").val();
        $.ajax({
            type: "Post",
            url: WebServiceUrl + "/Statistical/Statistical.ashx",//random" + Math.random(),//方法所在页面和方法名
            //async: false,
            dataType: 'jsonp',
            jsonp: 'jsoncallback',
            data: { "Id": ID, "EquipStatus": 5, "action": "UpdateStatus" },
            success: function (json) {
                if (json.result.Status == "error") {
                    layer.msg(json.result.Msg);
                    return;
                }
                if (json.result.Status == "no") {
                    layer.msg(json.result.Msg);
                    return;
                }
                if (json.result.Status == "ok") {
                    layer.msg("申请已提交");
                    getData(1);
                    return;
                }

            },
            error: OnError
        });
        getData(1);
    }

    //错误处理
    function OnError(XMLHttpRequest, textStatus, errorThrown) {
        //alert(XMLHttpRequest + "-" + textStatus + "-" + errorThrown);
    }
</script>
</html>
