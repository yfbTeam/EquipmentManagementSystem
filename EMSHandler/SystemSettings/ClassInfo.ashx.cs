using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EMSHandler.SystemSettings
{
    /// <summary>
    /// ClassInfo 的摘要说明
    /// </summary>
    public class ClassInfo : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string action=context.Request.QueryString["action"];
            if (!string.IsNullOrEmpty(action))
            {
                switch (action)
                {
                    case "GetDataPage": GetDataPage(context); break;
                    case "GetModelById": GetModelById(context); break;
                    case "AddClassInfo": AddClassInfo(context); break;
                    case "EditClassInfo": EditClassInfo(context); break;
                    default:
                        context.Response.Write("System Error");
                        break;
                }
            }
            context.Response.Write("System Error");
        }

        #region 获取班级列表数据 分页
        public void GetDataPage(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];
            //当前页
            int startIndex = Convert.ToInt32(context.Request["startIndex"]);
            //页容量
            int pageSize = Convert.ToInt32(context.Request["pageSize"]);
            string name = context.Request["name"];
            EmsModel.ClassInfo cla = new EmsModel.ClassInfo();
            if (!string.IsNullOrEmpty(name))
            {
                cla.Name = name;
            }
            //序列化
            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            EmsModel.JsonModel mod = new EmsBLL.ClassInfo().GetJsonModel(cla, startIndex, pageSize);
            //输出Json
            HttpContext.Current.Response.Write(callback + "({\"result\":" + jss.Serialize(mod) + "})");
            HttpContext.Current.Response.End();
        }
        #endregion

        #region 根据id获取对象实体
        public void GetModelById(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];
            int claid = Convert.ToInt32(context.Request["itemid"]);
            //序列化
            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            EmsModel.ClassInfo cla = new EmsBLL.ClassInfo().GetEmsModel(claid);
            //输出Json
            HttpContext.Current.Response.Write(callback + "({\"result\":" + jss.Serialize(cla) + "})");
            HttpContext.Current.Response.End();
        }
        #endregion

        #region 添加班级
        public void AddClassInfo(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];
            string name = context.Request["name"];
            int result;
            if (new EmsBLL.ClassInfo().IsNameExists(name))
            {
                result = -1;
            }
            else
            {
                string useridcard = context.Request["useridcard"];
                EmsModel.ClassInfo cla = new EmsModel.ClassInfo();
                cla.Name = name;
                cla.UseStatus = 0;
                cla.Creator = useridcard;
                cla.CreateTime = DateTime.Now;
                result = new EmsBLL.ClassInfo().Add(cla);
            }
            //输出Json
            HttpContext.Current.Response.Write(callback + "({\"result\":" + result + "})");
            HttpContext.Current.Response.End();
        }
        #endregion

        #region 编辑班级
        public void EditClassInfo(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];
            int claid = Convert.ToInt32(context.Request["itemid"]);
            string name = context.Request["name"];
            int result;
            if (new EmsBLL.ClassInfo().IsNameExists(name, claid))
            {
                result = -1;
            }
            else
            {
                EmsModel.ClassInfo cla = new EmsBLL.ClassInfo().GetEmsModel(claid);
                string useridcard = context.Request["useridcard"];
                cla.Id = claid;
                cla.Name = name;
                cla.Editor = useridcard;
                cla.UpdateTime = DateTime.Now;
                result = new EmsBLL.ClassInfo().Update(cla);
            }
            //输出Json
            HttpContext.Current.Response.Write(callback + "({\"result\":" + result + "})");
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