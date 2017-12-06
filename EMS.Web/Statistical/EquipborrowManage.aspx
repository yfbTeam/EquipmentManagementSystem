<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EquipborrowManage.aspx.cs" Inherits="EMS.Web.Statistical.EquipborrowManage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="Generator" content="EditPlus®">
    <meta name="Author" content="">
    <meta name="Keywords" content="">
    <meta name="Description" content="">
    <title>资产借用管理</title>
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
        .TempDIVCSS {
            display: none;
            /*width:600px;
            height:800px;*/
        }

        .TempAdd {
            display: block;
            padding: 8px 8px;
            background: #2789ba;
            border-radius: 3px;
            color: #fff;
            float: left;
            margin-right: 4px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="Teaching_plan_management">
            <h1 class="Page_name">设置可借用资产</h1>

            <div class="Teaching_plan_form">
                 <div class="right_form fl" id="rightDIV">
                    <div class="Operation_area">
                        <div class="Experiment_name">
                            <span id="SpanExpName" class=""></span>
                        </div>
                        <div class="clear"></div>
                        <div class="left_choice fl">
                            <ul>
                                <li class="Sear">行数：
                                    <select class="option" id="YIndex" style="width: 90px">
                                        <option value='10'>10行</option>
                                        <option value='20'>20行</option>
                                        <option value='50'>50行</option>
                                        <option value='100'>100行</option>
                                    </select>

                                </li>
                                <li class="Sear">分类：
                                    <select class="option" id="YEQtype" style="width: 120px">
                                        <option value=''>全部</option>
                                        <option value='0'>教学资产</option>
                                        <option value='1'>科研资产</option>
                                        <option value='2'>办公资产</option>
                                    </select>

                                </li>
                                <li class="Sear">
                                    <input type="text" name="search_w" style="width: 120px" class="search_w" id="Yname" placeholder="请输入设备名称" value="" />
                                </li>
                                <li>
                                    <a class="btn1" href="#" onclick="LoadData()">搜索</a>
                                </li>
                            </ul>
                        </div>

                    </div>
                    <h3 class="trth">可借用资产 </h3>
                    <div style="height: 300px; overflow: auto">
                        <table class="PR_form">
                            <thead>
                                <tr class="trth">
                                    <!--表头tr名称-->
                                    <th class="checkbox">
                                        <input id="YQuanXuan" type="checkbox" name="Check_box" class="Check_box"></th>
                                    <th class="Instrument_number">资产号</th>
                                    <th class="Instrument_name">资产名称</th>
                                    <th class="Instrument_model">计量单位</th>

                                </tr>
                            </thead>
                            <tbody id="YSelect">
                            </tbody>
                        </table>
                    </div>
                </div>
                <div class="LR_btn fl">
                    <a href="#">
                        <input type="button" class="rightbtn" onclick="QuXiao()"></a>
                    <a href="#">
                        <input type="button" class="leftbtn" onclick="XuanZe('DSelect')"></a>

                </div>
                <div class="left_form fl">
                    <div class="Operation_area">
                        <div class="Experiment_name">
                            <span id="SpanExpName" class=""></span>
                        </div>
                        <div class="clear"></div>
                        <div class="left_choice fl">
                            <ul>
                                <li class="Sear">行数：
                                    <select class="option" id="DIndex" style="width: 90px">
                                        <option value='10'>10行</option>
                                        <option value='20'>20行</option>
                                        <option value='50'>50行</option>
                                        <option value='100'>100行</option>
                                    </select>

                                </li>
                                <li class="Sear">分类：
                                    <select class="option" id="EQtype" style="width: 120px">
                                        <option value=''>全部</option>
                                        <option value='0'>教学资产</option>
                                        <option value='1'>科研资产</option>
                                        <option value='2'>办公资产</option>
                                    </select>

                                </li>
                                <li class="Sear">
                                    <input type="text" name="search_w" style="width: 120px" class="search_w" id="name" placeholder="请输入设备名称" value="" />
                                </li>
                                <li>
                                    <a class="btn1" href="#" onclick="Search()">搜索</a>
                                </li>
                            </ul>
                        </div>

                    </div>
                    <h3 class="trth">不可借用资产</h3>
                    <div style="height: 300px; overflow: auto">
                        <table class="PL_form">
                            <thead>
                                <tr class="trth">
                                    <!--表头tr名称-->
                                    <th class="checkbox">
                                        <input id="DQuanXuan" type="checkbox" name="Check_box" class="Check_box"></th>
                                    <th class="Instrument_number">资产号</th>
                                    <th class="Instrument_name">资产名称</th>
                                    <th class="Instrument_model">计量单位</th>

                                </tr>
                            </thead>
                            <tbody id="DSelect">
                            </tbody>
                        </table>
                    </div>

                </div>
                <div class="clear"></div>
                <div class="submit_btn">
                    <span class="Save_and_submit">
                        <input type="button" value="提交" class="Save_and_submit" onclick="javascript: Save('提交');" /></span>
                    <span class="cancel">
                        <input type="button" value="取消" class="cancel" onclick="javascript: quxiao();" /></span>

                </div>
            </div>
        </div>
        <div id="TempDIV" class="TempDIVCSS">
            <div class="left_choice fl">
                <ul>
                    <div class="clear"></div>
                    <li class="Sear">
                        <select class="option" id="selectLearnYear" style="width: 130px;">
                            <option value="">全部学年学期</option>
                        </select>
                    </li>
                    <li class="Sear">
                        <select class="option" id="selectPlan" style="width: 130px;">
                            <option value="">全部教学计划</option>
                        </select>
                    </li>
                    <li class="Sear">
                        <select class="option" id="selectExp" style="width: 100px;">
                            <option value="">全部实验</option>
                        </select>
                    </li>
                    <li class="Sear">
                        <a class="TempAdd" href="#" onclick="SearchTemp(1)">确定</a>
                        <a class="TempAdd" href="#" onclick="TempXuanZe()">添加</a>
                    </li>
                </ul>
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
        <td class="Instrument_number" name="DAssetNumber">${AssetNumber}</td>
        <td class="Instrument_name" name="DAssetName">${AssetName}</td>
        <td class="Instrument_model" name="DUnit">${Unit}</td>


    </tr>
</script>
<script id="trTempY" type="text/x-jquery-tmpl">
    <tr class="Single">
        <td class="checkbox">
            <input type="checkbox" name="Check_box" class="Check_box"><input type="hidden" name="YId" value="${Id}" /></td>
        <td class="Instrument_number" name="YAssetNumber">${AssetNumber}</td>
        <td class="Instrument_name" name="YAssetName">${AssetName}</td>
        <td class="Instrument_model" name="YUnit">${Unit}</td>


    </tr>
</script>

<script type="text/javascript">
    //加载
    $(document).ready(function () {
        $("#DQuanXuan").change(function () {
            QuanXuan($(this));
        });
        $("#YQuanXuan").change(function () {
            QuanXuan($(this));
        });
        Search();
        LoadData();
    })

    //全选
    function QuanXuan(obj) {
        var checked = $(obj).prop("checked");
        $(obj).parent().parent().parent().siblings("tbody").find("[name='Check_box']").prop("checked", checked);
    }

    //取消按钮
    function quxiao()
    {
        LoadData();
        Search();
    }


    //页面初始化数据，绑定可借用资产
    function LoadData() {
        $("#DSelect").html('');
        BorrowYN = 1;
        EQtype = $("#YEQtype").val().trim();
        name = $("#Yname").val().trim();
        index = $("#YIndex").val().trim();
        $.ajax({
            type: "post",
            url: WebServiceUrl + "/Statistical/Statistical.ashx",
            dataType: "jsonp",
            jsonp: "jsoncallback",
            data: { "BorrowYN": BorrowYN, "EQtype": EQtype, "name": name, "index": index, "action": "EquipborrowManage" },
            success: function (json) {
                var LoadModel = $("#YSelect");
                $("#YQuanXuan").prop("checked", false);
                if (json.result.Status == "error") {

                } else {
                    LoadModel.html('');
                    $("#trTempY").tmpl(json.result).appendTo(LoadModel);

                    ////生成页码条方法（方法对象,页码条容器，当前页码，总页数，页码组容量，总行数）
                    //  makePageBar(Search, document.getElementById("pageBar"), PageIndex, 1, 8, 0);
                }
            },
            error: OnError
        });
    }


    //搜索
    function Search() {

        $("#YSelect").html('');

        BorrowYN = 0;
        EQtype = $("#EQtype").val().trim();
        name = $("#name").val().trim();
        index = $("#DIndex").val().trim();
        $.ajax({
            type: "post",
            url: WebServiceUrl + "/Statistical/Statistical.ashx",
            //async: false,
            dataType: "jsonp",
            jsonp: "jsoncallback",
            data: { "BorrowYN": BorrowYN, "EQtype": EQtype, "name": name, "index": index, "action": "EquipborrowManage" },
            success: function (json) {
                var LoadModel = $("#DSelect");
                $("#DQuanXuan").prop("checked", false);
                if (json.result.Status == "error") {

                } else {
                    LoadModel.html('');
                    $("#trTempD").tmpl(json.result).appendTo(LoadModel);

                    ////生成页码条方法（方法对象,页码条容器，当前页码，总页数，页码组容量，总行数）
                    //  makePageBar(Search, document.getElementById("pageBar"), PageIndex, 1, 8, 0);
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
            var DAssetNumber = $(this).find("[name='DAssetNumber']").html();
            var DAssetName = $(this).find("[name='DAssetName']").html();
            var DUnit = $(this).find("[name='DUnit']").html();
            DArray.push("{\"Id\":" + DId + ",\"AssetNumber\":\"" + DAssetNumber + "\",\"AssetName\":\"" + DAssetName + "\",\"Unit\":\"" + DUnit + "\"}");
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
            temp = temp.replace("${AssetNumber}", json.AssetNumber.toString());
            temp = temp.replace("${AssetName}", json.AssetName.toString());
            temp = temp.replace("${Unit}", json.Unit.toString());

            $("#YSelect").append(temp);
        });


        var tr = $("#DSelect").children();
        tr.each(function () {
            var ischecked = $(this).find("[name='Check_box']").is(":checked");
            if (ischecked) {
                $(this).remove();
            }
        });
    }

    //取消选择
    function QuXiao() {
        //yixuanze
        //var trs = $("#YSelect").children();

        //trs.each(function () {
        //    var ischecked = $(this).find("[name='Check_box']").is(":checked");
        //    if (ischecked) {
        //        $(this).remove();
        //    }
        //});


        //获取待选择列表中选择的数据
        var DArray = new Array();
        var trs = $("#YSelect").children();

        trs.each(function () {
            var ischecked = $(this).find("[name='Check_box']").is(":checked");
            if (!ischecked) {
                return;
            }
            var YId = $(this).find("[name='YId']").val();
            var YAssetNumber = $(this).find("[name='YAssetNumber']").html();
            var YAssetName = $(this).find("[name='YAssetName']").html();
            var YUnit = $(this).find("[name='YUnit']").html();
            DArray.push("{\"Id\":" + YId + ",\"AssetNumber\":\"" + YAssetNumber + "\",\"AssetName\":\"" + YAssetName + "\",\"Unit\":\"" + YUnit + "\"}");
        });

        //遍历已选择列表
        var YiXuanID = "";
        $("#DSelect").children().each(function () {
            YiXuanID += "," + $(this).find("[name='DId']").val() + ",";
        });
        //将数据加载到已选择列表
        var JsonSelect = JSON.parse("[" + DArray.toString() + "]");

        $.each(JsonSelect, function (index, json) {
            if (YiXuanID.indexOf("," + json.Id + ",") != -1) {
                return;
            }
            var temp = $("#trTempD").html();
            temp = temp.replace("${Id}", json.Id.toString());
            temp = temp.replace("${AssetNumber}", json.AssetNumber.toString());
            temp = temp.replace("${AssetName}", json.AssetName.toString());
            temp = temp.replace("${Unit}", json.Unit.toString());

            $("#DSelect").append(temp);
        });



        var tr = $("#YSelect").children();
        tr.each(function () {
            var ischecked = $(this).find("[name='Check_box']").is(":checked");
            if (ischecked) {
                $(this).remove();
            }
        });

    }


    //保存
    function Save(type) {

        //遍历可借用选择列表
        var YiXuanID = new Array();
        $("#YSelect").children().each(function () {
            //  var strY = $(this).find("[name='YId']").val() + "-" + $(this).find("[name='YId']").val() + ":" + $(this).find("[name='YId']").val();
            var strY = $(this).find("[name='YId']").val();
            YiXuanID.push(strY);

        });

        //遍历不可借用选择列表
        var DYiXuanID = new Array();
        $("#DSelect").children().each(function () {
            //  var strY = $(this).find("[name='YId']").val() + "-" + $(this).find("[name='YId']").val() + ":" + $(this).find("[name='YId']").val();
            var strD = $(this).find("[name='DId']").val();
            DYiXuanID.push(strD);

        });




        var YSelectStr = YiXuanID.toString();
        var DSelectStr = DYiXuanID.toString();

        $.ajax({
            type: "post",
            url: WebServiceUrl + "/Statistical/Statistical.ashx",
            //async: false,
            dataType: "jsonp",
            jsonp: "jsoncallback",
            traditional: true,
            data: { "action": "SetEquipDatailBC", "YSelectStr": YSelectStr, "DSelectStr": DSelectStr },// "YSelectStr": YSelectStr, "action": "SetEquipDatailBC" 
            success: function (json) {
                var str;
                for (var i = 0; i < json.result.length; i++) {
                    str = json.result[i].value;
                }

                if (str == "ok") {
                    layer.msg("保存成功");

                }
                else if (str == "no") {
                    layer.msg("保存失败");
                } else if (str == "qx") {
                    layer.msg("数据没有更改，无需提交");
                } else {
                    layer.msg("保存失败");
                }

            },
            error: function () {
                layer.msg("保存失败");
            }
        });

    }
</script>
</html>
