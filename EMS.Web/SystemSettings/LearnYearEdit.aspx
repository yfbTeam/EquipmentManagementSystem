<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LearnYearEdit.aspx.cs" Inherits="EMS.Web.SystemSettings.LearnYearEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>新增学期</title>
    <link href="/css/style.css" rel="stylesheet" />
    <link href="/css/common.css" rel="stylesheet" />
    <link href="/css/iconfont.css" rel="stylesheet" />
    <link href="/css/animate.css" rel="stylesheet" />
    <script src="/js/jquery-1.11.2.min.js"></script>
    <script src="/js/layer/layer.js"></script>
    <script src="/js/Common.js"></script>
    <script src="/js/My97DatePicker/WdatePicker.js"></script>
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
                                            <td class="mi"><span class="m">学期名称：</span></td>
                                            <td class="ku">
                                                <input id="txt_name" type="text" class="hu" placeholder="请输入学期名称" /><span class="wstar">*</span></td>
                                        </tr>
                                        <tr>
                                            <td class="mi"><span class="m">学期起始时间：</span></td>
                                            <td class="ku">
                                              <input id="da_startdate" type="text" class="Wdate hu" onclick="javascript: WdatePicker();" onFocus="WdatePicker({maxDate:'#F{$dp.$D(\'da_enddate\')}'})"/><span class="wstar">*</span>                                            
                                           </td>
                                        </tr>                        
                                        <tr>
                                            <td class="mi"><span class="m">学期终止时间：</span></td>
                                            <td class="ku">
                                               <input id="da_enddate" type="text" class="Wdate hu" onclick="javascript: WdatePicker();" onFocus="WdatePicker({minDate:'#F{$dp.$D(\'da_startdate\')}'})"/><span class="wstar">*</span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="mi"><span class="m">课程录入限制周次：</span></td>
                                            <td class="ku">
                                                <input id="txt_datacoll" type="text" placeholder="请输入数字" onkeyup="value=value.replace(/[^\d]/g,'') " class="hu" style="width:166px;"/>周<span class="wstar">*</span></td>
                                        </tr>                                        
                                    </table>
                                </form>
                            </div>
                        </div>
                        <div class="submit_btn">
                            <span class="Save_and_submit">
                                <input type="submit" value="确定" class="Save_and_submit" onclick="SaveLearnYear();" /></span>
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
            url: WebServiceUrl + "/SystemSettings/LearnYear.ashx",//random" + Math.random(),//方法所在页面和方法名
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
            $("#da_startdate").val(DateTimeConvert(model.StartDate));
            $("#da_enddate").val(DateTimeConvert(model.EndDate));
            $("#txt_datacoll").val(model.DataCollectionTime);
        }
    }
    //保存用户
    function SaveLearnYear() {
        var name = $("#txt_name").val().trim();
        var startdate= $("#da_startdate").val();
        var enddate = $("#da_enddate").val();
        var datacoll = $("#txt_datacoll").val().trim();
        if (!name.length|| !startdate.length || !enddate.length|| !datacoll.length) {
            layer.msg("请填写完整信息！");
            return;
        }
        var itemid = $("#<%=hid_Id.ClientID%>").val();
        var actionp = "AddLearnYear";
        var url = WebServiceUrl + "/SystemSettings/LearnYear.ashx";
        if (itemid.length) {
            url = WebServiceUrl + "/SystemSettings/LearnYear.ashx";
            actionp = "EditLearnYear";
        }
        $.ajax({
            url: url,//random" + Math.random(),//方法所在页面和方法名
            type: "post",
            async: false,
            dataType: "jsonp",
            jsonp: "jsoncallback",
            data: {
                itemid: itemid,                
                name: name.trim(),
                startdate: startdate,
                enddate: enddate,
                datacollection:datacoll,
                useridcard: $("#hid_UserIDCard").val(),
                action:actionp
            },
            success: OnSaveSuccess,
            error: OnSaveError
        });
    }

    function OnSaveSuccess(json) {
        if (json.result == "-1") {
            layer.msg("该学期已存在！");
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

