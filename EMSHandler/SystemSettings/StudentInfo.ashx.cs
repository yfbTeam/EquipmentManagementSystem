using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EMSHandler.SystemSettings
{
    /// <summary>
    /// StudentInfo 的摘要说明
    /// </summary>
    public class StudentInfo : IHttpHandler
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
                    case "AddStudentInfo": AddStudentInfo(context); break;
                    case "EditStudentInfo": EditStudentInfo(context); break;
                    default:
                        context.Response.Write("System Error");
                        break;
                }
            }
            context.Response.Write("System Error");
        }


        #region 获取学生列表数据 分页
        public void GetDataPage(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];
            //当前页
            int startIndex = Convert.ToInt32(context.Request["startIndex"]);
            //页容量
            int pageSize = Convert.ToInt32(context.Request["pageSize"]);
            string name = context.Request["name"];
            EmsModel.Student stu = new EmsModel.Student();
            if (!string.IsNullOrEmpty(name))
            {
                stu.Name = name;
            }
            stu.IsDelete = 0;
            //序列化
            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            EmsModel.JsonModel mod = new EmsBLL.Student().GetJsonModel(stu, startIndex, pageSize);
            //输出Json
            HttpContext.Current.Response.Write(callback + "({\"result\":" + jss.Serialize(mod) + "})");
            HttpContext.Current.Response.End();
        }
        #endregion

        #region 根据id获取对象实体
        public void GetModelById(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];
            int stuid = Convert.ToInt32(context.Request["itemid"]);
            //序列化
            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            EmsModel.Student stu = new EmsBLL.Student().GetEmsModel(stuid);
            //输出Json
            HttpContext.Current.Response.Write(callback + "({\"result\":" + jss.Serialize(stu) + "})");
            HttpContext.Current.Response.End();
        }
        #endregion

        #region 添加学生
        public void AddStudentInfo(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];
            string name = context.Request["name"];
            int result;
            if (new EmsBLL.Student().IsNameExists(name))
            {
                result = -1;
            }
            else
            {
                EmsModel.Student stu = new EmsModel.Student();
                stu.Name = name;
                stu.Sex = context.Request["sex"];
                stu.KaNo = context.Request["kano"];
                stu.IDCard = context.Request["idcard"];
                stu.ClassId = Convert.ToInt32(context.Request["classid"]);
                stu.Phone = context.Request["phone"];
                stu.Remarks = context.Request["remarks"];
                stu.Creator = context.Request["useridcard"];
                stu.CreateTime = DateTime.Now;
                stu.IsDelete = 0;
                stu.UseStatus = 0;
                result = new EmsBLL.Student().Add(stu);
            }
            //输出Json
            HttpContext.Current.Response.Write(callback + "({\"result\":" + result + "})");
            HttpContext.Current.Response.End();
        }
        #endregion

        #region 编辑学生
        public void EditStudentInfo(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];
            int stuid = Convert.ToInt32(context.Request["itemid"]);
            string name = context.Request["name"];
            int result;
            if (new EmsBLL.Student().IsNameExists(name, stuid))
            {
                result = -1;
            }
            else
            {
                EmsModel.Student stu = new EmsBLL.Student().GetEmsModel(stuid);
                stu.Id = stuid;
                stu.Name = name;
                stu.Sex = context.Request["sex"];
                stu.KaNo = context.Request["kano"];
                stu.IDCard = context.Request["idcard"];
                stu.ClassId = Convert.ToInt32(context.Request["classid"]);
                stu.Phone = context.Request["phone"];
                stu.Remarks = context.Request["remarks"];
                stu.Editor = context.Request["useridcard"];
                stu.UpdateTime = DateTime.Now;
                result = new EmsBLL.Student().Update(stu);
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