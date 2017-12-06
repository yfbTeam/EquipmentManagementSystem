using EmsModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Services;



namespace EmsBLL
{
    public partial class OrderInfo
    {
        BLLCommon common = new BLLCommon();
        #region 获取订单数据
        /// <summary>
        /// 获取订单数据
        /// </summary>
        /// <returns></returns>
        public EmsModel.JsonModel GetJsonModel()
        {
            //当前页
            int pageIndex = 1;
            //页容量
            int pageSize = 16;
            List<EmsModel.OrderInfo> modList = GetList();
            //定义分页数据实体
            PagedDataModel<EmsModel.OrderInfo> pagedDataModel = null;
            //定义JSON标准格式实体中
            JsonModel jsonModel = null;
            if (modList.Count > 0)
            {
                var list = modList;
                //总条数
                int rowCount = modList.Count;
                //总页数
                int pageCount = (int)Math.Ceiling(rowCount * 1.0 / pageSize);
                //将数据封装到PagedDataModel分页数据实体中
                pagedDataModel = new PagedDataModel<EmsModel.OrderInfo>()
                {
                    PageCount = pageCount,
                    PagedData = list,
                    PageIndex = pageIndex,
                    PageSize = pageSize,
                    RowCount = rowCount
                };
                //将分页数据实体封装到JSON标准实体中
                jsonModel = new JsonModel()
                {
                    Data = pagedDataModel,
                    Msg = "成功",
                    Status = "ok",
                    BackUrl = ""
                };
                return jsonModel;
            }
            else
            {
                jsonModel = new JsonModel()
                {
                    Status = "no",
                    Msg = "失败"
                };
                return jsonModel;
            }
        }

        public EmsModel.JsonModel GetJsonModelVO(string OrderNo)
        {
            //当前页
            int pageIndex = 1;
            //页容量
            int pageSize = 999;
            List<EmsModel.View_orderCount> modList = GetListVO(OrderNo);
            //定义分页数据实体
            PagedDataModel<EmsModel.View_orderCount> pagedDataModel = null;
            //定义JSON标准格式实体中
            JsonModel jsonModel = null;
            if (modList.Count > 0)
            {
                var list = modList;
                //总条数
                int rowCount = modList.Count;
                //总页数
                int pageCount = (int)Math.Ceiling(rowCount * 1.0 / pageSize);
                //将数据封装到PagedDataModel分页数据实体中
                pagedDataModel = new PagedDataModel<EmsModel.View_orderCount>()
                {
                    PageCount = pageCount,
                    PagedData = list,
                    PageIndex = pageIndex,
                    PageSize = pageSize,
                    RowCount = rowCount
                };
                //将分页数据实体封装到JSON标准实体中
                jsonModel = new JsonModel()
                {
                    Data = pagedDataModel,
                    Msg = "成功",
                    Status = "ok",
                    BackUrl = ""
                };
                return jsonModel;
            }
            else
            {
                jsonModel = new JsonModel()
                {
                    Status = "no",
                    Msg = "失败"
                };
                return jsonModel;
            }
        }

        public EmsModel.JsonModel GetJsonModelEscheat(string OrderID)
        {
            //当前页
            int pageIndex = 1;
            //页容量
            int pageSize = 999;
            List<EmsModel.View_LoanANDEscheat> modList = GetListEscheat(OrderID);
            //定义分页数据实体
            PagedDataModel<EmsModel.View_LoanANDEscheat> pagedDataModel = null;
            //定义JSON标准格式实体中
            JsonModel jsonModel = null;
            if (modList.Count > 0)
            {
                var list = modList;
                //总条数
                int rowCount = modList.Count;
                //总页数
                int pageCount = (int)Math.Ceiling(rowCount * 1.0 / pageSize);
                //将数据封装到PagedDataModel分页数据实体中
                pagedDataModel = new PagedDataModel<EmsModel.View_LoanANDEscheat>()
                {
                    PageCount = pageCount,
                    PagedData = list,
                    PageIndex = pageIndex,
                    PageSize = pageSize,
                    RowCount = rowCount
                };
                //将分页数据实体封装到JSON标准实体中
                jsonModel = new JsonModel()
                {
                    Data = pagedDataModel,
                    Msg = "成功",
                    Status = "ok",
                    BackUrl = ""
                };
                return jsonModel;
            }
            else
            {
                jsonModel = new JsonModel()
                {
                    Status = "no",
                    Msg = "失败"
                };
                return jsonModel;
            }
        }

