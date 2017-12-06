<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExperimentEdit.aspx.cs" Inherits="EMS.Web.Experiment.ExperimentEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>编辑教学计划实验</title>
    <link href="../css/common.css" rel="stylesheet" />
    <link href="../css/style.css" rel="stylesheet" />
    <link href="../css/iconfont.css" rel="stylesheet" />
    <link href="../css/animate.css" rel="stylesheet" />

    <script src="../js/Common.js"></script>
    <script src="../js/jquery-1.11.2.min.js"></script>
    <script src="../js/jquery.tmpl.js"></script>
    <script src="../js/layer/layer.js"></script>
    <script src="/js/My97DatePicker/WdatePicker.js"></script>
    <style type="text/css">
        .Class_ul{
            width:450px;
           
        }
        .Class_ul li{
            display:inline-block;
            margin:10px 5px;
           
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="yy_dialog">
            <div class="t_content">
                <div class="yy_tab">
                    <div class="content">
                        <div class="tc">
                            <div class="t_message">
                                <div class="message_con">
                                    <table class="m_top">
                                        <tbody>
                                            <tr>
                                                <td class="mi"><span class="m">实验名称：</span></td>
                                                <td class="ku">
                                                    <input id="Name" class="hu" type="text" placeholder=" 请输入实验名称"/></td>
                                                <td class="mi"><span class="m">实验类型：</span></td>
                                                <td class="ku">
                                                    <select class="option" id="Type">  
                                                    </select>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="mi"><span class="m">是否开放：</span></td>
                                                <td>
                                                    <input type="radio" name="IsOpen" value="0" checked="checked" />是
                                                    <input type="radio" name="IsOpen" value="1"/>否
                                                </td>
                                                <td class="mi"><span class="m">日期：</span></td>
                                                <td class="ku">
                                                    <input id="StartDate" class="hu Wdate" type="text" placeholder="选择日期" onFocus="var sdate=document.getElementById('hidStarDate').value;var edate=document.getElementById('hidEndDate').value;WdatePicker({minDate:sdate,maxDate:edate,dateFmt:'yyyy-MM-dd'})"/>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="mi"><span class="m">周次：</span></td>
                                                <td class="ku">
                                                    <input id="Week" class="hu" type="text" placeholder=" 请输入周次" value="1"/>
                                                </td>
                                                <td class="mi"><span class="m">星期：</span></td>
                                                <td class="ku">
                                                    <%--<input id="Weekday" class="hu" type="text" placeholder=" 请输入星期"/>--%>
                                                    <select class="option" id="Weekday">
                                                        <option value="1">1</option>
                                                        <option value="2">2</option>
                                                        <option value="3">3</option>
                                                        <option value="4">4</option>
                                                        <option value="5">5</option>
                                                        <option value="6">6</option>
                                                        <option value="7">7</option>
                                                    </select>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="mi"><span class="m">学时：</span></td>
                                                <td class="ku">
                                                    <%--<input id="ClassHour" class="hu" type="text" placeholder=" 请输入学时"/>--%>
                                                    <select class="option" id="ClassHour">
                                                        <option value="1">1</option>
                                                        <option value="2">2</option>
                                                        <option value="3">3</option>
                                                        <option value="4">4</option>
                                                        <option value="5">5</option>
                                                        <option value="6">6</option>
                                                        <option value="7">7</option>
                                                        <option value="8">8</option>
                                                        <option value="9">9</option>
                                                        <option value="10">10</option>
                                                    </select>
                                                </td>
                                                <td class="mi"><span class="m">节次：</span></td>
                                                <td class="ku">
                                                    <input id="Part" class="hu" type="text" placeholder="格式：3/4"/>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="mi"><span class="m">班级：</span></td>
                                                <td class="ku">
                                                    <input id="Class" class="hu" type="text" />
                                                </td>
                                                <td class="mi"><span class="m">实验地点：</span></td>
                                                <td class="ku">
                                                    <select class="option" id="Place">
                                                    </select>
                                                </td>
                                            </tr>
                                            
                                            <tr >
                                                <td class="mi"><span class="m">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;实验类别：</span></td>
                                                <td class="ku">
                                                    <select class="option" id="Category">
                                                        <option value="0">室内上课</option>
                                                        <option value="1" selected="selected">野外实践</option>
                                                    </select>
                                                </td>
                                                <td class="mi" ><span class="m" id="ComputerRoom1">机房：</span></td>
                                                <td class="ku">
                                                    <select class="option" id="ComputerRoom">
                                                    </select>
                                                </td>
                                            </tr>
                                            <tr id="Group">
                                                <td class="mi"><span class="m">每组人数：</span></td>
                                                <td class="ku">
                                                    <input id="GroupMemberNumber" class="hu" type="text" value="1"/>
                                                </td>
                                                <td class="mi"><span class="m">每次组数：</span></td>
                                                <td class="ku">
                                                    <input id="GroupNumber" class="hu" type="text" value="1"/>
                                                </td>

                                            </tr>
                                            <tr id="NeedEquip1">
                                                <td class="mi"><span class="m">使用仪器设备：</span></td>
                                                <td class="ku" colspan="3">
                                                    <textarea id="NeedEquip" name="comment" rows="3" style="width: 492px;color:#000000;" placeholder="格式：设备名称-配件-数量-备注"></textarea>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="mi"><span class="m">实验内容：</span></td>
                                                <td class="ku" colspan="3">
                                                    <textarea id="Contents" name="comment" rows="3" style="width: 492px;color:#000000;"></textarea>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                            <div class="submit_btn">
                                <span class="Save_and_submit">
                                    <input class="Save_and_submit" type="button" value="确定" onclick="javascript: Save();" /></span>
                                <span class="cancel">
                                    <input class="cancel" type="button" value="取消" onclick="javascript: parent.CloseIFrameWindow();" /></span>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <asp:HiddenField ID="hidUserIDCard" runat="server" />
        <asp:HiddenField ID="hidType" runat="server" />
        <asp:HiddenField ID="hidId" runat="server" />
        <asp:HiddenField ID="hidPlanId" runat="server" />
        <asp:HiddenField ID="hidOriginalName" runat="server" />
        <asp:HiddenField ID="hidStarDate" runat="server" />
        <asp:HiddenField ID="hidEndDate" runat="server" />
        <script type="text/javascript">
            var htype = $('#hidType').val();
            var Id = $('#hidId').val();
            $(document).ready(function () {
                CategoryChange();
                DateLoad();
                //BindClass();
                //BindExpType();
                $("#Category").change(function () {
                    CategoryChange();
                });
            });
            //加载实验类型
            function DateLoad() {
                $.ajax({
                    type: "Post",
                    url: WebServiceUrl + "/Experiment/Experiment.ashx",
                    //async: false,
                    dataType: "jsonp",
                    jsonp: "jsoncallback",
                    data:{"action":"DateLoad"},
                    //data: { "Name": Name, "IsDelete": IsDelete, "Contents": Contents, "Creator": Creator },
                    success: function (json) {
                        //机房
                        if (json.result1.Status == "error") {
                            //layer.msg(json.result.Msg);
                            //return;
                        }
                        else if (json.result1.Status == "no") {
                            //layer.msg(json.result.Msg);
                            //return;
                        }
                        else if (json.result1.Status == "ok") {
                            $("#ComputerRoom").empty();
                            $.each(json.result1.Data, function (i, item) {
                                var option = "<option value='" + item.Id + "'>" + item.Name + "</option>";
                                $("#ComputerRoom").append(option);
                            });
                        }
                        //实验地点
                        if (json.result2.Status == "error") {
                            //layer.msg(json.result.Msg);
                            //return;
                        }
                        else if (json.result2.Status == "no") {
                            //layer.msg(json.result.Msg);
                            //return;
                        }
                        else if (json.result2.Status == "ok") {
                            $("#Place").empty();
                            $.each(json.result2.Data, function (i, item) {
                                var option = "<option value='" + item.Id + "'>" + item.Name + "</option>";
                                $("#Place").append(option);
                            });
                        }
                        BindClass();
                    },
                    error: OnError
                });
                
            }
            //加载实验类型
            function BindExpType() {
                $.ajax({
                    type: "Post",
                    url: WebServiceUrl + "/SystemSettings/SystemSettings.ashx",
                    //async: false,
                    dataType: "jsonp",
                    jsonp: "jsoncallback",
                    data: { "action": "GetExpType" },
                    //data: { "Name": Name, "IsDelete": IsDelete, "Contents": Contents, "Creator": Creator },
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
                            $("#Type").empty();
                            $.each(json.result.Data, function (i, item) {
                                var option = "<option value='" + item.Id + "'>" + item.Name + "</option>";
                                $("#Type").append(option);
                            });
                        }
                        if (htype == "Edit") {
                            GetExperiment();
                        }
                    },
                    error: OnError
                });
            }
            //加载班级
            function BindClass(){
                $.ajax({
                    type: "Post",
                    url: WebServiceUrl + "/Experiment/Experiment.ashx",
                    //async: false,
                    dataType: "jsonp",
                    jsonp: "jsoncallback",
                    data: { "UseStatus": 0, "action": "GetClass" },
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
                            $("#Class").empty();
                            $.each(json.result.Data, function (i, item) {
                                var li = "<li><input type='checkbox' name='ClassCheck' value='" + item.Id + "' />" + item.Name + "</li>";
                                $("#Class").append(li);
                            });
                        }
                        BindExpType();
                    },
                    error: OnError
                });
            }
            //获得实验
            function GetExperiment() {
                $.ajax({
                    type: "Post",
                    url: WebServiceUrl + "/Experiment/Experiment.ashx" ,
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
                            //layer.msg(json.result.Msg);
                            return;
                        }
                        if (json.result.Status == "ok") {
                            Plan = json.result.Data.PagedData[0];
                            $('#Name').val(Plan.Name);
                            $('#Type').val(Plan.Type);
                            if (Plan.IsOpen == "1") {
                                $("input[name='IsOpen'][value='1']").attr("checked", "checked");
                            }
                            $('#StartDate').val(DateTimeConvert(Plan.StartDate));
                            $('#Week').val(Plan.Week);
                            $('#Weekday').val(Plan.Weekday);
                            $('#ClassHour').val(Plan.ClassHour);
                            $('#Part').val(Plan.Part);
                            $('#GroupMemberNumber').val(Plan.GroupMemberNumber);
                            $('#GroupNumber').val(Plan.GroupNumber);
                            $('#ComputerRoom').val(Plan.ComputerRoom);
                            $('#Place').val(Plan.Place);
                            $('#NeedEquip').val(Plan.NeedEquip);
                            $('#Contents').val(Plan.Contents);
                            $('#Class').val(Plan.ClassName);
                            $('#Category').val(Plan.Category);
                            CategoryChange();
                            //if (json.result2.Status == "ok") {
                            //    var ExpClass = $.parseJSON(json.result2.Data).ds;
                            //    $.each(ExpClass, function () {
                            //        $("#Class").find("[value=" + this.ClassId + "]").prop("checked", true);
                            //    });
                            //}
                        }
                    },
                    error: OnError
                });

            }
            //新增实验
            function Add() {
                Name = $('#Name').val().trim();
                Type = $('#Type').val();
                IsOpen = $("input[name='IsOpen']:checked").val();
                StartDate = $('#StartDate').val().trim();
                Week = $('#Week').val().trim();
                Weekday = $('#Weekday').val();
                ClassHour = $('#ClassHour').val();
                Part = $('#Part').val().trim();
                Class = $('#Class').val().trim();
                //ClassId = new Array();
                //$("[name='ClassCheck']").each(function () {
                //    if ($(this).prop("checked")) {
                //        ClassId.push($(this).attr("value"));
                //    }
                //});
                //Class = ClassId.toString();
                GroupMemberNumber = $('#GroupMemberNumber').val().trim();
                GroupNumber = $('#GroupNumber').val().trim(); 
                ComputerRoom = $('#ComputerRoom').val();
                Place = $('#Place').val();
                NeedEquip = $('#NeedEquip').val();
                
                Contents = $('#Contents').val();
                hidUserIDCard = $('#hidUserIDCard').val();
                PlanId = $('#hidPlanId').val();
                Category = $('#Category').val();

                $.ajax({
                    type: "Post",
                    url: WebServiceUrl + "/Experiment/Experiment.ashx",
                    //async: false,
                    dataType: "jsonp",
                    jsonp: "jsoncallback",
                    data: {
                        "Name": Name, "Contents": Contents, "Creator": hidUserIDCard, "PlanId": PlanId
                        , "Type": Type, "IsOpen": IsOpen, "StartDate": StartDate, "Week": Week
                        , "Weekday": Weekday, "ClassHour": ClassHour, "Part": Part, "Class": Class
                        , "GroupMemberNumber": GroupMemberNumber, "GroupNumber": GroupNumber, "Place": Place
                        , "NeedEquip": NeedEquip, "ComputerRoom": ComputerRoom, "Category": Category
                        , "action": "AddExperiment"
                    },
                    success: function (json) {
                        if (json.result.Status == "error") {
                            //layer.msg(json.result.Msg);
                            layer.msg("添加失败！");
                            return;
                        }
                        if (json.result.Status == "no") {
                            layer.msg(json.result.Msg);
                            return;
                        }
                        if (json.result.Status == "cf") {
                            layer.msg(json.result.Msg);
                            return;
                        }
                        if (json.result.Status == "ok") {
                            parent.layer.msg(json.result.Msg);
                            ReturnUrl();
                        }
                    },
                    error: OnError
                });

            }
            //错误处理
            function OnError(XMLHttpRequest, textStatus, errorThrown) {
                //layer.msg(json.result.Msg);
            }
            //修改实验
            function Update() {
                Name = $('#Name').val().trim();
                Type = $('#Type').val();
                IsOpen = $("input[name='IsOpen']:checked").val();
                StartDate = $('#StartDate').val().trim();
                Week = $('#Week').val().trim();
                Weekday = $('#Weekday').val().trim();
                ClassHour = $('#ClassHour').val().trim();
                Part = $('#Part').val().trim();
                Class = $('#Class').val().trim();
                //ClassId = new Array();
                //$("[name='ClassCheck']").each(function () {
                //    if ($(this).prop("checked")) {
                //        ClassId.push($(this).attr("value"));
                //    }
                //});
                //Class = ClassId.toString();
                GroupMemberNumber = $('#GroupMemberNumber').val().trim();
                GroupNumber = $('#GroupNumber').val().trim();
                ComputerRoom = $('#ComputerRoom').val();
                Place = $('#Place').val();
                NeedEquip = $('#NeedEquip').val();
                hidUserIDCard = $('#hidUserIDCard').val();
                Contents = $('#Contents').val();
                Category = $('#Category').val();

                $.ajax({
                    type: "Post",
                    url: WebServiceUrl + "/Experiment/Experiment.ashx" ,//random" + Math.random(),//方法所在页面和方法名
                    //async: false,
                    dataType: "jsonp",
                    jsonp: "jsoncallback",
                    data: {
                        "Name": Name, "Contents": Contents, "Editor": hidUserIDCard, "Id": Id
                        , "Type": Type, "IsOpen": IsOpen, "StartDate": StartDate, "Week": Week
                        , "Weekday": Weekday, "ClassHour": ClassHour, "Part": Part, "Class": Class
                        , "GroupMemberNumber": GroupMemberNumber, "GroupNumber": GroupNumber, "Place": Place
                        , "NeedEquip": NeedEquip, "ComputerRoom": ComputerRoom, "Category": Category
                        , "action": "UpdateExperiment"
                    },
                    success: function (json) {
                        if (json.result.Status == "error") {
                            //layer.msg(json.result.Msg);
                            layer.msg("修改失败！");
                            return;
                        }
                        if (json.result.Status == "no") {
                            layer.msg(json.result.Msg);
                            return;
                        }
                        if (json.result.Status == "cf") {
                            layer.msg(json.result.Msg);
                            return;
                        }
                        if (json.result.Status == "ok") {
                            parent.layer.msg(json.result.Msg);
                            ReturnUrl();
                        }
                    },
                    error: OnError
                });

            }
            //保存
            function Save() {
                Name = $('#Name').val();
                Contents = $('#Contents').val();
                if (Name.trim() == "") {
                    layer.msg("请填写实验名称");
                    return;
                }
                StartDate = $('#StartDate').val();
                if (StartDate.trim() == "") {
                    layer.msg("请选择日期");
                    return;
                }
                if (htype == "Edit") {
                    Update();
                } else if (htype == "Add") {
                    Add();
                }
            }
            //返回列表页
            function ReturnUrl() {
                //location.href = "PlanList.aspx";
                parent.GetList(1);
                parent.CloseIFrameWindow();

            }
            //实验类别切换
            function CategoryChange() {
                var Category = $("#Category").val();
                if (Category == "") {
                    return;
                }
                else if (Category == "0") {
                    //显示机房
                    $("#ComputerRoom1").show();
                    $("#ComputerRoom").show();
                    //隐藏分组
                    $("#Group").hide();
                    //隐藏需要的仪器设备
                    $("#NeedEquip1").hide();
                }
                else if (Category == "1") {
                    //显示机房
                    $("#ComputerRoom1").hide();
                    $("#ComputerRoom").hide();
                    //隐藏分组
                    $("#Group").show();
                    //隐藏需要的仪器设备
                    $("#NeedEquip1").show();
                    return;
                }
            }
        </script>
    </form>
</body>
</html>
