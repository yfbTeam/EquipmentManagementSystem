using EmsModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace EmsBLL
{
    public partial class InventoryList
    {
        BLLCommon common = new BLLCommon();
        #region 获取盘点单列表数据 分页
        /// <summary>
        /// 获取盘点单列表数据 分页
        /// </summary>
        /// <param name="ht">查询条件</param>
        /// <returns>符合数据</returns>
        public JsonModel GetInvenListDataPage(Hashtable ht, bool ispage=true)
        {
            try
            {
                //增加起始条数、结束条数
                ht = common.AddStartEndIndex(ht);
                int PageIndex = Convert.ToInt32(ht["PageIndex"]);
                int PageSize = Convert.ToInt32(ht["PageSize"]);

                DataTable modList = dal.GetInvenListDataPage(ht, ispage);
                //定义分页数据实体
                PagedDataModel<Dictionary<string, object>> pagedDataModel = null;
                //定义JSON标准格式实体中
                JsonModel jsonModel = null;
                if (modList.Rows.Count <= 0)
                {
                    jsonModel = new JsonModel()
                    {
                        Status = "no",
                        Msg = "无数据"
                    };
                    return jsonModel;
                }

                List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
                list = common.DataTableToList(modList);
                //总条数
                int RowCount = Convert.ToInt32(ht["RowCount"].ToString());
                //总页数
                int PageCount = (int)Math.Ceiling(RowCount * 1.0 / PageSize);
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
        #endregion

        #region 导出盘点单信息
        /// <summary>
        /// 导出盘点单信息
        /// </summary>
        /// <param name="ht"></param>
        /// <returns></returns>
        public JsonModel ExportInventoryExcel(Hashtable ht)
        {
            try
            {
                //增加起始条数、结束条数
                ht = common.AddStartEndIndex(ht);
                int PageIndex = Convert.ToInt32(ht["PageIndex"]);
                int PageSize = Convert.ToInt32(ht["PageSize"]);
                DataTable modList = dal.GetInvenListDataPage(ht,false);
                //定义JSON标准格式实体中
                JsonModel jsonModel = null;
                if (modList.Rows.Count <= 0)
                {
                    jsonModel = new JsonModel()
                    {
                        Status = "no",
                        Msg = "无数据"
                    };
                    return jsonModel;
                }
                List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
                list = common.DataTableToList(modList);
                PagedDataModel<Dictionary<string, object>> pagedDataModel = null;
                pagedDataModel = new PagedDataModel<Dictionary<string, object>>()
                {
                    PageCount = 1,
                    PagedData = list,
                    PageIndex = PageIndex,
                    PageSize = PageSize,
                    RowCount = 1
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
        #endregion

        #region 获取盘点单总数信息
        /// <summary>
        /// 获取盘点单总数信息
        /// </summary>
        public DataTable GetInvenListCount(string planid)
        {
            return dal.GetInvenListCount(planid);
        }
        #endregion
    }
}