        public EmsModel.JsonModel GetJsonModelEscheat2(string OrderID)
        {
            //当前页
            int pageIndex = 1;
            //页容量
            int pageSize = 999;
            EmsModel.OrderEquipDetail mod = new EmsModel.OrderEquipDetail();
            mod.OrderId =Convert.ToInt32(OrderID);
            List<EmsModel.OrderEquipDetail> modList = new EmsBLL.OrderEquipDetail().GetListByPage(mod,1,999);
            //定义分页数据实体
            PagedDataModel<EmsModel.OrderEquipDetail> pagedDataModel = null;
            //定义JSON标准格式实体中
            JsonModel jsonModel = null;
            if (modList.Count > 0)
            {
                var list = modList;
                //总条数
                int rowCount = modList.Count;
                //总页数
                int pageCount = (int)Math.Ceiling(rowCount * 1.0 / pageSize);
                //将数据封装到PagedDataModel分页数据实体中
                pagedDataModel = new PagedDataModel<EmsModel.OrderEquipDetail>()
                {
                    PageCount = pageCount,
                    PagedData = list,
                    PageIndex = pageIndex,
                    PageSize = pageSize,
                    RowCount = rowCount
                };
                //将分页数据实体封装到JSON标准实体中
                jsonModel = new JsonModel()
                {
                    Data = pagedDataModel,
                    Msg = "成功",
                    Status = "ok",
                    BackUrl = ""
                };
                return jsonModel;
            }
            else
            {
                jsonModel = new JsonModel()
                {
                    Status = "no",
                    Msg = "失败"
                };
                return jsonModel;
            }
        }

        #endregion

        #region 获取订单数据 分页
        /// <summary>
        /// 获取订单数据 分页
        /// </summary>
        /// <param name="Mod">查询条件</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">页容量，每页显示条数</param>
        /// <returns></returns>
        public EmsModel.JsonModel GetJsonModel(EmsModel.OrderInfo Mod, int pageIndex, int pageSize)
        {

            List<EmsModel.OrderInfo> modList = GetListByPage(Mod, ((pageIndex - 1) * pageSize) + 1, (pageIndex * pageSize));
            //定义分页数据实体
            PagedDataModel<EmsModel.OrderInfo> pagedDataModel = null;
            //定义JSON标准格式实体中
            JsonModel jsonModel = null;
            if (modList.Count > 0)
            {
                var list = modList;
                //总条数
                int rowCount = GetListByPageCount(Mod);
                //总页数
                int pageCount = (int)Math.Ceiling(rowCount * 1.0 / pageSize);
                //将数据封装到PagedDataModel分页数据实体中
                pagedDataModel = new PagedDataModel<EmsModel.OrderInfo>()
                {
                    PageCount = pageCount,
                    PagedData = list,
                    PageIndex = pageIndex,
                    PageSize = pageSize,
                    RowCount = rowCount
                };
                //将分页数据实体封装到JSON标准实体中
                jsonModel = new JsonModel()
                {
                    Data = pagedDataModel,
                    Msg = "成功",
                    Status = "ok",
                    BackUrl = ""
                };
                return jsonModel;
            }
            else
            {
                jsonModel = new JsonModel()
                {
                    Status = "no",
                    Msg = "失败"
                };
                return jsonModel;
            }
        }

