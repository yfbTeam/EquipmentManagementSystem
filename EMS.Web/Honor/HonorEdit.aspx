<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HonorEdit.aspx.cs" Inherits="EMS.Web.Honor.HonorEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>编辑绩效</title>
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
                                                <td class="mi"><span class="m">绩效名称：</span></td>
                                                <td class="ku">
                                                    <input id="Name" class="hu" type="text" placeholder=" 请输入绩效名称"></td>
                                                <td class="mi"><span class="m">级别：</span></td>
                                                <td class="ku">
                                                    <select id="Level" class="option">
                                                    </select>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="mi"><span class="m">学期：</span></td>
                                                <td class="ku">
                                                    <select id="LearnYear" class="option">
                                                    </select>
                                                </td>
                                                <td class="mi"><span class="m">课程：</span></td>
                                                <td class="ku">
                                                    <select id="Plan" class="option">
                                                    </select>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="mi"><span class="m">实验项目：</span></td>
                                                <td class="ku">
                                                    <select id="Experiment" class="option">
                                                    </select>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                            <div class="submit_btn">
                                <span class="Save_and_submit">
                                    <input class="Save_and_submit" type="button" value="保存" onclick="javascript: Save();" /></span>
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
        <asp:HiddenField ID="hidOriginalName" runat="server" />
        <asp:HiddenField ID="hidIsAdmin" runat="server" />
        <script type="text/javascript">
            var htype = $('#hidType').val();
            var Id = $('#hidId').val();
            //课程缓存变量
            var PlanJson;
            //实验缓存变量
            var ExpJson;
            //绩效信息缓存
            var HonorModel;

            var HonorNameSave;
            $(document).ready(function () {
                //加载绩效级别
                BindLevel();
            });
            //加载级别
            function BindLevel() {
                $.ajax({
                    type: "Post",
                    url: WebServiceUrl + "/SystemSettings/SystemSettings.ashx",//random" + Math.random(),//方法所在页面和方法名
                    async: false,
                    dataType: "jsonp",
                    jsonp: "jsoncallback",
                    data: { "action": "GetLevelList" },
                    //data: { "Name": Name, "LearnYear": LearnYear, "Contents": Contents, "Creator": Creator },
                    success: function (json) {
                        $("#Level").empty();
                        $("#Level").append("<option value=''>请选择</option>");
                        if (json.result.Status == "error") {
                            //layer.msg(json.result.Msg);
                            return;
                        }
                        if (json.result.Status == "no") {
                            //layer.msg(json.result.Msg);
                            return;
                        }
                        if (json.result.Status == "ok") {
                            $.each(json.result.Data, function (i, item) {
                                var option = "<option value='" + item.Id + "'>" + item.Name + "</option>"
                                $("#Level").append(option);
                            });
                        }
                        //加载学年学期
                        BindLearnYear();
                    },
                    error: OnError
                });
            }
            //加载学年学期
            function BindLearnYear() {
                $LearnYear = $("#LearnYear");
                $LearnYear.empty();
                $LearnYear.append("<option value=''>全部学期</option>");
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
                        if ($('#hidIsAdmin').val() == "true") {
                            if (htype == "Edit") {
                                //获得荣誉
                                GetHonor();
                            } else {
                                GetPlanList("");
                            }
                        } else {

                            if (htype == "Edit") {
                                //获得荣誉
                                GetHonor();
                            } else {
                                GetPlanList($('#hidUserIDCard').val());
                            }

                        }
                    },
                    error: OnError
                });
            }
            //获得绩效
            function GetHonor() {
                $.ajax({
                    type: "Post",
                    url: WebServiceUrl + "/Honor/Honor.ashx",//random" + Math.random(),//方法所在页面和方法名
                    //async: false,
                    dataType: "jsonp",
                    jsonp: "jsoncallback",
                    data: { "Id": Id, "action": "GetHonor" },
                    success: function (json) {
                        HonorNameSave = "";
                        if (json.result.Status == "error") {
                            //layer.msg(json.result.Msg);
                            return;
                        }
                        if (json.result.Status == "no") {
                            //layer.msg(json.result.Msg);
                            return;
                        }
                        if (json.result.Status == "ok") {
                            HonorModel = json.result.Data.PagedData[0];
                            HonorNameSave = HonorModel.Name;
                            //加载课程
                            GetPlanList(HonorModel.Creator);
                        }
                    },
                    error: OnError
                });

            }
            //新增绩效
            function Add() {
                Experiment = $('#Experiment option:selected').val();
                Level = $('#Level option:selected').val();
                Name = $('#Name').val().trim();
                UserIDCard = $('#hidUserIDCard').val();

                $.ajax({
                    type: "Post",
                    url: WebServiceUrl + "/Honor/Honor.ashx",
                    //async: false,
                    dataType: "jsonp",
                    jsonp: "jsoncallback",
                    data: { "Name": Name, "ExperimentId": Experiment, "Level": Level, "Creator": UserIDCard, "action": "AddHonor" },
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
                        if (json.result.Status == "ok") {
                            parent.layer.msg(json.result.Msg);
                            ReturnUrl();
                        }
                    },
                    error: OnError
                });

            }
            //修改绩效
            function Update() {
                Experiment = $('#Experiment option:selected').val();
                Name = $('#Name').val().trim();
                UserIDCard = $('#hidUserIDCard').val();
                Level = $('#Level option:selected').val();

                $.ajax({
                    type: "Post",
                    url: WebServiceUrl + "/Honor/Honor.ashx",
                    //async: false,
                    dataType: "jsonp",
                    jsonp: "jsoncallback",
                    data: { "Name": Name, "ExperimentId": Experiment, "Level": Level, "Editor": UserIDCard, "Id": Id, "action": "UpdateHonor", "preName": HonorNameSave },
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
                var HonorName = $('#Name').val().trim();
                if (HonorName == "" || HonorName.length == 0) {
                    layer.msg("请输入绩效名称！");
                    return;
                }
                var re = /^[Aa-zA-Z0-9_\u4E00-\u9FFF]{1,30}$/;
                if (!re.test(HonorName)) {
                    layer.msg("请输入正确字符！");
                    return;
                }
                var Level = $('#Level option:selected').val();
                if (Level == "") {
                    layer.msg("请选择等级！");
                    return;
                }
                var Experiment = $('#Experiment option:selected').val();
                if (Experiment == "") {
                    layer.msg("请选择实验！");
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
                parent.GetList(1);
                parent.CloseIFrameWindow();
            }
            //获取课程
            function GetPlanList(DataUser) {
                Creator = DataUser;
                $.ajax({
                    type: "Post",
                    url: WebServiceUrl + "/Plan/Plan.ashx",
                    async: false,
                    dataType: "jsonp",
                    jsonp: "jsoncallback",
                    data: { "Creator": Creator, "action": "GetSelectOption" },
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
                            $("#Plan").empty();
                            $("#Plan").append("<option value=''>全部课程</option>");
                            $.each(PlanJson, function (i, item) {
                                var option = "<option value='" + item.Id + "'>" + item.Name + "</option>"
                                $("#Plan").append(option);
                            });
                            $("#LearnYear").change(function () {
                                ResetPlan();
                            });
                        }
                        GetPExperiment(DataUser);
                    },
                    error: OnError
                });

            }
            //获取实验
            function GetPExperiment(DataUser) {
                Creator = DataUser;
                $.ajax({
                    type: "Post",
                    url: WebServiceUrl + "/Experiment/Experiment.ashx",
                    async: false,
                    dataType: "jsonp",
                    jsonp: "jsoncallback",
                    data: { "Creator": Creator, "action": "GetSelectOption" },
                    success: function (json) {
                        $("#Experiment").empty();
                        $("#Experiment").append("<option value=''>选择实验</option>");
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
                                $("#Experiment").append(option);
                            });
                            $("#Plan").change(function () {
                                ResetExp();
                            });
                        }

                        if (htype == "Edit") {
                            Load1();
                        }
                    },
                    error: OnError
                });
            }
            //重置课程
            function ResetPlan() {
                var LearnYear = $('#LearnYear option:selected').val();
                $("#Plan").empty();
                $("#Plan").append("<option value=''>全部课程</option>");
                $.each(PlanJson, function (i, item) {
                    if (LearnYear != "" && item.LearnYear != LearnYear) {
                        return;
                    }
                    var option = "<option value='" + item.Id + "'>" + item.Name + "</option>"
                    $("#Plan").append(option);
                });

            }
            //重置实验
            function ResetExp() {
                var Plan = $('#Plan option:selected').val();
                $("#Experiment").empty();
                $("#Experiment").append("<option value=''>选择实验</option>");
                $.each(ExpJson, function (i, item) {
                    if (Plan != "" && item.PlanId != Plan) {
                        return;
                    }
                    var option = "<option value='" + item.Id + "'>" + item.Name + "</option>"
                    $("#Experiment").append(option);
                });

            }
            //加载信息
            function Load1() {
                $('#Name').val(HonorModel.Name);
                $('#Level').val(HonorModel.HonorLevel); 
                $('#Experiment').val(HonorModel.ExperimentId);

            }
            function OnError(XMLHttpRequest, textStatus, errorThrown) {
                //alert(XMLHttpRequest + "-" + textStatus + "-" + errorThrown);
            }

        </script>
    </form>
</body>
</html>
