using EmsModel;
using Newtonsoft.Json.Linq;
using DBUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace EMSHandler
{
    /// <summary>
    /// GetUserNameHandler 的摘要说明
    /// </summary>
    public class GetUserNameHandler : IHttpHandler
    {
        JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
        string sysAccountNo = ConfigHelper.GetConfigString("SysAccountNo");
        string u_handlerUrl = ConfigHelper.GetConfigString("Unified_HandlerUrl").SafeToString();
        public void ProcessRequest(HttpContext context)
        {

        }
        #region 为返回的数据添加用户姓名列
        /// <summary>
        /// 为返回的数据添加用户姓名列
        /// </summary>
        /// <param name="jsonModel">数据</param>
        /// <param name="type">type 0获取所有学生(默认)；1获取所有教师；2 根据UniqueNo获取用户；3 根据UniqueNo获取学生；4 获取所有用户信息</param>
        /// <param name="oneUserField">第一个需要返回用户姓名的列</param>
        /// <param name="uniqueNos">uniqueNos字符串,以逗号分隔，默认为空</param>
        /// <param name="twoUserField">第二个需要返回用户姓名的列</param>
        /// <param name="name">根据名称搜索</param>
        /// <param name="learnYearField">学年学期字段</param>
        /// <param name="AcademicId">默认0 当前学期； 历史学期 传学期id</param>
        /// <returns></returns>
        public JsonModel AddCreateNameForData(JsonModel jsonModel, int type = 0, string oneUserField = "CreateUID", string uniqueNos = "", string twoUserField = "", string name = "", string learnYearField = "", string AcademicId = "0")
        {
            if (jsonModel.Status == "ok")
            {
                List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
                List<Dictionary<string, object>> classList = new List<Dictionary<string, object>>();
                List<Dictionary<string, object>> learnYearList = new List<Dictionary<string, object>>();
                PagedDataModel<Dictionary<string, object>> pageModel = null;
                pageModel = jsonModel.Data as PagedDataModel<Dictionary<string, object>>;
                list = pageModel.PagedData as List<Dictionary<string, object>>;
                List<Dictionary<string, object>> allList = new List<Dictionary<string, object>>();
                allList = GetUnifiedUserData(type, uniqueNos, name, AcademicId);
                if (!string.IsNullOrEmpty(name))
                {
                    List<string> stuUniqueNo = (from dic in allList select dic["UniqueNo"].ToString()).ToList();
                    list = (from dic in list
                            where stuUniqueNo.Contains(dic[oneUserField].ToString())
                            select dic).ToList();
                }
                if (!string.IsNullOrEmpty(learnYearField))
                {
                    learnYearList = GetStudySectionData();
                }
                foreach (Dictionary<string, object> item in list)
                {
                    try
                    {
                        Dictionary<string, object> dicItem = (from dic in allList
                                                              where dic["UniqueNo"].ToString() == item[oneUserField].ToString()
                                                              select dic).FirstOrDefault();
                        item.Add("CreateName", dicItem == null ? "" : dicItem["Name"].ToString());
                        item.Add("OneLoginName", dicItem == null ? "" : dicItem["LoginName"].ToString());
                        item.Add("AbsHeadPic", dicItem == null ? "" : dicItem["AbsHeadPic"].ToString());
                        if (dicItem != null && dicItem.ContainsKey("OrgName"))
                        {
                            item.Add("OrgName", dicItem["OrgName"].ToString());
                        }
                        if (dicItem != null && dicItem.ContainsKey("GradeName"))
                        {
                            item.Add("GradeName", dicItem["GradeName"].ToString());
                        }
                        if (!string.IsNullOrEmpty(twoUserField))
                        {
                            Dictionary<string, object> dicItem_two = (from dic in allList
                                                                      where dic["UniqueNo"].ToString() == item[twoUserField].ToString()
                                                                      select dic).FirstOrDefault();
                            item.Add("TwoUserName", dicItem_two == null ? "" : dicItem_two["Name"].ToString());
                            item.Add("TwoAbsHeadPic", dicItem_two == null ? "" : dicItem_two["AbsHeadPic"].ToString());
                        }
                        if (!string.IsNullOrEmpty(learnYearField))
                        {
                            Dictionary<string, object> learnItem = (from dic in learnYearList
                                                                    where dic["Id"].ToString() == item[learnYearField].ToString()
                                                                    select dic).FirstOrDefault();
                            item.Add("LearnYearName", learnItem == null ? "" : learnItem["Academic"].ToString());
                            item.Add("StartDate", learnItem == null ? "" : learnItem["StartDate"].ToString());
                            item.Add("EndDate", learnItem == null ? "" : learnItem["EndDate"].ToString());
                        }
                    }
                    catch (Exception ex)
                    {
                        LogService.WriteErrorLog(ex.Message);
                    }

                }
                pageModel.PagedData = list;
                jsonModel.Data = pageModel;
            }
            return jsonModel;
        }
        #endregion

        #region 根据uniqueNo查找用户姓名    
        public string GetUserNameByUniqueNo(string uniqueNo)
        {
            string username = "";
            List<Dictionary<string, object>> allList = GetUnifiedUserData(4);
            Dictionary<string, object> dicItem = (from dic in allList
                                                  where dic["UniqueNo"].ToString() == uniqueNo
                                                  select dic).FirstOrDefault();
            if (dicItem != null)
            {
                username = dicItem["Name"].ToString();
            }
            return username;
        }
        #endregion

        #region 获取统一认证中心用户信息
        public List<Dictionary<string, object>> GetUnifiedUserData(int type, string uniqueNos = "", string name = "", string AcademicId = "0")
        {
            string urlHead = u_handlerUrl + "/UserManage/UserInfo.ashx?";
            string urlbady = "Func=GetData&SysAccountNo=" + sysAccountNo + "&Ispage=false";
            if (type == 0) //type 0获取所有学生(默认)；1获取所有教师；2 根据UniqueNo获取用户；3 根据UniqueNo获取学生；4 获取所有用户信息
            {
                urlbady += "&IsStu=true&AcademicId=" + AcademicId;
            }
            else if (type == 1)
            {
                urlbady += "&IsStu=false";
            }
            else if (type == 2)
            {
                if (!string.IsNullOrEmpty(uniqueNos))
                {
                    urlbady += "&UniqueNo=" + uniqueNos;
                }
            }
            else if (type == 3)
            {
                if (!string.IsNullOrEmpty(uniqueNos))
                {
                    urlbady += "&IsStu=true&UniqueNo=" + uniqueNos + "&AcademicId = " + AcademicId;
                }
            }
            else //全部用户
            {

            }
            if (!string.IsNullOrEmpty(name))
            {
                urlbady += "&Name=" + name;
            }
            string PageUrl = urlHead + urlbady;
            return AnalyticalReturnData(NetHelper.RequestPostUrl(PageUrl, urlbady));
        }
        #endregion

        #region 获取班级信息
        private List<Dictionary<string, object>> GetClassInfoData()
        {
            string urlHead = u_handlerUrl + "/EduManage/ClassHandler.ashx?";
            string urlbady = "Func=GetData&SysAccountNo=" + sysAccountNo + "&Ispage=false";
            string PageUrl = urlHead + urlbady;
            return AnalyticalReturnData(NetHelper.RequestPostUrl(PageUrl, urlbady));
        }
        #endregion

        #region 获取学年学期
        private List<Dictionary<string, object>> GetStudySectionData()
        {
            string urlHead = u_handlerUrl + "/EduManage/StudySection.ashx?";
            string urlbady = "Func=GetData&SysAccountNo=" + sysAccountNo + "&Ispage=false&Status=0";
            string PageUrl = urlHead + urlbady;
            return AnalyticalReturnData(NetHelper.RequestPostUrl(PageUrl, urlbady));
        }
        #endregion

        #region 将接口返回的信息解析为List
        public List<Dictionary<string, object>> AnalyticalReturnData(string result)
        {
            JObject rtnObj = JObject.Parse(result);
            JObject resultObj = JsonTool.GetObjVal(rtnObj, "result");
            List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
            if (JsonTool.GetStringVal(resultObj, "errNum") == "0")
            {
                list = jss.Deserialize<List<Dictionary<string, object>>>(resultObj["retData"].ToString());
            }
            return list;
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