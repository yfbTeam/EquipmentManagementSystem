using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EMSHandler.SystemSettings
{
    /// <summary>
    /// SectionPlace 的摘要说明
    /// </summary>
    public class SectionPlace : IHttpHandler
    {
        GetUserNameHandler nameCommon = new GetUserNameHandler();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string action = context.Request.QueryString["action"];
            if (!string.IsNullOrEmpty(action))
            {
                switch (action)
                {
                    case "GetDataPage": GetDataPage(context); break;
                    case "GetModelById": GetModelById(context); break;
                    case "AddSectionPlace": AddSectionPlace(context); break;
                    case "EditSectionPlace": EditSectionPlace(context); break;
                    case "GetDDInfo": GetDDInfo(context); break;
                    default:
                        context.Response.Write("System Error");
                        break;
                }
            }
            context.Response.Write("System Error");
        }

        #region 获取实验室科所列表数据 分页
        public void GetDataPage(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];
            Hashtable ht = new Hashtable();
            ht.Add("Name", context.Request["Name"] ?? "");
            ht.Add("UseStatus", context.Request["UseStatus"] ?? "");
            ht.Add("PageIndex", context.Request["PageIndex"] ?? "1");
            ht.Add("PageSize", context.Request["PageSize"] ?? "10");
            bool ispage = true;
            if (!string.IsNullOrEmpty(context.Request["ispage"]))
            {
                ispage = Convert.ToBoolean(context.Request["ispage"]);
            }              
            //序列化
            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            EmsModel.JsonModel mod = new EmsBLL.SectionPlace().GetPage(ht, ispage);
            mod = nameCommon.AddCreateNameForData(mod, 4, "Director", "", "ViceDirector");
            //输出Json
            HttpContext.Current.Response.Write(callback + "({\"result\":" + jss.Serialize(mod) + "})");
            HttpContext.Current.Response.End();
        }
        #endregion

        #region 根据id获取对象实体
        public void GetModelById(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];
            int splaid = Convert.ToInt32(context.Request["itemid"]);
            //序列化
            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            EmsModel.SectionPlace spla = new EmsBLL.SectionPlace().GetEmsModel(splaid);
            //输出Json
            HttpContext.Current.Response.Write(callback + "({\"result\":" + jss.Serialize(spla) + "})");
            HttpContext.Current.Response.End();
        }
        #endregion

        #region 添加科所
        public void AddSectionPlace(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];
            string name = context.Request["name"];
            int result;
            if (new EmsBLL.SectionPlace().IsNameExists(name))
            {
                result = -1;
            }
            else
            {
                EmsModel.SectionPlace spla = new EmsModel.SectionPlace();
                spla.Name = name;
                spla.Director = context.Request["director"];
                spla.ViceDirector = context.Request["vicedirector"];
                spla.Creator = context.Request["useridcard"];
                spla.CreateTime = DateTime.Now;
                spla.IsDelete = 0;
                spla.UseStatus = 0;
                result = new EmsBLL.SectionPlace().Add(spla);
            }
            //输出Json
            HttpContext.Current.Response.Write(callback + "({\"result\":" + result + "})");
            HttpContext.Current.Response.End();
        }
        #endregion

        #region 编辑科所
        public void EditSectionPlace(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];
            int splaid = Convert.ToInt32(context.Request["itemid"]);
            string name = context.Request["name"];
            int result;
            if (new EmsBLL.SectionPlace().IsNameExists(name, splaid))
            {
                result = -1;
            }
            else
            {
                EmsModel.SectionPlace spla = new EmsBLL.SectionPlace().GetEmsModel(splaid);
                spla.Id = splaid;
                spla.Name = name;
                spla.Director = context.Request["director"];
                spla.ViceDirector = context.Request["vicedirector"];
                spla.Editor = context.Request["useridcard"];
                spla.UpdateTime = DateTime.Now;
                result = new EmsBLL.SectionPlace().Update(spla);
            }
            //输出Json
            HttpContext.Current.Response.Write(callback + "({\"result\":" + result + "})");
            HttpContext.Current.Response.End();
        }
        #endregion

        /// <summary>
        /// 获取科研所下拉菜单信息
        /// </summary>
        /// <returns></returns>
        public void GetDDInfo(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];
            //Hashtable ht = new Hashtable();
            //ht.Add("PageSize", context.Request["PageSize"].ToString());
            EmsBLL.SectionPlace bll = new EmsBLL.SectionPlace();
            EmsModel.JsonModel Model = bll.GetDDInfo();

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
    }
}