        public EmsModel.JsonModel GetJsonModel_Land(EmsModel.View_LoanDate Mod, int pageIndex, int pageSize)
        {
            List<EmsModel.View_LoanDate> modList =new EmsBLL.View_LoanDate().GetListByPage(Mod, ((pageIndex - 1) * pageSize) + 1, (pageIndex * pageSize));
            //定义分页数据实体
            PagedDataModel<EmsModel.View_LoanDate> pagedDataModel = null;
            //定义JSON标准格式实体中
            JsonModel jsonModel = null;
            if (modList.Count > 0)
            {
                var list = modList;
                //总条数
                int rowCount = new EmsBLL.View_LoanDate().GetListByPageCount(Mod);
                //总页数
                int pageCount = (int)Math.Ceiling(rowCount * 1.0 / pageSize);
                //将数据封装到PagedDataModel分页数据实体中
                pagedDataModel = new PagedDataModel<EmsModel.View_LoanDate>()
                {
                    PageCount = pageCount,
                    PagedData = list,
                    PageIndex = pageIndex,
                    PageSize = pageSize,
                    RowCount = rowCount
                };
                //将分页数据实体封装到JSON标准实体中
                jsonModel = new JsonModel()
                {
                    Data = pagedDataModel,
                    Msg = "成功",
                    Status = "ok",
                    BackUrl = ""
                };
                return jsonModel;
            }
            else
            {
                jsonModel = new JsonModel()
                {
                    Status = "no",
                    Msg = "失败"
                };
                return jsonModel;
            }
        }

        public EmsModel.JsonModel GetJsonModel_RepairList(EmsModel.View_RepairList Mod, int pageIndex, int pageSize)
        {
            List<EmsModel.View_RepairList> modList = new EmsBLL.View_RepairList().GetListByPage(Mod, ((pageIndex - 1) * pageSize) + 1, (pageIndex * pageSize));
            //定义分页数据实体
            PagedDataModel<EmsModel.View_RepairList> pagedDataModel = null;
            //定义JSON标准格式实体中
            JsonModel jsonModel = null;
            if (modList.Count > 0)
            {
                var list = modList;
                //总条数
                int rowCount = new EmsBLL.View_RepairList().GetListByPageCount(Mod);
                //总页数
                int pageCount = (int)Math.Ceiling(rowCount * 1.0 / pageSize);
                //将数据封装到PagedDataModel分页数据实体中
                pagedDataModel = new PagedDataModel<EmsModel.View_RepairList>()
                {
                    PageCount = pageCount,
                    PagedData = list,
                    PageIndex = pageIndex,
                    PageSize = pageSize,
                    RowCount = rowCount
                };
                //将分页数据实体封装到JSON标准实体中
                jsonModel = new JsonModel()
                {
                    Data = pagedDataModel,
                    Msg = "成功",
                    Status = "ok",
                    BackUrl = ""
                };
                return jsonModel;
            }
            else
            {
                jsonModel = new JsonModel()
                {
                    Status = "no",
                    Msg = "失败"
                };
                return jsonModel;
            }
        }




        public EmsModel.JsonModel GetJsonModel_RepairLists(Hashtable ht, bool ispage = true)
        {
            int PageIndex = 0, PageSize = 0, PageCount = 0, RowCount = 0;
            if (ispage)
            {
                //增加起始条数、结束条数
                ht = common.AddStartEndIndex(ht);
                PageIndex = Convert.ToInt32(ht["PageIndex"]);
                PageSize = Convert.ToInt32(ht["PageSize"]);
            }
            DataTable modList = new EmsDAL.RepairDetails().GetPage(ht, ispage);
            //定义分页数据实体
            PagedDataModel<Dictionary<string, object>> pagedDataModel = null;
            //定义JSON标准格式实体中
            JsonModel jsonModel = null;
            if (modList.Rows.Count <= 0)
            {
                 jsonModel = new JsonModel()
                {
                    Status = "no",
                    Msg = "失败"
                };
                return jsonModel;
            }
            List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
            list = common.DataTableToList(modList);
            //总条数
            RowCount = Convert.ToInt32(ht["RowCount"].ToString());
            if (ispage)
            {
                //总页数
                PageCount = (int)Math.Ceiling(RowCount * 1.0 / PageSize);
            }
            //将数据封装到PagedDataModel分页数据实体中
            pagedDataModel = new PagedDataModel<Dictionary<string, object>>()
            {
                PageCount = PageCount,
                PagedData = list,
                PageIndex = PageIndex,
                PageSize = PageSize,
                RowCount = RowCount
            };          
            //将分页数据实体封装到JSON标准实体中
            jsonModel = new JsonModel()
            {
                Data = pagedDataModel,
                Msg = "成功",
                Status = "ok",
                BackUrl = ""
            };
            return jsonModel;
        }


