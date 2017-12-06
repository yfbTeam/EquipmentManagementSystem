<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EquipDataImport.aspx.cs" Inherits="EMS.Web.SystemSettings.EquipDataImport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>仪器设备数据导入</title>
    <link href="/css/style.css" rel="stylesheet" />
    <link href="/css/common.css" rel="stylesheet" />
    <link href="/css/iconfont.css" rel="stylesheet" />
    <link href="/css/animate.css" rel="stylesheet" />
    <script src="/js/jquery-1.11.2.min.js"></script>
    <script src="/js/layer/layer.js"></script>
    <script src="/js/Common.js"></script>
    <script src="/js/jquery.tmpl.js"></script>
    <script src="/js/PageBar.js"></script>
    <script id="trTemp" type="text/x-jquery-tmpl">
        <tr>
            <td>
                <input type="checkbox" name="cb_sub" /></td>
            <td>${pageIndex()}</td>
            <td>${AssetNumber}</td>
            <td>${AssetName}</td>
            <td>${AssetsClassName}</td>  
            <td>${EquipStatusChange(EquipStatus)}</td>
            <td>${Unit}</td>                 
            <td>${BrandStandardModel}</td>        
            <td>${Factory}</td>                 
            <td>${DateTimeConvert(CreateTime)}</td>
            <td>
                <input type="button" class="Topic_btn" value="详情" onclick="javascript: OpenIFrameWindow('设备详情', '/Statistical/EquipDetailInfo.aspx?Id=${Id}', '650px', '650px');" />
                <input type="button" class="Topic_btn" value="打印二维码" onclick="javascript: PrintQRCode('${Id}')" />
            </td>
        </tr>

    </script>
</head>
<body>
    <!--tz_dialog start-->
    <div class="yy_dialog">
        <div class="t_content">
            <div class="yy_tab">
                <div class="content">
                    <div class="tc">
                        <h1 class="Page_name">仪器设备数据导入</h1>
                        <div class="Operation_area">
                            <div class="left_choice fl">
                                <ul>
                                    <li class="Sear">
                                        <%--<input type="text" id="search_w" name="search_w" class="search_w" placeholder="请输入用户名" value="" /><a class="sea" href="#" onclick="SearchUser();">搜索</a>--%>
                                    </li>
                                </ul>
                            </div>
                            <div class="right_add fr">
                                <input type="file" id="fil_Doc" name="fil_Doc" runat="server" style="display: none;" />
                                <a class="add" href="#" onclick="$('#<%=fil_Doc.ClientID%>').click();"><i class="iconfont">&#xe726;</i>导入数据</a>
                                <a class="add" href="#"><i class="iconfont">&#xe607;</i>批量删除</a>
                            </div>
                        </div>
                        <div class="Honor_management">
                            <table class="W_form">
                                <thead>
                                    <tr class="trth">
                                        <th class="cbox">
                                            <input type="checkbox" id="cb_all" name="cb_all" onclick="CheckAll(this);" /></th>
                                        <th class="number">序号</th>
                                        <th>资产号</th>                                        
                                        <th>资产名称</th>                                  
                                        <th>资产分类名称</th>                         
                                        <th>设备状态</th> 
                                        <th>计量单位</th>                           
                                        <th>品牌及规格型号</th>                                    
                                        <th>厂家</th>                                                
                                        <th>创建时间</th>
                                        <th>操作</th>
                                    </tr>
                                </thead>
                                <tbody id="TbodyList">
                                </tbody>
                            </table>
                        </div>
                        <!--分页页码开始-->
                        <div class="paging">
                            <span id="pageBar"></span>
                        </div>
                        <!--分页页码结束-->
                        <div class="submit_btn">
                            <span class="Save_and_submit">
                                <input type="submit" value="确定" class="Save_and_submit" onclick="SaveDataImport();" /></span>
                            <span class="cancel">
                                <input type="submit" value="返回" class="cancel" onclick="javascript: history.back(-1);" />
                            </span>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!--end tz_dialog-->
</body>
<script type="text/javascript">
    $(document).ready(function () {
        //获取数据
        getData(1);
    });
    //全选或全不选
    function CheckAll(obj) {
        var flag = obj.checked;//判断全选按钮的状态 
        $("input[type=checkbox][name=cb_sub]").each(function () {//查找每一个name为cb_sub的checkbox 
            this.checked = flag;//选中或者取消选中 
        });
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
            data: { "PageIndex": PageIndex, "PageSize": PageSize, "action": "GetPageEquipDetail" },
            success: function (json) {
                if (json.result.Status == "error") {
                    return;
                }
                if (json.result.Status == "no") {
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
            error: function OnError(XMLHttpRequest, textStatus, errorThrown) {
                //layer.msg(XMLHttpRequest + "-" + textStatus + "-" + errorThrown);
            }
        });
    }

    function SaveDataImport() {

    }
    function DeleteUser(id) {
        layer.msg("确定要删除该用户?", {
            time: 0 //不自动关闭
            , btn: ['确定', '取消']
            , yes: function (index) {
                layer.close(index);
                $.ajax({
                    url: WebServiceUrl + "/SystemSettings/UserInfo.ashx",//random" + Math.random(),//方法所在页面和方法名
                    type: "post",
                    async: false,
                    dataType: "jsonp",
                    jsonp: "jsoncallback",
                    data: { "intID": id, "action": "DeleteUserInfo" },
                    success: function (json) {
                        if (json.result != "0") {
                            layer.msg("删除成功！");
                            getData(1);
                        } else {
                            layer.msg("删除失败！");
                        }
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        layer.msg("删除失败！");
                    }
                });
            }
        });
    }

    function PrintQRCode(id) {

    }
</script>
</html>
