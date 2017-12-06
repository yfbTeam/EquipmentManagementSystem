﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EquipborrowAuditing.aspx.cs" Inherits="EMS.Web.Statistical.EquipborrowAuditing" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>资产借用审核</title>
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
    <script src="../js/My97DatePicker/WdatePicker.js"></script>
</head>
<script id="trTemp" type="text/x-jquery-tmpl">
    <tr>
        <td class="">${pageIndex()}</td>
        <td class="">${CreateName}</td>
        <td class="">${DateTimeConvert(BeginDate)}</td>
        <td class="">${DateTimeConvert(EndDate)}</td>
        <td class="">${BorrowStatu(BorrowStatus)}</td>
        <td>
            <span class=" ">
                <input class="Topic_btn" type="button" value='${BorrowStatu(BorrowStatus)}' onclick="BorrowDetails(this, '${Id}','${BorrowStatus}')" />
            </span>
           <%-- {{if BorrowStatus == 0}}
                 <span class=" ">
                     <input name="btnHide" class="Topic_btnDisable" disabled="disabled" title="借用审核" type="button" value="借用审核" onclick="AuditingBorrow(this, '${Id}')" />
                 </span>
            {{/if}}
             {{if BorrowStatus == 1}}
                 <span class=" ">
                     <input name="btnHide" class="Topic_btnDisable" disabled="disabled" title="设置领用" type="button" value="设置领用" onclick="UpdateStatus('${Id}', 2)" />
                 </span>
            {{/if}}
             {{if BorrowStatus == 2}}
                 <span class=" ">
                     <input name="btnHide" class="Topic_btnDisable" disabled="disabled" title="资产归还" type="button" value="资产归还" onclick="UpdateStatus('${Id}', 3)" />
                 </span>
            {{/if}}--%>
        </td>
    </tr>
</script>
<body>
    <form id="form1" runat="server">
        <div class="Teaching_plan_management">
            <h1 class="Page_name">资产借用审核</h1>
            <div class="Operation_area">
                <div class="left_choice fl">
                    <ul>
                        <li class="Sear">
                            <input id="txt_BeginDate" class="search_w Wdate" type="text" placeholder="借用时间" onclick="var endDate = $dp.$('txt_EndDate'); WdatePicker({ onpicked: function () { endDate.focus(); }, maxDate: '#F{$dp.$D(\'txt_EndDate\')}' })" />
                        </li>
                        <li class="Sear">
                            <input id="txt_EndDate" class="search_w Wdate" type="text" placeholder="归还时间" onclick="WdatePicker({ minDate: '#F{$dp.$D(\'txt_BeginDate\')}' })" />
                        </li>
                        <li class="Sear">借用状态：<select id="se_BorrowStatus" name="sel_Room" class="search_w">
                            <option value="">全部</option>
                            <option value="0">审核中</option>
                            <option value="1">待领用</option>
                            <option value="2">借用中</option>
                            <option value="3">已归还</option>
                            <option value="4">未通过</option>
                        </select>

                        </li>
                        <li class="Sear">
                            <a class="btn1" href="#" onclick="getData(1);">搜索</a>
                        </li>
                    </ul>
                </div>

            </div>
            <div class="Honor_management">
                <table class="W_form" id="tbList" cellspacing="0">
                    <colgroup>
                        <col width="10%" />
                        <col width="25%" />
                        <col width="30%" />

                    </colgroup>
                    <thead>
                        <tr class="trth">
                            <th class="number">序号</th>
                            <th class=" ">借用人</th>
                            <th class="Project_name">借用时间</th>
                            <th class="">归还时间</th>
                            <th class=" ">借用状态</th>
                            <th>操作</th>
                        </tr>
                    </thead>
                    <tbody>
                    </tbody>
                </table>

            </div>
        </div>
        <!--分页页码开始-->
        <div class="paging">
            <span id="pageBar"></span>
        </div>
        <!--分页页码结束-->
        <asp:HiddenField ID="hidUserIDCard" runat="server" />
        <asp:HiddenField ID="hidIsAdmin" runat="server" />

    </form>
    <script type="text/javascript">
        $(document).ready(function () {

            //获取数据
            getData(1);

        });

        function IsShow() {
            //如果是管理员则启用所有按钮
            if ($("#hidIsAdmin").val() == "true") {
                $("[name='btnHide']").removeAttr("disabled");
                $("[name='btnHide']").removeAttr("title");
                $("[name='btnHide']").removeClass().addClass("Topic_btn");
                return;
            }
        }
        //获取数据
        function getData(startIndex) {
            //初始化序号 
            pageNum = (startIndex - 1) * 10 + 1
            $.ajax({
                url: WebServiceUrl + "/Statistical/Statistical.ashx",//random" + Math.random(),//方法所在页面和方法名
                async: false,
                dataType: "jsonp",
                jsonp: "jsoncallback",
                data: { "PageIndex": startIndex, "pageSize": 10, "UserIDCard": "", "BeginDate": $("#txt_BeginDate").val(), "EndDate": $("#txt_EndDate").val(), "BorrowStatus": $("#se_BorrowStatus").val(), "action": "getBorrowRecord" },
                success: OnSuccess,
                error: OnError
            });
        }

        function OnSuccess(json) {
            if (json.result.Status == "no" || json.result.Status == "error") {
                $("#tbList tbody").html('<tr><td colspan="100"  style="text-align:center;">无内容</td></tr>');
            } else {
                $("#tbList tbody").html('');
                //  var dtJson = $.parseJSON(json.result.Data.PagedData);
                $("#trTemp").tmpl(json.result.Data.PagedData).appendTo("#tbList");
                //隔行变色以及鼠标移动高亮
                $(".main-bd table tbody tr").mouseover(function () {
                    $(this).addClass("over");
                }).mouseout(function () {
                    $(this).removeClass("over");
                })
                $(".main-bd table tbody tr:odd").addClass("alt");
                makePageBar(getData, document.getElementById("pageBar"), json.result.Data.PageIndex, json.result.Data.PageCount, 8, json.result.Data.RowCount);

            }
            IsShow();
        }
        function OnError(XMLHttpRequest, textStatus, errorThrown) {
            $("#tbList tbody").html('<tr><td colspan="100"  style="text-align:center;">无内容</td></tr>');

        }

        function UpdateStatus(Id, BorrowStatus) {
            $.ajax({
                url: WebServiceUrl + "/Statistical/Statistical.ashx",//random" + Math.random(),//方法所在页面和方法名
                async: false,
                dataType: "jsonp",
                jsonp: "jsoncallback",
                data: { "Id": Id, "BorrowStatus": BorrowStatus, "action": "AuditingBorrow" },
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
                        getData(1);
                    }
                },
                error: OnError
            });
        }






        function AuditingBorrow(obj, Id) {
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
                        data: { "Id": Id, "BorrowStatus": 1, "action": "AuditingBorrow" },
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
                                getData(1);
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
                        data: { "Id": Id, "BorrowStatus": 4, "action": "AuditingBorrow" },
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
                                getData(1);
                            }
                        },
                        error: OnError
                    });
                }
            });

        }

        ///详细
        function BorrowDetails(obj, Id, BorrowStatus) {
            OpenIFrameWindow('借用管理', '../OfficeFurniture/BorrowDetails.aspx?Id=' + Id + '&BorrowStatus=' + BorrowStatus, '700px', '600px');
            return false;
        }

    </script>
</body>
</html>