        /// <summary>
        /// 获取订单数据 分页
        /// </summary>
        /// <param name="Mod">查询条件</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">页容量，每页显示条数</param>
        /// <returns></returns>
        public EmsModel.JsonModel GetJsonModelByOrder(EmsModel.OrderEquipDetail Mod, int pageIndex, int pageSize)
        {

            List<EmsModel.OrderEquipDetail> modList = new EmsBLL.OrderEquipDetail().GetListByPage(Mod, ((pageIndex - 1) * pageSize) + 1, (pageIndex * pageSize));
            //定义分页数据实体
            PagedDataModel<EmsModel.OrderEquipDetail> pagedDataModel = null;
            //定义JSON标准格式实体中
            JsonModel jsonModel = null;
            if (modList.Count > 0)
            {
                var list = modList;
                //总条数
                int rowCount = new EmsBLL.OrderEquipDetail().GetListByPageCount(Mod);
                //总页数
                int pageCount = (int)Math.Ceiling(rowCount * 1.0 / pageSize);
                //将数据封装到PagedDataModel分页数据实体中
                pagedDataModel = new PagedDataModel<EmsModel.OrderEquipDetail>()
                {
                    PageCount = pageCount,
                    PagedData = list,
                    PageIndex = pageIndex,
                    PageSize = pageSize,
                    RowCount = rowCount
                };
                //将分页数据实体封装到JSON标准实体中
                jsonModel = new JsonModel()
                {
                    Data = pagedDataModel,
                    Msg = "成功",
                    Status = "ok",
                    BackUrl = ""
                };
                return jsonModel;
            }
            else
            {
                jsonModel = new JsonModel()
                {
                    Status = "no",
                    Msg = "失败"
                };
                return jsonModel;
            }
        }
        #endregion

        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public EmsModel.OrderInfo GetEmsModel(int? ID)
        {
            return dal.GetEmsModel(ID);
        }
        #endregion

        #region 获取泛型数据列表
        /// <summary>
        /// 获取泛型数据列表
        /// </summary>
        public List<EmsModel.OrderInfo> GetList()
        {
            return dal.GetList();
        }
        

        /// <summary>
        /// 获取泛型数据列表
        /// </summary>
        public List<EmsModel.OrderEquipDetail> GetEmsModelExperimentId(string id)
        {
            return new EmsDAL.OrderEquipDetail().GetEmsModelExperimentId(id);
        }

        public List<EmsModel.View_orderCount> GetListVO(string OrderNo)
        {
            return dal.GetListVO(OrderNo);
        }
        public List<EmsModel.View_LoanANDEscheat> GetListEscheat(string OrderNo)
        {
            return dal.GetListEscheat(OrderNo);
        }
        public List<EmsModel.View_LoanDate> GetLoanDate(string creator)
        {
            return dal.GetLoanDate(creator);
        }
        #endregion

        #region 修改订单状态
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool UpdateOrder(EmsModel.OrderInfo Model)
        {
            EmsModel.OrderEquipDetail MOD = new EmsModel.OrderEquipDetail();
            MOD.OrderId = Model.Id;
            List<EmsModel.OrderEquipDetail> list = new EmsDAL.OrderEquipDetail().GetListByPage(MOD, 1, 999);
            return dal.UpdateOrder(Model, list);
        }
        #endregion
        public bool Lend(string orderNO, string orderDetailNO, int DetailType)
        {
            return dal.UpdateOrder(orderNO, orderDetailNO, DetailType);
        }
        public bool Lend(string strOrder, string orderNO, EmsModel.OrderInfo mod)
        {
            List<EmsModel.OrderEquipDetail> listModer = new List<EmsModel.OrderEquipDetail>();
            //"6,9,碳刷,18#6,9,碳刷,20"
            string[] sArr = strOrder.Split('#');
            for (int i = 0; i < sArr.Length; i++)
            {
                string[] sArr2 = sArr[i].Split(',');
                EmsModel.OrderEquipDetail model = new EmsModel.OrderEquipDetail();
                model.InventoryKindId =Convert.ToInt32(sArr2[0]);
                //model.OrderId =Convert.ToInt32( sArr2[1]);
                model.InstrumentEquip = sArr2[1];
                model.EquipDetailName = sArr2[1];
                model.EquipId = sArr2[2];
                model.Type = 1;

                listModer.Add(model);
            }
            int typeNo = 1;

            return dal.UpdateOrderLend(listModer, orderNO, typeNo, 1, mod);

        }

