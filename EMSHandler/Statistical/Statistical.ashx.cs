using EmsBLL;
using EmsModel;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;

namespace EMSHandler.Statistical
{
    /// <summary>
    /// Statistical 的摘要说明
    /// </summary>
    public class Statistical : IHttpHandler
    {

        EmsBLL.InstrumentEquip BllIE = new EmsBLL.InstrumentEquip();
        EmsBLL.EquipDetail BLLED = new EmsBLL.EquipDetail();
        EmsBLL.BorrowRecord BLLBR = new EmsBLL.BorrowRecord();
        GetUserNameHandler nameCommon = new GetUserNameHandler();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string action = context.Request.QueryString["action"];
            if (!string.IsNullOrEmpty(action))
            {
                switch (action)
                {
                    case "GetPageStock": GetPageStock(context); break;
                    case "GetModel": GetModel(context); break;
                    case "GetPageEquipDetail": GetPageEquipDetail(context); break;
                    case "GetEquipDetail": GetEquipDetail(context); break;
                    case "ImportEquip": ImportEquip(context); break;
                    case "GetOfficeFurOwner": GetOfficeFurOwner(context); break;
                    case "GetPageStock2": GetPageStock2(context); break;
                    case "AddEquip": AddEquip(context); break;
                    case "UpdateEquip": UpdateEquip(context); break;
                    case "GetEquip": GetEquip(context); break;
                    case "ExportEquipExcel": ExportEquipExcel(context); break;
                    case "UpdateStatus": UpdateStatus(context); break;
                    case "SelectCountALL": SelectCountALL(context); break;
                    case "SelectCountBG": SelectCountBG(context); break;
                    case "EquipborrowManage": EquipborrowManage(context); break;
                    case "SetEquipDatailBC": SetEquipDatailBC(context); break;
                    case "getBorrowRecord": getBorrowRecord(context); break;
                    case "setBorrowRecord": setBorrowRecord(context); break;
                    case "DeleteBorrowRecord": DeleteBorrowRecord(context); break;
                    case "AuditingBorrow": AuditingBorrow(context); break;
                    case "GetPage": GetPage(context); break;
                    case "GetPageList": GetPageList(context); break;
                    case "GetPageEquipDetailNew": GetPageEquipDetailNew(context); break;
                    case "SelectCountPlan_Status": SelectCountPlan_Status(context); break;
                    case "SelectCountPlan_Type": SelectCountPlan_Type(context); break;
                    default:
                        context.Response.Write("System Error");
                        break;
                   
                }
            }
            context.Response.Write("System Error");
        }



        /// <summary>
        /// 分页获得设备库存列表
        /// </summary>
        /// <returns></returns>

        public void GetPageStock(HttpContext context)
        {
            string callback =context.Request["jsoncallback"];
            Hashtable ht = new Hashtable();
            if (!string.IsNullOrEmpty(context.Request["Name"]))
            {
                ht.Add("AssetsClassName",context.Request["Name"].ToString());
            }
            if (!string.IsNullOrEmpty(context.Request["Type"]))
            {
                ht.Add("Type",context.Request["Type"].ToString());
            }
            //ht.Add("WarehouseId",context.Request["WarehouseId"].ToString());
            //ht.Add("IsDelete", "");
            //ht.Add("Type",context.Request["Type"].ToString());
            ht.Add("PageIndex",context.Request["PageIndex"].ToString());
            ht.Add("PageSize",context.Request["PageSize"].ToString());

            EmsModel.JsonModel Model = BLLED.GetPageStock(ht);

            //查询总数
            Hashtable htCount = new Hashtable();
            //if (!string.IsNullOrEmpty(context.Request["Type"]))
            //{
            //    htCount.Add("Type",context.Request["Type"].ToString());
            //}
            htCount.Add("IsDelete", "");
            EmsModel.JsonModel Model2 = BLLED.GetDataCount(htCount);

            //查询科研设备总数
            Hashtable htCount0 = new Hashtable();
            htCount0.Add("Type", 0);
            htCount0.Add("IsDelete", "");
            EmsModel.JsonModel Model3 = BLLED.GetDataCount(htCount0);

            //查询总数
            Hashtable htCount1 = new Hashtable();
            htCount1.Add("Type", 1);
            htCount1.Add("IsDelete", "");
            EmsModel.JsonModel Model4 = BLLED.GetDataCount(htCount1);

            //查询总数
            Hashtable htCount2 = new Hashtable();
            htCount2.Add("Type", 2);
            htCount2.Add("IsDelete", "");
            EmsModel.JsonModel Model5 = BLLED.GetDataCount(htCount2);

            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            //jss.Serialize(ModelPlan);

           context.Response.Write(callback + "({\"result\":" + jss.Serialize(Model) + ",\"result2\":" + jss.Serialize(Model2) + ",\"result3\":" + jss.Serialize(Model3) + ",\"result4\":" + jss.Serialize(Model4) + ",\"result5\":" + jss.Serialize(Model5) + "})");
           context.Response.End();
        }

