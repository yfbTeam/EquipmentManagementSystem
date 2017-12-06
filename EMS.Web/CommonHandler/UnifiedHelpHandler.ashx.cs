using EmsModel;
using DBUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EMS.Web.CommonHandler
{
    /// <summary>
    /// UnifiedHelpHandler 的摘要说明
    /// </summary>
    public class UnifiedHelpHandler : IHttpHandler
    {
        string sysAccountNo = ConfigHelper.GetConfigString("SysAccountNo");
        string u_handlerUrl = ConfigHelper.GetConfigString("Unified_HandlerUrl").SafeToString();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string func = context.Request["Func"];
            if (!string.IsNullOrEmpty(func))
            {
                try
                {
                    switch (func)
                    {
                        case "Login":
                            Login(context);
                            break;
                        case "GetUserInfoData":
                            GetUserInfoData(context);
                            break;
                        case "GetStudySectionData":
                            GetStudySectionData(context);
                            break;
                        default:
                            break;
                    }
                }
                catch (Exception ex)
                {
                    LogService.WriteErrorLog(ex.Message);
                }
            }
        }
        #region 登录
        private void Login(HttpContext context)
        {
            string urlHead = u_handlerUrl + "/UserManage/UserInfo.ashx?";
            string loginName = context.Request["loginName"].SafeToString();
            string passWord = context.Request["passWord"].SafeToString();
            string urlbady = "Func=Login&SysAccountNo=" + sysAccountNo + "&loginName=" + loginName + "&passWord=" + passWord;
            string PageUrl = urlHead + urlbady;
            string result = NetHelper.RequestPostUrl(PageUrl, urlbady);
            context.Response.Write(result);
            context.Response.End();
        }
        #endregion

        #region 获取学生信息
        private void GetUserInfoData(HttpContext context)
        {
            string urlHead = u_handlerUrl + "/UserManage/UserInfo.ashx?";
            string urlbady = "Func=GetData&SysAccountNo=" + sysAccountNo;
            if (!string.IsNullOrEmpty(context.Request["Ispage"]))
            {
                urlbady += "&PageIndex=" + (context.Request["PageIndex"] ?? "1") + "&PageSize=" + (context.Request["PageSize"] ?? "10");
            }
            else
            {
                urlbady += "&Ispage=false";
            }
            string isStu = context.Request["IsStu"] ?? ""; //true 为学生；false 为老师；空为全部
            string AcademicId = context.Request["Type"] ?? "0";
            if (!string.IsNullOrEmpty(isStu))
            {
                urlbady += "&IsStu=" + isStu + "&AcademicId=" + AcademicId;
            }
            if (!string.IsNullOrEmpty(context.Request["UniqueNos"]))
            {
                urlbady += "&UniqueNo=" + context.Request["UniqueNos"];
            }
            if (!string.IsNullOrEmpty(context.Request["JoinNoConn"]))
            {
                urlbady += "&JoinNoConn=" + context.Request["JoinNoConn"];
            }
            if (!string.IsNullOrEmpty(context.Request["Name"]))
            {
                urlbady += "&Name=" + context.Request["Name"].SafeToString();
            }
            if (!string.IsNullOrEmpty(context.Request["KaNo"]))
            {
                urlbady += "&KaNo=" + context.Request["KaNo"].SafeToString();
            }
            string PageUrl = urlHead + urlbady;
            string result = NetHelper.RequestPostUrl(PageUrl, urlbady);
            context.Response.Write(result);
            context.Response.End();
        }
        #endregion

        #region 获取学年学期
        private void GetStudySectionData(HttpContext context)
        {
            string urlHead = u_handlerUrl + "/EduManage/StudySection.ashx?";
            string urlbady = "Func=GetData&SysAccountNo=" + sysAccountNo;
            if (!string.IsNullOrEmpty(context.Request["Ispage"]))
            {
                urlbady += "&PageIndex=" + (context.Request["PageIndex"] ?? "1") + "&PageSize=" + (context.Request["PageSize"] ?? "10");
            }
            else
            {
                urlbady += "&Ispage=false";
            }
            if (!string.IsNullOrEmpty(context.Request["ID"]))
            {
                urlbady += "&ID="+ context.Request["ID"];
            }
            urlbady += "&Status=" + context.Request["Status"] ?? "0";
            string PageUrl = urlHead + urlbady;
            string result = NetHelper.RequestPostUrl(PageUrl, urlbady);
            context.Response.Write(result);
            context.Response.End();
        }
        #endregion
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}