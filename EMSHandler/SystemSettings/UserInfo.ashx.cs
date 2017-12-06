using EmsBLL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

namespace EMSHandler.SystemSettings
{
    /// <summary>
    /// UserInfo 的摘要说明
    /// </summary>
    public class UserInfo : IHttpHandler
    {
        BLLCommon bll_com = new BLLCommon();
        GetUserNameHandler nameCommon = new GetUserNameHandler();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string action = context.Request.QueryString["action"];
            if (!string.IsNullOrEmpty(action))
            {
                switch (action)
                {
                    case "GetData": GetData(context); break;
                    case "GetDataPage": GetDataPage(context); break;
                    case "GetDataByRoleId": GetDataByRoleId(context); break;
                    case "GetNotDataByRoleId": GetNotDataByRoleId(context); break;
                    case "GetModelById": GetModelById(context); break;
                    case "AddUserInfo": AddUserInfo(context); break;
                    case "EditUserInfo": EditUserInfo(context); break;
                    case "DeleteUserInfo": DeleteUserInfo(context); break;
                    case "Login": Login(context); break;
                    case "GetLeftNavigationMenu": GetLeftNavigationMenu(context); break;
                    case "ImportTeacher": ImportTeacher(context); break;
                    case "GetModelByUserIdCard": GetModelByUserIdCard(context); break;
                    case "EditPassword": EditPassword(context); break;
                    default:
                        context.Response.Write("System Error");
                        break;
                }
            }
            context.Response.Write("System Error");
        }

        

