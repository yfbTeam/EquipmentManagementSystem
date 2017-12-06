using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EMSHandler.Statistical.EquipList
{
    /// <summary>
    /// EquipList 的摘要说明
    /// </summary>
    public class EquipList : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            string action = context.Request.QueryString["action"];
            if (!string.IsNullOrEmpty(action))
            {
                switch (action)
                {
                    case "GetPage": GetPage(context); break;
                }
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }


        public void GetPage(HttpContext context)
        {
            EmsBLL.EquipList Bll = new EmsBLL.EquipList();
            string callback = context.Request["jsoncallback"];
            Hashtable ht = new Hashtable();
            ht.Add("Name", context.Request["Name"].ToString());
            ht.Add("HonorLevel", context.Request["HonorLevel"].ToString());
            ht.Add("ExperimentName", context.Request["ExperimentName"].ToString());
            ht.Add("IsDelete", context.Request["Filing"].ToString());
            ht.Add("Creator", context.Request["Creator"].ToString());
            ht.Add("PageIndex", context.Request["PageIndex"].ToString());
            ht.Add("PageSize", context.Request["PageSize"].ToString());

            EmsModel.JsonModel Model = Bll.GetPage(ht);

            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            //jss.Serialize(ModelPlan);

            context.Response.Write(callback + "({\"result\":" + jss.Serialize(Model) + "})");
            context.Response.End();
        }
    }
}