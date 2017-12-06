<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ScientificResearchList1.aspx.cs" Inherits="EMS.Web.ScientificResearch.ScientificResearchList1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>设备分类信息</title>
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

<body>
    <form id="form1" runat="server">
        <div class="Teaching_plan_management">
            <h1 class="Page_name">科研设备列表</h1>
            <div class="Operation_area">
                <div class="left_choice fl">
                    <ul>
                        <li class="Select">设备来源：
                            <select class="option" id="EquipSource">
                                <option value=''>全部</option>
                                <option value='0'>本院资产</option>
                                <option value='1'>资产系统</option>
                            </select>
                        </li>
                        <li class="Sear">
                            <input id="ClassName" type="text" name="search_w" class="search_w" placeholder="请输入分类名称" value="" />
                        </li>
                        <li class="Sear">
                            <input id="EquipName" type="text" name="search_w" class="search_w" placeholder="请输入设备名称" value="" />
                        </li>
                        <li>
                            <a class="btn1" href="#" onclick="javascript:SearchData();">搜索</a>
                        </li>

                    </ul>
                </div>
                <div class="right_add fr">
                </div>
            </div>
            <div class="Honor_management">
                <table class="W_form">
                    <thead>
                        <tr class="trth">
                            <th>序号</th>
                            <th>资产号</th>
                            <th>资产名称</th>
                            <th>资产类别</th>
                            <th>设备状态</th>
                            <th>计量单位</th>
                            <th>存放地点</th>
                            <th>设备来源</th>
                            <th>操作</th>
                        </tr>
                    </thead>
                    <tbody id="TbodyList">
                    </tbody>

                </table>
            </div>
        </div>
        <!--分页页码开始-->
        <div class="paging">
            <span id="pageBar"></span>
        </div>
        <!--分页页码结束-->
        <asp:HiddenField ID="hidIsAdmin" runat="server" />
        <asp:HiddenField ID="hidUserIDCard" runat="server" />
        <asp:HiddenField ID="hidUserRoleID" runat="server" />
    </form>
</body>
<script type="text/javascript">
    var EquipSource = "";//设备来源
    var ClassName = "";//分类名称
    var EquipName = "";//设备名称
    var UserIDCard = $('#hidUserIDCard').val();
    var SectionPlace = "";//科研所
    var distribution = "";//是否分配
    var Building = "";//房间

    $(document).ready(function () {
        SearchData();
    });

    //搜索
    function SearchData() {
        //获得搜索条件
        EquipSource = $('#EquipSource option:selected').val();
        ClassName = $('#ClassName').val().trim();
        EquipName = $('#EquipName').val().trim();
        getData(1);
    }

    //获取数据
    function getData(PageIndex) {
        //初始化序号 
        pageNum = (PageIndex - 1) * 10 + 1;
        PageSize = 10;
        $.ajax({
            type: "Post",
            url: WebServiceUrl + "/Statistical/Statistical.ashx",//random" + Math.random(),//方法所在页面和方法名
            //async: false,
            dataType: "jsonp",
            jsonp: "jsoncallback",
            data: {
                "PageIndex": PageIndex, "PageSize": PageSize, "AssetsClassName": $('#ClassName').val(), "Name": EquipName,
                "EquipSource": EquipSource, "action": "GetPageEquipDetail"
            },
            success: function (json) {
                if (json.result.Status == "error") {
                    //layer.msg(json.result.Msg);
                    return;
                }
                if (json.result.Status == "no") {
                    //layer.msg(json.result.Msg);
                    $("#TbodyList").html('');
                    //生成页码条方法（方法对象,页码条容器，当前页码，总页数，页码组容量，总行数）
                    makePageBar(getData, document.getElementById("pageBar"), 1, 1, 8, 0);

                    return;
                }
                if (json.result.Status == "ok") {
                    $("#TbodyList").html('');
                    $("#trTemp").tmpl(json.result.Data.PagedData).appendTo("#TbodyList");
                    //生成页码条方法（方法对象,页码条容器，当前页码，总页数，页码组容量，总行数）
                    makePageBar(getData, document.getElementById("pageBar"), json.result.Data.PageIndex, json.result.Data.PageCount, 8, json.result.Data.RowCount);
                }

            },
            error: OnError
        });

    }
    //错误处理
    function OnError(XMLHttpRequest, textStatus, errorThrown) {
        //layer.msg("");
    }
    function ShenQing(obj) {
        var ID = $(obj).parents(".Single").find("[name='hidEquipId']").val();
        $.ajax({
            type: "Post",
            url: WebServiceUrl + "/Statistical/Statistical.ashx",//random" + Math.random(),//方法所在页面和方法名
            //async: false,
            dataType: 'jsonp',
            jsonp: 'jsoncallback',
            data: { "Id": ID, "EquipStatus": 5, "action": "UpdateStatus" },
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
                    layer.msg("申请已提交");
                    getData(1);
                    return;
                }

            },
            error: OnError
        });
        getData(1);
    }
    function ShenPi(obj) {
        var ID = $(obj).parents(".Single").find("[name='hidEquipId']").val();

        layer.msg('借用审核', {
            time: 0,//不自动关闭
            shade: 0.3,
            btn: ['通过', '不通过'],
            yes: function (index) {
                layer.close(index);
                $.ajax({
                    type: "Post",
                    url: WebServiceUrl + "/Statistical/Statistical.ashx",//random" + Math.random(),//方法所在页面和方法名
                    //async: false,
                    dataType: "json",
                    data: { "Id": ID, "EquipStatus": 1 },
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
                            layer.msg("审核通过");
                            getData(1);
                            return;
                        }

                    },
                    error: OnError
                });
            },
            cancel: function (index) {
                layer.close(index);
                $.ajax({
                    type: "Post",
                    url: WebServiceUrl + "/Statistical/Statistical.ashx",//random" + Math.random(),//方法所在页面和方法名
                    //async: false,
                    dataType: "json",
                    data: { "Id": ID, "EquipStatus": 0 },
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
                            layer.msg("审核不通过");
                            getData(1);
                            return;
                        }

                    },
                    error: OnError
                });
            }
        });


    }
