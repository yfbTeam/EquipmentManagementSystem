<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ContractEdit.aspx.cs" Inherits="EMS.Web.Contract.ContractEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>合同编辑</title>
    <link href="/css/style.css" rel="stylesheet" />
    <link href="/css/common.css" rel="stylesheet" />
    <link href="/css/iconfont.css" rel="stylesheet" />
    <link href="/css/animate.css" rel="stylesheet" />
    <script src="/js/jquery-1.11.2.min.js"></script>
    <script src="/js/Validform_v5.3.1.js"></script>
    <script src="/js/layer/layer.js"></script>
    <script src="/js/Common.js"></script>
    <script src="/js/jquery.tmpl.js"></script>
    <script src="/js/My97DatePicker/WdatePicker.js"></script>
    <script src="/js/ajaxfileupload.js"></script>
    <style type="text/css">
        .Validform_wrong {
            color: red;
            white-space: nowrap;
            padding-left:5px;
        }
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
        <td>
            <span class=" ">
                    <input name="btnHide" type="button" value="撤销" onclick="CancelEquip(this, '${key}', '${name}')" />
            </span>
        </td>
    </tr>
</script>
</head>
<body>
    <form id="formEdit" name="formEdit" runat="server" class="demoform">
        <div class="Teaching_plan_management">
            <span class="cancel">
                <input class="Topic_btn" type="button" value="返回" onclick="javascript: history.back(-1);" style="float: right;" /></span>
            <h1 class="Page_name">合同：<span id="PlanName"></span>-->合同修改</h1>
            <table class="InfoTable">
                 <tbody>
                <tr>
                    <td><span>合同编号：</span></td>
                    <td><span>
                        <input id="txt_Number" type="text" class="hu" placeholder="请输入合同编号" datatype="*" errormsg="不能为空" /></span></td>
                    <td><span>合同名称：</span></td>
                    <td><span>
                        <input id="txt_Name" type="text" class="hu"  placeholder="请输入合同名称" datatype="*" errormsg="不能为空"  /></span></td>
                    <td><span>合同时间：</span></td>
                    <td><span>
                        <input id="txt_CreateTime" type="text" class="hu" disabled="disabled" /></span>
                    </td>
                </tr>
                     <tr>
                         <td><span>乙方签字人：</span></td>
                         <td><span><input id="txt_PartyB" type="text" class="hu" placeholder="请输入乙方签字人" datatype="/^[\u4e00-\u9fa5_a-zA-Z0-9]+$/" nullmsg="不能为空" errormsg="不能输入特殊字符" /></span></td>
                         <td><span>交易金额：</span></td>
                         <td><span><input id="txt_Money" type="text" class="hu"  placeholder="请输入交易金额"   /></span></td>
                         <td></td><td></td>
                     </tr>
                <tr>
                    <td colspan="6"><span style="margin-top: 5px;">合同备注：</span></td>
                </tr>
                <tr>
                    <td colspan="6">
                        <span>
                            <textarea id="txt_Description" name="te_Description" rows="4" style="width: 100%;" placeholder="请在此处输入文本..."></textarea>
                        </span>
                    </td>
                </tr>
                <tr>
                   <td colspan="6">
                       <span style="margin-top: 5px;">上传附件：</span>
                       <div class="shangchuan  shangchuana">
                            <div class="shgnchuanbottom">
                                <div class="ui-upload-holder">
                                    <div class="ui-upload-txt upload">
                                        点击上传
															
                                    </div>
                                    <input id="fileToUpload" type="file" size="45" name="fileToUpload" class="upload_file input ui-upload-input bluebutton dianjisc" />
                                </div>
                            </div>
                            <div id="divUpload" class="hidden">
                               <img id="loading" src="../Images/ajaxfileloading.gif" class="hidden" />
                            </div>
                        </div>
                        <div id="preview" class="upload_preview"></div>
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                        	<span>选择设备：</span>
                        <div id="Part" class="fr">
                        <input id="txt_Equip" type="button" class="btn1" value="选择设备"style="padding:0px 8px;cursor:pointer;" />
                    </div>
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
                            <th>操作</th>
                        </tr>
                    </thead>
                    <tbody>
                    </tbody>
                </table>

            </div>
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                        <div class="submit_btn">
                                <span class="Save_and_submit">
                                <input class="Save_and_submit" type="submit" value="确定" /></span>
                                <span class="cancel">
                                <input class="cancel" type="reset" value="取消" /></span>
                            </div>
                    </td>

                </tr>
                     </tbody>
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
    </form>
    
       <script type="text/javascript">

        $(document).ready(function () {
            $(".demoform").Validform({
                btnSubmit: ".Save_and_submit",
                btnReset: ".cancel",
                tiptype: 3,
                showAllError: true,
                beforeSubmit: function (curform) {
                    //在验证成功后，表单提交前执行的函数，curform参数是当前表单对象。
                    //这里明确return false的话表单将不会提交;	
                    saveData();
                }
            })
        })

           var fileArry = [];
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

               $("#fileToUpload").on("change", function () {
                   ajaxFileUpload($(this));
               })
            if ($("#hidOperator").val() == "edit") {
                   GetContract();
               } else {
                   $("#txt_CreateTime").removeAttr("disabled");
                   $("#txt_CreateTime").val(getNowFormatDate());
               }

            
           })

        function saveData()
        {
            $.ajax({
                type: "Post",
                url: WebServiceUrl + "/Contract/Contract.ashx",//random" + Math.random(),//方法所在页面和方法名
                //async: false,
                dataType: "jsonp",
                jsonp: "jsoncallback",
                data: {
                    Id: cId, number: $("#txt_Number").val(), name: $("#txt_Name").val(), desc: $("#txt_Description").val(), Creator: $("#hidUserIDCard").val(),
                    action: "saveContract", operator: $("#hidOperator").val(), fileJson: JSON.stringify(readArry), equipJson: JSON.stringify(readyIds),
                    PartyB: $("#txt_PartyB").val(), Money: $("#txt_Money").val()
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
                        window.location = "ContractList.aspx";
                    }
                },
                error: OnError
            });
        }
           //获得数据
           function GetContract() {
               $.ajax({
                   type: "Post",
                   url: WebServiceUrl + "/Contract/Contract.ashx",
                   //async: false,
                   dataType: "jsonp",
                   jsonp: "jsoncallback",
                   data: { "Id": cId, "action": "GetContract" },
                   success: function (json) {
                       var dtJson = $.parseJSON(json.result.Data);
                       var ContraArry = dtJson.ds;
                       var ContraData = ContraArry[0];
                       $('#txt_Number').val(ContraData.ContractNumber);
                       $('#txt_Name').val(ContraData.ContractName);
                       $('#txt_CreateTime').val(DateTimeConvert(ContraData.CreateTime, "yyyy-MM-dd HH:mm:ss"));
                       $('#txt_Description').val(ContraData.Description);
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
                               readyIds.push(arryIds[i]);
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

           function OpenEquipWin(obj, Id) {
            OpenIFrameWindow('资产列表', 'WinEquip.aspx', '820px', '470px');
           }

           function delFile(del) {
               var index = $(del).attr("data-index");
               $("#preview div").each(function (i, ele) {
                   var cIn = $(ele).attr("number");
                   if (index == cIn) {
                       $(ele).remove();
                       var arry = readArry;
                       for (var z = 0; z < arry.length; z++) {
                           var obj = arry[z];
                           if (obj.index == index) {
                               readArry.splice(z, 1);
                               break;
                           }
                       }
                       return false;
                   }
               });
               return false;
           }

           function innerHTMLFile(name, path) {

               fileArry.push(1);
               var html = '', i = fileArry.length, f = new Object();
               f.index = i;
               f.name = name;
               f.path = path;
               readArry.push(f);
            html = html + '<div id="uploadList_' + i + '" class="upload_append_list" number="' + i + '" ><p><strong><a href="'+path+'" target="_blank">' + name + '</a></strong>' +
                            '<a href="javascript:" class="upload_delete" title="删除" data-index="' + i + '" onclick="delFile(this)">删除</a><br />' +
                         //'<img id="uploadImage_' + i + '" src="' + path + '" class="upload_image" /></p>' +
                            //'<span id="uploadProgress_' + i + '" class="upload_progress"></span>' +
                        '</div>';
               $("#preview").append(html);
           }

           function ajaxFileUpload(event) {
               var e = event ? event : (window.event ? window.event : null);
               var uploadId = $(e).attr("id");
               var upattr = $(e).attr("uploadattr");
               if (!/\.(JPEG|jpeg|JPG|jpg|BMP|bmp|PNG|png|txt|TXT|doc|DOC|docx|DOCX|xlsx|XLSX|pdf|PDF|rtf|RTF)$/.test($(e).val())) {
                   art.alert("文档类型必须是jpg,png,bmp,txt,doc,xls,pdf,rtf中的一种！");
                   return false;
               }
               var fileTool = '';
               var url = '';
               if (uploadId == "fileToUpload") {
                   fileTool = 'fileToUpload';
                   $("#loading").ajaxStart(function () {
                       $(this).show();
                   }).ajaxComplete(function () {
                       $(this).hide();
                   });
               }
               $.ajaxFileUpload(
                   {
                       url: '../Handler/UploadImage.ashx',
                       secureuri: false,
                       fileElementId: fileTool,
                       dataType: "json",
                       data: { action: "UploadFileForContract" },
                       success: function (data, status) {
                           if (data.result) {
                               innerHTMLFile(data.name, decodeURIComponent(data.path));
                               $("#fileToUpload").on("change", function () {
                                   ajaxFileUpload($(this));
                               })
                           } else {
                               alert(data.desc);
                           }
                       },
                       error: function (data, status, e) {
                           alert(e);
                       }
                   }
               )
               return false;
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
                   var key = reObj[j].key;
                   if (key == id) {
                       readyObj.splice(i, 1);
                       break;
                   }
               }
               GetPage();
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
