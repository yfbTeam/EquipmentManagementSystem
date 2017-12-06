using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EMSHandler.Contract
{
    /// <summary>
    /// Contract 的摘要说明
    /// </summary>
    public class Contract : IHttpHandler
    {
        EmsBLL.ContractInfo BllContract = new EmsBLL.ContractInfo();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            
            string action = context.Request.QueryString["action"];
            if (!string.IsNullOrEmpty(action))
            {
                switch (action)
                {
                    case "GetPage": GetPage(context); break;
                    case "GetContract": GetContract(context); break;
                    case "saveContract": saveContract(context); break;
                    case "DeleteContract": DeleteContract(context); break;
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

            //合同名称
            if (!string.IsNullOrEmpty(context.Request["ContractName"]))
            {
                ht.Add("ContractName", context.Request["ContractName"].ToString());
            }
            if (!string.IsNullOrEmpty(context.Request["AttachmentName"]))
            {
                ht.Add("AttachmentName", context.Request["AttachmentName"].ToString());
            }
            if (!string.IsNullOrEmpty(context.Request["EquipName"]))
            {
                ht.Add("EquipName", context.Request["EquipName"].ToString());
            }
            //创建人
            if (!string.IsNullOrEmpty(context.Request["Creator"]))
            {
                ht.Add("Creator", context.Request["Creator"].ToString());
            }
            //登录账号角色
            if (!string.IsNullOrEmpty(context.Request["UserRoleID"]))
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
            EmsModel.JsonModel List = BllContract.GetPage(ht);
            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            //jss.Serialize(ModelPlan);

            HttpContext.Current.Response.Write(callback + "({\"result\":" + jss.Serialize(List) + "})");
            HttpContext.Current.Response.End();
        }

        public void GetContract(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];
            string Id = context.Request["Id"].ToString();
            EmsModel.JsonModel Model = BllContract.GetContract(Id);
            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();

            HttpContext.Current.Response.Write(callback + "({\"result\":" + jss.Serialize(Model) + "})");
            HttpContext.Current.Response.End();
        }

        public void saveContract(HttpContext context) {
            string callback = context.Request["jsoncallback"];
            Hashtable ht = new Hashtable();
            ht.Add("ContractName", context.Request["name"]);
            ht.Add("ContractNumber",context.Request["number"]);
            ht.Add("Description", context.Request["desc"]);
            ht.Add("PartyB", context.Request["PartyB"]);
            ht.Add("Money", context.Request["Money"]);
            ht.Add("Creator", context.Request["Creator"]);
            ht.Add("Id", context.Request["Id"]);
            ht.Add("operator", context.Request["operator"]);
            string fileJson = context.Request["fileJson"];
            string equipJson = context.Request["equipJson"];
            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            List<EmsModel.FileModel> files = jss.Deserialize<List<EmsModel.FileModel>>(fileJson);
            List<string> equips = jss.Deserialize<List<string>>(equipJson);
            ht.Add("files", files);
            ht.Add("equips", equips);
            EmsModel.JsonModel Model = BllContract.UpdateContract(ht);
            context.Response.Write(callback + "({\"result\":" + jss.Serialize(Model) + "})");
            context.Response.End();
        }

        public void DeleteContract(HttpContext context) 
        {
            string callback = context.Request["jsoncallback"];
            Hashtable ht = new Hashtable();
            ht.Add("Id", context.Request["Id"]);
            EmsModel.JsonModel Model = BllContract.DeleteContract(ht);
            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
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