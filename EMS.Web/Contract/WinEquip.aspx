<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WinEquip.aspx.cs" Inherits="EMS.Web.Contract.WinEquip" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="../css/style.css" rel="stylesheet" />
    <link href="../css/common.css" rel="stylesheet" />
    <link href="../css/iconfont.css" rel="stylesheet" />
    <link href="../css/animate.css" rel="stylesheet" />
    <script src="../js/jquery-1.11.2.min.js"></script>
    <script src="../js/layer/layer.js"></script>
    <script src="../js/PageBar.js"></script>
    <script src="../js/Common.js"></script>
    <script src="../js/jquery.tmpl.js"></script>
    <script id="trTemp" type="text/x-jquery-tmpl">
        <tr>
            <td>
                {{if isloadDataItem(Id)}}
                <input type="checkbox" name="checkEquip" value="${Id}" valueName="${AssetName}" />
                 {{else}}
            {{if isloadDataItem(Id)==false }}
                   <input type="checkbox" name="checkEquipEnable" value="${Id}" />
                {{/if}}
                 {{/if}}
            </td>
            <td>${pageIndex()}</td>
            <td>${AssetNumber}</td>
            <td><span title="${AssetName}">${NameLengthUpdate(AssetName,15)}</span></td>
            <td>${EquipTypeToStr(Type)}</td>
            <td>${EquipStatusChange(EquipStatus)}</td>
            <td>${Unit}</td>
            <td>${WarehouseName}</td>
            <td>${EquipSourceToStr(EquipSource)}</td>
            {{if isloadDataItem(Id)}}
            <td><input class="Topic_btn" type="button" value="添加" onclick="AddEquip(this, '${Id}', '${AssetName}', '${AssetNumber}', '${EquipTypeToStr(Type)}', '${EquipStatusChange(EquipStatus)}', '${Unit}')" /></td>
             {{else}}
            {{if isloadDataItem(Id)==false }}
            <td><input class="Topic_btn" type="button" value="取消" onclick="CancelEquip(this, '${Id}', '${AssetName}')" /></td>
            {{/if}}
             {{/if}}
        </tr>
         
    </script>
