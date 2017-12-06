<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BorrowAndAlso.aspx.cs" Inherits="EMS.Web.Order.BorrowAndAlso" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link type="text/css" rel="stylesheet" href="../css/style.css" />
    <link type="text/css" rel="stylesheet" href="../css/common.css" />
    <link type="text/css" rel="stylesheet" href="../css/iconfont.css" />
    <link type="text/css" rel="stylesheet" href="../css/animate.css" />
    <script type="text/javascript" src="../js/jquery-1.11.2.min.js"></script>
    <script type="text/javascript" src="../js/tz_slider.js"></script>
    <script src="../js/Common.js"></script>
    <script src="../js/jquery.tmpl.js"></script>
    <script src="../js/PageBar.js"></script>
    <script src="/js/layer/layer.js"></script>
    <style>
        .Lend0 {
            display: block;
        }

        .Escheat0 {
            display: none;
        }

        .Lend1 {
            display: block;
        }

        .Escheat1 {
            display: none;
        }

        .Lend2 {
            display: none;
        }

        .Escheat2 {
            display: block;
        }

        .Lend3 {
            display: none;
        }

        .Escheat3 {
            display: block;
        }

        .Lend4 {
            display: none;
        }

        .Escheat4 {
            display: none;
        }

        .ok0 {
            display: none;
        }

        .ok1 {
            display: none;
        }

        .ok2 {
            display: none;
        }

        .ok3 {
            display: none;
        }

        .ok4 {
            display: block;
        }
    </style>
    <script>
        //根据Status字段转换
        function GetStatus(Status) {
            var strStatus = "";
            switch (Status) {
                case 0:
                    strStatus = "未借出";
                    break
                case 1:
                    strStatus = "部分借出";
                    break
                case 2:
                    strStatus = "已借出";
                    break
                case 3:
                    strStatus = "部分归还";
                    break
                case 4:
                    strStatus = "完成";
                    break
                default:

            }
            return strStatus;
        }

    </script>
</head>
<script id="trTemp" type="text/x-jquery-tmpl">
    <tr>
        <td class="">${pageIndex()}</td>
        <td class="">${Name}</td>
        <td class="">${CName}</td>
        <td class="">${DateTimeConvert(StartDate)}</td>
        <%--<td class="">${LoanName}</td>--%>
        <td class="">${stuLoanName}</td>
        <td>
            <span class="ok${isStatus}">
                <input type="button" class="Topic_btn" value="已完成归还" /></span>
            <span class="Lend${isStatus}">
                <input type="button" class="Topic_btn" onclick="javascript: Lend('${Id}', '${orderID}')" value="借出" /></span>
            <span class="Escheat${isStatus}">
                <input type="button" class="Topic_btn" onclick="javascript: Escheat('${Id}', '${orderID}')" value="归还" />
            </span>
        </td>
    </tr>

</script>
<body>
    <form id="form1">
        <div>
            <div class="Teaching_plan_management">
                <h1 class="Page_name"><span class="fl">借还管理</span> <a href="Calendar_Lend.aspx" class="all_select fr"><span class="visited_xz">列表视图</span><span class="moren_wxz">日历视图</span></a></h1>
                <div class="clear"></div>
                <div class="Operation_area">
                    <div class="left_choice fl">
                        <ul>
                            <input type="hidden" name="search_w" class="search_w" value="" id="UserLoginName" />
                            <input type="hidden" name="search_w" class="search_w" value="" id="stuIDCard" />


                            <li class="Lab">教师一卡通号：&nbsp&nbsp
                                <input type="" name="search_w" class="search_w" placeholder="请刷卡" value="" id="KaNo" />
                            </li>
                            <li class="Lab">教师姓名：&nbsp&nbsp
                                <input type="" name="search_w" class="search_w" placeholder="请刷卡" value="" id="UserName">
                            </li>
                            <br />

                            <li class="Lab">学生一卡通号：&nbsp&nbsp
                                <input type="" name="search_w" class="search_w" placeholder="请刷卡" value="" id="stuKaNo" />
                            </li>
                            <li class="Lab">学生姓名：&nbsp&nbsp
                                <input type="" name="search_w" class="search_w" placeholder="请刷卡" value="" id="stuUserName">
                            </li>

                            <%--<li class="Select">
                                &nbsp&nbsp&nbsp&nbsp&nbsp
                                订单操作类型：
								<select id="sel" class="option">
									<option value="-1">全部</option>
									<option value="1">借出</option>
                                    <option value="2">归还</option>
								</select>
							</li>--%>
                            <%--<li class="Sear"><a class="sea" href="#">搜索</a></li>--%>
                        </ul>
                    </div>
                    <div class="right_add fr">
                        <a id="test123" class="add" href="NewOrder.aspx"><i class="iconfont">&#xe726;</i>新建订单</a>
                    </div>
                </div>
                <div class="Honor_management">
                    <table class="W_form" id="tbList" cellspacing="0">
                        <thead>
                            <tr class="trth">
                                <%--<th class="checkbox"><input type="checkbox"></th>--%>
                                <th class="number">序号</th>
                                <th class="Project_name">实验名称</th>
                                <th class="">主讲教师</th>
                                <th class="">使用时间</th>
                                <th class=" ">学生组长</th>
                                <th>操作</th>
                            </tr>
                        </thead>
                        <tr>
                            <td colspan="10">
                                <h1 style="color: red">请刷卡，刷卡后将显示借还数据。</h1>
                            </td>
                        </tr>
                        <tbody>
                        </tbody>
                    </table>

                </div>

                <!--分页页码开始-->
                <div class="paging">
                    <span id="pageBar"></span>
                </div>

                <!--分页页码结束-->
            </div>

        </div>
    </form>
