<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WarehouseEdit.aspx.cs" Inherits="EMS.Web.SystemSettings.WarehouseEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>新增库房</title>
    <link href="/css/style.css" rel="stylesheet" />
    <link href="/css/common.css" rel="stylesheet" />
    <link href="/css/iconfont.css" rel="stylesheet" />
    <link href="/css/animate.css" rel="stylesheet" />
    <script src="/js/jquery-1.11.2.min.js"></script>
    <script src="/js/layer/layer.js"></script>
    <script src="/js/Common.js"></script>
    <script src="/js/jquery.tmpl.js"></script>
</head>
<body>
    <input type="hidden" id="hid_Id" runat="server" />
    <input type="hidden" id="hid_UserIDCard" runat="server" />
    <!--tz_dialog start-->
    <div class="yy_dialog">
        <div class="t_content">
            <div class="yy_tab">
                <div class="content">
                    <div class="tc">
                        <div class="t_message">
                            <div class="message_con">
                                <form>
                                    <table class="m_top">
                                        <tr>
                                            <td class="mi"><span class="m">库房名称：</span></td>
                                            <td class="ku">
                                                <input id="txt_name" type="text" class="hu" placeholder="请输入库房名称" /><span class="wstar">*</span></td>
                                        </tr>
                                        <tr>
                                            <td class="mi"><span class="m">备注：</span></td>
                                            <td class="ku">
                                                <textarea id="te_remark" name="te_remark" form="usrform" placeholder="请在此处输入文本..."></textarea>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="mi"><span class="m">平面图：</span></td>
                                            <td class="ku">
                                                <input id="file_graph" type="file" class="hu" />
                                            </td>
                                        </tr>
                                    </table>
                                </form>
                            </div>
                        </div>
                        <div class="submit_btn">
                            <span class="Save_and_submit">
                                <input type="submit" value="确定" class="Save_and_submit" onclick="SaveWarehouse();"/></span>
                            <span class="cancel">
                                <input type="submit" value="取消" class="cancel" onclick="javascript: parent.CloseIFrameWindow();" /></span>
                        </div>
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
            var itemid = $("#<%=hid_Id.ClientID%>").val();
            if (itemid.length) {
                //为控件绑定数据
                BindDataById(itemid);
            }
        });
        function BindDataById(itemid) {
            $.ajax({
                url: WebServiceUrl+"/SystemSettings/Warehouse.ashx",//random" + Math.random(),//方法所在页面和方法名
                type: "post",
                async: false,
                dataType: "jsonp",
                jsonp: "jsoncallback",
                data: { itemid: itemid, action: "GetModelById" },
                success: OnBindSuccess,
                //error: OnBindError
            });
        }
        function OnBindSuccess(json) {
            var model = json.result;
            if (model.toString() != "") {
                $("#txt_name").val(model.Name);
                $("#te_remark").val(model.Remarks);
            }
        }
        //保存库房
        function SaveWarehouse() {
            var name = $("#txt_name").val();
            if (!name.length || name == "请输入库房名称") {
                layer.msg("请填写库房名称！");              
                return;
            }
            var itemid = $("#<%=hid_Id.ClientID%>").val();
            var actionp = "AddWarehouse";
            var url = WebServiceUrl+"/SystemSettings/Warehouse.ashx";
            if (itemid.length) {
                url = WebServiceUrl + "/SystemSettings/Warehouse.ashx";
                actionp = "EditWarehouse";
            }
            $.ajax({
                url: url,//random" + Math.random(),//方法所在页面和方法名
                type: "post",
                async: false,
                dataType: "json",
                data: {
                    itemid: itemid,
                    name: name,
                    remarks: $("#te_remark").val(),
                    useridcard: $("#hid_UserIDCard").val(),
                    action: actionp
                },
                success: OnSaveSuccess,
                error: OnSaveError
            });

        }

        function OnSaveSuccess(json) {
            if (json.result == "-1") {
                layer.msg("该库房已存在！");
            }
            else if (json.result != "0" && json.result != "-1") {                
                parent.layer.msg('操作成功!');
                parent.getData(1);
                parent.CloseIFrameWindow();            
            } else {
                layer.msg("操作失败！");
            }
        }
        function OnSaveError(XMLHttpRequest, textStatus, errorThrown) {
            layer.msg("操作失败！");
        }
</script>
</html>
