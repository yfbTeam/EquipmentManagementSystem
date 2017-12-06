<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BuildingLayerOperate.aspx.cs" Inherits="EMS.Web.SystemSettings.BuildingLayerOperate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>楼层管理</title>
    <link href="/css/style.css" rel="stylesheet" />
    <link href="/css/common.css" rel="stylesheet" />
    <link href="/css/iconfont.css" rel="stylesheet" />
    <link href="/css/animate.css" rel="stylesheet" />
    <script src="/js/jquery-1.11.2.min.js"></script>
    <script src="/js/layer/layer.js"></script>
    <script src="/js/Common.js"></script>
    <script src="/js/jquery.tmpl.js"></script>
    <script src="/js/PageBar.js"></script>
    <script id="tr_User" type="text/x-jquery-tmpl">
        <tr>
            <td>${pageIndex()}</td>
            <td><span id="span_${Id}">${Name}</span><div id="div_${Id}" style="display: none;">
                <input type="text" id="txt_name${Id}" value='' style="height: 22px; line-height: 22px;" onkeyup="value=value.replace(/[^\d]/g,'')"/> 层
                <input type="button" class="Topic_btn" value="确定" onclick="javascript: SaveBuild('${Id}', 'layer');" />
                <input type="button" class="Topic_btn" value="取消" onclick="javascript: $('#div_${Id}').hide(); $('#span_${Id}').show();" />
               </div>
            </td>
            <td>${DateTimeConvert(CreateTime)}</td>
            <td>
                <input type="button" class="Topic_btn" value="编辑" onclick="javascript: $('#span_${Id}').hide(); $('#div_${Id}').show(); $('#txt_name${Id}').val('${Name}');" />
                <input type="button" class="Topic_btn" value="删除" onclick="javascript: DeleteBuilding('${Id}', 'layer');" />
            </td>
        </tr>
    </script>
</head>
<body>
    <input type="hidden" id="hid_Pid" runat="server" />
    <input type="hidden" id="hid_UserIDCard" runat="server" />
    <!--tz_dialog start-->
    <div class="yy_dialog">
        <div class="t_content">
            <div class="yy_tab">
                <div class="content">
                    <div class="tc">
                        <div class="Operation_area">
                            <div class="left_choice fl">
                                <ul>
                                    <li class="Sear"></li>
                                </ul>
                            </div>
                            <div class="right_add fr">
                                <div style="float: left; margin-right: 10px;">添加楼层：<input type="text" id="txt_layer" name="txt_layer" placeholder="请输入数字" onkeyup="value=value.replace(/[^\d]/g,'') " style="width: 150px; height: 28px; line-height: 28px;" /> 层</div>
                                <a href="javascript:void(0);" class="add" onclick="javascript:SaveBuild('0','layer');"><i class="iconfont">&#xe726;</i>确定</a>
                            </div>
                        </div>
                        <div class="Honor_management">
                            <table class="W_form" id="tb_UserList" style="background: white;">
                                <thead>
                                    <tr class="trth">
                                        <th class="number">序号</th>
                                        <th style="width: 280px;">楼层名称</th>
                                        <th class="">创建时间</th>
                                        <th>操作</th>
                                    </tr>
                                </thead>
                                <tbody></tbody>
                            </table>
                        </div>
                        <!--分页页码开始-->
                        <div class="paging">
                            <span id="pageBar"></span>
                        </div>
                        <!--分页页码结束-->
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!--end tz_dialog-->

    <!--tz_yy start-->
    <div class="tz_yy"></div>
    <!--end tz_yy-->