</script>
<script id="trTemp" type="text/x-jquery-tmpl">
    <tr class="Single">
        <td>${pageIndex()}</td>
        <td>${AssetNumber}</td>
        <td><a href="javascript:OpenIFrameWindow('设备详情','../Statistical/EquipDetailInfo.aspx?Id=${Id}','70%','650px');"><span title="${AssetName}">${NameLengthUpdate(AssetName,15)}</span></a></td>
        <td>${AssetsClassName}</td>
        <td>${EquipStatusChange(EquipStatus)}</td>
        <td>${Unit}</td>
        <td>${WarehouseName}</td>
        <td>${EquipSourceToStr(EquipSource)}</td>
        <td>
            <input name="hidEquipStatus" type="hidden" value="${EquipStatus}" />
            <input name="hidEquipId" type="hidden" value="${Id}" />
            <span>
           <%-- {{if EquipStatus == 0 }}
                 {{if IsConsume == 0}}  
                <input type="button" class="Topic_btn" value="报修" onclick="OpenIFrameWindow('报修', '../Order/RepairEdit.aspx?eqID=${Id}', '650px', '360px')" />
                {{else}}
                {{if EquipStatus == 1 }}
                 {{if IsConsume == 0}}
                 <input type="button" class="Topic_btn" value="报修" onclick="OpenIFrameWindow('报修', '../Order/RepairEdit.aspx?eqID=${Id}', '650px', '360px')" />
                {{/if}}
                   {{/if}}
                   {{/if}}
                 {{/if}}--%>

                 {{if IsConsume == 0}}
                    {{if EquipStatus == 0 }}
                         <input type="button" class="Topic_btn" value="报修" onclick="OpenIFrameWindow('报修', '../Order/RepairEdit.aspx?eqID=${Id}', '650px', '360px')" />
                    {{/if}}
                      {{if EquipStatus != 0 }}
                           <input type="button" class="Topic_btn" value="报修" disabled="disabled" style="background:#ccc;" />
                      {{/if}}
                  {{/if}}
                  {{if IsConsume != 0}}
                          <input type="button" class="Topic_btn" value="报修" disabled="disabled" style="background:#ccc;" />
                   {{/if}}

            </span>

        </td>
    </tr>
</script>
</html>