        /// <summary>
        /// 获得分类信息
        /// </summary>
        /// <returns></returns>

        public void GetModel(HttpContext context)
        {
            string callback =context.Request["jsoncallback"];
            Hashtable ht = new Hashtable();
            ht.Add("Id",context.Request["Id"].ToString());

            EmsModel.JsonModel Model = BllIE.GetModel(ht);

            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            //jss.Serialize(ModelPlan);

           context.Response.Write(callback + "({\"result\":" + jss.Serialize(Model) + "})");
           context.Response.End();
        }
        /// <summary>
        /// 分页获得设备详情列表
        /// </summary>
        /// <returns></returns>

        public void GetPageEquipDetail(HttpContext context)
        {
            string callback =context.Request["jsoncallback"];
            Hashtable ht = new Hashtable();
            if (!string.IsNullOrEmpty(context.Request["Name"]))
            {
                ht.Add("AssetName",context.Request["Name"].ToString());
            }
            if (!string.IsNullOrEmpty(context.Request["Id"]))
            {
                ht.Add("EquipKindId",context.Request["Id"].ToString());
            }
            if (context.Request["AssetsClassName"] != null)
            {
                ht.Add("AssetsClassName",context.Request["AssetsClassName"].ToString());
            }
            if (context.Request["StorageLocation"] != null)
            {
                ht.Add("StorageLocation",context.Request["StorageLocation"].ToString());
            }
            if (!string.IsNullOrEmpty(context.Request["SerRoomid"]))
            {
                ht.Add("SerRoomid",context.Request["SerRoomid"].ToString());
            }
            if (!string.IsNullOrEmpty(context.Request["SerEquipOwner"]))  //负责人
            {
                ht.Add("SerEquipOwner",context.Request["SerEquipOwner"].ToString());
            }
            if (context.Request["SLSymbol"] != null)
            {
                ht.Add("SLSymbol",context.Request["SLSymbol"].ToString());
            }
            if (context.Request["Type"] != null)
            {
                ht.Add("Type",context.Request["Type"].ToString());
            }
            if (context.Request["UserRoleID"] != null)
            {
                ht.Add("RoleID",context.Request["UserRoleID"].ToString());
            }
            if (context.Request["EquipOwner"] != null)
            {
                ht.Add("EquipOwner",context.Request["EquipOwner"].ToString());
            }
            if (context.Request["EquipSource"] != null)
            {
                ht.Add("EquipSource",context.Request["EquipSource"].ToString());
            }
            if (context.Request["EquipStatus"] != null)
            {
                ht.Add("EquipStatus", context.Request["EquipStatus"].ToString());
            }
            if (context.Request["BorrowYN"] != null)
            {
                ht.Add("BorrowYN", context.Request["BorrowYN"].ToString());
            }
            ht.Add("AdminRoleID", System.Configuration.ConfigurationManager.ConnectionStrings["AdminRoleID"].ToString());
            ht.Add("IsDelete", "");
            ht.Add("PageIndex",context.Request["PageIndex"].ToString());
            ht.Add("PageSize",context.Request["PageSize"].ToString());

            EmsModel.JsonModel Model = BLLED.GetPage(ht);

            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            //jss.Serialize(ModelPlan);

           context.Response.Write(callback + "({\"result\":" + jss.Serialize(Model) + "})");
           context.Response.End();
        }
        /// <summary>
        /// 获得设备详情信息
        /// </summary>
        /// <returns></returns>

