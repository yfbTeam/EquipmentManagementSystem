using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace EmsDAL
{
    public partial class SectionPlace : DALHelper
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
                sbSql4org.Append(" SELECT sp.* FROM SectionPlace sp ");
                sbSql4org.Append(" where 1=1 and sp.IsDelete=0 ");
                List<DbParameter> List = new List<DbParameter>();
                if (ht.ContainsKey("Name") && !string.IsNullOrEmpty(ht["Name"].ToString()))
                {
                    sbSql4org.Append(" and sp.Name like '%'+@Name+'%' ");
                    List.Add(dbHelper.CreateInDbParameter("@Name", DbType.String, ht["Name"].ToString()));
                }
                DataSet ds = base.GetListByPage("(" + sbSql4org.ToString() + ")", "", "UseStatus,T.ID desc", Convert.ToInt32(ht["StartIndex"] ?? "1"), Convert.ToInt32(ht["EndIndex"] ?? "10"), List.ToArray(), ispage);
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

        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public EmsModel.SectionPlace GetEmsModel(int? ID)
        {
            StringBuilder sbSql4org;
            DbParameter[] parms4org;
            sbSql4org = new StringBuilder();
            sbSql4org.Append("SELECT * FROM SectionPlace");
            sbSql4org.Append(" WHERE ID=@in_ID");

            parms4org = new DbParameter[]{
                dbHelper.CreateInDbParameter("@in_ID", DbType.Int32,ID)};
            using (DbDataReader dr = dbHelper.ExecuteReader(CommandType.Text, sbSql4org.ToString(), parms4org))
            {
                if (dr.Read())
                {
                    return GetEmsModel(dr);
                }
                return null;
            }
        }
        #endregion

        #region 判断科所名称是否已存在
        /// <summary>
        /// 判断科所名称是否已存在
        /// </summary>
        public bool IsNameExists(string name, Int32 Id)
        {
            try
            {
                StringBuilder sbSql;
                DbParameter[] parms;
                sbSql = new StringBuilder();
                sbSql.Append("SELECT COUNT(1) FROM SectionPlace");
                sbSql.Append(" where IsDelete=0 and Name=@Name ");
                if (Id != 0)
                {
                    sbSql.Append(" and Id!=@Id ");
                }
                parms = new DbParameter[]{
							dbHelper.CreateInDbParameter("@Name", DbType.String,name),
                            dbHelper.CreateInDbParameter("@Id",DbType.Int32,Id)
							};
                object obj = dbHelper.ExecuteScalar(CommandType.Text, sbSql.ToString(), parms);
                return int.Parse(obj.ToString()) > 0;
            }
            catch (Exception)
            {
                //写入日志
                //throw;
                return false;
            }
        }
        #endregion

        /// <summary>
        /// 获取科研所下拉菜单信息
        /// </summary>
        /// <param name="ht">查询条件</param>
        /// <returns>Model的List集合</returns>
        public DataTable GetDDInfo()
        {
            try
            {
                StringBuilder sbSql4org;

                sbSql4org = new StringBuilder();
                sbSql4org.Append(" select Id,Name from SectionPlace ");
                sbSql4org.Append(" where IsDelete<>1 ");
                DataSet ds = dbHelper.ExecuteQuery(CommandType.Text, sbSql4org.ToString());
                return ds.Tables[0];

            }
            catch (Exception)
            {
                //写入日志
                //throw;
                return null;
            }
        }

        #region -------- 私有方法 --------

        #region 由一行数据得到一个实体
        /// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        private EmsModel.SectionPlace GetEmsModel(DbDataReader dr)
        {
            EmsModel.SectionPlace EmsModel = new EmsModel.SectionPlace();
            DbDataReaderToModel(EmsModel, dr);

            return EmsModel;
        }
        #endregion

        #region 由DbDataReader得到泛型数据列表
        /// <summary>
        /// 由DbDataReader得到泛型数据列表
        /// </summary>
        private List<EmsModel.SectionPlace> GetList(DbDataReader dr)
        {
            List<EmsModel.SectionPlace> lst = new List<EmsModel.SectionPlace>();
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
