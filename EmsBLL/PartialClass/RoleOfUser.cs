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
    public partial class RoleOfUser
    {
        BLLCommon common = new BLLCommon();
        #region 分页查询根据条件
        public JsonModel GetPage(Hashtable ht, bool ispage = true)
        {
            try
            {
                List<SqlParameter> pms = new List<SqlParameter>();
                int PageIndex = 0,PageSize = 0, PageCount=0, RowCount=0;
                if (ispage)
                {
                    //增加起始条数、结束条数
                    ht = common.AddStartEndIndex(ht);
                    PageIndex = Convert.ToInt32(ht["PageIndex"]);
                    PageSize = Convert.ToInt32(ht["PageSize"]);
                }
                DataTable modList = dal.GetPage(ht, ispage);
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

        #region 设置角色成员
        /// <summary>
        /// 设置角色成员
        /// </summary>
        /// <param name="roleid">角色id</param>
        /// <param name="loginnameStr">成员登录名字符串，以逗号连接</param>
        /// <returns>返回 影响行数</returns>
        public JsonModel SetRoleMember(string roleid, string loginnameStr)
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
                        string[] nameArray = loginnameStr.Split(',');
                        int count = 0,result = 0;
                        foreach (string name in nameArray)
                        {
                            EmsModel.RoleOfUser ru = new EmsModel.RoleOfUser();
                            ru.RoleId = Convert.ToInt32(roleid);
                            ru.LoginName = name;
                            result = dal.Add(trans,ru);
                            if (result > 0)
                            {
                                count++;
                            }
                        }
                        if (nameArray.Length != count)
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

        #region 删除关系数据， 删单条
        /// <summary>
        /// 删除关系数据， 删单条
        /// </summary>
        /// <returns>返回 影响行数</returns>
        public int DeleteUserRelation(EmsModel.RoleOfUser roleu)
        {
            int count = dal.DeleteUserRelation(roleu);
            return count;
        }

        #endregion
    }
}
