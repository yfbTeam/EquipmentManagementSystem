<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AssetsDistribution.aspx.cs" Inherits="EMS.Web.OfficeFurniture.AssetsDistribution" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>分配</title>
    <link href="/css/style.css" rel="stylesheet" />
    <link href="/css/common.css" rel="stylesheet" />
    <link href="/css/iconfont.css" rel="stylesheet" />
    <link href="/css/animate.css" rel="stylesheet" />
    <script src="/js/jquery-1.11.2.min.js"></script>
    <script src="/js/layer/layer.js"></script>
    <script src="/js/Common.js"></script>
    <script src="/js/jquery.tmpl.js"></script>
    <script src="/js/PageBar.js"></script>
    <script id="tr_InsEquip" type="text/x-jquery-tmpl">
        <tr>
            <td>
                <input type="checkbox" name="cbIns_sub" value="${Id}" opt="sel" onclick="checkItem(this)" /></td>
            <td>${AssetNumber}</td>
            <td>${NameLengthUpdate(AssetName,15)}</td>
            <td>${UseDepartment}</td>
            <td>${Storage}</td>
            <td>${Unit}</td>
            <td>${Count}</td>
        </tr>
    </script>
    <script id="tr_NoEquip" type="text/x-jquery-tmpl">
        <tr>
            <td>
                <input type="checkbox" name="cbDel_sub" value="${Id}" opt="no" onclick="checkItem(this)" /></td>
            <td>${AssetNumber}</td>
            <td>${NameLengthUpdate(AssetName,15)}</td>
            <td>${UseDepartment}</td>
            <td>${Storage}</td>
            <td>${Unit}</td>
            <td>${Count}</td>
        </tr>
    </script>
</head>
<body>
    <input type="hidden" id="hid_Type" runat="server" />
    <input type="hidden" id="hid_UserIDCard" runat="server" />
    <form id="form1" runat="server">
        <div class="Teaching_plan_management">
            <input class="Topic_btn" type="button" value="返回" onclick="javascript: ReturnPage();" style="float: right;" />
            <h1 class="Page_name" id="h1_title" name="h1_title" runat="server"></h1>
            <div class="stytem_items">
                <div class="stytem_item clearfix">
                    <div class="stytem_items_title fl">
                        楼房
                    </div>
                    <div class="stytem_items_list fl">
                        <div class="clearfix" id="lf">
                        </div>
                    </div>
                    <a href="javascript:;" class="stytem_items_more fr">
                        <span>更多</span>
                    </a>
                </div>
                <div class="stytem_item clearfix">
                    <div class="stytem_items_title fl">
                        楼层
                    </div>
                    <div class="stytem_items_list fl">
                        <div class="clearfix" id="lc">
                        </div>
                    </div>
                    <a href="javascript:;" class="stytem_items_more fr">
                        <span>更多</span>
                    </a>
                </div>
                <div class="stytem_item clearfix">
                    <div class="stytem_items_title fl">
                        房间
                    </div>
                    <div class="stytem_items_list fl">
                        <div class="clearfix" id="fj">
                        </div>
                    </div>
                    <a href="javascript:;" class="stytem_items_more fr">
                        <span>更多</span>
                    </a>
                </div>
            </div>

            <div class="room_messages">
                <div class="Teaching_plan_form clearfix">
                    <div class="right_form fl">
                        <h3 class="trth">已选择仪器设备 </h3>
                        <table class="PR_form">
                            <thead>
                                <tr class="trth">
                                    <!--表头tr名称-->
                                    <th class="checkbox">
                                        <input id="YQuanXuan" type="checkbox" name="CheckAll_box" class="Check_box" opt="sel" onclick="checkItem(this)" /></th>
                                    <th class="Instrument_number">仪器编号</th>
                                    <th class="Instrument_name">仪器名称</th>
                                    <th class="Instrument_model">领用单位</th>
                                    <th>办公室</th>
                                    <th class="classification">单位</th>
                                    <th class="Number">数量</th>
                                </tr>
                            </thead>
                            <tbody id="YSelect">
                            </tbody>
                        </table>
                        <div class="page">
                            <!--分页页码开始-->
                            <div class="paging">
                                <span id="pageBarYS"></span>
                            </div>
                            <!--分页页码结束-->
                        </div>
                    </div>
                    <div class="LR_btn fl">
                        <a href="#">
                            <input type="button" class="rightbtn" onclick="Operation('cancel')" /></a>
                        <a href="#">
                            <input type="button" class="leftbtn" onclick="Operation('insert')" /></a>
                    </div>
                    <div class="left_form fr" id="rightDIV">
                        <h3 class="trth">待选择仪器设备</h3>
                        <table class="PL_form">
                            <thead>
                                <tr class="trth">
                                    <!--表头tr名称-->
                                    <th class="checkbox">
                                        <input id="DQuanXuan" type="checkbox" name="CheckAll_box" class="Check_box" opt="no" onclick="checkItem(this);" /></th>
                                    <th class="Instrument_number">仪器编号</th>
                                    <th class="Instrument_name">仪器名称</th>
                                    <th class="Instrument_model">领用单位</th>
                                    <th>办公室</th>
                                    <th class="classification">单位</th>
                                    <th class="Number">数量</th>

                                </tr>
                            </thead>
                            <tbody id="DSelect">
                            </tbody>
                        </table>
                        <div class="page">
                            <!--分页页码开始-->
                            <div class="paging">
                                <span id="pageBar"></span>
                            </div>
                            <!--分页页码结束-->
                        </div>
                    </div>
                </div>
            </div>
        </div>

        
    </form>
    <style type="text/css">
        .stytem_items {
            border: 1px solid #8cc0e8;
            border-radius: 2px;
            margin-bottom: 10px;
            overflow: hidden;
        }

            .stytem_items .stytem_item {
                background: #f3f9fd;
                position: relative;
            }

                .stytem_items .stytem_item .stytem_items_title {
                    width: 75px;
                    height: 33px;
                    background: #35A7DF;
                    text-align: center;
                    line-height: 35px;
                    color: #fff;
                    font-size: 14px;
                    position: absolute;
                    left: 0;
                    top: 1px;
                }

                .stytem_items .stytem_item .stytem_items_more {
                    width: 60px;
                    height: 34px;
                    line-height: 35px;
                    text-align: center;
                    color: #5b93c8;
                    font-size: 12px;
                    position: absolute;
                    right: 0;
                    top: 0;
                }

                .stytem_items .stytem_item .stytem_items_list {
                    padding-left: 75px;
                    padding-right: 60px;
                    border-bottom: 1px solid #c1c1c1;
                    height: 35px;
                    overflow: hidden;
                    width: 100%;
                    box-sizing: border-box;
                }

                    .stytem_items .stytem_item .stytem_items_list a {
                        padding: 0px 10px;
                        height: 25px;
                        display: block;
                        float: left;
                        line-height: 25px;
                        text-align: center;
                        font-size: 14px;
                        color: #555;
                        margin: 5px 0px;
                        margin-left: 10px;
                        cursor: pointer;
                    }

                        .stytem_items .stytem_item .stytem_items_list a.on {
                            color: #fff;
                            background: #35A7DF;
                        }

    </style>
