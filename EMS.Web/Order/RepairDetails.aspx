<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RepairDetails.aspx.cs" Inherits="EMS.Web.Order.RepairDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>报修详细</title>
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
        .Validform_wrong {
            color: red;
            white-space: nowrap;
            padding-left: 5px;
        }

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
                    width: 100px;
                }

            .InfoTable td span {
                line-height: 20px;
            }

                .InfoTable td span input {
                    height: 30px;
                    padding-left: 8px;
                }

        .shangchuana {
            float: right;
            width: 100px;
            height: 30px;
        }

            .shangchuana .ui-upload-txt {
                width: 100px;
            }

            .shangchuana .ui-upload-holder {
                width: 100px;
            }
    </style>
    <script id="trTemp" type="text/x-jquery-tmpl">
        <tr>
            <td class="">${RecordDate}</td>
            <td class=""><span title="${name}">${NameLengthUpdate(Record,50)}</span></td>
            <td>
                <span class=" ">
                    <input name="btnHide" type="button" value="编辑" onclick="updeleteRepairDetails(this, '${Id}')" />
                </span>
                <span class=" ">
                    <input name="btnHide" type="button" value="删除" onclick="deleteRepairDetails(this, '${Id}')" />
                </span>
            </td>
        </tr>
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="Teaching_plan_management">
            <span class="cancel">
                <input class="Topic_btn" type="button" value="返回" onclick="javascript: history.back(-1);" style="float: right;" /></span>
            <h1 class="Page_name"><span id="PlanName"></span>报修详细</h1>
            <table class="InfoTable">

                <tr>
                    <td><span class="m">修理地点：</span></td>
                    <td>
                        <span>
                             <label id="txt_RepairLocation"></label>
                          <%--  <input id="txt_RepairLocation" type="text" class="hu" placeholder="请输入修理地点" />--%>
                        </span>
                    </td>
                    <td>修理<span class="m">费用：</span></td>
                    <td>
                        <span>
                               <label id="txt_CostOfRepairs"></label>
                         <%--   <input id="txt_CostOfRepairs" type="text" class="hu" placeholder="请输入修理费用" />--%>
                        </span>
                    </td>
                    <td><span class="m">损坏时间：</span></td>
                    <td>
                        <span>
                             <label id="txt_Damagetime"></label>
                           <%-- <input id="txt_Damagetime" class="hu" type="text" placeholder="选择日期" onclick="javascript: WdatePicker({ mindate: '#F{$dp.$D(\'txt_CompleteTime\')||\'new Date()\'}' });" />--%>
                        </span>
                    </td>
                    <td><span class="m">完成时间：</span></td>
                    <td>
                        <span>
                             <label id="txt_CompleteTime"></label>
                          <%--  <input id="txt_CompleteTime" class="hu" type="text" placeholder="选择日期" onclick="javascript: WdatePicker({ minDate: '#F{$dp.$D(\'txt_Damagetime\')}', maxDate: new Date() });" />--%>
                        </span>
                    </td>

                </tr>
                <tr>
                    <td class="mi"><span class="m">损坏原因：</span></td>
                    <td class="ku" colspan="7">
                          <label id="te_DamageCauses"></label>
                       <%-- <textarea id="te_DamageCauses" name="te_remark" rows="4" style="width: 100%;"></textarea>--%>
                    </td>
                </tr>
                <tr>
                    <td class="mi"><span class="m">备注：</span></td>
                    <td class="ku" colspan="7">
                         <label id="te_remark"></label>
                        <%--<textarea id="te_remark" name="te_remark" rows="4" style="width: 100%;"></textarea>--%>
                    </td>
                </tr>
                <tr>
                    <td colspan="8">维修记录：

                        <span id="Part" class="fr">
                               <input id="add" type="button" class="btn1" value="新增记录" onclick="OpenIFrameWindows()" style="padding:0px 8px;cursor:pointer;"/>
                           
                        </span>
                    </td>
                </tr>

                <tr>
                    <td colspan="8">
                        <div class="Honor_management">
                            <table class="W_form" id="tbList" cellspacing="0">
                                <colgroup>
                                    <col width="10%" />
                                    <col width="25%" />
                                    <col width="30%" />

                                </colgroup>
                                <thead>
                                    <tr class="trth">
                                        <th class="Project_name" style="width: 15%">新增时间</th>
                                        <th class="Project_name" style="width: 55%">记录内容</th>
                                        <th style="width: 30%">操作</th>
                                    </tr>
                                </thead>
                                <tbody id="Tb_List">
                                </tbody>
                            </table>

                        </div>
                    </td>
                </tr>
                <tr>
                    <td colspan="8">
                        <div class="submit_btn">
                            <span class="cancel">
                                <input class="cancel" type="button" value="返回" /></span>
                        </div>
                    </td>

                </tr>
            </table>
            <br />

        </div>
        <asp:HiddenField ID="hidId" runat="server" />
    </form>
    <script type="text/javascript">

        var fileArry = [];
        var readArry = [];
        var readyObj = [];
        var Id = $('#hidId').val();
        $(document).ready(function () {
            GetRepairDetails();
        });

        //获得报修详细
        function GetRepairDetails() {
            $.ajax({
                type: "Post",
                url: WebServiceUrl + "/Order/Order.ashx",
                //async: false,
                dataType: "jsonp",
                jsonp: "jsoncallback",
                data: { "Id": Id, "action": "SelectRepairDetails" },
                success: function (json) {
                    for (var i = 0; i < json.result.length; i++) {
                        Plan = json.result[i];
                        $('#txt_RepairLocation').html(Plan.RepairLocation);
                        $('#txt_CostOfRepairs').html(Plan.CostOfRepairs);
                        $('#txt_CompleteTime').html(DateTimeConvert(Plan.CompleteTime, "yyyy-MM-dd"));
                        $('#txt_Damagetime').html(DateTimeConvert(Plan.Damagetime, "yyyy-MM-dd"));
                        $('#te_DamageCauses').html(Plan.DamageCauses);
                        $('#te_remark').html(Plan.Remark);
                    }

                },
                error: OnError
            });


            $.ajax({
                type: "Post",
                url: WebServiceUrl + "/Order/Order.ashx",
                //async: false,
                dataType: "jsonp",
                jsonp: "jsoncallback",
                data: { "Id": Id, "action": "GetRepairDetails" },
                success: function (json) {
                    if (json.result.Status == "no" || json.result.Status == "error") {
                        $("#Tb_List").html('<tr><td colspan="100"  style="text-align:center;">无内容</td></tr>');
                    } else {
                        $("#Tb_List").html('');
                        var data = $.parseJSON(json.result.Data);
                        $("#trTemp").tmpl(data.ds).appendTo("#Tb_List");
                    }

                },
                error: OnError
            });



        }
        function OnError(XMLHttpRequest, textStatus, errorThrown) {
            //layer.msg("加载失败");
        }


        ///保存基础信息
        function SetRepairDetails() {
            var RepairLocation = $("#txt_RepairLocation").val().trim();
            var CostOfRepairs = $("#txt_CostOfRepairs").val().trim();
            var CompleteTime = $("#txt_CompleteTime").val().trim();
            var Damagetime = $("#txt_Damagetime").val();
            var DamageCauses = $("#te_DamageCauses").val().trim();
            var remarks = $("#te_remark").val().trim();
            var useridcard = $("#hid_UserIDCard").val();
            $.ajax({
                type: "Post",
                url: WebServiceUrl + "/Order/Order.ashx",//random" + Math.random(),//方法所在页面和方法名
                //async: false,
                dataType: "jsonp",
                jsonp: "jsoncallback",
                data: {
                    "id": $("#hidId").val(),
                    "RepairLocation": RepairLocation,
                    "CostOfRepairs": CostOfRepairs,
                    "CompleteTime": CompleteTime,
                    "Damagetime": Damagetime,
                    "DamageCauses": DamageCauses,
                    "remarks": remarks,
                    "useridcard": useridcard,
                    "fileJson": JSON.stringify(readArry),
                    "action": SetRepairDetails
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
                    if (json.result.Status == "ok") {
                        parent.layer.msg(json.result.Msg);
                        window.location = "RepairList.aspx";
                    }
                },
                error: OnError
            });
        }


        //删除
        function deleteRepairDetails(obj, id)
        {
            layer.msg('是否删除？', {
                time: 0,
                shade: 0.3,
                btn: ['是', '否'],
                yes: function (index) {
                    layer.close(index);

                    $.ajax({
                        url: WebServiceUrl + "/Order/Order.ashx",//random" + Math.random(),//方法所在页面和方法名
                        async: false,
                        dataType: "jsonp",
                        jsonp: "jsoncallback",
                        data: { "ID": id, "action": "deleteRepairDetails" },
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
                                GetRepairDetails();
                            }
                        },
                        error: OnError
                    });
                },
                cancel: function (index) {
                    layer.close(index);
                },
            });
        }

        function OpenIFrameWindows() {
            OpenIFrameWindow('新增报修记录', 'AddRepairDetails.aspx?p=add&id=' + $("#hidId").val() + '&Rid=0', '870px', '470px');
        }

        function updeleteRepairDetails(obj, id) {
          
            OpenIFrameWindow('编辑报修记录', 'AddRepairDetails.aspx?p=edit&id=' + $("#hidId").val()+'&Rid='+id, '870px', '470px');
        }
    </script>
</body>
</html>


