        public void GetEquipDetail(HttpContext context)
        {
            string callback =context.Request["jsoncallback"];
            Hashtable ht = new Hashtable();
            ht.Add("Id",context.Request["Id"].ToString());

            EmsModel.JsonModel Model = BLLED.GetEquipDetail(ht);
            Model = nameCommon.AddCreateNameForData(Model, 4, "Creator", "", "Editor");
            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            //jss.Serialize(ModelPlan);

           context.Response.Write(callback + "({\"result\":" + jss.Serialize(Model) + "})");
           context.Response.End();
        }


        /// <summary>
        /// 导入设备信息
        /// </summary>
        /// <returns></returns>

        public void ImportEquip(HttpContext context)
        {
            string callback =context.Request["jsoncallback"];
            Hashtable ht = new Hashtable();
            ht.Add("Creator",context.Request["Creator"].ToString());
            ht.Add("FilePath",context.Request["FilePath"].ToString());
            ht.Add("UseStatus", System.Configuration.ConfigurationManager.ConnectionStrings["DefaultEquipStatus"].ConnectionString);
            ht.Add("Password", System.Configuration.ConfigurationManager.ConnectionStrings["InitialPassword"].ConnectionString);
            EmsModel.JsonModel Model = BLLED.ImportEquip(ht);

            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            //jss.Serialize(ModelPlan);

           context.Response.Write(callback + "({\"result\":" + jss.Serialize(Model) + "})");
           context.Response.End();
        }

        #region 获取办公家具的负责人

        public void GetOfficeFurOwner(HttpContext context)
        {
            string callback =context.Request["jsoncallback"];
            //序列化
            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            EmsModel.JsonModel mod = new EmsBLL.EquipDetail().GetOfficeFurOwner(); 
            mod = nameCommon.AddCreateNameForData(mod, 4, "OwnerUID", "", "", context.Request["Name"] ?? "");
            StringBuilder orgJson = new StringBuilder();
            if (mod.Status== "ok")
            {
                PagedDataModel<Dictionary<string, object>> pageModel = null;
                pageModel = mod.Data as PagedDataModel<Dictionary<string, object>>;
                List<Dictionary<string, object>> list = pageModel.PagedData as List<Dictionary<string, object>>;
                foreach (Dictionary<string, object> item in list)
                {
                    if (!string.IsNullOrEmpty(item["CreateName"].ToString()))
                    {
                        orgJson.Append("<option value='" + item["OwnerUID"] + "'>" + item["CreateName"] + "</option>");
                    }                    
                }                   
            }
            //输出Json
           context.Response.Write(callback + "({\"result\":\"" + orgJson.ToString() + "\"})");
           context.Response.End();
        }
        #endregion
        
        /// <summary>
        /// 分页查询科研设备信息
        /// </summary>
        /// <returns></returns>

