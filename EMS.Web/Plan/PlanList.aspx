<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PlanList.aspx.cs" Inherits="EMS.Web.Plan.PlanList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>教学计划列表</title>
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
    <style type="text/css">
        .Topic_btnDisable  { line-height:24px; background:#DEDEDE !important; font-size:14px; color:#BDBDBD; margin:1px; border:none; border-radius:3px; cursor:not-allowed;}
        .addDisable { display:block; padding:8px 8px; background:#DEDEDE; border-radius:3px; color:#BDBDBD; float:left; margin-right:4px; cursor:not-allowed;}
    </style>
    <!--课程模板-->
    <script id="trTemp" type="text/x-jquery-tmpl">
        <li name="${Id}" id="${Id}">
            <a class="Topic_click" href="#">
                <table class="W_form1">
                    <tr name="trName1">
                        <td class="number">${pageIndex()}</td>
                        <td class="Project_name"><a href="javascript:;"><span title="${Name}">${NameLengthUpdate(Name,15)}</span></a></td>
                        <td class="Term">${LearnYearName}</td>
                        <td class="erlie">${MainTeacher}</td>
                        <td class="erlie">${CreateName}</td>
                        <td class="erlie">${DateTimeConvert(CreateTime)}</td>
                        <td>
                            <input type="hidden" name="IsDelete" value="${IsDelete}" />
                            <input type="hidden" name="PlanName" value="${Name}" />
                            <input type="hidden" name="LearnYear" value="${LearnYear}" />
                            <span class=" ">
                                <input class="Topic_btn" type="button" value="详情" onclick="PlanDetails(this,'${Id}')"; />
                            </span>
                            <span class=" ">
                                <input name="btnHide" class="Topic_btnDisable" disabled="disabled" title="不在信息录入时间内" type="button" value="编辑" onclick="UpdatePlan(this, '${Id}')" />
                            </span>
                            <span class=" ">
                                <input name="btnHide" class="Topic_btnDisable" disabled="disabled" title="不在信息录入时间内"  type="button" value="删除" onclick="Delete(this, '${Id}')" />
                            </span>
                            <span class="newExap ">
                                <input name="btnHide" class="Topic_btnDisable" disabled="disabled" title="不在信息录入时间内" type="button" value="新增实验" onclick="add_exper('${Id}', '${Name}', '${Id}', '${StartDate}', '${EndDate}')"/></span>
                        </td>
                        <td class="slidedown"><i>+</i></td>
                    </tr>
                </table>
            </a>
            <div class="Topic_con" style="display: none;">
                <table class="W_form" >
                    <thead>
                        <tr class="trth">
                            <th class="number"></th>
                            <%--<th class="number">序号</th>--%>
                            <th class="Exp_name">实验名称</th>
                            <th class="erlie">周次</th>
                            <th class="erlie">星期</th>
                            <th>操作</th>
                            <th class="slidedown">&nbsp;&nbsp;</th>
                        </tr>
                    </thead>
                    <tbody name="SecondList">

                    </tbody>
                </table>
            </div>
        </li>
    </script>
    <!--课程模板-->
    <!--实验模板-->
    <script>
        function addIds(id)
        {
            return "trST" + id;
        }
    </script>
    <script id="trSecondTemp" type="text/x-jquery-tmpl">
        <tr class="Single" name="trName" id="${addIds(pageIndex())}">
            <td class="checkbox">
                </td>
            <%--<td>${pageIndex()}</td>--%>
            <td><a href="javascript:ExperimentDetailsInfo(this, '${Id}');"><span title="${Name}">${NameLengthUpdate(Name,15)}</span></a></td>
            <td>${Week}</td>
            <td>${Weekday}</td>
            <td >
                <input type="hidden" name="IsDelete" value="${IsDelete}" />
                <input type="hidden" name="Status" value="${Status}" />
                <span class=" ">
                    <input class="Topic_btn" type="button" value="详情" onclick="ExperimentDetailsInfo(this, '${Id}')" />
                </span>
                <span class=" ">
                    <input name="btnHide" class="Topic_btnDisable" disabled="disabled" title="不在信息录入时间内" type="button" value="编辑" onclick="Edit(this, '${Id}', '${LearnYear}')" />
                </span>
                <span class=" ">
                    <input name="btnHide" class="Topic_btnDisable" disabled="disabled" title="不在信息录入时间内" type="button" value="删除" onclick="DeleteExperiment(this, '${Id}')" />
                </span>
            </td>
            <td class="slidedown">&nbsp;&nbsp;</td>
        </tr>
    </script>
    <!--实验模板-->
</head>

<body>
    <form id="form1" runat="server">
        <div class="Teaching_plan_management">
            <a href="../Order/Calendar.aspx" class="all_select fr">
                <span class="visited_xz">列表视图</span>
                <span class="moren_wxz">日历视图</span>
            </a>
            <h1 class="Page_name">教学计划管理 </h1>
            <br />
            <div class="Operation_area">
                <div class="left_choice fl">
                    <ul>
                        <li class="Select">学年学期：
                            <select class="option" id="LearnYear">
                                <option value=''>全部</option>
                            </select>
                        </li>

                        <li class="Sear">
                            <input id="Name" type="text" name="search_w" class="search_w" placeholder="请输入课程名称" value="" />
                        </li>
                        <li class="Sear">
                            <input id="EName" type="text" name="search_w" class="search_w" placeholder="请输入实验名称" value="" />
                        </li>
                        <li>
                            <a class="btn1" href="#" onclick="SearchData()">搜索</a>
                        </li>
                    </ul>
                </div>
                <div class="right_add fr">
                    <a class="addDisable" disabled="disabled" title="不在信息录入时间内" id="AddPlan" href="javascript:OpenIFrameWindow('新增课程','PlanEdit.aspx?type=Add&PlanId=${Id}','650px','470px');"><i class="iconfont">&#xe726;</i>新增课程</a>
                </div>
            </div>
            <div class="Topic_tcon">
                <div id="slide">
                    <!--菜单区域-->
                    <table class="W_form1">
                        <tr class="trth1">
                            <th class="number">序号</th>
                            <th class="Project_name">课程名称</th>
                            <th class="Term">学期</th>
                            <th class="erlie">主讲教师</th>
                            <th class="erlie">创建人</th>
                            <th class="erlie">创建时间</th>
                            <th>操作</th>
                            <th class="slidedown">&nbsp;&nbsp;</th>
                        </tr>
                    </table>
                    <ul class="Two_list" id="ulList">
                    </ul>
                    <!--end 菜单区域-->
                </div>
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
        <asp:HiddenField ID="hidPlanIDs" runat="server" />
    </form>
</body>
<script type="text/javascript">
    var LearnYearJSON;
    var NowLearnYear = "";

    //初始化序号 
    var LearnYear = "";
    var Name = "";
    var hidUserIDCard = "";
    var PageSize = 10;
    var tabObj = "";
    $(document).ready(function () {
        //加载学年学期
        BindLearnYear();
    });
    function SearchData() {
        //初始化序号 
        LearnYear = $('#LearnYear option:selected').val();
        Name = $('#Name').val().trim();
        EName = $('#EName').val().trim();
        hidUserIDCard = $('#hidUserIDCard').val();
        GetList(1);
    }
    function IsShow() {
        //如果是管理员则启用所有按钮
        if ($("#hidIsAdmin").val() == "true") {
            $("[name='btnHide']").removeAttr("disabled");
            $("[name='btnHide']").removeAttr("title");
            $("[name='btnHide']").removeClass().addClass("Topic_btn");
            $("#AddPlan").removeAttr("disabled");
            $("#AddPlan").removeAttr("title");
            $("#AddPlan").removeClass().addClass("add");
            return;
        }
        $.each($("#ulList").children(), function (i, li) {
            var LearnYearId = $(li).find("[name='LearnYear']").val();
            if (NowLearnYear == LearnYearId) {
                $(li).find("[name='btnHide']").removeAttr("disabled");
                $(li).find("[name='btnHide']").removeAttr("title");
                $(li).find("[name='btnHide']").removeClass().addClass("Topic_btn");
            }
        });


    }
    //加载学年学期
    function BindLearnYear() {
        $LearnYear = $("#LearnYear");
        $LearnYear.empty();
        $LearnYear.append("<option value=''>全部</option>");
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
                        var StartDate = new Date(parseInt(n.StartDate.replace(/\D/igm, "")));
                        var EndDate = new Date(parseInt(n.EndDate.replace(/\D/igm, "")));
                        var NowDate = new Date();
                        if (StartDate <= NowDate && NowDate < EndDate) {
                            $("#LearnYear").val(n.Id);
                            //var Deadline = new Date(StartDate.getTime() + (n.DataCollectionTime * 7 * 24 * 60 * 60 * 1000));
                            //if (NowDate < Deadline) {  //需要改
                                NowLearnYear = n.Id;
                                $("#AddPlan").removeAttr("disabled");
                                $("#AddPlan").removeClass().addClass("add");
                                $("#AddPlan").removeAttr("title");
                            //}
                        }
                    });
                    //加载数据
                    SearchData();
                }
                else { }
            },
            error: OnError
        });
    }
    //获取课程数据
    function GetList(PageIndex) {
        pageNum = (PageIndex - 1) * 10 + 1;
        $.ajax({
            type: "Post",
            url: WebServiceUrl + "/Plan/Plan.ashx",//random" + Math.random(),//方法所在页面和方法名
            //async: false,
            dataType: "jsonp",
            jsonp: "jsoncallback",
            //data: { "PageIndex": PageIndex, "PageSize": PageSize, "Name": Name, "LearnYear": LearnYear, "Filing": Filing, "StartDate": StartDate, "EndDate": EndDate, "UserLgoinName": UserLgoinName },
            data: { "PageIndex": PageIndex, "PageSize": PageSize, "Name": Name, "EName": EName, "LearnYear": LearnYear, "Creator": hidUserIDCard, "UserRoleID": hidUserIDCard, "IsDelete": "全部", "action": "GetPage", PIds: $("#hidPlanIDs").val() },
            success: function LoadData(json) {
                $("#hidPlanIDs").val("");
                //加载课程
                if (json.result.Status == "error") {
                    //$("#ulList").html("<tr><td style=\"text-align:center;width:100%;\" >" + json.result.Msg + "</td></tr>");
                    return;
                }
                if (json.result.Status == "no") {
                    $("#ulList").html('');
                    //生成页码条方法（方法对象,页码条容器，当前页码，总页数，页码组容量，总行数）
                    makePageBar(GetList, document.getElementById("pageBar"), 1, 1, 8, 0);
                    return;
                }
                if (json.result.Status == "ok") {
                    $("#ulList").html('');
                    var dtJson = json.result.Data.PagedData;
                    $("#trTemp").tmpl(dtJson).appendTo("#ulList");
                    //加载展开方法
                    zhankai();
                    var shiyanList = new Array();
                    $.each(dtJson, (function (i, item) {
                        shiyanList.push(item.Id);
                    }));
                    //生成页码条方法（方法对象,页码条容器，当前页码，总页数，页码组容量，总行数）
                    makePageBar(GetList, document.getElementById("pageBar"), json.result.Data.PageIndex, json.result.Data.PageCount, 8, json.result.Data.RowCount);
                    IsShow();
                    //加载数据2
                    GetList2(1, shiyanList.toString()); 
                }
                IsShow();
            },
            error: OnError
        });

    }
    //修改课程
    function UpdatePlan(obj, Id,e) {
        var tr = $(obj).parents("[name='trName1']:first");
        //var IsDelete = tr.find("[name='IsDelete']").val();
        //if (IsDelete == "2") {
        //    //layer.msg(json.result.Msg);
        //    return;
       
        $.ajax({
            type: "Post",
            url: WebServiceUrl + "/Plan/Plan.ashx",
            //async: false,
            dataType: "jsonp",
            jsonp: "jsoncallback",
            data: { "Id": Id, "action": "IsFiling" },
            success: function (json) {
                if (json.result.Status == "error") {
                    //layer.msg(json.result.Msg);
                    return;
                }
                else if (json.result.Status == "no") {
                    OpenIFrameWindow('修改课程', 'PlanEdit.aspx?type=Edit&Id=' + Id, '650px', '470px');
                    return;
                }
                else if (json.result.Status == "ok") {
                    //layer.msg(json.result.Msg + "，不能修改！");
                    return;
                }
            },
            error: OnError
        });
        //}
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
    //加载展开二级列表的方法
    function zhankai() {
        //$("#slide").find("ul.Two_list li a table tr td.slidedown").click(function () {
        //    var thisparent = $(this).parent().parent().parent().parent();
        //    thisparent.parent().toggleClass("selected").siblings().removeClass("selected");
        //    thisparent.next().slideToggle("fast").end().parent().siblings().find(".Topic_con")
        //    .addClass("animated bounceIn")
        //    .slideUp("fast").end().find("i").text("+");
        //    var t = $(this).find("i").text();
        //    $(this).find("i").text((t == "+" ? "-" : "+"));
        //});
        $("#slide").find("ul.Two_list li a .W_form1").click(function () {
            var thisparent = $(this).parent();
            //
            thisparent.next().is(':hidden') ? tabObj = "" : tabObj = thisparent.parent().attr('name');
            thisparent.parent().toggleClass("selected").siblings().removeClass("selected");
            thisparent.next().stop(true,true).slideToggle("fast").end().parent().siblings().find(".Topic_con")
            .addClass("animated bounceIn").stop(true,true)
            .slideUp("fast").end().find("i").text("+");
            var t = $(this).find("i").text();
            $(this).find("i").text((t == "+" ? "-" : "+"));
        });
    }
    //错误处理
    function OnError(XMLHttpRequest, textStatus, errorThrown) {
        //layer.msg(XMLHttpRequest + "-" + textStatus + "-" + errorThrown);
    }
    //删除课程
    function Delete(obj, Id, e) {
        // 取消事件冒泡
        var e = arguments.callee.caller.arguments[0] || event; // 若省略此句，下面的e改为event，IE运行可以，但是其他浏览器就不兼容
        if (e && e.stopPropagation) {
            // this code is for Mozilla and Opera
            e.stopPropagation();
        } else if (window.event) {
            // this code is for IE
            window.event.cancelBubble = true;
        }
        //js验证
        var ExpList = $(obj).parents("li:first").find("[name='SecondList']");
        if (ExpList.children().length > 0) {
            var isNullData=ExpList.children().eq(0).find("td:nth-child(1)");
            if (isNullData != null && isNullData.text()!="没有实验") {
                layer.msg("课程下有实验，不能删除");
                return;
            }
        }
        var tr = $(obj).parents("[name='trName1']:first");
        //var IsDelete = tr.find("[name='IsDelete']").val();
        //if (IsDelete == "2") {
        //    layer.msg("已归档，不能删除");
        //    return;
        //}
        //确认删除
        layer.msg('确认删除？', {
            time: 0,//不自动关闭
            shade: 0.3,
            btn: ['确认', '取消'],
            yes: function (index) {
                layer.close(index);
                hidUserIDCard = $('#hidUserIDCard').val();
                $.ajax({
                    url: WebServiceUrl + "/Plan/Plan.ashx",//random" + Math.random(),//方法所在页面和方法名
                    async: false,
                    dataType: "jsonp",
                    jsonp: "jsoncallback",
                    data: { "Id": Id, "Editor": hidUserIDCard, "action": "DeletePlan" },
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
                            GetList(1);
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
    //删除实验
    function DeleteExperiment(obj, Id) {

        //js验证
        var tr = $(obj).parents("[name='trName']:first");
        //var Status = tr.find("[name='Status']").val();
        //if (Status == "1") {
        //    layer.msg("已生成订单，不能删除");
        //    return;
        //}
        //var IsDelete = tr.find("[name='IsDelete']").val();
        //if (IsDelete == "2") {
        //    layer.msg("已归档，不能删除");
        //    return;
        //}
        //确认删除
        layer.msg('确认删除？', {
            time: 0,//不自动关闭
            shade: 0.3,
            btn: ['确认', '取消'],
            yes: function (index) {
                layer.close(index);
                //执行删除
                hidUserIDCard = $('#hidUserIDCard').val();
                $.ajax({
                    url: WebServiceUrl + "/Experiment/Experiment.ashx",//random" + Math.random(),//方法所在页面和方法名
                    async: false,
                    dataType: "jsonp",
                    jsonp: "jsoncallback",
                    data: { "Id": Id, "Editor": hidUserIDCard, "action": "DeleteExperiment" },
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
                            $(obj).parents("tr[name='trName']:first").remove();
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
    //获得实验列表
    function GetList2(PageIndex, PlanId) {
        //初始化序号 
        pageNum = (PageIndex - 1) * 10 + 1
        var PageIndex1 = 1;
        var PageSize1 = 1000;
        $.ajax({
            type: "Post",
            url: WebServiceUrl + "/Experiment/Experiment.ashx",//random" + Math.random(),//方法所在页面和方法名
            //async: false,
            dataType: "jsonp",
            jsonp: "jsoncallback",
            data: { "PageIndex": PageIndex1, "PageSize": PageSize1, "PlanId": PlanId, "IsDelete": "全部", "Name": EName, "action": "GetPage" },
            success: LoadSecond,
            error: OnError
        });
        
    }
    function LoadSecond(json) {
        //加载二级列表
        if (json.result.Status == "error") {
            //alert(json.result.Msg);
            return;
        }
        //if (json.result.Status == "no") {
        //    return;
        //}
        if (json.result.Status == "ok" || json.result.Status == "no") {
            $("#ulList").children().each(function () {
                var name = $(this).attr("name");
                var wwli = $(this).find("[name='SecondList']");
                if (json.result.Status != "no") {
                    $.each(json.result.Data.PagedData, function (i, data) {
                        if (data.PlanId == name) {
                            $("#trSecondTemp").tmpl(data).appendTo(wwli);
                        }
                    });
                }
                if (wwli.children().length == 0) {
                    wwli.append("<tr><td colspan='100' text-align='center'>没有实验</td></tr>");
                }
            });
            if (json.result.Status == "ok" && tabObj != "") {
                showExap(tabObj);
            }

        }
        IsShow();
    }
    //实验编辑
    function Edit(obj, Id, LearnYearId) {
        var tr = $(obj).parents("[name='trName']:first");
        //var Status = tr.find("[name='Status']").val();
        //if (Status == "1") {
        //    layer.msg("已生成订单，不能修改");
        //    return;
        //}
        //var IsDelete = tr.find("[name='IsDelete']").val();
        //if (IsDelete == "2") {
        //    layer.msg("已归档，不能修改");
        //    return;
        //}
        var PlanName = $(obj).parents("li:first").find("[name='PlanName']").val();
        //location.href = '../Experiment/ExperimentEdit.aspx?type=Edit&Id=' + Id;
        $LearnYear = $('#LearnYear');
        $.ajax({
            url: "/CommonHandler/UnifiedHelpHandler.ashx",
            type: "post",
            async: false,
            dataType: "json",
            data: { "Func": "GetStudySectionData", ID: LearnYearId },
            success: function (json) {
                if (json.result.errNum.toString() == "0") {
                    var learnYear = json.result.retData[0];
                    var starDate = DateTimeConvert(learnYear.StartDate);
                    var endDate = DateTimeConvert(learnYear.EndDate);
                    OpenIFrameWindow('课程：' + PlanName + '-编辑实验', '../Experiment/ExperimentEdit.aspx?type=Edit&Id=' + Id + "&starDate=" + starDate + "&endDate=" + endDate, '700px', '600px');
                }
            },
            error: OnError
        });        
        return;
    }
    //实验添加设备
    function SelectEquip(obj, Id, Name) {
        var tr = $(obj).parents("[name='trName']:first");
        //var Status = tr.find("[name='Status']").val();
        //if (Status == "1") {
        //    layer.msg("已生成订单，不能添加设备");
        //    return;
        //}
        //var IsDelete = tr.find("[name='IsDelete']").val();
        //if (IsDelete == "2") {
        //    layer.msg("已归档，不能添加设备");
        //    return;
        //}
        location.href = '../ExperimentEquip/SelectEquip.aspx?ExperimentId=' + Id + "&ExpName=" + Name;
        return;
    }
    //实验详情
    function ExperimentDetailsInfo(obj, Id) {
        var PlanName = $(obj).parents(".Topic_con").siblings(".Topic_click").find("[name='PlanName']").val();
        location.href = "../Experiment/ExperimentDetails.aspx?Id=" + Id + "&Name=" + PlanName;
        //OpenIFrameWindow('实验详情', "../Experiment/ExperimentDetails.aspx?Id=" + Id + "&Name=" + Name, '', '');
    }
    //课程详情
    function PlanDetails(obj,Id,e) {
        OpenIFrameWindow('课程详情', 'PlanDetails.aspx?Id=' + Id, '650px', '400px');
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
    function add_exper(objId,Name, Id, StartDate, EndDate, e) {
        tabObj = objId;
        OpenIFrameWindow('课程：' + Name + '-新增实验', '../Experiment/ExperimentEdit.aspx?type=Add&PlanId=' + Id + '&starDate=' + StartDate + '}&endDate=' + EndDate + '', '700px', '80%');

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
    function showExap(obj)
    {
        var thisparent = $("#"+obj);
			thisparent.children('div').stop().slideDown();
			thisparent.find('.slidedown').children('i').text('-');
    }
</script>
</html>
