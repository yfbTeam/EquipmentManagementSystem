<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RepairList.aspx.cs" Inherits="EMS.Web.Order.RepairList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link type="text/css" rel="stylesheet" href="../css/style.css" />
    <link type="text/css" rel="stylesheet" href="../css/common.css" />
    <link type="text/css" rel="stylesheet" href="../css/iconfont.css" />
    <link type="text/css" rel="stylesheet" href="../css/animate.css" />
    <script type="text/javascript" src="../js/jquery-1.11.2.min.js"></script>
    <script type="text/javascript" src="../js/tz_slider.js"></script>
    <script src="../js/Common.js"></script>
    <script src="../js/layer/layer.js"></script>
    <script src="../js/jquery.tmpl.js"></script>
    <script src="../js/PageBar.js"></script>
</head>


<script id="trTemp" type="text/x-jquery-tmpl">
    <tr>
        <td class="">${pageIndex()}</td>
        <td class="">${name}</td>
        <td class="">${CreateName}</td>
        <td class="">${DateTimeConvert(Damagetime)}</td>
        <td class="">${CostOfRepairs}</td>
        <td class="">${RepairStatu(RepairStatus)}</td>
        <td>
            <span>
                <input type="button" class="Topic_btn" onclick="RepairDetails(this, '${ID}')" value="查看详情" />
            </span>
            <span>{{if RepairStatus == 0}}
                   <input type="button" class="Topic_btn" onclick="UpdateStatus(this, '${RepairStatus}', '${ID}', '${EquipID}')" value="送修" />
                {{/if}}
                  {{if RepairStatus == 1}}
                  <input type="button" class="Topic_btn" onclick="UpdateStatus(this, '${RepairStatus}', '${ID}', '${EquipID}')" value="取回" />
                {{/if}}
                {{if RepairStatus == 2}}
                  <input type="button" class="Topic_btn" onclick="DeteleRepair(this, '${ID}')" value="删除" />
                {{/if}}
            </span>

        </td>
    </tr>
</script>
<body>
    <input type="hidden" id="Hid_IDCard" runat="server" />
    <form id="form1" runat="server">
        <div>
            <div class="Teaching_plan_management">
                <h1 class="Page_name">报修管理</h1>
                <div class="Operation_area">
                    <div class="left_choice fl">
                        <ul>
                            <li class="Select">资产分类：
                            <select class="option" id="EQtype">
                                <option value=''>全部</option>
                                <option value='0'>教学资产</option>
                                <option value='1'>科研资产</option>
                                <option value='2'>办公资产</option>
                            </select>
                            </li>
                            <li class="Sear">
                                <input type="text" name="search_w" class="search_w" id="name" placeholder="请输入设备名称" value="" />
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
                                <%--<th class="checkbox"><input type="checkbox"></th>--%>
                                <th class="number">序号</th>
                                <th class="">设备名称</th>
                                <th class="">报修人</th>
                                <th class=" ">损坏时间</th>
                                <th class="">报修费用</th>
                                <th class="">状态</th>
                                <th>操作</th>
                            </tr>
                        </thead>
                        <tbody>
                        </tbody>
                    </table>

                </div>
                <!--分页页码开始-->
                <div class="paging">
                    <span id="pageBar"></span>
                </div>
                <!--分页页码结束-->

            </div>

        </div>
    </form>
</body>


<script type="text/javascript">
    function GetUrlDate() {
        var name, value;
        var str = location.href; //取得整个地址栏
        var num = str.indexOf("?")
        str = str.substr(num + 1); //取得所有参数   stringvar.substr(start [, length ]

        var arr = str.split("&"); //各个参数放到数组里
        for (var i = 0; i < arr.length; i++) {
            num = arr[i].indexOf("=");
            if (num > 0) {
                name = arr[i].substring(0, num);
                value = arr[i].substr(num + 1);
                this[name] = value;
            }
        }
    }
    var UrlDate = new GetUrlDate(); //实例化
    $(document).ready(function () {
        //获取数据
        getData(1);

    });

    //获取数据
    function getData(startIndex) {
        //初始化序号 
        pageNum = (startIndex - 1) * 10 + 1
        $.ajax({
            url: WebServiceUrl + "/Order/Order.ashx",//random" + Math.random(),//方法所在页面和方法名
            async: false,
            dataType: "jsonp",
            jsonp: "jsoncallback",
            data: { "PageIndex": startIndex, "pageSize": 10, "IDCard": $("#Hid_IDCard").val(), "userName": "", "name": $("#name").val(), "EQtype": $("#EQtype").val(), "action": "RepairList" },
            success: OnSuccess,
            error: OnError
        });

    }

    function OnSuccess(json) {
        if (json.result.Data == null) {
            $("#tbList tbody").html('<tr><td colspan="100"  style="text-align:center;">无内容</td></tr>');
        } else {
            $("#tbList tbody").html('');
            $("#trTemp").tmpl(json.result.Data.PagedData).appendTo("#tbList");
            //隔行变色以及鼠标移动高亮
            $(".main-bd table tbody tr").mouseover(function () {
                $(this).addClass("over");
            }).mouseout(function () {
                $(this).removeClass("over");
            })
            $(".main-bd table tbody tr:odd").addClass("alt");
            //生成页码条方法（方法对象,页码条容器，当前页码，总页数，页码组容量，总行数）
            //makePageBar(getData, document.getElementById("pageBar"), json.result.Data.PageIndex, json.result.Data.PageCount, 8, json.result.Data.RowCount, document.getElementById("dataTable1_info"));
            makePageBar(getData, document.getElementById("pageBar"), json.result.Data.PageIndex, json.result.Data.PageCount, 8, json.result.Data.RowCount);

        }
    }
    function OnError(XMLHttpRequest, textStatus, errorThrown) {
        $("#tbList tbody").html('<tr><td colspan="100"  style="text-align:center;">无内容</td></tr>');

    }


    function UpdateStatus(obj, status, id, EquipID) {
        if (status == 0) {
            OpenIFrameWindow('送修信息填报', 'RepairInfo.aspx?Id=' + id, '400px', '300px');
        }
        if (status == 1) {
            layer.msg('是否修好？', {
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
                        data: { "ID": id, "EquipID": EquipID, "type": "yes", "action": "UpdateStatus" },
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
                        url: WebServiceUrl + "/Order/Order.ashx",//random" + Math.random(),//方法所在页面和方法名
                        async: false,
                        dataType: "jsonp",
                        jsonp: "jsoncallback",
                        data: { "ID": id, "EquipID": EquipID, "type": "no", "action": "UpdateStatus" },
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
                                layer.msg(json.result.Msg + ",此资产已经自动设置为作废");
                                getData(1);
                            }
                        },
                        error: OnError
                    });
                }
            });
        }
    }



    function DeteleRepair(obj, id) {
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
                    data: { "ID": id, "action": "DeteleRepair" },
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
            },
        });


    }





    function RepairDetails(obj, Id) {
        // OpenIFrameWindow('报修详情', 'RepairDetails.aspx?Id=' + Id, '650px', '470px');
        window.location = 'RepairDetails.aspx?Id=' + Id;
    }
</script>

</html>