</body>
<script type="text/javascript">
    //更多收起
    $('.stytem_item').find('.stytem_items_more').click(function () {
        if ($(this).children('span').text() == '更多') {
            $(this).children('span').text('收起');
            $(this).siblings('.stytem_items_list').height('auto');
            var heig = $(this).siblings('.stytem_items_list').height();
            $(this).siblings('.stytem_items_title').height(heig).css('lineHeight', heig + 'px');
        } else if ($(this).children('span').text() == '收起') {
            $(this).children('span').text('更多');
            $(this).siblings('.stytem_items_list').height('44px');
            $(this).siblings('.stytem_items_title').height('43px').css('lineHeight', '45px');
        }
    })

    $('.stytem_items_list a').click(function () {
        $(this).addClass('on').siblings().removeClass('on');
    });

    function checkItem(obj)
    {
        var operation = $(obj).attr("opt");
        var isChecked = $(obj).is(':checked');
        if (operation == "sel") {
            var checkArry = $(".PL_form").find("input[type='checkbox']");
            checkAll(checkArry);
            //checkArry.push($(this));
            //checkArry.push();
            //$("input[name='cbIns_sub']").each(function () {
            //    $(this).prop("checked", isChecked);
            //});
        } else {
            var checkArry = $(".PR_form").find("input[type='checkbox']");
            checkAll(checkArry);
            //$("input[name='cbDel_sub']").each(function () {
            //    $(this).prop("checked", isChecked);
            //});
        }
    }

    function checkAll(oInput) {
        var isCheckAll = function () {
            for (var i = 1, n = 0; i < oInput.length; i++) {
                oInput[i].checked && n++
            }
            oInput[0].checked = n == oInput.length - 1;
        };
        //全选
        oInput[0].onchange = function () {
            for (var i = 1; i < oInput.length; i++) {
                oInput[i].checked = this.checked
            }
            isCheckAll()
        };
        //根据复选个数更新全选框状态
        for (var i = 1; i < oInput.length; i++) {
            oInput[i].onchange = function () {
                isCheckAll()
            }
        }
    }

    $(document).ready(function () {
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
            data: { type: $("#hid_Type").val(), action: "GetBuildingDataNew" },
            success: function (data) {
                if (data.result != null) {
                    $("#lf").html(data.result);   //绑定菜单
                    GetLayersAndRoomsByInvenId(data.selid);
                }
            },
            error: function () {
                layer.msg("获取失败！");
            }
        });
    }
    function BuildLiClick(obj) {
        //$(obj).addClass("selected_build").siblings().removeClass("selected_build");
        //GetLayersAndRoomsByInvenId(obj.id.replace('buildli_', ''));
        $(obj).addClass('on').siblings().removeClass('on');
        if (obj.id != null && obj.id.indexOf("buildli") > -1) {
            GetLayersAndRoomsByInvenId(obj.id.replace('buildli_', ''));
        } else {
            if (HomeArrys.length > 0) {
                var layerId = $(obj).attr("layer");
                if (layerId != "") {
                    $("#fj").html("");
                    currentNumber = "";
                    var isload = false;
                    var currentHomeNum = "";
                    for (var j = 0; j < HomeArrys.length; j++) {
                        if (HomeArrys[j].PID == layerId) {
                            if (!isload) {
                                $("#fj").append("<a  class='on' home='" + HomeArrys[j].Id + "' onclick='javascript:BuildLiClick(this)'>" + HomeArrys[j].Name + " </a>");
                                isload = true;
                                currentHomeNum = HomeArrys[j].Id;
                            }
                            else $("#fj").append("<a onclick='javascript:BuildLiClick(this)'>" + HomeArrys[j].Name + " </a>");
                        }
                    }
                    if (currentHomeNum != "" && currentHomeNum.length > 0) {
                        currentNumber = currentHomeNum;
                        GetEquipDataSel(1);
                        GetEquipDataNo(1);
                    }
                }
            }
        }

    }
    var HomeArrys = [];
    var LayerArrys = [];
    var currentNumber = "";
    //绑定楼层及房间
    function GetLayersAndRoomsByInvenId(buildid) {
        HomeArrys = [];
        LayerArrys = [];
        $("#fj").html("");
        $("#lc").html("");
        currentNumber = "";
        var buildname = $("#buildli_" + buildid).html();
        $.ajax({
            url: WebServiceUrl + "/SystemSettings/Building.ashx",//random" + Math.random(),//方法所在页面和方法名
            type: "post",
            async: false,
            //dataType: "json",
            dataType: "jsonp",
            jsonp: "jsoncallback",
            data: { itemid: buildid, buildname: buildname, type: $("#hid_Type").val(), useridcard: $("#hid_UserIDCard").val(), action: "GetLayersAndRoomsByIdNew" },
            success: function (data) {
                var dtArry = data.result.Data;
                if (dtArry != null && dtArry.length > 1) {
                    var dtJson = ($.parseJSON(dtArry[0])).ds;
                    var drJson = ($.parseJSON(dtArry[1])).ds;
                    var currentLayer;
                    var currentHomeNum = "";
                    if (drJson != null && drJson.length > 0) {//楼层 
                        LayerArrys = drJson;
                        for (var i = 0; i < drJson.length; i++) {
                            if (i == 0) {
                                $("#lc").append("<a  class='on' layer='" + drJson[i].Id + "' onclick='javascript:BuildLiClick(this)'>第" + drJson[i].Name + "层</a>");
                                currentLayer = drJson[i].Id;
                            }
                            else {
                                $("#lc").append("<a onclick='javascript:BuildLiClick(this)'>" + drJson[i].Name + " </a>");
                            }
                        }
                    }
                    if (dtJson != null && dtJson.length > 0) {//房间
                        HomeArrys = dtJson;
                        var isload = false;
                        for (var j = 0; j < dtJson.length; j++) {
                            if (dtJson[j].PID == currentLayer) {
                                if (!isload) {
                                    $("#fj").append("<a  class='on' home='" + dtJson[j].Id + "' onclick='javascript:BuildLiClick(this)'>" + dtJson[j].Name + " </a>");
                                    isload = true;
                                    currentHomeNum = dtJson[j].Id;
                                }
                                else $("#fj").append("<a onclick='javascript:BuildLiClick(this)'>" + dtJson[j].Name + " </a>");
                            }
                        }
                    }
                    if (currentHomeNum != "" && currentHomeNum.length > 0) {
                        currentNumber = currentHomeNum;
                        GetEquipDataSel(1);
                        GetEquipDataNo(1);
                    }

                }
            },
            error: function (textStatus) {
                layer.msg("获取楼层及房间出现问题了,请通知管理员!");
            }
        });
    }

    function GetEquipDataSel(PageIndex) {
        $.ajax({
            type: "Post",
            url: WebServiceUrl + "/Statistical/Statistical.ashx",//random" + Math.random(),//方法所在页面和方法名
            //async: false,
            dataType: "jsonp",
            jsonp: "jsoncallback",
            data: {
                "PageIndex": PageIndex,
                "PageSize": 10,
                "Type": $("#hid_Type").val(),
                "Operation": "select",
                "UserRoleID": $("#hid_UserIDCard").val(),
                "StorageLocation": currentNumber,
                "EquipStatus": 0,
                "action": "GetPageEquipDetailNew"
            },
            success: function (json) {
                if (json.result.Status == "error") {
                    $("#YSelect").html('');
                }
                if (json.result.Status == "no") {
                    $("#YSelect").html('');
                    //生成页码条方法（方法对象,页码条容器，当前页码，总页数，页码组容量，总行数）
                    makePageBar(GetEquipData, document.getElementById("pageBarYS"), 1, 1, 10, 0);
                    return;
                }
                if (json.result.Status == "ok") {
                    $("#YSelect").html('');
                    $("#tr_InsEquip").tmpl(json.result.Data.PagedData).appendTo("#YSelect");
                    //生成页码条方法（方法对象,页码条容器，当前页码，总页数，页码组容量，总行数）
                    makePageBar(GetEquipDataSel, document.getElementById("pageBarYS"), json.result.Data.PageIndex, json.result.Data.PageCount, 10, json.result.Data.RowCount);
                }
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                //layer.msg("");
            }
        });
    }

    function GetEquipDataNo(PageIndex) {
        $.ajax({
            type: "Post",
            url: WebServiceUrl + "/Statistical/Statistical.ashx",//random" + Math.random(),//方法所在页面和方法名
            dataType: "jsonp",
            jsonp: "jsoncallback",
            data: {
                "PageIndex": PageIndex,
                "PageSize": 10,
                "StorageLocation": 0,
                "Type": $("#hid_Type").val(),
                "UserRoleID": $("#hid_UserIDCard").val(),
                "Operation": "no",
                "EquipStatus": 0,
                "action": "GetPageEquipDetailNew"
            },
            success: function (json) {
                if (json.result.Status == "error") {
                    $("#DSelect").html('');
                }
                if (json.result.Status == "no") {
                    $("#DSelect").html('');
                    //生成页码条方法（方法对象,页码条容器，当前页码，总页数，页码组容量，总行数）
                    makePageBar(GetEquipData, document.getElementById("pageBar"), 1, 1, 10, 0);
                    return;
                }
                if (json.result.Status == "ok") {
                    $("#DSelect").html('');
                    $("#tr_NoEquip").tmpl(json.result.Data.PagedData).appendTo("#DSelect");
                    //生成页码条方法（方法对象,页码条容器，当前页码，总页数，页码组容量，总行数）
                    makePageBar(GetEquipDataNo, document.getElementById("pageBar"), json.result.Data.PageIndex, json.result.Data.PageCount, 10, json.result.Data.RowCount);
                }
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                //layer.msg("");
            }
        });
    }

    function Operation(ot) {
        var equips = "";
        if (ot == "insert") {
            $("input[name='cbDel_sub']").each(function () {
                if ($(this).is(':checked')) {
                    var equip = $(this).val();
                    equips += equip + ",";
                }
            });
            if (equips != "") {
                equips = equips.substring(0, equips.length - 1);
                MoveEquipInsRoom(equips, currentNumber);
            }

        } else {
            $("input[name='cbIns_sub']").each(function () {
                if ($(this).is(':checked')) {
                    var equip = $(this).val();
                    equips += equip + ",";
                }
            });
            if (equips != "") {
                equips = equips.substring(0, equips.length - 1);
                MoveEquipOutRoom(equips);
            }
        }
    }

    function MoveEquipInsRoom(equipids, homeid) {
        $.ajax({
            url: WebServiceUrl + "/SystemSettings/Building.ashx",//random" + Math.random(),//方法所在页面和方法名
            type: "post",
            async: false,
            dataType: "jsonp",
            jsonp: "jsoncallback",
            data: { "itemid": equipids, "home": homeid, "action": "MoveEquipOutRoomNew" },
            success: function (json) {
                if (json.result != "0") {
                    layer.msg("加入成功！");
                    GetEquipDataSel(1);
                    GetEquipDataNo(1);
                } else {
                    layer.msg("加入失败！");
                }
            }
        });
    }

    function MoveEquipOutRoom(equipids) {
        layer.msg("确定要移出该房间?", {
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
                    data: { "itemid": equipids, "action": "MoveEquipOutRoomNew" },
                    success: function (json) {
                        if (json.result != "0") {
                            layer.msg("移出成功！");
                            GetEquipDataSel(1);
                            GetEquipDataNo(1);
                        } else {
                            layer.msg("移出失败！");
                        }
                    }
                });
            }
        });
    }

    function ReturnPage() {
        location.href = $("#hid_Type").val() == "2" ? "OfficeFurnitureList.aspx" : "/ScientificResearch/ScientificResearchList.aspx";
    }
</script>
</html>
