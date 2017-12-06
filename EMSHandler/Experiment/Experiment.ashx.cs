using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EMSHandler.Statistical.Experiment
{
    /// <summary>
    /// Experiment 的摘要说明
    /// </summary>
    public class Experiment : IHttpHandler
    {
        EmsBLL.PlanExperiment BllExperiment = new EmsBLL.PlanExperiment();
        EmsBLL.EquipList BLLEquipList = new EmsBLL.EquipList();
        GetUserNameHandler nameCommon = new GetUserNameHandler();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string action = context.Request.QueryString["action"];
            if (!string.IsNullOrEmpty(action))
            {
                switch (action)
                {
                    case "GetPage": GetPage(context); break;
                    case "GetSelectOption": GetSelectOption(context); break;
                    case "GetExperiment": GetExperiment(context); break;
                    case "AddExperiment": AddExperiment(context); break;
                    case "UpdateExperiment": UpdateExperiment(context); break;
                    case "RepeatName": RepeatName(context); break;
                    case "DeleteExperiment": DeleteExperiment(context); break;
                    case "GetExperimentEquipList": GetExperimentEquipList(context); break;
                    case "GetOrderEquipList": GetOrderEquipList(context); break;
                    case "GetClass": GetClass(context); break;
                    case "DateLoad": DateLoad(context); break;
                    case "GetExperiment_Calendar": GetExperiment_Calendar(context); break;
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
        /// 获得实验列表
        /// </summary>
        /// <returns></returns>

        public void GetPage(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];
            Hashtable ht = new Hashtable();
            if (context.Request["PlanId"] != null)
            {
                ht.Add("PlanId", context.Request["PlanId"].ToString());
            }
            if (context.Request["Name"] != null)
            {
                ht.Add("Name", context.Request["Name"].ToString());
            }
            if (context.Request["IsDelete"] != null)
            {
                ht.Add("IsDelete", context.Request["IsDelete"].ToString());
            }
            if (context.Request["PageIndex"] != null)
            {
                ht.Add("PageIndex", context.Request["PageIndex"].ToString());
            }
            else
            {
                ht.Add("PageIndex", 1);
            }
            if (context.Request["PageSize"] != null)
            {
                ht.Add("PageSize", context.Request["PageSize"].ToString());
            }
            else
            {
                ht.Add("PageSize", 10);
            }

            EmsModel.JsonModel Model = BllExperiment.GetPage(ht);
            Model = nameCommon.AddCreateNameForData(Model, 4, "Creator", "", "Editor");
            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            //jss.Serialize(ModelPlan);

            context.Response.Write(callback + "({\"result\":" + jss.Serialize(Model) + "})");
            context.Response.End();
        }
        /// <summary>
        /// 获得实验下拉列表
        /// </summary>
        /// <returns></returns>

        public void GetSelectOption(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];
            Hashtable ht = new Hashtable();
            if (context.Request["Creator"] != null)
            {
                ht.Add("Creator", context.Request["Creator"].ToString());
            }
            EmsModel.JsonModel Model = BllExperiment.GetSelectOption(ht);

            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            //jss.Serialize(ModelPlan);

            context.Response.Write(callback + "({\"result\":" + jss.Serialize(Model) + "})");
            context.Response.End();
        }
        /// <summary>
        /// 获得实验
        /// </summary>
        /// <returns></returns>

        public void GetExperiment(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];
            string Id = context.Request["Id"].ToString();

            EmsModel.JsonModel Model = BllExperiment.GetExperiment(Id);
            Model = nameCommon.AddCreateNameForData(Model, 4, "Creator", "", "Editor");
            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            //jss.Serialize(ModelExperiment);

            context.Response.Write(callback + "({\"result\":" + jss.Serialize(Model) + "})");
            context.Response.End();
        }

        /// <summary>
        /// 添加实验
        /// </summary>
        /// <returns>结果</returns>

        public void AddExperiment(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];
            Hashtable ht = new Hashtable();
            ht.Add("Name", context.Request["Name"].ToString());
            ht.Add("Type", context.Request["Type"].ToString());
            ht.Add("IsOpen", context.Request["IsOpen"].ToString());
            ht.Add("StartDate", context.Request["StartDate"].ToString());
            ht.Add("Week", context.Request["Week"].ToString());
            ht.Add("Weekday", context.Request["Weekday"].ToString());
            ht.Add("ClassHour", context.Request["ClassHour"].ToString());
            ht.Add("Part", context.Request["Part"].ToString());
            ht.Add("ComputerRoom", context.Request["ComputerRoom"].ToString());
            ht.Add("Place", context.Request["Place"].ToString());
            ht.Add("GroupMemberNumber", context.Request["GroupMemberNumber"].ToString());
            ht.Add("GroupNumber", context.Request["GroupNumber"].ToString());
            ht.Add("NeedEquip", context.Request["NeedEquip"].ToString());
            ht.Add("Contents", context.Request["Contents"].ToString());
            ht.Add("PlanId", context.Request["PlanId"].ToString());
            ht.Add("Creator", context.Request["Creator"].ToString());
            ht.Add("Class", context.Request["Class"].ToString());
            ht.Add("Category", context.Request["Category"].ToString());

            EmsModel.JsonModel Model = BllExperiment.AddExperiment(ht);

            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            //jss.Serialize(result);

            //输出Json
            //context.Response.Write(callback + "{\"result\":\"" + result + "\"}");
            context.Response.Write(callback + "({\"result\":" + jss.Serialize(Model) + "})");
            context.Response.End();
        }

        /// <summary>
        /// 修改实验
        /// </summary>
        /// <returns>结果</returns>

        public void UpdateExperiment(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];
            Hashtable ht = new Hashtable();
            ht.Add("Name", context.Request["Name"].ToString());
            ht.Add("Type", context.Request["Type"].ToString());
            ht.Add("IsOpen", context.Request["IsOpen"].ToString());
            ht.Add("StartDate", context.Request["StartDate"].ToString());
            ht.Add("Week", context.Request["Week"].ToString());
            ht.Add("Weekday", context.Request["Weekday"].ToString());
            ht.Add("ClassHour", context.Request["ClassHour"].ToString());
            ht.Add("Part", context.Request["Part"].ToString());
            ht.Add("ComputerRoom", context.Request["ComputerRoom"].ToString());
            ht.Add("Place", context.Request["Place"].ToString());
            ht.Add("GroupMemberNumber", context.Request["GroupMemberNumber"].ToString());
            ht.Add("GroupNumber", context.Request["GroupNumber"].ToString());
            ht.Add("NeedEquip", context.Request["NeedEquip"].ToString());
            ht.Add("Contents", context.Request["Contents"].ToString());
            ht.Add("Editor", context.Request["Editor"].ToString());
            ht.Add("Id", context.Request["Id"].ToString());
            ht.Add("Class", context.Request["Class"].ToString());
            ht.Add("Category", context.Request["Category"].ToString());


            //string result = BllExperiment.Update(ModelExperiment).ToString();
            EmsModel.JsonModel Model = BllExperiment.UpdateExperiment(ht);

            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            //jss.Serialize(result);

            //输出Json
            context.Response.Write(callback + "({\"result\":" + jss.Serialize(Model) + "})");
            context.Response.End();
        }

        /// <summary>
        /// 重名验证
        /// </summary>
        /// <returns>结果</returns>

        public void RepeatName(HttpContext context)
        {

            string Name = context.Request["Name"].ToString();


            //ModelExperiment.Name = Name;//教学计划名称

            //int result = BllPlan.Update(ModelExperiment);

            //System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            //jss.Serialize(result);

            //输出Json
            //context.Response.Write("{\"result\":" + result.ToString() + "}");
            context.Response.End();
        }

        /// <summary>
        /// 删除实验
        /// </summary>
        /// <returns>结果</returns>

        public void DeleteExperiment(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];
            Hashtable ht = new Hashtable();
            ht.Add("Id", context.Request["Id"].ToString());
            ht.Add("Editor", context.Request["Editor"].ToString());

            EmsModel.JsonModel Model = BllExperiment.MarkDelete(ht);

            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            //jss.Serialize(result);

            //输出Json
            context.Response.Write(callback + "({\"result\":" + jss.Serialize(Model) + "})");
            context.Response.End();
        }

        /// <summary>
        /// 获得实验设备详情状态列表
        /// </summary>
        /// <returns></returns>

        public void GetExperimentEquipList(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];
            Hashtable ht = new Hashtable();
            ht.Add("RelationID", context.Request["Id"].ToString());

            EmsModel.JsonModel Model = BLLEquipList.GetExperimentEquipList(ht);

            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            //jss.Serialize(ModelPlan);

            context.Response.Write(callback + "({\"result\":" + jss.Serialize(Model) + "})");
            context.Response.End();
        }
        /// <summary>
        /// 获得订单设备
        /// </summary>
        /// <returns></returns>

        public void GetOrderEquipList(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];
            Hashtable ht = new Hashtable();
            ht.Add("ExperimentId", context.Request["Id"].ToString());
            EmsBLL.OrderInfo BLLOrderInfo = new EmsBLL.OrderInfo();
            EmsModel.JsonModel Model = BLLOrderInfo.GetOrderEquipList(ht);

            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            //jss.Serialize(ModelPlan);

            context.Response.Write(callback + "({\"result\":" + jss.Serialize(Model) + "})");
            context.Response.End();
        }

        /// <summary>
        /// 获得班级
        /// </summary>
        /// <returns></returns>

        public void GetClass(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];
            Hashtable ht = new Hashtable();
            if (context.Request["Id"] != null)
            {
                ht.Add("Id", context.Request["Id"].ToString());
            }
            if (context.Request["UseStatus"] != null)
            {
                ht.Add("UseStatus", context.Request["UseStatus"].ToString());
            }
            EmsModel.JsonModel Model = BllExperiment.GetData2(ht);

            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            //jss.Serialize(ModelExperiment);

            context.Response.Write(callback + "({\"result\":" + jss.Serialize(Model) + "})");
            context.Response.End();
        }

        /// <summary>
        /// Edit页数据加载
        /// </summary>
        /// <returns></returns>

        public void DateLoad(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];
            //机房
            Hashtable htComputerRoom = new Hashtable();
            htComputerRoom.Add("Name", "机房");
            EmsBLL.Dictionary BLLDictionary = new EmsBLL.Dictionary();
            EmsModel.JsonModel Model1 = BLLDictionary.GetList(htComputerRoom);

            //实验地点
            Hashtable htPlace = new Hashtable();
            htPlace.Add("Name", "实验地点");
            EmsModel.JsonModel Model2 = BLLDictionary.GetList(htPlace);

            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            //jss.Serialize(ModelExperiment);

            context.Response.Write(callback + "({\"result1\":" + jss.Serialize(Model1) + ",\"result2\":" + jss.Serialize(Model2) + "})");
            context.Response.End();
        }

        /// <summary>
        /// 获得实验数据- 用于日历
        /// </summary>
        /// <returns></returns>

        public void GetExperiment_Calendar(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];
            string isStatus = context.Request["isStatus"];


            EmsBLL.PlanExperiment BLeci = new EmsBLL.PlanExperiment();
            List<EmsModel.View_Calendar_Land> List = BLeci.GetDataFroDateTime(DateTime.Now.ToString("yyyy-MM-dd"), isStatus);

            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            //jss.Serialize(ModelExperiment);

            context.Response.Write(callback + "({\"result\":" + jss.Serialize(List) + "})");
            context.Response.End();
        }
    }
}