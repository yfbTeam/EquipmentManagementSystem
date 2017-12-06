using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace EmsDAL
{
    public partial class RoleOfUser : DALHelper
    {
        #region 获取泛型数据列表 分页
        ///<summary>
        ///获取泛型数据列表 分页
        /// </summary>
        public DataTable GetPage(Hashtable ht, bool ispage = true)
        {
            try
            {
                StringBuilder sbSql4org;
                sbSql4org = new StringBuilder();
                sbSql4org.Append(@" SELECT * FROM RoleOfUser where 1=1  ");                
                List<DbParameter> List = new List<DbParameter>();
                if (ht.ContainsKey("RoleId") && !string.IsNullOrEmpty(ht["RoleId"].ToString()))
                {
                    sbSql4org.Append(" and RoleId=@RoleId ");
                    List.Add(dbHelper.CreateInDbParameter("@RoleId", DbType.String, ht["RoleId"].ToString()));
                }
                DataSet ds = base.GetListByPage("(" + sbSql4org.ToString() + ")", "", "Id desc", Convert.ToInt32(ht["StartIndex"]??"1"), Convert.ToInt32(ht["EndIndex"]??"10"), List.ToArray(), ispage);
                int RowCount = base.GetRecordCount("(" + sbSql4org.ToString() + ") T", "", List.ToArray());
                ht.Add("RowCount", RowCount);
                return ds.Tables[0];

            }
            catch (Exception ex)
            {
                //写入日志
                //throw;
                return null;
            }
        }
        #endregion

        #region 删除关系数据， 删单条
        /// <summary>
        /// 删除关系数据， 删单条
        /// </summary>
        public int DeleteUserRelation(EmsModel.RoleOfUser roleu)
        {
            try
            {
                StringBuilder sbSql;
                DbParameter[] parms;

                sbSql = new StringBuilder();
                sbSql.Append("DELETE FROM RoleOfUser");
                sbSql.Append(" WHERE RoleId=@RoleId and LoginName=@LoginName");

                parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@RoleId", DbType.Int32,roleu.RoleId),dbHelper.CreateInDbParameter("@LoginName", DbType.String,roleu.LoginName)};
                return dbHelper.ExecuteNonQuery(CommandType.Text, sbSql.ToString(), parms);
            }
            catch (Exception)
            {
                //写入日志
                //throw;
                return 0;
            }
        }
        #endregion

        #region 获得事物对象
        /// <summary>
        /// 获得事物对象
        /// </summary>
        /// <returns></returns>
        public SqlTransaction GetTran()
        {
            return dbHelper.BeginTransaction();
        }
        #endregion

        #region -------- 私有方法 --------

        #region 由一行数据得到一个实体
        /// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        private EmsModel.RoleOfUser GetEmsModel(DbDataReader dr)
        {
            EmsModel.RoleOfUser EmsModel = new EmsModel.RoleOfUser();
            DbDataReaderToModel(EmsModel, dr);

            return EmsModel;
        }
        #endregion

        #region 由DbDataReader得到泛型数据列表
        /// <summary>
        /// 由DbDataReader得到泛型数据列表
        /// </summary>
        private List<EmsModel.RoleOfUser> GetList(DbDataReader dr)
        {
            List<EmsModel.RoleOfUser> lst = new List<EmsModel.RoleOfUser>();
            while (dr.Read())
            {
                lst.Add(GetEmsModel(dr));
            }
            return lst;
        }
        #endregion

        #endregion
    }
}
