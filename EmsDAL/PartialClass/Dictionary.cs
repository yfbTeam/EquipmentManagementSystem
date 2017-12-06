using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace EmsDAL
{
    public partial class Dictionary : DALHelper
    {
        /// <summary>
        /// 获取指定名称的子项
        /// </summary>
        /// <param name="Name">父级名称</param>
        /// <returns>子项集</returns>
        public List<EmsModel.Dictionary> GetList(string Name)
        {
            try
            {
                StringBuilder sbSql4org;
                DbParameter[] parms4org;

                sbSql4org = new StringBuilder();
                sbSql4org.Append("SELECT a.* FROM Dictionary a left join Dictionary b on a.PID=b.Id ");
                sbSql4org.Append(" where b.Name=@in_Name ");

                parms4org = new DbParameter[]{
							dbHelper.CreateInDbParameter("@in_Name", DbType.String, Name)
							};

                DataSet ds = dbHelper.ExecuteQuery(CommandType.Text, sbSql4org.ToString(), parms4org);
                return GetList(ds.Tables[0]);
            }
            catch (Exception)
            {
                //写入日志
                //throw;
                return null;
            }
        }
        /// <summary>
        /// 获取指定项
        /// </summary>
        /// <param name="ht">父级名称</param>
        /// <returns>子项集</returns>
        public List<EmsModel.Dictionary> GetList(Hashtable ht)
        {
            try
            {
                StringBuilder sbSql4org;

                sbSql4org = new StringBuilder();
                sbSql4org.Append("SELECT a.* FROM Dictionary a left join Dictionary b on a.PID=b.Id ");
                sbSql4org.Append(" where 1=1 ");
                List<DbParameter> List = new List<DbParameter>();
                if (ht.Contains("Name"))
                {
                    sbSql4org.Append(" and b.Name=@in_Name ");
                    List.Add(dbHelper.CreateInDbParameter("@in_Name", DbType.String, ht["Name"].ToString()));
                }

                DataSet ds = dbHelper.ExecuteQuery(CommandType.Text, sbSql4org.ToString(), List.ToArray());
                return GetList(ds.Tables[0]);
            }
            catch (Exception)
            {
                //写入日志
                //throw;
                return null;
            }
        }
        /// <summary>
        /// 获取指定Id的数据
        /// </summary>
        /// <param name="Id">Id</param>
        /// <returns>Model</returns>
        public List<EmsModel.Dictionary> GetModel(string Id)
        {
            try
            {
                StringBuilder sbSql4org;
                DbParameter[] parms4org;

                sbSql4org = new StringBuilder();
                sbSql4org.Append("SELECT * FROM Dictionary ");
                sbSql4org.Append(" where Id=@in_Id ");

                parms4org = new DbParameter[]{
							dbHelper.CreateInDbParameter("@in_Id", DbType.Int32, Id)
							};

                DataSet ds = dbHelper.ExecuteQuery(CommandType.Text, sbSql4org.ToString(), parms4org);
                return GetList(ds.Tables[0]);
            }
            catch (Exception)
            {
                //写入日志
                throw;
            }
        }

    }
}