        public void GetPageStock2(HttpContext context)
        {
            string callback =context.Request["jsoncallback"];
            Hashtable ht = new Hashtable();
            if (!string.IsNullOrEmpty(context.Request["Name"]))
            {
                ht.Add("AssetsClassName",context.Request["Name"].ToString());
            }
            if (!string.IsNullOrEmpty(context.Request["UserRoleID"]))
            {
                ht.Add("RoleID",context.Request["UserRoleID"].ToString());
            }
            if (!string.IsNullOrEmpty(context.Request["UserIDCard"]))
            {
                ht.Add("LoginUserIDCard",context.Request["UserIDCard"].ToString());
            }
            if (!string.IsNullOrEmpty(context.Request["distribution"]))
            {
                ht.Add("StorageLocation",context.Request["distribution"].ToString());
            }
            if (!string.IsNullOrEmpty(context.Request["SectionPlace"]))
            {
                ht.Add("SectionPlaceID",context.Request["SectionPlace"].ToString());
            }
            if (!string.IsNullOrEmpty(context.Request["Building"]))
            {
                ht.Add("Building",context.Request["Building"].ToString());
            }
            //ht.Add("WarehouseId",context.Request["WarehouseId"].ToString());
            //ht.Add("IsDelete", "");
            //ht.Add("Type",context.Request["Type"].ToString());
            ht.Add("AdminRoleID", System.Configuration.ConfigurationManager.ConnectionStrings["AdminRoleID"].ToString());
            ht.Add("PageIndex",context.Request["PageIndex"].ToString());
            ht.Add("PageSize",context.Request["PageSize"].ToString());

            EmsModel.JsonModel Model = BLLED.GetPageStock2(ht);

            //查询总数
            Hashtable htCount = new Hashtable();

            htCount.Add("Type", "1");
            htCount.Add("IsDelete", "");
            EmsModel.JsonModel Model2 = BLLED.GetDataCount(htCount);

            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            //jss.Serialize(ModelPlan);

           context.Response.Write(callback + "({\"result\":" + jss.Serialize(Model) + ",\"result2\":" + jss.Serialize(Model2) + "})");
           context.Response.End();
        }

        /// <summary>
        /// 新增设备
        /// </summary>
        /// <returns></returns>

        public void AddEquip(HttpContext context)
        {
            string callback =context.Request["jsoncallback"];
            Hashtable ht = new Hashtable();
            if (!string.IsNullOrEmpty(context.Request["AssetNumber"]))
            {
                ht.Add("AssetNumber",context.Request["AssetNumber"].ToString());
            }
            if (!string.IsNullOrEmpty(context.Request["AssetName"]))
            {
                ht.Add("AssetName",context.Request["AssetName"].ToString());
            }
            if (!string.IsNullOrEmpty(context.Request["Type"]))
            {
                ht.Add("Type",context.Request["Type"].ToString());
            }
            if (!string.IsNullOrEmpty(context.Request["ClassNumbe"]))
            {
                ht.Add("ClassNumbe",context.Request["ClassNumbe"].ToString());
            }
            if (!string.IsNullOrEmpty(context.Request["AssetsClassName"]))
            {
                ht.Add("AssetsClassName",context.Request["AssetsClassName"].ToString());
            }
            if (!string.IsNullOrEmpty(context.Request["IntlClassCode"]))
            {
                ht.Add("IntlClassCode",context.Request["IntlClassCode"].ToString());
            }
            if (!string.IsNullOrEmpty(context.Request["IntlClassName"]))
            {
                ht.Add("IntlClassName",context.Request["IntlClassName"].ToString());
            }
            if (!string.IsNullOrEmpty(context.Request["Unit"]))
            {
                ht.Add("Unit",context.Request["Unit"].ToString());
            }

            if (!string.IsNullOrEmpty(context.Request["BrandStandardModel"]))
            {
                ht.Add("BrandStandardModel",context.Request["BrandStandardModel"].ToString());
            }
            if (!string.IsNullOrEmpty(context.Request["UsageDirection"]))
            {
                ht.Add("UsageDirection",context.Request["UsageDirection"].ToString());
            }
            if (!string.IsNullOrEmpty(context.Request["Remarks"]))
            {
                ht.Add("Remarks",context.Request["Remarks"].ToString());
            }
            if (!string.IsNullOrEmpty(context.Request["ImageName"]))
            {
                ht.Add("ImageName", context.Request["ImageName"].ToString());
            }
            if (!string.IsNullOrEmpty(context.Request["ImageUrl"]))
            {
                ht.Add("ImageUrl", context.Request["ImageUrl"].ToString());
            }
            EmsModel.JsonModel Model = BLLED.AddEquip(ht);

            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            //jss.Serialize(ModelPlan);

           context.Response.Write(callback + "({\"result\":" + jss.Serialize(Model) + "})");
           context.Response.End();
        }

