using EmsModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace EmsBLL
{
    public partial class Role
    {
        #region 获得列表的JSON数据实体
        public EmsModel.JsonModel GetJsonModel(EmsModel.Role role)
        {
            //当前页
            int pageIndex = 1;
            //页容量
            int pageSize = 16;
            List<EmsModel.Role> modList = GetList(role);
            //定义分页数据实体
            PagedDataModel<EmsModel.Role> pagedDataModel = null;
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
                pagedDataModel = new PagedDataModel<EmsModel.Role>()
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
        public EmsModel.Role GetEmsModel(int? ID)
        {
            return dal.GetEmsModel(ID);
        }
        #endregion

        #region 获取泛型数据列表
        /// <summary>
        /// 获取泛型数据列表
        /// </summary>
        public List<EmsModel.Role> GetList(EmsModel.Role role)
        {
            return dal.GetList(role);
        }
        #endregion

        #region 判断角色名称是否已存在
        /// <summary>
        /// 判断角色名称是否已存在
        /// </summary>
        public bool IsNameExists(string name, Int32 Id=0)
        {
            bool bln = dal.IsNameExists(name, Id);
            return bln;
        }
        #endregion

        #region 获取全部角色，返回List
        /// <summary>
        /// 获取全部角色，返回List
        /// </summary>
        public List<EmsModel.Role> GetAllRoleList()
        {
            return dal.GetAllRoleList();     
        }
        #endregion

        #region 根据登录名获得所属角色
        /// <summary>
        /// 根据登录名获得所属角色
        /// </summary>
        /// <returns></returns>
        public DataTable GetRoleByUniqueNo(string loginname)
        {
            return dal.GetRoleByUniqueNo(loginname);
        }
        #endregion
    }
}
