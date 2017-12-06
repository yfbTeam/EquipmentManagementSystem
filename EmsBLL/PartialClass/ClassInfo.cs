using EmsModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmsBLL
{
    public partial class ClassInfo
    {
        #region 获取班级列表数据 分页
        /// <summary>
        /// 获取班级列表数据 分页
        /// </summary>
        /// <param name="Mod">查询条件</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">页容量，每页显示条数</param>
        /// <returns></returns>
        public EmsModel.JsonModel GetJsonModel(EmsModel.ClassInfo Mod, int pageIndex, int pageSize)
        {
            List<EmsModel.ClassInfo> modList = dal.GetListByPageAndSear(Mod, ((pageIndex - 1) * pageSize) + 1, (pageIndex * pageSize));
            //定义分页数据实体
            PagedDataModel<EmsModel.ClassInfo> pagedDataModel = null;
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
                pagedDataModel = new PagedDataModel<EmsModel.ClassInfo>()
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
        public EmsModel.ClassInfo GetEmsModel(int? ID)
        {
            return dal.GetEmsModel(ID);
        }
        #endregion

        #region 判断班级名称是否已存在
        /// <summary>
        /// 判断班级名称是否已存在
        /// </summary>
        public bool IsNameExists(string name, Int32 Id = 0)
        {
            bool bln = dal.IsNameExists(name, Id);
            return bln;
        }
        #endregion
    }
}