        public bool OtherLend(string strOrder,string LoanName,string Creator,string orderNO)
        {
            List<EmsModel.OrderEquipDetail> listModer = new List<EmsModel.OrderEquipDetail>();
            //"6,9,碳刷,18#6,9,碳刷,20"
            string[] sArr = strOrder.Split('#');
            for (int i = 0; i < sArr.Length; i++)
            {
                string[] sArr2 = sArr[i].Split(',');
                EmsModel.OrderEquipDetail model = new EmsModel.OrderEquipDetail();
                model.InventoryKindId = Convert.ToInt32(sArr2[0]);
                //model.OrderId = Convert.ToInt32(sArr2[1]);
                model.InstrumentEquip = sArr2[2];
                model.EquipDetailName = sArr2[2];
                model.EquipId = sArr2[3];
                model.Type = 1;

                listModer.Add(model);
            }
            int num = dal.GetStatusCountL(orderNO);
            int typeNo = 1;
            //是否已经完成计划借用数
            if ((listModer.Count - num) <= 0)
            {
                typeNo = 2;
            }
            return dal.OtherLend(listModer, LoanName,Creator, orderNO, typeNo, 1);
        }

        public bool Escheat(string strID,string orderID)
        {
            
            string[] sArr = strID.Split('#');

            int num = dal.GetStatusCountE(orderID);
            int typeNo = 3;
            //是否已经完成归还数
            if ((sArr.Length - num) >= 0)
            {
                typeNo = 4;
            }
            return dal.UpdateOrderEscheat(strID,orderID, typeNo, 2);

        }






        #region 创建订单

