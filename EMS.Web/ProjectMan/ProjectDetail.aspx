<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProjectDetail.aspx.cs" Inherits="EMS.Web.ProjectMan.ProjectDetail" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>项目详细</title>
    <link href="/css/style.css" rel="stylesheet" />
    <link href="/css/common.css" rel="stylesheet" />
    <link href="/css/iconfont.css" rel="stylesheet" />
    <link href="/css/animate.css" rel="stylesheet" />
    <script src="/js/jquery-1.11.2.min.js"></script>
    <script src="/js/jquery.validate.min.js"></script>
    <script src="/js/layer/layer.js"></script>
    <script src="/js/Common.js"></script>
    <script src="/js/jquery.tmpl.js"></script>
    <script src="/js/My97DatePicker/WdatePicker.js"></script>
    <script src="/js/ajaxfileupload.js"></script>
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
            border-bottom: 1px solid #bbb;
            background-color: #fff;
            overflow: hidden;
        }

        .upload_append_list {
            height: 30px;
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

        span.error {
            color: #C00;
            padding: 0 6px;
        }
		.InfoTable tr{}
		.InfoTable td {
			border: 1px solid #cad9ea;
			padding: 5px 10px;
			height:25px;
		}
		.InfoTable td span{line-height:20px;}
		.InfoTable td span input{height:30px;padding-left:8px;}
		.shangchuana{float:right;width:100px;height:30px;}
		.shangchuana .ui-upload-txt{width:100px;}
		.shangchuana .ui-upload-holder{width:100px;}
    </style>
    <script id="trTemp" type="text/x-jquery-tmpl">
        <tr>
            <td class="">${number}</td>
            <td class=""><span title="${name}">${NameLengthUpdate(name,25)}</span></td>
            <td class="">${type}</td>
            <td class="">${status}</td>
            <td class="">${unit}</td>
        </tr>
    </script>
</head>
<body>
    <form id="formEdit" name="formEdit" runat="server">
        <div class="Teaching_plan_management">
            <table class="InfoTable">
                 <tbody>
                <tr>
                    <td><span>项目编号：</span></td>
                    <td><span>
                        <label id="txt_Number"></label></span></td>
                    <td><span>项目名称：</span></td>
                    <td><span>
                        <label id="txt_Name"></label> </span></td>
                    <td><span>项目时间：</span></td>
                    <td><span>
                        <label id="txt_CreateTime"></label></span>
                    </td>
                  
                </tr>
                     <tr>
                         <td><span>乙方签字人：</span></td>
                         <td><span>
                             <label id="txt_PartyB"></label>
                         </span></td>
                         <td><span>交易金额：</span></td>
                         <td><span>
                             <label id="txt_Money"></label>
                         </span></td>
                         <td colspan="2"></td>
                     </tr>
                <tr>
                    <td colspan="6"><span style="margin-top: 5px;">项目备注：</span></td>
                </tr>
                <tr>
                    <td colspan="6">
                        <span>
                            <label id="txt_Description"></label>
                        </span>
                    </td>
                </tr>
                <tr>
                   <td colspan="6" >
                   <span style="margin-top:5px;">上传附件：</span>
                        <ul class="fileUI">
                            
                        </ul>
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                        	<span>设备详细：</span>
                        <span id="Part" class="fr">
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
                                        <th class="number">资产号</th>
                                        <th class="Project_name">资产名称</th>
                                        <th class="">类型</th>
                                        <th class=" ">设备状态</th>
                                        <th>单位</th>
                                    </tr>
                                </thead>
                                <tbody>
                                </tbody>
                            </table>
                        </div>
                         <!--分页页码开始-->
                        <div class="paging">
                            <span id="pageBar"></span>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                        <div class="submit_btn">
                            <span class="cancel">
                                <input class="Topic_btn"  type="button" value="返回" onclick="javascript: parent.CloseIFrameWindow();" /></span>
                        </div>
                    </td>
                </tr>
                     </tbody>
            </table>
            <br />
        </div>
       
        <asp:HiddenField ID="hidId" runat="server" />
        <asp:HiddenField ID="hidOperator" runat="server" />
        <asp:HiddenField ID="hidUserIDCard" runat="server" />
        <asp:HiddenField ID="hidIsAdmin" runat="server" />
    </form>
    
    <script type="text/javascript">
        var cId = $('#hidId').val();
        var readyObj = [];
        $(function () {
            GetContract();
        })
        //获得数据
        function GetContract() {
            $.ajax({
                type: "Post",
                url: WebServiceUrl + "/Contract/Contract.ashx",
                async: false,
                dataType: "jsonp",
                jsonp: "jsoncallback",
                data: { "Id": cId, "action": "GetContract" },
                success: function (json) {
                    var dtJson = $.parseJSON(json.result.Data);
                    var ContraArry = dtJson.ds;
                    var ContraData = ContraArry[0];
                    $('#txt_Number').html(ContraData.ContractNumber);
                    $('#txt_Name').html(ContraData.ContractName);
                    $('#txt_CreateTime').html(DateTimeConvert(ContraData.CreateTime, "yyyy-MM-dd HH:mm:ss"));
                    $('#txt_Description').html(ContraData.Description);
                    $("#txt_PartyB").html(ContraData.PartyB);
                    $("#txt_Money").html(ContraData.Money);
                    if (ContraData.atta != null && ContraData.atta != "") {
                        var arryAtta = ContraData.atta.split('|');
                        var arryUrl = ContraData.url.split('|');
                        for (var i = 0; i < arryAtta.length; i++) {
                            innerHTMLFile(arryAtta[i], arryUrl[i]);
                        }
                    }
                    if (ContraData.equipids != null && ContraData.equipids != "") {
                        var arryIds = ContraData.equipids.split('|');
                        var arryNames = ContraData.equipiNames.split('|');
                        var numbers = ContraData.AssetNumbers.split('|');
                        var statuss = ContraData.Statuss.split('|');
                        var types = ContraData.Types.split('|');
                        var units = ContraData.units.split('|');
                        for (var i = 0; i < arryIds.length; i++) {
                            var save = new Object();
                            save.key = arryIds[i];
                            save.name = arryNames[i];
                            save.number = numbers[i];
                            save.type = types[i];
                            save.status = statuss[i];
                            save.unit = units[i];
                            readyObj.push(save);
                        }
                        GetPage();
                    }
                },
                error: OnError
            });
        }

        function OnError(XMLHttpRequest, textStatus, errorThrown) {

            //layer.msg("加载失败");
        }
        function innerHTMLFile(name, path) {
            var li = "<li><span><a href='" + path + "' target='_blank'>" + name + "</a></span></li>";
            $(".fileUI").append(li);
        }

        function GetPage() {
            $("#tbList tbody").html('');
            if (readyObj.length > 0) {
                $("#trTemp").tmpl(readyObj).appendTo("#tbList");
            }
        }
    </script>
</body>
</html>
