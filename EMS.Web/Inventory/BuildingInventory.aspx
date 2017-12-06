<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BuildingInventory.aspx.cs" Inherits="EMS.Web.Inventory.BuildingInventory" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>楼房盘点</title>
    <link href="/css/style.css" rel="stylesheet" />
    <link href="/css/common.css" rel="stylesheet" />
    <link href="/css/iconfont.css" rel="stylesheet" />
    <link href="/css/animate.css" rel="stylesheet" />
    <script src="/js/jquery-1.11.2.min.js"></script>
    <script src="/js/layer/layer.js"></script>
    <script src="/js/Common.js"></script>
    <script src="/js/jquery.tmpl.js"></script>
    <script src="/js/PageBar.js"></script>
</head>
<body>
    <input type="hidden" id="hid_Id" runat="server" />
    <input type="hidden" id="hid_Type" runat="server" />
    <input type="hidden" id="hid_UserIDCard" runat="server" />
    <form id="form1" runat="server">
        <div class="Teaching_plan_management">
            <input class="Topic_btn" type="button" value="返回" onclick="javascript: location.href = 'Inventory.aspx';" style="float:right;"/>
            <h1 class="Page_name">楼房盘点</h1>
            <div class="menubox1 left_navcon fl">
                <!--头部-->
                <h1><span class="tit_name">楼房</span><span class="fr btn"></span></h1>
                <!--菜单区域-->
                <div class="menu">
                    <ul>
                        <li>                            
                            <ul class="submenu1" id="ul_building"></ul>                                                     
                        </li>
                    </ul>
                </div>
                <!--end 菜单区域-->
            </div>
            <div class="right_dcon fr">
                <div class="tit_top">
				<p>
					<span class="left_tit fl">楼层</span>
				</p>
			 </div>
<div class="clear"></div>
                <div class="S_conditions">				
				<div id="div_layerroom" class="screenBox screenBackground"></div>
			</div>
			 <div class="clear"></div>
			 <!--展示区域-->
			 <div class="Display_form">	
				<div class="Resources_tab">			    
				  </div>
			</div>                
            </div>
        </div>
    </form>
</body>
<script type="text/javascript">
    $(document).ready(function () {
        BindBuilding();
    });
    //绑定楼房信息
    function BindBuilding() {
        $.ajax({
            url: WebServiceUrl + "/Inventory/Inventory.ashx",//random" + Math.random(),//方法所在页面和方法名
            type: "post",
            async: false,
            dataType: "jsonp",
            jsonp: "jsoncallback",
            data: { invenid: $("#<%=hid_Id.ClientID%>").val(), type: $("#<%=hid_Type.ClientID%>").val(), action: "GetBuildingByInventory" },
            success: function (data) {           
                if (data.result != null) {
                    $("#ul_building").html(data.result);   //绑定菜单
                    GetLayersAndRoomsByInvenId(data.selid);
                }                
            },
            error: function () {
                layer.msg("获取失败！");
            }
        });
    }
    function BuildLiClick(obj) {
        $(obj).addClass("selected_build").siblings().removeClass("selected_build");
        GetLayersAndRoomsByInvenId(obj.id.replace('buildli_', ''));
    }
    //绑定楼层及房间
    function GetLayersAndRoomsByInvenId(buildid) {
        var buildname = $("#buildli_" + buildid).html();
        $.ajax({
            url: WebServiceUrl + "/Inventory/Inventory.ashx",//random" + Math.random(),//方法所在页面和方法名
            type: "post",
            async: false,
            //dataType: "json",
            dataType: "text",
            jsonp: "jsoncallback",
            data: { invenid: $("#<%=hid_Id.ClientID%>").val(), buildid: buildid, buildname: buildname, type: $("#<%=hid_Type.ClientID%>").val(), useridcard: $("#hid_UserIDCard").val(), action: "GetLayersAndRoomsByInvenId" },
            success: function (data) {
                $("#div_layerroom").html(data);   //绑定楼层及房间               
            },
            error: function (textStatus) {
                layer.msg("获取楼层及房间出现问题了,请通知管理员!");
            }
        });
    }

</script>
</html>