        public EmsModel.JsonModel CreateOrder(Hashtable ht)
        {
            try
            {

                //string[] Str = ht["YSelectStr"].ToString().Split(',');//

                //订单编号前缀
                string prefix = "";
                if (ht["Type"].ToString() == "0")
                {
                    prefix = "SY";
                }
                else if (ht["Type"].ToString() == "1")
                {
                    prefix = "YJ";
                }

                EmsDAL.OrderEquipDetail ModelOrderEquipDetail = new EmsDAL.OrderEquipDetail();

                //订单赋值
                EmsModel.OrderInfo ModelOrderInfo = new EmsModel.OrderInfo();

                ModelOrderInfo.OrderNo = prefix;
                ModelOrderInfo.LoanName = ht["LoanName"].ToString();
                ModelOrderInfo.ExperimentId = Convert.ToInt32(ht["ExperimentId"]);
                ModelOrderInfo.Type = Convert.ToByte(ht["Type"]);
                ModelOrderInfo.Status = 0;
                ModelOrderInfo.Creator = ht["Creator"].ToString();
                ModelOrderInfo.CreateTime = DateTime.Now;
                ModelOrderInfo.IsDelete = 0;

                //修改实验“是否生成订单”状态
                EmsDAL.PlanExperiment DALPE = new EmsDAL.PlanExperiment();
                EmsModel.PlanExperiment ModelPE = DALPE.GetData(ht["ExperimentId"].ToString())[0];
                ModelPE.Status = 1;//将实验状态赋值为“已生成订单”

                //事务
                using (SqlTransaction trans = dal.GetTran())
                {
                    try
                    {
                        //添加订单
                        int orderId = dal.Add(trans, ModelOrderInfo);
                        if (orderId <= 0)
                        {
                            //回滚
                            trans.Rollback();
                            //定义JSON标准格式实体中
                            JsonModel jsonModel1 = new JsonModel();
                            jsonModel1.Status = "no";
                            jsonModel1.Msg = "订单生成失败";

                            return jsonModel1;
                        }
                        //修改订单编号
                        ModelOrderInfo.Id = orderId;
                        ModelOrderInfo.OrderNo = prefix + DateTime.Now.ToString("yyMMddHHmmss") + orderId;
                        int UpdateReturn = dal.Update(trans, ModelOrderInfo);
                        if (UpdateReturn != 1)
                        {
                            //回滚
                            trans.Rollback();
                            //定义JSON标准格式实体中
                            JsonModel jsonModel1 = new JsonModel();
                            jsonModel1.Status = "no";
                            jsonModel1.Msg = "订单生成失败";

                            return jsonModel1;
                        }
                        //修改实验状态
                        int UpdatePEReturn = DALPE.Update(trans, ModelPE);
                        if (UpdatePEReturn != 1)
                        {
                            //回滚
                            trans.Rollback();
                            //定义JSON标准格式实体中
                            JsonModel jsonModel1 = new JsonModel();
                            jsonModel1.Status = "no";
                            jsonModel1.Msg = "订单生成失败";

                            return jsonModel1;
                        }

                        #region 添加订单设备详情
                        
                        ////生成订单
                        //int AddCount = 0;
                        //int SuccessCount = 0;
                        ////循环添加设备
                        //foreach (string item in Str)
                        //{
                        //    int EquipKindId = Convert.ToInt32(item.Substring(0, item.IndexOf("-")));
                        //    int Count = Convert.ToInt32(item.Substring(item.IndexOf("-") + 1, item.IndexOf(":") - item.IndexOf("-") - 1));
                        //    string InstrumentEquip = item.Substring(item.IndexOf(":") + 1);

                        //    //更新需要添加的设备数量
                        //    AddCount += Count;
                        //    //每个设备添加一条数据
                        //    for (int i = 0; i < Count; i++)
                        //    {
                        //        //model赋值
                        //        EmsModel.OrderEquipDetail model = new EmsModel.OrderEquipDetail();
                        //        model.OrderId = orderId;
                        //        model.InventoryKindId = EquipKindId;
                        //        model.EquipId = "";
                        //        model.InstrumentEquip = InstrumentEquip;
                        //        model.EquipDetailName = "";
                        //        model.Type = 0;
                        //        int ret = ModelOrderEquipDetail.Add(trans, model);
                        //        if (ret > 0)
                        //        {
                        //            SuccessCount++;
                        //        }
                        //    }
                            
                        //}
                        //if (AddCount != SuccessCount)
                        //{
                        //    //回滚
                        //    trans.Rollback();
                        //    //定义JSON标准格式实体中
                        //    JsonModel jsonModel1 = new JsonModel();
                        //    jsonModel1.Status = "no";
                        //    jsonModel1.Msg = "订单生成失败";

                        //    return jsonModel1;
                        //}
                        //else
                        //{
                        //    //提交
                        //    trans.Commit();
                        //}
                        #endregion
                        //提交
                        trans.Commit();
                    }
                    catch (Exception)
                    {
                        //回滚
                        trans.Rollback();
                        throw;
                    }
                }

                //定义JSON标准格式实体中
                JsonModel jsonModel = new JsonModel();
                jsonModel.Status = "ok";
                jsonModel.Msg = "订单生成成功";

                return jsonModel;
            }
            catch (Exception ex)
            {
                JsonModel jsonModel = new JsonModel();
                jsonModel.Status = "error";
                jsonModel.Msg = ex.ToString();
                return jsonModel;
            }
        }

        #endregion

        /// <summary>
        /// 获取订单设备
        /// </summary>
        /// <param name="Mod">查询条件</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">页容量，每页显示条数</param>
        /// <returns></returns>
        public EmsModel.JsonModel GetOrderEquipList(Hashtable ht)
        {
            EmsDAL.OrderEquipDetail DALOED = new EmsDAL.OrderEquipDetail();
            BLLCommon com = new BLLCommon();
            try
            {
                DataTable dt = DALOED.GetData(ht);
                //定义JSON标准格式实体中
                JsonModel jsonModel = null;
                if (dt.Rows.Count == 0)
                {
                    jsonModel = new JsonModel()
                    {
                        Status = "no",
                        Msg = "无数据"
                    };
                    return jsonModel;
                }
                //将分页数据实体封装到JSON标准实体中
                jsonModel = new JsonModel()
                {
                    Data = com.DataTableToList(dt),
                    Msg = "",
                    Status = "ok",
                    BackUrl = ""
                };
                return jsonModel;
            }
            catch (Exception ex)
            {
                JsonModel jsonModel = new JsonModel();
                jsonModel.Status = "error";
                jsonModel.Msg = ex.ToString();
                return jsonModel;
            }
        }

    }
}
