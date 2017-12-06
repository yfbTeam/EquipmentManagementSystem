using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EMSHandler.Plan
{
    /// <summary>
    /// Plan 的摘要说明
    /// </summary>
    public class Plan : IHttpHandler
    {
        EmsBLL.TeachingPlan BllPlan = new EmsBLL.TeachingPlan();
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
                    case "GetPlan": GetPlan(context); break;
                    case "AddPlan": AddPlan(context); break;
                    case "UpdatePlan": UpdatePlan(context); break;
                    case "DeletePlan": DeletePlan(context); break;
                    case "IsFiling": IsFiling(context); break;
                    case "RepeatName": RepeatName(context); break;
                    case "GetTeacherOption": GetTeacherOption(context); break;
                    default:
                        context.Response.Write("System Error");
                        break;
                }
            }
            context.Response.Write("System Error");
        }

        /// <summary>
        /// 获得教学计划列表
        /// </summary>
        /// <returns></returns>
        public void GetPage(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];
            Hashtable ht = new Hashtable();
            if (context.Request["PIds"] != null)
            {
                ht.Add("PIds", context.Request["PIds"]);
            }
            if (context.Request["Date"] != null)
            {
                ht.Add("Date", context.Request["Date"]);
            }
            //课程名称
            if (context.Request["Name"] != null)
            {
                ht.Add("Name", context.Request["Name"].ToString());
            }
            //实验名称
            if (context.Request["EName"] != null)
            {
                ht.Add("EName", context.Request["EName"].ToString());
            }
            //学年学期
            if (context.Request["LearnYear"] != null)
            {
                ht.Add("LearnYear", context.Request["LearnYear"].ToString());
            }
            //是否删除
            if (context.Request["IsDelete"] != null)
            {
              //  ht.Add("IsDelete", context.Request["Filing"].ToString());
                ht.Add("IsDelete", context.Request["IsDelete"].ToString());
            }
            //ht.Add("StartDate", context.Request["StartDate"].ToString());
            //ht.Add("EndDate", context.Request["EndDate"].ToString());
            //创建人
            if (context.Request["Creator"] != null)
            {
                ht.Add("Creator", context.Request["Creator"].ToString());
            }
            //登录账号角色
            if (context.Request["UserRoleID"] != null)
            {
                ht.Add("RoleID", context.Request["UserRoleID"].ToString());
            }
            //第几页
            if (context.Request["PageIndex"] != null)
            {
                ht.Add("PageIndex", context.Request["PageIndex"].ToString());
            }
            else
            {
                ht.Add("PageIndex", "1");
            }
            //每页数量
            if (context.Request["PageSize"] != null)
            {
                ht.Add("PageSize", context.Request["PageSize"].ToString());
            }
            else
            {
                ht.Add("PageSize", "10");
            }

            ht.Add("AdminRoleID", System.Configuration.ConfigurationManager.ConnectionStrings["AdminRoleID"].ToString());
            EmsModel.JsonModel List = BllPlan.GetPage(ht);
            List = nameCommon.AddCreateNameForData(List, 4, "Creator", "", "", context.Request["Name"] ?? "", "LearnYear");
            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            //jss.Serialize(ModelPlan);

            HttpContext.Current.Response.Write(callback + "({\"result\":" + jss.Serialize(List) + "})");
            HttpContext.Current.Response.End();
        }

        /// <summary>
        /// 获得教学计划下拉列表
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

            EmsModel.JsonModel List = BllPlan.GetSelectOption(ht);

            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            //jss.Serialize(ModelPlan);

            HttpContext.Current.Response.Write(callback + "({\"result\":" + jss.Serialize(List) + "})");
            HttpContext.Current.Response.End();
        }

        /// <summary>
        /// 获得课程
        /// </summary>
        /// <returns></returns>
        public void GetPlan(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];
            string Id = context.Request["Id"].ToString();
            EmsModel.JsonModel Model = BllPlan.GetPlan(Id);

            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            //jss.Serialize(ModelPlan);

            HttpContext.Current.Response.Write(callback + "({\"result\":" + jss.Serialize(Model) + "})");
            HttpContext.Current.Response.End();
        }

        /// <summary>
        /// 添加课程
        /// </summary>
        /// <returns>结果</returns>
        public void AddPlan(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];

            string Name = context.Request["Name"].ToString();
            string LearnYear = context.Request["LearnYear"].ToString();
            string Contents = context.Request["Contents"].ToString();
            string Creator = context.Request["Creator"].ToString();
            string MainTeacher = context.Request["MainTeacher"].ToString();
            string GuideTeacher1 = context.Request["GuideTeacher1"].ToString();
            string GuideTeacher2 = context.Request["GuideTeacher2"].ToString();

            EmsModel.TeachingPlan ModelPlan = new EmsModel.TeachingPlan();
            ModelPlan.Name = Name;//课程名称
            ModelPlan.MainTeacher = MainTeacher;//主讲教师
            ModelPlan.GuideTeacher1 = GuideTeacher1;//指导教师1
            ModelPlan.GuideTeacher2 = GuideTeacher2;//指导教师2
            ModelPlan.Contents = Contents;//课程内容
            ModelPlan.LearnYear = Convert.ToInt32(LearnYear);//学年学期ID
            ModelPlan.Creator = Creator;//创建人登录名
            ModelPlan.CreateTime = DateTime.Now;//创建时间
            ModelPlan.IsDelete = 0;//是否删除 0未删除

            EmsModel.JsonModel Model = BllPlan.AddPlan(ModelPlan);


            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            //jss.Serialize(result);

            //输出Json
            //HttpContext.Current.Response.Write(callback + "{\"result\":\"" + result + "\"}");
            HttpContext.Current.Response.Write(callback + "({\"result\":" + jss.Serialize(Model) + "})");
            HttpContext.Current.Response.End();
        }

        /// <summary>
        /// 修改课程
        /// </summary>
        /// <returns>结果</returns>
        public void UpdatePlan(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];
            Hashtable ht = new Hashtable();
            ht.Add("Name", context.Request["Name"].ToString());
            ht.Add("MainTeacher", context.Request["MainTeacher"].ToString());
            ht.Add("GuideTeacher1", context.Request["GuideTeacher1"].ToString());
            ht.Add("GuideTeacher2", context.Request["GuideTeacher2"].ToString());
            ht.Add("LearnYear", context.Request["LearnYear"].ToString());
            ht.Add("Editor", context.Request["Editor"].ToString());
            ht.Add("Contents", context.Request["Contents"].ToString());
            ht.Add("Id", context.Request["Id"].ToString());

            EmsModel.JsonModel Model = BllPlan.UpdatePlan(ht);

            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            //jss.Serialize(result);

            //输出Json
            HttpContext.Current.Response.Write(callback + "({\"result\":" + jss.Serialize(Model) + "})");
            HttpContext.Current.Response.End();
        }

        /// <summary>
        /// 删除课程
        /// </summary>
        /// <returns></returns>
        public void DeletePlan(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];
            Hashtable ht = new Hashtable();
            ht.Add("Id", context.Request["Id"].ToString());
            ht.Add("Editor", context.Request["Editor"].ToString());

            EmsModel.JsonModel Model = BllPlan.MarkDelete(ht);

            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            //jss.Serialize(result);

            //输出Json
            HttpContext.Current.Response.Write(callback + "({\"result\":" + jss.Serialize(Model) + "})");
            HttpContext.Current.Response.End();
        }

        /// <summary>
        /// 是否归档
        /// </summary>
        /// <returns></returns>
        public void IsFiling(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];
            Hashtable ht = new Hashtable();
            ht.Add("Id", context.Request["Id"].ToString());

            EmsModel.JsonModel Model = BllPlan.Filing(ht);

            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            //jss.Serialize(result);

            //输出Json
            HttpContext.Current.Response.Write(callback + "({\"result\":" + jss.Serialize(Model) + "})");
            HttpContext.Current.Response.End();
        }

        /// <summary>
        /// 重名验证
        /// </summary>
        /// <returns>结果</returns>
        public void RepeatName(HttpContext context)
        {

            string Name = context.Request["Name"].ToString();


            //ModelPlan.Name = Name;//教学计划名称

            //int result = BllPlan.Update(ModelPlan);

            //System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            //jss.Serialize(result);

            //输出Json
            //HttpContext.Current.Response.Write("{\"result\":" + result.ToString() + "}");
            HttpContext.Current.Response.End();
        }

        /// <summary>
        /// 获得教师下拉信息
        /// </summary>
        /// <returns></returns>
        public void GetTeacherOption(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];

            EmsModel.JsonModel List = BllPlan.GetTeacherOption();

            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            //jss.Serialize(ModelPlan);

            HttpContext.Current.Response.Write(callback + "({\"result\":" + jss.Serialize(List) + "})");
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