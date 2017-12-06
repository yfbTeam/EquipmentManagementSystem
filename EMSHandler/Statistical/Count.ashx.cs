using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EMSHandler.Statistical
{
    /// <summary>
    /// Count 的摘要说明
    /// </summary>
    public class Count : IHttpHandler
    {
        EmsBLL.CountALL bc = new EmsBLL.CountALL();

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");

            string action=context.Request["action"];
                if (!string.IsNullOrEmpty(action))
                {
                    switch (action)
                    {
                        case "CountAll":
                            CountAll( context);
                            break;
                        default:
                            break;
                    }
                }
        }
        /// <summary>
        /// 查询所有
        /// </summary>
        public void CountAll(HttpContext context)
        {
            //string callback = HttpContext.Current.Request["action"];
            //Hashtable ht = new Hashtable();
            //ht.Add("sum", HttpContext.Current.Request["sum"].ToString());
            //ht.Add("Type", HttpContext.Current.Request["Type"].ToString());

            //EmsModel.JsonModel Model = bc.CountALLb(ht);

            //System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            //jss.Serialize(Model);

            //输出Json
            string callbackFunName = context.Request["callbackparam"];
            context.Response.Write(callbackFunName + "(" + bc.CountALLb() + ")");
            //HttpContext.Current.Response.Write(bc.CountALLb());

            context.Response.End();

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