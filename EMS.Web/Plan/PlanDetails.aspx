<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PlanDetails.aspx.cs" Inherits="EMS.Web.Plan.PlanDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>课程详情</title>
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
                                                <td class="mi"><span class="m">课程名称：</span></td>
                                                <td class="ku"><span id="Name"></span></td>
                                            <%--</tr>
                                            <tr>--%>
                                                <td class="mi"><span class="m">主讲教师：</span></td>
                                                <td class="ku"><span id="MainTeacher"></span></td>
                                            </tr>
                                            <tr>
                                                <td class="mi"><span class="m">指导教师1：</span></td>
                                                <td class="ku"><span id="GuideTeacher1"></span></td>
                                            <%--</tr>
                                            <tr>--%>
                                                <td class="mi"><span class="m">指导教师2：</span></td>
                                                <td class="ku"><span id="GuideTeacher2"></span></td>
                                            </tr>
                                            <tr>
                                                <td class="mi"><span class="m">学期：</span></td>
                                                <td class="ku">
                                                    <span id="LearnYear"></span>
                                                    <br />
                                                </td>
                                            <%--</tr>
                                            <tr>--%>
                                                <td class="mi"><span class="m">创建时间：</span></td>
                                                <td class="ku"><span id="CreateTime"></span></td>
                                            </tr>
                                            <tr>
                                                <td class="mi"><span class="m">课程内容：</span></td>
                                                <td class="ku" colspan="3">
                                                    <textarea id="Contents" name="comment" rows="3" style="width: 450px;" readonly="readonly"></textarea>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>

                            </div>
                            <div class="submit_btn">
                                <span class="cancel">
                                    <input class="Topic_btn" type="button" value="返回" onclick="javascript: parent.CloseIFrameWindow();" /></span>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <asp:HiddenField ID="hidId" runat="server" />
        <script type="text/javascript">
            var Id = $('#hidId').val();
            $(document).ready(function () {
                GetPlan();
            });
            //获得教学计划
            function GetPlan() {
                $.ajax({
                    type: "Post",
                    url: WebServiceUrl + "/Plan/Plan.ashx",
                    //async: false,
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
                        if (json.result.Status == "ok") {
                            Plan = json.result.Data;
                            $('#Name').html(Plan.Name);
                            $('#MainTeacher').html(Plan.MainTeacher);
                            $('#GuideTeacher1').html(Plan.GuideTeacher1);
                            $('#GuideTeacher2').html(Plan.GuideTeacher2);
                            $('#CreateTime').html(DateTimeConvert(Plan.CreateTime, "yyyy-MM-dd HH:mm:ss"));
                            GetLearnYear(Plan.LearnYear);
                            $('#Contents').html(Plan.Contents);
                        }
                    },
                    error: OnError
                });
            }
            function OnError(XMLHttpRequest, textStatus, errorThrown) {
                //layer.msg("加载失败");
            }
            //加载学年学期
            function GetLearnYear(LearnYearId) {
                $LearnYear = $('#LearnYear');
                $.ajax({
                    url: "/CommonHandler/UnifiedHelpHandler.ashx",
                    type: "post",
                    async: false,
                    dataType: "json",
                    data: { "Func": "GetStudySectionData", ID: LearnYearId },
                    success: function (json) {
                        if (json.result.errNum.toString() == "0") {
                            $LearnYear.html(json.result.retData[0].Academic);
                        }                      
                    },
                    error: OnError
                });
            }
        </script>
    </form>
</body>
</html>