        /// <summary>
        /// 修改设备
        /// </summary>
        /// <returns>结果</returns>

        public void UpdateEquip(HttpContext context)
        {
            string callback =context.Request["jsoncallback"];
            Hashtable ht = new Hashtable();
            if (!string.IsNullOrEmpty(context.Request["ID"]))
            {
                ht.Add("ID",context.Request["ID"].ToString());
            }
            //if (!string.IsNullOrEmpty(context.Request["AssetNumber"]))
            //{
            //    ht.Add("AssetNumber",context.Request["AssetNumber"].ToString());
            //}
            if (!string.IsNullOrEmpty(context.Request["AssetName"]))
            {
                ht.Add("AssetName",context.Request["AssetName"].ToString());
            }
            if (!string.IsNullOrEmpty(context.Request["Type"]))
            {
                ht.Add("Type",context.Request["Type"].ToString());
            }
            if (!string.IsNullOrEmpty(context.Request["ClassNumber"]))
            {
                ht.Add("ClassNumber",context.Request["ClassNumber"].ToString());
            }
            if (!string.IsNullOrEmpty(context.Request["AssetsClassName"]))
            {
                ht.Add("AssetsClassName",context.Request["AssetsClassName"].ToString());
            }
            if (!string.IsNullOrEmpty(context.Request["IntlClassCode"]))
            {
                ht.Add("IntlClassCode",context.Request["IntlClassCode"].ToString());
            }
            if (!string.IsNullOrEmpty(context.Request["IntlClassName"]))
            {
                ht.Add("IntlClassName",context.Request["IntlClassName"].ToString());
            }
            if (!string.IsNullOrEmpty(context.Request["Unit"]))
            {
                ht.Add("Unit",context.Request["Unit"].ToString());
            }

            if (!string.IsNullOrEmpty(context.Request["BrandStandardModel"]))
            {
                ht.Add("BrandStandardModel",context.Request["BrandStandardModel"].ToString());
            }
            if (!string.IsNullOrEmpty(context.Request["UsageDirection"]))
            {
                ht.Add("UsageDirection",context.Request["UsageDirection"].ToString());
            }
            if (!string.IsNullOrEmpty(context.Request["Remarks"]))
            {
                ht.Add("Remarks",context.Request["Remarks"].ToString());
            }
            if (!string.IsNullOrEmpty(context.Request["UserIDCard"]))
            {
                ht.Add("UserIDCard",context.Request["UserIDCard"].ToString());
            }
            if (!string.IsNullOrEmpty(context.Request["ImageName"]))
            {
                ht.Add("ImageName", context.Request["ImageName"].ToString());
            }
            if (!string.IsNullOrEmpty(context.Request["ImageUrl"]))
            {
                ht.Add("ImageUrl", context.Request["ImageUrl"].ToString());
            }
            EmsModel.JsonModel Model = BLLED.UpdateEquip(ht);

            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            //jss.Serialize(result);

            //输出Json
           context.Response.Write(callback + "({\"result\":" + jss.Serialize(Model) + "})");
           context.Response.End();
        }

        /// <summary>
        /// 获得设备信息
        /// </summary>
        /// <returns></returns>

        public void GetEquip(HttpContext context)
        {
            string callback =context.Request["jsoncallback"];
            Hashtable ht = new Hashtable();
            ht.Add("Id",context.Request["Id"].ToString());

            EmsModel.JsonModel Model = BLLED.GetEquip(ht);

            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            //jss.Serialize(ModelPlan);

           context.Response.Write(callback + "({\"result\":" + jss.Serialize(Model) + "})");
           context.Response.End();
        }


        /// <summary>
        /// 导出设备Excel
        /// </summary>
        /// <returns></returns>

