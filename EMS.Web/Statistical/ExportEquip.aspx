<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExportEquip.aspx.cs" Inherits="EMS.Web.Statistical.ExportEquip" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../css/common.css" rel="stylesheet" />
    <link href="../css/style.css" rel="stylesheet" />
    <link href="../css/iconfont.css" rel="stylesheet" />
    <link href="../css/animate.css" rel="stylesheet" />

    <script src="../js/Common.js"></script>
    <script src="../js/jquery-1.11.2.min.js"></script>
    <script src="../js/layer/layer.js"></script>
    <script src="../js/json2.js"></script>
    <style type="text/css">
        .ImportDIV {
            margin: auto;
            width: 580px;
            height: 100px;
            line-height: 50px;
            /*text-align: center;*/
            padding: 0 10px;
            padding-top:20px;
        }
        .SouSuo{border: 1px solid #2789ba; border-radius: 3px; color: #666;font-family: "微软雅黑",microsoft yahei ui;font-size: 14px; height: 28px; line-height: 28px; padding-left: 10px;}}
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="ImportDIV">
            设备来源：
            <select class="option" id="EquipSource">
                <option value=''>全部</option>
                <option value='0'>本院资产</option>
                <option value='1'>资产系统</option>
            </select>
            分类名称：
            <input id="ClassName" type="text" class="SouSuo" placeholder="请输入分类名称" value=""/>
            <%--<asp:Button runat="server" ID="btnImportEquip" Text="导出" OnClick="btnImportEquip_Click" class="Topic_btn" />--%>
            <input type="button" value="导出" onclick="ExportEquipExcel()" class="Topic_btn"/>
            <asp:Button ID="btnExport" runat="server" OnClick="btnExport_Click" style="display:none;"/>
        </div>
        <asp:HiddenField runat="server" ID="hidUserIDCard" />
        <asp:HiddenField ID="hidExcelCenter" runat="server" />
    </form>
</body>
<script type="text/javascript">
    //导出设备Excel
    function ExportEquipExcel() {
        var EquipSource = $("#EquipSource option:selected").val();
        var ClassName = $("#ClassName").val().trim();
        $.ajax({
            type: "Post",
            url: WebServiceUrl + "/Statistical/Statistical.ashx",//random" + Math.random(),//方法所在页面和方法名
            //async: false,
            dataType: "jsonp",
            jsonp: "jsoncallback",
            data: { "EquipSource": EquipSource, "ClassName": ClassName, "action": "ExportEquipExcel" },
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
                    $("#hidExcelCenter").val(JSON.stringify(json.result.Data));
                    $("#btnExport").click();
                }
            },
            error: OnError
        });
    }
    function OnError(XMLHttpRequest) {
        //layer.msg(XMLHttpRequest.statusText);
    }
</script>
</html>
