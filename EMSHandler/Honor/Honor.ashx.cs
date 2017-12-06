using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EMSHandler.Statistical.Honor
{
    /// <summary>
    /// Honor 的摘要说明
    /// </summary>
    public class Honor : IHttpHandler
    {
        EmsBLL.Honor BllHonor = new EmsBLL.Honor();
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
                    case "GetHonor": GetHonor(context); break;
                    case "AddHonor": AddHonor(context); break;
                    case "UpdateHonor": UpdateHonor(context); break;
                    case "RepeatName": RepeatName(context); break;
                    case "DeleteHonor": RepeatName(context); break;
                   

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
        /// 获得荣誉列表
        /// </summary>
        /// <returns></returns>

        public void GetPage(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];
            Hashtable ht = new Hashtable();
            ht.Add("Name", context.Request["Name"].ToString());
            ht.Add("HonorLevel", context.Request["HonorLevel"].ToString());
            ht.Add("ExperimentName", context.Request["ExperimentName"].ToString());
            ht.Add("IsDelete", context.Request["Filing"].ToString());
            ht.Add("Creator", context.Request["Creator"].ToString());
            if (context.Request["UserRoleID"] != null)
            {
                ht.Add("RoleID", context.Request["UserRoleID"].ToString());
            }
            ht.Add("AdminRoleID", System.Configuration.ConfigurationManager.ConnectionStrings["AdminRoleID"].ToString());
            ht.Add("PageIndex", context.Request["PageIndex"].ToString());
            ht.Add("PageSize", context.Request["PageSize"].ToString());

            EmsModel.JsonModel Model = BllHonor.GetPage(ht);
            Model = nameCommon.AddCreateNameForData(Model, 4, "Creator", "", "Editor");
            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            //jss.Serialize(ModelPlan);

            context.Response.Write(callback + "({\"result\":" + jss.Serialize(Model) + "})");
            context.Response.End();
        }

        /// <summary>
        /// 获得荣誉
        /// </summary>
        /// <returns></returns>

        public void GetHonor(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];
            Hashtable ht = new Hashtable();
            ht.Add("Id", context.Request["Id"].ToString());
            ht.Add("PageIndex", 1);
            ht.Add("PageSize", 10);
            EmsModel.JsonModel Model = BllHonor.GetHonor(ht);

            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            //jss.Serialize(ModelExperiment);

            context.Response.Write(callback + "({\"result\":" + jss.Serialize(Model) + "})");
            context.Response.End();
        }

        /// <summary>
        /// 添加荣誉
        /// </summary>
        /// <returns>结果</returns>

        public void AddHonor(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];

            string Name = context.Request["Name"].ToString();
            string Level = context.Request["Level"].ToString();
            string ExperimentId = context.Request["ExperimentId"].ToString();
            string Creator = context.Request["Creator"].ToString();

            EmsModel.Honor ModelHonor = new EmsModel.Honor();
            ModelHonor.Name = Name;//荣誉名称
            ModelHonor.HonorLevel = Convert.ToInt32(Level);//级别
            ModelHonor.ExperimentId = Convert.ToInt32(ExperimentId);//实验Id
            ModelHonor.Creator = Creator;//创建人登录名
            ModelHonor.CreateTime = DateTime.Now;//创建时间
            ModelHonor.IsDelete = 0;//是否删除 0未删除

            EmsModel.JsonModel Model = BllHonor.AddHonor(ModelHonor);

            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            //jss.Serialize(result);

            //输出Json
            context.Response.Write(callback + "({\"result\":" + jss.Serialize(Model) + "})");
            context.Response.End();
        }

        /// <summary>
        /// 修改荣誉
        /// </summary>
        /// <returns>结果</returns>

        public void UpdateHonor(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];
            Hashtable ht = new Hashtable();
            ht.Add("Name", context.Request["Name"].ToString());
            ht.Add("preName", context.Request["preName"].ToString());
            ht.Add("HonorLevel", context.Request["Level"].ToString());
            ht.Add("ExperimentId", context.Request["ExperimentId"].ToString());
            ht.Add("Editor", context.Request["Editor"].ToString());
            ht.Add("Id", context.Request["Id"].ToString());



            //string result = BllExperiment.Update(ModelExperiment).ToString();
            EmsModel.JsonModel Model = BllHonor.UpdateHonor(ht);

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
        /// 删除荣誉
        /// </summary>
        /// <returns>结果</returns>

        public void DeleteHonor(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];
            Hashtable ht = new Hashtable();
            ht.Add("Id", context.Request["Id"].ToString());
            ht.Add("Editor", context.Request["Editor"].ToString());

            EmsModel.JsonModel Model = BllHonor.MarkDelete(ht);

            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            //jss.Serialize(result);

            //输出Json
            context.Response.Write(callback + "({\"result\":" + jss.Serialize(Model) + "})");
            context.Response.End();
        }
    }
}