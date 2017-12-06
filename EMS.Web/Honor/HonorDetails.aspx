<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HonorDetails.aspx.cs" Inherits="EMS.Web.Honor.HonorDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>绩效详情</title>
    <link href="../css/common.css" rel="stylesheet" />
    <link href="../css/style.css" rel="stylesheet" />
    <link href="../css/iconfont.css" rel="stylesheet" />
    <link href="../css/animate.css" rel="stylesheet" />
    <script src="../js/Common.js"></script>
    <script src="../js/jquery-1.11.2.min.js"></script>
    <script src="../js/jquery.tmpl.js"></script>
    <script src="../js/layer/layer.js"></script>
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
									 <%--<form>--%>
										   <table class="m_top">
											  <tbody><tr>
												<td class="mi"><span class="m">绩效名称：</span></td>
                                                  <td class="ku"><span id="Name"></span></td>
											  </tr> 
											   <tr>
												<td class="mi"><span class="m">级别：</span></td>
												<td class="ku">  
														<span id="HonorLevel"></span><br />
												</td>
											  </tr>
                                                  <tr>
												<td class="mi"><span class="m">实验：</span></td>
												<td class="ku">  
														<span id="ExperimentName"></span><br />
												</td>
											  </tr>
                                              <tr>
												<td class="mi"><span class="m">创建时间：</span></td>
                                                  <td class="ku"><span id="CreateTime"></span></td>
											  </tr> 
											</tbody></table> 									 
									 
									 <%--</form>--%>
								</div>
								
							</div>
							<div class="submit_btn">
								<span class="cancel"><input class="Topic_btn" type="button" value="返回" onclick="javascript: parent.CloseIFrameWindow();"/></span>
							 </div>
					</div>				
				</div>
			</div>		
		</div>
	</div>
        <asp:HiddenField ID="hidId" runat="server" />
        <script type="text/javascript">
            var Id = $('#hidId').val();
            $(document).ready(function () {
                GetHonor();
            });
            //获得教学计划
            function GetHonor() {
                $.ajax({
                    type: "Post",
                    url: WebServiceUrl + "/Honor/Honor.ashx",
                    //async: false,
                    dataType: "jsonp",
                    jsonp: "jsoncallback",
                    data: { "Id": Id, "action": "GetHonor" },
                    success: function (json) {
                        if (json.result.Status == "error") {
                            //layer.msg(json.result.Msg);
                            return;
                        }
                        if (json.result.Status == "no") {
                            //layer.msg(json.result.Msg);
                            return;
                        }
                        if (json.result.Status == "ok") {
                            Honor = json.result.Data.PagedData[0];
                            $('#Name').html(Honor.Name);
                            $('#CreateTime').html(DateTimeConvert(Honor.CreateTime, "yyyy-MM-dd HH:mm:ss"));
                            $('#HonorLevel').html(Honor.LevelName);
                            $('#ExperimentName').html(Honor.ExperimentName);
                        }
                    },
                    error: function OnError(XMLHttpRequest, textStatus, errorThrown) {
                        //layer.msg(json.result.Msg);
                    }
                });
            }
        </script>
    </form>
</body>
</html>
