<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BuildingManagement.aspx.cs" Inherits="EMS.Web.SystemSettings.BuildingManagement" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>楼层及房间管理</title>
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
    <input type="hidden" id="hid_UserIDCard" runat="server" />
    <form id="form1" runat="server">
        <div class="Teaching_plan_management">
            <input class="Topic_btn" id="btn_return" type="button" value="返回" onclick="javascript: location.href = 'SectionPlaceManagement.aspx';" style="float: right;display:none;" />
            <h1 class="Page_name" id="h1_title">楼层及房间管理</h1>
            <div class="menubox1 left_navcon fl">
                <!--头部-->
                <h1><span class="tit_name">楼房</span><span class="fr btn"><a href="#" onclick="javascript: OpenIFrameWindowCall('楼房管理', 'BuildingOperate.aspx', '560px', '450px');">楼房管理</a></span></h1>
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
					<span class="right_operation fr" style="cursor:pointer;" onclick="javascript:LayerOperate();">楼层管理</span>
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
    var UrlDate = new GetUrlDate(); //实例化
    var secplaceid = "";
    $(document).ready(function () {
        if (UrlDate.secplaceid)
        {
            $("#btn_return").show();
            secplaceid = UrlDate.secplaceid;
            $("#h1_title").html(UrlDate.secplacename+"-实验室管理");
        }
        BindBuilding();
    });
    //绑定楼房信息
    function BindBuilding() {
        $.ajax({
            url: WebServiceUrl + "/SystemSettings/Building.ashx",//random" + Math.random(),//方法所在页面和方法名
            type: "post",
            async: false,
            dataType: "jsonp",
            jsonp: "jsoncallback",
            data: { action: "GetBuildingData" },
            success: function (data) {
                if (data.result != null) {
                    $("#ul_building").html(data.result);   //绑定菜单
                    GetLayersAndRoomsById(data.selid);                    
                }
            },
            error: function () {
                layer.msg("获取失败！");
            }
        });
    }

    function BuildLiClick(obj) {
        $(obj).addClass("selected_build").siblings().removeClass("selected_build");
        GetLayersAndRoomsById(obj.id.replace('buildli_', ''));
    }

    //绑定楼层及房间
    function GetLayersAndRoomsById(buildid) {
        $.ajax({
            url: WebServiceUrl + "/SystemSettings/Building.ashx",//random" + Math.random(),//方法所在页面和方法名
            type: "post",
            async: false,
            //dataType: "json",
            dataType: "jsonp",
            jsonp: "jsoncallback",
            data: { itemid: buildid, secplaceid: secplaceid, useridcard: $("#hid_UserIDCard").val(), action: "GetLayersAndRoomsById" },
            success: function (ok) {
                var data = decodeURIComponent(ok.result);
                $("#div_layerroom").html(data);   //绑定楼层及房间 
                $(".screenBox dl dd label").hover(function () {
                    $(this).find(".del").show().end().siblings();
                }, function () {
                    $(this).find(".del").hide();
                })
            },
            error: function (textStatus) {
                layer.msg("获取楼层及房间出现问题了,请通知管理员!");
            }
        });
    }

    var curWinindexCall;
    function OpenIFrameWindowCall(title, url, width, height) {
        //iframe层
        var index = layer.open({
            type: 2,
            title: title,
            shadeClose: false,
            shade: 0.2,
            area: [width, height],
            content: url, //iframe的url
            cancel: function (index) {
                if (title == "楼房管理") {
                    BindBuilding();
                } else {
                    var selobj = $("#ul_building li.selected_build");
                    if (selobj.length) {
                        GetLayersAndRoomsById(selobj[0].id.replace('buildli_', ''));
                    }
                }                
            }
        });
        curWinindexCall = index;
    }
    function LayerOperate() {
        var selobj = $("#ul_building li.selected_build");
        if (selobj.length) {
            OpenIFrameWindowCall('楼层管理', 'BuildingLayerOperate.aspx?pid=' + selobj[0].id.replace('buildli_', ''), '560px', '450px');
        }
    }
    //删除房间
    function DeleteBuilding(event, curid, flag) {
        layer.msg("确定要删除该房间？", {
            time: 0 //不自动关闭
            , btn: ['确定', '取消']
            , yes: function (index) {
                layer.close(index);
                $.ajax({
                    url: WebServiceUrl + "/SystemSettings/Building.ashx",//random" + Math.random(),//方法所在页面和方法名
                    type: "post",
                    async: false,
                    dataType: "jsonp",
                    jsonp: "jsoncallback",
                    data: { intID: curid, flag: flag, useridcard: $("#hid_UserIDCard").val(), action: "DeleteBuilding" },
                    success: function (json) {
                        if (json.result.Status == "ok") {
                            layer.msg(json.result.Msg);
                            var selobj = $("#ul_building li.selected_build");
                            if (selobj.length) {
                                GetLayersAndRoomsById(selobj[0].id.replace('buildli_', ''));
                            }
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

        var e = window.event || event;

        if (e.stopPropagation) { //如果提供了事件对象，则这是一个非IE浏览器
            e.stopPropagation();
        } else {
            //兼容IE的方式来取消事件冒泡
            window.event.cancelBubble = true;
        }
        return false;
    }
</script>
</html>
