<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RoomDistribution.aspx.cs" Inherits="EMS.Web.OfficeFurniture.RoomDistribution" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>房间分配</title>
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
            <td><input type="checkbox" name="cb_sub" /></td>
            <td style="display: none;">${Id}</td>
            <td>${pageIndex()}</td>
        <td>${AssetNumber}</td>
        <td><a href="#"><span title="${AssetName}">${NameLengthUpdate(AssetName,15)}</span></a></td>
        {{if Type == 2}}
        <td>${CreateName}</td>
        {{/if}} 
        <td>${Unit}</td>
        <td>${Storage}</td>
        <td>${Barcode}</td>
            {{if display == 1}}
                  <td><input type="button" class="Topic_btn" value="移出房间" onclick="javascript: MoveEquipOutRoom('${Id}');" /></td> 
            {{/if}} 
        </tr>
    </script>
</head>
<body>
    <input type="hidden" id="hid_Id" runat="server" />
    <input type="hidden" id="hid_Pid" runat="server" />
    <input type="hidden" id="hid_PPid" runat="server" />
    <input type="hidden" id="hid_UserIDCard" runat="server" />
    <!--tz_dialog start-->
    <div class="yy_dialog">
        <div class="t_content">
            <div class="yy_tab">
                <div class="content">
                    <div class="tc">
                        <div class="Operation_area">
                            <div class="left_choice fl">
                                <ul>
                                    <li class="Sear">当前房间：<span id="span_curroom" style="margin-right:20px;"></span>
                                        类型：<span id="span_type" style="margin-right:20px;"></span>
                                        <span id="span_sec" style="display:none;">实验室科所：<span id="span_secinfo"></span></span>
                                    </li>                                   
                                    <li class="Sear" style="margin-top:7px;margin-right:0px;">
                                        房间：<select id="sel_room" class="option">
                                        <option value=''>全部</option>
                                    </select> 
                                        <input id="txt_equipname" type="text" class="search_w" placeholder="请输入资产名称" />
                                        <span id="span_show">展示数据：<select id="sel_showdata" class="option" onchange="ShowDataChange(this.value);" style="width:160px;">
                                        <option value='!=' selected="selected">未分配</option>
                                             <option value='='>已分配</option>
                                    </select></span>                                       
                                        <a class="sea" href="#" onclick="SearchEquipInfo();">搜索</a>
                                    </li>
                                     <li class="Sear" style="margin-top:7px;margin-right:0px;">
                                        <span id="span_secplace" style="display:none;"><select id="sel_secplace" class="option"></select><span class="wstar">*</span></span>
                                        <span id="span_user" style="display:none;">负责人：<select id="sel_owner" class="option"></select></span>
                                   </li>
                                </ul>
                            </div>
                            <div class="right_add fr" style="margin-top:7px;">
                                <a class="add" id="btn_print" href="javascript:void(0);" style="display:none;" onclick="javascript:BatchPrintBarCode();"><i class="iconfont">&#xe726;</i>打印条形码</a>
                            </div>
                        </div>
                        <div class="Honor_management">
                            <table class="W_form" id="tb_InsEquipList" style="background: white;">
                                <thead>
                                    <tr class="trth">
                                        <th class="cbox"><input type="checkbox" id="cb_all" name="cb_all" onclick="CheckAll(this);" /></th>
                                        <th class="number" style="display: none;">id</th>
                                        <th class="number">序号</th>
                                        <th>资产号</th>
                                        <th>资产名称</th>
                                        <th>负责人</th>
                                        <th>计量单位</th>
                                        <th>存放地点</th>
                                        <th class="Code">条形码</th>
                                        <th>操作</th>
                                    </tr>
                                </thead>
                                <tbody id="tbody1"></tbody>
                            </table>
                        </div>
                        <!--分页页码开始-->
                        <div class="paging">
                            <span id="pageBar"></span>
                        </div>
                        <!--分页页码结束-->
                        <div class="submit_btn">
                            <span class="Save_and_submit">
                                <input type="submit" value="确定" class="Save_and_submit" onclick="SaveRoom();" /></span>
                            <span class="cancel">
                                <input type="submit" value="取消" class="cancel" onclick="javascript: parent.CloseIFrameWindow();" /></span>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!--end tz_dialog-->

    <!--tz_yy start-->
    <div class="tz_yy"></div>
    <!--end tz_yy-->