</body>


<script type="text/javascript">
    var num = "";
    tka = "";
    ska = "";
    ka = "";
    $(document).ready(function () {

        document.onkeydown = function (event) {
            var e = event || window.event || arguments.callee.caller.arguments[0];

            switch (event.which) {
                case 49:
                    num += "1";
                    break;
                case 50:
                    num += "2";
                    break;
                case 51:
                    num += "3";
                    break;
                case 52:
                    num += "4";
                    break;
                case 53:
                    num += "5";
                    break;
                case 54:
                    num += "6";
                    break;
                case 55:
                    num += "7";
                    break;
                case 56:
                    num += "8";
                    break;
                case 57:
                    num += "9";
                    break;
                case 48:
                    num += "0";
                    break;
                default:

            }

            if (e && e.keyCode == 13) { // enter 键
                //禁用回车刷新
                e.preventDefault();
                //获取数据
                // alert(num);
                if (num.length > 3) {
                    ka = num;
                    getUserByKaNo(num);
                }
                //清空 纪录
                num = "";

            }
        };

    });
    //获取数据
    function getData(startIndex, KaNo, stuKaNo, Status) {
        $.ajax({
            url: WebServiceUrl + "/Order/Order.ashx",//random" + Math.random(),//方法所在页面和方法名
            async: false,
            dataType: "jsonp",
            jsonp: "jsoncallback",
            data: { "startIndex": startIndex, "KaNo": KaNo, "stuKaNo": stuKaNo, "Status": Status, "pageSize": 10, "action": "GetDatePageNEW" },
            success: OnSuccessGetData,
            error: OnErrorGetData
        });
    }
    function OnSuccessGetData(json) {
        if (json.toString() == null) {
            $("#tbList tbody").html('');
            $("#tbList tbody").html('<tr><td colspan="100"  style="text-align:center;">无内容</td></tr>');
        } else if (json.result.Status == "no") {
            $("#tbList tbody").html('');
            $("#tbList tbody").html('<tr><td colspan="100"  style="text-align:center;">无内容</td></tr>');
        }

        else {
            $("#tbList tbody").html('');
            $("#trTemp").tmpl(json.result.Data.PagedData).appendTo("#tbList");
            //隔行变色以及鼠标移动高亮
            $(".main-bd table tbody tr").mouseover(function () {
                $(this).addClass("over");
            }).mouseout(function () {
                $(this).removeClass("over");
            })
            $(".main-bd table tbody tr:odd").addClass("alt");
            //生成页码条方法（方法对象,页码条容器，当前页码，总页数，页码组容量，总行数）
            makePageBar(getData, document.getElementById("pageBar"), json.result.Data.PageIndex, json.result.Data.PageCount, 8, json.result.Data.RowCount, document.getElementById("dataTable1_info"));

        }
    }
    function OnErrorGetData(XMLHttpRequest, textStatus, errorThrown) {
        $("#tbList tbody").html('<tr><td colspan="100"  style="text-align:center;">无内容</td></tr>');
    }


    //以卡号获取用户数据
    function getUserByKaNo(KaNo) {
        ka = KaNo;
        $.ajax({
            url: "/CommonHandler/UnifiedHelpHandler.ashx",
            type: "post",
            async: false,
            dataType: "json",
            data: {
                Func: "GetUserInfoData",
                IsStu: false,
                KaNo: ka
            },
            success: function (json) {               
                if (json.result.errNum.toString() == "0") {
                    var usermodel = json.result.retData[0];
                    if (usermodel.UserType == 2) {
                        ska = ka;
                        $("#stuKaNo").val(ka); ka = "";
                        $("#stuUserName").val(usermodel.Name);
                        $("#stuIDCard").val(usermodel.UniqueNo);
                        if ($("#UserLoginName").val() == "") {
                            getData("1", "", usermodel.UniqueNo, $("#sel").val());
                        }
                    } else {
                        tka = ka;
                        $("#KaNo").val(ka); ka = "";
                        $("#UserName").val(usermodel.Name);
                        $("#UserLoginName").val(usermodel.UniqueNo);
                        getData("1", usermodel.UniqueNo,"", $("#sel").val());
                    }                                       
                } else if (json.result.errNum.toString() == "999") {
                    //新增学生信息
                    OpenIFrameWindow('新增学生', '/SystemSettings/StudentEdit.aspx?kano=' + ka, '620px', '380px');
                }                
            }
        });
    }    
    //
    function Lend(id, orderNo) {
        location.href = "NewOrder.aspx?id=" + id + "&orderNo=" + orderNo + "&IDCard=" + $("#UserLoginName").val() + "&stuIDCard=" + $("#stuIDCard").val();
    }

    function Escheat(id, orderNo) {

        location.href = "Escheat.aspx?id=" + id + "&orderNo=" + orderNo;
    }

</script>

</html>