        #region 获取用户列表数据
        public void GetData(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];
            string name = context.Request["name"];
            EmsModel.UserInfo user = new EmsModel.UserInfo();
            if (!string.IsNullOrEmpty(name))
            {
                user.Name = name;
            }
            //序列化
            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            EmsModel.JsonModel mod = new EmsBLL.UserInfo().GetJsonModel(user);
            //输出Json
            HttpContext.Current.Response.Write(callback +
                     "({\"result\":" + jss.Serialize(mod) + "})");
            HttpContext.Current.Response.End();
        }
        #endregion

        #region 获取用户列表数据 分页
        public void GetDataPage(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];
            //当前页
            int startIndex = Convert.ToInt32(context.Request["startIndex"]);
            //页容量
            int pageSize = Convert.ToInt32(context.Request["pageSize"]);
            string name = context.Request["name"];
            EmsModel.UserInfo user = new EmsModel.UserInfo();
            if (!string.IsNullOrEmpty(name))
            {
                user.Name = name;
            }
            user.IsDelete = 0;
            //序列化
            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            EmsModel.JsonModel mod = new EmsBLL.UserInfo().GetJsonModel(user, startIndex, pageSize, "", "");
            //输出Json
            HttpContext.Current.Response.Write(callback +
                     "({\"result\":" + jss.Serialize(mod) + "})");
            HttpContext.Current.Response.End();
        }
        #endregion

        #region 根据角色id获取角色下的用户列表数据
        public void GetDataByRoleId(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];         
            Hashtable ht = new Hashtable();           
            ht.Add("RoleId", context.Request["RoleId"]??"");
            ht.Add("PageIndex", context.Request["PageIndex"]??"1");
            ht.Add("PageSize", context.Request["PageSize"]??"10");
            bool ispage = true;
            if (!string.IsNullOrEmpty(context.Request["ispage"]))
            {
                ispage = Convert.ToBoolean(context.Request["ispage"]);
            }
            //序列化
            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            EmsModel.JsonModel mod = new EmsBLL.RoleOfUser().GetPage(ht, ispage);
            mod= nameCommon.AddCreateNameForData(mod, 4, "LoginName","", "", context.Request["Name"] ?? "");
            //输出Json
            HttpContext.Current.Response.Write(callback +
                     "({\"result\":" + jss.Serialize(mod) + "})");
            HttpContext.Current.Response.End();
        }
        #endregion

        #region 根据角色id获取非该角色下的用户列表
        public void GetNotDataByRoleId(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];
            //当前页
            int startIndex = Convert.ToInt32(context.Request["startIndex"]);
            //页容量
            int pageSize = Convert.ToInt32(context.Request["pageSize"]);
            string roleid = context.Request["roleid"];
            string name = context.Request["name"];
            EmsModel.UserInfo user = new EmsModel.UserInfo();
            if (!string.IsNullOrEmpty(name))
            {
                user.Name = name;
            }
            user.IsDelete = 0;
            //序列化
            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            EmsModel.JsonModel mod = new EmsBLL.UserInfo().GetJsonModel(user, startIndex, pageSize, roleid, "not in");
            //输出Json
            HttpContext.Current.Response.Write(callback +
                     "({\"result\":" + jss.Serialize(mod) + "})");
            HttpContext.Current.Response.End();
        }
        #endregion

        #region 根据id获取对象实体
        public void GetModelById(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];
            int userid = Convert.ToInt32(context.Request["itemid"]);
            //序列化
            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            EmsModel.UserInfo user = new EmsBLL.UserInfo().GetEmsModel(userid);
            //输出Json
            HttpContext.Current.Response.Write(callback + "({\"result\":" + jss.Serialize(user) + "})");
            HttpContext.Current.Response.End();
        }
        #endregion

        #region 添加用户
        public void AddUserInfo(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];
            string name = context.Request["name"];
            string addloginname = context.Request["addloginname"];
            int result;
            if (new EmsBLL.UserInfo().IsNameExists(addloginname))
            {
                result = -1;
            }
            else
            {

                string pwd = bll_com.Md5Encrypting(context.Request["pwd"]);
                EmsModel.UserInfo user = new EmsModel.UserInfo();
                user.LoginName = addloginname;
                user.PassWord = pwd;
                user.Name = name;
                user.Sex = context.Request["sex"];
                user.KaNo = context.Request["kano"];
                user.IDCard = context.Request["idcard"];
                user.Creator = context.Request["useridcard"];
                user.CreateTime = DateTime.Now;
                user.IsDelete = 0;
                user.UseStatus = 0;
                result = new EmsBLL.UserInfo().Add(user);
            }
            //输出Json
            HttpContext.Current.Response.Write(callback + "({\"result\":" + result + "})");
            HttpContext.Current.Response.End();
        }
        #endregion

        #region 编辑用户
        public void EditUserInfo(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];
            int userid = Convert.ToInt32(context.Request["itemid"]);
            string name = context.Request["name"];
            string addloginname = context.Request["addloginname"];
            int result;
            if (new EmsBLL.UserInfo().IsNameExists(addloginname, userid))
            {
                result = -1;
            }
            else
            {
                EmsModel.UserInfo user = new EmsBLL.UserInfo().GetEmsModel(userid);
                string pwd = context.Request["pwd"];
                user.Id = userid;
                user.LoginName = addloginname;
                if (!string.IsNullOrEmpty(pwd))
                {
                    user.PassWord = bll_com.Md5Encrypting(pwd);
                }
                user.Name = name;
                user.Sex = context.Request["sex"];
                user.KaNo = context.Request["kano"];
                user.IDCard = context.Request["idcard"];
                user.Editor = context.Request["useridcard"];
                user.UpdateTime = DateTime.Now;
                result = new EmsBLL.UserInfo().Update(user);
            }
            //输出Json
            HttpContext.Current.Response.Write(callback + "({\"result\":" + result + "})");
            HttpContext.Current.Response.End();
        }
        #endregion

        #region 删除用户
        public void DeleteUserInfo(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];
            int userid = Convert.ToInt32(context.Request["intID"]);
            EmsModel.UserInfo user = new EmsBLL.UserInfo().GetEmsModel(userid);
            user.Id = userid;
            user.IsDelete = 1;
            int result = new EmsBLL.UserInfo().Update(user);
            //输出Json
            HttpContext.Current.Response.Write(callback +
                     "({\"result\":" + result + "})");
            HttpContext.Current.Response.End();
        }
        #endregion

        #region 登录
        public void Login(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];
            string loginName = context.Request["loginName"];
            string passWord = bll_com.Md5Encrypting(context.Request["passWord"]);
            //序列化
            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            EmsModel.UserInfo user = new EmsBLL.UserInfo().IsLogin(loginName, passWord);
            string result = "";
            if (user != null)
            {
                result = user.Id + "," + user.LoginName + "," + user.Name + "," + user.Sex + "," + user.KaNo + "," + user.IDCard + ","
                         + user.KaLv + "," + user.UseStatus + "," + user.RoleId + "," + user.RoleName + "," + user.WarehouseId + "," + user.WarehouseName;
            }
            //输出Json
            HttpContext.Current.Response.Write(callback + "({\"result\":'" + result + "',\"usestatus\":'" + (user != null ? user.UseStatus.ToString() : "") + "'})");
            HttpContext.Current.Response.End();
        }
        #endregion

        #region 获得首页左侧导航处菜单信息
        public void GetLeftNavigationMenu(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];
            string loginUID = context.Request["LoginUID"];
            //序列化
            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            DataTable dt = new EmsBLL.MenuInfo().GetLeftNavigationMenu(loginUID, ConfigurationManager.ConnectionStrings["AdminRoleID"].ConnectionString);
            StringBuilder orgJson = new StringBuilder();
            DataRow[] parMenu = dt.Select("Pid=0");
            for (int i = 0; i < parMenu.Count(); i++)
            {
                orgJson.Append("<li class='onenav'>");
                orgJson.Append("<a class='menuclick' href='#'><i class='" + parMenu[i]["iconClass"] + "'></i>" + parMenu[i]["Name"] + "<span class='iconfont icon-icoxiala'></span></a>");
                DataRow[] subMenu = dt.Select(" Pid=" + parMenu[i]["Id"]);
                orgJson.Append("<ul class='submenu' style='display:none;'>");
                for (int j = 0; j < subMenu.Count(); j++)
                {
                    orgJson.Append("<li><a href='javascript:void(0);' data-src='" + subMenu[j]["Url"] + "'>" + subMenu[j]["Name"] + "</a></li>");
                }
                orgJson.Append("</ul>");
                orgJson.Append("</li>");
            }
            //输出Json
            HttpContext.Current.Response.Write(callback + "({\"result\":\"" + orgJson.ToString() + "\"})");
            HttpContext.Current.Response.End();
        }
        #endregion

        /// <summary>
        /// 导入教师信息
        /// </summary>
        /// <returns></returns>
        public void ImportTeacher(HttpContext context)
        {
            EmsBLL.UserInfo BLL = new EmsBLL.UserInfo();
            string callback = context.Request["jsoncallback"];
            Hashtable ht = new Hashtable();
            ht.Add("Creator", context.Request["Creator"].ToString());
            ht.Add("FilePath", context.Request["FilePath"].ToString());
            ht.Add("UseStatus", System.Configuration.ConfigurationManager.ConnectionStrings["DefaultUserStatus"].ConnectionString);
            ht.Add("Password", System.Configuration.ConfigurationManager.ConnectionStrings["InitialPassword"].ConnectionString);
            ht.Add("RoleId", System.Configuration.ConfigurationManager.ConnectionStrings["RoleId"].ConnectionString);
            EmsModel.JsonModel Model = BLL.ImportTeacher(ht);

            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            //jss.Serialize(ModelPlan);

            HttpContext.Current.Response.Write(callback + "({\"result\":" + jss.Serialize(Model) + "})");
            HttpContext.Current.Response.End();
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        #region 根据身份证获取对象实体
        public void GetModelByUserIdCard(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];
            string useridcard = context.Request["userIdCard"];
            //序列化
            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            EmsModel.UserInfo user = new EmsBLL.UserInfo().GetModelByUserIdCard(useridcard);
            //输出Json
            HttpContext.Current.Response.Write(callback + "({\"result\":" + jss.Serialize(user) + "})");
            HttpContext.Current.Response.End();
        }
        #endregion

        #region 根据身份证号查询并更新密码
        public void EditPassword(HttpContext context) 
        {
            string callback = context.Request["jsoncallback"];
            string oldpwd = context.Request["oldpwd"];
            string useridcard = context.Request["useridcard"];
            string pwd = context.Request["pwd"];
            EmsModel.UserInfo user = new EmsBLL.UserInfo().GetModelByUserIdCard(useridcard);
            int result = 0;
            if (user != null) {
                if (user.PassWord != bll_com.Md5Encrypting(oldpwd))
                {
                    result = -1;
                }
                else
                {
                    if (!string.IsNullOrEmpty(pwd))
                    {
                        user.PassWord = bll_com.Md5Encrypting(pwd);
                        user.UpdateTime = DateTime.Now;
                        result = new EmsBLL.UserInfo().Update(user);
                    }
                }
            }
            HttpContext.Current.Response.Write(callback + "({\"result\":" + result + "})");
            HttpContext.Current.Response.End();
        }
        #endregion
    }
}