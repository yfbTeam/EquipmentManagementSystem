<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RepairInfo.aspx.cs" Inherits="EMS.Web.Order.RepairInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>送修</title>
    <link href="/css/style.css" rel="stylesheet" />
    <link href="/css/common.css" rel="stylesheet" />
    <link href="/css/iconfont.css" rel="stylesheet" />
    <link href="/css/animate.css" rel="stylesheet" />
    <script src="/js/jquery-1.11.2.min.js"></script>
    <script src="/js/layer/layer.js"></script>
    <script src="/js/Common.js"></script>
    <script src="/js/jquery.tmpl.js"></script>
    <script src="/js/My97DatePicker/WdatePicker.js"></script>
</head>
<body>
    <input type="hidden" id="hid_Id" runat="server" />
  
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
                                            <td class="mi"><span class="m">修理完成时间：</span></td>
                                            <td class="ku">
                                                <input id="txt_CompleteTime" class="hu Wdate" type="text" placeholder="选择日期" onclick="javascript: WdatePicker();" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="mi"><span class="m">修理地点：</span></td>
                                            <td class="ku">
                                                <input id="txt_RepairLocation" type="text" class="hu" placeholder="请输入修理地点" /><span class="wstar">*</span></td>
                                        </tr>
                                        <tr>
                                            <td class="mi" style="padding-left: 15px;">修理<span class="m">费用：</span></td>
                                            <td class="ku">
                                                <input id="txt_CostOfRepairs" type="text" class="hu" placeholder="请输入修理费用" 
                                                    onkeypress="value=value.replace(/[^\d.]/g,'')" onkeyup="value=value.replace(/[^\d.]/g,'')" onblur="value=value.replace(/[^\d.]/g,'')"
                                                    /><span class="wstar">*</span></td>
                                        </tr>
                                    </table>
                                </form>
                            </div>
                        </div>
                        <div class="submit_btn">
                            <span class="Save_and_submit">
                                <input type="submit" value="确定" class="Save_and_submit" onclick="Save();" /></span>
                            <span class="cancel">
                                <input type="submit" value="取消" class="cancel" onclick="javascript: parent.CloseIFrameWindow();" /></span>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
     
</body>
<script type="text/javascript">


    //保存
    function Save() {
         var RepairLocation = $("#txt_RepairLocation").val().trim();
         var CostOfRepairs = $("#txt_CostOfRepairs").val().trim();
         var CompleteTime = $("#txt_CompleteTime").val().trim();
         if (!RepairLocation.length || !CostOfRepairs.length) {
            layer.msg("请填写完整信息！");
            return;
        }
       
     
        $.ajax({
            url: WebServiceUrl + "/Order/Order.ashx",
            async: false,
            dataType: "jsonp",
            jsonp: "jsoncallback",
            data: {
                "RepairLocation": RepairLocation,
                "CostOfRepairs": CostOfRepairs,
                "CompleteTime": CompleteTime,
                "ID": $("#hid_Id").val(),
                "action": "RepairInfo"
            },
            success: OnSaveSuccess,
            error: OnSaveError
        });
       

    }

    function OnSaveSuccess(json) {
        if (json.result.Status == "no") {
            layer.msg("操作失败！");
        } else {
            parent.layer.msg('操作成功!');
            parent.getData(1);
        }
    }

    function OnSaveError(XMLHttpRequest, textStatus, errorThrown) {
        layer.msg("操作失败！");
    }
</script>
</html>
