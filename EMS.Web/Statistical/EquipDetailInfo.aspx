<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EquipDetailInfo.aspx.cs" Inherits="EMS.Web.Statistical.EquipDetailInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>设备详情</title>
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

    <style type="text/css">
        .auto-style1 {
            width: 169px;
        }
        .auto-style2 {
            width: 217px;
        }
        .auto-style3 {
            width: 209px;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
    <div >
        <table class="InfoTable" style="table-layout:auto;">
            
            <tbody><tr>
                <td class="auto-style1">资产号</td><td id="AssetNumber" class="auto-style2"></td>
                <td class="auto-style1">禁用/启用</td><td id="UseStatus" class="auto-style2"></td>
                <td colspan="2" rowspan="6" style="position:relative;margin:1em 0px;">
                    <a id="EquipHref" target="_blank"><img id="EquipImg"  style="position:absolute;left:0;right:0;top:0;bottom:0;margin:auto;height:185px;width:100%;"/></a>
                </td>
                
            </tr>
            <tr>
                <td class="auto-style1">分类号</td><td id="ClassNumber" class="auto-style2"></td>
                 <td class="auto-style1">国际分类代码</td><td id="IntlClassCode" class="auto-style2"></td>
              </tr>
            <tr>
                <td class="auto-style1">计量单位</td><td id="Unit" class="auto-style2"></td>
                 <td class="auto-style1">使用方向</td><td id="UsageDirection" class="auto-style2"></td>
              </tr>
            <tr>
               <td class="auto-style1">资产名称</td>
              <td id="AssetName" class="auto-style2"></td>
              <td class="auto-style3">设备状态</td>
              <td id="EquipStatus"></td>
              </tr>
            <tr>
                <td class="auto-style1">资产分类名称</td>
              <td id="AssetsClassName" class="auto-style2"></td>
              <td class="auto-style3">国际分类名称</td>
              <td id="IntlClassName"></td>
              </tr>
            <tr>
               <td class="auto-style1">使用状况</td>
              <td id="UsageStatus" class="auto-style2"></td>
              <td class="auto-style3">教育部报表使用方向</td>
              <td id="JYBBBSYFX"></td>
              </tr>
            <tr>
              <td class="auto-style1">取得方式</td><td id="AcquisitionMethod" class="auto-style2"></td>
                <td class="auto-style3">取得日期</td><td id="AcquisitionDate"></td>
                <td class="auto-style1">品牌及规格型号</td><td id="BrandStandardModel" class="auto-style2"></td>
            </tr>
            <tr>
              <td class="auto-style3">设备用途</td><td id="EquipmentUse"></td>
                <td class="auto-style1">使用/管理部门</td><td id="UseDepartment " class="auto-style2"></td>
                <td class="auto-style3">使用人</td><td id="UsePeople"></td>
            </tr>
            <tr>
              <td class="auto-style1">厂家</td><td id="Factory" class="auto-style2"></td>
                <td class="auto-style3">存放地点</td><td id="StorageLocation">0</td>
                <td class="auto-style1">价值类型</td><td id="WorthType" class="auto-style2"></td>
            </tr>
            <tr>
                 <td class="auto-style3">使用性质</td><td id="UseNature"></td>
                <td class="auto-style1">价值</td><td id="Worth" class="auto-style2"></td>
                <td class="auto-style3">财务入账形式</td><td id="FinanceRecordType"></td>
            </tr>
            <tr>
                 <td class="auto-style1">财政性资金</td><td id="FiscalFunds" class="auto-style2"></td>
                <td class="auto-style3">非财政性资金</td><td id="NonFiscalFunds"></td>
                 <td class="auto-style1">财政入账日期</td><td id="FinanceRecordDate" class="auto-style2"></td>
            </tr>
            <tr>
                <td class="auto-style3">凭证号</td><td id="VoucherNumber"></td>
                <td class="auto-style1">使用年限（月）</td><td id="UseTime" class="auto-style2"></td>
                <td class="auto-style3">预计报废时间</td><td id="ExpectedScrapDate"></td>
            </tr>
            <tr>
                 <td class="auto-style1">折旧状态</td><td id="DepreciationState" class="auto-style2"></td>
                <td class="auto-style3">净值</td><td id="NetWorth"></td>
                 <td class="auto-style1">出厂号</td><td id="OutFactoryNumber" class="auto-style2"></td>
            </tr>
            <tr>
                <td class="auto-style3">供货商</td><td id="Supplier"></td>
               <td class="auto-style1">经费科目</td><td id="FundsSubject" class="auto-style2"></td>
                <td class="auto-style3">采购组织形式</td><td id="PurchaseModality"></td>
            </tr>
            <tr>
                <td class="auto-style1">国别码</td><td id="CountryCode" class="auto-style2"></td>
                <td class="auto-style3">经手人</td><td id="Operator"></td>
                <td class="auto-style1">保修截止日期</td><td id="GuaranteeEndDate" class="auto-style2"></td>
            </tr>
            <tr>
                <td class="auto-style3">设备号</td><td id="EquipmentNumber"></td>
                <td class="auto-style1">发票号</td><td id="InvoiceNumber" class="auto-style2"></td>
                <td class="auto-style3">合同号</td><td id="CompactNumber"></td>
            </tr>
            <tr>
               <td class="auto-style1">基本经费</td><td id="BasicFunds" class="auto-style2"></td>
                <td class="auto-style3">项目经费1</td><td id="ItemFunds1"></td>
                <td class="auto-style1">项目经费2</td><td id="ItemFunds2" class="auto-style2"></td>
                
            </tr>
            <tr>
                <td class="auto-style3">项目经费3</td><td id="ItemFunds3"></td>
                <td class="auto-style1">项目经费4</td><td id="ItemFunds4" class="auto-style2"></td>
                <td class="auto-style3">项目经费1金额</td><td id="ItemFundsMoney1"></td>
            </tr>

            <tr>
               <td class="auto-style1">项目经费2金额</td><td id="ItemFundsMoney2" class="auto-style2"></td>
                <td class="auto-style3">项目经费3金额</td><td id="ItemFundsMoney3"></td>
                 <td class="auto-style1">项目经费4金额</td><td id="ItemFundsMoney4" class="auto-style2"></td>
            </tr>
            <tr>
               <td class="auto-style3"></td><td></td>
                <td class="auto-style1">创建人</td><td id="Creator" class="auto-style2"></td>
                <td class="auto-style3">创建时间</td><td id="CreateTime"></td>
            </tr>
            <tr>
                <td class="auto-style1">修改人</td><td id="Editor" class="auto-style2"></td>
                <td class="auto-style3">修改时间</td><td id="UpdateTime" colspan="3"></td>
            </tr>
            <tr>
                <td class="auto-style1">备注</td><td id="Remarks" colspan="5"></td>
            </tr>

            <tr>
               <td colspan="6" style="text-align:center;"><input class="Topic_btn" type="button" value="取消" onclick="javascript: parent.CloseIFrameWindow();"></td>
                
                
            </tr>

        </tbody></table>
    </div>
        <asp:HiddenField ID="hidId" runat="server" />
    </form>
    <script type="text/javascript">
        $(document).ready(function () {
            BindData();

        });
        //加载设备信息
        function BindData() {
            Id = $("#hidId").val();
            $.ajax({
                type: "Post",
                url: WebServiceUrl + "/Statistical/Statistical.ashx",
                //async: false,
                dataType: "jsonp",
                jsonp: "jsoncallback",
                data: { "Id": Id, "action": "GetEquipDetail" },
                success: function (json) {
                    if (json.result.Status == "error") {
                        //layer.msg(json.result.Msg);
                        return;
                    }
                    if (json.result.Status == "no") {
                        //layer.msg(json.result.Msg);
                        return;
                    }
                    if (json.result.Status == "ok") {
                        var ds = json.result.Data.PagedData;
                        var modelJson = ds[0];

                        //$("#EquipKindName").html(modelJson.ClassName);
                        $("#EquipStatus").html(EquipStatusChange(modelJson.EquipStatus));
                        $("#AssetNumber").html(modelJson.AssetNumber);
                        $("#AssetName").html(modelJson.AssetName);
                        $("#ClassNumber").html(modelJson.ClassNumber);
                        $("#AssetsClassName").html(modelJson.AssetsClassName);
                        $("#IntlClassCode").html(modelJson.IntlClassCode);
                        $("#IntlClassName").html(modelJson.IntlClassName);
                        $("#Unit").html(modelJson.Unit);
                        $("#UsageStatus").html(modelJson.UsageStatus);
                        $("#UsageDirection").html(modelJson.UsageDirection);
                        $("#JYBBBSYFX").html(modelJson.JYBBBSYFX);
                        $("#AcquisitionMethod").html(modelJson.AcquisitionMethod);
                        $("#AcquisitionDate").html(modelJson.AcquisitionDate);

                        $("#BrandStandardModel").html(modelJson.BrandStandardModel);
                        $("#EquipmentUse").html(modelJson.EquipmentUse);
                        $("#UseDepartment").html(modelJson.UseDepartment);
                        $("#UsePeople").html(modelJson.UsePeople);
                        $("#Factory").html(modelJson.Factory);
                        $("#StorageLocation").html(modelJson.WarehouseName);
                        $("#WorthType").html(modelJson.WorthType);
                        $("#UseNature").html(modelJson.UseNature);
                        $("#Worth").html(modelJson.Worth);
                        $("#FinanceRecordType").html(modelJson.FinanceRecordType);
                        $("#FiscalFunds").html(modelJson.FiscalFunds);
                        $("#NonFiscalFunds").html(modelJson.NonFiscalFunds);
                        $("#FinanceRecordDate").html(modelJson.FinanceRecordDate);
                        $("#VoucherNumber").html(modelJson.VoucherNumber);
                        $("#UseTime").html(modelJson.UseTime);
                        $("#ExpectedScrapDate").html(modelJson.ExpectedScrapDate);
                        $("#DepreciationState").html(modelJson.DepreciationState);
                        $("#NetWorth").html(modelJson.NetWorth);
                        $("#OutFactoryNumber").html(modelJson.OutFactoryNumber);
                        $("#Supplier").html(modelJson.Supplier);
                        $("#FundsSubject").html(modelJson.FundsSubject);
                        $("#PurchaseModality").html(modelJson.PurchaseModality);
                        $("#CountryCode").html(modelJson.CountryCode);
                        $("#Operator").html(modelJson.Operator);
                        $("#GuaranteeEndDate").html(modelJson.GuaranteeEndDate);
                        $("#EquipmentNumber").html(modelJson.EquipmentNumber);
                        $("#InvoiceNumber").html(modelJson.InvoiceNumber);
                        $("#CompactNumber").html(modelJson.CompactNumber);
                        $("#BasicFunds").html(modelJson.BasicFunds);
                        $("#ItemFunds1").html(modelJson.ItemFunds1);

                        $("#ItemFunds2").html(modelJson.ItemFunds2);
                        $("#ItemFunds3").html(modelJson.ItemFunds3);
                        $("#ItemFunds4").html(modelJson.ItemFunds4);
                        $("#ItemFundsMoney1").html(modelJson.ItemFundsMoney1);
                        $("#ItemFundsMoney2").html(modelJson.ItemFundsMoney2);
                        $("#ItemFundsMoney3").html(modelJson.ItemFundsMoney3);
                        $("#ItemFundsMoney4").html(modelJson.ItemFundsMoney4);
                        //$("#IsDelete").html(DataState(modelJson.IsDelete));
                        $("#Creator").html(modelJson.CreateName);
                        $("#CreateTime").html(modelJson.CreateTime);
                        $("#Editor").html(modelJson.TwoUserName);
                        $("#UpdateTime").html(modelJson.UpdateTime);
                        $("#Remarks").html(modelJson.Remarks);
                        $("#UseStatus").html(modelJson.UseStatus == 0 ? "启用" : "禁用");
                        $("#EquipImg").attr("src", modelJson.ImageUrl);
                        $("#EquipHref").attr("href", modelJson.ImageUrl);
                    }
                },
                error: OnError
            });
        }
        //错误处理
        function OnError(XMLHttpRequest, textStatus, errorThrown) {
            //layer.msg('');
        }
    </script>
</body>
</html>
