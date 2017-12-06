<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EquipEdit.aspx.cs" Inherits="EMS.Web.Statistical.EquipEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>编辑设备</title>
    <link href="../css/common.css" rel="stylesheet" />
    <link href="../css/style.css" rel="stylesheet" />
    <link href="../css/iconfont.css" rel="stylesheet" />
    <link href="../css/animate.css" rel="stylesheet" />

    <script src="../js/Common.js"></script>
    <script src="../js/jquery-1.11.2.min.js"></script>
    <script src="../js/jquery.tmpl.js"></script>
    <script src="../js/layer/layer.js"></script>
    <script src="../js/ajaxfileupload.js"></script>
    <style type="text/css">
        .PlanMust {
            color: red;
        }

        .Poto {
            width: 100%;
            height: 100%;
        }

        .divimg {
            border: 1px solid #ccc;
        }

        .shangchuan {
            width: 200px;
            height: 140px;
            float: left;
            margin-right: 5px;
        }

        .shgnchuantop {
            border: 1px solid #d0d0d0;
            height: 108px;
        }

            .shgnchuantop img {
                width: 198px;
                height: 108px;
                display: inline;
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

        /*.ui-upload-input {
            position: absolute;
            top: 0px;
            right: 0px;
            height: 100%;
            cursor: pointer;
            opacity: 0;
            filter: alpha(opacity:0);
            z-index: 999;
            font-size: 100px;
        }*/

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

        .m_top {
            overflow: hidden;
        }

            .m_top li {
                overflow: hidden;
            }

                .m_top li .mi {
                    width: 132px;
                    font-size: 14px;
                    line-height: 30px;
                    padding: 7px 0;
                    float: left;
                    text-align: right;
                }

                .m_top li .ku {
                    width: 205px;
                    font-size: 14px;
                    line-height: 30px;
                    padding: 7px 0;
                    float: left;
                    margin-left: 10px;
                }

                    .m_top li .ku input {
                        height: 30px;
                        width: 180px;
                        padding: 0 10px;
                        border-radius: 3px;
                        border: 1px solid #999;
                    }

                .m_top li .ku1 textarea {
                    border: 1px solid #999;
                    border-radius: 3px;
                    color: #999;
                    width: 400px;
                }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="yy_dialog">
            <div class="t_content">
                <div class="yy_tab">
                    <div class="content">
                        <div class="tc">
                            <div class="t_message">
                                <div class="message_con">
                                    <ul class="m_top">
                                        <li>
                                            <div class="mi"><span class="PlanMust">*</span><span class="m">资产号：</span></div>
                                            <div class="ku">
                                                <span>
                                                    <label id="AssetNumber"></label>
                                                </span>
                                                <%--<input id="AssetNumber" class="hu" type="text" disabled="disabled">--%>
                                            </div>
                                            <div class="mi"><span class="PlanMust">*</span><span class="m">资产名称：</span></div>
                                            <div class="ku">
                                                <input id="AssetName" class="hu" type="text">
                                            </div>
                                        </li>
                                        <li>
                                            <div style="width: 347px; float: left">
                                                <div class="mi"><span class="m">上传附件：</span></div>
                                                <div class="ku">
                                                    <div class="shangchuan">
                                                        <div class="shgnchuantop" id="imgshow1">
                                                            <img src="../images/fpsc.jpg">
                                                        </div>
                                                        <div class="shgnchuanbottom">
                                                            <div class="ui-upload-holder">
                                                                <div class="ui-upload-txt upload">
                                                                    点击上传
															
                                                                </div>
                                                                <input id="fileToUpload" type="file" size="45" name="fileToUpload" class="upload_file input ui-upload-input bluebutton dianjisc">
                                                            </div>
                                                        </div>
                                                        <div id="divUpload" class="hidden">
                                                            <img id="loading" src="../images/ajaxfileloading.gif" class="hidden">
                                                        </div>
                                                    </div>
                                                </div>
                                                <script>
                                                    $(function () {
                                                        $('.upload').on('click', function () {
                                                            $('.upload_file').click();
                                                        })
                                                    })
                                                </script>
                                                <div class="mi"></div>
                                                <div class="ku">
                                                    <div class="shgnchuanbottom">
                                                        <div class="ui-upload-holder">
                                                            <div class="ui-upload-txt">
                                                                <a target="_blank" href="../iamges/fpsc.jpg" class="lockPreImg" style="color: #fff; display: block; width: 100%; height: 16px;">点击浏览原图</a>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div style="width: 347px; float: left">
                                                <div class="mi"><span class="m">分类号：</span></div>
                                                <div class="ku">
                                                    <input id="ClassNumber" class="hu" type="text">
                                                </div>
                                                <div class="mi"><span class="m">国际分类代码：</span></div>
                                                <div class="ku">
                                                    <input id="IntlClassCode" class="hu" type="text">
                                                </div>
                                                <div class="mi"><span class="m">计量单位：</span></div>
                                                <div class="ku">
                                                    <input id="Unit" class="hu" type="text">
                                                </div>
                                                <div class="mi"><span class="m">使用方向：</span></div>
                                                <div class="ku">
                                                    <input id="UsageDirection" class="hu" type="text">
                                                </div>
                                            </div>
                                        </li>
                                        <li>
                                            <div class="mi"><span class="m">类别：</span></div>
                                            <div class="ku">
                                                <select class="option" id="Type">
                                                    <option value="0">教学设备</option>
                                                    <option value="1">科研设备</option>
                                                    <option value="2">办公设备</option>
                                                </select>
                                            </div>
                                            <div class="mi"><span class="m">资产分类名称：</span></div>
                                            <div class="ku">
                                                <input id="AssetsClassName" class="hu" type="text">
                                            </div>
                                        </li>

                                        <li>
                                            <div class="mi"><span class="m">国际分类名称：</span></div>
                                            <div class="ku">
                                                <input id="IntlClassName" class="hu" type="text">
                                            </div>
                                            <div class="mi"><span class="m">品牌及规格型号：</span></div>
                                            <div class="ku">
                                                <input id="BrandStandardModel" class="hu" type="text">
                                            </div>
                                        </li>
                                        <li>
                                            <div class="mi"><span class="m">备注：</span></div>
                                            <div class="ku ku1">
                                                <textarea id="Remarks" name="comment" rows="3" style="width: 543px;"></textarea>
                                            </div>
                                        </li>
                                    </ul>

                                </div>
                            </div>
                        </div>
                        <div class="submit_btn">
                            <span class="Save_and_submit">
                                <input class="Save_and_submit" type="button" value="确定" onclick="javascript: Save();" /></span>
                            <span class="cancel">
                                <input class="cancel" type="button" value="取消" onclick="javascript: parent.CloseIFrameWindow();" /></span>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <asp:HiddenField ID="hidUserIDCard" runat="server" />
        <asp:HiddenField ID="hidOriginalName" runat="server" />
        <asp:HiddenField ID="hidIsAdmin" runat="server" />
        <asp:HiddenField ID="hidUserName" runat="server" />
        <input name="fileImgName" id="fileImgName" type="hidden" />
        <input name="fileImgUrl" id="fileImgUrl" type="hidden" />
        <script type="text/javascript">
            var UrlDate = new GetUrlDate(); //实例化
            var htype = UrlDate.Type;
            var Id = UrlDate.Id;
            $(document).ready(function () {
                //$("#Upload").change(function () {
                //    Preview(this);
                //});
                $("#fileToUpload").on("change", function () {
                    ajaxFileUpload($(this));
                });
                $("#AssetNumber").attr("disabled", true);
                Load1();
            });
            function Load1() {
                if (htype == "Edit") {
                    GetEquip();
                }
            }
            //获得设备数据
            function GetEquip() {
                $.ajax({
                    type: "Post",
                    url: WebServiceUrl + "/Statistical/Statistical.ashx",//random" + Math.random(),//方法所在页面和方法名
                    async: false,
                    dataType: "jsonp",
                    jsonp: "jsoncallback",
                    data: { "Id": Id, "action": "GetEquip" },
                    success: function (json) {
                        if (json.result.Status == "error") {
                            //layer.msg(json.result.Msg);
                            return;
                        }
                        if (json.result.Status == "no") {
                            //layer.msg(json.result.Msg);
                            return;
                        }
                        Plan = json.result.Data;
                        $('#AssetNumber').html(Plan.AssetNumber);
                        $('#AssetName').val(Plan.AssetName);
                        $('#Type').val(Plan.Type);
                        $('#ClassNumber').val(Plan.ClassNumber);
                        $('#AssetsClassName').val(Plan.AssetsClassName);
                        $('#IntlClassCode').val(Plan.IntlClassCode);
                        $('#IntlClassName').val(Plan.IntlClassName);
                        $('#Unit').val(Plan.Unit);
                        $('#BrandStandardModel').val(Plan.BrandStandardModel);
                        $('#UsageDirection').val(Plan.UsageDirection);
                        $('#Remarks').val(Plan.Remarks);
                        if (Plan.ImageName.length > 0) {
                            $('#fileImgName').val(Plan.ImageName);
                            $("#fileImgUrl").val(Plan.ImageUrl);
                            $("#imgshow1>:first-child").attr("src", Plan.ImageUrl);
                            $(".lockPreImg").attr("href", Plan.ImageUrl);
                        }

                    },
                    error: OnError
                });

            }
            //新增课程
            function Add() {
                AssetNumber = $('#AssetNumber').val().trim();
                AssetName = $('#AssetName').val().trim();
                Type = $('#Type option:selected').val();
                ClassNumbe = $('#ClassNumbe').val().trim();
                AssetsClassName = $('#AssetsClassName').val().trim();
                IntlClassCode = $('#IntlClassCode').val();
                IntlClassName = $('#IntlClassName').val();
                Unit = $('#Unit').val();
                BrandStandardModel = $('#BrandStandardModel').val();
                UsageDirection = $('#UsageDirection').val();
                Remarks = $('#Remarks').val();
                UserIDCard = $('#hidUserIDCard').val();
                var ImageName = $("#fileImgName").val();
                var ImageUrl = $("#fileImgUrl").val();
                $.ajax({
                    type: "Post",
                    url: WebServiceUrl + "/Statistical/Statistical.ashx",//random" + Math.random(),//方法所在页面和方法名
                    //async: false,
                    dataType: "jsonp",
                    jsonp: "jsoncallback",
                    data: {
                        "AssetNumber": AssetNumber, "AssetName": AssetName, "Type": Type, "ClassNumbe": ClassNumbe
                        , "AssetsClassName": AssetsClassName, "IntlClassCode": IntlClassCode, "IntlClassName": IntlClassName
                        , "Unit": Unit, "BrandStandardModel": BrandStandardModel, "UsageDirection": UsageDirection, "Remarks": Remarks
                        , "UserIDCard": UserIDCard, "action": "AddEquip", "ImageName": ImageName, "ImageUrl": ImageUrl
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
                            ReturnUrl();

                        }
                    },
                    error: OnError
                });

            }
            //错误处理
            function OnError(XMLHttpRequest, textStatus, errorThrown) {
                //layer.msg("保存失败");
            }
            //修改课程
            function Update() {
                //AssetNumber = $('#AssetNumber').val().trim();
                AssetName = $('#AssetName').val().trim();
                Type = $('#Type option:selected').val();
                ClassNumber = $('#ClassNumber').val().trim();
                AssetsClassName = $('#AssetsClassName').val().trim();
                IntlClassCode = $('#IntlClassCode').val();
                IntlClassName = $('#IntlClassName').val();
                Unit = $('#Unit').val();
                BrandStandardModel = $('#BrandStandardModel').val();
                UsageDirection = $('#UsageDirection').val();
                Remarks = $('#Remarks').val();
                UserIDCard = $('#hidUserIDCard').val();
                var ImageName = $("#fileImgName").val();
                var ImageUrl = $("#fileImgUrl").val();
                $.ajax({
                    type: "Post",
                    url: WebServiceUrl + "/Statistical/Statistical.ashx",//random" + Math.random(),//方法所在页面和方法名
                    //async: false,
                    dataType: "jsonp",
                    jsonp: "jsoncallback",
                    data: {
                        "AssetName": AssetName, "Type": Type, "ClassNumber": ClassNumber
                        , "AssetsClassName": AssetsClassName, "IntlClassCode": IntlClassCode, "IntlClassName": IntlClassName
                        , "Unit": Unit, "BrandStandardModel": BrandStandardModel, "UsageDirection": UsageDirection, "Remarks": Remarks
                        , "UserIDCard": UserIDCard, "ID": Id, "action": "UpdateEquip", "ImageName": ImageName, "ImageUrl": ImageUrl
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
                            ReturnUrl();


                        }
                    },
                    error: OnError
                });

            }
            //保存
            function Save() {
                if (htype == "Edit") {
                    Update();
                } else if (htype == "Add") {
                    Add();
                }
            }
            //返回列表页
            function ReturnUrl() {
                //location.href = "PlanList.aspx";
                parent.GetList(1);
                parent.CloseIFrameWindow();

            }

            //展示图片
            function Preview(file) {
                var prevImg = document.getElementById("EquipImage");
                if (file.files && file.files[0]) {
                    var reader = new FileReader();
                    reader.onload = function (evt) {
                        prevImg.src = evt.target.result;
                    }
                    reader.readAsDataURL(file.files[0]);
                }
                else {
                    prevImg.style.display = "none";
                    var divImg = document.getElementById('EquipImage');
                    divImg.style.display = "block";
                    divImg.filters.item("DXImageTransform.Microsoft.AlphaImageLoader").src = file.value;
                }
            }


            function ajaxFileUpload(event) {
                var e = event ? event : (window.event ? window.event : null);
                var uploadId = $(e).attr("id");
                var upattr = $(e).attr("uploadattr");
                if (!/\.(JPEG|jpeg|JPG|jpg|BMP|bmp|PNG|png)$/.test($(e).val())) {
                    art.alert("图片类型必须是jpg,png,bmp中的一种！");
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
                        data: { action: "UploadFileForImg" },
                        success: function (data, status) {
                            if (data.result) {
                                $("#imgshow1>:first-child").attr("src", decodeURIComponent(data.path));
                                $(".lockPreImg").attr("href", decodeURIComponent(data.path));
                                $("#fileImgName").val(data.name);
                                $("#fileImgUrl").val(decodeURIComponent(data.path));
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
        </script>
    </form>
</body>
</html>
