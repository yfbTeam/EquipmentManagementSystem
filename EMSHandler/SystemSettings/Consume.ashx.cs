using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EMSHandler.SystemSettings
{
    /// <summary>
    /// Consume 的摘要说明
    /// </summary>
    public class Consume : IHttpHandler
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
                    case "AddConsume": AddConsume(context); break;
                    case "EditConsume": EditConsume(context); break;
                    case "GetJsonModelByEquipId": GetJsonModelByEquipId(context); break;
                    case "EquipIntoCount": EquipIntoCount(context); break;
                    default:
                        context.Response.Write("System Error");
                        break;
                }
            }
            context.Response.Write("System Error");
        }

        #region 获取耗材列表数据 分页
        public void GetDataPage(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];
            Hashtable ht = new Hashtable();
            if (!string.IsNullOrEmpty(context.Request["name"]))
            {
                ht.Add("AssetName", context.Request["name"].ToString());
            }
            if (!string.IsNullOrEmpty(context.Request["Id"]))
            {
                ht.Add("EquipKindId", context.Request["Id"].ToString());
            }
            ht.Add("IsConsume", "1");
            ht.Add("IsDelete", "0");
            ht.Add("PageIndex", context.Request["startIndex"].ToString());
            ht.Add("PageSize", context.Request["pageSize"].ToString());

            EmsModel.JsonModel Model = new EmsBLL.EquipDetail().GetPage(ht);

            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();

            HttpContext.Current.Response.Write(callback + "({\"result\":" + jss.Serialize(Model) + "})");
            HttpContext.Current.Response.End();
        }
        #endregion

        #region 根据id获取对象实体
        public void GetModelById(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];
            int insEpid = Convert.ToInt32(context.Request["itemid"]);
            //序列化
            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            EmsModel.EquipDetail insEp = new EmsBLL.EquipDetail().GetEmsModel(insEpid);
            //输出Json
            HttpContext.Current.Response.Write(callback + "({\"result\":" + jss.Serialize(insEp) + "})");
            HttpContext.Current.Response.End();
        }
        #endregion

        #region 添加耗材
        public void AddConsume(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];
            string name = context.Request["name"];
            byte type = Convert.ToByte(HttpContext.Current.Request["type"]);
            int result;
            if (new EmsBLL.EquipDetail().IsInsEpExists(name,type))
            {
                result = -1;
            }
            else
            {
                string useridcard = context.Request["useridcard"];
                int count = Convert.ToInt32(context.Request["count"]);
                string unit = context.Request["unit"];
                string remarks = context.Request["remarks"];
                EmsModel.EquipDetail insEp = new EmsModel.EquipDetail();
                insEp.AssetNumber = "";
                insEp.AssetName = name;
                insEp.Count = count;
                insEp.Unit = unit;
                insEp.Type = type;
                insEp.EquipSource = 0;//0本院资产;1资产系统
                insEp.IsConsume = 1;
                insEp.Remarks = remarks;
                insEp.Creator = useridcard;
                insEp.CreateTime = DateTime.Now;
                insEp.IsDelete = 0;
                insEp.UseStatus = 0;
                insEp.EquipKindId = 0;
                insEp.EquipIntoID = 0;
                insEp.EquipStatus = 0;
                insEp.Barcode = "";
                insEp.ClassNumber = "";
                insEp.AssetsClassName = name;
                insEp.IntlClassCode = "";
                insEp.IntlClassName = "";
                insEp.UsageStatus = "";
                insEp.UsageDirection = "";
                insEp.JYBBBSYFX = "";
                insEp.AcquisitionMethod = "";
                insEp.AcquisitionDate = DateTime.Now;
                insEp.BrandStandardModel = "";
                insEp.EquipmentUse = "";
                insEp.UseDepartment = "";
                insEp.UsePeople = "";
                insEp.Factory = "";
                insEp.StorageLocation = "0";
                insEp.WorthType = "";
                insEp.UseNature = "";
                insEp.Worth = 0;
                insEp.FinanceRecordType = "";
                insEp.FundsSubject = "";
                insEp.CountryCode = "";
                insEp.Operator = useridcard;
                insEp.FinanceRecordType = "";
                insEp.FinanceRecordType = "";
                insEp.FinanceRecordType = "";
                insEp.ManualModify = 0;
                result = new EmsBLL.EquipDetail().Add(insEp);
            }
            //输出Json
            HttpContext.Current.Response.Write(callback + "({\"result\":" + result + "})");
            HttpContext.Current.Response.End();
        }
        #endregion

        #region 编辑耗材
        public void EditConsume(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];
            int insEpid = Convert.ToInt32(context.Request["itemid"]);
            string name = context.Request["name"];
            byte type = Convert.ToByte(HttpContext.Current.Request["type"]);
            int result;
            if (new EmsBLL.EquipDetail().IsInsEpExists(name,type,insEpid))
            {
                result = -1;
            }
            else
            {
                EmsModel.EquipDetail insEp = new EmsBLL.EquipDetail().GetEmsModel(insEpid);
                string useridcard = context.Request["useridcard"];
                string unit = context.Request["unit"];
                string remarks = context.Request["remarks"];
                insEp.Id = insEpid;
                insEp.AssetName = name;
                insEp.AssetsClassName = name;
                insEp.Unit = unit;
                insEp.Type = type;
                insEp.Remarks = remarks;
                insEp.Editor = useridcard;
                insEp.UpdateTime = DateTime.Now;
                result = new EmsBLL.EquipDetail().Update(insEp);
            }
            //输出Json
            HttpContext.Current.Response.Write(callback + "({\"result\":" + result + "})");
            HttpContext.Current.Response.End();
        }
        #endregion

        #region 根据Id获取仪器设备历史列表数据 分页
        public void GetJsonModelByEquipId(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];
            Hashtable ht = new Hashtable();
            ht.Add("EquipId", context.Request["EquipId"] ?? "");
            ht.Add("PageIndex", context.Request["PageIndex"] ?? "1");
            ht.Add("PageSize", context.Request["PageSize"] ?? "10");
            bool ispage = true;
            if (!string.IsNullOrEmpty(context.Request["ispage"]))
            {
                ispage = Convert.ToBoolean(context.Request["ispage"]);
            }            
            //序列化
            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            EmsModel.JsonModel mod = new EmsBLL.EquipDetail().GetJsonModelByEquipId(ht, ispage);
            mod = nameCommon.AddCreateNameForData(mod, 4, "UserIDCard","","",context.Request["Name"]??"");
            //输出Json
            HttpContext.Current.Response.Write(callback + "({\"result\":" + jss.Serialize(mod) + "})");
            HttpContext.Current.Response.End();
        }
        #endregion

        #region 耗材入库
        public void EquipIntoCount(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];
            int itemid = Convert.ToInt32(context.Request["itemid"]);
            int count = Convert.ToInt32(context.Request["count"]);
            EmsModel.EquipDetail equip = new EmsBLL.EquipDetail().GetEmsModel(itemid);
            equip.Id = itemid;
            equip.Count = equip.Count + count;
            equip.Editor = context.Request["useridcard"];
            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            EmsModel.JsonModel mod = new EmsBLL.EquipDetail().EquipIntoCount(equip, count);
            //输出Json
            HttpContext.Current.Response.Write(callback + "({\"result\":" + jss.Serialize(mod) + "})");
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