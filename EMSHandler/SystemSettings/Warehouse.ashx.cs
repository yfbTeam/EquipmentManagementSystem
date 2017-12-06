using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EMSHandler.SystemSettings
{
    /// <summary>
    /// Warehouse 的摘要说明
    /// </summary>
    public class Warehouse : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string action = context.Request.QueryString["action"];
            if (!string.IsNullOrEmpty(action))
            {
                switch (action)
                {
                    case "GetData": GetData(context); break;
                    case "GetDataPage": GetDataPage(context); break;
                    case "GetModelById": GetModelById(context); break;
                    case "AddWarehouse": AddWarehouse(context); break;
                    case "EditWarehouse": EditWarehouse(context); break;
                    case "DeleteWarehouse": DeleteWarehouse(context); break;
                    case "GetNotInsEquipByWareId": GetNotInsEquipByWareId(context); break;
                    case "SetInstrumentEquip": SetInstrumentEquip(context); break;
                    default:
                        context.Response.Write("System Error");
                        break;
                }
            }
            context.Response.Write("System Error");
        }

        #region 获取库房列表数据
        public void GetData(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];
            string warehousename = context.Request["warehousename"];
            EmsModel.Warehouse ware = new EmsModel.Warehouse();
            if (!string.IsNullOrEmpty(warehousename))
            {
                ware.Name = warehousename;
            }
            //序列化
            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            EmsModel.JsonModel mod = new EmsBLL.Warehouse().GetJsonModel(ware);
            //输出Json
            HttpContext.Current.Response.Write(callback +
                     "({\"result\":" + jss.Serialize(mod) + "})");

            HttpContext.Current.Response.End();
        }
        #endregion

        #region 获取库房列表数据 分页
        public void GetDataPage(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];
            //当前页
            int startIndex = Convert.ToInt32(context.Request["startIndex"]);
            //页容量
            int pageSize = Convert.ToInt32(context.Request["pageSize"]);
            string warehousename = context.Request["warehousename"];
            EmsModel.Warehouse ware = new EmsModel.Warehouse();
            if (!string.IsNullOrEmpty(warehousename))
            {
                ware.Name = warehousename;
            }
            ware.IsDelete = 0;
            //序列化
            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            EmsModel.JsonModel mod = new EmsBLL.Warehouse().GetJsonModel(ware, startIndex, pageSize);
            //输出Json
            HttpContext.Current.Response.Write(callback +
                     "({\"result\":" + jss.Serialize(mod) + "})");

            HttpContext.Current.Response.End();
        }
        #endregion

        #region 根据id获取对象实体
        public void GetModelById(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];
            int wareid = Convert.ToInt32(context.Request["itemid"]);
            //序列化
            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            EmsModel.Warehouse ware = new EmsBLL.Warehouse().GetEmsModel(wareid);
            //输出Json
            HttpContext.Current.Response.Write(callback +
                     "({\"result\":" + jss.Serialize(ware) + "})");
            HttpContext.Current.Response.End();
        }
        #endregion

        #region 添加库房
        public void AddWarehouse(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];
            string name = context.Request["name"];
            int result;
            if (new EmsBLL.Warehouse().IsNameExists(name))
            {
                result = -1;
            }
            else
            {
                string useridcard = context.Request["useridcard"];
                string remarks = context.Request["remarks"];

                EmsModel.MenuInfo menu = new EmsModel.MenuInfo();
                menu.Name = name;
                menu.Pid = 0;
                menu.isMeu = false;
                menu.isShow = 0;

                EmsModel.Warehouse ware = new EmsModel.Warehouse();
                ware.Name = name;
                ware.Remarks = remarks;
                ware.Creator = useridcard;
                ware.CreateTime = DateTime.Now;
                ware.IsDelete = 0;
                ware.UseStatus = 0;

                //HttpPostedFile file = context.Request.Files[0];
                //string path = "/EMS.Web/Upload/Warehouse";
                //path = HttpContext.Current.Server.MapPath("~" + path);
                //if (!Directory.Exists(path))
                //{
                //    Directory.CreateDirectory(path);
                //}
                //path += "/" + DateTime.Now.ToString("yyyyMMddhhmmss") + "-" + file.FileName;
                //try
                //{
                //    file.SaveAs(path);
                //    ware.PlaneGraph = path;
                //}
                //catch (Exception ex)
                //{
                //    HttpContext.Current.Response.End();
                //}
                result = new EmsBLL.Warehouse().AddWarehouse(ware, menu);
            }
            //输出Json
            HttpContext.Current.Response.Write(callback +
                     "({\"result\":" + result + "})");
            HttpContext.Current.Response.End();
        }
        #endregion

        #region 编辑库房
        public void EditWarehouse(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];
            int wareid = Convert.ToInt32(context.Request["itemid"]);
            string name = context.Request["name"];
            string useridcard = context.Request["useridcard"];
            string remarks = context.Request["remarks"];
            int result;
            if (new EmsBLL.Warehouse().IsNameExists(name, wareid))
            {
                result = -1;
            }
            else
            {
                EmsModel.Warehouse ware = new EmsBLL.Warehouse().GetEmsModel(wareid);

                EmsModel.MenuInfo menu = new EmsBLL.MenuInfo().GetEmsModelByName(ware.Name);
                menu.Name = name;

                ware.Id = wareid;
                ware.Name = name;
                ware.Remarks = remarks;
                ware.Editor = useridcard;
                ware.UpdateTime = DateTime.Now;

                result = new EmsBLL.Warehouse().EditWarehouse(ware, menu);
            }
            //输出Json
            HttpContext.Current.Response.Write(callback + "({\"result\":" + result + "})");
            HttpContext.Current.Response.End();
        }
        #endregion

        #region 删除库房
        public void DeleteWarehouse(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];
            int wareid = Convert.ToInt32(context.Request["intID"]);
            int result;
            EmsModel.Warehouse ware = new EmsBLL.Warehouse().GetEmsModel(wareid);
            EmsModel.MenuInfo menu = new EmsBLL.MenuInfo().GetEmsModelByName(ware.Name);
            ware.Id = wareid;
            ware.IsDelete = 1;

            result = new EmsBLL.Warehouse().DeleteWarehouse(ware, menu);
            //输出Json
            HttpContext.Current.Response.Write(callback + "({\"result\":" + result + "})");
            HttpContext.Current.Response.End();
        }
        #endregion

        #region 获取仪器设备分类列表数据 分页
        public void GetNotInsEquipByWareId(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];
            //当前页
            int startIndex = Convert.ToInt32(context.Request["startIndex"]);
            //页容量
            int pageSize = Convert.ToInt32(context.Request["pageSize"]);
            int curwareid = Convert.ToInt32(context.Request["curwareid"]);
            string name = context.Request["name"];
            string model = context.Request["model"];
            string selwareid = context.Request["selwareid"];
            EmsModel.InstrumentEquip insE = new EmsModel.InstrumentEquip();
            if (!string.IsNullOrEmpty(name))
            {
                insE.Name = name;
            }
            if (!string.IsNullOrEmpty(model))
            {
                insE.Model = model;
            }
            insE.WarehouseId = curwareid;
            insE.IsDelete = 0;
            //序列化
            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            EmsModel.JsonModel mod = new EmsBLL.InstrumentEquip().GetJsonModel(insE, startIndex, pageSize, "!=", selwareid);
            //输出Json
            HttpContext.Current.Response.Write(callback +
                     "({\"result\":" + jss.Serialize(mod) + "})");

            HttpContext.Current.Response.End();
        }
        #endregion

        #region 设置仪器设备分类
        public void SetInstrumentEquip(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];
            string wareid = context.Request["itemid"];
            string idsStr = context.Request["idsStr"];
            //序列化
            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            EmsModel.JsonModel mod = new EmsBLL.InstrumentEquip().SetInstrumentEquip(wareid, idsStr);
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