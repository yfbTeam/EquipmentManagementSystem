<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ImportEquip.aspx.cs" Inherits="EMS.Web.Statistical.ImportEquip" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="../css/common.css" rel="stylesheet" />
    <link href="../css/style.css" rel="stylesheet" />
    <link href="../css/iconfont.css" rel="stylesheet" />
    <link href="../css/animate.css" rel="stylesheet" />

    <script src="../js/Common.js"></script>
    <script src="../js/jquery-1.11.2.min.js"></script>
    <script src="../js/layer/layer.js"></script>
    <style type="text/css">
        .ImportDIV{
            margin:auto;
            width:500px;
            height:100px;
            line-height:50px;
            text-align:center;
        }
    </style>
    <script type="text/javascript">
        
        //导入
        function ImportEquip(FilePath) {
            UserIDCard = $("#hidUserIDCard").val();
            $.ajax({
                type: "Post",
                url: WebServiceUrl + "/Statistical/Statistical.ashx",//random" + Math.random(),//方法所在页面和方法名
                //async: false,
                timeout: 1200000, //超时时间设置，单位毫秒  20分钟
                dataType: "jsonp",
                jsonp: "jsoncallback",
                data: { "Creator": UserIDCard, "FilePath": FilePath, "action": "ImportEquip" },
                success: function (json) {
                    if (json.result.Status == "error") {
                        //alert(json.result.Msg);
                    }
                    else if (json.result.Status == "no") {
                        layer.msg(json.result.Msg);
                    }
                    else if (json.result.Status == "ok") {
                        parent.layer.msg(json.result.Msg);
                        ReturnUrl();
                    }
                },
                error: OnError
            });
        }
        function OnError(XMLHttpRequest) {
            alert(XMLHttpRequest.statusText);
        }
        //返回列表页
        function ReturnUrl() {
            parent.GetList(1);
            parent.CloseIFrameWindow();

        }
</script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="ImportDIV">
        <span >如果没有模板，需要先下载模板，填好数据后进行导入</span><br />
        仪器设备： <asp:FileUpload runat="server" ID="FileUpEquip" class="Topic_btn"/>
        <asp:Button runat="server" ID="btnImportEquip" Text="导入" OnClick="btnImportEquip_Click" class="Topic_btn"/>
        <asp:Button runat="server" ID="DownLoad" Text="下载模板" class="Topic_btn" OnClick="DownLoad_Click"/>
    </div>
    <asp:HiddenField runat="server" ID="hidUserIDCard" />
    </form>
</body>

</html>
