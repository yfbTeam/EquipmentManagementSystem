using EmsModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace EmsBLL
{
    public partial class InventoryListDetail
    {        
        BLLCommon common = new BLLCommon();

        #region 生成盘点单

        public JsonModel CreateInventoryList(int planid, string type, string useridcard)
        {
            //定义JSON标准格式实体中
            JsonModel jsonModel = new JsonModel();
            try
            {
                //事务
                using (SqlTransaction trans = dal.GetTran())
                {
                    try
                    {
                        int listCount =new EmsDAL.InventoryList().AddInventoryList(trans, planid, type, useridcard);
                        if (listCount <= 0)
                        {
                            trans.Rollback();//回滚
                            jsonModel.Status = "no";
                            jsonModel.Msg = "生成盘点单失败";
                            return jsonModel;
                        }
                        int addCount = dal.AddInventoryListDetail(trans, planid, type);
                        if (addCount <= 0)
                        {
                            trans.Rollback();//回滚
                            jsonModel.Status = "no";
                            jsonModel.Msg = "生成盘点单失败";
                            return jsonModel;
                        }
                        EmsModel.InventoryPlan plan=new EmsBLL.InventoryPlan().GetEmsModel(planid);
                        plan.IsGenerate=1;
                        int upcount = new EmsDAL.InventoryPlan().Update(plan);
                        if (upcount <= 0)
                        {
                            trans.Rollback();//回滚
                            jsonModel.Status = "no";
                            jsonModel.Msg = "生成盘点单失败";
                            return jsonModel;
                        }
                        trans.Commit();//提交                        
                    }
                    catch (Exception)
                    {
                        trans.Rollback();//回滚
                        throw;
                    }
                }
                jsonModel.Status = "ok";
                jsonModel.Msg = "操作成功";
                return jsonModel;
            }
            catch (Exception ex)
            {
                jsonModel.Status = "error";
                jsonModel.Msg = ex.ToString();
                return jsonModel;
            }
        }
        #endregion

        #region 根据盘点单获得楼房信息
        /// <summary>
        /// 根据盘点单获得楼房信息
        /// </summary>  
        public DataTable GetBuildingByInventory(string invenid, string type="")
        {            
            return dal.GetBuildingByInventory(invenid,type);
        }
        #endregion

        #region 根据盘点单id及楼房id获得盘点时的楼层及房间信息
        /// <summary>
        /// 根据盘点单id及楼房id获得盘点时的楼层及房间信息
        /// </summary>  
        public DataTable GetLayersAndRoomsByInvenId(string invenid, string buildid, string type)
        {            
            return dal.GetLayersAndRoomsByInvenId(invenid,buildid,type);
        }
        #endregion

        #region 获取房间的仪器设备信息
        /// <summary>
        /// 获取房间的仪器设备信息
        /// </summary>
        /// <param name="invenid">盘点单id</param>
        /// <param name="roomid">房间id</param>
        /// <returns></returns>
        public EmsModel.JsonModel GetJsonModelEquip(string invenid, string roomid)
        {
            //当前页
            int pageIndex = 1;
            //页容量
            int pageSize = 999;
            List<EmsModel.View_InvenRoomEquip> modList = dal.GetRoomEquipList(invenid, roomid);
            //定义分页数据实体
            PagedDataModel<EmsModel.View_InvenRoomEquip> pagedDataModel = null;
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
                pagedDataModel = new PagedDataModel<EmsModel.View_InvenRoomEquip>()
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

        #region 根据条形码得到盘点单中的一个对象实体
        /// <summary>
        /// 根据条形码得到盘点单中的一个对象实体
        /// </summary>
        public EmsModel.View_InvenRoomEquip GetInvenModelByBarcode(string invenid, string barcode)
        {
            return dal.GetInvenModelByBarcode(invenid,barcode);
        }
        #endregion

        #region 保存房间盘点信息
        /// <summary>
        /// 保存房间盘点信息
        /// </summary>
        /// <param name="invenid">盘点单id</param>
        /// <param name="roomid">房间id</param>
        /// <param name="idStr">盘点详情id</param>
        /// <param name="editStr">需要换房间的盘点详情id</param>
        /// <param name="useridcard">用户身份证号</param>
        /// <returns></returns>
        public JsonModel SaveRoomInventory(string invenid, string roomid, string idStr, string editStr, string useridcard)
        {
            //定义JSON标准格式实体中
            JsonModel jsonModel = new JsonModel();
            try
            {
                //事务
                using (SqlTransaction trans = dal.GetTran())
                {
                    try
                    {
                        string[] idArray =idStr.Split(',');
                        string[] editArray = editStr.Split(',');
                        int result = 0;
                        if (!string.IsNullOrEmpty(idStr))
                        {                            
                            int idcount = 0;
                            foreach (string deid in idArray)
                            {
                                EmsModel.InventoryListDetail ind = dal.GetEmsModel(Convert.ToInt32(deid));
                                ind.IsLoss = true;
                                result = dal.Update(trans,ind);
                                if (result > 0)
                                {
                                    idcount++;
                                }
                            }
                            if (idArray.Length != idcount)
                            {
                                trans.Rollback();//回滚
                                jsonModel.Status = "no";
                                jsonModel.Msg = "保存失败";
                                return jsonModel;
                            }
                        }
                        if(!string.IsNullOrEmpty(editStr))
                        {                            
                            int editcount = 0;
                            foreach (string editid in editArray)
                            {
                                EmsModel.InventoryListDetail ind = dal.GetEmsModel(Convert.ToInt32(editid));
                                ind.SourceRoomId = ind.RoomId;
                                ind.RoomId = Convert.ToInt32(roomid);                                
                                ind.IsLoss = true;
                                result = dal.Update(trans, ind);
                                EmsDAL.EquipDetail dal_equip = new EmsDAL.EquipDetail();
                                EmsModel.EquipDetail equip = dal_equip.GetEmsModel(ind.EquipId);
                                equip.StorageLocation = roomid;
                                dal_equip.Update(trans, equip);//修改仪器设备详情存放地点
                                if (result > 0)
                                {
                                    editcount++;
                                }
                            }
                            if (editArray.Length != editcount)
                            {
                                trans.Rollback();//回滚
                                jsonModel.Status = "no";
                                jsonModel.Msg = "保存失败";
                                return jsonModel;
                            }
                        }
                        EmsDAL.InventoryList dal_list = new EmsDAL.InventoryList();
                        EmsModel.InventoryList list = dal_list.GetEmsModelByInvRoomId(invenid, roomid);
                        list.RealQuantity = (!string.IsNullOrEmpty(idStr) ? idArray.Length : 0) + (!string.IsNullOrEmpty(editStr) ? editArray.Length : 0);
                        list.Status = 1;
                        list.Operator = useridcard;
                        list.Editor = useridcard;
                        list.UpdateTime = DateTime.Now;
                        result = dal_list.Update(trans, list);
                        if (result == 0)
                        {
                            trans.Rollback();//回滚
                            jsonModel.Status = "no";
                            jsonModel.Msg = "保存失败";
                            return jsonModel;
                        }
                        if (dal.GetNotInventoryCount(trans,invenid) == 0)
                        {
                            EmsDAL.InventoryPlan dal_plan = new EmsDAL.InventoryPlan();
                            EmsModel.InventoryPlan plan = dal_plan.GetEmsModel(Convert.ToInt32(invenid));
                            plan.Status = 1;
                            result = dal_plan.Update(trans, plan);
                            if (result == 0)
                            {
                                trans.Rollback();//回滚
                                jsonModel.Status = "no";
                                jsonModel.Msg = "保存失败";
                                return jsonModel;
                            }
                        }
                        trans.Commit();//提交          
                    }
                    catch (Exception)
                    {
                        trans.Rollback();//回滚
                        throw;
                    }
                }
                jsonModel.Status = "ok";
                jsonModel.Msg = "操作成功";
                return jsonModel;
            }
            catch (Exception ex)
            {
                jsonModel.Status = "error";
                jsonModel.Msg = ex.ToString();
                return jsonModel;
            }
        }
        #endregion

        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public EmsModel.InventoryListDetail GetEmsModel(int? ID)
        {
            return dal.GetEmsModel(ID);
        }
        #endregion
    }
}
