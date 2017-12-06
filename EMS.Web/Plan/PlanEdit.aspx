<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PlanEdit.aspx.cs" Inherits="EMS.Web.Plan.PlanEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>编辑课程</title>
    <link href="../css/common.css" rel="stylesheet" />
    <link href="../css/style.css" rel="stylesheet" />
    <link href="../css/iconfont.css" rel="stylesheet" />
    <link href="../css/animate.css" rel="stylesheet" />

    <script src="../js/Common.js"></script>
    <script src="../js/jquery-1.11.2.min.js"></script>
    <script src="../js/jquery.tmpl.js"></script>
    <script src="../js/layer/layer.js"></script>
    <style type="text/css">
        .selectDiv{
            display:none;position:absolute;width:190px;background-color:white;padding:0 10px;padding-right:0px;/*max-height:200px;*/
        }
        .selectDiv ul{
            max-height:200px;overflow:scroll;width:190px;cursor:auto;
        }
        .selectDiv ul li {
            cursor:copy;
        }
         .selectDiv ul li:hover {
            background-color:#CCCCCC;
        }
        .PlanMust{
            color:red;
        }
        .PlanTiShi{
            color:#999;
            padding:5px 0;
        }
        .PlanTiShiRed{
            color:red;
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
                                                <td class="mi"><span class="PlanMust">*</span><span class="m">课程名称：</span></td>
                                                <td class="ku">
                                                    <input id="Name" class="hu" type="text" placeholder="请输入课程名称"/>
                                                    <br /><span class="PlanTiShi"><span id="NameT1">1-30个字</span>、<span id="NameT2">不能为空</span></span>
                                                </td>
                                            <%--</tr>
                                            <tr>--%>
                                                <td class="mi"><span class="PlanMust">*</span><span class="m">主讲教师：</span></td>
                                                <td class="ku">
                                                    <input id="MainTeacher" class="hu" type="text" onclick="div1Click()"/>
                                                    <div id="div1" class="selectDiv">
                                                        <ul>
                                                        </ul>
                                                    </div>
                                                    <br /><span class="PlanTiShi"><span id="MainTeacherT">不为空</span></span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="mi"><span class="m">指导教师1：</span></td>
                                                <td class="ku">
                                                    <input id="GuideTeacher1" class="hu" type="text"  onclick="div2Click()"/>
                                                    <div id="div2" class="selectDiv">
                                                        <ul></ul>
                                                    </div>
                                                </td>
                                            <%--</tr>
                                            <tr>--%>
                                                <td class="mi"><span class="m">指导教师2：</span></td>
                                                <td class="ku">
                                                    <input id="GuideTeacher2" class="hu" type="text" onclick="div3Click()"/>
                                                    <div id="div3" class="selectDiv">
                                                        <ul></ul>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="mi"><span class="m">学期：</span></td>
                                                <td class="ku" colspan="3">
                                                    <select id="LearnYear" class="option">
                                                    </select>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="mi"><span class="m">课程内容：</span></td>
                                                <td class="ku" colspan="3">
                                                    <textarea id="Contents" name="comment" rows=3" style="width: 500px;color:#000000;"></textarea>
                                                    <br /><span class="PlanTiShi"><span id="ContentsT" >最多100个字</span></span>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>

                                </div>
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
        <asp:HiddenField ID="hidUserIDCard" runat="server" />
        <asp:HiddenField ID="hidType" runat="server" />
        <asp:HiddenField ID="hidId" runat="server" />
        <asp:HiddenField ID="hidOriginalName" runat="server" />
        <asp:HiddenField ID="hidIsAdmin" runat="server" />
        <asp:HiddenField ID="hidUserName" runat="server" />
        
        <script type="text/javascript">
            var htype = $('#hidType').val();
            var Id = $('#hidId').val();
            $(document).ready(function () {
                $('#MainTeacher').val($('#hidUserName').val());
                BindLearnYear();
            });
            function Load1() {
                if (htype == "Edit") {
                    GetPlan();
                }
                if ($("#hidIsAdmin").val() == "false") {
                    $("#LearnYear").attr("disabled", "disabled");
                }
            }
            function div1Click() {
                $("#div1").stop().slideToggle();
                $('#div3').slideUp();
                $('#div2').slideUp();
                stopEvent();
            }
            function div2Click() {
                $("#div2").stop().slideToggle();
                $('#div1').slideUp();
                $('#div3').slideUp();
                stopEvent();
            }
            function div3Click() {
                $("#div3").stop().slideToggle();
                $('#div1').slideUp();
                $('#div2').slideUp();
                stopEvent();
            }
            function stopEvent() { // 阻止冒泡事件
                // 取消事件冒泡
                var e = arguments.callee.caller.arguments[0] || event; // 若省略此句，下面的e改为event，IE运行可以，但是其他浏览器就不兼容
                if (e && e.stopPropagation) {
                    // this code is for Mozilla and Opera
                    e.stopPropagation();
                } else if (window.event) {
                    // this code is for IE
                    window.event.cancelBubble = true;
                }
            }
            $(document).click(function () {
                $('#div1').slideUp();
                $('#div2').slideUp();
                $('#div3').slideUp();
            })
            function LiSelected(obj) {
                var LiValue = $(obj).html();
                var InputText = $(obj).parent().parent().siblings(":text");
                $(InputText).val(LiValue);
                $(obj).parent().parent().slideToggle();
            }
            //绑定教师信息
            function BindTeacher() {
                $.ajax({
                    url: "/CommonHandler/UnifiedHelpHandler.ashx",
                    type: "post",
                    async: false,
                    dataType: "json",
                    data: {
                        Func: "GetUserInfoData",
                        IsStu:false                        
                    },
                    success: function (json) {
                        $("#div1 ul").empty();
                        $("#div2 ul").empty();
                        $("#div3 ul").empty();
                        if (json.result.errNum.toString() == "0") {
                            $.each(json.result.retData, function (i, item) {
                                var li = "<li >" + item.Name + "</li>"
                                $("#div1 ul").append(li);
                                $("#div2 ul").append(li);
                                $("#div3 ul").append(li);
                            });
                            $("#div1 ul").children().click(function () {
                                LiSelected(this);
                            });
                            $("#div2 ul").children().click(function () {
                                LiSelected(this);
                            });
                            $("#div3 ul").children().click(function () {
                                LiSelected(this);
                            });
                        }
                        Load1();
                    },
                    error: OnError
                });
            }
            //加载学年学期
            function BindLearnYear() {
                $LearnYear = $("#LearnYear");
                $LearnYear.empty();
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
                                //选择当前学期
                                var StartDate = new Date(parseInt(n.StartDate.replace(/\D/igm, "")));
                                var EndDate = new Date(parseInt(n.EndDate.replace(/\D/igm, "")));
                                var NowDate = new Date();
                                if (StartDate <= NowDate && NowDate < EndDate) {
                                    $LearnYear.val(n.Id);
                                }                                
                            });                            
                        }
                        BindTeacher();                        
                    },
                    error: OnError
                });
            }
            //获得课程
            function GetPlan() {
                $.ajax({
                    type: "Post",
                    url: WebServiceUrl + "/Plan/Plan.ashx",//random" + Math.random(),//方法所在页面和方法名
                    async: false,
                    dataType: "jsonp",
                    jsonp: "jsoncallback",
                    data: { "Id": Id, "action": "GetPlan" },
                    success: function (json) {
                        if (json.result.Status == "error") {
                            //layer.msg(json.result.Msg);
                            return;
                        }
                        if (json.result.Status == "no") {
                            //layer.msg(json.result.Msg);
                            return;
                        }
                        Plan = json.result.Data;
                        $('#Name').val(Plan.Name);
                        $('#MainTeacher').val(Plan.MainTeacher);
                        $('#GuideTeacher1').val(Plan.GuideTeacher1);
                        $('#GuideTeacher2').val(Plan.GuideTeacher2);
                        $('#LearnYear').val(Plan.LearnYear);
                        $('#Contents').val(Plan.Contents);
                    },
                    error: OnError
                });

            }
            //新增课程
            function Add() {
                LearnYear = $('#LearnYear option:selected').val();
                Name = $('#Name').val().trim();
                MainTeacher = $('#MainTeacher').val().trim();
                GuideTeacher1 = $('#GuideTeacher1').val().trim();
                GuideTeacher2 = $('#GuideTeacher2').val().trim();
                hidUserIDCard = $('#hidUserIDCard').val();
                Contents = $('#Contents').val();

                $.ajax({
                    type: "Post",
                    url: WebServiceUrl + "/Plan/Plan.ashx",//random" + Math.random(),//方法所在页面和方法名
                    //async: false,
                    dataType: "jsonp",
                    jsonp: "jsoncallback",
                    data: {
                        "Name": Name, "LearnYear": LearnYear, "Contents": Contents, "Creator": hidUserIDCard
                        , "MainTeacher": MainTeacher, "GuideTeacher1": GuideTeacher1, "GuideTeacher2": GuideTeacher2, "action": "AddPlan"
                    },
                    success: function (json) {
                        if (json.result.Status == "error") {
                            //layer.msg(json.result.Msg);
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
                //layer.msg("保存失败");
            }
            //修改课程
            function Update() {
                LearnYear = $('#LearnYear option:selected').val();
                Name = $('#Name').val().trim();
                MainTeacher = $('#MainTeacher').val().trim();
                GuideTeacher1 = $('#GuideTeacher1').val().trim();
                GuideTeacher2 = $('#GuideTeacher2').val().trim();
                hidUserIDCard = $('#hidUserIDCard').val();
                Contents = $('#Contents').val();

                $.ajax({
                    type: "Post",
                    url: WebServiceUrl + "/Plan/Plan.ashx",//random" + Math.random(),//方法所在页面和方法名
                    //async: false,
                    dataType: "jsonp",
                    jsonp: "jsoncallback",
                    data: {
                        "Name": Name, "LearnYear": LearnYear, "Contents": Contents, "Editor": hidUserIDCard, "Id": Id
                        , "MainTeacher": MainTeacher, "GuideTeacher1": GuideTeacher1, "GuideTeacher2": GuideTeacher2, "action": "UpdatePlan"
                    },
                    success: function (json) {
                        if (json.result.Status == "error") {
                            //layer.msg(json.result.Msg);
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
                if (!JSValidate()) {
                    return;
                }
                if (htype == "Edit") {
                    Update();
                } else if (htype == "Add") {
                    Add();
                }
            }
            //验证数据
            function JSValidate() {
                //验证结果
                var JSResult = true;
                //验证课程名称
                Name = $('#Name').val().trim();
                if (Name.trim() == "") {
                    $('#NameT2').removeClass().addClass("PlanTiShiRed");
                    JSResult = false;
                } else {
                    $('#NameT2').removeClass();
                }
                if (Name.trim().length > 30) {
                    $('#NameT1').removeClass().addClass("PlanTiShiRed");
                    JSResult = false;
                } else {
                    $('#NameT1').removeClass();
                }

                //验证主讲教师
                MainTeacher = $('#MainTeacher').val().trim();
                if (MainTeacher.trim() == "") {
                    $('#MainTeacherT').removeClass().addClass("PlanTiShiRed");
                    JSResult = false;
                } else {
                    $('#MainTeacherT').removeClass();
                }

                //验证课程内容
                Contents = $('#Contents').val();
                if (Contents.trim().length > 100) {
                    $('#ContentsT').removeClass().addClass("PlanTiShiRed");
                    JSResult = false;
                } else {
                    $('#ContentsT').removeClass();
                }
                return JSResult;
            }
            //返回列表页
            function ReturnUrl() {
                //location.href = "PlanList.aspx";
                parent.GetList(1);
                parent.CloseIFrameWindow();

            }
        </script>
    </form>
</body>
</html>