</body>
<script type="text/javascript">
    var UrlDate = new GetUrlDate(); //实例化
    var $thr = $('#tb_InsEquipList tr');
    var serroomid = '', sershowdata = '!=', sername='';
    $(document).ready(function () {
        $("#span_type").html(UrlDate.type == "0" ? "仪器室" : (UrlDate.type == "1" ? "实验室" : "办公室"));
        if (UrlDate.type == "2") {
            $('#span_user').show();
            $thr.find('th:eq(5)').show();
        } else {
            $('#span_user').hide();
            $thr.find('th:eq(5)').hide();
        }
        if (UrlDate.type == "1") {
            $("#span_sec").show();
        } else {
            $("#span_sec").hide();
        }
        $('#btn_print').hide();
        $thr.find('th:eq(9)').hide();
        //BindEquipClass();
        BindSectionPlace();
        BindUserInfo();
        var itemid = $("#<%=hid_Id.ClientID%>").val();
        if (itemid.length) {
            //为控件绑定数据
            BindDataById(itemid);
        } 
    });
    //全选或全不选
    function CheckAll(obj) {
        var flag = obj.checked;//判断全选按钮的状态 
        $("input[type=checkbox][name=cb_sub]").each(function () {//查找每一个name为cb_sub的checkbox 
            this.checked = flag;//选中或者取消选中 
        });
    }
    function BindDataById(itemid) {
        $.ajax({
            url: WebServiceUrl + "/SystemSettings/Building.ashx",//random" + Math.random(),//方法所在页面和方法名
            type: "post",
            async: false,
            dataType: "jsonp",
            jsonp: "jsoncallback",
            data: { itemid: itemid, action: "GetModelById" },
            success: function (json) {
                var model = json.result;
                if (model.toString() != "") {
                    $("#span_curroom").html(model.RoomNo + "(" + model.Name+")");                    
                    if (model.Type == "1") {
                        $("#span_secinfo").html(model.SecName + "(" + model.SecDirector + ")");
                    } 
                    BindSerDropDownList("sel_room", WebServiceUrl + "/SystemSettings/Building.ashx", { type: model.Type, action: "GetRoomInfoByType" }, true);//根据类型绑定房间信息
                    GetEquipData(1);
                }
            },
            //error: OnBindError
        });
    }
    function SearchEquipInfo() {
        serroomid = $("#sel_room").val();
        sershowdata = $('#sel_showdata option:selected').val();
        sername = $("#txt_equipname").val().trim();// $('#sel_equipclass option:selected').val();
        GetEquipData(1);
    }
    //获取数据
    function GetEquipData(PageIndex) {
        //初始化序号 
        pageNum = (PageIndex - 1) * 10 + 1;
        var itemid = $("#<%=hid_Id.ClientID%>").val();
        var roomid = itemid.length ? $("#<%=hid_Id.ClientID%>").val() : "";
        var slsymbol = itemid.length ? sershowdata : "";
        $.ajax({
            type: "Post",
            url: WebServiceUrl + "/Statistical/Statistical.ashx",//random" + Math.random(),//方法所在页面和方法名
            //async: false,
            dataType: "jsonp",
            jsonp: "jsoncallback",
            data: {
                "PageIndex": PageIndex,
                "PageSize": 5,
                "Name": sername,
                "StorageLocation": roomid,
                "SerRoomid": serroomid,
                "SLSymbol": slsymbol,
                "Type": UrlDate.type,
                "action": "GetPageEquipDetail"
            },
            success: function (json) {
                if (json.result.Status == "error") {
                    $("#tbody1").html('');
                }
                if (json.result.Status == "no") {
                    $("#tbody1").html('');
                    //生成页码条方法（方法对象,页码条容器，当前页码，总页数，页码组容量，总行数）
                    makePageBar(GetEquipData, document.getElementById("pageBar"), 1, 1, 8, 0);
                    return;
                }
                if (json.result.Status == "ok") {
                    $("#tbody1").html('');
                    $("#tr_InsEquip").tmpl(json.result.Data.PagedData).appendTo("#tbody1");
                    //生成页码条方法（方法对象,页码条容器，当前页码，总页数，页码组容量，总行数）
                    makePageBar(GetEquipData, document.getElementById("pageBar"), json.result.Data.PageIndex, json.result.Data.PageCount, 8, json.result.Data.RowCount);
                }
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                //layer.msg("");
            }
        });

    }
    //绑定实验室科所
    function BindSectionPlace() {
        $.ajax({
            type: "post",
            url: WebServiceUrl + "/SystemSettings/SectionPlace.ashx",
            async: false,
            dataType: "jsonp",
            jsonp: "jsoncallback",
            data: { usestatus: "0", startIndex: 1, pageSize: 1000, action: "GetDataPage" },
            success: function (json) {
                $("#sel_secplace").empty();
                if (json.result.Status.toString() == "error") {
                    layer.msg(json.result.Msg);
                    return;
                }
                if (json.result.Status.toString() == "no") {
                    return;
                }
                $.each(json.result.Data.PagedData, function (i, item) {
                    var option = "<option value='" + item.Id + "'>" + item.Name + "(" + item.Director + ")</option>"
                    $("#sel_secplace").append(option);
                });
            }//,
            //error: OnError
        });
    }
    //绑定用户
    function BindUserInfo() {
        $.ajax({
            type: "post",
            url: WebServiceUrl + "/SystemSettings/UserInfo.ashx",
            async: false,
            dataType: "jsonp",
            jsonp: "jsoncallback",
            data: { action: "GetData" },
            success: function (json) {
                $("#sel_owner").empty();
                if (json.result.Status.toString() == "error") {
                    layer.msg(json.result.Msg);
                    return;
                }
                if (json.result.Status.toString() == "no") {
                    return;
                }
                $.each(json.result.Data.PagedData, function (i, item) {
                    var option = "<option value='" + item.IDCard + "'>" + item.Name + "</option>"
                    $("#sel_owner").append(option);
                });
            }
        });
    }
    //绑定仪器设备分类
    function BindEquipClass() {
        $.ajax({
            type: "Post",
            url: WebServiceUrl + "/Statistical/Statistical.ashx",
            async: false,
            dataType: "jsonp",
            jsonp: "jsoncallback",
            data: { "PageIndex": 1, "PageSize": 1000, "action": "GetPageStock" },
            success: function (json) {
                $("#sel_equipclass").empty();
                $("#sel_equipclass").append("<option value=''>全部</option>");
                if (json.result.Status.toString() == "error") {
                    layer.msg(json.result.Msg);
                    return;
                }
                if (json.result.Status.toString() == "no") {
                    return;
                }
                $.each(json.result.Data.PagedData, function (i, item) {
                    var option = "<option value='" + item.AssetsClassName + "'>" + item.AssetsClassName + "</option>"
                    $("#sel_equipclass").append(option);
                });
            }//,
            //error: OnError
        });
    }
    //保存房间信息
    function SaveRoom() {        
        var idArray = [];
        if ($('#sel_showdata option:selected').val() == "!=") {
            var leg = $("#tb_InsEquipList tr").length - 1;  //$("#tb_InsEquipList tr").length是获取table的行数
            $("#tb_InsEquipList tr:gt(0):lt(" + leg + ")").each(function () {  //gt（0）代表是大于第一行，从第二行起;  lt（10）代表小于；
                if ($(this).children("td").eq(0).children("input")[0].checked) {
                    temp = $(this).children("td").eq(1)[0].innerHTML; //获取仪器设备id
                    if (temp.length > 0) {
                        idArray.push(temp);
                    }
                }
            });
            if (!idArray.length) {
                layer.msg("请勾选需要分配的资产！");
                return;
            }
        }        
        var itemid = $("#<%=hid_Id.ClientID%>").val();
        $.ajax({
            url: WebServiceUrl + "/SystemSettings/Building.ashx",//random" + Math.random(),//方法所在页面和方法名
            type: "post",
            async: false,
            dataType: "jsonp",
            jsonp: "jsoncallback",
            data: {
                itemid: itemid,
                flag: "room",
                type: UrlDate.type,
                owneridcard: $("#sel_owner").val(),
                idsStr: idArray.join(","),
                useridcard: $("#hid_UserIDCard").val(),
                action: "SetRoomDistributionEquip"
            },
            success: function (json) {
                if (json.result.Status == "ok") {
                    parent.layer.msg(json.result.Msg);
                    GetEquipData(1);
                } else {
                    layer.msg(json.result.Msg);
                }                
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                layer.msg("操作失败！");
            }
        });
    }
    function BatchPrintBarCode() {
        var leg = $("#tb_InsEquipList tr").length - 1;
        $("#tb_InsEquipList tr:gt(0):lt(" + leg + ")").each(function () {
            if ($(this).children("td").eq(0).children("input")[0].checked) {
                temp = $(this).children("td").eq(1)[0].innerHTML; //获取仪器设备id
                //alert(temp);
            }
        });
    }
    function MoveEquipOutRoom(equipid) {
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
                    data: { "itemid": equipid, action: "MoveEquipOutRoom" },
                    success: function (json) {
                        if (json.result != "0") {
                            layer.msg("移出成功！");
                            GetEquipData(1);
                        } else {
                            layer.msg("移出失败！");
                        }
                    }//,
                    //error: OnErrorDelete
                });
            }
        });
    }
    function ShowDataChange(value) {
        if (value == '=') {
            $('#btn_print').show();
            $('#span_user').hide();
            $thr.find('th:eq(9)').show();
        } else {
            $('#btn_print').hide();
            if (UrlDate.type == "2") {
                $('#span_user').show();
            } else {
                $('#span_user').hide();
            }
            $thr.find('th:eq(9)').hide();
        };
        SearchEquipInfo();
    }
</script>
</html>