        public void ExportEquipExcel(HttpContext context)
        {
            string callback =context.Request["jsoncallback"];
            Hashtable ht = new Hashtable();
            if (!string.IsNullOrEmpty(context.Request["Id"]))
            {
                ht.Add("Id",context.Request["Id"].ToString());
            }
            if (!string.IsNullOrEmpty(context.Request["ColumnsName"]))
            {
                ht.Add("ColumnsName",context.Request["ColumnsName"].ToString());
            }
            if (!string.IsNullOrEmpty(context.Request["EquipSource"]))
            {
                ht.Add("EquipSource",context.Request["EquipSource"].ToString());
            }
            if (!string.IsNullOrEmpty(context.Request["ClassName"]))
            {
                ht.Add("ClassName",context.Request["ClassName"].ToString());
            }
            EmsModel.JsonModel Model = BLLED.ExportEquipExcel(ht);

            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            jss.MaxJsonLength = Int32.MaxValue; //取得最大数值
            //jss.Serialize(ModelPlan);

           context.Response.Write(callback + "({\"result\":" + jss.Serialize(Model) + "})");
           context.Response.End();
        }

        /// <summary>
        /// 修改状态
        /// </summary>
        /// <returns></returns>

        public void UpdateStatus(HttpContext context)
        {
            string callback =context.Request["jsoncallback"];
            Hashtable ht = new Hashtable();
            if (!string.IsNullOrEmpty(context.Request["Id"]))
            {
                ht.Add("Id",context.Request["Id"].ToString());
            }
            if (!string.IsNullOrEmpty(context.Request["EquipStatus"]))
            {
                ht.Add("EquipStatus",context.Request["EquipStatus"].ToString());
            }
            EmsModel.JsonModel Model = BLLED.UpdateStatus(ht);

            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            //jss.Serialize(ModelPlan);

           context.Response.Write(callback + "({\"result\":" + jss.Serialize(Model) + "})");
           context.Response.End();
        }



        public void SelectCountALL(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];
            EmsBLL.View_CountALL View_CountALL = new EmsBLL.View_CountALL();
            DataTable dt = View_CountALL.SelectView_CountALL();

            List<object> lists = new List<object>();
            foreach (DataRow dr in dt.Rows)
            {
                //EmsModel.View_CountALL all = new EmsModel.View_CountALL();
                //all.Name = dr["Name"].ToString();
                //all.value = Convert.ToInt32(dr["value"]);
                var obj = new { name = dr["Name"], value = dr["value"] };
                lists.Add(obj);
            }

