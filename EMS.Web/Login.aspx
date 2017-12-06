<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="EMS.Web.Login" %>
<!DOCTYPE html>
<html lang="en" xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8" />
    <title>资产管理系统</title>
    <link type="text/css" rel="stylesheet" href="css/layout.css" />
    <link type="text/css" rel="stylesheet" href="css/reset.css" />
    <script type="text/javascript" src="js/jquery-1.11.2.min.js"></script>
    <script src="/js/Validform_v5.3.1.js"></script>
    <script src="/js/layer/layer.js"></script>
    <script src="/js/md5.js"></script>
    <script src="/js/tab.js" type="text/javascript"></script>
    <script src="/js/Common.js"></script>
    <script src="/js/jquery.cookie.js"></script>
    <style type="text/css">
        .Validform_checktip{display:block;line-height:25px;font-size:15px;color:#fff;text-indent:45px;}
        .Validform_wrong{color:red;}
        .Validform_right{color:#91c954;}
        .code {
            background-image: url(w1.jpg);
            font-family: Arial;
            font-style: italic;
            color: Red;
            border: 0;
            padding: 2px 3px;
            letter-spacing: 3px;
            font-weight: bolder;
        }
    </style>
</head>
<body>
    <input type="hidden" id="hidPreUrl" runat="server" />
    <!--- -->
    <div class="wrap">
        <div class="top_top">
            <div class="top_top_con">
                <h1 class="main">资产管理系统</h1>
            </div>
        </div>
        <div class="Login main">
            <div class="login_con">
                <h1>系统登录</h1>
                <div class="form">
                    <form id="loginform" name="loginform" runat="server">
                        <ul id="sortable1" class="con">
                            <li class="xian"><span class="icon">
                                <img src="images/people.png" /></span><input id="txt_loginName" type="text" class="kuang" placeholder="请输入用户名"  datatype="*" nullmsg="请输入用户名！"/></li>
                            <li class="xian"><span class="icon">
                                <img src="images/password.png" /></span><input id="txt_passWord" type="password" class="kuang" placeholder="请输入密码" datatype="*" nullmsg="请输入密码"/></li>
                            <li class="yzm xian"><span class="icon">
                                <img src="images/yzm.png" /></span><input type="hidden" id="hidCode" name="hidCode" />
                                <input id="inpCode" type="text" class="kuang1" style="ime-mode:disabled" placeholder="请输入验证码" datatype="iCode" nullmsg="请输入验证码！" errormsg="验证码输入错误！"/>
                                <span id="checkCode" class="yzmtu" onclick="createCode()"></span>
                            </li>
                            <li>
                                <span class="btn">
                                    <input id="BtnLogin" type="button" class="btn_btn" value="登录" onclick="Login()" />
                                </span>
                            </li>
                        </ul>
                        <div class="clear"></div>
                    </form>
                </div>
            </div>
        </div>
    </div>
</body>
<script type="text/javascript">
    $(function () {
        var loadIndex = layer.load(1, {
            shade: [0.8, '#393D49'], //0.1透明度的白色背景
        });
        createCode();
        GetSysToken();
        //加载验证码

        //回车提交事件
        $("body").keydown(function () {
            if (event.keyCode == "13") {//keyCode=13是回车键
                $("#BtnLogin").click();
            }
        });

        var valiNewForm = $("#loginform").Validform({
            datatype: {
                "iCode": function (gets, obj, curform, regxp) {
                    /*参数gets是获取到的表单元素值，
                      obj为当前表单元素，
                      curform为当前验证的表单，
                      regxp为内置的一些正则表达式的引用。*/
                    var reg1 = regxp["*"];

                    var hidcode = curform.find("#hidCode");
                    if (reg1.test(gets)) { if (hidcode.val().toUpperCase() == gets.toUpperCase()) { return true; } }
                    return false;
                }
            },
            ajaxPost: true,
            btnSubmit: "#BtnLogin",
            tiptype: 3,
            showAllError: false,
            beforeSubmit: function (curform) {
                //在验证成功后，表单提交前执行的函数，curform参数是当前表单对象。
                //这里明确return false的话表单将不会提交;	
                Login();
            }
        })
    });
    function GetSysToken() {
        //var userInfo = "{\"Id\":7,\"UniqueNo\":\"啊发生\",\"UserType\":3,\"Name\":\"唐\",\"Nickname\":\"唐\",\"Sex\":1,\"Phone\":\"\",\"Birthday\":\"2016-09-29\",\"LoginName\":\"tang\",\"IDCard\":\"140481199805263255\",\"HeadPic\":\"\",\"RegisterOrg\":\"1001\",\"AuthenType\":0,\"Address\":\"\",\"Remarks\":\"\",\"CreateUID\":\"\",\"CreateTime\":\"2016-09-29 11:12:47\",\"EditUID\":null,\"EditTime\":null,\"IsEnable\":1,\"IsDelete\":0}";
        //$.cookie('TokenID', "e90bd89c594744c0b15d916a22b8ae92", { path: '/', secure: false });
        //$.cookie('LoginCookie_Author', userInfo, { path: '/', secure: false });
        if ($.cookie('TokenID') != null && $.cookie('TokenID') != "null" && $.cookie('TokenID') != "")
            GetUserInfoByToken($.cookie('TokenID'));
        else if ($.cookie('LoginCookie_Author') != null && $.cookie('LoginCookie_Author') != "null" && $.cookie('LoginCookie_Author') != "") {
            layer.closeAll('loading');
            var item = JSON.parse($.cookie('LoginCookie_Author'));
            if (item.LoginName != "") $("#txt_loginName").val(item.LoginName);
            if ($.cookie('RememberCookie_Cube') != null && $.cookie('RememberCookie_Cube') != "null" && $.cookie('RememberCookie_Cube') != "") {
                if (item.Password != "") $("#txt_passWord").val($.cookie('RememberCookie_Cube'));
                $("#rem_paddword").prop("checked", true);
            }
        }
        else
            layer.closeAll('loading');
    }


    var code; //在全局 定义验证码
    function createCode() {
        code = "";
        var codeLength = 4;//验证码的长度
        var checkCode = document.getElementById("checkCode");
        checkCode.innerHTML = "";
        var selectChar = new Array(1, 2, 3, 4, 5, 6, 7, 8, 9, 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'j', 'k', 'l', 'm', 'n', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'J', 'K', 'L', 'M', 'N', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z');

        for (var i = 0; i < codeLength; i++) {
            var charIndex = Math.floor(Math.random() * 60);
            code += selectChar[charIndex];
        }
        if (code.length != codeLength) {
            createCode();
        }
        checkCode.innerHTML = code;
        $("#hidCode").val(code);
        $("#inpCode").val(code);
    }

    function Login() {
        var loginName = $("#txt_loginName").val();
        var passWord = $("#txt_passWord").val();
        layer.load(1, {
            shade: [0.8, '#393D49'], //0.1透明度的白色背景
        });

        /******************************统一认证登录*************************************/

           var postData = { Func: "Login", userName: loginName, password: hex_md5(passWord), returnUrl: window.location.href };
            $.ajax({
                type: "Post",
                url: '<%=TokenPath%>',
                data: postData,
                dataType: "jsonp",
                jsonp: "jsoncallback",
                success: function (returnVal) {
                    var result = returnVal.result;
                    GetUserInfoByToken(result);

                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    layer.closeAll('loading');
                    //console.log(errorThrown);
                }
            });


             <%--$.ajax({
                url: "/CommonHandler/UnifiedHelpHandler.ashx",
                async: false,
                type: "Post",
                dataType: "json",
                data: { "Func": "Login", "loginName": loginName, "passWord": passWord },
                success: OnSuccessLogin,
                error: OnErrorLogin

            });
            return false;--%>
        }

        function GetUserInfoByToken(tokenID) {
            if (tokenID != "") {
                var postData = { Func: "GetUserInfoByToken", tokenID: tokenID, returnUrl: window.location.href };
                $.ajax({
                    type: "Post",
                    url: '<%=TokenPath%>',
                    data: postData,
                    dataType: "jsonp",
                    jsonp: "jsoncallback",
                    success: function (returnVal) {
                        var flg = returnVal.result;
                        if (flg != null) {
                            if (flg.errNum == 0) {
                                var item = flg.retData;
                                $.cookie('TokenID', tokenID, { path: '/', secure: false });
                                if (item.CreateTime != null) item.CreateTime = DateTimeConvert(item.CreateTime);
                                if (item.EditTime != null) item.EditTime = DateTimeConvert(item.EditTime);
                                if (item.Birthday != null) item.Birthday = DateTimeConvert(item.Birthday);
                                $.cookie('LoginCookie_Author', JSON.stringify(item), { expires: 7, path: '/', secure: false });
                                if ($("#rem_paddword").is(":checked")) $.cookie('RememberCookie_Cube', $("#txt_passWord").val(), { expires: 7, path: '/', secure: false });
                                if ($("#hidPreUrl").val() != "" && ($("#hidPreUrl").val().toLocaleLowerCase().indexOf("login.aspx") == -1 || $("#hidPreUrl").val().toLocaleLowerCase().indexOf("register.aspx") == -1)) window.location = $("#hidPreUrl").val();
                                else window.location = "/Index.aspx";
                            } else {
                                layer.msg(flg.errMsg);
                            }
                        }
                        layer.closeAll('loading');
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        layer.closeAll('loading');
                        //console.log(errorThrown);
                    }
                });
            }
        }
        function OnSuccessLogin(json) {
            layer.closeAll('loading');
            var cookie = json.result;
            if (cookie.errNum == "0") {
                var str = cookie.retData[0];
                if (str != "" && str.length > 0) {
                    var items = JSON.parse(cookie.retData[0]);
                    if (items != null && items.data.length > 0) {
                        var item = items.data;
                        $.cookie('LoginCookie_Author', JSON.stringify(item[0]), { expires: 7, path: '/', secure: false });
                        if ($("#rem_paddword").is(":checked")) $.cookie('RememberCookie_Cube', $("#txt_passWord").val(), { expires: 7, path: '/', secure: false });
                        if ($("#hidPreUrl").val() != "" && ($("#hidPreUrl").val().toLocaleLowerCase().indexOf("login.aspx") == -1 || $("#hidPreUrl").val().toLocaleLowerCase().indexOf("register.aspx") == -1)) window.location = $("#hidPreUrl").val();
                        else window.location = "/Index.aspx";
                        return;
                    }
                }
                layer.msg("用户名或密码错误！");

            } else if (cookie.errNum == "333") {
                layer.msg("帐号已被禁用请联系管理员！");
            } else if (cookie.errNum == "444") {
                layer.msg("帐号已被删除请重新注册！");
            } else if (cookie.errNum == "999") {
                layer.msg("用户名或密码错误！");
            }
            else {
                layer.msg(json.result.errMsg + "！");
            }
        }
        function OnErrorLogin(XMLHttpRequest, textStatus, errorThrown) {
            layer.msg("用户名或密码错误！" + errorThrown);
        }
</script>
</html>
