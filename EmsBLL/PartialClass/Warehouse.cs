using EmsModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace EmsBLL
{
    public partial class Warehouse
    {
        #region 获取库房列表数据
        public EmsModel.JsonModel GetJsonModel(EmsModel.Warehouse ware)
        {
            //当前页
            int pageIndex = 1;
            //页容量
            int pageSize = 16;
            List<EmsModel.Warehouse> modList = GetList(ware);
            //定义分页数据实体
            PagedDataModel<EmsModel.Warehouse> pagedDataModel = null;
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
                pagedDataModel = new PagedDataModel<EmsModel.Warehouse>()
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

        #region 获取库房列表数据 分页
        /// <summary>
        /// 获取库房列表数据 分页
        /// </summary>
        /// <param name="Mod">查询条件</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">页容量，每页显示条数</param>
        /// <returns></returns>
        public EmsModel.JsonModel GetJsonModel(EmsModel.Warehouse Mod, int pageIndex, int pageSize)
        {
            List<EmsModel.Warehouse> modList = dal.GetListByPageAndSear(Mod, ((pageIndex - 1) * pageSize) + 1, (pageIndex * pageSize));
            //定义分页数据实体
            PagedDataModel<EmsModel.Warehouse> pagedDataModel = null;
            //定义JSON标准格式实体中
            JsonModel jsonModel = null;
            if (modList.Count > 0)
            {
                var list = modList;
                //总条数
                int rowCount = dal.GetListByPageCountAndSear(Mod);
                //总页数
                int pageCount = (int)Math.Ceiling(rowCount * 1.0 / pageSize);
                //将数据封装到PagedDataModel分页数据实体中
                pagedDataModel = new PagedDataModel<EmsModel.Warehouse>()
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
        public EmsModel.Warehouse GetEmsModel(int? ID)
        {
            return dal.GetEmsModel(ID);
        }
        #endregion

        #region 获取泛型数据列表
        /// <summary>
        /// 获取泛型数据列表
        /// </summary>
        public List<EmsModel.Warehouse> GetList(EmsModel.Warehouse ware)
        {
            return dal.GetList(ware);
        }
        #endregion

        #region 判断库房名称是否已存在
        /// <summary>
        /// 判断库房名称是否已存在
        /// </summary>
        public bool IsNameExists(string name, Int32 Id = 0)
        {
            bool bln = dal.IsNameExists(name, Id);
            return bln;
        }
        #endregion

        #region 添加库房
        /// <summary>
        /// 添加库房
        /// </summary>
        /// <param name="Mod">库房实体类</param>
        /// <param name="menu">菜单实体类</param>
        /// <returns></returns>
        public int AddWarehouse(EmsModel.Warehouse ware, EmsModel.MenuInfo menu)
        {
            try
            {
                //事务
                using (SqlTransaction trans = dal.GetTran())
                {
                    try
                    {
                        int result = new EmsDAL.MenuInfo().Add(trans, menu);
                        if (result <= 0)
                        {
                            trans.Rollback();//回滚
                            return 0;
                        }
                        result = dal.Add(trans,ware);
                        if (result <= 0)
                        {
                            trans.Rollback();//回滚
                            return 0;
                        }                                             
                        trans.Commit();//提交
                    }
                    catch (Exception)
                    {
                        trans.Rollback();//回滚
                        throw;
                    }
                }               
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        #endregion

        #region 编辑库房
        /// <summary>
        /// 编辑库房
        /// </summary>
        /// <param name="Mod">库房实体类</param>
        /// <param name="menu">菜单实体类</param>
        /// <returns></returns>
        public int EditWarehouse(EmsModel.Warehouse ware, EmsModel.MenuInfo menu)
        {
            try
            {
                //事务
                using (SqlTransaction trans = dal.GetTran())
                {
                    try
                    {
                        int result = new EmsDAL.MenuInfo().Update(trans, menu);                       
                        if (result <= 0)
                        {
                            trans.Rollback();//回滚
                            return 0;
                        }
                        result = dal.Update(trans, ware);
                        if (result <= 0)
                        {
                            trans.Rollback();//回滚
                            return 0;
                        }
                        trans.Commit();//提交
                    }
                    catch (Exception)
                    {
                        trans.Rollback();//回滚
                        throw;
                    }
                }
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        #endregion

        #region 删除库房
        /// <summary>
        /// 删除库房
        /// </summary>
        /// <param name="Mod">库房实体类</param>
        /// <param name="menu">菜单实体类</param>
        /// <returns></returns>
        public int DeleteWarehouse(EmsModel.Warehouse ware, EmsModel.MenuInfo menu)
        {
            try
            {
                //事务
                using (SqlTransaction trans = dal.GetTran())
                {
                    try
                    {
                        int result = new EmsDAL.MenuInfo().Delete(trans,menu.Id.ToString());
                        if (result <= 0)
                        {
                            trans.Rollback();//回滚
                            return 0;
                        }
                        result = dal.Update(trans,ware);
                        if (result <= 0)
                        {
                            trans.Rollback();//回滚
                            return 0;
                        }
                        trans.Commit();//提交
                    }
                    catch (Exception)
                    {
                        trans.Rollback();//回滚
                        throw;
                    }
                }
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        #endregion
    }
}
