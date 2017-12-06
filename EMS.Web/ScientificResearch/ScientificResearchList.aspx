<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ScientificResearchList.aspx.cs" Inherits="EMS.Web.ScientificResearch.ScientificResearchList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>科研设备列表</title>
    <link href="../css/common.css" rel="stylesheet" />
    <link href="../css/style.css" rel="stylesheet" />
    <link href="../css/iconfont.css" rel="stylesheet" />
    <link href="../css/animate.css" rel="stylesheet" />

    <script src="../js/Common.js"></script>
    <script src="../js/jquery-1.11.2.min.js"></script>
    <script src="/js/layer/layer.js"></script>
    <script src="../js/jquery.tmpl.js"></script>
    <script src="../js/PageBar.js"></script>
    <script src="../js/tz_slider.js"></script>
    <script src="../js/layer/layer.js"></script>

    <script id="trTemp" type="text/x-jquery-tmpl">
        <tr class="Single">
            <td>${pageIndex()}</td>
            <td><a href="javascript: location.href = 'EquipClassInfo.aspx?Id=${AssetsClassName}';"><span title="${AssetsClassName}">${NameLengthUpdate(AssetsClassName,15)}</span></a></td>
            <td>${IsConsumeToStr(IsConsume)}</td>
            <td>${Total}</td>
            <td>${Unit}</td>
            <td>
                <span class=" ">
                    <input type="button" class="Topic_btn" value="查看" onclick="javascript: location.href = '../Statistical/EquipClassInfo.aspx?Id=${AssetsClassName}&Type=${Type}';" />
                </span>
               
            </td>
        </tr>
    </script>

</head>

<body>
    <form id="form1" runat="server">
        <div class="Teaching_plan_management">
            <h1 class="Page_name">科研设备<span id="EquipCount"></span></h1>
            <div class="Operation_area">
                <div class="left_choice fl">
                    <ul>
                        <li class="Select">房间：
							<select class="option" id="Building">
                                <option value=''>全部</option>
                            </select>
                        </li>
                        <li class="Select" id="LiSectionPlace" style="display:none;">科研所：
							<select class="option" id="SectionPlace">
                                <option value=''>全部</option>
                            </select>
                        </li>
                        <li class="Select">是否分配：
							<select class="option" id="distribution">
                                <option value=''>全部</option>
                                <option value='0'>未分配</option>
                                <option value='1'>已分配</option>
                            </select>
                        </li>
                        <li class="Sear">
                            <input id="Name" type="text" name="search_w" class="search_w" placeholder="请输入分类名称" value=""/>
                        </li>
                        <li>
                            <a class="btn1" href="#" onclick="SearchData()">搜索</a>
                        </li>
                    </ul>
                </div>
                <div class="right_add fr">
                    <a id="EquipFP" style="display:none;" class="add" href="javascript:void(0);" onclick="javascript:location.href = '/OfficeFurniture/AssetsDistribution.aspx?type=1';"><i class="iconfont">&#xe726;</i>科研设备分配</a>
                </div>
            </div>
            <div class="Honor_management">
                <table class="W_form">
                    <thead>
                        <tr class="trth">
                            <th>序号</th>
                            <th>资产分类名称</th>
                            <th>是否耗材</th>
                            <th>总数</th>
                            <th>单位</th>
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
    var Name = "";
    var Type = "1";
    var PageSize = 10;
    var distribution = "";//是否分配
    var UserIDCard = $('#hidUserIDCard').val();
    var SectionPlace = "";//科研所
    var Building = "";//房间
    $(document).ready(function () {
        if ($('#hidIsAdmin').val() == 'true') {
            //如果是管理员，显示科研所搜索条件
            $('#LiSectionPlace').show();
            //如果是管理员，显示分配按钮
            $('#EquipFP').show();
            BindSectionPlace();
        }
        BindBuilding();
        SearchData();
    });
    function SearchData() {
        
        //初始化序号 
        Name = $('#Name').val().trim();
        distribution = $('#distribution').val();
        SectionPlace = $('#SectionPlace').val();
        Building = $('#Building').val();
        GetList(1);
    }
    //加载科研所
    function BindSectionPlace() {
        $.ajax({
            type: "Post",
            url: WebServiceUrl + "/SystemSettings/SectionPlace.ashx",
            //async: false,
            dataType: "jsonp",
            jsonp: "jsoncallback",
            //data: { "Name": Name, "IsDelete": IsDelete, "Contents": Contents, "Creator": Creator },
            data:{action:"GetDDInfo"},
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
                    $("#SectionPlace").empty();
                    $("#SectionPlace").append("<option value=''>全部</option>");
                    $.each(json.result.Data, function (i, item) {
                        var option = "<option value='" + item.Id + "'>" + item.Name + "</option>";
                        $("#SectionPlace").append(option);
                    });
                }
            },
            error: OnError
        });
    }
    //加载房间
    function BindBuilding() {
        $.ajax({
            type: "Post",
            url: WebServiceUrl + "/SystemSettings/Building.ashx",
            //async: false,
            dataType: "jsonp",
            jsonp: "jsoncallback",
            data: { "type": "1", "action": "GetRoomInfoByType" },
            success: function (json) {
                $("#Building").empty();
                $("#Building").append("<option value=''>全部</option>");
                $("#Building").append(json.result);
            },
            error: OnError
        });
    }
    //获取数据
    function GetList(PageIndex) {
        //初始化序号 
        pageNum = (PageIndex - 1) * 10 + 1
        $.ajax({
            type: "Post",
            url: WebServiceUrl + "/Statistical/Statistical.ashx",
            //async: false,
            dataType: "jsonp",
            jsonp: "jsoncallback",
            data: {
                "PageIndex": PageIndex, "PageSize": PageSize, "Name": Name, "distribution": distribution, "UserIDCard": UserIDCard
                , "UserRoleID": UserIDCard, "SectionPlace": SectionPlace, "Building": Building, "action": "GetPageStock2"
            },
            success: function (json) {
                if (json.result.Status == "error") {

                    return;
                }
                if (json.result.Status == "no") {
                    //$("#ulList").html("<tr><td style=\"text-align:center;width:100%;\">" + json.result.Msg + "</td></tr>");
                    //alert(json.result.Msg);
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
                    $("#EquipCount").html("总数量：" + json.result2.Data);
                }

            },
            error: OnError
        });

    }
    //各行变色
    function RowColor() {

    }
    //错误处理
    function OnError(XMLHttpRequest, textStatus, errorThrown) {
        //layer.msg('');
    }
    //导入设备Excel
    function ImportEquip() {
        OpenIFrameWindow('导入教师', '../Statistical/ImportEquip.aspx', '500px', '200px');
        //return;
    }
</script>
</html>