            JavaScriptSerializer jss = new JavaScriptSerializer();
            context.Response.Write(callback + "({\"result\":" + jss.Serialize(lists) + "})");
            context.Response.End();

        }


        public void EquipborrowManage(HttpContext context) 
        {
            int BorrowYN = Convert.ToInt32(context.Request["BorrowYN"]);
            string EQtype = context.Request["EQtype"];
            string name = context.Request["name"];
            int index =Convert.ToInt32(context.Request["index"]);
            if (EQtype != "")
            {
                Byte ByEQtype = Convert.ToByte(EQtype);
            }


            string callback = context.Request["jsoncallback"];
            EmsBLL.EquipborrowManage EquipborrowManage = new EmsBLL.EquipborrowManage();
            DataTable dt = EquipborrowManage.SelectRepairDetails(BorrowYN, EQtype, name,index);

            List<EmsModel.View_EquipDatail> list = new EmsBLL.EquipborrowManage().GetList(dt);

            JavaScriptSerializer jss = new JavaScriptSerializer();
            jss.MaxJsonLength = Int32.MaxValue;
            context.Response.Write(callback + "({\"result\":" + jss.Serialize(list) + "})");
            context.Response.End();
        }


        public void SetEquipDatailBC(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];
            string YSelectStr = context.Request["YSelectStr"];
            string DSelectStr = context.Request["DSelectStr"];

            List<object> lists = new List<object>();
            string str = new EmsBLL.EquipborrowManage().setEquipDetail(YSelectStr, DSelectStr);
            var obj = new { name ="str", value = str };
            lists.Add(obj);


            JavaScriptSerializer jss = new JavaScriptSerializer();
            context.Response.Write(callback + "({\"result\":" + jss.Serialize(lists) + "})");
            context.Response.End();
          
        }

        public void getBorrowRecord(HttpContext context) 
        {
            string BeginDate = context.Request["BeginDate"];
            string EndDate = context.Request["EndDate"];
            string BorrowStatus = context.Request["BorrowStatus"];
            string UserIDCard = context.Request["UserIDCard"];
            string callback = context.Request["jsoncallback"];
          

            Hashtable ht = new Hashtable();
            if (!string.IsNullOrEmpty(context.Request["BeginDate"]))
            {
                ht.Add("BeginDate", context.Request["BeginDate"].ToString());
            }
            if (!string.IsNullOrEmpty(context.Request["BorrowStatus"]))
            {
                ht.Add("BorrowStatus", context.Request["BorrowStatus"].ToString());
            }
            if (!string.IsNullOrEmpty(context.Request["UserIDCard"]))
            {
                ht.Add("UserIDCard", context.Request["UserIDCard"].ToString());
            }
            if (!string.IsNullOrEmpty(context.Request["EndDate"]))
            {
                ht.Add("EndDate", context.Request["EndDate"].ToString());
            }

            ht.Add("PageIndex", context.Request["PageIndex"].ToString());
            ht.Add("PageSize", context.Request["PageSize"].ToString());

            EmsModel.JsonModel Model = BLLBR.GetPage(ht);
            Model = nameCommon.AddCreateNameForData(Model, 4, "IDCard");
            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
          

            context.Response.Write(callback + "({\"result\":" + jss.Serialize(Model) + "})");
            context.Response.End();


        }



        public void setBorrowRecord(HttpContext context) 
        {
            string callback = context.Request["jsoncallback"];
            Hashtable ht = new Hashtable();


            ht.Add("Id", context.Request["Id"]);
            ht.Add("UserIDCard", context.Request["UserIDCard"]);
            ht.Add("BeginDate", context.Request["BeginDate"]);
            ht.Add("EndDate", context.Request["EndDate"]);
            ht.Add("BorrowReason", context.Request["BorrowReason"]);
            ht.Add("Notes", context.Request["Notes"]);
            ht.Add("operator", context.Request["operator"]);
            string equipJson = context.Request["equipJson"];
            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            List<string> equips = jss.Deserialize<List<string>>(equipJson);
            ht.Add("equips", equips);


            EmsModel.JsonModel Model = BLLBR.SetBorrowRecord(ht);
            context.Response.Write(callback + "({\"result\":" + jss.Serialize(Model) + "})");
            context.Response.End();
        }

        /// <summary>
        /// 删除借用信息
        /// </summary>
        /// <param name="context"></param>
        public void DeleteBorrowRecord(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];
            Hashtable ht = new Hashtable();
            ht.Add("Id", context.Request["Id"]);

            EmsModel.JsonModel Model = BLLBR.DeleteBorrowRecord(ht);
            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            //输出Json
            HttpContext.Current.Response.Write(callback + "({\"result\":" + jss.Serialize(Model) + "})");
            HttpContext.Current.Response.End();
        }


        public void AuditingBorrow(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];
            Hashtable ht = new Hashtable();
            ht.Add("Id", context.Request["Id"]);
            ht.Add("BorrowStatus", context.Request["BorrowStatus"]);

            EmsModel.JsonModel Model = BLLBR.AuditingBorrow(ht);
            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            //输出Json
            HttpContext.Current.Response.Write(callback + "({\"result\":" + jss.Serialize(Model) + "})");
            HttpContext.Current.Response.End();
        }



        public void GetPage(HttpContext context) 
        {
            string callback = context.Request["jsoncallback"];
            Hashtable ht = new Hashtable();
            int id=Convert.ToInt32( context.Request["Id"]);

            EmsModel.JsonModel Model = BLLBR.GetPage(id);
            Model = nameCommon.AddCreateNameForData(Model, 4, "IDCard");
            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            HttpContext.Current.Response.Write(callback + "({\"result\":" + jss.Serialize(Model) + "})");
            HttpContext.Current.Response.End();
        }



        public void GetPageList(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];
            Hashtable ht = new Hashtable();
            int id = Convert.ToInt32(context.Request["Id"]);

            EmsModel.JsonModel Model = BLLBR.GetPageList(id);
            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            HttpContext.Current.Response.Write(callback + "({\"result\":" + jss.Serialize(Model) + "})");
            HttpContext.Current.Response.End();
        }



        public void GetPageEquipDetailNew(HttpContext context) 
        {
            string callback = context.Request["jsoncallback"];
            Hashtable ht = new Hashtable();
            if (!string.IsNullOrWhiteSpace(Convert.ToString(context.Request["Type"] )))
            {
                ht.Add("Type", context.Request["Type"]);
            }
            if (!string.IsNullOrWhiteSpace(Convert.ToString(context.Request["UserRoleID"])))
            {
                ht.Add("RoleID", context.Request["UserRoleID"]);
            }
            if (!string.IsNullOrWhiteSpace(Convert.ToString(context.Request["StorageLocation"])))
            {
                ht.Add("StorageLocation", context.Request["StorageLocation"]);
            }
            if (!string.IsNullOrWhiteSpace(Convert.ToString(context.Request["EquipStatus"])))
            {
                ht.Add("EquipStatus", context.Request["EquipStatus"]);
            }
            string operation = context.Request["Operation"].ToString();
            ht.Add("PageIndex", context.Request["PageIndex"].ToString());
            ht.Add("PageSize", context.Request["PageSize"].ToString());
            ht.Add("AdminRoleID", System.Configuration.ConfigurationManager.ConnectionStrings["AdminRoleID"].ToString());
            EmsModel.JsonModel Model = BLLED.GetPage(ht);

            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            context.Response.Write(callback + "({\"result\":" + jss.Serialize(Model) + "})");
            context.Response.End();

        }

        public void SelectCountBG(HttpContext context)
        {
            string callback =context.Request["jsoncallback"];
            EmsBLL.View_CountBG View_CountBG = new EmsBLL.View_CountBG();
            DataTable dt = View_CountBG.SelectView_CountBG();

            List<object> lists = new List<object>();
            foreach (DataRow dr in dt.Rows)
            {
                //EmsModel.View_CountALL all = new EmsModel.View_CountALL();
                //all.Name = dr["Name"].ToString();
                //all.value = Convert.ToInt32(dr["value"]);
                var obj = new { name = dr["name"], value = dr["value"] };
                lists.Add(obj);
            }

            JavaScriptSerializer jss = new JavaScriptSerializer();
           context.Response.Write(callback + "({\"result\":" + jss.Serialize(lists) + "})");
           context.Response.End();

        }


        public void SelectCountPlan_Status(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];
            EmsBLL.CountPlan CountPlan = new EmsBLL.CountPlan();
            DataTable dt = CountPlan.View_CountPlan_Status();

            List<object> lists = new List<object>();
            foreach (DataRow dr in dt.Rows)
            {
                //EmsModel.View_CountALL all = new EmsModel.View_CountALL();
                //all.Name = dr["Name"].ToString();
                //all.value = Convert.ToInt32(dr["value"]);
                var obj = new { name = dr["name"], value = dr["value"] };
                lists.Add(obj);
            }

            JavaScriptSerializer jss = new JavaScriptSerializer();
            context.Response.Write(callback + "({\"result\":" + jss.Serialize(lists) + "})");
            context.Response.End();

        }

        public void SelectCountPlan_Type(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];
            EmsBLL.CountPlan CountPlan = new EmsBLL.CountPlan();
            DataTable dt = CountPlan.View_CountPlan_Type();

            List<object> lists = new List<object>();
            foreach (DataRow dr in dt.Rows)
            {
                //EmsModel.View_CountALL all = new EmsModel.View_CountALL();
                //all.Name = dr["Name"].ToString();
                //all.value = Convert.ToInt32(dr["value"]);
                var obj = new { name = dr["name"], value = dr["value"] };
                lists.Add(obj);
            }

            JavaScriptSerializer jss = new JavaScriptSerializer();
            context.Response.Write(callback + "({\"result\":" + jss.Serialize(lists) + "})");
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