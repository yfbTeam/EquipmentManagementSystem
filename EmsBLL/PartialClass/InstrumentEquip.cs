using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EmsModel;
using System.Collections;
using System.Data;
using System.Data.SqlClient;

namespace EmsBLL
{
    public partial class InstrumentEquip
    {
        BLLCommon common = new BLLCommon();
        /// <summary>
        /// 分页查询分类列表
        /// </summary>
        /// <param name="ht"></param>
        /// <returns></returns>
        public JsonModel GetPage(Hashtable ht)
        {
            try
            {
            //增加起始条数、结束条数
            ht = common.AddStartEndIndex(ht);
            int PageIndex = Convert.ToInt32(ht["PageIndex"]);
            int PageSize = Convert.ToInt32(ht["PageSize"]);
            List<EmsModel.InstrumentEquip> modList = dal.GetList(ht);
            //定义分页数据实体
            PagedDataModel<EmsModel.InstrumentEquip> pagedDataModel = null;
            //定义JSON标准格式实体中
            JsonModel jsonModel = null;
            if (modList.Count <= 0)
            {
                jsonModel = new JsonModel()
                {
                    Status = "no",
                    Msg = ""
                };
                return jsonModel;
            }
            var list = modList;
            //总条数
                int RowCount = dal.GetListByPageCount(ht);
            //总页数
            int PageCount = (int)Math.Ceiling(RowCount * 1.0 / PageSize);
            //将数据封装到PagedDataModel分页数据实体中
            pagedDataModel = new PagedDataModel<EmsModel.InstrumentEquip>()
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

        /// <summary>
        /// 获得分类详情
        /// </summary>
        /// <param name="ht"></param>
        /// <returns></returns>
        public JsonModel GetModel(Hashtable ht)
        {
            return common.GetJsonModelByDataTable(dal.GetIEDetails(ht));
        }

        /// <summary>
        /// 分页查询库存情况
        /// </summary>
        /// <param name="ht"></param>
        /// <returns></returns>
        public JsonModel GetPageStock(Hashtable ht)
        {
            try
            {
                //增加起始条数、结束条数
                ht = common.AddStartEndIndex(ht);
                int PageIndex = Convert.ToInt32(ht["PageIndex"]);
                int PageSize = Convert.ToInt32(ht["PageSize"]);
                DataTable dt = dal.GetListStock(ht);

                //定义分页数据实体
                PagedDataModel<string> pagedDataModel = null;
                //定义JSON标准格式实体中
                JsonModel jsonModel = null;
                if (dt.Rows.Count <= 0)
                {
                    jsonModel = new JsonModel()
                    {
                        Status = "no",
                        Msg = "没有数据"
                    };
                    return jsonModel;
                }
                string jsondt = common.DataTableToJson(dt);
                List<string> list = new List<string>();
                list.Add(jsondt);
                //总条数
                int RowCount = dal.GetListByPageCountStock(ht);
                //总页数
                int PageCount = (int)Math.Ceiling(RowCount * 1.0 / PageSize);
                //将数据封装到PagedDataModel分页数据实体中
                pagedDataModel = new PagedDataModel<string>()
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

        #region 获取仪器设备分类数据 分页
        /// <summary>
        /// 获取仪器设备分类数据 分页
        /// </summary>
        /// <param name="Mod">查询条件</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">页容量，每页显示条数</param>
        /// <returns></returns>
        public EmsModel.JsonModel GetJsonModel(EmsModel.InstrumentEquip Mod, int pageIndex, int pageSize, string joinStr = "=", string selwareid="")
        {

            List<EmsModel.InstrumentEquip> modList = dal.GetListByPageAndWareid(Mod, ((pageIndex - 1) * pageSize) + 1, (pageIndex * pageSize), joinStr, selwareid);
            //定义分页数据实体
            PagedDataModel<EmsModel.InstrumentEquip> pagedDataModel = null;
            //定义JSON标准格式实体中
            JsonModel jsonModel = null;
            if (modList.Count > 0)
            {
                var list = modList;
                //总条数
                int rowCount = dal.GetListByPageCountAndWareid(Mod, joinStr, selwareid);
                //总页数
                int pageCount = (int)Math.Ceiling(rowCount * 1.0 / pageSize);
                //将数据封装到PagedDataModel分页数据实体中
                pagedDataModel = new PagedDataModel<EmsModel.InstrumentEquip>()
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

        #region 设置仪器设备分类
        /// <summary>
        /// 设置仪器设备分类
        /// </summary>
        /// <param name="roleid">库房id</param>
        /// <param name="menuids">仪器设备分类ids字符串，以逗号连接</param>
        /// <returns>返回 影响行数</returns>
        public JsonModel SetInstrumentEquip(string wareid, string insEquipids)
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
                        string[] idArray = insEquipids.Split(',');
                        int count = 0, result = 0;
                        foreach (string insid in idArray)
                        {
                            int itemid = Convert.ToInt32(insid);
                            EmsModel.InstrumentEquip insEp = dal.GetEmsModel(itemid);
                            insEp.WarehouseId = Convert.ToInt32(wareid);
                            result = dal.Update(trans,insEp);
                            if (result > 0)
                            {
                                count++;
                            }
                        }
                        if (idArray.Length != count)
                        {
                            trans.Rollback();//回滚
                            jsonModel.Status = "no";
                            jsonModel.Msg = "保存失败";
                            return jsonModel;
                        }
                        else
                        {
                            trans.Commit();//提交
                        }
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
        public EmsModel.InstrumentEquip GetEmsModel(int? ID)
        {
            return dal.GetEmsModel(ID);
        }

        public EmsModel.InstrumentEquip GetModelByNumber(string Number)
        {
            return dal.GetModelByNumber(Number);
        }
        
        #endregion

        #region 判断耗材是否已存在
        /// <summary>
        /// 判断耗材是否已存在
        /// </summary>
        public bool IsInsEpExists(string number,string name,string model, Int32 Id = 0)
        {
            bool bln = dal.IsInsEpExists(number, name, model, Id);
            return bln;
        }
        #endregion
    }
}
