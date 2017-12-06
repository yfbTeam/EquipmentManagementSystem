<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RepairEdit.aspx.cs" Inherits="EMS.Web.Order.RepairEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>报修</title>
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
<body onload="this.focus();">
    <input type="hidden" id="hid_Id" runat="server" />
    <input type="hidden" id="hid_UserIDCard" runat="server" />
     <input type="hidden" id="hidUserName" runat="server" />
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
                                             <td class="mi" style="padding-left: 15px;"><span class="m">报修人：</span></td>
                                            <td class="ku">
                                                 <input id="txt_UserName" type="text" class="hu"/><span class="wstar"></span>
                                               
                                            </td>
                                            <td class="mi" style="padding-left: 15px;"><span class="m">损坏时间：</span></td>
                                            <td class="ku">
                                                <input id="txt_Damagetime" class="hu Wdate" type="text" placeholder="选择日期" onclick="javascript: WdatePicker({skin:'whyGreen',maxDate:'%y-%M-%d'});" />
                                                 
                                            </td>

                                        </tr>
                                        <tr>
                                            <td class="mi"><span class="m">损坏原因：</span></td>
                                            <td class="ku" colspan="3">
                                                <textarea id="te_DamageCauses" name="te_DamageCauses" rows="4" style="width: 100%;" form="usrform" placeholder="请在此处输入文本..."></textarea>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="mi"><span class="m">备注：</span></td>
                                            <td class="ku" colspan="3">
                                                <textarea id="te_remark" name="te_remark" rows="4" style="width: 100%;" form="usrform" placeholder="请在此处输入文本..."></textarea>
                                            </td>
                                        </tr>
                                        <%--    <tr>
                                            <td class="mi"><span class="m">修理地点：</span></td>
                                            <td class="ku">
                                                <input id="txt_RepairLocation" type="text" class="hu" placeholder="请输入修理地点" /><span class="wstar">*</span></td>
                                            <td class="mi" style="padding-left: 15px;">修理<span class="m">费用：</span></td>
                                            <td class="ku">
                                                <input id="txt_CostOfRepairs" type="text" class="hu" placeholder="请输入修理费用" /><span class="wstar">*</span></td>
                                        </tr>
                                        <tr>
                                            <td class="mi" style="padding-left: 15px;"><span class="m">损坏时间：</span></td>
                                            <td class="ku">
                                                <input id="txt_Damagetime" class="hu" type="text" placeholder="选择日期" onclick="javascript: WdatePicker({ mindate: '#F{$dp.$D(\'txt_CompleteTime\')||\'new Date()\'}' });" />
                                            </td>
                                            <td class="mi"><span class="m">修理完成时间：</span></td>
                                            <td class="ku">
                                                <input id="txt_CompleteTime" class="hu" type="text" placeholder="选择日期" onclick="javascript: WdatePicker({ minDate: '#F{$dp.$D(\'txt_Damagetime\')}', maxDate: new Date() });" />
                                            </td>

                                        </tr>
                                        <tr>
                                            <td class="mi"><span class="m">损坏原因：</span></td>
                                            <td class="ku" colspan="3">
                                                <textarea id="te_DamageCauses" name="te_remark" rows="4" style="width: 100%;" form="usrform" placeholder="请在此处输入文本..."></textarea>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="mi"><span class="m">备注：</span></td>
                                            <td class="ku" colspan="3">
                                                <textarea id="te_remark" name="te_remark" rows="4" style="width: 100%;" form="usrform" placeholder="请在此处输入文本..."></textarea>
                                            </td>
                                        </tr>--%>
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
    <!--end tz_dialog-->

    <!--tz_yy start-->
    <div class="tz_yy"></div>
    <!--end tz_yy-->
    
</body>
<script type="text/javascript">
    $(document).ready(function () {
        $("#txt_UserName").val($("#hidUserName").val())
       

    });


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
    var num = "";
    var UrlDate = new GetUrlDate(); //实例化
    $(document).ready(function () {
        $("#txt_kano").val(UrlDate.kano);
        // BindClassDrop();
    });



    //保存
    function Save() {
       // var RepairLocation = $("#txt_RepairLocation").val().trim();
       // var CostOfRepairs = $("#txt_CostOfRepairs").val().trim();
       // var CompleteTime = $("#txt_CompleteTime").val().trim();
        var Damagetime = $("#txt_Damagetime").val();
        var DamageCauses = $("#te_DamageCauses").val().trim();
        var remarks = $("#te_remark").val().trim();
        var useridcard = $("#hid_UserIDCard").val();

        if ( !Damagetime.length || !DamageCauses.length) {
            layer.msg("请填写完整信息！");
            return;
        }

        //var url = WebServiceUrl + "/order/order.asmx/RepairEdit?jsoncallback=?";
        $.ajax({
            url: WebServiceUrl + "/Order/Order.ashx",//random" + Math.random(),//方法所在页面和方法名
            async: false,
            dataType: "jsonp",
            jsonp: "jsoncallback",
            data: {
                "Damagetime": Damagetime,
                "DamageCauses": DamageCauses,
                "remarks": remarks,
                "useridcard": useridcard,
                "eqID": UrlDate.eqID,
                "Type": UrlDate.Type,
                "action": "RepairEdit"
            },
            success: OnSaveSuccess,
            error: OnSaveError
        });
        //$.ajax({
        //    url: url,//random" + Math.random(),//方法所在页面和方法名
        //    type: "post",
        //    async: false,
        //    dataType: "json",
        //    data: {
        //        "RepairLocation": RepairLocation,
        //        "CostOfRepairs": CostOfRepairs,
        //        "CompleteTime": CompleteTime,
        //        "Damagetime": Damagetime,
        //        "DamageCauses": DamageCauses,
        //        "remarks": remarks,
        //        "useridcard": useridcard
        //    },
        //    success: OnSaveSuccess,
        //    error: OnSaveError
        //});

    }

    function OnSaveSuccess(json) {
        if (json.result == "-1") {
            layer.msg("该姓名已存在！");
        }
        else if (json.result != "0" && json.result != "-1") {
            parent.layer.msg('报修成功!');
            if (UrlDate.kano) {
                parent.getUserByKaNo(UrlDate.kano);
            } else {
                parent.getData(1);
            }
            parent.CloseIFrameWindow();
        } else {
            layer.msg("报修失败！");
        }
    }
    function OnSaveError(XMLHttpRequest, textStatus, errorThrown) {
        layer.msg("报修失败！");
    }
</script>
</html>
