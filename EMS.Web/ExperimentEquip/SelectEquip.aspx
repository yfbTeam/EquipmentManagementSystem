<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SelectEquip.aspx.cs" Inherits="EMS.Web.ExperimentEquip.SelectEquip" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="Generator" content="EditPlus®">
    <meta name="Author" content="">
    <meta name="Keywords" content="">
    <meta name="Description" content="">
    <title>仪器设备选择</title>
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
        .TempDIVCSS{
            display:none;
            /*width:600px;
            height:800px;*/
        }
        .TempAdd{
            display:block; padding:8px 8px; background:#2789ba; border-radius:3px; color:#fff; float:left; margin-right:4px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="Teaching_plan_management">
            <h1 class="Page_name">添加仪器设备</h1>
            <div class="Operation_area">
                <div class="Experiment_name">
                    <!--<span class="">实验名称：</span>
                    <input type="text" name="search_w" class="search_w" placeholder="请输入实验名称" value="">-->
                    <span id="SpanExpName" class=""></span>
                </div>
                <div class="clear"></div>
                <div class="left_choice fl">
                    <ul>
                        <div class="clear"></div>
                        <li class="Sear">
                            <input id="Number" type="text" name="search_w" class="search_w" placeholder="请输入仪器编号" value="">
                        </li>
                        <li class="Sear">
                            <input id="Name" type="text" name="search_w" class="search_w" placeholder="请输入仪器名称" value="">
                        </li>
                        <li class="Sear">
                            <input id="Model" type="text" name="search_w" class="search_w" placeholder="请输入仪器型号" value="">
                        </li>
                        <li>
                            <a class="btn1" href="#" onclick="Search(1)">搜索</a>
                        </li>
                    </ul>
                </div>
                <div class="right_add fr">
                    
                    <a class="add" href="#" onclick="TempSelect()">选择模版快速添加</a>
                </div>
            </div>
            <div class="Teaching_plan_form">
                <div class="left_form fl">
                    <h3 class="trth">待选择仪器设备</h3>
                    <table class="PL_form">
                        <thead>
                            <tr class="trth">
                                <!--表头tr名称-->
                                <th class="checkbox">
                                    <input id="DQuanXuan" type="checkbox" name="Check_box" class="Check_box"></th>
                                <th class="Instrument_number">仪器编号</th>
                                <th class="Instrument_name">仪器名称</th>
                                <th class="Instrument_model">仪器型号</th>
                                <th class="classification">单位</th>
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
                <div class="LR_btn fl">
                    <a href="#">
                        <input type="button" class="rightbtn" onclick="XuanZe('DSelect')"></a>
                    <a href="#">
                        <input type="button" class="leftbtn" onclick="QuXiao()"></a>

                </div>
                <div class="right_form fr" id="rightDIV">
                    <h3 class="trth">已选择仪器设备 </h3>
                    <table class="PR_form">
                        <thead>
                            <tr class="trth">
                                <!--表头tr名称-->
                                <th class="checkbox">
                                    <input id="YQuanXuan" type="checkbox" name="Check_box" class="Check_box"></th>
                                <th class="Instrument_number">仪器编号</th>
                                <th class="Instrument_name">仪器名称</th>
                                <th class="Instrument_model">仪器型号</th>
                                <th class="classification">单位</th>
                                <th class="Number">数量</th>
                            </tr>
                        </thead>
                        <tbody id="YSelect">
                        </tbody>
                    </table>
                </div>
                <div class="clear"></div>
                <div class="submit_btn">
                    <span class="Save_and_submit">
                        <input type="button" value="保存并生成订单" class="Save_and_submit" onclick="javascript: Save('保存并生成');" /></span>
                    <span class="cancel">
                        <input type="button" value="取消" class="cancel" onclick="javascript: location.href = '../Plan/PlanList.aspx';" /></span>
                    <span class="Save_only"><a href="#" class="Save_only" onclick="javascript:Save('保存');">仅保存</a></span>
                </div>
            </div>
        </div>
        <div id="TempDIV" class="TempDIVCSS">
            <div class="left_choice fl">
                <ul>
                    <div class="clear"></div>
                    <li class="Sear">
                        <select class="option" id="selectLearnYear" style="width:130px;">
                            <option value="">全部学年学期</option>
                        </select>
                    </li>
                    <li class="Sear">
                        <select class="option" id="selectPlan" style="width:130px;">
                            <option value="">全部教学计划</option>
                        </select>
                    </li>
                    <li class="Sear">
                        <select class="option" id="selectExp" style="width:100px;">
                            <option value="">全部实验</option>
                        </select>
                    </li>
                    <li class="Sear">
                        <a class="TempAdd" href="#" onclick="SearchTemp(1)">确定</a>
                        <a class="TempAdd" href="#" onclick="TempXuanZe()">添加</a>
                    </li>
                </ul>
            </div>
            <div class="left_form fl" style="width:100%;">
                    <h3 class="trth">选择模板</h3>
                    <table class="PL_form">
                        <thead>
                            <tr class="trth">
                                <!--表头tr名称-->
                                <th class="checkbox">
                                    <input id="TQuanXuan" type="checkbox" name="Check_box" class="Check_box"></th>
                                <th class="Instrument_number">仪器编号</th>
                                <th class="Instrument_name">仪器名称</th>
                                <th class="Instrument_model">仪器型号</th>
                                <th class="Number">数量</th>
                                <th class="classification">单位</th>
                            </tr>
                        </thead>
                        <tbody id="TSelect">
                        </tbody>
                    </table>
                    <div class="page">
                        <!--分页页码开始-->
                        <div class="paging">
                            <span id="TPageBar"></span>
                        </div>
                        <!--分页页码结束-->
                    </div>
                    <script id="trTempT" type="text/x-jquery-tmpl">
                        <tr class="Single">
                            <td class="checkbox">
                                <input type="checkbox" name="Check_box" class="Check_box"><input type="hidden" name="TId" value="${EquipKindId}" /></td>
                            <td class="Instrument_number" name="TNumber">${Number}</td>
                            <td class="Instrument_name" name="TName">${Name}</td>
                            <td class="Instrument_model" name="TModel">${Model}</td>
                            <td class="Number" name="TCount">${Count}</td>
                            <td class="classification" name="TUnit">${Unit}</td>
                            
                        </tr>
                    </script>
                </div>
        </div>
        <asp:HiddenField ID="hidExperimentId" runat="server" />
        <asp:HiddenField ID="hidExpName" runat="server" />
        <asp:HiddenField ID="hidUserLgoinName" runat="server" />
    </form>
</body>
<script id="trTempD" type="text/x-jquery-tmpl">
    <tr class="Single">
        <td class="checkbox">
            <input type="checkbox" name="Check_box" class="Check_box"><input type="hidden" name="DId" value="${Id}" /></td>
        <td class="Instrument_number" name="DNumber">${Number}</td>
        <td class="Instrument_name" name="DName">${Name}</td>
        <td class="Instrument_model" name="DModel">${Model}</td>
        <td class="classification" name="DUnit">${Unit}</td>
    </tr>
</script>
<script id="trTempY" type="text/x-jquery-tmpl">
    <tr class="Single">
        <td class="checkbox">
            <input type="checkbox" name="Check_box" class="Check_box"><input type="hidden" name="YId" value="${Id}" /></td>
        <td class="Instrument_number" name="YNumber">${Number}</td>
        <td class="Instrument_name" name="YName">${Name}</td>
        <td class="Instrument_model" name="YModel">${Model}</td>
        <td class="classification" name="YUnit">${Unit}</td>
        <td class="Number">
            <span class="d_jiajian">
                <a href="#" class="d_jia" onclick="javascript:LessenCount(this)">-</a>
                <em>
                    <input name="YCount" type="text" value="${Count}" onchange="CheckValue(this)"></em>
                <a href="#" class="d_jian" onclick="javascript:AddCount(this)">+</a>
            </span>
        </td>
    </tr>
</script>

<script type="text/javascript">
    //教学计划缓存变量
    var PlanJson;
    //实验缓存变量
    var ExpJson;

    $(document).ready(function () {
        $("#rightDIV").css("height", "370px");
        $("#rightDIV").css("overflow", "auto");

        //加载实验名称
        $("#SpanExpName").html("实验名称：" + $("#hidExpName").val());
        //加载全选点击事件
        $("#DQuanXuan").change(function () {
            QuanXuan($(this));
        });
        $("#YQuanXuan").change(function () {
            QuanXuan($(this));
        });
        $("#TQuanXuan").change(function () {
            QuanXuan($(this));
        });
        LoadData();
        Search(1);
        BindLearnYear();
        GetPlanList();
        GetPExperiment();
        $("#selectLearnYear").change(function () {
            ResetPlan();
        });
        $("#selectPlan").change(function () {
            ResetExp();
        });
    })
    //全选
    function QuanXuan(obj) {
        var checked = $(obj).prop("checked");
        $(obj).parent().parent().parent().siblings("tbody").find("[name='Check_box']").prop("checked", checked);
    }
    //页面初始化数据
    function LoadData() {
        ExperimentId = $("#hidExperimentId").val();
        PageIndex = 1;//第几页
        PageSize = 10000;//每页条数
        $.ajax({
            type: "post",
            url: WebServiceUrl + "/ExperimentEquip/ExperimentEquip.ashx",
            dataType: "jsonp",
            jsonp: "jsoncallback",
            data: { "PageIndex": PageIndex, "PageSize": PageSize, "RelationID": ExperimentId, "action": "GetPage2" },
            success: function (json) {
                var LoadModel = $("#YSelect");
                if (json.result.Status == "error") {

                } else if (json.result.Status == "no") {
                    //LoadModel.html("<tr><td text-align='center'>无内容</td></tr>");
                } else if (json.result.Status == "ok") {
                    LoadModel.html('');
                    $("#trTempY").tmpl(json.result.Data.PagedData).appendTo(LoadModel);
                }
            },
            error: OnError
        });
    }
    //搜索
    function Search(PageIndex) {
        Number = $("#Number").val().trim();
        Name = $("#Name").val().trim();
        Model = $("#Model").val().trim();
        PageSize = 10;//每页条数
        $.ajax({
            type: "post",
            url: WebServiceUrl + "/ExperimentEquip/ExperimentEquip.ashx",
            //async: false,
            dataType: "jsonp",
            jsonp: "jsoncallback",
            data: { "PageIndex": PageIndex, "PageSize": PageSize, "Number": Number, "Name": Name, "Model": Model, "action": "GetPage" },
            success: function (json) {
                var LoadModel = $("#DSelect");
                $("#DQuanXuan").prop("checked", false);
                if (json.result.Status == "error") {

                } else if (json.result.Status == "no") {
                    LoadModel.html('');
                    //生成页码条方法（方法对象,页码条容器，当前页码，总页数，页码组容量，总行数）
                    makePageBar(Search, document.getElementById("pageBar"), PageIndex, 1, 8, 0);
                } else {
                    LoadModel.html('');
                    $("#trTempD").tmpl(json.result.Data.PagedData).appendTo(LoadModel);
                    //生成页码条方法（方法对象,页码条容器，当前页码，总页数，页码组容量，总行数）
                    makePageBar(Search, document.getElementById("pageBar"), json.result.Data.PageIndex, json.result.Data.PageCount, 8, json.result.Data.RowCount);
                }
            },
            error: OnError
        });
    }
    //保存
    function Save(type) {
        ExperimentId = $("#hidExperimentId").val();

        //遍历已选择列表
        var YiXuanID = new Array();
        $("#YSelect").children().each(function () {
            var strY = $(this).find("[name='YId']").val() + "-" + $(this).find("[name='YCount']").val() + ":" + $(this).find("[name='YName']").html();
            YiXuanID.push(strY);
        });
      
        YSelectStr= YiXuanID.toString();
        $.ajax({
            type: "Post",
            url: WebServiceUrl + "/ExperimentEquip/ExperimentEquip.ashx",//random" + Math.random(),//方法所在页面和方法名
            //async: false,
            dataType: "jsonp",
            jsonp: "jsoncallback",
            data: { "ExperimentId": ExperimentId, "YSelectStr": YSelectStr, "action": "SaveEquipList" },
            success: function (json) {
                if (json.result.Status == "error") {
                    layer.msg("保存失败");
                }
                else if (json.result.Status == "no") {
                    layer.msg(json.result.Msg);
                }
                else if (json.result.Status == "ok") {
                    if (type == "保存") {
                        layer.msg(json.result.Msg);
                    } else if (type == "保存并生成") {
                        //CreateOrder(YSelectStr);
                        CreateOrder("");
                    }
                }
            },
            error: function () {
                layer.msg("保存失败");
            }
        });
    }
    //生成订单
    function CreateOrder(YSelectStr) {
        ExperimentId = $("#hidExperimentId").val();
        UserLgoinName = $("#hidUserLgoinName").val();
        Type = 0;

        $.ajax({
            type: "Post",
            url: WebServiceUrl + "/ExperimentEquip/ExperimentEquip.ashx",
            //async: false,
            dataType: "jsonp",
            jsonp: "jsoncallback",
            //data: { "ExperimentId": ExperimentId, "YSelectStr": YSelectStr, "LoanName": UserLgoinName, "Type": Type, "Creator": UserLgoinName },
            data: { "ExperimentId": ExperimentId, "LoanName": UserLgoinName, "Type": Type, "Creator": UserLgoinNamem, "action": "CreateOrder" },
            success: function (json) {
                if (json.result.Status == "error") {
                    layer.msg("生成订单失败！")
                }
                else if (json.result.Status == "no") {
                    layer.msg(json.result.Msg);
                }
                else if (json.result.Status == "ok") {
                    layer.msg(json.result.Msg);
                    //location.href = "../Plan/PlanList.aspx";
                }
            },
            error: OnError
        });
    }
    //错误处理
    function OnError(XMLHttpRequest, textStatus, errorThrown) {
        //alert(XMLHttpRequest + "-" + textStatus + "-" + errorThrown);
    }
    //选择
    function XuanZe() {
        //获取待选择列表中选择的数据
        var DArray = new Array();
        var trs = $("#DSelect").children();

        trs.each(function () {
            var ischecked = $(this).find("[name='Check_box']").is(":checked");
            if (!ischecked) {
                return;
            }
            var DId = $(this).find("[name='DId']").val();
            var DNumber = $(this).find("[name='DNumber']").html();
            var DName = $(this).find("[name='DName']").html();
            var DModel = $(this).find("[name='DModel']").html();
            var DUnit = $(this).find("[name='DUnit']").html();
            DArray.push("{\"Id\":" + DId + ",\"Number\":\"" + DNumber + "\",\"Name\":\"" + DName + "\",\"Model\":\"" + DModel + "\",\"Unit\":\"" + DUnit + "\"}");
        });

        //遍历已选择列表
        var YiXuanID = "";
        $("#YSelect").children().each(function () {
            YiXuanID += "," + $(this).find("[name='YId']").val() + ",";
        });
        //将数据加载到已选择列表
        var JsonSelect = JSON.parse("[" + DArray.toString() + "]");

        $.each(JsonSelect, function (index, json) {
            if (YiXuanID.indexOf("," + json.Id + ",") != -1) {
                return;
            }
            var temp = $("#trTempY").html();
            temp = temp.replace("${Id}", json.Id.toString());
            temp = temp.replace("${Number}", json.Number.toString());
            temp = temp.replace("${Name}", json.Name.toString());
            temp = temp.replace("${Model}", json.Model.toString());
            temp = temp.replace("${Unit}", json.Unit.toString());
            temp = temp.replace("${Count}", "1");
            $("#YSelect").append(temp);
        });
    }
    //取消选择
    function QuXiao() {
        //yixuanze
        var trs = $("#YSelect").children();

        trs.each(function () {
            var ischecked = $(this).find("[name='Check_box']").is(":checked");
            if (ischecked) {
                $(this).remove();
            }
        });
    }
    //增加数量
    function AddCount(a) {
        var number = $(a).parent().find("[name='YCount']");
        number.val(parseInt(number.val()) + 1);
    }
    //减少数量
    function LessenCount(a) {
        var number = $(a).parent().find("[name='YCount']");
        if (number.val() <= 1) {
            return;
        }
        number.val(parseInt(number.val()) - 1);

    }
    //检查值
    function CheckValue(text) {
        var value = $(text).val();
        if (!isNaN(value)) {
            if (value <= 1) {
                $(text).val("1");
                return;
            }
            $(text).val(parseInt(value));
        } else {
            $(text).val("1");
        }

    }
    //加载学年学期
    function BindLearnYear() {
        $LearnYear = $("#selectLearnYear");
        $LearnYear.empty();
        $LearnYear.append("<option value=''>全部学年学期</option>");
        $.ajax({
            url: "/CommonHandler/UnifiedHelpHandler.ashx",
            type: "post",
            async: false,
            dataType: "json",
            data: { "Func": "GetStudySectionData" },
            success: function (json) {
                if (json.result.errNum.toString() == "0") {
                    $(json.result.retData).each(function (i, n) {
                        $LearnYear.append('<option value="' + n.Id + '">' + n.Academic + '</option>');                        
                    });
                }
                BindTeacher();
                Load1();
            },
            error: OnError
        });
    }
    //获取教学计划
    function GetPlanList() {
        UserLgoinName = $('#hidUserLgoinName').val();
        PageSize = 10;
        $.ajax({
            type: "Post",
            url: WebServiceUrl + "/Plan/Plan.ashx",
            async: false,
            dataType: "jsonp",
            jsonp: "jsoncallback",
            data: { "UserLgoinName": UserLgoinName, "action": "GetSelectOption" },
            success: function (json) {
                if (json.result.Status == "error") {
                    return;
                }
                if (json.result.Status == "no") {
                    return;
                }
                if (json.result.Status == "ok") {
                    var ds = json.result.Data;
                    PlanJson = $.parseJSON(ds).ds;
                    $("#selectPlan").empty();
                    $("#selectPlan").append("<option value=''>全部教学计划</option>");
                    $.each(PlanJson, function (i, item) {
                        var option = "<option value='" + item.Id + "'>" + item.Name + "</option>"
                        $("#selectPlan").append(option);
                    });
                }
            },
            error: OnError
        });

    }
    //获取实验
    function GetPExperiment() {
        UserLgoinName = $('#hidUserLgoinName').val();
        //PlanId = $('#Plan option:selected').val();

        $.ajax({
            type: "Post",
            url: WebServiceUrl + "/Experiment/Experiment.ashx",
            async: false,
            dataType: "jsonp",
            jsonp: "jsoncallback",
            data: { "UserLgoinName": UserLgoinName, "action": "GetSelectOption" },
            success: function (json) {
                $("#selectExp").empty();
                $("#selectExp").append("<option value=''>请选择</option>");
                if (json.result.Status == "error") {
                    //layer.msg(json.result.Msg);
                    return;
                }
                if (json.result.Status == "no") {
                    //layer.msg(json.result.Msg);
                    return;
                }
                if (json.result.Status == "ok") {
                    var ds = json.result.Data;
                    ExpJson = $.parseJSON(ds).ds;
                    $.each(ExpJson, function (i, item) {
                        var option = "<option value='" + item.Id + "'>" + item.Name + "</option>"
                        $("#selectExp").append(option);
                    });
                }
            },
            error: OnError
        });
    }
    //重置教学计划
    function ResetPlan() {
        var LearnYear = $('#selectLearnYear option:selected').val();
        $("#selectPlan").empty();
        $("#selectPlan").append("<option value=''>全部教学计划</option>");
        $.each(PlanJson, function (i, item) {
            if (LearnYear != "" && item.LearnYear != LearnYear) {
                return;
            }
            var option = "<option value='" + item.Id + "'>" + item.Name + "</option>"
            $("#selectPlan").append(option);
        });

    }
    //重置实验
    function ResetExp() {
        var Plan = $('#selectPlan option:selected').val();
        $("#selectExp").empty();
        $("#selectExp").append("<option value=''>全部实验</option>");
        $.each(ExpJson, function (i, item) {
            if (Plan != "" && item.PlanId != Plan) {
                return;
            }
            var option = "<option value='" + item.Id + "'>" + item.Name + "</option>"
            $("#selectExp").append(option);
        });

    }
    //搜索
    function SearchTemp(PageIndex) {
        var ExpId = $('#selectExp option:selected').val();
        PageSize = 10;//每页条数
        $.ajax({
            type: "post",
            url: WebServiceUrl + "/ExperimentEquip/ExperimentEquip.ashx",
            //async: false,
            dataType: "jsonp",
            jsonp: "jsoncallback",
            data: { "PageIndex": PageIndex, "PageSize": PageSize, "RelationID": ExpId, "action": "GetPageTempSelect" },
            success: function (json) {
                var LoadModel = $("#TSelect");
                $("#TQuanXuan").prop("checked", false);
                if (json.result.Status == "error") {

                } else if (json.result.Status == "no") {
                    LoadModel.html('');
                    //生成页码条方法（方法对象,页码条容器，当前页码，总页数，页码组容量，总行数）
                    makePageBar(SearchTemp, document.getElementById("TPageBar"), PageIndex, 1, 8, 0);
                } else {
                    LoadModel.html('');
                    var ds = json.result.Data.PagedData;
                    var dsJson = $.parseJSON(ds).ds;
                    $("#trTempT").tmpl(dsJson).appendTo(LoadModel);
                    //生成页码条方法（方法对象,页码条容器，当前页码，总页数，页码组容量，总行数）
                    makePageBar(SearchTemp, document.getElementById("TPageBar"), json.result.Data.PageIndex, json.result.Data.PageCount, 8, json.result.Data.RowCount);
                }
            },
            error: OnError
        });
    }
    //选择
    function TempXuanZe() {
        //获取待选择列表中选择的数据
        var DArray = new Array();
        var trs = $("#TSelect").children();

        trs.each(function () {
            var ischecked = $(this).find("[name='Check_box']").is(":checked");
            if (!ischecked) {
                return;
            }
            var TId = $(this).find("[name='TId']").val();
            var TNumber = $(this).find("[name='TNumber']").html();
            var TName = $(this).find("[name='TName']").html();
            var TModel = $(this).find("[name='TModel']").html();
            var TUnit = $(this).find("[name='TUnit']").html();
            var TCount = $(this).find("[name='TCount']").html();
            DArray.push("{\"Id\":" + TId + ",\"Number\":\"" + TNumber + "\",\"Name\":\"" + TName + "\",\"Model\":\"" + TModel + "\",\"Unit\":\"" + TUnit + "\",\"Count\":\"" + TCount + "\"}");
        });

        //遍历已选择列表
        var YiXuanID = "";
        $("#YSelect").children().each(function () {
            YiXuanID += "," + $(this).find("[name='YId']").val() + ",";
        });
        //将数据加载到已选择列表
        var JsonSelect = JSON.parse("[" + DArray.toString() + "]");

        $.each(JsonSelect, function (index, json) {
            if (YiXuanID.indexOf("," + json.Id + ",") != -1) {
                return;
            }
            var temp = $("#trTempY").html();
            temp = temp.replace("${Id}", json.Id.toString());
            temp = temp.replace("${Number}", json.Number.toString());
            temp = temp.replace("${Name}", json.Name.toString());
            temp = temp.replace("${Model}", json.Model.toString());
            temp = temp.replace("${Unit}", json.Unit.toString());
            temp = temp.replace("${Count}", json.Count.toString());
            $("#YSelect").append(temp);
        });
    }
    //弹出模板选择
    function TempSelect() {

        //页面层
        layer.open({
            type: 1,
            title: '选择模板',
            shade: 0,
            offset: ['20px','20px'],
            skin: 'layui-layer-rim', //加上边框
            area: ['50%', '70%'], //宽高
            //content: 'html内容'
            content: $("#TempDIV")
        });
        SearchTemp(1);
    }

</script>
</html>
