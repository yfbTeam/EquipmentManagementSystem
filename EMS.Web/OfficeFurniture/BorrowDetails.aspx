<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BorrowDetails.aspx.cs" Inherits="EMS.Web.OfficeFurniture.BorrowDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>办公设备借用详细</title>
    <link href="/css/style.css" rel="stylesheet" />
    <link href="/css/common.css" rel="stylesheet" />
    <link href="/css/iconfont.css" rel="stylesheet" />
    <link href="/css/animate.css" rel="stylesheet" />
    <script src="/js/jquery-1.11.2.min.js"></script>
    <script src="/js/layer/layer.js"></script>
    <script src="/js/Common.js"></script>
    <script src="/js/jquery.tmpl.js"></script>
    <script src="/js/My97DatePicker/WdatePicker.js"></script>
    <script src="../js/ajaxfileupload.js"></script>
    <style type="text/css">
        .shangchuan {
            width: 200px;
            height: 140px;
            float: left;
            margin-right: 5px;
        }

        .dianjisc {
            border: none;
            border-radius: 3px;
            /*width: 100px;*/
            color: #fff;
            padding: 5px 0px;
        }

        .bluebutton:hover {
            background: #1B85CE none repeat scroll 0% 0%;
            cursor: pointer;
        }

        .bluebutton {
            background: #0097DD none repeat scroll 0% 0%;
            cursor: pointer;
        }

        .ui-upload-holder {
            position: relative;
            width: 198px;
            height: 27px;
            border: 1px solid silver;
            overflow: hidden;
            border-radius: 3px;
            cursor: pointer;
        }

        .ui-upload-txt {
            position: absolute;
            top: 0px;
            left: 0px;
            width: 198px;
            height: 27px;
            line-height: 27px;
            text-align: center;
            background: #2789BA none repeat scroll 0% 0%;
            color: #fff;
            font: 12px "微软雅黑";
            vertical-align: middle;
            padding: 5px 0px;
            cursor: pointer;
        }

        .upload_preview {
            border-top: 1px solid #bbb;
            border-bottom: 1px solid #bbb;
            background-color: #fff;
            overflow: hidden;
        }

        .upload_append_list {
            height: 300px;
            padding: 0 1em;
            float: left;
            position: relative;
        }

        .upload_delete {
            margin-left: 2em;
        }

        .upload_image {
            max-height: 250px;
            padding: 5px;
        }

        .InfoTable td {
            border: 1px solid #cad9ea;
            padding: 5px 10px;
            height: 25px;
        }

            .InfoTable td span {
                line-height: 20px;
            }

                .InfoTable td span input {
                    height: 30px;
                    padding-left: 8px;
                }
    </style>
    <script id="trTemp" type="text/x-jquery-tmpl">
        <tr>
            <td class="">${number}</td>
            <td class=""><span title="${name}">${NameLengthUpdate(name,25)}</span></td>
            <td class="">${type}</td>
            <td class="">${unit}</td>

        </tr>
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="Teaching_plan_management">
            <h1 class="Page_name"><span id="PlanName"></span>办公设备借用详细</h1>
            <table class="InfoTable">
                <tr>
                    <td>
                        <span>借用人：</span>

                    </td>
                    <td>
                        <span>
                            <label id="txt_UserName"></label>
                        </span>
                    </td>
                    <td><span>借用时间：</span></td>
                    <td><span>
                        <label id="txt_BeginDate"></label>

                    </span></td>
                    <td><span>归还时间：</span></td>
                    <td><span>
                        <label id="txt_EndDate"></label>
                    </span>
                    </td>
                </tr>
                <tr>
                    <td colspan="6">借用原因：</td>
                </tr>
                <tr>

                    <td colspan="6">
                        <%--<textarea id="te_BorrowReason" name="te_remark" rows="2" style="width: 100%;" form="usrform" placeholder="请在此处输入借用原因..." disabled></textarea>--%>
                         <label id="te_BorrowReason" style="height:100px;display:block;"></label>
                    </td>
                </tr>
                <tr>
                    <td colspan="6">备&nbsp注：</td>
                </tr>
                <tr>
                    <td colspan="6">
                       <%-- <textarea id="te_Notes" name="te_remark" rows="2" style="width: 100%;" form="usrform" placeholder="请在此处输入备注..." disabled></textarea>--%>
                      <label id="te_Notes" style="height:100px;display:block;"></label>
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                        <div class="Honor_management">
                            <table class="W_form" id="tbList" cellspacing="0">
                                <colgroup>
                                    <col width="10%" />
                                    <col width="25%" />
                                    <col width="30%" />

                                </colgroup>
                                <thead>
                                    <tr class="trth">
                                        <th class="Project_name">资产号</th>
                                        <th class="Project_name">资产名称</th>
                                        <th class="">类型</th>
                                        <th>单位</th>

                                    </tr>
                                </thead>
                                <tbody id="Tb_List">
                                </tbody>
                            </table>

                        </div>
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                        <div class="submit_btn">
                            <span class="Save_and_submit">
                                <input id="jysh" name="btnHide" class="button"  title="借用审核" type="button" value="借用审核" onclick="AuditingBorrow(this)" />
                                <input id="sbly" name="btnHide" class="button"  title="设备领用" type="button" value="设置领用" onclick="UpdateStatus( 2)" />
                                <input id="zcgh" name="btnHide" class="button"  title="资产归还" type="button" value="资产归还" onclick="UpdateStatus( 3)" />
                                <input class="Topic_btn" type="button" value="返回" onclick="javascript: parent.CloseIFrameWindow();" /></span>
                        </div>
                    </td>

                </tr>
            </table>
            <br />

        </div>
        <asp:HiddenField ID="hidId" runat="server" />
        <asp:HiddenField ID="hidOperator" runat="server" />
        <asp:HiddenField ID="hidUserIDCard" runat="server" />
        <asp:HiddenField ID="hidIsAdmin" runat="server" />
        <asp:HiddenField ID="hidUserName" runat="server" />
        <asp:HiddenField ID="hidBorrowStatus" runat="server" />
    </form>
    <script type="text/javascript">
        if ($('#hidBorrowStatus').val() == "0") {
            $("#sbly").hide();
            $("#zcgh").hide();
        } else if ($('#hidBorrowStatus').val() == "1") {
            $("#jysh").hide();
            $("#zcgh").hide();
        } else if ($('#hidBorrowStatus').val() == "2") {
            $("#jysh").hide();
            $("#sbly").hide();
        } else {
            $("#jysh").hide();
            $("#sbly").hide();
            $("#zcgh").hide();
        }

        $('#txt_UserName').val($('#hidUserName').val());
        var readArry = [];
        var cId = $('#hidId').val();
        var readyIds = [];
        var readyObj = [];
        $(function () {
            GetPage();
        })
        //获得数据
        function GetPage() {
            $.ajax({
                type: "Post",
                url: WebServiceUrl + "/Statistical/Statistical.ashx",
                //async: false,
                dataType: "jsonp",
                jsonp: "jsoncallback",
                data: { "Id": cId, "action": "GetPage" },
                success: function (json) {
                    if (json.result.Data.PagedData.length > 0) {
                        Plan = json.result.Data.PagedData;
                        if (Plan != null && Plan.length > 0) {
                            var obj = Plan[0];
                            $('#txt_UserName').html(obj.CreateName);
                            $('#txt_BeginDate').html(DateTimeConvert(obj.BeginDate, "yyyy-MM-dd"));
                            $('#txt_EndDate').html(DateTimeConvert(obj.EndDate, "yyyy-MM-dd"));
                            $('#te_BorrowReason').html(obj.BorrowReason);
                            $('#te_Notes').html(obj.Notes);
                        }
                    }
                },


                error: OnError
            });

            $.ajax({
                url: WebServiceUrl + "/Statistical/Statistical.ashx",//random" + Math.random(),//方法所在页面和方法名
                async: false,
                dataType: "jsonp",
                jsonp: "jsoncallback",
                data: { "id": cId, "action": "GetPageList" },
                success: OnSuccess,
                error: OnError
            });

        }

        function OnSuccess(json) {
            if (json.result.Status == "no" || json.result.Status == "error") {
                $("#Tb_List").html('<tr><td colspan="100" style="text-align:center;">无内容</td></tr>');
            } else {
                $("#Tb_List").html('');
                var data = $.parseJSON(json.result.Data);
                $("#trTemp").tmpl(data.ds).appendTo("#Tb_List");

                //   $("#trTemp").tmpl(json.result.Data).appendTo($("#Honor_management"));

            }

        }

        function OnError(XMLHttpRequest, textStatus, errorThrown) {
            //layer.msg("加载失败");
        }


        function AuditingBorrow(obj) {
            //审核
            layer.msg('确认审核通过？', {
                time: 0,//不自动关闭
                shade: 0.3,
                btn: ['通过', '拒绝'],
                yes: function (index) {
                    layer.close(index);
                    $.ajax({
                        url: WebServiceUrl + "/Statistical/Statistical.ashx",//random" + Math.random(),//方法所在页面和方法名
                        async: false,
                        dataType: "jsonp",
                        jsonp: "jsoncallback",
                        data: { "Id": cId, "BorrowStatus": 1, "action": "AuditingBorrow" },
                        success: function (json) {
                            if (json.result.Status == "error") {
                                layer.msg("操作失败！");
                                return;
                            }
                            if (json.result.Status == "no") {
                                layer.msg(json.result.Msg);
                                return;
                            }
                            if (json.result.Status == "ok") {
                                layer.msg(json.result.Msg);
                               
                                keepIframe();
                            }
                        },
                        error: OnError
                    });
                },
                cancel: function (index) {
                    layer.close(index);
                    $.ajax({
                        url: WebServiceUrl + "/Statistical/Statistical.ashx",//random" + Math.random(),//方法所在页面和方法名
                        async: false,
                        dataType: "jsonp",
                        jsonp: "jsoncallback",
                        data: { "Id": cId, "BorrowStatus": 4, "action": "AuditingBorrow" },
                        success: function (json) {
                            if (json.result.Status == "error") {
                                layer.msg("操作失败！");
                                return;
                            }
                            if (json.result.Status == "no") {
                                layer.msg(json.result.Msg);
                                return;
                            }
                            if (json.result.Status == "ok") {
                                layer.msg(json.result.Msg);
                                keepIframe();
                            }
                        },
                        error: OnError
                    });
                }
            });

        }


        function UpdateStatus( BorrowStatus) {
            $.ajax({
                url: WebServiceUrl + "/Statistical/Statistical.ashx",//random" + Math.random(),//方法所在页面和方法名
                async: false,
                dataType: "jsonp",
                jsonp: "jsoncallback",
                data: { "Id": cId, "BorrowStatus": BorrowStatus, "action": "AuditingBorrow" },
                success: function (json) {
                    if (json.result.Status == "error") {
                        layer.msg("操作失败！");
                        return;
                    }
                    if (json.result.Status == "no") {
                        layer.msg(json.result.Msg);
                        return;
                    }
                    if (json.result.Status == "ok") {
                        layer.msg(json.result.Msg);
                      
                        keepIframe();
                    }
                },
                error: OnError
            });
        }


        function keepIframe() {
            parent.window.location.href = '../Statistical/EquipborrowAuditing.aspx';
            var index = parent.layer.getFrameIndex(window.name);
            parent.layer.close(index);
            layer.msg("efse");
        }

    </script>
</body>
</html>

















