<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HonorList.aspx.cs" Inherits="EMS.Web.Honor.HonorList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>绩效列表</title>
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

    <script id="trTemp" type="text/x-jquery-tmpl">

                    <tr class="Single">
                        <td class="number">${pageIndex()}</td>
                        <td class="Project_name">
                            <a href="javascript:OpenIFrameWindow('绩效详情', 'HonorDetails.aspx?Id=${Id}', '400px', '350px');">
                                <span title="${Name}">${NameLengthUpdate(Name,15)}</span>
                            </a>
                        </td>
                        <td class="Term">${LevelName}</td>
                        <td class="erlie">${CreateName}</td>
                        <td>
                            <span class=" ">
                                <input class="Topic_btn" type="button" value="详情" onclick="OpenIFrameWindow('绩效详情', 'HonorDetails.aspx?Id=${Id}', '500px', '350px')" />
                            </span>
                            <span class=" ">
                                <input class="Topic_btn" type="button" value="编辑" onclick="OpenIFrameWindow('编辑绩效', 'HonorEdit.aspx?type=Edit&Id=${Id}', '650px', '350px')" />
                            </span>
                            <span class=" ">
                                <input class="Topic_btn" type="button" value="删除" onclick="Delete(this,'${Id}')" />
                            </span>
                        </td>
                    </tr>

    </script>

</head>

<body>
    <form id="form1" runat="server">
        <div class="Teaching_plan_management">
            <h1 class="Page_name">绩效管理</h1>
            <div class="Operation_area">
                <div class="left_choice fl">
                    <ul>
                        <li class="Select">
                            级别：
                            <select class="option" id="Level">
                                <option value='全部'>全部</option>
                            </select>
                        </li>
                        <li class="Sear">
                            <input id="Name" type="text" name="search_w" class="search_w" placeholder="请输入奖项名称" value="" />
                        </li>
                        <li class="Sear" style="display:none;">
                            <input id="ExperimentName" type="text" name="search_w" class="search_w" placeholder="请输入实验名称" value="" />
                        </li>
                        <li>
                            <a class="btn1" href="#" onclick="SearchData();">搜索</a>
                        </li>
                    </ul>
                </div>
                <div class="right_add fr">
                    
                    <a class="add" href="javascript:OpenIFrameWindow('新增荣誉','HonorEdit.aspx?type=Add&PlanId=${Id}','650px','350px');"><i class="iconfont">&#xe726;</i>新增绩效</a>
                </div>
            </div>
            <div class="Honor_management">
                    <table class="W_form">
                        <thead>
                            <tr class="trth">
                            <th class="number">序号</th>
                            <th class="Project_name">绩效名称</th>
                            <th class="Term">级别</th>
                            <th class="erlie">创建人</th>
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
        <asp:HiddenField ID="hidUserIDCard" runat="server" />
        <%--<asp:HiddenField ID="hidPlanId" runat="server" />--%>
        <asp:HiddenField ID="hidUserRoleID" runat="server" />
    </form>
