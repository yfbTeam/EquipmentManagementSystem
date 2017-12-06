using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

namespace EMSHandler.SystemSettings
{
    /// <summary>
    /// RoleInfo 的摘要说明
    /// </summary>
    public class RoleInfo : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string action = context.Request.QueryString["action"];
            if (!string.IsNullOrEmpty(action))
            {
                switch (action)
                {
                    case "GetData": GetData(context); break;
                    case "GetRoleTreeData": GetRoleTreeData(context); break;
                    case "GetModelById": GetModelById(context); break;
                    case "AddRole": AddRole(context); break;
                    case "EditRole": EditRole(context); break;
                    case "DeleteRole": DeleteRole(context); break;
                    case "GetMenuById": GetMenuById(context); break;
                    case "SetRoleMenu": SetRoleMenu(context); break;
                    case "SetRoleMember": SetRoleMember(context); break;
                    case "DeleteUserRelation": DeleteUserRelation(context); break;
                    default:
                        context.Response.Write("System Error");
                        break;
                }
            }
            context.Response.Write("System Error");
        }

        #region 获取角色列表数据
        public void GetData(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];
            string rolename = context.Request["rolename"];
            EmsModel.Role role = new EmsModel.Role();
            if (!string.IsNullOrEmpty(rolename))
            {
                role.Name = rolename;
            }
            //序列化
            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            EmsModel.JsonModel mod = new EmsBLL.Role().GetJsonModel(role);

            //输出Json
            HttpContext.Current.Response.Write(callback + "({\"result\":" + jss.Serialize(mod) + "})");

            HttpContext.Current.Response.End();
        }
        #endregion
        #region 获取角色树数据
        public void GetRoleTreeData(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];
            //序列化
            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            List<EmsModel.Role> roles = new EmsBLL.Role().GetAllRoleList();
            StringBuilder orgJson = new StringBuilder();
            foreach (EmsModel.Role item in roles)
            {
                orgJson.Append("{\"id\":" + item.Id + ", \"pId\": 0, \"name\":\"" + item.Name + "\"},");  //
            }
            //输出Json
            HttpContext.Current.Response.Write(callback +
                     "({\"result\":" + "[" + orgJson.ToString().TrimEnd(',') + "]})");

            HttpContext.Current.Response.End();
        }
        #endregion
        #region 根据id获取对象实体
        public void GetModelById(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];
            int roleid = Convert.ToInt32(context.Request["itemid"]);
            //序列化
            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            EmsModel.Role role = new EmsBLL.Role().GetEmsModel(roleid);
            //输出Json
            HttpContext.Current.Response.Write(callback +
                     "({\"result\":" + jss.Serialize(role) + "})");

            HttpContext.Current.Response.End();
        }
        #endregion

        #region 添加角色
        public void AddRole(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];
            string name = context.Request["name"];
            int result;
            if (new EmsBLL.Role().IsNameExists(name))
            {
                result = -1;
            }
            else
            {
                string useridcard = context.Request["useridcard"];
                EmsModel.Role role = new EmsModel.Role();
                role.Name = name;
                role.Creator = useridcard;
                role.CreateTime = DateTime.Now;
                role.IsDelete = 0;
                result = new EmsBLL.Role().Add(role);
            }
            //输出Json
            HttpContext.Current.Response.Write(callback +
                     "({\"result\":" + result + "})");
            HttpContext.Current.Response.End();
        }
        #endregion

        #region 编辑角色
        public void EditRole(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];
            int roleid = Convert.ToInt32(context.Request["itemid"]);
            string name = context.Request["name"];
            string useridcard = context.Request["useridcard"];
            int result;
            if (new EmsBLL.Role().IsNameExists(name, roleid))
            {
                result = -1;
            }
            else
            {
                EmsModel.Role role = new EmsBLL.Role().GetEmsModel(roleid);
                role.Id = roleid;
                role.Name = name;
                role.Editor = useridcard;
                role.UpdateTime = DateTime.Now;
                result = new EmsBLL.Role().Update(role);
            }
            //输出Json
            HttpContext.Current.Response.Write(callback +
                    "({\"result\":" + result + "})");
            HttpContext.Current.Response.End();
        }
        #endregion

        #region 删除角色
        public void DeleteRole(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];
            int roleid = Convert.ToInt32(context.Request["intID"]);
            EmsModel.Role ware = new EmsBLL.Role().GetEmsModel(roleid);
            ware.Id = roleid;
            ware.IsDelete = 1;
            int result = new EmsBLL.Role().Update(ware);
            //输出Json
            HttpContext.Current.Response.Write(callback +
                     "({\"result\":" + result + "})");
            HttpContext.Current.Response.End();
        }
        #endregion

        #region 根据id获取角色权限
        public void GetMenuById(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];
            string roleid = context.Request["itemid"];
            //序列化
            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            DataTable dt = new EmsBLL.MenuInfo().GetPermissionMenu(roleid);
            StringBuilder orgJson = new StringBuilder();
            foreach (DataRow row in dt.Rows)
            {
                orgJson.Append("{\"id\":" + row["Id"].ToString() + ", \"pId\": " + row["Pid"].ToString()
                    + ", \"name\":\"" + row["Name"].ToString() + "\",\"checked\":" + (row["ischeck"].ToString() == "0" ? "false" : "true") + "},");  //
            }
            //输出Json
            HttpContext.Current.Response.Write(callback +
                     "({\"result\":" + "[" + orgJson.ToString().TrimEnd(',') + "]})");

            HttpContext.Current.Response.End();
        }
        #endregion

        #region 设置角色菜单
        public void SetRoleMenu(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];
            string roleid = context.Request["itemid"];
            string nodeids = context.Request["nodeids"];
            //序列化
            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            EmsModel.JsonModel mod = new EmsBLL.RoleOfMenu().SetRoleMenu(roleid, nodeids);
            //输出Json
            HttpContext.Current.Response.Write(callback + "({\"result\":" + jss.Serialize(mod) + "})");
            HttpContext.Current.Response.End();
        }
        #endregion

        #region 设置角色成员
        public void SetRoleMember(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];
            string roleid = context.Request["itemid"];
            string loginnameStr = context.Request["loginnameStr"];
            //序列化
            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            EmsModel.JsonModel mod = new EmsBLL.RoleOfUser().SetRoleMember(roleid, loginnameStr);
            //输出Json
            HttpContext.Current.Response.Write(callback + "({\"result\":" + jss.Serialize(mod) + "})");
            HttpContext.Current.Response.End();
        }
        #endregion

        #region 根据角色id和登录名删除数据
        public void DeleteUserRelation(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];
            int roleid = Convert.ToInt32(context.Request["roleid"]);
            string useridcard = context.Request["useridcard"];
            int result;
            EmsModel.RoleOfUser roleu = new EmsModel.RoleOfUser();
            roleu.RoleId = roleid;
            roleu.LoginName = useridcard;
            result = new EmsBLL.RoleOfUser().DeleteUserRelation(roleu);
            //输出Json
            HttpContext.Current.Response.Write(callback +
                     "({\"result\":" + result + "})");
            HttpContext.Current.Response.End();
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