</body>
<script type="text/javascript">
    $(document).ready(function () {
        //获取数据
        getData(1);
    });
    //获取数据
    function getData(startIndex) {
        //初始化序号 
        pageNum = (startIndex - 1) * 10 + 1;
        $.ajax({
            url: WebServiceUrl + "/SystemSettings/Building.ashx",//random" + Math.random(),//方法所在页面和方法名
            type: "post",
            async: false,
            dataType: "jsonp",
            jsonp: "jsoncallback",
            data: { pid: $("#<%=hid_Pid.ClientID%>").val(), startIndex: startIndex, pageSize: 10, action: "GetDataPage" },
            success: OnSuccess,
            error: OnError
        });

    }

    function OnSuccess(json) {
        if (json.result.Status.toString() == "no") {
            $("#tb_UserList tbody").html('<tr><td colspan="100"  style="text-align:center;">无内容</td></tr>');
        } else {
            $("#tb_UserList tbody").html('');
            $("#tr_User").tmpl(json.result.Data.PagedData).appendTo("#tb_UserList");
            //隔行变色以及鼠标移动高亮
            $(".main-bd table tbody tr").mouseover(function () {
                $(this).addClass("over");
            }).mouseout(function () {
                $(this).removeClass("over");
            })
            $(".main-bd table tbody tr:odd").addClass("alt");
            //生成页码条方法（方法对象,页码条容器，当前页码，总页数，页码组容量，总行数）
            makePageBar(getData, document.getElementById("pageBar"), json.result.Data.PageIndex, json.result.Data.PageCount, 8, json.result.Data.RowCount);
        }
    }
    function OnError(XMLHttpRequest, textStatus, errorThrown) {
        $("#tb_UserList tbody").html('<tr><td colspan="100"  style="text-align:center;">无内容</td></tr>');
    }
    function SaveBuild(curid, flag) {
        var name, url, paction;
        var re = /[1-9][0-9]{0,5}/ig;
        if (curid != "0") {
            url = WebServiceUrl + "/SystemSettings/Building.ashx";
            name = $("#txt_name" + curid).val().trim();
            paction = "EditBuilding";
        } else {
            url = WebServiceUrl + "/SystemSettings/Building.ashx";
            name = $("#txt_layer").val().trim();
            paction = "AddBuilding";
        }
        if (!name.length) {
            layer.msg("请填写楼层！");
            return;
        }
        if (!re.test(name)) {
            layer.msg("请输入正确楼层数字！");
            return;
        }
        $.ajax({
            url: url,//random" + Math.random(),//方法所在页面和方法名
            type: "post",
            async: false,
            dataType: "jsonp",
            jsonp: "jsoncallback",
            data: {
                itemid: curid,
                flag: flag,
                name: name.trim(),
                pid: $("#<%=hid_Pid.ClientID%>").val(),
                useridcard: $("#hid_UserIDCard").val(),
                action:paction
            },
            success: function (json) {
                if (json.result == "-1") {
                    layer.msg("该楼层已存在！");
                }
                else if (json.result != "0" && json.result != "-1") {
                    layer.msg('操作成功!');
                    if (curid == "0") {
                        $("#txt_layer").val("");
                    }
                    getData(1);
                } else {
                    layer.msg("操作失败！");
                }
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                layer.msg("操作失败！");
            }
        });
    }
    //删除楼层
    function DeleteBuilding(curid, flag) {
        layer.msg("确定要删除该楼层？", {
            time: 0 //不自动关闭
            , btn: ['确定', '取消']
            , yes: function (index) {
                layer.close(index);
                $.ajax({
                    url: WebServiceUrl + "/SystemSettings/Building.ashx",//random" + Math.random(),//方法所在页面和方法名
                    type: "post",
                    async: false,
                    dataType: "jsonp",
                    jsonp: "jsoncallback",
                    data: { intID: curid, flag: flag, useridcard: $("#hid_UserIDCard").val(), action: "DeleteBuilding" },
                    success: function (json) {
                        if (json.result.Status == "ok") {
                            layer.msg(json.result.Msg);
                            getData(1);
                        } else {
                            layer.msg(json.result.Msg);
                        }
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        layer.msg("操作失败！");
                    }
                });
            }
        });
    }
</script>
</html>