</body>
<script type="text/javascript">
    var Level = "";
    var Name = "";
    var ExperimentName = "";
    var UserIDCard = "";
    var UserRoleName = "";
    var PageSize = 10;
    $(document).ready(function () {
        //加载级别
        BindLevel();
        //加载数据
        SearchData();
    });
    function SearchData() {
        //初始化序号 
        Level = $('#Level option:selected').val();
        Name = $('#Name').val().trim();
        ExperimentName = $('#ExperimentName').val().trim();
        UserIDCard = $('#hidUserIDCard').val();
        GetList(1);
    }
    //加载级别
    function BindLevel() {
        $.ajax({
            type: "Post",
            url: WebServiceUrl + "/SystemSettings/SystemSettings.ashx",//random" + Math.random(),//方法所在页面和方法名
            async: false,
            dataType: "jsonp",
            jsonp: "jsoncallback",
            data: { "action": "GetLevelList" },
            //data: { "Name": Name, "LearnYear": LearnYear, "Contents": Contents, "Creator": Creator },
            success: function (json) {
                $("#Level").empty();
                $("#Level").append("<option value='全部'>全部</option>");
                if (json.result.Status == "error") {
                    //layer.msg(json.result.Msg);
                    return;
                }
                if (json.result.Status == "no") {
                    //layer.msg(json.result.Msg);
                    return;
                }
                if (json.result.Status == "ok") {
                    $.each(json.result.Data, function (i, item) {
                        var option = "<option value='" + item.Id + "'>" + item.Name + "</option>"
                        $("#Level").append(option);
                    });
                }
            },
            error: OnError
        });
    }
    //获取数据
    function GetList(PageIndex) {
        //初始化序号 
        pageNum = (PageIndex - 1) * 10 + 1
        //Level = $('#Level option:selected').val();
        //Name = $('#Name').val().trim();
        //ExperimentName = $('#ExperimentName').val().trim();
        //UserIDCard = $('#hidUserIDCard').val();
        //PageSize = 10;
        $.ajax({
            type: "Post",
            url: WebServiceUrl + "/Honor/Honor.ashx",//random" + Math.random(),//方法所在页面和方法名
            //async: false,
            dataType: "jsonp",
            jsonp: "jsoncallback",
            //data: { "PageIndex": PageIndex, "PageSize": PageSize, "Name": Name, "LearnYear": LearnYear, "Filing": Filing, "StartDate": StartDate, "EndDate": EndDate, "UserLgoinName": UserLgoinName },
            data: { "PageIndex": PageIndex, "PageSize": PageSize, "Name": Name, "HonorLevel": Level, "ExperimentName": ExperimentName, "Filing": "全部", "Creator": UserIDCard, "UserRoleID": UserIDCard, "action": "GetPage" },
            success: LoadData,
            error: OnError
        });

    }

    //加载
    function LoadData(json) {
        if (json.result.Status == "error") {
            //$("#TbodyList").html("<tr><td style=\"text-align:center;width:100%;\" >" + json.result.Msg + "</td></tr>");
            return;
        } 
        if (json.result.Status == "no") {
            //$("#TbodyList").html("<tr><td style=\"text-align:center;width:100%;\">" + json.result.Msg + "</td></tr>");
            $("#TbodyList").html('');
            //生成页码条方法（方法对象,页码条容器，当前页码，总页数，页码组容量，总行数）
            makePageBar(GetList, document.getElementById("pageBar"), 1, 1, 8, 0);
            return;
        }
        if (json.result.Status == "ok") {
            $("#TbodyList").html('');
            $("#trTemp").tmpl(json.result.Data.PagedData).appendTo("#TbodyList");
            //生成页码条方法（方法对象,页码条容器，当前页码，总页数，页码组容量，总行数）
            makePageBar(GetList, document.getElementById("pageBar"), json.result.Data.PageIndex, json.result.Data.PageCount, 8, json.result.Data.RowCount);

        }
    }

    function OnError(XMLHttpRequest, textStatus, errorThrown) {
        //layer.msg('');
    }
    //删除荣誉
    function Delete(obj,Id) {
        UserIDCard = $('#hidUserIDCard').val();
        //确认删除
        layer.msg('确认删除？', {
            time: 0,//不自动关闭
            shade: 0.3,
            btn: ['确认', '取消'],
            yes: function (index) {
                layer.close(index);
                UserLgoinName = $('#hidUserLgoinName').val();
                $.ajax({
                    url: WebServiceUrl + "/Honor/Honor.ashx",//random" + Math.random(),//方法所在页面和方法名
                    async: false,
                    dataType: "jsonp",
                    jsonp: "jsoncallback",
                    data: { "Id": Id, "Editor": UserIDCard,"action":"DeleteHonor"},
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
                            $(obj).parents("tr:first").remove();
                        }
                    },
                    error: OnError
                });
            }
        });
        

    }
</script>
</html>
