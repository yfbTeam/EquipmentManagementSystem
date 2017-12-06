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
    public partial class EquipList
    {
        BLLCommon common = new BLLCommon();
        /// <summary>
        /// 获得查询数据的总条数
        /// </summary>
        /// <param name="ht">查询条件</param>
        /// <returns></returns>
        public int GetListByPageCount(Hashtable ht)
        {
            return dal.GetListByPageCount(ht);
        }
        /// <summary>
        /// 查询根据条件
        /// </summary>
        /// <param name="ht">查询条件</param>
        /// <returns>符合数据</returns>
        public JsonModel GetPage(Hashtable ht)
        {
            try
            {
                //增加起始条数、结束条数
                ht = common.AddStartEndIndex(ht);
                int PageIndex = Convert.ToInt32(ht["PageIndex"]);
                int PageSize = Convert.ToInt32(ht["PageSize"]);

                List<EmsModel.View_EquipListDetail> modList = dal.GetList(ht);
                //定义分页数据实体
                PagedDataModel<EmsModel.View_EquipListDetail> pagedDataModel = null;
                //定义JSON标准格式实体中
                JsonModel jsonModel = null;
                if (modList.Count <= 0)
                {
                    jsonModel = new JsonModel()
                    {
                        Status = "no",
                        Msg = "无数据"
                    };
                    return jsonModel;
                }
                var list = modList;
                //总条数
                int RowCount = GetListByPageCount(ht);
                //总页数
                int PageCount = (int)Math.Ceiling(RowCount * 1.0 / PageSize);
                //将数据封装到PagedDataModel分页数据实体中
                pagedDataModel = new PagedDataModel<EmsModel.View_EquipListDetail>()
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
        /// 保存计划
        /// </summary>
        /// <param name="ht">参数Key:Id</param>
        /// <returns></returns>
        public JsonModel SaveEquipList(Hashtable ht)
        {
            try
            {
                int RelationID = Convert.ToInt32(ht["RelationID"].ToString());
                string[] Str = ht["YSelectStr"].ToString().Split(',');
                if (string.IsNullOrEmpty(ht["YSelectStr"].ToString()))
                {
                    Str = new string[0];
                }

                //事务
                using (SqlTransaction trans = dal.GetTran())
                {
                    try
                    {
                        //清除实验设备
                        dal.DeleteEquipList(trans, ht);

                        int count = 0;
                        //循环添加设备
                        foreach (string item in Str)
                        {
                            int EquipKindId = Convert.ToInt32(item.Substring(0, item.IndexOf("-")));
                            int Count = Convert.ToInt32(item.Substring(item.IndexOf("-") + 1, item.IndexOf(":") - item.IndexOf("-") - 1));

                            //model赋值
                            EmsModel.EquipList model = new EmsModel.EquipList();
                            model.RelationID = RelationID;
                            model.EquipKindId = EquipKindId;
                            model.Count = Count;
                            int ret = dal.Add(trans, model);
                            if (ret > 0)
                            {
                                count++;
                            }
                        }
                        if (Str.Length != count)
                        {
                            //回滚
                            trans.Rollback();
                            //定义JSON标准格式实体中
                            JsonModel jsonModel1 = new JsonModel();
                            jsonModel1.Status = "no";
                            jsonModel1.Msg = "保存失败";

                            return jsonModel1;
                        }
                        else
                        {
                            //提交
                            trans.Commit();
                        }
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
                jsonModel.Msg = "保存成功";
                    
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
        /// 快速模板实验设备列表
        /// </summary>
        /// <param name="ht">查询条件</param>
        /// <returns>符合数据</returns>
        public JsonModel GetPageTempSelect(Hashtable ht)
        {
            try
            {
                //增加起始条数、结束条数
                ht = common.AddStartEndIndex(ht);
                int PageIndex = Convert.ToInt32(ht["PageIndex"]);
                int PageSize = Convert.ToInt32(ht["PageSize"]);

                DataTable dt = dal.GetPageTempSelect(ht);
                //定义分页数据实体
                PagedDataModel<string> pagedDataModel = null;
                //定义JSON标准格式实体中
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
                string dtJson = common.DataTableToJson(dt);
                List<string> list = new List<string>();
                list.Add(dtJson);
                //总条数
                int RowCount = dal.GetListByPageCountTempSelect(ht);
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
        /// <summary>
        /// 查询根据条件
        /// </summary>
        /// <param name="ht">查询条件</param>
        /// <returns>符合数据</returns>
        public JsonModel GetExperimentEquipList(Hashtable ht)
        {
            try
            {

                DataTable dt = dal.GetExperimentEquipList(ht);
                //定义JSON标准格式实体中
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
                string dtJson = common.DataTableToJson(dt);
                //将分页数据实体封装到JSON标准实体中
                jsonModel = new JsonModel()
                {
                    Data = dtJson,
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
