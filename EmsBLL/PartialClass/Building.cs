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
    public partial class Building
    {
        BLLCommon common = new BLLCommon();
        #region 获取楼房列表数据 分页
        /// <summary>
        /// 获取楼房列表数据 分页
        /// </summary>
        /// <param name="Mod">查询条件</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">页容量，每页显示条数</param>
        /// <returns></returns>
        public EmsModel.JsonModel GetJsonModel(EmsModel.Building Mod, int pageIndex, int pageSize)
        {
            List<EmsModel.Building> modList = dal.GetListByPage(Mod, ((pageIndex - 1) * pageSize) + 1, (pageIndex * pageSize));
            //定义分页数据实体
            PagedDataModel<EmsModel.Building> pagedDataModel = null;
            //定义JSON标准格式实体中
            JsonModel jsonModel = null;
            if (modList.Count > 0)
            {
                var list = modList;
                //总条数
                int rowCount = dal.GetListByPageCount(Mod);
                //总页数
                int pageCount = (int)Math.Ceiling(rowCount * 1.0 / pageSize);
                //将数据封装到PagedDataModel分页数据实体中
                pagedDataModel = new PagedDataModel<EmsModel.Building>()
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

        #region 获得楼房信息
        /// <summary>
        /// 获得楼房信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetBuildingInfo(string pid = "0",string type="")
        {
            return dal.GetBuildingInfo(pid,type);
        }
        #endregion

        #region 根据楼房id获得楼层及房间信息
        /// <summary>
        /// 根据楼房id获得楼层及房间信息
        /// </summary>  
        public DataTable GetLayersAndRoomsById(string buildid, string type = "", string secplaceid="")
        {
            return dal.GetLayersAndRoomsById(buildid, type, secplaceid);
        }
        #endregion

        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public EmsModel.Building GetEmsModel(int? ID)
        {
            return dal.GetEmsModel(ID);
        }
        #endregion

        #region 判断某楼房或某楼房的楼层是否已存在
        /// <summary>
        /// 判断某楼房或某楼房的楼层是否已存在
        /// </summary>
        /// <param name="name">楼房/楼层名称</param>       
        /// <param name="Pid">0/楼房Id</param>
        /// <param name="Id">楼房/楼层Id</param>
        /// <returns></returns>
        public bool IsNameExists(string name, Int32 Pid, Int32 Id = 0)
        {
            return dal.IsNameExists(name, Pid, Id);
        }
        #endregion

        #region 判断某楼房的某楼层的房间是否已存在
        /// <summary>
        /// 判断某楼房的某楼层的房间是否已存在
        /// </summary>
        /// <param name="roomno">房间号</param>      
        /// <param name="Pid">楼层Id</param>
        /// <param name="PPid">楼房Id</param>
        /// <param name="Id">房间Id</param>
        /// <returns></returns>
        public bool IsNameExists(string roomno, Int32 Pid, Int32 PPid, Int32 Id = 0)
        {
            return dal.IsNameExists(roomno, Pid, PPid, Id);
        }
        #endregion

        #region 为房间分配办公家具或科研设备
        public JsonModel SetRoomDistributionEquip(string roomid,string type, string equipids, string owneridcard)
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
                        if (!string.IsNullOrEmpty(equipids))
                        {
                            string[] idArray = equipids.Split(',');
                            int count = 0;
                            EmsDAL.EquipDetail dal_equip = new EmsDAL.EquipDetail();
                            foreach (string equipid in idArray)
                            {
                                EmsModel.EquipDetail equip = dal_equip.GetEmsModel(Convert.ToInt32(equipid));
                                equip.StorageLocation = roomid;
                                if (type == "2")
                                {
                                    equip.EquipOwner = owneridcard;
                                }
                                int result = dal_equip.Update(trans, equip);
                                if (result > 0)
                                {
                                    count++;
                                }
                            }
                            if (idArray.Length != count)
                            {
                                trans.Rollback();//回滚
                                jsonModel.Status = "no";
                                jsonModel.Msg = "操作失败";
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

        #region 删除楼房

        public JsonModel DeleteBuilding(EmsModel.Building build, string flag)
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
                        if (new EmsDAL.EquipDetail().IsHasEquipByRoomIds(build.Id.ToString(), flag))
                        {
                            jsonModel.Status = "exist";
                            jsonModel.Msg = flag == "room" ? "该房间内已存放仪器，不能删除!" : (flag == "layer" ? "该楼层的房间内已存放仪器，不能删除!" : "该楼房的房间内已存放仪器，不能删除!");
                            return jsonModel;
                        }
                        int upCount = dal.UpdateBatch(trans, build.Id.ToString(), flag);
                        if (upCount <= 0)
                        {
                            trans.Rollback();//回滚
                            jsonModel.Status = "no";
                            jsonModel.Msg = "删除失败";
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

        #region 根据类型获得房间信息
        /// <summary>
        /// 根据类型获得房间信息
        /// </summary>  
        public DataTable GetRoomInfoByType(string type)
        {
            return dal.GetRoomInfoByType(type);
        }
        #endregion

        public JsonModel GetLayersAndRoomsByIdNew(string buildid, string type = "", string secplaceid = "")
        {
            DataTable dt = dal.GetLayersAndRoomsById(buildid, type, secplaceid);
            JsonModel jsonModel = null;
            if (dt.Rows.Count <= 0)
            {
                jsonModel = new JsonModel()
                {
                    Status = "no",
                    Msg = "无数据"
                };
                return jsonModel;
            }
            List<string> list = new List<string>();
            list.Add(common.DataTableToJson(dt));
            DataRow[] parLayer = dt.Select("Pid=" + buildid);
            DataTable dtnew = new DataTable();
            dtnew = parLayer.CopyToDataTable();
            dtnew.TableName = "ds";
            list.Add(common.DataTableToJson(dtnew));
            jsonModel = new JsonModel()
            {
                Data = list,
                Status = "ok"
            };
            return jsonModel;
        }

        public JsonModel UpdateStorageLocationMore(Hashtable ht) 
        {
            try
            {
                int result = dal.UpdateStorageLocationMore(ht);
                //定义JSON标准格式实体中
                JsonModel jsonModel = new JsonModel();
                if (result > 0)
                {
                    jsonModel.Status = "ok";
                    jsonModel.Msg = "操作成功";
                }
                else
                {
                    jsonModel.Status = "no";
                    jsonModel.Msg = "操作失败";
                }
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
