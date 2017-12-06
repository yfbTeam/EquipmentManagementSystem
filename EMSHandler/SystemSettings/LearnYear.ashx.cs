using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EMSHandler.SystemSettings
{
    /// <summary>
    /// LearnYear 的摘要说明
    /// </summary>
    public class LearnYear : IHttpHandler
    {

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
                    case "AddLearnYear": AddLearnYear(context); break;
                    case "EditLearnYear": EditLearnYear(context); break;
                    case "GetModelList": GetModelList(context); break;
                    case "GetModel": GetModel(context); break;
                    default:
                        context.Response.Write("System Error");
                        break;
                }
            }
            context.Response.Write("System Error");
        }

        #region 获取学年学期列表数据 分页
        public void GetDataPage(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];
            //当前页
            int startIndex = Convert.ToInt32(context.Request["startIndex"]);
            //页容量
            int pageSize = Convert.ToInt32(context.Request["pageSize"]);
            string name = context.Request["name"];
            EmsModel.LearnYear ley = new EmsModel.LearnYear();
            if (!string.IsNullOrEmpty(name))
            {
                ley.Name = name;
            }
            ley.IsDelete = 0;
            //序列化
            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            EmsModel.JsonModel mod = new EmsBLL.LearnYear().GetJsonModel(ley, startIndex, pageSize);
            //输出Json
            HttpContext.Current.Response.Write(callback + "({\"result\":" + jss.Serialize(mod) + "})");
            HttpContext.Current.Response.End();
        }
        #endregion

        #region 根据id获取对象实体
        public void GetModelById(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];
            int leyid = Convert.ToInt32(context.Request["itemid"]);
            //序列化
            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            EmsModel.LearnYear ley = new EmsBLL.LearnYear().GetEmsModel(leyid);
            //输出Json
            HttpContext.Current.Response.Write(callback + "({\"result\":" + jss.Serialize(ley) + "})");
            HttpContext.Current.Response.End();
        }
        #endregion

        #region 添加学期
        public void AddLearnYear(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];
            string name = context.Request["name"];
            int result;
            if (new EmsBLL.LearnYear().IsNameExists(name))
            {
                result = -1;
            }
            else
            {
                string startdate = context.Request["startdate"];
                string enddate = context.Request["enddate"];
                string datacollection = context.Request["datacollection"];
                string useridcard = context.Request["useridcard"];
                EmsModel.LearnYear ley = new EmsModel.LearnYear();
                ley.Name = name;
                ley.StartDate = Convert.ToDateTime(startdate);
                ley.EndDate = Convert.ToDateTime(enddate);
                ley.DataCollectionTime = Convert.ToByte(datacollection);
                ley.Creator = useridcard;
                ley.CreateTime = DateTime.Now;
                ley.IsDelete = 0;
                ley.UseStatus = 0;
                result = new EmsBLL.LearnYear().Add(ley);
            }
            //输出Json
            HttpContext.Current.Response.Write(callback + "({\"result\":" + result + "})");
            HttpContext.Current.Response.End();
        }
        #endregion

        #region 编辑学期
        public void EditLearnYear(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];
            int leyid = Convert.ToInt32(context.Request["itemid"]);
            string name = context.Request["name"];
            int result;
            if (new EmsBLL.LearnYear().IsNameExists(name, leyid))
            {
                result = -1;
            }
            else
            {
                EmsModel.LearnYear ley = new EmsBLL.LearnYear().GetEmsModel(leyid);
                string startdate = context.Request["startdate"];
                string enddate = context.Request["enddate"];
                string datacollection = context.Request["datacollection"];
                string useridcard = context.Request["useridcard"];
                ley.Id = leyid;
                ley.Name = name;
                ley.StartDate = Convert.ToDateTime(startdate);
                ley.EndDate = Convert.ToDateTime(enddate);
                ley.DataCollectionTime = Convert.ToByte(datacollection);
                ley.Editor = useridcard;
                ley.UpdateTime = DateTime.Now;
                result = new EmsBLL.LearnYear().Update(ley);
            }
            //输出Json
            HttpContext.Current.Response.Write(callback + "({\"result\":" + result + "})");
            HttpContext.Current.Response.End();
        }
        #endregion

        /// <summary>
        /// 获得List
        /// </summary>
        public void GetModelList(HttpContext context)
        {
            EmsBLL.LearnYear BLL = new EmsBLL.LearnYear();
            string callback = context.Request["jsoncallback"];
            Hashtable ht = new Hashtable();
            //学期名称
            if (context.Request["Name"] != null)
            {
                ht.Add("Name", context.Request["Name"].ToString());
            }
            //是否删除
            if (context.Request["IsDelete"] != null)
            {
                ht.Add("IsDelete", context.Request["IsDelete"].ToString());
            }
            EmsModel.JsonModel Model = BLL.GetModelList(ht);

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
            EmsBLL.LearnYear BLL = new EmsBLL.LearnYear();
            string callback = context.Request["jsoncallback"];
            Hashtable ht = new Hashtable();
            ht.Add("Id", context.Request["Id"].ToString());
            EmsModel.JsonModel Model = BLL.GetModel(ht["Id"].ToString());


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