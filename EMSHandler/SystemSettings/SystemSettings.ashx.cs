using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EMSHandler.SystemSettings
{
    /// <summary>
    /// SystemSettings 的摘要说明
    /// </summary>
    public class SystemSettings : IHttpHandler
    {
        EmsBLL.Dictionary BllDictionary = new EmsBLL.Dictionary();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string action = context.Request.QueryString["action"];
            if (!string.IsNullOrEmpty(action))
            {
                switch (action)
                {
                    case "GetLearnYear": GetLearnYear(context); break;
                    case "GetModel": GetModel(context); break;
                    case "GetLevelList": GetLevelList(context); break;
                    case "GetExpType": GetExpType(context); break;
                    default:
                        context.Response.Write("System Error");
                        break;
                }
            }
            context.Response.Write("System Error");
        }

        
        /// <summary>
        /// 获得学年学期List
        /// </summary>
        public void GetLearnYear(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];
            EmsModel.JsonModel Model = BllDictionary.GetLearnYearList();

            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            //jss.Serialize(result);

            //输出Json
            HttpContext.Current.Response.Write(callback + "({\"result\":" + jss.Serialize(Model) + "})");
            HttpContext.Current.Response.End();
        }

        /// <summary>
        /// 获得Model
        /// </summary>
        public void GetModel(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];
            Hashtable ht = new Hashtable();
            ht.Add("Id", context.Request["Id"].ToString());
            EmsModel.JsonModel Model = BllDictionary.GetModel(ht);


            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            //jss.Serialize(result);

            //输出Json
            HttpContext.Current.Response.Write(callback + "({\"result\":" + jss.Serialize(Model) + "})");
            HttpContext.Current.Response.End();
        }

        /// <summary>
        /// 获得级别List
        /// </summary>
        public void GetLevelList(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];
            EmsModel.JsonModel Model = BllDictionary.GetLevelList();

            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            //jss.Serialize(result);

            //输出Json
            HttpContext.Current.Response.Write(callback + "({\"result\":" + jss.Serialize(Model) + "})");
            HttpContext.Current.Response.End();
        }
        /// <summary>
        /// 获得实验类型
        /// </summary>
        public void GetExpType(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];
            EmsModel.JsonModel Model = BllDictionary.GetExpType();

            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            //jss.Serialize(result);

            //输出Json
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
    }
}