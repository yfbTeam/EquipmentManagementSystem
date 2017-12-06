<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddRepairDetails.aspx.cs" Inherits="EMS.Web.Order.AddRepairDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>办公设备借用详细</title>
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
            height: 50px;
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

        .shangchuana {
            float: right;
            width: 100px;
            height: 30px;
        }

            .shangchuana .ui-upload-txt {
                width: 100px;
            }

            .shangchuana .ui-upload-holder {
                width: 100px;
            }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="Teaching_plan_management">
            <h1 class="Page_name"><span id="PlanName"></span>资产报修新增记录</h1>
            <table class="InfoTable">
                <tr>
                    <td>
                        <span>记录人：</span>

                    </td>
                    <td>
                        <span>
                            <label id="txt_UserName"></label>
                        </span>
                    </td>
                    <td><span>记录时间：</span></td>
                    <td><span>
                        <label id="txt_Date"></label>

                    </span></td>
                </tr>
                <tr>
                    <td colspan="4">报修记录：</td>
                </tr>
                <tr>

                    <td colspan="4" class="ku">
                        <textarea id="te_Record" name="te_Record" rows="4" style="width: 100%;" form="usrform" placeholder="请在此处输入报修记录..."></textarea>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">上传附件：
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
                    <td colspan="4">
                        <div class="submit_btn">
                            <span class="Save_and_submit">
                                <input class="Topic_btn" type="button" value="保存" onclick="javascript: AddDetails();" />
                                <input class="Topic_btn" type="button" value="返回" onclick="javascript: parent.CloseIFrameWindow();" /></span>
                        </div>
                    </td>

                </tr>
            </table>
            <br />

        </div>
        <asp:HiddenField ID="hidOperator" runat="server" />
        <asp:HiddenField ID="hidId" runat="server" />
        <asp:HiddenField ID="hidRId" runat="server" />
        <asp:HiddenField ID="hidUserName" runat="server" />
        <asp:HiddenField ID="hidDate" runat="server" />
    </form>
    <script type="text/javascript">
     
        $('#txt_UserName').html($('#hidUserName').val());
        $('#txt_Date').html($('#hidDate').val());
        var fileArry = [];
        var readArry = [];
        $(function () {
            $('.upload').on('click', function () {
                $('.upload_file').click();
            })


            $("#fileToUpload").on("change", function () {
                ajaxFileUpload($(this));
            })

           
           
            if ($('#hidOperator').val() == "edit")
            {
                getdate();
            }
           

        })


        function getdate()
        {
            $.ajax({
                type: "Post",
                url: WebServiceUrl + "/Order/Order.ashx",
                //async: false,
                dataType: "jsonp",
                jsonp: "jsoncallback",
                data: { "Id": $('#hidRId').val(), "action": "GetRepairDetailsNo" },
                success: function (json) {
                    if (json.result.Status != "no" || json.result.Status != "error") {
                        var dtJson = $.parseJSON(json.result.Data);
                        var ContraArry = dtJson.ds;
                        var ContraData = ContraArry[0];
                        $('#txt_Date').val(ContraData.RecordDate);
                        $('#te_Record').val(ContraData.Record);
                    } 

                },
                error: OnError
            });


            $.ajax({
                type: "Post",
                url: WebServiceUrl + "/Order/Order.ashx",
                //async: false,
                dataType: "jsonp",
                jsonp: "jsoncallback",
                data: { "Id": $('#hidRId').val(), "action": "GetRepairAttachment" },
                success: function (json) {
                    if (json.result.Status != "no" || json.result.Status != "error") {
                        var dtJson = $.parseJSON(json.result.Data);
                        for (var i = 0; i < dtJson.ds.length; i++) {
                            innerHTMLFile(dtJson.ds[i].AttachmentName, dtJson.ds[i].AttachmentPath);
                        }
                       // alert(dtJson.ds[0].AttachmentName);
                    }

                },
                error: OnError
            });


        }



        ///生成上传内容
        function innerHTMLFile(name, path) {

            fileArry.push(1);
            var html = '', i = fileArry.length, f = new Object();
            f.index = i;
            f.name = name;
            f.path = path;
            readArry.push(f);
            html = html + '<div id="uploadList_' + i + '" class="upload_append_list" number="' + i + '" ><p><strong><a href="' + path + '" target="_blank">' + name + '</a></strong>' +
                            '<a href="javascript:" class="upload_delete" title="删除" data-index="' + i + '" onclick="delFile(this)">删除</a><br /></div>';
            $("#preview").append(html);
        }



        //上传
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



        ///保存记录以及附件
        function AddDetails() {
            var Date = $("#txt_Date").html().trim();
            var Record = $("#te_Record").val().trim();
            $.ajax({
                type: "Post",
                url: WebServiceUrl + "/Order/Order.ashx",//random" + Math.random(),//方法所在页面和方法名
                //async: false,
                dataType: "jsonp",
                jsonp: "jsoncallback",
                data: {
                    "Record": Record,
                    "Date": Date,
                    "id": $("#hidId").val(),
                    "Operator": $("#hidOperator").val(),
                    "fileJson": JSON.stringify(readArry),
                    "RID": $("#hidRId").val(),
                    "action": "AddRepairDetails"
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
                        parent.GetRepairDetails();
                    }
                    parent.CloseIFrameWindow();
                },
                error: OnError
            });
        }

        function OnError(XMLHttpRequest, textStatus, errorThrown) {
            //layer.msg("加载失败");
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
    </script>
</body>
</html>

















