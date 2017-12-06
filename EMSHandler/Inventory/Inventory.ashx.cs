using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

namespace EMSHandler.Inventory
{
    /// <summary>
    /// Inventory 的摘要说明
    /// </summary>
    public class Inventory : IHttpHandler
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
                    case "AddInventoryPlan": AddInventoryPlan(context); break;
                    case "EditInventoryPlan": EditInventoryPlan(context); break;
                    case "DeleteInventoryPlan": DeleteInventoryPlan(context); break;
                    case "CreateInventoryList": CreateInventoryList(context); break;
                    case "GetBuildingByInventory": GetBuildingByInventory(context); break;
                    case "GetLayersAndRoomsByInvenId": GetLayersAndRoomsByInvenId(context); break;
                    case "GetEquipByInvenRoomId": GetEquipByInvenRoomId(context); break;
                    case "GetInvenModelByBarcode": GetInvenModelByBarcode(context); break;
                    case "SaveRoomInventory": SaveRoomInventory(context); break;
                    case "GetInvenListDataPage": GetInvenListDataPage(context); break;
                    case "GetInvenListCount": GetInvenListCount(context); break;
                    case "DiskBackEquip": DiskBackEquip(context); break;
                    default:
                        context.Response.Write("System Error");
                        break;
                }
            }
            context.Response.Write("System Error");
        }

        #region 获取盘点计划列表数据 分页
        public void GetDataPage(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];
            //当前页
            int startIndex = Convert.ToInt32(context.Request["startIndex"]);
            //页容量
            int pageSize = Convert.ToInt32(context.Request["pageSize"]);
            string name = context.Request["name"];
            EmsModel.InventoryPlan plan = new EmsModel.InventoryPlan();
            if (!string.IsNullOrEmpty(name))
            {
                plan.Name = name;
            }
            plan.IsDelete = 0;
            //序列化
            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            EmsModel.JsonModel mod = new EmsBLL.InventoryPlan().GetJsonModel(plan, startIndex, pageSize);
            //输出Json
            HttpContext.Current.Response.Write(callback + "({\"result\":" + jss.Serialize(mod) + "})");
            HttpContext.Current.Response.End();
        }
        #endregion

        #region 根据id获取盘点计划对象实体
        public void GetModelById(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];
            int planid = Convert.ToInt32(context.Request["itemid"]);
            //序列化
            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            EmsModel.InventoryPlan plan = new EmsBLL.InventoryPlan().GetEmsModel(planid);
            //输出Json
            HttpContext.Current.Response.Write(callback + "({\"result\":" + jss.Serialize(plan) + "})");
            HttpContext.Current.Response.End();
        }
        #endregion

        #region 添加盘点计划
        public void AddInventoryPlan(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];
            string name = context.Request["name"];
            int result;
            if (new EmsBLL.InventoryPlan().IsNameExists(name))
            {
                result = -1;
            }
            else
            {
                string useridcard = context.Request["useridcard"];
                EmsModel.InventoryPlan plan = new EmsModel.InventoryPlan();
                plan.Name = name;
                plan.InventoryNo = context.Request["invno"];
                plan.InventoryTime = Convert.ToDateTime(context.Request["invtime"]);
                plan.Type = Convert.ToByte(context.Request["type"]);
                plan.Creator = useridcard;
                plan.CreateTime = DateTime.Now;
                plan.Status = 0;
                plan.IsGenerate = 0;
                plan.IsDelete = 0;
                result = new EmsBLL.InventoryPlan().Add(plan);
            }
            //输出Json
            HttpContext.Current.Response.Write(callback + "({\"result\":" + result + "})");
            HttpContext.Current.Response.End();
        }
        #endregion

        #region 编辑盘点计划
        public void EditInventoryPlan(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];
            int planid = Convert.ToInt32(context.Request["itemid"]);
            string name = context.Request["name"];
            int result;
            if (new EmsBLL.InventoryPlan().IsNameExists(name, planid))
            {
                result = -1;
            }
            else
            {
                EmsModel.InventoryPlan plan = new EmsBLL.InventoryPlan().GetEmsModel(planid);
                string useridcard = context.Request["useridcard"];
                plan.Id = planid;
                plan.Name = name;
                plan.InventoryTime = Convert.ToDateTime(context.Request["invtime"]);
                plan.Type = Convert.ToByte(context.Request["type"]);
                plan.Editor = useridcard;
                plan.UpdateTime = DateTime.Now;
                result = new EmsBLL.InventoryPlan().Update(plan);
            }
            //输出Json
            HttpContext.Current.Response.Write(callback + "({\"result\":" + result + "})");
            HttpContext.Current.Response.End();
        }
        #endregion

        #region 删除盘点计划
        public void DeleteInventoryPlan(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];
            int planid = Convert.ToInt32(context.Request["intID"]);
            EmsModel.InventoryPlan plan = new EmsBLL.InventoryPlan().GetEmsModel(planid);
            plan.Id = planid;
            plan.IsDelete = 1;
            int result = new EmsBLL.InventoryPlan().Update(plan);
            //输出Json
            HttpContext.Current.Response.Write(callback + "({\"result\":" + result + "})");
            HttpContext.Current.Response.End();
        }
        #endregion

        #region 生成盘点单
        public void CreateInventoryList(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];
            int planid = Convert.ToInt32(context.Request["planid"]);
            string type = context.Request["type"];
            string useridcard = context.Request["useridcard"];
            //序列化
            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            EmsModel.JsonModel mod = new EmsBLL.InventoryListDetail().CreateInventoryList(planid, type, useridcard);
            //输出Json
            HttpContext.Current.Response.Write(callback + "({\"result\":" + jss.Serialize(mod) + "})");
            HttpContext.Current.Response.End();
        }
        #endregion

        #region 获得盘点时的楼房信息
        public void GetBuildingByInventory(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];
            string invenid = context.Request["invenid"];
            string type = context.Request["type"];
            //序列化
            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            DataTable dt = new EmsBLL.InventoryListDetail().GetBuildingByInventory(invenid, type);
            StringBuilder orgJson = new StringBuilder();
            string selid = "";
            if (dt.Rows.Count > 0)
            {
                selid = dt.Rows[0]["Id"].ToString();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    var liclass = i == 0 ? " class='selected_build' " : "";
                    orgJson.Append("<li " + liclass + " id='buildli_" + dt.Rows[i]["Id"] + "' onclick='BuildLiClick(this)'>" + dt.Rows[i]["Name"] + "</li>");
                }
            }
            //输出Json
            HttpContext.Current.Response.Write(callback + "({\"result\":\"" + orgJson.ToString() + "\",\"selid\":\"" + selid + "\"})");
            HttpContext.Current.Response.End();
        }
        #endregion

        #region 根据楼房id及类型获得盘点时的楼层及房间信息
        public void GetLayersAndRoomsByInvenId(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];
            string invenid = context.Request["invenid"];
            string buildid = context.Request["buildid"];
            string buildname = context.Request["buildname"];
            string type = context.Request["type"];
            //序列化
            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            DataTable dt = new EmsBLL.InventoryListDetail().GetLayersAndRoomsByInvenId(invenid, buildid, type);
            StringBuilder orgJson = new StringBuilder();
            DataRow[] parLayer = dt.Select("Pid=" + buildid);//得到楼层信息
            if (parLayer.Count() > 0)
            {
                for (int i = 0; i < parLayer.Count(); i++)
                {
                    orgJson.Append("<dl class='listIndex' attr='terminal_brand_s'>");
                    orgJson.Append("<dt>第" + parLayer[i]["Name"].ToString() + "层</dt>");
                    orgJson.Append("<dd>");
                    DataRow[] subRoom = dt.Select(" Pid=" + parLayer[i]["Id"].ToString());//得到房间信息
                    if (subRoom.Count() > 0)
                    {
                        for (int j = 0; j < subRoom.Count(); j++)
                        {
                            if (subRoom[j]["Status"].ToString() == "0")
                            {
                                orgJson.Append("<label><a href='javascript:void(0);' style='background:white;' onclick=\"OpenIFrameWindow('房间盘点', 'RoomInventory.aspx?itemid=" + subRoom[j]["Id"].ToString() + "&invenid=" + invenid + "&ppid=" + buildid + "&status=" + subRoom[j]["Status"].ToString() + "&roomname=" + buildname + "-" + subRoom[j]["RoomNo"].ToString() + "(" + subRoom[j]["Name"].ToString() + ")" + "','560px','500px');\"><span class='liangge'>" + subRoom[j]["RoomNo"] + "</span><span class='liangge'>" + subRoom[j]["Name"] + "</span></a></label>");
                            }
                            else
                            {
                                orgJson.Append("<label><a href='javascript:void(0);' style='background:#54FF9F;' onclick=\"OpenIFrameWindow('房间盘点', 'RoomInventory.aspx?itemid=" + subRoom[j]["Id"].ToString() + "&invenid=" + invenid + "&ppid=" + buildid + "&status=" + subRoom[j]["Status"].ToString() + "&roomname=" + buildname + "-" + subRoom[j]["RoomNo"].ToString() + "(" + subRoom[j]["Name"].ToString() + ")" + "','560px','500px');\"><span class='liangge'>" + subRoom[j]["RoomNo"] + "</span><span class='liangge'>" + subRoom[j]["Name"] + "</span></a></label>");
                            }
                        }
                    }
                    orgJson.Append("</dd>");
                    orgJson.Append("</dl>");
                }
            }

            //输出Json
            HttpContext.Current.Response.Write(orgJson.ToString());
            //HttpContext.Current.Response.Write(callback + "({\"result\":\"" + orgJson.ToString() + "\"})");
            HttpContext.Current.Response.End();
        }
        #endregion

        #region 获取房间的仪器设备信息
        public void GetEquipByInvenRoomId(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];
            string invenid = context.Request["invenid"];
            string roomid = context.Request["roomid"];
            //序列化
            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            EmsModel.JsonModel mod = new EmsBLL.InventoryListDetail().GetJsonModelEquip(invenid, roomid);
            //输出Json
            HttpContext.Current.Response.Write(callback + "({\"result\":" + jss.Serialize(mod) + "})");
            HttpContext.Current.Response.End();
        }
        #endregion

        #region 根据条形码得到盘点单中的一个对象实体
        public void GetInvenModelByBarcode(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];
            string invenid = context.Request["invenid"];
            string barcode = context.Request["barcode"];
            //序列化
            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            EmsModel.View_InvenRoomEquip ind = new EmsBLL.InventoryListDetail().GetInvenModelByBarcode(invenid, barcode);
            //输出Json
            HttpContext.Current.Response.Write(callback + "({\"result\":" + jss.Serialize(ind) + "})");
            HttpContext.Current.Response.End();
        }
        #endregion

        #region 保存房间盘点信息
        public void SaveRoomInventory(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];
            string invenid = context.Request["invenid"];
            string roomid = context.Request["roomid"];
            string idStr = context.Request["idStr"];
            string editStr = context.Request["editStr"];
            string useridcard = context.Request["useridcard"];
            //序列化
            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            EmsModel.JsonModel mod = new EmsBLL.InventoryListDetail().SaveRoomInventory(invenid, roomid, idStr, editStr, useridcard);
            //输出Json
            HttpContext.Current.Response.Write(callback + "({\"result\":" + jss.Serialize(mod) + "})");
            HttpContext.Current.Response.End();
        }
        #endregion

        #region 获取盘点单列表数据 分页
        public void GetInvenListDataPage(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];
            Hashtable ht = new Hashtable();
            if (!string.IsNullOrEmpty(context.Request["PlanId"])) //盘点Id
            {
                ht.Add("PlanId", context.Request["PlanId"].ToString());
            }
            if (!string.IsNullOrEmpty(context.Request["IsRoomGroup"])) //是否根据房间分组
            {
                ht.Add("IsRoomGroup", context.Request["IsRoomGroup"].ToString());
            }
            if (!string.IsNullOrEmpty(context.Request["RoomId"])) //房间Id
            {
                ht.Add("RoomId", context.Request["RoomId"].ToString());
            }
            if (!string.IsNullOrEmpty(context.Request["serisloss"])) //是否拟盘亏
            {
                ht.Add("serisloss", context.Request["serisloss"].ToString());
            }
            if (!string.IsNullOrEmpty(context.Request["equipsource"])) //设备来源
            {
                ht.Add("equipsource", context.Request["equipsource"].ToString());
            }
            if (!string.IsNullOrEmpty(context.Request["assetname"])) //资产名称
            {
                ht.Add("assetname", context.Request["assetname"].ToString());
            }
            if (!string.IsNullOrEmpty(context.Request["type"])) //盘点类型
            {
                ht.Add("type", context.Request["type"].ToString());
            }
            bool isPage = true;
            if (!string.IsNullOrEmpty(context.Request["ispage"])) //是否分页
            {
                isPage = false;
            }
            string pageIndex = context.Request["PageIndex"];
            string pageSize = context.Request["PageSize"];
            ht.Add("PageIndex", pageIndex != null ? pageIndex.ToString() : "1");
            ht.Add("PageSize", pageSize != null ? pageSize.ToString() : "10");
            //序列化
            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            EmsModel.JsonModel mod = isPage ? new EmsBLL.InventoryList().GetInvenListDataPage(ht) : new EmsBLL.InventoryList().ExportInventoryExcel(ht);
            mod = nameCommon.AddCreateNameForData(mod, 4, "OwnerUID", "", "OperatorUID");
            //输出Json
            HttpContext.Current.Response.Write(callback + "({\"result\":" + jss.Serialize(mod) + "})");
            HttpContext.Current.Response.End();
        }
        #endregion

        #region 获取盘点单总数信息
        public void GetInvenListCount(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];
            Hashtable ht = new Hashtable();
            string planid = context.Request["PlanId"].ToString();
            //序列化
            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            DataTable dt = new EmsBLL.InventoryList().GetInvenListCount(planid);
            Object obj = null;
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                obj = new
                {
                    Quantity = row["Quantity"].ToString(),
                    RealQuantity = row["RealQuantity"].ToString(),
                    BorrowQuantity = row["BorrowQuantity"].ToString(),
                    LossQuantity = row["LossQuantity"].ToString(),
                    Name = row["Name"].ToString(),
                    InventoryNo = row["InventoryNo"].ToString()
                };
            }
            //输出Json
            HttpContext.Current.Response.Write(callback + "({\"result\":" + jss.Serialize(obj) + "})");
            HttpContext.Current.Response.End();
        }
        #endregion

        #region 盘回仪器设备
        public void DiskBackEquip(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];
            int itemid = Convert.ToInt32(context.Request["itemid"]);
            EmsModel.InventoryListDetail det = new EmsBLL.InventoryListDetail().GetEmsModel(itemid);
            det.Id = itemid;
            det.IsLoss = true;
            int result = new EmsBLL.InventoryListDetail().Update(det);
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