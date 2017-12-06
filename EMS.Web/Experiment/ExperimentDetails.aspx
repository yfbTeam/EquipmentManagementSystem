<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExperimentDetails.aspx.cs" Inherits="EMS.Web.Experiment.ExperimentDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>教学计划实验详情</title>
    <link href="../css/common.css" rel="stylesheet" />
    <link href="../css/style.css" rel="stylesheet" />
    <link href="../css/iconfont.css" rel="stylesheet" />
    <link href="../css/animate.css" rel="stylesheet" />

    <script src="../js/Common.js"></script>
    <script src="../js/jquery-1.11.2.min.js"></script>
    <script src="../js/jquery.tmpl.js"></script>
    <script src="../js/layer/layer.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="Teaching_plan_management">
            <span class="cancel">
                <input class="Topic_btn" type="button" value="返回" onclick="javascript: history.back(-1);" style="float: right;" /></span>
            <h1 class="Page_name">课程：<span id="PlanName"></span>-->实验详情</h1>
            <table class="InfoTable">
                <tr>
                    <td>实验名称：</td>
                    <td><span id="Name"></span></td>
                    <td>实验类型：</td>
                    <td><span id="Type"></span></td>
                    <td>是否开放：</td>
                    <td><span id="IsOpen"></span></td>  
                    <td>实验地点：</td>
                    <td><span id="Place"></span></td>
                </tr>
                <tr>
                    <td>开课日期：</td>
                    <td><span id="StartDate"></span></td>
                    <td>周次：</td>
                    <td><span id="Week"></span></td>
                    <td>星期：</td>
                    <td><span id="Weekday"></span></td>
                    <td>学时：</td>
                    <td><span id="ClassHour"></span></td>
                </tr>
                <tr>
                    <td>节次：</td>
                    <td><span id="Part"></span></td>
                    <td>每组人数：</td>
                    <td><span id="GroupMemberNumber"></span></td>
                    <td>每次组数：</td>
                    <td><span id="GroupNumber"></span></td>
                    <td>订单状态：</td>
                    <td><span id="Status"></span></td>
                </tr>
                <tr>
                    <td>创建人：</td>
                    <td><span id="CreateName"></span></td>
                    <td>创建时间：</td>
                    <td><span id="CreateTime"></span></td>
                    <td>修改人：</td>
                    <td><span id="TwoUserName"></span></td>
                    <td>修改时间：</td>
                    <td><span id="UpdateTime"></span></td>
                </tr>
                <tr>
                    <td>班级：</td>
                    <td colspan="7"><span id="ClassName"></span></td>
                </tr>
                <tr>
                    <td>使用仪器设备：</td>
                    <td colspan="3"><pre><span id="NeedEquip"></span></pre></td>
                    <td>实验内容：</td>
                    <td colspan="3"><pre><span id="Contents"></span></pre></td>
                </tr>
            </table>
            <br />
            <div class="Honor_management">
                <div class="thetrth">
                    <span class="leftcon fl">订单编号：<span id="OrderNo"></span> </span>
                    <span class="rightcon fr">数量：<span id="Count">0</span></span>
                </div>
                <table class="W_form">
                    <thead>
                        <tr class="trth">
                            <th class="number">序号</th>
                            <th class="">仪器名称</th>
                            <th>规格</th>
                            <th>数量</th>
                            <th>单位</th>
                            <th>存放地点</th>
                            <th>状态</th>
                            <th>借出时间</th>
                            <th>归还时间</th>
                        </tr>
                    </thead>
                    <tbody id="tbList"></tbody>
                </table>
            </div>


        </div>
        <asp:HiddenField ID="hidId" runat="server" />
        <asp:HiddenField ID="hidName" runat="server" />
    </form>
    <script type="text/javascript">
        var Id = $('#hidId').val();
        $(document).ready(function () {
            $('#PlanName').html($('#hidName').val());
            GetExperiment();
            //BindEquipList();
        });
        //获得实验
        function GetExperiment() {
            $.ajax({
                type: "Post",
                url: WebServiceUrl + "/Experiment/Experiment.ashx",
                //async: false,
                dataType: "jsonp",
                jsonp: "jsoncallback",
                data: { "Id": Id, "action": "GetExperiment" },
                success: function (json) {
                    if (json.result.Status == "error") {
                        //layer.msg(json.result.Msg);
                        return;
                    }
                    if (json.result.Status == "no") {
                        layer.msg(json.result.Msg);
                        return;
                    }
                    if (json.result.Status == "ok") {
                        Experiment = json.result.Data.PagedData[0];
                        $('#Name').html(Experiment.Name);
                        $('#Type').html(Experiment.TypeName);
                        if (Experiment.IsOpen == 0) {
                            $('#IsOpen').html("是");
                        } else {
                            $('#IsOpen').html("不是");
                        }
                        if (Experiment.Status == 0) {
                            $('#Status').html("未生成订单");
                            $("#OrderNo").html("未生成订单");
                        } else {
                            $('#Status').html("已生成订单");
                            BindEquipList();
                        }
                        $('#StartDate').html(DateTimeConvert(Experiment.StartDate));
                        $('#Week').html(Experiment.Week);
                        $('#Weekday').html(Experiment.Weekday);
                        $('#ClassHour').html(Experiment.ClassHour);
                        $('#Part').html(Experiment.Part);
                        $('#Place').html(Experiment.Place);
                        $('#GroupMemberNumber').html(Experiment.GroupMemberNumber);
                        $('#GroupNumber').html(Experiment.GroupNumber);
                        $('#NeedEquip').html(Experiment.NeedEquip);
                        $('#CreateName').html(Experiment.CreateName);
                        $('#TwoUserName').html(Experiment.TwoUserName);
                        $('#CreateTime').html(DateTimeConvert(Experiment.CreateTime, "yyyy-MM-dd HH:mm:ss"));
                        $('#UpdateTime').html(DateTimeConvert(Experiment.UpdateTime, "yyyy-MM-dd HH:mm:ss"));
                        $('#Contents').html(Experiment.Contents);
                        $('#ClassName').html(Experiment.ClassName);

                    }
                },
                error: OnError
            });
        }
        //错误处理
        function OnError(XMLHttpRequest, textStatus, errorThrown) {
            //layer.msg('');
        }
        //获得实验设备列表
        function BindEquipList() {
            //初始化序号 
            var PageIndex = 1;
            pageNum = (PageIndex - 1) * 10 + 1
            $.ajax({
                type: "Post",
                url: WebServiceUrl + "/Experiment/Experiment.ashx" ,//random" + Math.random(),//方法所在页面和方法名
                //async: false,
                dataType: "jsonp",
                jsonp: "jsoncallback",
                data: { "Id": Id, "action": "GetOrderEquipList" },
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
                        $("#OrderNo").html(json.result.Data[0].OrderNo);
                        var EquipCount = 0;
                        $.each(json.result.Data, function () {
                            EquipCount += parseInt(this.Count);
                        });
                        $("#Count").html(EquipCount);
                        if ($("#Count").html() == "") {
                            $("#Count").html("0");
                        }
                        $("#tbList").html('');
                        $("#trTemp").tmpl(json.result.Data).appendTo("#tbList");
                    }
                },
                error: OnError
            });
        }
        function OrderType(type) {
            if (type == 1) {
                return "未归还";
            } else if (type == 2) {
                return "归还";
            }
            
        }
    </script>
    <script id="trTemp" type="text/x-jquery-tmpl">
        <tr class="Single">
            <td class="number">${pageIndex()}</td>
            <td class=""><span title="${AssetName}">${NameLengthUpdate(AssetName,15)}</span></td>
            <td >${BrandStandardModel}</td>
            <td >${Count}</td>
            <td >${Unit}</td>
            <td>${StorageLocation}</td>
            <td>${OrderType(Type)}</td>
            <td>${LendTime}</td>
            <td>${ReturnTime}</td>
        </tr>
    </script>
</body>
</html>
