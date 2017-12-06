using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace EMSHandler.Order
{
    /// <summary>
    /// Order 的摘要说明
    /// </summary>
    public class Order : IHttpHandler
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
                    case "GetDate": GetDate(context); break;
                    case "GetDateL": GetDateL(context); break;
                    case "GetDateEscheat": GetDateEscheat(context); break;
                    case "GetDateByID": GetDateByID(context); break;
                    case "GetUsetByKa": GetUsetByKa(context); break;
                    case "GetDatePage": GetDatePage(context); break;
                    case "GetDatePageNEW": GetDatePageNEW(context); break;
                    case "GetDatePageLoan": GetDatePageLoan(context); break;
                    case "GetUserByKaNo": GetUserByKaNo(context); break;
                    case "GetDataByBarcode": GetDataByBarcode(context); break;
                    case "DeteleOrder": DeteleOrder(context); break;
                    case "UpdateOrderStatus": UpdateOrderStatus(context); break;
                    case "LendDate": LendDate(context); break;
                    case "ToLend": ToLend(context); break;
                    case "GetInstrumentEquip": GetInstrumentEquip(context); break;
                    case "ToOtherLend": ToOtherLend(context); break;
                    case "ToEscheat": ToEscheat(context); break;
                    case "RepairEdit": RepairEdit(context); break;
                    case "RepairList": RepairList(context); break;
                    case "SelectRepairDetails": SelectRepairDetails(context); break;
                    case "RepairInfo": RepairInfo(context); break;
                    case "UpdateStatus": UpdateStatus(context); break;
                    case "SetRepairDetails": SetRepairDetails(context); break;
                    case "AddRepairDetails": AddRepairDetails(context); break;
                    case "GetRepairDetails": GetRepairDetails(context); break;
                    case "DeteleRepair": DeteleRepair(context) ; break;
                    case "deleteRepairDetails": deleteRepairDetails(context); break;
                    case "GetRepairAttachment": GetRepairAttachment(context); break;
                    case "GetRepairDetailsNo": GetRepairDetailsNo(context); break;
                    default:
                        context.Response.Write("System Error");
                        break;
                }
            }
            context.Response.Write("System Error");
        }

       /// <summary>
       /// 获取订单数据(借还)
       /// </summary>
       /// <param name="context"></param>
        public void GetDate(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];
            int startIndex = Convert.ToInt32(context.Request["startIndex"]);
            //状态
            int Status = Convert.ToInt32(context.Request["Status"]);
            //租借人
            string LoanName = context.Request["LoanName"];
            EmsModel.OrderInfo Mod = new EmsModel.OrderInfo();
            Mod.LoanName = LoanName;
            Mod.Status = Status;
            ;
            //序列化
            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            EmsModel.JsonModel mod = new EmsBLL.OrderInfo().GetJsonModel(Mod, startIndex, 10);
            //输出Json
            HttpContext.Current.Response.Write(callback +
                     "({\"result\":" + jss.Serialize(mod) + "})");

            HttpContext.Current.Response.End();
        }

        public void GetDateL(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];

            string OrderNo = context.Request["OrderNo"];
            //序列化
            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            EmsModel.JsonModel mod = new EmsBLL.OrderInfo().GetJsonModelVO(OrderNo);
            //输出Json
            HttpContext.Current.Response.Write(callback +
                     "({\"result\":" + jss.Serialize(mod) + "})");

            HttpContext.Current.Response.End();
        }

        public void GetDateEscheat(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];

            string OrderNo = context.Request["OrderID"];
            //序列化
            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            List<EmsModel.EquipDetail> mod = new EmsBLL.EquipDetail().GetEmsModelExperimentId(OrderNo, "1");
            //输出Json
            HttpContext.Current.Response.Write(callback +
                     "({\"result\":" + jss.Serialize(mod) + "})");

            HttpContext.Current.Response.End();
        }

        public void GetDateByID(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];

            string OrderID = context.Request["OrderID"];
            //序列化
            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            EmsModel.PlanExperiment mod = new EmsBLL.PlanExperiment().GetEmsModel(Convert.ToInt32(OrderID));
            //输出Json
            HttpContext.Current.Response.Write(callback +
                     "({\"result\":" + jss.Serialize(mod) + "})");

            HttpContext.Current.Response.End();
        }

        public void GetUsetByKa(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];

            EmsModel.UserInfo user = new EmsModel.UserInfo();
            user.KaNo = context.Request["User"];
            List<EmsModel.UserInfo> userList = new EmsBLL.UserInfo().GetListByPage(user, 1, 998);

            string userName = "";
            string usetLoginNae = "";
            if (userList == null)
            {
                userName = userList[0].Name;
                usetLoginNae = userList[0].LoginName;
            }
            //序列化
            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();

            //输出Json
            HttpContext.Current.Response.Write(callback +
                     "({\"result\":" + userName + "@" + usetLoginNae + "})");

            HttpContext.Current.Response.End();
        }
       

       /// <summary>
       ///  获取订单数据（借还）
       /// </summary>
       /// <param name="context"></param>
        public void GetDatePage(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];
            //当前页
            int startIndex = Convert.ToInt32(context.Request["startIndex"]);
            //页容量
            int pageSize = Convert.ToInt32(context.Request["pageSize"]);

            EmsModel.OrderInfo Mod = new EmsModel.OrderInfo();
            //订单状态
            if (context.Request["Status"] != null && context.Request["Status"] != "-1")
            {
                Mod.Status = Convert.ToInt32(context.Request["Status"]);
            }
            //借用人
            if (context.Request["LoanName"] != null)
            {
                Mod.LoanName = context.Request["LoanName"];
            }


            //序列化
            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            EmsModel.JsonModel mod = new EmsBLL.OrderInfo().GetJsonModel(Mod, startIndex, pageSize);
            //输出Json
            HttpContext.Current.Response.Write(callback +
                     "({\"result\":" + jss.Serialize(mod) + "})");

            HttpContext.Current.Response.End();
        }

        public void GetDatePageNEW(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];
            //当前页
            int startIndex = Convert.ToInt32(context.Request["startIndex"]);
            //页容量
            int pageSize = Convert.ToInt32(context.Request["pageSize"]);

            EmsModel.View_LoanDate Mod = new EmsModel.View_LoanDate();

            //借用人
            if (context.Request["KaNo"] != null)
            {
                Mod.Creator = context.Request["KaNo"];
            }
            if (context.Request["stuKaNo"] != null)
            {
                Mod.stuLoanIDCard = context.Request["stuKaNo"];
                Mod.Creator = null;
            }


            //序列化
            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            EmsModel.JsonModel mod = new EmsBLL.OrderInfo().GetJsonModel_Land(Mod, startIndex, pageSize);
            //输出Json
            HttpContext.Current.Response.Write(callback +
                     "({\"result\":" + jss.Serialize(mod) + "})");

            HttpContext.Current.Response.End();
        }

        public void GetDatePageLoan(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];
            //当前页
            int startIndex = Convert.ToInt32(context.Request["startIndex"]);
            //页容量
            int pageSize = Convert.ToInt32(context.Request["pageSize"]);

            EmsModel.OrderInfo Mod = new EmsModel.OrderInfo();
            //订单状态
            if (context.Request["Status"] != null && context.Request["Status"] != "-1")
            {
                Mod.Status = Convert.ToInt32(context.Request["Status"]);
            }
            //借用人
            if (context.Request["LoanName"] != null)
            {
                Mod.LoanName = context.Request["LoanName"];
            }


            //序列化
            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            EmsModel.JsonModel mod = new EmsBLL.OrderInfo().GetJsonModel(Mod, startIndex, pageSize);
            //输出Json
            HttpContext.Current.Response.Write(callback +
                     "({\"result\":" + jss.Serialize(mod) + "})");

            HttpContext.Current.Response.End();
        }

        public void GetUserByKaNo(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];

            string KaNo = context.Request["KaNo"];

            EmsModel.UserInfo user = new EmsBLL.UserInfo().GetEmsModelByKaNo(KaNo);

            EmsModel.Student stu = new EmsBLL.Student().GetEmsModelByKaNo(KaNo);
            //序列化
            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();

            //输出Json
            HttpContext.Current.Response.Write(callback +
                     "({\"result\":" + jss.Serialize(user) + ",\"result2\":" + jss.Serialize(stu) + "})");

            HttpContext.Current.Response.End();

        }

        public void GetDataByBarcode(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];

            string Barcode = context.Request["Barcode"];

            EmsModel.EquipDetail user = new EmsBLL.EquipDetail().GetModelByBarcode(Barcode);
            //序列化
            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();

            //输出Json
            HttpContext.Current.Response.Write(callback +
                     "({\"result\":" + jss.Serialize(user) + "})");

            HttpContext.Current.Response.End();

        }
      

        public void DeteleOrder(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];

            string strid = context.Request["intID"];

            //bool isok = true;
            //序列化
            //System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            //jss.Serialize(isok)
            //输出Json
            HttpContext.Current.Response.Write(callback +
                     "({\"result\":" + strid + "})");

            HttpContext.Current.Response.End();

        }

        /// <summary>
        /// 修改订单状态
        /// </summary>
        /// <param name="context"></param>

        public void UpdateOrderStatus(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];

            string orderNO = context.Request["orderNO"];
            string orderDetailNO = context.Request["orderDetailNO"];
            int DetailType = Convert.ToInt32(context.Request["DetailType"]);

            EmsBLL.OrderInfo order = new EmsBLL.OrderInfo();
            //EmsModel.OrderInfo Mod = order.GetEmsModel(id);

            bool isok = order.Lend(orderNO, orderDetailNO, DetailType);
            //序列化
            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            //jss.Serialize(isok)
            //输出Json
            HttpContext.Current.Response.Write(callback +
                     "({\"result\":" + jss.Serialize(isok) + "})");

            HttpContext.Current.Response.End();

        }

        public void LendDate(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];
            //当前页
            int startIndex = Convert.ToInt32(context.Request["startIndex"]);
            //页容量
            int pageSize = 999;//Convert.ToInt32(context.Request["pageSize"]);

            EmsModel.OrderEquipDetail Mod = new EmsModel.OrderEquipDetail();
            //Mod.Type = 3;
            //
            if (context.Request["Type"] != null)
            {
                Mod.Type = Convert.ToByte(context.Request["Type"]);
            }
            //
            if (context.Request["OrderId"] != null)
            {
                Mod.OrderId = Convert.ToInt32(context.Request["OrderId"]);
            }


            //序列化
            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            EmsModel.JsonModel mod = new EmsBLL.OrderInfo().GetJsonModelByOrder(Mod, startIndex, pageSize);
            //输出Json
            HttpContext.Current.Response.Write(callback +
                     "({\"result\":" + jss.Serialize(mod) + "})");

            HttpContext.Current.Response.End();
        }

        public void ToLend(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];

            string strData = context.Request["strData"];

            string OrderNo = context.Request["OrderNo"];
            string IDCard = context.Request["IDCard"];
            string stuCard = context.Request["stuCard"];

            EmsModel.OrderInfo mod = new EmsModel.OrderInfo();
            mod.OrderNo = "SY" + DateTime.Now.ToString("yy-MM-dd");
            mod.IDCard = IDCard;
            mod.stuLoanIDCard = stuCard;
            mod.ExperimentId = Convert.ToInt32(OrderNo);
            mod.Creator = "admin";
            mod.CreateTime = DateTime.Now;
            mod.Type = 0;
            mod.Status = 2;
            mod.IsDelete = 0;
            mod.LoanName = "admin";
            mod.LendTime = DateTime.Now;

            bool isok = new EmsBLL.OrderInfo().Lend(strData, OrderNo, mod);
            //序列化
            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();

            //输出Json
            HttpContext.Current.Response.Write(callback +
                     "({\"result\":" + jss.Serialize(isok) + "})");

            HttpContext.Current.Response.End();
        }

        public void GetInstrumentEquip(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];

            string InstrumentEquipID = context.Request["InstrumentEquipID"];

            //序列化
            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            EmsModel.InstrumentEquip mod = new EmsBLL.InstrumentEquip().GetModelByNumber(InstrumentEquipID);
            //输出Json
            HttpContext.Current.Response.Write(callback +
                     "({\"result\":" + jss.Serialize(mod) + "})");

            HttpContext.Current.Response.End();
        }

        public void ToOtherLend(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];

            string strData = context.Request["strData"];

            string OrderNo = context.Request["OrderNo"];

            string LoanName = context.Request["LoanName"];

            string Creator = context.Request["Creator"];
            //序列化
            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            bool isok = new EmsBLL.OrderInfo().OtherLend(strData, LoanName, Creator, OrderNo);
            //输出Json
            HttpContext.Current.Response.Write(callback +
                     "({\"result\":" + jss.Serialize(isok) + "})");

            HttpContext.Current.Response.End();
        }

        public void ToEscheat(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];
            string strData = context.Request["strData"];
            string orderID = context.Request["orderID"];
            //序列化
            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            bool isok = new EmsBLL.OrderInfo().Escheat(strData, orderID);
            //输出Json
            HttpContext.Current.Response.Write(callback +
                     "({\"result\":" + jss.Serialize(isok) + "})");

            HttpContext.Current.Response.End();
        }
       


        /// <summary>
        /// 送修添加送修信息
        /// </summary>
        /// <param name="context"></param>
       
        public void RepairInfo(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];
            Hashtable ht = new Hashtable();
            ht.Add("RepairLocation", context.Request["RepairLocation"]);
            ht.Add("CostOfRepairs", context.Request["CostOfRepairs"]);
            ht.Add("CompleteTime", context.Request["CompleteTime"]);
            ht.Add("ID", context.Request["ID"]);
            EmsModel.JsonModel Model = new EmsBLL.Repair().RepairInfo(ht);
            //序列化
            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();

            //输出Json
            HttpContext.Current.Response.Write(callback +
                     "({\"result\":" + jss.Serialize(Model) + "})");

            HttpContext.Current.Response.End();
        }


        /// <summary>
        /// 取回修改状态
        /// </summary>
        /// <param name="context"></param>
      
        public void UpdateStatus(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];
            Hashtable ht = new Hashtable();
            ht.Add("EquipID", context.Request["EquipID"]);
            ht.Add("ID", context.Request["ID"]);
            ht.Add("type", context.Request["type"]);
            EmsModel.JsonModel Model = new EmsBLL.Repair().UpdateStatus(ht);
            //序列化
            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();

            //输出Json
            HttpContext.Current.Response.Write(callback +
                     "({\"result\":" + jss.Serialize(Model) + "})");

            HttpContext.Current.Response.End();
        }

        /// <summary>
        /// 逻辑删除
        /// </summary>
        /// <param name="context"></param>
        public void DeteleRepair(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];
            Hashtable ht = new Hashtable();
            ht.Add("ID", context.Request["ID"]);
            EmsModel.JsonModel Model = new EmsBLL.Repair().DeteleRepair(ht);
            //序列化
            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();

            //输出Json
            HttpContext.Current.Response.Write(callback +
                     "({\"result\":" + jss.Serialize(Model) + "})");

            HttpContext.Current.Response.End();
        }


        /// <summary>
        /// 删除报修单条记录
        /// </summary>
        /// <param name="context"></param>
        public void deleteRepairDetails(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];
            Hashtable ht = new Hashtable();
            ht.Add("ID", context.Request["ID"]);
            EmsModel.JsonModel Model = new EmsBLL.Repair().deleteRepairDetails(ht);
            //序列化
            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();

            //输出Json
            HttpContext.Current.Response.Write(callback +
                     "({\"result\":" + jss.Serialize(Model) + "})");

            HttpContext.Current.Response.End();
        }


      
        public void RepairEdit(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];
            string Damagetime = context.Request["Damagetime"];
            string DamageCauses = context.Request["DamageCauses"];
            string remarks = context.Request["remarks"];
            string useridcard = context.Request["useridcard"];
            string eqID = context.Request["eqID"];


            EmsModel.Repair mod = new EmsModel.Repair();
            mod.Damagetime = Convert.ToDateTime(Damagetime);
            mod.DamageCauses = DamageCauses;
            mod.Remark = remarks;
            mod.RepairMan = useridcard;
            mod.RepairTime = DateTime.Now;
            mod.EquipID = Convert.ToInt32(eqID);
            mod.IsDelete = 0;
            mod.RepairStatus = 0;

            int rep = new EmsBLL.Repair().Add(mod);
            //EmsModel.EquipDetail eMod = new EmsBLL.EquipDetail().GetEmsModel(Convert.ToInt32(eqID));
            //输出Json

            if(rep>0)
            {
                Hashtable ht = new Hashtable();
                ht.Add("Id", context.Request["eqID"]);
                ht.Add("EquipStatus", 2);
                new EmsBLL.EquipDetail().UpdateStatus(ht);
            }



            HttpContext.Current.Response.Write(callback +
                     "({\"result\":" + rep + "})");

            HttpContext.Current.Response.End();

        }

        /// <summary>
        /// 更新报修信息
        /// </summary>
        /// <param name="context"></param>
        public void SetRepairDetails(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];
            string RepairLocation = context.Request["RepairLocation"];
            string CostOfRepairs = context.Request["CostOfRepairs"];
            string CompleteTime = context.Request["CompleteTime"];
            string Damagetime = context.Request["Damagetime"];
            string DamageCauses = context.Request["DamageCauses"];
            string remarks = context.Request["remarks"];
            string useridcard = context.Request["useridcard"];
            string ID = context.Request["id"];


            EmsModel.Repair mod = new EmsModel.Repair();
            mod.ID = Convert.ToInt32(ID);
            mod.RepairLocation = RepairLocation;
            mod.CostOfRepairs = CostOfRepairs;
            mod.CompleteTime = CompleteTime;
            mod.Damagetime = Convert.ToDateTime(Damagetime);
            mod.DamageCauses = DamageCauses;
            mod.Remark = remarks;
            mod.RepairMan = useridcard;
            mod.RepairTime = DateTime.Now;
            mod.EquipID = Convert.ToInt32(ID);
            int rep = new EmsBLL.Repair().Update(mod);
            HttpContext.Current.Response.Write(callback + "({\"result\":" + rep + "})");
            HttpContext.Current.Response.End();
        }


        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="context"></param>
        public void AddRepairDetails(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];
            Hashtable ht = new Hashtable();
            ht.Add("Record", context.Request["Record"]);
            ht.Add("Date", context.Request["Date"]);
            ht.Add("ID", context.Request["ID"]);
            ht.Add("RID", context.Request["RID"]);
            ht.Add("Operator", context.Request["Operator"]);
            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            string fileJson = context.Request["fileJson"];
            List<EmsModel.FileModel> files = jss.Deserialize<List<EmsModel.FileModel>>(fileJson);
            ht.Add("fileJson", files);
         
            EmsBLL.Repair repair = new EmsBLL.Repair();
            EmsModel.JsonModel Model = repair.AddRepairDetails(ht);
      
            HttpContext.Current.Response.Write(callback + "({\"result\":" + jss.Serialize(Model) + "})");
            HttpContext.Current.Response.End();
        }


        public void RepairList(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];
            Hashtable ht = new Hashtable();
            ht.Add("Name", context.Request["name"] ?? "");
            ht.Add("RepairMan", context.Request["IDCard"] ?? "");
            ht.Add("EQtype", context.Request["EQtype"] ?? "");
            ht.Add("PageIndex", context.Request["PageIndex"] ?? "1");
            ht.Add("PageSize", context.Request["PageSize"] ?? "10");
            bool ispage = true;
            if (!string.IsNullOrEmpty(context.Request["ispage"]))
            {
                ispage = Convert.ToBoolean(context.Request["ispage"]);
            }
            EmsModel.JsonModel repMod = new EmsBLL.OrderInfo().GetJsonModel_RepairLists(ht,ispage);
            repMod = nameCommon.AddCreateNameForData(repMod, 4, "RepairMan","","", context.Request["userName"]??"");
            //序列化
            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();

            //输出Json
            HttpContext.Current.Response.Write(callback +
                     "({\"result\":" + jss.Serialize(repMod) + "})");

            HttpContext.Current.Response.End();
        }

        public void SelectRepairDetails(HttpContext context)
        {
            string ID = context.Request["ID"];
            string callback = context.Request["jsoncallback"];
            EmsBLL.RepairDetails SelectRepairDetails = new EmsBLL.RepairDetails();
            DataTable dt = SelectRepairDetails.SelectRepairDetails(Convert.ToInt32(ID));

            List<EmsModel.View_RepairList> list = new EmsBLL.RepairDetails().GetList(dt);


            JavaScriptSerializer jss = new JavaScriptSerializer();
            context.Response.Write(callback + "({\"result\":" + jss.Serialize(list) + "})");
            context.Response.End();
        }


        /// <summary>
        /// 根据主表ID查询记录表
        /// </summary>
        /// <param name="context"></param>
        public void GetRepairDetails(HttpContext context)
        {

            string callback = context.Request["jsoncallback"];
            Hashtable ht = new Hashtable();
            int id = Convert.ToInt32(context.Request["ID"]);

            EmsModel.JsonModel Model = new EmsBLL.Repair().GetRepairDetails(id);
            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            HttpContext.Current.Response.Write(callback + "({\"result\":" + jss.Serialize(Model) + "})");
            HttpContext.Current.Response.End();
        }



        /// <summary>
        /// 根据ID查询记录表一条数据
        /// </summary>
        /// <param name="context"></param>
        public void GetRepairDetailsNo(HttpContext context)
        {

            string callback = context.Request["jsoncallback"];
            Hashtable ht = new Hashtable();
            int id = Convert.ToInt32(context.Request["ID"]);

            EmsModel.JsonModel Model = new EmsBLL.Repair().GetRepairDetailsNo(id);
            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            HttpContext.Current.Response.Write(callback + "({\"result\":" + jss.Serialize(Model) + "})");
            HttpContext.Current.Response.End();
        }


        /// <summary>
        /// 查询附件表
        /// </summary>
        /// <param name="context"></param>
        public void GetRepairAttachment(HttpContext context)
        {

            string callback = context.Request["jsoncallback"];
            Hashtable ht = new Hashtable();
            int id = Convert.ToInt32(context.Request["ID"]);

            EmsModel.JsonModel Model = new EmsBLL.Repair().GetRepairAttachment(id);
            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
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