</head>
<body>
    <form id="form1" runat="server">
         <div class="Honor_management">
                <div class="thetrth">
                    <ul>
                        <li class="Select clearfix">
                            <div style="float:left;">
                                <span style="">设备来源：</span>
                                <select class="option" id="EquipSource" style="width:150px;margin-left:10px;">
                                    <option value=''>全部</option>
                                    <option value='0'>本院资产</option>
                                    <option value='1'>资产系统</option>
                                </select>
                            </div>
                            <div style="float:left;margin-left:10px;">
                                <span style="">类型：</span>
                                <select class="option" id="Type" style="width:150px;margin-left:10px;">
                                    <option value=''>全部</option>
                                    <option value='0'>教学资产</option>
                                    <option value='1'>科研资产</option>
                                    <option value='2'>办公资产</option>
                                </select>
                            </div>
                            <input id="EquipName" type="text" name="search_w" class="search_w" placeholder="请输入资产名称" value=""  style="float:left;margin-left:10px;" />
                            <a class="btn1" href="#" onclick="javascript:SearchData();" style="margin-left:10px;padding:0px 8px;width:60px;text-align:center;">搜索</a>
                            <a class="btn1" href="#" onclick="javascript:AddAll();" style="padding:0px 8px;float:right;width:60px;text-align:center;">批量添加</a>
                        </li>
                        <li class="Sear clearfix">
                           
                        </li>
                         <li>
                            
                        </li>

                    </ul>

                </div>
                <table class="W_form">
                    <thead>
                        <tr class="trth">
                            <th class="number" style="width:60px;">
                                <input type="checkbox" name="allEquip" />
                                <span>全选</span>

                            </th>
                            <th class="number">序号</th>
                            <th class="">资产号</th>
                            <th class="">资产名称</th>
                            <th>类型</th>
                            <th>设备状态</th>
                            <th>单位</th>
                            <th>存放地点</th>
                            <th>设备来源</th>
                            <th>操作</th>
                        </tr>
                    </thead>
                    <tbody id="tbList"></tbody>
                </table>
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
    <script type="text/javascript">
        var UserIDCard = $('#hidUserIDCard').val();
        var EquipSource = "";//设备来源
        var Type = "";//类型
        var ClassName = "";//分类名称
        var EquipName = "";//设备名称
        $(function () {
            SearchData();
            $("input[name='allEquip']").on('click', function () {
                var isChecked = $(this).is(':checked');
                $("input[name='checkEquip']").each(function () {
                    $(this).prop("checked", isChecked);
                });
            })
        })
        //搜索
        function SearchData() {
            //获得搜索条件
            EquipSource = $('#EquipSource option:selected').val();
            Type = $('#Type option:selected').val();
            EquipName = $('#EquipName').val().trim();
            $("input[name='allEquip']").prop("checked", false);
            GetList(1);
        }
        //获取数据
        function GetList(PageIndex) {
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
                    "PageIndex": PageIndex, "PageSize": PageSize,  "Name": EquipName, "Type": Type
                    , "EquipSource": EquipSource, "action": "GetPageEquipDetail"
                },
                success: function (json) {
                    if (json.result.Status == "error") {
                        //layer.msg(json.result.Msg);
                        return;
                    }
                    if (json.result.Status == "no") {
                        //layer.msg(json.result.Msg);
                        $("#tbList").html('');
                        //生成页码条方法（方法对象,页码条容器，当前页码，总页数，页码组容量，总行数）
                        makePageBar(GetList, document.getElementById("pageBar"), 1, 1, 8, 0);

                        return;
                    }
                    if (json.result.Status == "ok") {
                        $("#tbList").html('');
                        $("#trTemp").tmpl(json.result.Data.PagedData).appendTo("#tbList");
                        //生成页码条方法（方法对象,页码条容器，当前页码，总页数，页码组容量，总行数）
                        makePageBar(GetList, document.getElementById("pageBar"), json.result.Data.PageIndex, json.result.Data.PageCount, 8, json.result.Data.RowCount);
                    }

                },
                error: OnError
            });

        }
        //错误处理
        function OnError(XMLHttpRequest, textStatus, errorThrown) {
            //layer.msg("");
        }

        function AddEquip(obj, id, name, number, type, status, unit) {
            var save = new Object();
            save.key = id;
            save.name = name;
            save.number = number;
            save.type = type;
            save.status = status;
            save.unit = unit;
            parent.readyIds.push(id);
            parent.readyObj.push(save);
            parent.GetPage();
            SearchData();
        }

        function CancelEquip(obj, id, name) {
            var reIds = parent.readyIds;
            var reObj = parent.readyObj;
            for (var i = 0; i < reIds.length; i++) {
                var key = reIds[i];
                if (key == id) {
                    parent.readyIds.splice(i, 1);
                    break;
                }
            }
            for (var j = 0; j < reObj.length; j++) {
                var key = reObj[j].key;
                if (key == id) {
                    parent.readyObj.splice(i, 1);
                    break;
                }
            }
            parent.GetPage();
            SearchData();
        }

        function isloadDataItem(id) {

            if ($.inArray(id, parent.readyIds) < 0)
                return true;
            else
                return false;
        }

        function AddAll() {
            var isAll = false;
            $("input[name='checkEquip']").each(function () {
                var isChecked = $(this).is(':checked');
                if (isChecked) {
                    var itemID = $(this).val();
                    var itemName = $(this).attr("valueName");
                    AddEquip(null, itemID, itemName);
                    isAll = true;
                }
            });
            if (isAll) {
                SearchData();
            }
        }
    </script>
</body>
</html>
