<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProjectList.aspx.cs" Inherits="EMS.Web.ProjectMan.ProjectList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>项目列表</title>
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
</head>
<script id="trTemp" type="text/x-jquery-tmpl">
    <tr>
        <td class="">${pageIndex()}</td>
        <td class="">${ContractNumber}</td>
        <td class=""><a href="javascript:PlanDetails(this,'${Id}');"><span title="${ContractName}">${NameLengthUpdate(ContractName,15)}</span></a></td>
        <td class="">${PartyB}</td>
        <td class="">${Money}</td>
        <td class="">${DateTimeConvert(CreateTime)}</td>
        <td class="">${CalculateNumForSplit(atta)}</td>
        <td class="">${CalculateNumForSplit(equip)}</td>
        <td>
            <span class=" ">
                <input type="hidden" name="hidContractName" value="${ContractName}" />
                <input class="Topic_btn" type="button" value="详情" onclick="ContractDetails(this, '${Id}')" />
            </span>
            <span class=" ">
                <input name="btnHide" class="Topic_btnDisable" disabled="disabled" title="不在信息录入时间内" type="button" value="编辑" onclick="UpdateContract(this, '${Id}')" />
            </span>
            <span class=" ">
                <input name="btnHide" class="Topic_btnDisable" disabled="disabled" title="不在信息录入时间内" type="button" value="删除" onclick="DeleteContract(this, '${Id}')" />
            </span>
        </td>
    </tr>
</script>
<body>
    <form id="form1" runat="server">
        <div class="Teaching_plan_management">
            <h1 class="Page_name">项目管理</h1>
            <div class="Operation_area clearfix">
                <div class="left_choice fl">
                    <ul class="clearfix">
                        <li class="Sear">
                            <input type="text" name="search_w" class="search_w" id="ContractName" placeholder="请输入项目名称" value="" />
                        </li>
                        <li class="Sear">
                            <input type="text" name="search_w" class="search_w" id="AttachmentName" placeholder="请输入附件名称" value="" />
                        </li>
                        <li class="Sear">
                            <input type="text" name="search_w" class="search_w" id="EquipName" placeholder="请输入设备名称" value="" />
                        </li>
                        <li class="Sear">
                            <a class="btn1" href="#" onclick="getData(1);">搜索</a>
                         </li>   
                    </ul>
                </div>
                <div class="fr">
                     <a  class="btn1" href="ProjectEdit.aspx?p=add">添加</a>
                </div>
            </div>
            <div class="Honor_management">
                <table class="W_form" id="tbList" cellspacing="0">
                    <%--<colgroup>
                        <col width="10%" />
                        <col width="25%" />
                        <col width="30%" />

                    </colgroup>--%>
                    <thead>
                        <tr class="trth">
                            <th class="number">序号</th>
                            <th class="Project_name">项目编号</th>
                            <th class="">项目名称</th>
                            <th class="">乙方签字人</th>
                            <th class="">交易金额</th>
                            <th class=" ">时间</th>
                            <th class="">附件数量</th>
                            <th class="">设备数量</th>
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
        <asp:HiddenField ID="hidUserRoleId" runat="server" />
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
                url: WebServiceUrl + "/Contract/Contract.ashx",//random" + Math.random(),//方法所在页面和方法名
                async: false,
                dataType: "jsonp",
                jsonp: "jsoncallback",
                data: { "PageIndex": startIndex, "pageSize": 10, "ContractName": $("#ContractName").val(), "AttachmentName": $("#AttachmentName").val(), "EquipName": $("#EquipName").val(), "Creator": $("#hidUserIDCard").val(), "UserRoleID": $("#hidUserIDCard").val(), "action": "GetPage" },
                success: OnSuccess,
                error: OnError
            });
        }

        function OnSuccess(json) {
            if (json.result.Status == "no" || json.result.Status == "error") {
                $("#tbList tbody").html('<tr><td colspan="100" style="text-align:center;">无内容</td></tr>');
            } else {
                $("#tbList tbody").html('');
                var dtJson = $.parseJSON(json.result.Data.PagedData);
                $("#trTemp").tmpl(dtJson.ds).appendTo("#tbList");
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

        function UpdateContract(obj, Id) {
            window.location = 'ProjectEdit.aspx?Id=' + Id + "&p=edit";
            //OpenIFrameWindow('编辑项目', 'ContractEdit.aspx?Id=' + Id, '650px', '470px');
        }

        function ContractDetails(obj, Id) {
            var CName = $(obj).parents("span:first").find("[name='hidContractName']").val();
            OpenIFrameWindow('项目详细：' + CName, 'ProjectDetail.aspx?Id=' + Id, '700px', '600px');
            return false;
        }

        function DeleteContract(obj, Id) {
            //确认删除
            layer.msg('确认删除？', {
                time: 0,//不自动关闭
                shade: 0.3,
                btn: ['确认', '取消'],
                yes: function (index) {
                    layer.close(index);
                    hidUserIDCard = $('#hidUserIDCard').val();
                    $.ajax({
                        url: WebServiceUrl + "/Contract/Contract.ashx",//random" + Math.random(),//方法所在页面和方法名
                        async: false,
                        dataType: "jsonp",
                        jsonp: "jsoncallback",
                        data: { "Id": Id, "UserIDCard": hidUserIDCard, "action": "DeleteContract" },
                        success: function (json) {
                            if (json.result.Status == "error") {
                                layer.msg("删除失败！");
                                return;
                            }
                            if (json.result.Status == "no") {
                                layer.msg(json.result.Msg);
                                return;
                            }
                            if (json.result.Status == "ok") {
                                layer.msg(json.result.Msg);
                                //静态删除
                                // $(obj).parents("li:first").remove();
                                getData(1);
                            }
                        },
                        error: OnError
                    });
                },
                cancel: function (index) {
                    layer.close(index);
                }
            });

        }
    </script>
</body>
</html>
