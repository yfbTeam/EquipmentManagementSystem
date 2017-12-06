using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace EmsDAL
{
    public partial class RoleOfMenu : DALHelper
    {
        #region 根据角色id获得角色下的菜单
        /// <summary>
        /// 根据角色id获得角色下的菜单
        /// </summary>
        /// <returns></returns>
        public List<EmsModel.RoleOfMenu> GetMenusByRoleid(string roleid)
        {
            StringBuilder sbSql4org;
            DbParameter[] parms4org;

            sbSql4org = new StringBuilder();
            sbSql4org.Append("SELECT * FROM RoleOfMenu where RoleId=@RoleId ");
            parms4org = new DbParameter[]{
                dbHelper.CreateInDbParameter("@RoleId", DbType.Int32, roleid)};

            using (DbDataReader dr = dbHelper.ExecuteReader(CommandType.Text, sbSql4org.ToString(), parms4org))
            {
                List<EmsModel.RoleOfMenu> lst = GetList(dr);
                return lst;
            }
        }
        #endregion

        #region 根据角色id删除角色下的菜单
        /// <summary>
        /// 根据角色id删除角色下的菜单
        /// </summary>
        /// <param name="roleid">角色id</param>
        /// <returns>返回 影响行数</returns>
        public int DelMenusByRoleid(string roleid, SqlTransaction trans)
        {
            try
            {
                StringBuilder sbSql;
                DbParameter[] parms;

                sbSql = new StringBuilder();
                sbSql.Append("DELETE FROM RoleOfMenu");
                sbSql.Append(" WHERE RoleId=@RoleId ");

                parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@RoleId", DbType.Int32, roleid)};
                if (trans == null)
                {
                    return dbHelper.ExecuteNonQuery(CommandType.Text, sbSql.ToString(), parms);
                }
                else
                {
                    return dbHelper.ExecuteNonQuery(trans, CommandType.Text, sbSql.ToString(), parms);
                }
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
        private EmsModel.RoleOfMenu GetEmsModel(DbDataReader dr)
        {
            EmsModel.RoleOfMenu EmsModel = new EmsModel.RoleOfMenu();
            DbDataReaderToModel(EmsModel, dr);

            return EmsModel;
        }
        #endregion

        #region 由DbDataReader得到泛型数据列表
        /// <summary>
        /// 由DbDataReader得到泛型数据列表
        /// </summary>
        private List<EmsModel.RoleOfMenu> GetList(DbDataReader dr)
        {
            List<EmsModel.RoleOfMenu> lst = new List<EmsModel.RoleOfMenu>();
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
