using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EMSHandler.Statistical.ExperimentEquip
{
    /// <summary>
    /// ExperimentEquip 的摘要说明
    /// </summary>
    public class ExperimentEquip : IHttpHandler
    {
        EmsBLL.EquipList BLLEquipList = new EmsBLL.EquipList();
        EmsBLL.InstrumentEquip BllInstrumentEquip = new EmsBLL.InstrumentEquip();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string action = context.Request.QueryString["action"];
            if (!string.IsNullOrEmpty(action))
            {
                switch (action)
                {
                    case "GetPage": GetPage(context); break;
                    case "GetPage2": GetPage2(context); break;
                    case "GetPageTempSelect": GetPageTempSelect(context); break;
                    case "SaveEquipList": SaveEquipList(context); break;
                    case "CreateOrder": CreateOrder(context); break;

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


        /// <summary>
        /// 获得设备分类列表
        /// </summary>
        /// <returns></returns>
      
        public void GetPage(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];
            Hashtable ht = new Hashtable();

            if (context.Request["Name"] != null)
            {
                ht.Add("Name", context.Request["Name"].ToString());
            }
            if (context.Request["Number"] != null)
            {
                ht.Add("Number", context.Request["Number"].ToString());
            }
            if (context.Request["Model"] != null)
            {
                ht.Add("Model", context.Request["Model"].ToString());
            }
            ht.Add("PageIndex", context.Request["PageIndex"].ToString());
            ht.Add("PageSize", context.Request["PageSize"].ToString());

            EmsModel.JsonModel Model = BllInstrumentEquip.GetPage(ht);

            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            //jss.Serialize(ModelPlan);

            context.Response.Write(callback + "({\"result\":" + jss.Serialize(Model) + "})");
            context.Response.End();
        }
        /// <summary>
        /// 获得实验设备列表
        /// </summary>
        /// <returns></returns>
       
        public void GetPage2(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];
            Hashtable ht = new Hashtable();
            if (context.Request["RelationID"] != null)
            {
                ht.Add("RelationID", context.Request["RelationID"].ToString());
            }
            ht.Add("PageIndex", context.Request["PageIndex"].ToString());
            ht.Add("PageSize", context.Request["PageSize"].ToString());

            EmsModel.JsonModel Model = BLLEquipList.GetPage(ht);

            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            //jss.Serialize(ModelPlan);

            context.Response.Write(callback + "({\"result\":" + jss.Serialize(Model) + "})");
            context.Response.End();
        }
        /// <summary>
        /// 快速模板实验设备列表
        /// </summary>
        /// <returns></returns>
       
        public void GetPageTempSelect(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];
            Hashtable ht = new Hashtable();
            if (context.Request["RelationID"] != null)
            {
                ht.Add("RelationID", context.Request["RelationID"].ToString());
            }
            ht.Add("PageIndex", context.Request["PageIndex"].ToString());
            ht.Add("PageSize", context.Request["PageSize"].ToString());

            EmsModel.JsonModel Model = BLLEquipList.GetPageTempSelect(ht);

            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            //jss.Serialize(ModelPlan);

            context.Response.Write(callback + "({\"result\":" + jss.Serialize(Model) + "})");
            context.Response.End();
        }


        /// <summary>
        /// 保存选择结果
        /// </summary>
        /// <returns>结果</returns>
      
        public void SaveEquipList(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];

            Hashtable ht = new Hashtable();
            ht.Add("RelationID", context.Request["ExperimentId"].ToString());
            ht.Add("YSelectStr", context.Request["YSelectStr"].ToString());

            EmsModel.JsonModel Model = BLLEquipList.SaveEquipList(ht);

            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            //jss.Serialize(result);

            //输出Json
            context.Response.Write(callback + "({\"result\":" + jss.Serialize(Model) + "})");
            context.Response.End();
        }

        /// <summary>
        /// 生成订单
        /// </summary>
        /// <returns>结果</returns>
       
        public void CreateOrder(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];
            EmsBLL.OrderInfo BLLOrderInfo = new EmsBLL.OrderInfo();

            Hashtable ht = new Hashtable();
            ht.Add("ExperimentId", context.Request["ExperimentId"].ToString());
            //ht.Add("YSelectStr", context.Request["YSelectStr"].ToString());
            ht.Add("LoanName", context.Request["LoanName"].ToString());
            ht.Add("Creator", context.Request["Creator"].ToString());
            ht.Add("Type", context.Request["Type"].ToString());

            EmsModel.JsonModel Model = BLLOrderInfo.CreateOrder(ht);

            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            //jss.Serialize(result);

            //输出Json
            context.Response.Write(callback + "({\"result\":" + jss.Serialize(Model) + "})");
            context.Response.End();
        }
    }
}