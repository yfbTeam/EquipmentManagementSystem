<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BorrowEdit.aspx.cs" Inherits="EMS.Web.OfficeFurniture.BorrowEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="/css/style.css" rel="stylesheet" />
    <link href="/css/common.css" rel="stylesheet" />
    <link href="/css/iconfont.css" rel="stylesheet" />
    <link href="/css/animate.css" rel="stylesheet" />
    <script src="/js/jquery-1.11.2.min.js"></script>
    <script src="/js/layer/layer.js"></script>
    <script src="/js/Common.js"></script>
    <script src="/js/jquery.tmpl.js"></script>
    <script src="/js/My97DatePicker/WdatePicker.js"></script>
    <script src="../js/ajaxfileupload.js"></script>
    <style type="text/css">
        .shangchuan {
            width: 200px;
            height: 140px;
            float: left;
            margin-right: 5px;
        }

        .dianjisc {
            border: none;
            border-radius: 3px;
            /*width: 100px;*/
            color: #fff;
            padding: 5px 0px;
        }

        .bluebutton:hover {
            background: #1B85CE none repeat scroll 0% 0%;
            cursor: pointer;
        }

        .bluebutton {
            background: #0097DD none repeat scroll 0% 0%;
            cursor: pointer;
        }

        .ui-upload-holder {
            position: relative;
            width: 198px;
            height: 27px;
            border: 1px solid silver;
            overflow: hidden;
            border-radius: 3px;
            cursor: pointer;
        }

        .ui-upload-txt {
            position: absolute;
            top: 0px;
            left: 0px;
            width: 198px;
            height: 27px;
            line-height: 27px;
            text-align: center;
            background: #2789BA none repeat scroll 0% 0%;
            color: #fff;
            font: 12px "微软雅黑";
            vertical-align: middle;
            padding: 5px 0px;
            cursor: pointer;
        }

        .upload_preview {
            border-top: 1px solid #bbb;
            border-bottom: 1px solid #bbb;
            background-color: #fff;
            overflow: hidden;
        }

        .upload_append_list {
            height: 300px;
            padding: 0 1em;
            float: left;
            position: relative;
        }

        .upload_delete {
            margin-left: 2em;
        }

        .upload_image {
            max-height: 250px;
            padding: 5px;
        }

        .InfoTable td {
            border: 1px solid #cad9ea;
            padding: 5px 10px;
            height: 25px;
        }

            .InfoTable td span {
                line-height: 20px;
            }

                .InfoTable td span input {
                    height: 30px;
                    padding-left: 8px;
                }
    </style>
    <script id="trTemp" type="text/x-jquery-tmpl">
        <tr>
            <td class="">${number}</td>
            <td class=""><span title="${name}">${NameLengthUpdate(name,25)}</span></td>
            <td class="">${EquipTypeToStr(type)}</td>
            <td class="">${unit}</td>
            <td>
                <span class=" ">
                    <input name="btnHide" type="button" value="取消" onclick="CancelEquip(this, '${EquipDatailID}', '${name}')" />
                </span>
            </td>
        </tr>
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="Teaching_plan_management">
             <span class="cancel">
                <input class="Topic_btn" type="button" value="返回" onclick="javascript: history.back(-1);" style="float: right;" /></span>
            <h1 class="Page_name"><span id="PlanName"></span>办公设备借用</h1>
            <table class="InfoTable">
                <tr>
                    <td>
                        <span>借用人：</span>

                    </td>
                    <td>
                        <span>
                            <input id="txt_UserName" type="text" class="hu" />
                        </span>
                    </td>
                    <td><span>借用时间：</span></td>
                    <td><span>
                        <input id="txt_BeginDate" class="hu Wdate" type="text" placeholder="选择日期" onclick="var endDate = $dp.$('txt_EndDate'); WdatePicker({ onpicked: function () { endDate.focus(); }, maxDate: '#F{$dp.$D(\'txt_EndDate\')}' })"  />
                    </span></td>
                    <td><span>归还时间：</span></td>
                    <td><span>

                        <input id="txt_EndDate" class="hu Wdate" type="text" placeholder="选择日期"onclick="WdatePicker({ minDate: '#F{$dp.$D(\'txt_BeginDate\')}' })" />
                    </span>
                    </td>
                </tr>
                <tr>
                    <td colspan="6">借用原因：</td>
                </tr>
                <tr>

                    <td colspan="6">
                        <textarea id="te_BorrowReason" name="te_remark" rows="4" style="width: 100%;" form="usrform" placeholder="请在此处输入借用原因..."></textarea>
                    </td>
                </tr>
                <tr>
                    <td colspan="6">备&nbsp注：</td>
                </tr>
                <tr>
                    <td colspan="6">
                        <textarea id="te_Notes" name="te_remark" rows="4" style="width: 100%;" form="usrform" placeholder="请在此处输入备注..."></textarea>
                    </td>
                </tr>
                <tr>
                    <td colspan="6">借用资产：

                        <span id="Part" class="fr">
                            <input id="txt_Equip" type="button" class="btn1" value="选择资产" style="padding:0px 8px;cursor:pointer;"/>

                        </span>
                    </td>
                </tr>

                <tr>
                    <td colspan="6">
                        <div class="Honor_management">
                            <table class="W_form" id="tbList" cellspacing="0">
                                <colgroup>
                                    <col width="10%" />
                                    <col width="25%" />
                                    <col width="30%" />

                                </colgroup>
                                <thead>
                                    <tr class="trth">
                                        <th class="Project_name">资产号</th>
                                        <th class="Project_name">资产名称</th>
                                        <th class="">类型</th>
                                        <th>单位</th>
                                        <th>操作</th>
                                    </tr>
                                </thead>
                                <tbody id="Tb_List">
                                </tbody>
                            </table>

                        </div>
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                        <div class="submit_btn">
                            <span class="Save_and_submit">
                                <input class="Save_and_submit" type="button" value="确定" onclick="javascript: SaveContract();" /></span>
                            <span class="cancel">
                                <input class="cancel" type="button" value="取消" onclick="quxiao()" /></span>
                        </div>
                    </td>

                </tr>
            </table>
            <br />

        </div>
        <!--分页页码开始-->
        <div class="paging">
            <span id="pageBar"></span>
        </div>
        <asp:HiddenField ID="hidId" runat="server" />
        <asp:HiddenField ID="hidOperator" runat="server" />
        <asp:HiddenField ID="hidUserIDCard" runat="server" />
        <asp:HiddenField ID="hidIsAdmin" runat="server" />
        <asp:HiddenField ID="hidUserName" runat="server" />
    </form>
    <script type="text/javascript">
        $('#txt_UserName').val($('#hidUserName').val());
        var readArry = [];
        var cId = $('#hidId').val();
        var readyIds = [];
        var readyObj = [];
        $(function () {
            $('.upload').on('click', function () {
                $('.upload_file').click();
            })
            $("#txt_Equip").on('click', function () {
                OpenEquipWin();
            })


            if ($("#hidOperator").val() == "edit") {
                GetPage();
            } else {
                $("#txt_BeginDate").val(getNowFormatDate());
            }
        })


        function GetPageAll() {
            $("#tbList tbody").html('');
            if (readyObj.length > 0) {
                $("#trTemp").tmpl(readyObj).appendTo("#tbList");
            }
        }



        //获得数据
        function GetPage() {
            $.ajax({
                type: "Post",
                url: WebServiceUrl + "/Statistical/Statistical.ashx",
                //async: false,
                dataType: "jsonp",
                jsonp: "jsoncallback",
                data: { "Id": cId, "action": "GetPage" },
                success: function (json) {
                    if (json.result.Data.PagedData.length > 0) {
                        Plan = json.result.Data.PagedData;
                        if (Plan!=null && Plan.length>0) {
                            var obj = Plan[0];
                            $('#txt_UserName').val(obj.CreateName);
                            $('#txt_BeginDate').val(DateTimeConvert(obj.BeginDate, "yyyy-MM-dd"));
                            $('#txt_EndDate').val(DateTimeConvert(obj.EndDate, "yyyy-MM-dd"));
                            $('#te_BorrowReason').val(obj.BorrowReason);
                            $('#te_Notes').val(obj.Notes);
                        }
                    }
                },


                error: OnError
            });

            $.ajax({
                url: WebServiceUrl + "/Statistical/Statistical.ashx",//random" + Math.random(),//方法所在页面和方法名
                async: false,
                dataType: "jsonp",
                jsonp: "jsoncallback",
                data: { "id": cId, "action": "GetPageList" },
                success: OnSuccess,
                error: OnError
            });

        }

        function OnSuccess(json) {
            if (json.result.Status == "no" || json.result.Status == "error") {
                $("#Tb_List").html('<tr><td colspan="100"  style="text-align:center;">无内容</td></tr>');
            } else {
              
                $("#Tb_List").html('');
                var data = $.parseJSON(json.result.Data);
                for (var i = 0; i < data.ds.length; i++) {
                    var save = new Object();
                   
                    readyObj.push(data.ds[i]);
                    readyIds.push(data.ds[i].EquipDatailID);
                }

                //alert(readyObj)

                //$("#trTemp").tmpl(data.ds).appendTo("#Tb_List");

                ////   $("#trTemp").tmpl(json.result.Data).appendTo($("#Honor_management"));

            }
            GetPageAll();

        }



        function OnError(XMLHttpRequest, textStatus, errorThrown) {
            //layer.msg("加载失败");
        }

        function OpenEquipWin(obj, Id) {
            OpenIFrameWindow('可借用资产列表', 'selectionEquip.aspx', '870px', '470px');
        }




        ///保存
        function SaveContract() {
            if ($("#txt_EndDate").val().trim()=="") {
                layer.msg("请填写归还日期！");
                return;
            }
            if ($("#te_BorrowReason").val().trim() == "") {
                layer.msg("请填写借用原因！");
                return;
            }
            if (!readyIds.length) {
                layer.msg("请选择要借用的资产！");
                return;
            }


            $.ajax({
                type: "Post",
                url: WebServiceUrl + "/Statistical/Statistical.ashx",//random" + Math.random(),//方法所在页面和方法名
                //async: false,
                dataType: "jsonp",
                jsonp: "jsoncallback",
                data: {
                    Id: cId, UserIDCard: $("#hidUserIDCard").val(), BeginDate: $("#txt_BeginDate").val(), EndDate: $("#txt_EndDate").val(), BorrowReason: $("#te_BorrowReason").val(),
                    action: "setBorrowRecord", Notes: $("#te_Notes").val(), equipJson: JSON.stringify(readyIds), operator: $("#hidOperator").val(),
                },
                success: function (json) {
                    if (json.result.Status == "error") {
                        //layer.msg(json.result.Msg);
                        return;
                    }
                    if (json.result.Status == "no") {
                        layer.msg(json.result.Msg);
                        return;
                    }
                    if (json.result.Status == "ok") {
                        parent.layer.msg(json.result.Msg);
                        window.location = "OfficeFurnitureBorrow.aspx";
                    }
                },
                error: OnError
            });
        }

        //取消
        function CancelEquip(obj, id, name) {
            var reIds = readyIds;
            var reObj = readyObj;

            for (var i = 0; i < reIds.length; i++) {
                var key = reIds[i];
                if (key == id) {
                    readyIds.splice(i, 1);
                    break;
                }
            }

            for (var j = 0; j < reObj.length; j++) {
                var key = reObj[j].EquipDatailID;
                if (key == id) {
                    readyObj.splice(j, 1);
                    break;
                }
            }
            GetPageAll();
        }



        function quxiao() {
            window.location = "OfficeFurnitureBorrow.aspx";
          
        }
       
    </script>
</body>
</html>


















